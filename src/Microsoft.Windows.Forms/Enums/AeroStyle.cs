using System;

namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// 背景色绘制完后再绘制的内容的类型
    /// </summary>
    [Flags]
    public enum AeroStyle : int
    {
        /// <summary>
        /// 不绘制
        /// </summary>
        None = 0x0000,
        /// <summary>
        /// 绘制半透明模糊,一般位于控件顶部或左侧
        /// </summary>
        Blur = 0x0001,
        /// <summary>
        /// 绘制圆玻璃效果,一般位于底部或右侧
        /// </summary>
        Glass = 0x0002,
        /// <summary>
        /// 两个个效果都绘制
        /// </summary>
        All = 0x0003,
    }
}
