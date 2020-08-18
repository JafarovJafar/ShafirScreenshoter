using System.Windows.Forms;
using System.Drawing;

namespace ShafirScreenshoter
{
    class Program
    {
        static void Main(string[] args)
        {
            TakeScreenshot();
        }

        private static void TakeScreenshot()
        {
            Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(printscreen as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
            printscreen.Save("1.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}