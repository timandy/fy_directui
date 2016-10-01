namespace Microsoft.Win32
{
    //ROP定义
    public static partial class NativeMethods
    {
        /// <summary>
        /// 将源矩形区域直接拷贝到目标矩形区域。
        /// </summary>
        public const int SRCCOPY = 0x00CC0020;      /* dest = source                   */
        /// <summary>
        /// 通过使用布尔型的OR（或）操作符将源和目标矩形区域的颜色合并。
        /// </summary>
        public const int SRCPAINT = 0x00EE0086;     /* dest = source OR dest           */
        /// <summary>
        /// 通过使用AND（与）操作符来将源和目标矩形区域内的颜色合并。
        /// </summary>
        public const int SRCAND = 0x008800C6;       /* dest = source AND dest          */
        /// <summary>
        /// 通过使用布尔型的XOR（异或）操作符将源和目标矩形区域的颜色合并。
        /// </summary>
        public const int SRCINVERT = 0x00660046;    /* dest = source XOR dest          */
        /// <summary>
        /// 通过使用AND（与）操作符将目标矩形区域颜色取反后与源矩形区域的颜色值合并。
        /// </summary>
        public const int SRCERASE = 0x00440328;     /* dest = source AND (NOT dest )   */
        /// <summary>
        /// 将源矩形区域颜色取反，于拷贝到目标矩形区域。
        /// </summary>
        public const int NOTSRCCOPY = 0x00330008;   /* dest = (NOT source)             */
        /// <summary>
        /// 使用布尔类型的OR（或）操作符组合源和目标矩形区域的颜色值，然后将合成的颜色取反。
        /// </summary>
        public const int NOTSRCERASE = 0x001100A6;  /* dest = (NOT src) AND (NOT dest) */
        /// <summary>
        /// 表示使用布尔型的AND（与）操作符将源矩形区域的颜色与特定模式组合一起。
        /// </summary>
        public const int MERGECOPY = 0x00C000CA;    /* dest = (source AND pattern)     */
        /// <summary>
        /// 通过使用布尔型的OR（或）操作符将反向的源矩形区域的颜色与目标矩形区域的颜色合并。
        /// </summary>
        public const int MERGEPAINT = 0x00BB0226;   /* dest = (NOT source) OR dest     */
        /// <summary>
        /// 将特定的模式拷贝到目标位图上。
        /// </summary>
        public const int PATCOPY = 0x00F00021;      /* dest = pattern                  */
        /// <summary>
        /// 通过使用布尔OR（或）操作符将源矩形区域取反后的颜色值与特定模式的颜色合并。然后使用OR（或）操作符将该操作的结果与目标矩形区域内的颜色合并。
        /// </summary>
        public const int PATPAINT = 0x00FB0A09;     /* dest = DPSnoo                   */
        /// <summary>
        /// 通过使用XOR（异或）操作符将源和目标矩形区域内的颜色合并。
        /// </summary>
        public const int PATINVERT = 0x005A0049;    /* dest = pattern XOR dest         */
        /// <summary>
        /// 表示使目标矩形区域颜色取反。
        /// </summary>
        public const int DSTINVERT = 0x00550009;    /* dest = (NOT dest)               */
        /// <summary>
        /// 表示使用与物理调色板的索引0相关的色彩来填充目标矩形区域，（对缺省的物理调色板而言，该颜色为黑色）。
        /// </summary>
        public const int BLACKNESS = 0x00000042;    /* dest = BLACK                    */
        /// <summary>
        /// 使用与物理调色板中索引1有关的颜色填充目标矩形区域。（对于缺省物理调色板来说，这个颜色就是白色）。
        /// </summary>
        public const int WHITENESS = 0x00FF0062;    /* dest = WHITE                    */
    }
}
