using System;

namespace Microsoft.Windows.Forms
{
    partial class UIForm
    {
        /// <summary>
        /// 检查是否已释放资源
        /// </summary>
        public void CheckDisposed()
        {
            if (this.IsDisposed)
                throw new ObjectDisposedException(this.GetType().FullName);
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="disposing">释放托管资源为 true,否则为 false</param>
        protected override void Dispose(bool disposing)
        {
            if (this.m_UIControls != null)
            {
                this.m_UIControls.Dispose();
                this.m_UIControls = null;
            }

            if (this.m_Sprite != null)
            {
                this.m_Sprite.Dispose();
                this.m_Sprite = null;
            }

            if (this.m_DoubleBufferedGraphics != null)
            {
                this.m_DoubleBufferedGraphics.Dispose();
                this.m_DoubleBufferedGraphics = null;
            }

            base.Dispose(disposing);
        }
    }
}
