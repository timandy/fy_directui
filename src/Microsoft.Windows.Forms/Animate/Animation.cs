using System;

namespace Microsoft.Windows.Forms.Animate
{
    /// <summary>
    /// 动画
    /// </summary>
    /// <typeparam name="T">动画类型</typeparam>
    public abstract class Animation<T> : DisposableMini, IAnimation<T>
    {
        /// <summary>
        /// 标识动画停止的百分比
        /// </summary>
        protected const double STOPPED = 1d;

        private bool m_Stopped = true;
        /// <summary>
        /// 获取动画是否已停止
        /// </summary>
        public virtual bool Stopped
        {
            get
            {
                return this.m_Stopped;
            }
        }

        private DateTime m_StartTime;
        /// <summary>
        /// 获取动画开始时间
        /// </summary>
        public virtual DateTime StartTime
        {
            get
            {
                return this.m_StartTime;
            }
        }

        private TimeSpan m_Span;
        /// <summary>
        /// 获取或设置动画执行时间段,毫秒
        /// </summary>
        public virtual int Span
        {
            get
            {
                return (int)this.m_Span.TotalMilliseconds;
            }
            set
            {
                this.m_Span = new TimeSpan(0, 0, 0, 0, value);
            }
        }

        /// <summary>
        /// 获取当前帧
        /// </summary>
        public abstract T Current
        {
            get;
        }

        /// <summary>
        /// 获取动画完成百分比,如果等于 1 标志已结束
        /// </summary>
        protected virtual double Percentage
        {
            get
            {
                if (this.m_Stopped)
                    return STOPPED;
                DateTime now = DateTime.Now;
                if (now >= this.m_StartTime + this.m_Span)
                {
                    this.m_Stopped = true;
                    return STOPPED;
                }
                return (now - this.m_StartTime).TotalMilliseconds / this.m_Span.TotalMilliseconds;
            }
        }

        /// <summary>
        /// 开始动画
        /// </summary>
        protected virtual void Start()
        {
            this.m_Stopped = false;
            this.m_StartTime = DateTime.Now;
        }

        /// <summary>
        /// 停止动画
        /// </summary>
        protected virtual void Stop()
        {
            this.m_Stopped = true;
        }
    }
}
