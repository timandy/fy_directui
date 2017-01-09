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
        /// <para>功能:</para>
        /// <para>该函数选择一对象到指定的设备上下文环境中，该新对象替换先前的相同类型的对象。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>该函数返回先前指定类型的选择对象，一个应用程序在它使用新对象进行绘制完成之后，应该用原始的缺省的对象替换新对象。</para>
        /// <para>应用程序不能同时选择一个位图到多个设备上下文环境中。</para>
        /// <para>ICM：如果被选择的对象是画笔或笔，那么就执行颜色管理。</para>
        /// <para>.</para>
        /// <para>hgdiobj必须为以下方法生成的对象</para>
        /// <para>位图：CreateBitmap, CreateBitmapIndirect, CreateCompatible Bitmap, CreateDIBitmap, CreateDIBsection（只有内存设备上下文环境可选择位图，并且在同一时刻只能一个设备上下文环境选择位图）。</para>
        /// <para>画刷：CreateBrushIndirect, CreateDIBPatternBrush, CreateDIBPatternBrushPt, CreateHatchBrush, CreatePatternBrush, CreateSolidBrush。</para>
        /// <para>字体：CreateFont, CreateFontIndirect。</para>
        /// <para>笔：CreatePen, CreatePenIndirect。</para>
        /// <para>区域：CombineRgn, CreateEllipticRgn, CreateEllipticRgnIndirect, CreatePolygonRgn, CreateRectRgn, CreateRectRgnIndirect。</para>
        /// </summary>
        /// <param name="hdc">设备上下文环境的句柄。</param>
        /// <param name="hgdiobj">被选择的对象的句柄，该指定对象必须由如下的函数创建。</param>
        /// <returns>
        /// <para>如果选择对象不是区域并且函数执行成功，那么返回值是被取代的对象的句柄；</para>
        /// <para>如果选择对象是区域并且函数执行成功，返回如下一值；</para>
        /// <para>SIMPLEREGION：区域由单个矩形组成；</para>
        /// <para>COMPLEXREGION：区域由多个矩形组成。</para>
        /// <para>NULLREGION：区域为空。</para>
        /// <para>如果发生错误并且选择对象不是一个区域，那么返回值为NULL，否则返回GDI_ERROR。</para>
        /// </returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);


        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数删除指定的设备上下文环境（DC）。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>如果一个设备上下文环境的句柄是通过调用GetDC函数得到的，那么应用程序不能删除该设备上下文环境，它应该调用ReleaseDC函数来释放该设备上下文环境。</para>
        /// </summary>
        /// <param name="hdc">设备上下文环境的句柄。</param>
        /// <returns>成功，返回非零值；失败，返回零。</returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr DeleteDC(IntPtr hdc);
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数删除一个逻辑笔、画笔、字体、位图、区域或者调色板，释放所有与该对象有关的系统资源，在对象被删除之后，指定的句柄也就失效了。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>当一个绘画对象（如笔或画笔）当前被选入一个设备上下文环境时不要删除该对象。当一个调色板画笔被删除时，与该画笔相关的位图并不被删除，该图必须单独地删除。</para>
        /// </summary>
        /// <param name="hObject">逻辑笔、画笔、字体、位图、区域或者调色板的句柄。</param>
        /// <returns>成功，返回非零值；如果指定的句柄无效或者它已被选入设备上下文环境，则返回值为零。</returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr DeleteObject(IntPtr hObject);


        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数创建一个与指定设备兼容的内存设备上下文环境（DC）。通过GetDC()获取的HDC直接与相关设备沟通，而本函数创建的DC，则是与内存中的一个表面相关联。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>内存设备上下文环境是仅在内存中存在的设备上下文环境，当内存设备上下文环境被创建时，它的显示界面是标准的一个单色像素宽和一个单色像素高，在一个应用程序可以使用内存设备上下文环境进行绘图操作之前，它必须选择一个高和宽都正确的位图到设备上下文环境中，这可以通过使用CreateCompatibleBitmap函数指定高、宽和色彩组合以满足函数调用的需要。</para>
        /// <para>当一个内存设备上下文环境创建时，所有的特性都设为缺省值，内存设备上下文环境作为一个普通的设备上下文环境使用，当然也可以设置这些特性为非缺省值，得到它的特性的当前设置，为它选择画笔，刷子和区域。</para>
        /// <para>CreateCompatibleDC函数只适用于支持光栅操作的设备，应用程序可以通过调用GetDeviceCaps函数来确定一个设备是否支持这些操作。</para>
        /// <para>当不再需要内存设备上下文环境时，可调用DeleteDC函数删除它。</para>
        /// <para>ICM：如果通过该函数的hdc参数传送给该函数设备上下文环境(DC)对于独立颜色管理（ICM）是能用的，则该函数创建的设备上下文环境(DC)是ICM能用的，资源和目标颜色间隔是在DC中定义。</para>
        /// </summary>
        /// <param name="hdc">现有设备上下文环境的句柄，如果该句柄为NULL，该函数创建一个与应用程序的当前显示器兼容的内存设备上下文环境。</param>
        /// <returns>如果成功，则返回内存设备上下文环境的句柄；如果失败，则返回值为NULL。</returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数创建与指定的设备环境相关的设备兼容的位图。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>由CreateCompatibleBitmap函数创建的位图的颜色格式与由参数hdc标识的设备的颜色格式匹配。该位图可以选入任意一个与原设备兼容的内存设备环境中。由于内存设备环境允许彩色和单色两种位图。因此当指定的设备环境是内存设备环境时，由CreateCompatibleBitmap函数返回的位图格式不一定相同。然而为非内存设备环境创建的兼容位图通常拥有相同的颜色格式，并且使用与指定的设备环境一样的色彩调色板。</para>
        /// </summary>
        /// <param name="hdc">设备环境句柄。</param>
        /// <param name="nWidth">指定位图的宽度，单位为像素。</param>
        /// <param name="nHeight">指定位图的高度，单位为像素。</param>
        /// <returns>如果函数执行成功，那么返回值是位图的句柄；如果函数执行失败，那么返回值为NULL。若想获取更多错误信息，请调用GetLastError。</returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);


        /// <summary>
        /// <para>功能:</para>
        /// <para>The SetBkMode function sets the background mix mode of the specified device context.</para>
        /// <para>The background mix mode is used with text, hatched brushes, and pen styles that are not solid lines.</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>The SetBkMode function affects the line styles for lines drawn using a pen created by the CreatePen function.</para>
        /// <para>SetBkMode does not affect lines drawn using a pen created by the ExtCreatePen function.</para>
        /// </summary>
        /// <param name="hdc">A handle to the device context.</param>
        /// <param name="iBkMode">The background mode. This parameter can be one of the following values.</param>
        /// <returns>If the function succeeds, the return value specifies the previous background mode.If the function fails, the return value is zero.</returns>
        [DllImport("gdi32.dll")]
        public static extern int SetBkMode(IntPtr hdc, int iBkMode);
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数创建一个矩形剪切区域</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>不用时一定要用DeleteObject函数删除该区域</para>
        /// <para>这个矩形的下边和右边不包含在区域之内</para>
        /// </summary>
        /// <param name="nLeftRect">左</param>
        /// <param name="nTopRect">上</param>
        /// <param name="nRightRect">右</param>
        /// <param name="nBottomRect">下</param>
        /// <returns>见切区域句柄</returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);
        /// <summary>
        /// <para>功能:</para>
        /// <para>创建一个圆角矩形，该矩形由nLeftRect，nTopRect-nRightRect，nBottomRect确定，并由nWidthEllipse，nHeightEllipse确定的椭圆描述圆角弧度 返回值 Long，执行成功则为区域句柄，失败则为0</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>不用时一定要用DeleteObject函数删除该区域</para>
        /// <para>用该函数创建的区域与用RoundRect API函数画的圆角矩形不完全相同，因为本矩形的右边和下边不包括在区域之内</para>
        /// </summary>
        /// <param name="nLeftRect">左宽度</param>
        /// <param name="nTopRect">上高度</param>
        /// <param name="nRightRect">右宽度</param>
        /// <param name="nBottomRect">下高度</param>
        /// <param name="nWidthEllipse">圆角椭圆的宽。其范围从0（没有圆角）到矩形宽（全圆）</param>
        /// <param name="nHeightEllipse">圆角椭圆的高。其范围从0（没有圆角）到矩形高（全圆）</param>
        /// <returns>如果函数执行成功返回region句柄。否则返回NULL。</returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        /// <summary>
        /// The SelectClipRgn function selects a region as the current clipping region for the specified device context.
        /// </summary>
        /// <param name="hdc">设备环境句柄。</param>
        /// <param name="hrgn">标识被选择的区域。</param>
        /// <returns>返回值表明了区域的复杂度，可以是下列值之一。</returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int SelectClipRgn(IntPtr hdc, IntPtr hrgn);
        /// <summary>
        /// 访函数通过特定的方式把一个特定的区域与当前的剪切区域合并在一起。
        /// </summary>
        /// <param name="hdc">设备环境句柄。</param>
        /// <param name="hrgn">标识被选择的区域。当指定RGN_COPY模式时，该句柄才能为NULL。</param>
        /// <param name="fnMode">定义执行的运算模式。它必须是下列值之一：</param>
        /// <returns>返回值表明了新的剪切区域的复杂度，它的值是如下几种：</returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int ExtSelectClipRgn(IntPtr hdc, IntPtr hrgn, int fnMode);


        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数可以设置指定设备环境中的位图拉伸模式。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>拉伸模式在应用程序调用StretchBit函数时定义系统如何将位图的行或列与显示设备上的现有像素点进行组合。</para>
        /// <para>BLACKONWHITE(STRETCH_ANDSCANS)和WHITEONBLACK(STRETCH_ORSCANS)模式典型地用来保留单色位图中的前景像素。COLORONCOLOR(STRETCH_DELETESCANS)模式则典型地用于保留彩色位图中的颜色。</para>
        /// <para>HALFTONE模式比其他三种模式需要对源图像进行更多的处理，也比其他模式慢，但它能产生高质量图像，也应注意在设置HALFTONE模式之后，应调用SetBrushOrgEx函数以避免出现刷子没对准现象。</para>
        /// <para>根据设备驱动程序的功能不同，其他一些拉伸模式也可能有效。</para>
        /// </summary>
        /// <param name="hdc">设备环境句柄。</param>
        /// <param name="iStretchMode">指定拉伸模式。它可以取下列值，这些值的含义如下：</param>
        /// <returns>如果函数执行成功，那么返回值就是先前的拉伸模式，如果函数执行失败，那么返回值为0。</returns>
        [DllImport("gdi32.dll")]
        public static extern int SetStretchBltMode(IntPtr hdc, int iStretchMode);
        /// <summary>
        /// <para>功能:</para>
        /// <para>对指定的源设备环境区域中的像素进行位块（bit_block）转换，以传送到目标设备环境。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>如果在源设备环境中可以实行旋转或剪切变换，那么函数BitBlt返回一个错误。如果存在其他变换（并且目标设备环境中匹配变换无效），那么目标设备环境中的矩形区域将在需要时进行拉伸、压缩或旋转。</para>
        /// <para>如果源和目标设备环境的颜色格式不匹配，那么BitBlt函数将源场景的颜色格式转换成能与目标格式匹配的格式。当正在记录一个增强型图元文件时，如果源设备环境标识为一个增强型图元文件设备环境，那么会出现错误。如果源和目标设备环境代表不同的设备，那么BitBlt函数返回错误。</para>
        /// <para>.</para>
        /// <para>下列标志可被设置在参数dwRop里:</para>
        /// <para>BLACKNESS：表示使用与物理调色板的索引0相关的色彩来填充目标矩形区域，（对缺省的物理调色板而言，该颜色为黑色）。</para>
        /// <para>DSTINVERT：表示使目标矩形区域颜色取反。</para>
        /// <para>MERGECOPY：表示使用布尔型的AND（与）操作符将源矩形区域的颜色与特定模式组合一起。</para>
        /// <para>MERGEPAINT：通过使用布尔型的OR（或）操作符将反向的源矩形区域的颜色与目标矩形区域的颜色合并。</para>
        /// <para>NOTSRCCOPY：将源矩形区域颜色取反，于拷贝到目标矩形区域。</para>
        /// <para>NOTSRCERASE：使用布尔类型的OR（或）操作符组合源和目标矩形区域的颜色值，然后将合成的颜色取反。</para>
        /// <para>PATCOPY：将特定的模式拷贝到目标位图上。</para>
        /// <para>PATPAINT：通过使用布尔OR（或）操作符将源矩形区域取反后的颜色值与特定模式的颜色合并。然后使用OR（或）操作符将该操作的结果与目标矩形区域内的颜色合并。</para>
        /// <para>PATINVERT：通过使用XOR（异或）操作符将源和目标矩形区域内的颜色合并。</para>
        /// <para>SRCAND：通过使用AND（与）操作符来将源和目标矩形区域内的颜色合并。</para>
        /// <para>SRCCOPY：将源矩形区域直接拷贝到目标矩形区域。</para>
        /// <para>SRCERASE：通过使用AND（与）操作符将目标矩形区域颜色取反后与源矩形区域的颜色值合并。</para>
        /// <para>SRCINVERT：通过使用布尔型的XOR（异或）操作符将源和目标矩形区域的颜色合并。</para>
        /// <para>SRCPAINT：通过使用布尔型的OR（或）操作符将源和目标矩形区域的颜色合并。</para>
        /// <para>WHITENESS：使用与物理调色板中索引1有关的颜色填充目标矩形区域。（对于缺省物理调色板来说，这个颜色就是白色）。</para>
        /// </summary>
        /// <param name="hdcDest">指向目标设备环境的句柄。</param>
        /// <param name="nXDest">指定目标矩形区域左上角的X轴逻辑坐标。</param>
        /// <param name="nYDest">指定目标矩形区域左上角的Y轴逻辑坐标。</param>
        /// <param name="nWidth">指定源和目标矩形区域的逻辑宽度。</param>
        /// <param name="nHeight">指定源和目标矩形区域的逻辑高度。</param>
        /// <param name="hdcSrc">指向源设备环境的句柄。</param>
        /// <param name="nXSrc">指定源矩形区域左上角的X轴逻辑坐标。</param>
        /// <param name="nYSrc">指定源矩形区域左上角的Y轴逻辑坐标。</param>
        /// <param name="dwRop">指定光栅操作代码。这些代码将定义源矩形区域的颜色数据，如何与目标矩形区域的颜色数据组合以完成最后的颜色。</param>
        /// <returns>如果函数成功，那么返回值非零；如果函数失败，则返回值为零。</returns>
        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        /// <summary>
        /// <para>功能:</para>
        /// <para>函数从源矩形中复制一个位图到目标矩形，必要时按目前目标设备设置的模式进行图像的拉伸或压缩。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>StretchBlt stretches or compresses the source bitmap in memory and then copies the result to the destination rectangle. This bitmap can be either a compatible bitmap (DDB) or the output from CreateDIBSection. The color data for pattern or destination pixels is merged after the stretching or compression occurs.</para>
        /// <para>When an enhanced metafile is being recorded, an error occurs (and the function returns FALSE) if the source device context identifies an enhanced-metafile device context.</para>
        /// <para>If the specified raster operation requires a brush, the system uses the brush currently selected into the destination device context.</para>
        /// <para>The destination coordinates are transformed by using the transformation currently specified for the destination device context; the source coordinates are transformed by using the transformation currently specified for the source device context.</para>
        /// <para>If the source transformation has a rotation or shear, an error occurs.</para>
        /// <para>If destination, source, and pattern bitmaps do not have the same color format, StretchBlt converts the source and pattern bitmaps to match the destination bitmap.</para>
        /// <para>If StretchBlt must convert a monochrome bitmap to a color bitmap, it sets white bits (1) to the background color and black bits (0) to the foreground color. To convert a color bitmap to a monochrome bitmap, it sets pixels that match the background color to white (1) and sets all other pixels to black (0). The foreground and background colors of the device context with color are used.</para>
        /// <para>StretchBlt creates a mirror image of a bitmap if the signs of the nWidthSrc and nWidthDest parameters or if the nHeightSrc and nHeightDest parameters differ. If nWidthSrc and nWidthDest have different signs, the function creates a mirror image of the bitmap along the x-axis. If nHeightSrc and nHeightDest have different signs, the function creates a mirror image of the bitmap along the y-axis.</para>
        /// <para>Not all devices support the StretchBlt function. For more information, see the GetDeviceCaps.</para>
        /// <para>ICM: No color management is performed when a blit operation occurs.</para>
        /// <para>When used in a multiple monitor system, both hdcSrc and hdcDest must refer to the same device or the function will fail. To transfer data between DCs for different devices, convert the memory bitmap to a DIB by calling GetDIBits. To display the DIB to the second device, call SetDIBits or StretchDIBits.</para>
        /// </summary>
        /// <param name="hdcDest">指向目标设备环境的句柄。</param>
        /// <param name="nXOriginDest">指定目标矩形左上角的X轴坐标，按逻辑单位表示坐标。</param>
        /// <param name="nYOriginDest">指定目标矩形左上角的Y轴坐标，按逻辑单位表示坐标。</param>
        /// <param name="nWidthDest">指定目标矩形的宽度，按逻辑单位表示宽度。</param>
        /// <param name="nHeightDest">指定目标矩形的高度，按逻辑单位表示高度。</param>
        /// <param name="hdcSrc">指向源设备环境的句柄。</param>
        /// <param name="nXOriginSrc">指向源矩形区域左上角的X轴坐标，按逻辑单位表示坐标。</param>
        /// <param name="nYOriginSrc">指向源矩形区域左上角的Y轴坐标，按逻辑单位表示坐标。</param>
        /// <param name="nWidthSrc">指定源矩形的宽度，按逻辑单位表示宽度。</param>
        /// <param name="nHeightSrc">指定源矩形的高度，按逻辑单位表示高度。</param>
        /// <param name="dwRop">指定要进行的光栅操作。光栅操作码定义了系统如何在输出操作中组合颜色，这些操作包括刷子、源位图和目标位图等对象。参考BitBlt可了解常用的光栅操作码列表。</param>
        /// <returns>如果函数执行成功，那么返回值为非零，如果函数执行失败，那么返回值为零。</returns>
        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool StretchBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeightDest, IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc, int dwRop);
        /// <summary>
        /// <para>功能:</para>
        /// <para>（Win2K和Win2K后请调用GdiAlphaBlend）该函数用来显示具有指定透明度的图像。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>如果源矩形区域与目标矩形区域大小不一样，那么将缩放源位图与目标矩形区域匹配。</para>
        /// <para>如果使用SetStretchBltMode函数，那么iStretchMode的值是BLACKONWHITE和WHITEONBLACK，在本函数中，iStretchMode的值自动转换成COLORONCOLOR。</para>
        /// <para>目标坐标使用为目标设备环境当前指定的转换方式进行转换。</para>
        /// <para>源坐标则使用为源设备环境指定的当前转换方式进行转换。</para>
        /// <para>如果源设备环境标识为增强型图元文件设备环境，那么会出错（并且该函数返回FALSE）。</para>
        /// <para>如果目标和源位图的色彩格式不同，那么AlphaBlend将源位图转换以匹配目标位图。</para>
        /// <para>AlphaBlend不支持镜像。如果源或目标区域的宽度或高度为负数，那么调用将失败。</para>
        /// </summary>
        /// <param name="hdcDest">指向目标设备环境的句柄。</param>
        /// <param name="xoriginDest">指定目标矩形区域左上角的X轴坐标，按逻辑单位。</param>
        /// <param name="yoriginDest">指定目标矩形区域左上角的Y轴坐标，按逻辑单位。</param>
        /// <param name="wDest">指定目标矩形区域的宽度，按逻辑单位。</param>
        /// <param name="hDest">指向目标矩形区域的高度，按逻辑单位。</param>
        /// <param name="hdcSrc">指向源设备环境的句柄。</param>
        /// <param name="xoriginSrc">指定源矩形区域左上角的X轴坐标，按逻辑单位。</param>
        /// <param name="yoriginSrc">指定源矩形区域左上角的Y轴坐标，按逻辑单位。</param>
        /// <param name="wSrc">指定源矩形区域的宽度，按逻辑单位。</param>
        /// <param name="hSrc">指定源矩形区域的高度，按逻辑单位。</param>
        /// <param name="ftn">指定用于源位图和目标位图使用的alpha混合功能，用于整个源位图的全局alpha值和格式信息。源和目标混合功能当前只限为AC_SRC_OVER。最后一个参数blendFunction是一个BLENDFUNCTION结构。BLENDFUNCTION结构控制源和目标位图的混合方式，它的BlendOp字段指明了源混合操作，但只支持AC_SRC_OVER，即根据源alpha值把源图像叠加到目标图像上。OpenGL的alpha混合还支持其他的方式，如常量颜色源。下一个字段BlendFlags必须是0，也是为以后的应用保留的。最后一个字段AlphaFormat有两个选择：0表示常量alpha值，AC_SRC_ALPHA表示每个像素有各自的alpha通道。</param>
        /// <returns>如果函数执行成功，那么返回值为TRUE；如果函数执行失败，那么返回值为FALSE。If the function succeeds, the return value is TRUE.If the function fails, the return value is FALSE.This function can return the following value.ERROR_INVALID_PARAMETER:One or more of the input parameters is invalid.</returns>
        [DllImport("gdi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GdiAlphaBlend(IntPtr hdcDest, int xoriginDest, int yoriginDest, int wDest, int hDest, IntPtr hdcSrc, int xoriginSrc, int yoriginSrc, int wSrc, int hSrc, NativeMethods.BLENDFUNCTION ftn);
        /// <summary>
        /// <para>功能:</para>
        /// <para>（Win2K和Win2K后请调用GdiGradientFill）该函数填充矩形和三角形结构。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>若想在矩形区域中加入一些平滑的阴影（底纹），请用三角形的三个顶点调用GradientFill函数。CDI将进行线性插值，并填充矩形区域。</para>
        /// <para>在绘制矩形时可能使用两种阴影模式在水平模式中，矩形从左至右开始变暗，在垂直模式中则是从上至下进行。</para>
        /// </summary>
        /// <param name="hdc">指向目标设备环境的句柄。</param>
        /// <param name="pVertex">指向TRIVERTEX结构数组的指针，该数组中的每项定义了三角形顶点。</param>
        /// <param name="dwVertex">顶点数目。</param>
        /// <param name="pMesh">三角形模式下的GRADIENT_TRIANGLE结构数组，或矩形模式下的GRADIENT_RECT结构数组。</param>
        /// <param name="dwMesh">参数pMesh中的成员数目（这些成员是三角形或矩形）。</param>
        /// <param name="dwMode">指定倾斜填充模式。该参数可以包含下列值，这些值的含义为：</param>
        /// <returns>如果函数执行成功，那么返回值为TRUE；如果函数执行失败，则返回值为FALSE。</returns>
        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GdiGradientFill(IntPtr hdc, IntPtr pVertex, uint dwVertex, IntPtr pMesh, uint dwMesh, uint dwMode);
        /// <summary>
        /// <para>功能:</para>
        /// <para>（Win2K和Win2K后请调用GdiTransparentBlt）该函数对指定的源设备环境中的矩形区域像素的颜色数据进行位块（bit_block）转换，并将结果置于目标设备环境。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>函数TransparentBlt支持4位/像素和8位/像素格式的源位图，使用AlphaBlend可以指定带有透明度的32位/像素格式的位图。</para>
        /// <para>如果源和目标矩形的大小不一致，那么将对源位图进行拉伸以与目标矩形匹配，当使用SetStretchBltMode函数时，BLACKONWHITE和WHITEONBLACK两种iStretchMode模式将被转换成TransparentBlt函数的COLORONCOLOR模式。</para>
        /// <para>目标设备环境指定了用于目标坐标的变换类型，而源设备环境指定了源坐标使用的变换类型。</para>
        /// <para>如果源位图或目标位图的宽度或高度是负数，那么TransparentBlt函数也不对位图进行镜像。</para>
        /// </summary>
        /// <param name="hdcDest">指向目标设备环境的句柄。</param>
        /// <param name="xoriginDest">指定目标矩形区域左上角的X轴坐标，按逻辑单位。</param>
        /// <param name="yoriginDest">指定目标矩形区域左上角的Y轴坐标，按逻辑单位。</param>
        /// <param name="wDest">指定目标矩形区域的宽度，按逻辑单位。</param>
        /// <param name="hDest">指向目标矩形区域的高度，按逻辑单位。</param>
        /// <param name="hdcSrc">指向源设备环境的句柄。</param>
        /// <param name="xoriginSrc">指定源矩形区域左上角的X轴坐标，按逻辑单位。</param>
        /// <param name="yoriginSrc">指定源矩形区域左上角的Y轴坐标，按逻辑单位。</param>
        /// <param name="wSrc">指定源矩形区域的宽度，按逻辑单位。</param>
        /// <param name="hSrc">指定源矩形区域的高度，按逻辑单位。</param>
        /// <param name="crTransparent">源位图中的RGB值当作透明颜色。</param>
        /// <returns>返回值：如果函数执行成功，那么返回值为TRUE；如果函数执行失败，那么返回值为FALSE。</returns>
        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GdiTransparentBlt(IntPtr hdcDest, int xoriginDest, int yoriginDest, int wDest, int hDest, IntPtr hdcSrc, int xoriginSrc, int yoriginSrc, int wSrc, int hSrc, uint crTransparent);
    }
}
