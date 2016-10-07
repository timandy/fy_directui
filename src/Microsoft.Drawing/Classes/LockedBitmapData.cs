using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Microsoft.Drawing
{
    /// <summary>
    /// 位图的属性,已锁定
    /// </summary>
    public sealed class LockedBitmapData : DisposableMini
    {
        private Bitmap m_Bitmap;//位图
        private BitmapData m_BitmapData;//属性

        /// <summary>
        /// 获取或设置返回此 System.Drawing.Imaging.BitmapData 对象的 System.Drawing.Bitmap 对象中像素信息的格式。
        /// </summary>
        public PixelFormat PixelFormat
        {
            get
            {
                return this.m_BitmapData.PixelFormat;
            }
            set
            {
                this.m_BitmapData.PixelFormat = value;
            }
        }

        /// <summary>
        /// 获取或设置 System.Drawing.Bitmap 对象的像素宽度。这也可以看作是一个扫描行中的像素数。
        /// </summary>
        public int Width
        {
            get
            {
                return this.m_BitmapData.Width;
            }
            set
            {
                this.m_BitmapData.Width = value;
            }
        }

        /// <summary>
        /// 获取或设置 System.Drawing.Bitmap 对象的像素高度。有时也称作扫描行数。
        /// </summary>
        public int Height
        {
            get
            {
                return this.m_BitmapData.Height;
            }
            set
            {
                this.m_BitmapData.Height = value;
            }
        }

        /// <summary>
        /// 获取或设置 System.Drawing.Bitmap 对象的跨距宽度（也称为扫描宽度）。
        /// </summary>
        public int Stride
        {
            get
            {
                return this.m_BitmapData.Stride;
            }
            set
            {
                this.m_BitmapData.Stride = value;
            }
        }

        /// <summary>
        /// 获取或设置位图中第一个像素数据的地址。它也可以看成是位图中的第一个扫描行。
        /// </summary>
        public IntPtr Scan0
        {
            get
            {
                return this.m_BitmapData.Scan0;
            }
            set
            {
                this.m_BitmapData.Scan0 = value;
            }
        }

        /// <summary>
        /// 保留。不要使用。
        /// </summary>
        public int Reserved
        {
            get
            {
                return this.m_BitmapData.Reserved;
            }
            set
            {
                this.m_BitmapData.Reserved = value;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="bitmap">位图</param>
        /// <param name="flags">读写模式</param>
        /// <param name="format">像素格式</param>
        public LockedBitmapData(Bitmap bitmap, ImageLockMode flags, PixelFormat format)
        {
            this.m_Bitmap = bitmap;
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            this.m_BitmapData = this.m_Bitmap.LockBits(rect, flags, format);
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="disposing">释放托管资源为true,否则为false</param>
        protected override void Dispose(bool disposing)
        {
            if (this.m_Bitmap != null)
            {
                this.m_Bitmap.UnlockBits(this.m_BitmapData);
                this.m_Bitmap = null;
                this.m_BitmapData = null;
            }
        }
    }
}
