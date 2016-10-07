using System.Drawing;
using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// TRIVERTEX定义
    /// </summary>
    public static partial class NativeMethods
    {
        /// <summary>
        /// <para>实现功能:The TRIVERTEX structure contains color information and position information.</para>
        /// <para>调用方法:Win32结构体</para>
        /// <para>.</para>
        /// <para>创建人员:许崇雷</para>
        /// <para>创建日期:2013-11-25</para>
        /// <para>创建备注:</para>
        /// <para>.</para>
        /// <para>修改人员:</para>
        /// <para>修改日期:</para>
        /// <para>修改备注:</para>
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct TRIVERTEX
        {
            /// <summary>
            /// The x-coordinate, in logical units, of the upper-left corner of the rectangle.
            /// </summary>
            int x;
            /// <summary>
            /// The y-coordinate, in logical units, of the upper-left corner of the rectangle.
            /// </summary>
            int y;
            /// <summary>
            /// The color information at the point of x, y.
            /// </summary>
            ushort Red;
            /// <summary>
            /// The color information at the point of x, y.
            /// </summary>
            ushort Green;
            /// <summary>
            /// The color information at the point of x, y.
            /// </summary>
            ushort Blue;
            /// <summary>
            /// The color information at the point of x, y.
            /// </summary>
            ushort Alpha;

            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="x">横坐标</param>
            /// <param name="y">纵坐标</param>
            /// <param name="red">R</param>
            /// <param name="green">G</param>
            /// <param name="blue">B</param>
            /// <param name="alpha">A</param>
            public TRIVERTEX(int x, int y, ushort red, ushort green, ushort blue, ushort alpha)
            {
                this.x = x;
                this.y = y;
                this.Red = red;
                this.Green = green;
                this.Blue = blue;
                this.Alpha = alpha;
            }
            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="x">横坐标</param>
            /// <param name="y">纵坐标</param>
            /// <param name="color">颜色</param>
            public TRIVERTEX(int x, int y, Color color)
            {
                this.x = x;
                this.y = y;
                this.Red = color.R;
                this.Green = color.G;
                this.Blue = color.B;
                this.Alpha = color.A;
            }
            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="pt">坐标</param>
            /// <param name="color">颜色</param>
            public TRIVERTEX(Point pt, Color color)
            {
                this.x = pt.X;
                this.y = pt.Y;
                this.Red = color.R;
                this.Green = color.G;
                this.Blue = color.B;
                this.Alpha = color.A;
            }
        }
    }
}
