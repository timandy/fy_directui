using System.Drawing;

namespace Microsoft.Windows.Forms
{
    partial interface IUIControl
    {
        /// <summary>
        /// 获取或设置文本
        /// </summary>
        string Text
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置字体
        /// </summary>
        Font Font
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置背景色
        /// </summary>
        Color BackColor
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置前景色
        /// </summary>
        Color ForeColor
        {
            get;
            set;
        }

        /// <summary>
        /// 获取状态
        /// </summary>
        State State
        {
            get;
        }
    }
}
