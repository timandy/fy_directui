using System;

namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// 建立圆角路径的样式。
    /// </summary>
    [Flags]
    public enum RoundStyle : int
    {
        /// <summary>
        /// 四个角都不是圆角。
        /// </summary>
        None = 0x0000,
        /// <summary>
        /// 左上角为圆角。
        /// </summary>
        TopLeft = 0x0001,
        /// <summary>
        /// 右上角为圆角。
        /// </summary>
        TopRight = 0x0002,
        /// <summary>
        /// 右下角为圆角
        /// </summary>
        BottomRight = 0x0004,
        /// <summary>
        /// 左下角为圆角。
        /// </summary>
        BottomLeft = 0x0008,
        /// <summary>
        /// 左边两个角为圆角。
        /// </summary>
        Left = 0x0009,
        /// <summary>
        /// 上边两个角为圆角。
        /// </summary>
        Top = 0x0003,
        /// <summary>
        /// 右边两个角为圆角。
        /// </summary>
        Right = 0x0006,
        /// <summary>
        /// 下边两个角为圆角。
        /// </summary>
        Bottom = 0x000C,
        /// <summary>
        /// 四个角都为圆角。
        /// </summary>
        All = 0x000F,
    }
}
