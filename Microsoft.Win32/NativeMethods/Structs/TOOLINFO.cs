using System;
using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// TOOLINFO∂®“Â
    /// </summary>
    public static partial class NativeMethods
    {
        /// <summary>
        /// The TOOLINFO structure contains information about a tool in a tooltip control.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct TOOLINFO
        {
            /// <summary>
            /// Size of this structure, in bytes. This member must be specified.
            /// </summary>
            public int cbSize;
            /// <summary>
            /// Flags that control the tooltip display. This member can be a combination of the following values:TTF_
            /// </summary>
            public int uFlags;
            /// <summary>
            /// Handle to the window that contains the tool. If lpszText includes the LPSTR_TEXTCALLBACK value, this member identifies the window that receives the TTN_GETDISPINFO notification codes.
            /// </summary>
            public IntPtr hwnd;
            /// <summary>
            /// Application-defined identifier of the tool. If uFlags includes the TTF_IDISHWND flag, uId must specify the window handle to the tool.
            /// </summary>
            public IntPtr uId;
            /// <summary>
            /// The bounding rectangle coordinates of the tool. The coordinates are relative to the upper-left corner of the client area of the window identified by hwnd. If uFlags includes the TTF_IDISHWND flag, this member is ignored.
            /// </summary>
            public RECT rect;
            /// <summary>
            /// Handle to the instance that contains the string resource for the tool. If lpszText specifies the identifier of a string resource, this member is used.
            /// </summary>
            public IntPtr hinst;
            /// <summary>
            /// Pointer to the buffer that contains the text for the tool, or identifier of the string resource that contains the text. This member is sometimes used to return values. If you need to examine the returned value, must point to a valid buffer of sufficient size. Otherwise, it can be set to NULL. If lpszText is set to LPSTR_TEXTCALLBACK, the control sends the TTN_GETDISPINFO notification code to the owner window to retrieve the text.
            /// </summary>
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpszText;
            /// <summary>
            /// Version 4.70 and later. A 32-bit application-defined value that is associated with the tool.
            /// </summary>
            public int lParam;
            ///// <summary>
            ///// Windows XP and later. Reserved. Must be set to NULL.
            ///// </summary>
            //public void* lpReserved;
        }
    }
}
