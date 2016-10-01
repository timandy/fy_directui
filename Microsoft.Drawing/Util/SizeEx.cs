using System.Drawing;

namespace Microsoft.Drawing
{
    /// <summary>
    /// Size 操作
    /// </summary>
    public static class SizeEx
    {
        /// <summary>
        /// 宽度放大倍数
        /// </summary>
        /// <param name="size">Size</param>
        /// <param name="count">倍数</param>
        /// <returns>新的Size</returns>
        public static Size MultiplyWidth(Size size, int count)
        {
            return new Size(size.Width * count, size.Height);
        }

        /// <summary>
        /// 高度放大倍数
        /// </summary>
        /// <param name="size">Size</param>
        /// <param name="count">倍数</param>
        /// <returns>新的Size</returns>
        public static Size MultiplyHeight(Size size, int count)
        {
            return new Size(size.Width, size.Height * count);
        }

        /// <summary>
        /// 宽度和高度放大倍数
        /// </summary>
        /// <param name="size">Size</param>
        /// <param name="count">倍数</param>
        /// <returns>新的Size</returns>
        public static Size MultiplyBoth(Size size, int count)
        {
            return new Size(size.Width * count, size.Height * count);
        }
    }
}
