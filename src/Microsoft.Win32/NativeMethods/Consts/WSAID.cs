using System;

namespace Microsoft.Win32
{
    //WSAID定义
    public static partial class NativeMethods
    {
        /// <summary>
        /// The AcceptEx extension function.
        /// </summary>
        public static readonly Guid WSAID_ACCEPTEX = new Guid("{0xb5367df1,0xcbac,0x11cf,{0x95,0xca,0x00,0x80,0x5f,0x48,0xa1,0x92}}");
        /// <summary>
        /// The ConnectEx extension function.
        /// </summary>
        public static readonly Guid WSAID_CONNECTEX = new Guid("{0x25a207b9,0xddf3,0x4660,{0x8e,0xe9,0x76,0xe5,0x8c,0x74,0x06,0x3e}}");
        /// <summary>
        /// The DisconnectEx extension function.
        /// </summary>
        public static readonly Guid WSAID_DISCONNECTEX = new Guid("{0x7fda2e11,0x8630,0x436f,{0xa0, 0x31, 0xf5, 0x36, 0xa6, 0xee, 0xc1, 0x57}}");
        /// <summary>
        /// The GetAcceptExSockaddrs extension function.
        /// </summary>
        public static readonly Guid WSAID_GETACCEPTEXSOCKADDRS = new Guid("{0xb5367df2,0xcbac,0x11cf,{0x95,0xca,0x00,0x80,0x5f,0x48,0xa1,0x92}}");
        /// <summary>
        /// None.
        /// </summary>
        public static readonly Guid WSAID_MULTIPLE_RIO = new Guid("{0x8509e081,0x96dd,0x4005,{0xb1,0x65,0x9e,0x2e,0xe8,0xc7,0x9e,0x3f}}");
        /// <summary>
        /// The TransmitFile extension function.
        /// </summary>
        public static readonly Guid WSAID_TRANSMITFILE = new Guid("{0xb5367df0,0xcbac,0x11cf,{0x95,0xca,0x00,0x80,0x5f,0x48,0xa1,0x92}}");
        /// <summary>
        /// The TransmitPackets extension function.
        /// </summary>
        public static readonly Guid WSAID_TRANSMITPACKETS = new Guid("{0xd9689da0,0x1f90,0x11d3,{0x99,0x71,0x00,0xc0,0x4f,0x68,0xc8,0x76}}");
        /// <summary>
        /// None.
        /// </summary>
        public static readonly Guid WSAID_WSAPOLL = new Guid("{0x18C76F85,0xDC66,0x4964,{0x97,0x2E,0x23,0xC2,0x72,0x38,0x31,0x2B}}");
        /// <summary>
        /// The WSARecvMsg extension function.
        /// </summary>
        public static readonly Guid WSAID_WSARECVMSG = new Guid("{0xf689d7c8,0x6f1f,0x436b,{0x8a,0x53,0xe5,0x4f,0xe3,0x51,0xc3,0x22}}");
        /// <summary>
        /// The WSASendMsg extension function.
        /// </summary>
        public static readonly Guid WSAID_WSASENDMSG = new Guid("{0xa441e712,0x754f,0x43ca,{0x84,0xa7,0x0d,0xee,0x44,0xcf,0x60,0x6d}}");
    }
}
