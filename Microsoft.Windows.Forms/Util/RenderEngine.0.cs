using System;
using System.Drawing.Imaging;

namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// 渲染引擎
    /// </summary>
    public static partial class RenderEngine
    {
        /// <summary>
        /// 黄金分割比例
        /// </summary>
        private const float GOLDEN_RATIO = 0.618033988749895f;

        /// <summary>
        /// 随机颜色,Hue 起始值
        /// </summary>
        [ThreadStatic]
        private static float? RANDOM_COLOR_HUE;

        /// <summary>
        /// 灰色图像参数
        /// </summary>
        [ThreadStatic]
        private static ImageAttributes m_DisabledImageAttr;
    }
}
