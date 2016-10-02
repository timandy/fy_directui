using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// 渲染管理器
    /// </summary>
    public static class PaintManager
    {
        /// <summary>
        /// 捕获鼠标消息的虚拟控件
        /// </summary>
        public static UIControl CaptureControl
        {
            get;
            internal set;
        }


        /// <summary>
        /// 先在缓冲区渲染再复制到目标设备(客户区)
        /// </summary>
        /// <param name="window">可双缓冲渲染的控件</param>
        /// <param name="e">原始渲染数据数据或称作目标设备渲染数据</param>
        public static void OnPaint(IUIWindow window, PaintEventArgs e)
        {
            //缓冲区准备
            if (!window.DoubleBufferedGraphics.Prepare())
                return;

            //使用缓冲区绘图
            Rectangle clip = e.ClipRectangle;
            using (PaintEventArgs b = new PaintEventArgs(window.DoubleBufferedGraphics.Graphics, window.ClientRectangle))
            {
                window.DoubleBufferedGraphics.Graphics.SetClip(clip, CombineMode.Replace);
                window.RenderCore(b);
            }

            //使用缓冲区渲染目标设备
            e.Graphics.SetClip(clip, CombineMode.Replace);
            window.DoubleBufferedGraphics.Render(e);
        }

        /// <summary>
        /// WM_PAINT消息处理 不进行渲染
        /// </summary>
        /// <param name="m">消息</param>
        public static void WmPaint(ref Message m)
        {
            //========No Drawing
            UnsafeNativeMethods.ValidateRect(m.HWnd, IntPtr.Zero);
        }

        /// <summary>
        /// WM_PAINT消息处理
        /// </summary>
        /// <param name="window">可双缓冲渲染的控件(客户区)</param>
        /// <param name="m">消息</param>
        public static void WmPaint(IUIWindow window, ref Message m)
        {
            WmPaint(window, ref m, null);
        }

        /// <summary>
        /// WM_PAINT消息处理
        /// </summary>
        /// <param name="window">可双缓冲渲染的控件(客户区)</param>
        /// <param name="m">消息</param>
        /// <param name="e">如果该值为null,则自动创建默认PaintEventArgs.否则将直接使用该值作为OnPaint的参数</param>
        public static void WmPaint(IUIWindow window, ref Message m, PaintEventArgs e)
        {
            //========Begin
            IntPtr hWnd = m.HWnd;
            NativeMethods.PAINTSTRUCT ps = new NativeMethods.PAINTSTRUCT();
            IntPtr hDC = UnsafeNativeMethods.BeginPaint(hWnd, ref ps);

            //========Drawing
            try
            {
                if (e == null)
                {
                    using (Graphics g = Graphics.FromHdcInternal(hDC))
                    {
                        using (e = new PaintEventArgs(g, Rectangle.FromLTRB(ps.rcPaint.left, ps.rcPaint.top, ps.rcPaint.right, ps.rcPaint.bottom)))
                        {
                            OnPaint(window, e);
                        }
                    }
                }
                else
                {
                    OnPaint(window, e);
                }
            }
            finally
            {
                //========End
                UnsafeNativeMethods.EndPaint(hWnd, ref ps);
            }
        }
    }
}
