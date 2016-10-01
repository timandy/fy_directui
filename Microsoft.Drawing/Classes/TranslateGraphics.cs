using System.Drawing;

namespace Microsoft.Drawing
{
    /// <summary>
    /// 平移变换
    /// </summary>
    public class TranslateGraphics : DisposableMini
    {
        private int m_X;                    //水平平移
        private int m_Y;                    //垂直平移
        private Graphics m_Graphics;        //要修改剪切区的绘图对象

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="graphics">绘图对象</param>
        /// <param name="x">水平偏移像素</param>
        /// <param name="y">垂直偏移像素</param>
        public TranslateGraphics(Graphics graphics, int x, int y)
        {
            this.m_Graphics = graphics;
            this.m_X = x;
            this.m_Y = y;
            this.m_Graphics.TranslateTransform(this.m_X, this.m_Y);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="graphics">绘图对象</param>
        /// <param name="p">偏移量</param>
        public TranslateGraphics(Graphics graphics, Point p)
        {
            this.m_Graphics = graphics;
            this.m_X = p.X;
            this.m_Y = p.Y;
            this.m_Graphics.TranslateTransform(this.m_X, this.m_Y);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="graphics">绘图对象</param>
        /// <param name="s">偏移量</param>
        public TranslateGraphics(Graphics graphics, Size s)
        {
            this.m_Graphics = graphics;
            this.m_X = s.Width;
            this.m_Y = s.Height;
            this.m_Graphics.TranslateTransform(this.m_X, this.m_Y);
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="disposing">释放托管资源为true,否则为false</param>
        protected override void Dispose(bool disposing)
        {
            if (this.m_Graphics != null)
            {
                this.m_Graphics.TranslateTransform(-this.m_X, -this.m_Y);
                this.m_Graphics = null;
            }
            this.m_X = 0;
            this.m_Y = 0;
        }
    }
}
