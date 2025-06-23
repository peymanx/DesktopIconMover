using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

public class DesktopIconLocator
{
    private const int LVM_GETITEMCOUNT = 0x1000;
    private const int LVM_GETITEMTEXT = 0x1073;
    private const int LVM_GETITEMPOSITION = 0x1010;
    private const int LVM_SETITEMPOSITION = 0x100F;
    private const int LVIF_TEXT = 0x0001;

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct LVITEM
    {
        public uint mask;
        public int iItem;
        public int iSubItem;
        public int state;
        public int stateMask;
        public IntPtr pszText;
        public int cchTextMax;
        public int iImage;
        public IntPtr lParam;
    }

    [DllImport("user32.dll", SetLastError = true)]
    static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll", SetLastError = true)]
    static extern IntPtr FindWindowEx(IntPtr parent, IntPtr childAfter, string className, string windowTitle);

    [DllImport("user32.dll")]
    static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, ref Point lParam);

    [DllImport("user32.dll")]
    static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);

    [DllImport("user32.dll")]
    static extern int SendMessage(IntPtr hWnd, int msg, int wParam, ref LVITEM lParam);

    private static IntPtr GetListViewHandle()
    {
        IntPtr progman = FindWindow("Progman", null);
        IntPtr desktopWnd = FindWindowEx(progman, IntPtr.Zero, "SHELLDLL_DefView", null);
        if (desktopWnd == IntPtr.Zero)
        {
            IntPtr workerW = FindWindowEx(IntPtr.Zero, IntPtr.Zero, "WorkerW", null);
            while (workerW != IntPtr.Zero && desktopWnd == IntPtr.Zero)
            {
                desktopWnd = FindWindowEx(workerW, IntPtr.Zero, "SHELLDLL_DefView", null);
                workerW = FindWindowEx(IntPtr.Zero, workerW, "WorkerW", null);
            }
        }

        if (desktopWnd == IntPtr.Zero)
            return IntPtr.Zero;

        return FindWindowEx(desktopWnd, IntPtr.Zero, "SysListView32", null);
    }

    public static Point? GetRecycleBinPosition()
    {
        IntPtr listView = GetListViewHandle();
        if (listView == IntPtr.Zero)
            return null;

        int itemCount = SendMessage(listView, LVM_GETITEMCOUNT, 0, IntPtr.Zero).ToInt32();
        for (int i = 0; i < itemCount; i++)
        {
            string name = GetItemText(listView, i);
            if (!string.IsNullOrEmpty(name) && name.ToLower().Contains("recycle"))
            {
                Point p = new Point();
                SendMessage(listView, LVM_GETITEMPOSITION, i, ref p);
                return p;
            }
        }

        return null;
    }

    public static int? GetIconIndexByName(string iconName)
    {
        IntPtr listView = GetListViewHandle();
        if (listView == IntPtr.Zero)
            return null;

        var itemCount = SendMessage(listView, LVM_GETITEMCOUNT, 0, IntPtr.Zero).ToInt32();
        for (int i = 0; i < itemCount; i++)
        {
            string name = GetItemText(listView, i);
            if (!string.IsNullOrEmpty(name) && name.ToLower().Contains(iconName.ToLower()))
            {
                return i;
            }
        }

        return null;
    }

    public static bool SetIconPosition(int index, int x, int y)
    {
        IntPtr listView = GetListViewHandle();
        if (listView == IntPtr.Zero)
            return false;

        // ارسال موقعیت جدید برای آیکون
        SendMessage(listView, LVM_SETITEMPOSITION, index, (IntPtr)((y << 16) | (x & 0xFFFF)));
        return true;
    }

    private static string GetItemText(IntPtr listView, int index)
    {
        LVITEM lvi = new LVITEM
        {
            mask = LVIF_TEXT,
            iItem = index,
            iSubItem = 0,
            cchTextMax = 512,
            pszText = Marshal.AllocHGlobal(1024)
        };

        string result = "";
        try
        {
            SendMessage(listView, LVM_GETITEMTEXT, index, ref lvi);
            result = Marshal.PtrToStringAuto(lvi.pszText);
        }
        finally
        {
            Marshal.FreeHGlobal(lvi.pszText);
        }

        return result;
    }
}