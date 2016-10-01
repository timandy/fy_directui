using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.Drawing
{
    /// <summary>
    /// 颜色向量,只支持加减操作,不支持乘除操作
    /// Copyright (c) JajaSoft
    /// </summary>
    [Serializable, StructLayout(LayoutKind.Sequential), ComVisible(true), TypeConverter(typeof(ColorVectorConverter))]
    public struct ColorVector
    {
        #region 静态

        /// <summary>
        /// A=0,R=0,G=0,B=0
        /// </summary>
        public static readonly ColorVector Empty;

        /// <summary>
        /// 静态构造
        /// </summary>
        static ColorVector()
        {
            Empty = new ColorVector();
        }

        /// <summary>
        /// 生成Long,各占16位共64位
        /// </summary>
        /// <param name="alpha">A</param>
        /// <param name="red">R</param>
        /// <param name="green">G</param>
        /// <param name="blue">B</param>
        /// <returns>长整型数值</returns>
        private static long MakeLong(int alpha, int red, int green, int blue)
        {
            ulong ulA = (ulong)(alpha & ushort.MaxValue);
            ulong ulR = (ulong)(red & ushort.MaxValue);
            ulong ulG = (ulong)(green & ushort.MaxValue);
            ulong ulB = (ulong)(blue & ushort.MaxValue);
            return (long)((ulA << 0x30) | (ulR << 0x20) | (ulG << 0x10) | ulB);
        }


        /// <summary>
        /// 从一个64位整数创建ColorVector结构
        /// </summary>
        /// <param name="value">64位整数</param>
        /// <returns>ColorVector结构</returns>
        public static ColorVector FromArgb(long value)
        {
            return new ColorVector(value);
        }

        /// <summary>
        /// 从一个Color结构创建ColorVector结构
        /// </summary>
        /// <param name="color">Color结构</param>
        /// <returns>ColorVector结构</returns>
        public static ColorVector FromArgb(Color color)
        {
            return new ColorVector(color.A, color.R, color.G, color.B);
        }

        /// <summary>
        /// 从一个Color结构创建ColorVector结构,但Alpha使用指定的值
        /// </summary>
        /// <param name="alpha">Alpha指定值</param>
        /// <param name="color">Color结构</param>
        /// <returns>ColorVector结构</returns>
        public static ColorVector FromArgb(int alpha, Color color)
        {
            return new ColorVector(alpha, color.R, color.G, color.B);
        }

        /// <summary>
        /// 从一个ColorVector结构创建ColorVector结构,但Alpha使用指定值
        /// </summary>
        /// <param name="alpha">Alpha指定值</param>
        /// <param name="vector">ColorVector结构</param>
        /// <returns>ColorVector结构</returns>
        public static ColorVector FromArgb(int alpha, ColorVector vector)
        {
            return new ColorVector(alpha, vector.R, vector.G, vector.B);
        }

        /// <summary>
        /// 从三个16位整数创建ColorVector结构,Alpha使用0
        /// </summary>
        /// <param name="red">Red值</param>
        /// <param name="green">Green值</param>
        /// <param name="blue">Blue值</param>
        /// <returns>ColorVector结构</returns>
        public static ColorVector FromArgb(int red, int green, int blue)
        {
            return new ColorVector(0, red, green, blue);
        }

        /// <summary>
        /// 从四个16位整数创建ColorVector结构
        /// </summary>
        /// <param name="alpha">Alpha值</param>
        /// <param name="red">Red值</param>
        /// <param name="green">Green值</param>
        /// <param name="blue">Blue值</param>
        /// <returns>ColorVector结构</returns>
        public static ColorVector FromArgb(int alpha, int red, int green, int blue)
        {
            return new ColorVector(alpha, red, green, blue);
        }

        #endregion


        #region 字段属性

        //64位值
        private long Value;

        /// <summary>
        /// Alpha分量上的偏移量
        /// </summary>
        public short A
        {
            get
            {
                return (short)((this.Value >> 0x30) & ushort.MaxValue);
            }
        }

        /// <summary>
        /// 红色分量上的偏移量
        /// </summary>
        public short R
        {
            get
            {
                return (short)((this.Value >> 0x20) & ushort.MaxValue);
            }
        }

        /// <summary>
        /// 绿色分量上的偏移量
        /// </summary>
        public short G
        {
            get
            {
                return (short)((this.Value >> 0x10) & ushort.MaxValue);
            }
        }

        /// <summary>
        /// 蓝色分量上的偏移量
        /// </summary>
        public short B
        {
            get
            {
                return (short)(this.Value & ushort.MaxValue);
            }
        }

        #endregion


        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="value">长整型数值</param>
        private ColorVector(long value)
        {
            this.Value = value;
        }

        /// <summary>
        /// 构造函数,各占16位.short(-32768,32767)
        /// </summary>
        /// <param name="alpha">A</param>
        /// <param name="red">R</param>
        /// <param name="green">G</param>
        /// <param name="blue">B</param>
        private ColorVector(int alpha, int red, int green, int blue)
            : this(MakeLong(alpha, red, green, blue))
        {
        }

        #endregion


        #region 公共方法

        /// <summary>
        /// 获取Hash值
        /// </summary>
        /// <returns>返回</returns>
        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        /// <summary>
        /// 转换为字符串
        /// </summary>
        /// <returns>字符串</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(0x20);
            builder.Append(base.GetType().Name);
            builder.Append(" [");
            if (this == ColorVector.Empty)
            {
                builder.Append("Empty");
            }
            else
            {
                builder.Append("A=");
                builder.Append(this.A);
                builder.Append(", R=");
                builder.Append(this.R);
                builder.Append(", G=");
                builder.Append(this.G);
                builder.Append(", B=");
                builder.Append(this.B);
            }
            builder.Append("]");
            return builder.ToString();
        }

        /// <summary>
        /// 判断两个是否相等
        /// </summary>
        /// <param name="obj">目标对象</param>
        /// <returns>相等返回true,否则返回false</returns>
        public override bool Equals(object obj)
        {
            if (obj is ColorVector)
            {
                ColorVector vector = (ColorVector)obj;
                return this == vector;
            }
            return false;
        }

        /// <summary>
        /// 转换为颜色
        /// </summary>
        /// <returns>颜色</returns>
        public Color ToColor()
        {
            return Color.FromArgb(MathEx.Clamp(this.A, (byte)0, (byte)255),
                MathEx.Clamp(this.R, (byte)0, (byte)255),
                MathEx.Clamp(this.G, (byte)0, (byte)255),
                MathEx.Clamp(this.B, (byte)0, (byte)255));
        }

        #endregion


        #region 操作符

        /// <summary>
        /// 等于
        /// </summary>
        /// <param name="left">左值</param>
        /// <param name="right">右值</param>
        /// <returns>相等返回true,否则返回false</returns>
        public static bool operator ==(ColorVector left, ColorVector right)
        {
            return left.Value == right.Value;
        }

        /// <summary>
        /// 等于
        /// </summary>
        /// <param name="left">左值</param>
        /// <param name="right">右值</param>
        /// <returns>不等返回true,否则返回false</returns>
        public static bool operator !=(ColorVector left, ColorVector right)
        {
            return !(left == right);
        }

        /// <summary>
        /// 大于
        /// </summary>
        /// <param name="left">左值</param>
        /// <param name="right">右值</param>
        /// <returns>A,R,G,B全部大于返回true,否则返回false</returns>
        public static bool operator >(ColorVector left, ColorVector right)
        {
            return left.A > right.A
                && left.R > right.R
                && left.G > right.G
                && left.B > right.B;
        }

        /// <summary>
        /// 大于等于
        /// </summary>
        /// <param name="left">左值</param>
        /// <param name="right">右值</param>
        /// <returns>A,R,G,B全部大于等于返回true,否则返回false</returns>
        public static bool operator >=(ColorVector left, ColorVector right)
        {
            return left.A >= right.A
                && left.R >= right.R
                && left.G >= right.G
                && left.B >= right.B;
        }

        /// <summary>
        /// 小于
        /// </summary>
        /// <param name="left">左值</param>
        /// <param name="right">右值</param>
        /// <returns>A,R,G,B全部小于返回true,否则返回false</returns>
        public static bool operator <(ColorVector left, ColorVector right)
        {
            return left.A < right.A
                && left.R < right.R
                && left.G < right.G
                && left.B < right.B;
        }

        /// <summary>
        /// 小于等于
        /// </summary>
        /// <param name="left">左值</param>
        /// <param name="right">右值</param>
        /// <returns>A,R,G,B全部小于等于返回true,否则返回false</returns>
        public static bool operator <=(ColorVector left, ColorVector right)
        {
            return left.A <= right.A
                && left.R <= right.R
                && left.G <= right.G
                && left.B <= right.B;
        }

        /// <summary>
        /// 两个颜色向量相加
        /// </summary>
        /// <param name="left">左值</param>
        /// <param name="right">右值</param>
        /// <returns>返回新颜色向量</returns>
        public static ColorVector operator +(ColorVector left, ColorVector right)
        {
            return new ColorVector(left.A + right.A, left.R + right.R, left.G + right.G, left.B + right.B);
        }

        /// <summary>
        /// 颜色加上颜色向量
        /// </summary>
        /// <param name="left">颜色</param>
        /// <param name="right">颜色向量</param>
        /// <returns>返回新颜色</returns>
        public static Color operator +(Color left, ColorVector right)
        {
            return Color.FromArgb(MathEx.Clamp(left.A + right.A, (byte)0, (byte)255),
                MathEx.Clamp(left.R + right.R, (byte)0, (byte)255),
                MathEx.Clamp(left.G + right.G, (byte)0, (byte)255),
                MathEx.Clamp(left.B + right.B, (byte)0, (byte)255));
        }

        /// <summary>
        /// 两个颜色向量相减
        /// </summary>
        /// <param name="left">左值</param>
        /// <param name="right">右值</param>
        /// <returns>返回新颜色向量</returns>
        public static ColorVector operator -(ColorVector left, ColorVector right)
        {
            return new ColorVector(left.A - right.A, left.R - right.R, left.G - right.G, left.B - right.B);
        }

        /// <summary>
        /// 颜色减去颜色向量
        /// </summary>
        /// <param name="left">颜色</param>
        /// <param name="right">颜色向量</param>
        /// <returns>返回新颜色</returns>
        public static Color operator -(Color left, ColorVector right)
        {
            return Color.FromArgb(MathEx.Clamp(left.A - right.A, (byte)0, (byte)255),
                MathEx.Clamp(left.R - right.R, (byte)0, (byte)255),
                MathEx.Clamp(left.G - right.G, (byte)0, (byte)255),
                MathEx.Clamp(left.B - right.B, (byte)0, (byte)255));
        }

        /// <summary>
        /// 颜色向量乘以浮点数
        /// </summary>
        /// <param name="left">颜色向量</param>
        /// <param name="right">浮点数</param>
        /// <returns>返回新颜色向量</returns>
        public static ColorVector operator *(ColorVector left, float right)
        {
            return new ColorVector((int)(left.A * right), (int)(left.R * right), (int)(left.G * right), (int)(left.B * right));
        }

        /// <summary>
        /// 浮点数乘以颜色向量
        /// </summary>
        /// <param name="left">浮点数</param>
        /// <param name="right">颜色向量</param>
        /// <returns>返回新颜色向量</returns>
        public static ColorVector operator *(float left, ColorVector right)
        {
            return new ColorVector((int)(left * right.A), (int)(left * right.R), (int)(left * right.G), (int)(left * right.B));
        }

        /// <summary>
        /// 颜色向量乘以整数
        /// </summary>
        /// <param name="left">颜色向量</param>
        /// <param name="right">浮点数</param>
        /// <returns>返回新颜色向量</returns>
        public static ColorVector operator *(ColorVector left, int right)
        {
            return new ColorVector(left.A * right, left.R * right, left.G * right, left.B * right);
        }

        /// <summary>
        /// 整数乘以颜色向量
        /// </summary>
        /// <param name="left">整数</param>
        /// <param name="right">颜色向量</param>
        /// <returns>返回新颜色向量</returns>
        public static ColorVector operator *(int left, ColorVector right)
        {
            return new ColorVector(left * right.A, left * right.R, left * right.G, left * right.B);
        }

        /// <summary>
        /// 颜色向量除以浮点数
        /// </summary>
        /// <param name="left">颜色向量</param>
        /// <param name="right">浮点数</param>
        /// <returns>返回新颜色向量</returns>
        public static ColorVector operator /(ColorVector left, float right)
        {
            return new ColorVector((int)(left.A / right), (int)(left.R / right), (int)(left.G / right), (int)(left.B / right));
        }

        /// <summary>
        /// 浮点数除以颜色向量
        /// </summary>
        /// <param name="left">浮点数</param>
        /// <param name="right">颜色向量</param>
        /// <returns>返回新颜色向量</returns>
        public static ColorVector operator /(float left, ColorVector right)
        {
            return new ColorVector((int)(left / right.A), (int)(left / right.R), (int)(left / right.G), (int)(left / right.B));
        }

        /// <summary>
        /// 颜色向量除以整数
        /// </summary>
        /// <param name="left">颜色向量</param>
        /// <param name="right">整数</param>
        /// <returns>返回新颜色向量</returns>
        public static ColorVector operator /(ColorVector left, int right)
        {
            return new ColorVector(left.A / right, left.R / right, left.G / right, left.B / right);
        }

        /// <summary>
        /// 整数除以颜色向量
        /// </summary>
        /// <param name="left">整数</param>
        /// <param name="right">颜色向量</param>
        /// <returns>返回新颜色向量</returns>
        public static ColorVector operator /(int left, ColorVector right)
        {
            return new ColorVector(left / right.A, left / right.R, left / right.G, left / right.B);
        }

        #endregion
    }
}
