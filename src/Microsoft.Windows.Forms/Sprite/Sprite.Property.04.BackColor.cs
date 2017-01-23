using System.Drawing;
using System.Windows.Forms;

namespace Microsoft.Windows.Forms
{
    public partial class Sprite
    {
        private BlendStyle m_BackColorBlendStyle = BlendStyle.Solid;
        /// <summary>
        /// 背景色混合样式
        /// </summary>
        public BlendStyle BackColorBlendStyle
        {
            get
            {
                return this.m_BackColorBlendStyle;
            }
            set
            {
                if (value != this.m_BackColorBlendStyle)
                {
                    this.m_BackColorBlendStyle = value;
                    this.Feedback();
                }
            }
        }

        private Color m_BackColor = DefaultTheme.BackColor;
        /// <summary>
        /// 背景色
        /// </summary>
        public Color BackColor
        {
            get
            {
                return this.m_BackColor;
            }
            set
            {
                if (value != this.m_BackColor)
                {
                    this.m_BackColor = value;
                    this.Feedback();
                }
            }
        }

        private Color m_BackColorHovered = DefaultTheme.BackColor + DefaultTheme.BackColorHoveredVector;
        /// <summary>
        /// 背景鼠标移上颜色向量
        /// </summary>
        public Color BackColorHovered
        {
            get
            {
                return this.m_BackColorHovered;
            }
            set
            {
                if (value != this.m_BackColorHovered)
                {
                    this.m_BackColorHovered = value;
                    this.Feedback();
                }
            }
        }

        private Color m_BackColorPressed = DefaultTheme.BackColor + DefaultTheme.BackColorPressedVector;
        /// <summary>
        /// 背景鼠标按下颜色向量
        /// </summary>
        public Color BackColorPressed
        {
            get
            {
                return this.m_BackColorPressed;
            }
            set
            {
                if (value != this.m_BackColorPressed)
                {
                    this.m_BackColorPressed = value;
                    this.Feedback();
                }
            }
        }

        private Color m_BackColorFocused = DefaultTheme.BackColor + DefaultTheme.BackColorFocusedVector;
        /// <summary>
        /// 背景拥有焦点颜色向量
        /// </summary>
        public Color BackColorFocused
        {
            get
            {
                return this.m_BackColorFocused;
            }
            set
            {
                if (value != this.m_BackColorFocused)
                {
                    this.m_BackColorFocused = value;
                    this.Feedback();
                }
            }
        }

        private Color m_BackColorDisabled = DefaultTheme.BackColor + DefaultTheme.BackColorDisabledVector;
        /// <summary>
        /// 背景状态禁用颜色向量
        /// </summary>
        public Color BackColorDisabled
        {
            get
            {
                return this.m_BackColorDisabled;
            }
            set
            {
                if (value != this.m_BackColorDisabled)
                {
                    this.m_BackColorDisabled = value;
                    this.Feedback();
                }
            }
        }

        private Color m_BackColorHighlight = DefaultTheme.BackColor + DefaultTheme.BackColorHighlightVector;
        /// <summary>
        /// 背景高亮颜色向量
        /// </summary>
        public Color BackColorHighlight
        {
            get
            {
                return this.m_BackColorHighlight;
            }
            set
            {
                if (value != this.m_BackColorHighlight)
                {
                    this.m_BackColorHighlight = value;
                    this.Feedback();
                }
            }
        }

        private float m_BackColorPos1 = 0.45f;
        /// <summary>
        /// 背景色位置1
        /// </summary>
        public float BackColorPos1
        {
            get
            {
                return this.m_BackColorPos1;
            }
            set
            {
                if (value != this.m_BackColorPos1)
                {
                    this.m_BackColorPos1 = value;
                    this.Feedback();
                }
            }
        }

        private float m_BackColorPos2 = 0.5f;
        /// <summary>
        /// 背景色位置2
        /// </summary>
        public float BackColorPos2
        {
            get
            {
                return this.m_BackColorPos2;
            }
            set
            {
                if (value != this.m_BackColorPos2)
                {
                    this.m_BackColorPos2 = value;
                    this.Feedback();
                }
            }
        }

        private TabAlignment m_BackColorAlign = TabAlignment.Top;
        /// <summary>
        /// 背景色,决定渐变方向,反转
        /// </summary>
        public TabAlignment BackColorAlign
        {
            get
            {
                return this.m_BackColorAlign;
            }
            set
            {
                if (value != this.m_BackColorAlign)
                {
                    this.m_BackColorAlign = value;
                    this.Feedback();
                }
            }
        }
    }
}
