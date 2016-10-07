using System;

namespace Microsoft.Windows.Forms.Animate
{
    /// <summary>
    /// 动画接口
    /// </summary>
    /// <typeparam name="T">动画元素类型</typeparam>
    public interface IAnimation<T>
    {
        /// <summary>
        /// 获取动画是否已停止
        /// </summary>
        bool Stopped
        {
            get;
        }

        /// <summary>
        /// 获取动画开始时间
        /// </summary>
        DateTime StartTime
        {
            get;
        }

        /// <summary>
        /// 获取或设置动画执行时间段,毫秒
        /// </summary>
        int Span
        {
            get;
            set;
        }

        /// <summary>
        /// 获取当前帧
        /// </summary>
        T Current
        {
            get;
        }
    }
}
