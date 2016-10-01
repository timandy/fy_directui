using System.Drawing;
using System.Drawing.Drawing2D;

namespace Microsoft.Drawing
{
    /// <summary>
    /// 暂时修改绘图对象的像素偏移模式,释放时改为原来模式
    /// </summary>
    public class PixelOffsetModeGraphics : DisposableMini
    {
        private PixelOffsetMode m_OldMode;  //原始的像素偏移模式
        private Graphics m_Graphics;        //要修改像素偏移模式的绘图对象

        /// <summary>
        /// 构造函数,暂时修改为默认像素偏移
        /// </summary>
        /// <param name="graphics">绘图对象</param>
        public PixelOffsetModeGraphics(Graphics graphics)
            : this(graphics, PixelOffsetMode.Default)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="graphics">绘图对象</param>
        /// <param name="newMode">新像素偏移模式</param>
        public PixelOffsetModeGraphics(Graphics graphics, PixelOffsetMode newMode)
        {
            this.m_Graphics = graphics;
            this.m_OldMode = graphics.PixelOffsetMode;
            graphics.PixelOffsetMode = newMode;
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="disposing">释放托管资源为true,否则为false</param>
        protected override void Dispose(bool disposing)
        {
            if (this.m_Graphics != null)
            {
                this.m_Graphics.PixelOffsetMode = this.m_OldMode;
                this.m_Graphics = null;
            }
            this.m_OldMode = PixelOffsetMode.Default;
        }
    }
}
