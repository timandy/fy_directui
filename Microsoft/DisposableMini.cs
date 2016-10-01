using System;

namespace Microsoft
{
    /// <summary>
    /// Dispose 模式
    /// </summary>
    public abstract class DisposableMini : IDisposable
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public DisposableMini()
        {
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        ~DisposableMini()
        {
            this.Dispose(false);
        }

        #endregion


        #region 保护方法

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="disposing">释放托管资源为true,否则为false</param>
        protected abstract void Dispose(bool disposing);

        #endregion


        #region 公共方法

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
