using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// MMCKINFO∂®“Â
    /// </summary>
    public static partial class NativeMethods
    {
        /// <summary>
        /// MMCKINFO
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct MMCKINFO
        {
            /// <summary>
            /// 
            /// </summary>
            public int ckID;
            /// <summary>
            /// 
            /// </summary>
            public int cksize;
            /// <summary>
            /// 
            /// </summary>
            public int fccType;
            /// <summary>
            /// 
            /// </summary>
            public int dwDataOffset;
            /// <summary>
            /// 
            /// </summary>
            public int dwFlags;
        }
    }
}
