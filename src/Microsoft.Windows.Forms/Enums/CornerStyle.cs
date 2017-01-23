using System;

namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// 边角弯曲样式。
    /// </summary>
    [Flags]
    public enum CornerStyle : int
    {
        /// <summary>
        /// 默认样式
        /// </summary>
        None = 0x0000,
        /// <summary>
        /// 左上角,左下角往内部弯曲
        /// </summary>
        LeftIn = 0x0001,
        /// <summary>
        /// 左上角,右上角往内部弯曲
        /// </summary>
        TopIn = 0x0002,
        /// <summary>
        /// 右上角,右下角往内部弯曲
        /// </summary>
        RightIn = 0x0004,
        /// <summary>
        /// 左下角,右下角往内部弯曲
        /// </summary>
        BottomIn = 0x0008,

        /// <summary>
        /// 左上角,左下角往外部弯曲
        /// </summary>
        LeftOut = 0x0010,
        /// <summary>
        /// 左上角,右上角往外部弯曲
        /// </summary>
        TopOut = 0x0020,
        /// <summary>
        /// 右上角,右下角往外部弯曲
        /// </summary>
        RightOut = 0x0040,
        /// <summary>
        /// 左下角,右下角往外部弯曲
        /// </summary>
        BottomOut = 0x0080,

        /// <summary>
        /// 水平(LeftIn|RightIn|LeftOut|RightOut)
        /// </summary>
        Horizontal = 0x0055,
        /// <summary>
        /// 垂直(TopIn|BottomIn|TopOut|BottomOut)
        /// </summary>
        Vertical = 0x00AA,
    }
}
