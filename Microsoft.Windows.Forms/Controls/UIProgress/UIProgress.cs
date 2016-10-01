using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Drawing;

namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// 虚拟进度条控件
    /// </summary>
    public class UIProgress : UIControl
    {
        private const int ANIMATION_INTERVAL = 10;          //定时器间隔(毫秒)
        private const int ANIMATION_SPAN = 200;             //动画时间(毫秒)
        private Timer m_Timer = new Timer();                //动画定时器
        private Animation m_Animation = new Animation();    //动画对象


        private Color m_ProgressColor = Color.DodgerBlue;
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

        private Color m_BorderColor = Color.DodgerBlue;
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
                    this.m_Timer.Start();
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
            this.m_Timer.Interval = ANIMATION_INTERVAL;
            this.m_Timer.Tick += (sender, e) =>
            {
                if (this.m_Animation.Last == this.m_Percentage)
                    this.m_Timer.Stop();
                else
                    this.Invalidate();
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
            int width = (int)(maxWidth * this.m_Animation.Current / 100m);
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
            if (this.m_Timer != null)
            {
                this.m_Timer.Dispose();
                this.m_Timer = null;
            }
            this.m_Animation = null;
            base.Dispose(disposing);
        }


        #region 内部类

        /// <summary>
        /// 动画
        /// </summary>
        private class Animation
        {
            private DateTime m_StartTime;
            /// <summary>
            /// 开始时间
            /// </summary>
            public DateTime StartTime
            {
                get
                {
                    return this.m_StartTime;
                }
            }

            private int m_From;
            /// <summary>
            /// 起始百分比
            /// </summary>
            public int Form
            {
                get
                {
                    return this.m_From;
                }
            }

            private int m_To;
            /// <summary>
            /// 截止百分比
            /// </summary>
            public int To
            {
                get
                {
                    return this.m_To;
                }
            }

            private int m_Last;
            /// <summary>
            /// 获取上次百分比
            /// </summary>
            public int Last
            {
                get
                {
                    return this.m_Last;
                }
            }

            /// <summary>
            /// 当前显示百分比
            /// </summary>
            public int Current
            {
                get
                {
                    if (this.m_From >= this.m_To)
                        return this.m_Last = this.m_To;
                    int current = this.m_From + (this.m_To - this.m_From) * (int)(DateTime.Now - this.m_StartTime).TotalMilliseconds / ANIMATION_SPAN;
                    return this.m_Last = current > this.m_To ? this.m_To : current;
                }
            }

            /// <summary>
            /// 下一个动画开始
            /// </summary>
            /// <param name="to">截止百分比</param>
            public void Next(int to)
            {
                this.m_From = this.m_Last;
                this.m_To = to;
                this.m_StartTime = DateTime.Now;
            }
        }

        #endregion
    }
}
