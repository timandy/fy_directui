
namespace Microsoft.Windows.Forms
{
    public partial class Sprite
    {
        private bool m_AutoFeedback = false;
        /// <summary>
        /// 是否自动反馈到Owner
        /// </summary>
        public bool AutoFeedback
        {
            get
            {
                return this.m_AutoFeedback;
            }
            set
            {
                if (value != this.m_AutoFeedback)
                {
                    this.m_AutoFeedback = value;
                }
            }
        }

        private IUIControl m_Owner;
        /// <summary>
        /// 父控件
        /// </summary>
        public IUIControl Owner
        {
            get
            {
                return this.m_Owner;
            }
        }

        /// <summary>
        /// 反馈方法,非强制
        /// </summary>
        public void Feedback()
        {
            this.Feedback(false);
        }

        /// <summary>
        /// 反馈方法
        /// </summary>
        /// <param name="force">是否强制反馈</param>
        public void Feedback(bool force)
        {
            if (this.m_Owner != null && (force || this.m_AutoFeedback))
                this.m_Owner.Invalidate();
        }
    }
}
