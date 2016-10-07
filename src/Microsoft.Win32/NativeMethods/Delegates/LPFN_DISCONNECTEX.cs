using System;

namespace Microsoft.Win32
{
    //LPFN_DISCONNECTEX定义
    public static partial class NativeMethods
    {
        /// <summary>
        /// The DisconnectEx function closes a connection on a socket, and allows the socket handle to be reused.Note  This function is a Microsoft-specific extension to the Windows Sockets specification.
        /// </summary>
        /// <param name="s">A handle to a connected, connection-oriented socket.</param>
        /// <param name="lpOverlapped">A pointer to an OVERLAPPED structure. If the socket handle has been opened as overlapped, specifying this parameter results in an overlapped (asynchronous) I/O operation.</param>
        /// <param name="dwFlags">A set of flags that customizes processing of the function call. When this parameter is set to zero, no flags are set. The dwFlags parameter can have the following value.</param>
        /// <param name="dwReserved">Reserved. Must be zero. If nonzero, WSAEINVAL is returned.</param>
        /// <returns>On success, the DisconnectEx function returns TRUE. On failure, the function returns FALSE. Use the WSAGetLastError function to get extended error information. If a call to the WSAGetLastError function returns ERROR_IO_PENDING, the operation initiated successfully and is in progress. Under such circumstances, the call may still fail when the operation completes.</returns>
        public delegate bool LPFN_DISCONNECTEX(
            IntPtr s,
            IntPtr lpOverlapped,
            int dwFlags,
            int dwReserved
            );
    }
}
