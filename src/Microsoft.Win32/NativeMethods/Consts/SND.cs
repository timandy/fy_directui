namespace Microsoft.Win32
{
    //SND定义
    public static partial class NativeMethods
    {
        /// <summary>
        /// 同步播放声音，在播放完后PlaySound函数才返回。
        /// </summary>
        public const int SND_SYNC = 0;
        /// <summary>
        /// 用异步方式播放声音，PlaySound函数在开始播放后立即返回。
        /// </summary>
        public const int SND_ASYNC = 1;
        /// <summary>
        /// 不播放缺省声音，若无此标志，则PlaySound在没找到声音时会播放缺省声音。
        /// </summary>
        public const int SND_NODEFAULT = 2;
        /// <summary>
        /// 播放载入到内存中的声音，此时pszSound是指向声音数据的指针。
        /// </summary>
        public const int SND_MEMORY = 4;
        /// <summary>
        /// 重复播放声音，必须与SND_ASYNC标志一块使用。
        /// </summary>
        public const int SND_LOOP = 8;
        /// <summary>
        /// PlaySound不打断原来的声音播出并立即返回FALSE。
        /// </summary>
        public const int SND_NOSTOP = 0x10;
        /// <summary>
        /// 停止所有与调用任务有关的声音。若参数pszSound为NULL，就停止所有的声音，否则，停止pszSound指定的声音。
        /// </summary>
        public const int SND_PURGE = 0x40;
        /// <summary>
        /// pszSound参数指定了WAVE文件名。
        /// </summary>
        public const int SND_FILENAME = 0x20000;
    }
}
