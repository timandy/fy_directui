using System.Drawing;

namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// 默认值方案
    /// </summary>
    public static partial class DefaultTheme
    {
        /// <summary>
        /// 模糊特效颜色
        /// </summary>
        public static Color BlurColor = Color.FromArgb(80, 255, 255, 255);
        /// <summary>
        /// 模糊特效颜色
        /// </summary>
        public const string _BlurColor = "80, 255, 255, 255";

        /// <summary>
        /// 玻璃特效中心颜色
        /// </summary>
        public static Color GlassCenterColor = Color.FromArgb(200, 255, 255, 255);
        /// <summary>
        /// 玻璃特效中心颜色
        /// </summary>
        public const string _GlassCenterColor = "200, 255, 255, 255";

        /// <summary>
        /// 玻璃特效环绕颜色
        /// </summary>
        public static Color GlassSurroundColor = Color.Transparent;
        /// <summary>
        /// 玻璃特效环绕颜色
        /// </summary>
        public const string _GlassSurroundColor = "Transparent";
    }
}
