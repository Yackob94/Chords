﻿using System.Runtime.InteropServices;

namespace Chords.CoreApp
{
    public static class CoolerMasterSdkWrapper
    {
        private const int MaxLedRow = 7;
        private const int MaxLedColumn = 24;
        private const string SdkDll = @"SDKDLL.dll";

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void KeyCallback(int iRow, int iColumn, [MarshalAs(UnmanagedType.I1)] bool bPressed);

        [DllImport(SdkDll, EntryPoint = "SetControlDevice")]
        public static extern void SetControlDevice(DeviceIndex devIndex);

        [DllImport(SdkDll, EntryPoint = "IsDevicePlug")]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsDevicePlug(DeviceIndex devIndex = DeviceIndex.DevDefault);


        [DllImport(SdkDll, EntryPoint = "EnableLedControl")]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool EnableLedControl([MarshalAs(UnmanagedType.I1)] bool bEnable, DeviceIndex devIndex = DeviceIndex.DevDefault);


        [DllImport(SdkDll, EntryPoint = "RefreshLed")]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool RefreshLed([MarshalAs(UnmanagedType.I1)] bool bAuto, DeviceIndex devIndex = DeviceIndex.DevDefault);

        [DllImport(SdkDll, EntryPoint = "SetAllLedColor")]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool SetAllLedColor(ColorMatrix colorMatrix, DeviceIndex devIndex = DeviceIndex.DevDefault);

        [DllImport(SdkDll, EntryPoint = "SetLedColor")]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool SetLedColor(int iRow, int iColumn, byte r, byte g, byte b, DeviceIndex devIndex = DeviceIndex.DevDefault);

        [DllImport(SdkDll, EntryPoint = "EnableKeyInterrupt")]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool EnableKeyInterrupt([MarshalAs(UnmanagedType.I1)] bool bEnable, DeviceIndex devIndex = DeviceIndex.DevDefault);

        [DllImport(SdkDll, EntryPoint = "SetKeyCallBack")]
        public static extern void SetKeyCallBack(KeyCallback callback, DeviceIndex devIndex = DeviceIndex.DevDefault);

        [StructLayout(LayoutKind.Sequential)]
        public struct KeyColor
        {
            public readonly byte r;
            public readonly byte g;
            public readonly byte b;

            public KeyColor(byte r, byte g, byte b)
            {
                this.r = r;
                this.g = g;
                this.b = b;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ColorMatrix
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MaxLedRow * MaxLedColumn,
                ArraySubType = UnmanagedType.Struct)]
            public KeyColor[,] KeyColor;
        }

        public enum DeviceIndex
        {
            DevMKeysSWhite = 7,
            DevDefault = 0xFFFF
        }
    }
}