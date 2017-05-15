using Nik.DbDoc.Core.ApiModel;
using Nik.Framework.Copy.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Nik.DbDoc.Core.Service
{
    public class Table
    {
        private readonly Domain.Data.Table dal = new Domain.Data.Table();

        /// <summary>
        /// 获取数据库表列表
        /// </summary>
        /// <param name="dbName">数据库名称</param>
        /// <returns></returns>
        public IList<TableModel> GetList(string dbName)
        {
            var dbs = dal.GetList(dbName);
            var dbModels = from item in dbs select item.CopyTo<TableModel>();
            return dbModels.ToList();
        }

        /// <summary>
        /// 获取数据库列表
        /// </summary>
        /// <param name="dbName">数据库名称</param>
        /// <param name="tableName">数据库表名称</param>
        /// <returns></returns>
        public IList<FieldModel> GetFieldList(string dbName, string tableName)
        {
            var dbs = dal.GetFieldList(dbName, tableName);
            var dbModels = from item in dbs select item.CopyTo<FieldModel>();
            return dbModels.ToList();
        }
    }
}