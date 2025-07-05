using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;


[StructLayout(LayoutKind.Sequential)]
public struct POINT
{
    public int X;
    public int Y;
}

public class WindowsAPI
{



    // توابع WinAPI
    [DllImport("user32.dll", SetLastError = true)]
    static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll", SetLastError = true)]
    static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

    [DllImport("user32.dll", SetLastError = true)]
    static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);



    delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll", SetLastError = true)]
    static extern int SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);


    [DllImport("user32.dll")]
    private static extern bool IsWindowVisible(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int maxLength);

    [DllImport("user32.dll")]   // محل پنجره های باز در صفحه
    private static extern bool GetWindowRect(IntPtr hWnd, out RECT rect);  

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }



    // ثابت‌ها
    public const int LVM_GETITEMCOUNT = 0x1000 + 4;
    public const int LVM_SETITEMPOSITION = 0x1000 + 15;
    public const int LVM_GETITEMPOSITION = 0x1000 + 16;
    public const int LVM_GETITEMTEXT = 0x1000 + 45;
    public const int WM_COMMAND = 0x111;





    [DllImport("user32.dll")]
    static extern int GetSystemMetrics(int nIndex);

    const int SM_CXSCREEN = 0;
    const int SM_CYSCREEN = 1;




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
            bool success = SendMessage(hwndListView, LVM_GETITEMPOSITION, iconIndex, pointPtr) != 0;
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

            SendMessage(hwndListView, LVM_SETITEMPOSITION, iconIndex, lParam);

            Console.WriteLine($"آیکون {iconIndex} منتقل شد به ({newPoint.X}, {newPoint.Y})");

            Marshal.FreeHGlobal(lParam);
        }
        finally
        {
            Marshal.FreeHGlobal(pointPtr);
        }
    }
}