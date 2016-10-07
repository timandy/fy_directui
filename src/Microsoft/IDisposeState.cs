namespace Microsoft
{
    /// <summary>
    /// 定义判断分配的资源是否已经释放的属性接口.
    /// Copyright (c) JajaSoft
    /// </summary>
    public interface IDisposeState
    {
        /// <summary>
        /// 分配的资源是否正在释放
        /// </summary>
        bool Disposing
        {
            get;
        }

        /// <summary>
        /// 分配的资源是否已经释放
        /// </summary>
        bool IsDisposed
        {
            get;
        }

        /// <summary>
        /// 检查是否已释放资源,如果已释放资源则抛出异常
        /// </summary>
        void CheckDisposed();
    }
}
