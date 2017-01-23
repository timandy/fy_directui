using System;
using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// FLASHWINFO定义
    /// </summary>
    public static partial class NativeMethods
    {
        /// <summary>
        /// FLASHWINFO
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO
        {
            /// <summary>
            /// The size of the structure, in bytes.
            /// </summary>
            public int cbSize;
            /// <summary>
            /// A handle to the window to be flashed. The window can be either opened or minimized.
            /// </summary>
            public IntPtr hwnd;
            /// <summary>
            /// The flash status. This parameter can be one or more of the following values.see FLASHW_
            /// </summary>
            public int dwFlags;
            /// <summary>
            /// The number of times to flash the window.
            /// </summary>
            public int uCount;
            /// <summary>
            /// The rate at which the window is to be flashed, in milliseconds. If dwTimeout is zero, the function uses the default cursor blink rate.
            /// </summary>
            public int dwTimeout;
        }
    }
}
