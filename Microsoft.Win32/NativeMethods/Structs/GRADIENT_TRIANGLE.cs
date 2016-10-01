using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// GRADIENT_TRIANGLE定义
    /// </summary>
    public static partial class NativeMethods
    {
        /// <summary>
        /// The GRADIENT_TRIANGLE structure specifies the index of three vertices in the pVertex array in the GradientFill function. These three vertices form one triangle.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct GRADIENT_TRIANGLE
        {
            /// <summary>
            /// The first point of the triangle where sides intersect.
            /// </summary>
            uint Vertex1;
            /// <summary>
            /// The second point of the triangle where sides intersect.
            /// </summary>
            uint Vertex2;
            /// <summary>
            /// The third point of the triangle where sides intersect.
            /// </summary>
            uint Vertex3;

            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="vertex1">第一个点</param>
            /// <param name="vertex2">第二个点</param>
            /// <param name="vertex3">第三个点</param>
            public GRADIENT_TRIANGLE(uint vertex1, uint vertex2, uint vertex3)
            {
                this.Vertex1 = vertex1;
                this.Vertex2 = vertex2;
                this.Vertex3 = vertex3;
            }
        }
    }
}
