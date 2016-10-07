using System;

namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// 九宫格图片布局方式
    /// </summary>
    [Flags]
    public enum ImageLayout9 : int
    {
        /// <summary>
        /// 全部拉伸
        /// </summary>
        None = 0x0000,
        /// <summary>
        /// 左侧平铺
        /// </summary>
        LeftTile = 0x0001,
        /// <summary>
        /// 顶部平铺
        /// </summary>
        TopTile = 0x0002,
        /// <summary>
        /// 右侧平铺
        /// </summary>
        RightTile = 0x0004,
        /// <summary>
        /// 底部平铺
        /// </summary>
        BottomTile = 0x0008,
        /// <summary>
        /// 中心平铺
        /// </summary>
        MiddleTile = 0x0010,
        /// <summary>
        /// 全部平铺
        /// </summary>
        AllTile = 0x001F,
    }
}
