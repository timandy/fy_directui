using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Microsoft.Windows.Forms
{
    partial class UIControl
    {
        /// <summary>
        /// 虚拟控件集合
        /// </summary>
        public class UIControlCollection : Collection<UIControl>, IDisposable
        {
            //集合所属控件
            private IUIControl m_Owner;

            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="owner">所属控件</param>
            internal UIControlCollection(IUIControl owner)
            {
                if (owner == null)
                    throw new ArgumentNullException("owner");
                this.m_Owner = owner;
            }

            /// <summary>
            /// 析构函数
            /// </summary>
            ~UIControlCollection()
            {
                this.Dispose(false);
            }

            /// <summary>
            /// 插入控件
            /// </summary>
            /// <param name="index">索引,值越小 Z 轴顺序越靠后</param>
            /// <param name="control">控件</param>
            protected override void InsertItem(int index, UIControl control)
            {
                if (control == null)
                    throw new ArgumentNullException("control");

                if (control.UIParentInternal == this.m_Owner)
                {
                    control.BringToFront();
                }
                else
                {
                    if (control.UIParentInternal != null)
                        control.UIParentInternal.UIControls.Remove(control);
                    this.m_Owner.SuspendLayout();
                    try
                    {
                        base.InsertItem(index, control);
                        control.UIParentInternal = this.m_Owner;
                    }
                    finally
                    {
                        this.m_Owner.ResumeLayout();
                    }
                }
            }

            /// <summary>
            /// 移除控件
            /// </summary>
            /// <param name="index">索引</param>
            protected override void RemoveItem(int index)
            {
                UIControl control = this[index];
                this.m_Owner.SuspendLayout();
                try
                {
                    base.RemoveItem(index);
                    control.UIParentInternal = null;
                }
                finally
                {
                    this.m_Owner.ResumeLayout();
                }
            }

            /// <summary>
            /// 不支持的操作
            /// </summary>
            /// <param name="index">索引</param>
            /// <param name="control">控件</param>
            protected override void SetItem(int index, UIControl control)
            {
                throw new NotSupportedException("不支持的操作");
            }

            /// <summary>
            /// 清空所有控件
            /// </summary>
            protected override void ClearItems()
            {
                this.m_Owner.SuspendLayout();
                try
                {
                    foreach (UIControl control in this)
                        control.UIParentInternal = null;
                    base.ClearItems();
                }
                finally
                {
                    this.m_Owner.ResumeLayout();
                }
            }

            /// <summary>
            /// 批量添加控件
            /// </summary>
            /// <param name="controls">控件集合</param>
            public void AddRange(IEnumerable<UIControl> controls)
            {
                this.m_Owner.SuspendLayout();
                try
                {
                    foreach (UIControl control in controls)
                        this.Add(control);
                }
                finally
                {
                    this.m_Owner.ResumeLayout();
                }
            }

            /// <summary>
            /// 释放资源
            /// </summary>
            /// <param name="disposing">释放托管资源为 true,否则为 false</param>
            private void Dispose(bool disposing)
            {
                if (this.m_Owner != null)
                {
                    if (this.Count > 0)
                    {
                        this.m_Owner.SuspendLayout();
                        try
                        {
                            UIControl[] array = new UIControl[this.Count];
                            this.CopyTo(array, 0);
                            foreach (UIControl control in array)
                                control.Dispose();
                            base.ClearItems();
                        }
                        finally
                        {
                            this.m_Owner.ResumeLayout();
                        }
                    }
                    this.m_Owner = null;
                }
            }

            /// <summary>
            /// 释放资源
            /// </summary>
            public void Dispose()
            {
                this.Dispose(true);
                GC.SuppressFinalize(this);
            }
        }
    }
}
