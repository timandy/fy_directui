using System;
using System.ComponentModel;
using System.Drawing;

namespace Microsoft.Windows.Forms
{
    partial class UIWinControl
    {
        /// <summary>
        /// 获取或设置父控件
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IUIControl UIParent
        {
            get
            {
                return null;
            }
            set
            {
                throw new NotSupportedException("不允许为 UIWinControl 设置 Parent");
            }
        }

        private UIControl.UIControlCollection m_UIControls;
        /// <summary>
        /// 获取子控件集合
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public UIControl.UIControlCollection UIControls
        {
            get
            {
                this.CheckDisposed();
                if (this.m_UIControls == null)
                    this.m_UIControls = new UIControl.UIControlCollection(this);
                return this.m_UIControls;
            }
        }

        private int m_LayoutSuspendCount;
        /// <summary>
        /// 挂起布局操作
        /// </summary>
        public new void SuspendLayout()
        {
            this.m_LayoutSuspendCount++;
            base.SuspendLayout();
        }

        /// <summary>
        /// 恢复挂起的布局操作
        /// </summary>
        public new void ResumeLayout()
        {
            this.ResumeLayout(false);
        }

        /// <summary>
        /// 恢复挂起的布局操作,可选择是否强制执行布局
        /// </summary>
        /// <param name="performLayout">如果强制则为 true, 否则为 false</param>
        public new void ResumeLayout(bool performLayout)
        {
            this.m_LayoutSuspendCount--;
            this.DoLayout(performLayout);
            base.ResumeLayout(performLayout);
        }

        /// <summary>
        /// 如果未挂起布局操作则重新计算子控件布局
        /// </summary>
        public void DoLayout()
        {
            this.DoLayout(false);
        }

        /// <summary>
        /// 重新计算子控件布局,可选择是否强制执行布局
        /// </summary>
        /// <param name="performLayout">如果强制则为 true, 否则为 false</param>
        public void DoLayout(bool performLayout)
        {
            if (performLayout || this.m_LayoutSuspendCount == 0)
                UIControl.DoLayoutInternal(this);
        }

        /// <summary>
        /// 将所在 Win32 控件坐标系的点转换为控件坐标系的点
        /// </summary>
        /// <param name="p">点</param>
        /// <returns>转换后的点</returns>
        public Point PointToUIControl(Point p)
        {
            return p;
        }

        /// <summary>
        /// 将控件坐标系的点转换为所在 Win32 控件坐标系的点
        /// </summary>
        /// <param name="p">点</param>
        /// <returns>转换后的点</returns>
        public Point PointToUIWindow(Point p)
        {
            return p;
        }

        /// <summary>
        /// 将所在 Win32 控件坐标系的矩形转换为控件坐标系的矩形
        /// </summary>
        /// <param name="r">矩形</param>
        /// <returns>转换后的矩形</returns>
        public Rectangle RectangleToUIControl(Rectangle r)
        {
            return r;
        }

        /// <summary>
        /// 将控件坐标系的矩形转换为所在 Win32 控件坐标系的矩形
        /// </summary>
        /// <param name="r">矩形</param>
        /// <returns>转换后的矩形</returns>
        public Rectangle RectangleToUIWindow(Rectangle r)
        {
            return r;
        }

        /// <summary>
        /// 查找所在的 Win32 控件
        /// </summary>
        /// <returns>所在的 Win32 控件</returns>
        public IUIWindow FindUIWindow()
        {
            return this;
        }

        /// <summary>
        /// 根据坐标查找子控件
        /// </summary>
        /// <param name="p">坐标</param>
        /// <returns>子控件</returns>
        public UIControl FindUIChild(Point p)
        {
            return UIControl.FindUIChildInternal(this, p);
        }

        /// <summary>
        /// 根据名称查找子控件
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>子控件</returns>
        public UIControl FindUIChild(string name)
        {
            return UIControl.FindUIChildInternal(this, name);
        }

        /// <summary>
        /// 大小改变,重新计算布局
        /// </summary>
        /// <param name="e">计算布局</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.DoLayout();
        }
    }
}
