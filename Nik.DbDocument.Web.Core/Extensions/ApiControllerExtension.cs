using Nik.Framework.Extensions;
using System;
using System.Text;
using System.Web.Http;
using System.Web.Mvc;

namespace Nik.DbDocument.Web.Core.Extensions
{
    public static class ApiControllerExtension
    {
        public static JsonResult JsonNetResult(this ApiController controller, object data)
        {
            return new JsonNetResult(data);
        }
    }

    public class JsonNetResult : JsonResult
    {
        public JsonNetResult(object data, JsonRequestBehavior behavior = JsonRequestBehavior.AllowGet, string contentType = null, Encoding contentEncoding = null)
        {
            Data = data;
            JsonRequestBehavior = behavior;
            ContentEncoding = contentEncoding;
            ContentType = contentType;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet &&
                string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("JSON GET is not allowed");
            }
            var response = context.HttpContext.Response;
            response.ContentType = string.IsNullOrEmpty(ContentType) ? "application/json" : ContentType;

            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }

            if (Data == null)
            {
                return;
            }

            response.Write(Data.SerializeObject());
        }
    }
}