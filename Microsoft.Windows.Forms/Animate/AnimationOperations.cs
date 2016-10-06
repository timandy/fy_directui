using System.Collections.Generic;
using System.Drawing;

namespace Microsoft.Windows.Forms.Animate
{
    /// <summary>
    /// 动画操作集合
    /// </summary>
    internal class AnimationOperations : DisposableMini
    {
        //操作集合
        private List<AnimationFrame> m_Frames = new List<AnimationFrame>();

        private bool m_Cleared;
        /// <summary>
        /// 获取是否清空关键帧
        /// </summary>
        public bool Cleared
        {
            get
            {
                return this.m_Cleared;
            }
        }

        private Size? m_Size;
        /// <summary>
        /// 获取要改变的大小
        /// </summary>
        public Size Size
        {
            get
            {
                return this.m_Size.Value;
            }
        }

        /// <summary>
        /// 获取是否要改变大小
        /// </summary>
        public bool Resized
        {
            get
            {
                return this.m_Size != null;
            }
        }

        /// <summary>
        /// 改变大小操作
        /// </summary>
        /// <param name="size">要改变的大小</param>
        public void Resize(Size size)
        {
            this.m_Size = size;
        }

        /// <summary>
        /// 添加关键帧操作
        /// </summary>
        /// <param name="frame">关键帧</param>
        public void AddFrame(AnimationFrame frame)
        {
            this.m_Frames.Add(frame);
        }

        /// <summary>
        /// 清空关键帧操作
        /// </summary>
        public void ClearFrame()
        {
            foreach (AnimationFrame frame in this.m_Frames)
                frame.Dispose();
            this.m_Frames.Clear();
            this.m_Cleared = true;
        }

        /// <summary>
        /// 使用完毕,清空操作
        /// </summary>
        public void Clear()
        {
            this.m_Frames.Clear();
            this.m_Cleared = false;
            this.m_Size = null;
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="disposing">释放托管资源为 true,否则为 false</param>
        protected override void Dispose(bool disposing)
        {
            if (this.m_Frames != null)
            {
                foreach (AnimationFrame frame in this.m_Frames)
                    frame.Dispose();
                this.m_Frames.Clear();
                this.m_Frames = null;
            }
        }
    }
}
