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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace DesktopIconMover
{
    public partial class MainForm : Form
    {
        public int Step { get; set; } = 25;
        private readonly List<string> iconNames = new List<string>();

        public enum Direction { Up, Left, Right, Down, Null };

        public Direction Dir { get; set; } = Direction.Null;
        // توابع WinAPI
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);


        [DllImport("user32.dll", SetLastError = true)]
        static extern int SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        // ثابت‌ها
        const uint LVM_GETITEMCOUNT = 0x1000 + 4;
        const uint LVM_SETITEMPOSITION = 0x1000 + 15;
        private const uint LVM_GETITEMPOSITION = 0x1000 + 16;
        private const uint LVM_GETITEMTEXT = 0x1000 + 45;
        const int WM_COMMAND = 0x111;
        private const string PacmanFile = @"F:\peyman\desktop\pacman.png";

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

            LoadDesktopIcons();
        }

        static void RefreshDesktop()
        {
            // دریافت هندل پنجره دسکتاپ (SysListView32)
            IntPtr progman = FindWindow("Progman", null);
            IntPtr desktopWnd = FindWindowEx(progman, IntPtr.Zero, "SHELLDLL_DefView", null);
            IntPtr listView = FindWindowEx(desktopWnd, IntPtr.Zero, "SysListView32", "FolderView");

            // ارسال پیام WM_COMMAND با کد ریفرش
            SendMessage(desktopWnd, WM_COMMAND, new IntPtr(0x7103), IntPtr.Zero);
        }


        private void LoadDesktopIcons()
        {
            cmbIconList.Items.Clear();

            IntPtr hwndListView = GetDesktopListView();
            if (hwndListView == IntPtr.Zero) return;

            int count = SendMessage(hwndListView, LVM_GETITEMCOUNT, IntPtr.Zero, IntPtr.Zero);
            StringBuilder itemText = new StringBuilder(256);

            for (int i = 0; i < count; i++)
            {
                // SendMessage2(hwndListView, LVM_GETITEMTEXT, (IntPtr)i, itemText);
                string iconName = "آیکون شماره " + i;
                iconNames.Add(iconName);
            }


            cmbIconList.Items.AddRange(iconNames.ToArray());

            cmbIconList.SelectedIndex = iconNames.Count-1;
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
            if (cmbIconList.SelectedIndex == -1) return;

            int selectedIndex = cmbIconList.SelectedIndex;
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
            chkLock.Checked = false;
            // LoadDesktopIcons();
            numX.Value = numY.Value = 100;
        }

        private void btnGo(object sender, EventArgs e)
        {
            MoveIconRelative(cmbIconList.SelectedIndex, (int)numX.Value, (int)numY.Value);

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


            panelArrowKeys.Focus();
        }



        private void btnUp(object sender, EventArgs e)
        {
            numY.Value -= Step;
            MoveIconRelative(cmbIconList.SelectedIndex, (int)numX.Value, (int)numY.Value);

            if (Dir != Direction.Up)
            {
                Dir = Direction.Up;
                if (chkPacman.Checked)
                    Properties.Resources.up.Save(PacmanFile);
                ResetArrowButtonColor();
                ButtonUp.BackColor = Color.Gold;
                RefreshDesktop();

            }


        }

        private void btnDown(object sender, EventArgs e)
        {
            numY.Value += Step;

            MoveIconRelative(cmbIconList.SelectedIndex, (int)numX.Value, (int)numY.Value);
            if (Dir != Direction.Down)
            {
                Dir = Direction.Down;
                if (chkPacman.Checked)
                    Properties.Resources.down.Save(PacmanFile);
                ResetArrowButtonColor();
                ButtonDown.BackColor = Color.Gold;
                RefreshDesktop();

            }




        }

        private void ResetArrowButtonColor()
        {
            ButtonRight.BackColor = Color.WhiteSmoke;
            ButtonLeft.BackColor = Color.WhiteSmoke;
            ButtonUp.BackColor = Color.WhiteSmoke;
            ButtonDown.BackColor = Color.WhiteSmoke;
             panelArrowKeys.Focus();
        }

        private void btnLeft(object sender, EventArgs e)
        {
            numX.Value -= Step;
            MoveIconRelative(cmbIconList.SelectedIndex, (int)numX.Value, (int)numY.Value);
            if (Dir != Direction.Left)
            {
                Dir = Direction.Left;
                if (chkPacman.Checked)
                    Properties.Resources.left.Save(PacmanFile);
                ResetArrowButtonColor();
                ButtonLeft.BackColor = Color.Gold;
                RefreshDesktop();

            }


        }

        private void btnRight(object sender, EventArgs e)
        {
            numX.Value += Step ;

            MoveIconRelative(cmbIconList.SelectedIndex, (int)numX.Value, (int)numY.Value);

            if (Dir != Direction.Right)
            {
                Dir = Direction.Right;
                if (chkPacman.Checked)
                    Properties.Resources.right.Save(PacmanFile);
                ResetArrowButtonColor();
                ButtonRight.BackColor = Color.Gold;
                ButtonRight.Focus();

                RefreshDesktop();
            }


        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = chkLock.Checked;
            cmbIconList.Enabled = !chkLock.Checked;
            ResetArrowButtonColor();

            if (timer1.Enabled) Step = 5;
            else
                 Step = 30;
        }



        private void MainForm_Load(object sender, EventArgs e)
        {
            trackBar1_Scroll(null,null);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            

        


        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {


  




        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void MainForm_Click(object sender, EventArgs e)
        {
            chkLock.Checked = false;
        }

        private void numX_ValueChanged(object sender, EventArgs e)
        {
            MoveIconRelative(cmbIconList.SelectedIndex, (int)numX.Value, (int)numY.Value);

        }

        private void numY_ValueChanged(object sender, EventArgs e)
        {
            MoveIconRelative(cmbIconList.SelectedIndex, (int)numX.Value, (int)numY.Value);

        }

        private void timerTarget_Tick(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ButtonRight_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = trackBar1.Value * 2;
            lblSpeed.Text = (trackBar1.Maximum - trackBar1.Value +1).ToString();
            if(timer1.Enabled) timer1_Tick(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chkLock.Checked = false;
            this.Hide();
            new MarioForm().ShowDialog();
            this.Show();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Escape)
                chkLock.Checked = false;


            if (keyData == Keys.Up)
                btnUp(null, null);
            else if (keyData == Keys.Down)
                btnDown(null, null);

            else if (keyData == Keys.Left)
                btnLeft(null, null);

            if (keyData == Keys.Right)
                btnRight(null, null);

            panelArrowKeys.Focus();
            return base.ProcessCmdKey(ref msg, keyData);
        }



        private void MainForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

   
        }
    }
}
