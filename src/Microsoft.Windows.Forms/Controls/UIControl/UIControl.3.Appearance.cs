using System;
using System.Drawing;

namespace Microsoft.Windows.Forms
{
    partial class UIControl
    {
        private string m_Text;
        /// <summary>
        /// 获取或设置文本
        /// </summary>
        public virtual string Text
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
                    this.Invalidate();
                }
            }
        }

        private Font m_Font = DefaultTheme.Font;
        /// <summary>
        /// 获取或设置字体
        /// </summary>
        public virtual Font Font
        {
            get
            {
                return this.m_Font;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                if (value != this.m_Font)
                {
                    this.m_Font = value;
                    this.Invalidate();
                }
            }
        }

        private Color m_BackColor = DefaultTheme.BackColor;
        /// <summary>
        /// 获取或设置背景色
        /// </summary>
        public virtual Color BackColor
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
                    this.Invalidate();
                }
            }
        }

        private Color m_ForeColor = DefaultTheme.ForeColor;
        /// <summary>
        /// 获取或设置前景色
        /// </summary>
        public virtual Color ForeColor
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
                    this.Invalidate();
                }
            }
        }

        private State m_State;
        /// <summary>
        /// 获取状态
        /// </summary>
        public virtual State State
        {
            get
            {
                return this.m_State;
            }
            protected set
            {
                if (value != this.m_State)
                {
                    this.m_State = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// 计算状态
        /// </summary>
        /// <returns>状态</returns>
        protected virtual State GetState()
        {
            return this.Enabled ? State.Normal : State.Disabled;
        }
    }
}
