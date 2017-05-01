using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Nik.DbDocument.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { controller = "db", id = RouteParameter.Optional }
            );

            //移除xml序列化，默认返回json
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            //跨域配置
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            RegisterSerializerSettings();
        }

        /// <summary>
        /// 注册json序列化器
        /// </summary>
        private static void RegisterSerializerSettings()
        {
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local;
            json.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            json.SerializerSettings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat;

            //避免序列化结果出现k__BackingField
            json.SerializerSettings.ContractResolver = new DefaultContractResolver { IgnoreSerializableAttribute = true };
        }
    }
}
