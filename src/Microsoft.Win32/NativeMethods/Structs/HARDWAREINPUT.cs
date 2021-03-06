﻿using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// HARDWAREINPUT定义
    /// </summary>
    public static partial class NativeMethods
    {
        /// <summary>
        /// 硬件输入
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct HARDWAREINPUT
        {
            /// <summary>
            /// The message generated by the input hardware.
            /// </summary>
            public int uMsg;
            /// <summary>
            /// The low-order word of the lParam parameter for uMsg.
            /// </summary>
            public short wParamL;
            /// <summary>
            /// The high-order word of the lParam parameter for uMsg.
            /// </summary>
            public short wParamH;
        }
    }
}
