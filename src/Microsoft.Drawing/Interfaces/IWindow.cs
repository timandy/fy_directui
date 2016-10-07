using System;
using System.Drawing;
using System.Windows.Forms;

namespace Microsoft.Drawing
{
    /// <summary>
    /// 与 Win32 窗口关联的控件接口
    /// </summary>
    public interface IWindow : IWin32Window, IDisposable, IDisposed, IDisposeState
    {
        /// <summary>
        /// 获取一个值，该值指示控件是否有与它关联的句柄。
        /// </summary>
        bool IsHandleCreated
        {
            get;
        }

        /// <summary>
        /// 获取一个值，该值指示是否显示该控件及其所有子控件。
        /// </summary>
        bool Visible
        {
            get;
        }

        /// <summary>
        /// 获取控件的高度和宽度。
        /// </summary>
        Size Size
        {
            get;
        }

        /// <summary>
        /// 为控件创建绘图画面。
        /// </summary>
        /// <returns>绘图画面</returns>
        Graphics CreateGraphics();
    }
}
