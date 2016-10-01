using System;

namespace Microsoft
{
    /// <summary>
    /// Math类扩展
    /// Copyright (c) JajaSoft
    /// </summary>
    public static class MathEx
    {
        #region 字段

        /// <summary>
        /// E
        /// </summary>
        public const float E = 2.718282f;
        /// <summary>
        /// Log10E
        /// </summary>
        public const float Log10E = 0.4342945f;
        /// <summary>
        /// Log2E
        /// </summary>
        public const float Log2E = 1.442695f;
        /// <summary>
        /// Pi
        /// </summary>
        public const float Pi = 3.141593f;
        /// <summary>
        /// Pi/2
        /// </summary>
        public const float PiOver2 = 1.570796f;
        /// <summary>
        /// Pi/4
        /// </summary>
        public const float PiOver4 = 0.7853982f;
        /// <summary>
        /// Pi*2
        /// </summary>
        public const float TwoPi = 6.283185f;
        /// <summary>
        /// Double类型的 180d / Math.PI
        /// </summary>
        public const double Double180OverPi = 180d / Math.PI;
        /// <summary>
        /// Double类型的 Math.PI / 180d
        /// </summary>
        public const double DoublePiOver180 = Math.PI / 180d;
        /// <summary>
        /// Single类型的 180d / Math.PI
        /// </summary>
        public const float Single180OverPi = (float)Double180OverPi;
        /// <summary>
        /// Single类型的 Math.PI / 180d
        /// </summary>
        public const float SinglePiOver180 = (float)DoublePiOver180;

        #endregion

        #region 方法

        /// <summary>
        /// 返回指定范围内的限定值
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns>限定值</returns>
        public static Byte Clamp(Byte value, Byte min, Byte max)
        {
            value = (value > max) ? max : value;
            value = (value < min) ? min : value;
            return value;
        }
        /// <summary>
        /// 返回指定范围内的限定值
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns>限定值</returns>
        public static Decimal Clamp(Decimal value, Decimal min, Decimal max)
        {
            value = (value > max) ? max : value;
            value = (value < min) ? min : value;
            return value;
        }
        /// <summary>
        /// 返回指定范围内的限定值
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns>限定值</returns>
        public static Double Clamp(Double value, Double min, Double max)
        {
            value = (value > max) ? max : value;
            value = (value < min) ? min : value;
            return value;
        }
        /// <summary>
        /// 返回指定范围内的限定值
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns>限定值</returns>
        public static Int16 Clamp(Int16 value, Int16 min, Int16 max)
        {
            value = (value > max) ? max : value;
            value = (value < min) ? min : value;
            return value;
        }
        /// <summary>
        /// 返回指定范围内的限定值
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns>限定值</returns>
        public static Int32 Clamp(Int32 value, Int32 min, Int32 max)
        {
            value = (value > max) ? max : value;
            value = (value < min) ? min : value;
            return value;
        }
        /// <summary>
        /// 返回指定范围内的限定值
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns>限定值</returns>
        public static Int64 Clamp(Int64 value, Int64 min, Int64 max)
        {
            value = (value > max) ? max : value;
            value = (value < min) ? min : value;
            return value;
        }
        /// <summary>
        /// 返回指定范围内的限定值
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns>限定值</returns>
        public static SByte Clamp(SByte value, SByte min, SByte max)
        {
            value = (value > max) ? max : value;
            value = (value < min) ? min : value;
            return value;
        }
        /// <summary>
        /// 返回指定范围内的限定值
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns>限定值</returns>
        public static Single Clamp(Single value, Single min, Single max)
        {
            value = (value > max) ? max : value;
            value = (value < min) ? min : value;
            return value;
        }
        /// <summary>
        /// 返回指定范围内的限定值
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns>限定值</returns>
        public static UInt16 Clamp(UInt16 value, UInt16 min, UInt16 max)
        {
            value = (value > max) ? max : value;
            value = (value < min) ? min : value;
            return value;
        }
        /// <summary>
        /// 返回指定范围内的限定值
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns>限定值</returns>
        public static UInt32 Clamp(UInt32 value, UInt32 min, UInt32 max)
        {
            value = (value > max) ? max : value;
            value = (value < min) ? min : value;
            return value;
        }
        /// <summary>
        /// 返回指定范围内的限定值
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns>限定值</returns>
        public static UInt64 Clamp(UInt64 value, UInt64 min, UInt64 max)
        {
            value = (value > max) ? max : value;
            value = (value < min) ? min : value;
            return value;
        }

        /// <summary>
        /// 弧度转换为角度
        /// </summary>
        /// <param name="radians">弧度</param>
        /// <returns>角度</returns>
        public static Double ToDegrees(Double radians)
        {
            return (radians * Double180OverPi);
        }
        /// <summary>
        /// 弧度转换为角度
        /// </summary>
        /// <param name="radians">弧度</param>
        /// <returns>角度</returns>
        public static Single ToDegrees(Single radians)
        {
            return (radians * Single180OverPi);
        }
        /// <summary>
        /// 角度转换为弧度
        /// </summary>
        /// <param name="degrees">角度</param>
        /// <returns>弧度</returns>
        public static Double ToRadians(Double degrees)
        {
            return (degrees * DoublePiOver180);
        }
        /// <summary>
        /// 角度转换为弧度
        /// </summary>
        /// <param name="degrees">角度</param>
        /// <returns>弧度</returns>
        public static Single ToRadians(Single degrees)
        {
            return (degrees * SinglePiOver180);
        }

        #endregion
    }
}
