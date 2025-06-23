using System;
using System.Drawing;
using System.Windows.Forms;

public class MyForm : Form
{
    private PictureBox pictureBox;

    public MyForm()
    {
        this.Text = "رسم مستطیل ساده";
        this.Width = 400;
        this.Height = 300;

        pictureBox = new PictureBox();
        pictureBox.Dock = DockStyle.Fill;
        this.Controls.Add(pictureBox);

        // بوم نقاشی
        Bitmap bmp = new Bitmap(400, 300);
        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.Clear(Color.White); // پس‌زمینه سفید

            // مستطیل تو پر قرمز
            g.FillRectangle(Brushes.Red, 50, 50, 200, 100);
        }

        // قرار دادن تصویر در PictureBox
        pictureBox.Image = bmp;
    }
}