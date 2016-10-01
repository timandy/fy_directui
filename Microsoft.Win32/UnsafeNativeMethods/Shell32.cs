using System;
using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// Gdi32.dll
    /// </summary>
    public static partial class UnsafeNativeMethods
    {
        /// <summary>
        /// 该函数从限定的可执行文件；动态链接库（DLL），或者图标文件中生成图标句柄数组。
        /// </summary>
        /// <param name="lpszFile">定义可获取图标的可执行文件，DLL,或者图标文件的名字的空结束字符串指针。</param>
        /// <param name="nIconIndex">指定抽取第一个图标基于零的变址；例如，如果该值是零；函数在限定的文件中抽取第一图标；如该值是C1且phlconLarge和phiconSmall参数均为NULL，函数返回限定文件中图标的总数；如果文件是可执行文件或DLL；返回值是RT_GROUP_ICON资源的数目；如果文件是一个ICO文件，返回值是1；在Windows95，WindowsNT4.0,和更高版本中，如果值为负数且phlconLarge和phiconSmall均不为NULL，函数从获取图标开始，该图标的资源标识符等于nlconlndex绝对值。例如，使用-3来获取资源标识符为3的图标。</param>
        /// <param name="phIconLarge">指向图标句柄数组的指针，它可接收从文件获取的大图标的句柄。如果该参数是NULL没有从文件抽取大图标。</param>
        /// <param name="phIconSmall">指向图标句柄数组的指针，它可接收从文件获取的小图标的句柄。如果该参数是NULL，没有从文件抽取小图标。</param>
        /// <param name="nIcons">指定要从文件中抽取图标的数目。</param>
        /// <returns>如果nlconlndex参数是-1，PhiconLarge和PhiconSmall参数是NULL，返回值是包含在指定文件中的图标数目；否则，返回值是成功地从文件中获取图标的数目。</returns>
        [DllImport("shell32.dll")]
        public static extern uint ExtractIconEx(string lpszFile, int nIconIndex, IntPtr[] phIconLarge, IntPtr[] phIconSmall, uint nIcons);
    }
}
