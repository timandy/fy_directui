using System;
using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// MOUSEINPUT定义
    /// </summary>
    public static partial class NativeMethods
    {
        /// <summary>
        /// 鼠标输入
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEINPUT
        {
            /// <summary>
            /// Provides the absolute position of the mouse, or the amount of motion since the last mouse event was generated, depending on the value of the dwFlags member. Absolute data is provided as the x coordinate of the mouse; relative data is provided as the number of pixels moved.
            /// </summary>
            public int dx;
            /// <summary>
            /// Provides the absolute position of the mouse, or the amount of motion since the last mouse event was generated, depending on the value of the dwFlags member. Absolute data is provided as the y coordinate of the mouse; relative data is provided as the number of pixels moved.
            /// </summary>
            public int dy;
            /// <summary>
            /// If dwFlags contains MOUSEEVENTF_WHEEL, then mouseData provides the amount of wheel movement. A positive value indicates that the wheel was rotated forward, away from the user; a negative value indicates that the wheel was rotated backward, toward the user. One wheel click is defined as WHEEL_DELTA, which is 120.f dwFlags does not contain MOUSEEVENTF_WHEEL then mouseData should be zero.
            /// </summary>
            public int mouseData;
            /// <summary>
            /// Set of bit flags that indicate various aspects of mouse motion and button clicks. The bits in this member can be any reasonable combination of the following values.
            /// </summary>
            public int dwFlags;
            /// <summary>
            /// Time stamp for the event, in milliseconds. If this parameter is 0, the system will provide its own time stamp.
            /// </summary>
            public int time;
            /// <summary>
            /// Data in this member is ignored.
            /// </summary>
            public IntPtr dwExtraInfo;
        }
    }
}
