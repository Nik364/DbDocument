﻿using System;

namespace Nik.DbDocument.Business.Model
{
    /// <summary>
    /// 数据库对象
    /// </summary>
    public class DataBase
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// 描述
        /// </summary>
        public string Caption { get; set; } = "";

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
