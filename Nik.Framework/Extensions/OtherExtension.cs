using System;
using System.ComponentModel;
using System.Reflection;

namespace Nik.Framework.Extensions
{
    /// <summary>
    /// 其他扩展方法
    /// </summary>
    public class OtherExtension
    {
        /// <summary>
        /// 获取对象的指定属性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="attributeName">字段名称</param>
        /// <returns></returns>
        public static string GetDescriptionAttribute<T>(string attributeName) where T : new()
        {
            var type = typeof(T);
            if (type.IsEnum)
            {
                return GetEnumDescription<T>(attributeName);
            }

            var info = type.GetProperty(attributeName, BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance);
            return GetDescription(info);
        }

        /// <summary>
        /// 获取枚举的Description
        /// </summary>
        /// <param name="attributeName">要获取描述信息的枚举项。</param>
        /// <returns>枚举想的描述信息。</returns>
        public static string GetEnumDescription<T>(string attributeName)
        {
            var type = typeof(T);
            if (!type.IsEnum)
            {
                return "";
            }

            // 获取枚举字段。
            var info = type.GetField(attributeName);
            return GetDescription(info);
        }

        /// <summary>
        /// 获取对象程序Description
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private static string GetDescription(MemberInfo info)
        {
            if (info == null)
            {
                return "";
            }
            // 获取描述的属性。
            var attr = Attribute.GetCustomAttribute(info, typeof(DescriptionAttribute), false) as DescriptionAttribute;
            return attr == null ? "" : attr.Description;
        }
    }
}