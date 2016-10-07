using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using Microsoft.Drawing;

namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// 虚拟标签控件
    /// </summary>
    public class UILabel : UIControl
    {
        private TextRenderingHint m_TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        /// <summary>
        /// 文本呈现质量
        /// </summary>
        public TextRenderingHint TextRenderingHint
        {
            get
            {
                return this.m_TextRenderingHint;
            }
            set
            {
                if (value != this.m_TextRenderingHint)
                {
                    this.m_TextRenderingHint = value;
                    this.Invalidate();
                }
            }
        }

        private ContentAlignment m_TextAlign = ContentAlignment.MiddleCenter;
        /// <summary>
        /// 文本对齐方式
        /// </summary>
        public ContentAlignment TextAlign
        {
            get
            {
                return this.m_TextAlign;
            }
            set
            {
                if (value != this.m_TextAlign)
                {
                    this.m_TextAlign = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// 渲染控件
        /// </summary>
        /// <param name="e">数据</param>
        protected override void RenderSelf(PaintEventArgs e)
        {
            //准备
            Graphics g = e.Graphics;
            Rectangle rect = RectangleEx.Subtract(this.ClientRectangle, this.Padding);
            //渲染
            this.Sprite.BackColor = this.BackColor;
            this.Sprite.Font = this.Font;
            this.Sprite.Text = this.Text;
            this.Sprite.TextRenderingHint = this.TextRenderingHint;
            this.Sprite.TextAlign = this.TextAlign;
            this.Sprite.BorderVisibleStyle = BorderVisibleStyle.None;
            this.Sprite.State = this.State;
            this.Sprite.BeginRender(g);
            this.Sprite.RenderText(rect);
            this.Sprite.EndRender();
        }
    }
}
