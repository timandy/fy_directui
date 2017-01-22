using System;
using System.Windows.Forms;

namespace Microsoft.Windows.Forms
{
    partial interface IUIControl
    {
        /// <summary>
        /// 父控件改变事件
        /// </summary>
        event EventHandler ParentChanged;

        /// <summary>
        /// 鼠标进入事件
        /// </summary>
        event EventHandler Enter;

        /// <summary>
        /// 鼠标离开事件
        /// </summary>
        event EventHandler Leave;

        /// <summary>
        /// 坐标改变事件
        /// </summary>
        event EventHandler LocationChanged;

        /// <summary>
        /// 大小改变事件
        /// </summary>
        event EventHandler SizeChanged;

        /// <summary>
        /// 鼠标按下事件
        /// </summary>
        event MouseEventHandler MouseDown;

        /// <summary>
        /// 鼠标弹起事件
        /// </summary>
        event MouseEventHandler MouseUp;

        /// <summary>
        /// 鼠标移动事件
        /// </summary>
        event MouseEventHandler MouseMove;

        /// <summary>
        /// 单击事件
        /// </summary>
        event EventHandler Click;

        /// <summary>
        /// 双击事件
        /// </summary>
        event EventHandler DoubleClick;

        /// <summary>
        /// 渲染事件
        /// </summary>
        event PaintEventHandler Render;
    }
}
