using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nik.Framework.Extensions;

namespace Nik.DbDocument.Business.Data
{
    /// <summary>
    /// 数据库访问对象
    /// </summary>
    public class Table : Base
    {
        /// <summary>
        /// 获取数据库列表
        /// </summary>
        /// <param name="dbName">数据库名称</param>
        /// <returns></returns>
        public IList<Model.Table> GetList(string dbName)
        {
            string sql = string.Format(@"
                SELECT obj.name, obj.crdate createDate, prop.value caption 
                FROM {0}.sys.sysobjects obj LEFT JOIN {0}.sys.extended_properties prop ON obj.id = prop.major_id 
                WHERE prop.minor_id = 0", dbName);
            
            DataTable dt = this.ExecSql(sql).Tables[0];
            return dt.ToModel<Model.Table>();
        }
    }
}
