using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// Gdiplus.dll
    /// </summary>
    public static partial class UnsafeNativeMethods
    {
        /// <summary>
        /// 测试字符串大小
        /// </summary>
        /// <param name="hGraphics">绘图对象句柄</param>
        /// <param name="szText">要测试的字符串</param>
        /// <param name="nLength">字符串长度</param>
        /// <param name="hFont">字体句柄</param>
        /// <param name="aPositions">坐标数组</param>
        /// <param name="nFlags">标记</param>
        /// <param name="hMatrix"></param>
        /// <param name="tBounds">区域</param>
        /// <returns></returns>
        [DllImport("gdiplus.dll", CharSet = CharSet.Auto)]
        public extern static int GdipMeasureDriverString(IntPtr hGraphics, string szText, int nLength, IntPtr hFont, PointF[] aPositions, int nFlags, IntPtr hMatrix, ref RectangleF tBounds);
        /// <summary>
        /// 绘制字符串
        /// </summary>
        /// <param name="hGraphics">绘图对象</param>
        /// <param name="szText">要绘制的文本</param>
        /// <param name="nLength">字符串长度</param>
        /// <param name="hFont">字体句柄</param>
        /// <param name="hBrush">画刷句柄</param>
        /// <param name="aPositions">坐标数组</param>
        /// <param name="nFlags">标记</param>
        /// <param name="hMatrix">向量矩阵</param>
        /// <returns></returns>
        [DllImport("gdiplus.dll", CharSet = CharSet.Auto)]
        public extern static int GdipDrawDriverString(IntPtr hGraphics, string szText, int nLength, IntPtr hFont, IntPtr hBrush, PointF[] aPositions, int nFlags, IntPtr hMatrix);
    }
}
