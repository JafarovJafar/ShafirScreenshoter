using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace ShafirScreenshoter
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckCfg();
            GetVars();
            TakeScreenshot();
        }

        private static string path = "//192.168.44.32/Users2/Obmen/646/screens/";

        private static void CheckCfg()
        {
            if (!File.Exists("ShafirScreenshoter.cfg"))
            {
                FileStream fileStream = File.Create("ShafirScreenShoter.cfg");
                fileStream.Close();

                StreamWriter streamWriter = new StreamWriter("ShafirScreenshoter.cfg");
                streamWriter.WriteLine(path);
                streamWriter.Close();
            }
        }

        private static void GetVars()
        {
            StreamReader streamReader = new StreamReader("ShafirScreenshoter.cfg");
            path = streamReader.ReadLine();
        }

        private static void TakeScreenshot()
        {
            Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(printscreen as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
            printscreen.Save(path + "1.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}