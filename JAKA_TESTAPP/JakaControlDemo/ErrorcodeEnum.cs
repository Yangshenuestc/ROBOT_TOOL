using System.ComponentModel;

namespace JAKA_TESTAPP.JakaControlDemo
{
    /// <summary>
    /// JAKA 机器人错误代码枚举
    /// </summary>
    public enum ErrorcodeEnum : long
    {
        #region 关节 1 (Joint 1)
        [Description("关节1运动速度超过限制")]
        Code_000030 = 0x000030,
        [Description("关节1到达正软限位")]
        Code_000031 = 0x000031,
        [Description("关节1到达负软限位")]
        Code_000032 = 0x000032,
        [Description("关节1即将到达正软限位")]
        Code_000033 = 0x000033,
        [Description("关节1即将到达负软限位")]
        Code_000034 = 0x000034,
        [Description("JOG目标位置超过关节1正软限位")]
        Code_000035 = 0x000035,
        [Description("JOG目标位置超过关节1负软限位")]
        Code_000036 = 0x000036,
        [Description("关节1加速度过大")]
        Code_000037 = 0x000037,
        [Description("关节1即将达到软限位")]
        Code_000042 = 0x000042,
        [Description("关节1检测到碰撞并停止运动")]
        Code_000061 = 0x000061,
        [Description("安装角度设置超过阈值")]
        Code_000200 = 0x000200,
        [Description("当前无法设置轨迹规划器")]
        Code_000250 = 0x000250,
        [Description("当前不在SERVO模式中")]
        Code_000350 = 0x000350,
        [Description("不可以在SERVO模式中设置滤波器")]
        Code_000351 = 0x000351,
        [Description("SERVO指令参数无效")]
        Code_000352 = 0x000352,
        [Description("SERVO滤波器参数无效")]
        Code_000353 = 0x000353,
        [Description("IO序号超过范围")]
        Code_000400 = 0x000400,
        [Description("IO类型超过范围")]
        Code_000401 = 0x000401,
        [Description("别名已经存在")]
        Code_000450 = 0x000450,
        [Description("所设参数超过碰撞等级的范围")]
        Code_000500 = 0x000500,
        [Description("逆解失败")]
        Code_000550 = 0x000550,
        [Description("关节1CAN连接异常")]
        Code_001002 = 0x001002,
        [Description("关节1驱动器故障")]
        Code_001003 = 0x001003,
        [Description("关节1跟随误差过大")]
        Code_001004 = 0x001004,
        #endregion

        #region 关节 2 (Joint 2)
        [Description("关节2运动速度超过限制")]
        Code_010030 = 0x010030,
        [Description("关节2到达正软限位")]
        Code_010031 = 0x010031,
        [Description("关节2到达负软限位")]
        Code_010032 = 0x010032,
        [Description("关节2即将到达正软限位")]
        Code_010033 = 0x010033,
        [Description("关节2即将到达负软限位")]
        Code_010034 = 0x010034,
        [Description("JOG目标位置超过关节2正软限位")]
        Code_010035 = 0x010035,
        [Description("JOG目标位置超过关节2负软限位")]
        Code_010036 = 0x010036,
        [Description("关节2加速度过大")]
        Code_010037 = 0x010037,
        [Description("关节2即将达到软限位")]
        Code_010042 = 0x010042,
        [Description("关节2检测到碰撞并停止运动")]
        Code_010061 = 0x010061,
        [Description("关节2CAN连接异常")]
        Code_011002 = 0x011002,
        [Description("关节2驱动器故障")]
        Code_011003 = 0x011003,
        [Description("关节2跟随误差过大")]
        Code_011004 = 0x011004,
        #endregion

        #region 关节 3 (Joint 3)
        [Description("关节3运动速度超过限制")]
        Code_020030 = 0x020030,
        [Description("关节3到达正软限位")]
        Code_020031 = 0x020031,
        [Description("关节3到达负软限位")]
        Code_020032 = 0x020032,
        [Description("关节3即将到达正软限位")]
        Code_020033 = 0x020033,
        [Description("关节3即将到达负软限位")]
        Code_020034 = 0x020034,
        [Description("JOG目标位置超过关节3正软限位")]
        Code_020035 = 0x020035,
        [Description("JOG目标位置超过关节3负软限位")]
        Code_020036 = 0x020036,
        [Description("关节3加速度过大")]
        Code_020037 = 0x020037,
        [Description("关节3即将达到软限位")]
        Code_020042 = 0x020042,
        [Description("关节3检测到碰撞并停止运动")]
        Code_020061 = 0x020061,
        [Description("关节3CAN连接异常")]
        Code_021002 = 0x021002,
        [Description("关节3驱动器故障")]
        Code_021003 = 0x021003,
        [Description("关节3跟随误差过大")]
        Code_021004 = 0x021004,
        #endregion

        #region 关节 4 (Joint 4)
        [Description("关节4运动速度超过限制")]
        Code_030030 = 0x030030,
        [Description("关节4到达正软限位")]
        Code_030031 = 0x030031,
        [Description("关节4到达负软限位")]
        Code_030032 = 0x030032,
        [Description("关节4即将到达正软限位")]
        Code_030033 = 0x030033,
        [Description("关节4即将到达负软限位")]
        Code_030034 = 0x030034,
        [Description("JOG目标位置超过关节4正软限位")]
        Code_030035 = 0x030035,
        [Description("JOG目标位置超过关节4负软限位")]
        Code_030036 = 0x030036,
        [Description("关节4加速度过大")]
        Code_030037 = 0x030037,
        [Description("关节4即将达到软限位")]
        Code_030042 = 0x030042,
        [Description("关节4检测到碰撞并停止运动")]
        Code_030061 = 0x030061,
        [Description("关节4CAN连接异常")]
        Code_031002 = 0x031002,
        [Description("关节4驱动器故障")]
        Code_031003 = 0x031003,
        [Description("关节4跟随误差过大")]
        Code_031004 = 0x031004,
        #endregion

        #region 关节 5 (Joint 5)
        [Description("关节5运动速度超过限制")]
        Code_040030 = 0x040030,
        [Description("关节5到达正软限位")]
        Code_040031 = 0x040031,
        [Description("关节5到达负软限位")]
        Code_040032 = 0x040032,
        [Description("关节5即将到达正软限位")]
        Code_040033 = 0x040033,
        [Description("关节5即将到达负软限位")]
        Code_040034 = 0x040034,
        [Description("JOG目标位置超过关节5正软限位")]
        Code_040035 = 0x040035,
        [Description("JOG目标位置超过关节5负软限位")]
        Code_040036 = 0x040036,
        [Description("关节5加速度过大")]
        Code_040037 = 0x040037,
        [Description("关节5即将达到软限位")]
        Code_040042 = 0x040042,
        [Description("关节5检测到碰撞并停止运动")]
        Code_040061 = 0x040061,
        [Description("关节5CAN连接异常")]
        Code_041002 = 0x041002,
        [Description("关节5驱动器故障")]
        Code_041003 = 0x041003,
        [Description("关节5跟随误差过大")]
        Code_041004 = 0x041004,
        #endregion

        #region 关节 6 (Joint 6)
        [Description("关节6运动速度超过限制")]
        Code_050030 = 0x050030,
        [Description("关节6到达正软限位")]
        Code_050031 = 0x050031,
        [Description("关节6到达负软限位")]
        Code_050032 = 0x050032,
        [Description("关节6即将到达正软限位")]
        Code_050033 = 0x050033,
        [Description("关节6即将到达负软限位")]
        Code_050034 = 0x050034,
        [Description("JOG目标位置超过关节6正软限位")]
        Code_050035 = 0x050035,
        [Description("JOG目标位置超过关节6负软限位")]
        Code_050036 = 0x050036,
        [Description("关节6加速度过大")]
        Code_050037 = 0x050037,
        [Description("关节6即将达到软限位")]
        Code_050042 = 0x050042,
        [Description("关节6检测到碰撞并停止运动")]
        Code_050061 = 0x050061,
        [Description("关节6CAN连接异常")]
        Code_051002 = 0x051002,
        [Description("关节6驱动器故障")]
        Code_051003 = 0x051003,
        [Description("关节6跟随误差过大")]
        Code_051004 = 0x051004,
        #endregion

        #region 控制器与系统错误 (System Errors)
        [Description("没有错误")]
        Code_E0000 = 0xE0000,
        [Description("gRPC调用异常")]
        Code_E0001 = 0xE0001,
        [Description("密码错误")]
        Code_E0002 = 0xE0002,
        [Description("用户名错误")]
        Code_E0003 = 0xE0003,
        [Description("重复登录")]
        Code_E0004 = 0xE0004,
        [Description("用户尚未登录")]
        Code_E0005 = 0xE0005,
        [Description("关节限位异常")]
        Code_E0006 = 0xE0006,
        [Description("运动学逆解失败")]
        Code_E0007 = 0xE0007,
        [Description("运动学正解失败")]
        Code_E0008 = 0xE0008,
        [Description("找不到文件或者文件夹")]
        Code_E0009 = 0xE0009,
        [Description("MD5检测没有匹配")]
        Code_E000A = 0xE000A,
        [Description("计算工具中心点失败")]
        Code_E000B = 0xE000B,
        [Description("无效的参数")]
        Code_E000C = 0xE000C,
        [Description("太多的输出绑定到相同的状态")]
        Code_E000D = 0xE000D,
        [Description("变量别名已存在")]
        Code_E000E = 0xE000E,
        [Description("参数值超出范围")]
        Code_E000F = 0xE000F,
        [Description("消息ID超出范围")]
        Code_E0010 = 0xE0010,
        [Description("字符串不应超过16个字符")]
        Code_E0011 = 0xE0011,
        [Description("没有操作权限")]
        Code_E0012 = 0xE0012,
        [Description("用户权限等级不正确")]
        Code_E0013 = 0xE0013,
        [Description("用户名已经存在")]
        Code_E0014 = 0xE0014,
        [Description("升级安装包不正确")]
        Code_E0015 = 0xE0015,
        [Description("不支持jog坐标系")]
        Code_E0016 = 0xE0016,
        [Description("当前不支持该模式")]
        Code_E0017 = 0xE0017,
        [Description("机器人正在移动")]
        Code_E0018 = 0xE0018,
        [Description("作业运行时无法执行作业加载")]
        Code_E0019 = 0xE0019,
        [Description("当前引脚被其他功能占用")]
        Code_E001A = 0xE001A,
        [Description("衰减模式下无法设置各级衰减倍率")]
        Code_E001B = 0xE001B,
        [Description("轨迹复现时生成jks脚本失败")]
        Code_E001C = 0xE001C,
        [Description("只有一个TIO RS485通道可以使用力矩传感器")]
        Code_E001D = 0xE001D,
        [Description("力矩传感器通道切换失败")]
        Code_E001E = 0xE001E,
        [Description("机器人流水号不正确")]
        Code_E001F = 0xE001F,
        [Description("redis服务未启动")]
        Code_E0020 = 0xE0020,
        [Description("未知的机器人模型")]
        Code_E0021 = 0xE0021,
        [Description("扩展IO模块数量或扩展IO索引超出范围")]
        Code_E0022 = 0xE0022,
        [Description("'轨迹记录'指令在单步调试模式下不支持")]
        Code_E0023 = 0xE0023,
        [Description("仿真模式下不允许此操作")]
        Code_E0026 = 0xE0026,
        [Description("读取网络配置文件失败")]
        Code_E0027 = 0xE0027,
        [Description("太多的输入绑定到相同的功能")]
        Code_E0028 = 0xE0028,
        [Description("程序正在运行，不允许删除文件")]
        Code_E002A = 0xE002A,
        [Description("导入配置文件失败")]
        Code_E002B = 0xE002B,
        [Description("该机器人模型不支持仿真")]
        Code_E0030 = 0xE0030,
        [Description("用户坐标系标定失败")]
        Code_E0031 = 0xE0031,
        #endregion

        #region AddOn 服务错误
        [Description("AddOn启动数目超过限制")]
        Code_E03E8 = 0xE03E8,
        [Description("AddOn服务开启失败")]
        Code_E03E9 = 0xE03E9,
        [Description("AddOn服务关闭失败")]
        Code_E03EA = 0xE03EA,
        [Description("配置文件无效")]
        Code_E03EB = 0xE03EB,
        [Description("AddOn服务不存在")]
        Code_E03EC = 0xE03EC,
        [Description("AddOn配置不存在")]
        Code_E03ED = 0xE03ED,
        [Description("配置文件中 AddOn 规范未知")]
        Code_E03EE = 0xE03EE,
        [Description("配置文件中AddOn类型错误")]
        Code_E03EF = 0xE03EF,
        [Description("配置文件编程语言错误")]
        Code_E03F0 = 0xE03F0,
        [Description("配置文件中AddOn程序入口错误")]
        Code_E03F1 = 0xE03F1,
        [Description("配置文件中自启动配置错误")]
        Code_E03F2 = 0xE03F2,
        [Description("配置文件缺少必须的配置项")]
        Code_E03F3 = 0xE03F3,
        [Description("配置文件中AddOn中名称配置出错")]
        Code_E03F4 = 0xE03F4,
        [Description("配置文件中 AddOn 描述出错")]
        Code_E03F5 = 0xE03F5,
        [Description("AddOn版本无法识别")]
        Code_E03F6 = 0xE03F6,
        [Description("配置文件中AddOn中Url出错")]
        Code_E03F7 = 0xE03F7,
        [Description("分配端口号发生异常")]
        Code_E03F8 = 0xE03F8,
        [Description("AddOn服务正在运行")]
        Code_E03F9 = 0xE03F9,
        [Description("目录已经存在")]
        Code_E03FA = 0xE03FA,
        [Description("IP地址已经存在")]
        Code_E03FB = 0xE03FB,
        [Description("计算安全姿态相关参数失败")]
        Code_E03FC = 0xE03FC,
        #endregion

        #region 账户与安装错误
        [Description("校验文件不匹配")]
        Code_E044C = 0xE044C,
        [Description("密码错误")]
        Code_E044D = 0xE044D,
        [Description("两次密码输入不一致")]
        Code_E044E = 0xE044E,
        [Description("首次登录需要重置密码")]
        Code_E044F = 0xE044F,
        [Description("修改密码不能与上一次相同")]
        Code_E0450 = 0xE0450,
        [Description("账户未激活")]
        Code_E0451 = 0xE0451,
        [Description("无法激活账号")]
        Code_E0452 = 0xE0452,
        [Description("AddOn正在安装")]
        Code_E0453 = 0xE0453,
        [Description("AddOn安装失败")]
        Code_E0454 = 0xE0454,
        [Description("AddOn包过大")]
        Code_E0455 = 0xE0455,
        [Description("错误状态下切换手自动模式")]
        Code_E0456 = 0xE0456,
        [Description("输入的字符串中存在不支持的字符")]
        Code_E0457 = 0xE0457,
        [Description("急停状态无法升级")]
        Code_E04B0 = 0xE04B0,
        [Description("未知错误")]
        Code_EFFFF = 0xEFFFF,
        #endregion

        #region 机器人本体与运动控制错误 (Motion & Robot Errors)
        [Description("机器人本体未上电")]
        Code_0F0001 = 0x0F0001,
        [Description("机器人未使能")]
        Code_0F0002 = 0x0F0002,
        [Description("当前模式下无法进行此操作")]
        Code_0F0003 = 0x0F0003,
        [Description("运动学逆解计算失败")]
        Code_0F0004 = 0x0F0004,
        [Description("位置设置过大")]
        Code_0F0005 = 0x0F0005,
        [Description("机器人关节达到正的硬限位")]
        Code_0F0006 = 0x0F0006,
        [Description("机器人关节达到负的硬限位")]
        Code_0F0007 = 0x0F0007,
        [Description("机器人关节达到正的软限位")]
        Code_0F0008 = 0x0F0008,
        [Description("机器人关节达到负的软限位")]
        Code_0F0009 = 0x0F0009,
        [Description("笛卡尔目标位置超过最大位置限制")]
        Code_0F000A = 0x0F000A,
        [Description("笛卡尔目标位置超过最小位置限制")]
        Code_0F000B = 0x0F000B,
        [Description("关节回零过程中无法进行手动操作")]
        Code_0F000E = 0x0F000E,
        [Description("指令关节索引无效")]
        Code_0F000F = 0x0F000F,
        [Description("运动指令速度无效")]
        Code_0F0010 = 0x0F0010,
        [Description("运动指令目标位置超过机器限制")]
        Code_0F0011 = 0x0F0011,
        [Description("非关节模式不能进行home操作")]
        Code_0F0012 = 0x0F0012,
        [Description("home正在进行")]
        Code_0F0013 = 0x0F0013,
        [Description("退出保护模式失败")]
        Code_0F0014 = 0x0F0014,
        [Description("机器人未启动")]
        Code_0F0015 = 0x0F0015,
        [Description("机器人关节处于软限位")]
        Code_0F0016 = 0x0F0016,
        [Description("运动指令目标位置不可达")]
        Code_0F0017 = 0x0F0017,
        [Description("到达奇异点保护性停止")]
        Code_0F0018 = 0x0F0018,
        [Description("CAN设备初始化失败")]
        Code_0F0019 = 0x0F0019,
        [Description("一键升级超时")]
        Code_0F001A = 0x0F001A,
        [Description("一键升级异常")]
        Code_0F001B = 0x0F001B,
        [Description("控制器启动过程中检测到关节限位数据异常")]
        Code_0F001C = 0x0F001C,
        [Description("机器人上电超时")]
        Code_0F001D = 0x0F001D,
        [Description("机器人运动过程中运动学逆解异常")]
        Code_0F001E = 0x0F001E,
        [Description("固件升级超时")]
        Code_0F001F = 0x0F001F,
        [Description("直线运动到目标位置失败")]
        Code_0F0020 = 0x0F0020,
        [Description("不支持该型号机器人")]
        Code_0F0021 = 0x0F0021,
        [Description("机器人序列号无效")]
        Code_0F0022 = 0x0F0022,
        [Description("负载辨识轨迹索引无效")]
        Code_0F0023 = 0x0F0023,
        [Description("倍率模式下无法设置倍率")]
        Code_0F0024 = 0x0F0024,
        [Description("负载辨识轨迹定义不满足规范")]
        Code_0F0025 = 0x0F0025,
        [Description("关闭电源之前请下使能")]
        Code_0F0026 = 0x0F0026,
        [Description("程序运行期间不能下使能")]
        Code_0F0027 = 0x0F0027,
        [Description("负载设置存在偏差")]
        Code_0F0028 = 0x0F0028,
        [Description("执行圆弧运动指令失败")]
        Code_0F0029 = 0x0F0029,
        [Description("关节速度限制被设置为0")]
        Code_0F0030 = 0x0F0030,
        [Description("三位置使能限制")]
        Code_0F0031 = 0x0F0031,
        [Description("传送带跟踪不支持非直线或圆弧运动类型")]
        Code_0F0032 = 0x0F0032,
        [Description("检测到奇异点")]
        Code_0F0033 = 0x0F0033,
        [Description("检测到碰撞")]
        Code_0F0034 = 0x0F0034,
        [Description("超过姿态限制")]
        Code_0F0035 = 0x0F0035,
        [Description("工具末端超过最大位置偏差限制")]
        Code_0F0036 = 0x0F0036,
        [Description("工具末端线速度超过最大速度限制")]
        Code_0F0037 = 0x0F0037,
        [Description("执行关节运动指令失败")]
        Code_0F0038 = 0x0F0038,
        [Description("TCP标定示教点重复")]
        Code_0F0039 = 0x0F0039,
        [Description("机器人运动过程中不允许关闭使能")]
        Code_0F003A = 0x0F003A,
        [Description("机器人已上电，无需重复上电")]
        Code_0F003B = 0x0F003B,
        [Description("机器人已使能，无需重复使能")]
        Code_0F003C = 0x0F003C,
        [Description("TCP坐标系的标定有示教点在同一条直线上的情况")]
        Code_0F003D = 0x0F003D,
        [Description("TCP坐标系的标定误差超过预设阈值")]
        Code_0F003E = 0x0F003E,
        [Description("TCP坐标系的标定坐标超出了工作空间")]
        Code_0F003F = 0x0F003F,
        [Description("在软限位上无法进入拖拽模式")]
        Code_0F0040 = 0x0F0040,
        [Description("拖拽超出软限位将退出拖拽")]
        Code_0F0041 = 0x0F0041,
        [Description("力控参数设置失败")]
        Code_0F0042 = 0x0F0042,
        [Description("机器人未使能无法进入拖拽")]
        Code_0F0043 = 0x0F0043,
        [Description("机器人正在运动无法进入拖拽")]
        Code_0F0044 = 0x0F0044,
        [Description("关节力矩超限无法进入拖拽")]
        Code_0F0045 = 0x0F0045,
        [Description("拖拽按钮已屏蔽无法进入拖拽")]
        Code_0F0046 = 0x0F0046,
        [Description("程序暂停/恢复按钮已屏蔽")]
        Code_0F0047 = 0x0F0047,
        [Description("point按钮已屏蔽无法记录点位")]
        Code_0F0048 = 0x0F0048,
        [Description("仿真模式下无法进入拖拽模式")]
        Code_0F0049 = 0x0F0049,
        [Description("力控参数设置失败")]
        Code_0F004A = 0x0F004A,
        [Description("力传感器未就绪")]
        Code_0F0050 = 0x0F0050,
        [Description("力控牵引模式下无法切换力矩传感器模式")]
        Code_0F0051 = 0x0F0051,
        [Description("力控牵引过程中力矩传感器故障")]
        Code_0F0052 = 0x0F0052,
        [Description("程序运行期间无法执行单步运行操作")]
        Code_0F0054 = 0x0F0054,
        [Description("机器人运动期间不能设置碰撞灵敏度")]
        Code_0F0055 = 0x0F0055,
        [Description("扩展IO模块未运行")]
        Code_0F0056 = 0x0F0056,
        [Description("无法设置动力学前馈")]
        Code_0F0057 = 0x0F0057,
        [Description("未检测到功能使用许可")]
        Code_0F0058 = 0x0F0058,
        [Description("保护性停止复位失败")]
        Code_0F0059 = 0x0F0059,
        [Description("拒绝设置安全参数操作")]
        Code_0F005A = 0x0F005A,
        [Description("拒绝设置安全参数操作")]
        Code_0F005B = 0x0F005B,
        [Description("安全参数数值异常")]
        Code_0F005C = 0x0F005C,
        [Description("拒绝设置安全参数操作")]
        Code_0F005D = 0x0F005D,
        [Description("安全参数冲突")]
        Code_0F005E = 0x0F005E,
        [Description("保护性停止模式下无法设置倍率")]
        Code_0F0060 = 0x0F0060,
        [Description("用户坐标系标定失败")]
        Code_0F0061 = 0x0F0061,
        [Description("TIO RS485通道力矩传感器模式未启用")]
        Code_0F0062 = 0x0F0062,
        [Description("最多支持一路TIO RS485通道启用为力矩传感器模式")]
        Code_0F0063 = 0x0F0063,
        [Description("通讯参数修改失败")]
        Code_0F0064 = 0x0F0064,
        [Description("信号量定义无效")]
        Code_0F0065 = 0x0F0065,
        [Description("信号量超过最大支持数量")]
        Code_0F0066 = 0x0F0066,
        [Description("指定信号量不存在")]
        Code_0F0067 = 0x0F0067,
        [Description("发送TIO RS485指令失败")]
        Code_0F0068 = 0x0F0068,
        [Description("接收TIO RS485指令反馈超时")]
        Code_0F0069 = 0x0F0069,
        [Description("指令生成失败")]
        Code_0F006A = 0x0F006A,
        [Description("数字输出端口不可用")]
        Code_0F006B = 0x0F006B,
        [Description("倍率模式下无法设置倍率")]
        Code_0F006C = 0x0F006C,
        [Description("机器人DH参数读取校验异常")]
        Code_0F0070 = 0x0F0070,
        [Description("机器人动力学参数读取校验异常")]
        Code_0F0071 = 0x0F0071,
        [Description("伺服参数读取异常，使能失败")]
        Code_0F0072 = 0x0F0072,
        [Description("达到机器人动量限制")]
        Code_0F0073 = 0x0F0073,
        [Description("达到机器人TCP速度限制")]
        Code_0F0074 = 0x0F0074,
        [Description("即将超出安全平面")]
        Code_0F0075 = 0x0F0075,
        [Description("伺服端DH参数版本号无效")]
        Code_0F0076 = 0x0F0076,
        [Description("伺服端动力学参数版本号无效")]
        Code_0F0077 = 0x0F0077,
        [Description("伺服使能操作过于频繁")]
        Code_0F0078 = 0x0F0078,
        [Description("无法切换仿真/真机模式 请关闭电源")]
        Code_0F0079 = 0x0F0079,
        [Description("不支持将两个网口的IP设置在同一网段")]
        Code_0F007A = 0x0F007A,
        [Description("即将超出工具姿态安全限制")]
        Code_0F007B = 0x0F007B,
        [Description("无法切换仿真/真机模式")]
        Code_0F007C = 0x0F007C,
        [Description("上电状态不允许切换机器人模型")]
        Code_0F0080 = 0x0F0080,
        [Description("机器人运动过程中不允许重置密码")]
        Code_0F0081 = 0x0F0081,
        [Description("请检查密码复位按钮是否正常")]
        Code_0F0082 = 0x0F0082,
        [Description("关节减速失败")]
        Code_0F0083 = 0x0F0083,
        [Description("圆形传送带P1，P2，P3三点共线")]
        Code_0F0084 = 0x0F0084,
        [Description("直线传送带跟踪方向为零")]
        Code_0F0085 = 0x0F0085,
        [Description("获取负载辨识结果失败")]
        Code_0F0086 = 0x0F0086,
        [Description("时间最优规划寻优失败")]
        Code_0F0087 = 0x0F0087,
        [Description("负载辨识仅支持正装")]
        Code_0F0088 = 0x0F0088,
        [Description("无法执行急停后恢复程序运行")]
        Code_0F0089 = 0x0F0089,
        [Description("设置数字输出失败")]
        Code_0F008A = 0x0F008A,
        [Description("获取数字输入信号跳过运动指令失败")]
        Code_0F008B = 0x0F008B,
        [Description("IO索引超出范围")]
        Code_0F008C = 0x0F008C,
        [Description("拒绝设置安全参数操作")]
        Code_0F008E = 0x0F008E,
        [Description("程序运行时无法切换手/自动模式")]
        Code_0F0090 = 0x0F0090,
        [Description("机器人运动时无法切换手/自动模式")]
        Code_0F0091 = 0x0F0091,
        [Description("在手动模式下无法触发此DI功能")]
        Code_0F0092 = 0x0F0092,
        [Description("在自动模式下无法触发此DI功能")]
        Code_0F0093 = 0x0F0093,
        [Description("机器人拖拽时无法切换手/自动模式")]
        Code_0F0094 = 0x0F0094,
        [Description("启动程序失败")]
        Code_0F0095 = 0x0F0095,
        [Description("自动启动程序功能设置错误")]
        Code_0F0096 = 0x0F0096,
        [Description("功能设置错误")]
        Code_0F0097 = 0x0F0097,
        [Description("自动使能失败")]
        Code_0F0098 = 0x0F0098,
        [Description("指令执行失败")]
        Code_0F0099 = 0x0F0099,
        [Description("机器人功率超限")]
        Code_0F0100 = 0x0F0100,
        [Description("机器人动量超限")]
        Code_0F0101 = 0x0F0101,
        [Description("底座传感器检测到碰撞")]
        Code_0F0102 = 0x0F0102,
        [Description("末端力超限，1轴检测到碰撞")]
        Code_0F0103 = 0x0F0103,
        [Description("末端力超限，2轴检测到碰撞")]
        Code_0F0104 = 0x0F0104,
        [Description("末端力超限，3轴检测到碰撞")]
        Code_0F0105 = 0x0F0105,
        [Description("末端力超限，4轴检测到碰撞")]
        Code_0F0106 = 0x0F0106,
        [Description("末端力超限，5轴检测到碰撞")]
        Code_0F0107 = 0x0F0107,
        [Description("末端力超限，6轴检测到碰撞")]
        Code_0F0108 = 0x0F0108,
        [Description("安全平面点设置错误")]
        Code_0F0109 = 0x0F0109,
        [Description("无法设置动力学参数")]
        Code_0F0110 = 0x0F0110,
        [Description("设置动力学参数中断")]
        Code_0F0111 = 0x0F0111,
        [Description("设置动力学参数超时")]
        Code_0F0112 = 0x0F0112,
        [Description("不支持的控制柜类型")]
        Code_0F0113 = 0x0F0113,
        [Description("无法在下使能状态下进行负载辨识")]
        Code_0F0114 = 0x0F0114,
        [Description("获取底部或者Lan2网口ip失败")]
        Code_0F0115 = 0x0F0115,
        [Description("AddOn数量超限")]
        Code_0F0116 = 0x0F0116,
        [Description("AddOn服务不存在")]
        Code_0F0117 = 0x0F0117,
        [Description("AddOn端口查看空闲端口号失败")]
        Code_0F0118 = 0x0F0118,
        [Description("AddOn端口号分配失败")]
        Code_0F0119 = 0x0F0119,
        [Description("AddOn操作失败")]
        Code_0F011A = 0x0F011A,
        [Description("停止AddOn操作失败")]
        Code_0F011B = 0x0F011B,
        [Description("未知的AddOn操作")]
        Code_0F011C = 0x0F011C,
        [Description("系统AddOn端口重复")]
        Code_0F011D = 0x0F011D,
        [Description("AddOn未知错误")]
        Code_0F011E = 0x0F011E,
        [Description("非法的SystemAddOn操作")]
        Code_0F011F = 0x0F011F,
        [Description("操作失效AddOn失败")]
        Code_0F0120 = 0x0F0120,
        [Description("AddOn内配置文件无效")]
        Code_0F0121 = 0x0F0121,
        [Description("AddOn内配置文件无效")]
        Code_0F0122 = 0x0F0122,
        [Description("AddOn内配置文件无效")]
        Code_0F0123 = 0x0F0123,
        [Description("AddOn内配置文件无效")]
        Code_0F0124 = 0x0F0124,
        [Description("AddOn内配置文件无效")]
        Code_0F0125 = 0x0F0125,
        [Description("AddOn内配置文件无效")]
        Code_0F0126 = 0x0F0126,
        [Description("AddOn内配置文件无效")]
        Code_0F0127 = 0x0F0127,
        [Description("AddOn内配置文件无效或AddOn目录名无效")]
        Code_0F0128 = 0x0F0128,
        [Description("AddOn内配置文件无效")]
        Code_0F0129 = 0x0F0129,
        [Description("AddOn内配置文件无效")]
        Code_0F012A = 0x0F012A,
        [Description("AddOn内配置文件无效")]
        Code_0F012B = 0x0F012B,
        [Description("AddOn安装包错误")]
        Code_0F012C = 0x0F012C,
        [Description("AddOn安装包错误")]
        Code_0F012D = 0x0F012D,
        [Description("AddOn安装包错误")]
        Code_0F012E = 0x0F012E,
        [Description("AddOn安装包错误")]
        Code_0F012F = 0x0F012F,
        [Description("当前无AddOn安装任务")]
        Code_0F0130 = 0x0F0130,
        [Description("AddOn安装包错误")]
        Code_0F0131 = 0x0F0131,
        [Description("AddOn包压缩或解压超时")]
        Code_0F0132 = 0x0F0132,
        [Description("AddOn安装包格式错误")]
        Code_0F0133 = 0x0F0133,
        [Description("分享程序成功")]
        Code_0F0134 = 0x0F0134,
        [Description("分享程序失败")]
        Code_0F0135 = 0x0F0135,
        [Description("超出设定力值软限位")]
        Code_0F0140 = 0x0F0140,
        [Description("超过传感器最大量程")]
        Code_0F0141 = 0x0F0141,
        [Description("Profinet通信在未使能状态")]
        Code_0F0142 = 0x0F0142,
        [Description("EtherNet/IP通信在未使能状态")]
        Code_0F0143 = 0x0F0143,
        [Description("查询SCB硬件型号失败")]
        Code_0F0150 = 0x0F0150,
        [Description("设置SCB安全功能DI配置失败")]
        Code_0F0151 = 0x0F0151,
        [Description("设置SCB安全功能DO配置失败")]
        Code_0F0152 = 0x0F0152,
        [Description("设置SCB功率限制配置失败")]
        Code_0F0153 = 0x0F0153,
        [Description("向SCB同步工具坐标系失败")]
        Code_0F0154 = 0x0F0154,
        [Description("设置控制柜序列号配置失败")]
        Code_0F0155 = 0x0F0155,
        [Description("设置控制柜输出电压配置失败")]
        Code_0F0156 = 0x0F0156,
        [Description("设置SCB停止时间配置失败")]
        Code_0F0157 = 0x0F0157,
        [Description("设置SCB停止距离配置失败")]
        Code_0F0158 = 0x0F0158,
        [Description("设置SCB末端拖拽速度限制配置失败")]
        Code_0F0159 = 0x0F0159,
        [Description("发送控制器版本号至安全控制器失败")]
        Code_0F0160 = 0x0F0160,
        [Description("安全控制器版本过低")]
        Code_0F0161 = 0x0F0161,
        [Description("安全参数冲突")]
        Code_0F0170 = 0x0F0170,
        [Description("负载配置错误拒绝使能")]
        Code_0F0171 = 0x0F0171,
        [Description("有效负载配置参数值错误")]
        Code_0F0172 = 0x0F0172,
        [Description("使能超时 请重新打开电源")]
        Code_0F1001 = 0x0F1001,
        [Description("伺服版本号查询超时")]
        Code_0F1002 = 0x0F1002,
        #endregion

        #region 编程与语法错误 (Programming Errors)
        [Description("编程文件语法错误")]
        Code_0F2000 = 0x0F2000,
        [Description("没有编程文件打开")]
        Code_0F2001 = 0x0F2001,
        [Description("编程文件打开失败")]
        Code_0F2002 = 0x0F2002,
        [Description("编程文件关闭失败")]
        Code_0F2003 = 0x0F2003,
        [Description("程序备份成功")]
        Code_0F2004 = 0x0F2004,
        [Description("自动备份程序失败")]
        Code_0F2005 = 0x0F2005,
        [Description("解析错误")]
        Code_0F2010 = 0x0F2010,
        [Description("PyCall()失败")]
        Code_0F2011 = 0x0F2011,
        [Description("解析断言失败")]
        Code_0F2012 = 0x0F2012,
        [Description("解析失败，圆弧半径为零")]
        Code_0F2013 = 0x0F2013,
        [Description("解析失败，语法错误")]
        Code_0F2014 = 0x0F2014,
        [Description("网络连接失败")]
        Code_0F2015 = 0x0F2015,
        [Description("连接服务端失败")]
        Code_0F2016 = 0x0F2016,
        [Description("通讯失败未连接服务器")]
        Code_0F2017 = 0x0F2017,
        [Description("TCP/IP接收数据失败")]
        Code_0F2018 = 0x0F2018,
        [Description("TCP/IP发送数据失败")]
        Code_0F2019 = 0x0F2019,
        [Description("加载2D视觉配置失败")]
        Code_0F201A = 0x0F201A,
        [Description("内部错误")]
        Code_0F201B = 0x0F201B,
        [Description("作业程序语法错误")]
        Code_0F201C = 0x0F201C,
        [Description("作业程序语法错误")]
        Code_0F201D = 0x0F201D,
        [Description("作业程序语法错误")]
        Code_0F201E = 0x0F201E,
        [Description("作业程序语法错误")]
        Code_0F201F = 0x0F201F,
        [Description("作业程序语法错误")]
        Code_0F2020 = 0x0F2020,
        [Description("方法不该被调用")]
        Code_0F2021 = 0x0F2021,
        [Description("未知操作")]
        Code_0F2022 = 0x0F2022,
        [Description("错误数据格式")]
        Code_0F2023 = 0x0F2023,
        [Description("参数未定义")]
        Code_0F2024 = 0x0F2024,
        [Description("打开文件失败")]
        Code_0F2025 = 0x0F2025,
        [Description("作业程序语法错误")]
        Code_0F2026 = 0x0F2026,
        [Description("内存不足")]
        Code_0F2027 = 0x0F2027,
        [Description("返回值类型错误")]
        Code_0F2028 = 0x0F2028,
        [Description("作业程序语法错误")]
        Code_0F2029 = 0x0F2029,
        [Description("不能添加参数")]
        Code_0F202A = 0x0F202A,
        [Description("用户定义错误")]
        Code_0F202B = 0x0F202B,
        [Description("作业程序语法错误")]
        Code_0F202C = 0x0F202C,
        [Description("作业程序语法错误")]
        Code_0F202D = 0x0F202D,
        [Description("作业程序语法错误")]
        Code_0F202E = 0x0F202E,
        [Description("作业程序语法错误")]
        Code_0F202F = 0x0F202F,
        [Description("作业程序语法错误")]
        Code_0F2030 = 0x0F2030,
        [Description("作业程序语法错误")]
        Code_0F2031 = 0x0F2031,
        [Description("作业程序语法错误")]
        Code_0F2032 = 0x0F2032,
        [Description("指令过长")]
        Code_0F2033 = 0x0F2033,
        [Description("作业程序语法错误")]
        Code_0F2034 = 0x0F2034,
        [Description("作业程序语法错误")]
        Code_0F2035 = 0x0F2035,
        [Description("文件没有打开")]
        Code_0F2036 = 0x0F2036,
        [Description("重复定义")]
        Code_0F2037 = 0x0F2037,
        [Description("作业程序语法错误")]
        Code_0F2038 = 0x0F2038,
        [Description("重复打开文件")]
        Code_0F2039 = 0x0F2039,
        [Description("未匹配的'end'关键字")]
        Code_0F203A = 0x0F203A,
        [Description("创建线程失败")]
        Code_0F203B = 0x0F203B,
        [Description("创建线程失败")]
        Code_0F203C = 0x0F203C,
        [Description("未匹配的关键字")]
        Code_0F203D = 0x0F203D,
        [Description("未匹配的关键字")]
        Code_0F203E = 0x0F203E,
        [Description("未匹配的关键字")]
        Code_0F203F = 0x0F203F,
        [Description("未匹配的关键字")]
        Code_0F2040 = 0x0F2040,
        [Description("未匹配的关键字")]
        Code_0F2041 = 0x0F2041,
        [Description("TIO信号量读取失败")]
        Code_0F2042 = 0x0F2042,
        [Description("添加系统变量失败")]
        Code_0F2043 = 0x0F2043,
        [Description("SOCKET id 无效")]
        Code_0F2050 = 0x0F2050,
        [Description("逆解失败")]
        Code_0F2051 = 0x0F2051,
        [Description("正解失败")]
        Code_0F2052 = 0x0F2052,
        [Description("TCP/IP 通讯接收到错误数据")]
        Code_0F2053 = 0x0F2053,
        [Description("数组变量无效")]
        Code_0F2054 = 0x0F2054,
        [Description("数组元素索引无效")]
        Code_0F2055 = 0x0F2055,
        [Description("位姿插值系数无效")]
        Code_0F2056 = 0x0F2056,
        [Description("控制块结束符不匹配")]
        Code_0F2057 = 0x0F2057,
        [Description("不支持的转义字符")]
        Code_0F2058 = 0x0F2058,
        [Description("无效的数组切割间距参数")]
        Code_0F2059 = 0x0F2059,
        [Description("不支持数组嵌套")]
        Code_0F2060 = 0x0F2060,
        [Description("不支持字符串数组")]
        Code_0F2061 = 0x0F2061,
        [Description("SOCKET资源分配过多而未释放")]
        Code_0F2062 = 0x0F2062,
        [Description("SOCKET 接收的数据无效")]
        Code_0F2063 = 0x0F2063,
        [Description("Socket 接收到的数组长度不匹配")]
        Code_0F2064 = 0x0F2064,
        [Description("Socket 接收到的数据类型不匹配")]
        Code_0F2065 = 0x0F2065,
        [Description("程序指令设置碰撞灵敏度等级功能未启用")]
        Code_0F2066 = 0x0F2066,
        [Description("变量类型错误")]
        Code_0F2067 = 0x0F2067,
        [Description("程序运行出错")]
        Code_0F2068 = 0x0F2068,
        [Description("获取数字输入信号失败")]
        Code_0F2069 = 0x0F2069,
        [Description("获取数字输出信号失败")]
        Code_0F206A = 0x0F206A,
        [Description("等待数字输入指令执行失败")]
        Code_0F206B = 0x0F206B,
        [Description("连接指定视觉设备失败")]
        Code_0F3001 = 0x0F3001,
        [Description("没有连接视觉设备")]
        Code_0F3002 = 0x0F3002,
        [Description("伺服状态读取失败")]
        Code_0F4001 = 0x0F4001,
        [Description("固件升级失败")]
        Code_0F4002 = 0x0F4002,
        [Description("当前硬件不支持该功能")]
        Code_0F4003 = 0x0F4003,
        [Description("机器人自诊断异常")]
        Code_0F4004 = 0x0F4004,
        [Description("其它错误")]
        Code_0FFFFE = 0x0FFFFE,
        [Description("未知错误")]
        Code_0FFFFF = 0x0FFFFF,
        #endregion

        #region 关节详细硬件错误 (Joint Hardware)
        // Joint 1
        [Description("关节1母线过流")]
        Code_102230 = 0x102230,
        [Description("关节1输出过流")]
        Code_102320 = 0x102320,
        [Description("关节1电机寻相过流")]
        Code_102321 = 0x102321,
        [Description("关节1模块过载（I2T）")]
        Code_102350 = 0x102350,
        [Description("关节1输入缺相")]
        Code_103130 = 0x103130,
        [Description("关节1伺服过压")]
        Code_103210 = 0x103210,
        [Description("关节1驱动板动力电源故障")]
        Code_103211 = 0x103211,
        [Description("关节1伺服欠压")]
        Code_103220 = 0x103220,
        [Description("关节1编码器校零失败")]
        Code_103380 = 0x103380,
        [Description("关节1输出缺相")]
        Code_103381 = 0x103381,
        [Description("关节1电机过温")]
        Code_104210 = 0x104210,
        [Description("关节1伺服过温")]
        Code_104310 = 0x104310,
        [Description("关节1参数未解锁")]
        Code_105201 = 0x105201,
        [Description("关节1校零与DH参数冲突")]
        Code_105202 = 0x105202,
        [Description("关节1参数设置与硬件功率不匹配")]
        Code_105210 = 0x105210,
        [Description("关节1型号选择错误")]
        Code_105211 = 0x105211,
        [Description("关节1内部参数错误")]
        Code_105280 = 0x105280,
        [Description("关节1PID运算溢出")]
        Code_105281 = 0x105281,
        [Description("关节1EEPROM错误")]
        Code_105282 = 0x105282,
        [Description("关节1上使能失败")]
        Code_105283 = 0x105283,
        [Description("关节1内部连接错误")]
        Code_105441 = 0x105441,
        [Description("关节1伺服过功率")]
        Code_105480 = 0x105480,
        [Description("关节1绝对编码器内部错误")]
        Code_106000 = 0x106000,
        [Description("关节1编码器温度过热")]
        Code_106010 = 0x106010,
        [Description("关节1电机过载(I2T)")]
        Code_107180 = 0x107180,
        [Description("关节1电机抱闸故障")]
        Code_107181 = 0x107181,
        [Description("关节1高频注入反向")]
        Code_107182 = 0x107182,
        [Description("关节1电机抱闸电流异常")]
        Code_107185 = 0x107185,
        [Description("关节1编码器连接超时")]
        Code_107380 = 0x107380,
        [Description("关节1编码器电池欠压")]
        Code_107381 = 0x107381,
        [Description("关节1编码器电池断开")]
        Code_107382 = 0x107382,
        [Description("关节1编码器存储角度错误")]
        Code_107383 = 0x107383,
        [Description("关节1编码器计数错误")]
        Code_107384 = 0x107384,
        [Description("关节1双编码器校验错误")]
        Code_107385 = 0x107385,
        [Description("关节1编码器内部错误")]
        Code_107386 = 0x107386,
        [Description("关节1Z线捕捉故障")]
        Code_107387 = 0x107387,
        [Description("关节1编码器磁信号异常")]
        Code_107388 = 0x107388,
        [Description("关节1增量编码器连接异常")]
        Code_107389 = 0x107389,
        [Description("关节1转矩前馈超过限制值")]
        Code_107580 = 0x107580,
        [Description("关节1位置偏离")]
        Code_108000 = 0x108000,
        [Description("关节1位置偏离预警")]
        Code_108001 = 0x108001,
        [Description("关节1正向速度跟踪错误")]
        Code_108480 = 0x108480,
        [Description("关节1负向速度跟踪错误")]
        Code_108481 = 0x108481,
        [Description("关节1速度超限")]
        Code_108482 = 0x108482,
        [Description("关节1速度跟踪误差过大")]
        Code_108483 = 0x108483,
        [Description("关节1预留故障")]
        Code_108484 = 0x108484,
        [Description("关节1速度控制异常")]
        Code_108485 = 0x108485,
        [Description("关节1反向驱动模式下伺服禁止使能")]
        Code_108501 = 0x108501,
        [Description("关节1位置偏差过大")]
        Code_108611 = 0x108611,
        [Description("关节1位置指令增量过大")]
        Code_108612 = 0x108612,
        [Description("关节1加速度过大")]
        Code_108613 = 0x108613,
        [Description("关节1位置指令过大")]
        Code_108614 = 0x108614,
        [Description("关节1CAN通讯异常")]
        Code_108615 = 0x108615,
        [Description("关节 1温度传感器通信异常")]
        Code_108616 = 0x108616,
        [Description("关节1CAN通信周期波动预警")]
        Code_108617 = 0x108617,
        [Description("关节发生错误")]
        Code_10FFFF = 0x10FFFF,

        // Joint 2
        [Description("关节2母线过流")]
        Code_112230 = 0x112230,
        [Description("关节2输出过流")]
        Code_112320 = 0x112320,
        [Description("关节2电机寻相过流")]
        Code_112321 = 0x112321,
        [Description("关节2模块过载（I2T）")]
        Code_112350 = 0x112350,
        [Description("关节2输入缺相")]
        Code_113130 = 0x113130,
        [Description("关节2伺服过压")]
        Code_113210 = 0x113210,
        [Description("关节2驱动板动力电源故障")]
        Code_113211 = 0x113211,
        [Description("关节2伺服欠压")]
        Code_113220 = 0x113220,
        [Description("关节2编码器校零失败")]
        Code_113380 = 0x113380,
        [Description("关节2输出缺相")]
        Code_113381 = 0x113381,
        [Description("关节2电机过温")]
        Code_114210 = 0x114210,
        [Description("关节2伺服过温")]
        Code_114310 = 0x114310,
        [Description("关节2参数未解锁")]
        Code_115201 = 0x115201,
        [Description("关节2校零与DH参数冲突")]
        Code_115202 = 0x115202,
        [Description("关节2参数设置与硬件功率不匹配")]
        Code_115210 = 0x115210,
        [Description("关节2型号选择错误")]
        Code_115211 = 0x115211,
        [Description("关节2内部参数错误")]
        Code_115280 = 0x115280,
        [Description("关节2PID运算溢出")]
        Code_115281 = 0x115281,
        [Description("关节2EEPROM错误")]
        Code_115282 = 0x115282,
        [Description("关节2上使能失败")]
        Code_115283 = 0x115283,
        [Description("关节2内部连接错误")]
        Code_115441 = 0x115441,
        [Description("关节2伺服过功率")]
        Code_115480 = 0x115480,
        [Description("关节2绝对编码器内部错误")]
        Code_116000 = 0x116000,
        [Description("关节2编码器温度过热")]
        Code_116010 = 0x116010,
        [Description("关节2电机过载(I2T)")]
        Code_117180 = 0x117180,
        [Description("关节2电机抱闸故障")]
        Code_117181 = 0x117181,
        [Description("关节2高频注入反向")]
        Code_117182 = 0x117182,
        [Description("关节2电机抱闸电流异常")]
        Code_117185 = 0x117185,
        [Description("关节2编码器连接超时")]
        Code_117380 = 0x117380,
        [Description("关节2编码器电池欠压")]
        Code_117381 = 0x117381,
        [Description("关节2编码器电池断开")]
        Code_117382 = 0x117382,
        [Description("关节2编码器存储角度错误")]
        Code_117383 = 0x117383,
        [Description("关节2编码器计数错误")]
        Code_117384 = 0x117384,
        [Description("关节2双编码器校验错误")]
        Code_117385 = 0x117385,
        [Description("关节2编码器内部错误")]
        Code_117386 = 0x117386,
        [Description("关节2Z线捕捉故障")]
        Code_117387 = 0x117387,
        [Description("关节2编码器磁信号异常")]
        Code_117388 = 0x117388,
        [Description("关节2增量编码器连接异常")]
        Code_117389 = 0x117389,
        [Description("关节2转矩前馈超过限制值")]
        Code_117580 = 0x117580,
        [Description("关节2位置偏离")]
        Code_118000 = 0x118000,
        [Description("关节2位置偏离预警")]
        Code_118001 = 0x118001,
        [Description("关节2正向速度跟踪错误")]
        Code_118480 = 0x118480,
        [Description("关节2负向速度跟踪错误")]
        Code_118481 = 0x118481,
        [Description("关节2速度超限")]
        Code_118482 = 0x118482,
        [Description("关节2速度跟踪误差过大")]
        Code_118483 = 0x118483,
        [Description("关节2预留故障")]
        Code_118484 = 0x118484,
        [Description("关节2速度控制异常")]
        Code_118485 = 0x118485,
        [Description("关节2反向驱动模式下伺服禁止使能")]
        Code_118501 = 0x118501,
        [Description("关节2位置偏差过大")]
        Code_118611 = 0x118611,
        [Description("关节2位置指令增量过大")]
        Code_118612 = 0x118612,
        [Description("关节2加速度过大")]
        Code_118613 = 0x118613,
        [Description("关节2位置指令过大")]
        Code_118614 = 0x118614,
        [Description("关节2CAN通讯异常")]
        Code_118615 = 0x118615,
        [Description("关节 2温度传感器通信异常")]
        Code_118616 = 0x118616,
        [Description("关节2CAN通信周期波动预警")]
        Code_118617 = 0x118617,

        // Joint 3
        [Description("关节3母线过流")]
        Code_122230 = 0x122230,
        [Description("关节3输出过流")]
        Code_122320 = 0x122320,
        [Description("关节3电机寻相过流")]
        Code_122321 = 0x122321,
        [Description("关节3模块过载（I2T）")]
        Code_122350 = 0x122350,
        [Description("关节3输入缺相")]
        Code_123130 = 0x123130,
        [Description("关节3伺服过压")]
        Code_123210 = 0x123210,
        [Description("关节3驱动板动力电源故障")]
        Code_123211 = 0x123211,
        [Description("关节3伺服欠压")]
        Code_123220 = 0x123220,
        [Description("关节3编码器校零失败")]
        Code_123380 = 0x123380,
        [Description("关节3输出缺相")]
        Code_123381 = 0x123381,
        [Description("关节3电机过温")]
        Code_124210 = 0x124210,
        [Description("关节3伺服过温")]
        Code_124310 = 0x124310,
        [Description("关节3参数未解锁")]
        Code_125201 = 0x125201,
        [Description("关节3校零与DH参数冲突")]
        Code_125202 = 0x125202,
        [Description("关节3参数设置与硬件功率不匹配")]
        Code_125210 = 0x125210,
        [Description("关节3型号选择错误")]
        Code_125211 = 0x125211,
        [Description("关节3内部参数错误")]
        Code_125280 = 0x125280,
        [Description("关节3PID运算溢出")]
        Code_125281 = 0x125281,
        [Description("关节3EEPROM错误")]
        Code_125282 = 0x125282,
        [Description("关节3上使能失败")]
        Code_125283 = 0x125283,
        [Description("关节3内部连接错误")]
        Code_125441 = 0x125441,
        [Description("关节3伺服过功率")]
        Code_125480 = 0x125480,
        [Description("关节3绝对编码器内部错误")]
        Code_126000 = 0x126000,
        [Description("关节3编码器温度过热")]
        Code_126010 = 0x126010,
        [Description("关节3电机过载(I2T)")]
        Code_127180 = 0x127180,
        [Description("关节3电机抱闸故障")]
        Code_127181 = 0x127181,
        [Description("关节3高频注入反向")]
        Code_127182 = 0x127182,
        [Description("关节3电机抱闸电流异常")]
        Code_127185 = 0x127185,
        [Description("关节3编码器连接超时")]
        Code_127380 = 0x127380,
        [Description("关节3编码器电池欠压")]
        Code_127381 = 0x127381,
        [Description("关节3编码器电池断开")]
        Code_127382 = 0x127382,
        [Description("关节3编码器存储角度错误")]
        Code_127383 = 0x127383,
        [Description("关节3编码器计数错误")]
        Code_127384 = 0x127384,
        [Description("关节3双编码器校验错误")]
        Code_127385 = 0x127385,
        [Description("关节3编码器内部错误")]
        Code_127386 = 0x127386,
        [Description("关节3Z线捕捉故障")]
        Code_127387 = 0x127387,
        [Description("关节3编码器磁信号异常")]
        Code_127388 = 0x127388,
        [Description("关节3增量编码器连接异常")]
        Code_127389 = 0x127389,
        [Description("关节3转矩前馈超过限制值")]
        Code_127580 = 0x127580,
        [Description("关节3位置偏离")]
        Code_128000 = 0x128000,
        [Description("关节3位置偏离预警")]
        Code_128001 = 0x128001,
        [Description("关节3正向速度跟踪错误")]
        Code_128480 = 0x128480,
        [Description("关节3负向速度跟踪错误")]
        Code_128481 = 0x128481,
        [Description("关节3速度超限")]
        Code_128482 = 0x128482,
        [Description("关节3速度跟踪误差过大")]
        Code_128483 = 0x128483,
        [Description("关节3预留故障")]
        Code_128484 = 0x128484,
        [Description("关节3速度控制异常")]
        Code_128485 = 0x128485,
        [Description("关节3反向驱动模式下伺服禁止使能")]
        Code_128501 = 0x128501,
        [Description("关节3位置偏差过大")]
        Code_128611 = 0x128611,
        [Description("关节3位置指令增量过大")]
        Code_128612 = 0x128612,
        [Description("关节3加速度过大")]
        Code_128613 = 0x128613,
        [Description("关节3位置指令过大")]
        Code_128614 = 0x128614,
        [Description("关节3CAN通讯异常")]
        Code_128615 = 0x128615,
        [Description("关节 3温度传感器通信异常")]
        Code_128616 = 0x128616,
        [Description("关节3CAN通信周期波动预警")]
        Code_128617 = 0x128617,

        // Joint 4
        [Description("关节4母线过流")]
        Code_132230 = 0x132230,
        [Description("关节4输出过流")]
        Code_132320 = 0x132320,
        [Description("关节4电机寻相过流")]
        Code_132321 = 0x132321,
        [Description("关节4模块过载（I2T）")]
        Code_132350 = 0x132350,
        [Description("关节4输入缺相")]
        Code_133130 = 0x133130,
        [Description("关节4伺服过压")]
        Code_133210 = 0x133210,
        [Description("关节4驱动板动力电源故障")]
        Code_133211 = 0x133211,
        [Description("关节4伺服欠压")]
        Code_133220 = 0x133220,
        [Description("关节4编码器校零失败")]
        Code_133380 = 0x133380,
        [Description("关节4输出缺相")]
        Code_133381 = 0x133381,
        [Description("关节4电机过温")]
        Code_134210 = 0x134210,
        [Description("关节4伺服过温")]
        Code_134310 = 0x134310,
        [Description("关节4参数未解锁")]
        Code_135201 = 0x135201,
        [Description("关节4校零与DH参数冲突")]
        Code_135202 = 0x135202,
        [Description("关节4参数设置与硬件功率不匹配")]
        Code_135210 = 0x135210,
        [Description("关节4型号选择错误")]
        Code_135211 = 0x135211,
        [Description("关节4内部参数错误")]
        Code_135280 = 0x135280,
        [Description("关节4PID运算溢出")]
        Code_135281 = 0x135281,
        [Description("关节4EEPROM错误")]
        Code_135282 = 0x135282,
        [Description("关节4上使能失败")]
        Code_135283 = 0x135283,
        [Description("关节4内部连接错误")]
        Code_135441 = 0x135441,
        [Description("关节4伺服过功率")]
        Code_135480 = 0x135480,
        [Description("关节4绝对编码器内部错误")]
        Code_136000 = 0x136000,
        [Description("关节4编码器温度过热")]
        Code_136010 = 0x136010,
        [Description("关节4电机过载(I2T)")]
        Code_137180 = 0x137180,
        [Description("关节4电机抱闸故障")]
        Code_137181 = 0x137181,
        [Description("关节4高频注入反向")]
        Code_137182 = 0x137182,
        [Description("关节4电机抱闸电流异常")]
        Code_137185 = 0x137185,
        [Description("关节4编码器连接超时")]
        Code_137380 = 0x137380,
        [Description("关节4编码器电池欠压")]
        Code_137381 = 0x137381,
        [Description("关节4编码器电池断开")]
        Code_137382 = 0x137382,
        [Description("关节4编码器存储角度错误")]
        Code_137383 = 0x137383,
        [Description("关节4编码器计数错误")]
        Code_137384 = 0x137384,
        [Description("关节4双编码器校验错误")]
        Code_137385 = 0x137385,
        [Description("关节4编码器内部错误")]
        Code_137386 = 0x137386,
        [Description("关节4Z线捕捉故障")]
        Code_137387 = 0x137387,
        [Description("关节4编码器磁信号异常")]
        Code_137388 = 0x137388,
        [Description("关节4增量编码器连接异常")]
        Code_137389 = 0x137389,
        [Description("关节4转矩前馈超过限制值")]
        Code_137580 = 0x137580,
        [Description("关节4位置偏离")]
        Code_138000 = 0x138000,
        [Description("关节4位置偏离预警")]
        Code_138001 = 0x138001,
        [Description("关节4正向速度跟踪错误")]
        Code_138480 = 0x138480,
        [Description("关节4负向速度跟踪错误")]
        Code_138481 = 0x138481,
        [Description("关节4速度超限")]
        Code_138482 = 0x138482,
        [Description("关节4速度跟踪误差过大")]
        Code_138483 = 0x138483,
        [Description("关节4预留故障")]
        Code_138484 = 0x138484,
        [Description("关节4速度控制异常")]
        Code_138485 = 0x138485,
        [Description("关节4反向驱动模式下伺服禁止使能")]
        Code_138501 = 0x138501,
        [Description("关节4位置偏差过大")]
        Code_138611 = 0x138611,
        [Description("关节4位置指令增量过大")]
        Code_138612 = 0x138612,
        [Description("关节4加速度过大")]
        Code_138613 = 0x138613,
        [Description("关节4位置指令过大")]
        Code_138614 = 0x138614,
        [Description("关节4CAN通讯异常")]
        Code_138615 = 0x138615,
        [Description("关节 4温度传感器通信异常")]
        Code_138616 = 0x138616,
        [Description("关节4CAN通信周期波动预警")]
        Code_138617 = 0x138617,

        // Joint 5
        [Description("关节5母线过流")]
        Code_142230 = 0x142230,
        [Description("关节5输出过流")]
        Code_142320 = 0x142320,
        [Description("关节5电机寻相过流")]
        Code_142321 = 0x142321,
        [Description("关节5模块过载（I2T）")]
        Code_142350 = 0x142350,
        [Description("关节5输入缺相")]
        Code_143130 = 0x143130,
        [Description("关节5伺服过压")]
        Code_143210 = 0x143210,
        [Description("关节5驱动板动力电源故障")]
        Code_143211 = 0x143211,
        [Description("关节5伺服欠压")]
        Code_143220 = 0x143220,
        [Description("关节5编码器校零失败")]
        Code_143380 = 0x143380,
        [Description("关节5输出缺相")]
        Code_143381 = 0x143381,
        [Description("关节5电机过温")]
        Code_144210 = 0x144210,
        [Description("关节5伺服过温")]
        Code_144310 = 0x144310,
        [Description("关节5参数未解锁")]
        Code_145201 = 0x145201,
        [Description("关节5校零与DH参数冲突")]
        Code_145202 = 0x145202,
        [Description("关节5参数设置与硬件功率不匹配")]
        Code_145210 = 0x145210,
        [Description("关节5型号选择错误")]
        Code_145211 = 0x145211,
        [Description("关节5内部参数错误")]
        Code_145280 = 0x145280,
        [Description("关节5PID运算溢出")]
        Code_145281 = 0x145281,
        [Description("关节5EEPROM错误")]
        Code_145282 = 0x145282,
        [Description("关节5上使能失败")]
        Code_145283 = 0x145283,
        [Description("关节5内部连接错误")]
        Code_145441 = 0x145441,
        [Description("关节5伺服过功率")]
        Code_145480 = 0x145480,
        [Description("关节5绝对编码器内部错误")]
        Code_146000 = 0x146000,
        [Description("关节5编码器温度过热")]
        Code_146010 = 0x146010,
        [Description("关节5电机过载(I2T)")]
        Code_147180 = 0x147180,
        [Description("关节5电机抱闸故障")]
        Code_147181 = 0x147181,
        [Description("关节5高频注入反向")]
        Code_147182 = 0x147182,
        [Description("关节5电机抱闸电流异常")]
        Code_147185 = 0x147185,
        [Description("关节5编码器连接超时")]
        Code_147380 = 0x147380,
        [Description("关节5编码器电池欠压")]
        Code_147381 = 0x147381,
        [Description("关节5编码器电池断开")]
        Code_147382 = 0x147382,
        [Description("关节5编码器存储角度错误")]
        Code_147383 = 0x147383,
        [Description("关节5编码器计数错误")]
        Code_147384 = 0x147384,
        [Description("关节5双编码器校验错误")]
        Code_147385 = 0x147385,
        [Description("关节5编码器内部错误")]
        Code_147386 = 0x147386,
        [Description("关节5Z线捕捉故障")]
        Code_147387 = 0x147387,
        [Description("关节5编码器磁信号异常")]
        Code_147388 = 0x147388,
        [Description("关节5增量编码器连接异常")]
        Code_147389 = 0x147389,
        [Description("关节5转矩前馈超过限制值")]
        Code_147580 = 0x147580,
        [Description("关节5位置偏离")]
        Code_148000 = 0x148000,
        [Description("关节5位置偏离预警")]
        Code_148001 = 0x148001,
        [Description("关节5正向速度跟踪错误")]
        Code_148480 = 0x148480,
        [Description("关节5负向速度跟踪错误")]
        Code_148481 = 0x148481,
        [Description("关节5速度超限")]
        Code_148482 = 0x148482,
        [Description("关节5速度跟踪误差过大")]
        Code_148483 = 0x148483,
        [Description("关节5预留故障")]
        Code_148484 = 0x148484,
        [Description("关节5速度控制异常")]
        Code_148485 = 0x148485,
        [Description("关节5反向驱动模式下伺服禁止使能")]
        Code_148501 = 0x148501,
        [Description("关节5位置偏差过大")]
        Code_148611 = 0x148611,
        [Description("关节5位置指令增量过大")]
        Code_148612 = 0x148612,
        [Description("关节5加速度过大")]
        Code_148613 = 0x148613,
        [Description("关节5位置指令过大")]
        Code_148614 = 0x148614,
        [Description("关节5CAN通讯异常")]
        Code_148615 = 0x148615,
        [Description("关节 5温度传感器通信异常")]
        Code_148616 = 0x148616,
        [Description("关节5CAN通信周期波动预警")]
        Code_148617 = 0x148617,

        // Joint 6
        [Description("关节6母线过流")]
        Code_152230 = 0x152230,
        [Description("关节6输出过流")]
        Code_152320 = 0x152320,
        [Description("关节6电机寻相过流")]
        Code_152321 = 0x152321,
        [Description("关节6模块过载（I2T）")]
        Code_152350 = 0x152350,
        [Description("关节6输入缺相")]
        Code_153130 = 0x153130,
        [Description("关节6伺服过压")]
        Code_153210 = 0x153210,
        [Description("关节6驱动板动力电源故障")]
        Code_153211 = 0x153211,
        [Description("关节6伺服欠压")]
        Code_153220 = 0x153220,
        [Description("关节6编码器校零失败")]
        Code_153380 = 0x153380,
        [Description("关节6输出缺相")]
        Code_153381 = 0x153381,
        [Description("关节6电机过温")]
        Code_154210 = 0x154210,
        [Description("关节6伺服过温")]
        Code_154310 = 0x154310,
        [Description("关节6参数未解锁")]
        Code_155201 = 0x155201,
        [Description("关节6校零与DH参数冲突")]
        Code_155202 = 0x155202,
        [Description("关节6参数设置与硬件功率不匹配")]
        Code_155210 = 0x155210,
        [Description("关节6型号选择错误")]
        Code_155211 = 0x155211,
        [Description("关节6内部参数错误")]
        Code_155280 = 0x155280,
        [Description("关节6PID运算溢出")]
        Code_155281 = 0x155281,
        [Description("关节6EEPROM错误")]
        Code_155282 = 0x155282,
        [Description("关节6上使能失败")]
        Code_155283 = 0x155283,
        [Description("关节6内部连接错误")]
        Code_155441 = 0x155441,
        [Description("关节6伺服过功率")]
        Code_155480 = 0x155480,
        [Description("关节6绝对编码器内部错误")]
        Code_156000 = 0x156000,
        [Description("关节6编码器温度过热")]
        Code_156010 = 0x156010,
        [Description("关节6电机过载(I2T)")]
        Code_157180 = 0x157180,
        [Description("关节6电机抱闸故障")]
        Code_157181 = 0x157181,
        [Description("关节6高频注入反向")]
        Code_157182 = 0x157182,
        [Description("关节6电机抱闸电流异常")]
        Code_157185 = 0x157185,
        [Description("关节6编码器连接超时")]
        Code_157380 = 0x157380,
        [Description("关节6编码器电池欠压")]
        Code_157381 = 0x157381,
        [Description("关节6编码器电池断开")]
        Code_157382 = 0x157382,
        [Description("关节6编码器存储角度错误")]
        Code_157383 = 0x157383,
        [Description("关节6编码器计数错误")]
        Code_157384 = 0x157384,
        [Description("关节6双编码器校验错误")]
        Code_157385 = 0x157385,
        [Description("关节6编码器内部错误")]
        Code_157386 = 0x157386,
        [Description("关节6Z线捕捉故障")]
        Code_157387 = 0x157387,
        [Description("关节6编码器磁信号异常")]
        Code_157388 = 0x157388,
        [Description("关节6增量编码器连接异常")]
        Code_157389 = 0x157389,
        [Description("关节6转矩前馈超过限制值")]
        Code_157580 = 0x157580,
        [Description("关节6位置偏离")]
        Code_158000 = 0x158000,
        [Description("关节6位置偏离预警")]
        Code_158001 = 0x158001,
        [Description("关节6正向速度跟踪错误")]
        Code_158480 = 0x158480,
        [Description("关节6负向速度跟踪错误")]
        Code_158481 = 0x158481,
        [Description("关节6速度超限")]
        Code_158482 = 0x158482,
        [Description("关节6速度跟踪误差过大")]
        Code_158483 = 0x158483,
        [Description("关节6预留故障")]
        Code_158484 = 0x158484,
        [Description("关节6速度控制异常")]
        Code_158485 = 0x158485,
        [Description("关节6反向驱动模式下伺服禁止使能")]
        Code_158501 = 0x158501,
        [Description("关节6位置偏差过大")]
        Code_158611 = 0x158611,
        [Description("关节6位置指令增量过大")]
        Code_158612 = 0x158612,
        [Description("关节6加速度过大")]
        Code_158613 = 0x158613,
        [Description("关节6位置指令过大")]
        Code_158614 = 0x158614,
        [Description("关节6CAN通讯异常")]
        Code_158615 = 0x158615,
        [Description("关节 6温度传感器通信异常")]
        Code_158616 = 0x158616,
        [Description("关节6CAN通信周期波动预警")]
        Code_158617 = 0x158617,
        #endregion

        #region 扩展IO与Modbus (Extended IO)
        [Description("TIO初始化失败")]
        Code_201002 = 0x201002,
        [Description("扩展IO初始化时Modbus RTU配置错误")]
        Code_201101 = 0x201101,
        [Description("扩展IO初始化时创建Modbus RTU连接失败")]
        Code_201102 = 0x201102,
        [Description("扩展IO RTU 串行总线参数不一致")]
        Code_201104 = 0x201104,
        [Description("扩展IO初始化时Modbus TCP配置错误")]
        Code_201201 = 0x201201,
        [Description("扩展IO初始化时创建Modbus TCP连接失败")]
        Code_201202 = 0x201202,
        [Description("扩展IO初始化时未知错误")]
        Code_201304 = 0x201304,
        [Description("扩展IO运行时Modbus TCP节点掉线")]
        Code_202102 = 0x202102,
        [Description("扩展IO运行时Modbus RTU节点掉线")]
        Code_202103 = 0x202103,
        #endregion

        #region 电气与安全警告 (Electrical & Safety)
        [Description("风扇电流异常")]
        Code_302380 = 0x302380,
        [Description("本体电流异常一级报警")]
        Code_302381 = 0x302381,
        [Description("本体电流异常二级报警")]
        Code_302382 = 0x302382,
        [Description("本体电流异常三级报警")]
        Code_302383 = 0x302383,
        [Description("用户IO供电电流异常")]
        Code_302384 = 0x302384,
        [Description("IPC电流异常")]
        Code_302385 = 0x302385,
        [Description("本体功率异常")]
        Code_302391 = 0x302391,
        [Description("220V供电电压异常")]
        Code_303181 = 0x303181,
        [Description("主供电继电器异常")]
        Code_303182 = 0x303182,
        [Description("安全信号异常拒绝上电")]
        Code_303184 = 0x303184,
        [Description("5V供电电压异常")]
        Code_303281 = 0x303281,
        [Description("12V供电电压异常")]
        Code_303282 = 0x303282,
        [Description("24V供电电压异常")]
        Code_303283 = 0x303283,
        [Description("本体输出供电电压异常")]
        Code_303381 = 0x303381,
        [Description("PSCB 继电器异常")]
        Code_303387 = 0x303387,
        [Description("PDU温度异常")]
        Code_304281 = 0x304281,
        [Description("制动电阻过温")]
        Code_304282 = 0x304282,
        [Description("手柄急停安全输入异常")]
        Code_305081 = 0x305081,
        [Description("外部急停安全输入异常")]
        Code_305082 = 0x305082,
        [Description("保护性停止信号输入异常")]
        Code_305083 = 0x305083,
        [Description("SCB继电器异常")]
        Code_305084 = 0x305084,
        [Description("制动电阻过温")]
        Code_305085 = 0x305085,
        [Description("手柄使能输入异常")]
        Code_305086 = 0x305086,
        [Description("附加急停安全输入异常")]
        Code_305087 = 0x305087,
        [Description("附加保护性停止安全输入异常")]
        Code_305088 = 0x305088,
        [Description("保护性停止复位安全输入异常")]
        Code_305089 = 0x305089,
        [Description("缩减模式安全输入异常")]
        Code_30508A = 0x30508A,
        [Description("三位置使能安全输入异常")]
        Code_30508B = 0x30508B,
        [Description("关闭碰撞检测安全输入异常")]
        Code_305090 = 0x305090,
        [Description("设置碰撞灵敏度LV1安全输入异常")]
        Code_305091 = 0x305091,
        [Description("设置碰撞灵敏度LV2安全输入异常")]
        Code_305092 = 0x305092,
        [Description("设置碰撞灵敏度LV3安全输入异常")]
        Code_305093 = 0x305093,
        [Description("设置碰撞灵敏度LV4安全输入异常")]
        Code_305094 = 0x305094,
        [Description("设置碰撞灵敏度LV5安全输入异常")]
        Code_305095 = 0x305095,
        [Description("设置碰撞灵敏度极低安全输入异常")]
        Code_305097 = 0x305097,
        [Description("手柄CAN通信中断")]
        Code_308181 = 0x308181,
        [Description("控制器CAN通信中断")]
        Code_308182 = 0x308182,
        [Description("本体CAN通信中断")]
        Code_308183 = 0x308183,
        [Description("TIO CAN通信中断")]
        Code_308184 = 0x308184,
        [Description("等待CAN通信正常超时")]
        Code_308185 = 0x308185,
        [Description("拖拽模式TCP速度超限")]
        Code_309081 = 0x309081,
        [Description("急停触发")]
        Code_309082 = 0x309082,
        [Description("机器人整机功率报警阈值")]
        Code_309083 = 0x309083,
        [Description("力矩传感器通讯初始化失败")]
        Code_3F0001 = 0x3F0001,
        [Description("接收力矩传感器数据失败")]
        Code_3F1001 = 0x3F1001,
        [Description("接收力矩传感器数据格式错误")]
        Code_3F1002 = 0x3F1002,
        #endregion

        #region 状态与事件 (Status & Events)
        [Description("系统急停触发")]
        Code_10F0000 = 0x10F0000,
        [Description("系统急停复位")]
        Code_10F0001 = 0x10F0001,
        [Description("机器人电源已打开")]
        Code_10F0002 = 0x10F0002,
        [Description("机器人电源已关闭")]
        Code_10F0003 = 0x10F0003,
        [Description("机器人伺服使能完成")]
        Code_10F0004 = 0x10F0004,
        [Description("机器人伺服使能关闭")]
        Code_10F0005 = 0x10F0005,
        [Description("机器人退出倍率模式")]
        Code_10F0006 = 0x10F0006,
        [Description("机器人进入一级倍率模式")]
        Code_10F0007 = 0x10F0007,
        [Description("机器人进入二级倍率模式")]
        Code_10F0008 = 0x10F0008,
        [Description("机器人进入保护性停止")]
        Code_10F0009 = 0x10F0009,
        [Description("机器人退出碰撞保护性停止")]
        Code_10F000A = 0x10F000A,
        [Description("机器人进入碰撞保护性停止")]
        Code_10F000B = 0x10F000B,
        [Description("机器人关节限位状态恢复")]
        Code_10F000C = 0x10F000C,
        [Description("传送带功能已开启")]
        Code_10F000D = 0x10F000D,
        [Description("传送带功能已关闭")]
        Code_10F000E = 0x10F000E,
        [Description("柔顺控制功能已开启")]
        Code_10F000F = 0x10F000F,
        [Description("柔顺控制功能已关闭")]
        Code_10F0010 = 0x10F0010,
        [Description("机器人进入拖拽模式")]
        Code_10F0011 = 0x10F0011,
        [Description("机器人退出拖拽模式")]
        Code_10F0012 = 0x10F0012,
        [Description("机器人进入力控牵引模式")]
        Code_10F0013 = 0x10F0013,
        [Description("机器人退出力控牵引模式")]
        Code_10F0014 = 0x10F0014,
        [Description("机器人SERVO运动模式已开启")]
        Code_10F0015 = 0x10F0015,
        [Description("机器人SERVO运动模式已关闭")]
        Code_10F0016 = 0x10F0016,
        [Description("机器人超出安全边界外")]
        Code_10F0017 = 0x10F0017,
        [Description("机器人返回安全边界内")]
        Code_10F0018 = 0x10F0018,
        [Description("开启笛卡尔空间限速")]
        Code_10F0019 = 0x10F0019,
        [Description("停止笛卡尔空间限速")]
        Code_10F001A = 0x10F001A,
        [Description("作业程序开始执行")]
        Code_10F001B = 0x10F001B,
        [Description("作业程序暂停执行")]
        Code_10F001C = 0x10F001C,
        [Description("作业程序恢复执行")]
        Code_10F001D = 0x10F001D,
        [Description("作业程序停止执行")]
        Code_10F001E = 0x10F001E,
        [Description("机器人进入缩减模式")]
        Code_10F0020 = 0x10F0020,
        [Description("机器人退出缩减模式")]
        Code_10F0021 = 0x10F0021,
        [Description("机器人进入动量缩减")]
        Code_10F0022 = 0x10F0022,
        [Description("机器人进入功率缩减")]
        Code_10F0023 = 0x10F0023,
        [Description("机器人退出保护性停止")]
        Code_10F0024 = 0x10F0024,
        [Description("用户安全配置发生变更")]
        Code_10F0025 = 0x10F0025,
        [Description("用户安全配置初始姿态变更")]
        Code_10F0026 = 0x10F0026,
        [Description("用户安全配置初始姿态误差变更")]
        Code_10F0027 = 0x10F0027,
        [Description("用户安全配置控制器运行模式变更")]
        Code_10F0028 = 0x10F0028,
        [Description("用户安全配置关节负限位变更")]
        Code_10F0029 = 0x10F0029,
        [Description("用户安全配置关节正限位变更")]
        Code_10F002A = 0x10F002A,
        [Description("用户安全功能di配置变更")]
        Code_10F002B = 0x10F002B,
        [Description("用户安全功能do配置变更")]
        Code_10F002C = 0x10F002C,
        [Description("机器人功率限制配置变更")]
        Code_10F002D = 0x10F002D,
        [Description("机器人末端速度限制变更")]
        Code_10F002E = 0x10F002E,
        [Description("用户安全配置停止距离变更")]
        Code_10F002F = 0x10F002F,
        [Description("用户安全配置停止时间变更")]
        Code_10F0030 = 0x10F0030,
        [Description("肘部速度限制变更")]
        Code_10F0031 = 0x10F0031,
        [Description("动量限制变更")]
        Code_10F0032 = 0x10F0032,
        [Description("关节速度限制变更")]
        Code_10F0033 = 0x10F0033,
        [Description("关节误差报警阈值变更")]
        Code_10F0034 = 0x10F0034,
        [Description("工具姿态约束变更")]
        Code_10F0035 = 0x10F0035,
        [Description("碰撞选项变更")]
        Code_10F0036 = 0x10F0036,
        [Description("伺服关节力矩限制变更")]
        Code_10F0037 = 0x10F0037,
        [Description("开机默认加载配置变更")]
        Code_10F0038 = 0x10F0038,
        [Description("上电自动使能状态变更")]
        Code_10F0039 = 0x10F0039,
        [Description("使能自动运行程序状态变更")]
        Code_10F003A = 0x10F003A,
        [Description("安全平面全局配置变更")]
        Code_10F003B = 0x10F003B,
        [Description("初始化过程检测到安全参数变化")]
        Code_10F003C = 0x10F003C,
        [Description("末端力限制变更")]
        Code_10F003D = 0x10F003D,
        [Description("关节灵敏度变更")]
        Code_10F003F = 0x10F003F,
        [Description("碰撞使能状态变更")]
        Code_10F0040 = 0x10F0040,
        [Description("单个安全平面配置变更")]
        Code_10F0041 = 0x10F0041,
        [Description("单个安全平面点位变更")]
        Code_10F0042 = 0x10F0042,
        [Description("机器人缩减模式下功率限制配置变更")]
        Code_10F0043 = 0x10F0043,
        [Description("缩减模式下动量限制变更")]
        Code_10F0044 = 0x10F0044,
        [Description("机器人缩减模式下末端速度限制变更")]
        Code_10F0045 = 0x10F0045,
        [Description("缩减模式下停止距离变更")]
        Code_10F0046 = 0x10F0046,
        [Description("用户安全配置缩减模式下停止时间变更")]
        Code_10F0047 = 0x10F0047,
        [Description("急停时禁止上电")]
        Code_10F0048 = 0x10F0048,
        [Description("机器人末端拖拽速度限制变更")]
        Code_10F0049 = 0x10F0049,
        [Description("无法恢复程序执行")]
        Code_10F0060 = 0x10F0060,
        [Description("回到初始位置失败")]
        Code_10F0061 = 0x10F0061,
        [Description("力矩传感器已开启")]
        Code_10F0100 = 0x10F0100,
        [Description("力矩传感器已关闭")]
        Code_10F0101 = 0x10F0101,
        [Description("扩展IO模块已启用")]
        Code_10F0102 = 0x10F0102,
        [Description("扩展IO模块已关闭")]
        Code_10F0103 = 0x10F0103,
        [Description("控制手柄锁定")]
        Code_10F0104 = 0x10F0104,
        [Description("功能DI（执行程序）已触发")]
        Code_10F0200 = 0x10F0200,
        [Description("功能DI（暂停程序）已触发")]
        Code_10F0201 = 0x10F0201,
        [Description("功能DI（恢复程序）已触发")]
        Code_10F0202 = 0x10F0202,
        [Description("功能DI（停止程序）已触发")]
        Code_10F0203 = 0x10F0203,
        [Description("功能DI（打开电源）已触发")]
        Code_10F0204 = 0x10F0204,
        [Description("功能DI（关闭电源）已触发")]
        Code_10F0205 = 0x10F0205,
        [Description("功能DI（伺服使能打开）已触发")]
        Code_10F0206 = 0x10F0206,
        [Description("功能DI（伺服使能关闭）已触发")]
        Code_10F0207 = 0x10F0207,
        [Description("功能DI（进入一级倍率模式）已触发")]
        Code_10F0208 = 0x10F0208,
        [Description("功能DI（进入二级倍率模式）已触发")]
        Code_10F0209 = 0x10F0209,
        [Description("功能DI（进入保护性停止）已触发")]
        Code_10F020A = 0x10F020A,
        [Description("功能DI（返回初始位置）已触发")]
        Code_10F020B = 0x10F020B,
        [Description("功能DI（清除碰撞）已触发")]
        Code_10F020C = 0x10F020C,
        [Description("功能DI（进入拖拽模式）已触发")]
        Code_10F020D = 0x10F020D,
        [Description("功能DI（退出拖拽模式）已触发")]
        Code_10F020E = 0x10F020E,
        [Description("功能DI（停止程序 或 暂停程序）已触发，（运行程序）不该被执行")]
        Code_10F020F = 0x10F020F,
        [Description("功能DI（暂停程序）已触发，（恢复程序）不该被执行")]
        Code_10F0210 = 0x10F0210,
        [Description("功能DI（关闭电源）已触发，（打开电源）不该被执行")]
        Code_10F0211 = 0x10F0211,

        [Description("功能DI（下使能）已触发，（上使能）不该被执行")]
        Code_10F0212 = 0x10F0212,

        [Description("功能DO（作业空闲）置位")]
        Code_10F0220 = 0x10F0220,

        [Description("功能DO（作业空闲）复位")]
        Code_10F0221 = 0x10F0221,

        [Description("功能DO（作业程序暂停）置位")]
        Code_10F0222 = 0x10F0222,

        [Description("功能DO（作业程序暂停）复位")]
        Code_10F0223 = 0x10F0223,

        [Description("功能DO（作业程序运行中）置位")]
        Code_10F0224 = 0x10F0224,

        [Description("功能DO（作业程序运行中）复位")]
        Code_10F0225 = 0x10F0225,

        [Description("功能DO（控制系统故障）置位")]
        Code_10F0226 = 0x10F0226,

        [Description("功能DO（控制系统故障）复位")]
        Code_10F0227 = 0x10F0227,

        [Description("功能DO（机器人电源已打开）置位")]
        Code_10F0228 = 0x10F0228,

        [Description("功能DO（机器人电源已打开）复位")]
        Code_10F0229 = 0x10F0229,

        [Description("功能DO（伺服使能已打开）置位")]
        Code_10F022A = 0x10F022A,

        [Description("功能DO（伺服使能已打开）复位")]
        Code_10F022B = 0x10F022B,

        [Description("功能DO（机器人运动中）置位")]
        Code_10F022C = 0x10F022C,

        [Description("功能DO（机器人运动中）复位")]
        Code_10F022D = 0x10F022D,

        [Description("功能DO（机器人静止）置位")]
        Code_10F022E = 0x10F022E,

        [Description("功能DO（机器人静止）复位")]
        Code_10F022F = 0x10F022F,

        [Description("功能DO（控制系统已就绪）置位")]
        Code_10F0230 = 0x10F0230,

        [Description("功能DO（控制系统已就绪）复位")]
        Code_10F0231 = 0x10F0231,

        [Description("功能DO（机器人急停）置位")]
        Code_10F0232 = 0x10F0232,

        [Description("功能DO（机器人急停）复位")]
        Code_10F0233 = 0x10F0233,

        [Description("功能DO（机器人处于二级倍率模式）置位")]
        Code_10F0234 = 0x10F0234,

        [Description("功能DO（机器人处于二级倍率模式）复位")]
        Code_10F0235 = 0x10F0235,

        [Description("功能DO（机器人处于保护性停止）置位")]
        Code_10F0236 = 0x10F0236,

        [Description("功能DO（机器人处于保护性停止）复位")]
        Code_10F0237 = 0x10F0237,

        [Description("功能DO（机器人处于初始位）置位")]
        Code_10F0238 = 0x10F0238,

        [Description("功能DO（机器人处于初始位）复位")]
        Code_10F0239 = 0x10F0239,

        [Description("功能DO（机器人处于一级倍率模式）置位")]
        Code_10F0240 = 0x10F0240,

        [Description("功能DO（机器人处于一级倍率模式）复位")]
        Code_10F0241 = 0x10F0241,

        [Description("安全功能DI（附加急停）已触发")]
        Code_10F0250 = 0x10F0250,

        [Description("安全功能DI（附加保护性停止）已触发")]
        Code_10F0251 = 0x10F0251,

        [Description("安全功能DI（保护性停止复位）已触发")]
        Code_10F0252 = 0x10F0252,

        [Description("安全功能DI（缩减模式）已触发")]
        Code_10F0253 = 0x10F0253,

        [Description("安全功能DI（三位置使能）已触发")]
        Code_10F0254 = 0x10F0254,

        [Description("安全功能DI设置碰撞灵敏度（level0）已触发")]
        Code_10F0255 = 0x10F0255,

        [Description("安全功能DI设置碰撞灵敏度（level1）已触发")]
        Code_10F0256 = 0x10F0256,

        [Description("安全功能DI设置碰撞灵敏度（level2）已触发")]
        Code_10F0257 = 0x10F0257,

        [Description("安全功能DI设置碰撞灵敏度（level3）已触发")]
        Code_10F0258 = 0x10F0258,

        [Description("安全功能DI设置碰撞灵敏度（level4）已触发")]
        Code_10F0259 = 0x10F0259,

        [Description("安全功能DI设置碰撞灵敏度（level5）已触发")]
        Code_10F025A = 0x10F025A,

        [Description("安全功能DI设置碰撞灵敏度（level7）已触发")]
        Code_10F025B = 0x10F025B,

        [Description("安全功能DI（保护性停止）已触发")]
        Code_10F025C = 0x10F025C,

        [Description("安全功能DO（按钮急停触发）置位")]
        Code_10F0260 = 0x10F0260,

        [Description("安全功能DO（按钮急停触发）复位")]
        Code_10F0261 = 0x10F0261,

        [Description("安全功能DO（系统急停触发）置位")]
        Code_10F0262 = 0x10F0262,

        [Description("安全功能DO（系统急停触发）复位")]
        Code_10F0263 = 0x10F0263,

        [Description("安全功能DO（机器人处于保护性停止）置位")]
        Code_10F0264 = 0x10F0264,

        [Description("安全功能DO（机器人处于保护性停止）复位")]
        Code_10F0265 = 0x10F0265,

        [Description("安全功能DO（机器人运动中）置位")]
        Code_10F0266 = 0x10F0266,

        [Description("安全功能DO（机器人运动中）复位")]
        Code_10F0267 = 0x10F0267,

        [Description("安全功能DO（机器人处于缩减模式）置位")]
        Code_10F0268 = 0x10F0268,

        [Description("安全功能DO（机器人处于缩减模式）复位")]
        Code_10F0269 = 0x10F0269,

        [Description("动力学参数辨识完成")]
        Code_10F0280 = 0x10F0280,

        [Description("摩擦力参数辨识完成")]
        Code_10F0281 = 0x10F0281,

        [Description("写动力学参数完成")]
        Code_10F0282 = 0x10F0282,

        [Description("碰撞反弹终止")]
        Code_10F0283 = 0x10F0283,

        [Description("本次碰撞无反弹")]
        Code_10F0284 = 0x10F0284,

        [Description("制动电阻启动电压设置成功")]
        Code_10F0285 = 0x10F0285,

        [Description("程序已经在运行")]
        Code_10F0286 = 0x10F0286,

        [Description("登录初始化失败")]
        Code_10F0300 = 0x10F0300,

        [Description("此版本为测试版本")]
        Code_10F0301 = 0x10F0301,

        [Description("程序运行完成")]
        Code_10F2000 = 0x10F2000,

        [Description("终止程序运行")]
        Code_10F2001 = 0x10F2001
        #endregion
    }
}
