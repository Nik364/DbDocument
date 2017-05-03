using Nik.Framework.Config;
using Nik.Framework.Data;
using System.Data;
using System.Data.SqlClient;

namespace Nik.DbDocument.Business.Data
{
    public class Base
    {
        /// <summary>
        /// DB连接字符串
        /// </summary>
        public string DbConnectionString => ConfigHelper.GetConfigString("connStr");

        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>DataSet</returns>
        public DataSet ExecSql(string sql)
        {
            return SqlHelper.ExecuteDataset(DbConnectionString, CommandType.Text, sql);
        }

        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>DataSet</returns>
        public DataSet ExecSql(string sql, params SqlParameter[] parameters)
        {
            return SqlHelper.ExecuteDataset(DbConnectionString, CommandType.Text, sql, parameters);
        }

        /// <summary>
        /// 执行非查询语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public int ExecNonQuerySql(string sql)
        {
            return SqlHelper.ExecuteNonQuery(DbConnectionString, CommandType.Text, sql);
        }

        /// <summary>
        /// 执行非查询语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public int ExecNonQuerySql(string sql, params SqlParameter[] parameters)
        {
            return SqlHelper.ExecuteNonQuery(DbConnectionString, CommandType.Text, sql, parameters);
        }

        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>查询所返回的结果集中第一行的第一列</returns>
        public object ExecScalar(string sql)
        {
            return SqlHelper.ExecuteScalar(DbConnectionString, CommandType.Text, sql);
        }

        /// <summary>
        /// 执行查询SQL
        /// </summary>
        /// <param name="sql">SQL语句字符串</param>
        /// <param name="parameters">参数</param>
        /// <returns>查询所返回的结果集中第一行的第一列</returns>
        public object ExecScalar(string sql, params SqlParameter[] parameters)
        {
            return SqlHelper.ExecuteScalar(DbConnectionString, CommandType.Text, sql, parameters);
        }
    }
}