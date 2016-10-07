using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Microsoft.Drawing;

namespace Microsoft.Windows.Forms
{
    public static partial class RenderEngine
    {
        /// <summary>
        /// 获取线段与水平X轴夹角(角度表示)
        /// </summary>
        /// <param name="pt1">起点</param>
        /// <param name="pt2">终点</param>
        /// <returns>夹角</returns>
        public static float GetLineDegrees(Point pt1, Point pt2)
        {
            return (float)MathEx.ToDegrees(Math.Atan(((double)pt2.Y - (double)pt1.Y) / ((double)pt2.X - (double)pt1.X)));
        }

        /// <summary>
        /// 获取包含线段的最小矩形(非空)
        /// </summary>
        /// <param name="pt1">起点</param>
        /// <param name="pt2">终点</param>
        /// <returns>矩形</returns>
        public static Rectangle GetLineRect(Point pt1, Point pt2)
        {
            Rectangle rect = Rectangle.FromLTRB(Math.Min(pt1.X, pt2.X), Math.Min(pt1.Y, pt2.Y), Math.Max(pt1.X, pt2.X), Math.Max(pt1.Y, pt2.Y));
            rect.Inflate(1, 1);
            return rect;
        }


        /// <summary>
        /// 创建画刷,渲染背景和边框使用
        /// </summary>
        /// <param name="rect">画刷区域</param>
        /// <param name="baseColor">基色</param>
        /// <param name="pos1">基色位置1</param>
        /// <param name="pos2">基色位置2</param>
        /// <param name="reverse">是否反转</param>
        /// <param name="mode">渐变模式</param>
        /// <param name="style">样式</param>
        /// <returns>画刷</returns>
        public static Brush CreateBrush(Rectangle rect, Color baseColor, float pos1, float pos2, bool reverse, LinearGradientMode mode, BlendStyle style)
        {
            Brush brush = null;
            RectangleEx.MakeNotEmpty(ref rect);
            switch (style)
            {
                case BlendStyle.Solid:
                    {
                        SolidBrush brushTmp = new SolidBrush(baseColor);
                        brush = brushTmp;
                        brushTmp = null;
                    }
                    break;

                case BlendStyle.Gradient:
                    {
                        LinearGradientBrush brushTmp = new LinearGradientBrush(rect, Color.Empty, Color.Empty, mode);
                        //画刷设置
                        ColorBlend blendTmp = new ColorBlend();
                        Color[] colors;
                        float[] positions;
                        RenderEngine.GetColorPosGradient(baseColor, pos1, pos2, reverse, false, out colors, out positions);
                        blendTmp.Colors = colors;
                        blendTmp.Positions = positions;
                        //
                        brushTmp.InterpolationColors = blendTmp;
                        brush = brushTmp;
                        brushTmp = null;
                    }
                    break;

                case BlendStyle.FadeIn:
                    {
                        LinearGradientBrush brushTmp = new LinearGradientBrush(rect, Color.Empty, Color.Empty, mode);
                        //画刷设置
                        ColorBlend blendTmp = new ColorBlend();
                        Color[] colors;
                        float[] positions;
                        RenderEngine.GetColorPosFadeIn(baseColor, pos1, pos2, reverse, false, out colors, out positions);
                        blendTmp.Colors = colors;
                        blendTmp.Positions = positions;
                        //
                        brushTmp.InterpolationColors = blendTmp;
                        brush = brushTmp;
                        brushTmp = null;
                    }
                    break;

                case BlendStyle.FadeOut:
                    {
                        LinearGradientBrush brushTmp = new LinearGradientBrush(rect, Color.Empty, Color.Empty, mode);
                        //画刷设置
                        ColorBlend blendTmp = new ColorBlend();
                        Color[] colors;
                        float[] positions;
                        RenderEngine.GetColorPosFadeOut(baseColor, pos1, pos2, reverse, false, out colors, out positions);
                        blendTmp.Colors = colors;
                        blendTmp.Positions = positions;
                        //
                        brushTmp.InterpolationColors = blendTmp;
                        brush = brushTmp;
                        brushTmp = null;
                    }
                    break;

                case BlendStyle.FadeInFadeOut:
                    {
                        LinearGradientBrush brushTmp = new LinearGradientBrush(rect, Color.Empty, Color.Empty, mode);
                        //画刷设置
                        ColorBlend blendTmp = new ColorBlend();
                        Color[] colors;
                        float[] positions;
                        RenderEngine.GetColorPosFadeInFadeOut(baseColor, pos1, pos2, reverse, false, out colors, out positions);
                        blendTmp.Colors = colors;
                        blendTmp.Positions = positions;
                        //
                        brushTmp.InterpolationColors = blendTmp;
                        brush = brushTmp;
                        brushTmp = null;
                    }
                    break;

                default:
                    break;
            }
            return brush;
        }

        /// <summary>
        /// 创建画刷,渲染线段使用
        /// </summary>
        /// <param name="pt1">起点</param>
        /// <param name="pt2">终点</param>
        /// <param name="baseColor">基色</param>
        /// <param name="style">样式</param>
        /// <returns>画刷</returns>
        public static Brush CreateBrush(Point pt1, Point pt2, Color baseColor, BlendStyle style)
        {
            Brush brush = null;
            switch (style)
            {
                case BlendStyle.Solid:
                    {
                        SolidBrush brushTmp = new SolidBrush(baseColor);
                        brush = brushTmp;
                        brushTmp = null;
                    }
                    break;

                case BlendStyle.Gradient:
                    {
                        LinearGradientBrush brushTmp = new LinearGradientBrush(GetLineRect(pt1, pt2), Color.Empty, Color.Empty, GetLineDegrees(pt1, pt2));
                        //画刷设置
                        ColorBlend blendTmp = new ColorBlend();
                        Color[] colors;
                        float[] positions;
                        RenderEngine.GetColorPosGradient(baseColor, float.NaN, float.NaN, false, true, out colors, out positions);
                        blendTmp.Colors = colors;
                        blendTmp.Positions = positions;
                        //
                        brushTmp.InterpolationColors = blendTmp;
                        brush = brushTmp;
                        brushTmp = null;
                    }
                    break;

                case BlendStyle.FadeIn:
                    {
                        LinearGradientBrush brushTmp = new LinearGradientBrush(GetLineRect(pt1, pt2), Color.Empty, Color.Empty, GetLineDegrees(pt1, pt2));
                        //画刷设置
                        ColorBlend blendTmp = new ColorBlend();
                        Color[] colors;
                        float[] positions;
                        RenderEngine.GetColorPosFadeIn(baseColor, float.NaN, float.NaN, false, true, out colors, out positions);
                        blendTmp.Colors = colors;
                        blendTmp.Positions = positions;
                        //
                        brushTmp.InterpolationColors = blendTmp;
                        brush = brushTmp;
                        brushTmp = null;
                    }
                    break;

                case BlendStyle.FadeOut:
                    {
                        LinearGradientBrush brushTmp = new LinearGradientBrush(GetLineRect(pt1, pt2), Color.Empty, Color.Empty, GetLineDegrees(pt1, pt2));
                        //画刷设置
                        ColorBlend blendTmp = new ColorBlend();
                        Color[] colors;
                        float[] positions;
                        RenderEngine.GetColorPosFadeOut(baseColor, float.NaN, float.NaN, false, true, out colors, out positions);
                        blendTmp.Colors = colors;
                        blendTmp.Positions = positions;
                        //
                        brushTmp.InterpolationColors = blendTmp;
                        brush = brushTmp;
                        brushTmp = null;
                    }
                    break;

                case BlendStyle.FadeInFadeOut:
                    {
                        LinearGradientBrush brushTmp = new LinearGradientBrush(GetLineRect(pt1, pt2), Color.Empty, Color.Empty, GetLineDegrees(pt1, pt2));
                        //画刷设置
                        ColorBlend blendTmp = new ColorBlend();
                        Color[] colors;
                        float[] positions;
                        RenderEngine.GetColorPosFadeInFadeOut(baseColor, float.NaN, float.NaN, false, true, out colors, out positions);
                        blendTmp.Colors = colors;
                        blendTmp.Positions = positions;
                        //
                        brushTmp.InterpolationColors = blendTmp;
                        brush = brushTmp;
                        brushTmp = null;
                    }
                    break;

                default:
                    break;
            }
            return brush;
        }

        /// <summary>
        /// 创建画笔
        /// </summary>
        /// <param name="brush">画刷</param>
        /// <param name="width">直线宽度</param>
        /// <param name="style">虚线样式</param>
        /// <param name="pattern">点线长度数组</param>
        /// <param name="cap">每个线段键帽样式</param>
        /// <param name="offset">直线的起点到短划线图案起始处的距离</param>
        /// <returns>画笔</returns>
        public static Pen CreatePen(Brush brush, int width, DashStyle style, float[] pattern, DashCap cap, float offset)
        {
            Pen pen = new Pen(brush);
            pen.Width = width;
            pen.DashStyle = style;
            if (style == DashStyle.Custom && pattern != null && pattern.Length > 0)
                pen.DashPattern = pattern;
            pen.DashCap = cap;
            pen.DashOffset = offset;
            return pen;
        }
    }
}
