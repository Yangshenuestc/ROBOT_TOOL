using System.Text.Json.Serialization;

namespace JAKA_TESTAPP
{
    // --- 数据模型 ---

    // 10000端口返回的状态数据模型
    public class RobotState
    {
        [JsonPropertyName("curr_tcp_trans_vel")]
        public double CurrTcpTransVel { get; set; }

        // [之前修复点] 倍率也是小数
        [JsonPropertyName("rapidrate")]
        public double RapidRate { get; set; }

        // 关节角度 [j1, j2, j3, j4, j5, j6]
        [JsonPropertyName("joint_actual_position")]
        public List<double> JointActualPosition { get; set; }

        // TCP位姿 [x, y, z, rx, ry, rz]
        [JsonPropertyName("actual_position")]
        public List<double> ActualPosition { get; set; }

        // 上电状态 (0或1)
        [JsonPropertyName("powered_on")]
        public int PoweredOn { get; set; }

        // 使能状态 (true或false)
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        // ==========================================
        // 复杂/易错字段 (全部改为 object 防止崩溃)
        // ==========================================

        // 二维数组或复杂结构，必须用 object
        [JsonPropertyName("funcdi")]
        public object Funcdi { get; set; }

        [JsonPropertyName("monitor_data")]
        public object MonitorData { get; set; }

        [JsonPropertyName("extio")]
        public object Extio { get; set; }

        [JsonPropertyName("torqsensor")]
        public object Torqsensor { get; set; }

        [JsonPropertyName("drag_near_limit")]
        public object DragNearLimit { get; set; }

        // IO 数组 (类型不确定时用 object 最稳)
        [JsonPropertyName("din")]
        public object Din { get; set; }
        [JsonPropertyName("dout")]
        public object Dout { get; set; }
        [JsonPropertyName("ain")]
        public object Ain { get; set; }
        [JsonPropertyName("aout")]
        public object Aout { get; set; }
        [JsonPropertyName("homed")]
        public object Homed { get; set; }

        // ==========================================
        // 其他状态字段
        // ==========================================

        [JsonPropertyName("drag_status")]
        public bool DragStatus { get; set; }

        [JsonPropertyName("errcode")]
        public string Errcode { get; set; }

        [JsonPropertyName("errmsg")]
        public string Errmsg { get; set; }

        [JsonPropertyName("task_state")]
        public int TaskState { get; set; }

        [JsonPropertyName("task_mode")]
        public int TaskMode { get; set; }

        [JsonPropertyName("interp_state")]
        public int InterpState { get; set; }

        [JsonPropertyName("paused")]
        public bool Paused { get; set; }

        [JsonPropertyName("current_tool_id")]
        public int CurrentToolId { get; set; }

        [JsonPropertyName("on_soft_limit")]
        public int OnSoftLimit { get; set; }

        [JsonPropertyName("emergency_stop")]
        public int EmergencyStop { get; set; }

        [JsonPropertyName("protective_stop")]
        public int ProtectiveStop { get; set; }

        [JsonPropertyName("inpos")]
        public bool Inpos { get; set; }

        [JsonPropertyName("motion_mode")]
        public int MotionMode { get; set; }

        [JsonPropertyName("netState")]
        public int NetState { get; set; }
    }

    public class ExtIO
    {
        Dictionary<string, object> _extIO;
    }

    // 指令响应模型 (根据文档 2页 消息接收格式)
    public class CommandResponse
    {
        [JsonPropertyName("errorCode")]
        public string ErrorCode { get; set; } // 可能是字符串或数字

        [JsonPropertyName("errorMsg")]
        public string ErrorMsg { get; set; }

        [JsonPropertyName("cmdName")]
        public string CmdName { get; set; }
    }
}