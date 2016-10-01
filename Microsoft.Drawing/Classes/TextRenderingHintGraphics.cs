using System.Drawing;
using System.Drawing.Text;

namespace Microsoft.Drawing
{
    /// <summary>
    /// 暂时修改绘图对象的文本呈现模式,释放时改为原来模式
    /// </summary>
    public class TextRenderingHintGraphics : DisposableMini
    {
        private TextRenderingHint m_OldHint;    //原始的文本呈现模式
        private Graphics m_Graphics;            //要修改文本呈现模式的绘图对象

        /// <summary>
        /// 构造函数,暂时修改为抗锯齿
        /// </summary>
        /// <param name="graphics">绘图对象</param>
        public TextRenderingHintGraphics(Graphics graphics)
            : this(graphics, TextRenderingHint.AntiAlias)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="graphics">绘图对象</param>
        /// <param name="newHint">新文本呈现模式</param>
        public TextRenderingHintGraphics(Graphics graphics, TextRenderingHint newHint)
        {
            this.m_Graphics = graphics;
            this.m_OldHint = graphics.TextRenderingHint;
            graphics.TextRenderingHint = newHint;
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="disposing">释放托管资源为true,否则为false</param>
        protected override void Dispose(bool disposing)
        {
            if (this.m_Graphics != null)
            {
                this.m_Graphics.TextRenderingHint = this.m_OldHint;
                this.m_Graphics = null;
            }
            this.m_OldHint = TextRenderingHint.SystemDefault;
        }
    }
}
