using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// SCROLLINFO定义
    /// </summary>
    public static partial class NativeMethods
    {
        /// <summary>
        /// The SCROLLINFO structure contains scroll bar parameters to be set by the SetScrollInfo function (or SBM_SETSCROLLINFO message), or retrieved by the GetScrollInfo function (or SBM_GETSCROLLINFO message).
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SCROLLINFO
        {
            /// <summary>
            /// Specifies the size, in bytes, of this structure. The caller must set this to sizeof(SCROLLINFO).
            /// </summary>
            public int cbSize;
            /// <summary>
            /// Specifies the scroll bar parameters to set or retrieve. This member can be a combination of the following values: SIF_
            /// </summary>
            public uint fMask;
            /// <summary>
            /// Specifies the minimum scrolling position.
            /// </summary>
            public int nMin;
            /// <summary>
            /// Specifies the maximum scrolling position.
            /// </summary>
            public int nMax;
            /// <summary>
            /// Specifies the page size, in device units. A scroll bar uses this value to determine the appropriate size of the proportional scroll box.
            /// </summary>
            public int nPage;
            /// <summary>
            /// Specifies the position of the scroll box.
            /// </summary>
            public int nPos;
            /// <summary>
            /// Specifies the immediate position of a scroll box that the user is dragging. An application can retrieve this value while processing the SB_THUMBTRACK request code. An application cannot set the immediate scroll position; the SetScrollInfo function ignores this member.
            /// </summary>
            public int nTrackPos;
        }
    }
}
