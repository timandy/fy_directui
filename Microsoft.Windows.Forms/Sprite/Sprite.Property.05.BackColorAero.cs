using System.Drawing;

namespace Microsoft.Windows.Forms
{
    public partial class Sprite
    {
        private AeroStyle m_BackColorAeroStyle = AeroStyle.None;
        /// <summary>
        /// 特效绘制方式
        /// </summary>
        public AeroStyle BackColorAeroStyle
        {
            get
            {
                return this.m_BackColorAeroStyle;
            }
            set
            {
                if (value != this.m_BackColorAeroStyle)
                {
                    this.m_BackColorAeroStyle = value;
                    this.Feedback();
                }
            }
        }

        private float m_BackColorAeroPos = 0.45f;
        /// <summary>
        /// 特效分割位置
        /// </summary>
        public float BackColorAeroPos
        {
            get
            {
                return this.m_BackColorAeroPos;
            }
            set
            {
                if (value != this.m_BackColorAeroPos)
                {
                    this.m_BackColorAeroPos = value;
                    this.Feedback();
                }
            }
        }

        private Color m_BackColorAeroBlurColor = DefaultTheme.BlurColor;
        /// <summary>
        /// 模糊特效颜色
        /// </summary>
        public Color BackColorAeroBlurColor
        {
            get
            {
                return this.m_BackColorAeroBlurColor;
            }
            set
            {
                if (value != this.m_BackColorAeroBlurColor)
                {
                    this.m_BackColorAeroBlurColor = value;
                    this.Feedback();
                }
            }
        }

        private Color m_BackColorAeroGlassCenterColor = DefaultTheme.GlassCenterColor;
        /// <summary>
        /// 玻璃特效中心颜色
        /// </summary>
        public Color BackColorAeroGlassCenterColor
        {
            get
            {
                return this.m_BackColorAeroGlassCenterColor;
            }
            set
            {
                if (value != this.m_BackColorAeroGlassCenterColor)
                {
                    this.m_BackColorAeroGlassCenterColor = value;
                    this.Feedback();
                }
            }
        }

        private Color m_BackColorAeroGlassSurroundColor = DefaultTheme.GlassSurroundColor;
        /// <summary>
        /// 玻璃特效环绕颜色
        /// </summary>
        public Color BackColorAeroGlassSurroundColor
        {
            get
            {
                return this.m_BackColorAeroGlassSurroundColor;
            }
            set
            {
                if (value != this.m_BackColorAeroGlassSurroundColor)
                {
                    this.m_BackColorAeroGlassSurroundColor = value;
                    this.Feedback();
                }
            }
        }
    }
}
