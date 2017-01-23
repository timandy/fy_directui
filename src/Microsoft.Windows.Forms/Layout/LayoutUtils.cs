using System;
using System.Drawing;
using System.Windows.Forms;

namespace Microsoft.Windows.Forms.Layout
{
    /// <summary>
    /// 布局工具类
    /// </summary>
    public static class LayoutUtils
    {
        /// <summary>
        /// <para>0*****1*****2</para>
        /// <para>*           *</para>
        /// <para>*           *</para>
        /// <para>4     5     6</para>
        /// <para>*           *</para>
        /// <para>*           *</para>
        /// <para>8*****9*****10</para>
        /// <para>获取对齐方式的索引,如上图</para>
        /// </summary>
        /// <param name="alignment">对齐方式</param>
        /// <returns>索引</returns>
        public static int ContentAlignmentToIndex(ContentAlignment alignment)
        {
            int num = xContentAlignmentToIndex(((int)alignment) & 15);//取0-3位,如果等于4返回3,其余不变
            int num2 = xContentAlignmentToIndex((((int)alignment) >> 4) & 15);//4-7,如果等于4返回3,其余不变
            int num3 = xContentAlignmentToIndex((((int)alignment) >> 8) & 15);//8-11,如果等于4返回3,其余不变
            int num4 = (((((num2 != 0) ? 4 : 0) | ((num3 != 0) ? 8 : 0)) | num) | num2) | num3;
            num4--;
            return num4;
        }
        /// <summary>
        /// 上面方法的辅助
        /// </summary>
        /// <param name="threeBitFlag">4bit数字</param>
        /// <returns>如果等于4返回3,其余不变</returns>
        private static byte xContentAlignmentToIndex(int threeBitFlag)
        {
            return ((threeBitFlag == 4) ? ((byte)3) : ((byte)threeBitFlag));
        }


        /// <summary>
        /// 获取反向的文本图片相对位置
        /// </summary>
        /// <param name="relation">文本图片相对位置</param>
        /// <returns>反向的文本图片相对位置</returns>
        public static TextImageRelation GetOppositeTextImageRelation(TextImageRelation relation)
        {
            return (TextImageRelation)GetOppositeAnchor((AnchorStyles)relation);
        }
        /// <summary>
        /// 获取反向的锚定方式
        /// </summary>
        /// <param name="anchor">锚定方式</param>
        /// <returns>反向的锚定方式</returns>
        private static AnchorStyles GetOppositeAnchor(AnchorStyles anchor)
        {
            AnchorStyles none = AnchorStyles.None;
            if (anchor != AnchorStyles.None)
            {
                for (int i = 1; i <= 8; i = i << 1)
                {
                    switch ((anchor & (AnchorStyles)i))
                    {
                        case AnchorStyles.Top:
                            none |= AnchorStyles.Bottom;
                            break;

                        case AnchorStyles.Bottom:
                            none |= AnchorStyles.Top;
                            break;

                        case AnchorStyles.Left:
                            none |= AnchorStyles.Right;
                            break;

                        case AnchorStyles.Right:
                            none |= AnchorStyles.Left;
                            break;
                    }
                }
            }
            return none;
        }


        /// <summary>
        /// 在矩形指定位置划出指定大小的区域
        /// </summary>
        /// <param name="size">大小</param>
        /// <param name="rect">矩形</param>
        /// <param name="align">对齐方式</param>
        /// <returns>划定区域</returns>
        public static Rectangle Align(Size size, Rectangle rect, ContentAlignment align)
        {
            return VAlign(size, HAlign(size, rect, align), align);
        }
        /// <summary>
        /// 调整X坐标和宽度,使宽度为size的宽度,在水平方向上移动对齐到矩形
        /// </summary>
        /// <param name="size">大小</param>
        /// <param name="rect">矩形</param>
        /// <param name="align">水平对齐方式</param>
        /// <returns>新矩形</returns>
        public static Rectangle HAlign(Size size, Rectangle rect, ContentAlignment align)
        {
            if ((align & (ContentAlignment.BottomRight | ContentAlignment.MiddleRight | ContentAlignment.TopRight)) != ((ContentAlignment)0))
            {
                rect.X += rect.Width - size.Width;
            }
            else if ((align & (ContentAlignment.BottomCenter | ContentAlignment.MiddleCenter | ContentAlignment.TopCenter)) != ((ContentAlignment)0))
            {
                rect.X += (rect.Width - size.Width) / 2;
            }
            rect.Width = size.Width;
            return rect;
        }
        /// <summary>
        /// 调整Y坐标和高度,使高度为size的高度,在垂直方向上移动对齐到矩形
        /// </summary>
        /// <param name="size">大小</param>
        /// <param name="rect">矩形</param>
        /// <param name="align">垂直对齐方式</param>
        /// <returns>新矩形</returns>
        public static Rectangle VAlign(Size size, Rectangle rect, ContentAlignment align)
        {
            if ((align & (ContentAlignment.BottomRight | ContentAlignment.BottomCenter | ContentAlignment.BottomLeft)) != ((ContentAlignment)0))
            {
                rect.Y += rect.Height - size.Height;
            }
            else if ((align & (ContentAlignment.MiddleRight | ContentAlignment.MiddleCenter | ContentAlignment.MiddleLeft)) != ((ContentAlignment)0))
            {
                rect.Y += (rect.Height - size.Height) / 2;
            }
            rect.Height = size.Height;
            return rect;
        }
        /// <summary>
        /// 在矩形指定位置划出指定大小的区域
        /// </summary>
        /// <param name="size">大小</param>
        /// <param name="rect">矩形</param>
        /// <param name="align">对齐方式</param>
        /// <returns>划定区域</returns>
        public static RectangleF Align(SizeF size, RectangleF rect, ContentAlignment align)
        {
            return VAlign(size, HAlign(size, rect, align), align);
        }
        /// <summary>
        /// 调整X坐标和宽度,使宽度为size的宽度,在水平方向上移动对齐到矩形
        /// </summary>
        /// <param name="size">大小</param>
        /// <param name="rect">矩形</param>
        /// <param name="align">水平对齐方式</param>
        /// <returns>新矩形</returns>
        public static RectangleF HAlign(SizeF size, RectangleF rect, ContentAlignment align)
        {
            if ((align & (ContentAlignment.BottomRight | ContentAlignment.MiddleRight | ContentAlignment.TopRight)) != ((ContentAlignment)0))
            {
                rect.X += rect.Width - size.Width;
            }
            else if ((align & (ContentAlignment.BottomCenter | ContentAlignment.MiddleCenter | ContentAlignment.TopCenter)) != ((ContentAlignment)0))
            {
                rect.X += (rect.Width - size.Width) / 2f;
            }
            rect.Width = size.Width;
            return rect;
        }
        /// <summary>
        /// 调整Y坐标和高度,使高度为size的高度,在垂直方向上移动对齐到矩形
        /// </summary>
        /// <param name="size">大小</param>
        /// <param name="rect">矩形</param>
        /// <param name="align">垂直对齐方式</param>
        /// <returns>新矩形</returns>
        public static RectangleF VAlign(SizeF size, RectangleF rect, ContentAlignment align)
        {
            if ((align & (ContentAlignment.BottomRight | ContentAlignment.BottomCenter | ContentAlignment.BottomLeft)) != ((ContentAlignment)0))
            {
                rect.Y += rect.Height - size.Height;
            }
            else if ((align & (ContentAlignment.MiddleRight | ContentAlignment.MiddleCenter | ContentAlignment.MiddleLeft)) != ((ContentAlignment)0))
            {
                rect.Y += (rect.Height - size.Height) / 2f;
            }
            rect.Height = size.Height;
            return rect;
        }

        /// <summary>
        /// 调整X坐标和宽度,使宽度为size的宽度,在水平方向上移动对齐到矩形
        /// </summary>
        /// <param name="size">大小</param>
        /// <param name="rect">矩形</param>
        /// <param name="align">水平对齐方式</param>
        /// <returns>新矩形</returns>
        public static Rectangle HAlign(Size size, Rectangle rect, HorizontalAlignment align)
        {
            if ((align & HorizontalAlignment.Right) != 0)
            {
                rect.X += rect.Width - size.Width;
            }
            else if ((align & HorizontalAlignment.Center) != 0)
            {
                rect.X += (rect.Width - size.Width) / 2;
            }
            rect.Width = size.Width;
            return rect;
        }
        /// <summary>
        /// 调整X坐标和宽度,使宽度为size的宽度,在水平方向上移动对齐到矩形
        /// </summary>
        /// <param name="size">大小</param>
        /// <param name="rect">矩形</param>
        /// <param name="align">水平对齐方式</param>
        /// <returns>新矩形</returns>
        public static RectangleF HAlign(SizeF size, RectangleF rect, HorizontalAlignment align)
        {
            if ((align & HorizontalAlignment.Right) != 0)
            {
                rect.X += rect.Width - size.Width;
            }
            else if ((align & HorizontalAlignment.Center) != 0)
            {
                rect.X += (rect.Width - size.Width) / 2f;
            }
            rect.Width = size.Width;
            return rect;
        }


        /// <summary>
        /// 从容器大小中减去指定大小by关系.重叠关系(需要预先手动排除)
        /// </summary>
        /// <param name="containerSize">容器大小</param>
        /// <param name="contentSize">内容大小</param>
        /// <param name="relation">容器内容关系</param>
        /// <returns>新大小</returns>
        public static Size SubAlignedRegion(Size containerSize, Size contentSize, TextImageRelation relation)
        {
            return SubAlignedRegionCore(containerSize, contentSize, IsVerticalRelation(relation));
        }
        /// <summary>
        /// 从容器大小中减去指定大小by是否上下关系.重叠关系(需要预先手动排除)
        /// </summary>
        /// <param name="containerSize">容器大小</param>
        /// <param name="contentSize">内容大小</param>
        /// <param name="vertical">是否垂直关系</param>
        /// <returns>新大小</returns>
        public static Size SubAlignedRegionCore(Size containerSize, Size contentSize, bool vertical)
        {
            if (vertical)
            {
                containerSize.Height -= contentSize.Height;
            }
            else
            {
                containerSize.Width -= contentSize.Width;
            }
            return containerSize;
        }
        /// <summary>
        /// 是否垂直关系
        /// </summary>
        /// <param name="relation">文本图片相对位置</param>
        /// <returns>是垂直关系返回true,否则返回false</returns>
        public static bool IsVerticalRelation(TextImageRelation relation)
        {
            return ((relation & (TextImageRelation.TextAboveImage | TextImageRelation.ImageAboveText)) != TextImageRelation.Overlay);
        }


        /// <summary>
        /// 两个大小相加,by关系.重叠关系(需要预先手动排除)
        /// </summary>
        /// <param name="contentSize1">内容大小1</param>
        /// <param name="contentSize2">内容大小2</param>
        /// <param name="relation">两个内容关系</param>
        /// <returns>新大小</returns>
        public static Size AddAlignedRegion(Size contentSize1, Size contentSize2, TextImageRelation relation)
        {
            return AddAlignedRegionCore(contentSize1, contentSize2, IsVerticalRelation(relation));
        }
        /// <summary>
        /// 两个大小相加,by是否上下关系.重叠关系(需要预先手动排除)
        /// </summary>
        /// <param name="contentSize1">内容大小1</param>
        /// <param name="contentSize2">内容大小2</param>
        /// <param name="vertical">是否吹关系</param>
        /// <returns>新大小</returns>
        public static Size AddAlignedRegionCore(Size contentSize1, Size contentSize2, bool vertical)
        {
            if (vertical)
            {
                contentSize1.Width = Math.Max(contentSize1.Width, contentSize2.Width);
                contentSize1.Height += contentSize2.Height;
            }
            else
            {
                contentSize1.Width += contentSize2.Width;
                contentSize1.Height = Math.Max(contentSize1.Height, contentSize2.Height);
            }
            return contentSize1;
        }


        /// <summary>
        /// 获取两个重叠的Size的最小容器的大小
        /// </summary>
        /// <param name="a">大小1</param>
        /// <param name="b">大小2</param>
        /// <returns>容器大小</returns>
        public static Size UnionSizes(Size a, Size b)
        {
            return new Size(Math.Max(a.Width, b.Width), Math.Max(a.Height, b.Height));
        }
        /// <summary>
        /// 按锚定方式分割矩形
        /// </summary>
        /// <param name="bounds">要被分割的矩形</param>
        /// <param name="contentSize">内容大小</param>
        /// <param name="anchor">锚定方式</param>
        /// <param name="region1">第一个矩形</param>
        /// <param name="region2">第二个矩形</param>
        public static void SplitRegion(Rectangle bounds, Size contentSize, AnchorStyles anchor, out Rectangle region1, out Rectangle region2)
        {
            region1 = region2 = bounds;
            switch (anchor)
            {
                case AnchorStyles.Top:
                    region1.Height = contentSize.Height;
                    region2.Y += contentSize.Height;
                    region2.Height -= contentSize.Height;
                    return;

                case AnchorStyles.Bottom:
                    region1.Y += bounds.Height - contentSize.Height;
                    region1.Height = contentSize.Height;
                    region2.Height -= contentSize.Height;
                    break;

                case (AnchorStyles.Bottom | AnchorStyles.Top):
                    break;

                case AnchorStyles.Left:
                    region1.Width = contentSize.Width;
                    region2.X += contentSize.Width;
                    region2.Width -= contentSize.Width;
                    return;

                case AnchorStyles.Right:
                    region1.X += bounds.Width - contentSize.Width;
                    region1.Width = contentSize.Width;
                    region2.Width -= contentSize.Width;
                    return;

                default:
                    return;
            }
        }


        /// <summary>
        /// 将region2按anchor锚定到bounds,将region1按反转的anchor锚定到bounds
        /// </summary>
        /// <param name="bounds">容器矩形</param>
        /// <param name="anchor">锚定方式</param>
        /// <param name="region1">矩形1</param>
        /// <param name="region2">矩形2</param>
        public static void ExpandRegionsToFillBounds(Rectangle bounds, AnchorStyles anchor, ref Rectangle region1, ref Rectangle region2)
        {
            switch (anchor)
            {
                case AnchorStyles.Top:
                    region1 = SubstituteSpecifiedBounds(bounds, region1, AnchorStyles.Bottom);
                    region2 = SubstituteSpecifiedBounds(bounds, region2, AnchorStyles.Top);
                    return;

                case AnchorStyles.Bottom:
                    region1 = SubstituteSpecifiedBounds(bounds, region1, AnchorStyles.Top);
                    region2 = SubstituteSpecifiedBounds(bounds, region2, AnchorStyles.Bottom);
                    break;

                case (AnchorStyles.Bottom | AnchorStyles.Top):
                    break;

                case AnchorStyles.Left:
                    region1 = SubstituteSpecifiedBounds(bounds, region1, AnchorStyles.Right);
                    region2 = SubstituteSpecifiedBounds(bounds, region2, AnchorStyles.Left);
                    return;

                case AnchorStyles.Right:
                    region1 = SubstituteSpecifiedBounds(bounds, region1, AnchorStyles.Left);
                    region2 = SubstituteSpecifiedBounds(bounds, region2, AnchorStyles.Right);
                    return;

                default:
                    return;
            }
        }
        /// <summary>
        /// 锚定内容矩形到容器矩形
        /// </summary>
        /// <param name="containerBounds">容器矩形</param>
        /// <param name="contentBounds">内容矩形</param>
        /// <param name="anchor">锚定方式</param>
        /// <returns>新矩形</returns>
        private static Rectangle SubstituteSpecifiedBounds(Rectangle containerBounds, Rectangle contentBounds, AnchorStyles anchor)
        {
            int left = ((anchor & AnchorStyles.Left) != AnchorStyles.None) ? contentBounds.Left : containerBounds.Left;
            int top = ((anchor & AnchorStyles.Top) != AnchorStyles.None) ? contentBounds.Top : containerBounds.Top;
            int right = ((anchor & AnchorStyles.Right) != AnchorStyles.None) ? contentBounds.Right : containerBounds.Right;
            int bottom = ((anchor & AnchorStyles.Bottom) != AnchorStyles.None) ? contentBounds.Bottom : containerBounds.Bottom;
            return Rectangle.FromLTRB(left, top, right, bottom);
        }
    }
}
