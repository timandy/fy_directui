using System.Drawing;

namespace Microsoft.Windows.Forms
{
    static partial class DefaultTheme
    {
        /// <summary>
        /// 透明色
        /// </summary>
        public static Color Transparent = Color.Transparent;
        /// <summary>
        /// 透明色
        /// </summary>
        public const string _Transparent = "Transparent";

        /// <summary>
        /// 半透明色,透明度高高
        /// </summary>
        public static Color DarkDarkTransparent = Color.FromArgb(20, 255, 255, 255);
        /// <summary>
        /// 半透明色,透明度高高
        /// </summary>
        public const string _DarkDarkTransparent = "20, 255, 255, 255";

        /// <summary>
        /// 半透明色,透明度高
        /// </summary>
        public static Color DarkTransparent = Color.FromArgb(40, 255, 255, 255);
        /// <summary>
        /// 半透明色,透明度高
        /// </summary>
        public const string _DarkTransparent = "40, 255, 255, 255";

        /// <summary>
        /// 半透明颜色,透明度低
        /// </summary>
        public static Color LightTransparent = Color.FromArgb(60, 255, 255, 255);
        /// <summary>
        /// 半透明颜色,透明度低
        /// </summary>
        public const string _LightTransparent = "60, 255, 255, 255";

        /// <summary>
        /// 半透明颜色,透明度低低
        /// </summary>
        public static Color LightLightTransparent = Color.FromArgb(80, 255, 255, 255);
        /// <summary>
        /// 半透明颜色,透明度低低
        /// </summary>
        public const string _LightLightTransparent = "80, 255, 255, 255";
    }
}
