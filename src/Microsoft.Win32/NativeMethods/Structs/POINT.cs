using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// POINT定义
    /// </summary>
    public static partial class NativeMethods
    {
        /// <summary>
        /// POINT
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            /// <summary>
            /// 水平坐标
            /// </summary>
            public int x;
            /// <summary>
            /// 垂直坐标
            /// </summary>
            public int y;

            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="x">水平坐标</param>
            /// <param name="y">垂直坐标</param>
            public POINT(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}
