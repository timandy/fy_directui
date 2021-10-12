using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Microsoft.Win32
{
    /// <summary>
    /// User32扩展
    /// </summary>
    public static partial class Util
    {
        /// <summary>
        /// 开始更新,禁止控件重绘
        /// </summary>
        /// <param name="hWnd">控件句柄</param>
        public static void BeginUpdate(IntPtr hWnd)
        {
            UnsafeNativeMethods.SendMessage(hWnd, NativeMethods.WM_SETREDRAW, 0, 0);
        }
        /// <summary>
        /// 开始更新,允许控件重绘
        /// </summary>
        /// <param name="hWnd">控件句柄</param>
        public static void EndUpdate(IntPtr hWnd)
        {
            UnsafeNativeMethods.SendMessage(hWnd, NativeMethods.WM_SETREDRAW, 1, 0);
        }

        /// <summary>
        /// 开始拖动窗口
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        public static void BeginDrag(IntPtr hWnd)
        {
            UnsafeNativeMethods.ReleaseCapture();
            UnsafeNativeMethods.SendMessage(hWnd, NativeMethods.WM_SYSCOMMAND, NativeMethods.SC_MOVE | NativeMethods.HTCAPTION, 0);
        }

        /// <summary>
        /// 在指定句柄窗口内按下鼠标,不等待消息处理完成立即返回
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="pt">相对于窗口的点</param>
        public static void PostMouseDown(IntPtr hWnd, Point pt)
        {
            IntPtr lParam = Util.MAKELPARAM(pt.X, pt.Y);
            UnsafeNativeMethods.PostMessage(hWnd, NativeMethods.WM_MOUSEMOVE, IntPtr.Zero, lParam);
            UnsafeNativeMethods.PostMessage(hWnd, NativeMethods.WM_LBUTTONDOWN, IntPtr.Zero, lParam);
        }
        /// <summary>
        /// 在指定句柄窗口内弹起鼠标,不等待消息处理完成立即返回
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="pt">相对于窗口的点</param>
        public static void PostMouseUp(IntPtr hWnd, Point pt)
        {
            IntPtr lParam = Util.MAKELPARAM(pt.X, pt.Y);
            UnsafeNativeMethods.PostMessage(hWnd, NativeMethods.WM_LBUTTONUP, IntPtr.Zero, lParam);
        }
        /// <summary>
        /// 在指定句柄窗口内单击鼠标,不等待消息处理完成立即返回
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="pt">相对于窗口的点</param>
        public static void PostMouseClick(IntPtr hWnd, Point pt)
        {
            IntPtr lParam = Util.MAKELPARAM(pt.X, pt.Y);
            UnsafeNativeMethods.PostMessage(hWnd, NativeMethods.WM_MOUSEMOVE, IntPtr.Zero, lParam);
            UnsafeNativeMethods.PostMessage(hWnd, NativeMethods.WM_LBUTTONDOWN, IntPtr.Zero, lParam);
            UnsafeNativeMethods.PostMessage(hWnd, NativeMethods.WM_LBUTTONUP, IntPtr.Zero, lParam);
        }

        /// <summary>
        /// 在指定句柄窗口内按下鼠标,等待消息处理完成后再返回
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="pt">相对于窗口的点</param>
        public static void SendMouseDown(IntPtr hWnd, Point pt)
        {
            IntPtr lParam = Util.MAKELPARAM(pt.X, pt.Y);
            UnsafeNativeMethods.SendMessage(hWnd, NativeMethods.WM_MOUSEMOVE, IntPtr.Zero, lParam);
            UnsafeNativeMethods.SendMessage(hWnd, NativeMethods.WM_LBUTTONDOWN, IntPtr.Zero, lParam);
        }
        /// <summary>
        /// 在指定句柄窗口内弹起鼠标,等待消息处理完成后再返回
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="pt">相对于窗口的点</param>
        public static void SendMouseUp(IntPtr hWnd, Point pt)
        {
            IntPtr lParam = Util.MAKELPARAM(pt.X, pt.Y);
            UnsafeNativeMethods.SendMessage(hWnd, NativeMethods.WM_LBUTTONUP, IntPtr.Zero, lParam);
        }
        /// <summary>
        /// 在指定句柄窗口内单击鼠标,等待消息处理完成后再返回
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="pt">相对于窗口的点</param>
        public static void SendMouseClick(IntPtr hWnd, Point pt)
        {
            IntPtr lParam = Util.MAKELPARAM(pt.X, pt.Y);
            UnsafeNativeMethods.SendMessage(hWnd, NativeMethods.WM_MOUSEMOVE, IntPtr.Zero, lParam);
            UnsafeNativeMethods.SendMessage(hWnd, NativeMethods.WM_LBUTTONDOWN, IntPtr.Zero, lParam);
            UnsafeNativeMethods.SendMessage(hWnd, NativeMethods.WM_LBUTTONUP, IntPtr.Zero, lParam);
        }

        /// <summary>
        /// 按下键盘键
        /// </summary>
        /// <param name="vKey">虚拟键码</param>
        public static void SendKeyDown(short vKey)
        {
            NativeMethods.INPUT[] input = new NativeMethods.INPUT[1];
            input[0].type = NativeMethods.INPUT_KEYBOARD;
            input[0].ki.wVk = vKey;
            input[0].ki.time = UnsafeNativeMethods.GetTickCount();
            UnsafeNativeMethods.SendInput((uint)input.Length, input, Marshal.SizeOf(input[0]));
        }
        /// <summary>
        /// 弹起键盘键
        /// </summary>
        /// <param name="vKey">虚拟键码</param>
        public static void SendKeyUp(short vKey)
        {
            NativeMethods.INPUT[] input = new NativeMethods.INPUT[1];
            input[0].type = NativeMethods.INPUT_KEYBOARD;
            input[0].ki.wVk = vKey;
            input[0].ki.dwFlags = NativeMethods.KEYEVENTF_KEYUP;
            input[0].ki.time = UnsafeNativeMethods.GetTickCount();
            UnsafeNativeMethods.SendInput((uint)input.Length, input, Marshal.SizeOf(input[0]));
        }
        /// <summary>
        /// 按一下并弹起键盘键
        /// </summary>
        /// <param name="vKey">虚拟键码</param>
        public static void SendKeyClick(short vKey)
        {
            SendKeyDown(vKey);
            SendKeyUp(vKey);
        }

        /// <summary>
        /// 显示或隐藏光标.
        /// </summary>
        /// <param name="visible">显示为true,否则为false.</param>
        public static void ShowCursor(bool visible)
        {
            if (visible)
            {
                while (UnsafeNativeMethods.ShowCursor(true) < 0) { }
            }
            else
            {
                while (UnsafeNativeMethods.ShowCursor(false) >= 0) { }
            }
        }
        /// <summary>
        /// 获取光标是否显示.显示为true,否则为false.
        /// </summary>
        public static bool GetCursorVisible()
        {
            UnsafeNativeMethods.ShowCursor(false);
            return UnsafeNativeMethods.ShowCursor(true) >= 0;
        }

        /// <summary>
        /// 获取指定窗口的所有者窗口。
        /// </summary>
        /// <param name="hWnd">指定窗口。</param>
        /// <returns>所有者窗口。</returns>
        public static IntPtr GetOwner(IntPtr hWnd)
        {
            return UnsafeNativeMethods.GetWindow(hWnd, NativeMethods.GW_OWNER);
        }
        /// <summary>
        /// 为指定窗口设置新的的所有者窗口。
        /// </summary>
        /// <param name="hWnd">指定窗口。</param>
        /// <param name="hWndNewOwner">新的所有者窗口。</param>
        public static void SetOwner(IntPtr hWnd, IntPtr hWndNewOwner)
        {
            UnsafeNativeMethods.SetWindowLong(hWnd, NativeMethods.GWL_HWNDPARENT, (int)hWndNewOwner);
        }
        /// <summary>
        /// 获取指定窗口的父窗口。
        /// </summary>
        /// <param name="hWnd">指定窗口。</param>
        /// <returns>父窗口。</returns>
        public static IntPtr GetParent(IntPtr hWnd)
        {
            return UnsafeNativeMethods.GetAncestor(hWnd, NativeMethods.GA_PARENT);
        }
        /// <summary>
        /// 为指定窗口设置新的父窗口。
        /// </summary>
        /// <param name="hWnd">指定窗口。</param>
        /// <param name="hWndNewParent">新的父窗口。</param>
        public static void SetParent(IntPtr hWnd, IntPtr hWndNewParent)
        {
            UnsafeNativeMethods.SetParent(hWnd, hWndNewParent);
        }

        /// <summary>
        /// 获取指定窗口包含的滚动条。
        /// </summary>
        /// <param name="hWnd">窗口句柄。</param>
        /// <returns>返回值见 System.Windows.Forms.ScrollBars 定义</returns>
        public static int GetScrollBars(IntPtr hWnd)
        {
            int wndStyle = UnsafeNativeMethods.GetWindowLong(hWnd, NativeMethods.GWL_STYLE);
            bool hsVisible = (wndStyle & NativeMethods.WS_HSCROLL) != 0;
            bool vsVisible = (wndStyle & NativeMethods.WS_VSCROLL) != 0;

            if (hsVisible)
                return vsVisible ? 3 : 1;
            else
                return vsVisible ? 2 : 0;
        }
        /// <summary>
        /// 获取指定窗口是否有左滚动条样式。
        /// </summary>
        /// <param name="hWnd">窗口句柄。</param>
        /// <returns>窗口有左滚动条样式返回 true，否则返回 false。</returns>
        public static bool GetLeftScrollBar(IntPtr hWnd)
        {
            int wndExStyle = UnsafeNativeMethods.GetWindowLong(hWnd, NativeMethods.GWL_EXSTYLE);
            return (wndExStyle & NativeMethods.WS_EX_LEFTSCROLLBAR) != 0;
        }
        /// <summary>
        /// 获取指定窗口边框宽度。
        /// </summary>
        /// <param name="hWnd">窗口句柄。</param>
        /// <returns>窗口边框宽度。</returns>
        public static int GetBorderWidth(IntPtr hWnd)
        {
            int wndExStyle = UnsafeNativeMethods.GetWindowLong(hWnd, NativeMethods.GWL_EXSTYLE);
            if ((wndExStyle & NativeMethods.WS_EX_STATICEDGE) != 0)
                return 3;
            else if ((wndExStyle & NativeMethods.WS_EX_WINDOWEDGE) != 0)
                return 2;
            else if ((wndExStyle & NativeMethods.WS_EX_CLIENTEDGE) != 0)
                return 2;
            else if ((UnsafeNativeMethods.GetWindowLong(hWnd, NativeMethods.GWL_STYLE) & NativeMethods.WS_BORDER) != 0)
                return 1;
            else
                return 0;
        }
        /// <summary>
        /// 从 GDI+ Region 创建一个 GDI Region。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <param name="region">System.Drawing.Region 对象。</param>
        /// <returns>GDI Region 句柄。</returns>
        public static IntPtr GetHRgn(IntPtr hWnd, Region region)
        {
            using (Graphics g = Graphics.FromHwndInternal(hWnd))
            {
                return region.GetHrgn(g);
            }
        }
        /// <summary>
        /// 获取窗口的客户区相对于窗口左上角的矩形.(特别注意:如果有非客户区起点一般不为0,0 如果没有非客户区该值同ClientRectangle相等).该函数非常特别尽量不要调用,在非客户区操作时可能使用到,其余问题请咨询编写人员. by Tim 2013.11.23
        /// </summary>
        /// <param name="hWnd">指定窗口句柄</param>
        /// <returns>客户区相对于窗口坐标系的坐标和大小</returns>
        public static NativeMethods.RECT GetClientRect(IntPtr hWnd)
        {
            NativeMethods.RECT wndRect = new NativeMethods.RECT();//窗口相对于屏幕的坐标和大小
            NativeMethods.RECT clientRect = new NativeMethods.RECT();//以0,0开始的客户区坐标和大小

            UnsafeNativeMethods.GetWindowRect(hWnd, ref wndRect);//窗口
            UnsafeNativeMethods.GetClientRect(hWnd, ref clientRect);//客户区
            UnsafeNativeMethods.MapWindowPoints(hWnd, NativeMethods.HWND_DESKTOP, ref clientRect, 2);//客户区映射到屏幕

            //偏移
            clientRect.left -= wndRect.left;
            clientRect.top -= wndRect.top;
            clientRect.right -= wndRect.left;
            clientRect.bottom -= wndRect.top;

            //返回
            return clientRect;
        }

        /// <summary>
        /// 闪烁指定窗口。
        /// </summary>
        /// <param name="hWnd">指定窗口句柄。</param>
        /// <param name="count">闪烁次数。</param>
        /// <returns>返回闪烁前窗口是否已被激活。</returns>
        public static bool FlashWindow(IntPtr hWnd, int count)
        {
            NativeMethods.FLASHWINFO fwi = new NativeMethods.FLASHWINFO();
            fwi.cbSize = Marshal.SizeOf(fwi);
            fwi.hwnd = hWnd;
            fwi.dwFlags = NativeMethods.FLASHW_TRAY;
            fwi.uCount = count;
            fwi.dwTimeout = 0;
            return UnsafeNativeMethods.FlashWindowEx(ref fwi);
        }


        #region 扩展

        /// <summary>
        /// 将窗口置顶
        /// </summary>
        /// <param name="lpClassName">窗口类名</param>
        /// <param name="lpWindowName">窗口标题</param>
        public static void BringToFront(string lpClassName, string lpWindowName)
        {
            IntPtr hWnd = UnsafeNativeMethods.FindWindow(lpClassName, lpWindowName);
            if (hWnd != IntPtr.Zero)
                UnsafeNativeMethods.SetWindowPos(hWnd, NativeMethods.HWND_TOP, 0, 0, 0, 0, NativeMethods.SWP_NOSIZE | NativeMethods.SWP_NOMOVE);
        }

        /// <summary>
        /// 将窗口置底
        /// </summary>
        /// <param name="lpClassName">窗口类名</param>
        /// <param name="lpWindowName">窗口标题</param>
        public static void SendToBack(string lpClassName, string lpWindowName)
        {
            IntPtr hWnd = UnsafeNativeMethods.FindWindow(lpClassName, lpWindowName);
            if (hWnd != IntPtr.Zero)
                UnsafeNativeMethods.SetWindowPos(hWnd, NativeMethods.HWND_BOTTOM, 0, 0, 0, 0, NativeMethods.SWP_NOSIZE | NativeMethods.SWP_NOMOVE);
        }

        /// <summary>
        /// 跨进程,向指定窗口发送WM_COPYDATA消息
        /// </summary>
        /// <param name="lpWindowName">窗口标题</param>
        /// <param name="flag">区分标记</param>
        /// <param name="data">要发送的字符串数据</param>
        public static void SendCopyData(string lpWindowName, int flag, string data)
        {
            IntPtr hWnd = UnsafeNativeMethods.FindWindow(null, lpWindowName);
            if (hWnd == IntPtr.Zero)
                return;

            byte[] arr = Encoding.UTF8.GetBytes(data);
            NativeMethods.COPYDATASTRUCT cds = new NativeMethods.COPYDATASTRUCT();
            cds.dwData = flag;
            cds.cbData = arr.Length + 1;
            cds.lpData = data;
            UnsafeNativeMethods.SendMessage(hWnd, NativeMethods.WM_COPYDATA, IntPtr.Zero, ref cds);
        }

        /// <summary>
        /// 向指定标题的窗口发送WM_CLOSE消息
        /// </summary>
        /// <param name="lpWindowName">窗口标题</param>
        public static void CloseWindow(string lpWindowName)
        {
            IntPtr hWnd = UnsafeNativeMethods.FindWindow(null, lpWindowName);
            if (hWnd == IntPtr.Zero)
                return;

            UnsafeNativeMethods.PostMessage(hWnd, NativeMethods.WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
        }

        /// <summary>
        /// 设置窗口显示状态
        /// </summary>
        /// <param name="lpWindowName">窗口标题</param>
        /// <param name="nCmdShow">显示指令</param>
        public static void ShowWindow(string lpWindowName, int nCmdShow)
        {
            IntPtr hWnd = UnsafeNativeMethods.FindWindow(null, lpWindowName);
            if (hWnd == IntPtr.Zero)
                return;

            UnsafeNativeMethods.ShowWindow(hWnd, nCmdShow);
        }

        /// <summary>
        /// 获取控件是否TopMost(判断控件是否为“TopMost”类型的窗口，这种类型的窗口总是在其它窗口的前面)
        /// </summary>
        /// <param name="hWnd">要判断的窗口</param>
        public static bool IsTopMost(IntPtr hWnd)
        {
            return (UnsafeNativeMethods.GetWindowLong(hWnd, NativeMethods.GWL_EXSTYLE) & NativeMethods.WS_EX_TOPMOST) != 0;
        }

        /// <summary>
        /// 设置控件TopMost(使窗口成为“TopMost”类型的窗口，这种类型的窗口总是在其它窗口的前面)
        /// </summary>
        /// <param name="hWnd">要设置的窗口</param>
        public static void SetTopMost(IntPtr hWnd)
        {
            try
            {
                UnsafeNativeMethods.SetWindowPos(hWnd, NativeMethods.HWND_TOPMOST, 0, 0, 0, 0, NativeMethods.SWP_NOSIZE | NativeMethods.SWP_NOMOVE | NativeMethods.SWP_NOACTIVATE);
            }
            catch
            {
            }
        }

        /// <summary>
        /// 设置控件NoTopMost(将窗口放在所有“TopMost”类型窗口的后面,其它类型窗口的前面)
        /// </summary>
        /// <param name="hWnd">要设置的窗口</param>
        public static void SetNoTopMost(IntPtr hWnd)
        {
            try
            {
                UnsafeNativeMethods.SetWindowPos(hWnd, NativeMethods.HWND_NOTOPMOST, 0, 0, 0, 0, NativeMethods.SWP_NOSIZE | NativeMethods.SWP_NOMOVE | NativeMethods.SWP_NOACTIVATE);
            }
            catch
            {
            }
        }

        /// <summary>
        /// 设置窗口的拥有窗口,可以跨进程
        /// </summary>
        /// <param name="child"></param>
        /// <param name="lpParentWindowName"></param>
        public static void SetOwner(Control child, string lpParentWindowName)
        {
            IntPtr hWndNewParent = UnsafeNativeMethods.FindWindow(null, lpParentWindowName);
            if (hWndNewParent != IntPtr.Zero)
                SetOwner(child.Handle, hWndNewParent);
        }

        /// <summary>
        /// 设置窗口的拥有窗口,可以跨进程
        /// </summary>
        /// <param name="lpChildWindowName"></param>
        /// <param name="parent"></param>
        public static void SetOwner(string lpChildWindowName, Control parent)
        {
            IntPtr hWndChild = UnsafeNativeMethods.FindWindow(null, lpChildWindowName);
            if (hWndChild != IntPtr.Zero)
                SetOwner(hWndChild, parent.Handle);
        }

        /// <summary>
        /// 跨进程,向指定窗口发送指定消息,立即返回
        /// </summary>
        /// <param name="lpWindowName">窗口标题</param>
        /// <param name="msg">消息</param>
        /// <param name="lParam">lParam</param>
        public static void PostMessage(string lpWindowName, int msg, int lParam)
        {
            IntPtr hWnd = UnsafeNativeMethods.FindWindow(null, lpWindowName);
            if (hWnd == IntPtr.Zero)
                return;

            UnsafeNativeMethods.PostMessage(hWnd, msg, IntPtr.Zero, (IntPtr)lParam);
        }

        /// <summary>
        /// 跨进程,向指定窗口发送指定消息,立即返回
        /// </summary>
        /// <param name="lpWindowName">窗口标题</param>
        /// <param name="msg">消息</param>
        /// <param name="wParam">wParm</param>
        /// <param name="lParam">lParm</param>
        public static void PostMessage(string lpWindowName, int msg, int wParam, int lParam)
        {
            IntPtr hWnd = UnsafeNativeMethods.FindWindow(null, lpWindowName);
            if (hWnd == IntPtr.Zero)
                return;

            UnsafeNativeMethods.PostMessage(hWnd, msg, (IntPtr)wParam, (IntPtr)lParam);
        }

        /// <summary>
        /// 跨进程,向指定窗口发送指定消息,立即返回
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="msg">消息</param>
        /// <param name="lParam">lParam</param>
        public static void PostMessage(IntPtr hWnd, int msg, int lParam)
        {
            if (hWnd == IntPtr.Zero)
                return;

            UnsafeNativeMethods.PostMessage(hWnd, msg, IntPtr.Zero, (IntPtr)lParam);
        }

        /// <summary>
        /// 跨进程,向指定窗口发送指定消息,立即返回
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="msg">消息</param>
        /// <param name="wParam">wParam</param>
        /// <param name="lParam">lParam</param>
        public static void PostMessage(IntPtr hWnd, int msg, int wParam, int lParam)
        {
            if (hWnd == IntPtr.Zero)
                return;

            UnsafeNativeMethods.PostMessage(hWnd, msg, (IntPtr)wParam, (IntPtr)lParam);
        }

        #endregion


        #region 窗口

        /// <summary>
        /// 从 lParam 提取坐标
        /// </summary>
        /// <param name="lParam">消息中的 lParam 参数</param>
        /// <returns>鼠标相对窗口坐标</returns>
        public static Point GetMousePosition(IntPtr lParam)
        {
            return new Point(GET_X_LPARAM(lParam), GET_Y_LPARAM(lParam));
        }
        /// <summary>
        /// 获取该控件的右下角相对于其容器的左上角的坐标。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <returns>System.Drawing.Point，它表示控件的右下角相对于其容器的左上角。</returns>
        public static Point GetBottomRight(IntPtr hWnd)
        {
            NativeMethods.RECT lpRect = new NativeMethods.RECT();
            UnsafeNativeMethods.GetWindowRect(hWnd, ref lpRect);
            NativeMethods.POINT pt = new NativeMethods.POINT(lpRect.bottom, lpRect.right);

            //父窗口不为空转换坐标
            IntPtr hWndParent = GetParent(hWnd);
            if (hWndParent != IntPtr.Zero)
                UnsafeNativeMethods.MapWindowPoints(NativeMethods.HWND_DESKTOP, hWndParent, ref pt, 1);

            return new Point(pt.x, pt.y);
        }
        /// <summary>
        /// 获取一个值，该值指示是否将控件显示为顶级窗口。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <returns>如果为 true，则将控件显示为顶级窗口；否则，为 false。</returns>
        public static bool GetTopLevel(IntPtr hWnd)
        {
            int dwStyle = UnsafeNativeMethods.GetWindowLong(hWnd, NativeMethods.GWL_STYLE);
            return ((dwStyle & NativeMethods.WS_CHILD) == 0);
        }
        /// <summary>
        /// 获取一个值，该值指示控件是否有与它关联的句柄。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <returns>如果已经为控件分配了句柄，则为 true；否则为 false。</returns>
        public static bool GetIsHandleCreated(IntPtr hWnd)
        {
            return (hWnd != IntPtr.Zero);
        }
        /// <summary>
        /// 获取一个值，该值指示是否显示该控件及其所有父控件。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <returns>如果显示该控件及其所有父控件，则为 true；否则为 false。默认为 true。</returns>
        public static bool GetVisible(IntPtr hWnd)
        {
            return UnsafeNativeMethods.IsWindowVisible(hWnd);
        }
        /// <summary>
        /// 设置一个值，该值指示是否显示该控件及其所有父控件。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <param name="value">如果显示该控件及其所有父控件，则为 true；否则为 false。默认为 true。</param>
        public static void SetVisible(IntPtr hWnd, bool value)
        {
            UnsafeNativeMethods.SetWindowPos(hWnd, IntPtr.Zero, 0, 0, 0, 0, NativeMethods.SWP_NOSIZE | NativeMethods.SWP_NOMOVE | NativeMethods.SWP_NOZORDER | NativeMethods.SWP_NOACTIVATE | (value ? NativeMethods.SWP_SHOWWINDOW : NativeMethods.SWP_HIDEWINDOW));
        }
        /// <summary>
        /// 获取一个值，该值指示控件是否可以对用户交互作出响应。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <returns>如果控件可以对用户交互作出响应，则为 true；否则为 false。默认为 true。</returns>
        public static bool GetEnabled(IntPtr hWnd)
        {
            return UnsafeNativeMethods.IsWindowEnabled(hWnd);
        }
        /// <summary>
        /// 设置一个值，该值指示控件是否可以对用户交互作出响应。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <param name="value">如果控件可以对用户交互作出响应，则为 true；否则为 false。默认为 true。</param>
        public static void SetEnabled(IntPtr hWnd, bool value)
        {
            UnsafeNativeMethods.EnableWindow(hWnd, value);
        }
        /// <summary>
        /// 获取一个值，该值指示控件是否有输入焦点。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <returns>如果控件有焦点，则为 true；否则为 false。</returns>
        public static bool GetFocused(IntPtr hWnd)
        {
            return (GetIsHandleCreated(hWnd) && (UnsafeNativeMethods.GetFocus() == hWnd));
        }
        /// <summary>
        /// 获取一个值，该值指示控件是否可以接收焦点。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <returns>如果控件可以接收焦点，则为 true；否则为 false。</returns>
        public static bool GetCanFocus(IntPtr hWnd)
        {
            if (!GetIsHandleCreated(hWnd))
                return false;

            return UnsafeNativeMethods.IsWindowVisible(hWnd) && UnsafeNativeMethods.IsWindowEnabled(hWnd);
        }
        /// <summary>
        /// 获取一个值，该值指示控件或它的一个子控件当前是否有输入焦点。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <returns>如果控件或它的一个子控件当前已经有输入焦点，则为 true；否则为 false。</returns>
        public static bool GetContainsFocus(IntPtr hWnd)
        {
            if (!GetIsHandleCreated(hWnd))
                return false;

            IntPtr focus = UnsafeNativeMethods.GetFocus();
            if (focus == IntPtr.Zero)
                return false;

            return ((focus == hWnd) || UnsafeNativeMethods.IsChild(hWnd, focus));
        }
        /// <summary>
        /// 获取一个值，该值指示控件是否已捕获鼠标。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <returns>如果控件已捕获鼠标，则为 true；否则为 false。</returns>
        public static bool GetCapture(IntPtr hWnd)
        {
            return (GetIsHandleCreated(hWnd) && (UnsafeNativeMethods.GetCapture() == hWnd));
        }
        /// <summary>
        /// 设置一个值，该值指示控件是否已捕获鼠标。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <param name="value">如果控件已捕获鼠标，则为 true；否则为 false。</param>
        public static void SetCapture(IntPtr hWnd, bool value)
        {
            if (value)
                UnsafeNativeMethods.SetCapture(hWnd);
            else
                UnsafeNativeMethods.ReleaseCapture();
        }
        /// <summary>
        /// 获取该控件的左上角相对于其容器的左上角的坐标。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <returns>System.Drawing.Point，它表示控件的左上角相对于其容器的左上角。</returns>
        public static Point GetLocation(IntPtr hWnd)
        {
            NativeMethods.RECT lpRect = new NativeMethods.RECT();
            UnsafeNativeMethods.GetWindowRect(hWnd, ref lpRect);
            NativeMethods.POINT pt = new NativeMethods.POINT(lpRect.left, lpRect.top);

            //父窗口不为空转换坐标
            IntPtr hWndParent = GetParent(hWnd);
            if (hWndParent != IntPtr.Zero)
                UnsafeNativeMethods.MapWindowPoints(NativeMethods.HWND_DESKTOP, hWndParent, ref pt, 1);

            return new Point(pt.x, pt.y);
        }
        /// <summary>
        /// 设置该控件的左上角相对于其容器的左上角的坐标。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <param name="value">System.Drawing.Point，它表示控件的左上角相对于其容器的左上角。</param>
        public static void SetLocation(IntPtr hWnd, Point value)
        {
            UnsafeNativeMethods.SetWindowPos(hWnd, IntPtr.Zero, value.X, value.Y, 0, 0, NativeMethods.SWP_NOSIZE | NativeMethods.SWP_NOZORDER | NativeMethods.SWP_NOACTIVATE);
        }
        /// <summary>
        /// 获取控件的高度和宽度。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <returns>System.Drawing.Size，表示控件的高度和宽度（以像素为单位）。</returns>
        public static Size GetSize(IntPtr hWnd)
        {
            NativeMethods.RECT lpRect = new NativeMethods.RECT();
            UnsafeNativeMethods.GetWindowRect(hWnd, ref lpRect);
            return lpRect.Size;
        }
        /// <summary>
        /// 设置控件的高度和宽度。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <param name="value">System.Drawing.Size，表示控件的高度和宽度（以像素为单位）。</param>
        public static void SetSize(IntPtr hWnd, Size value)
        {
            UnsafeNativeMethods.SetWindowPos(hWnd, IntPtr.Zero, 0, 0, value.Width, value.Height, NativeMethods.SWP_NOMOVE | NativeMethods.SWP_NOZORDER | NativeMethods.SWP_NOACTIVATE);
        }
        /// <summary>
        /// 获取控件（包括其非工作区元素）相对于其父控件的大小和位置（以像素为单位）。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <returns>相对于父控件的 System.Drawing.Rectangle，表示控件（包括其非工作区元素）的大小和位置（以像素为单位）。</returns>
        public static Rectangle GetBounds(IntPtr hWnd)
        {
            NativeMethods.RECT lpRect = new NativeMethods.RECT();
            UnsafeNativeMethods.GetWindowRect(hWnd, ref lpRect);

            //父窗口不为空转换坐标
            IntPtr hWndParent = GetParent(hWnd);
            if (hWndParent != IntPtr.Zero)
                UnsafeNativeMethods.MapWindowPoints(NativeMethods.HWND_DESKTOP, hWndParent, ref lpRect, 2);

            return lpRect.ToRectangle();
        }
        /// <summary>
        /// 设置控件（包括其非工作区元素）相对于其父控件的大小和位置（以像素为单位）。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <param name="value">相对于父控件的 System.Drawing.Rectangle，表示控件（包括其非工作区元素）的大小和位置（以像素为单位）。</param>
        public static void SetBounds(IntPtr hWnd, Rectangle value)
        {
            UnsafeNativeMethods.SetWindowPos(hWnd, IntPtr.Zero, value.X, value.Y, value.Width, value.Height, NativeMethods.SWP_NOZORDER | NativeMethods.SWP_NOACTIVATE);
        }
        /// <summary>
        /// 获取控件左边缘与其容器的工作区左边缘之间的距离（以像素为单位）。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <returns>System.Int32 表示控件左边缘与其容器的工作区左边缘之间的距离（以像素为单位）。</returns>
        public static int GetLeft(IntPtr hWnd)
        {
            return GetLocation(hWnd).X;
        }
        /// <summary>
        /// 设置控件左边缘与其容器的工作区左边缘之间的距离（以像素为单位）。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <param name="value">System.Int32 表示控件左边缘与其容器的工作区左边缘之间的距离（以像素为单位）。</param>
        public static void SetLeft(IntPtr hWnd, int value)
        {
            Point pt = GetLocation(hWnd);
            pt.X = value;
            SetLocation(hWnd, pt);
        }
        /// <summary>
        /// 获取控件上边缘与其容器的工作区上边缘之间的距离（以像素为单位）。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <returns>System.Int32 表示控件下边缘与其容器的工作区上边缘之间的距离（以像素为单位）。</returns>
        public static int GetTop(IntPtr hWnd)
        {
            return GetLocation(hWnd).Y;
        }
        /// <summary>
        /// 设置控件上边缘与其容器的工作区上边缘之间的距离（以像素为单位）。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <param name="value">System.Int32 表示控件上边缘与其容器的工作区上边缘之间的距离（以像素为单位）。</param>
        public static void SetTop(IntPtr hWnd, int value)
        {
            Point pt = GetLocation(hWnd);
            pt.Y = value;
            SetLocation(hWnd, pt);
        }
        /// <summary>
        /// 获取控件右边缘与其容器的工作区左边缘之间的距离（以像素为单位）。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <returns>System.Int32 表示控件右边缘与其容器的工作区左边缘之间的距离（以像素为单位）。</returns>
        public static int GetRight(IntPtr hWnd)
        {
            return GetBottomRight(hWnd).X;
        }
        /// <summary>
        /// 获取控件下边缘与其容器的工作区上边缘之间的距离（以像素为单位）。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <returns>System.Int32 表示控件下边缘与其容器的工作区上边缘之间的距离（以像素为单位）。</returns>
        public static int GetBottom(IntPtr hWnd)
        {
            return GetBottomRight(hWnd).Y;
        }
        /// <summary>
        /// 获取控件的宽度。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <returns>控件的宽度（以像素为单位）。</returns>
        public static int GetWidth(IntPtr hWnd)
        {
            return GetSize(hWnd).Width;
        }
        /// <summary>
        /// 设置控件的宽度。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <param name="value">控件的宽度（以像素为单位）。</param>
        public static void SetWidth(IntPtr hWnd, int value)
        {
            Size sz = GetSize(hWnd);
            sz.Width = value;
            SetSize(hWnd, sz);
        }
        /// <summary>
        /// 获取控件的高度。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <returns>控件的高度（以像素为单位）。</returns>
        public static int GetHeight(IntPtr hWnd)
        {
            return GetSize(hWnd).Height;
        }
        /// <summary>
        /// 设置控件的高度。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <param name="value">控件的高度（以像素为单位）。</param>
        public static void SetHeight(IntPtr hWnd, int value)
        {
            Size sz = GetSize(hWnd);
            sz.Height = value;
            SetSize(hWnd, sz);
        }
        /// <summary>
        /// 获取控件的工作区的高度和宽度。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <returns>一个 System.Drawing.Size，表示控件的工作区的维数。</returns>
        public static Size GetClientSize(IntPtr hWnd)
        {
            NativeMethods.RECT lpRect = new NativeMethods.RECT();
            UnsafeNativeMethods.GetClientRect(hWnd, ref lpRect);
            return lpRect.Size;
        }
        /// <summary>
        /// 设置控件的工作区的高度和宽度。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <param name="value">一个 System.Drawing.Size，表示控件的工作区的维数。</param>
        public static void SetClientSize(IntPtr hWnd, Size value)
        {
            NativeMethods.RECT lpRect = new NativeMethods.RECT(0, 0, value.Width, value.Height);
            int dwStyle = UnsafeNativeMethods.GetWindowLong(hWnd, NativeMethods.GWL_STYLE);
            int dwExStyle = UnsafeNativeMethods.GetWindowLong(hWnd, NativeMethods.GWL_EXSTYLE);
            UnsafeNativeMethods.AdjustWindowRectEx(ref lpRect, dwStyle, false, dwExStyle);
            SetSize(hWnd, lpRect.Size);
        }
        /// <summary>
        /// 获取表示控件的工作区的矩形。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <returns>一个 System.Drawing.Rectangle，它表示控件的工作区。</returns>
        public static Rectangle GetClientRectangle(IntPtr hWnd)
        {
            NativeMethods.RECT lpRect = new NativeMethods.RECT();
            UnsafeNativeMethods.GetClientRect(hWnd, ref lpRect);
            return lpRect.ToRectangle();
        }
        /// <summary>
        /// 获取与此控件关联的文本。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <returns>与该控件关联的文本。</returns>
        public static string GetText(IntPtr hWnd)
        {
            if (!GetIsHandleCreated(hWnd))
                return string.Empty;

            int windowTextLength = UnsafeNativeMethods.GetWindowTextLength(hWnd);
            if (UnsafeNativeMethods.GetSystemMetrics(NativeMethods.SM_DBCSENABLED) != 0)
                windowTextLength = (windowTextLength * 2) + 1;
            StringBuilder lpString = new StringBuilder(windowTextLength + 1);
            UnsafeNativeMethods.GetWindowText(hWnd, lpString, lpString.Capacity);
            return lpString.ToString();
        }
        /// <summary>
        /// 设置与此控件关联的文本。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <param name="value">与该控件关联的文本。</param>
        public static void SetText(IntPtr hWnd, string value)
        {
            if (GetIsHandleCreated(hWnd))
                return;

            UnsafeNativeMethods.SetWindowText(hWnd, value);
        }

        /// <summary>
        /// 将与此控件关联的文本重置为其默认值。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        public static void ResetText(IntPtr hWnd)
        {
            SetText(hWnd, string.Empty);
        }
        /// <summary>
        /// 向用户显示控件。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        public static void Show(IntPtr hWnd)
        {
            SetVisible(hWnd, true);
        }
        /// <summary>
        /// 对用户隐藏控件。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        public static void Hide(IntPtr hWnd)
        {
            SetVisible(hWnd, false);
        }
        /// <summary>
        /// 将控件带到 Z 顺序的前面。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        public static void BringToFront(IntPtr hWnd)
        {
            UnsafeNativeMethods.SetWindowPos(hWnd, NativeMethods.HWND_TOP, 0, 0, 0, 0, NativeMethods.SWP_NOSIZE | NativeMethods.SWP_NOMOVE);
        }
        /// <summary>
        /// 将控件发送到 Z 顺序的后面。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        public static void SendToBack(IntPtr hWnd)
        {
            UnsafeNativeMethods.SetWindowPos(hWnd, NativeMethods.HWND_BOTTOM, 0, 0, 0, 0, NativeMethods.SWP_NOSIZE | NativeMethods.SWP_NOMOVE);
        }
        /// <summary>
        /// 为控件设置输入焦点。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <returns>如果输入焦点请求成功，则为 true；否则为 false。</returns>
        public static bool Focus(IntPtr hWnd)
        {
            if (GetCanFocus(hWnd))
                UnsafeNativeMethods.SetFocus(hWnd);

            return GetFocused(hWnd);
        }
        /// <summary>
        /// 为控件创建 System.Drawing.Graphics。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <returns>控件的 System.Drawing.Graphics。</returns>
        public static Graphics CreateGraphics(IntPtr hWnd)
        {
            return Graphics.FromHwndInternal(hWnd);
        }
        /// <summary>
        /// 将指定屏幕点的位置计算成工作区坐标。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <param name="p">要转换的屏幕坐标 System.Drawing.Point。</param>
        /// <returns>一个 System.Drawing.Point，它表示转换后的 System.Drawing.Point、p（以工作区坐标表示）。</returns>
        public static Point PointToClient(IntPtr hWnd, Point p)
        {
            NativeMethods.POINT pt = new NativeMethods.POINT(p.X, p.Y);
            UnsafeNativeMethods.MapWindowPoints(NativeMethods.HWND_DESKTOP, hWnd, ref pt, 1);
            return new Point(pt.x, pt.y);
        }
        /// <summary>
        /// 将指定工作区点的位置计算成屏幕坐标。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <param name="p">要转换的工作区坐标 System.Drawing.Point。</param>
        /// <returns>一个 System.Drawing.Point，它表示转换后的 System.Drawing.Point、p（以屏幕坐标表示）。</returns>
        public static Point PointToScreen(IntPtr hWnd, Point p)
        {
            NativeMethods.POINT pt = new NativeMethods.POINT(p.X, p.Y);
            UnsafeNativeMethods.MapWindowPoints(hWnd, NativeMethods.HWND_DESKTOP, ref pt, 1);
            return new Point(pt.x, pt.y);
        }
        /// <summary>
        /// 计算指定屏幕矩形的大小和位置（以工作区坐标表示）。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <param name="r">要转换的屏幕坐标 System.Drawing.Rectangle。</param>
        /// <returns>一个 System.Drawing.Rectangle，它表示转换后的 System.Drawing.Rectangle、r（以工作区坐标表示）。</returns>
        public static Rectangle RectangleToClient(IntPtr hWnd, Rectangle r)
        {
            NativeMethods.RECT rect = new NativeMethods.RECT(r);
            UnsafeNativeMethods.MapWindowPoints(NativeMethods.HWND_DESKTOP, hWnd, ref rect, 2);
            return rect.ToRectangle();
        }
        /// <summary>
        /// 计算指定工作区矩形的大小和位置（以屏幕坐标表示）。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <param name="r">要转换的工作区坐标 System.Drawing.Rectangle。</param>
        /// <returns>一个 System.Drawing.Rectangle，它表示转换后的 System.Drawing.Rectangle、r（以屏幕坐标表示）。</returns>
        public static Rectangle RectangleToScreen(IntPtr hWnd, Rectangle r)
        {
            NativeMethods.RECT rect = new NativeMethods.RECT(r);
            UnsafeNativeMethods.MapWindowPoints(hWnd, NativeMethods.HWND_DESKTOP, ref rect, 2);
            return rect.ToRectangle();
        }
        /// <summary>
        /// 使控件的整个图面无效并导致重绘控件。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        public static void Invalidate(IntPtr hWnd)
        {
            Invalidate(hWnd, false);
        }
        /// <summary>
        /// 使控件的指定区域无效（将其添加到控件的更新区域，下次绘制操作时将重新绘制更新区域），并向控件发送绘制消息。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <param name="rc">一个 System.Drawing.Rectangle，表示要使之无效的区域。</param>
        public static void Invalidate(IntPtr hWnd, Rectangle rc)
        {
            Invalidate(hWnd, rc, false);
        }
        /// <summary>
        /// 使控件的指定区域无效（将其添加到控件的更新区域，下次绘制操作时将重新绘制更新区域），并向控件发送绘制消息。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <param name="region">要使之无效的 System.Drawing.Region。</param>
        public static void Invalidate(IntPtr hWnd, Region region)
        {
            Invalidate(hWnd, region, false);
        }
        /// <summary>
        /// 使控件的特定区域无效并向控件发送绘制消息。还可以使分配给该控件的子控件无效。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <param name="invalidateChildren">若要使控件的子控件无效，则为 true；否则为 false。</param>
        public static void Invalidate(IntPtr hWnd, bool invalidateChildren)
        {
            if (GetIsHandleCreated(hWnd))
            {
                if (invalidateChildren)
                {
                    UnsafeNativeMethods.RedrawWindow(hWnd, IntPtr.Zero, IntPtr.Zero, NativeMethods.RDW_ALLCHILDREN | NativeMethods.RDW_INVALIDATE);//.Net Framework :多NativeMethods.RDW_ERASE
                }
                else
                {
                    UnsafeNativeMethods.InvalidateRect(hWnd, IntPtr.Zero, false);//.Net Framework :支持透明为true,否则false
                }
            }
        }
        /// <summary>
        /// 使控件的指定区域无效（将其添加到控件的更新区域，下次绘制操作时将重新绘制更新区域），并向控件发送绘制消息。还可以使分配给该控件的子控件无效。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <param name="rc">一个 System.Drawing.Rectangle，表示要使之无效的区域。</param>
        /// <param name="invalidateChildren">若要使控件的子控件无效，则为 true；否则为 false。</param>
        public static void Invalidate(IntPtr hWnd, Rectangle rc, bool invalidateChildren)
        {
            if (rc.IsEmpty)
            {
                Invalidate(hWnd, invalidateChildren);
            }
            else if (GetIsHandleCreated(hWnd))
            {
                if (invalidateChildren)
                {
                    NativeMethods.RECT rcUpdate = NativeMethods.RECT.FromXYWH(rc.X, rc.Y, rc.Width, rc.Height);
                    UnsafeNativeMethods.RedrawWindow(hWnd, ref rcUpdate, IntPtr.Zero, NativeMethods.RDW_ALLCHILDREN | NativeMethods.RDW_INVALIDATE);//.Net Framework :多NativeMethods.RDW_ERASE
                }
                else
                {
                    NativeMethods.RECT rect = NativeMethods.RECT.FromXYWH(rc.X, rc.Y, rc.Width, rc.Height);
                    UnsafeNativeMethods.InvalidateRect(hWnd, ref rect, false);//.Net Framework :支持透明为true,否则false
                }
            }
        }
        /// <summary>
        /// 使控件的指定区域无效（将其添加到控件的更新区域，下次绘制操作时将重新绘制更新区域），并向控件发送绘制消息。还可以使分配给该控件的子控件无效。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        /// <param name="region">要使之无效的 System.Drawing.Region。</param>
        /// <param name="invalidateChildren">若要使控件的子控件无效，则为 true；否则为 false。</param>
        public static void Invalidate(IntPtr hWnd, Region region, bool invalidateChildren)
        {
            if (region == null)
            {
                Invalidate(hWnd, invalidateChildren);
            }
            else if (GetIsHandleCreated(hWnd))
            {
                IntPtr hRgn = GetHRgn(hWnd, region);
                try
                {
                    if (invalidateChildren)
                    {
                        UnsafeNativeMethods.RedrawWindow(hWnd, IntPtr.Zero, hRgn, NativeMethods.RDW_ALLCHILDREN | NativeMethods.RDW_INVALIDATE);//.Net Framework :多NativeMethods.RDW_ERASE
                    }
                    else
                    {
                        UnsafeNativeMethods.InvalidateRgn(hWnd, hRgn, false);//.Net Framework :支持透明为true,否则false
                    }
                }
                finally
                {
                    UnsafeNativeMethods.DeleteObject(hRgn);
                }
            }
        }
        /// <summary>
        /// 用当前大小和位置更新控件的边界。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        public static void Update(IntPtr hWnd)
        {
            UnsafeNativeMethods.UpdateWindow(hWnd);
        }
        /// <summary>
        /// 强制控件使其工作区无效并立即重绘自己和任何子控件。
        /// </summary>
        /// <param name="hWnd">控件句柄。</param>
        public static void Refresh(IntPtr hWnd)
        {
            Invalidate(hWnd, true);
            Update(hWnd);
        }

        #endregion
    }
}
