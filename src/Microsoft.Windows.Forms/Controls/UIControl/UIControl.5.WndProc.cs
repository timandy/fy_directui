using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Microsoft.Windows.Forms
{
    partial class UIControl
    {
        /// <summary>
        /// 消息处理
        /// </summary>
        /// <param name="m">消息</param>
        protected internal virtual void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case NativeMethods.WM_LBUTTONDOWN:
                    this.OnMouseDown(new MouseEventArgs(MouseButtons.Left, 1, Util.GET_X_LPARAM(m.LParam), Util.GET_Y_LPARAM(m.LParam), 0));
                    break;

                case NativeMethods.WM_LBUTTONDBLCLK:
                    if (this.Capture)
                        this.OnDoubleClick(new MouseEventArgs(MouseButtons.Left, 2, Util.GET_X_LPARAM(m.LParam), Util.GET_Y_LPARAM(m.LParam), 0));
                    break;

                case NativeMethods.WM_LBUTTONUP:
                    this.OnMouseUp(new MouseEventArgs(MouseButtons.Left, 1, Util.GET_X_LPARAM(m.LParam), Util.GET_Y_LPARAM(m.LParam), 0));
                    if (this.Capture)
                        this.OnClick(EventArgs.Empty);
                    break;

                case NativeMethods.WM_MOUSEMOVE:
                    MouseButtons buttons = MouseButtons.None;
                    int wParam = m.WParam.ToInt32();
                    if ((wParam & NativeMethods.MK_LBUTTON) != 0)
                        buttons &= MouseButtons.Left;
                    if ((wParam & NativeMethods.MK_RBUTTON) != 0)
                        buttons &= MouseButtons.Right;
                    if ((wParam & NativeMethods.MK_MBUTTON) != 0)
                        buttons &= MouseButtons.Middle;
                    if ((wParam & NativeMethods.MK_XBUTTON1) != 0)
                        buttons &= MouseButtons.XButton1;
                    if ((wParam & NativeMethods.MK_XBUTTON2) != 0)
                        buttons &= MouseButtons.XButton2;
                    this.OnMouseMove(new MouseEventArgs(buttons, 1, Util.GET_X_LPARAM(m.LParam), Util.GET_Y_LPARAM(m.LParam), 0));
                    break;
            }
            this.State = this.GetState();
        }
    }
}
