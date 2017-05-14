using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nik.Framework.Extensions
{
    /// <summary>
    /// Json相关方法扩展
    /// </summary>
    public static class JsonExtension
    {
        /// <summary>
        /// 将对象转化为json格式字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeObject<T>(this T obj)
        {
            var timeFormat = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
            return JsonConvert.SerializeObject(obj, Formatting.Indented, timeFormat);
        }

        /// <summary>
        /// 将json字符串反序列化为Object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}