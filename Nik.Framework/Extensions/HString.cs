using System.Text;

namespace Nik.Framework.Extensions
{
    /// <summary>
    /// HString�����ϵͳstring��
    /// �ڲ�����StringBuilderƴ�ӣ�����string+����ʱ����Ĵ�����
    /// </summary>
    public sealed class HString
    {
        /// <summary>
        /// �ڲ�StringBuilder����
        /// </summary>
        private readonly StringBuilder builder = null;

        /// <summary>
        /// Ĭ���޲������캯��
        /// </summary>
        public HString()
        {
            if (builder == null)
            {
                builder = new StringBuilder();
            }
        }

        /// <summary>
        /// ��string�����Ĺ��캯��
        /// </summary>
        public HString(string v)
            : this()
        {
            builder.Append(v);
        }

        /// <summary>
        /// ��string������ʽת��ΪHString����
        /// </summary>
        public static implicit operator HString(string v)
        {
            return new HString(v);
        }

        /// <summary>
        /// ��HString������ʽת��Ϊ�ַ���
        /// </summary>
        public static implicit operator string(HString v)
        {
            return v.ToString();
        }

        /// <summary>
        /// HString + string��ʽ
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
        /// string + HString��ʽ
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
        /// object + HString��ʽ
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
        /// HString + object��ʽ
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
        /// ׷�Ӹ�ʽ���ַ���
        /// </summary>
        public void AppendFormat(string format, params object[] args)
        {
            if (args != null && args.Length > 0)
            {
                builder.AppendFormat(format, args);
            }
        }

        /// <summary>
        /// ���ض����Ĭ��ToString�������ƴ���ַ�
        /// </summary>
        public override string ToString()
        {
            return builder.ToString();
        }
    }
}