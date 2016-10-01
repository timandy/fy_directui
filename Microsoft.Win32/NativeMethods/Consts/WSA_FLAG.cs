namespace Microsoft.Win32
{
    //WSA_FLAG定义
    public static partial class NativeMethods
    {
        /// <summary>
        /// This flag causes an overlapped socket to be created. Overlapped sockets can use WSASend, WSASendTo, WSARecv, WSARecvFrom, and WSAIoctl for overlapped I/O operations, which allow multiple operations to be initiated and in progress simultaneously. All functions that allow overlapped operation also support nonoverlapped usage on an overlapped socket if the values for parameters related to overlapped operations are NULL.
        /// </summary>
        public const int WSA_FLAG_OVERLAPPED = 0x01;
        /// <summary>
        /// Indicates that the socket created will be a c_root in a multipoint session. This is only allowed if a rooted control plane is indicated in the protocol's WSAPROTOCOL_INFO structure.
        /// </summary>
        public const int WSA_FLAG_MULTIPOINT_C_ROOT = 0x02;
        /// <summary>
        /// Indicates that the socket created will be a c_leaf in a multicast session. This is only allowed if XP1_SUPPORT_MULTIPOINT is indicated in the protocol's WSAPROTOCOL_INFO structure.
        /// </summary>
        public const int WSA_FLAG_MULTIPOINT_C_LEAF = 0x04;
        /// <summary>
        /// Indicates that the socket created will be a d_root in a multipoint session. This is only allowed if a rooted data plane is indicated in the protocol's WSAPROTOCOL_INFO structure. Refer to Multipoint and Multicast Semantics for additional information.
        /// </summary>
        public const int WSA_FLAG_MULTIPOINT_D_ROOT = 0x08;
        /// <summary>
        /// Indicates that the socket created will be a d_leaf in a multipoint session. This is only allowed if XP1_SUPPORT_MULTIPOINT is indicated in the protocol's WSAPROTOCOL_INFO structure.
        /// </summary>
        public const int WSA_FLAG_MULTIPOINT_D_LEAF = 0x10;
        /// <summary>
        /// 
        /// </summary>
        public const int WSA_FLAG_ACCESS_SYSTEM_SECURITY = 0x40;
        /// <summary>
        /// 
        /// </summary>
        public const int WSA_FLAG_NO_HANDLE_INHERIT = 0x80;
        /// <summary>
        /// 
        /// </summary>
        public const int WSA_FLAG_REGISTERED_IO = 0x100;
    }
}
