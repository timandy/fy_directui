using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Microsoft.Drawing
{
    /// <summary>
    /// 双缓冲区
    /// </summary>
    public class DoubleBufferedGraphics : Disposable
    {
        private bool m_IsCreating;                      //是否正在创建缓冲区
        private IWin32Window m_Owner;                   //拥有该缓冲区的窗口
        private BufferedGraphics m_BufferedGraphics;    //缓冲区


        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="owner">拥有者</param>
        public DoubleBufferedGraphics(IWin32Window owner)
        {
            this.m_Owner = owner;
        }

        #endregion


        #region 字段属性

        private CompositingMode m_CompositingMode = CompositingMode.SourceOver;
        /// <summary>
        /// 获取一个值，该值指定如何将合成图像绘制到此 System.Drawing.Graphics。
        /// </summary>
        public CompositingMode CompositingMode
        {
            get
            {
                return this.m_CompositingMode;
            }
            set
            {
                if (value != this.m_CompositingMode)
                {
                    this.m_CompositingMode = value;
                    if (this.m_BufferedGraphics != null)
                        this.m_BufferedGraphics.Graphics.CompositingMode = value;
                }
            }
        }

        private CompositingQuality m_CompositingQuality = CompositingQuality.Default;
        /// <summary>
        /// 获取或设置绘制到此 System.Drawing.Graphics 的合成图像的呈现质量。
        /// </summary>
        public CompositingQuality CompositingQuality
        {
            get
            {
                return this.m_CompositingQuality;
            }
            set
            {
                if (value != this.m_CompositingQuality)
                {
                    this.m_CompositingQuality = value;
                    if (this.m_BufferedGraphics != null)
                        this.m_BufferedGraphics.Graphics.CompositingQuality = value;
                }
            }
        }

        private InterpolationMode m_InterpolationMode = InterpolationMode.Bilinear;
        /// <summary>
        /// 获取或设置与此 System.Drawing.Graphics 关联的插补模式。
        /// </summary>
        public InterpolationMode InterpolationMode
        {
            get
            {
                return this.m_InterpolationMode;
            }
            set
            {
                if (value != this.m_InterpolationMode)
                {
                    this.m_InterpolationMode = value;
                    if (this.m_BufferedGraphics != null)
                        this.m_BufferedGraphics.Graphics.InterpolationMode = value;
                }
            }
        }

        private PixelOffsetMode m_PixelOffsetMode = PixelOffsetMode.Default;
        /// <summary>
        /// 获取或设置一个值，该值指定在呈现此 System.Drawing.Graphics 的过程中像素如何偏移。
        /// </summary>
        public PixelOffsetMode PixelOffsetMode
        {
            get
            {
                return this.m_PixelOffsetMode;
            }
            set
            {
                if (value != this.m_PixelOffsetMode)
                {
                    this.m_PixelOffsetMode = value;
                    if (this.m_BufferedGraphics != null)
                        this.m_BufferedGraphics.Graphics.PixelOffsetMode = value;
                }
            }
        }

        private SmoothingMode m_SmoothingMode = SmoothingMode.None;
        /// <summary>
        /// 获取或设置此 System.Drawing.Graphics 的呈现质量。
        /// </summary>
        public SmoothingMode SmoothingMode
        {
            get
            {
                return this.m_SmoothingMode;
            }
            set
            {
                if (value != this.m_SmoothingMode)
                {
                    this.m_SmoothingMode = value;
                    if (this.m_BufferedGraphics != null)
                        this.m_BufferedGraphics.Graphics.SmoothingMode = value;
                }
            }
        }

        private int m_TextContrast = 4;
        /// <summary>
        /// 获取或设置呈现文本的灰度校正值。
        /// </summary>
        public int TextContrast
        {
            get
            {
                return this.m_TextContrast;
            }
            set
            {
                if (value != this.m_TextContrast)
                {
                    this.m_TextContrast = value;
                    if (this.m_BufferedGraphics != null)
                        this.m_BufferedGraphics.Graphics.TextContrast = value;
                }
            }
        }

        private TextRenderingHint m_TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        /// <summary>
        /// 获取或设置与此 System.Drawing.Graphics 关联的文本的呈现模式。
        /// </summary>
        public TextRenderingHint TextRenderingHint
        {
            get
            {
                return this.m_TextRenderingHint;
            }
            set
            {
                if (value != this.m_TextRenderingHint)
                {
                    this.m_TextRenderingHint = value;
                    if (this.m_BufferedGraphics != null)
                        this.m_BufferedGraphics.Graphics.TextRenderingHint = value;
                }
            }
        }

        /// <summary>
        /// 缓冲区绘图对象
        /// </summary>
        public Graphics Graphics
        {
            get
            {
                return this.m_BufferedGraphics.Graphics;
            }
        }

        private Size m_Size = Size.Empty;
        /// <summary>
        /// 获取缓冲区的虚拟画布大小。
        /// </summary>
        public Size Size
        {
            get
            {
                return this.m_Size;
            }
        }

        #endregion


        #region 私有方法

        /// <summary>
        /// 重新创建缓冲区
        /// </summary>
        /// <returns>创建成功返回true,正在创建或失败返回false</returns>
        private bool RecreateBuffer()
        {
            //设置状态
            if (this.m_IsCreating)
                return false;
            this.m_IsCreating = true;

            //检查资源
            if (this.IsDisposed)
                throw new ObjectDisposedException(this.GetType().FullName);

            //区域大小检查
            Rectangle wndRect = new Rectangle(Point.Empty, Util.GetSize(this.m_Owner.Handle));
            if (wndRect.Width <= 0 || wndRect.Height <= 0)
            {
                this.m_IsCreating = false;
                return false;
            }

            //缓冲上下文
            BufferedGraphicsContext bufferedGraphicsContext = BufferedGraphicsManager.Current;
            bufferedGraphicsContext.MaximumBuffer = wndRect.Size;

            //创建
            if (this.m_BufferedGraphics != null)
                this.m_BufferedGraphics.Dispose();
            this.m_BufferedGraphics = bufferedGraphicsContext.Allocate(Graphics.FromHwndInternal(this.m_Owner.Handle), wndRect);

            //初始化绘图对象
            this.InitGraphics(this.m_BufferedGraphics.Graphics);
            this.m_Size = wndRect.Size;

            //不创建
            this.m_IsCreating = false;
            return true;
        }

        /// <summary>
        /// 初始化绘图画面
        /// </summary>
        /// <param name="g">绘图对象</param>
        private void InitGraphics(Graphics g)
        {
            g.CompositingMode = this.m_CompositingMode;
            g.CompositingQuality = this.m_CompositingQuality;
            g.InterpolationMode = this.m_InterpolationMode;
            g.PixelOffsetMode = this.m_PixelOffsetMode;
            g.SmoothingMode = this.m_SmoothingMode;
            g.TextContrast = this.m_TextContrast;
            g.TextRenderingHint = this.m_TextRenderingHint;
        }

        #endregion


        #region 公共方法

        /// <summary>
        /// 开始渲染
        /// </summary>
        /// <returns>成功返回true,否则返回false</returns>
        public bool Prepare()
        {
            return (!this.IsDisposed) && (this.m_BufferedGraphics != null && this.m_Size == Util.GetSize(this.m_Owner.Handle) || this.RecreateBuffer());
        }

        /// <summary>
        /// 在目标设备上混合渲染
        /// </summary>
        /// <param name="g">目标设备渲染数据</param>
        /// <returns>成功返回true,否则返回false</returns>
        public void BlendRender(Graphics g)
        {
            BufferedGraphicsEx.BlendRender(this.m_BufferedGraphics, g);
        }

        /// <summary>
        /// 在目标设备上混合渲染
        /// </summary>
        /// <param name="e">目标设备渲染数据</param>
        /// <returns>成功返回true,否则返回false</returns>
        public void BlendRender(PaintEventArgs e)
        {
            BufferedGraphicsEx.BlendRender(this.m_BufferedGraphics, e.Graphics, e.ClipRectangle);
        }

        /// <summary>
        /// 在目标设备上复制渲染
        /// </summary>
        /// <param name="g">目标设备渲染数据</param>
        /// <returns>成功返回true,否则返回false</returns>
        public void Render(Graphics g)
        {
            this.m_BufferedGraphics.Render(g);
        }

        /// <summary>
        /// 在目标设备上复制渲染
        /// </summary>
        /// <param name="e">目标设备渲染数据</param>
        /// <returns>成功返回true,否则返回false</returns>
        public void Render(PaintEventArgs e)
        {
            BufferedGraphicsEx.Render(this.m_BufferedGraphics, e.Graphics, e.ClipRectangle);
        }

        #endregion


        #region 释放资源

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="disposing">释放托管资源为true,否则为false</param>
        protected override void Dispose(bool disposing)
        {
            this.m_Owner = null;//取消引用
            if (this.m_BufferedGraphics != null)
            {
                this.m_BufferedGraphics.Dispose();
                this.m_BufferedGraphics = null;
            }
        }

        #endregion
    }
}
