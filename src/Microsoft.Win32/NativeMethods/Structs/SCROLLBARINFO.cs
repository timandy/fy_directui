using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// SCROLLBARINFO∂®“Â
    /// </summary>
    public static partial class NativeMethods
    {
        /// <summary>
        /// The SCROLLBARINFO structure contains scroll bar information.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SCROLLBARINFO
        {
            /// <summary>
            /// Specifies the size, in bytes, of the structure. Before calling the GetScrollBarInfo function, set cbSize to sizeof(SCROLLBARINFO).
            /// </summary>
            public int cbSize;
            /// <summary>
            /// Coordinates of the scroll bar as specified in a RECT structure.
            /// </summary>
            public RECT rcScrollBar;
            /// <summary>
            /// Height or width of the thumb.
            /// </summary>
            public int dxyLineButton;
            /// <summary>
            /// Position of the top or left of the thumb.
            /// </summary>
            public int xyThumbTop;
            /// <summary>
            /// Position of the bottom or right of the thumb.
            /// </summary>
            public int xyThumbBottom;
            /// <summary>
            /// <para>An array of DWORD elements. Each element indicates the state of a scroll bar component. The following values show the scroll bar component that corresponds to each array index.</para>
            /// <para>Index	Scroll bar component</para>
            /// <para>0	The scroll bar itself.</para>
            /// <para>1	The top or right arrow button.</para>
            /// <para>2	The page up or page right region.</para>
            /// <para>3	The scroll box (thumb).</para>
            /// <para>4	The page down or page left region.</para>
            /// <para>5	The bottom or left arrow button.</para>
            /// <para>.</para>
            /// <para>The DWORD element for each scroll bar component can include a combination of the following bit flags.</para>
            /// <para>Value	Meaning</para>
            /// <para>STATE_SYSTEM_INVISIBLE</para>
            /// <para>For the scroll bar itself, indicates the specified vertical or horizontal scroll bar does not exist. For the page up or page down regions, indicates the thumb is positioned such that the region does not exist.</para>
            /// <para>STATE_SYSTEM_OFFSCREEN</para>
            /// <para>For the scroll bar itself, indicates the window is sized such that the specified vertical or horizontal scroll bar is not currently displayed.</para>
            /// <para>STATE_SYSTEM_PRESSED</para>
            /// <para>The arrow button or page region is pressed.</para>
            /// <para>STATE_SYSTEM_UNAVAILABLE</para>
            /// <para>The component is disabled.</para>
            /// </summary>
            public int reserved;
            /// <summary>
            /// <para>An array of DWORD elements. Each element indicates the state of a scroll bar component. The following values show the scroll bar component that corresponds to each array index.</para>
            /// <para>Index	Scroll bar component</para>
            /// <para>0	The scroll bar itself.</para>
            /// <para>1	The top or right arrow button.</para>
            /// <para>2	The page up or page right region.</para>
            /// <para>3	The scroll box (thumb).</para>
            /// <para>4	The page down or page left region.</para>
            /// <para>5	The bottom or left arrow button.</para>
            /// <para>.</para>
            /// <para>The DWORD element for each scroll bar component can include a combination of the following bit flags.</para>
            /// <para>Value	Meaning</para>
            /// <para>STATE_SYSTEM_INVISIBLE</para>
            /// <para>For the scroll bar itself, indicates the specified vertical or horizontal scroll bar does not exist. For the page up or page down regions, indicates the thumb is positioned such that the region does not exist.</para>
            /// <para>STATE_SYSTEM_OFFSCREEN</para>
            /// <para>For the scroll bar itself, indicates the window is sized such that the specified vertical or horizontal scroll bar is not currently displayed.</para>
            /// <para>STATE_SYSTEM_PRESSED</para>
            /// <para>The arrow button or page region is pressed.</para>
            /// <para>STATE_SYSTEM_UNAVAILABLE</para>
            /// <para>The component is disabled.</para>
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = CCHILDREN_SCROLLBAR + 1)]
            public int[] rgstate;
        }
    }
}
