using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public static class DesktopRefresher
{
    const int SHCNE_ASSOCCHANGED = 0x8000000;
    const int SHCNF_IDLIST = 0x0;

    [DllImport("shell32.dll")]
    static extern void SHChangeNotify(int wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);

    [DllImport("user32.dll")]
    static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, IntPtr dwExtraInfo);

    const uint KEYEVENTF_KEYUP = 0x0002;
    const byte VK_F5 = 0x74;

    public static void RefreshDesktop()
    {

        // مرحله دوم: ارسال کلید F5
        SendF5Key();

    }

    public static void HardRefresh()
    {
        // مرحله اول: نوتیفای به Explorer
        SHChangeNotify(SHCNE_ASSOCCHANGED, SHCNF_IDLIST, IntPtr.Zero, IntPtr.Zero);


    }

    private static void SendF5Key()
    {
        keybd_event(VK_F5, 0, 0, IntPtr.Zero);               // کلید پایین
        keybd_event(VK_F5, 0, KEYEVENTF_KEYUP, IntPtr.Zero); // کلید بالا
    }
}