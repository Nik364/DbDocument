using Nik.Framework.Data;
using Nik.Framework.Extensions;
using System.Collections.Generic;
using System.Data;

namespace Nik.DbDocument.Business.Data
{
    /// <summary>
    /// 数据库访问对象
    /// </summary>
    public class DataBase
    {
        /// <summary>
        /// 获取数据库列表
        /// </summary>
        /// <returns></returns>
        public IList<Model.DataBase> GetList()
        {
            string sql = @"SELECT name, crdate createDate FROM Master..SysDatabases ORDER BY crdate DESC;";
            DataTable dt = SqlHelper.ExecuteDataset(sql).Tables[0];
            return dt.ToModel<Model.DataBase>();
        }
    }
}