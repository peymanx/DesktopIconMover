using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DesktopIconMover
{
    public partial class MainForm : Form
    {
        public int Step { get; set; } = 10;
        public enum Direction { Up, Left, Right, Down, Null };

        public Direction Dir { get; set; } = Direction.Null;
        // توابع WinAPI
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);


        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SendMessage2(IntPtr hWnd, uint Msg, IntPtr wParam, StringBuilder lParam);


        [DllImport("user32.dll", SetLastError = true)]
        static extern int SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        // ثابت‌ها
        const uint LVM_GETITEMCOUNT = 0x1000 + 4;
        const uint LVM_SETITEMPOSITION = 0x1000 + 15;
        private const uint LVM_GETITEMPOSITION = 0x1000 + 16;
        private const uint LVM_GETITEMTEXT = 0x1000 + 45;

        static IntPtr GetDesktopListView()
        {
            IntPtr progman = FindWindow("Progman", null);
            SendMessage(progman, 0x052C, IntPtr.Zero, IntPtr.Zero);

            IntPtr listView = IntPtr.Zero;

            EnumWindows((topHandle, lParam) =>
            {
                IntPtr shellView = FindWindowEx(topHandle, IntPtr.Zero, "SHELLDLL_DefView", null);
                if (shellView != IntPtr.Zero)
                {
                    IntPtr sysListView = FindWindowEx(shellView, IntPtr.Zero, "SysListView32", "FolderView");
                    if (sysListView != IntPtr.Zero)
                    {
                        listView = sysListView;
                        return false; // Stop
                    }
                }
                return true;
            }, IntPtr.Zero);

            return listView;
        }
        public MainForm()
        {
            InitializeComponent();


            this.Text = "مدیریت آیکون‌های دسکتاپ"; 
            TopMost = true;

            LoadDesktopIcons();
        }
        private List<string> iconNames = new List<string>();




        private void LoadDesktopIcons()
        {
            IntPtr hwndListView = GetDesktopListView();
            if (hwndListView == IntPtr.Zero) return;

            int count = SendMessage(hwndListView, LVM_GETITEMCOUNT, IntPtr.Zero, IntPtr.Zero);
                StringBuilder itemText = new StringBuilder(256);
            for (int i = 0; i < count; i++)
            {
               // SendMessage2(hwndListView, LVM_GETITEMTEXT, (IntPtr)i, itemText);
                string iconName = "icon "+ i;
                iconNames.Add(iconName);
            }

            comboBox1.Items.AddRange(iconNames.ToArray());
        }
        public static void MoveIconRelative(int iconIndex, int dx, int dy)
        {
            IntPtr hwndListView = GetDesktopListView();
            if (hwndListView == IntPtr.Zero) return;

            int posData = SendMessage(hwndListView, LVM_GETITEMPOSITION, (IntPtr)iconIndex, IntPtr.Zero);

            int currentX = posData & 0xFFFF;
            int currentY = (posData >> 16) & 0xFFFF;

            int newX = currentX + dx;
            int newY = currentY + dy;

            IntPtr lParam = (IntPtr)((newY << 16) | (newX & 0xFFFF));
            SendMessage(hwndListView, LVM_SETITEMPOSITION, (IntPtr)iconIndex, lParam);

            Console.WriteLine($"آیکون {iconIndex} به مکان جدید ({newX}, {newY}) منتقل شد.");
        }


        private void BtnMoveIcon_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1) return;

            int selectedIndex = comboBox1.SelectedIndex;
            IntPtr hwndListView = GetDesktopListView();
            if (hwndListView == IntPtr.Zero) return;

            IntPtr lParam = (IntPtr)(((int)numY.Value << 16) | ((int)numX.Value & 0xFFFF));
            SendMessage(hwndListView, LVM_SETITEMPOSITION, (IntPtr)selectedIndex, lParam);

           
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkBox2.Checked = false;

        }

        private void btnGo(object sender, EventArgs e)
        {
            MoveIconRelative(comboBox1.SelectedIndex, (int)numX.Value, (int)numY.Value);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (Dir)
            {
                case Direction.Up:
                    btnUp(null, null);
                    break;
                case Direction.Left:
                    btnLeft(null, null);
                    break;
                case Direction.Right:
                    btnRight(null, null);
                    break;

                case Direction.Down:
                    btnDown(null, null);
                    break;
                default:
                    break;
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false) return;
            Point mousePosition = Cursor.Position;

            // Access the X and Y coordinates
            int x = mousePosition.X;
            int y = mousePosition.Y;

            // Alternatively, you can directly access the coordinates without creating a Point object:
            int xDirect = Cursor.Position.X;
            int yDirect = Cursor.Position.Y;

            numX.Value = x; numY.Value = y;
            btnGo(sender, e);
        }

        private void btnUp(object sender, EventArgs e)
        {
            numY.Value -= Step;
            MoveIconRelative(comboBox1.SelectedIndex, (int)numX.Value, (int)numY.Value);
            Dir = Direction.Up;

            ButtonRight.BackColor = Color.WhiteSmoke;
            ButtonLeft.BackColor = Color.WhiteSmoke;
            ButtonUp.BackColor = Color.Gold;
            ButtonDown.BackColor = Color.WhiteSmoke;
            panel1.Focus();

        }

        private void btnDown(object sender, EventArgs e)
        {
            numY.Value += Step;

            MoveIconRelative(comboBox1.SelectedIndex, (int)numX.Value, (int)numY.Value);
            Dir = Direction.Down;
            ButtonRight.BackColor = Color.WhiteSmoke;
            ButtonLeft.BackColor = Color.WhiteSmoke;
            ButtonUp.BackColor = Color.WhiteSmoke;
            ButtonDown.BackColor = Color.Gold;

            panel1.Focus();

        }

        private void btnLeft(object sender, EventArgs e)
        {
            numX.Value -= Step;
            MoveIconRelative(comboBox1.SelectedIndex, (int)numX.Value, (int)numY.Value);
            Dir = Direction.Left;

            ButtonRight.BackColor = Color.WhiteSmoke;
            ButtonLeft.BackColor = Color.Gold;
            ButtonUp.BackColor = Color.WhiteSmoke;
            ButtonDown.BackColor = Color.WhiteSmoke;
            panel1.Focus();

        }

        private void btnRight(object sender, EventArgs e)
        {
            numX.Value += Step;

            MoveIconRelative(comboBox1.SelectedIndex, (int)numX.Value, (int)numY.Value);
            Dir = Direction.Right;
          
            ButtonRight.BackColor = Color.Gold;
            ButtonLeft.BackColor = Color.WhiteSmoke;
            ButtonUp.BackColor = Color.WhiteSmoke;
            ButtonDown.BackColor = Color.WhiteSmoke;

            panel1.Focus();

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = checkBox2.Checked;
            comboBox1.Enabled = !checkBox2.Checked;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
          

        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                btnUp(null, null);
            if (e.KeyCode == Keys.Down)
                btnDown(null, null);

            if (e.KeyCode == Keys.Left)
                btnLeft(null, null);

            if (e.KeyCode == Keys.Right)
                btnRight(null, null);
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void MainForm_Click(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
        }

        private void numX_ValueChanged(object sender, EventArgs e)
        {
            MoveIconRelative(comboBox1.SelectedIndex, (int)numX.Value, (int)numY.Value);

        }

        private void numY_ValueChanged(object sender, EventArgs e)
        {
            MoveIconRelative(comboBox1.SelectedIndex, (int)numX.Value, (int)numY.Value);

        }
    }
}
