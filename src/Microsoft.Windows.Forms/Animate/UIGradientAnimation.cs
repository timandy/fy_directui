using System;
using Microsoft.Windows.Forms.Animate;

namespace Microsoft.Windows
{
    /// <summary>
    /// 两段渐进动画动画
    /// </summary>
    public sealed class UIGradientAnimation : Animation<float>
    {
        private const float ANIMATION_DURATION = 500;                                                  //动画持续时间(毫秒)
        private const float FIRST_TIME = 0.5f * ANIMATION_DURATION;                                    //第一段时间(毫秒)
        private const float FIRST_PERCENT = 0.875f;                                                    //第一段百分比
        private const float SECOND_TIME = ANIMATION_DURATION - FIRST_TIME;                             //第二段时间(毫秒)
        private const float SECOND_PERCENT = 1f - FIRST_PERCENT;                                       //第二段百分比

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

        /// <summary>
        /// 构造函数
        /// </summary>
        public UIGradientAnimation()
        {
        }

        /// <summary>
        /// 获取当前滑动距离
        /// </summary>
        public override float Current
        {
            get
            {
                float distance = this.m_To - this.m_From;
                float escaped = (float)(DateTime.Now - this.StartTime).TotalMilliseconds;
                if (escaped < FIRST_TIME)//公式 第一段时间/第一段距离=流逝时间/移动距离
                    return this.m_From + escaped / FIRST_TIME * distance * FIRST_PERCENT;
                if (escaped < ANIMATION_DURATION)//公式 第二段时间/第二段距离=(流逝时间-第一段时间)/(移动距离-第一段距离)
                    return this.m_From + (escaped - FIRST_TIME) / SECOND_TIME * distance * SECOND_PERCENT + distance * FIRST_PERCENT;
                this.Stop();
                return this.m_To;
            }
        }

        /// <summary>
        /// 重新开始动画
        /// </summary>
        public void Next()
        {
            base.Start();
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="disposing">释放托管资源为true,否则为false</param>
        protected override void Dispose(bool disposing)
        {
        }
    }
}
