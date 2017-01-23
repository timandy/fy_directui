using System;
using System.Drawing;

namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// 随机颜色生成器
    /// </summary>
    public class RandomColor
    {
        /// <summary>
        /// 黄金分割比例
        /// </summary>
        private const float GOLDEN_RATIO = 0.618033988749895f;

        /// <summary>
        /// 随机颜色,Hue 起始值
        /// </summary>
        private float? m_Hue;

        /// <summary>
        /// 获取随机颜色
        /// </summary>
        /// <param name="saturation">饱和度[0-1]</param>
        /// <param name="brightness">亮度[0-1]</param>
        /// <returns>颜色</returns>
        public Color Next(float saturation, float brightness)
        {
            if (this.m_Hue == null)
            {
                Random random = new Random(unchecked((int)DateTime.Now.Ticks));
                this.m_Hue = (float)random.NextDouble();
            }
            float hue = this.m_Hue.Value;
            hue += GOLDEN_RATIO;
            hue %= 1;
            this.m_Hue = hue;
            return RenderEngine.FromHsv(hue, saturation, brightness);
        }

        /// <summary>
        /// 获取随机颜色
        /// </summary>
        /// <returns>颜色</returns>
        public Color Next()
        {
            return this.Next(0.5f, 0.99f);
        }
    }
}
