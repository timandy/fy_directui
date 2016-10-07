using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Drawing;
using Microsoft.Win32;

namespace Microsoft.Windows.Forms
{
    partial class UIWinControl
    {
        private Sprite m_Sprite;
        /// <summary>
        /// 获取精灵
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual Sprite Sprite
        {
            get
            {
                this.CheckDisposed();
                if (this.m_Sprite == null)
                    this.m_Sprite = new Sprite(this);
                return this.m_Sprite;
            }
        }

        private DoubleBufferedGraphics m_DoubleBufferedGraphics;
        /// <summary>
        /// 双缓冲接口
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        DoubleBufferedGraphics IUIWindow.DoubleBufferedGraphics
        {
            get
            {
                this.CheckDisposed();
                if (this.m_DoubleBufferedGraphics == null)
                    this.m_DoubleBufferedGraphics = new DoubleBufferedGraphics(this);
                return this.m_DoubleBufferedGraphics;
            }
        }

        private int m_UpdateSuspendCount;
        /// <summary>
        /// 获取布局操作是否被挂起
        /// </summary>
        public bool UpdateSuspended
        {
            get
            {
                return this.m_UpdateSuspendCount != 0;
            }
        }

        /// <summary>
        /// 渲染控件
        /// </summary>
        /// <param name="e">数据</param>
        protected virtual void RenderSelf(PaintEventArgs e)
        {
            //准备
            Graphics g = e.Graphics;
            Rectangle rect = this.ClientRectangle;
            //渲染
            this.Sprite.BackColor = this.BackColor;
            this.Sprite.BeginRender(g);
            this.Sprite.RenderBackColor(rect);
            this.Sprite.RenderBorder(rect);
            this.Sprite.EndRender();
        }

        /// <summary>
        /// 渲染子控件
        /// </summary>
        /// <param name="e">数据</param>
        protected virtual void RenderChildren(PaintEventArgs e)
        {
            foreach (IUIControl control in this.UIControls)
            {
                if (control.Visible)
                    using (new TranslateGraphics(e.Graphics, control.Location))
                        control.RenderCore(e);
            }
        }

        /// <summary>
        /// 渲染控件和子控件
        /// </summary>
        /// <param name="e">数据</param>
        void IUIControl.RenderCore(PaintEventArgs e)
        {
            this.RenderSelf(e);
            this.OnRender(e);
            this.RenderChildren(e);
        }

        /// <summary>
        /// 挂起刷新 UI
        /// </summary>
        public void BeginUpdate()
        {
            if (this.m_UpdateSuspendCount == 0 && this.Visible)
                Util.BeginUpdate(this.Handle);
            this.m_UpdateSuspendCount++;
        }

        /// <summary>
        /// 恢复刷新 UI
        /// </summary>
        public void EndUpdate()
        {
            this.EndUpdate(false);
        }

        /// <summary>
        /// 恢复刷新 UI,可以选择强制刷新
        /// </summary>
        /// <param name="forceUpdate">若要执行刷新为 true,否则为 false</param>
        public void EndUpdate(bool forceUpdate)
        {
            this.m_UpdateSuspendCount--;
            if (!this.UpdateSuspended)
            {
                if (this.Visible)
                {
                    Util.EndUpdate(this.Handle);
                    this.Refresh();
                }
            }
            else if (forceUpdate)
            {
                if (this.Visible)
                {
                    Util.EndUpdate(this.Handle);
                    this.Refresh();
                    Util.BeginUpdate(this.Handle);
                }
            }
        }

        /// <summary>
        /// 处理重绘事件
        /// </summary>
        /// <param name="e">数据</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            PaintManager.OnPaint(this, e);
        }
    }
}
