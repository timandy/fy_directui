using System;

namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// 边框样式
    /// </summary>
    [Flags]
    public enum BorderVisibleStyle : int
    {
        /// <summary>
        /// 无
        /// </summary>
        None = 0x0000,
        /// <summary>
        /// 左边框
        /// </summary>
        Left = 0x0001,
        /// <summary>
        /// 上边框
        /// </summary>
        Top = 0x0002,
        /// <summary>
        /// 右边框
        /// </summary>
        Right = 0x0004,
        /// <summary>
        /// 下边框
        /// </summary>
        Bottom = 0x0008,
        /// <summary>
        /// 所有边框
        /// </summary>
        All = 0x000F,
    }
}
