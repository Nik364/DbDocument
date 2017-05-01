using System.Text;

namespace Nik.Framework.Extensions
{
    /// <summary>
    /// HString类替代系统string，
    /// 内部采用StringBuilder拼接，减少string+操作时对象的创建。
    /// </summary>
    public sealed class HString
    {
        /// <summary>
        /// 内部StringBuilder变量
        /// </summary>
        private readonly StringBuilder builder = null;

        /// <summary>
        /// 默认无参数构造函数
        /// </summary>
        public HString()
        {
            if (builder == null)
            {
                builder = new StringBuilder();
            }
        }

        /// <summary>
        /// 带string参数的构造函数
        /// </summary>
        public HString(string v)
            : this()
        {
            builder.Append(v);
        }

        /// <summary>
        /// 将string对象隐式转换为HString对象
        /// </summary>
        public static implicit operator HString(string v)
        {
            return new HString(v);
        }

        /// <summary>
        /// 将HString对象隐式转换为字符串
        /// </summary>
        public static implicit operator string(HString v)
        {
            return v.ToString();
        }

        /// <summary>
        /// HString + string方式
        /// </summary>
        public static HString operator +(HString hs, string v)
        {
            if (string.IsNullOrEmpty(v) == false)
            {
                hs.builder.Append(v);
            }
            return hs;
        }

        /// <summary>
        /// string + HString方式
        /// </summary>
        public static HString operator +(string v, HString hs)
        {
            if (string.IsNullOrEmpty(v) == false)
            {
                hs.builder.Insert(0, v);
            }
            return hs;
        }

        /// <summary>
        /// object + HString方式
        /// </summary>
        public static HString operator +(object v, HString hs)
        {
            if (v != null)
            {
                hs.builder.Insert(0, v);
            }
            return hs;
        }

        /// <summary>
        /// HString + object方式
        /// </summary>
        public static HString operator +(HString hs, object v)
        {
            if (v != null)
            {
                hs.builder.Append(v);
            }
            return hs;
        }

        /// <summary>
        /// 追加格式化字符串
        /// </summary>
        public void AppendFormat(string format, params object[] args)
        {
            if (args != null && args.Length > 0)
            {
                builder.AppendFormat(format, args);
            }
        }

        /// <summary>
        /// 重载对象的默认ToString方法输出拼接字符
        /// </summary>
        public override string ToString()
        {
            return builder.ToString();
        }
    }
}