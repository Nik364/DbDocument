using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nik.DbDocument.Business.Model
{
    /// <summary>
    /// 数据库表实体
    /// </summary>
    public class Table
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
