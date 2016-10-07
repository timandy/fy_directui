using System;
using System.Windows.Forms;

namespace Microsoft.Windows.Forms
{
    partial class UIControl
    {
        private static readonly object EVENT_PARENT_CHANGED = new object();
        /// <summary>
        /// 父控件改变事件
        /// </summary>
        public event EventHandler ParentChanged
        {
            add
            {
                base.Events.AddHandler(EVENT_PARENT_CHANGED, value);
            }
            remove
            {
                base.Events.RemoveHandler(EVENT_PARENT_CHANGED, value);
            }
        }
        /// <summary>
        /// 触发父控件改变事件
        /// </summary>
        /// <param name="e">数据</param>
        protected virtual void OnParentChanged(EventArgs e)
        {
            EventHandler handler = base.Events[EVENT_PARENT_CHANGED] as EventHandler;
            if (handler != null)
                handler(this, e);
        }

        private static readonly object EVENT_ENTER = new object();
        /// <summary>
        /// 鼠标进入事件
        /// </summary>
        public event EventHandler Enter
        {
            add
            {
                base.Events.AddHandler(EVENT_ENTER, value);
            }
            remove
            {
                base.Events.RemoveHandler(EVENT_ENTER, value);
            }
        }
        /// <summary>
        /// 触发鼠标进入事件
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnEnter(EventArgs e)
        {
            EventHandler handler = base.Events[EVENT_ENTER] as EventHandler;
            if (handler != null)
                handler(this, e);
        }

        private static readonly object EVENT_LEAVE = new object();
        /// <summary>
        /// 鼠标离开事件
        /// </summary>
        public event EventHandler Leave
        {
            add
            {
                base.Events.AddHandler(EVENT_LEAVE, value);
            }
            remove
            {
                base.Events.RemoveHandler(EVENT_LEAVE, value);
            }
        }
        /// <summary>
        /// 触发鼠标离开事件
        /// </summary>
        /// <param name="e">数据</param>
        protected virtual void OnLeave(EventArgs e)
        {
            EventHandler handler = base.Events[EVENT_LEAVE] as EventHandler;
            if (handler != null)
                handler(this, e);
        }

        private static readonly object EVENT_LOCATION_CHANGED = new object();
        /// <summary>
        /// 坐标改变事件
        /// </summary>
        public event EventHandler LocationChanged
        {
            add
            {
                base.Events.AddHandler(EVENT_LOCATION_CHANGED, value);
            }
            remove
            {
                base.Events.RemoveHandler(EVENT_LOCATION_CHANGED, value);
            }
        }
        /// <summary>
        /// 触发坐标改变事件
        /// </summary>
        /// <param name="e">数据</param>
        protected virtual void OnLocationChanged(EventArgs e)
        {
            EventHandler handler = base.Events[EVENT_LOCATION_CHANGED] as EventHandler;
            if (handler != null)
                handler(this, e);
        }

        private static readonly object EVENT_SIZE_CHANGED = new object();
        /// <summary>
        /// 大小改变事件
        /// </summary>
        public event EventHandler SizeChanged
        {
            add
            {
                base.Events.AddHandler(EVENT_SIZE_CHANGED, value);
            }
            remove
            {
                base.Events.RemoveHandler(EVENT_SIZE_CHANGED, value);
            }
        }
        /// <summary>
        /// 触发大小改变事件
        /// </summary>
        /// <param name="e">数据</param>
        protected virtual void OnSizeChanged(EventArgs e)
        {
            EventHandler handler = base.Events[EVENT_SIZE_CHANGED] as EventHandler;
            if (handler != null)
                handler(this, e);
        }

        private static readonly object EVENT_MOUSE_DOWN = new object();
        /// <summary>
        /// 鼠标按下事件
        /// </summary>
        public event MouseEventHandler MouseDown
        {
            add
            {
                base.Events.AddHandler(EVENT_MOUSE_DOWN, value);
            }
            remove
            {
                base.Events.RemoveHandler(EVENT_MOUSE_DOWN, value);
            }
        }
        /// <summary>
        /// 触发鼠标按下事件
        /// </summary>
        /// <param name="e">数据</param>
        protected virtual void OnMouseDown(MouseEventArgs e)
        {
            MouseEventHandler handler = base.Events[EVENT_MOUSE_DOWN] as MouseEventHandler;
            if (handler != null)
                handler(this, e);
        }

        private static readonly object EVENT_MOUSE_UP = new object();
        /// <summary>
        /// 鼠标弹起事件
        /// </summary>
        public event MouseEventHandler MouseUp
        {
            add
            {
                base.Events.AddHandler(EVENT_MOUSE_UP, value);
            }
            remove
            {
                base.Events.RemoveHandler(EVENT_MOUSE_UP, value);
            }
        }
        /// <summary>
        /// 触发鼠标弹起事件
        /// </summary>
        /// <param name="e">数据</param>
        protected virtual void OnMouseUp(MouseEventArgs e)
        {
            MouseEventHandler handler = base.Events[EVENT_MOUSE_UP] as MouseEventHandler;
            if (handler != null)
                handler(this, e);
        }

        private static readonly object EVENT_CLICK = new object();
        /// <summary>
        /// 单击事件
        /// </summary>
        public event EventHandler Click
        {
            add
            {
                base.Events.AddHandler(EVENT_CLICK, value);
            }
            remove
            {
                base.Events.RemoveHandler(EVENT_CLICK, value);
            }
        }
        /// <summary>
        /// 触发单击事件
        /// </summary>
        /// <param name="e">数据</param>
        protected virtual void OnClick(EventArgs e)
        {
            EventHandler handler = base.Events[EVENT_CLICK] as EventHandler;
            if (handler != null)
                handler(this, e);
        }

        private static readonly object EVENT_DOUBLE_CLICK = new object();
        /// <summary>
        /// 双击事件
        /// </summary>
        public event EventHandler DoubleClick
        {
            add
            {
                base.Events.AddHandler(EVENT_DOUBLE_CLICK, value);
            }
            remove
            {
                base.Events.RemoveHandler(EVENT_DOUBLE_CLICK, value);
            }
        }
        /// <summary>
        /// 触发双击事件
        /// </summary>
        /// <param name="e">数据</param>
        protected virtual void OnDoubleClick(EventArgs e)
        {
            EventHandler handler = base.Events[EVENT_DOUBLE_CLICK] as EventHandler;
            if (handler != null)
                handler(this, e);
        }

        private static readonly object EVENT_RENDER = new object();
        /// <summary>
        /// 渲染事件
        /// </summary>
        public event PaintEventHandler Render
        {
            add
            {
                base.Events.AddHandler(EVENT_RENDER, value);
            }
            remove
            {
                base.Events.RemoveHandler(EVENT_RENDER, value);
            }
        }
        /// <summary>
        /// 触发渲染事件
        /// </summary>
        /// <param name="e">数据</param>
        protected virtual void OnRender(PaintEventArgs e)
        {
            PaintEventHandler handler = base.Events[EVENT_RENDER] as PaintEventHandler;
            if (handler != null)
                handler(this, e);
        }
    }
}
