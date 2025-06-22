using System;
using System.Runtime.InteropServices;

public class DesktopIconMetrics
{
    const int LVM_FIRST = 0x1000;
    const int LVM_GETITEMSPACING = LVM_FIRST + 51;

    [DllImport("user32.dll")]
    static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll")]
    static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

    [DllImport("user32.dll")]
    static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

    [DllImport("user32.dll")]
    static extern bool EnumChildWindows(IntPtr hWndParent, EnumWindowsProc lpEnumFunc, IntPtr lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

    delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

    public static (int Width, int Height)? GetDesktopIconSpacing()
    {
        IntPtr listViewHandle = FindDesktopListView();
        if (listViewHandle != IntPtr.Zero)
        {
            IntPtr result = SendMessage(listViewHandle, LVM_GETITEMSPACING, new IntPtr(1), IntPtr.Zero);
            int spacing = result.ToInt32();
            int iconSpacingX = spacing & 0xFFFF;
            int iconSpacingY = (spacing >> 16) & 0xFFFF;
            return (iconSpacingX, iconSpacingY);
        }
        return null;
    }

    private static IntPtr FindDesktopListView()
    {
        IntPtr found = IntPtr.Zero;

        EnumWindows((topHandle, lParam) =>
        {
            // دنبال WorkerWهایی بگرد که SHELLDLL_DefView دارند
            IntPtr shellView = FindWindowEx(topHandle, IntPtr.Zero, "SHELLDLL_DefView", null);
            if (shellView != IntPtr.Zero)
            {
                IntPtr sysListView32 = FindWindowEx(shellView, IntPtr.Zero, "SysListView32", "FolderView");
                if (sysListView32 != IntPtr.Zero)
                {
                    found = sysListView32;
                    return false; // Stop enumeration
                }
            }
            return true; // Continue
        }, IntPtr.Zero);

        return found;
    }
}