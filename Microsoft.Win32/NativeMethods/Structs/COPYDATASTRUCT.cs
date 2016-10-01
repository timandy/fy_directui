using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// COPYDATASTRUCT定义
    /// </summary>
    public static partial class NativeMethods
    {
        /// <summary>
        /// 进程间传递数据结构
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct COPYDATASTRUCT
        {
            /// <summary>
            /// flag
            /// </summary>
            public int dwData;//flag
            /// <summary>
            /// 大小
            /// </summary>
            public int cbData;//size
            /// <summary>
            /// 数据
            /// </summary>
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }
    }
}
