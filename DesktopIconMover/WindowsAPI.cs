using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct POINT
{
    public int X;
    public int Y;
}

public class WindowsAPI
{
    const int LVM_GETITEMPOSITION = 0x1010;
    const int LVM_SETITEMPOSITION = 0x100F;

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);


    [DllImport("user32.dll")]
    static extern int GetSystemMetrics(int nIndex);

    const int SM_CXSCREEN = 0;
    const int SM_CYSCREEN = 1;


    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

    public static IntPtr GetDesktopListView()
    {
        IntPtr progman = FindWindow("Progman", null);
        IntPtr desktopWnd = FindWindowEx(progman, IntPtr.Zero, "SHELLDLL_DefView", null);
        if (desktopWnd == IntPtr.Zero)
        {
            // گاهی اوقات در ویندوزهای جدید، SHELLDLL_DefView در یک WorkerW دیگر هست
            IntPtr desktopWorker = FindWindowEx(IntPtr.Zero, IntPtr.Zero, "WorkerW", null);
            while (desktopWorker != IntPtr.Zero && desktopWnd == IntPtr.Zero)
            {
                desktopWnd = FindWindowEx(desktopWorker, IntPtr.Zero, "SHELLDLL_DefView", null);
                desktopWorker = FindWindowEx(IntPtr.Zero, desktopWorker, "WorkerW", null);
            }
        }
        return FindWindowEx(desktopWnd, IntPtr.Zero, "SysListView32", "FolderView");
    }




    public static void MoveIconRelative(int iconIndex, int dx, int dy)
    {
        IntPtr hwndListView = GetDesktopListView();
        if (hwndListView == IntPtr.Zero)
        {
            Console.WriteLine("دسترسی به لیست آیکون‌ها ممکن نیست.");
            return;
        }

        // حافظه برای دریافت مختصات
        IntPtr pointPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(POINT)));
        try
        {
            bool success = SendMessage(hwndListView, LVM_GETITEMPOSITION, (IntPtr)iconIndex, pointPtr) != IntPtr.Zero;
            if (!success)
            {
                Console.WriteLine("موقعیت فعلی آیکون قابل دریافت نیست.");
                return;
            }

            POINT current = Marshal.PtrToStructure<POINT>(pointPtr);
            POINT newPoint = new POINT { X = current.X + dx, Y = current.Y + dy };

            // مکان جدید
            IntPtr lParam = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(POINT)));
            Marshal.StructureToPtr(newPoint, lParam, false);

            SendMessage(hwndListView, LVM_SETITEMPOSITION, (IntPtr)iconIndex, lParam);

            Console.WriteLine($"آیکون {iconIndex} منتقل شد به ({newPoint.X}, {newPoint.Y})");

            Marshal.FreeHGlobal(lParam);
        }
        finally
        {
            Marshal.FreeHGlobal(pointPtr);
        }
    }
}