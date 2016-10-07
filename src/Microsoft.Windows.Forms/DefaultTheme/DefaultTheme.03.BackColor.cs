using System.Drawing;
using Microsoft.Drawing;

namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// 默认值方案
    /// </summary>
    public static partial class DefaultTheme
    {
        /// <summary>
        /// 深深背景色
        /// </summary>
        public static Color DarkDarkBackColor = Color.FromArgb(30, 30, 30);
        /// <summary>
        /// 深深背景色
        /// </summary>
        public const string _DarkDarkBackColor = "30, 30, 30";

        /// <summary>
        /// 深背景色
        /// </summary>
        public static Color DarkBackColor = Color.FromArgb(37, 37, 37);
        /// <summary>
        /// 深背景色
        /// </summary>
        public const string _DarkBackColor = "37, 37, 37";

        /// <summary>
        /// 背景色
        /// </summary>
        public static Color BackColor = Color.FromArgb(45, 45, 45);
        /// <summary>
        /// 背景色
        /// </summary>
        public const string _BackColor = "45, 45, 45";

        /// <summary>
        /// 浅背景色
        /// </summary>
        public static Color LightBackColor = Color.FromArgb(51, 51, 51);
        /// <summary>
        /// 浅背景色
        /// </summary>
        public const string _LightBackColor = "51, 51, 51";

        /// <summary>
        /// 浅浅背景色
        /// </summary>
        public static Color LightLightBackColor = Color.FromArgb(62, 62, 62);
        /// <summary>
        /// 浅浅背景色
        /// </summary>
        public const string _LightLightBackColor = "62, 62, 62";


        /// <summary>
        /// 背景鼠标移上颜色向量
        /// </summary>
        public static ColorVector BackColorHoveredVector = ColorVector.FromArgb(10, 10, 10);
        /// <summary>
        /// 背景鼠标移上颜色向量
        /// </summary>
        public const string _BackColorHoveredVector = "10, 10, 10";

        /// <summary>
        /// 背景鼠标按下颜色向量
        /// </summary>
        public static ColorVector BackColorPressedVector = ColorVector.FromArgb(20, 20, 20);
        /// <summary>
        /// 背景鼠标按下颜色向量
        /// </summary>
        public const string _BackColorPressedVector = "20, 20, 20";

        /// <summary>
        /// 背景拥有焦点颜色向量
        /// </summary>
        public static ColorVector BackColorFocusedVector = ColorVector.FromArgb(0, 0, 0);
        /// <summary>
        /// 背景拥有焦点颜色向量
        /// </summary>
        public const string _BackColorFocusedVector = "0, 0, 0";

        /// <summary>
        /// 背景状态禁用颜色向量
        /// </summary>
        public static ColorVector BackColorDisabledVector = ColorVector.FromArgb(-255, 255, 255, 255);
        /// <summary>
        /// 背景状态禁用颜色向量
        /// </summary>
        public const string _BackColorDisabledVector = "-255, 255, 255, 255";

        /// <summary>
        /// 背景高亮颜色向量
        /// </summary>
        public static ColorVector BackColorHighlightVector = ColorVector.FromArgb(-255, 60, -142);
        /// <summary>
        /// 背景高亮颜色向量
        /// </summary>
        public const string _BackColorHighlightVector = "-255, 60, -142";
    }
}
