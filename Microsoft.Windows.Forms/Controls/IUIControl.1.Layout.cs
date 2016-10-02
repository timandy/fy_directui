using System.Drawing;
using System.Windows.Forms;

namespace Microsoft.Windows.Forms
{
    partial interface IUIControl
    {
        /// <summary>
        /// 获取或设置父控件
        /// </summary>
        IUIControl UIParent
        {
            get;
            set;
        }

        /// <summary>
        /// 获取子控件集合
        /// </summary>
        UIControl.UIControlCollection UIControls
        {
            get;
        }

        /// <summary>
        /// 获取或设置控件的区域
        /// </summary>
        Region Region
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置停靠方式
        /// </summary>
        DockStyle Dock
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置锚定方式
        /// </summary>
        AnchorStyles Anchor
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置距离父控件的左边距
        /// </summary>
        int Left
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置距离父控件的上边距
        /// </summary>
        int Top
        {
            get;
        }

        /// <summary>
        /// 获取或设置宽度
        /// </summary>
        int Width
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置高度
        /// </summary>
        int Height
        {
            get;
            set;
        }

        /// <summary>
        /// 获取距离父控件的右边距
        /// </summary>
        int Right
        {
            get;
        }

        /// <summary>
        /// 获取距离父控件的下边距
        /// </summary>
        int Bottom
        {
            get;
        }

        /// <summary>
        /// 获取或设置控件左上角的坐标
        /// </summary>
        Point Location
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置控件的大小
        /// </summary>
        Size Size
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置控件的位置和大小
        /// </summary>
        Rectangle Bounds
        {
            get;
            set;
        }

        /// <summary>
        /// 获取控件客户区大小
        /// </summary>
        Size ClientSize
        {
            get;
            set;
        }

        /// <summary>
        /// 获取控件客户区的位置和大小
        /// </summary>
        Rectangle ClientRectangle
        {
            get;
        }

        /// <summary>
        /// 获取或设置内边距
        /// </summary>
        Padding Padding
        {
            get;
            set;
        }

        /// <summary>
        /// 挂起布局操作
        /// </summary>
        void SuspendLayout();

        /// <summary>
        /// 恢复挂起的布局操作
        /// </summary>
        void ResumeLayout();

        /// <summary>
        /// 恢复挂起的布局操作,可选择是否强制执行布局
        /// </summary>
        /// <param name="performLayout">如果强制则为 true, 否则为 false</param>
        void ResumeLayout(bool performLayout);

        /// <summary>
        /// 如果未挂起布局操作则重新计算子控件布局
        /// </summary>
        void DoLayout();

        /// <summary>
        /// 重新计算子控件布局,可选择是否强制执行布局
        /// </summary>
        /// <param name="performLayout">如果强制则为 true, 否则为 false</param>
        void DoLayout(bool performLayout);

        /// <summary>
        /// 将控件置于 Z 轴底层
        /// </summary>
        void SendToBack();

        /// <summary>
        /// 将控件置于 Z 轴顶层
        /// </summary>
        void BringToFront();

        /// <summary>
        /// 将屏幕坐标系的点转换为控件坐标系的点
        /// </summary>
        /// <param name="p">点</param>
        /// <returns>转换后的点</returns>
        Point PointToClient(Point p);

        /// <summary>
        /// 将控件坐标系的点转换为屏幕坐标系的点
        /// </summary>
        /// <param name="p">点</param>
        /// <returns>转换后的点</returns>
        Point PointToScreen(Point p);

        /// <summary>
        /// 将屏幕坐标系的矩形转换为控件坐标系的矩形
        /// </summary>
        /// <param name="r">矩形</param>
        /// <returns>转换后的矩形</returns>
        Rectangle RectangleToClient(Rectangle r);

        /// <summary>
        /// 将控件坐标系的矩形转换为屏幕坐标系的矩形
        /// </summary>
        /// <param name="r">矩形</param>
        /// <returns>转换后的矩形</returns>
        Rectangle RectangleToScreen(Rectangle r);

        /// <summary>
        /// 将所在 Win32 控件坐标系的点转换为控件坐标系的点
        /// </summary>
        /// <param name="p">点</param>
        /// <returns>转换后的点</returns>
        Point PointToUIControl(Point p);

        /// <summary>
        /// 将控件坐标系的点转换为所在 Win32 控件坐标系的点
        /// </summary>
        /// <param name="p">点</param>
        /// <returns>转换后的点</returns>
        Point PointToUIWindow(Point p);

        /// <summary>
        /// 将所在 Win32 控件坐标系的矩形转换为控件坐标系的矩形
        /// </summary>
        /// <param name="r">矩形</param>
        /// <returns>转换后的矩形</returns>
        Rectangle RectangleToUIControl(Rectangle r);

        /// <summary>
        /// 将控件坐标系的矩形转换为所在 Win32 控件坐标系的矩形
        /// </summary>
        /// <param name="r">矩形</param>
        /// <returns>转换后的矩形</returns>
        Rectangle RectangleToUIWindow(Rectangle r);

        /// <summary>
        /// 查找所在的 Win32 控件
        /// </summary>
        /// <returns>所在的 Win32 控件</returns>
        IUIWindow FindUIWindow();

        /// <summary>
        /// 根据坐标查找子控件
        /// </summary>
        /// <param name="p">坐标</param>
        /// <returns>子控件</returns>
        UIControl FindUIChild(Point p);

        /// <summary>
        /// 根据名称查找子控件
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>子控件</returns>
        UIControl FindUIChild(string name);
    }
}
