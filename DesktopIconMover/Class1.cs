using System;
using System.Runtime.InteropServices;
using System.Text;

public class DesktopIconLocator
{
    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern int SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, StringBuilder lParam);

    private const uint LVM_GETITEMCOUNT = 0x1000 + 4;
    private const uint LVM_GETITEMTEXT = 0x1000 + 45;
    private const uint LVM_GETITEMPOSITION = 0x1000 + 16;

    public static (int x, int y) GetIconPositionByName(string iconName)
    {
        IntPtr hwndListView = GetDesktopListView();
        if (hwndListView == IntPtr.Zero) return (-1, -1);

        int count = SendMessage(hwndListView, LVM_GETITEMCOUNT, IntPtr.Zero, IntPtr.Zero);

        for (int i = 0; i < count; i++)
        {
            StringBuilder itemText = new StringBuilder(256);
            SendMessage(hwndListView, LVM_GETITEMTEXT, (IntPtr)i, itemText);

            if (itemText.ToString().Equals(iconName, StringComparison.OrdinalIgnoreCase))
            {
                int posData = SendMessage(hwndListView, LVM_GETITEMPOSITION, (IntPtr)i, IntPtr.Zero);
                int x = posData & 0xFFFF;
                int y = (posData >> 16) & 0xFFFF;
                return (x, y);
            }
        }

        return (-1, -1); // آیکون پیدا نشد
    }

    private static IntPtr GetDesktopListView()
    {
        IntPtr progman = FindWindow("Progman", null);
        SendMessage(progman, 0x052C, IntPtr.Zero, IntPtr.Zero);

        IntPtr shellView = FindWindowEx(progman, IntPtr.Zero, "SHELLDLL_DefView", null);
        return shellView == IntPtr.Zero ? IntPtr.Zero : FindWindowEx(shellView, IntPtr.Zero, "SysListView32", "FolderView");
    }
}