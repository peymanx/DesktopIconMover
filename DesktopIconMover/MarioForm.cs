using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopIconMover
{
    public partial class MarioForm : Form
    {
        public MarioForm()
        {
            InitializeComponent();
            txtDesktopPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            MarioPath = Path.Combine(txtDesktopPath.Text, "mario.png");
            Ground = (int)numGround.Value;


        }

        public int Step { get; set; } = 20;
        public int Ground { get; set; }
        public string MarioPath { get; set; }

        public bool Grounded
        {
            get
            {
                if (timerJump.Enabled) return false;
                return !Falling;
            }
        }
        public bool Falling
        {
            get
            {
                if (numY.Value < Ground) return true;
                return false;
            }
        }

        public int Target { get; set; }
        private readonly List<string> iconNames = new List<string>();


        public Direction Dir { get; set; } = Direction.Null;

        private void LoadDesktopIcons()
        {
            iconNames.Clear();
            cmbIconList.Items.Clear();

            IntPtr hwndListView = WindowsAPI.GetDesktopListView();
            if (hwndListView == IntPtr.Zero) return;

            int count = WindowsAPI.SendMessage(hwndListView, WindowsAPI.LVM_GETITEMCOUNT, 0, IntPtr.Zero);
            StringBuilder itemText = new StringBuilder(256);

            for (int i = 0; i < count; i++)
            {
                // SendMessage2(hwndListView, LVM_GETITEMTEXT, (IntPtr)i, itemText);
                string iconName = "آیکون شماره " + (i+1);
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
            WindowsAPI.SendMessage(hwndListView, WindowsAPI.LVM_SETITEMPOSITION, (IntPtr)iconIndex, lParam);

            Console.WriteLine($"آیکون {iconIndex} به مکان جدید ({newX}, {newY}) منتقل شد.");
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
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




        private void MarioForm_KeyUp(object sender, KeyEventArgs e)
        {



        }



        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (chkDebug.Checked) return false;
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


            UpdateGroundLeft();

            if (Grounded)
                numX.Value -= Step;
            else
                numX.Value -= (Step / 4);

            MoveIconRelative(cmbIconList.SelectedIndex, (int)numX.Value, (int)numY.Value);
            if (Dir != Direction.Left)
            {
                Dir = Direction.Left;
                if (chkMario.Checked)
                {
                    Properties.Resources.mario_left.Save(MarioPath);
                    if (chkHardRefresh.Checked)
                        DesktopRefresher.HardRefresh();
                    else
                        DesktopRefresher.RefreshDesktop();
                }

                ResetArrowButtonColor();
                ButtonLeft.BackColor = Color.Gold;
            }
            panelArrows.Focus();


        }

        private void ButtonRight_Click(object sender, EventArgs e)
        {

            UpdateGroundRight();
            if (Grounded)
                numX.Value += Step;
            else
                numX.Value += (Step / 4);

            MoveIconRelative(cmbIconList.SelectedIndex, (int)numX.Value, (int)numY.Value);

            if (Dir != Direction.Right)
            {
                Dir = Direction.Right;
                if (chkMario.Checked)
                {
                    Properties.Resources.mario_right.Save(MarioPath);
                    if (chkHardRefresh.Checked)
                        DesktopRefresher.HardRefresh();
                    else
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
            (int Width, int Height) = DisplayResolutionInfo.GetPhysicalScreenResolution();
            canvas = new Bitmap(Width, Height);
            image = canvas;

            Minimize(sender, e);

            ResetPlayer();
            new Task(() =>
            {
                Thread.Sleep(2000);
                LoadDesktopIcons();
                ButtonRight_Click(null, null);

            }).Start();
            SetDesktopBackground(sender, e);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResetPlayer();
        }

        private void ResetPlayer()
        {
            Properties.Resources.mario_right.Save(MarioPath);
            Properties.Resources.mario_right.Save(MarioPath);
            LoadDesktopIcons();
            numY.Value = 0;
            DesktopRefresher.HardRefresh();
        }

        private void ButtonSpace_Click(object sender, EventArgs e)
        {

            if (numY.Value >= Ground)
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
                        Properties.Resources.mario_jump_right.Save(MarioPath);
                }

                timerJump.Enabled = true;

                if (chkHardRefresh.Checked)
                    DesktopRefresher.HardRefresh();
                else
                    DesktopRefresher.RefreshDesktop();

            }

        }

        private void timerJump_Tick(object sender, EventArgs e)
        {


            numY.Value -= 5;
            if (numY.Value < Target) // jump ended - grounded
            {
                timerJump.Enabled = false;

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

            if (Falling && !timerJump.Enabled)

            {
                numY.Value += 6;
                panelArrows.Focus();
                MoveIconRelative(cmbIconList.SelectedIndex, (int)numX.Value, (int)numY.Value);
            }
            return;



        }

        private void ButtonDown_Click(object sender, EventArgs e)
        {

        }

        private void SetDesktopBackground(object sender, EventArgs e)
        {
            Wallpaper.Set(Properties.Resources.supermario_wallpaper01, Wallpaper.Style.Stretched);
            CurrentWallpaper = Properties.Resources.supermario_wallpaper01;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            var open = new FolderBrowserDialog();
            if (open.ShowDialog() == DialogResult.OK)
                txtDesktopPath.Text = open.SelectedPath;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var randomName = $"goomba_{new Random().Next(1111, 9999)}.png";
            Properties.Resources.goomba.Save(Path.Combine(txtDesktopPath.Text, randomName));
            if (chkHardRefresh.Checked)
                DesktopRefresher.HardRefresh();
            else
                DesktopRefresher.RefreshDesktop();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            WindowsAPI.MoveIconRelative(0, 100, 0);
        }

        private void Minimize(object sender, EventArgs e)
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
                chkDebug.Checked = false;

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var rand = new Random().Next(1111, 9999);
            var randomName = $"koopa_{rand}.png";
            if (rand % 2 == 0)
                Properties.Resources.koopa_red.Save(Path.Combine(txtDesktopPath.Text, randomName));
            else
                Properties.Resources.koopa_green.Save(Path.Combine(txtDesktopPath.Text, randomName));

            if (chkHardRefresh.Checked)
                DesktopRefresher.HardRefresh();
            else
                DesktopRefresher.RefreshDesktop();

        }

        private void MarioForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerGravity.Enabled = timerJump.Enabled = false;
        }

        private void numGround_ValueChanged(object sender, EventArgs e)
        {
            UpdateGround();
            if (numY.Value > numGround.Value) numY.Value = 1;
            if (chkDebug.Checked) DrawOn();
        }
        Image CurrentWallpaper;
        private void button6_Click(object sender, EventArgs e)
        {
            Wallpaper.Set(Properties.Resources.Mario_cloud, Wallpaper.Style.Stretched);
            CurrentWallpaper = Properties.Resources.Mario_cloud;

        }

        public void UpdateGround()
        {
            Ground = (int)numGround.Value;
            if (numX.Value > numSep1.Value)
                Ground = (int)numGround2.Value;
            if (numX.Value > numSep2.Value)
                Ground = (int)numGround3.Value;

        }

        public void UpdateGroundRight()
        {
            Ground = (int)numGround.Value;
            if (numX.Value > numSep1.Value - 20)
                Ground = (int)numGround2.Value;
            if (numX.Value > numSep2.Value - 20)
                Ground = (int)numGround3.Value;

        }


        public void UpdateGroundLeft()
        {

            Ground = (int)numGround.Value;
            if (numX.Value - icon_height / 2 > numSep1.Value)
                Ground = (int)numGround2.Value;
            if (numX.Value - icon_height / 2 > numSep2.Value)
                Ground = (int)numGround3.Value;

        }


        Bitmap canvas;
        Image image;

        private void DrawImageOnCanvas(Image inputImage)
        {
            if (inputImage == null) return;

            using (Graphics g = Graphics.FromImage(canvas))
            {
                // رسم عکس در موقعیت دلخواه، مثلاً بالا-چپ
                g.DrawImage(inputImage, new Rectangle(0, 0, inputImage.Width, inputImage.Height));
                image = canvas;

            }


        }
        int icon_height = 100;

        private void DrawOn()
        {
            DrawImageOnCanvas(CurrentWallpaper);
            (int w, int h) = DisplayResolutionInfo.GetPhysicalScreenResolution();

            int g1 = (int)numGround.Value;
            int g2 = (int)numGround2.Value;
            int g3 = (int)numGround3.Value;

            int s1 = (int)numSep1.Value;
            int s2 = (int)numSep2.Value;


            using (Graphics g = Graphics.FromImage(canvas))
            {
                var rect = new Rectangle(0, 0, s1, g1); // مستطیل مقصد
                g.DrawRectangle(new Pen(Color.Black), rect);
                rect = new Rectangle(0, 0, s1, g1 + icon_height); // مستطیل مقصد
                g.DrawRectangle(new Pen(Color.Black), rect);

                rect = new Rectangle(s1, g2, w - s2 - icon_height * 2, h - g2); // مستطیل مقصد
                g.DrawRectangle(new Pen(Color.Yellow), rect);
                rect = new Rectangle(s1, g2 + icon_height, w - s2 - icon_height * 2, h - g2); // مستطیل مقصد
                g.DrawRectangle(new Pen(Color.Yellow), rect);

                rect = new Rectangle(s2, g3, w - s2, h - g3); // مستطیل مقصد
                g.DrawRectangle(new Pen(Color.Red), rect);
                rect = new Rectangle(s2, g3 + icon_height, w - s2, h - g3); // مستطیل مقصد
                g.DrawRectangle(new Pen(Color.Red), rect);

            }

            // قرار دادن تصویر در PictureBox
            image = canvas;

            Wallpaper.Set(image, Wallpaper.Style.Stretched);


        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (chkDebug.Checked==false)
            {
                numX.Value = 200;
                numGround.Value = numGround3.Value = 806;
                numGround2.Value = 1050;
                numSep1.Value = 1578;
                numSep2.Value = 1650;
                chkDebug.Checked = true;
            }
            else
            {
                chkDebug.Checked = true;
            }

            UpdateGround();
            DrawOn();
        }




        private void numGround2_ValueChanged(object sender, EventArgs e)
        {
            chkDebug.Checked = true;
            UpdateGround();
            DrawOn();
        }

        private void numGround3_ValueChanged(object sender, EventArgs e)
        {
            chkDebug.Checked = true;

            UpdateGround();
            DrawOn();
        }

        private void numSep1_ValueChanged(object sender, EventArgs e)
        {
            UpdateGround();

            DrawOn();
        }

        private void numSep2_ValueChanged(object sender, EventArgs e)
        {
            UpdateGround();

            DrawOn();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            TopMost = false;
            new Task(() =>

            MessageBox.Show("من نقش زمان بازی رو دارم", "پیام", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)).Start();
        }
    }
}
