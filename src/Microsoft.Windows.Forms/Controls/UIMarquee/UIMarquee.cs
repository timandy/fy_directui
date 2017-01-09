using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.Drawing;
using Microsoft.Windows.Forms.Animate;

namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// 跑马灯控件
    /// </summary>
    public class UIMarquee : UIControl
    {
        private const int DEFAULT_FRAME_INTERVAL = 10;                          //定时器间隔(毫秒)
        private Timer m_FrameTimer = new Timer();                               //动画定时器
        private UILinearAnimation m_Animation = new UILinearAnimation();        //动画对象


        private Color m_ProgressColor = DefaultTheme.LightTransparent;
        /// <summary>
        /// 获取或设置进度条颜色
        /// </summary>
        public virtual Color ProgressColor
        {
            get
            {
                return this.m_ProgressColor;
            }
            set
            {
                if (value != this.m_ProgressColor)
                {
                    this.m_ProgressColor = value;
                    this.Invalidate();
                }
            }
        }

        private Color m_BorderColor = DefaultTheme.LightLightTransparent;
        /// <summary>
        /// 获取或设置进度条边框颜色
        /// </summary>
        public virtual Color BorderColor
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

        private int m_ProgressLengthReal;//真实长度
        private float m_ProgressLength = 0.2F;
        /// <summary>
        /// 获取或设置进度深色长度0-1f
        /// </summary>
        public float ProgressLength
        {
            get
            {
                return this.m_ProgressLength;
            }
            set
            {
                if (value == this.m_ProgressLength)
                    return;
                this.m_ProgressLength = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// 获取或设置动画是否停止
        /// </summary>
        public bool Stopped
        {
            get { return this.m_FrameTimer.Enabled; }
            set
            {
                if (value != this.m_FrameTimer.Enabled)
                {
                    if (value)
                        this.Start();
                    else
                        this.Stop();
                }
            }
        }

        /// <summary>
        /// 获取或设置动画间隔,默认为2000ms
        /// </summary>
        public int AnimationSpan
        {
            get { return this.m_Animation.Span; }
            set { this.m_Animation.Span = value; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public UIMarquee()
        {
            this.BackColor = DefaultTheme.DarkDarkTransparent;
            this.m_FrameTimer.Interval = DEFAULT_FRAME_INTERVAL;
            this.m_FrameTimer.Tick += (sender, e) =>
            {
                this.Invalidate();
                if (this.m_Animation.Stopped)
                    this.m_Animation.Next();
            };
            this.m_Animation.Span = 2000;
            this.ResetAnimation();
        }

        /// <summary>
        /// 重置动画参数
        /// </summary>
        protected virtual void ResetAnimation()
        {
            Rectangle rect = RectangleEx.Subtract(this.ClientRectangle, this.Padding);
            Rectangle rcContent = RectangleEx.Subtract(rect, new Padding(1));
            int width = rcContent.Width;
            this.m_Animation.From = rcContent.Left;
            this.m_ProgressLengthReal = (int)(width * this.m_ProgressLength);
            this.m_Animation.To = width + this.m_ProgressLengthReal + 1;//要多一个像素
        }

        /// <summary>
        /// 触发大小改变事件
        /// </summary>
        /// <param name="e">数据</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.ResetAnimation();
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
            Rectangle rcContent = RectangleEx.Subtract(rect, new Padding(1));

            int left = rcContent.Left;
            int top = rcContent.Top;
            int height = rcContent.Height;
            int position = (int)this.m_Animation.Current;

            Rectangle rcMiddle = new Rectangle(position - this.m_ProgressLengthReal, top, this.m_ProgressLengthReal, height);
            Rectangle rcLeft = new Rectangle(left, top, rcMiddle.Left - left, height);
            Rectangle rcRight = new Rectangle(rcMiddle.Right, top, rect.Right - 1 - rcMiddle.Right, height);

            //渲染进度
            using (new ClipGraphics(g, rcContent, CombineMode.Intersect))
            {
                if (RectangleEx.IsVisible(rcLeft))
                {
                    this.Sprite.BorderVisibleStyle = BorderVisibleStyle.None;
                    this.Sprite.BackColor = this.BackColor;
                    this.Sprite.State = this.State;
                    this.Sprite.BeginRender(g);
                    this.Sprite.RenderBackColor(rcLeft);
                    this.Sprite.EndRender();
                }
                if (RectangleEx.IsVisible(rcMiddle))
                {
                    this.Sprite.BorderVisibleStyle = BorderVisibleStyle.None;
                    this.Sprite.BackColor = this.ProgressColor;
                    this.Sprite.State = this.State;
                    this.Sprite.BeginRender(g);
                    this.Sprite.RenderBackColor(rcMiddle);
                    this.Sprite.EndRender();
                }
                if (RectangleEx.IsVisible(rcRight))
                {
                    this.Sprite.BorderVisibleStyle = BorderVisibleStyle.None;
                    this.Sprite.BackColor = this.BackColor;
                    this.Sprite.State = this.State;
                    this.Sprite.BeginRender(g);
                    this.Sprite.RenderBackColor(rcRight);
                    this.Sprite.EndRender();
                }
            }

            //渲染边框
            this.Sprite.BorderVisibleStyle = BorderVisibleStyle.All;
            this.Sprite.BorderColor = this.BorderColor;
            this.Sprite.BeginRender(g);
            this.Sprite.RenderBorder(rect);
            this.Sprite.EndRender();
        }

        /// <summary>
        /// 开始动画
        /// </summary>
        public virtual void Start()
        {
            this.m_Animation.Next();
            this.m_FrameTimer.Start();
        }

        /// <summary>
        /// 停止动画
        /// </summary>
        public virtual void Stop()
        {
            this.m_Animation.Stop();
            this.m_FrameTimer.Stop();
            this.Invalidate();
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="disposing">释放托管资源为true,否则为false</param>
        protected override void Dispose(bool disposing)
        {
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
