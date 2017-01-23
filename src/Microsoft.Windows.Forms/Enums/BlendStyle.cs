namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// 混合样式
    /// </summary>
    public enum BlendStyle : int
    {
        /// <summary>
        /// 单色
        /// </summary>
        Solid = 0,
        /// <summary>
        /// 渐变
        /// </summary>
        Gradient = 1,
        /// <summary>
        /// Alpha通道从0渐变指定值-渐显
        /// </summary>
        FadeIn = 2,
        /// <summary>
        /// Alpha通道从指定值渐变0-渐隐
        /// </summary>
        FadeOut = 3,
        /// <summary>
        /// Alpha通道从0渐变指定值再渐变到0-渐显渐隐
        /// </summary>
        FadeInFadeOut = 4,
    }
}
