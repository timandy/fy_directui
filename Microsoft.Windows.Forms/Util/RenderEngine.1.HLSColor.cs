using System;
using System.Drawing;

namespace Microsoft.Windows.Forms
{
    public static partial class RenderEngine
    {
        /// <summary>
        /// 色调,亮度,饱和度颜色
        /// </summary>
        private struct HLSColor
        {
            private const int ShadowAdj = -333;
            private const int HilightAdj = 500;
            private const int WatermarkAdj = -50;
            private const int Range = 240;
            private const int HLSMax = Range;
            private const int RGBMax = 255;
            private const int Undefined = HLSMax * 2 / 3;

            private int hue;
            private int saturation;
            private int luminosity;
            private bool isSystemColors_Control;

            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="color">RGBA颜色</param>
            public HLSColor(Color color)
            {
                isSystemColors_Control = (color.ToKnownColor() == SystemColors.Control.ToKnownColor());
                int r = color.R;
                int g = color.G;
                int b = color.B;
                int max, min;        /* max and min RGB values */
                int sum, dif;
                int Rdelta, Gdelta, Bdelta;  /* intermediate value: % of spread from max */

                /* calculate lightness */
                max = Math.Max(Math.Max(r, g), b);
                min = Math.Min(Math.Min(r, g), b);
                sum = max + min;

                luminosity = (((sum * HLSMax) + RGBMax) / (2 * RGBMax));

                dif = max - min;
                if (dif == 0)
                {       /* r=g=b --> achromatic case */
                    saturation = 0;                         /* saturation */
                    hue = Undefined;                 /* hue */
                }
                else
                {                           /* chromatic case */
                    /* saturation */
                    if (luminosity <= (HLSMax / 2))
                        saturation = (int)(((dif * (int)HLSMax) + (sum / 2)) / sum);
                    else
                        saturation = (int)((int)((dif * (int)HLSMax) + (int)((2 * RGBMax - sum) / 2))
                                            / (2 * RGBMax - sum));
                    /* hue */
                    Rdelta = (int)((((max - r) * (int)(HLSMax / 6)) + (dif / 2)) / dif);
                    Gdelta = (int)((((max - g) * (int)(HLSMax / 6)) + (dif / 2)) / dif);
                    Bdelta = (int)((((max - b) * (int)(HLSMax / 6)) + (dif / 2)) / dif);

                    if ((int)r == max)
                        hue = Bdelta - Gdelta;
                    else if ((int)g == max)
                        hue = (HLSMax / 3) + Rdelta - Bdelta;
                    else /* B == cMax */
                        hue = ((2 * HLSMax) / 3) + Gdelta - Rdelta;

                    if (hue < 0)
                        hue += HLSMax;
                    if (hue > HLSMax)
                        hue -= HLSMax;
                }
            }

            /// <summary>
            /// 色调
            /// </summary>
            public int Hue
            {
                get
                {
                    return hue;
                }
            }

            /// <summary>
            /// 亮度
            /// </summary>
            public int Luminosity
            {
                get
                {
                    return luminosity;
                }
            }

            /// <summary>
            /// 饱和度
            /// </summary>
            public int Saturation
            {
                get
                {
                    return saturation;
                }
            }

            /// <summary>
            /// 获取减小指定亮度后的颜色
            /// </summary>
            /// <param name="percDarker">要减小的亮度</param>
            /// <returns>新的颜色</returns>
            public Color Darker(float percDarker)
            {
                if (isSystemColors_Control)
                {
                    // With the usual color scheme, ControlDark/DarkDark is not exactly
                    // what we would otherwise calculate
                    if (percDarker == 0.0f)
                    {
                        return SystemColors.ControlDark;
                    }
                    else if (percDarker == 1.0f)
                    {
                        return SystemColors.ControlDarkDark;
                    }
                    else
                    {
                        Color dark = SystemColors.ControlDark;
                        Color darkDark = SystemColors.ControlDarkDark;

                        int dr = dark.R - darkDark.R;
                        int dg = dark.G - darkDark.G;
                        int db = dark.B - darkDark.B;

                        return Color.FromArgb((byte)(dark.R - (byte)(dr * percDarker)),
                                              (byte)(dark.G - (byte)(dg * percDarker)),
                                              (byte)(dark.B - (byte)(db * percDarker)));
                    }
                }
                else
                {
                    int oneLum = 0;
                    int zeroLum = NewLuma(ShadowAdj, true);
                    return ColorFromHLS(hue, zeroLum - (int)((zeroLum - oneLum) * percDarker), saturation);
                }
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

                HLSColor c = (HLSColor)o;
                return hue == c.hue &&
                       saturation == c.saturation &&
                       luminosity == c.luminosity &&
                       isSystemColors_Control == c.isSystemColors_Control;
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
                return hue << 6 | saturation << 2 | luminosity;
            }

            /// <summary>
            /// 获取增加指定亮度后的颜色
            /// </summary>
            /// <param name="percLighter">要增加的亮度</param>
            /// <returns>新的颜色</returns>
            public Color Lighter(float percLighter)
            {
                if (isSystemColors_Control)
                {
                    // With the usual color scheme, ControlLight/LightLight is not exactly
                    // what we would otherwise calculate
                    if (percLighter == 0.0f)
                    {
                        return SystemColors.ControlLight;
                    }
                    else if (percLighter == 1.0f)
                    {
                        return SystemColors.ControlLightLight;
                    }
                    else
                    {
                        Color light = SystemColors.ControlLight;
                        Color lightLight = SystemColors.ControlLightLight;

                        int dr = light.R - lightLight.R;
                        int dg = light.G - lightLight.G;
                        int db = light.B - lightLight.B;

                        return Color.FromArgb((byte)(light.R - (byte)(dr * percLighter)),
                                              (byte)(light.G - (byte)(dg * percLighter)),
                                              (byte)(light.B - (byte)(db * percLighter)));
                    }
                }
                else
                {
                    int zeroLum = luminosity;
                    int oneLum = NewLuma(HilightAdj, true);
                    return ColorFromHLS(hue, zeroLum + (int)((oneLum - zeroLum) * percLighter), saturation);
                }
            }

            private int NewLuma(int n, bool scale)
            {
                return NewLuma(luminosity, n, scale);
            }

            private int NewLuma(int luminosity, int n, bool scale)
            {
                if (n == 0)
                    return luminosity;

                if (scale)
                {
                    if (n > 0)
                    {
                        return (int)(((int)luminosity * (1000 - n) + (Range + 1L) * n) / 1000);
                    }
                    else
                    {
                        return (int)(((int)luminosity * (n + 1000)) / 1000);
                    }
                }

                int newLum = luminosity;
                newLum += (int)((long)n * Range / 1000);

                if (newLum < 0)
                    newLum = 0;
                if (newLum > HLSMax)
                    newLum = HLSMax;

                return newLum;
            }

            private Color ColorFromHLS(int hue, int luminosity, int saturation)
            {
                byte r, g, b;                      /* RGB component values */
                int magic1, magic2;       /* calculated magic numbers (really!) */

                if (saturation == 0)
                {                /* achromatic case */
                    r = g = b = (byte)((luminosity * RGBMax) / HLSMax);
                    if (hue != Undefined)
                    {
                        /* ERROR */
                    }
                }
                else
                {                         /* chromatic case */
                    /* set up magic numbers */
                    if (luminosity <= (HLSMax / 2))
                        magic2 = (int)((luminosity * ((int)HLSMax + saturation) + (HLSMax / 2)) / HLSMax);
                    else
                        magic2 = luminosity + saturation - (int)(((luminosity * saturation) + (int)(HLSMax / 2)) / HLSMax);
                    magic1 = 2 * luminosity - magic2;

                    /* get RGB, change units from HLSMax to RGBMax */
                    r = (byte)(((HueToRGB(magic1, magic2, (int)(hue + (int)(HLSMax / 3))) * (int)RGBMax + (HLSMax / 2))) / (int)HLSMax);
                    g = (byte)(((HueToRGB(magic1, magic2, hue) * (int)RGBMax + (HLSMax / 2))) / HLSMax);
                    b = (byte)(((HueToRGB(magic1, magic2, (int)(hue - (int)(HLSMax / 3))) * (int)RGBMax + (HLSMax / 2))) / (int)HLSMax);
                }
                return Color.FromArgb(r, g, b);
            }

            private int HueToRGB(int n1, int n2, int hue)
            {
                /* range check: note values passed add/subtract thirds of range */

                /* The following is redundant for WORD (unsigned int) */
                if (hue < 0)
                    hue += HLSMax;

                if (hue > HLSMax)
                    hue -= HLSMax;

                /* return r,g, or b value from this tridrant */
                if (hue < (HLSMax / 6))
                    return (n1 + (((n2 - n1) * hue + (HLSMax / 12)) / (HLSMax / 6)));
                if (hue < (HLSMax / 2))
                    return (n2);
                if (hue < ((HLSMax * 2) / 3))
                    return (n1 + (((n2 - n1) * (((HLSMax * 2) / 3) - hue) + (HLSMax / 12)) / (HLSMax / 6)));
                else
                    return (n1);

            }
        }
    }
}
