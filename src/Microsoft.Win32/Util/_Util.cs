using System;

namespace Microsoft.Win32
{
    /// <summary>
    /// Util
    /// </summary>
    public static partial class Util
    {
        /// <summary>
        /// 获取有符号低16位整数
        /// </summary>
        /// <param name="lParam">句柄</param>
        /// <returns>有符号低16位整数</returns>
        public static int GET_X_LPARAM(IntPtr lParam)
        {
            return LOWORD(lParam);
        }
        /// <summary>
        /// 获取有符号高十六位整数
        /// </summary>
        /// <param name="lParam">句柄</param>
        /// <returns>有符号高十六位整数</returns>
        public static int GET_Y_LPARAM(IntPtr lParam)
        {
            return HIWORD(lParam);
        }


        /// <summary>
        /// 获取无符号高8位整数
        /// </summary>
        /// <param name="wValue">无符号16位整数</param>
        /// <returns>无符号高8位整数</returns>
        public static byte HIBYTE(ushort wValue)
        {
            return (byte)((wValue >> 0x8) & 0xff);
        }
        /// <summary>
        /// 获取无符号低8位整数
        /// </summary>
        /// <param name="wValue">无符号16位整数</param>
        /// <returns>无符号低8位整数</returns>
        public static byte LOBYTE(ushort wValue)
        {
            return (byte)(wValue & 0xff);
        }
        /// <summary>
        /// 获取无符号高16位整数
        /// </summary>
        /// <param name="dwValue">无符号32位整数</param>
        /// <returns>无符号高16位整数</returns>
        public static ushort HIWORD(uint dwValue)
        {
            return (ushort)((dwValue >> 0x10) & 0xffff);
        }
        /// <summary>
        /// 获取无符号低16位整数
        /// </summary>
        /// <param name="dwValue">无符号32位整数</param>
        /// <returns>无符号低16位整数</returns>
        public static ushort LOWORD(uint dwValue)
        {
            return (ushort)(dwValue & 0xffff);
        }


        /// <summary>
        /// 将两个无符号8位整数合并为一个无符号16位整数
        /// </summary>
        /// <param name="bLow">无符号低8位整数</param>
        /// <param name="bHigh">无符号高8位整数</param>
        /// <returns>无符号16位整数</returns>
        public static ushort MAKEWORD(byte bLow, byte bHigh)
        {
            return (ushort)((((ushort)bHigh) << 0x8) | ((ushort)(bLow & 0xff)));
        }
        /// <summary>
        /// 将两个无符号16位整数合并为一个无符号32位整数
        /// </summary>
        /// <param name="wLow">无符号低16位整数</param>
        /// <param name="wHigh">无符号高16位整数</param>
        /// <returns>无符号32位整数</returns>
        public static uint MAKELONG(ushort wLow, ushort wHigh)
        {
            return ((((uint)wHigh) << 0x10) | ((uint)(wLow & 0xffff)));
        }
        /// <summary>
        /// 将两个无符号16位整数合并为一个有符号32位整数
        /// </summary>
        /// <param name="wLow">无符号低16位整数</param>
        /// <param name="wHigh">无符号高16位整数</param>
        /// <returns>有符号32位整数</returns>
        public static int MAKELPARAM(ushort wLow, ushort wHigh)
        {
            return (int)MAKELONG(wLow, wHigh);
        }
        /// <summary>
        /// 将两个无符号16位整数合并为一个有符号32位整数
        /// </summary>
        /// <param name="wLow">无符号低16位整数</param>
        /// <param name="wHigh">无符号高16位整数</param>
        /// <returns>有符号32位整数</returns>
        public static int MAKEWPARAM(ushort wLow, ushort wHigh)
        {
            return (int)MAKELONG(wLow, wHigh);
        }
        /// <summary>
        /// 将两个无符号16位整数合并为一个有符号句柄
        /// </summary>
        /// <param name="wLow">无符号低16位整数</param>
        /// <param name="wHigh">无符号高16位整数</param>
        /// <returns>有符号句柄</returns>
        public static IntPtr MAKELRESULT(ushort wLow, ushort wHigh)
        {
            return (IntPtr)MAKELONG(wLow, wHigh);
        }


        /// <summary>
        /// 获取无符号高16位整数
        /// </summary>
        /// <param name="n">32位有符号整数</param>
        /// <returns>无符号高16位整数</returns>
        public static int HIWORD(int n)
        {
            return ((n >> 0x10) & 0xffff);
        }
        /// <summary>
        /// 获取无符号高16位整数
        /// </summary>
        /// <param name="n">句柄</param>
        /// <returns>无符号高16位整数</returns>
        public static int HIWORD(IntPtr n)
        {
            return HIWORD((int)((long)n));
        }
        /// <summary>
        /// 获取无符号低16位整数
        /// </summary>
        /// <param name="n">32位有符号整数</param>
        /// <returns>无符号低16位整数</returns>
        public static int LOWORD(int n)
        {
            return (n & 0xffff);
        }
        /// <summary>
        /// 获取无符号低16位整数
        /// </summary>
        /// <param name="n">句柄</param>
        /// <returns>无符号低16位整数</returns>
        public static int LOWORD(IntPtr n)
        {
            return LOWORD((int)((long)n));
        }
        /// <summary>
        /// 获取有符号高16位整数
        /// </summary>
        /// <param name="n">32位有符号整数</param>
        /// <returns>有符号高16位整数</returns>
        public static int SignedHIWORD(int n)
        {
            return (short)((n >> 0x10) & 0xffff);
        }
        /// <summary>
        /// 获取有符号高16位整数
        /// </summary>
        /// <param name="n">句柄</param>
        /// <returns>有符号高16位整数</returns>
        public static int SignedHIWORD(IntPtr n)
        {
            return SignedHIWORD((int)((long)n));
        }
        /// <summary>
        /// 获取有符号低16位整数
        /// </summary>
        /// <param name="n">32位有符号整数</param>
        /// <returns>有符号低16位整数</returns>
        public static int SignedLOWORD(int n)
        {
            return (short)(n & 0xffff);
        }
        /// <summary>
        /// 获取有符号低16位整数
        /// </summary>
        /// <param name="n">句柄</param>
        /// <returns>有符号低16位整数</returns>
        public static int SignedLOWORD(IntPtr n)
        {
            return SignedLOWORD((int)((long)n));
        }


        /// <summary>
        /// 将两个16位整数合并为一个32位整数
        /// </summary>
        /// <param name="low">低16位整数</param>
        /// <param name="high">高16为整数</param>
        /// <returns>32位整数</returns>
        public static int MAKELONG(int low, int high)
        {
            return ((high << 0x10) | (low & 0xffff));
        }
        /// <summary>
        /// 将两个16位整数合并为句柄
        /// </summary>
        /// <param name="low">低16位整数</param>
        /// <param name="high">高16为整数</param>
        /// <returns>LParam</returns>
        public static IntPtr MAKELPARAM(int low, int high)
        {
            return (IntPtr)((high << 0x10) | (low & 0xffff));
        }
    }
}
