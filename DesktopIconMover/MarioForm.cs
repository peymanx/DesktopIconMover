using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DesktopIconMover
{
    public partial class MarioForm : Form
    {
        public MarioForm()
        {
            InitializeComponent();
            LoadDesktopIcons();

        }




        public int Step { get; set; } = 10;
        public string MarioPath { get; set; }

        public int Target { get; set; }
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



        const int LVM_GETITEMPOSITION2 = 0x1010;
        const int LVM_SETITEMPOSITION2 = 0x100F;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        // ثابت‌ها
        const uint LVM_GETITEMCOUNT = 0x1000 + 4;
        const uint LVM_SETITEMPOSITION = 0x1000 + 15;
        private const uint LVM_GETITEMPOSITION = 0x1000 + 16;
        private const uint LVM_GETITEMTEXT = 0x1000 + 45;
        const int WM_COMMAND = 0x111;
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

            cmbIconList.SelectedIndex = iconNames.Count - 1;
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

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
        }

        public static void MoveIconRelative2(int iconIndex, int dx, int dy)
        {
            IntPtr hwndListView = GetDesktopListView();
            if (hwndListView == IntPtr.Zero) return;

            // حافظه موقت برای دریافت مختصات
            IntPtr pointPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(POINT)));
            try
            {
                bool success = SendMessage(hwndListView, LVM_GETITEMPOSITION2, (IntPtr)iconIndex, pointPtr) != IntPtr.Zero;
                if (!success)
                {
                    Console.WriteLine("موقعیت فعلی آیکون خوانده نشد.");
                    return;
                }

                POINT currentPos = Marshal.PtrToStructure<POINT>(pointPtr);
                int newX = currentPos.X + dx;
                int newY = currentPos.Y + dy;

                IntPtr lParam = (IntPtr)((newY << 16) | (newX & 0xFFFF));
                SendMessage(hwndListView, LVM_SETITEMPOSITION, (IntPtr)iconIndex, lParam);

                Console.WriteLine($"آیکون {iconIndex} به مکان جدید ({newX}, {newY}) منتقل شد.");
            }
            finally
            {
                Marshal.FreeHGlobal(pointPtr);
            }
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






        private void btnUp(object sender, EventArgs e)
        {
            numY.Value -= Step;
            MoveIconRelative(cmbIconList.SelectedIndex, (int)numX.Value, (int)numY.Value);

            if (Dir != Direction.Up)
            {
                Dir = Direction.Up;
                ResetArrowButtonColor();
                ButtonUp.BackColor = Color.Gold;
            }

            panelArrows.Focus();

        }

        private void btnDown(object sender, EventArgs e)
        {
            numY.Value += Step;

            MoveIconRelative(cmbIconList.SelectedIndex, (int)numX.Value, (int)numY.Value);
            if (Dir != Direction.Down)
            {
                Dir = Direction.Down;
                ResetArrowButtonColor();
                ButtonDown.BackColor = Color.Gold;
            }




        }

        private void ResetArrowButtonColor()
        {
            ButtonRight.BackColor = Color.WhiteSmoke;
            ButtonLeft.BackColor = Color.WhiteSmoke;
            ButtonUp.BackColor = Color.WhiteSmoke;
            ButtonDown.BackColor = Color.WhiteSmoke;
            ButtonSpace.BackColor = Color.WhiteSmoke;
            panelArrows.Focus();
        }







        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void MarioForm_KeyUp(object sender, KeyEventArgs e)
        {



        }



        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Left)
                ButtonLeft_Click(null, null);

            else if (keyData == Keys.Right)
                ButtonRight_Click(null, null);

            else if (keyData == Keys.Space)
            {

                ButtonSpace_Click(null, null);

            }


            panelArrows.Focus();
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void MarioForm_KeyDown(object sender, KeyEventArgs e)
        {


        }

        private void ButtonUp_Click(object sender, EventArgs e)
        {

        }

        private void ButtonLeft_Click(object sender, EventArgs e)
        {
            numX.Value -= Step;
            MoveIconRelative(cmbIconList.SelectedIndex, (int)numX.Value, (int)numY.Value);
            if (Dir != Direction.Left)
            {
                Dir = Direction.Left;
                if (chkMario.Checked)
                {
                    Properties.Resources.mario_left.Save(MarioPath);
                    DesktopRefresher.RefreshDesktop();
                }

                ResetArrowButtonColor();
                ButtonLeft.BackColor = Color.Gold;
            }
            panelArrows.Focus();


        }

        private void ButtonRight_Click(object sender, EventArgs e)
        {
            numX.Value += Step;

            MoveIconRelative(cmbIconList.SelectedIndex, (int)numX.Value, (int)numY.Value);

            if (Dir != Direction.Right)
            {
                Dir = Direction.Right;
                if (chkMario.Checked)
                {
                    Properties.Resources.mario_right.Save(MarioPath);
                    DesktopRefresher.RefreshDesktop();
                }

                ResetArrowButtonColor();
                ButtonRight.BackColor = Color.Gold;
                ButtonRight.Focus();
            }
            panelArrows.Focus();

        }

        private void numX_ValueChanged(object sender, EventArgs e)
        {
            MoveIconRelative(cmbIconList.SelectedIndex, (int)numX.Value, (int)numY.Value);

        }

        private void numY_ValueChanged(object sender, EventArgs e)
        {
            MoveIconRelative(cmbIconList.SelectedIndex, (int)numX.Value, (int)numY.Value);

        }

        private void MarioForm_Load(object sender, EventArgs e)
        {
            numY.Value = numGround.Value;
            txtDesktopPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            MarioPath = Path.Combine(txtDesktopPath.Text, "mario.png");
            button4_Click_2(sender, e);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmbIconList.Enabled = !cmbIconList.Enabled;
        }

        private void ButtonSpace_Click(object sender, EventArgs e)
        {




            if (numY.Value == numGround.Value)
            {
                panelArrows.Focus();

                ResetArrowButtonColor();
                ButtonSpace.BackColor = Color.Gold;
                Target = (int)numY.Value - (int)numJump.Value;
                if (chkMario.Checked)
                {
                    if (Dir == Direction.Right)
                        Properties.Resources.mario_jump_right.Save(MarioPath);
                    else if (Dir == Direction.Left)
                        Properties.Resources.mario_jump_left.Save(MarioPath);
                    else
                        Properties.Resources.mario_jump_right.Save(MarioPath    );
                }

                timerJump.Enabled = true;

                DesktopRefresher.RefreshDesktop();

            }

        }

        private void timerJump_Tick(object sender, EventArgs e)
        {


            numY.Value -= 5;
            if (numY.Value < Target) // jump ended - grounded
            {
                timerJump.Enabled = false;
                Target = (int)numY.Value + (int)numJump.Value;

                if (chkMario.Checked)
                {
                    if (Dir == Direction.Right)
                        Properties.Resources.mario_right.Save(MarioPath);
                    else if (Dir == Direction.Left)
                        Properties.Resources.mario_left.Save(MarioPath);
                    else
                        Properties.Resources.mario_right.Save(MarioPath);
                }

            }


        }

        private void timerGravity_Tick(object sender, EventArgs e)
        {
            if (numY.Value < numGround.Value && !timerJump.Enabled)
            {
                numY.Value += 6;
                panelArrows.Focus();
                MoveIconRelative(cmbIconList.SelectedIndex, (int)numX.Value, (int)numY.Value);

            }

            if (numY.Value > numGround.Value)
            {
                numY.Value = numGround.Value;
                panelArrows.Focus();
                MoveIconRelative(cmbIconList.SelectedIndex, (int)numX.Value, (int)numY.Value);



                DesktopRefresher.RefreshDesktop();
            }


        }

        private void ButtonDown_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Wallpaper.Set( Properties.Resources.supermario_wallpaper01, Wallpaper.Style.Stretched );
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var open = new FolderBrowserDialog();
            if(open.ShowDialog() == DialogResult.OK)
                txtDesktopPath.Text = open.SelectedPath;
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            var randomName = $"goomba {new Random().Next(111111111, 999999999)}.png";
            Properties.Resources.goomba.Save(Path.Combine(txtDesktopPath.Text,randomName));

            DesktopRefresher.RefreshDesktop();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            WindowsAPI.MoveIconRelative(0, 100, 0);
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            if (button4.Text == "<<")
            {
                this.Width = 864;
                this.Height = 268;
                button4.Text = ">>";
            }
            else
            {
                this.Width = 382;
                this.Height = 198;
                button4.Text = "<<";

            }
        }
    }
}
