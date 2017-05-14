namespace Nik.DbDoc.Domain.Model
{
    /// <summary>
    /// 数据库表字段实体
    /// </summary>
    public class Field
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
        /// 默认值
        /// </summary>
        public string Default { get; set; } = "";

        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; } = "";
    }
}