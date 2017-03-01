using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using Microsoft.Drawing;

namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// 虚拟超链接控件
    /// </summary>
    public class UILink : UIControl
    {
        //暂存进入控件前的光标
        private Cursor m_Cursor;

        private Color m_HoveredForeColor = DefaultTheme.ForeColor;
        /// <summary>
        /// 鼠标悬停背景色
        /// </summary>
        public virtual Color HoveredForeColor
        {
            get
            {
                return this.m_HoveredForeColor;
            }
            set
            {
                if (value != this.m_HoveredForeColor)
                {
                    this.m_HoveredForeColor = value;
                    this.Invalidate();
                }
            }
        }

        private Color m_PresseddForeColor = DefaultTheme.ForeColor;
        /// <summary>
        /// 鼠标按下背景色
        /// </summary>
        public virtual Color PresseddForeColor
        {
            get
            {
                return this.m_PresseddForeColor;
            }
            set
            {
                if (value != this.m_PresseddForeColor)
                {
                    this.m_PresseddForeColor = value;
                    this.Invalidate();
                }
            }
        }

        private TextRenderingHint m_TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        /// <summary>
        /// 文本呈现质量
        /// </summary>
        public virtual TextRenderingHint TextRenderingHint
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
                    this.Invalidate();
                }
            }
        }

        private ContentAlignment m_TextAlign = ContentAlignment.MiddleCenter;
        /// <summary>
        /// 文本对齐方式
        /// </summary>
        public virtual ContentAlignment TextAlign
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
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override State GetState()
        {
            if (this.Enabled)
            {
                if (this.Capture)
                {
                    if ((Control.MouseButtons & MouseButtons.Left) != 0)//左键按下
                        return State.Pressed;
                    else
                        return State.Hovered;
                }
                else
                {
                    return State.Normal;
                }
            }
            else
            {
                return State.Disabled;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public UILink()
        {
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

            //渲染
            this.Sprite.BorderVisibleStyle = BorderVisibleStyle.All;
            this.Sprite.Font = this.Font;
            this.Sprite.ForeColor = this.ForeColor;
            this.Sprite.ForeColorHovered = this.HoveredForeColor;
            this.Sprite.ForeColorPressed = this.PresseddForeColor;
            this.Sprite.ForeColorDisabled = this.ForeColor;
            this.Sprite.Text = this.Text;
            this.Sprite.TextRenderingHint = this.TextRenderingHint;
            this.Sprite.TextAlign = this.TextAlign;
            this.Sprite.State = this.State;
            this.Sprite.BeginRender(g);
            this.Sprite.RenderText(rect);
            this.Sprite.EndRender();
        }

        /// <summary>
        /// 触发鼠标进入事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnEnter(EventArgs e)
        {
            this.m_Cursor = Cursor.Current;
            Control control = this.FindUIWindow() as Control;
            if (control != null)
                control.Cursor = Cursors.Hand;
            base.OnEnter(e);
        }

        /// <summary>
        /// 触发鼠标离开事件
        /// </summary>
        /// <param name="e">数据</param>
        protected override void OnLeave(EventArgs e)
        {
            Control control = this.FindUIWindow() as Control;
            if (control != null)
                control.Cursor = this.m_Cursor;
            base.OnLeave(e);
        }
    }
}
