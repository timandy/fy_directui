using System.Drawing;
using System.Drawing.Drawing2D;

namespace Microsoft.Windows.Forms
{
    public partial class Sprite
    {
        private BorderVisibleStyle m_BorderVisibleStyle = BorderVisibleStyle.All;
        /// <summary>
        /// 边框样式
        /// </summary>
        public BorderVisibleStyle BorderVisibleStyle
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
                    this.Feedback();
                }
            }
        }

        private BlendStyle m_BorderBlendStyle = BlendStyle.Solid;
        /// <summary>
        /// 边框混合样式
        /// </summary>
        public BlendStyle BorderBlendStyle
        {
            get
            {
                return this.m_BorderBlendStyle;
            }
            set
            {
                if (value != this.m_BorderBlendStyle)
                {
                    this.m_BorderBlendStyle = value;
                    this.Feedback();
                }
            }
        }

        private DashStyle m_BorderDashStyle = DashStyle.Solid;
        /// <summary>
        /// 边框绘制虚线样式
        /// </summary>
        public DashStyle BorderDashStyle
        {
            get
            {
                return this.m_BorderDashStyle;
            }
            set
            {
                if (value != this.m_BorderDashStyle)
                {
                    this.m_BorderDashStyle = value;
                    this.Feedback();
                }
            }
        }

        private float[] m_BorderDashPattern = null;
        /// <summary>
        /// 边框自定义的短划线和空白区域的数组
        /// </summary>
        public float[] BorderDashPattern
        {
            get
            {
                return this.m_BorderDashPattern;
            }
            set
            {
                if (value != this.m_BorderDashPattern)
                {
                    this.m_BorderDashPattern = value;
                    this.Feedback();
                }
            }
        }

        private DashCap m_BorderDashCap = DashCap.Flat;
        /// <summary>
        /// 边框虚线断弦断终点的线帽样式
        /// </summary>
        public DashCap BorderDashCap
        {
            get
            {
                return this.m_BorderDashCap;
            }
            set
            {
                if (value != this.m_BorderDashCap)
                {
                    this.m_BorderDashCap = value;
                    this.Feedback();
                }
            }
        }

        private float m_BorderDashOffset = 0f;
        /// <summary>
        /// 边框直线的起点到短划线图案起始处的距离
        /// </summary>
        public float BorderDashOffset
        {
            get
            {
                return this.m_BorderDashOffset;
            }
            set
            {
                if (value != this.m_BorderDashOffset)
                {
                    this.m_BorderDashOffset = value;
                    this.Feedback();
                }
            }
        }

        private Color m_BorderColor = DefaultTheme.BorderColor;
        /// <summary>
        /// 边框颜色
        /// </summary>
        public Color BorderColor
        {
            get
            {
                return this.m_BorderColor;
            }
            set
            {
                if (value != this.m_BorderColor)
                {
                    this.m_BorderColor = value;
                    this.Feedback();
                }
            }
        }

        private Color m_BorderColorHovered = DefaultTheme.BorderColor + DefaultTheme.BorderColorHoveredVector;
        /// <summary>
        /// 边框色鼠标移上向量
        /// </summary>
        public Color BorderColorHovered
        {
            get
            {
                return this.m_BorderColorHovered;
            }
            set
            {
                if (value != this.m_BorderColorHovered)
                {
                    this.m_BorderColorHovered = value;
                    this.Feedback();
                }
            }
        }

        private Color m_BorderColorPressed = DefaultTheme.BorderColor + DefaultTheme.BorderColorPressedVector;
        /// <summary>
        /// 边框色鼠标按下向量
        /// </summary>
        public Color BorderColorPressed
        {
            get
            {
                return this.m_BorderColorPressed;
            }
            set
            {
                if (value != this.m_BorderColorPressed)
                {
                    this.m_BorderColorPressed = value;
                    this.Feedback();
                }
            }
        }

        private Color m_BorderColorFocused = DefaultTheme.BorderColor + DefaultTheme.BorderColorFocusedVector;
        /// <summary>
        /// 边框色获取焦点向量
        /// </summary>
        public Color BorderColorFocused
        {
            get
            {
                return this.m_BorderColorFocused;
            }
            set
            {
                if (value != this.m_BorderColorFocused)
                {
                    this.m_BorderColorFocused = value;
                    this.Feedback();
                }
            }
        }

        private Color m_BorderColorDisabled = DefaultTheme.BorderColor + DefaultTheme.BorderColorDisabledVector;
        /// <summary>
        /// 边框色状态禁用向量
        /// </summary>
        public Color BorderColorDisabled
        {
            get
            {
                return this.m_BorderColorDisabled;
            }
            set
            {
                if (value != this.m_BorderColorDisabled)
                {
                    this.m_BorderColorDisabled = value;
                    this.Feedback();
                }
            }
        }

        private Color m_BorderColorHighlight = DefaultTheme.BorderColor + DefaultTheme.BorderColorHighlightVector;
        /// <summary>
        /// 边框色高亮向量
        /// </summary>
        public Color BorderColorHighlight
        {
            get
            {
                return this.m_BorderColorHighlight;
            }
            set
            {
                if (value != this.m_BorderColorHighlight)
                {
                    this.m_BorderColorHighlight = value;
                    this.Feedback();
                }
            }
        }

        private float m_BorderColorPos1 = 0.45f;
        /// <summary>
        /// 边框颜色位置1
        /// </summary>
        public float BorderColorPos1
        {
            get
            {
                return this.m_BorderColorPos1;
            }
            set
            {
                if (value != this.m_BorderColorPos1)
                {
                    this.m_BorderColorPos1 = value;
                    this.Feedback();
                }
            }
        }

        private float m_BorderColorPos2 = 0.5f;
        /// <summary>
        /// 边框颜色位置2
        /// </summary>
        public float BorderColorPos2
        {
            get
            {
                return this.m_BorderColorPos2;
            }
            set
            {
                if (value != this.m_BorderColorPos2)
                {
                    this.m_BorderColorPos2 = value;
                    this.Feedback();
                }
            }
        }


        private BorderVisibleStyle m_InnerBorderVisibleStyle = BorderVisibleStyle.None;
        /// <summary>
        /// 内边框样式
        /// </summary>
        public BorderVisibleStyle InnerBorderVisibleStyle
        {
            get
            {
                return this.m_InnerBorderVisibleStyle;
            }
            set
            {
                if (value != this.m_InnerBorderVisibleStyle)
                {
                    this.m_InnerBorderVisibleStyle = value;
                    this.Feedback();
                }
            }
        }

        private BlendStyle m_InnerBorderBlendStyle = BlendStyle.Solid;
        /// <summary>
        /// 内边框混合样式
        /// </summary>
        public BlendStyle InnerBorderBlendStyle
        {
            get
            {
                return this.m_InnerBorderBlendStyle;
            }
            set
            {
                if (value != this.m_InnerBorderBlendStyle)
                {
                    this.m_InnerBorderBlendStyle = value;
                    this.Feedback();
                }
            }
        }

        private DashStyle m_InnerBorderDashStyle = DashStyle.Solid;
        /// <summary>
        /// 内边框绘制虚线样式
        /// </summary>
        public DashStyle InnerBorderDashStyle
        {
            get
            {
                return this.m_InnerBorderDashStyle;
            }
            set
            {
                if (value != this.m_InnerBorderDashStyle)
                {
                    this.m_InnerBorderDashStyle = value;
                    this.Feedback();
                }
            }
        }

        private float[] m_InnerBorderDashPattern = null;
        /// <summary>
        /// 内边框自定义的短划线和空白区域的数组
        /// </summary>
        public float[] InnerBorderDashPattern
        {
            get
            {
                return this.m_InnerBorderDashPattern;
            }
            set
            {
                if (value != this.m_InnerBorderDashPattern)
                {
                    this.m_InnerBorderDashPattern = value;
                    this.Feedback();
                }
            }
        }

        private DashCap m_InnerBorderDashCap = DashCap.Flat;
        /// <summary>
        /// 内边框虚线断弦断终点的线帽样式
        /// </summary>
        public DashCap InnerBorderDashCap
        {
            get
            {
                return this.m_InnerBorderDashCap;
            }
            set
            {
                if (value != this.m_InnerBorderDashCap)
                {
                    this.m_InnerBorderDashCap = value;
                    this.Feedback();
                }
            }
        }

        private float m_InnerBorderDashOffset = 0f;
        /// <summary>
        /// 内边框直线的起点到短划线图案起始处的距离
        /// </summary>
        public float InnerBorderDashOffset
        {
            get
            {
                return this.m_InnerBorderDashOffset;
            }
            set
            {
                if (value != this.m_InnerBorderDashOffset)
                {
                    this.m_InnerBorderDashOffset = value;
                    this.Feedback();
                }
            }
        }

        private Color m_InnerBorderColor = DefaultTheme.InnerBorderColor;
        /// <summary>
        /// 内边框颜色
        /// </summary>
        public Color InnerBorderColor
        {
            get
            {
                return this.m_InnerBorderColor;
            }
            set
            {
                if (value != this.m_InnerBorderColor)
                {
                    this.m_InnerBorderColor = value;
                    this.Feedback();
                }
            }
        }

        private Color m_InnerBorderColorHovered = DefaultTheme.InnerBorderColor + DefaultTheme.InnerBorderColorHoveredVector;
        /// <summary>
        /// 内边框色鼠标移上向量
        /// </summary>
        public Color InnerBorderColorHovered
        {
            get
            {
                return this.m_InnerBorderColorHovered;
            }
            set
            {
                if (value != this.m_InnerBorderColorHovered)
                {
                    this.m_InnerBorderColorHovered = value;
                    this.Feedback();
                }
            }
        }

        private Color m_InnerBorderColorPressed = DefaultTheme.InnerBorderColor + DefaultTheme.InnerBorderColorPressedVector;
        /// <summary>
        /// 内边框色鼠标按下向量
        /// </summary>
        public Color InnerBorderColorPressed
        {
            get
            {
                return this.m_InnerBorderColorPressed;
            }
            set
            {
                if (value != this.m_InnerBorderColorPressed)
                {
                    this.m_InnerBorderColorPressed = value;
                    this.Feedback();
                }
            }
        }

        private Color m_InnerBorderColorFocused = DefaultTheme.InnerBorderColor + DefaultTheme.InnerBorderColorFocusedVector;
        /// <summary>
        /// 内边框色获取焦点向量
        /// </summary>
        public Color InnerBorderColorFocused
        {
            get
            {
                return this.m_InnerBorderColorFocused;
            }
            set
            {
                if (value != this.m_InnerBorderColorFocused)
                {
                    this.m_InnerBorderColorFocused = value;
                    this.Feedback();
                }
            }
        }

        private Color m_InnerBorderColorDisabled = DefaultTheme.InnerBorderColor + DefaultTheme.InnerBorderColorDisabledVector;
        /// <summary>
        /// 内边框色状态禁用向量
        /// </summary>
        public Color InnerBorderColorDisabled
        {
            get
            {
                return this.m_InnerBorderColorDisabled;
            }
            set
            {
                if (value != this.m_InnerBorderColorDisabled)
                {
                    this.m_InnerBorderColorDisabled = value;
                    this.Feedback();
                }
            }
        }

        private Color m_InnerBorderColorHighlight = DefaultTheme.InnerBorderColor + DefaultTheme.InnerBorderColorHighlightVector;
        /// <summary>
        /// 内边框色高亮向量
        /// </summary>
        public Color InnerBorderColorHighlight
        {
            get
            {
                return this.m_InnerBorderColorHighlight;
            }
            set
            {
                if (value != this.m_InnerBorderColorHighlight)
                {
                    this.m_InnerBorderColorHighlight = value;
                    this.Feedback();
                }
            }
        }

        private float m_InnerBorderColorPos1 = 0.45f;
        /// <summary>
        /// 内边框颜色位置1
        /// </summary>
        public float InnerBorderColorPos1
        {
            get
            {
                return this.m_InnerBorderColorPos1;
            }
            set
            {
                if (value != this.m_InnerBorderColorPos1)
                {
                    this.m_InnerBorderColorPos1 = value;
                    this.Feedback();
                }
            }
        }

        private float m_InnerBorderColorPos2 = 0.5f;
        /// <summary>
        /// 内边框颜色位置2
        /// </summary>
        public float InnerBorderColorPos2
        {
            get
            {
                return this.m_InnerBorderColorPos2;
            }
            set
            {
                if (value != this.m_InnerBorderColorPos2)
                {
                    this.m_InnerBorderColorPos2 = value;
                    this.Feedback();
                }
            }
        }
    }
}
