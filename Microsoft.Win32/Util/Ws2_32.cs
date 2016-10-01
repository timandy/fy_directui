using System;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// Ws2_32扩展
    /// </summary>
    public static partial class Util
    {
        /// <summary>
        /// 获取扩展函数指针
        /// </summary>
        /// <param name="guid">扩展函数标识</param>
        /// <param name="type">函数类型</param>
        /// <param name="socket">socket 指针</param>
        /// <returns>函数指针</returns>
        public static Delegate SioGetExtensionFunctionPointer(Guid guid, Type type, IntPtr socket)
        {
            IntPtr funPointer = IntPtr.Zero;
            int byteTransfered = 0;
            SocketError nErrorCode = UnsafeNativeMethods.WSAIoctl(socket, NativeMethods.SIO_GET_EXTENSION_FUNCTION_POINTER, ref guid, Marshal.SizeOf(guid), ref funPointer, IntPtr.Size, out byteTransfered, NativeMethods.NULL, NativeMethods.NULL);
            if (nErrorCode != SocketError.Success)
                throw new SocketException((int)nErrorCode);
            return Marshal.GetDelegateForFunctionPointer(funPointer, type);
        }
    }
}
