using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Microsoft.Windows.Forms
{
    public static partial class RenderEngine
    {
        /// <summary>
        /// 色度,亮度,饱和度颜色
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct HLSColor
        {
            private const int ShadowAdj = -333;
            private const int HilightAdj = 500;
            private const int WatermarkAdj = -50;
            private const int Range = 240;
            private const int HLSMax = 240;
            private const int RGBMax = 0xff;
            private const int Undefined = 160;
            private int hue;
            private int saturation;
            private int luminosity;
            private bool isSystemColors_Control;

            /// <summary>
            /// 亮度
            /// </summary>
            public int Luminosity
            {
                get
                {
                    return this.luminosity;
                }
            }

            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="color">RGBA颜色</param>
            public HLSColor(Color color)
            {
                this.isSystemColors_Control = color.ToKnownColor() == SystemColors.Control.ToKnownColor();
                int r = color.R;
                int g = color.G;
                int b = color.B;
                int num4 = Math.Max(Math.Max(r, g), b);
                int num5 = Math.Min(Math.Min(r, g), b);
                int num6 = num4 + num5;
                this.luminosity = ((num6 * 240) + 0xff) / 510;
                int num7 = num4 - num5;
                if (num7 == 0)
                {
                    this.saturation = 0;
                    this.hue = 160;
                }
                else
                {
                    if (this.luminosity <= 120)
                    {
                        this.saturation = ((num7 * 240) + (num6 / 2)) / num6;
                    }
                    else
                    {
                        this.saturation = ((num7 * 240) + ((510 - num6) / 2)) / (510 - num6);
                    }
                    int num8 = (((num4 - r) * 40) + (num7 / 2)) / num7;
                    int num9 = (((num4 - g) * 40) + (num7 / 2)) / num7;
                    int num10 = (((num4 - b) * 40) + (num7 / 2)) / num7;
                    if (r == num4)
                    {
                        this.hue = num10 - num9;
                    }
                    else if (g == num4)
                    {
                        this.hue = (80 + num8) - num10;
                    }
                    else
                    {
                        this.hue = (160 + num9) - num8;
                    }
                    if (this.hue < 0)
                    {
                        this.hue += 240;
                    }
                    if (this.hue > 240)
                    {
                        this.hue -= 240;
                    }
                }
            }

            /// <summary>
            /// 获取减小指定亮度后的颜色
            /// </summary>
            /// <param name="percDarker">要减小的亮度</param>
            /// <returns>新的颜色</returns>
            public Color Darker(float percDarker)
            {
                if (this.isSystemColors_Control)
                {
                    if (percDarker == 0f)
                    {
                        return SystemColors.ControlDark;
                    }
                    if (percDarker == 1f)
                    {
                        return SystemColors.ControlDarkDark;
                    }
                    Color controlDark = SystemColors.ControlDark;
                    Color controlDarkDark = SystemColors.ControlDarkDark;
                    int num = controlDark.R - controlDarkDark.R;
                    int num2 = controlDark.G - controlDarkDark.G;
                    int num3 = controlDark.B - controlDarkDark.B;
                    return Color.FromArgb((byte)(controlDark.R - ((byte)(num * percDarker))), (byte)(controlDark.G - ((byte)(num2 * percDarker))), (byte)(controlDark.B - ((byte)(num3 * percDarker))));
                }
                int num4 = 0;
                int num5 = this.NewLuma(-333, true);
                return this.ColorFromHLS(this.hue, num5 - ((int)((num5 - num4) * percDarker)), this.saturation);
            }

            /// <summary>
            /// 是否相等
            /// </summary>
            /// <param name="o">要比较的对象</param>
            /// <returns>相等返回true,否则返回false</returns>
            public override bool Equals(object o)
            {
                if (!(o is HLSColor))
                {
                    return false;
                }
                HLSColor color = (HLSColor)o;
                return ((((this.hue == color.hue) && (this.saturation == color.saturation)) && (this.luminosity == color.luminosity)) && (this.isSystemColors_Control == color.isSystemColors_Control));
            }

            /// <summary>
            /// 是否相等
            /// </summary>
            /// <param name="a">颜色a</param>
            /// <param name="b">颜色b</param>
            /// <returns>相等返回true,否则返回false</returns>
            public static bool operator ==(HLSColor a, HLSColor b)
            {
                return a.Equals(b);
            }

            /// <summary>
            /// 是否不等
            /// </summary>
            /// <param name="a">颜色a</param>
            /// <param name="b">颜色b</param>
            /// <returns>不等返回true,否则返回false</returns>
            public static bool operator !=(HLSColor a, HLSColor b)
            {
                return !a.Equals(b);
            }

            /// <summary>
            /// 获取哈希码
            /// </summary>
            /// <returns>哈希码</returns>
            public override int GetHashCode()
            {
                return (((this.hue << 6) | (this.saturation << 2)) | this.luminosity);
            }

            /// <summary>
            /// 获取增加指定亮度后的颜色
            /// </summary>
            /// <param name="percLighter">要增加的亮度</param>
            /// <returns>新的颜色</returns>
            public Color Lighter(float percLighter)
            {
                if (this.isSystemColors_Control)
                {
                    if (percLighter == 0f)
                    {
                        return SystemColors.ControlLight;
                    }
                    if (percLighter == 1f)
                    {
                        return SystemColors.ControlLightLight;
                    }
                    Color controlLight = SystemColors.ControlLight;
                    Color controlLightLight = SystemColors.ControlLightLight;
                    int num = controlLight.R - controlLightLight.R;
                    int num2 = controlLight.G - controlLightLight.G;
                    int num3 = controlLight.B - controlLightLight.B;
                    return Color.FromArgb((byte)(controlLight.R - ((byte)(num * percLighter))), (byte)(controlLight.G - ((byte)(num2 * percLighter))), (byte)(controlLight.B - ((byte)(num3 * percLighter))));
                }
                int luminosity = this.luminosity;
                int num5 = this.NewLuma(500, true);
                return this.ColorFromHLS(this.hue, luminosity + ((int)((num5 - luminosity) * percLighter)), this.saturation);
            }

            private int NewLuma(int n, bool scale)
            {
                return this.NewLuma(this.luminosity, n, scale);
            }

            private int NewLuma(int luminosity, int n, bool scale)
            {
                if (n == 0)
                {
                    return luminosity;
                }
                if (scale)
                {
                    if (n > 0)
                    {
                        return (int)(((luminosity * (0x3e8 - n)) + (0xf1L * n)) / 0x3e8L);
                    }
                    return ((luminosity * (n + 0x3e8)) / 0x3e8);
                }
                int num = luminosity;
                num += (int)((n * 240L) / 0x3e8L);
                if (num < 0)
                {
                    num = 0;
                }
                if (num > 240)
                {
                    num = 240;
                }
                return num;
            }

            private Color ColorFromHLS(int hue, int luminosity, int saturation)
            {
                byte num;
                byte num2;
                byte num3;
                if (saturation == 0)
                {
                    num = num2 = num3 = (byte)((luminosity * 0xff) / 240);
                    if (hue == 160)
                    {
                    }
                }
                else
                {
                    int num5;
                    if (luminosity <= 120)
                    {
                        num5 = ((luminosity * (240 + saturation)) + 120) / 240;
                    }
                    else
                    {
                        num5 = (luminosity + saturation) - (((luminosity * saturation) + 120) / 240);
                    }
                    int num4 = (2 * luminosity) - num5;
                    num = (byte)(((this.HueToRGB(num4, num5, hue + 80) * 0xff) + 120) / 240);
                    num2 = (byte)(((this.HueToRGB(num4, num5, hue) * 0xff) + 120) / 240);
                    num3 = (byte)(((this.HueToRGB(num4, num5, hue - 80) * 0xff) + 120) / 240);
                }
                return Color.FromArgb(num, num2, num3);
            }

            private int HueToRGB(int n1, int n2, int hue)
            {
                if (hue < 0)
                {
                    hue += 240;
                }
                if (hue > 240)
                {
                    hue -= 240;
                }
                if (hue < 40)
                {
                    return (n1 + ((((n2 - n1) * hue) + 20) / 40));
                }
                if (hue < 120)
                {
                    return n2;
                }
                if (hue < 160)
                {
                    return (n1 + ((((n2 - n1) * (160 - hue)) + 20) / 40));
                }
                return n1;
            }
        }
    }
}
