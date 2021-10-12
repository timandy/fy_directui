using System;
using System.Drawing;
using System.Reflection;

namespace Microsoft.Drawing
{
    /// <summary>
    /// BufferedGraphicsEx辅助类
    /// </summary>
    public static class BufferedGraphicsEx
    {
        private static readonly FieldInfo FiTargetLoc;      //BufferedGraphics.targetLoc字段信息
        private static readonly FieldInfo FiVirtulSize;     //BufferedGraphics.virtualSize字段信息

        /// <summary>
        /// 静态构造
        /// </summary>
        static BufferedGraphicsEx()
        {
            Type type = typeof(BufferedGraphics);
            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
            FiTargetLoc = type.GetField("_targetLoc", flags);
            FiVirtulSize = type.GetField("_virtualSize", flags);
        }

        /// <summary>
        /// 获取缓冲区的目标坐标。
        /// </summary>
        /// <param name="bg">缓冲区。</param>
        /// <returns>缓冲区的目标坐标</returns>
        public static Point GetTargetLoc(BufferedGraphics bg)
        {
            if (bg == null)
                throw new ArgumentNullException("bg");

            return (Point)FiTargetLoc.GetValue(bg);
        }

        /// <summary>
        /// 获取缓冲区的虚拟尺寸大小。
        /// </summary>
        /// <param name="bg">缓冲区。</param>
        /// <returns>缓冲区的虚拟尺寸大小。</returns>
        public static Size GetVirtualSize(BufferedGraphics bg)
        {
            if (bg == null)
                throw new ArgumentNullException("bg");

            return (Size)FiVirtulSize.GetValue(bg);
        }

        /// <summary>
        /// 将图形缓冲区的内容写入指定的 System.Drawing.Graphics 对象。
        /// </summary>
        /// <param name="bgSrc">图形缓冲区，要混合的源。</param>
        /// <param name="gDest">一个 System.Drawing.Graphics 对象，要向其中写入图形缓冲区的内容。</param>
        /// <param name="rcDest">目标矩形。</param>
        public static void Render(BufferedGraphics bgSrc, Graphics gDest, Rectangle rcDest)
        {
            //验证
            if (bgSrc == null || gDest == null || !RectangleEx.IsVisible(rcDest))
                return;

            //反射获取私有字段 
            Point targetLoc = (Point)FiTargetLoc.GetValue(bgSrc);
            targetLoc.Offset(rcDest.X, rcDest.Y);
            Size virtualSize = rcDest.Size;
            Point sourceLoc = rcDest.Location;

            //混合渲染
            GraphicsEx.Render(bgSrc.Graphics, gDest, targetLoc, sourceLoc, virtualSize);
        }

        /// <summary>
        /// 将图形缓冲区的内容与指定的 System.Drawing.Graphics 对象混合。(支持缓冲区Alpha通道)
        /// </summary>
        /// <param name="bgSrc"></param>
        /// <param name="gDest">一个 System.Drawing.Graphics 对象，图形缓冲区要混合的目标。</param>
        public static void BlendRender(BufferedGraphics bgSrc, Graphics gDest)
        {
            //验证
            if (bgSrc == null || gDest == null)
                return;

            //反射获取私有字段
            Point targetLoc = (Point)FiTargetLoc.GetValue(bgSrc);
            Size virtualSize = (Size)FiVirtulSize.GetValue(bgSrc);

            //混合渲染
            GraphicsEx.BlendRender(bgSrc.Graphics, gDest, targetLoc, Point.Empty, virtualSize);
        }

        /// <summary>
        /// 将图形缓冲区的内容与指定的 System.Drawing.Graphics 对象混合。(支持缓冲区Alpha通道)
        /// </summary>
        /// <param name="bgSrc">图形缓冲区，要混合的源。</param>
        /// <param name="gDest">一个 System.Drawing.Graphics 对象，图形缓冲区要混合的目标。</param>
        /// <param name="rcDest">目标矩形。</param>
        public static void BlendRender(BufferedGraphics bgSrc, Graphics gDest, Rectangle rcDest)
        {
            //验证
            if (bgSrc == null || gDest == null || !RectangleEx.IsVisible(rcDest))
                return;

            //反射获取私有字段
            Point targetLoc = (Point)FiTargetLoc.GetValue(bgSrc);
            targetLoc.Offset(rcDest.X, rcDest.Y);
            Size virtualSize = rcDest.Size;
            Point sourceLoc = rcDest.Location;

            //混合渲染
            GraphicsEx.BlendRender(bgSrc.Graphics, gDest, targetLoc, sourceLoc, virtualSize);
        }
    }
}
