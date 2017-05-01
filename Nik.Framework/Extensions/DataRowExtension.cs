using System;
using System.Data;
using System.Reflection;

namespace Nik.Framework.Extensions
{
    /// <summary>
    /// DataRow扩展方法
    /// </summary>
    public static class DataRowExtension
    {
        /// <summary>
        /// 将数据行转化为指定对像
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="dr">DataRow 对象</param>
        /// <returns></returns>
        public static T ToModel<T>(this DataRow dr) where T : new()
        {
            if (dr == null) return default(T);
            Type modelType = typeof(T);
            Type stringType = typeof(String);
            Type nullableType = typeof(Nullable<>);
            PropertyInfo[] infos = modelType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            T model = new T();
            foreach (PropertyInfo p in infos)
            {
                if (!p.CanWrite)
                {
                    continue;
                }

                if (dr.Table.Columns.Contains(p.Name) == true)
                {
                    object v = dr[p.Name];
                    //如果是可空类型，且类型是数值类型，则设定默认值
                    if ((v == null || v == DBNull.Value) && p.PropertyType.IsGenericType)
                    {
                        Type nullableBaseType = p.PropertyType.GetGenericArguments()[0];
                        if (nullableBaseType.IsValueType || nullableBaseType.IsPrimitive)
                        {
                            v = Activator.CreateInstance(nullableBaseType);
                        }
                    }

                    if (v != null && v != DBNull.Value && (p.PropertyType.IsValueType || p.PropertyType == stringType))
                    {
                        if (v.GetType().Name.Equals("MySqlDateTime") && v.ToString().Equals("0000/0/0 0:00:00"))
                        {
                            continue;
                        }
                        if ((v.GetType().Name.Equals("DateTime") && v.ToString().Equals("0001/1/1 0:00:00")))
                        {
                            continue;
                        }

                        if (v is TimeSpan)
                        {
                            TimeSpan ts = (TimeSpan)v;
                            v = new DateTime(1970, 1, 1, ts.Hours, ts.Minutes, ts.Seconds);
                        }
                        if (p.PropertyType.IsGenericType == true)
                        {
                            Type genericType = p.PropertyType.GetGenericTypeDefinition();
                            if (nullableType == genericType)
                            {
                                p.SetValue(model, Convert.ChangeType(v, Nullable.GetUnderlyingType(p.PropertyType)), null);
                            }
                        }
                        else if (p.PropertyType.IsEnum)
                        {
                            object obj = Enum.Parse(p.PropertyType, Enum.GetName(p.PropertyType, v));
                            p.SetValue(model, obj, null);
                        }
                        else
                        {
                            p.SetValue(model, Convert.ChangeType(v, p.PropertyType), null);
                        }
                    }
                }
            }
            return model;
        }
    }
}