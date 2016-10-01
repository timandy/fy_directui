using System.Drawing;
using System.Windows.Forms;
using Microsoft.Drawing;

namespace Microsoft.Windows.Forms.Layout
{
    /// <summary>
    /// 布局数据
    /// </summary>
    public sealed class LayoutData : DisposableMini
    {
        /// <summary>
        /// 测试用绘图对象
        /// </summary>
        public Graphics Graphics;

        /// <summary>
        /// 区域
        /// </summary>
        public Rectangle ClientRectangle;
        /// <summary>
        /// 边距
        /// </summary>
        public Padding Padding;
        /// <summary>
        /// 文本图片相对位置
        /// </summary>
        public TextImageRelation TextImageRelation;
        /// <summary>
        /// 左右反转样式
        /// </summary>
        public RightToLeft RightToLeft;

        /// <summary>
        /// 图片大小
        /// </summary>
        public Size ImageSize;
        /// <summary>
        /// 图片对齐方式
        /// </summary>
        public ContentAlignment ImageAlign;
        /// <summary>
        /// 图片偏移量
        /// </summary>
        public Point ImageOffset;

        /// <summary>
        /// 文本
        /// </summary>
        public string Text;
        /// <summary>
        /// 字体
        /// </summary>
        public Font Font;
        /// <summary>
        /// 文本对齐方式
        /// </summary>
        public ContentAlignment TextAlign;
        /// <summary>
        /// 文本偏移量
        /// </summary>
        public Point TextOffset;

        /// <summary>
        /// 输出-图片区域(必须先调用Layout()方法)
        /// </summary>
        public Rectangle OutImageBounds;//[OUT]
        /// <summary>
        /// 输出-文本区域(必须先调用Layout()方法)
        /// </summary>
        public Rectangle OutTextBounds;//[OUT]


        //==================

        private bool m_IsLayouted;
        /// <summary>
        /// 是否执行过布局操作
        /// </summary>
        public bool IsLayouted
        {
            get
            {
                return this.m_IsLayouted;
            }
        }


        private Rectangle? m_CurrentClientRectangle;
        /// <summary>
        /// 当前区域,已减去边距
        /// </summary>
        public Rectangle CurrentClientRectangle
        {
            get
            {
                if (this.m_CurrentClientRectangle == null)
                    this.m_CurrentClientRectangle = RectangleEx.Subtract(this.ClientRectangle, this.Padding);
                return this.m_CurrentClientRectangle.Value;
            }
        }

        private TextImageRelation? m_CurrentTextImageRelation;
        /// <summary>
        /// 当前文本图片相对位置,已通过左右反转样式翻译
        /// </summary>
        public TextImageRelation CurrentTextImageRelation
        {
            get
            {
                if (this.m_CurrentTextImageRelation == null)
                    this.m_CurrentTextImageRelation = LayoutOptions.RtlTranslateRelation(this.TextImageRelation, this.RightToLeft);
                return this.m_CurrentTextImageRelation.Value;
            }
        }

        private StringFormat m_CurrentStringFormat;
        /// <summary>
        /// 当前文本格式,渲染文本时使用
        /// </summary>
        public StringFormat CurrentStringFormat
        {
            get
            {
                if (this.m_CurrentStringFormat == null)
                    this.m_CurrentStringFormat = LayoutOptions.GetStringFormat(this.TextAlign, this.RightToLeft);
                return this.m_CurrentStringFormat;
            }
        }

        private ContentAlignment? m_CurrentImageAlign;
        /// <summary>
        /// 当前图片对齐方式,已通过左右反转样式翻译
        /// </summary>
        public ContentAlignment CurrentImageAlign
        {
            get
            {
                if (this.m_CurrentImageAlign == null)
                    this.m_CurrentImageAlign = LayoutOptions.RtlTranslateAlignment(this.ImageAlign, this.RightToLeft);
                return this.m_CurrentImageAlign.Value;
            }
        }

        private ContentAlignment? m_CurrentTextAlign;
        /// <summary>
        /// 当前文本对齐方式,已通过左右反转样式翻译
        /// </summary>
        public ContentAlignment CurrentTextAlign
        {
            get
            {
                if (this.m_CurrentTextAlign == null)
                    this.m_CurrentTextAlign = LayoutOptions.RtlTranslateAlignment(this.TextAlign, this.RightToLeft);
                return this.m_CurrentTextAlign.Value;
            }
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        public LayoutData()
        {
        }

        /// <summary>
        /// 布局文本和图片.该方法可被调用多次,但再生命周期内布局操作只会被执行一次.
        /// </summary>
        public void DoLayout()
        {
            if (this.m_IsLayouted)
                return;
            this.m_IsLayouted = true;
            LayoutOptions.LayoutTextAndImage(this);
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="disposing">释放托管资源为true,否则为false</param>
        protected override void Dispose(bool disposing)
        {
            if (this.m_CurrentStringFormat != null)
            {
                this.m_CurrentStringFormat.Dispose();
                this.m_CurrentStringFormat = null;
            }
        }
    }
}
