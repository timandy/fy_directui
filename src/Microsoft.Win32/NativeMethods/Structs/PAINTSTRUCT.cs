using System;
using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// 绘图结构定义
    /// </summary>
    public static partial class NativeMethods
    {
        /// <summary>
        /// 绘图结构
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct PAINTSTRUCT
        {
            /// <summary>
            /// 是用于绘制的句柄
            /// </summary>
            public IntPtr hdc;
            /// <summary>
            /// 如果为非零值则擦除背景，否则不擦除背景
            /// </summary>
            public bool fErase;
            /// <summary>
            /// 通过制定左上角和右下角的坐标确定一个要绘制的矩形范围，该矩形单位相对于客户区左上角
            /// </summary>
            public RECT rcPaint;
            /// <summary>
            /// Reserved; used internally by the system.
            /// </summary>
            public bool fRestore;
            /// <summary>
            /// Reserved; used internally by the system.
            /// </summary>
            public bool fIncUpdate;
            /// <summary>
            /// Reserved; used internally by the system.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] rgbReserved;
        }
    }
}
