using System;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// Ws2_32.dll
    /// </summary>
    public static partial class UnsafeNativeMethods
    {
        /// <summary>
        /// The WSAStartup function initiates use of the Winsock DLL by a process.
        /// </summary>
        /// <param name="wVersionRequested">The highest version of Windows Sockets specification that the caller can use. The high-order byte specifies the minor version number; the low-order byte specifies the major version number.</param>
        /// <param name="lpWSAData">A pointer to the WSADATA data structure that is to receive details of the Windows Sockets implementation.</param>
        /// <returns>If successful, the WSAStartup function returns zero. Otherwise, it returns one of the error codes listed below.The WSAStartup function directly returns the extended error code in the return value for this function. A call to the WSAGetLastError function is not needed and should not be used.</returns>
        [DllImport("ws2_32.dll", SetLastError = true)]
        public static extern SocketError WSAStartup(int wVersionRequested, out NativeMethods.WSADATA lpWSAData);

        /// <summary>
        /// The WSACleanup function terminates use of the Winsock 2 DLL (Ws2_32.dll).
        /// </summary>
        /// <returns>The return value is zero if the operation was successful. Otherwise, the value SOCKET_ERROR is returned, and a specific error number can be retrieved by calling WSAGetLastError.In a multithreaded environment, WSACleanup terminates Windows Sockets operations for all threads.</returns>
        [DllImport("ws2_32.dll", SetLastError = true)]
        public static extern SocketError WSACleanup();

        /// <summary>
        /// The WSASocket function creates a socket that is bound to a specific transport-service provider.
        /// </summary>
        /// <param name="af">The address family specification. Possible values for the address family are defined in the Winsock2.h header file.On the Windows SDK released for Windows Vista and later, the organization of header files has changed and the possible values for the address family are defined in the Ws2def.h header file. Note that the Ws2def.h header file is automatically included in Winsock2.h, and should never be used directly.The values currently supported are AF_INET or AF_INET6, which are the Internet address family formats for IPv4 and IPv6. Other options for address family (AF_NETBIOS for use with NetBIOS, for example) are supported if a Windows Sockets service provider for the address family is installed. Note that the values for the AF_ address family and PF_ protocol family constants are identical (for example, AF_INET and PF_INET), so either constant can be used.The table below lists common values for address family although many other values are possible.</param>
        /// <param name="type">The type specification for the new socket. Possible values for the socket type are defined in the Winsock2.h header file.The following table lists the possible values for the type parameter supported for Windows Sockets 2:In Windows Sockets 2, new socket types were introduced. An application can dynamically discover the attributes of each available transport protocol through the WSAEnumProtocols function. So an application can determine the possible socket type and protocol options for an address family and use this information when specifying this parameter. Socket type definitions in the Winsock2.h and Ws2def.h header files will be periodically updated as new socket types, address families, and protocols are defined.In Windows Sockets 1.1, the only possible socket types are SOCK_DGRAM and SOCK_STREAM.</param>
        /// <param name="protocol">The protocol to be used. The possible options for the protocol parameter are specific to the address family and socket type specified. Possible values for the protocol are defined are defined in the Winsock2.h and Wsrm.h header files.On the Windows SDK released for Windows Vista and later,, the organization of header files has changed and this parameter can be one of the values from the IPPROTO enumeration type defined in the Ws2def.h header file. Note that the Ws2def.h header file is automatically included in Winsock2.h, and should never be used directly.If a value of 0 is specified, the caller does not wish to specify a protocol and the service provider will choose the protocol to use.When the af parameter is AF_INET or AF_INET6 and the type is SOCK_RAW, the value specified for the protocol is set in the protocol field of the IPv6 or IPv4 packet header.The table below lists common values for the protocol although many other values are possible.</param>
        /// <param name="lpProtocolInfo">A pointer to a WSAPROTOCOL_INFO structure that defines the characteristics of the socket to be created. If this parameter is not NULL, the socket will be bound to the provider associated with the indicated WSAPROTOCOL_INFO structure.</param>
        /// <param name="g">An existing socket group ID or an appropriate action to take when creating a new socket and a new socket group.If g is an existing socket group ID, join the new socket to this socket group, provided all the requirements set by this group are met.If g is not an existing socket group ID, then the following values are possible.</param>
        /// <param name="dwFlags">A set of flags used to specify additional socket attributes.A combination of these flags may be set, although some combinations are not allowed.Important  For multipoint sockets, only one of WSA_FLAG_MULTIPOINT_C_ROOT or WSA_FLAG_MULTIPOINT_C_LEAF flags can be specified, and only one of WSA_FLAG_MULTIPOINT_D_ROOT or WSA_FLAG_MULTIPOINT_D_LEAF flags can be specified. Refer to Multipoint and Multicast Semantics for additional information.</param>
        /// <returns>If no error occurs, WSASocket returns a descriptor referencing the new socket. Otherwise, a value of INVALID_SOCKET is returned, and a specific error code can be retrieved by calling WSAGetLastError.Note  This error code description is Microsoft-specific.</returns>
        [DllImport("ws2_32.dll", SetLastError = true)]
        public static extern IntPtr WSASocket(AddressFamily af, SocketType type, ProtocolType protocol, IntPtr lpProtocolInfo, uint g, int dwFlags);

        /// <summary>
        /// The WSASend function sends data on a connected socket.
        /// </summary>
        /// <param name="s">A descriptor that identifies a connected socket.</param>
        /// <param name="lpBuffers">A pointer to an array of WSABUF structures. Each WSABUF structure contains a pointer to a buffer and the length, in bytes, of the buffer. For a Winsock application, once the WSASend function is called, the system owns these buffers and the application may not access them. This array must remain valid for the duration of the send operation.</param>
        /// <param name="dwBufferCount">The number of WSABUF structures in the lpBuffers array.</param>
        /// <param name="lpNumberOfBytesSent">A pointer to the number, in bytes, sent by this call if the I/O operation completes immediately.Use NULL for this parameter if the lpOverlapped parameter is not NULL to avoid potentially erroneous results. This parameter can be NULL only if the lpOverlapped parameter is not NULL.</param>
        /// <param name="dwFlags">The flags used to modify the behavior of the WSASend function call. For more information, see Using dwFlags in the Remarks section.</param>
        /// <param name="lpOverlapped">A pointer to a WSAOVERLAPPED structure. This parameter is ignored for nonoverlapped sockets.</param>
        /// <param name="lpCompletionRoutine">A pointer to the completion routine called when the send operation has been completed. This parameter is ignored for nonoverlapped sockets.</param>
        /// <returns>If no error occurs and the send operation has completed immediately, WSASend returns zero. In this case, the completion routine will have already been scheduled to be called once the calling thread is in the alertable state. Otherwise, a value of SOCKET_ERROR is returned, and a specific error code can be retrieved by calling WSAGetLastError. The error code WSA_IO_PENDING indicates that the overlapped operation has been successfully initiated and that completion will be indicated at a later time. Any other error code indicates that the overlapped operation was not successfully initiated and no completion indication will occur.</returns>
        [DllImport("ws2_32.dll", SetLastError = true)]
        public static extern SocketError WSASend(IntPtr s, ref NativeMethods.WSABUF lpBuffers, int dwBufferCount, int lpNumberOfBytesSent, ref SocketFlags dwFlags, IntPtr lpOverlapped, IntPtr lpCompletionRoutine);

        /// <summary>
        /// The WSARecvFrom function receives a datagram and stores the source address.
        /// </summary>
        /// <param name="s">A descriptor identifying a socket.</param>
        /// <param name="lpBuffers">A pointer to an array of WSABUF structures. Each WSABUF structure contains a pointer to a buffer and the length of the buffer.</param>
        /// <param name="dwBufferCount">The number of WSABUF structures in the lpBuffers array.</param>
        /// <param name="lpNumberOfBytesRecvd">A pointer to the number of bytes received by this call if the WSARecvFrom operation completes immediately.Use NULL for this parameter if the lpOverlapped parameter is not NULL to avoid potentially erroneous results. This parameter can be NULL only if the lpOverlapped parameter is not NULL.</param>
        /// <param name="lpFlags">A pointer to flags used to modify the behavior of the WSARecvFrom function call. See remarks below.</param>
        /// <param name="lpOverlapped">An optional pointer to a buffer that will hold the source address upon the completion of the overlapped operation.</param>
        /// <param name="lpCompletionRoutine">A pointer to the size, in bytes, of the "from" buffer required only if lpFrom is specified.</param>
        /// <returns>A pointer to a WSAOVERLAPPED structure (ignored for nonoverlapped sockets).</returns>
        [DllImport("ws2_32.dll", SetLastError = true)]
        public static extern SocketError WSARecv(IntPtr s, ref NativeMethods.WSABUF lpBuffers, int dwBufferCount, out int lpNumberOfBytesRecvd, ref SocketFlags lpFlags, IntPtr lpOverlapped, IntPtr lpCompletionRoutine);

        /// <summary>
        /// The WSAGetOverlappedResult function retrieves the results of an overlapped operation on the specified socket.
        /// </summary>
        /// <param name="s">A descriptor identifying the socket.This is the same socket that was specified when the overlapped operation was started by a call to any of the Winsock functions that supports overlappped operations. These functions include AcceptEx, ConnectEx, DisconnectEx, TransmitFile, TransmitPackets, WSARecv, WSARecvFrom, WSARecvMsg, WSASend, WSASendMsg, WSASendTo, and WSAIoctl.</param>
        /// <param name="lpOverlapped">A pointer to a WSAOVERLAPPED structure that was specified when the overlapped operation was started. This parameter must not be a NULL pointer.</param>
        /// <param name="lpcbTransfer">A pointer to a 32-bit variable that receives the number of bytes that were actually transferred by a send or receive operation, or by the WSAIoctl function. This parameter must not be a NULL pointer.</param>
        /// <param name="fWait">A flag that specifies whether the function should wait for the pending overlapped operation to complete. If TRUE, the function does not return until the operation has been completed. If FALSE and the operation is still pending, the function returns FALSE and the WSAGetLastError function returns WSA_IO_INCOMPLETE. The fWait parameter may be set to TRUE only if the overlapped operation selected the event-based completion notification.</param>
        /// <param name="lpdwFlags">A pointer to a 32-bit variable that will receive one or more flags that supplement the completion status. If the overlapped operation was initiated through WSARecv or WSARecvFrom, this parameter will contain the results value for lpFlags parameter. This parameter must not be a NULL pointer.</param>
        /// <returns>If WSAGetOverlappedResult succeeds, the return value is TRUE. This means that the overlapped operation has completed successfully and that the value pointed to by lpcbTransfer has been updated.If WSAGetOverlappedResult returns FALSE, this means that either the overlapped operation has not completed, the overlapped operation completed but with errors, or the overlapped operation's completion status could not be determined due to errors in one or more parameters to WSAGetOverlappedResult. On failure, the value pointed to by lpcbTransfer will not be updated. Use WSAGetLastError to determine the cause of the failure (either by the WSAGetOverlappedResult function or by the associated overlapped operation).</returns>
        [DllImport("ws2_32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WSAGetOverlappedResult(IntPtr s, IntPtr lpOverlapped, out int lpcbTransfer, bool fWait, out SocketFlags lpdwFlags);

        /// <summary>
        /// The WSAIoctl function controls the mode of a socket.
        /// </summary>
        /// <param name="s">A descriptor identifying a socket.</param>
        /// <param name="dwIoControlCode">The control code of operation to perform.</param>
        /// <param name="lpvInBuffer">A pointer to the input buffer.</param>
        /// <param name="cbInBuffer">The size, in bytes, of the input buffer.</param>
        /// <param name="lpvOutBuffer">A pointer to the output buffer.</param>
        /// <param name="cbOutBuffer">The size, in bytes, of the output buffer.</param>
        /// <param name="lpcbBytesReturned">A pointer to actual number of bytes of output.</param>
        /// <param name="lpOverlapped">A pointer to a WSAOVERLAPPED structure (ignored for non-overlapped sockets).</param>
        /// <param name="lpCompletionRoutine">Note  A pointer to the completion routine called when the operation has been completed (ignored for non-overlapped sockets). See Remarks.</param>
        /// <returns>Upon successful completion, the WSAIoctl returns zero. Otherwise, a value of SOCKET_ERROR is returned, and a specific error code can be retrieved by calling WSAGetLastError.</returns>
        [DllImport("ws2_32.dll", SetLastError = true)]
        public static extern SocketError WSAIoctl(IntPtr s, int dwIoControlCode, byte[] lpvInBuffer, int cbInBuffer, byte[] lpvOutBuffer, int cbOutBuffer, out int lpcbBytesReturned, IntPtr lpOverlapped, IntPtr lpCompletionRoutine);

        /// <summary>
        /// The WSAIoctl function controls the mode of a socket.
        /// </summary>
        /// <param name="s">A descriptor identifying a socket.</param>
        /// <param name="dwIoControlCode">The control code of operation to perform.</param>
        /// <param name="lpvInBuffer">A pointer to the input buffer.</param>
        /// <param name="cbInBuffer">The size, in bytes, of the input buffer.</param>
        /// <param name="lpvOutBuffer">A pointer to the output buffer.</param>
        /// <param name="cbOutBuffer">The size, in bytes, of the output buffer.</param>
        /// <param name="lpcbBytesReturned">A pointer to actual number of bytes of output.</param>
        /// <param name="lpOverlapped">A pointer to a WSAOVERLAPPED structure (ignored for non-overlapped sockets).</param>
        /// <param name="lpCompletionRoutine">Note  A pointer to the completion routine called when the operation has been completed (ignored for non-overlapped sockets). See Remarks.</param>
        /// <returns>Upon successful completion, the WSAIoctl returns zero. Otherwise, a value of SOCKET_ERROR is returned, and a specific error code can be retrieved by calling WSAGetLastError.</returns>
        [DllImport("Ws2_32.dll", SetLastError = true)]
        public static extern SocketError WSAIoctl(IntPtr s, int dwIoControlCode, ref Guid lpvInBuffer, int cbInBuffer, ref IntPtr lpvOutBuffer, int cbOutBuffer, out int lpcbBytesReturned, IntPtr lpOverlapped, IntPtr lpCompletionRoutine);

        /// <summary>
        /// The bind function associates a local address with a socket.
        /// </summary>
        /// <param name="s">A descriptor identifying an unbound socket.</param>
        /// <param name="name">A pointer to a sockaddr structure of the local address to assign to the bound socket .</param>
        /// <param name="namelen">The length, in bytes, of the value pointed to by the name parameter.</param>
        /// <returns>If no error occurs, bind returns zero. Otherwise, it returns SOCKET_ERROR, and a specific error code can be retrieved by calling WSAGetLastError.</returns>
        [DllImport("ws2_32.dll", SetLastError = true)]
        public static extern SocketError bind(IntPtr s, byte[] name, int namelen);

        /// <summary>
        /// The listen function places a socket in a state in which it is listening for an incoming connection.
        /// </summary>
        /// <param name="s">A descriptor identifying a bound, unconnected socket.</param>
        /// <param name="backlog">The maximum length of the queue of pending connections. If set to SOMAXCONN, the underlying service provider responsible for socket s will set the backlog to a maximum reasonable value. If set to SOMAXCONN_HINT(N) (where N is a number), the backlog value will be N, adjusted to be within the range (200, 65535). Note that SOMAXCONN_HINT can be used to set the backlog to a larger value than possible with SOMAXCONN.SOMAXCONN_HINT is only supported by the Microsoft TCP/IP service provider. There is no standard provision to obtain the actual backlog value.</param>
        /// <returns>If no error occurs, listen returns zero. Otherwise, a value of SOCKET_ERROR is returned, and a specific error code can be retrieved by calling WSAGetLastError.</returns>
        [DllImport("ws2_32.dll", SetLastError = true)]
        public static extern SocketError listen(IntPtr s, int backlog);

        /// <summary>
        /// The closesocket function closes an existing socket.
        /// </summary>
        /// <param name="s">A descriptor identifying the socket to close.</param>
        /// <returns>If no error occurs, closesocket returns zero. Otherwise, a value of SOCKET_ERROR is returned, and a specific error code can be retrieved by calling WSAGetLastError.</returns>
        [DllImport("ws2_32.dll", SetLastError = true)]
        public static extern SocketError closesocket(IntPtr s);

        /// <summary>
        /// The getsockname function retrieves the local name for a socket.
        /// </summary>
        /// <param name="s">Descriptor identifying a socket.</param>
        /// <param name="name">Pointer to a SOCKADDR structure that receives the address (name) of the socket.</param>
        /// <param name="namelen">Size of the name buffer, in bytes.</param>
        /// <returns>If no error occurs, getsockname returns zero. Otherwise, a value of SOCKET_ERROR is returned, and a specific error code can be retrieved by calling WSAGetLastError.</returns>
        [DllImport("ws2_32.dll", SetLastError = true)]
        public static extern SocketError getsockname(IntPtr s, byte[] name, ref int namelen);

        /// <summary>
        /// The getpeername function retrieves the address of the peer to which a socket is connected.
        /// </summary>
        /// <param name="s">A descriptor identifying a connected socket.</param>
        /// <param name="name">The SOCKADDR structure that receives the address of the peer.</param>
        /// <param name="namelen">A pointer to the size, in bytes, of the name parameter.</param>
        /// <returns>If no error occurs, getpeername returns zero. Otherwise, a value of SOCKET_ERROR is returned, and a specific error code can be retrieved by calling WSAGetLastError.</returns>
        [DllImport("ws2_32.dll", SetLastError = true)]
        public static extern SocketError getpeername(IntPtr s, byte[] name, ref int namelen);

        /// <summary>
        /// The getsockopt function retrieves a socket option.
        /// </summary>
        /// <param name="s">A descriptor identifying a socket.</param>
        /// <param name="level">The level at which the option is defined. Example: SOL_SOCKET.</param>
        /// <param name="optname">The socket option for which the value is to be retrieved. Example: SO_ACCEPTCONN. The optname value must be a socket option defined within the specified level, or behavior is undefined.</param>
        /// <param name="optval">A pointer to the buffer in which the value for the requested option is to be returned.</param>
        /// <param name="optlen">A pointer to the size, in bytes, of the optval buffer.</param>
        /// <returns>If no error occurs, getsockopt returns zero. Otherwise, a value of SOCKET_ERROR is returned, and a specific error code can be retrieved by calling WSAGetLastError.</returns>
        [DllImport("ws2_32.dll", SetLastError = true)]
        public static extern SocketError getsockopt(IntPtr s, int level, int optname, byte[] optval, int optlen);

        /// <summary>
        /// The setsockopt function sets a socket option.
        /// </summary>
        /// <param name="s">A descriptor that identifies a socket.</param>
        /// <param name="level">The level at which the option is defined (for example, SOL_SOCKET).</param>
        /// <param name="optname">The socket option for which the value is to be set (for example, SO_BROADCAST). The optname parameter must be a socket option defined within the specified level, or behavior is undefined.</param>
        /// <param name="optval">A pointer to the buffer in which the value for the requested option is specified.</param>
        /// <param name="optlen">The size, in bytes, of the buffer pointed to by the optval parameter.</param>
        /// <returns>If no error occurs, setsockopt returns zero. Otherwise, a value of SOCKET_ERROR is returned, and a specific error code can be retrieved by calling WSAGetLastError.</returns>
        [DllImport("ws2_32.dll", SetLastError = true)]
        public static extern SocketError setsockopt(IntPtr s, int level, int optname, byte[] optval, int optlen);
    }
}
