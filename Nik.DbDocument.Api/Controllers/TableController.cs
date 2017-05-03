using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Nik.DbDocument.Business.Service;
using Nik.DbDocument.Web.Core.Models;

namespace Nik.DbDocument.Api.Controllers
{
    public class TableController : ApiController
    {
        private readonly Table bll = new Table();

        /// <summary>
        /// 获取数据库表列表
        /// </summary>
        /// <param name="dbName">数据库名</param>
        /// <returns></returns>
        public AjaxResult Get(string dbName)
        {
            return new AjaxResult
            {
                PromptMsg = "查询成功",
                Result = DoResult.Success,
                RetValue = bll.GetList(dbName)
            };
        }

        /// <summary>
        /// 获取数据库表字段列表
        /// </summary>
        /// <param name="dbName">数据库名</param>
        /// <param name="tableName">数据库表名称</param>
        /// <returns></returns>
        public AjaxResult GetDetail(string dbName, string tableName)
        {
            return new AjaxResult
            {
                PromptMsg = "查询成功",
                Result = DoResult.Success,
                RetValue = bll.GetFieldList(dbName, tableName)
            };
        }
    }
}
