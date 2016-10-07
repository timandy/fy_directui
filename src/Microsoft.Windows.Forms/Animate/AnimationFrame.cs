using System;
using System.Drawing;

namespace Microsoft.Windows.Forms.Animate
{
    /// <summary>
    /// 动画帧
    /// </summary>
    internal sealed class AnimationFrame : DisposableMini
    {
        private AnimationFrameType m_FrameType;
        /// <summary>
        /// 获取帧类型
        /// </summary>
        public AnimationFrameType FrameType
        {
            get
            {
                return this.m_FrameType;
            }
        }

        private object m_Value;
        /// <summary>
        /// 帧值,通常为图片或颜色
        /// </summary>
        public object Value
        {
            get
            {
                return this.m_Value;
            }
        }

        /// <summary>
        /// 创建一个随机的颜色帧
        /// </summary>
        public AnimationFrame()
            : this(RenderEngine.RandomColor())
        {
        }

        /// <summary>
        /// 创建一个颜色帧
        /// </summary>
        /// <param name="color">颜色</param>
        public AnimationFrame(Color color)
        {
            this.m_Value = color;
            this.m_FrameType = AnimationFrameType.Color;
        }

        /// <summary>
        /// 创建一个图像帧
        /// </summary>
        /// <param name="image">图像</param>
        public AnimationFrame(Image image)
        {
            this.m_Value = image;
            this.m_FrameType = AnimationFrameType.Image;
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="disposing">释放托管资源为true,否则为false</param>
        protected override void Dispose(bool disposing)
        {
            if (this.m_Value != null)
            {
                IDisposable disposable = this.m_Value as IDisposable;
                if (disposable != null)
                    disposable.Dispose();
                this.m_Value = null;
            }
        }
    }
}
