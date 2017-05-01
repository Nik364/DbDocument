using System;
using System.Configuration;

namespace Nik.Framework.Config
{
    /// <summary>
    /// web.config操作类
    /// </summary>
    public sealed class ConfigHelper
    {
        /// <summary>
        /// 得到AppSettings中的配置字符串信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConfigString(string key)
        {
            return GetConfigString(key, null);
        }

        /// <summary>
        /// 得到AppSettings中的配置字符串信息
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static string GetConfigString(string key, string defaultValue)
        {
            var result = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(result))
            {
                result = defaultValue;
            }
            return result;
        }

        /// <summary>
        /// 得到AppSettings中的配置信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetConfig<T>(string key)
        {
            try
            {
                var val = GetConfigString(key);
                return (T)Convert.ChangeType(val, typeof(T));
            }
            catch
            {
                return default(T);
            }
        }
    }
}