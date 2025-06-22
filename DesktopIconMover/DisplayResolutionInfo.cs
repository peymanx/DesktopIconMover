using System;
using System.Runtime.InteropServices;

public class DisplayResolutionInfo
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    private struct DEVMODE
    {
        private const int CCHDEVICENAME = 32;
        private const int CCHFORMNAME = 32;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHDEVICENAME)]
        public string dmDeviceName;

        public ushort dmSpecVersion;
        public ushort dmDriverVersion;
        public ushort dmSize;
        public ushort dmDriverExtra;
        public uint dmFields;

        public int dmPositionX;
        public int dmPositionY;
        public uint dmDisplayOrientation;
        public uint dmDisplayFixedOutput;

        public short dmColor;
        public short dmDuplex;
        public short dmYResolution;
        public short dmTTOption;
        public short dmCollate;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHFORMNAME)]
        public string dmFormName;

        public ushort dmLogPixels;
        public uint dmBitsPerPel;
        public uint dmPelsWidth;   // ✅ Width
        public uint dmPelsHeight;  // ✅ Height
        public uint dmDisplayFlags;
        public uint dmDisplayFrequency;
    }

    [DllImport("user32.dll", CharSet = CharSet.Ansi)]
    private static extern bool EnumDisplaySettings(
        string lpszDeviceName, int iModeNum, ref DEVMODE lpDevMode);

    public static (int Width, int Height) GetPhysicalScreenResolution()
    {
        DEVMODE devMode = new DEVMODE();
        devMode.dmSize = (ushort)Marshal.SizeOf(typeof(DEVMODE));

        const int ENUM_CURRENT_SETTINGS = -1;

        if (EnumDisplaySettings(null, ENUM_CURRENT_SETTINGS, ref devMode))
        {
            return ((int)devMode.dmPelsWidth, (int)devMode.dmPelsHeight);
        }
        else
        {
            throw new Exception("❌ نتوانستم رزولوشن واقعی را دریافت کنم.");
        }
    }
}