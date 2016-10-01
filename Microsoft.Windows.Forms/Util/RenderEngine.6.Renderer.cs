using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.Drawing;
using Microsoft.Windows.Forms.Layout;

namespace Microsoft.Windows.Forms
{
    public static partial class RenderEngine
    {
        /// <summary>
        /// 围绕rect的中心将坐标系顺时针旋转degrees角度,返回新坐标系矩形
        /// </summary>
        /// <param name="g">绘图对象</param>
        /// <param name="rect">要旋转的矩形</param>
        /// <param name="degrees">角度</param>
        /// <param name="fit">内容旋转,绘图区域不旋转</param>
        /// <returns>新坐标系矩形</returns>
        public static Rectangle RotateRect(Graphics g, Rectangle rect, float degrees, bool fit)
        {
            g.RotateTransform(degrees, MatrixOrder.Append);//围绕中心原点旋转
            g.TranslateTransform(rect.X + rect.Width / 2, rect.Y + rect.Height / 2, MatrixOrder.Append);//平移原点
            if (fit)
            {
                decimal decLessStraigntAngle = Math.Abs((decimal)degrees) % 180m;//取绝对值后除以180的余数,小于平角的角度
                return ((decLessStraigntAngle >= 0 && decLessStraigntAngle <= 45) || (decLessStraigntAngle >= 135 && decLessStraigntAngle <= 180))
                    ? new Rectangle(-rect.Width / 2, -rect.Height / 2, rect.Width, rect.Height)
                    : new Rectangle(-rect.Height / 2, -rect.Width / 2, rect.Height, rect.Width);//新坐标系矩形
            }
            else
            {
                return new Rectangle(-rect.Width / 2, -rect.Height / 2, rect.Width, rect.Height);
            }
        }


        /// <summary>
        /// 开始绘制字符串(画布无限制),并返回路径区域和字符串大小.注意不要修改返回的矩形和字符串大小,在EndDrawString中需要传回.必须与EndDrawString成对出现.
        /// </summary>
        /// <param name="g">绘图对象</param>
        /// <param name="s">字符串</param>
        /// <param name="font">字体</param>
        /// <param name="strSize">字符串大小</param>
        /// <returns>字符串路径区域</returns>
        public static Rectangle BeginDrawString(Graphics g, string s, Font font, out Size strSize)
        {
            using (StringFormat sf = DefaultTheme.StringFormat)
            {
                strSize = Size.Ceiling(g.MeasureString(s, font, PointF.Empty, sf));
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddString(s, font.FontFamily, (int)font.Style, g.DpiY * font.SizeInPoints / 72f, Point.Empty, sf);
                    return Rectangle.Round(path.GetBounds());
                }
            }
        }

        /// <summary>
        /// 开始绘制字符串(画布有限制),并返回路径区域和字符串大小.注意不要修改返回的矩形和字符串大小,在EndDrawString中需要传回.必须与EndDrawString成对出现.
        /// </summary>
        /// <param name="g">绘图对象</param>
        /// <param name="s">字符串</param>
        /// <param name="font">字体</param>
        /// <param name="layoutRectangle">限制矩形</param>
        /// <param name="strSize">字符串大小</param>
        /// <returns>字符串路径区域</returns>
        public static Rectangle BeginDrawString(Graphics g, string s, Font font, Rectangle layoutRectangle, out Size strSize)
        {
            using (StringFormat sf = DefaultTheme.StringFormat)
            {
                strSize = Size.Ceiling(g.MeasureString(s, font, layoutRectangle.Size, sf));
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddString(s, font.FontFamily, (int)font.Style, g.DpiY * font.SizeInPoints / 72f, layoutRectangle, sf);
                    return Rectangle.Round(path.GetBounds());
                }
            }
        }

        /// <summary>
        /// 正式绘制字符串.与BeginDrawString成对出现
        /// </summary>
        /// <param name="g">绘图对象</param>
        /// <param name="s">字符串</param>
        /// <param name="font">字体</param>
        /// <param name="brush">画刷</param>
        /// <param name="layoutRectangle">画布区域</param>
        /// <param name="align">对齐方式</param>
        /// <param name="pathBounds">字符串路径区域,BeginDrawString(...)返回值</param>
        /// <param name="strSize">字符串大小,BeginDrawString(...)返回值</param>
        public static void EndDrawString(Graphics g, string s, Font font, Brush brush, Rectangle layoutRectangle, ContentAlignment align, Rectangle pathBounds, Size strSize)
        {
            layoutRectangle = LayoutUtils.Align(pathBounds.Size, layoutRectangle, align);
#if DEBUG
            g.DrawRectangle(SystemPens.ControlDarkDark, layoutRectangle);
#endif
            layoutRectangle.Offset(-pathBounds.X, -pathBounds.Y);
            layoutRectangle.Size = strSize;
            using (StringFormat sf = DefaultTheme.StringFormat)
            {
                g.DrawString(s, font, brush, layoutRectangle, sf);
            }
        }

        /// <summary>
        /// 精确绘制字符串
        /// </summary>
        /// <param name="g">绘图对象</param>
        /// <param name="s">字符串</param>
        /// <param name="font">字体</param>
        /// <param name="brush">画刷</param>
        /// <param name="layoutRectangle">绘制区域</param>
        /// <param name="align">对齐方式</param>
        public static void DrawString(Graphics g, string s, Font font, Brush brush, Rectangle layoutRectangle, ContentAlignment align)
        {
            Size strSize;
            Rectangle pathBounds = BeginDrawString(g, s, font, layoutRectangle, out strSize);
            EndDrawString(g, s, font, brush, layoutRectangle, align, pathBounds, strSize);
        }

        /// <summary>
        /// 绘制背景图
        /// </summary>
        /// <param name="g">绘图上下文</param>
        /// <param name="image">背景图</param>
        /// <param name="rect">绘制区域</param>
        /// <param name="layout">背景图布局方式</param>
        public static void DrawBackgroundImage(Graphics g, Image image, Rectangle rect, ImageLayout layout)
        {
            if (image == null)
                return;

            switch (layout)
            {
                case ImageLayout.None:
                    g.DrawImageUnscaled(image, rect.Location);
                    break;

                case ImageLayout.Tile:
                    using (Brush brush = new TextureBrush(image, WrapMode.Tile))
                    {
                        g.FillRectangle(brush, rect);
                    }
                    break;

                case ImageLayout.Center:
                    int x = rect.Left + (rect.Width - image.Width) / 2;
                    int y = rect.Top + (rect.Height - image.Height) / 2;
                    g.DrawImageUnscaled(image, x, y);
                    break;

                case ImageLayout.Stretch:
                    g.DrawImage(image, rect);
                    break;

                case ImageLayout.Zoom:
                    float xscale = (float)rect.Width / (float)image.Width;
                    float yscale = (float)rect.Height / (float)image.Height;
                    float scale = Math.Min(xscale, yscale);
                    int width = (int)(((float)image.Width) * scale);
                    int height = (int)(((float)image.Height) * scale);
                    x = rect.Left + (rect.Width - width) / 2;
                    y = rect.Top + (rect.Height - height) / 2;
                    g.DrawImage(image, x, y, width, height);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 绘制九宫格背景图
        /// </summary>
        /// <param name="g">绘图上下文</param>
        /// <param name="image">背景图</param>
        /// <param name="rect">目标区域</param>
        /// <param name="left">九宫格划分,左</param>
        /// <param name="top">九宫格划分,上</param>
        /// <param name="right">九宫格划分,右</param>
        /// <param name="bottom">九宫格划分,下</param>
        /// <param name="layout">九宫格背景图布局方式</param>
        public static void DrawBackgroundImage9(Graphics g, Image image, Rectangle rect, int left, int top, int right, int bottom, ImageLayout9 layout)
        {
            if (image == null || !RectangleEx.IsVisible(rect))
                return;

            //基本
            int nSrcWidth = image.Width;
            int nSrcHeight = image.Height;
            int nDestWidth = rect.Width;
            int nDestHeight = rect.Height;
            //左上
            Rectangle rcSrcTopLeft = new Rectangle(0, 0, left, top);
            Rectangle rcDestTopLeft = new Rectangle(rect.X, rect.Y, left, top);
            //上
            Rectangle rcSrcTop = new Rectangle(rcSrcTopLeft.Right, rcSrcTopLeft.Y, nSrcWidth - left - right, top);
            Rectangle rcDestTop = new Rectangle(rcDestTopLeft.Right, rcDestTopLeft.Y, nDestWidth - left - right, top);
            //右上
            Rectangle rcSrcTopRight = new Rectangle(rcSrcTop.Right, rcSrcTop.Y, right, top);
            Rectangle rcDestTopRight = new Rectangle(rcDestTop.Right, rcDestTop.Y, right, top);
            //右
            Rectangle rcSrcRight = new Rectangle(rcSrcTopRight.X, rcSrcTopRight.Bottom, right, nSrcHeight - top - bottom);
            Rectangle rcDestRight = new Rectangle(rcDestTopRight.X, rcDestTopRight.Bottom, right, nDestHeight - top - bottom);
            //右下
            Rectangle rcSrcBottomRight = new Rectangle(rcSrcRight.X, rcSrcRight.Bottom, right, bottom);
            Rectangle rcDestBottomRight = new Rectangle(rcDestRight.X, rcDestRight.Bottom, right, bottom);
            //下
            Rectangle rcSrcBottom = new Rectangle(rcSrcTop.X, rcSrcBottomRight.Y, rcSrcTop.Width, bottom);
            Rectangle rcDestBottom = new Rectangle(rcDestTop.X, rcDestBottomRight.Y, rcDestTop.Width, bottom);
            //左下
            Rectangle rcSrcBottomLeft = new Rectangle(rcSrcTopLeft.X, rcSrcBottom.Y, left, bottom);
            Rectangle rcDestBottomLeft = new Rectangle(rcDestTopLeft.X, rcDestBottom.Y, left, bottom);
            //左
            Rectangle rcSrcLeft = new Rectangle(rcSrcBottomLeft.X, rcSrcRight.Y, left, rcSrcRight.Height);
            Rectangle rcDestLeft = new Rectangle(rcDestBottomLeft.X, rcDestRight.Y, left, rcDestRight.Height);
            //中
            Rectangle rcSrcMiddle = new Rectangle(rcSrcTop.X, rcSrcLeft.Y, rcSrcTop.Width, rcSrcLeft.Height);
            Rectangle rcDestMiddle = new Rectangle(rcDestTop.X, rcDestLeft.Y, rcDestTop.Width, rcDestLeft.Height);

            //左上
            if (RectangleEx.IsVisible(rcSrcTopLeft))
            {
                g.DrawImage(image, rcDestTopLeft, rcSrcTopLeft, GraphicsUnit.Pixel);
            }
            //上
            if (RectangleEx.IsVisible(rcSrcTop) && RectangleEx.IsVisible(rcDestTop))
            {
                if ((layout & ImageLayout9.TopTile) == 0)//拉伸
                {
                    g.DrawImage(image, rcDestTop, rcSrcTop, GraphicsUnit.Pixel);
                }
                else//平铺
                {
                    using (TextureBrush brush = new TextureBrush(image, WrapMode.Tile, rcSrcTop))
                    {
                        brush.TranslateTransform(rcDestTop.X, rcDestTop.Y);
                        g.FillRectangle(brush, rcDestTop);
                    }
                }
            }
            //右上
            if (RectangleEx.IsVisible(rcSrcTopRight))
            {
                g.DrawImage(image, rcDestTopRight, rcSrcTopRight, GraphicsUnit.Pixel);
            }
            //右
            if (RectangleEx.IsVisible(rcSrcRight) && RectangleEx.IsVisible(rcDestRight))
            {
                if ((layout & ImageLayout9.RightTile) == 0)//拉伸
                {
                    g.DrawImage(image, rcDestRight, rcSrcRight, GraphicsUnit.Pixel);
                }
                else//平铺
                {
                    using (TextureBrush brush = new TextureBrush(image, WrapMode.Tile, rcSrcRight))
                    {
                        brush.TranslateTransform(rcDestRight.X, rcDestRight.Y);
                        g.FillRectangle(brush, rcDestRight);
                    }
                }
            }
            //右下
            if (RectangleEx.IsVisible(rcSrcBottomRight))
            {
                g.DrawImage(image, rcDestBottomRight, rcSrcBottomRight, GraphicsUnit.Pixel);
            }
            //下
            if (RectangleEx.IsVisible(rcSrcBottom) && RectangleEx.IsVisible(rcDestBottom))
            {
                if ((layout & ImageLayout9.BottomTile) == 0)//拉伸
                {
                    g.DrawImage(image, rcDestBottom, rcSrcBottom, GraphicsUnit.Pixel);
                }
                else//平铺
                {
                    using (TextureBrush brush = new TextureBrush(image, WrapMode.Tile, rcSrcBottom))
                    {
                        brush.TranslateTransform(rcDestBottom.X, rcDestBottom.Y);
                        g.FillRectangle(brush, rcDestBottom);
                    }
                }
            }
            //左下
            if (RectangleEx.IsVisible(rcSrcBottomLeft))
            {
                g.DrawImage(image, rcDestBottomLeft, rcSrcBottomLeft, GraphicsUnit.Pixel);
            }
            //左
            if (RectangleEx.IsVisible(rcSrcLeft) && RectangleEx.IsVisible(rcDestLeft))
            {
                if ((layout & ImageLayout9.LeftTile) == 0)//拉伸
                {
                    g.DrawImage(image, rcDestLeft, rcSrcLeft, GraphicsUnit.Pixel);
                }
                else//平铺
                {
                    using (TextureBrush brush = new TextureBrush(image, WrapMode.Tile, rcSrcLeft))
                    {
                        brush.TranslateTransform(rcDestLeft.X, rcDestLeft.Y);
                        g.FillRectangle(brush, rcDestLeft);
                    }
                }
            }
            //中间
            if (RectangleEx.IsVisible(rcSrcMiddle) && RectangleEx.IsVisible(rcDestMiddle))
            {
                if ((layout & ImageLayout9.MiddleTile) == 0)//拉伸
                {
                    g.DrawImage(image, rcDestMiddle, rcSrcMiddle, GraphicsUnit.Pixel);
                }
                else//平铺
                {
                    using (TextureBrush brush = new TextureBrush(image, WrapMode.Tile, rcSrcMiddle))
                    {
                        brush.TranslateTransform(rcDestMiddle.X, rcDestMiddle.Y);
                        g.FillRectangle(brush, rcDestMiddle);
                    }
                }
            }
        }

        /// <summary>
        /// 绘制边框
        /// </summary>
        /// <param name="g">绘图对象</param>
        /// <param name="pen">画笔</param>
        /// <param name="rect">矩形区域</param>
        /// <param name="borderStyle">边框样式</param>
        /// <param name="cornerStyle">圆角弯曲样式</param>
        /// <param name="roundStyle">圆角样式</param>
        /// <param name="radius">圆角半径</param>
        /// <param name="correct">是否减小一个像素</param>
        public static void DrawBorder(Graphics g, Pen pen, Rectangle rect, BorderVisibleStyle borderStyle, CornerStyle cornerStyle, RoundStyle roundStyle, float radius, bool correct)
        {
            //-----------------不绘制-----------------
            if (borderStyle == BorderVisibleStyle.None)
                return;
            //-----------------校准-----------------
            if (correct)
            {
                rect.Width--;
                rect.Height--;
            }

            //-----------------特殊情况处理-----------------
            if (float.IsNaN(radius) || radius <= 0f)
            {
                //-----------------全边-----------------
                if (borderStyle == BorderVisibleStyle.All)
                {
                    g.DrawRectangle(pen, rect);
                    return;
                }
                cornerStyle = CornerStyle.None;
                roundStyle = RoundStyle.None;
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
            PointF ptBeginTopLeft;
            PointF ptEndTopLeft;
            PointF ptBeginTopRight;
            PointF ptEndTopRight;
            PointF ptBeginBottomRight;
            PointF ptEndBottomRight;
            PointF ptBeginBottomLeft;
            PointF ptEndBottomLeft;


            #region 计算左上端点
            if ((roundStyle & RoundStyle.TopLeft) == 0)//直角
            {
                if ((cornerStyle & CornerStyle.LeftIn) != 0)
                {
                    ptBeginTopLeft = new PointF(rect.X + radius, ptMiddleCenter.Y);
                    ptEndTopLeft = new PointF(rect.X, rect.Y);
                }
                else if ((cornerStyle & CornerStyle.LeftOut) != 0)
                {
                    ptBeginTopLeft = new PointF(rect.X, ptMiddleCenter.Y);
                    ptEndTopLeft = new PointF(rect.X + radius, rect.Y);
                }
                else if ((cornerStyle & CornerStyle.TopIn) != 0)
                {
                    ptBeginTopLeft = new PointF(rect.X, rect.Y);
                    ptEndTopLeft = new PointF(ptMiddleCenter.X, rect.Y + radius);
                }
                else if ((cornerStyle & CornerStyle.TopOut) != 0)
                {
                    ptBeginTopLeft = new PointF(rect.X, rect.Y + radius);
                    ptEndTopLeft = new PointF(ptMiddleCenter.X, rect.Y);
                }
                else
                {
                    ptBeginTopLeft = ptEndTopLeft = new PointF(rect.X, rect.Y);
                }
            }
            else//圆角
            {
                if ((cornerStyle & CornerStyle.LeftIn) != 0)
                {
                    if (radius > halfHeight)
                    {
                        ptBeginTopLeft = new PointF(rect.X + lrOffset, ptMiddleCenter.Y);
                        ptEndTopLeft = new PointF(rect.X, rect.Y);
                    }
                    else
                    {
                        ptBeginTopLeft = new PointF(rect.X + radius, rect.Y + radius);
                        ptEndTopLeft = new PointF(rect.X, rect.Y);
                    }
                }
                else if ((cornerStyle & CornerStyle.LeftOut) != 0)
                {
                    if (radius > halfHeight)
                    {
                        ptBeginTopLeft = new PointF(rect.X, ptMiddleCenter.Y);
                        ptEndTopLeft = new PointF(rect.X + lrOffset, rect.Y);
                    }
                    else
                    {
                        ptBeginTopLeft = new PointF(rect.X, rect.Y + radius);//same
                        ptEndTopLeft = new PointF(rect.X + radius, rect.Y);//same
                    }
                }
                else if ((cornerStyle & CornerStyle.TopIn) != 0)
                {
                    if (radius > halfWidth)
                    {
                        ptBeginTopLeft = new PointF(rect.X, rect.Y);
                        ptEndTopLeft = new PointF(ptMiddleCenter.X, rect.Y + tbOffset);
                    }
                    else
                    {
                        ptBeginTopLeft = new PointF(rect.X, rect.Y);
                        ptEndTopLeft = new PointF(rect.X + radius, rect.Y + radius);
                    }
                }
                else if ((cornerStyle & CornerStyle.TopOut) != 0)
                {
                    if (radius > halfWidth)
                    {
                        ptBeginTopLeft = new PointF(rect.X, rect.Y + tbOffset);
                        ptEndTopLeft = new PointF(ptMiddleCenter.X, rect.Y);
                    }
                    else
                    {
                        ptBeginTopLeft = new PointF(rect.X, rect.Y + radius);//same
                        ptEndTopLeft = new PointF(rect.X + radius, rect.Y);//same
                    }
                }
                else
                {
                    ptBeginTopLeft = new PointF(rect.X, rect.Y + radius);//same
                    ptEndTopLeft = new PointF(rect.X + radius, rect.Y);//same
                }
            }
            #endregion

            #region 计算右上端点
            if ((roundStyle & RoundStyle.TopRight) == 0)
            {
                if ((cornerStyle & CornerStyle.RightIn) != 0)
                {
                    ptBeginTopRight = new PointF(rect.Right, rect.Y);
                    ptEndTopRight = new PointF(rect.Right - radius, ptMiddleCenter.Y);
                }
                else if ((cornerStyle & CornerStyle.RightOut) != 0)
                {
                    ptBeginTopRight = new PointF(rect.Right - radius, rect.Y);
                    ptEndTopRight = new PointF(rect.Right, ptMiddleCenter.Y);
                }
                else if ((cornerStyle & CornerStyle.TopIn) != 0)
                {
                    ptBeginTopRight = new PointF(ptMiddleCenter.X, rect.Y + radius);
                    ptEndTopRight = new PointF(rect.Right, rect.Y);
                }
                else if ((cornerStyle & CornerStyle.TopOut) != 0)
                {
                    ptBeginTopRight = new PointF(ptMiddleCenter.X, rect.Y);
                    ptEndTopRight = new PointF(rect.Right, rect.Y + radius);
                }
                else
                {
                    ptBeginTopRight = ptEndTopRight = new PointF(rect.Right, rect.Y);
                }
            }
            else
            {
                if ((cornerStyle & CornerStyle.RightIn) != 0)
                {
                    if (radius > halfHeight)
                    {
                        ptBeginTopRight = new PointF(rect.Right, rect.Y);
                        ptEndTopRight = new PointF(rect.Right - lrOffset, ptMiddleCenter.Y);
                    }
                    else
                    {
                        ptBeginTopRight = new PointF(rect.Right, rect.Y);
                        ptEndTopRight = new PointF(rect.Right - radius, rect.Y + radius);
                    }
                }
                else if ((cornerStyle & CornerStyle.RightOut) != 0)
                {
                    if (radius > halfHeight)
                    {
                        ptBeginTopRight = new PointF(rect.Right - lrOffset, rect.Y);
                        ptEndTopRight = new PointF(rect.Right, ptMiddleCenter.Y);
                    }
                    else
                    {
                        ptBeginTopRight = new PointF(rect.Right - radius, rect.Y);//same
                        ptEndTopRight = new PointF(rect.Right, rect.Y + radius);//same
                    }
                }
                else if ((cornerStyle & CornerStyle.TopIn) != 0)
                {
                    if (radius > halfWidth)
                    {
                        ptBeginTopRight = new PointF(ptMiddleCenter.X, rect.Y + tbOffset);
                        ptEndTopRight = new PointF(rect.Right, rect.Y);
                    }
                    else
                    {
                        ptBeginTopRight = new PointF(rect.Right - radius, rect.Y + radius);
                        ptEndTopRight = new PointF(rect.Right, rect.Y);
                    }
                }
                else if ((cornerStyle & CornerStyle.TopOut) != 0)
                {
                    if (radius > halfWidth)
                    {
                        ptBeginTopRight = new PointF(ptMiddleCenter.X, rect.Y);
                        ptEndTopRight = new PointF(rect.Right, rect.Y + tbOffset);
                    }
                    else
                    {
                        ptBeginTopRight = new PointF(rect.Right - radius, rect.Y);//same
                        ptEndTopRight = new PointF(rect.Right, rect.Y + radius);//same
                    }
                }
                else
                {
                    ptBeginTopRight = new PointF(rect.Right - radius, rect.Y);//same
                    ptEndTopRight = new PointF(rect.Right, rect.Y + radius);//same
                }
            }
            #endregion

            #region 计算右下端点
            if ((roundStyle & RoundStyle.BottomRight) == 0)
            {
                if ((cornerStyle & CornerStyle.RightIn) != 0)
                {
                    ptBeginBottomRight = new PointF(rect.Right - radius, ptMiddleCenter.Y);
                    ptEndBottomRight = new PointF(rect.Right, rect.Bottom);
                }
                else if ((cornerStyle & CornerStyle.RightOut) != 0)
                {
                    ptBeginBottomRight = new PointF(rect.Right, ptMiddleCenter.Y);
                    ptEndBottomRight = new PointF(rect.Right - radius, rect.Bottom);
                }
                else if ((cornerStyle & CornerStyle.BottomIn) != 0)
                {
                    ptBeginBottomRight = new PointF(rect.Right, rect.Bottom);
                    ptEndBottomRight = new PointF(ptMiddleCenter.X, rect.Bottom - radius);
                }
                else if ((cornerStyle & CornerStyle.BottomOut) != 0)
                {
                    ptBeginBottomRight = new PointF(rect.Right, rect.Bottom - radius);
                    ptEndBottomRight = new PointF(ptMiddleCenter.X, rect.Bottom);
                }
                else
                {
                    ptBeginBottomRight = ptEndBottomRight = new PointF(rect.Right, rect.Bottom);
                }
            }
            else
            {
                if ((cornerStyle & CornerStyle.RightIn) != 0)
                {
                    if (radius > halfHeight)
                    {
                        ptBeginBottomRight = new PointF(rect.Right - lrOffset, ptMiddleCenter.Y);
                        ptEndBottomRight = new PointF(rect.Right, rect.Bottom);
                    }
                    else
                    {
                        ptBeginBottomRight = new PointF(rect.Right - radius, rect.Bottom - radius);
                        ptEndBottomRight = new PointF(rect.Right, rect.Bottom);
                    }
                }
                else if ((cornerStyle & CornerStyle.RightOut) != 0)
                {
                    if (radius > halfHeight)
                    {
                        ptBeginBottomRight = new PointF(rect.Right, ptMiddleCenter.Y);
                        ptEndBottomRight = new PointF(rect.Right - lrOffset, rect.Bottom);
                    }
                    else
                    {
                        ptBeginBottomRight = new PointF(rect.Right, rect.Bottom - radius);//same
                        ptEndBottomRight = new PointF(rect.Right - radius, rect.Bottom);//same
                    }
                }
                else if ((cornerStyle & CornerStyle.BottomIn) != 0)
                {
                    if (radius > halfWidth)
                    {
                        ptBeginBottomRight = new PointF(rect.Right, rect.Bottom);
                        ptEndBottomRight = new PointF(ptMiddleCenter.X, rect.Bottom - tbOffset);
                    }
                    else
                    {
                        ptBeginBottomRight = new PointF(rect.Right, rect.Bottom);
                        ptEndBottomRight = new PointF(rect.Right - radius, rect.Bottom - radius);
                    }
                }
                else if ((cornerStyle & CornerStyle.BottomOut) != 0)
                {
                    if (radius > halfWidth)
                    {
                        ptBeginBottomRight = new PointF(rect.Right, rect.Bottom - tbOffset);
                        ptEndBottomRight = new PointF(ptMiddleCenter.X, rect.Bottom);
                    }
                    else
                    {
                        ptBeginBottomRight = new PointF(rect.Right, rect.Bottom - radius);//same
                        ptEndBottomRight = new PointF(rect.Right - radius, rect.Bottom);//same
                    }
                }
                else
                {
                    ptBeginBottomRight = new PointF(rect.Right, rect.Bottom - radius);//same
                    ptEndBottomRight = new PointF(rect.Right - radius, rect.Bottom);//same
                }
            }
            #endregion

            #region 计算左下端点
            if ((roundStyle & RoundStyle.BottomLeft) == 0)
            {
                if ((cornerStyle & CornerStyle.LeftIn) != 0)
                {
                    ptBeginBottomLeft = new PointF(rect.X, rect.Bottom);
                    ptEndBottomLeft = new PointF(rect.X + radius, ptMiddleCenter.Y);
                }
                else if ((cornerStyle & CornerStyle.LeftOut) != 0)
                {
                    ptBeginBottomLeft = new PointF(rect.X + radius, rect.Bottom);
                    ptEndBottomLeft = new PointF(rect.X, ptMiddleCenter.Y);
                }
                else if ((cornerStyle & CornerStyle.BottomIn) != 0)
                {
                    ptBeginBottomLeft = new PointF(ptMiddleCenter.X, rect.Bottom - radius);
                    ptEndBottomLeft = new PointF(rect.X, rect.Bottom);
                }
                else if ((cornerStyle & CornerStyle.BottomOut) != 0)
                {
                    ptBeginBottomLeft = new PointF(ptMiddleCenter.X, rect.Bottom);
                    ptEndBottomLeft = new PointF(rect.X, rect.Bottom - radius);
                }
                else
                {
                    ptBeginBottomLeft = ptEndBottomLeft = new PointF(rect.X, rect.Bottom);
                }
            }
            else
            {
                if ((cornerStyle & CornerStyle.LeftIn) != 0)
                {
                    if (radius > halfHeight)
                    {
                        ptBeginBottomLeft = new PointF(rect.Left, rect.Bottom);
                        ptEndBottomLeft = new PointF(rect.Left + lrOffset, ptMiddleCenter.Y);
                    }
                    else
                    {
                        ptBeginBottomLeft = new PointF(rect.Left, rect.Bottom);
                        ptEndBottomLeft = new PointF(rect.Left + radius, rect.Bottom - radius);
                    }
                }
                else if ((cornerStyle & CornerStyle.LeftOut) != 0)
                {
                    if (radius > halfHeight)
                    {
                        ptBeginBottomLeft = new PointF(rect.Left + lrOffset, rect.Bottom);
                        ptEndBottomLeft = new PointF(rect.Left, ptMiddleCenter.Y);
                    }
                    else
                    {
                        ptBeginBottomLeft = new PointF(rect.Left + radius, rect.Bottom);//same
                        ptEndBottomLeft = new PointF(rect.Left, rect.Bottom - radius);//same
                    }
                }
                else if ((cornerStyle & CornerStyle.BottomIn) != 0)
                {
                    if (radius > halfWidth)
                    {
                        ptBeginBottomLeft = new PointF(ptMiddleCenter.X, rect.Bottom - tbOffset);
                        ptEndBottomLeft = new PointF(rect.Left, rect.Bottom);
                    }
                    else
                    {
                        ptBeginBottomLeft = new PointF(rect.Left + radius, rect.Bottom - radius);
                        ptEndBottomLeft = new PointF(rect.Left, rect.Bottom);
                    }
                }
                else if ((cornerStyle & CornerStyle.BottomOut) != 0)
                {
                    if (radius > halfWidth)
                    {
                        ptBeginBottomLeft = new PointF(ptMiddleCenter.X, rect.Bottom);
                        ptEndBottomLeft = new PointF(rect.Left, rect.Bottom - tbOffset);
                    }
                    else
                    {
                        ptBeginBottomLeft = new PointF(rect.Left + radius, rect.Bottom);//same
                        ptEndBottomLeft = new PointF(rect.Left, rect.Bottom - radius);//same
                    }
                }
                else
                {
                    ptBeginBottomLeft = new PointF(rect.Left + radius, rect.Bottom);//same
                    ptEndBottomLeft = new PointF(rect.Left, rect.Bottom - radius);//same
                }
            }
            #endregion


            #region 绘制左边
            if ((borderStyle & BorderVisibleStyle.Left) != 0)
            {
                g.DrawLine(pen, ptEndBottomLeft, ptBeginTopLeft);
            }
            #endregion

            #region 绘制左上角
            if ((borderStyle & BorderVisibleStyle.Left) != 0 || (borderStyle & BorderVisibleStyle.Top) != 0)
            {
                if ((roundStyle & RoundStyle.TopLeft) == 0)
                {
                    g.DrawLine(pen, ptBeginTopLeft, ptEndTopLeft);
                }
                else
                {
                    if ((cornerStyle & CornerStyle.LeftIn) != 0)
                    {
                        if (radius > halfHeight)
                            g.DrawArc(pen, rect.X - radius, rect.Y, diameter, diameter, 270 + lrDegrees, -lrDegrees);
                        else
                            g.DrawArc(pen, rect.X - radius, rect.Y, diameter, diameter, 0, -90);
                    }
                    else if ((cornerStyle & CornerStyle.LeftOut) != 0)
                    {
                        if (radius > halfHeight)
                            g.DrawArc(pen, rect.X - (radius - lrOffset), rect.Y, diameter, diameter, 270 - lrDegrees, lrDegrees);
                        else
                            g.DrawArc(pen, rect.X, rect.Y, diameter, diameter, 180, 90);//same
                    }
                    else if ((cornerStyle & CornerStyle.TopIn) != 0)
                    {
                        if (radius > halfWidth)
                            g.DrawArc(pen, rect.X, rect.Y - radius, diameter, diameter, 180, -tbDegrees);
                        else
                            g.DrawArc(pen, rect.X, rect.Y - radius, diameter, diameter, 180, -90);
                    }
                    else if ((cornerStyle & CornerStyle.TopOut) != 0)
                    {
                        if (radius > halfWidth)
                            g.DrawArc(pen, rect.X, rect.Y - (radius - tbOffset), diameter, diameter, 180, tbDegrees);
                        else
                            g.DrawArc(pen, rect.X, rect.Y, diameter, diameter, 180, 90);//same
                    }
                    else
                    {
                        g.DrawArc(pen, rect.X, rect.Y, diameter, diameter, 180, 90);//same
                    }
                }
            }
            #endregion

            #region 绘制上边
            if ((borderStyle & BorderVisibleStyle.Top) != 0)
            {
                g.DrawLine(pen, ptEndTopLeft, ptBeginTopRight);
            }
            #endregion

            #region 绘制右上角
            if ((borderStyle & BorderVisibleStyle.Top) != 0 || (borderStyle & BorderVisibleStyle.Right) != 0)
            {
                if ((roundStyle & RoundStyle.TopRight) == 0)
                {
                    g.DrawLine(pen, ptBeginTopRight, ptEndTopRight);
                }
                else
                {
                    if ((cornerStyle & CornerStyle.RightIn) != 0)
                    {
                        if (radius > halfHeight)
                            g.DrawArc(pen, rect.Right - radius, rect.Y, diameter, diameter, 270, -lrDegrees);
                        else
                            g.DrawArc(pen, rect.Right - radius, rect.Y, diameter, diameter, 270, -90);
                    }
                    else if ((cornerStyle & CornerStyle.RightOut) != 0)
                    {
                        if (radius > halfHeight)
                            g.DrawArc(pen, rect.Right - radius - lrOffset, rect.Y, diameter, diameter, 270, lrDegrees);
                        else
                            g.DrawArc(pen, rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);//same
                    }
                    else if ((cornerStyle & CornerStyle.TopIn) != 0)
                    {
                        if (radius > halfWidth)
                            g.DrawArc(pen, rect.Right - diameter, rect.Y - radius, diameter, diameter, tbDegrees, -tbDegrees);
                        else
                            g.DrawArc(pen, rect.Right - diameter, rect.Y - radius, diameter, diameter, 90, -90);
                    }
                    else if ((cornerStyle & CornerStyle.TopOut) != 0)
                    {
                        if (radius > halfWidth)
                            g.DrawArc(pen, rect.Right - diameter, rect.Y - (radius - tbOffset), diameter, diameter, 360 - tbDegrees, tbDegrees);
                        else
                            g.DrawArc(pen, rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);//same
                    }
                    else
                    {
                        g.DrawArc(pen, rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);//same
                    }
                }
            }
            #endregion

            #region 绘制右边
            if ((borderStyle & BorderVisibleStyle.Right) != 0)
            {
                g.DrawLine(pen, ptEndTopRight, ptBeginBottomRight);
            }
            #endregion

            #region 绘制右下角
            if ((borderStyle & BorderVisibleStyle.Right) != 0 || (borderStyle & BorderVisibleStyle.Bottom) != 0)
            {
                if ((roundStyle & RoundStyle.BottomRight) == 0)
                {
                    g.DrawLine(pen, ptBeginBottomRight, ptEndBottomRight);
                }
                else
                {
                    if ((cornerStyle & CornerStyle.RightIn) != 0)
                    {
                        if (radius > halfHeight)
                            g.DrawArc(pen, rect.Right - radius, rect.Bottom - diameter, diameter, diameter, 90 + lrDegrees, -lrDegrees);
                        else
                            g.DrawArc(pen, rect.Right - radius, rect.Bottom - diameter, diameter, diameter, 180, -90);
                    }
                    else if ((cornerStyle & CornerStyle.RightOut) != 0)
                    {
                        if (radius > halfHeight)
                            g.DrawArc(pen, rect.Right - radius - lrOffset, rect.Bottom - diameter, diameter, diameter, 90 - lrDegrees, lrDegrees);
                        else
                            g.DrawArc(pen, rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);//same
                    }
                    else if ((cornerStyle & CornerStyle.BottomIn) != 0)
                    {
                        if (radius > halfWidth)
                            g.DrawArc(pen, rect.Right - diameter, rect.Bottom - radius, diameter, diameter, 0, -tbDegrees);
                        else
                            g.DrawArc(pen, rect.Right - diameter, rect.Bottom - radius, diameter, diameter, 0, -90);
                    }
                    else if ((cornerStyle & CornerStyle.BottomOut) != 0)
                    {
                        if (radius > halfWidth)
                            g.DrawArc(pen, rect.Right - diameter, rect.Bottom - radius - tbOffset, diameter, diameter, 0, tbDegrees);
                        else
                            g.DrawArc(pen, rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);//same
                    }
                    else
                    {
                        g.DrawArc(pen, rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);//same
                    }
                }
            }
            #endregion

            #region 绘制下边
            if ((borderStyle & BorderVisibleStyle.Bottom) != 0)
            {
                g.DrawLine(pen, ptEndBottomRight, ptBeginBottomLeft);
            }
            #endregion

            #region 绘制左下角
            if ((borderStyle & BorderVisibleStyle.Bottom) != 0 || (borderStyle & BorderVisibleStyle.Left) != 0)
            {
                if ((roundStyle & RoundStyle.BottomLeft) == 0)
                {
                    g.DrawLine(pen, ptBeginBottomLeft, ptEndBottomLeft);
                }
                else
                {
                    if ((cornerStyle & CornerStyle.LeftIn) != 0)
                    {
                        if (radius > halfHeight)
                            g.DrawArc(pen, rect.X - radius, rect.Bottom - diameter, diameter, diameter, 90, -lrDegrees);
                        else
                            g.DrawArc(pen, rect.X - radius, rect.Bottom - diameter, diameter, diameter, 90, -90);
                    }
                    else if ((cornerStyle & CornerStyle.LeftOut) != 0)
                    {
                        if (radius > halfHeight)
                            g.DrawArc(pen, rect.X - (radius - lrOffset), rect.Bottom - diameter, diameter, diameter, 90, lrDegrees);
                        else
                            g.DrawArc(pen, rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);//same
                    }
                    else if ((cornerStyle & CornerStyle.BottomIn) != 0)
                    {
                        if (radius > halfWidth)
                            g.DrawArc(pen, rect.X, rect.Bottom - radius, diameter, diameter, 180 + tbDegrees, -tbDegrees);
                        else
                            g.DrawArc(pen, rect.X, rect.Bottom - radius, diameter, diameter, 270, -90);
                    }
                    else if ((cornerStyle & CornerStyle.BottomOut) != 0)
                    {
                        if (radius > halfWidth)
                            g.DrawArc(pen, rect.X, rect.Bottom - radius - tbOffset, diameter, diameter, 180 - tbDegrees, tbDegrees);
                        else
                            g.DrawArc(pen, rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);//same
                    }
                    else
                    {
                        g.DrawArc(pen, rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);//same
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// 绘制模糊特效,颜色需要带alpha通道
        /// </summary>
        /// <param name="g">绘图对象</param>
        /// <param name="rect">区域</param>
        /// <param name="color">颜色(带alpha通道)</param>
        public static void DrawAeroBlur(Graphics g, Rectangle rect, Color color)
        {
            using (Brush brush = new SolidBrush(color))
            {
                g.FillRectangle(brush, rect);
            }
        }

        /// <summary>
        /// 绘制玻璃效果,颜色需要带alpha通道
        /// </summary>
        /// <param name="g">绘图对象</param>
        /// <param name="rect">区域</param>
        /// <param name="centerColor">中心颜色(带alpha通道)</param>
        /// <param name="surroundColor">周围颜色(带alpha通道)</param>
        public static void DrawAeroGlass(Graphics g, Rectangle rect, Color centerColor, Color surroundColor)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(rect);
                using (PathGradientBrush brush = new PathGradientBrush(path))
                {
                    brush.CenterColor = centerColor;
                    brush.SurroundColors = new Color[] { surroundColor };
                    brush.CenterPoint = new PointF(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
                    g.FillPath(brush, path);
                }
            }
        }

        /// <summary>
        /// 绘制对号(按比例)
        /// </summary>
        /// <param name="g">绘图对象</param>
        /// <param name="rect">绘图区域</param>
        /// <param name="color">颜色</param>
        public static void DrawCheck(Graphics g, Rectangle rect, Color color)
        {
            rect.Width--;
            rect.Height--;

            int width = rect.Width;
            int height = rect.Height;
            int l = rect.X;
            int t = rect.Y;
            int r = rect.Right;
            int b = rect.Bottom;

            PointF[] points = new PointF[3];
            points[0] = new PointF(l + width * 0.2f, t + height * 0.522f);//左
            points[1] = new PointF(l + width * 0.422f, b - height * 0.251f);//中
            points[2] = new PointF(r - width * 0.204f, t + height * 0.208f);//右
            using (Pen pen = new Pen(color, Math.Max(2f, Math.Min(rect.Width, rect.Height) * 0.15f)))
            {
                using (new SmoothingModeGraphics(g))
                {
                    g.DrawLines(pen, points);
                }
            }
        }

        /// <summary>
        /// 绘制叉号(按比例)
        /// </summary>
        /// <param name="g">绘图对象</param>
        /// <param name="rect">绘图区域</param>
        /// <param name="color">颜色</param>
        public static void DrawCross(Graphics g, Rectangle rect, Color color)
        {
            rect.Width--;
            rect.Height--;

            int width = rect.Width;
            int height = rect.Height;
            int l = rect.X;
            int t = rect.Y;
            int r = rect.Right;
            int b = rect.Bottom;
            float offset = 0.2f;

            PointF[] points = new PointF[2];
            points[0] = new PointF(l + offset * width, t + offset * height);
            points[1] = new PointF(r - offset * width, b - offset * height);

            PointF[] points1 = new PointF[2];
            points1[0] = new PointF(r - offset * width, t + offset * height);
            points1[1] = new PointF(l + offset * width, b - offset * height);

            using (Pen pen = new Pen(color, Math.Max(2f, Math.Min(rect.Width, rect.Height) / 6f)))
            {
                using (new SmoothingModeGraphics(g))
                {
                    g.DrawLines(pen, points);
                    g.DrawLines(pen, points1);
                }
            }
        }

        /// <summary>
        /// 绘制省略号(按比例)
        /// </summary>
        /// <param name="g">绘图对象</param>
        /// <param name="rect">绘图区域</param>
        /// <param name="color">颜色</param>
        public static void DrawEllipsis(Graphics g, Rectangle rect, Color color)
        {
            rect.Width--;
            rect.Height--;

            float d = Math.Max(3f, rect.Width / 6f);
            float t = rect.Y + (rect.Height - d) / 2f;
            float leftl = rect.X + d;
            float midl = rect.X + (rect.Width - d) / 2f;
            float rightl = rect.Right - d - d;

            using (Brush brush = new SolidBrush(color))
            {
                using (new SmoothingModeGraphics(g))
                {
                    g.FillEllipse(brush, leftl, t, d, d);
                    g.FillEllipse(brush, midl, t, d, d);
                    g.FillEllipse(brush, rightl, t, d, d);
                }
            }
        }

        /// <summary>
        /// 绘制箭头(按比例)
        /// </summary>
        /// <param name="g">绘图对象</param>
        /// <param name="rect">绘图区域</param>
        /// <param name="color">颜色</param>
        /// <param name="direction">方向</param>
        public static void DrawArrow(Graphics g, Rectangle rect, Color color, ArrowDirection direction)
        {
            rect.Width--;
            rect.Height--;

            int width = rect.Width;
            int height = rect.Height;
            int l = rect.X;
            int t = rect.Y;
            int r = rect.Right;
            int b = rect.Bottom;
            //以朝下的为准定义以下变量
            float offsetL = 0.24f;
            float offsetT = 0.33f;
            float offsetB = 0.27f;

            PointF[] points = new PointF[3]; ;
            switch (direction)
            {
                case ArrowDirection.Left:
                    points[0] = new PointF(l + width * offsetB, t + height * 0.5f);
                    points[1] = new PointF(r - width * offsetT, t + height * offsetL);
                    points[2] = new PointF(r - width * offsetT, b - height * offsetL);
                    break;

                case ArrowDirection.Up:
                    points[0] = new PointF(l + width * 0.5f, t + height * offsetB);
                    points[1] = new PointF(r - width * offsetL, b - height * offsetT);
                    points[2] = new PointF(l + width * offsetL, b - height * offsetT);
                    break;

                case ArrowDirection.Right:
                    points[0] = new PointF(l + width * offsetT, t + height * offsetL);
                    points[1] = new PointF(r - width * offsetB, t + height * 0.5f);
                    points[2] = new PointF(l + width * offsetT, b - height * offsetL);
                    break;

                default:
                    points[0] = new PointF(l + width * offsetL, t + height * offsetT);
                    points[1] = new PointF(r - width * offsetL, t + height * offsetT);
                    points[2] = new PointF(l + width * 0.5f, b - height * offsetB);
                    break;
            }

            using (Brush brush = new SolidBrush(color))
            {
                using (new SmoothingModeGraphics(g, SmoothingMode.AntiAlias))
                {
                    using (new PixelOffsetModeGraphics(g, PixelOffsetMode.Default))
                    {
                        g.FillPolygon(brush, points);
                    }
                }
            }
        }

        /// <summary>
        /// 绘制箭头(可选大小)
        /// </summary>
        /// <param name="g">绘图对象</param>
        /// <param name="rect">区域</param>
        /// <param name="color">颜色</param>
        /// <param name="direction">箭头方向</param>
        /// <param name="style">大小样式</param>
        public static void DrawArrow(Graphics g, Rectangle rect, Color color, ArrowDirection direction, SizeStyle style)
        {
            Point point = new Point(rect.Left + (rect.Width / 2), rect.Top + (rect.Height / 2));
            Point[] points = null;

            switch (style)
            {
                case SizeStyle.Tiny:
                    switch (direction)
                    {
                        case ArrowDirection.Left:
                            points = new Point[] { new Point(point.X + 1, point.Y - 2), new Point(point.X + 1, point.Y + 2), new Point(point.X - 1, point.Y) };
                            break;

                        case ArrowDirection.Up:
                            points = new Point[] { new Point(point.X - 2, point.Y + 1), new Point(point.X + 2, point.Y + 1), new Point(point.X, point.Y - 2) };
                            break;

                        case ArrowDirection.Right:
                            points = new Point[] { new Point(point.X - 1, point.Y - 2), new Point(point.X - 1, point.Y + 2), new Point(point.X + 1, point.Y) };
                            break;

                        default:
                            points = new Point[] { new Point(point.X - 1, point.Y - 1), new Point(point.X + 2, point.Y - 1), new Point(point.X, point.Y + 1) };
                            break;
                    }
                    break;

                case SizeStyle.Small:
                    switch (direction)
                    {
                        case ArrowDirection.Left:
                            points = new Point[] { new Point(point.X + 2, point.Y - 3), new Point(point.X + 2, point.Y + 3), new Point(point.X - 1, point.Y) };
                            break;

                        case ArrowDirection.Up:
                            points = new Point[] { new Point(point.X - 3, point.Y + 2), new Point(point.X + 3, point.Y + 2), new Point(point.X, point.Y - 2) };
                            break;

                        case ArrowDirection.Right:
                            points = new Point[] { new Point(point.X - 1, point.Y - 3), new Point(point.X - 1, point.Y + 3), new Point(point.X + 2, point.Y) };
                            break;

                        default:
                            points = new Point[] { new Point(point.X - 2, point.Y - 1), new Point(point.X + 3, point.Y - 1), new Point(point.X, point.Y + 2) };
                            break;
                    }
                    break;

                case SizeStyle.Normal:
                    switch (direction)
                    {
                        case ArrowDirection.Left:
                            points = new Point[] { new Point(point.X + 2, point.Y - 4), new Point(point.X + 2, point.Y + 4), new Point(point.X - 2, point.Y) };
                            break;

                        case ArrowDirection.Up:
                            points = new Point[] { new Point(point.X - 4, point.Y + 2), new Point(point.X + 5, point.Y + 2), new Point(point.X, point.Y - 3) };
                            break;

                        case ArrowDirection.Right:
                            points = new Point[] { new Point(point.X - 2, point.Y - 4), new Point(point.X - 2, point.Y + 4), new Point(point.X + 2, point.Y) };
                            break;

                        default:
                            points = new Point[] { new Point(point.X - 3, point.Y - 2), new Point(point.X + 4, point.Y - 2), new Point(point.X, point.Y + 2) };
                            break;
                    }
                    break;

                case SizeStyle.Large:
                    switch (direction)
                    {
                        case ArrowDirection.Left:
                            points = new Point[] { new Point(point.X + 3, point.Y - 5), new Point(point.X + 3, point.Y + 5), new Point(point.X - 2, point.Y) };
                            break;

                        case ArrowDirection.Up:
                            points = new Point[] { new Point(point.X - 5, point.Y + 3), new Point(point.X + 6, point.Y + 3), new Point(point.X, point.Y - 3) };
                            break;

                        case ArrowDirection.Right:
                            points = new Point[] { new Point(point.X - 2, point.Y - 5), new Point(point.X - 2, point.Y + 5), new Point(point.X + 3, point.Y) };
                            break;

                        default:
                            points = new Point[] { new Point(point.X - 4, point.Y - 2), new Point(point.X + 5, point.Y - 2), new Point(point.X, point.Y + 3) };
                            break;
                    }
                    break;

                case SizeStyle.Huge:
                    switch (direction)
                    {
                        case ArrowDirection.Left:
                            points = new Point[] { new Point(point.X + 3, point.Y - 6), new Point(point.X + 3, point.Y + 6), new Point(point.X - 3, point.Y) };
                            break;

                        case ArrowDirection.Up:
                            points = new Point[] { new Point(point.X - 6, point.Y + 3), new Point(point.X + 7, point.Y + 3), new Point(point.X, point.Y - 4) };
                            break;

                        case ArrowDirection.Right:
                            points = new Point[] { new Point(point.X - 3, point.Y - 6), new Point(point.X - 3, point.Y + 6), new Point(point.X + 3, point.Y) };
                            break;

                        default:
                            points = new Point[] { new Point(point.X - 5, point.Y - 3), new Point(point.X + 6, point.Y - 3), new Point(point.X, point.Y + 3) };
                            break;
                    }
                    break;

                default:
                    break;
            }

            using (Brush brush = new SolidBrush(color))
            {
                using (new SmoothingModeGraphics(g, SmoothingMode.None))
                {
                    using (new PixelOffsetModeGraphics(g, PixelOffsetMode.Default))
                    {
                        g.FillPolygon(brush, points);
                    }
                }
            }
        }
    }
}
