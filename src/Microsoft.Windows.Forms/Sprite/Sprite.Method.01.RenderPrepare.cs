using System.Drawing;
using System.Drawing.Drawing2D;

namespace Microsoft.Windows.Forms
{
    partial class Sprite
    {
        private Graphics m_Graphics;
        private Region m_GraphicsClip;

        /// <summary>
        /// 开始渲染
        /// </summary>
        public void BeginRender(Graphics g)
        {
            this.DisposeReferences();
            this.m_Graphics = g;
            this.m_GraphicsClip = g.Clip;
            //由于此时未对 BackColorRect 赋值.所以不能设置剪切区,在生成 m_CurrentBackColorPathRect 时设置剪切区
        }

        /// <summary>
        /// 结束渲染
        /// </summary>
        public void EndRender()
        {
            this.m_Graphics.SetClip(this.m_GraphicsClip, CombineMode.Replace);
            this.m_GraphicsClip.Dispose();
            this.m_GraphicsClip = null;
        }
    }
}
