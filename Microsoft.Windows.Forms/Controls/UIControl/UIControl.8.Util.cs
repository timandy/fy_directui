using System.Drawing;
using System.Windows.Forms;
using Microsoft.Drawing;

namespace Microsoft.Windows.Forms
{
    partial class UIControl
    {
        /// <summary>
        /// 对指定控件的所有子控件重新计算布局
        /// </summary>
        /// <param name="control">指定控件</param>
        internal static void DoLayoutInternal(IUIControl control)
        {
            if (control.UIControls.Count <= 0)
                return;
            control.BeginUpdate();
            try
            {
                Rectangle rcClient = control.ClientRectangle;
                Rectangle rcDock = rcClient;
                foreach (UIControl child in control.UIControls)
                {
                    try
                    {
                        //停靠
                        switch (child.Dock)
                        {
                            case DockStyle.Left:
                                child.m_PreferredX = rcDock.Left;
                                child.m_PreferredY = rcDock.Top;
                                child.m_PreferredHeight = rcDock.Height;
                                child.SetBoundsCore();
                                if (child.Visible)
                                    rcDock = RectangleEx.Subtract(rcDock, new Padding(child.m_PreferredWidth, 0, 0, 0));
                                continue;

                            case DockStyle.Top:
                                child.m_PreferredX = rcDock.Left;
                                child.m_PreferredY = rcDock.Top;
                                child.m_PreferredWidth = rcDock.Width;
                                child.SetBoundsCore();
                                if (child.Visible)
                                    rcDock = RectangleEx.Subtract(rcDock, new Padding(0, child.m_PreferredHeight, 0, 0));
                                continue;

                            case DockStyle.Right:
                                child.m_PreferredX = rcDock.Right - child.m_PreferredWidth;
                                child.m_PreferredY = rcDock.Top;
                                child.m_PreferredHeight = rcDock.Height;
                                child.SetBoundsCore();
                                if (child.Visible)
                                    rcDock = RectangleEx.Subtract(rcDock, new Padding(0, 0, child.m_PreferredWidth, 0));
                                continue;

                            case DockStyle.Bottom:
                                child.m_PreferredX = rcDock.Left;
                                child.m_PreferredY = rcDock.Bottom - child.m_PreferredHeight;
                                child.m_PreferredWidth = rcDock.Width;
                                child.SetBoundsCore();
                                if (child.Visible)
                                    rcDock = RectangleEx.Subtract(rcDock, new Padding(0, 0, 0, child.m_PreferredHeight));
                                continue;

                            case DockStyle.Fill:
                                child.m_PreferredX = rcDock.Left;
                                child.m_PreferredY = rcDock.Top;
                                child.m_PreferredWidth = rcDock.Width;
                                child.m_PreferredHeight = rcDock.Height;
                                child.SetBoundsCore();
                                if (child.Visible)
                                    rcDock = control.ClientRectangle; //下一轮重新布局
                                continue;
                        }
                        //锚定左右
                        if (child.m_LeftToParent == null || child.m_RightToParent == null)
                        {
                            child.m_LeftToParent = child.m_PreferredX;
                            child.m_RightToParent = rcClient.Width - child.m_PreferredX - child.m_PreferredWidth;
                        }
                        else
                        {
                            switch (child.Anchor & (AnchorStyles.Left | AnchorStyles.Right))
                            {
                                case AnchorStyles.Left:
                                    child.m_PreferredX = child.m_LeftToParent.Value;
                                    break;
                                case AnchorStyles.Right:
                                    child.m_PreferredX = rcClient.Width - child.m_RightToParent.Value - child.m_PreferredWidth;
                                    break;
                                case AnchorStyles.Left | AnchorStyles.Right:
                                    child.m_PreferredX = child.m_LeftToParent.Value;
                                    child.m_PreferredWidth = rcClient.Width - child.m_LeftToParent.Value - child.m_RightToParent.Value;
                                    break;
                                default:
                                    child.m_PreferredX = child.m_LeftToParent.Value + (rcClient.Width - child.m_LeftToParent.Value - child.m_PreferredWidth - child.m_RightToParent.Value) / 2;
                                    break;
                            }
                        }
                        //锚定上下
                        if (child.m_TopToParent == null || child.m_BottomToParent == null)
                        {
                            child.m_TopToParent = child.m_PreferredY;
                            child.m_BottomToParent = rcClient.Height - child.m_PreferredY - child.m_PreferredHeight;
                        }
                        else
                        {
                            switch (child.Anchor & (AnchorStyles.Top | AnchorStyles.Bottom))
                            {
                                case AnchorStyles.Top:
                                    child.m_PreferredY = child.m_TopToParent.Value;
                                    break;
                                case AnchorStyles.Bottom:
                                    child.m_PreferredY = rcClient.Height - child.m_BottomToParent.Value - child.m_PreferredHeight;
                                    break;
                                case AnchorStyles.Top | AnchorStyles.Bottom:
                                    child.m_PreferredY = child.m_TopToParent.Value;
                                    child.m_PreferredHeight = rcClient.Height - child.m_TopToParent.Value - child.m_BottomToParent.Value;
                                    break;
                                default:
                                    child.m_PreferredY = child.m_TopToParent.Value + (rcClient.Height - child.m_TopToParent.Value - child.m_PreferredHeight - child.m_BottomToParent.Value) / 2;
                                    break;
                            }
                        }
                        child.SetBoundsCore();
                    }
                    finally
                    {
                        DoLayoutInternal(child);
                    }
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
