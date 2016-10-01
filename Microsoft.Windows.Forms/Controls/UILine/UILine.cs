using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.Drawing;

namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// 虚拟直线控件
    /// </summary>
    public class UILine : UIControl
    {
        private bool m_Horizontal = true;
        /// <summary>
        /// 获取或设置是否水平线.true表示水平线,false表示垂直线
        /// </summary>
        public bool Horizontal
        {
            get
            {
                return this.m_Horizontal;
            }
            set
            {
                if (value != this.m_Horizontal)
                {
                    this.m_Horizontal = value;
                    base.Invalidate();
                }
            }
        }

        private int m_LineWidth = 1;
        /// <summary>
        /// 获取或设置直线宽度
        /// </summary>
        public virtual int LineWidth
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
                    this.Invalidate();
                }
            }
        }

        private Color m_LineColor = DefaultTheme.LightBackColor;
        /// <summary>
        /// 获取或设置直线颜色
        /// </summary>
        public virtual Color LineColor
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
                    this.Invalidate();
                }
            }
        }

        private BlendStyle m_LineBlendStyle = BlendStyle.Solid;
        /// <summary>
        /// 渲染方式
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
                    base.Invalidate();
                }
            }
        }

        private DashStyle m_LineDashStyle = DashStyle.Solid;
        /// <summary>
        /// 获取或设置直线的虚线样式
        /// </summary>
        public virtual DashStyle LineDashStyle
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
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// 获取状态
        /// </summary>
        public override State State
        {
            get
            {
                return base.State == State.Disabled ? State.Disabled : State.Normal;
            }
            protected set
            {
                base.State = value;
            }
        }

        /// <summary>
        /// 渲染控件
        /// </summary>
        /// <param name="e">数据</param>
        protected override void RenderSelf(PaintEventArgs e)
        {
            //准备
            Graphics g = e.Graphics;
            Rectangle rect = RectangleEx.Subtract(this.ClientRectangle, this.Padding);
            //计算起点终点
            Point begin, end;
            if (this.Horizontal)
            {
                begin = new Point(rect.X, (rect.Y + rect.Bottom) / 2);
                end = new Point(rect.Right, begin.Y);
            }
            else
            {
                begin = new Point((rect.X + rect.Right) / 2, rect.Y);
                end = new Point(begin.X, rect.Bottom);
            }
            //渲染
            this.Sprite.LineWidth = this.LineWidth;
            this.Sprite.LineColor = this.LineColor;
            this.Sprite.LineBlendStyle = this.LineBlendStyle;
            this.Sprite.LineDashStyle = this.LineDashStyle;
            base.Sprite.BeginRender(g);
            base.Sprite.RenderLine(begin, end);
            base.Sprite.EndRender();
        }
    }
}
