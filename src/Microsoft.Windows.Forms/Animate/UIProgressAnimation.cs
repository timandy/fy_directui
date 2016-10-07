namespace Microsoft.Windows.Forms.Animate
{
    /// <summary>
    /// 进度条动画
    /// </summary>
    public sealed class UIProgressAnimation : Animation<float>
    {
        /// <summary>
        /// 默认动画执行时间
        /// </summary>
        public const int DEFAULT_ANIMATION_SPAN = 200;

        private float m_From;                                   //起点
        private float m_To;                                     //终点

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
        public UIProgressAnimation()
        {
            base.Span = DEFAULT_ANIMATION_SPAN;
        }

        /// <summary>
        /// 开始下一个动画
        /// </summary>
        /// <param name="to">终点</param>
        public void Next(float to)
        {
            this.m_From = this.m_Current;
            this.m_To = to;
            this.Start();
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
