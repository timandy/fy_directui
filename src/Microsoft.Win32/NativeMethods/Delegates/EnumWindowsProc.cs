using System;

namespace Microsoft.Win32
{
    //EnumWindowsProc定义
    public static partial class NativeMethods
    {
        /// <summary>
        ///     <para>功能:</para>
        ///     <para>函数是一个与 EnumWindows 或 EnumDesktopWindows 一起使用的应用程序定义的回调函数。它接收顶层窗口句柄。</para>
        ///     <para>WNDENUMPROC 定义一个指向这个回调函数的指针。EnumWindowsProc 是应用程序定义函数名的位置标志符。</para>
        ///     <para>.</para>
        ///     <para>备注:</para>
        ///     <para>应用程序必须通过传递给 EnumWindows 或 EnumDesktopWindows 应用程序地址来注册这个回调函数。</para>
        /// </summary>
        /// <param name="hwnd">顶层窗口句柄。</param>
        /// <param name="lParam">指定在 EnumWindows 或 EnumDesktopWindows 中的应用程序定义值。</param>
        /// <returns>如要继续枚举，回调函数必须返回 TRUE；如要停止枚举，回调函数必须返回 FALSE。</returns>
        public delegate bool EnumWindowsProc(IntPtr hwnd, object lParam);
    }
}