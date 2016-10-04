using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Drawing;

namespace Microsoft.Windows.Forms
{
    public static partial class RenderEngine
    {
        /// <summary>
        /// 颜色c1,相对c2是否为暗色
        /// </summary>
        /// <param name="c1">颜色c1</param>
        /// <param name="c2">颜色c2</param>
        /// <returns>是否为暗</returns>
        private static bool IsDarker(Color c1, Color c2)
        {
            HLSColor color = new HLSColor(c1);
            HLSColor color2 = new HLSColor(c2);
            return (color.Luminosity < color2.Luminosity);
        }

        /// <summary>
        /// 获取无效时文本颜色
        /// </summary>
        /// <param name="backColor">控件背景色</param>
        /// <returns>无效颜色</returns>
        public static Color GetGrayColor(Color backColor)
        {
            Color controlDark = SystemColors.ControlDark;
            if (RenderEngine.IsDarker(backColor, SystemColors.Control))
            {
                controlDark = ControlPaint.Dark(backColor);
            }
            return controlDark;
        }

        /// <summary>
        /// HSV/HSB颜色 转 RGB颜色
        /// </summary>
        /// <param name="hue">色调[0-1]</param>
        /// <param name="saturation">饱和度[0-1]</param>
        /// <param name="brightness">亮度[0-1]</param>
        /// <returns>RGB颜色</returns>
        public static Color FromHsv(float hue, float saturation, float brightness)
        {
            if (saturation == 0)
            {
                byte v = (byte)(brightness * 255f + 0.5f);
                return Color.FromArgb(v, v, v);
            }
            else
            {
                float h = hue * 6f;
                int nh = (int)h;
                float sf = saturation * (h - nh);
                byte p = (byte)(brightness * (1f - saturation) * 255f + 0.5f);
                byte q = (byte)(brightness * (1f - sf) * 255f + 0.5f);
                byte t = (byte)(brightness * (1f - saturation + sf) * 255f + 0.5f);
                byte v = (byte)(brightness * 255.0f + 0.5f);
                switch (nh)
                {
                    case 0:
                        return Color.FromArgb(v, t, p);
                    case 1:
                        return Color.FromArgb(q, v, p);
                    case 2:
                        return Color.FromArgb(p, v, t);
                    case 3:
                        return Color.FromArgb(p, q, v);
                    case 4:
                        return Color.FromArgb(t, p, v);
                    case 5:
                        return Color.FromArgb(v, p, q);
                    default:
                        return Color.Empty;
                }
            }
        }

        /// <summary>
        /// 获取随机颜色
        /// </summary>
        /// <param name="saturation">饱和度[0-1]</param>
        /// <param name="brightness">亮度[0-1]</param>
        /// <returns>颜色</returns>
        public static Color RandomColor(float saturation, float brightness)
        {
            if (RANDOM_COLOR_HUE == null)
            {
                Random random = new Random();
                RANDOM_COLOR_HUE = (float)random.NextDouble();
            }
            float hue = RANDOM_COLOR_HUE.Value;
            hue += GOLDEN_RATIO;
            hue %= 1;
            RANDOM_COLOR_HUE = hue;
            return FromHsv(hue, saturation, brightness);
        }

        /// <summary>
        /// 获取随机颜色
        /// </summary>
        /// <returns>颜色</returns>
        public static Color RandomColor()
        {
            return RandomColor(0.5f, 0.99f);
        }


        /// <summary>
        /// 获取渐变颜色位置数组
        /// </summary>
        /// <param name="baseColor">基色</param>
        /// <param name="pos1">位置1</param>
        /// <param name="pos2">位置2</param>
        /// <param name="reverse">是否反转</param>
        /// <param name="avg">是否均分位置</param>
        /// <param name="colors">颜色数组</param>
        /// <param name="positions">位置数组</param>
        public static void GetColorPosGradient(Color baseColor, float pos1, float pos2, bool reverse, bool avg, out Color[] colors, out float[] positions)
        {
            ColorVector vector = ColorVector.FromArgb(8, 8, 8);
            Color outerColor = baseColor + vector;
            Color innerColor = baseColor - vector;
            if (reverse)
            {
                colors = new Color[] { outerColor, innerColor, innerColor, outerColor };
                if (avg)
                    positions = new float[] { 0.0f, 0.333333f, 0.666667f, 1.0f };//均分时.反转与不反转相同
                else
                    positions = new float[] { 0.0f, 1.0f - pos2, 1.0f - pos1, 1.0f };//非均分时.1-各个元素,再反转顺序
            }
            else
            {
                colors = new Color[] { outerColor, innerColor, innerColor, outerColor };
                if (avg)
                    positions = new float[] { 0.0f, 0.333333f, 0.666667f, 1.0f };
                else
                    positions = new float[] { 0.0f, pos1, pos2, 1.0f };
            }
        }

        /// <summary>
        /// 获取渐显颜色位置数组
        /// </summary>
        /// <param name="baseColor">基色</param>
        /// <param name="pos1">位置1</param>
        /// <param name="pos2">位置2</param>
        /// <param name="reverse">是否反转</param>
        /// <param name="avg">是否均分位置</param>
        /// <param name="colors">颜色数组</param>
        /// <param name="positions">位置数组</param>
        public static void GetColorPosFadeIn(Color baseColor, float pos1, float pos2, bool reverse, bool avg, out Color[] colors, out float[] positions)
        {
            if (reverse)
            {
                colors = new Color[] { baseColor, baseColor, Color.Transparent };
                if (avg)
                    positions = new float[] { 0.0f, 0.5f, 1.0f };
                else
                    positions = new float[] { 0.0f, 1.0f - pos1, 1.0f };
            }
            else
            {
                colors = new Color[] { Color.Transparent, baseColor, baseColor };
                if (avg)
                    positions = new float[] { 0.0f, 0.5f, 1.0f };
                else
                    positions = new float[] { 0.0f, pos1, 1.0f };
            }
        }

        /// <summary>
        /// 获取渐隐颜色位置数组
        /// </summary>
        /// <param name="baseColor">基色</param>
        /// <param name="pos1">位置1</param>
        /// <param name="pos2">位置2</param>
        /// <param name="reverse">是否反转</param>
        /// <param name="avg">是否均分位置</param>
        /// <param name="colors">颜色数组</param>
        /// <param name="positions">位置数组</param>
        public static void GetColorPosFadeOut(Color baseColor, float pos1, float pos2, bool reverse, bool avg, out Color[] colors, out float[] positions)
        {
            if (reverse)
            {
                colors = new Color[] { Color.Transparent, baseColor, baseColor };
                if (avg)
                    positions = new float[] { 0.0f, 0.5f, 1.0f };
                else
                    positions = new float[] { 0.0f, 1.0f - pos1, 1.0f };
            }
            else
            {
                colors = new Color[] { baseColor, baseColor, Color.Transparent };
                if (avg)
                    positions = new float[] { 0.0f, 0.5f, 1.0f };
                else
                    positions = new float[] { 0.0f, pos1, 1.0f };
            }
        }

        /// <summary>
        /// 获取渐隐渐显颜色位置数组
        /// </summary>
        /// <param name="baseColor">基色</param>
        /// <param name="pos1">位置1</param>
        /// <param name="pos2">位置2</param>
        /// <param name="reverse">是否反转</param>
        /// <param name="avg">是否均分位置</param>
        /// <param name="colors">颜色数组</param>
        /// <param name="positions">位置数组</param>
        public static void GetColorPosFadeInFadeOut(Color baseColor, float pos1, float pos2, bool reverse, bool avg, out Color[] colors, out float[] positions)
        {
            if (reverse)
            {
                colors = new Color[] { Color.Transparent, baseColor, baseColor, Color.Transparent };
                if (avg)
                    positions = new float[] { 0.0f, 0.333333f, 0.666667f, 1.0f };
                else
                    positions = new float[] { 0.0f, 1.0f - pos2, 1.0f - pos1, 1.0f };
            }
            else
            {
                colors = new Color[] { Color.Transparent, baseColor, baseColor, Color.Transparent };
                if (avg)
                    positions = new float[] { 0.0f, 0.333333f, 0.666667f, 1.0f };
                else
                    positions = new float[] { 0.0f, pos1, pos2, 1.0f };
            }
        }
    }
}
