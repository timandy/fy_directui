using System.Drawing;

namespace Microsoft.Drawing
{
    /// <summary>
    /// 点帮助类
    /// </summary>
    public static class PointEx
    {
        /// <summary>
        /// 平移指定量
        /// </summary>
        /// <param name="p">点</param>
        /// <param name="size">平移量</param>
        /// <returns>平移后的点</returns>
        public static Point Offset(Point p, Size size)
        {
            p.Offset(size.Width, size.Height);
            return p;
        }

        /// <summary>
        /// 平移指定量
        /// </summary>
        /// <param name="p">点</param>
        /// <param name="pos">平移量</param>
        /// <returns>平移后的点</returns>
        public static Point Offset(Point p, Point pos)
        {
            p.Offset(pos);
            return p;
        }

        /// <summary>
        /// 平移指定量
        /// </summary>
        /// <param name="p">点</param>
        /// <param name="dx">水平平移量</param>
        /// <param name="dy">垂直平移量</param>
        /// <returns>平移后的点</returns>
        public static Point Offset(Point p, int dx, int dy)
        {
            p.Offset(dx, dy);
            return p;
        }
    }
}
