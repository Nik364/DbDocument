using System;

namespace Nik.DbDoc.Core.ApiModel
{
    /// <summary>
    /// 数据库表对象
    /// </summary>
    [Serializable]
    public class TableModel
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}