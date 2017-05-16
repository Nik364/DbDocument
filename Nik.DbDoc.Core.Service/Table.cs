using Nik.DbDoc.Core.ApiModel;
using Nik.Framework.Copy.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Nik.DbDoc.Core.Service
{
    public class Table
    {
        /// <summary>
        /// 获取数据库表列表
        /// </summary>
        /// <param name="dbName">数据库名称</param>
        /// <returns></returns>
        public IList<TableModel> GetList(string dbName)
        {
            Domain.Data.Table dal = new Domain.Data.Table();
            var dbs = dal.GetList(dbName);
            var dbModels = from item in dbs select item.CopyTo<TableModel>();
            return dbModels.ToList();
        }

        /// <summary>
        /// 获取数据库表字段列表
        /// </summary>
        /// <param name="dbName">数据库名称</param>
        /// <param name="tableName">数据库表名称</param>
        /// <returns></returns>
        public IList<FieldModel> GetFieldList(string dbName, string tableName)
        {
            Domain.Data.Field dal = new Domain.Data.Field();
            var dbs = dal.GetList(dbName, tableName);
            var dbModels = from item in dbs select item.CopyTo<FieldModel>();
            return dbModels.ToList();
        }

        /// <summary>
        /// 新增或者更新字段描述
        /// 若不存在则新增否则更新
        /// </summary>
        /// <param name="dbName">数据库名</param>
        /// <param name="model">扩展对象属性</param>
        public void AddOrUpdateFieldCaption(string dbName, ExtendPropModel model)
        {
            Domain.Data.ExtendProp dal = new Domain.Data.ExtendProp();
            var prop = model.CopyTo<Domain.Model.ExtendProp>();
            if (dal.Exist(dbName, prop))
            {
                dal.Update(dbName, prop);
            }
            else
            {
                dal.Add(dbName, prop);
            }
        }
    }
}