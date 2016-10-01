using System.Drawing;
using System.Windows.Forms;

namespace Microsoft.Windows.Forms
{
    public partial class Sprite
    {
        private Image m_BackgroundImage9 = null;
        /// <summary>
        /// ¾Å¹¬¸ñ±³¾°Í¼
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
        /// Êó±êÒÆÉÏ¾Å¹¬¸ñ±³¾°Í¼
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
        /// Êó±ê°´ÏÂ¾Å¹¬¸ñ±³¾°Í¼
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
        /// »ñÈ¡½¹µã¾Å¹¬¸ñ±³¾°Í¼
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
        /// ×´Ì¬½ûÓÃ¾Å¹¬¸ñ±³¾°Í¼
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
        /// ¸ßÁÁ¾Å¹¬¸ñ±³¾°Í¼
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
        /// ¾Å¹¬¸ñ±³¾°Í¼ÄÚ±ß¾à
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
        /// ¾Å¹¬¸ñ±³¾°Í¼²¼¾Ö·½Ê½
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
        /// ×´Ì¬½ûÓÃÊ±¾Å¹¬¸ñ±³¾°Í¼ÊÇ·ñ±ä»Ò
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
