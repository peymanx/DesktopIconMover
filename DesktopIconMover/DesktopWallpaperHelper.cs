using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class DesktopWallpaperHelper
{
    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool SystemParametersInfo(int uAction, int uParam, System.Text.StringBuilder lpvParam, int fuWinIni);

    private const int SPI_GETDESKWALLPAPER = 0x0073;
    private const int MAX_PATH = 260;

    public static Bitmap GetDesktopWallpaperBitmap(int width, int height)
    {
        var sb = new System.Text.StringBuilder(MAX_PATH);
        if (SystemParametersInfo(SPI_GETDESKWALLPAPER, MAX_PATH, sb, 0))
        {
            string path = sb.ToString();

            if (System.IO.File.Exists(path))
            {
                Image img = Image.FromFile(path);
                // resize تصویر زمینه به ابعاد دلخواه
                Bitmap bmp = new Bitmap(width, height);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.DrawImage(img, 0, 0, width, height);
                }
                return bmp;
            }
        }

        return null;
    }
}