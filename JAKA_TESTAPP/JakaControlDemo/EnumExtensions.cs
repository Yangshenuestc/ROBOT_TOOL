using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace JAKA_TESTAPP.JakaControlDemo
{
    /// <summary>
    /// 高性能 JAKA 错误码解析助手
    /// </summary>
    public static class EnumExtensions
    {
        // 缓存字典：Key=错误码数值, Value=错误描述
        // 使用 Dictionary 实现 O(1) 快速查找，避免每次都反射
        private static readonly Dictionary<long, string> _errorCache = new Dictionary<long, string>();

        /// <summary>
        /// 静态构造函数：程序第一次调用时自动执行，将 Enum 加载到字典中
        /// </summary>
        static EnumExtensions()
        {
            InitializeCache();
        }

        private static void InitializeCache()
        {
            _errorCache.Clear();
            Type enumType = typeof(ErrorcodeEnum);

            // 获取所有枚举值
            foreach (var value in Enum.GetValues(enumType))
            {
                long codeLong = Convert.ToInt64(value);

                // 获取字段信息
                FieldInfo field = enumType.GetField(value.ToString());

                // 获取 [Description] 特性
                DescriptionAttribute attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

                // 如果有描述就用描述，没有就用字段名
                string description = attr != null ? attr.Description : value.ToString();

                // 加入缓存
                if (!_errorCache.ContainsKey(codeLong))
                {
                    _errorCache.Add(codeLong, description);
                }
            }
        }

        /// <summary>
        /// 扩展方法：根据十六进制字符串获取描述
        /// </summary>
        /// <param name="hexCode">例如 "0x102230" 或 "102230"</param>
        public static string GetRobotErrorDescription(this string hexCode)
        {
            if (string.IsNullOrWhiteSpace(hexCode) || hexCode == "0" || hexCode == "0x0")
                return "Ready (无错误)";

            try
            {
                // 1. 清洗字符串
                string cleanHex = hexCode.Trim().Replace("0x", "", StringComparison.OrdinalIgnoreCase);

                // 2. 转换为 long (关键修正：匹配 Enum : long 的定义)
                if (long.TryParse(cleanHex, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out long codeValue))
                {
                    // 3. 从缓存查找 (极速)
                    if (_errorCache.TryGetValue(codeValue, out string desc))
                    {
                        return $"[{hexCode}] {desc}";
                    }
                    else
                    {
                        return $"[{hexCode}] 未知错误码";
                    }
                }
                else
                {
                    return $"[{hexCode}] 格式错误";
                }
            }
            catch
            {
                return $"[{hexCode}] 解析异常";
            }
        }

        /// <summary>
        /// 重载：支持直接传入数值 (如果您的 errcode 是 int/long 类型)
        /// </summary>
        public static string GetRobotErrorDescription(this long errCode)
        {
            if (errCode == 0) return "Ready";

            if (_errorCache.TryGetValue(errCode, out string desc))
            {
                return $"[0x{errCode:X}] {desc}";
            }
            return $"[0x{errCode:X}] 未知错误";
        }

        // 兼容 int 调用
        public static string GetRobotErrorDescription(this int errCode)
        {
            return GetRobotErrorDescription((long)errCode);
        }
    }
}
