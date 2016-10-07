using System;

namespace Microsoft.Win32
{
    //LPFN_ACCEPTEX定义
    public static partial class NativeMethods
    {
        /// <summary>
        /// The AcceptEx function accepts a new connection, returns the local and remote address, and receives the first block of data sent by the client application.Hinweis  This function is a Microsoft-specific extension to the Windows Sockets specification.
        /// </summary>
        /// <param name="sListenSocket">A descriptor identifying a socket that has already been called with the listen function. A server application waits for attempts to connect on this socket.</param>
        /// <param name="sAcceptSocket">A descriptor identifying a socket on which to accept an incoming connection. This socket must not be bound or connected.</param>
        /// <param name="lpOutputBuffer">A pointer to a buffer that receives the first block of data sent on a new connection, the local address of the server, and the remote address of the client. The receive data is written to the first part of the buffer starting at offset zero, while the addresses are written to the latter part of the buffer. This parameter must be specified.</param>
        /// <param name="dwReceiveDataLength">The number of bytes in lpOutputBuffer that will be used for actual receive data at the beginning of the buffer. This size should not include the size of the local address of the server, nor the remote address of the client; they are appended to the output buffer. If dwReceiveDataLength is zero, accepting the connection will not result in a receive operation. Instead, AcceptEx completes as soon as a connection arrives, without waiting for any data.</param>
        /// <param name="dwLocalAddressLength">The number of bytes reserved for the local address information. This value must be at least 16 bytes more than the maximum address length for the transport protocol in use.</param>
        /// <param name="dwRemoteAddressLength">The number of bytes reserved for the remote address information. This value must be at least 16 bytes more than the maximum address length for the transport protocol in use. Cannot be zero.</param>
        /// <param name="lpdwBytesReceived">A pointer to a DWORD that receives the count of bytes received. This parameter is set only if the operation completes synchronously. If it returns ERROR_IO_PENDING and is completed later, then this DWORD is never set and you must obtain the number of bytes read from the completion notification mechanism.</param>
        /// <param name="lpOverlapped">An OVERLAPPED structure that is used to process the request. This parameter must be specified; it cannot be NULL.</param>
        /// <returns>If no error occurs, the AcceptEx function completed successfully and a value of TRUE is returned.If the function fails, AcceptEx returns FALSE. The WSAGetLastError function can then be called to return extended error information. If WSAGetLastError returns ERROR_IO_PENDING, then the operation was successfully initiated and is still in progress. If the error is WSAECONNRESET, an incoming connection was indicated, but was subsequently terminated by the remote peer prior to accepting the call.</returns>
        public delegate bool LPFN_ACCEPTEX(
            IntPtr sListenSocket,
            IntPtr sAcceptSocket,
            IntPtr lpOutputBuffer,
            int dwReceiveDataLength,
            int dwLocalAddressLength,
            int dwRemoteAddressLength,
            out int lpdwBytesReceived,
            IntPtr lpOverlapped
            );
    }
}
