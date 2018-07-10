using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Microsoft.Drawing;

namespace Microsoft.Windows.Forms.Animate
{
    /// <summary>
    /// 图片颜色切换动画
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

        private List<AnimationFrame> m_Origins = new List<AnimationFrame>();            //原始图片集合
        private List<byte[]> m_Frames = new List<byte[]>();                             //截至帧集合
        private AnimationOperations m_SuspendedOps = new AnimationOperations();         //挂起的操作
        private RandomColor m_RandomColor = new RandomColor();                          //随机颜色生成器
        private Random m_Random = new Random(unchecked((int)DateTime.Now.Ticks));       //随机数生成器
        private byte[] m_From;                                                          //起始帧数据
        private int m_ToIndex = NONE_INDEX;                                             //截至帧索引
        private bool m_CurrentValid;                                                    //当前帧是否有效

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
            get
            {
                return this.m_Size;
            }
            set
            {
                if (value.Width <= 0)
                    value.Width = 1;
                if (value.Height <= 0)
                    value.Height = 1;
                this.Resize(value);
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
                {
                    if (!this.m_CurrentValid)
                    {
                        byte[] current = this.UpdateCurrent();
                        if (current != null)
                            CopyBitmap(current, this.m_Current);
                        this.m_CurrentValid = true;
                    }
                    return this.m_Current;
                }
                //计算信息
                byte[] from = this.m_From;
                byte[] to = this.m_ToIndex == NONE_INDEX ? null : this.m_Frames[this.m_ToIndex];
                //图像处理
                BlendBitmap(from, to, this.m_Current, this.Percentage);
                this.m_CurrentValid = true;
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
        /// 动画停止状态,当前帧无效时重新获取当前帧数据
        /// </summary>
        /// <returns>帧数据</returns>
        private byte[] UpdateCurrent()
        {
            int count = this.m_Origins.Count;
            switch (count)
            {
                case 0:
                    this.m_ToIndex = NONE_INDEX;
                    return null;
                case 1:
                    this.m_ToIndex = 0;
                    return this.m_Frames[0];
                default:
                    if (this.m_ToIndex < 0 || this.m_ToIndex >= count)
                        this.m_ToIndex = this.GetNextIndex();
                    return this.m_Frames[this.m_ToIndex];
            }
        }

        /// <summary>
        /// 获取下一个目标帧
        /// </summary>
        /// <returns>下一个目标帧</returns>
        private int GetNextIndex()
        {
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
            else
            {
                return (this.m_ToIndex + 1 >= count) ? 0 : (this.m_ToIndex + 1);
            }
        }

        /// <summary>
        /// 切换下一帧,开始动画
        /// </summary>
        public void Next()
        {
            //动画未结束
            if (!this.Stopped)
                return;
            //恢复挂起的操作,截止帧变起始帧
            this.Resume();
            //查找下一个截止帧
            switch (this.m_Origins.Count)
            {
                case 0:
                    this.m_ToIndex = NONE_INDEX;
                    break;
                case 1:
                    this.m_ToIndex = 0;
                    break;
                default:
                    this.m_ToIndex = this.GetNextIndex();
                    break;
            }
            //开始动画
            this.Start();
        }

        #endregion


        #region 集合操作

        /// <summary>
        /// 恢复大小改变操作,重新创建所有帧
        /// </summary>
        private void ResumeResize(Size size)
        {
            //赋值
            this.m_Size = size;
            //重新创建关键帧
            this.m_Frames.Clear();
            foreach (AnimationFrame frame in this.m_Origins)
                this.m_Frames.Add(GetFrameData(frame, size));
            //重新创建当前图像
            if (this.m_Current != null)
                this.m_Current.Dispose();
            this.m_Current = new Bitmap(this.m_Size.Width < 1 ? 1 : this.m_Size.Width, this.m_Size.Height < 1 ? 1 : this.m_Size.Height, PixelFormat.Format32bppArgb);
            this.m_CurrentValid = false;
        }

        /// <summary>
        /// 恢复添加关键帧操作
        /// </summary>
        /// <param name="frame">关键帧</param>
        private void ResumeAddFrame(AnimationFrame frame)
        {
            this.m_Origins.Add(frame);
            this.m_Frames.Add(GetFrameData(frame, this.m_Size));
        }

        /// <summary>
        /// 恢复清空关键帧操作
        /// </summary>
        private void ResumeClearFrame()
        {
            foreach (AnimationFrame frame in this.m_Origins)
                frame.Dispose();
            this.m_Origins.Clear();
            this.m_Frames.Clear();
        }

        /// <summary>
        /// 恢复挂起的操作,截止帧变起始帧
        /// </summary>
        private void Resume()
        {
            //截止帧变起始帧
            bool getLater = false;
            if (this.m_ToIndex == NONE_INDEX)
            {
                this.m_From = null;
            }
            else if (this.m_SuspendedOps.Resized)
            {
                if (this.m_SuspendedOps.Cleared)
                    this.m_From = GetFrameData(this.m_Origins[this.m_ToIndex], this.m_SuspendedOps.Size);
                else
                    getLater = true;
            }
            else
            {
                this.m_From = this.m_Frames[this.m_ToIndex];
            }

            //清理帧
            if (this.m_SuspendedOps.Cleared)
                this.ResumeClearFrame();

            //大小改变
            if (this.m_SuspendedOps.Resized)
                this.ResumeResize(this.m_SuspendedOps.Size);

            //大小改变后获取
            if (getLater)
                this.m_From = this.m_Frames[this.m_ToIndex];

            //添加帧
            foreach (AnimationFrame frame in this.m_SuspendedOps)
                this.ResumeAddFrame(frame);

            //清空操作
            this.m_SuspendedOps.Clear();
        }

        #endregion


        #region 用户操作

        /// <summary>
        /// 大小改变
        /// </summary>
        /// <param name="size">大小</param>
        private void Resize(Size size)
        {
            if (this.m_Current == null)
                this.ResumeResize(size);
            else
                this.m_SuspendedOps.Resize(size);
        }

        /// <summary>
        /// 添加一个图像帧
        /// </summary>
        /// <param name="image">图像</param>
        public void AddFrame(Image image)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            AnimationFrame frame = new AnimationFrame(image);
            if (this.m_SuspendedOps.Cleared)
                this.m_SuspendedOps.AddFrame(frame);
            else
                this.ResumeAddFrame(frame);
        }

        /// <summary>
        /// 添加一个颜色帧
        /// </summary>
        /// <param name="color">颜色</param>
        public void AddFrame(Color color)
        {
            AnimationFrame frame = new AnimationFrame(color);
            if (this.m_SuspendedOps.Cleared)
                this.m_SuspendedOps.AddFrame(frame);
            else
                this.ResumeAddFrame(frame);
        }

        /// <summary>
        /// 添加一个随机颜色帧
        /// </summary>
        public void AddFrame()
        {
            AnimationFrame frame = new AnimationFrame(this.m_RandomColor.Next());
            if (this.m_SuspendedOps.Cleared)
                this.m_SuspendedOps.AddFrame(frame);
            else
                this.ResumeAddFrame(frame);
        }

        /// <summary>
        /// 清空所有帧,并释放占用的资源
        /// </summary>
        public void ClearFrame()
        {
            this.m_SuspendedOps.ClearFrame();
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
        /// <param name="srcBmp">源图像</param>
        /// <param name="destData">目标帧数据</param>
        private static void CopyBitmap(Bitmap srcBmp, ref byte[] destData)
        {
            if (destData == null)
                destData = new byte[srcBmp.Width * srcBmp.Height * 4];
            using (LockedBitmapData bmpData = new LockedBitmapData(srcBmp, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb))
                Marshal.Copy(bmpData.Scan0, destData, 0, destData.Length);
        }

        /// <summary>
        /// 从帧数据快照图像
        /// </summary>
        /// <param name="srcData">源帧数据</param>
        /// <param name="destBmp">目标图像</param>
        private static void CopyBitmap(byte[] srcData, Bitmap destBmp)
        {
            using (LockedBitmapData bmpData = new LockedBitmapData(destBmp, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb))
                Marshal.Copy(srcData, 0, bmpData.Scan0, srcData.Length);
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

        /// <summary>
        /// 获取帧数据
        /// </summary>
        /// <param name="frame">原始帧</param>
        /// <param name="size">帧数据图像大小</param>
        /// <returns>帧数据</returns>
        private static byte[] GetFrameData(AnimationFrame frame, Size size)
        {
            byte[] frameData = null;
            switch (frame.FrameType)
            {
                case AnimationFrameType.Image:
                    using (Bitmap bmp = new Bitmap((Image)frame.Value, size.Width, size.Height))
                        CopyBitmap(bmp, ref frameData);
                    return frameData;
                case AnimationFrameType.Color:
                    CopyColor((Color)frame.Value, size, ref frameData);
                    return frameData;
                default:
                    throw new ArgumentException("frame type error.");
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
            if (this.m_SuspendedOps != null)
            {
                this.m_SuspendedOps.Dispose();
                this.m_SuspendedOps = null;
            }
            if (this.m_Current != null)
            {
                this.m_Current.Dispose();
                this.m_Current = null;
            }
            this.m_RandomColor = null;
            this.m_Random = null;
            this.m_From = null;
        }

        #endregion
    }
}
