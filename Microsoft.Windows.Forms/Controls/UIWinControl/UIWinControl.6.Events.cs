using System.Windows.Forms;

namespace Microsoft.Windows.Forms
{
    partial class UIWinControl
    {
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
