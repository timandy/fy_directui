using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using Microsoft.Drawing;

namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// 虚拟按钮
    /// </summary>
    public class UIButton : UIControl
    {
        private Color m_HoveredBackColor = DefaultTheme.DarkDarkTransparent;
        /// <summary>
        /// 鼠标悬停背景色
        /// </summary>
        public virtual Color HoveredBackColor
        {
            get
            {
                return this.m_HoveredBackColor;
            }
            set
            {
                if (value != this.m_HoveredBackColor)
                {
                    this.m_HoveredBackColor = value;
                    this.Invalidate();
                }
            }
        }

        private Color m_PressedBackColor = DefaultTheme.DarkTransparent;
        /// <summary>
        /// 鼠标按下背景色
        /// </summary>
        public virtual Color PressedBackColor
        {
            get
            {
                return this.m_PressedBackColor;
            }
            set
            {
                if (value != this.m_PressedBackColor)
                {
                    this.m_PressedBackColor = value;
                    this.Invalidate();
                }
            }
        }

        private Image m_Image;
        /// <summary>
        /// 图片
        /// </summary>
        public virtual Image Image
        {
            get
            {
                return this.m_Image;
            }
            set
            {
                if (value != this.m_Image)
                {
                    this.m_Image = value;
                    this.Invalidate();
                }
            }
        }

        private Size m_ImageSize;
        /// <summary>
        /// 图片大小
        /// </summary>
        public virtual Size ImageSize
        {
            get
            {
                return this.m_ImageSize;
            }
            set
            {
                if (value != this.m_ImageSize)
                {
                    this.m_ImageSize = value;
                    this.Invalidate();
                }
            }
        }

        private ContentAlignment m_ImageAlign = ContentAlignment.MiddleCenter;
        /// <summary>
        /// 图片对齐方式
        /// </summary>
        public ContentAlignment ImageAlign
        {
            get
            {
                return this.m_ImageAlign;
            }
            set
            {
                if (value != this.m_ImageAlign)
                {
                    this.m_ImageAlign = value;
                    this.Invalidate();
                }
            }
        }

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

        private TextImageRelation m_TextImageRelation = TextImageRelation.ImageBeforeText;
        /// <summary>
        /// 文本图片关系
        /// </summary>
        public TextImageRelation TextImageRelation
        {
            get
            {
                return this.m_TextImageRelation;
            }
            set
            {
                if (value != this.m_TextImageRelation)
                {
                    this.m_TextImageRelation = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public UIButton()
        {
            this.BackColor = DefaultTheme.Transparent;
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
            this.Sprite.BorderVisibleStyle = BorderVisibleStyle.None;
            this.Sprite.BackColor = this.BackColor;
            this.Sprite.BackColorHovered = this.HoveredBackColor;
            this.Sprite.BackColorPressed = this.PressedBackColor;
            this.Sprite.Image = this.Image;
            this.Sprite.ImageSize = this.ImageSize;
            this.Sprite.ImageAlign = this.ImageAlign;
            this.Sprite.Font = this.Font;
            this.Sprite.ForeColor = this.ForeColor;
            this.Sprite.Text = this.Text;
            this.Sprite.TextRenderingHint = this.TextRenderingHint;
            this.Sprite.TextAlign = this.TextAlign;
            this.Sprite.TextImageRelation = this.TextImageRelation;
            this.Sprite.State = this.State;
            this.Sprite.BeginRender(g);
            this.Sprite.RenderBackColor(rect);
            this.Sprite.RenderImage(rect);
            this.Sprite.RenderText(rect);
            this.Sprite.EndRender();
        }
    }
}
