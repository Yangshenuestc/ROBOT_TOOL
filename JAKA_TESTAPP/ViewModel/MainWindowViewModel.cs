using JAKA_TESTAPP.JakaControlDemo;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Threading;

namespace JAKA_TESTAPP.ViewModel
{
    public class MainWindowViewModel : MvvmCore
    {
        private JakaRobot _robot;
        private DispatcherTimer _monitorTimer;

        public MainWindowViewModel()
        {
            // 初始化命令
            ConnectCommand = new RelayCommand(async _ =>
            {
                await ConnectAsync();
            });
            PowerOnCommand = new RelayCommand(async _ => await SafeExecute(r => r.PowerOn()));
            EnableCommand = new RelayCommand(async _ => await SafeExecute(r => r.EnableRobot()));
            StopCommand = new RelayCommand(_ => _robot?.Stop());
            RecoverCommand = new RelayCommand(async _ => await SafeExecute(r => r.Recover(r)));
            HomeCommand = new RelayCommand(async _ => await SafeExecute(r => r.Home_Move()));
            PauseCommand = new RelayCommand(async _ => await SafeExecute(r => r.PauseProgram()));
            ResumeCommand = new RelayCommand(async _ => await SafeExecute(r => r.ResumeProgram()));
            MoveToCoordinateCommand = new RelayCommand(async _ =>
            {
                await SafeExecute(r => r.WorkTask(InputX, InputY, InputZ, InputRX, InputRY, InputRZ));
                IsValueLocked = false;
            });
            DirectMoveCommand = new RelayCommand(async _ =>
            {
                await SafeExecute(r => r.TCP_Move(InputX, InputY, InputZ, InputRX, InputRY, InputRZ));
                IsValueLocked = false;
            });
            SetToolFrameCommand = new RelayCommand(async _ =>
            {
                await SetTool();
                IsValueLocked = false;
            });
            GripperOpenCommand = new RelayCommand(async _ => await SafeExecute(r => r.GripperMove(1000, 30, 50)));
            GripperCloseCommand = new RelayCommand(async _ => await SafeExecute(r => r.GripperMove(0, 30, 50)));
            GripperInitCommand = new RelayCommand(async _ => await SafeExecute(r => r.GripperInitialize()));
            SetToolFrameCommand = new RelayCommand(async _ => await SetTool());
            GripperOpenCommand = new RelayCommand(async _ => await SafeExecute(r=> r.GripperMove(1000,30,50)));
            GripperCloseCommand = new RelayCommand(async _ => await SafeExecute(r => r.GripperMove(0,30,50)));
            GripperInitCommand = new RelayCommand(async _ =>await SafeExecute(r => r.GripperInitialize()));
            
            // 初始化定时器
            _monitorTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(100) };
            _monitorTimer.Tick += (s, e) => UpdateState();
        }

        #region 属性绑定 (Binding Properties)
        //机器人IP
        private string _robotIp = "192.168.10.10";//jakaZu5
        //private string _robotIp = "192.168.10.20";//jakaZu3
        public string RobotIp { get => _robotIp; set => SetProperty(ref _robotIp, value); }

        //日志消息
        private string _statusMsg = "等待连接...";
        public string StatusMsg
        {
            get => _statusMsg;
            set
            {
                //SetProperty 会检查新值是否和旧值不同，如果不同则更新并触发 OnPropertyChanged
                if (SetProperty(ref _statusMsg, value))
                {
                    //核心逻辑：一旦 StatusMsg 改变，就自动写入 LogList
                    if (!string.IsNullOrEmpty(value))
                    {
                        WriteLog(value);
                    }
                }
            }
        }
        //是否连接
        private bool _isConnected;
        public bool IsConnected
        {
            get => _isConnected;
            set
            {
                SetProperty(ref _isConnected, value);
                OnPropertyChanged(nameof(ConnectBtnText)); // 按钮文字随连接状态变化
            }
        }

        public string ConnectBtnText => IsConnected ? "Disconnect" : "Connect";


        //日志列表
        public ObservableCollection<string> LogList { get; set; } = new ObservableCollection<string>();

        // --- 状态指示 (用于界面变色) ---
        private bool _isPoweredOn;
        public bool IsPoweredOn { get => _isPoweredOn; set => SetProperty(ref _isPoweredOn, value); }//上电

        private bool _isEnabled;
        public bool IsEnabled { get => _isEnabled; set => SetProperty(ref _isEnabled, value); }//使能

        private bool _isInPos;
        public bool IsInPos { get => _isInPos; set => SetProperty(ref _isInPos, value); }//到位

        private bool _isProtectiveStop;
        public bool IsProtectiveStop { get => _isProtectiveStop; set => SetProperty(ref _isProtectiveStop, value); }//保护性停止

        private bool _isGripperConnected;
        public bool IsGripperConnected { get => _isGripperConnected; set => SetProperty(ref _isGripperConnected, value); }//夹爪连接

        private string _errorMessage = "待连接获取";
        public string ErrorMessage { get => _errorMessage; set => SetProperty(ref _errorMessage, value); }//错误信息

        private string _errorcode = "待连接获取";
        public string ErrorCode { get => _errorcode; set => SetProperty(ref _errorcode, value); }//错误码

        // --- 实时数据展示 ---
        private string _jointDisplay = "Connection Pending";
        public string JointDisplay { get => _jointDisplay; set => SetProperty(ref _jointDisplay, value); }//关节角度

        private string _tcpDisplay = "Connection Pending";
        public string TcpDisplay { get => _tcpDisplay; set => SetProperty(ref _tcpDisplay, value); }//TCP坐标

        // --- 运动输入 ---
        //坐标变化锁定
        private bool _isValueLocked = false;
        public bool IsValueLocked
        {
            get => _isValueLocked;
            set => SetProperty(ref _isValueLocked, value);
        }
        private double _inputX;
        public double InputX
        {
            get => _inputX; set => SetProperty(ref _inputX, value);//目标点X
        }

        private double _inputY;
        public double InputY
        {
            get => _inputY; set => SetProperty(ref _inputY, value);//目标点Y
        }

        private double _inputZ;
        public double InputZ
        {
            get => _inputZ; set => SetProperty(ref _inputZ, value);//目标点Z
        }

        private double _inputRX;
        public double InputRX
        {
            get => _inputRX; set => SetProperty(ref _inputRX, value);//目标点RX
        }

        private double _inputRY;
        public double InputRY
        {
            get => _inputRY; set => SetProperty(ref _inputRY, value);//目标点RY
        }

        private double _inputRZ;
        public double InputRZ
        {
            get => _inputRZ; set => SetProperty(ref _inputRZ, value);//目标点RZ
        }

        //工具坐标系设置
        private int _currentToolIdDisplay = 0;
        public int CurrentToolIdDisplay { get => _currentToolIdDisplay; set => SetProperty(ref _currentToolIdDisplay, value); }

        private string _currentToolNameDisplay;
        public string CurrentToolNameDisplay { get => _currentToolNameDisplay; set => SetProperty(ref _currentToolNameDisplay, value); }

        private string _currentToolOffsetDisplay = "X:0     Y:0     Z:0     RX:0     RY:0     RZ:0";
        public string CurrentToolOffsetDisplay { get => _currentToolOffsetDisplay; set => SetProperty(ref _currentToolOffsetDisplay, value); }

        private int _toolId;
        public int ToolId
        {
            get => _toolId; set => SetProperty(ref _toolId, value);
        }
        private string _toolName = "Default Tool Coordinate System";
        public string ToolName
        {
            get => _toolName; set => SetProperty(ref _toolName, value);
        }
        private double _toolOffX = 0;
        public double ToolOffX
        {
            get => _toolOffX; set => SetProperty(ref _toolOffX, value);
        }
        private double _toolOffY = 0;
        public double ToolOffY
        {
            get => _toolOffY; set => SetProperty(ref _toolOffY, value);
        }
        private double _toolOffZ = 0;
        public double ToolOffZ
        {
            get => _toolOffZ; set => SetProperty(ref _toolOffZ, value);
        }
        private double _toolOffRX = 0;
        public double ToolOffRX
        {
            get => _toolOffRX; set => SetProperty(ref _toolOffRX, value);
        }
        private double _toolOffRY = 0;
        public double ToolOffRY
        {
            get => _toolOffRY; set => SetProperty(ref _toolOffRY, value);
        }
        private double _toolOffRZ = 0;
        public double ToolOffRZ
        {
            get => _toolOffRZ; set => SetProperty(ref _toolOffRZ, value);
        }
        #endregion

        #region 命令 (Commands)绑定

        public ICommand ConnectCommand { get; }
        public ICommand PowerOnCommand { get; }
        public ICommand EnableCommand { get; }
        public ICommand StopCommand { get; }
        public ICommand RecoverCommand { get; }
        public ICommand MoveToCoordinateCommand { get; }
        public ICommand SetToolFrameCommand { get; }
        public ICommand HomeCommand { get; }
        public ICommand PauseCommand { get; }
        public ICommand ResumeCommand { get; }
        public ICommand GripperOpenCommand { get; }
        public ICommand GripperCloseCommand { get; }
        public ICommand GripperInitCommand { get; }
        public ICommand DirectMoveCommand { get; }

        #endregion

        #region 逻辑实现

        private async Task ConnectAsync()
        {
            if (IsConnected)
            {
                // 断开逻辑
                _monitorTimer.Stop();
                _robot?.Dispose();
                _robot = null;
                IsConnected = false;
                StatusMsg = "已断开";
            }
            else
            {
                try
                {
                    StatusMsg = $"正在连接 {RobotIp}...";
                    _robot = new JakaRobot(RobotIp);
                    await _robot.ConnectRobot();
                    _robot.OnLogReceived += Robot_OnLogReceived;

                    if (_robot.IsConnected)
                    {
                        IsConnected = true;
                        IsGripperConnected = true;
                        // 开启反馈
                        JakaRobot.FeedBacksControl(_robot);
                        _robot.SetStatusRate(200);
                        _monitorTimer.Start();
                        await _robot.SetMotionLimitWarningRange(3);//预警范围
                        await _robot.SetCurrentToolId(0);//设置当前工具坐标系
                        await _robot.SecurityInitialize(4);//碰撞等级
                        StatusMsg = "机器人连接成功";
                    }
                    else
                    {
                        StatusMsg = "机器人连接失败";
                    }
                }
                catch (Exception ex)
                {
                    StatusMsg = $"机器人连接异常: {ex.Message}";
                }
            }
        }
        // 定时更新 UI 状态
        private void UpdateState()
        {
            if (_robot?.CurrentState == null) return;
            var s = _robot.CurrentState;
            IsPoweredOn = s.PoweredOn == 1;
            IsEnabled = s.Enabled;
            IsInPos = s.Inpos;
            IsProtectiveStop = s.ProtectiveStop == 1;
            ErrorCode = s.Errcode;
            ErrorMessage = s.Errmsg;
            if (!string.IsNullOrWhiteSpace(_robot.CurrentState.Errmsg))
            {
                string MS = _robot.CurrentState.Errcode.GetRobotErrorDescription();
                StatusMsg = MS;
            }
            if (s.JointActualPosition != null && s.JointActualPosition.Count >= 6)
            {
                JointDisplay = $"J1: {s.JointActualPosition[0]:F2}  J2: {s.JointActualPosition[1]:F2}  J3: {s.JointActualPosition[2]:F2}\n" +
                               $"J4: {s.JointActualPosition[3]:F2}  J5: {s.JointActualPosition[4]:F2}  J6: {s.JointActualPosition[5]:F2}";
            }

            if (s.ActualPosition != null && s.ActualPosition.Count >= 6)
            {
                TcpDisplay = $"X: {s.ActualPosition[0]:F1}  Y: {s.ActualPosition[1]:F1}  Z: {s.ActualPosition[2]:F1}\n" +
                             $"RX: {s.ActualPosition[3]:F1} RY: {s.ActualPosition[4]:F1} RZ: {s.ActualPosition[5]:F1}";
                if (!IsValueLocked)
                {
                    InputX = Math.Round(s.ActualPosition[0], 1);
                    InputY = Math.Round(s.ActualPosition[1], 1);
                    InputZ = Math.Round(s.ActualPosition[2], 1);
                    InputRX = Math.Round(s.ActualPosition[3], 1);
                    InputRY = Math.Round(s.ActualPosition[4], 1);
                    InputRZ = Math.Round(s.ActualPosition[5], 1);
                    ToolId = s.CurrentToolId;
                    CurrentToolIdDisplay = ToolId;
                    CurrentToolNameDisplay = ToolName;
                    CurrentToolOffsetDisplay = $"X:{ToolOffX}     Y:{ToolOffY}     Z:{ToolOffZ}     RX:{ToolOffRX}     RY:{ToolOffRY}     RZ:{ToolOffRZ}";
                }
            }
        }

        //辅助函数，确保安全
        private async Task SafeExecute(Func<JakaRobot, Task> action)
        {
            if (_robot == null) return;
            try
            {
                await action(_robot);
            }
            catch (Exception ex)
            {
                StatusMsg = $"操作失败: {ex.Message}";
            }
            if (!string.IsNullOrWhiteSpace(ErrorMessage))
            {
                StatusMsg = ErrorMessage;
            }
        }

        //日志更新
        private void Robot_OnLogReceived(string message)
        {
            // 必须使用 Dispatcher，因为 JakaRobot 可能在后台线程触发这个事件
            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                StatusMsg = message;
            });
        }
        private void WriteLog(string message)
        {
            // 确保在 UI 线程操作 ObservableCollection
            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                string timeStr = DateTime.Now.ToString("HH:mm:ss");
                // 防止重复添加完全相同的最后一条消息（可选，看你需求）
                //if (LogList.Count > 0 && LogList.Last().EndsWith(message)) return;

                LogList.Add($"[{timeStr}] {message}");

                // 保持日志在 150 条以内
                while (LogList.Count > 150)
                {
                    LogList.RemoveAt(0);
                }
            });
        }
        //工具坐标系设定+选择
        private async Task SetTool()
        {
            try
            {
                StatusMsg = "正在设置工具坐标系！";
                bool success = await Task.Run(async () =>
                {
                    await _robot.SetToolCoordinate(ToolId, ToolName, ToolOffX, ToolOffY, ToolOffZ, ToolOffRX, ToolOffRY, ToolOffRZ);
                    await Task.Delay(1000);
                    await _robot.SetCurrentToolId(ToolId);
                    for (int i = 0; i < 20; i++)
                    {
                        // 如果状态已经更新，且 ID 对上了，就返回成功
                        if (_robot.CurrentState.CurrentToolId == ToolId)
                        {
                            return true;
                        }
                        // 没对上，就等100ms再看
                        await Task.Delay(100);
                    }

                    // 如果等了 2 秒还没变过来，再检查最后一次
                    return (_robot.CurrentState.CurrentToolId == ToolId);
                });
                await Task.Delay(1000);
                if (success)
                {
                    StatusMsg = $"工具坐标系设置成功,当前工具坐标系为{ToolName}";
                }
            }
            catch (Exception ex)
            {
                StatusMsg = $"工具坐标系设置异常: {ex.Message}";
            }
        }
        #endregion
    }
}
