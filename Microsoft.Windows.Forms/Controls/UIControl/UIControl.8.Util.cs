using System.Drawing;
using System.Windows.Forms;
using Microsoft.Drawing;

namespace Microsoft.Windows.Forms
{
    partial class UIControl
    {
        /// <summary>
        /// 对指定控件的子控件重新计算布局
        /// </summary>
        /// <param name="control">指定控件</param>
        internal static void DoLayoutInternal(IUIControl control)
        {
            //实际
            int _x;
            int _y;
            int _width;
            int _height;
            Rectangle rect = control.ClientRectangle;
            control.BeginUpdate();
            try
            {
                foreach (UIControl child in control.UIControls)
                {
                    //停靠
                    switch (child.Dock)
                    {
                        case DockStyle.Left:
                            child.SetBoundsCore(rect.Left, rect.Top, child.m_Width, rect.Height);
                            if (child.Visible)
                                rect = RectangleEx.Subtract(rect, new Padding(child.m_Width, 0, 0, 0));
                            continue;

                        case DockStyle.Top:
                            child.SetBoundsCore(rect.Left, rect.Top, rect.Width, child.m_Height);
                            if (child.Visible)
                                rect = RectangleEx.Subtract(rect, new Padding(0, child.m_Height, 0, 0));
                            continue;

                        case DockStyle.Right:
                            child.SetBoundsCore(rect.Width - child.m_Width, rect.Top, child.m_Width, rect.Height);
                            if (child.Visible)
                                rect = RectangleEx.Subtract(rect, new Padding(0, 0, child.m_Width, 0));
                            continue;

                        case DockStyle.Bottom:
                            child.SetBoundsCore(rect.Left, rect.Height - child.m_Height, rect.Width, child.m_Height);
                            if (child.Visible)
                                rect = RectangleEx.Subtract(rect, new Padding(0, 0, 0, child.m_Height));
                            continue;

                        case DockStyle.Fill:
                            child.SetBoundsCore(rect.Left, rect.Top, rect.Width, rect.Height);
                            if (child.Visible)
                                rect = Rectangle.Empty;
                            continue;
                    }
                    //锚定
                    if (child.m_TopToParent == null || child.m_BottomToParent == null)
                    {
                        _y = child.m_Y;
                        _height = child.m_Height;
                        child.m_TopToParent = child.m_Y;
                        child.m_BottomToParent = rect.Height - child.Bottom;
                    }
                    else
                    {
                        switch (child.Anchor & (AnchorStyles.Top | AnchorStyles.Bottom))
                        {
                            case AnchorStyles.Top:
                                _y = child.m_TopToParent.Value;
                                _height = child.m_Height;
                                break;
                            case AnchorStyles.Bottom:
                                _y = rect.Height - child.m_BottomToParent.Value - child.m_Height;
                                _height = child.m_Height;
                                break;
                            case AnchorStyles.Top | AnchorStyles.Bottom:
                                _y = child.m_TopToParent.Value;
                                _height = rect.Height - child.m_TopToParent.Value - child.m_BottomToParent.Value;
                                break;
                            default:
                                _y = child.m_TopToParent.Value + (rect.Height - child.m_TopToParent.Value - child.m_Height - child.m_BottomToParent.Value) / 2;
                                _height = child.m_Height;
                                break;
                        }
                    }
                    //zuoyou
                    if (child.m_LeftToParent == null || child.m_RightToParent == null)
                    {
                        _x = child.m_X;
                        _width = child.m_Width;
                        child.m_LeftToParent = child.m_X;
                        child.m_RightToParent = rect.Width - child.Right;
                    }
                    else
                    {
                        switch (child.Anchor & (AnchorStyles.Left | AnchorStyles.Right))
                        {
                            case AnchorStyles.Left:
                                _x = child.m_LeftToParent.Value;
                                _width = child.m_Width;
                                break;
                            case AnchorStyles.Right:
                                _x = rect.Width - child.m_RightToParent.Value - child.m_Width;
                                _width = child.m_Width;
                                break;
                            case AnchorStyles.Left | AnchorStyles.Right:
                                _x = child.m_LeftToParent.Value;
                                _width = rect.Width - child.m_LeftToParent.Value - child.m_BottomToParent.Value;
                                break;
                            default:
                                _x = child.m_LeftToParent.Value + (rect.Width - child.m_LeftToParent.Value - child.m_Width - child.m_RightToParent.Value) / 2;
                                _width = child.m_Width;
                                break;
                        }
                    }
                    child.SetBoundsCore(_x, _y, _width, _height);
                }
            }
            finally
            {
                control.EndUpdate();
            }
        }

        /// <summary>
        /// 查找控件内指定坐标的子控件,按 Z 轴可见序查找
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="p">控件坐标系内的点</param>
        /// <returns>查找到返回子控件,否则返回 null</returns>
        internal static UIControl FindUIChildInternal(IUIControl control, Point p)
        {
            UIControl child;
            for (int i = control.UIControls.Count - 1; i >= 0; i--)//按 Z 轴顺序遍历
            {
                child = control.UIControls[i];
                if (child.Visible && child.Bounds.Contains(p) && (child.Region == null || child.Region.IsVisible(PointEx.Offset(p, -child.Left, -child.Top))))
                    return FindUIChildInternal(child, PointEx.Offset(p, -child.Left, -child.Top)) ?? child;
            }
            return null;
        }

        /// <summary>
        /// 查找控件内指定名称的控件,按 Z 轴可见序查找
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="name">名称</param>
        /// <returns>查找到返回子控件,否则返回 null</returns>
        internal static UIControl FindUIChildInternal(IUIControl control, string name)
        {
            UIControl child;
            for (int i = control.UIControls.Count - 1; i >= 0; i--)
            {
                child = control.UIControls[i];
                if (child.Name == name)
                    return child;
                else if (child.UIControls.Count > 0)
                    return FindUIChildInternal(child, name);
            }
            return null;
        }
    }
}
