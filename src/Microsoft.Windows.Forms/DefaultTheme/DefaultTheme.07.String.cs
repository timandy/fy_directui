using System.Drawing;

namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// 默认值方案
    /// </summary>
    public static partial class DefaultTheme
    {
        /// <summary>
        /// 默认文本布局信息.每次获取都将生成新对象,使用完毕需要释放资源.
        /// </summary>
        public static StringFormat StringFormat
        {
            get
            {
                StringFormat sf = (StringFormat)StringFormat.GenericTypographic.Clone();
                sf.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
                sf.Trimming = StringTrimming.EllipsisCharacter;
                return sf;
            }
        }
    }
}
