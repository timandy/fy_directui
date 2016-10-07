using System;
using System.Drawing;
using System.Windows.Forms;

namespace Microsoft.Windows.Forms
{
    partial class UIControl
    {
        private IUIControl m_UIParent;
        private IUIControl UIParentInternal
        {
            get
            {
                return this.m_UIParent;
            }
            set
            {
                if (value != this.m_UIParent)
                {
                    this.m_UIParent = value;
                    this.OnParentChanged(EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// 获取或设置父控件
        /// </summary>
        public IUIControl UIParent
        {
            get
            {
                return this.m_UIParent;
            }
            set
            {
                if (value != this.m_UIParent)
                {
                    if (value != null)
                        value.UIControls.Add(this);
                    else
                        this.m_UIParent.UIControls.Remove(this);
                }
            }
        }

        private UIControlCollection m_UIControls;
        /// <summary>
        /// 获取子控件集合
        /// </summary>
        public UIControlCollection UIControls
        {
            get
            {
                this.CheckDisposed();
                if (this.m_UIControls == null)
                    this.m_UIControls = new UIControlCollection(this);
                return this.m_UIControls;
            }
        }

        private Region m_Region;
        /// <summary>
        /// 获取或设置控件区域
        /// </summary>
        public Region Region
        {
            get
            {
                return this.m_Region;
            }
            set
            {
                if (this.m_Region != null)
                    this.m_Region.Dispose();
                this.m_Region = value == null ? null : value.Clone();
            }
        }

        private DockStyle m_Dock;
        /// <summary>
        /// 获取或设置停靠方式
        /// </summary>
        public DockStyle Dock
        {
            get
            {
                return this.m_Dock;
            }
            set
            {
                if (value != this.m_Dock)
                {
                    this.m_Dock = value;
                    if (this.m_UIParent != null)
                        this.m_UIParent.DoLayout();
                }
            }
        }

        private AnchorStyles m_Anchor = AnchorStyles.Left | AnchorStyles.Top;
        /// <summary>
        /// 获取或设置锚定方式
        /// </summary>
        public AnchorStyles Anchor
        {
            get
            {
                return this.m_Anchor;
            }
            set
            {
                if (value != this.m_Anchor)
                {
                    this.m_Anchor = value;
                    this.m_LeftToParent = null;
                    this.m_TopToParent = null;
                    this.m_RightToParent = null;
                    this.m_BottomToParent = null;
                }
            }
        }

        //初始左边距
        private int? m_LeftToParent;
        //初始上边距
        private int? m_TopToParent;
        //初始右边距
        private int? m_RightToParent;
        //初始下边距
        private int? m_BottomToParent;

        private int m_PreferredX;
        private int m_X;
        /// <summary>
        /// 获取或设置距离父控件的左边距
        /// </summary>
        public int Left
        {
            get
            {
                return this.m_X;
            }
            set
            {
                if (value != this.m_X)
                {
                    this.m_PreferredX = value;
                    this.SetBounds();
                }
            }
        }

        private int m_PreferredY;
        private int m_Y;
        /// <summary>
        /// 获取或设置距离父控件的上边距
        /// </summary>
        public int Top
        {
            get
            {
                return this.m_Y;
            }
            set
            {
                if (value != this.m_Y)
                {
                    this.m_PreferredY = value;
                    this.SetBounds();
                }
            }
        }

        private int m_PreferredWidth;
        private int m_Width;
        /// <summary>
        /// 获取或设置宽度
        /// </summary>
        public int Width
        {
            get
            {
                return this.m_Width;
            }
            set
            {
                if (value != this.m_Width)
                {
                    this.m_PreferredWidth = value;
                    this.SetBounds();
                }
            }
        }

        private int m_PreferredHeight;
        private int m_Height;
        /// <summary>
        /// 获取或设置高度
        /// </summary>
        public int Height
        {
            get
            {
                return this.m_Height;
            }
            set
            {
                if (value != this.m_Height)
                {
                    this.m_PreferredHeight = value;
                    this.SetBounds();
                }
            }
        }

        /// <summary>
        /// 获取距离父控件的右边距
        /// </summary>
        public int Right
        {
            get
            {
                return this.m_X + this.m_Width;
            }
        }

        /// <summary>
        /// 获取距离父控件的下边距
        /// </summary>
        public int Bottom
        {
            get
            {
                return this.m_Y + this.m_Height;
            }
        }

        /// <summary>
        /// 获取或设置控件左上角的坐标
        /// </summary>
        public Point Location
        {
            get
            {
                return new Point(this.m_X, this.m_Y);
            }
            set
            {
                if (value != this.Location)
                {
                    this.m_PreferredX = value.X;
                    this.m_PreferredY = value.Y;
                    this.SetBounds();
                }
            }
        }

        /// <summary>
        /// 获取或设置控件的大小
        /// </summary>
        public Size Size
        {
            get
            {
                return new Size(this.m_Width, this.m_Height);
            }
            set
            {
                if (value != this.Size)
                {
                    this.m_PreferredWidth = value.Width;
                    this.m_PreferredHeight = value.Height;
                    this.SetBounds();
                }
            }
        }

        /// <summary>
        /// 获取或设置控件的位置和大小
        /// </summary>
        public Rectangle Bounds
        {
            get
            {
                return new Rectangle(this.m_X, this.m_Y, this.m_Width, this.m_Height);
            }
            set
            {
                if (value != this.Bounds)
                {
                    this.m_PreferredX = value.X;
                    this.m_PreferredY = value.Y;
                    this.m_PreferredWidth = value.Width;
                    this.m_PreferredHeight = value.Height;
                    this.SetBounds();
                }
            }
        }

        /// <summary>
        /// 获取控件客户区大小
        /// </summary>
        public Size ClientSize
        {
            get
            {
                return this.Size;
            }
            set
            {
                this.Size = value;
            }
        }

        /// <summary>
        /// 获取控件客户区的位置和大小
        /// </summary>
        public Rectangle ClientRectangle
        {
            get
            {
                return new Rectangle(0, 0, this.m_Width, this.m_Height);
            }
        }

        private Padding m_Padding;
        /// <summary>
        /// 获取或设置内边距
        /// </summary>
        public Padding Padding
        {
            get
            {
                return this.m_Padding;
            }
            set
            {
                if (value != this.m_Padding)
                {
                    this.m_Padding = value;
                    this.Invalidate();
                }
            }
        }

        private int m_LayoutSuspendCount;
        /// <summary>
        /// 获取布局操作是否被挂起
        /// </summary>
        public bool LayoutSuspended
        {
            get
            {
                return this.m_LayoutSuspendCount != 0 || (this.m_UIParent != null && this.m_UIParent.LayoutSuspended);
            }
        }

        /// <summary>
        /// 设置控件位置和大小,先计算后设置
        /// </summary>
        private void SetBounds()
        {
            if (this.m_UIParent == null || this.Dock == DockStyle.None)
            {
                this.SetBoundsCore();
                this.DoLayout();
            }
            else
            {
                this.m_UIParent.DoLayout();
            }
        }

        /// <summary>
        /// 设置控件位置和大小,直接设置
        /// </summary>
        private void SetBoundsCore()
        {
            if (this.m_PreferredX != this.m_X || this.m_PreferredY != this.m_Y)
            {
                this.m_X = this.m_PreferredX;
                this.m_Y = this.m_PreferredY;
                if (this.m_UIParent != null)
                    this.m_UIParent.Invalidate();
                this.OnLocationChanged(EventArgs.Empty);
            }
            if (this.m_PreferredWidth != this.m_Width || this.m_PreferredHeight != this.m_Height)
            {
                this.m_Width = this.m_PreferredWidth;
                this.m_Height = this.m_PreferredHeight;
                this.Invalidate();
                this.OnSizeChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// 挂起布局操作
        /// </summary>
        public void SuspendLayout()
        {
            this.m_LayoutSuspendCount++;
        }

        /// <summary>
        /// 恢复挂起的布局操作
        /// </summary>
        public void ResumeLayout()
        {
            this.ResumeLayout(false);
        }

        /// <summary>
        /// 恢复挂起的布局操作,可选择是否强制执行布局
        /// </summary>
        /// <param name="performLayout">如果强制则为 true, 否则为 false</param>
        public void ResumeLayout(bool performLayout)
        {
            this.m_LayoutSuspendCount--;
            this.DoLayoutCore(performLayout);
        }

        /// <summary>
        /// 如果未挂起布局操作则重新计算子控件布局
        /// </summary>
        public void DoLayout()
        {
            this.DoLayoutCore(false);
        }

        /// <summary>
        /// 重新计算子控件布局,可选择是否强制执行布局
        /// </summary>
        /// <param name="performLayout">如果强制则为 true, 否则为 false</param>
        protected void DoLayoutCore(bool performLayout)
        {
            if (performLayout || !this.LayoutSuspended)
                DoLayoutInternal(this);
        }

        /// <summary>
        /// 将控件置于 Z 轴底层
        /// </summary>
        public void SendToBack()
        {
            IUIControl parent = this.m_UIParent;
            if (parent == null)
                return;
            parent.SuspendLayout();
            try
            {
                parent.UIControls.Remove(this);
                parent.UIControls.Insert(0, this);
            }
            finally
            {
                parent.ResumeLayout();
            }
        }

        /// <summary>
        /// 将控件置于 Z 轴顶层
        /// </summary>
        public void BringToFront()
        {
            IUIControl parent = this.m_UIParent;
            if (parent == null)
                return;
            parent.SuspendLayout();
            try
            {
                parent.UIControls.Remove(this);
                parent.UIControls.Add(this);
            }
            finally
            {
                parent.ResumeLayout();
            }
        }

        /// <summary>
        /// 将屏幕坐标系的点转换为控件坐标系的点
        /// </summary>
        /// <param name="p">点</param>
        /// <returns>转换后的点</returns>
        public Point PointToClient(Point p)
        {
            IUIControl parent = this;
            IUIWindow window = null;
            while (parent != null && (window = parent as IUIWindow) == null)
            {
                p.Offset(-parent.Left, -parent.Top);
                parent = parent.UIParent;
            }
            return window.PointToClient(p);
        }

        /// <summary>
        /// 将控件坐标系的点转换为屏幕坐标系的点
        /// </summary>
        /// <param name="p">点</param>
        /// <returns>转换后的点</returns>
        public Point PointToScreen(Point p)
        {
            IUIControl parent = this;
            IUIWindow window = null;
            while (parent != null && (window = parent as IUIWindow) == null)
            {
                p.Offset(parent.Left, parent.Top);
                parent = parent.UIParent;
            }
            return window.PointToScreen(p);
        }

        /// <summary>
        /// 将屏幕坐标系的矩形转换为控件坐标系的矩形
        /// </summary>
        /// <param name="r">矩形</param>
        /// <returns>转换后的矩形</returns>
        public Rectangle RectangleToClient(Rectangle r)
        {
            IUIControl parent = this;
            IUIWindow window = null;
            while (parent != null && (window = parent as IUIWindow) == null)
            {
                r.Offset(-parent.Left, -parent.Top);
                parent = parent.UIParent;
            }
            return window.RectangleToClient(r);
        }

        /// <summary>
        /// 将控件坐标系的矩形转换为屏幕坐标系的矩形
        /// </summary>
        /// <param name="r">矩形</param>
        /// <returns>转换后的矩形</returns>
        public Rectangle RectangleToScreen(Rectangle r)
        {
            IUIControl parent = this;
            IUIWindow window = null;
            while (parent != null && (window = parent as IUIWindow) == null)
            {
                r.Offset(parent.Left, parent.Top);
                parent = parent.UIParent;
            }
            return window.RectangleToScreen(r);
        }

        /// <summary>
        /// 将所在 Win32 控件坐标系的点转换为控件坐标系的点
        /// </summary>
        /// <param name="p">点</param>
        /// <returns>转换后的点</returns>
        public Point PointToUIControl(Point p)
        {
            IUIControl parent = this;
            IUIWindow window = null;
            while (parent != null && (window = parent as IUIWindow) == null)
            {
                p.Offset(-parent.Left, -parent.Top);
                parent = parent.UIParent;
            }
            return p;
        }

        /// <summary>
        /// 将控件坐标系的点转换为所在 Win32 控件坐标系的点
        /// </summary>
        /// <param name="p">点</param>
        /// <returns>转换后的点</returns>
        public Point PointToUIWindow(Point p)
        {
            IUIControl parent = this;
            IUIWindow window = null;
            while (parent != null && (window = parent as IUIWindow) == null)
            {
                p.Offset(parent.Left, parent.Top);
                parent = parent.UIParent;
            }
            return p;
        }

        /// <summary>
        /// 将所在 Win32 控件坐标系的矩形转换为控件坐标系的矩形
        /// </summary>
        /// <param name="r">矩形</param>
        /// <returns>转换后的矩形</returns>
        public Rectangle RectangleToUIControl(Rectangle r)
        {
            IUIControl parent = this;
            IUIWindow window = null;
            while (parent != null && (window = parent as IUIWindow) == null)
            {
                r.Offset(-parent.Left, -parent.Top);
                parent = parent.UIParent;
            }
            return r;
        }

        /// <summary>
        /// 将控件坐标系的矩形转换为所在 Win32 控件坐标系的矩形
        /// </summary>
        /// <param name="r">矩形</param>
        /// <returns>转换后的矩形</returns>
        public Rectangle RectangleToUIWindow(Rectangle r)
        {
            IUIControl parent = this;
            IUIWindow window = null;
            while (parent != null && (window = parent as IUIWindow) == null)
            {
                r.Offset(parent.Left, parent.Top);
                parent = parent.UIParent;
            }
            return r;
        }

        /// <summary>
        /// 查找所在的 Win32 控件
        /// </summary>
        /// <returns>所在的 Win32 控件</returns>
        public IUIWindow FindUIWindow()
        {
            IUIControl parent = this;
            IUIWindow window = null;
            while (parent != null && (window = parent as IUIWindow) == null)
                parent = parent.UIParent;
            return window;
        }

        /// <summary>
        /// 根据坐标查找子控件
        /// </summary>
        /// <param name="p">坐标</param>
        /// <returns>子控件</returns>
        public UIControl FindUIChild(Point p)
        {
            return FindUIChildInternal(this, p);
        }

        /// <summary>
        /// 根据名称查找子控件
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>子控件</returns>
        public UIControl FindUIChild(string name)
        {
            return FindUIChildInternal(this, name);
        }
    }
}
