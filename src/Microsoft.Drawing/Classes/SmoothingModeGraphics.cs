using System.Drawing;
using System.Drawing.Drawing2D;

namespace Microsoft.Drawing
{
    /// <summary>
    /// 暂时修改绘图对象的平滑模式,释放时改为原来模式
    /// </summary>
    public sealed class SmoothingModeGraphics : DisposableMini
    {
        private SmoothingMode m_OldMode;    //原始的平滑模式
        private Graphics m_Graphics;        //要修改平滑模式的绘图对象

        /// <summary>
        /// 构造函数,暂时修改为抗锯齿
        /// </summary>
        /// <param name="graphics">绘图对象</param>
        public SmoothingModeGraphics(Graphics graphics)
            : this(graphics, SmoothingMode.AntiAlias)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="graphics">绘图对象</param>
        /// <param name="newMode">新平滑模式</param>
        public SmoothingModeGraphics(Graphics graphics, SmoothingMode newMode)
        {
            this.m_Graphics = graphics;
            this.m_OldMode = graphics.SmoothingMode;
            graphics.SmoothingMode = newMode;
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="disposing">释放托管资源为true,否则为false</param>
        protected override void Dispose(bool disposing)
        {
            if (this.m_Graphics != null)
            {
                this.m_Graphics.SmoothingMode = this.m_OldMode;
                this.m_Graphics = null;
            }
            this.m_OldMode = SmoothingMode.Default;
        }
    }
}
