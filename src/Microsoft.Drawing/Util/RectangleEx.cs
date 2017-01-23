using System.Drawing;
using System.Windows.Forms;

namespace Microsoft.Drawing
{
    /// <summary>
    /// 矩形帮助类
    /// </summary>
    public static class RectangleEx
    {
        /// <summary>
        /// 调整矩形非空,影响原来矩形
        /// </summary>
        /// <param name="rect">要调整的矩形</param>
        public static void MakeNotEmpty(ref Rectangle rect)
        {
            if (rect.Width < 1)
                rect.Width = 1;
            if (rect.Height < 1)
                rect.Height = 1;
        }

        /// <summary>
        /// 获取矩形是否可见
        /// </summary>
        /// <param name="rect">矩形</param>
        /// <returns>宽度大于0并且高度大于0返回true,否则返回false</returns>
        public static bool IsVisible(Rectangle rect)
        {
            return rect.Width > 0 && rect.Height > 0;
        }

        /// <summary>
        /// 在指定的方向放大矩形,不影响原来的矩形
        /// </summary>
        /// <param name="rect">矩形</param>
        /// <param name="align">方向</param>
        /// <param name="value">放大量</param>
        /// <returns>放大后的矩形</returns>
        public static Rectangle Inflate(Rectangle rect, TabAlignment align, int value)
        {
            switch (align)
            {
                case TabAlignment.Top:
                    rect.Y -= value;
                    rect.Height += value;
                    break;

                case TabAlignment.Bottom:
                    rect.Height += value;
                    break;

                case TabAlignment.Left:
                    rect.X -= value;
                    rect.Width += value;
                    break;

                case TabAlignment.Right:
                    rect.Width += value;
                    break;

                default:
                    break;
            }

            return rect;
        }

        /// <summary>
        /// 在指定的方向和反向放大矩形,不影响原来的矩形
        /// </summary>
        /// <param name="rect">矩形</param>
        /// <param name="align">方向</param>
        /// <param name="value">放大量</param>
        /// <param name="revalue">反向放大量</param>
        /// <returns>放大后矩形</returns>
        public static Rectangle Inflate(Rectangle rect, TabAlignment align, int value, int revalue)
        {
            switch (align)
            {
                case TabAlignment.Top:
                    rect.Y -= value;
                    rect.Height += value + revalue;
                    break;

                case TabAlignment.Bottom:
                    rect.Y -= revalue;
                    rect.Height += revalue + value;
                    break;

                case TabAlignment.Left:
                    rect.X -= value;
                    rect.Width += value + revalue;
                    break;

                case TabAlignment.Right:
                    rect.X -= revalue;
                    rect.Width += revalue + value;
                    break;

                default:
                    break;
            }

            return rect;
        }

        /// <summary>
        /// 在指定的方向的两侧放大矩形,不影响原来的矩形
        /// </summary>
        /// <param name="rect">矩形</param>
        /// <param name="align">方向</param>
        /// <param name="value">放大量</param>
        /// <returns>放大后矩形</returns>
        public static Rectangle InflateSide(Rectangle rect, TabAlignment align, int value)
        {
            int half = value / 2;
            switch (align)
            {
                case TabAlignment.Top:
                case TabAlignment.Bottom:
                    rect.X -= half;
                    rect.Width += value;
                    break;

                case TabAlignment.Left:
                case TabAlignment.Right:
                    rect.Y -= half;
                    rect.Height += value;
                    break;

                default:
                    break;
            }

            return rect;
        }

        /// <summary>
        /// 按指定边调整矩形,使在该方向上的大小为指定值
        /// </summary>
        /// <param name="rect">矩形</param>
        /// <param name="align">方向</param>
        /// <param name="value">大小</param>
        /// <returns>调整后矩形</returns>
        public static Rectangle Adjust(Rectangle rect, TabAlignment align, int value)
        {
            switch (align)
            {
                case TabAlignment.Top:
                    rect.Y += (rect.Height - value);
                    rect.Height = value;
                    break;

                case TabAlignment.Bottom:
                    rect.Height = value;
                    break;

                case TabAlignment.Left:
                    rect.X += (rect.Width - value);
                    rect.Width = value;
                    break;

                case TabAlignment.Right:
                    rect.Width = value;
                    break;

                default:
                    break;
            }

            return rect;
        }

        /// <summary>
        /// 调整矩形使其在指定方向上与标准矩形对齐,并加上偏移量,不影响原来的矩形
        /// </summary>
        /// <param name="rect">矩形</param>
        /// <param name="rectStand">标准矩形</param>
        /// <param name="align">方向</param>
        /// <param name="offset">偏移量</param>
        /// <returns>调整后的矩形</returns>
        public static Rectangle Align(Rectangle rect, Rectangle rectStand, TabAlignment align, int offset)
        {
            int value;
            switch (align)
            {
                case TabAlignment.Top:
                    value = rect.Y - rectStand.Y + offset;
                    rect.Y -= value;
                    rect.Height += value;
                    break;

                case TabAlignment.Bottom:
                    value = rectStand.Bottom - rect.Bottom + offset;
                    rect.Height += value;
                    break;

                case TabAlignment.Left:
                    value = rect.X - rectStand.X + offset;
                    rect.X -= value;
                    rect.Width += value;
                    break;

                case TabAlignment.Right:
                    value = rectStand.Right - rect.Right + offset;
                    rect.Width += value;
                    break;

                default:
                    break;
            }

            return rect;
        }

        /// <summary>
        /// 矩形加上Padding后的新矩形
        /// </summary>
        /// <param name="rect">矩形</param>
        /// <param name="padding">外边距</param>
        /// <returns>新矩形</returns>
        public static Rectangle Add(Rectangle rect, Padding padding)
        {
            return new Rectangle(rect.Left - padding.Left, rect.Top - padding.Top, rect.Width + padding.Horizontal, rect.Height + padding.Vertical);
        }

        /// <summary>
        /// 矩形减去Padding后的新矩形
        /// </summary>
        /// <param name="rect">矩形</param>
        /// <param name="padding">内边距</param>
        /// <returns>新矩形</returns>
        public static Rectangle Subtract(Rectangle rect, Padding padding)
        {
            return new Rectangle(rect.Left + padding.Left, rect.Top + padding.Top, rect.Width - padding.Horizontal, rect.Height - padding.Vertical);
        }

        /// <summary>
        /// 将此矩形的位置调整指定的量。返回新矩形，不影响原来值。
        /// </summary>
        /// <param name="rect">矩形</param>
        /// <param name="pos">该位置的偏移量</param>
        /// <returns>偏移后的新矩形</returns>
        public static Rectangle Offset(Rectangle rect, Point pos)
        {
            rect.Offset(pos);
            return rect;
        }

        /// <summary>
        /// 将矩形的位置调整指定的量。返回新矩形，不影响原来值。
        /// </summary>
        /// <param name="rect">矩形</param>
        /// <param name="x">水平偏移量</param>
        /// <param name="y">垂直偏移量</param>
        /// <returns>偏移后的新矩形</returns>
        public static Rectangle Offset(Rectangle rect, int x, int y)
        {
            rect.Offset(x, y);
            return rect;
        }
    }
}
