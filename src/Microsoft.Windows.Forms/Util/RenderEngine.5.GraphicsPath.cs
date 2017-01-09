using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Microsoft.Windows.Forms
{
    public static partial class RenderEngine
    {
        /// <summary>
        /// 创建路径。
        /// </summary>
        /// <param name="rect">矩形。</param>
        /// <returns>创建的路径。</returns>
        public static GraphicsPath CreateGraphicsPath(Rectangle rect)
        {
            return CreateGraphicsPath(rect.X, rect.Y, rect.Width, rect.Height);
        }

        /// <summary>
        /// 创建路径。
        /// </summary>
        /// <param name="pt">左上角。</param>
        /// <param name="sz">大小</param>
        /// <returns>创建的路径。</returns>
        public static GraphicsPath CreateGraphicsPath(Point pt, Size sz)
        {
            return CreateGraphicsPath(pt.X, pt.Y, sz.Width, sz.Height);
        }

        /// <summary>
        /// 创建路径。
        /// </summary>
        /// <param name="x">左上角水平坐标。</param>
        /// <param name="y">左上角垂直坐标</param>
        /// <param name="width">宽度。</param>
        /// <param name="height">高度。</param>
        /// <returns>创建的路劲。</returns>
        public static GraphicsPath CreateGraphicsPath(int x, int y, int width, int height)
        {
            Point[] points = new Point[4];
            points[0] = new Point(x, y);
            points[1] = new Point(x + width, y);
            points[2] = new Point(x + width, y + height);
            points[3] = new Point(x, y + height);
            GraphicsPath shape = new GraphicsPath();
            shape.AddPolygon(points);
            return shape;
        }

        /// <summary>
        /// 创建路径。
        /// </summary>
        /// <param name="rect">用来创建路径的矩形。</param>
        /// <param name="cornerStyle">圆角弯曲样式。</param>
        /// <param name="roundStyle">圆角的样式。</param>
        /// <param name="radius">圆角半径。</param>
        /// <param name="correct">是否把矩形长宽减 1,以便画出边框。</param>
        /// <returns>创建的路径。</returns>
        public static GraphicsPath CreateGraphicsPath(Rectangle rect, CornerStyle cornerStyle, RoundStyle roundStyle, float radius, bool correct)
        {
            //-----------------校准-----------------
            if (correct)
            {
                rect.Width--;
                rect.Height--;
            }

            //-----------------定义返回值-----------------
            GraphicsPath path = new GraphicsPath();
            //-----------------特殊情况处理-----------------
            if (float.IsNaN(radius) || radius <= 0f)
            {
                path.AddRectangle(rect);
                return path;
            }
            //-----------------临时变量定义-----------------
            float diameter = radius * 2;//直径
            float halfWidth = rect.Width / 2f;//宽度一半
            float halfHeight = rect.Height / 2f;//高度一半
            PointF ptMiddleCenter = new PointF(rect.X + halfWidth, rect.Y + halfHeight);//中心点            
            float lrDegrees = 0f;//半径大于半高,圆心角
            float lrOffset = 0f;//半径大于半高,圆弧到边距离
            if ((roundStyle & RoundStyle.All) != 0 && radius > halfHeight)
            {
                double lrRadian = Math.Acos((radius - halfHeight) / radius);//弧度
                lrDegrees = (float)MathEx.ToDegrees(lrRadian);//角度
                lrOffset = (float)(radius * Math.Sin(lrRadian));
            }
            float tbDegrees = 0f;//半径大于半宽,圆心角
            float tbOffset = 0f;//半径大于办宽,圆弧到边距离
            if ((roundStyle & RoundStyle.All) != 0 && radius > halfWidth)
            {
                double tbRadian = Math.Acos((radius - halfWidth) / radius);//弧度
                tbDegrees = (float)MathEx.ToDegrees(tbRadian);//角度
                tbOffset = (float)(radius * Math.Sin(tbRadian));
            }
            //临时变量
            PointF ptBegin;
            PointF ptEnd;


            #region 左上
            if ((roundStyle & RoundStyle.TopLeft) == 0)//直角
            {
                if ((cornerStyle & CornerStyle.LeftIn) != 0)
                {
                    ptBegin = new PointF(rect.X + radius, ptMiddleCenter.Y);
                    ptEnd = new PointF(rect.X, rect.Y);
                    path.AddLine(ptBegin, ptEnd);
                }
                else if ((cornerStyle & CornerStyle.LeftOut) != 0)
                {
                    ptBegin = new PointF(rect.X, ptMiddleCenter.Y);
                    ptEnd = new PointF(rect.X + radius, rect.Y);
                    path.AddLine(ptBegin, ptEnd);
                }
                else if ((cornerStyle & CornerStyle.TopIn) != 0)
                {
                    ptBegin = new PointF(rect.X, rect.Y);
                    ptEnd = new PointF(ptMiddleCenter.X, rect.Y + radius);
                    path.AddLine(ptBegin, ptEnd);
                }
                else if ((cornerStyle & CornerStyle.TopOut) != 0)
                {
                    ptBegin = new PointF(rect.X, rect.Y + radius);
                    ptEnd = new PointF(ptMiddleCenter.X, rect.Y);
                    path.AddLine(ptBegin, ptEnd);
                }
                else
                {
                    ptBegin = ptEnd = new PointF(rect.X, rect.Y);
                    path.AddLine(ptBegin, ptEnd);
                }
            }
            else//圆角
            {
                if ((cornerStyle & CornerStyle.LeftIn) != 0)
                {
                    if (radius > halfHeight)
                        path.AddArc(rect.X - radius, rect.Y, diameter, diameter, 270 + lrDegrees, -lrDegrees);
                    else
                        path.AddArc(rect.X - radius, rect.Y, diameter, diameter, 0, -90);
                }
                else if ((cornerStyle & CornerStyle.LeftOut) != 0)
                {
                    if (radius > halfHeight)
                        path.AddArc(rect.X - (radius - lrOffset), rect.Y, diameter, diameter, 270 - lrDegrees, lrDegrees);
                    else
                        path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
                }
                else if ((cornerStyle & CornerStyle.TopIn) != 0)
                {
                    if (radius > halfWidth)
                        path.AddArc(rect.X, rect.Y - radius, diameter, diameter, 180, -tbDegrees);
                    else
                        path.AddArc(rect.X, rect.Y - radius, diameter, diameter, 180, -90);
                }
                else if ((cornerStyle & CornerStyle.TopOut) != 0)
                {
                    if (radius > halfWidth)
                        path.AddArc(rect.X, rect.Y - (radius - tbOffset), diameter, diameter, 180, tbDegrees);
                    else
                        path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
                }
                else
                {
                    path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
                }
            }
            #endregion


            #region 右上
            if ((roundStyle & RoundStyle.TopRight) == 0)
            {
                if ((cornerStyle & CornerStyle.RightIn) != 0)
                {
                    ptBegin = new PointF(rect.Right, rect.Y);
                    ptEnd = new PointF(rect.Right - radius, ptMiddleCenter.Y);
                    path.AddLine(ptBegin, ptEnd);
                }
                else if ((cornerStyle & CornerStyle.RightOut) != 0)
                {
                    ptBegin = new PointF(rect.Right - radius, rect.Y);
                    ptEnd = new PointF(rect.Right, ptMiddleCenter.Y);
                    path.AddLine(ptBegin, ptEnd);
                }
                else if ((cornerStyle & CornerStyle.TopIn) != 0)
                {
                    ptBegin = new PointF(ptMiddleCenter.X, rect.Y + radius);
                    ptEnd = new PointF(rect.Right, rect.Y);
                    path.AddLine(ptBegin, ptEnd);
                }
                else if ((cornerStyle & CornerStyle.TopOut) != 0)
                {
                    ptBegin = new PointF(ptMiddleCenter.X, rect.Y);
                    ptEnd = new PointF(rect.Right, rect.Y + radius);
                    path.AddLine(ptBegin, ptEnd);
                }
                else//矩形
                {
                    ptBegin = ptEnd = new PointF(rect.Right, rect.Y);
                    path.AddLine(ptBegin, ptEnd);
                }
            }
            else
            {
                if ((cornerStyle & CornerStyle.RightIn) != 0)
                {
                    if (radius > halfHeight)
                        path.AddArc(rect.Right - radius, rect.Y, diameter, diameter, 270, -lrDegrees);
                    else
                        path.AddArc(rect.Right - radius, rect.Y, diameter, diameter, 270, -90);
                }
                else if ((cornerStyle & CornerStyle.RightOut) != 0)
                {
                    if (radius > halfHeight)
                        path.AddArc(rect.Right - radius - lrOffset, rect.Y, diameter, diameter, 270, lrDegrees);
                    else
                        path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
                }
                else if ((cornerStyle & CornerStyle.TopIn) != 0)
                {
                    if (radius > halfWidth)
                        path.AddArc(rect.Right - diameter, rect.Y - radius, diameter, diameter, tbDegrees, -tbDegrees);
                    else
                        path.AddArc(rect.Right - diameter, rect.Y - radius, diameter, diameter, 90, -90);
                }
                else if ((cornerStyle & CornerStyle.TopOut) != 0)
                {
                    if (radius > halfWidth)
                        path.AddArc(rect.Right - diameter, rect.Y - (radius - tbOffset), diameter, diameter, 360 - tbDegrees, tbDegrees);
                    else
                        path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
                }
                else
                {
                    path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
                }
            }
            #endregion


            #region 右下
            if ((roundStyle & RoundStyle.BottomRight) == 0)
            {
                if ((cornerStyle & CornerStyle.RightIn) != 0)
                {
                    ptBegin = new PointF(rect.Right - radius, ptMiddleCenter.Y);
                    ptEnd = new PointF(rect.Right, rect.Bottom);
                    path.AddLine(ptBegin, ptEnd);
                }
                else if ((cornerStyle & CornerStyle.RightOut) != 0)
                {
                    ptBegin = new PointF(rect.Right, ptMiddleCenter.Y);
                    ptEnd = new PointF(rect.Right - radius, rect.Bottom);
                    path.AddLine(ptBegin, ptEnd);
                }
                else if ((cornerStyle & CornerStyle.BottomIn) != 0)
                {
                    ptBegin = new PointF(rect.Right, rect.Bottom);
                    ptEnd = new PointF(ptMiddleCenter.X, rect.Bottom - radius);
                    path.AddLine(ptBegin, ptEnd);
                }
                else if ((cornerStyle & CornerStyle.BottomOut) != 0)
                {
                    ptBegin = new PointF(rect.Right, rect.Bottom - radius);
                    ptEnd = new PointF(ptMiddleCenter.X, rect.Bottom);
                    path.AddLine(ptBegin, ptEnd);
                }
                else//矩形
                {
                    ptBegin = ptEnd = new PointF(rect.Right, rect.Bottom);
                    path.AddLine(ptBegin, ptEnd);
                }
            }
            else
            {
                if ((cornerStyle & CornerStyle.RightIn) != 0)
                {
                    if (radius > halfHeight)
                        path.AddArc(rect.Right - radius, rect.Bottom - diameter, diameter, diameter, 90 + lrDegrees, -lrDegrees);
                    else
                        path.AddArc(rect.Right - radius, rect.Bottom - diameter, diameter, diameter, 180, -90);
                }
                else if ((cornerStyle & CornerStyle.RightOut) != 0)
                {
                    if (radius > halfHeight)
                        path.AddArc(rect.Right - radius - lrOffset, rect.Bottom - diameter, diameter, diameter, 90 - lrDegrees, lrDegrees);
                    else
                        path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
                }
                else if ((cornerStyle & CornerStyle.BottomIn) != 0)
                {
                    if (radius > halfWidth)
                        path.AddArc(rect.Right - diameter, rect.Bottom - radius, diameter, diameter, 0, -tbDegrees);
                    else
                        path.AddArc(rect.Right - diameter, rect.Bottom - radius, diameter, diameter, 0, -90);
                }
                else if ((cornerStyle & CornerStyle.BottomOut) != 0)
                {
                    if (radius > halfWidth)
                        path.AddArc(rect.Right - diameter, rect.Bottom - radius - tbOffset, diameter, diameter, 0, tbDegrees);
                    else
                        path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
                }
                else
                {
                    path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
                }
            }
            #endregion


            #region 左下
            if ((roundStyle & RoundStyle.BottomLeft) == 0)
            {
                if ((cornerStyle & CornerStyle.LeftIn) != 0)
                {
                    ptBegin = new PointF(rect.X, rect.Bottom);
                    ptEnd = new PointF(rect.X + radius, ptMiddleCenter.Y);
                    path.AddLine(ptBegin, ptEnd);
                }
                else if ((cornerStyle & CornerStyle.LeftOut) != 0)
                {
                    ptBegin = new PointF(rect.X + radius, rect.Bottom);
                    ptEnd = new PointF(rect.X, ptMiddleCenter.Y);
                    path.AddLine(ptBegin, ptEnd);
                }
                else if ((cornerStyle & CornerStyle.BottomIn) != 0)
                {
                    ptBegin = new PointF(ptMiddleCenter.X, rect.Bottom - radius);
                    ptEnd = new PointF(rect.X, rect.Bottom);
                    path.AddLine(ptBegin, ptEnd);
                }
                else if ((cornerStyle & CornerStyle.BottomOut) != 0)
                {
                    ptBegin = new PointF(ptMiddleCenter.X, rect.Bottom);
                    ptEnd = new PointF(rect.X, rect.Bottom - radius);
                    path.AddLine(ptBegin, ptEnd);
                }
                else
                {
                    ptBegin = ptEnd = new PointF(rect.X, rect.Bottom);
                    path.AddLine(ptBegin, ptEnd);
                }
            }
            else
            {
                if ((cornerStyle & CornerStyle.LeftIn) != 0)
                {
                    if (radius > halfHeight)
                        path.AddArc(rect.X - radius, rect.Bottom - diameter, diameter, diameter, 90, -lrDegrees);
                    else
                        path.AddArc(rect.X - radius, rect.Bottom - diameter, diameter, diameter, 90, -90);
                }
                else if ((cornerStyle & CornerStyle.LeftOut) != 0)
                {
                    if (radius > halfHeight)
                        path.AddArc(rect.X - (radius - lrOffset), rect.Bottom - diameter, diameter, diameter, 90, lrDegrees);
                    else
                        path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
                }
                else if ((cornerStyle & CornerStyle.BottomIn) != 0)
                {
                    if (radius > halfWidth)
                        path.AddArc(rect.X, rect.Bottom - radius, diameter, diameter, 180 + tbDegrees, -tbDegrees);
                    else
                        path.AddArc(rect.X, rect.Bottom - radius, diameter, diameter, 270, -90);
                }
                else if ((cornerStyle & CornerStyle.BottomOut) != 0)
                {
                    if (radius > halfWidth)
                        path.AddArc(rect.X, rect.Bottom - radius - tbOffset, diameter, diameter, 180 - tbDegrees, tbDegrees);
                    else
                        path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
                }
                else
                {
                    path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
                }
            }
            #endregion


            //闭合返回
            path.CloseFigure();
            return path;
        }

        /// <summary>
        /// 建立带有圆角样式和标题的路径。
        /// </summary>
        /// <param name="rect">用来简历路径的矩形。</param>
        /// <param name="style">圆角样式。</param>
        /// <param name="radius">圆角大小。</param>
        /// <param name="tabSize">标题大小。</param>
        /// <param name="tabRound">标题是否圆角。</param>
        /// <param name="tabRadius">标题圆角大小。</param>
        /// <param name="correct">是否把矩形长宽减 1,以便画出边框。</param>
        /// <returns>简历的路径。</returns>
        public static GraphicsPath CreateGroupBoxTabGraphicsPath(Rectangle rect, RoundStyle style, float radius, Size tabSize, bool tabRound, float tabRadius, bool correct)
        {
            //校正
            if (correct)
            {
                rect.Width--;
                rect.Height--;
            }
            style = (float.IsNaN(radius) || radius <= 0f) ? RoundStyle.None : style;
            tabRound = (float.IsNaN(tabRadius) || tabRadius <= 0f) ? false : tabRound;

            //定义
            GraphicsPath path = new GraphicsPath();
            Rectangle tabRect = new Rectangle(rect.Location, tabSize);
            float diameter = radius * 2;
            float tabDiameter = tabRadius * 2;
            Point pt;

            //左上
            if ((style & RoundStyle.TopLeft) == 0)
            {
                pt = new Point(rect.X, rect.Y);
                path.AddLine(pt, pt);
            }
            else
            {
                path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            }

            //Tab右上
            if (tabRound)
            {
                if (tabRadius > tabRect.Height)//不到90度
                {
                    double radians = Math.Acos((tabRadius - tabRect.Height) / tabRadius);
                    path.AddArc((float)(tabRect.Right - tabRadius * Math.Sin(radians) - tabRadius),
                        tabRect.Y, tabDiameter, tabDiameter, 270, (float)MathEx.ToDegrees(radians));
                }
                else//到90度
                {
                    path.AddArc(tabRect.Right - tabDiameter, tabRect.Y, tabDiameter, tabDiameter, 270, 90);

                    //Tab右下
                    pt = new Point(tabRect.Right, tabRect.Bottom);
                    path.AddLine(pt, pt);
                }
            }
            else
            {
                pt = new Point(tabRect.Right, tabRect.Y);
                path.AddLine(pt, pt);

                //Tab右下
                pt = new Point(tabRect.Right, tabRect.Bottom);
                path.AddLine(pt, pt);
            }

            //右上
            if ((style & RoundStyle.TopRight) == 0)
            {
                pt = new Point(rect.Right, tabRect.Bottom);
                path.AddLine(pt, pt);
            }
            else
            {
                path.AddArc(rect.Right - diameter, tabRect.Bottom, diameter, diameter, 270, 90);
            }

            //右下
            if ((style & RoundStyle.BottomRight) == 0)
            {
                pt = new Point(rect.Right, rect.Bottom);
                path.AddLine(pt, pt);
            }
            else
            {
                path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            }

            //左下
            if ((style & RoundStyle.BottomLeft) == 0)
            {
                pt = new Point(rect.X, rect.Bottom);
                path.AddLine(pt, pt);
            }
            else
            {
                path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            }

            //闭合返回
            path.CloseFigure();
            return path;
        }
    }
}
