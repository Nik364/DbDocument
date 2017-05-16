using System.Data;
using System.Data.SqlClient;

namespace Nik.DbDoc.Domain.Data
{
    /// <summary>
    /// 数据库扩展属性访问类
    /// </summary>
    public class ExtendProp : Base
    {
        /// <summary>
        /// 修改扩展属性
        /// </summary>
        /// <param name="dbName">数据库名称</param>
        /// <param name="prop">数据库属性</param>
        public void Update(string dbName, Model.ExtendProp prop)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@name",SqlDbType.NVarChar,128) { Value = prop.Name },
                new SqlParameter("@value",SqlDbType.Variant) { Value = prop.Value },
                new SqlParameter("@level0type",SqlDbType.NVarChar,128) { Value = prop.SchemaType },
                new SqlParameter("@level0name",SqlDbType.NVarChar,128) { Value = prop.SchemaName },
                new SqlParameter("@level1type",SqlDbType.NVarChar,128) { Value = prop.TableType },
                new SqlParameter("@level1name",SqlDbType.NVarChar,128) { Value = prop.TableName },
                new SqlParameter("@level2type",SqlDbType.NVarChar,128) { Value = prop.ColumnType },
                new SqlParameter("@level2name",SqlDbType.NVarChar,128) { Value = prop.ColumnName },
            };
            ExecNonQuerySql(CommandType.StoredProcedure, "sys.sp_updateextendedproperty", parms);
        }
        
        /// <summary>
        /// 添加扩展属性
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="prop"></param>
        public void Add(string dbName, Model.ExtendProp prop)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@name",SqlDbType.NVarChar,128) { Value = prop.Name },
                new SqlParameter("@value",SqlDbType.Variant) { Value = prop.Value },
                new SqlParameter("@level0type",SqlDbType.NVarChar,128) { Value = prop.SchemaType },
                new SqlParameter("@level0name",SqlDbType.NVarChar,128) { Value = prop.SchemaName },
                new SqlParameter("@level1type",SqlDbType.NVarChar,128) { Value = prop.TableType },
                new SqlParameter("@level1name",SqlDbType.NVarChar,128) { Value = prop.TableName },
                new SqlParameter("@level2type",SqlDbType.NVarChar,128) { Value = prop.ColumnType },
                new SqlParameter("@level2name",SqlDbType.NVarChar,128) { Value = prop.ColumnName },
            };
            ExecNonQuerySql(CommandType.StoredProcedure, "sys.sp_addextendedproperty", parms);
        }

        /// <summary>
        /// 扩展属性是否存在
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="prop"></param>
        /// <returns></returns>
        public bool Exist(string dbName, Model.ExtendProp prop)
        {
            return false;
        }
    }
}
