using System.Drawing;
using System.Windows.Forms;
using Microsoft.Drawing;

namespace Microsoft.Windows.Forms
{
    partial class UIControl
    {
        private Sprite m_Sprite;
        /// <summary>
        /// 获取精灵
        /// </summary>
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

        private int m_UpdateSuspendCount;
        /// <summary>
        /// 挂起刷新 UI
        /// </summary>
        public void BeginUpdate()
        {
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
            this.Invalidate(forceUpdate);
        }

        /// <summary>
        /// 使控件工作区无效
        /// </summary>
        public void Invalidate()
        {
            this.Invalidate(false);
        }

        /// <summary>
        /// 使控件矩形无效
        /// </summary>
        /// <param name="rc">无效矩形</param>
        public void Invalidate(Rectangle rc)
        {
            this.Invalidate(rc, false);
        }

        /// <summary>
        /// 使控件工作区无效,可以选择是否强制更新
        /// </summary>
        /// <param name="forceUpdate">强制更新为 true,否则为false</param>
        protected void Invalidate(bool forceUpdate)
        {
            this.Invalidate(this.ClientRectangle, forceUpdate);
        }

        /// <summary>
        /// 使控件矩形无效,可以选择是否强制更新
        /// </summary>
        /// <param name="rc">无效矩形</param>
        /// <param name="forceUpdate">强制更新为 true,否则为false</param>
        protected void Invalidate(Rectangle rc, bool forceUpdate)
        {
            if (forceUpdate || this.m_UpdateSuspendCount == 0)
            {
                IUIControl parent = this;
                IUIWindow window = null;
                while (parent != null && (window = parent as IUIWindow) == null)
                {
                    rc.Offset(parent.Left, parent.Top);
                    parent = parent.UIParent;
                }
                if (window == null)
                    return;
                window.Invalidate(rc);
            }
        }

        /// <summary>
        /// 重绘所在 Win32 窗口的无效区域
        /// </summary>
        public void Update()
        {
            this.Update(false);
        }

        /// <summary>
        /// 重绘所在 Win32 窗口的无效区域,可以选择是否强制更新
        /// </summary>
        /// <param name="forceUpdate">强制更新为 true,否则为false</param>
        protected void Update(bool forceUpdate)
        {
            if (forceUpdate || this.m_UpdateSuspendCount == 0)
            {
                IUIControl parent = this;
                IUIWindow window = null;
                while (parent != null && (window = parent as IUIWindow) == null)
                    parent = parent.UIParent;
                if (window == null)
                    return;
                window.Update();
            }
        }

        /// <summary>
        /// 立即刷新所在 Win32 窗口
        /// </summary>
        public void Refresh()
        {
            this.Refresh(false);
        }

        /// <summary>
        /// 立即刷新所在 Win32 窗口,可以选择是否强制更新
        /// </summary>
        /// <param name="forceUpdate">强制更新为 true,否则为false</param>
        protected void Refresh(bool forceUpdate)
        {
            if (forceUpdate || this.m_UpdateSuspendCount == 0)
            {
                IUIControl parent = this;
                IUIWindow window = null;
                Rectangle rc = this.ClientRectangle;
                while (parent != null && (window = parent as IUIWindow) == null)
                {
                    rc.Offset(parent.Left, parent.Top);
                    parent = parent.UIParent;
                }
                if (window == null)
                    return;
                window.Invalidate(rc);
                window.Update();
            }
        }
    }
}
