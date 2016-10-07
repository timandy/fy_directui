using System.Drawing;
using System.Windows.Forms;

namespace Microsoft.Windows.Forms
{
    partial interface IUIControl
    {
        /// <summary>
        /// 获取刷新操作是否被挂起
        /// </summary>
        bool UpdateSuspended
        {
            get;
        }

        /// <summary>
        /// 渲染控件和子控件
        /// </summary>
        /// <param name="e">数据</param>
        void RenderCore(PaintEventArgs e);

        /// <summary>
        /// 挂起刷新 UI
        /// </summary>
        void BeginUpdate();

        /// <summary>
        /// 恢复刷新 UI
        /// </summary>
        void EndUpdate();

        /// <summary>
        /// 恢复刷新 UI,可以选择强制刷新
        /// </summary>
        /// <param name="forceUpdate">若要执行刷新为 true,否则为 false</param>
        void EndUpdate(bool forceUpdate);

        /// <summary>
        /// 使控件工作区无效
        /// </summary>
        void Invalidate();

        /// <summary>
        /// 使控件工作区无效
        /// </summary>
        /// <param name="invalidateChildren">使控件所在的 Win32 窗口的子控件无效为 true,否则为 false</param>
        void Invalidate(bool invalidateChildren);

        /// <summary>
        /// 使控件矩形无效
        /// </summary>
        /// <param name="rc">无效矩形</param>
        void Invalidate(Rectangle rc);

        /// <summary>
        /// 使控件矩形无效
        /// </summary>
        /// <param name="rc">无效矩形</param>
        /// <param name="invalidateChildren">使控件所在的 Win32 窗口的子控件无效为 true,否则为 false</param>
        void Invalidate(Rectangle rc, bool invalidateChildren);

        /// <summary>
        /// 重绘所在 Win32 窗口的无效区域
        /// </summary>
        void Update();

        /// <summary>
        /// 立即刷新所在 Win32 窗口和其子控件
        /// </summary>
        void Refresh();
    }
}
