using System.Drawing;
using System.Windows.Forms;

namespace Microsoft.Windows.Forms
{
    public partial class Sprite
    {
        private Image m_BackgroundImage9 = null;
        /// <summary>
        /// 九宫格背景图
        /// </summary>
        public Image BackgroundImage9
        {
            get
            {
                return this.m_BackgroundImage9;
            }
            set
            {
                if (value != this.m_BackgroundImage9)
                {
                    this.m_BackgroundImage9 = value;
                    this.Feedback();
                }
            }
        }

        private Image m_BackgroundImage9Hovered = null;
        /// <summary>
        /// 鼠标移上九宫格背景图
        /// </summary>
        public Image BackgroundImage9Hovered
        {
            get
            {
                return this.m_BackgroundImage9Hovered;
            }
            set
            {
                if (value != this.m_BackgroundImage9Hovered)
                {
                    this.m_BackgroundImage9Hovered = value;
                    this.Feedback();
                }
            }
        }

        private Image m_BackgroundImage9Pressed = null;
        /// <summary>
        /// 鼠标按下九宫格背景图
        /// </summary>
        public Image BackgroundImage9Pressed
        {
            get
            {
                return this.m_BackgroundImage9Pressed;
            }
            set
            {
                if (value != this.m_BackgroundImage9Pressed)
                {
                    this.m_BackgroundImage9Pressed = value;
                    this.Feedback();
                }
            }
        }

        private Image m_BackgroundImage9Focused = null;
        /// <summary>
        /// 获取焦点九宫格背景图
        /// </summary>
        public Image BackgroundImage9Focused
        {
            get
            {
                return this.m_BackgroundImage9Focused;
            }
            set
            {
                if (value != this.m_BackgroundImage9Focused)
                {
                    this.m_BackgroundImage9Focused = value;
                    this.Feedback();
                }
            }
        }

        private Image m_BackgroundImage9Disabled = null;
        /// <summary>
        /// 状态禁用九宫格背景图
        /// </summary>
        public Image BackgroundImage9Disabled
        {
            get
            {
                return this.m_BackgroundImage9Disabled;
            }
            set
            {
                if (value != this.m_BackgroundImage9Disabled)
                {
                    this.m_BackgroundImage9Disabled = value;
                    this.Feedback();
                }
            }
        }

        private Image m_BackgroundImage9Highlight = null;
        /// <summary>
        /// 高亮九宫格背景图
        /// </summary>
        public Image BackgroundImage9Highlight
        {
            get
            {
                return this.m_BackgroundImage9Highlight;
            }
            set
            {
                if (value != this.m_BackgroundImage9Highlight)
                {
                    this.m_BackgroundImage9Highlight = value;
                    this.Feedback();
                }
            }
        }

        private Padding m_BackgroundImage9Padding = Padding.Empty;
        /// <summary>
        /// 九宫格背景图内边距
        /// </summary>
        public Padding BackgroundImage9Padding
        {
            get
            {
                return this.m_BackgroundImage9Padding;
            }
            set
            {
                if (value != this.m_BackgroundImage9Padding)
                {
                    this.m_BackgroundImage9Padding = value;
                    this.Feedback();
                }
            }
        }

        private ImageLayout9 m_BackgroundImage9Layout = ImageLayout9.None;
        /// <summary>
        /// 九宫格背景图布局方式
        /// </summary>
        public ImageLayout9 BackgroundImage9Layout
        {
            get
            {
                return this.m_BackgroundImage9Layout;
            }
            set
            {
                if (value != this.m_BackgroundImage9Layout)
                {
                    this.m_BackgroundImage9Layout = value;
                    this.Feedback();
                }
            }
        }

        private bool m_BackgroundImage9GrayOnDisabled = false;
        /// <summary>
        /// 状态禁用时九宫格背景图是否变灰
        /// </summary>
        public bool BackgroundImage9GrayOnDisabled
        {
            get
            {
                return this.m_BackgroundImage9GrayOnDisabled;
            }
            set
            {
                if (value != this.m_BackgroundImage9GrayOnDisabled)
                {
                    this.m_BackgroundImage9GrayOnDisabled = value;
                    this.Feedback();
                }
            }
        }
    }
}
