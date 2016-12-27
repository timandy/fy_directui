using System.Drawing;
using System.Windows.Forms;
using Microsoft.Drawing;

namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// 虚拟容器控件
    /// </summary>
    public class UIPanel : UIControl
    {
        private Image m_BackgroundImage;
        /// <summary>
        /// 获取或设置背景图
        /// </summary>
        public virtual Image BackgroundImage
        {
            get
            {
                return this.m_BackgroundImage;
            }
            set
            {
                if (value != this.m_BackgroundImage)
                {
                    this.m_BackgroundImage = value;
                    this.Invalidate();
                }
            }
        }

        private ImageLayout m_BackgroundImageLayout = ImageLayout.None;
        /// <summary>
        /// 获取或设置背景图布局方式
        /// </summary>
        public virtual ImageLayout BackgroundImageLayout
        {
            get { return this.m_BackgroundImageLayout; }
            set
            {
                if (value != this.m_BackgroundImageLayout)
                {
                    this.m_BackgroundImageLayout = value;
                    this.Invalidate();
                }
            }
        }

        private Color m_BorderColor = DefaultTheme.BorderColor;
        /// <summary>
        /// 获取或设置边框色
        /// </summary>
        public virtual Color BorderColor
        {
            get { return this.m_BorderColor; }
            set
            {
                if (value != this.m_BorderColor)
                {
                    this.m_BorderColor = value;
                    this.Invalidate();
                }
            }
        }

        private BorderVisibleStyle m_BorderVisibleStyle = BorderVisibleStyle.None;
        /// <summary>
        /// 获取或设置边框可见性
        /// </summary>
        public virtual BorderVisibleStyle BorderVisibleStyle
        {
            get
            {
                return this.m_BorderVisibleStyle;
            }
            set
            {
                if (value != this.m_BorderVisibleStyle)
                {
                    this.m_BorderVisibleStyle = value;
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
            this.Sprite.BackgroundImage = this.BackgroundImage;
            this.Sprite.BackgroundImageLayout = this.BackgroundImageLayout;
            this.Sprite.BorderColor = this.BorderColor;
            this.Sprite.BorderVisibleStyle = this.BorderVisibleStyle;
            this.Sprite.State = this.State;
            this.Sprite.BeginRender(g);
            this.Sprite.RenderBackColor(rect);
            this.Sprite.RenderBackgroundImage(rect);
            this.Sprite.RenderBorder(rect);
            this.Sprite.EndRender();
        }
    }
}
