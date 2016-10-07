using System.Windows.Forms;
using Microsoft.Win32;

namespace Microsoft.Windows.Forms
{
    partial class UIForm
    {
        private UIControl m_CaptureControl;
        /// <summary>
        /// 获取捕获鼠标消息的虚拟控件
        /// </summary>
        protected UIControl CaptureControl
        {
            get
            {
                return m_CaptureControl;
            }
            set
            {
                if (value != this.m_CaptureControl)
                {
                    if (this.m_CaptureControl != null)
                        this.m_CaptureControl.Capture = false;
                    this.m_CaptureControl = value;
                    if (this.m_CaptureControl != null)
                        this.m_CaptureControl.Capture = true;
                }
            }
        }

        /// <summary>
        /// 消息处理
        /// </summary>
        /// <param name="m">消息</param>
        protected override void WndProc(ref Message m)
        {
            this.DispatchMessage(ref m);
            if (m.Result == NativeMethods.TRUE)
                return;
            base.WndProc(ref m);
        }

        /// <summary>
        /// 分派消息
        /// </summary>
        /// <param name="m">消息</param>
        protected virtual void DispatchMessage(ref Message m)
        {
            switch (m.Msg)
            {
                //左键按下
                case NativeMethods.WM_LBUTTONDOWN:
                case NativeMethods.WM_LBUTTONDBLCLK:
                    this.WmLButtonDown(ref m);
                    break;

                //左键弹起
                case NativeMethods.WM_LBUTTONUP:
                    this.WmLButtonUp(ref m);
                    break;

                //鼠标移动
                case NativeMethods.WM_MOUSEMOVE:
                    this.WmMouseMove(ref m);
                    break;

                //鼠标离开
                case NativeMethods.WM_MOUSELEAVE:
                    this.WmMouseLeave(ref m);
                    break;
            }
        }

        /// <summary>
        /// 处理鼠标左键按下消息
        /// </summary>
        /// <param name="m">消息</param>
        protected virtual void WmLButtonDown(ref Message m)
        {
            UIControl control = this.FindUIChild(Util.GetMousePosition(m.LParam));
            this.CaptureControl = control = (control != null && control.Enabled) ? control : null;
            if (control != null)
            {
                control.WndProc(ref m);
                m.Result = NativeMethods.TRUE;
            }
        }

        /// <summary>
        /// 处理鼠标左键弹起消息
        /// </summary>
        /// <param name="m">消息</param>
        protected virtual void WmLButtonUp(ref Message m)
        {
            UIControl lastAccess = this.CaptureControl;
            UIControl control = this.FindUIChild(Util.GetMousePosition(m.LParam));
            this.CaptureControl = control = (control != null && control.Enabled) ? control : null;
            if (control == lastAccess && control != null)
            {
                control.WndProc(ref m);
                m.Result = NativeMethods.TRUE;
            }
        }

        /// <summary>
        /// 处理鼠标移动消息
        /// </summary>
        /// <param name="m">消息</param>
        protected virtual void WmMouseMove(ref Message m)
        {
            if ((Control.MouseButtons & MouseButtons.Left) == MouseButtons.None)//未按下左键
            {
                this.WmLButtonDown(ref m);
            }
            else//左键按下
            {
                UIControl lastAccess = this.CaptureControl;
                if (lastAccess != null)
                {
                    lastAccess.WndProc(ref m);
                    m.Result = NativeMethods.TRUE;
                }
            }
        }

        /// <summary>
        /// 处理鼠标移开消息
        /// </summary>
        /// <param name="m">消息</param>
        protected virtual void WmMouseLeave(ref Message m)
        {
            this.CaptureControl = null;
        }
    }
}
