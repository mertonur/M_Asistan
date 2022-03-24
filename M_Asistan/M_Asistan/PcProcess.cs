using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Threading;
using System.Diagnostics;
using M_Asistan.Properties;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Timers;
namespace M_Asistan
{
    class PcProcess
    {

        public static PcProcess pcProcess;

        public PcProcess()
        {
            pcProcess = this;
        }

        public Rectangle FindImageOnScreen(Bitmap bmpMatch, Bitmap screenCapture, bool ExactMatch)
        {
            Rectangle rct = Rectangle.Empty;
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                Bitmap ScreenBmp = screenCapture;



                BitmapData ImgBmd = bmpMatch.LockBits(new Rectangle(0, 0, bmpMatch.Width, bmpMatch.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData ScreenBmd = ScreenBmp.LockBits(new Rectangle(0, 0, ScreenBmp.Width, ScreenBmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                byte[] ImgByts = new byte[(Math.Abs(ImgBmd.Stride) * bmpMatch.Height) - 1 + 1];
                byte[] ScreenByts = new byte[(Math.Abs(ScreenBmd.Stride) * ScreenBmp.Height) - 1 + 1];

                Marshal.Copy(ImgBmd.Scan0, ImgByts, 0, ImgByts.Length);
                Marshal.Copy(ScreenBmd.Scan0, ScreenByts, 0, ScreenByts.Length);

                bool FoundMatch = false;
             
                int sindx, iindx;
                int spc, ipc;

                int skpx = System.Convert.ToInt32((bmpMatch.Width - 1) / (double)10);
                if (skpx < 1 | ExactMatch)
                    skpx = 1;
                int skpy = System.Convert.ToInt32((bmpMatch.Height - 1) / (double)10);
                if (skpy < 1 | ExactMatch)
                    skpy = 1;

                for (int si = 0; si <= ScreenByts.Length - 1; si += 3)
                {
                    FoundMatch = true;
                    for (int iy = 0; iy <= ImgBmd.Height - 1; iy += skpy)
                    {
                        for (int ix = 0; ix <= ImgBmd.Width - 1; ix += skpx)
                        {
                            sindx = (iy * ScreenBmd.Stride) + (ix * 3) + si;
                            iindx = (iy * ImgBmd.Stride) + (ix * 3);
                            spc = Color.FromArgb(ScreenByts[sindx + 2], ScreenByts[sindx + 1], ScreenByts[sindx]).ToArgb();
                            ipc = Color.FromArgb(ImgByts[iindx + 2], ImgByts[iindx + 1], ImgByts[iindx]).ToArgb();
                            if (spc != ipc)
                            {
                                FoundMatch = false;
                                iy = ImgBmd.Height - 1;
                                ix = ImgBmd.Width - 1;
                            }
                        }
                    }
                    if (FoundMatch)
                    {
                        double r = si / (double)(ScreenBmp.Width * 3);
                        double c = ScreenBmp.Width * (r % 1);
                        if (r % 1 >= 0.5)
                            r -= 1;
                        rct.X = System.Convert.ToInt32(c);
                        rct.Y = System.Convert.ToInt32(r);
                        rct.Width = bmpMatch.Width;
                        rct.Height = bmpMatch.Height;
                        break;
                    }
                }

                bmpMatch.UnlockBits(ImgBmd);
                ScreenBmp.UnlockBits(ScreenBmd);
                //ScreenBmp.Dispose();


                sw.Stop();
                TimeSpan ts = sw.Elapsed;
                Debug(" Süre:" + ts);
                return rct;
            }
            catch(Exception e)
            {
                return rct;
            }
            return rct;

        }

        public Bitmap GetScreenCapture()
        {
            Bitmap screenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            Graphics g = Graphics.FromImage(screenCapture);

            g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                             Screen.PrimaryScreen.Bounds.Y,
                             0, 0,
                             screenCapture.Size,
                             CopyPixelOperation.SourceCopy);
            return screenCapture;
        }




        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public static void DoMouseClick()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        public void SetCursorPosition(int x,int y)
        {
            System.Windows.Forms.Cursor.Position = new Point(x, y);
        }
        private void Debug(string text)
        {
            Form1.form1.Debug(text);
           
        }


    }
}
