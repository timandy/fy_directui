using System.Drawing;
using System.Drawing.Drawing2D;

namespace Microsoft.Windows.Forms
{
    partial class Sprite
    {
        private int m_LineWidth = 1;
        /// <summary>
        /// 直线
        /// </summary>
        public int LineWidth
        {
            get
            {
                return this.m_LineWidth;
            }
            set
            {
                if (value != this.m_LineWidth)
                {
                    this.m_LineWidth = value;
                    this.Feedback();
                }
            }
        }

        private BlendStyle m_LineBlendStyle = BlendStyle.Solid;
        /// <summary>
        /// 直线混合样式
        /// </summary>
        public BlendStyle LineBlendStyle
        {
            get
            {
                return this.m_LineBlendStyle;
            }
            set
            {
                if (value != this.m_LineBlendStyle)
                {
                    this.m_LineBlendStyle = value;
                    this.Feedback();
                }
            }
        }

        private DashStyle m_LineDashStyle = DashStyle.Solid;
        /// <summary>
        /// 直线绘制虚线样式
        /// </summary>
        public DashStyle LineDashStyle
        {
            get
            {
                return this.m_LineDashStyle;
            }
            set
            {
                if (value != this.m_LineDashStyle)
                {
                    this.m_LineDashStyle = value;
                    this.Feedback();
                }
            }
        }

        private float[] m_LineDashPattern = null;
        /// <summary>
        /// 直线自定义的短划线和空白区域的数组
        /// </summary>
        public float[] LineDashPattern
        {
            get
            {
                return this.m_LineDashPattern;
            }
            set
            {
                if (value != this.m_LineDashPattern)
                {
                    this.m_LineDashPattern = value;
                    this.Feedback();
                }
            }
        }

        private DashCap m_LineDashCap = DashCap.Flat;
        /// <summary>
        /// 直线虚线断弦断终点的线帽样式
        /// </summary>
        public DashCap LineDashCap
        {
            get
            {
                return this.m_LineDashCap;
            }
            set
            {
                if (value != this.m_LineDashCap)
                {
                    this.m_LineDashCap = value;
                    this.Feedback();
                }
            }
        }

        private float m_LineDashOffset = 0f;
        /// <summary>
        /// 直线直线的起点到短划线图案起始处的距离
        /// </summary>
        public float LineDashOffset
        {
            get
            {
                return this.m_LineDashOffset;
            }
            set
            {
                if (value != this.m_LineDashOffset)
                {
                    this.m_LineDashOffset = value;
                    this.Feedback();
                }
            }
        }

        private Color m_LineColor = DefaultTheme.BorderColor;
        /// <summary>
        /// 直线颜色
        /// </summary>
        public Color LineColor
        {
            get
            {
                return this.m_LineColor;
            }
            set
            {
                if (value != this.m_LineColor)
                {
                    this.m_LineColor = value;
                    this.Feedback();
                }
            }
        }

        private Color m_LineColorHovered = DefaultTheme.BorderColor + DefaultTheme.BorderColorHoveredVector;
        /// <summary>
        /// 直线色鼠标移上向量
        /// </summary>
        public Color LineColorHovered
        {
            get
            {
                return this.m_LineColorHovered;
            }
            set
            {
                if (value != this.m_LineColorHovered)
                {
                    this.m_LineColorHovered = value;
                    this.Feedback();
                }
            }
        }

        private Color m_LineColorPressed = DefaultTheme.BorderColor + DefaultTheme.BorderColorPressedVector;
        /// <summary>
        /// 直线色鼠标按下向量
        /// </summary>
        public Color LineColorPressed
        {
            get
            {
                return this.m_LineColorPressed;
            }
            set
            {
                if (value != this.m_LineColorPressed)
                {
                    this.m_LineColorPressed = value;
                    this.Feedback();
                }
            }
        }

        private Color m_LineColorFocused = DefaultTheme.BorderColor + DefaultTheme.BorderColorFocusedVector;
        /// <summary>
        /// 直线色获取焦点向量
        /// </summary>
        public Color LineColorFocused
        {
            get
            {
                return this.m_LineColorFocused;
            }
            set
            {
                if (value != this.m_LineColorFocused)
                {
                    this.m_LineColorFocused = value;
                    this.Feedback();
                }
            }
        }

        private Color m_LineColorDisabled = DefaultTheme.BorderColor + DefaultTheme.BorderColorDisabledVector;
        /// <summary>
        /// 直线色状态禁用向量
        /// </summary>
        public Color LineColorDisabled
        {
            get
            {
                return this.m_LineColorDisabled;
            }
            set
            {
                if (value != this.m_LineColorDisabled)
                {
                    this.m_LineColorDisabled = value;
                    this.Feedback();
                }
            }
        }

        private Color m_LineColorHighlight = DefaultTheme.BorderColor + DefaultTheme.BorderColorHighlightVector;
        /// <summary>
        /// 直线色高亮向量
        /// </summary>
        public Color LineColorHighlight
        {
            get
            {
                return this.m_LineColorHighlight;
            }
            set
            {
                if (value != this.m_LineColorHighlight)
                {
                    this.m_LineColorHighlight = value;
                    this.Feedback();
                }
            }
        }

        private float m_LineColorPos1 = 0.45f;
        /// <summary>
        /// 直线颜色位置1
        /// </summary>
        public float LineColorPos1
        {
            get
            {
                return this.m_LineColorPos1;
            }
            set
            {
                if (value != this.m_LineColorPos1)
                {
                    this.m_LineColorPos1 = value;
                    this.Feedback();
                }
            }
        }

        private float m_LineColorPos2 = 0.5f;
        /// <summary>
        /// 直线颜色位置2
        /// </summary>
        public float LineColorPos2
        {
            get
            {
                return this.m_LineColorPos2;
            }
            set
            {
                if (value != this.m_LineColorPos2)
                {
                    this.m_LineColorPos2 = value;
                    this.Feedback();
                }
            }
        }
    }
}
