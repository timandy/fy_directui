using System;
using System.Drawing;
using Microsoft.Win32;

namespace Microsoft.Drawing
{
    /// <summary>
    /// Graphics辅助类
    /// </summary>
    public static class GraphicsEx
    {
        /// <summary>
        /// 复制设备内容(不支持Alpha通道)
        /// </summary>
        /// <param name="gSrc">原设备</param>
        /// <param name="gDest">目标设备</param>
        /// <param name="ptDest">源起始坐标</param>
        /// <param name="ptSrc">目标起始坐标</param>
        /// <param name="szBlock">复制大小</param>
        public static void Render(Graphics gSrc, Graphics gDest, Point ptDest, Point ptSrc, Size szBlock)
        {
            if (gSrc == null || gDest == null)
                return;

            IntPtr hdcDest = gDest.GetHdc();
            IntPtr hdcSrc = gSrc.GetHdc();
            try
            {
                UnsafeNativeMethods.BitBlt(hdcDest, ptDest.X, ptDest.Y, szBlock.Width, szBlock.Height, hdcSrc, ptSrc.X, ptSrc.Y, NativeMethods.SRCCOPY);
            }
            finally
            {
                gSrc.ReleaseHdcInternal(hdcSrc);
                gDest.ReleaseHdcInternal(hdcDest);
            }
        }

        /// <summary>
        /// 混合设备内容(支持Alpha通道)
        /// </summary>
        /// <param name="gSrc">原设备</param>
        /// <param name="gDest">目标设备</param>
        /// <param name="ptDest">源起始坐标</param>
        /// <param name="ptSrc">目标起始坐标</param>
        /// <param name="szBlock">复制大小</param>
        public static void BlendRender(Graphics gSrc, Graphics gDest, Point ptDest, Point ptSrc, Size szBlock)
        {
            if (gSrc == null || gDest == null)
                return;

            IntPtr hdcDest = gDest.GetHdc();
            IntPtr hdcSrc = gSrc.GetHdc();
            try
            {
                UnsafeNativeMethods.GdiAlphaBlend(hdcDest, ptDest.X, ptDest.Y, szBlock.Width, szBlock.Height, hdcSrc, ptSrc.X, ptSrc.Y, szBlock.Width, szBlock.Height, NativeMethods.BLENDFUNCTION.Default);
            }
            finally
            {
                gSrc.ReleaseHdcInternal(hdcSrc);
                gDest.ReleaseHdcInternal(hdcDest);
            }
        }

        /// <summary>
        /// 混合设备内容(支持Alpha通道)
        /// </summary>
        /// <param name="gSrc">原设备</param>
        /// <param name="gDest">目标设备</param>
        /// <param name="ptDest">源起始坐标</param>
        /// <param name="ptSrc">目标起始坐标</param>
        /// <param name="szBlock">复制大小</param>
        /// <param name="alpha">透明度[0-255]</param>
        public static void BlendRender(Graphics gSrc, Graphics gDest, Point ptDest, Point ptSrc, Size szBlock, byte alpha)
        {
            if (gSrc == null || gDest == null)
                return;

            IntPtr hdcDest = gDest.GetHdc();
            IntPtr hdcSrc = gSrc.GetHdc();
            try
            {
                UnsafeNativeMethods.GdiAlphaBlend(hdcDest, ptDest.X, ptDest.Y, szBlock.Width, szBlock.Height, hdcSrc, ptSrc.X, ptSrc.Y, szBlock.Width, szBlock.Height, new NativeMethods.BLENDFUNCTION(NativeMethods.AC_SRC_OVER, 0, alpha, NativeMethods.AC_SRC_ALPHA));
            }
            finally
            {
                gSrc.ReleaseHdcInternal(hdcSrc);
                gDest.ReleaseHdcInternal(hdcDest);
            }
        }
    }
}
