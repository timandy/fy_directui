namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// 控件的状态。(Disabled)(Focused与Noraml,Hovered,Pressed组合)
    /// </summary>
    public enum State : int
    {
        /// <summary>
        /// 正常
        /// </summary>
        Normal = 0,
        /// <summary>
        /// 正常焦点
        /// </summary>
        NormalFocused = 1,
        /// <summary>
        /// 鼠标移上
        /// </summary>
        Hovered = 2,
        /// <summary>
        /// 鼠标移上焦点
        /// </summary>
        HoveredFocused = 3,
        /// <summary>
        /// 鼠标按下
        /// </summary>
        Pressed = 4,
        /// <summary>
        /// 鼠标按下焦点
        /// </summary>
        PressedFocused = 5,
        /// <summary>
        /// 禁用
        /// </summary>
        Disabled = 6,
        /// <summary>
        /// 隐藏
        /// </summary>
        Hidden = 7,
        /// <summary>
        /// 高亮突出
        /// </summary>
        Highlight = 8,
    }
}
