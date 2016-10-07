using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// INPUT定义
    /// </summary>
    public static partial class NativeMethods
    {
        /// <summary>
        /// 输入数据,如果是64位系统应该改为[FieldOffset(8)]
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        public struct INPUT
        {
            /// <summary>
            /// Indicates the type of device information this structure carries. It is one of the following values.
            /// </summary>
            [FieldOffset(0)]
            public int type;
            /// <summary>
            /// MOUSEINPUT structure that contains information about simulated mouse input.
            /// </summary>
            [FieldOffset(4)]
            public MOUSEINPUT mi;
            /// <summary>
            /// KEYBDINPUT structure that contains information about simulated keyboard input.
            /// </summary>
            [FieldOffset(4)]
            public KEYBDINPUT ki;
            /// <summary>
            /// HARDWAREINPUT structure that contains information about a simulated input device message.
            /// </summary>
            [FieldOffset(4)]
            public HARDWAREINPUT hi;
        }
    }
}
