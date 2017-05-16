using Nik.Framework.Extensions;
using System.Collections.Generic;
using System.Data;

namespace Nik.DbDoc.Domain.Data
{
    /// <summary>
    /// 数据库表访问对象
    /// </summary>
    public class Table : Base
    {
        /// <summary>
        /// 获取数据库表列表
        /// </summary>
        /// <param name="dbName">数据库名称</param>
        /// <returns></returns>
        public IList<Model.Table> GetList(string dbName)
        {
            this.DbName = dbName;

            const string sql = @"
                SELECT obj.name, obj.crdate createDate, prop.value caption
                FROM sys.sysobjects obj LEFT JOIN sys.extended_properties prop ON obj.id = prop.major_id AND prop.minor_id = 0
                WHERE obj.[type] = 'U'
                ORDER BY obj.name;";

            DataTable dt = this.ExecSql(sql).Tables[0];
            return dt.ToModel<Model.Table>();
        }
    }
}