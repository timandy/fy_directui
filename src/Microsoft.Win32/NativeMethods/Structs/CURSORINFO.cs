using System;
using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// CURSORINFO定义
    /// </summary>
    public static partial class NativeMethods
    {
        /// <summary>
        /// 光标信息
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct CURSORINFO
        {
            /// <summary>
            /// Specifies the size, in bytes, of the structure. The caller must set this to Marshal.SizeOf(typeof(CURSORINFO)).
            /// </summary>
            public int cbSize;
            /// <summary>
            /// Specifies the cursor state. This parameter can be one of the following values:0 The cursor is hidden.1 The cursor is showing.
            /// </summary>
            public int flags;
            /// <summary>
            /// Handle to the cursor. 
            /// </summary>
            public IntPtr hCursor;
            /// <summary>
            /// A POINT structure that receives the screen coordinates of the cursor. 
            /// </summary>
            public POINT ptScreenPos;
        }
    }
}
