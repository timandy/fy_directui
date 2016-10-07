using System;
using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// COMBOBOXINFO∂®“Â
    /// </summary>
    public static partial class NativeMethods
    {
        /// <summary>
        /// COMBOBOXINFO Contains combo box status information.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct COMBOBOXINFO
        {
            /// <summary>
            /// The size, in bytes, of the structure. The calling application must set this to sizeof(COMBOBOXINFO).
            /// </summary>
            public int cbSize;
            /// <summary>
            /// A RECT structure that specifies the coordinates of the edit box.
            /// </summary>
            public RECT rcItem;
            /// <summary>
            /// A RECT structure that specifies the coordinates of the button that contains the drop-down arrow.
            /// </summary>
            public RECT rcButton;
            /// <summary>
            /// <para>The combo box button state. This parameter can be one of the following values.</para>
            /// <para>Value	Meaning</para>
            /// <para>0</para>
            /// <para>The button exists and is not pressed.</para>
            /// <para>STATE_SYSTEM_INVISIBLE</para>
            /// <para>There is no button.</para>
            /// <para>STATE_SYSTEM_PRESSED</para>
            /// <para>The button is pressed.</para>
            /// </summary>
            public int stateButton;
            /// <summary>
            /// A handle to the combo box.
            /// </summary>
            public IntPtr hwndCombo;
            /// <summary>
            /// A handle to the edit box.
            /// </summary>
            public IntPtr hwndItem;
            /// <summary>
            /// A handle to the drop-down list.
            /// </summary>
            public IntPtr hwndList;
        }
    }
}
