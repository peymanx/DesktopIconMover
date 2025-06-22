using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace DesktopIconMover
{
    public partial class MainForm : Form
    {
        public int Step { get; set; } = 25;
        private readonly List<string> iconNames = new List<string>();

        public enum Direction { Up, Left, Right, Down, Null };

        public Direction Dir { get; set; } = Direction.Null;



        private string PacmanFile;
        private string DesktopPath;

        public MainForm()
        {
            InitializeComponent();

            LoadDesktopIcons();
        }


        private void LoadDesktopIcons()
        {
            cmbIconList.Items.Clear();

            IntPtr hwndListView = WindowsAPI.GetDesktopListView();
            if (hwndListView == IntPtr.Zero) return;

            int count = WindowsAPI.SendMessage(hwndListView, WindowsAPI.LVM_GETITEMCOUNT, 0, IntPtr.Zero);
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
            IntPtr hwndListView = WindowsAPI.GetDesktopListView();
            if (hwndListView == IntPtr.Zero) return;

            int posData = WindowsAPI.SendMessage(hwndListView, WindowsAPI.LVM_GETITEMPOSITION, iconIndex, IntPtr.Zero);

            int currentX = posData & 0xFFFF;
            int currentY = (posData >> 16) & 0xFFFF;

            int newX = currentX + dx;
            int newY = currentY + dy;

            IntPtr lParam = (IntPtr)((newY << 16) | (newX & 0xFFFF));
            WindowsAPI.SendMessage(hwndListView, WindowsAPI.LVM_SETITEMPOSITION, iconIndex, lParam);

            Console.WriteLine($"آیکون {iconIndex} به مکان جدید ({newX}, {newY}) منتقل شد.");
        }


        private void BtnMoveIcon_Click(object sender, EventArgs e)
        {
            if (cmbIconList.SelectedIndex == -1) return;

            int selectedIndex = cmbIconList.SelectedIndex;
            IntPtr hwndListView = WindowsAPI.GetDesktopListView();
            if (hwndListView == IntPtr.Zero) return;

            IntPtr lParam = (IntPtr)(((int)numY.Value << 16) | ((int)numX.Value & 0xFFFF));
            WindowsAPI.SendMessage(hwndListView, WindowsAPI.LVM_SETITEMPOSITION, selectedIndex, lParam);


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
                if (chkHardRefresh.Checked)
                    DesktopRefresher.HardRefresh();
                else
                    DesktopRefresher.RefreshDesktop();


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
                if (chkHardRefresh.Checked)
                    DesktopRefresher.HardRefresh();
                else
                    DesktopRefresher.RefreshDesktop();


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
                if (chkHardRefresh.Checked)
                    DesktopRefresher.HardRefresh();
                else
                    DesktopRefresher.RefreshDesktop();

            }

            if (chkPortal.Checked)
            {
                var space = DesktopIconMetrics.GetDesktopIconSpacing();
                if (space.HasValue)
                {
                    if (numX.Value < -space.Value.Width)
                    {
                        var w = DisplayResolutionInfo.GetPhysicalScreenResolution().Width;
                        numX.Value = w;
                    }
                }

            }


        }

        private void btnRight(object sender, EventArgs e)
        {
            numX.Value += Step;

            MoveIconRelative(cmbIconList.SelectedIndex, (int)numX.Value, (int)numY.Value);

            if (Dir != Direction.Right)
            {
                Dir = Direction.Right;
                if (chkPacman.Checked)
                    Properties.Resources.right.Save(PacmanFile);
                ResetArrowButtonColor();
                ButtonRight.BackColor = Color.Gold;
                ButtonRight.Focus();
                if (chkHardRefresh.Checked)
                    DesktopRefresher.HardRefresh();
                else
                    DesktopRefresher.RefreshDesktop();

            }

            if (chkPortal.Checked)
            {

                var space = DesktopIconMetrics.GetDesktopIconSpacing();
                if (space.HasValue)
                {
                    var w = DisplayResolutionInfo.GetPhysicalScreenResolution().Width;

                    if (numX.Value > w + space.Value.Width)
                    {
                        numX.Value = 0 - space.Value.Width / 2;
                    }

                }

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
            trackBar1_Scroll(null, null);
            DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            PacmanFile = Path.Combine(DesktopPath, "pacman.png");

            button3_Click(sender, e);
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
            lblSpeed.Text = (trackBar1.Maximum - trackBar1.Value + 1).ToString();
            if (timer1.Enabled) timer1_Tick(sender, e);
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
        int ghost = 0;
        private void button2_Click_1(object sender, EventArgs e)
        {
            var randomName = $"ghost {new Random().Next(1111, 9999)}.png";
            var image = Properties.Resources.ghost_blue;


            ghost = ++ghost % 3;
            switch (ghost)
            {
                case 0:
                    image = Properties.Resources.ghost_pink;
                    break;
                case 1:
                    image = Properties.Resources.ghost_blue;
                    break;
                case 2:
                    image = Properties.Resources.ghost_yellow;
                    break;
                default:
                    break;
            }

            image.Save(Path.Combine(DesktopPath, randomName));

            if (chkHardRefresh.Checked)
                DesktopRefresher.HardRefresh();
            else
                DesktopRefresher.RefreshDesktop();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "<<")
            {
                this.Width = 650;
                this.Height = 346;
                button3.Text = ">>";
            }
            else
            {
                this.Width = 338;
                this.Height = 165;
                button3.Text = "<<";

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Wallpaper.Set(Properties.Resources.pacman_wallpaper, Wallpaper.Style.Stretched);

        }
    }
}
