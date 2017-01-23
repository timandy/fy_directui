namespace Microsoft.Windows.Forms
{
    partial class Sprite
    {
        /// <summary>
        /// 释放托管资源
        /// </summary>
        protected virtual void DisposeResources()
        {
            //=================取消引用
            this.m_Owner = null;

            //=================取消引用
            this.m_BackgroundImage = null;
            this.m_BackgroundImageHovered = null;
            this.m_BackgroundImagePressed = null;
            this.m_BackgroundImageFocused = null;
            this.m_BackgroundImageDisabled = null;
            this.m_BackgroundImageHighlight = null;

            this.m_BackgroundImage9 = null;
            this.m_BackgroundImage9Hovered = null;
            this.m_BackgroundImage9Pressed = null;
            this.m_BackgroundImage9Focused = null;
            this.m_BackgroundImage9Disabled = null;
            this.m_BackgroundImage9Highlight = null;

            this.m_Font = null;

            this.m_Image = null;
            this.m_ImageHovered = null;
            this.m_ImagePressed = null;
            this.m_ImageFocused = null;
            this.m_ImageDisabled = null;
            this.m_ImageHighlight = null;
        }

        /// <summary>
        /// 释放中间引用值
        /// </summary>
        protected virtual void DisposeReferences()
        {
            //=================剪切区相关
            this.m_Graphics = null;//取消引用
            if (this.m_GraphicsClip != null)//在BeginRender
            {
                this.m_GraphicsClip.Dispose();
                this.m_GraphicsClip = null;
            }

            //=================绘制参数
            if (this.m_CurrentBackColorPath != null)
            {
                this.m_CurrentBackColorPath.Dispose();
                this.m_CurrentBackColorPath = null;
            }

            this.m_CurrentBackColor = null;
            this.m_CurrentBackColorReverse = null;
            this.m_CurrentBackColorMode = null;
            this.m_CurrentBackColorPathRect = null;
            this.m_CurrentBackColorBrushRect = null;

            this.m_CurrentBackgroundImage = null;
            this.m_CurrentBackgroundImageRect = null;

            this.m_CurrentBackgroundImage9 = null;
            this.m_CurrentBackgroundImage9Rect = null;

            this.m_CurrentBorderColor = null;
            this.m_CurrentBorderPathRect = null;
            this.m_CurrentBorderBrushRect = null;
            this.m_CurrentInnerBorderColor = null;
            this.m_CurrentInnerBorderPathRect = null;
            this.m_CurrentInnerBorderBrushRect = null;

            this.m_CurrentStringClientRect = null;
            this.m_CurrentStringRect = null;
            this.m_CurrentStringPathRect = null;
            this.m_CurrentStringSize = null;

            this.m_CurrentTextImageClientRect = null;
            this.m_CurrentTextImagePreferredRect = null;
            this.m_CurrentTextPreferredRect = null;
            this.m_CurrentForeColor = null;
            this.m_CurrentImagePreferredRect = null;
            this.m_CurrentImage = null;

            this.m_CurrentLineColor = null;
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="disposing">释放托管资源为true,否则为false</param>
        protected override void Dispose(bool disposing)
        {
            this.DisposeReferences();
            this.DisposeResources();
        }
    }
}
