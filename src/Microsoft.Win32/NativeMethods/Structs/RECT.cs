using System.Drawing;
using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// 矩形结构定义
    /// </summary>
    public static partial class NativeMethods
    {
        /// <summary>
        /// 矩形结构
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            /// <summary>
            /// 左上角水平坐标
            /// </summary>
            public int left;
            /// <summary>
            /// 左上角垂直坐标
            /// </summary>
            public int top;
            /// <summary>
            /// 右下角水平坐标
            /// </summary>
            public int right;
            /// <summary>
            /// 右下角垂直坐标
            /// </summary>
            public int bottom;

            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="left">左上角水平坐标</param>
            /// <param name="top">左上角垂直坐标</param>
            /// <param name="right">右下角水平坐标</param>
            /// <param name="bottom">右下角垂直坐标</param>
            public RECT(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }

            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="r">Rectangle结构</param>
            public RECT(Rectangle r)
            {
                this.left = r.Left;
                this.top = r.Top;
                this.right = r.Right;
                this.bottom = r.Bottom;
            }

            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="x">左上角水平坐标</param>
            /// <param name="y">左上角垂直坐标</param>
            /// <param name="width">宽度</param>
            /// <param name="height">高度</param>
            /// <returns>矩形结构</returns>
            public static NativeMethods.RECT FromXYWH(int x, int y, int width, int height)
            {
                return new NativeMethods.RECT(x, y, x + width, y + height);
            }

            /// <summary>
            /// 宽度
            /// </summary>
            public int Width
            {
                get
                {
                    return this.right - this.left;
                }
            }

            /// <summary>
            /// 高度
            /// </summary>
            public int Height
            {
                get
                {
                    return this.bottom - this.top;
                }
            }

            /// <summary>
            /// 左上角
            /// </summary>
            public Point Location
            {
                get
                {
                    return new Point(this.left, this.top);
                }
            }

            /// <summary>
            /// 右下角
            /// </summary>
            public Point BottomRight
            {
                get
                {
                    return new Point(this.right, this.bottom);
                }
            }

            /// <summary>
            /// 大小
            /// </summary>
            public Size Size
            {
                get
                {
                    return new Size(this.right - this.left, this.bottom - this.top);
                }
            }

            /// <summary>
            /// 转换为 System.Drawing.Rectangle.
            /// </summary>
            /// <returns>System.Drawing.Rectangle</returns>
            public Rectangle ToRectangle()
            {
                return new Rectangle(this.left, this.top, this.right - this.left, this.bottom - this.top);
            }

            /// <summary>
            /// 是否包含指定点
            /// </summary>
            /// <param name="pt">点</param>
            /// <returns>包含返回true,否则返回false</returns>
            public bool Contains(NativeMethods.POINT pt)
            {
                return this.Contains(pt.x, pt.y);
            }

            /// <summary>
            /// 是否包含指定点
            /// </summary>
            /// <param name="pt">点</param>
            /// <returns>包含返回true,否则返回false</returns>
            public bool Contains(Point pt)
            {
                return this.Contains(pt.X, pt.Y);
            }

            /// <summary>
            /// 是否包含指定坐标
            /// </summary>
            /// <param name="x">水平坐标</param>
            /// <param name="y">垂直坐标</param>
            /// <returns>包含返回true,否则返回false</returns>
            public bool Contains(int x, int y)
            {
                return ((this.left <= x) && (x < this.right) && (this.top <= y) && (y < this.bottom));
            }
        }
    }
}
