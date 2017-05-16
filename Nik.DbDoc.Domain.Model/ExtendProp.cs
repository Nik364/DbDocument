namespace Nik.DbDoc.Domain.Model
{
    /// <summary>
    /// 数据库扩展属性实体
    /// </summary>
    public class ExtendProp
    {
        /// <summary>
        /// 扩展属性名
        /// </summary>
        internal string Name { get; set; } = "MS_Description";
        
        /// <summary>
        /// 架构类型
        /// </summary>
        internal string SchemaType { get; set; } = "SCHEMA";

        /// <summary>
        /// 表类型
        /// </summary>
        internal string TableType { get; set; } = "TABLE";

        /// <summary>
        /// 列类型
        /// </summary>
        internal string ColumnType { get; set; } = "COLUMN";

        /// <summary>
        /// 扩展属性值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 架构名
        /// </summary>
        public string SchemaName { get; set; } = "dbo";

        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 列名
        /// </summary>
        public string ColumnName { get; set; }
    }
}
