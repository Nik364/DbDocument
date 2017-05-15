using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Reflection;

namespace Nik.Framework.Copy.Extensions
{
    /// <summary>
    /// ICopy扩展方法
    /// </summary>
    public static class CopyExtension
    {
        /// <summary>
        /// 将对象转化为json格式字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T CopyTo<T>(this ICopy obj) where T : new()
        {
            if (obj == null)
            {
                return default(T);
            }
            T result = new T();

            var sourceProps = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var targetProps = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var tp in targetProps)
            {
                if (!tp.CanWrite)
                {
                    continue;
                }

                foreach (var sp in sourceProps)
                {
                    if (!string.Equals(tp.Name, sp.Name, StringComparison.OrdinalIgnoreCase)) continue;
                    tp.SetValue(result, sp.GetValue(obj));
                    break;
                }
            }
            return result;
        }
    }
}
