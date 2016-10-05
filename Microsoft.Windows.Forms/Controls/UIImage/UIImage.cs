using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Drawing;
using Microsoft.Windows.Forms.Animate;

namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// 图片动画控件
    /// </summary>
    public class UIImage : UIControl
    {
        internal const int DEFAULT_ANIMATION_INTERVAL = 8000;           //默认动画触发时间间隔
        internal const int DEFAULT_FRAME_INTERVAL = 40;                 //默认帧间隔
        private UIImageAnimation m_Animation = new UIImageAnimation();  //图片动画
        private Timer m_AnimationTimer = new Timer();                   //动画触发定时器
        private Timer m_FrameTimer = new Timer();                       //帧定时器

        /// <summary>
        /// 获取或设置动画触发时间间隔,毫秒
        /// </summary>
        public int AnimationInterval
        {
            get
            {
                return this.m_AnimationTimer.Interval;
            }
            set
            {
                this.m_AnimationTimer.Interval = value;
            }
        }

        /// <summary>
        /// 获取或设置动画执行时间,毫秒
        /// </summary>
        public int AnimationSpan
        {
            get
            {
                return this.m_Animation.Span;
            }
            set
            {
                this.m_Animation.Span = value;
            }
        }

        /// <summary>
        /// 获取或设置动画是否随机
        /// </summary>
        public bool AnimationRandom
        {
            get
            {
                return this.m_Animation.RandomPlay;
            }
            set
            {
                this.m_Animation.RandomPlay = value;
            }
        }

        private Color m_BorderColor = DefaultTheme.BorderColor;
        /// <summary>
        /// 获取或设置边框颜色
        /// </summary>
        public Color BorderColor
        {
            get
            {
                return this.m_BorderColor;
            }
            set
            {
                if (value != this.m_BorderColor)
                {
                    this.m_BorderColor = value;
                    this.Invalidate();
                }
            }
        }

        private BorderVisibleStyle m_BorderVisibleStyle;
        /// <summary>
        /// 获取或设置边框样式
        /// </summary>
        public BorderVisibleStyle BorderVisibleStyle
        {
            get
            {
                return this.m_BorderVisibleStyle;
            }
            set
            {
                if (value != this.m_BorderVisibleStyle)
                {
                    this.m_BorderVisibleStyle = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public UIImage()
        {
            //初始化触发定时器
            this.m_AnimationTimer.Interval = DEFAULT_ANIMATION_INTERVAL;
            this.m_AnimationTimer.Tick += (sender, e) =>
            {
                this.m_FrameTimer.Start();
                this.m_Animation.Next();
            };
            //初始化帧定时器
            this.m_FrameTimer.Interval = DEFAULT_FRAME_INTERVAL;
            this.m_FrameTimer.Tick += (sender, e) =>
            {
                this.Invalidate();
                if (this.m_Animation.Stopped)
                    this.m_FrameTimer.Stop();
            };
            //启动触发定时器
            this.m_AnimationTimer.Start();
        }

        /// <summary>
        /// 添加一个图像帧
        /// </summary>
        /// <param name="image">图像</param>
        public void AddFrame(Image image)
        {
            this.m_Animation.AddFrame(image);
        }

        /// <summary>
        /// 添加一个颜色帧
        /// </summary>
        /// <param name="color">颜色</param>
        public void AddFrame(Color color)
        {
            this.m_Animation.AddFrame(color);
        }

        /// <summary>
        /// 添加一个随机颜色帧
        /// </summary>
        public void AddFrame()
        {
            this.m_Animation.AddFrame();
        }

        /// <summary>
        /// 清空帧
        /// </summary>
        public void ClearFrame()
        {
            this.m_Animation.ClearFrame();
        }

        /// <summary>
        /// 渲染控件
        /// </summary>
        /// <param name="e">数据</param>
        protected override void RenderSelf(PaintEventArgs e)
        {
            //准备
            Graphics g = e.Graphics;
            Rectangle rect = RectangleEx.Subtract(this.ClientRectangle, this.Padding);
            //渲染
            this.Sprite.BackgroundImage = this.m_Animation.Current;
            this.Sprite.BackgroundImageLayout = ImageLayout.None;
            this.Sprite.BorderColor = this.BorderColor;
            this.Sprite.BorderVisibleStyle = this.BorderVisibleStyle;
            this.Sprite.State = this.State;
            this.Sprite.BeginRender(g);
            this.Sprite.RenderBackgroundImage(rect);
            this.Sprite.RenderBorder(rect);
            this.Sprite.EndRender();
        }

        /// <summary>
        /// 大小改变
        /// </summary>
        /// <param name="e">数据</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.m_Animation.Size = this.Size - this.Padding.Size;
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="disposing">释放托管资源为true,否则为false</param>
        protected override void Dispose(bool disposing)
        {
            if (this.m_AnimationTimer != null)
            {
                this.m_AnimationTimer.Dispose();
                this.m_AnimationTimer = null;
            }
            if (this.m_FrameTimer != null)
            {
                this.m_FrameTimer.Dispose();
                this.m_FrameTimer = null;
            }
            if (this.m_Animation != null)
            {
                this.m_Animation.Dispose();
                this.m_Animation = null;
            }
            base.Dispose(disposing);
        }
    }
}
