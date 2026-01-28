using JAKA_TESTAPP.JakaControlDemo;
using System.Globalization;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Text.Json;

namespace JAKA_TESTAPP
{
    public class JakaRobot : IDisposable
    {
        #region JakaRobot相关定义

        private readonly string _ip;                 //readonly--->仅在声明时或者构造函数中赋值
        private TcpClient _cmdClient;                // 10001：发送控制指令到服务器端口
        private TcpClient _stateClient;              // 10000：从服务器端口接收机器人状态
        private NetworkStream _cmdStream;            // 控制指令流
        private NetworkStream _stateStream;          // 状态流
        private byte _gripperSlaveId = 1; // PGC 夹爪默认站号
        private int currentChnId = 1;

        public string statemessage { get; private set; }    //UI状态信息
        private Dictionary<string, double[]> _positionDict = new Dictionary<string, double[]>();//Txt文件坐标信息


        public bool IsConnected { get; private set; }  //是否连接成功
        public bool Inpos { get; private set; }    //是否到达指定位置

        public bool IsCommandsended { get; private set; }    //是否发送完所有指令


        //执行日志信息
        public event Action<string> OnLogReceived;
        public List<string> Log { get; private set; } = new List<string>();


        private bool _isRunning;                     //是否获取控制后台任务的运行状态
        private CancellationTokenSource _cts;        //协作式取消（获取取消令牌）

        public RobotState CurrentState { get; private set; } = new RobotState();    // 存储最新的机器人状态

        public JakaRobot(string ip)
        {
            _ip = ip;                                       //将机器人实际IP地址赋值给_ip
        }
        #endregion

        #region 连接机器人
        // 连接机器人
        public async Task ConnectRobot()
        {
            try
            {
                //连接至指令端口10001
                _cmdClient = new TcpClient();
                await _cmdClient.ConnectAsync(_ip, 10001);//await--->异步方法,不会阻塞主线程 _
                _cmdStream = _cmdClient.GetStream();

                // 连接至状态端口10000
                _stateClient = new TcpClient();
                await _stateClient.ConnectAsync(_ip, 10000);
                _stateStream = _stateClient.GetStream();

                AddLog("机器人连接成功！");

                // 启动后台任务监控状态
                _isRunning = true;
                _cts = new CancellationTokenSource();                 //通过调用_cts.Cancel()可以通知任务需要停止
                _ = Task.Run(() => MonitorStateLoop(_cts.Token));     //使用"_"丢弃返回的Task对象，表示我们不关心任务的返回值，_cts.Token作为参数传递给MonitorStateLoop方法，以便在需要时取消任务
                IsConnected = true;
            }
            catch (Exception ex)
            {
                IsConnected = false;
                AddLog($"连接失败: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region 后台监控

        // 后台循环监控：读取10000端口的JSON流，解析并更新机器人状态
        private async Task MonitorStateLoop(CancellationToken token)
        {
            StringBuilder sb = new StringBuilder();
            byte[] buffer = new byte[16384];

            while (_isRunning && !token.IsCancellationRequested)
            {
                try
                {
                    int bytesRead = await _stateStream.ReadAsync(buffer, 0, buffer.Length, token);
                    if (bytesRead > 0)
                    {
                        string chunk = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                        // 遍历字符，利用花括号计数来提取完整的 JSON 对象
                        foreach (char c in chunk)
                        {
                            sb.Append(c);
                            if (c == '}')
                            {
                                string potentialJson = sb.ToString();
                                // 简单的完整性检查：花括号数量匹配
                                if (IsValidJsonStructure(potentialJson))
                                {
                                    ProcessJson(potentialJson);
                                    sb.Clear(); // 清空缓冲区，准备接收下一个包
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (_isRunning)
                    {
                        AddLog($"[监控异常] {ex.Message}");
                        throw new Exception(ex.Message);
                    }
                }
                await Task.Delay(20);
            }
        }

        // 检查花括号是否闭合
        private bool IsValidJsonStructure(string str)
        {
            int open = 0;
            foreach (char c in str)
            {
                if (c == '{') open++;
                if (c == '}') open--;
            }
            return open == 0 && str.Trim().StartsWith("{") && str.Trim().EndsWith("}");
        }

        private void ProcessJson(string json)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString
                };

                var newState = JsonSerializer.Deserialize<RobotState>(json, options);

                if (newState != null)
                {
                    CurrentState = newState;

                    // --- 调试重点：如果关键数据为空，打印原始 JSON ---
                    if (newState.JointActualPosition == null)
                    {
                        AddLog($"[警告] 收到 JSON 但无关节数据! 原始内容: {json.Substring(0, Math.Min(json.Length, 100))}...");
                        throw new Exception($"[警告] 收到 JSON 但无关节数据! 原始内容: {json.Substring(0, Math.Min(json.Length, 100))}...");
                    }
                }
            }
            catch (JsonException ex)
            {
                AddLog($"[解析失败] JSON格式错误: {ex.Message}");
                throw new Exception($"[解析失败] JSON格式错误: {ex.Message}");
            }
        }
        #endregion

        #region 发送指令

        // 发送指令通用方法
        public string SendCommand(object cmdObj, bool throwOnError = true)
        {
            if (_cmdClient == null || !_cmdClient.Connected) return "未连接";

            try
            {
                // 序列化指令
                string jsonCmd = JsonSerializer.Serialize(cmdObj);
                byte[] data = Encoding.UTF8.GetBytes(jsonCmd);
                _cmdStream.Write(data, 0, data.Length);   //data将指令发送到指令流

                // 接收反馈
                byte[] buffer = new byte[4096];        //4096字节=4KB
                int bytesRead = _cmdStream.Read(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                // 解析错误码
                var respObj = JsonSerializer.Deserialize<CommandResponse>(response);
                if (respObj.ErrorCode.ToString() == "0")
                {
                    AddLog($"发送指令成功: {respObj.CmdName}");
                }
                else
                {
                    AddLog($"发送指令错误 [{respObj.ErrorCode}]: {respObj.ErrorMsg}");
                    if (throwOnError)
                        throw new Exception(respObj.ErrorMsg);
                }
                return response;
            }
            catch (Exception ex)
            {
                AddLog($"发送指令异常: {ex.Message}");
                if (throwOnError)
                    throw;
                return null;
            }
        }
        #endregion

        #region 基本功能
        //PowerOn、EnableRobot、MoveJ、MoveL、End_Move、Home_Move
        // 上电
        public async Task PowerOn()
        {
            int Choice;
            if (CurrentState.PoweredOn == 0)
            {
                Choice = 0;
            }
            else
            {
                Choice = 1;
            }
            switch (Choice)
            {
                case 0:
                    AddLog("上电...");
                    SendCommand(new { cmdName = "power_on" });
                    await Task.Delay(15000);
                    if (CurrentState.PoweredOn == 1)
                    {
                        AddLog("上电成功");
                    }
                    else
                    {
                        AddLog("上电失败");
                    }
                    break;
                case 1:
                    AddLog("下电...");
                    SendCommand(new { cmdName = "power_off" });
                    await Task.Delay(15000);
                    if (CurrentState.PoweredOn == 0)
                    {
                        AddLog("下电成功");
                    }
                    else
                    {
                        AddLog("下电失败");
                    }
                    break;
            }
        }

        // 上使能
        public async Task EnableRobot()
        {
            int Choice;
            if (CurrentState.Enabled == false)
                Choice = 0;
            else
                Choice = 1;
            switch (Choice)
            {
                case 0:
                    AddLog("上使能...");
                    SendCommand(new { cmdName = "enable_robot" });
                    await Task.Delay(15000);
                    if (CurrentState.Enabled == true)
                    {
                        AddLog("上使能成功");
                    }
                    else
                    {
                        AddLog("上使能失败");
                    }
                    break;
                case 1:
                    AddLog("下使能...");
                    SendCommand(new { cmdName = "disable_robot" });
                    await Task.Delay(15000);
                    if (CurrentState.Enabled == false)
                    {
                        AddLog("下使能成功");
                    }
                    else
                    {
                        AddLog("下使能失败");
                    }
                    break;

            }
        }

        // 关节运动 MoveJ
        public async Task MoveJ(double[] jointPos, double speed, double accel)
        {
            var cmd = new
            {
                cmdName = "joint_move",
                relFlag = 0, // 0=绝对运动
                jointPosition = jointPos,     //[j1,j2,j3,j4,j5,j6]填入的是每一个关节的角度值

                speed = speed,                //单位：°/S
                accel = accel                 //单位：°/S^2
            };
            SendCommand(cmd);
            await WaitForMotionComplete();
        }

        // 直线运动 MoveL
        public async Task MoveL(double X, double Y, double Z, double RX, double RY, double RZ)
        {
            double[] endPos = { X, Y, Z, RX, RY, RZ };
            double speed = 20;
            double accel = 10;
            var cmd = new
            {
                cmdName = "moveL",
                relFlag = 0, // 0=绝对运动
                cartPosition = endPos,       //[x,y,z,rx,ry,rz]指定笛卡尔空间x,y,z,rx,ry,rz的值
                speed = speed,                //单位：mm/s
                accel = accel                 //单位：mm/s^2
            };
            SendCommand(cmd);
            await WaitForMotionComplete();
        }

        //TCP末端运动到指定位置
        public async Task TCP_Move(double X, double Y, double Z, double RX, double RY, double RZ)
        {
            double[] endPos = { X, Y, Z, RX, RY, RZ };
            double speed = 20;
            double accel = 10;
            var cmd = new
            {
                cmdName = "end_move",
                endPosition = endPos,       //[x,y,z,rx,ry,rz]指定笛卡尔空间x,y,z,rx,ry,rz的值
                speed = speed,                //单位：°/S
                accel = accel                 //单位：°/S^2
            };
            SendCommand(cmd);
            await WaitForMotionComplete();
        }
        public async Task Home_Move()
        {
            double[] homePosition = { 684, 127, 100, 180, 0, 0 };
            //double[] homePosition = { -200, -466.5, 118, 180, 0, 150 };
            var cmd = new
            {
                cmdName = "end_move",
                endPosition = homePosition,     //[x,y,z,rx,ry,rz]指定笛卡尔空间x,y,z,rx,ry,rz的值
                speed = 20,                //单位：°/S
                accel = 10                //单位：°/S^2
            };
            SendCommand(cmd);
            await WaitForMotionComplete();
        }

        // 停止运动
        public void Stop() => SendCommand(new { cmdName = "stop_program" });

        public void Dispose()
        {
            _isRunning = false;
            IsConnected = false;
            _cts?.Cancel();
            _cts?.Dispose();
            _cts = null;
            _cmdClient?.Close();
            _stateClient?.Close();

        }

        //WorkTask
        public async Task WorkTask(double X, double Y, double Z, double RX, double RY, double RZ)
        {
            double[] homePos = { 500, 0, 350, 180, 0, -115 };
            double moveheight = 350;
            double Grip = 60;
            double[] SafePos = CurrentState.ActualPosition.ToArray();
            //打开夹爪并移动到物体上方,关闭夹爪
            await GripperMove(1000, 30, 50);
            await TCP_Move(SafePos[0], SafePos[1], Grip, SafePos[3], SafePos[4], SafePos[5]);
            await GripperMove(0, 30, 50);
            //移动到安全高度
            await TCP_Move(SafePos[0], SafePos[1], moveheight, SafePos[3], SafePos[4], SafePos[5]);
            await Task.Delay(500);
            //移动到目标点上方
            await TCP_Move(X, Y, moveheight, RX, RY, RZ);
            await Task.Delay(500);
            //下降并打开夹爪
            await TCP_Move(X, Y, Grip, RX, RY, RZ);
            await GripperMove(1000, 30, 50);
            await Task.Delay(500);
            //移动到目标点上方,并回到中转位置
            await TCP_Move(X, Y, moveheight, RX, RY, RZ);
            await TCP_Move(homePos[0], homePos[1], homePos[2], homePos[3], homePos[4], homePos[5]);
        }
        //选择工具坐标系
        public async Task SetCurrentToolId(int id)
        {
            try
            {
                var cmd = new
                {
                    cmdName = "set_tool_id",        // 指令名称 
                    tool_id = id                    // 工具坐标系 ID 号
                };

                SendCommand(cmd);
                await Task.Delay(2000);
                if (CurrentState.CurrentToolId == id)
                {
                    AddLog($"工具坐标系{id}选择成功");
                }
            }
            catch (Exception ex)
            {
                AddLog($"工具坐标系{id}选择失败: {ex.Message}");
            }
        }
        //设置工具坐标系
        public async Task SetToolCoordinate(int id, string toolName, double X, double Y, double Z, double RX, double RY, double RZ)
        {
            double[] offsets = [X, Y, Z, RX, RY, RZ];
            var cmd = new
            {
                cmdName = "set_tool_offsets",   // 指令名称 
                tooloffset = offsets,           // [x,y,z,rx,ry,rz] 填入工具坐标系的偏移值
                id = id,                        // 想要设置的工具坐标系 ID (1-15)
                name = toolName                 // 工具名称
            };
            SendCommand(cmd);
            AddLog($"工具坐标系{id}设置成功");
            await Task.Delay(500);
        }
        #endregion

        #region 安全
        //碰撞等级设置
        public async Task SecurityInitialize(int safetyLevel)
        {
            try
            {
                AddLog("正在进行安全参数初始化...");

                // 设置机器人碰撞等级
                // 可选值 0-7，1代表灵敏度最高（最安全），0代表关闭
                var collisionCmd = new { cmdName = "set_clsn_sensitivity", sensitivityVal = safetyLevel };
                SendCommand(collisionCmd);
                await Task.Delay(500); // 给控制器一点处理时间
                AddLog($"碰撞灵敏度已设置为: {safetyLevel} (1-7, 1最灵敏)");

                // 设置机器人全局速度倍率
                // 范围 0 到 1，默认 1 
                double limitRate = 1;
                var rateCmd = new { cmdName = "rapid_rate", rate_value = limitRate };
                SendCommand(rateCmd);
                await Task.Delay(500); // 给控制器一点处理时间
                AddLog($"全局运动倍率已设置为: {limitRate * 100}%");

                // 设置运动规划器为S规划，使运动更平稳 
                var plannerCmd = new { cmdName = "set_motion_planner", type = 1 };
                SendCommand(plannerCmd);
                AddLog("运动规划器设置为S规划");

                await Task.Delay(1000); // 给控制器一点处理时间
                AddLog("安全初始化完成");
            }
            catch (Exception ex)
            {
                AddLog($"安全初始化失败: {ex.Message}");
            }
        }
        // 设置运动限制（奇异点和关节限位）预警范围
        // rangeLevel: 范围等级，1-5 (1为默认，范围最小/最敏感；5范围最大/最不敏感)
        public async Task SetMotionLimitWarningRange(int rangeLevel)
        {
            if (rangeLevel < 1 || rangeLevel > 5)
            {
                AddLog("预警范围等级必须在 1 到 5 之间");
                throw new Exception("预警范围等级必须在 1 到 5 之间");
            }

            var cmd = new
            {
                cmdName = "set_motion_limit_warning_range",
                range_level = rangeLevel
            };
            SendCommand(cmd);
            await Task.Delay(500); // 给控制器一点处理时间
            AddLog($"已发送预警范围设置指令，等级: {rangeLevel}");
            await Task.Delay(500);
        }

        // 获取当前运动限制预警范围
        public void GetMotionLimitWarningRange()
        {
            var cmd = new { cmdName = "get_motion_limit_warning_range" };
            string response = SendCommand(cmd);

            // 解析并打印结果
            if (!string.IsNullOrEmpty(response))
            {
                try
                {
                    using (JsonDocument doc = JsonDocument.Parse(response))
                    {
                        if (doc.RootElement.TryGetProperty("range_level", out JsonElement levelElement))
                        {
                            AddLog($"当前运动限制预警范围等级: {levelElement.GetInt32()}");
                        }
                    }
                }
                catch (Exception e)
                {
                    AddLog($"解析响应失败: {e.Message}");
                }
            }
        }
        #endregion

        #region 状态更新频率
        public void SetStatusRate(int ms) => SendCommand(new { cmdName = "set_port10000_delay_ms", port10000_delay_ms = ms });
        #endregion

        #region 位置判断
        // 等待机器人运动完成
        // timeoutMs: 超时时间，防止程序死锁
        private async Task WaitForMotionComplete()
        {
            int timeoutMs = 600000;
            await Task.Delay(500);
            int elapsedTime = 0;
            int checkInterval = 50;

            while (!CurrentState.Inpos)
            {
                if (!string.IsNullOrWhiteSpace(CurrentState.Errmsg))
                {
                    AddLog($"机器人发生内部错误，错误信息: {CurrentState.Errmsg}");
                    string MS = CurrentState.Errcode.GetRobotErrorDescription();
                    throw new Exception($"机器人发生内部错误，错误信息: {MS}");
                }
                if (CurrentState.ProtectiveStop == 1)
                {
                    AddLog("检测到保护性停止！(ProtectiveStop=1)");
                    throw new Exception("检测到保护性停止！(ProtectiveStop=1)");
                }
                if (!CurrentState.Enabled || CurrentState.PoweredOn == 0)
                {
                    AddLog("机器人未使能或掉电！");
                    throw new Exception("机器人未使能或掉电");
                }
                await Task.Delay(checkInterval);
                if (!CurrentState.Paused)
                {
                    elapsedTime += checkInterval;
                }
                if (elapsedTime >= timeoutMs)
                {
                    throw new TimeoutException("TIMEOUT: 等待运动到位超时！");
                }
            }
            await Task.Delay(1000);
            AddLog("机器人已到位!");
        }
        #endregion      

        #region 反馈开启和日志触发
        public static void FeedBacksControl(JakaRobot robot)
        {
            robot.SendCommand(new { cmdName = "setOptionalInfoConfig", section = "ATTROPTIONALDATA", key = "joint_actual_position", value = 1 });//开启关节位置反馈
            robot.SendCommand(new { cmdName = "setOptionalInfoConfig", section = "ATTROPTIONALDATA", key = "actual_position", value = 1 });      //开启笛卡尔位置反馈
            robot.SendCommand(new { cmdName = "setOptionalInfoConfig", section = "ATTROPTIONALDATA", key = "powered_on", value = 1 });           //开启上电状态反馈
            robot.SendCommand(new { cmdName = "setOptionalInfoConfig", section = "ATTROPTIONALDATA", key = "enabled", value = 1 });              //开启使能状态反馈
            robot.SendCommand(new { cmdName = "setOptionalInfoConfig", section = "ATTROPTIONALDATA", key = "inpos", value = 1 });                //开启到位状态反馈
            robot.SendCommand(new { cmdName = "setOptionalInfoConfig", section = "ATTROPTIONALDATA", key = "task_mode", value = 1 });            //开启机器人模式反馈
            //robot.SendCommand(new { cmdName = "setOptionalInfoConfig", section = "ATTROPTIONALDATA", key = "errmsg", value = 1 });               //开启错误信息反馈
            robot.SendCommand(new { cmdName = "setOptionalInfoConfig", section = "ATTROPTIONALDATA", key = "protective_stop", value = 1 });               //保护性停止
        }
        public void AddLog(string msg)
        {
            Log.Add(msg);
            OnLogReceived?.Invoke(msg);
        }
        #endregion

        #region 保护性停止恢复
        public async Task Recover(JakaRobot robot)
        {
            try
            {
                AddLog(">>> 正在执行恢复程序 <<<");

                if (CurrentState.Errmsg != "")
                {
                    AddLog("发送Clear_Error指令，错误信息清除...");
                    SendCommand(new { cmdName = "clear_error" });
                    await Task.Delay(5000);
                    int retryCount = 0;
                    while (!string.IsNullOrWhiteSpace(CurrentState.Errmsg))
                    {
                        AddLog($"等待错误清除... 当前错误信息: {CurrentState.Errmsg}");
                        await Task.Delay(500);
                        retryCount++;
                        if (retryCount > 10) // 等待5秒还不好
                        {
                            throw new Exception("恢复失败：无法清除机器人错误状态，请检查急停按钮或硬件连接！");
                        }
                    }
                }
                if (CurrentState.ProtectiveStop == 1)
                {
                    AddLog("发送Clear_Error指令，保护性停止解除...");
                    SendCommand(new { cmdName = "clear_error" });
                    await Task.Delay(5000);
                    int retryCount1 = 0;
                    while (CurrentState.ProtectiveStop == 1)
                    {
                        AddLog($"等待保护性停止恢复... 当前状态: {CurrentState.ProtectiveStop}");
                        await Task.Delay(500);
                        retryCount1++;
                        if (retryCount1 > 10) // 等待5秒还不好
                        {
                            throw new Exception("恢复失败：无法恢复保护性停止状态，请检查急停按钮或硬件连接！");
                        }
                    }
                }
                if (CurrentState.PoweredOn != 1)
                {
                    AddLog("检测到未上电，正在重新上电...");
                    await PowerOn();
                    await Task.Delay(5000);
                }
                if (!CurrentState.Enabled)
                {
                    AddLog("检测到未使能，正在重新使能...");
                    await EnableRobot();
                    await Task.Delay(5000);
                }
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                AddLog($"恢复失败原因: {ex.Message}");
            }
        }
        #endregion

        #region TXT坐标读取
        public void LoadCoordinates(string filePath = "E:\\Visual Studio Community 2022\\JAKA_TESTAPP\\JAKA_TESTAPP\\positions.txt")
        {
            _positionDict.Clear();

            // 检查文件是否存在
            if (!File.Exists(filePath))
            {
                //statemessage = ($"错误: 找不到坐标文件 {filePath}，请确保文件在程序运行目录下。");
                AddLog($"错误: 找不到坐标文件 {filePath}，请确保文件在程序运行目录下。");
                return;
            }

            try
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    // 跳过空行或注释
                    if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#")) continue;

                    // 解析格式: Name=x,y,z,rx,ry,rz
                    var parts = line.Split('=');
                    if (parts.Length == 2)
                    {
                        string name = parts[0].Trim();
                        string[] valStrs = parts[1].Split(',');

                        if (valStrs.Length == 6)
                        {
                            double[] coords = new double[6];
                            for (int i = 0; i < 6; i++)
                            {
                                coords[i] = double.Parse(valStrs[i].Trim());
                            }
                            _positionDict[name] = coords;
                        }
                    }
                }
                //statemessage = ($"成功加载坐标点: {_positionDict.Count} 个");
                AddLog($"成功加载坐标点: {_positionDict.Count} 个");
            }
            catch (Exception ex)
            {
                //statemessage = ($"解析坐标文件失败: {ex.Message}");
                AddLog($"解析坐标文件失败: {ex.Message}");
            }
        }

        // 辅助方法：根据名字获取坐标
        private double[] GetPositionByName(string name)
        {
            if (_positionDict.ContainsKey(name))
            {
                return _positionDict[name];
            }
            else
            {
                //statemessage = ($"错误: 未在文件中找到点位 [{name}]");
                AddLog($"错误: 未在文件中找到点位 [{name}]");
                return null;
            }
        }
        #endregion

        #region 暂停恢复程序
        public async Task PauseProgram()
        {
            AddLog("正在暂停程序...");
            try
            {
                SendCommand(new { cmdName = "pause_program" });
                await Task.Delay(1000);
                if (CurrentState.Paused == true)
                    AddLog("程序暂停成功！");
                else
                {
                    AddLog("程序暂停失败！强制下使能及下电...");
                    SendCommand(new { cmdName = "disable_robot" });
                    await Task.Delay(6000);
                    SendCommand(new { cmdName = "power_off" });
                    await Task.Delay(6000);
                    if (CurrentState.PoweredOn == 0 && CurrentState.Enabled == false)
                        AddLog("下使能及下电成功！");
                }
            }
            catch (Exception ex)
            {
                AddLog($"暂停失败原因: {ex.Message}");
            }
        }
        public async Task ResumeProgram()
        {
            AddLog("正在恢复程序...");
            try
            {
                SendCommand(new { cmdName = "resume_program" });
                await Task.Delay(1000);
                if (CurrentState.Paused == false)
                {
                    //statemessage = "程序恢复成功！";
                    AddLog("程序恢复成功！");
                }
                else
                {
                    //statemessage = "程序恢复失败！";
                    AddLog("程序恢复失败！");
                }
            }
            catch (Exception ex)
            {
                //statemessage = ($"恢复失败原因: {ex.Message}");
                AddLog($"恢复失败原因: {ex.Message}");
            }
        }
        #endregion

        #region 运动学逆解
        public async Task<bool> CheckCoordinateReachable(double x, double y, double z, double rx, double ry, double rz)
        {
            try
            {
                // 1. 获取当前关节作为参考
                if (CurrentState.JointActualPosition == null || CurrentState.JointActualPosition.Count < 6)
                {
                    AddLog("错误：无法获取当前关节数据作为逆解参考");
                    return false;
                }
                double[] refJoints = CurrentState.JointActualPosition.ToArray();

                // 2. 构造指令
                var cmd = new
                {
                    cmdName = "kine_inverse",
                    jointPosition = refJoints, // 参考关节角
                    cartPosition = new double[] { x, y, z, rx, ry, rz } // 目标笛卡尔
                };

                // 3. 发送指令，关键：设置 throwOnError = false，因为不可达也是一种正常结果，不要崩
                // 注意：这里其实不需要 await Task.Delay，因为 SendCommand 是同步阻塞读取返回值的
                // 如果想完全不卡UI，SendCommand 内部应该用 ReadAsync，但这里为了简单先保持同步
                string response = await Task.Run(() => SendCommand(cmd, false));

                if (string.IsNullOrEmpty(response)) return false;

                // 4. 解析具体返回数据
                using (JsonDocument doc = JsonDocument.Parse(response))
                {
                    var root = doc.RootElement;

                    // 提取错误码
                    if (root.TryGetProperty("errorCode", out JsonElement errElem))
                    {
                        string errStr = errElem.ToString();

                        // 0 或 "0x0" 代表成功
                        if (errStr == "0" || errStr == "0x0")
                        {
                            // 再次确认是否包含关节数据
                            if (root.TryGetProperty("jointPosition", out JsonElement jointPosElem))
                            {
                                AddLog($"逆解成功! 目标点可达。");
                                return true;
                            }
                        }
                        else
                        {
                            // 如果是 -16 (正解失败/无解) 或 -12 (运动超限) 等
                            // 这里可以利用您之前写的扩展方法显示具体原因
                            string errDesc = errStr.GetRobotErrorDescription();
                            AddLog($"逆解结果: 不可达 (代码: {errStr}, 原因: {errDesc})");
                            return false;
                        }
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                // 只有真正的通信错误（如网线断了）才会进入这里
                AddLog($"逆解校验发生系统异常: {ex.Message}");
                return false;
            }
        }
        #endregion

        #region 夹爪配合
        private void SendTioRsCommand(byte[] frame)
        {
            // 将 byte 数组转换为 int 数组 (16进制 -> 10进制)
            int[] decimalCmdBuf = frame.Select(b => (int)b).ToArray();

            // 构造指令对象
            // 注意：cmdBuf 字段名必须与协议严格一致
            var cmd = new
            {
                cmdName = "send_tio_rs_command",
                chn_id = currentChnId,
                cmdBuf = decimalCmdBuf,
            };

            // 发送
            SendCommand(cmd);
        }
        //初始化夹爪
        public async Task GripperInitialize()
        {
            AddLog("正在初始化夹爪...");

            // 构建 Modbus RTU 报文: 写入寄存器 0x0100 (256) 值 1
            byte[] frame = BuildModbusRTUWriteSingle(_gripperSlaveId, 0x0100, 1);

            SendTioRsCommand(frame);

            await Task.Delay(5000); // 等待初始化动作完成
            AddLog("夹爪初始化指令已发送");
        }
        //控制夹爪动作
        public async Task GripperMove(int position, int force, int speed)
        {
            // 限制范围
            position = Math.Clamp(position, 0, 1000);
            force = Math.Clamp(force, 20, 100);
            speed = Math.Clamp(speed, 1, 100);

            // (1) 设置力值 (地址 0x0101)
            byte[] frameForce = BuildModbusRTUWriteSingle(_gripperSlaveId, 0x0101, (ushort)force);
            SendTioRsCommand(frameForce);
            await Task.Delay(200);

            // (2) 设置速度 (地址 0x0104)
            byte[] frameSpeed = BuildModbusRTUWriteSingle(_gripperSlaveId, 0x0104, (ushort)speed);
            SendTioRsCommand(frameSpeed);
            await Task.Delay(200);

            // (3) 设置位置 (地址 0x0103)
            byte[] framePos = BuildModbusRTUWriteSingle(_gripperSlaveId, 0x0103, (ushort)position);
            SendTioRsCommand(framePos);
            await Task.Delay(2000);
            AddLog($"夹爪动作: Pos={position / 10.0}%, Force={force}%, Speed={speed}%");
        }
        //辅助函数
        private byte[] BuildModbusRTUWriteSingle(byte slaveId, ushort address, ushort value)
        {
            List<byte> frame = new List<byte>();
            frame.Add(slaveId);
            frame.Add(0x06); // Write Single Register
            frame.Add((byte)(address >> 8));
            frame.Add((byte)(address & 0xFF));
            frame.Add((byte)(value >> 8));
            frame.Add((byte)(value & 0xFF));

            byte[] crc = Crc16.Calculate(frame.ToArray());
            frame.Add(crc[0]);
            frame.Add(crc[1]);

            return frame.ToArray();
        }
        //校验
        public static class Crc16
        {
            public static byte[] Calculate(byte[] data)
            {
                ushort crc = 0xFFFF;

                for (int i = 0; i < data.Length; i++)
                {
                    crc ^= data[i];
                    for (int j = 0; j < 8; j++)
                    {
                        if ((crc & 0x0001) != 0)
                        {
                            crc >>= 1;
                            crc ^= 0xA001;
                        }
                        else
                        {
                            crc >>= 1;
                        }
                    }
                }

                // Modbus CRC 是低字节在前，高字节在后
                return new byte[] { (byte)(crc & 0xFF), (byte)(crc >> 8) };
            }
        }
        #endregion
    }
}