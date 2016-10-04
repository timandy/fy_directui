using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Microsoft.Drawing;

namespace Microsoft.Windows.Forms.Animate
{
    /// <summary>
    /// 图片动画
    /// </summary>
    public sealed class UIImageAnimation : Animation<Bitmap>
    {
        /// <summary>
        /// 默认动画是否随机
        /// </summary>
        public const bool DEFAULT_ANIMATION_RANDOM_PLAY = false;
        /// <summary>
        /// 默认动画执行时间,毫秒
        /// </summary>
        public const int DEFAULT_ANIMATION_SPAN = 3000;
        /// <summary>
        /// 空索引
        /// </summary>
        public const int NONE_INDEX = -1;

        private List<AnimationFrame> m_Origins = new List<AnimationFrame>();    //原始图片集合
        private List<byte[]> m_Frames = new List<byte[]>();                     //截至帧集合
        private Random m_Random = new Random();                                 //随机数生成器
        private byte[] m_From;                                                  //起始帧数据
        private int m_ToIndex = NONE_INDEX;                                     //截至帧索引


        #region 属性

        private bool m_RandomPlay = DEFAULT_ANIMATION_RANDOM_PLAY;
        /// <summary>
        /// 获取或设置是否随机播放
        /// </summary>
        public bool RandomPlay
        {
            get
            {
                return this.m_RandomPlay;
            }
            set
            {
                this.m_RandomPlay = value;
            }
        }

        private Size m_Size = new Size(1, 1);
        /// <summary>
        /// 获取或设置动画大小
        /// </summary>
        public Size Size
        {
            get { return this.m_Size; }
            set
            {
                if (value.Width == 0)
                    value.Width = 1;
                if (value.Height == 0)
                    value.Height = 1;
                if (value != this.m_Size)
                {
                    //暂存
                    Size oldSize = this.m_Size;
                    //赋值
                    this.m_Size = value;
                    if (this.m_From != null)//以前有数据
                        ResizeBitmap(ref this.m_From, oldSize, this.m_Size);
                    this.RecreateFrames();//to 列表
                    if (this.m_Current != null)//current
                        this.m_Current.Dispose();
                    this.m_Current = new Bitmap(this.m_Size.Width, this.m_Size.Height, PixelFormat.Format32bppArgb);
                    this.Start();//失效,下次调用 current 将获取新的
                }
            }
        }

        private Bitmap m_Current;
        /// <summary>
        /// 获取当前帧图像
        /// </summary>
        public override unsafe Bitmap Current
        {
            get
            {
                //已停止
                if (this.Stopped)
                    return this.m_Current;
                //计算信息
                byte[] from;
                byte[] to;
                bool stopped;
                this.GetCurrentInfo(out from, out to, out stopped);
                //图像处理
                BlendBitmap(from, to, this.m_Current, stopped ? STOPPED : this.Percentage);
                if (stopped)
                    this.Stop();
                return this.m_Current;
            }
        }

        #endregion 属性


        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public UIImageAnimation()
        {
            base.Span = DEFAULT_ANIMATION_SPAN;
        }

        #endregion


        #region 动画操作

        /// <summary>
        /// 获取当前帧信息
        /// </summary>
        /// <param name="from">起始数据</param>
        /// <param name="to">停止数据</param>
        /// <param name="stopped">是否停止</param>
        private void GetCurrentInfo(out byte[] from, out byte[] to, out bool stopped)
        {
            int count = this.m_Origins.Count;
            switch (count)
            {
                case 0:
                    from = this.m_From;
                    to = null;
                    stopped = from == null;
                    break;
                case 1:
                    from = this.m_From;
                    to = this.m_Frames[0];
                    stopped = from == null;
                    break;
                default:
                    if (this.m_From == null)
                    {
                        this.m_ToIndex = this.GetNextIndex();
                        CopyBitmap(this.m_Frames[this.m_ToIndex], ref this.m_From);
                        this.m_ToIndex = this.GetNextIndex();
                    }
                    from = this.m_From;
                    to = (this.m_ToIndex < 0 || this.m_ToIndex > count - 1) ? null : this.m_Frames[this.m_ToIndex];
                    stopped = false;
                    break;
            }
        }

        /// <summary>
        /// 获取下一个目标帧
        /// </summary>
        /// <returns>下一个目标帧</returns>
        private int GetNextIndex()
        {
            //随机
            int count = this.m_Origins.Count;
            if (this.m_RandomPlay)
            {
                int current = this.m_ToIndex;
                int temp;
                do
                {
                    temp = this.m_Random.Next(count);
                } while (temp == current);
                return temp;
            }
            //非随机
            return (this.m_ToIndex >= (count - 1)) ? 0 : this.m_ToIndex + 1;
        }

        /// <summary>
        /// 切换下一帧,开始动画
        /// </summary>
        public void Next()
        {
            switch (this.m_Origins.Count)
            {
                case 0:
                    this.m_ToIndex = NONE_INDEX;
                    if (this.m_From != null && this.m_Current != null)
                        CopyBitmap(this.m_Current, ref this.m_From);//创建快照
                    break;
                case 1:
                    this.m_ToIndex = 0;
                    if (this.m_From != null && this.m_Current != null)
                        CopyBitmap(this.m_Current, ref this.m_From);//创建快照
                    break;
                default:
                    this.m_ToIndex = this.GetNextIndex();
                    if (this.m_Current != null)
                        CopyBitmap(this.m_Current, ref this.m_From);//创建快照
                    break;
            }
            this.Start();
        }

        #endregion


        #region 集合操作

        /// <summary>
        /// 添加图片到帧集合
        /// </summary>
        /// <param name="frame">图片</param>
        private void AddCore(AnimationFrame frame)
        {
            byte[] frameData = null;
            switch (frame.FrameType)
            {
                case AnimationFrameType.Image:
                    using (Bitmap bmp = new Bitmap((Image)frame.Value, this.m_Size.Width, this.m_Size.Height))
                    {
                        CopyBitmap(bmp, ref frameData);
                        this.m_Frames.Add(frameData);
                    }
                    break;
                case AnimationFrameType.Color:
                    CopyColor((Color)frame.Value, this.m_Size, ref frameData);
                    this.m_Frames.Add(frameData);
                    break;
                default:
                    throw new ArgumentException("frame type error.");
            }
        }

        /// <summary>
        /// 重新创建所有帧,一般在大小改变后调用
        /// </summary>
        private void RecreateFrames()
        {
            this.m_Frames.Clear();
            foreach (AnimationFrame frame in this.m_Origins)
                this.AddCore(frame);
        }

        /// <summary>
        /// 添加一个图像帧
        /// </summary>
        /// <param name="image">图像</param>
        public void AddFrame(Image image)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            //添加到原始图
            AnimationFrame frame = new AnimationFrame(image);
            this.m_Origins.Add(frame);
            //添加到缓存
            this.AddCore(frame);
        }

        /// <summary>
        /// 添加一个颜色帧
        /// </summary>
        /// <param name="color">颜色</param>
        public void AddFrame(Color color)
        {
            //添加到原始图
            AnimationFrame frame = new AnimationFrame(color);
            this.m_Origins.Add(frame);
            //添加到缓存
            this.AddCore(frame);
        }

        /// <summary>
        /// 添加一个随机颜色帧
        /// </summary>
        public void AddFrame()
        {
            //添加到原始图
            AnimationFrame frame = new AnimationFrame();
            this.m_Origins.Add(frame);
            //添加到缓存
            this.AddCore(frame);
        }

        /// <summary>
        /// 清空所有帧,并释放占用的资源
        /// </summary>
        public void ClearFrame()
        {
            //释放资源
            foreach (AnimationFrame frame in this.m_Origins)
                frame.Dispose();
            //清空原始
            this.m_Origins.Clear();
            //清空缓存
            this.m_Frames.Clear();
            //启动动画
            this.Next();
        }

        #endregion


        #region 图像处理

        /// <summary>
        /// 从颜色创建帧数据
        /// </summary>
        /// <param name="color">颜色</param>
        /// <param name="destSize">帧大小</param>
        /// <param name="destData">帧数据</param>
        private unsafe static void CopyColor(Color color, Size destSize, ref byte[] destData)
        {
            if (destData == null)
                destData = new byte[destSize.Width * destSize.Height * 4];
            byte b = color.B;
            byte g = color.G;
            byte r = color.R;
            byte a = color.A;
            for (int i = 0, length = destData.Length; i < length; i += 4)
            {
                destData[i] = b;
                destData[i + 1] = g;
                destData[i + 2] = r;
                destData[i + 3] = a;
            }
        }

        /// <summary>
        /// 从图像创建帧数据
        /// </summary>
        /// <param name="srcBmp">图像</param>
        /// <param name="destData">帧数据</param>
        private static void CopyBitmap(Bitmap srcBmp, ref byte[] destData)
        {
            if (destData == null)
                destData = new byte[srcBmp.Width * srcBmp.Height * 4];
            using (LockedBitmapData bmpData = new LockedBitmapData(srcBmp, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb))
                Marshal.Copy(bmpData.Scan0, destData, 0, destData.Length);
        }

        /// <summary>
        /// 从图像快照帧数据
        /// </summary>
        /// <param name="srcData">源图像数据</param>
        /// <param name="destData">目标图像数据</param>
        private static void CopyBitmap(byte[] srcData, ref byte[] destData)
        {
            if (destData == null)
                destData = new byte[srcData.Length];
            Array.Copy(srcData, destData, srcData.Length);
        }

        /// <summary>
        /// 图像改变大小
        /// </summary>
        /// <param name="srcData">原图像数据</param>
        /// <param name="srcSize">原大小</param>
        /// <param name="destSize">目标大小</param>
        private static void ResizeBitmap(ref byte[] srcData, Size srcSize, Size destSize)
        {
            byte[] destData = new byte[destSize.Width * destSize.Height * 4];
            int srcWidth = srcSize.Width * 4;
            int destWidth = destSize.Width * 4;
            int width = Math.Min(srcWidth, destWidth);
            int height = Math.Min(srcSize.Height, destSize.Height);
            for (int i = 0; i < height; i++)
                Array.Copy(srcData, srcWidth * i, destData, destWidth * i, width);
            srcData = destData;
        }

        /// <summary>
        /// 获取两个帧之间指定百分比的动画帧
        /// </summary>
        /// <param name="from">起始帧数据</param>
        /// <param name="to">截止帧数据</param>
        /// <param name="destBmp">目标图像</param>
        /// <param name="percentage">百分比</param>
        private unsafe static void BlendBitmap(byte[] from, byte[] to, Bitmap destBmp, double percentage)
        {
            using (LockedBitmapData bmpData = new LockedBitmapData(destBmp, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb))
            {
                if (from == null)
                {
                    if (to == null)
                    {
                        byte* ptr = (byte*)bmpData.Scan0;
                        for (int i = 0, length = bmpData.Stride * bmpData.Height; i < length; i++)
                            *(ptr++) = 0;
                    }
                    else if (percentage == STOPPED)
                    {
                        Marshal.Copy(to, 0, bmpData.Scan0, to.Length);
                    }
                    else
                    {
                        byte* ptr = (byte*)bmpData.Scan0;
                        for (int i = 0, length = to.Length; i < length; i++)
                            *(ptr++) = (byte)(to[i] * percentage);
                    }
                }
                else
                {
                    if (to == null)
                    {
                        percentage = STOPPED - percentage;
                        byte* ptr = (byte*)bmpData.Scan0;
                        for (int i = 0, length = from.Length; i < length; i++)
                            *(ptr++) = (byte)(from[i] * percentage);
                    }
                    else if (percentage == STOPPED)
                    {
                        Marshal.Copy(to, 0, bmpData.Scan0, from.Length);
                    }
                    else
                    {
                        byte tmp;
                        byte* ptr = (byte*)bmpData.Scan0;
                        for (int i = 0, length = from.Length; i < length; i++)
                            *(ptr++) = (byte)((tmp = from[i]) + (to[i] - tmp) * percentage);
                    }
                }
            }
        }

        #endregion


        #region 释放资源

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="disposing">释放托管资源为true,否则为false</param>
        protected override void Dispose(bool disposing)
        {
            if (this.m_Origins != null)
            {
                foreach (AnimationFrame frame in this.m_Origins)
                    frame.Dispose();
                this.m_Origins.Clear();
                this.m_Origins = null;
            }
            if (this.m_Frames != null)
            {
                this.m_Frames.Clear();
                this.m_Frames = null;
            }
            if (this.m_Current != null)
            {
                this.m_Current.Dispose();
                this.m_Current = null;
            }
            this.m_Random = null;
            this.m_From = null;
        }

        #endregion
    }
}
