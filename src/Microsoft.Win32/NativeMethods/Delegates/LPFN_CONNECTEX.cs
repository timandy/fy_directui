using System;

namespace Microsoft.Win32
{
    //LPFN_CONNECTEX定义
    public static partial class NativeMethods
    {
        /// <summary>
        /// The ConnectEx function establishes a connection to a specified socket, and optionally sends data once the connection is established. The ConnectEx function is only supported on connection-oriented sockets.Note  This function is a Microsoft-specific extension to the Windows Sockets specification.
        /// </summary>
        /// <param name="s">A descriptor that identifies an unconnected, previously bound socket. See Remarks for more information.</param>
        /// <param name="name">A pointer to a sockaddr structure that specifies the address to which to connect. For IPv4, the sockaddr contains AF_INET for the address family, the destination IPv4 address, and the destination port. For IPv6, the sockaddr structure contains AF_INET6 for the address family, the destination IPv6 address, the destination port, and may contain additional IPv6 flow and scope-id information.</param>
        /// <param name="namelen">The length, in bytes, of the sockaddr structure pointed to by the name parameter.</param>
        /// <param name="lpSendBuffer">A pointer to the buffer to be transferred after a connection is established. This parameter is optional.Note  This parameter does not point to "connect data" that is sent as part of connection establishment. To send "connect data" using the ConnectEx function, the setsockopt function must be called on the unconnected socket s with the SO_CONNDATA socket option to set a pointer to a buffer containing the connect data, and then called with the SO_CONNDATALEN socket option to set the length of the "connect data" in the buffer. Then the ConnectEx function can be called. As an alternative, the WSAConnect function can be used if connect data is to be sent as part of connection establishment.</param>
        /// <param name="dwSendDataLength">The length, in bytes, of data pointed to by the lpSendBuffer parameter. This parameter is ignored when the lpSendBuffer parameter is NULL.</param>
        /// <param name="lpdwBytesSent">On successful return, this parameter points to a DWORD value that indicates the number of bytes that were sent after the connection was established. The bytes sent are from the buffer pointed to by the lpSendBuffer parameter. This parameter is ignored when the lpSendBuffer parameter is NULL.</param>
        /// <param name="lpOverlapped">An OVERLAPPED structure used to process the request. The lpOverlapped parameter must be specified, and cannot be NULL.</param>
        /// <returns>On success, the ConnectEx function returns TRUE. On failure, the function returns FALSE. Use the WSAGetLastError function to get extended error information. If a call to the WSAGetLastError function returns ERROR_IO_PENDING, the operation initiated successfully and is in progress. Under such circumstances, the call may still fail when the overlapped operation completes.If the error code returned is WSAECONNREFUSED, WSAENETUNREACH, or WSAETIMEDOUT, the application can call ConnectEx, WSAConnect, or connect again on the same socket.</returns>
        public delegate bool LPFN_CONNECTEX(
            IntPtr s,
            byte[] name,
            int namelen,
            IntPtr lpSendBuffer,
            int dwSendDataLength,
            out int lpdwBytesSent,
            IntPtr lpOverlapped
            );
    }
}
