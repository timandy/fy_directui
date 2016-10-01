using System;
using System.ComponentModel;

namespace Microsoft.Windows.Forms
{
    partial class UIWinControl
    {
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
