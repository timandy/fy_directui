using System.Windows.Forms;

namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// 支持虚拟控件的窗体
    /// </summary>
    public partial class UIForm : Form, IUIWindow
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public UIForm()
        {
            this.SetStyle(
               ControlStyles.UserPaint |
               ControlStyles.AllPaintingInWmPaint |
               ControlStyles.OptimizedDoubleBuffer |
               ControlStyles.ResizeRedraw |
               ControlStyles.SupportsTransparentBackColor, true);
            this.Font = DefaultTheme.Font;
            this.BackColor = DefaultTheme.BackColor;
            this.ForeColor = DefaultTheme.ForeColor;
        }
    }
}
