﻿using Nik.DbDoc.Core.ApiModel;
using System.Collections.Generic;
using System.Linq;

namespace Nik.DbDoc.Core.Service
{
    public class DataBase
    {
        private readonly Domain.Data.DataBase dal = new Domain.Data.DataBase();

        /// <summary>
        /// 获取数据库列表
        /// </summary>
        /// <returns></returns>
        public IList<DataBaseModel> GetList()
        {
            var dbs = dal.GetList();
            var dbModels = from item in dbs
                           select new DataBaseModel()
                           {
                               Name = item.Name,
                               Caption = item.Caption,
                               CreateDate = item.CreateDate
                           };
            return dbModels.ToList();
        }
    }
}