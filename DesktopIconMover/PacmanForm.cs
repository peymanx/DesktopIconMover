using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
using System.Threading;


namespace DesktopIconMover
{
    public partial class PacmanForm : Form
    {
        public int Step { get; set; } = 25;
        private readonly List<string> iconNames = new List<string>();

        public Direction Dir { get; set; } = Direction.Null;



        private string PacmanFile;
        private string DesktopPath;

        public PacmanForm()
        {
            InitializeComponent();
            DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            PacmanFile = Path.Combine(DesktopPath, "pacman.png");
            Properties.Resources.right.Save(PacmanFile);

            (int Width, int Height) = DisplayResolutionInfo.GetPhysicalScreenResolution();
            canvas = new Bitmap(Width, Height);
            pictureBox1.Image = canvas;
            LoadDesktopIcons();

        }

        Bitmap canvas;
        Brush BrushColor = Brushes.Black;
        int Size = 50;


        private void DrawImageOnCanvas(Image inputImage)
        {
            if (inputImage == null) return;

            using (Graphics g = Graphics.FromImage(canvas))
            {
                // رسم عکس در موقعیت دلخواه، مثلاً بالا-چپ
                g.DrawImage(inputImage, new Rectangle(0, 0, inputImage.Width, inputImage.Height));
                pictureBox1.Image = canvas;

            }

            pictureBox1.Invalidate(); // رفرش تصویر در PictureBox
        }

        private void DrawOn(int x, int y, int w, int h)
        {

            if (chkDotEater.Checked == false) return;
            using (Graphics g = Graphics.FromImage(canvas))
            {
                var rect = new Rectangle(x, y, w, h); // مستطیل مقصد
                g.FillRectangle(BrushColor, rect);
            }

            // قرار دادن تصویر در PictureBox
            pictureBox1.Image = canvas;
            DrawImageOnCanvas(Properties.Resources.Pacman_frame);

            Wallpaper.Set(pictureBox1.Image, Wallpaper.Style.Stretched);


        }

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

            DrawOn((int)numX.Value, (int)numY.Value - 8, Size, Size);

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
            DrawOn((int)numX.Value, (int)numY.Value + 5, Size, Size);


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
            DrawOn((int)numX.Value - 5, (int)numY.Value, Size, Size);


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

            DrawOn((int)numX.Value + 5, (int)numY.Value, Size, Size);

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

        public int CalculateSize()
        {
            return 70;
            return (int)(DesktopIconMetrics.GetDesktopIconSpacing().Value.Height * 1.3);

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = chkLock.Checked;
            cmbIconList.Enabled = !chkLock.Checked;
            ResetArrowButtonColor();



            if (timer1.Enabled) Step = (int)(CalculateSize() / 3);
            else
                Size = CalculateSize();


        }



        private void MainForm_Load(object sender, EventArgs e)
        {
            trackBar1_Scroll(null, null);
            Size = CalculateSize();
            SetDefaultGamePlay();
            ResetPlayer();


            new Task(() =>
            {
                Thread.Sleep(2000);
                LoadDesktopIcons();
                btnRight(sender, e);

            }).Start();


            Minimize(sender, e);

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
            timer1.Interval = trackBar1.Value * 7;
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
            var randomName = $"ghost_{new Random().Next(1111, 9999)}.png";
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

        private void Minimize(object sender, EventArgs e)
        {
            if (button3.Text == "<<")
            {
                this.Width = 660;
                this.Height = 404;
                button3.Text = ">>";
            }
            else
            {
                this.Width = 336;
                this.Height = 213;
                button3.Text = "<<";

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SetDefaultGamePlay();

        }

        private void SetDefaultGamePlay()
        {
            DrawImageOnCanvas(Properties.Resources.Pacman_frame);
            DrawImageOnCanvas(Properties.Resources.Pacman_dots);

            Wallpaper.Set(pictureBox1.Image, Wallpaper.Style.Stretched);
        }

        private void PacmanForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ResetPlayer();

        }

        private void ResetPlayer()
        {

            Properties.Resources.right.Save(PacmanFile);
            DesktopRefresher.HardRefresh();
            Properties.Resources.right.Save(PacmanFile);
            LoadDesktopIcons();
        }

        private void chkDebug_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDebug.Checked)
            {
                BrushColor = Brushes.Lime;
            }
            else
                BrushColor = Brushes.Black;

        }
    }
}
