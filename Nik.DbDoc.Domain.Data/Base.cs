using Nik.Framework.Config;
using Nik.Framework.Db;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Nik.DbDoc.Domain.Data
{
    public class Base
    {
        /// <summary>
        /// 数据库名称
        /// </summary>
        public string DbName { get; set; }

        /// <summary>
        /// DB连接字符串
        /// </summary>
        public string DbConnectionString
        {
            get
            {
                string connStr = ConfigHelper.GetConfigString("connStr");
                if (!string.IsNullOrEmpty(DbName))
                {
                    if (connStr.ToLower().Contains("database"))
                    {
                        connStr = Regex.Replace(connStr, @"(?<=database=)\w+(?=;)", DbName, RegexOptions.IgnoreCase);
                    }
                    else
                    {
                        connStr = Regex.Replace(connStr, @"(?<=Initial Catalog=)\w+(?=;)", DbName, RegexOptions.IgnoreCase);
                    }
                }
                return connStr;
            }
        }

        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>DataSet</returns>
        public DataSet ExecSql(string sql)
        {
            return this.ExecSql(sql, null);
        }

        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>DataSet</returns>
        public DataSet ExecSql(string sql, params SqlParameter[] parameters)
        {
            return this.ExecSql(CommandType.Text, sql, parameters);
        }

        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="type">命令类型</param>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>DataSet</returns>
        public DataSet ExecSql(CommandType type, string sql, params SqlParameter[] parameters)
        {
            return SqlHelper.ExecuteDataset(DbConnectionString, type, sql, parameters);
        }

        /// <summary>
        /// 执行非查询语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public int ExecNonQuerySql(string sql)
        {
            return this.ExecNonQuerySql(sql, null);
        }

        /// <summary>
        /// 执行非查询语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public int ExecNonQuerySql(string sql, params SqlParameter[] parameters)
        {
            return this.ExecNonQuerySql(CommandType.Text, sql, parameters);
        }

        /// <summary>
        /// 执行非查询语句
        /// </summary>
        /// <param name="type">命令类型</param>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public int ExecNonQuerySql(CommandType type, string sql, params SqlParameter[] parameters)
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
            return this.ExecScalar(sql, null);
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