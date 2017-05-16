namespace Nik.DbDoc.Domain.Data
{
    /// <summary>
    /// 数据库扩展属性访问类
    /// </summary>
    public class ExtendProp : Base
    {
        /// <summary>
        /// 修改扩展属性
        /// </summary>
        /// <param name="dbname">数据库名称</param>
        /// <param name="prop">数据库属性</param>
        public void Update(string dbname, ExtendProp prop)
        {

        }


        /// <summary>
        /// 添加扩展属性
        /// </summary>
        /// <param name="dbname"></param>
        /// <param name="prop"></param>
        public void Add(string dbname, ExtendProp prop)
        {
        }

        /// <summary>
        /// 扩展属性是否存在
        /// </summary>
        /// <param name="dbname"></param>
        /// <param name="prop"></param>
        /// <returns></returns>
        public bool Exist(string dbname, ExtendProp prop)
        {
            return true;
        }
    }
}
