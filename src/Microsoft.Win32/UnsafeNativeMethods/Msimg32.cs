using System;
using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// Msimg32.dll
    /// </summary>
    public static partial class UnsafeNativeMethods
    {
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
        /// <returns>如果函数执行成功，那么返回值为TRUE；如果函数执行失败，那么返回值为FALSE。</returns>
        [DllImport("msimg32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AlphaBlend(IntPtr hdcDest, int xoriginDest, int yoriginDest, int wDest, int hDest, IntPtr hdcSrc, int xoriginSrc, int yoriginSrc, int wSrc, int hSrc, NativeMethods.BLENDFUNCTION ftn);
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
        /// <param name="nVertex">顶点数目。</param>
        /// <param name="pMesh">三角形模式下的GRADIENT_TRIANGLE结构数组，或矩形模式下的GRADIENT_RECT结构数组。</param>
        /// <param name="nMesh">参数pMesh中的成员数目（这些成员是三角形或矩形）。</param>
        /// <param name="ulMode">指定倾斜填充模式。该参数可以包含下列值，这些值的含义为：</param>
        /// <returns>如果函数执行成功，那么返回值为TRUE；如果函数执行失败，则返回值为FALSE。</returns>
        [DllImport("msimg32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GradientFill(IntPtr hdc, IntPtr pVertex, uint nVertex, IntPtr pMesh, uint nMesh, uint ulMode);
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
        [DllImport("msimg32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool TransparentBlt(IntPtr hdcDest, int xoriginDest, int yoriginDest, int wDest, int hDest, IntPtr hdcSrc, int xoriginSrc, int yoriginSrc, int wSrc, int hSrc, uint crTransparent);
    }
}
