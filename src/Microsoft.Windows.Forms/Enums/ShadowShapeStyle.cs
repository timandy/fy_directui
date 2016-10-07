using System;

namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// 文本阴影描边样式
    /// </summary>
    [Flags]
    public enum ShadowShapeStyle : int
    {
        /// <summary>
        /// 无
        /// </summary>
        None = 0x0000,
        /// <summary>
        /// 阴影
        /// </summary>
        Shadow = 0x0001,
        /// <summary>
        /// 阴影描边
        /// </summary>
        ShapeOfShadow = 0x0002,
        /// <summary>
        /// 文本描边
        /// </summary>
        ShapeOfText = 0x0004,
        /// <summary>
        /// 全部
        /// </summary>
        All = 0x0007,
    }
}
