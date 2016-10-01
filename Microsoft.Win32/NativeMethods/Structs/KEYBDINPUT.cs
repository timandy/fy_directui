using System;
using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// KEYBDINPUT∂®“Â
    /// </summary>
    public static partial class NativeMethods
    {
        /// <summary>
        /// º¸≈Ã ‰»Î
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct KEYBDINPUT
        {
            /// <summary>
            /// Provides a virtual-key code. The code must be a value in the range 1 to 254. The Winuser.h header file provides macro definitions (VK_*) for each value. If the dwFlags member specifies KEYEVENTF_UNICODE, then wVk must be 0.
            /// </summary>
            public short wVk;
            /// <summary>
            /// Provides a hardware scan code for the key. If dwFlags specifies KEYEVENTF_UNICODE, then wScan specifies a Unicode character that is to be sent to the foreground application.
            /// </summary>
            public short wScan;
            /// <summary>
            /// Provides various aspects of a keystroke. This member can be a combination of the following values.
            /// </summary>
            public int dwFlags;
            /// <summary>
            /// Data in this member is ignored.
            /// </summary>
            public int time;
            /// <summary>
            /// Data in this member is ignored.
            /// </summary>
            public IntPtr dwExtraInfo;
        }
    }
}
