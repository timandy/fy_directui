using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Drawing;
using Microsoft.Windows.Forms.Animate;

namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// 虚拟进度条控件
    /// </summary>
    public class UIProgress : UIControl
    {
        private const int DEFAULT_FRAME_INTERVAL = 10;                          //定时器间隔(毫秒)
        private Timer m_FrameTimer = new Timer();                               //动画定时器
        private UIProgressAnimation m_Animation = new UIProgressAnimation();    //动画对象

        private Color m_ProgressColor = DefaultTheme.LightLightTransparent;
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

        private int m_Percentage = 0;
        /// <summary>
        /// 获取或设置进度条颜色
        /// </summary>
        public virtual int Percentage
        {
            get
            {
                return this.m_Percentage;
            }
            set
            {
                if (value != this.m_Percentage)
                {
                    this.m_Percentage = value;
                    this.m_FrameTimer.Start();
                    this.m_Animation.Next(this.m_Percentage);
                }
            }
        }

        /// <summary>
        /// 获取状态
        /// </summary>
        public override State State
        {
            get
            {
                return base.State == State.Disabled ? State.Disabled : State.Normal;
            }
            protected set
            {
                base.State = value;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public UIProgress()
        {
            this.BackColor = DefaultTheme.DarkDarkTransparent;
            this.m_FrameTimer.Interval = DEFAULT_FRAME_INTERVAL;
            this.m_FrameTimer.Tick += (sender, e) =>
            {
                this.Invalidate();
                if (this.m_Animation.Stopped)
                    this.m_FrameTimer.Stop();
            };
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
            //已完成进度
            int maxWidth = rect.Width - 2;
            int width = (int)(maxWidth * this.m_Animation.Current / 100d);
            Rectangle rcProgress = new Rectangle(rect.Left + 1, rect.Top + 1, Math.Min(width, maxWidth), rect.Height - 2);
            //未完成进度
            Rectangle rcBlank = new Rectangle(rcProgress.Right, rcProgress.Top, rect.Width - 2 - rcProgress.Width, rcProgress.Height);
            //渲染已完成进度
            this.Sprite.BorderVisibleStyle = BorderVisibleStyle.None;
            this.Sprite.BackColor = this.ProgressColor;
            this.Sprite.State = this.State;
            this.Sprite.BeginRender(g);
            this.Sprite.RenderBackColor(rcProgress);
            this.Sprite.EndRender();
            //渲染未完成进度
            this.Sprite.BackColor = this.BackColor;
            this.Sprite.BeginRender(g);
            this.Sprite.RenderBackColor(rcBlank);
            this.Sprite.EndRender();
            //渲染边框
            this.Sprite.BorderVisibleStyle = BorderVisibleStyle.All;
            this.Sprite.BorderColor = this.BorderColor;
            this.Sprite.BeginRender(g);
            this.Sprite.RenderBorder(rect);
            this.Sprite.EndRender();
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
