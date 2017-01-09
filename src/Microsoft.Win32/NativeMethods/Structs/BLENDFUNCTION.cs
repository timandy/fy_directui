using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// BLENDFUNCTION定义
    /// </summary>
    public static partial class NativeMethods
    {
        /// <summary>
        /// <para>实现功能:The BLENDFUNCTION structure controls blending by specifying the blending functions for source and destination bitmaps.</para>
        /// <para>调用方法:Win32结构体</para>
        /// <para>.</para>
        /// <para>创建人员:许崇雷</para>
        /// <para>创建日期:2011-12-23</para>
        /// <para>创建备注:</para>
        /// <para>.</para>
        /// <para>修改人员:</para>
        /// <para>修改日期:</para>
        /// <para>修改备注:</para>
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct BLENDFUNCTION
        {
            /// <summary>
            /// 无效的,空结构所有字段为默认值
            /// </summary>
            public static readonly BLENDFUNCTION Empty;
            /// <summary>
            /// 一般情况下使用该值
            /// </summary>
            public static readonly BLENDFUNCTION Default;
            /// <summary>
            /// 静态构造
            /// </summary>
            static BLENDFUNCTION()
            {
                Empty = new BLENDFUNCTION();
                Default = new BLENDFUNCTION(NativeMethods.AC_SRC_OVER, 0, 255, NativeMethods.AC_SRC_ALPHA);
            }

            /// <summary>
            /// 指定源混合操作。目前，唯一的源和目标的混合方式已定义为AC_SRC_OVER。
            /// </summary>
            public byte BlendOp;
            /// <summary>
            /// 必须是0。
            /// </summary>
            public byte BlendFlags;
            /// <summary>
            /// 指定一个alpha透明度值，这个值将用于整个源位图;该SourceConstantAlpha值与源位图的每个像素的alpha值组合;如果设置为0，就会假定你的图片是透明的;如果需要使用每像素本身的alpha值，设置SourceConstantAlpha值255（不透明）。
            /// </summary>
            public byte SourceConstantAlpha;
            /// <summary>
            /// 这个参数控制源和目标的解析方式，AlphaFormat参数有以下值：AC_SRC_ALPHA： 这个值在源或者目标本身有Alpha通道时（也就是操作的图本身带有透明通道信息时），提醒系统API调用函数前必须预先乘以alpha值，也就是说位图上某个像素位置的red、green、blue通道值必须先与alpha相乘。例如，如果alpha透明值是x，那么red、green、blue三个通道的值必须乘以x并且再除以255（因为alpha的值的范围是0～255），之后才能被调用。
            /// </summary>
            public byte AlphaFormat;

            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="op">BlendOp</param>
            /// <param name="flags">BlendFlags</param>
            /// <param name="alpha">SourceConstantAlpha</param>
            /// <param name="format">AlphaFormat</param>
            public BLENDFUNCTION(byte op, byte flags, byte alpha, byte format)
            {
                this.BlendOp = op;
                this.BlendFlags = flags;
                this.SourceConstantAlpha = alpha;
                this.AlphaFormat = format;
            }
        }
    }
}
