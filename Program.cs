using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

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


        private static string cfgFileName = "ShafirScreenshoter.cfg";
        private static string path = "//192.168.44.32/Users2/Obmen/646/screens/";

        private static void CheckCfg()
        {
            if (!File.Exists(cfgFileName))
            {
                FileStream fileStream = File.Create(cfgFileName);
                fileStream.Close();

                StreamWriter streamWriter = new StreamWriter(cfgFileName);
                streamWriter.WriteLine(path);
                streamWriter.Close();
            }
        }

        private static void GetVars()
        {
            StreamReader streamReader = new StreamReader(cfgFileName);
            path = streamReader.ReadLine();
        }

        private static void TakeScreenshot()
        {
            string fileName = DateTime.Now.ToString();
            fileName = fileName.Replace(':', '_');

            Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(printscreen);
            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
            printscreen.Save(path + $"{fileName}.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}