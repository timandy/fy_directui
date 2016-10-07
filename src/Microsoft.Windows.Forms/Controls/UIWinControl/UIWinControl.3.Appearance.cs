using System;
using System.ComponentModel;
using System.Drawing;

namespace Microsoft.Windows.Forms
{
    partial class UIWinControl
    {
        /// <summary>
        /// 获取或设置字体
        /// </summary>
        [DefaultValue(typeof(Font), DefaultTheme._Font)]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
            }
        }

        /// <summary>
        /// 获取或设置背景色
        /// </summary>
        [DefaultValue(typeof(Font), DefaultTheme._BackColor)]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }

        /// <summary>
        /// 获取或设置前景色
        /// </summary>
        [DefaultValue(typeof(Font), DefaultTheme._ForeColor)]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
            }
        }

        private State m_State;
        /// <summary>
        /// 获取状态
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
            return this.Enabled ? (this.Focused ? State.NormalFocused : State.Normal) : State.Disabled;
        }

        /// <summary>
        /// 启用状态改变
        /// </summary>
        /// <param name="e">数据</param>
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            this.State = this.GetState();
        }

        /// <summary>
        /// 获取焦点
        /// </summary>
        /// <param name="e">数据</param>
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            this.State = this.GetState();
        }

        /// <summary>
        /// 失去焦点
        /// </summary>
        /// <param name="e">数据</param>
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            this.State = this.GetState();
        }
    }
}
