using System;

namespace Microsoft.Win32
{
    //EnumChildProc定义
    public static partial class NativeMethods
    {
        /// <summary>
        ///     <para>功能:</para>
        ///     <para>该函数是由应用程序定义的，与函数 EnumChildWindows 一起使用的回调函数。它接收子窗口句柄。</para>
        ///     <para>类型 WNDENUMPROC 定义了一个指向回调函数的指针。EnumChildProc 是一个应用程序定义的函数名的位置标志符。</para>
        ///     <para>.</para>
        ///     <para>备注:</para>
        ///     <para>回调函数可以执行任何要求的任务。</para>
        ///     <para>应用程序必须通过将其地址传送给 EnumChildWindows 函数来注册这个回调函数。</para>
        /// </summary>
        /// <param name="hwnd">指向在 EnumChildWindows 中指定的父窗口的子窗口句柄。</param>
        /// <param name="lParam">指定在 EnumChildWindows 函数给出的应用程序定义值。</param>
        /// <returns>如要继续枚举，回调函数必须返回 TRUE；如要停止枚举，回调函数必须返回 FALSE。</returns>
        public delegate bool EnumChildProc(IntPtr hwnd, object lParam);
    }
}