using System;

namespace Microsoft.Win32
{
    //HWND定义
    public static partial class NativeMethods
    {
        /// <summary>
        /// 桌面窗口句柄  参见MapWindowPoints
        /// </summary>
        public static readonly IntPtr HWND_DESKTOP = IntPtr.Zero;

        /// <summary>
        /// 将窗口置于Z序的顶部。 参见SetWindowPos
        /// </summary>
        public static readonly IntPtr HWND_TOP = IntPtr.Zero;
        /// <summary>
        /// 将窗口置于Z序的底部。如果参数hWnd标识了一个顶层窗口，则窗口失去顶级位置，并且被置在其他窗口的底部。 参见SetWindowPos
        /// </summary>
        public static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        /// <summary>
        /// 将窗口置于所有非顶层窗口之上。即使窗口未被激活窗口也将保持顶级位置。 参见SetWindowPos
        /// </summary>
        public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        /// <summary>
        /// 将窗口置于所有非顶层窗口之上（即在所有顶层窗口之后）。如果窗口已经是非顶层窗口则该标志不起作用。 参见SetWindowPos
        /// </summary>
        public static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);

        /// <summary>
        /// 消息被寄送到系统的所有顶层窗口，包括无效或不可见的非自身拥有的窗口、 被覆盖的窗口和弹出式窗口。消息不被寄送到子窗口  参见PostMessage
        /// </summary>
        public static readonly IntPtr HWND_BROADCAST = new IntPtr(0xFFFF);
        /// <summary>
        /// 如果hwndParent是HWND_MESSAGE，函数仅查找所有消息窗口。 参见FindWindowEx
        /// </summary>
        public static readonly IntPtr HWND_MESSAGE = new IntPtr(-3);
    }
}
