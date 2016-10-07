using System;
using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// NMHDR定义
    /// </summary>
    public static partial class NativeMethods
    {
        /// <summary>
        /// NMHDR结构
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct NMHDR
        {
            /// <summary>
            /// A window handle to the control sending the message.
            /// </summary>
            public IntPtr hwndFrom;
            /// <summary>
            /// An identifier of the control sending the message.
            /// </summary>
            public IntPtr idFrom;
            /// <summary>
            /// A notification code. This member can be one of the common notification codes (see Notifications under General Control Reference), or it can be a control-specific notification code.
            /// </summary>
            public int code;         // NM_ code
        }
    }
}
