using System.Windows.Forms;

namespace Microsoft.Windows.Forms
{
    public partial class Sprite
    {
        private Padding m_Padding = new Padding(3);
        /// <summary>
        /// 文本图片内边距
        /// </summary>
        public Padding Padding
        {
            get
            {
                return this.m_Padding;
            }
            set
            {
                if (value != this.m_Padding)
                {
                    this.m_Padding = value;
                    this.Feedback();
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
                    this.Feedback();
                }
            }
        }

        private RightToLeft m_RightToLeft = RightToLeft.No;
        /// <summary>
        /// 文本图片左右互换
        /// </summary>
        public RightToLeft RightToLeft
        {
            get
            {
                return this.m_RightToLeft;
            }
            set
            {
                if (value != this.m_RightToLeft)
                {
                    this.m_RightToLeft = value;
                    this.Feedback();
                }
            }
        }
    }
}
