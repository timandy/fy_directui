using System;

namespace Microsoft.Windows.Forms
{
    public partial class Sprite
    {
        /// <summary>
        /// 状态改变事件索引标记
        /// </summary>
        private static readonly object EVENT_STATE_CHANGED = new object();

        private State m_State = State.Normal;
        /// <summary>
        /// 按钮状态
        /// </summary>
        public State State
        {
            get
            {
                return this.m_State;
            }
            set
            {
                if (value != this.m_State)
                {
                    this.m_State = value;
                    this.Feedback();
                    this.OnStateChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// 按钮状态改变后发生
        /// </summary>
        public event EventHandler StateChanged
        {
            add { this.Events.AddHandler(EVENT_STATE_CHANGED, value); }
            remove { this.Events.RemoveHandler(EVENT_STATE_CHANGED, value); }
        }

        /// <summary>
        /// 按钮状态改变事件函数
        /// </summary>
        /// <param name="e">数据</param>
        protected virtual void OnStateChanged(EventArgs e)
        {
            EventHandler handler = this.Events[EVENT_STATE_CHANGED] as EventHandler;
            if (handler != null)
                handler(this, e);
        }
    }
}
