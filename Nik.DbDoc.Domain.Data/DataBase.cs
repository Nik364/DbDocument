using Nik.Framework.Extensions;
using System.Collections.Generic;
using System.Data;

namespace Nik.DbDoc.Domain.Data
{
    /// <summary>
    /// 数据库访问对象
    /// </summary>
    public class DataBase : Base
    {
        /// <summary>
        /// 获取数据库列表
        /// </summary>
        /// <returns></returns>
        public IList<Model.DataBase> GetList()
        {
            string sql = @"
                CREATE TABLE #tmpDbCaption(
	                Value NVARCHAR(128),
	                Name NVARCHAR(128)
                )

                DECLARE @sql NVARCHAR(MAX);
                SELECT @sql = LEFT(Tmp, LEN(Tmp) - 10)  FROM (
	                SELECT (
		                SELECT 'SELECT CAST(Value AS NVARCHAR(128)), ''' + name + ''' Name FROM ' + name + '.sys.extended_properties WHERE class = 0 UNION ALL ' FROM master..sysdatabases FOR XML PATH('')
	                ) Tmp
                ) DbCaption;
                INSERT INTO #tmpDbCaption EXEC (@sql);

                SELECT db.name, db.crdate createDate, caption.Value caption FROM master..sysdatabases db LEFT JOIN #tmpDbCaption caption ON caption.Name = db.name ORDER BY createDate DESC;
                ";
            DataTable dt = this.ExecSql(sql).Tables[0];
            return dt.ToModel<Model.DataBase>();
        }
    }
}