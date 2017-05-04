using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using Nik.DbDocument.ApiModel;
using Nik.DbDocument.Web.Core.Extensions;
using Nik.DbDocument.Business.Service;
using Nik.DbDocument.Web.Core.Models;

namespace Nik.DbDocument.Api.Controllers
{
    public class DbController : ApiController
    {
        private readonly DataBase bll = new DataBase();

        public AjaxResult Get()
        {
            return new AjaxResult
            {
                PromptMsg = "查询成功",
                Result = DoResult.Success,
                RetValue = bll.GetList()
            };
        }

        //public IEnumerable<DataBaseModel> Get()
        //{
        //    return bll.GetList();
        //}

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}