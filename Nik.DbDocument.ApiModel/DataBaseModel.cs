using System;

namespace Nik.DbDocument.ApiModel
{
    /// <summary>
    /// 数据库对象
    /// </summary>
    [Serializable]
    public class DataBaseModel
    {
        /// <summary>
        /// 数据库名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 数据库描述
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
