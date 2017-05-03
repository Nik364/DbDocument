using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nik.DbDocument.ApiModel;

namespace Nik.DbDocument.Business.Service
{
    public class Table
    {
        private readonly Data.Table dal = new Data.Table();

        /// <summary>
        /// 获取数据库表列表
        /// </summary>
        /// <param name="dbName">数据库名称</param>
        /// <returns></returns>
        public IList<TableModel> GetList(string dbName)
        {
            var dbs = dal.GetList(dbName);
            var dbModels = from item in dbs
                           select new TableModel()
                           {
                               Name = item.Name,
                               Caption = item.Caption,
                               CreateDate = item.CreateDate
                           };
            return dbModels.ToList();
        }
    }
}
