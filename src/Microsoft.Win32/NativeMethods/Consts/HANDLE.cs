using System;

namespace Microsoft.Win32
{
    //HANDLE定义
    public static partial class NativeMethods
    {
        /// <summary>
        /// 无效句柄值
        /// </summary>
        public static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
    }
}
