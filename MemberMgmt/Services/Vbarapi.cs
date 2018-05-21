﻿using System;
using System.Runtime.InteropServices;

namespace MemberMgmt.Services
{
    class Vbarapi
    {
        IntPtr dev;
        //连接设备
        [DllImport("vbar.dll", EntryPoint = "vbar_connectDevice", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vbar_connectDevice(long arg);
        //关闭设备
        [DllImport("vbar.dll", EntryPoint = "vbar_disconnectDevice", CallingConvention = CallingConvention.Cdecl)]
        public static extern void vbar_disconnectDevice(IntPtr dev);
        //背光控制
        [DllImport("vbar.dll", EntryPoint = "vbar_backlight", CallingConvention = CallingConvention.Cdecl)]
        public static extern int vbar_backlight(IntPtr dev, bool bswitch);
        //扫描间隔时间
        [DllImport("vbar.dll", EntryPoint = "vbar_interval", CallingConvention = CallingConvention.Cdecl)]
        public static extern int vbar_interval(IntPtr dev, int time);
        //蜂鸣器控制
        [DllImport("vbar.dll", EntryPoint = "vbar_beepControl", CallingConvention = CallingConvention.Cdecl)]
        public static extern int vbar_beepControl(IntPtr dev, byte times);
        //获取扫码结果
        [DllImport("vbar.dll", EntryPoint = "vbar_getResultStr", CallingConvention = CallingConvention.Cdecl)]
        public static extern int vbar_getResultStr(IntPtr dev, byte[] result_buffer, ref int result_size, ref int result_type);

        //码制添加
        [DllImport("vbar.dll", EntryPoint = "vbar_addCodeFormat", CallingConvention = CallingConvention.Cdecl)]
        public static extern int vbar_addCodeFormat(IntPtr dev, byte codeFormat);


        /// <summary>
        /// 连接设备
        /// </summary>
        /// <param name="devnum"></param>
        /// <returns></returns>
        public bool openDevice(int devnum)
        {
            dev = vbar_connectDevice(devnum);
            if (dev == IntPtr.Zero)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 背光控制
        /// </summary>
        /// <param name="bswitch"></param>
        public void backlight(bool bswitch)
        {
            if (dev != null)
            {
                vbar_backlight(dev, bswitch);
            }
        }
        /// <summary>
        /// 间隔时间设置
        /// </summary>
        /// <param name="time"></param>
        public void interval(int time)
        {
            if (dev != null)
            {
                vbar_interval(dev, time);
            }
        }

        /// <summary>
        /// 设置码制
        /// </summary>
        /// <param name="codeFormat"></param>
        /// <returns></returns>
        public bool addCodeFormat(byte codeFormat)
        {
            if (dev != null)
            {
                if (vbar_addCodeFormat(dev, codeFormat) == 0)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        /// <summary>
        /// 蜂鸣器控制
        /// </summary>
        /// <param name="times"></param>
        public void beepControl(byte times)
        {
            if (dev != null)
            {
                vbar_beepControl(dev, times);
            }
        }
        /// <summary>
        /// 断开设备
        /// </summary>
        public void disConnected()
        {
            if (dev != null)
            {
                vbar_disconnectDevice(dev);
                dev = IntPtr.Zero;
            }
        }
        /// <summary>
        /// 解码设置
        /// </summary>
        /// <param name="result_buffer"></param>
        /// <param name="result_size"></param>
        /// <returns></returns>
        public bool getResultStr(out byte[] result_buffer, out int result_size)
        {
            byte[] c_result = new byte[256];
            int c_size = 0;
            int c_type = 0;
            if (dev != null)
            {
                if (vbar_getResultStr(dev, c_result, ref c_size, ref c_type) == 0)
                {
                    result_buffer = c_result;
                    result_size = c_size;
                    return true;
                }
                else
                {
                    result_buffer = null;
                    result_size = 0;
                    return false;
                }
            }
            else
            {
                result_buffer = null;
                result_size = 0;
                return false;
            }
        }
    }
}
