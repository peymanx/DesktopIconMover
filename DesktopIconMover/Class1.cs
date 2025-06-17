using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

public partial class Form1 : Form
{


    [DllImport("user32.dll", SetLastError = true)]
    static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll", SetLastError = true)]
    static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    static extern int SendMessage(IntPtr hWnd, int msg, int wParam, StringBuilder lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    static extern int SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;
    }

    const int LVM_GETITEMCOUNT = 0x1000 + 4;
    const int LVM_GETITEMTEXT = 0x1000 + 45;
    const int LVM_GETITEMPOSITION = 0x1000 + 16;
    const int MAX_TEXT = 260;

    ComboBox comboBoxIcons = new ComboBox() { Dock = DockStyle.Top, DropDownStyle = ComboBoxStyle.DropDownList };
    Label labelPos = new Label() { Dock = DockStyle.Fill, Font = new Font("Consolas", 12) };

    private void LoadDesktopIcons()
    {
        Controls.Add(labelPos);
        Controls.Add(comboBoxIcons);

        IntPtr listView = GetDesktopListView();
        if (listView == IntPtr.Zero) return;

        int count = SendMessage(listView, LVM_GETITEMCOUNT, 0, IntPtr.Zero);

        for (int i = 0; i < count; i++)
        {
            StringBuilder sb = new StringBuilder(MAX_TEXT);
            SendMessage(listView, LVM_GETITEMTEXT, i, GetLParamItemText(i, sb));
            comboBoxIcons.Items.Add($"{i}: {sb.ToString()}");
        }

        comboBoxIcons.SelectedIndexChanged += (s, e) =>
        {
            int idx = comboBoxIcons.SelectedIndex;
            Point p = GetIconPosition(idx);
            labelPos.Text = $"Position of '{comboBoxIcons.SelectedItem}': X = {p.X}, Y = {p.Y}";
        };
    }

    private IntPtr GetDesktopListView()
    {
        IntPtr progman = FindWindow("Progman", null);
        IntPtr shellView = FindWindowEx(progman, IntPtr.Zero, "SHELLDLL_DefView", null);

        if (shellView == IntPtr.Zero)
        {
            // گاهی اوقات در WorkerW هست
            IntPtr desktop = IntPtr.Zero;
            while ((desktop = FindWindowEx(IntPtr.Zero, desktop, "WorkerW", null)) != IntPtr.Zero)
            {
                shellView = FindWindowEx(desktop, IntPtr.Zero, "SHELLDLL_DefView", null);
                if (shellView != IntPtr.Zero)
                    break;
            }
        }

        return shellView == IntPtr.Zero ? IntPtr.Zero :
            FindWindowEx(shellView, IntPtr.Zero, "SysListView32", "FolderView");
    }

    private IntPtr GetLParamItemText(int itemIndex, StringBuilder sb)
    {
        LVITEM lv = new LVITEM();
        lv.mask = 0x0001; // LVIF_TEXT
        lv.iItem = itemIndex;
        lv.iSubItem = 0;
        lv.cchTextMax = sb.Capacity;
        lv.pszText = Marshal.AllocHGlobal(sb.Capacity * 2);
        Marshal.Copy(sb.ToString().ToCharArray(), 0, lv.pszText, sb.Length);

        IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(lv));
        Marshal.StructureToPtr(lv, ptr, false);
        return ptr;
    }

    private Point GetIconPosition(int index)
    {
        IntPtr listView = GetDesktopListView();
        if (listView == IntPtr.Zero) return Point.Empty;

        IntPtr ptrPoint = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(POINT)));
        SendMessage(listView, LVM_GETITEMPOSITION, index, ptrPoint);
        POINT pt = Marshal.PtrToStructure<POINT>(ptrPoint);
        Marshal.FreeHGlobal(ptrPoint);
        return new Point(pt.X, pt.Y);
    }

    private int GetIconCount()
    {
        IntPtr listView = GetDesktopListView();
        return listView == IntPtr.Zero ? 0 : SendMessage(listView, LVM_GETITEMCOUNT, 0, IntPtr.Zero);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LVITEM
    {
        public uint mask;
        public int iItem;
        public int iSubItem;
        public uint state;
        public uint stateMask;
        public IntPtr pszText;
        public int cchTextMax;
        public int iImage;
        public IntPtr lParam;
    }
}