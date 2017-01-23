using System.ComponentModel;

namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// 图元对象
    /// </summary>
    [Browsable(false)]
    public partial class Sprite : Disposable
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Sprite()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="owner">所有者</param>
        public Sprite(IUIControl owner)
        {
            this.m_Owner = owner;
        }
    }
}
