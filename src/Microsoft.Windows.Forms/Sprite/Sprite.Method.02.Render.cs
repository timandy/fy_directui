using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.Drawing;
using Microsoft.Windows.Forms.Layout;

namespace Microsoft.Windows.Forms
{
    partial class Sprite
    {
        //渲染时传递进来的临时变量
        private Rectangle m_BackColorRect;
        private Rectangle m_BackgroundImageRect;
        private Rectangle m_BackgroundImage9Rect;
        private Rectangle m_TextImageRect;
        private Rectangle m_StringRect;
        private Rectangle m_BorderColorRect;

        //渲染文本核心方法
        private void RenderTextCore(LayoutData layout)
        {
            layout.DoLayout();//执行布局
            this.CurrentTextPreferredRect = layout.OutTextBounds;//保存文本区域矩形
            bool needRotate = !(Single.IsNaN(this.m_TextRotateAngle) || this.m_TextRotateAngle % 360f == 0f);//是否需要旋转
            Rectangle textRect = needRotate ? RenderEngine.RotateRect(this.m_Graphics, this.CurrentTextPreferredRect, this.m_TextRotateAngle, false) : this.CurrentTextPreferredRect; //新绘图区域(如果旋转则为旋转后的区域)

            //绘制阴影或描边
            if (this.m_TextShadowShapeStyle != 0)
            {
                using (new SmoothingModeGraphics(this.m_Graphics, SmoothingMode.AntiAlias))
                {
                    using (GraphicsPath textPath = new GraphicsPath())
                    {
                        //添加文本
                        textPath.AddString(this.m_Text, this.m_Font.FontFamily, (int)this.m_Font.Style, this.m_Graphics.DpiY * this.m_Font.SizeInPoints / 72f, textRect, layout.CurrentStringFormat);

                        //绘制阴影和阴影描边
                        if (((this.m_TextShadowShapeStyle & ShadowShapeStyle.Shadow) != 0) || ((this.m_TextShadowShapeStyle & ShadowShapeStyle.ShapeOfShadow) != 0 && this.m_TextShapeOfShadowWidth > 0f))
                        {
                            using (GraphicsPath shadowPath = textPath.Clone() as GraphicsPath)
                            {
                                using (Matrix shadowMatrix = new Matrix(1, 0, 0, 1, this.m_TextShadowMatrixOffset.X, this.m_TextShadowMatrixOffset.Y))
                                {
                                    shadowPath.Transform(shadowMatrix);
                                }

                                //绘制阴影
                                if ((this.m_TextShadowShapeStyle & ShadowShapeStyle.Shadow) != 0)
                                {
                                    using (Brush shadowBrush = new SolidBrush(this.m_TextShadowColor))
                                    {
                                        this.m_Graphics.FillPath(shadowBrush, shadowPath);
                                    }
                                }
                                //阴影描边
                                if ((this.m_TextShadowShapeStyle & ShadowShapeStyle.ShapeOfShadow) != 0 && this.m_TextShapeOfShadowWidth > 0f)
                                {
                                    using (Pen shapeOfShadowPen = new Pen(this.m_TextShapeOfShadowColor, this.m_TextShapeOfShadowWidth))
                                    {
                                        this.m_Graphics.DrawPath(shapeOfShadowPen, shadowPath);
                                    }
                                }
                            }
                        }

                        //绘制文本
                        using (Brush textBrush = new SolidBrush(this.CurrentForeColor))
                        {
                            this.m_Graphics.FillPath(textBrush, textPath);
                        }

                        //文本描边
                        if ((this.m_TextShadowShapeStyle & ShadowShapeStyle.ShapeOfText) != 0 && this.m_TextShapeOfTextWidth > 0f)
                        {
                            using (Pen shapeOfTextPen = new Pen(this.m_TextShapeOfTextColor, this.m_TextShapeOfTextWidth))
                            {
                                this.m_Graphics.DrawPath(shapeOfTextPen, textPath);
                            }
                        }
                    }
                }
            }
            else
            {
                using (new TextRenderingHintGraphics(this.m_Graphics, this.m_TextRenderingHint))
                {
                    using (Brush textBrush = new SolidBrush(this.CurrentForeColor))
                    {
                        this.m_Graphics.DrawString(this.m_Text, this.m_Font, textBrush, textRect, layout.CurrentStringFormat);
                    }
                }
            }

            //恢复旋转
            if (needRotate)
                this.m_Graphics.ResetTransform();
        }
        //渲染图片核心方法
        private void RenderImageCore(LayoutData layout)
        {
            layout.DoLayout();//执行布局
            this.CurrentImagePreferredRect = layout.OutImageBounds;//保存图片区域矩形
            bool needRotate = !(float.IsNaN(this.m_ImageRotateAngle) || this.m_ImageRotateAngle % 360f == 0f);//是否需要旋转
            Rectangle imageBounds = needRotate ? RenderEngine.RotateRect(this.m_Graphics, this.CurrentImagePreferredRect, this.m_ImageRotateAngle, false) : this.CurrentImagePreferredRect;//新绘图区域(如果旋转则为旋转后的区域)

            //开始绘制
            if (this.m_State == State.Disabled && this.m_ImageGrayOnDisabled)
            {
                using (Image grayImg = RenderEngine.GetGrayImage(this.CurrentImage))
                {
                    this.m_Graphics.DrawImage(grayImg, imageBounds);
                }
            }
            else
            {
                this.m_Graphics.DrawImage(this.CurrentImage, imageBounds);
            }

            //恢复旋转
            if (needRotate)
                this.m_Graphics.ResetTransform();
        }

        /// <summary>
        /// 创建区域
        /// </summary>
        /// <param name="rect">区域位置和大小</param>
        /// <returns>区域</returns>
        public Region CreateRegion(Rectangle rect)
        {
            if (this.m_RoundStyle == RoundStyle.None)//直角
            {
                if ((this.m_RoundCornerStyle & CornerStyle.Horizontal) != 0)
                    rect.Inflate(2, 0);
                else if ((this.m_RoundCornerStyle & CornerStyle.Vertical) != 0)
                    rect.Inflate(0, 2);
                else
                    return null;
            }
            else//有圆角
            {
                if ((this.m_RoundCornerStyle & CornerStyle.Horizontal) != 0)
                    rect.Inflate(5, 1);
                else if ((this.m_RoundCornerStyle & CornerStyle.Vertical) != 0)
                    rect.Inflate(1, 5);
                else
                    return null;
            }

            using (GraphicsPath path = RenderEngine.CreateGraphicsPath(rect, this.m_RoundCornerStyle, this.m_RoundStyle, this.m_RoundRadius, false))
            {
                return new Region(path);
            }
        }

        /// <summary>
        /// 渲染背景色
        /// </summary>
        /// <param name="rect">渲染区域</param>
        public void RenderBackColor(Rectangle rect)
        {
            this.m_BackColorRect = rect;

            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(this.m_BackColorRect))
                return;

            using (Brush brush = RenderEngine.CreateBrush(this.CurrentBackColorBrushRect, this.CurrentBackColor, this.m_BackColorPos1, this.m_BackColorPos2, this.CurrentBackColorReverse, this.CurrentBackColorMode, this.m_BackColorBlendStyle))
            {
                if (float.IsNaN(this.m_RoundRadius) || this.m_RoundRadius <= 0f)
                    this.m_Graphics.FillRectangle(brush, this.CurrentBackColorPathRect);
                else
                    this.m_Graphics.FillPath(brush, this.CurrentBackColorPath);
            }
        }
        /// <summary>
        /// 渲染背景色特效
        /// </summary>
        public void RenderBackColorAero()
        {
            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(this.m_BackColorRect))
                return;

            //绘制模糊效果
            if ((this.m_BackColorAeroStyle & AeroStyle.Blur) != 0)
            {
                Rectangle blurRect = this.CurrentBackColorPathRect;
                int blurWidth = 0;
                int blurHeight = 0;
                switch (this.m_BackColorAlign)
                {
                    case TabAlignment.Top:
                        blurHeight = (int)(this.CurrentBackColorPathRect.Height * this.m_BackColorAeroPos);
                        blurRect.Height = blurHeight;
                        break;

                    case TabAlignment.Bottom:
                        blurHeight = (int)(this.CurrentBackColorPathRect.Height * this.m_BackColorAeroPos);
                        blurRect.Y = blurRect.Bottom - blurHeight;
                        blurRect.Height = blurHeight;
                        break;

                    case TabAlignment.Left:
                        blurWidth = (int)(this.CurrentBackColorPathRect.Width * this.m_BackColorAeroPos);
                        blurRect.Width = blurWidth;
                        break;

                    case TabAlignment.Right:
                        blurWidth = (int)(this.CurrentBackColorPathRect.Width * this.m_BackColorAeroPos);
                        blurRect.X = blurRect.Right - blurWidth;
                        blurRect.Width = blurWidth;
                        break;

                    default://同Top
                        blurHeight = (int)(this.CurrentBackColorPathRect.Height * this.m_BackColorAeroPos);
                        blurRect.Height = blurHeight;
                        break;
                }

                //绘制
                RenderEngine.DrawAeroBlur(this.m_Graphics, blurRect, this.m_BackColorAeroBlurColor);
            }

            //绘制玻璃效果
            if ((this.m_BackColorAeroStyle & AeroStyle.Glass) != 0)
            {
                Rectangle glassRect = this.CurrentBackColorPathRect;
                int blurWidth = 0;
                int blurHeight = 0;
                switch (this.m_BackColorAlign)
                {
                    case TabAlignment.Top:
                        blurHeight = (int)(glassRect.Height * this.BackColorAeroPos);
                        glassRect.Y += blurHeight;//底部
                        glassRect.Height = (glassRect.Height - blurHeight) * 2;//圆的一半
                        break;

                    case TabAlignment.Bottom:
                        blurHeight = (int)(glassRect.Height * this.BackColorAeroPos);
                        glassRect.Y -= (glassRect.Height - blurHeight);//顶部
                        glassRect.Height = (this.CurrentBackColorPathRect.Height - blurHeight) * 2;//圆的一半
                        break;


                    case TabAlignment.Left:
                        blurWidth = (int)(glassRect.Width * this.BackColorAeroPos);
                        glassRect.X += blurWidth;//右侧
                        glassRect.Width = (glassRect.Width - blurWidth) * 2;//圆的一半
                        break;


                    case TabAlignment.Right:
                        blurWidth = (int)(glassRect.Width * this.BackColorAeroPos);
                        glassRect.X -= (glassRect.Width - blurWidth);//左侧
                        glassRect.Width = (glassRect.Width - blurWidth) * 2;//圆的一般
                        break;

                    default://同Top
                        blurHeight = (int)(glassRect.Height * this.BackColorAeroPos);
                        glassRect.Y += blurHeight;//底部
                        glassRect.Height = (glassRect.Height - blurHeight) * 2;//圆的一半
                        break;
                }

                //绘制
                RenderEngine.DrawAeroGlass(this.m_Graphics, glassRect, this.BackColorAeroGlassCenterColor, this.BackColorAeroGlassSurroundColor);
            }
        }
        /// <summary>
        /// 渲染背景图
        /// </summary>
        /// <param name="rect">渲染区域</param>
        public void RenderBackgroundImage(Rectangle rect)
        {
            this.m_BackgroundImageRect = rect;

            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(this.m_BackgroundImageRect) || this.CurrentBackgroundImage == null)
                return;

            if (this.m_State == State.Disabled && this.m_BackgroundImageGrayOnDisabled)//灰色图片
            {
                using (Image img = RenderEngine.GetGrayImage(this.CurrentBackgroundImage))
                {
                    RenderEngine.DrawBackgroundImage(this.m_Graphics, img, this.CurrentBackgroundImageRect, this.m_BackgroundImageLayout);
                }
            }
            else//原图
            {
                RenderEngine.DrawBackgroundImage(this.m_Graphics, this.CurrentBackgroundImage, this.CurrentBackgroundImageRect, this.m_BackgroundImageLayout);
            }
        }
        /// <summary>
        /// 渲染九宫格背景图
        /// </summary>
        /// <param name="rect">渲染区域</param>
        public void RenderBackgroundImage9(Rectangle rect)
        {
            this.m_BackgroundImage9Rect = rect;

            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(this.m_BackgroundImage9Rect) || this.CurrentBackgroundImage9 == null)
                return;

            if (this.m_State == State.Disabled && this.m_BackgroundImage9GrayOnDisabled)//灰色图片
            {
                using (Image img = RenderEngine.GetGrayImage(this.CurrentBackgroundImage9))
                {
                    RenderEngine.DrawBackgroundImage9(this.m_Graphics, img, this.CurrentBackgroundImage9Rect, this.m_BackgroundImage9Padding.Left, this.m_BackgroundImage9Padding.Top, this.m_BackgroundImage9Padding.Right, this.m_BackgroundImage9Padding.Bottom, this.m_BackgroundImage9Layout);
                }
            }
            else//原图
            {
                RenderEngine.DrawBackgroundImage9(this.m_Graphics, this.CurrentBackgroundImage9, this.CurrentBackgroundImage9Rect, this.m_BackgroundImage9Padding.Left, this.m_BackgroundImage9Padding.Top, this.m_BackgroundImage9Padding.Right, this.m_BackgroundImage9Padding.Bottom, this.m_BackgroundImage9Layout);
            }
        }
        /// <summary>
        /// 渲染文本和图片
        /// </summary>
        /// <param name="rect">渲染区域</param>
        public void RenderTextAndImage(Rectangle rect)
        {
            this.m_TextImageRect = rect;

            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(this.m_TextImageRect) || ((this.m_Text == null || this.m_Text.Length <= 0) && this.m_Image == null))
                return;

            using (LayoutData layout = new LayoutData())
            {
                layout.Graphics = this.m_Graphics;

                layout.ClientRectangle = this.CurrentTextImageClientRect;
                layout.Padding = this.m_Padding;
                layout.TextImageRelation = this.m_TextImageRelation;
                layout.RightToLeft = this.m_RightToLeft;

                layout.ImageSize = (this.CurrentImage == null ? Size.Empty : this.m_ImageSize);
                layout.ImageAlign = this.m_ImageAlign;
                layout.ImageOffset = this.m_ImageOffset;

                layout.Text = this.m_Text;
                layout.Font = this.m_Font;
                layout.TextAlign = this.m_TextAlign;
                layout.TextOffset = this.m_TextOffset;

                if (this.CurrentImage != null)
                    this.RenderImageCore(layout);

                if (this.Text != null && this.Text.Length > 0)
                    this.RenderTextCore(layout);
            }
        }
        /// <summary>
        /// 渲染文本
        /// </summary>
        /// <param name="rect">渲染区域</param>
        public void RenderText(Rectangle rect)
        {
            this.m_TextImageRect = rect;

            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(this.m_TextImageRect) || this.Text == null || this.Text.Length <= 0)
                return;

            using (LayoutData layout = new LayoutData())
            {
                layout.Graphics = this.m_Graphics;

                layout.ClientRectangle = this.CurrentTextImageClientRect;
                layout.Padding = this.m_Padding;
                layout.TextImageRelation = this.m_TextImageRelation;
                layout.RightToLeft = this.m_RightToLeft;

                layout.Text = this.m_Text;
                layout.Font = this.m_Font;
                layout.TextAlign = this.m_TextAlign;
                layout.TextOffset = this.m_TextOffset;

                this.RenderTextCore(layout);
            }
        }
        /// <summary>
        /// 渲染图片
        /// </summary>
        /// <param name="rect">渲染区域</param>
        public void RenderImage(Rectangle rect)
        {
            this.m_TextImageRect = rect;

            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(this.m_TextImageRect) || this.CurrentImage == null)
                return;

            using (LayoutData layout = new LayoutData())
            {
                layout.Graphics = this.m_Graphics;

                layout.ClientRectangle = this.CurrentTextImageClientRect;
                layout.Padding = this.m_Padding;
                layout.TextImageRelation = this.m_TextImageRelation;
                layout.RightToLeft = this.m_RightToLeft;

                layout.ImageSize = (this.CurrentImage == null ? Size.Empty : this.m_ImageSize);
                layout.ImageAlign = this.m_ImageAlign;
                layout.ImageOffset = this.m_ImageOffset;

                this.RenderImageCore(layout);
            }
        }
        /// <summary>
        /// 准备渲染字符串路径,返回字符串路径的大小(测量字符串路径大小,画布无限制)
        /// </summary>
        /// <returns>字符串路径大小</returns>
        public Size BeginRenderString()
        {
            if (this.m_State == State.Hidden || this.Text == null || this.Text.Length <= 0)
                return Size.Empty;

            Size strSize;
            this.m_CurrentStringPathRect = RenderEngine.BeginDrawString(this.m_Graphics, this.Text, this.Font, out strSize);
            this.m_CurrentStringSize = strSize;
            return this.CurrentStringPathRect.Size;
        }
        /// <summary>
        /// 准备渲染字符串路径,返回字符串路径的大小(测量字符串路径大小,画布有限制)
        /// </summary>
        /// <param name="rect">测量时,画布限制.与绘制区域无关</param>
        /// <returns>字符串路径大小</returns>
        public Size BeginRenderString(Rectangle rect)
        {
            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(rect) || this.Text == null || this.Text.Length <= 0)
                return Size.Empty;

            Size strSize;
            this.m_CurrentStringPathRect = RenderEngine.BeginDrawString(this.m_Graphics, this.Text, this.Font, rect, out strSize);
            this.m_CurrentStringSize = strSize;
            return this.CurrentStringPathRect.Size;
        }
        /// <summary>
        /// 正式渲染字符串路径
        /// </summary>
        /// <param name="rect">渲染区域</param>
        public void EndRenderString(Rectangle rect)
        {
            this.m_StringRect = rect;

            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(this.m_StringRect) || this.Text == null || this.Text.Length <= 0)
                return;

            using (Brush brush = new SolidBrush(this.CurrentForeColor))
            {
                RenderEngine.EndDrawString(this.m_Graphics, this.m_Text, this.m_Font, brush, this.CurrentStringRect, this.m_TextAlign, this.CurrentStringPathRect, this.CurrentStringSize);
            }
        }
        /// <summary>
        /// 渲染字符串路径
        /// </summary>
        /// <param name="rect">渲染区域</param>
        public void RenderString(Rectangle rect)
        {
            this.BeginRenderString(rect);
            this.EndRenderString(rect);
        }
        /// <summary>
        /// 渲染边框颜色(RoundStyle圆角样式,BorderStyle确定绘制哪个边,BlendStyle混合方式)
        /// </summary>
        /// <param name="rect">渲染区域</param>
        public void RenderBorder(Rectangle rect)
        {
            this.m_BorderColorRect = rect;

            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(this.m_BorderColorRect))
                return;

            //重置剪切区
            this.m_Graphics.SetClip(this.m_GraphicsClip, CombineMode.Replace);

            //绘制内边框
            if (this.m_InnerBorderVisibleStyle != BorderVisibleStyle.None)
            {
                using (Brush brush = RenderEngine.CreateBrush(this.CurrentInnerBorderBrushRect, this.CurrentInnerBorderColor, this.m_InnerBorderColorPos1, this.m_InnerBorderColorPos2, this.CurrentBackColorReverse, this.CurrentBackColorMode, this.m_InnerBorderBlendStyle))
                {
                    using (Pen pen = RenderEngine.CreatePen(brush, 1, this.m_InnerBorderDashStyle, this.m_InnerBorderDashPattern, this.m_InnerBorderDashCap, this.m_InnerBorderDashOffset))
                    {
                        RenderEngine.DrawBorder(this.m_Graphics, pen, this.CurrentInnerBorderPathRect, this.m_InnerBorderVisibleStyle, this.m_RoundCornerStyle, this.m_RoundStyle, this.m_RoundRadius, false);
                    }
                }
            }

            //绘制边框
            if (this.m_BorderVisibleStyle != BorderVisibleStyle.None)
            {
                using (Brush brush = RenderEngine.CreateBrush(this.CurrentBorderBrushRect, this.CurrentBorderColor, this.m_BorderColorPos1, this.m_BorderColorPos2, this.CurrentBackColorReverse, this.CurrentBackColorMode, this.m_BorderBlendStyle))
                {
                    using (Pen pen = RenderEngine.CreatePen(brush, 1, this.m_BorderDashStyle, this.m_BorderDashPattern, this.m_BorderDashCap, this.m_BorderDashOffset))
                    {
                        RenderEngine.DrawBorder(this.m_Graphics, pen, this.CurrentBorderPathRect, this.m_BorderVisibleStyle, this.m_RoundCornerStyle, this.m_RoundStyle, this.m_RoundRadius, false);
                    }
                }
            }
        }
        /// <summary>
        /// 渲染线段
        /// </summary>
        /// <param name="pt1">起点</param>
        /// <param name="pt2">终点</param>
        public void RenderLine(Point pt1, Point pt2)
        {
            if (this.m_State == State.Hidden || pt1 == pt2)
                return;

            //使用边框颜色
            using (Brush brush = RenderEngine.CreateBrush(pt1, pt2, this.CurrentLineColor, this.m_LineBlendStyle))
            {
                using (Pen pen = RenderEngine.CreatePen(brush, this.m_LineWidth, this.m_LineDashStyle, this.m_LineDashPattern, this.m_LineDashCap, this.m_LineDashOffset))
                {
                    this.m_Graphics.DrawLine(pen, pt1, pt2);
                }
            }
        }

        /// <summary>
        /// 渲染对号(按比例渲染)
        /// </summary>
        /// <param name="rect">渲染区域</param>
        public void RenderCheck(Rectangle rect)
        {
            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(rect))
                return;

            this.CurrentTextPreferredRect = rect;
            RenderEngine.DrawCheck(this.m_Graphics, this.CurrentTextPreferredRect, this.CurrentForeColor);
        }
        /// <summary>
        /// 渲染叉号(按比例渲染)
        /// </summary>
        /// <param name="rect">渲染区域</param>
        public void RenderCross(Rectangle rect)
        {
            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(rect))
                return;

            this.CurrentTextPreferredRect = rect;
            RenderEngine.DrawCross(this.m_Graphics, this.CurrentTextPreferredRect, this.CurrentForeColor);
        }
        /// <summary>
        /// 渲染省略号(按比例渲染)
        /// </summary>
        /// <param name="rect">渲染区域</param>
        public void RenderEllipsis(Rectangle rect)
        {
            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(rect))
                return;

            this.CurrentTextPreferredRect = rect;
            RenderEngine.DrawEllipsis(this.m_Graphics, this.CurrentTextPreferredRect, this.CurrentForeColor);
        }
        /// <summary>
        /// 渲染箭头(按比例渲染)
        /// </summary>
        /// <param name="rect">渲染区域</param>
        /// <param name="direction">箭头方向</param>
        public void RenderArrow(Rectangle rect, ArrowDirection direction)
        {
            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(rect))
                return;

            this.CurrentTextPreferredRect = rect;
            RenderEngine.DrawArrow(this.m_Graphics, this.CurrentTextPreferredRect, this.CurrentForeColor, direction);
        }
        /// <summary>
        /// 渲染箭头(固定大小)
        /// </summary>
        /// <param name="rect">渲染区域</param>
        /// <param name="direction">箭头方向</param>
        /// <param name="style">大小样式</param>
        public void RenderArrow(Rectangle rect, ArrowDirection direction, SizeStyle style)
        {
            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(rect))
                return;

            this.CurrentTextPreferredRect = rect;
            RenderEngine.DrawArrow(this.m_Graphics, this.CurrentTextPreferredRect, this.CurrentForeColor, direction, style);
        }
        /// <summary>
        /// 渲染Metrol按下边框
        /// </summary>
        /// <param name="rect">渲染区域</param>
        public void RenderMetroPress(Rectangle rect)
        {
            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(rect))
                return;

            //左侧
            if ((this.m_InnerBorderVisibleStyle & BorderVisibleStyle.Left) != 0)
            {
                rect.X += 2;
                rect.Width -= 2;
            }
            else if ((this.m_BorderVisibleStyle & BorderVisibleStyle.Left) != 0)
            {
                rect.X += 1;
                rect.Width -= 1;
            }

            //上边
            if ((this.m_InnerBorderVisibleStyle & BorderVisibleStyle.Top) != 0)
            {
                rect.Y += 2;
                rect.Height -= 2;
            }
            else if ((this.m_BorderVisibleStyle & BorderVisibleStyle.Top) != 0)
            {
                rect.Y += 1;
                rect.Height -= 1;
            }

            //右边
            if ((this.m_InnerBorderVisibleStyle & BorderVisibleStyle.Right) != 0)
            {
                rect.Width -= 2;
            }
            else if ((this.m_BorderVisibleStyle & BorderVisibleStyle.Right) != 0)
            {
                rect.Width -= 1;
            }

            //下边
            if ((this.m_InnerBorderVisibleStyle & BorderVisibleStyle.Bottom) != 0)
            {
                rect.Height -= 2;
            }
            else if ((this.m_BorderVisibleStyle & BorderVisibleStyle.Bottom) != 0)
            {
                rect.Height -= 1;
            }

            //设置剪切区
            this.m_Graphics.SetClip(rect);

            //绘制宽边框
            using (GraphicsPath pathBorder = RenderEngine.CreateGraphicsPath(rect),
                pathBorderIn = RenderEngine.CreateGraphicsPath(Rectangle.Inflate(rect, -3, -3)))
            {
                //边框区域
                pathBorder.AddPath(pathBorderIn, true);

                //绘制
                using (Brush brush = new SolidBrush(this.CurrentBorderColor))
                {
                    this.m_Graphics.FillPath(brush, pathBorder);
                }
            }
        }
        /// <summary>
        /// 绘制Metrol选中边框
        /// </summary>
        /// <param name="rect">渲染区域</param>
        public void RenderMetroCheck(Rectangle rect)
        {
            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(rect))
                return;

            //左侧
            if ((this.m_InnerBorderVisibleStyle & BorderVisibleStyle.Left) != 0)
            {
                rect.X += 2;
                rect.Width -= 2;
            }
            else if ((this.m_BorderVisibleStyle & BorderVisibleStyle.Left) != 0)
            {
                rect.X += 1;
                rect.Width -= 1;
            }

            //上边
            if ((this.m_InnerBorderVisibleStyle & BorderVisibleStyle.Top) != 0)
            {
                rect.Y += 2;
                rect.Height -= 2;
            }
            else if ((this.m_BorderVisibleStyle & BorderVisibleStyle.Top) != 0)
            {
                rect.Y += 1;
                rect.Height -= 1;
            }

            //右边
            if ((this.m_InnerBorderVisibleStyle & BorderVisibleStyle.Right) != 0)
            {
                rect.Width -= 2;
            }
            else if ((this.m_BorderVisibleStyle & BorderVisibleStyle.Right) != 0)
            {
                rect.Width -= 1;
            }

            //下边
            if ((this.m_InnerBorderVisibleStyle & BorderVisibleStyle.Bottom) != 0)
            {
                rect.Height -= 2;
            }
            else if ((this.m_BorderVisibleStyle & BorderVisibleStyle.Bottom) != 0)
            {
                rect.Height -= 1;
            }

            //设置剪切区
            this.m_Graphics.SetClip(rect);

            //绘制宽边框
            using (GraphicsPath pathBorder = RenderEngine.CreateGraphicsPath(rect),
                pathBorderIn = RenderEngine.CreateGraphicsPath(Rectangle.Inflate(rect, -3, -3)),
                pathTriangle = new GraphicsPath())
            {
                //边框区域
                pathBorder.AddPath(pathBorderIn, true);

                //右上角三角区域
                Point[] points = new Point[] {
                    new Point(rect.X + rect.Width - 40, rect.Y),
                    new Point(rect.X + rect.Width, rect.Y),
                    new Point(rect.X + rect.Width, rect.Y + 40) 
                };
                pathTriangle.AddPolygon(points);

                //绘制
                using (Brush brush = new SolidBrush(this.CurrentBackColor))
                {
                    this.m_Graphics.FillPath(brush, pathBorder);
                    this.m_Graphics.FillPath(brush, pathTriangle);
                }
            }

            //绘制对号
            RenderEngine.DrawCheck(this.m_Graphics, new Rectangle(rect.Right - 22, rect.Y + 2, 20, 20), this.CurrentForeColor);
        }
        /// <summary>
        /// 渲染标签样式分组控件背景色
        /// </summary>
        /// <param name="rect">渲染区域</param>
        /// <param name="tabSize">左上角标签大小</param>
        /// <param name="tabRound">标签右上角是否发圆角</param>
        /// <param name="tabRadius">标签右上角圆角半径</param>
        public void RenderBackColorGroupBoxTab(Rectangle rect, Size tabSize, bool tabRound, float tabRadius)
        {
            this.m_BackColorRect = rect;

            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(this.m_BackColorRect))
                return;

            using (Brush brush = RenderEngine.CreateBrush(this.CurrentBackColorBrushRect, this.CurrentBackColor, this.m_BackColorPos1, this.m_BackColorPos2, this.CurrentBackColorReverse, this.CurrentBackColorMode, this.m_BackColorBlendStyle))
            {
                //校正背景区域
                if (this.m_InnerBorderVisibleStyle != BorderVisibleStyle.None)
                    tabSize.Width -= 4;
                else if (this.m_BorderVisibleStyle != BorderVisibleStyle.None)
                    tabSize.Width -= 2;
                using (GraphicsPath path = RenderEngine.CreateGroupBoxTabGraphicsPath(this.CurrentBackColorPathRect, this.m_RoundStyle, this.m_RoundRadius, tabSize, tabRound, tabRadius, false))
                {
                    this.m_Graphics.SetClip(path, CombineMode.Intersect);
                    this.m_Graphics.FillPath(brush, path);
                }
            }
        }
        /// <summary>
        /// 渲染标签样式分组控件边框色
        /// </summary>
        /// <param name="rect">渲染区域</param>
        /// <param name="tabSize">左上角标签大小</param>
        /// <param name="tabRound">标签右上角是否发圆角</param>
        /// <param name="tabRadius">标签右上角圆角半径</param>
        public void RenderBorderColorGroupBoxTab(Rectangle rect, Size tabSize, bool tabRound, float tabRadius)
        {
            this.m_BorderColorRect = rect;

            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(this.m_BorderColorRect))
                return;

            //重置剪切区
            this.m_Graphics.SetClip(this.m_GraphicsClip, CombineMode.Replace);

            //绘制内边框
            if (this.m_InnerBorderVisibleStyle != BorderVisibleStyle.None)
            {
                using (Brush brush = RenderEngine.CreateBrush(this.CurrentInnerBorderBrushRect, this.CurrentInnerBorderColor, this.m_InnerBorderColorPos1, this.m_InnerBorderColorPos2, this.CurrentBackColorReverse, this.CurrentBackColorMode, this.m_InnerBorderBlendStyle))
                {
                    using (Pen pen = RenderEngine.CreatePen(brush, 1, this.m_InnerBorderDashStyle, this.m_InnerBorderDashPattern, this.m_InnerBorderDashCap, this.m_InnerBorderDashOffset))
                    {
                        Size innerBorderTabSize = new Size(tabSize.Width - 3, tabSize.Height);
                        using (GraphicsPath path = RenderEngine.CreateGroupBoxTabGraphicsPath(this.CurrentInnerBorderPathRect, this.m_RoundStyle, this.m_RoundRadius, innerBorderTabSize, tabRound, tabRadius, false))
                        {
                            this.m_Graphics.DrawPath(pen, path);
                        }
                    }
                }
            }

            //绘制边框
            if (this.m_BorderVisibleStyle != BorderVisibleStyle.None)
            {
                using (Brush brush = RenderEngine.CreateBrush(this.CurrentBorderBrushRect, this.CurrentBorderColor, this.m_BorderColorPos1, this.m_BorderColorPos2, this.CurrentBackColorReverse, this.CurrentBackColorMode, this.m_BorderBlendStyle))
                {
                    using (Pen pen = RenderEngine.CreatePen(brush, 1, this.m_BorderDashStyle, this.m_BorderDashPattern, this.m_BorderDashCap, this.m_BorderDashOffset))
                    {
                        Size borderTabSize = new Size(tabSize.Width - 1, tabSize.Height);
                        using (GraphicsPath path = RenderEngine.CreateGroupBoxTabGraphicsPath(this.CurrentBorderPathRect, this.m_RoundStyle, this.m_RoundRadius, borderTabSize, tabRound, tabRadius, false))
                        {
                            this.m_Graphics.DrawPath(pen, path);
                        }
                    }
                }
            }
        }
    }
}
