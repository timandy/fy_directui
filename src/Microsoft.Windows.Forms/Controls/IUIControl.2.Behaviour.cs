namespace Microsoft.Windows.Forms
{
    partial interface IUIControl
    {
        /// <summary>
        /// 获取或设置控件名称
        /// </summary>
        string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置控件是否可见
        /// </summary>
        bool Visible
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置控件是否启用
        /// </summary>
        bool Enabled
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置控件是否捕获鼠标
        /// </summary>
        bool Capture
        {
            get;
            set;
        }

        /// <summary>
        /// 显示控件
        /// </summary>
        void Show();

        /// <summary>
        /// 隐藏控件
        /// </summary>
        void Hide();
    }
}
