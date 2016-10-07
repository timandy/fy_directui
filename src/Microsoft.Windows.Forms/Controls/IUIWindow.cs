using System;
using Microsoft.Drawing;

namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// 支持虚拟控件的 Win32 控件接口
    /// </summary>
    public interface IUIWindow : IUIControl, IWindow, IDisposable, IDisposed, IDisposeState
    {
        /// <summary>
        /// 双缓冲接口
        /// </summary>
        DoubleBufferedGraphics DoubleBufferedGraphics
        {
            get;
        }
    }
}
