using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DesktopIconMover
{
    public partial class DrawForm : Form
    {
        public DrawForm()
        {
            InitializeComponent();
            (int Width, int Height) = DisplayResolutionInfo.GetPhysicalScreenResolution();
            canvas = new Bitmap(Width, Height);
            pictureBox1.Image = canvas;


            DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var icon_size = DesktopIconMetrics.GetDesktopIconSpacing();
            if (icon_size.HasValue)
                Size = icon_size.Value.Width / 2;


        }

        Bitmap canvas;
        public Direction Dir { get; set; } = Direction.Null;
        public string DesktopPath { get; set; }
        Brush BrushColor = Brushes.Red;
        int X = 150;
        int Y = 150;
        int Size = 50;
        public bool PenIsDown { get; set; } = false;

        private readonly List<string> iconNames = new List<string>();

        private void UpdateDesktopBackground(object sender, EventArgs e)
        {
            Wallpaper.Set(pictureBox1.Image, Wallpaper.Style.Stretched);
        }

        private void Red_clicked(object sender, EventArgs e)
        {
            BrushColor = Brushes.Red;
            btnSelectedColor.BackColor = Color.Red;
            ActivePen();

            PencilIconGenerate();
            DesktopRefresher.HardRefresh();

        }

        private void DrawOnScreen()
        {
            if (PenIsDown == false) return;

            using (Graphics g = Graphics.FromImage(canvas))
            {
                // ساخت بافت مربعی
                int squareSize = 10;
                Bitmap pattern = new Bitmap(squareSize, squareSize);
                Rectangle rect = new Rectangle(X, Y, Size, Size); // مستطیل مقصد

                g.FillRectangle(BrushColor, rect);
            }

            // قرار دادن تصویر در PictureBox
            pictureBox1.Image = canvas;
            UpdateDesktopBackground(null, null);


        }

        private void FillBlack()
        {
            // بوم نقاشی

            using (Graphics g = Graphics.FromImage(canvas))
            {

                Rectangle rect = new Rectangle(0, 0, canvas.Width, canvas.Height); // مستطیل مقصد

                g.FillRectangle(Brushes.Black, rect);
            }

            // قرار دادن تصویر در PictureBox
            pictureBox1.Image = canvas;

            UpdateDesktopBackground(null, null);
        }


        private void ResetBrush()
        {
            PencilIconGenerate();
            LoadDesktopIcons();
            PencilIconGenerate();
            DesktopRefresher.HardRefresh();
            ButtonRight_Click(null, null);
        }

        private void DrawForm_Load(object sender, EventArgs e)
        {
            Red_clicked(sender, e);

            Minimize(sender, e);


            new Task(() =>
            {

                Thread.Sleep(2000);
                LoadDesktopIcons();
                ButtonRight_Click(null, null);


                //ResetBrush();

            }).Start();

            //var res = DisplayResolutionInfo.GetPhysicalScreenResolution();
            //this.Location = new Point(res.Width - this.Width, this.Height);
            this.Location = new Point(500, 500);
            FillBlack();


        }

        private void ButtonUp_Click(object sender, EventArgs e)
        {
            Y -= Size;

            MoveIconRelative(cmbIconList.SelectedIndex, X, Y);
            DrawOnScreen();

            if (Dir != Direction.Up)
            {
                ButtonUp.BackColor = Color.Gold;
                ButtonUp.Focus();


            }

            PencilIconGenerate();
            panelArrows.Focus();



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
                string iconName = "آیکون شماره " + (i + 1);
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



        private void ButtonRight_Click(object sender, EventArgs e)
        {
            X += Size;
            MoveIconRelative(cmbIconList.SelectedIndex, X, Y);

            DrawOnScreen();

            if (Dir != Direction.Right)
            {
                Dir = Direction.Right;
                ButtonRight.BackColor = Color.Gold;
                ButtonRight.Focus();
            }
            PencilIconGenerate();
            panelArrows.Focus();


        }
        public Bitmap GrayScaleFilter(Bitmap image)
        {
            Bitmap grayScale = new Bitmap(image.Width, image.Height);

            for (Int32 y = 0; y < grayScale.Height; y++)
                for (Int32 x = 0; x < grayScale.Width; x++)
                {
                    Color c = image.GetPixel(x, y);

                    Int32 gs = (Int32)(c.R * 0.3 + c.G * 0.59 + c.B * 0.11);

                    grayScale.SetPixel(x, y, Color.FromArgb(gs, gs, gs));
                }
            return grayScale;
        }

        private void PencilIconGenerate()
        {
            var pencil_path = Path.Combine(DesktopPath, "pencil.png");

            var pen_image = Properties.Resources.pencil_red;

            if (BrushColor == Brushes.Red)
            {
                pen_image = Properties.Resources.pencil_red;
                

            }
            else if (BrushColor == Brushes.Black)
            {
                pen_image = Properties.Resources.eraser;

            }
            else if (BrushColor == Brushes.Blue)
            {
                pen_image = Properties.Resources.pencil_blue;

            }
            else if (BrushColor == Brushes.Gold)
            {
                pen_image = Properties.Resources.pencil_gold;

            }
            else if (BrushColor == Brushes.Lime)
            {
                pen_image = Properties.Resources.pencil_green;

            }
            else if (BrushColor == Brushes.White)
            {
                pen_image = Properties.Resources.pencil_white;

            }
            if (PenIsDown == false)
            {
              pen_image = RotateBitmap(pen_image, 45);
         

            }
            pen_image.Save(pencil_path);

            ResetArrowButtonColor();
        }


        public Bitmap RotateBitmap(Bitmap bmp, float angle)
        {
            double radianAngle = angle / 180.0 * Math.PI;
            double cosA = Math.Abs(Math.Cos(radianAngle));
            double sinA = Math.Abs(Math.Sin(radianAngle));

            int newWidth = (int)(cosA * bmp.Width + sinA * bmp.Height);
            int newHeight = (int)(cosA * bmp.Height + sinA * bmp.Width);

            var rotatedBitmap = new Bitmap(newWidth, newHeight);
            rotatedBitmap.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);

            using (Graphics g = Graphics.FromImage(rotatedBitmap))
            {
                g.TranslateTransform(rotatedBitmap.Width / 2, rotatedBitmap.Height / 2);
                g.RotateTransform(angle);
                g.TranslateTransform(-bmp.Width / 2, -bmp.Height / 2);
                g.DrawImage(bmp, new Point(0, 0));
            }

            bmp.Dispose();//Remove if you want to keep oryginal bitmap

            return rotatedBitmap;
        }
        private void ResetArrowButtonColor()
        {
            ButtonRight.BackColor = Color.WhiteSmoke;
            ButtonLeft.BackColor = Color.WhiteSmoke;
            ButtonUp.BackColor = Color.WhiteSmoke;
            ButtonDown.BackColor = Color.WhiteSmoke;

            panelArrows.Focus();
        }


        private void ButtonDown_Click(object sender, EventArgs e)
        {
            Y += Size;

            MoveIconRelative(cmbIconList.SelectedIndex, X, Y);
            DrawOnScreen();

            if (Dir != Direction.Down)
            {
                Dir = Direction.Down;
                ButtonDown.BackColor = Color.Gold;
                ButtonDown.Focus();

            }
            PencilIconGenerate();
            panelArrows.Focus();



        }

        private void ButtonLeft_Click(object sender, EventArgs e)
        {
            X -= Size;


            MoveIconRelative(cmbIconList.SelectedIndex, X, Y);
            DrawOnScreen();

            if (Dir != Direction.Left)
            {
                Dir = Direction.Left;
                ButtonLeft.BackColor = Color.Gold;

                ButtonLeft.Focus();
            }
            PencilIconGenerate();
            panelArrows.Focus();



        }

        public void ActivePen()
        {
            //btnPen.BackColor = Color.Gold;
            btnEraser.BackColor = btnClearBoom.BackColor;
        }



        private void BtnPen_Clicked(object sender, EventArgs e)
        {
            PenIsDown = !PenIsDown;

            if (PenIsDown)
            {
                PencilIconGenerate();
                DesktopRefresher.HardRefresh();

                btnPen.Image = Properties.Resources.pen_down;
                toolStat.Text = "مداد فعال است";
                ActivePen();
                DrawOnScreen();

            }
            else
            {
                PencilIconGenerate();
                btnPen.BackColor = btnClearBoom.BackColor;
                btnPen.Image = Properties.Resources.pen_up;
                btnEraser.BackColor = btnClearBoom.BackColor;
                toolStat.Text = "مداد بالا";
                DesktopRefresher.HardRefresh();
            }

        }



        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Left)
                ButtonLeft_Click(null, null);

            else if (keyData == Keys.Right)
                ButtonRight_Click(null, null);
            else if (keyData == Keys.Up)
                ButtonUp_Click(null, null);
            else if (keyData == Keys.Down)
                ButtonDown_Click(null, null);
            else if (keyData == Keys.Space)
                BtnPen_Clicked(null, null);
            else if (keyData == Keys.R)
                Red_clicked(null, null);
            else if (keyData == Keys.G)
                Green_clicked(null, null);
            else if (keyData == Keys.B)
                Blue_Clicked(null, null);
            else if (keyData == Keys.K || keyData == Keys.E)
                Black_Clicked(null, null);
            else if (keyData == Keys.W)
                White_Clicked(null, null);
            else if (keyData == Keys.Y)
                Gold_clicked(null, null);
            else if (keyData == Keys.Escape)
                FillBlack();




            panelArrows.Focus();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Blue_Clicked(object sender, EventArgs e)
        {
            BrushColor = Brushes.Blue;
            btnSelectedColor.BackColor = Color.Blue;
            ActivePen();

            DrawOnScreen();
            PencilIconGenerate();
            DesktopRefresher.HardRefresh();

        }

        private void Green_clicked(object sender, EventArgs e)
        {
            BrushColor = Brushes.Lime;
            btnSelectedColor.BackColor = Color.Lime;
            ActivePen();

            DrawOnScreen();
            PencilIconGenerate();
            DesktopRefresher.HardRefresh();

        }

        private void Black_Clicked(object sender, EventArgs e)
        {
            BrushColor = Brushes.Black;
            btnSelectedColor.BackColor = Color.Black;
            PencilIconGenerate();
            DesktopRefresher.HardRefresh();



        }

        private void White_Clicked(object sender, EventArgs e)
        {
            BrushColor = Brushes.White;
            btnSelectedColor.BackColor = Color.White;
            ActivePen();
            DrawOnScreen();
            PencilIconGenerate();
            DesktopRefresher.HardRefresh();


        }

        private void Gold_clicked(object sender, EventArgs e)
        {
            BrushColor = Brushes.Gold;
            btnSelectedColor.BackColor = Color.Gold;
            ActivePen();

            DrawOnScreen();
            PencilIconGenerate();
            DesktopRefresher.HardRefresh();

        }

        private void Minimize(object sender, EventArgs e)
        {
            if (button4.Text == "<<")
            {
                this.Width = 717;
                this.Height = 310;
                button4.Text = ">>";
            }
            else
            {
                this.Width = 377;
                this.Height = 250;
                button4.Text = "<<";

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FillBlack();
        }

        private void btnEraser_Click(object sender, EventArgs e)
        {
            toolStat.Text = "پاکن کن";
            PenIsDown = true;
            btnPen.BackColor = btnClearBoom.BackColor;
            btnPen.Image = Properties.Resources.pen_down;




            btnEraser.BackColor = Color.Gold;
            btnPen.BackColor = ButtonRight.BackColor;

            BrushColor = Brushes.Black;
            btnSelectedColor.BackColor = Color.Black;
            PencilIconGenerate();
            DrawOnScreen();
            UpdateDesktopBackground(null, null);
            DesktopRefresher.HardRefresh();

        }
        private void LoadImageOntoCanvas(string imagePath)
        {
            try
            {
                using (Image img = Image.FromFile(imagePath))
                {
                    using (Graphics g = Graphics.FromImage(canvas))
                    {
                        // رسم تصویر روی بوم در گوشه بالا چپ، یا می‌تونی اندازه رو مقیاس بدی
                        g.DrawImage(img, new Rectangle(0, 0, canvas.Width, canvas.Height));
                    }

                    pictureBox1.Invalidate(); // رفرش تصویر
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در بارگذاری تصویر: " + ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var open = new OpenFileDialog
            {
                Filter = "عکس|*.jpg;*.png;*.bmp"
            };
            if (open.ShowDialog() == DialogResult.OK)
            {
                LoadImageOntoCanvas(open.FileName);
                UpdateDesktopBackground(sender, e);
            }
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            ResetBrush();
        }
    }
}
