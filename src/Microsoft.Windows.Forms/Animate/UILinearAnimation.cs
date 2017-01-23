namespace Microsoft.Windows.Forms.Animate
{
    /// <summary>
    /// 线性动画
    /// </summary>
    public sealed class UILinearAnimation : Animation<float>
    {
        /// <summary>
        /// 默认动画执行时间
        /// </summary>
        public const int DEFAULT_ANIMATION_SPAN = 200;

        private float m_From;
        /// <summary>
        /// 获取或设置起点
        /// </summary>
        public float From
        {
            get { return this.m_From; }
            set { this.m_From = value; }
        }

        private float m_To;
        /// <summary>
        /// 获取或设置终点
        /// </summary>
        public float To
        {
            get { return this.m_To; }
            set { this.m_To = value; }
        }

        private float m_Current;
        /// <summary>
        /// 获取动画当前帧
        /// </summary>
        public override float Current
        {
            get
            {
                if (this.m_From >= this.m_To)
                {
                    this.Stop();
                    return this.m_Current = this.m_To;
                }
                double percentage = this.Percentage;
                return this.m_Current = (percentage == STOPPED ? this.m_To : (float)(this.m_From + (this.m_To - this.m_From) * percentage));
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public UILinearAnimation()
        {
            base.Span = DEFAULT_ANIMATION_SPAN;
        }

        /// <summary>
        /// 继续动画
        /// </summary>
        /// <param name="to">终点</param>
        public void Continue(float to)
        {
            this.m_From = this.m_Current;
            this.m_To = to;
            this.Start();
        }

        /// <summary>
        /// 重新开始动画
        /// </summary>
        public void Next()
        {
            base.Start();
        }

        /// <summary>
        /// 停止动画
        /// </summary>
        public new void Stop()
        {
            base.Stop();
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="disposing">释放托管资源为 true,否则为 false</param>
        protected override void Dispose(bool disposing)
        {
        }
    }
}
