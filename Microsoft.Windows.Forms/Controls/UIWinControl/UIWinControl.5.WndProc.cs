using System.Windows.Forms;
using Microsoft.Win32;

namespace Microsoft.Windows.Forms
{
    partial class UIWinControl
    {
        /// <summary>
        /// 消息处理
        /// </summary>
        /// <param name="m">消息</param>
        protected override void WndProc(ref Message m)
        {
            if (this.DispatchMessage(ref m))
            {
                m.Result = NativeMethods.TRUE;
                return;
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// 分派消息
        /// </summary>
        /// <param name="m">消息</param>
        /// <returns>已处理返回true,否则返回false</returns>
        protected virtual bool DispatchMessage(ref Message m)
        {
            UIControl lastAccess = PaintManager.CaptureControl;
            UIControl control;
            switch (m.Msg)
            {
                //左键按下
                case NativeMethods.WM_LBUTTONDOWN:
                case NativeMethods.WM_LBUTTONDBLCLK:
                    if (lastAccess == null)
                    {
                        control = this.FindUIChild(Util.GetMousePosition(m.LParam));
                        if (control != null && control.Enabled)
                        {
                            control.Capture = true;
                            control.WndProc(ref m);
                            return true;
                        }
                    }
                    else
                    {
                        lastAccess.Capture = false;
                        control = this.FindUIChild(Util.GetMousePosition(m.LParam));
                        if (control != null && control.Enabled)
                        {
                            control.Capture = true;
                            control.WndProc(ref m);
                            return true;
                        }
                    }
                    break;

                //左键弹起
                case NativeMethods.WM_LBUTTONUP:
                    if (lastAccess != null)
                        lastAccess.WndProc(ref m);
                    break;

                //鼠标移动
                case NativeMethods.WM_MOUSEMOVE:
                    if ((Control.MouseButtons & MouseButtons.Left) == MouseButtons.None)//未按下左键
                    {
                        if (lastAccess == null)//上次为空
                        {
                            control = this.FindUIChild(Util.GetMousePosition(m.LParam));
                            if (control != null && control.Enabled)
                            {
                                control.Capture = true;
                                control.WndProc(ref m);
                                return true;
                            }
                        }
                        else//上次不为空
                        {
                            control = this.FindUIChild(Util.GetMousePosition(m.LParam));
                            if (control == lastAccess)
                            {
                                control.WndProc(ref m);
                                return true;
                            }
                            else
                            {
                                lastAccess.Capture = false;
                                if (control != null && control.Enabled)
                                {
                                    control.Capture = true;
                                    control.WndProc(ref m);
                                    return true;
                                }
                            }
                        }
                    }
                    else//左键按下
                    {
                        if (lastAccess != null)
                        {
                            lastAccess.WndProc(ref m);
                            return true;
                        }
                    }
                    break;
            }
            return false;
        }
    }
}
