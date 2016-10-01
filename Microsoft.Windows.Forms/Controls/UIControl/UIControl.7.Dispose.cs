
namespace Microsoft.Windows.Forms
{
    partial class UIControl
    {
        /// <summary>
        /// 释放资源 
        /// </summary>
        /// <param name="disposing">释放托管资源为 true,否则为 false</param>
        protected override void Dispose(bool disposing)
        {
            IUIControl parent = this.UIParent;
            this.UIParent = null;
            if (parent != null)
                parent.DoLayout();

            if (this.m_UIControls != null)
            {
                this.m_UIControls.Dispose();
                this.m_UIControls = null;
            }

            if (this.m_Region != null)
            {
                this.m_Region.Dispose();
                this.m_Region = null;
            }

            if (this.m_Sprite != null)
            {
                this.m_Sprite.Dispose();
                this.m_Sprite = null;
            }
        }
    }
}
