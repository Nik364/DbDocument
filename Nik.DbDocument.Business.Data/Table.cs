using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            this.DbName = dbName;

            const string sql = @"
                SELECT obj.name, obj.crdate createDate, prop.value caption 
                FROM sys.sysobjects obj LEFT JOIN sys.extended_properties prop ON obj.id = prop.major_id 
                WHERE prop.minor_id = 0";

            DataTable dt = this.ExecSql(sql).Tables[0];
            return dt.ToModel<Model.Table>();
        }

        /// <summary>
        /// 获取数据库列表
        /// </summary>
        /// <param name="dbName">数据库名称</param>
        /// <param name="tableName">数据库表名称</param>
        /// <returns></returns>
        public IList<Model.Field> GetFieldList(string dbName, string tableName)
        {
            this.DbName = dbName;

            const string sql = @"
                SELECT a.name, ISNULL(g.[value], '') caption, e.[text] [default],  
                    	CASE WHEN b.name IN ( 'varchar', 'nvarchar' )
                          THEN b.name + '('
                               + CAST(COLUMNPROPERTY(a.id, a.name, 'PRECISION') AS VARCHAR(4))
                               + ')'
                          WHEN b.name = 'decimal'
                          THEN b.name + '('
                               + CAST(COLUMNPROPERTY(a.id, a.name, 'PRECISION') AS VARCHAR(4))
                               + ','
                               + CAST(COLUMNPROPERTY(a.id, a.name, 'Scale') AS VARCHAR(4))
                               + ')'
                          ELSE b.name END [type]
                FROM sys.syscolumns a   
                    LEFT JOIN sys.systypes b ON a.xusertype = b.xusertype    
                    INNER JOIN sys.sysobjects d ON a.id = d.id AND d.xtype = 'U' AND d.name <> 'dtproperties'  
                    LEFT JOIN sys.syscomments e ON a.cdefault = e.id   
                    LEFT JOIN sys.extended_properties g ON a.id = g.major_id AND a.colid = g.minor_id   
                WHERE d.name = @tableName
                ORDER BY a.id , a.colorder";

            SqlParameter[] parms =
            {
                new SqlParameter("@tableName",SqlDbType.NVarChar,128) { Value = tableName }
            };

            DataTable dt = this.ExecSql(sql, parms).Tables[0];
            return dt.ToModel<Model.Field>();
        }
    }
}
