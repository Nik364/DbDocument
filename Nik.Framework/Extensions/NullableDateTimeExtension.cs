using System;

namespace Nik.Framework.Extensions
{
    /// <summary>
    /// DateTime?扩展方法
    /// </summary>
    public static class NullableDateTimeExtension
    {
        /// <summary>
        /// 格式化可空日期类型
        /// </summary>
        /// <param name="time">日期</param>
        /// <param name="format">格式化日期</param>
        /// <returns></returns>
        public static string ToString(this DateTime? time, string format)
        {
            return time?.ToString(format) ?? "";
        }
    }
}