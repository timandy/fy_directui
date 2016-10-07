using System.Drawing;
using System.Drawing.Text;

namespace Microsoft.Windows.Forms
{
    public partial class Sprite
    {
        private string m_Text = null;
        /// <summary>
        /// 文本
        /// </summary>
        public string Text
        {
            get
            {
                return this.m_Text;
            }
            set
            {
                if (value != this.m_Text)
                {
                    this.m_Text = value;
                    this.Feedback();
                }
            }
        }

        private Point m_TextOffset = Point.Empty;
        /// <summary>
        /// 文本偏移
        /// </summary>
        public Point TextOffset
        {
            get
            {
                return this.m_TextOffset;
            }
            set
            {
                if (value != this.m_TextOffset)
                {
                    this.m_TextOffset = value;
                    this.Feedback();
                }
            }
        }

        private Point m_TextOffsetHovered = Point.Empty;
        /// <summary>
        /// 鼠标移上时在TextOffset上再次偏移
        /// </summary>
        public Point TextOffsetHovered
        {
            get
            {
                return this.m_TextOffsetHovered;
            }
            set
            {
                if (value != this.m_TextOffsetHovered)
                {
                    this.m_TextOffsetHovered = value;
                    this.Feedback();
                }
            }
        }

        private Point m_TextOffsetPressed = Point.Empty;
        /// <summary>
        /// 鼠标按下时在TextOffset上再次偏移
        /// </summary>
        public Point TextOffsetPressed
        {
            get
            {
                return this.m_TextOffsetPressed;
            }
            set
            {
                if (value != this.m_TextOffsetPressed)
                {
                    this.m_TextOffsetPressed = value;
                    this.Feedback();
                }
            }
        }

        private Point m_TextOffsetFocused = Point.Empty;
        /// <summary>
        /// 获取焦点时在TextOffset上再次偏移
        /// </summary>
        public Point TextOffsetFocused
        {
            get
            {
                return this.m_TextOffsetFocused;
            }
            set
            {
                if (value != this.m_TextOffsetFocused)
                {
                    this.m_TextOffsetFocused = value;
                    this.Feedback();
                }
            }
        }

        private Point m_TextOffsetDisabled = Point.Empty;
        /// <summary>
        /// 禁用时在TextOffset上再次偏移
        /// </summary>
        public Point TextOffsetDisabled
        {
            get
            {
                return this.m_TextOffsetDisabled;
            }
            set
            {
                if (value != this.m_TextOffsetDisabled)
                {
                    this.m_TextOffsetDisabled = value;
                    this.Feedback();
                }
            }
        }

        private Point m_TextOffsetHighlight = Point.Empty;
        /// <summary>
        /// 高亮时在TextOffset上再次偏移
        /// </summary>
        public Point TextOffsetHighlight
        {
            get
            {
                return this.m_TextOffsetHighlight;
            }
            set
            {
                if (value != this.m_TextOffsetHighlight)
                {
                    this.m_TextOffsetHighlight = value;
                    this.Feedback();
                }
            }
        }

        private Font m_Font = DefaultTheme.Font;
        /// <summary>
        /// 字体.该字体为全局静态变量,不要释放
        /// </summary>
        public Font Font
        {
            get
            {
                return this.m_Font;
            }
            set
            {
                if (value != this.m_Font)
                {
                    this.m_Font = value;
                    this.Feedback();
                }
            }
        }

        private Color m_ForeColor = DefaultTheme.ForeColor;
        /// <summary>
        /// 前景色
        /// </summary>
        public Color ForeColor
        {
            get
            {
                return this.m_ForeColor;
            }
            set
            {
                if (value != this.m_ForeColor)
                {
                    this.m_ForeColor = value;
                    this.Feedback();
                }
            }
        }

        private Color m_ForeColorHovered = DefaultTheme.ForeColor + DefaultTheme.ForeColorHoveredVector;
        /// <summary>
        /// 前景鼠标移上颜色向量
        /// </summary>
        public Color ForeColorHovered
        {
            get
            {
                return this.m_ForeColorHovered;
            }
            set
            {
                if (value != this.m_ForeColorHovered)
                {
                    this.m_ForeColorHovered = value;
                    this.Feedback();
                }
            }
        }

        private Color m_ForeColorPressed = DefaultTheme.ForeColor + DefaultTheme.ForeColorPressedVector;
        /// <summary>
        /// 前景鼠标按下颜色向量
        /// </summary>
        public Color ForeColorPressed
        {
            get
            {
                return this.m_ForeColorPressed;
            }
            set
            {
                if (value != this.m_ForeColorPressed)
                {
                    this.m_ForeColorPressed = value;
                    this.Feedback();
                }
            }
        }

        private Color m_ForeColorFocused = DefaultTheme.ForeColor + DefaultTheme.ForeColorFocusedVector;
        /// <summary>
        /// 前景获取焦点颜色向量
        /// </summary>
        public Color ForeColorFocused
        {
            get
            {
                return this.m_ForeColorFocused;
            }
            set
            {
                if (value != this.m_ForeColorFocused)
                {
                    this.m_ForeColorFocused = value;
                    this.Feedback();
                }
            }
        }

        private Color m_ForeColorDisabled = DefaultTheme.ForeColor + DefaultTheme.ForeColorDisabledVector;
        /// <summary>
        /// 前景状态禁用颜色向量
        /// </summary>
        public Color ForeColorDisabled
        {
            get
            {
                return this.m_ForeColorDisabled;
            }
            set
            {
                if (value != this.m_ForeColorDisabled)
                {
                    this.m_ForeColorDisabled = value;
                    this.Feedback();
                }
            }
        }

        private Color m_ForeColorHighlight = DefaultTheme.ForeColor + DefaultTheme.ForeColorHighlightVector;
        /// <summary>
        /// 前景高亮颜色向量
        /// </summary>
        public Color ForeColorHighlight
        {
            get
            {
                return this.m_ForeColorHighlight;
            }
            set
            {
                if (value != this.m_ForeColorHighlight)
                {
                    this.m_ForeColorHighlight = value;
                    this.Feedback();
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
                    this.Feedback();
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
                    this.Feedback();
                }
            }
        }

        private float m_TextRotateAngle = 0f;
        /// <summary>
        /// 文本旋转角度
        /// </summary>
        public float TextRotateAngle
        {
            get
            {
                return this.m_TextRotateAngle;
            }
            set
            {
                if (value != this.m_TextRotateAngle)
                {
                    this.m_TextRotateAngle = value;
                    this.Feedback();
                }
            }
        }

        private bool m_TextGrayOnDisabled = true;
        /// <summary>
        /// 状态禁用时文本是否变灰
        /// </summary>
        public bool TextGrayOnDisabled
        {
            get
            {
                return this.m_TextGrayOnDisabled;
            }
            set
            {
                if (value != this.m_TextGrayOnDisabled)
                {
                    this.m_TextGrayOnDisabled = value;
                    this.Feedback();
                }
            }
        }


        private ShadowShapeStyle m_TextShadowShapeStyle = ShadowShapeStyle.None;
        /// <summary>
        /// 文本阴影描边样式
        /// </summary>
        public ShadowShapeStyle TextShadowShapeStyle
        {
            get
            {
                return this.m_TextShadowShapeStyle;
            }
            set
            {
                if (value != this.m_TextShadowShapeStyle)
                {
                    this.m_TextShadowShapeStyle = value;
                    this.Feedback();
                }
            }
        }

        private Color m_TextShadowColor = DefaultTheme.LightLightForeColor;
        /// <summary>
        /// 阴影颜色
        /// </summary>
        public Color TextShadowColor
        {
            get
            {
                return this.m_TextShadowColor;
            }
            set
            {
                if (value != this.m_TextShadowColor)
                {
                    this.m_TextShadowColor = value;
                    this.Feedback();
                }
            }
        }

        private Point m_TextShadowMatrixOffset = Point.Empty;
        /// <summary>
        /// 阴影偏移量
        /// </summary>
        public Point TextShadowMatrixOffset
        {
            get
            {
                return this.m_TextShadowMatrixOffset;
            }
            set
            {
                if (value != this.m_TextShadowMatrixOffset)
                {
                    this.m_TextShadowMatrixOffset = value;
                    this.Feedback();
                }
            }
        }

        private Color m_TextShapeOfShadowColor = DefaultTheme.LightLightForeColor;
        /// <summary>
        /// 阴影描边颜色
        /// </summary>
        public Color TextShapeOfShadowColor
        {
            get
            {
                return this.m_TextShapeOfShadowColor;
            }
            set
            {
                if (value != this.m_TextShapeOfShadowColor)
                {
                    this.m_TextShapeOfShadowColor = value;
                    this.Feedback();
                }
            }
        }

        private float m_TextShapeOfShadowWidth = 0f;
        /// <summary>
        /// 阴影描边宽度
        /// </summary>
        public float TextShapeOfShadowWidth
        {
            get
            {
                return this.m_TextShapeOfShadowWidth;
            }
            set
            {
                if (value != this.m_TextShapeOfShadowWidth)
                {
                    this.m_TextShapeOfShadowWidth = value;
                    this.Feedback();
                }
            }
        }

        private Color m_TextShapeOfTextColor = DefaultTheme.LightLightForeColor;
        /// <summary>
        /// 文本描边颜色
        /// </summary>
        public Color TextShapeOfTextColor
        {
            get
            {
                return this.m_TextShapeOfTextColor;
            }
            set
            {
                if (value != this.m_TextShapeOfTextColor)
                {
                    this.m_TextShapeOfTextColor = value;
                    this.Feedback();
                }
            }
        }

        private float m_TextShapeOfTextWidth = 0f;
        /// <summary>
        /// 文本描边宽度
        /// </summary>
        public float TextShapeOfTextWidth
        {
            get
            {
                return this.m_TextShapeOfTextWidth;
            }
            set
            {
                if (value != this.m_TextShapeOfTextWidth)
                {
                    this.m_TextShapeOfTextWidth = value;
                    this.Feedback();
                }
            }
        }
    }
}
