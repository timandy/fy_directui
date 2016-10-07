using System;

namespace Microsoft
{
    /// <summary>
    /// 分配的资源释放事件接口
    /// </summary>
    public interface IDisposed
    {
        /// <summary>
        /// 资源释放事件
        /// </summary>
        event EventHandler Disposed;
    }
}
