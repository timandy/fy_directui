namespace Microsoft.Win32
{
    //MMIO定义
    public static partial class NativeMethods
    {
        /// <summary>
        /// MMIO_READ
        /// </summary>
        public const int MMIO_READ = 0;
        /// <summary>
        /// MMIO_FINDRIFF
        /// </summary>
        public const int MMIO_FINDRIFF = 0x20;
        /// <summary>
        /// MMIO_ALLOCBUF
        /// </summary>
        public const int MMIO_ALLOCBUF = 0x10000;
    }
}
