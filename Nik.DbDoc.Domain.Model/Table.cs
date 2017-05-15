using System;
using Nik.Framework.Copy;

namespace Nik.DbDoc.Domain.Model
{
    /// <summary>
    /// 数据库表实体
    /// </summary>
    public class Table : ICopy
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// 描述
        /// </summary>
        public string Caption { get; set; } = "";

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}