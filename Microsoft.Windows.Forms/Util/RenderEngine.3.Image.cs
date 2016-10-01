using System.Drawing;
using System.Drawing.Imaging;

namespace Microsoft.Windows.Forms
{
    public static partial class RenderEngine
    {
        /// <summary>
        /// 获取黑白图像(返回了新的图像,使用完后需要手动释放)
        /// </summary>
        /// <param name="originImage">原图</param>
        /// <returns>黑白图</returns>
        public static Bitmap GetGrayImage(Image originImage)
        {
            int width = originImage.Width;
            int height = originImage.Height;
            Bitmap newBitmap = new Bitmap(width, height);

            //绘制新图像
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                //绘图参数检查
                if (m_DisabledImageAttr == null)
                {
                    //颜色变换矩阵,第一行到第五行分别表示RGBA虚拟,第一列到第五列分别表示RGBA虚拟.
                    ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                    {
                        new float[] {0.2125f, 0.2125f, 0.2125f, 000f, 000f},//新的R=旧的R*0.2125f+旧的G*0.2125f+旧的B*0.2125f
                        new float[] {0.2577f, 0.2577f, 0.2577f, 000f, 000f},
                        new float[] {0.0361f, 0.0361f, 0.0361f, 000f, 000f},
                        new float[] {000000f, 000000f, 000000f, 001f, 000f},
                        new float[] {0.3800f, 0.3800f, 0.3800f, 000f, 001f}
                    });

                    //创建绘图参数
                    m_DisabledImageAttr = new ImageAttributes();
                    m_DisabledImageAttr.SetColorMatrix(colorMatrix);
                }

                //绘图
                g.DrawImage(originImage, new Rectangle(0, 0, width, height), 0, 0, width, height, GraphicsUnit.Pixel, m_DisabledImageAttr);
            }

            //返回
            return newBitmap;
        }

        /// <summary>
        /// 获取透明图像(返回了新的图像,使用完后需要手动释放)
        /// </summary>
        /// <param name="originImage">原图</param>
        /// <param name="opacity">透明度[0-1]</param>
        /// <returns>透明图像</returns>
        public static Bitmap GetTransparentImage(Image originImage, float opacity)
        {
            int width = originImage.Width;
            int height = originImage.Height;
            Bitmap newBitmap = new Bitmap(width, height);

            //绘制新图像
            using (Graphics graphics = Graphics.FromImage(newBitmap))
            {
                //绘图参数
                using (ImageAttributes imgAttr = new ImageAttributes())
                {
                    ColorMatrix clrMatrix = new ColorMatrix();
                    clrMatrix.Matrix33 = opacity;
                    imgAttr.SetColorMatrix(clrMatrix);

                    //绘图
                    graphics.DrawImage(originImage, new Rectangle(0, 0, width, height), 0, 0, width, height, GraphicsUnit.Pixel, imgAttr);
                }
            }

            //返回
            return newBitmap;
        }

        /// <summary>
        /// 缩放图像(返回了新的图像,使用完后需要手动释放)
        /// </summary>
        /// <param name="originImage">要缩放的图像</param>
        /// <param name="size">要缩放为的大小</param>
        /// <returns>缩放后的图像</returns>
        public static Bitmap GetStretchImage(Image originImage, Size size)
        {
            if (originImage == null || size.Width <= 0 || size.Height <= 0)
                return null;

            Bitmap newBitmap = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                g.DrawImage(originImage, new Rectangle(0, 0, size.Width, size.Height));
            }
            return newBitmap;
        }
    }
}
