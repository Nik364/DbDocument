using System;

namespace Nik.DbDocument.Web.Core.Models
{
    /// <summary>
    /// ajax请求返回实体
    /// </summary>
    [Serializable]
    public class AjaxResult
    {
        /// <summary>
        /// 调试信息
        /// </summary>
        public string DebugMessage { get; set; }

        /// <summary>
        /// 提示信息
        /// </summary>
        public string PromptMsg { get; set; }

        /// <summary>
        /// 状态码
        /// </summary>
        public DoResult Result { get; set; }

        /// <summary>
        /// 返回结果信息
        /// </summary>
        public object RetValue { get; set; }

        /// <summary>
        /// 标记
        /// </summary>
        public object Tag { get; set; }
    }

    /// <summary>
    /// Ajax请求结果状态码
    /// </summary>
    public enum DoResult
    {
        Failed = 0,
        Success = 1,
        OverTime = 2,
        Other = 255
    }
}