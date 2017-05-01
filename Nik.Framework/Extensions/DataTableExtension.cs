using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Nik.Framework.Extensions
{
    /// <summary>
    /// DataTable扩展方法
    /// </summary>
    public static class DataTableExtension
    {
        /// <summary>
        /// 将DataTable转换为T类型
        /// </summary>
        /// <typeparam name="T">数据实体类型</typeparam>
        /// <param name="dt">数据集</param>
        /// <returns>数据列表</returns>
        public static IList<T> ToModel<T>(this DataTable dt) where T : new()
        {
            return (from DataRow dr in dt.Rows select dr.ToModel<T>()).ToList();
        }
    }
}