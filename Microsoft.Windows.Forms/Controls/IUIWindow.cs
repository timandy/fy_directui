using System.Windows.Forms;
using Microsoft.Drawing;

namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// 支持虚拟控件的 Win32 控件接口
    /// </summary>
    public interface IUIWindow : IUIControl, IWin32Window
    {
        /// <summary>
        /// 是否已创建句柄
        /// </summary>
        bool IsHandleCreated
        {
            get;
        }

        /// <summary>
        /// 双缓冲接口
        /// </summary>
        DoubleBufferedGraphics DoubleBufferedGraphics
        {
            get;
        }
    }
}
