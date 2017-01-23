using System.Drawing;
using System.Windows.Forms;

namespace Microsoft.Windows.Forms
{
    public partial class Sprite
    {
        private Image m_BackgroundImage = null;
        /// <summary>
        /// 背景图
        /// </summary>
        public Image BackgroundImage
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
                    this.Feedback();
                }
            }
        }

        private Image m_BackgroundImageHovered = null;
        /// <summary>
        /// 鼠标移上背景图
        /// </summary>
        public Image BackgroundImageHovered
        {
            get
            {
                return this.m_BackgroundImageHovered;
            }
            set
            {
                if (value != this.m_BackgroundImageHovered)
                {
                    this.m_BackgroundImageHovered = value;
                    this.Feedback();
                }
            }
        }

        private Image m_BackgroundImagePressed = null;
        /// <summary>
        /// 鼠标按下背景图
        /// </summary>
        public Image BackgroundImagePressed
        {
            get
            {
                return this.m_BackgroundImagePressed;
            }
            set
            {
                if (value != this.m_BackgroundImagePressed)
                {
                    this.m_BackgroundImagePressed = value;
                    this.Feedback();
                }
            }
        }

        private Image m_BackgroundImageFocused = null;
        /// <summary>
        /// 获取焦点背景图
        /// </summary>
        public Image BackgroundImageFocused
        {
            get
            {
                return this.m_BackgroundImageFocused;
            }
            set
            {
                if (value != this.m_BackgroundImageFocused)
                {
                    this.m_BackgroundImageFocused = value;
                    this.Feedback();
                }
            }
        }

        private Image m_BackgroundImageDisabled = null;
        /// <summary>
        /// 状态禁用背景图
        /// </summary>
        public Image BackgroundImageDisabled
        {
            get
            {
                return this.m_BackgroundImageDisabled;
            }
            set
            {
                if (value != this.m_BackgroundImageDisabled)
                {
                    this.m_BackgroundImageDisabled = value;
                    this.Feedback();
                }
            }
        }

        private Image m_BackgroundImageHighlight = null;
        /// <summary>
        /// 高亮背景图
        /// </summary>
        public Image BackgroundImageHighlight
        {
            get
            {
                return this.m_BackgroundImageHighlight;
            }
            set
            {
                if (value != this.m_BackgroundImageHighlight)
                {
                    this.m_BackgroundImageHighlight = value;
                    this.Feedback();
                }
            }
        }

        private ImageLayout m_BackgroundImageLayout = ImageLayout.Tile;
        /// <summary>
        /// 背景图布局方式
        /// </summary>
        public ImageLayout BackgroundImageLayout
        {
            get
            {
                return this.m_BackgroundImageLayout;
            }
            set
            {
                if (value != this.m_BackgroundImageLayout)
                {
                    this.m_BackgroundImageLayout = value;
                    this.Feedback();
                }
            }
        }

        private bool m_BackgroundImageGrayOnDisabled = false;
        /// <summary>
        /// 状态禁用时背景图是否变灰
        /// </summary>
        public bool BackgroundImageGrayOnDisabled
        {
            get
            {
                return this.m_BackgroundImageGrayOnDisabled;
            }
            set
            {
                if (value != this.m_BackgroundImageGrayOnDisabled)
                {
                    this.m_BackgroundImageGrayOnDisabled = value;
                    this.Feedback();
                }
            }
        }
    }
}
