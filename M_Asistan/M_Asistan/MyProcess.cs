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
    class MyProcess
    {
        public int tamekran = 0;

        public static MyProcess myprocess;

        public MyProcess()
        {
            myprocess = this;
        }


        public void OpenHaxballHeadless()
        {



        }

        public void DiziboxReklamGec() {

            MyTimers.myTimers.WaitFun(5000,"DiziboxReklamGec1",1,7000,5);

            }
        public void DiziboxReklamGec1()
        {
            Debug("Reklam1");
            if (MyTimers.myTimers.GetTimerName("DiziboxReklamGec1"))
            {
                Debug("Reklam1içi");
                if (DiziboxReklamAra())
                {
                    MyTimers.myTimers.SetTimerDisable("DiziboxReklamGec1");
                    PcProcess.DoMouseClick();
                  
                    MyTimers.myTimers.WaitFun(5000, "DiziboxReklamGec2", 1,1000,1);
                }
            }
        }

        public void DiziboxReklamGec2()
        {
           
                Debug("Reklam2içi");
               
                    MyTimers.myTimers.SetTimerDisable("DiziboxReklamGec2");
                    PcProcess.DoMouseClick();

            MyTimers.myTimers.WaitFun(1500, "DiziboxReklamGec3", 1, 1000, 1);


        }
        public void DiziboxReklamGec3()
        {
            Debug("Reklam3");
           
                Debug("Reklam3içi");
            MyTimers.myTimers.SetTimerDisable("DiziboxReklamGec3");

            if (DiziboxFilmiBaslatAra())
                {
                   
                    PcProcess.DoMouseClick();

                Speak.speak.DebugSpeek("The series started");
                MyTimers.myTimers.WaitFun(1000, "DiziboxFilmDevamKontrol", 1, 1000, 1);
                


                }
            
        }

        public void DiziboxFilmDevamKontrol()
        {
            MyTimers.myTimers.SetTimerDisable("DiziboxFilmDevamKontrol");

            if (DiziboxFilmDevamKontrolAra())
            {
                PcProcess.DoMouseClick();
                Speak.speak.DebugSpeek("The series started");
               // MyTimers.myTimers.WaitFun(1000, "DiziboxTamEkranAc", 1, 1000, 1);

            }
            else
            {
               // MyTimers.myTimers.WaitFun(1000, "DiziboxTamEkranAc", 1, 1000, 1);
            }
        }

        public void DiziboxOncekiBolum()
        {
            if (tamekran == 1) { TamEkrandanCik(); }
            MyTimers.myTimers.SetTimerDisable("DiziboxOncekiBolum");

            if (DiziboxOrtakResimAra("Önceki Bölüm"))
            {
                PcProcess.DoMouseClick();
                Speak.speak.DebugSpeek("previous chapter opening");
                MyTimers.myTimers.WaitFun(1000, "DiziboxReklamGec", 1, 1000, 1);

            }
            
        }
        public void DiziboxSonrakiBolum()
        {
            //gectiği bölüm kaydet
            if (tamekran == 1) { TamEkrandanCik(); }

            MyTimers.myTimers.SetTimerDisable("DiziboxSonrakiBolum");

            if (DiziboxOrtakResimAra("Sonraki Bölüm"))
            {
                PcProcess.DoMouseClick();
                Speak.speak.DebugSpeek("next chapter opening");
                MyTimers.myTimers.WaitFun(1000, "DiziboxReklamGec", 1, 1000, 1);

            }

        }

        public void DiziboxTamEkranAc()
        {
            MyTimers.myTimers.SetTimerDisable("DiziboxTamEkranAc");

            if (DiziboxTamEkranAra())
            {
                tamekran = 1;
                System.Threading.Thread.Sleep(300);
                PcProcess.DoMouseClick();


            }
        }

        public void TamEkrandanCik()
        {
            tamekran = 0;
            SendKeys.Send("{F11}");
        }
        public void DiziAc(string diziismi)
        {


        }

       public void DiziBox()
        {
            LinkAc("https://www.dizibox.tv/forever-1-sezon-17-bolum-izle/");
            DiziboxReklamGec();

        }
        public void LinkAc(string link)
        {
            Process.Start(link);
        }


        public bool DiziboxReklamBul(Bitmap ekrangoruntusu, Bitmap resim)
        {
            Rectangle rect = PcProcess.pcProcess.FindImageOnScreen(resim, ekrangoruntusu, false);


            if (rect != Rectangle.Empty)//Image Foud
            {
                Speak.speak.DebugSpeek("ad finded");
                Point cntr = new Point(rect.X + System.Convert.ToInt32(rect.Width / (double)2), rect.Y + System.Convert.ToInt32(rect.Height / (double)2));
                Cursor.Position = cntr;
                Debug(rect.ToString());
                return true;

            }
            else
            {
                Debug("Image not found ");
                return false;

            }

        }
        public bool DiziboxDevamKontrolBul(Bitmap ekrangoruntusu, Bitmap resim)
        {
            Rectangle rect = PcProcess.pcProcess.FindImageOnScreen(resim, ekrangoruntusu, false);


            if (rect != Rectangle.Empty)//Image Foud
            {
                Speak.speak.DebugSpeek("button finded");
                Point cntr = new Point(rect.X + System.Convert.ToInt32(rect.Width / (double)2), rect.Y + System.Convert.ToInt32(rect.Height / (double)2));
                Cursor.Position = cntr;
                Debug(rect.ToString());
                return true;

            }
            else
            {
                Debug("Image not found ");
                return false;

            }

        }
        public bool DiziboxTamEkranBul(Bitmap ekrangoruntusu, Bitmap resim)
        {
            Rectangle rect = PcProcess.pcProcess.FindImageOnScreen(resim, ekrangoruntusu, false);


            if (rect != Rectangle.Empty)//Image Foud
            {
                Speak.speak.DebugSpeek("full screen finded");
                Point cntr = new Point(rect.X + System.Convert.ToInt32(rect.Width-100), rect.Y - System.Convert.ToInt32(rect.Height));
                Cursor.Position = cntr;
                Debug(rect.ToString());
                return true;

            }
            else
            {
                Debug("Image not found ");
                return false;

            }

        }
        public bool DiziboxFilmiBaslatBul(Bitmap ekrangoruntusu, Bitmap resim)
        {
            Rectangle rect = PcProcess.pcProcess.FindImageOnScreen(resim, ekrangoruntusu, false);


            if (rect != Rectangle.Empty)//Image Foud
            {
                Speak.speak.DebugSpeek("start finded");
                Point cntr = new Point(rect.X + System.Convert.ToInt32(rect.Width / (double)2), rect.Y + System.Convert.ToInt32(rect.Height / (double)2));
                Cursor.Position = cntr;
                Debug(rect.ToString());
                return true;

            }
            else
            {
                Debug("Image not found ");
                return false;

            }

        }

        public bool DiziboxOrtakResimBul(Bitmap ekrangoruntusu, Bitmap resim,string tur)
        {
            Rectangle rect = PcProcess.pcProcess.FindImageOnScreen(resim, ekrangoruntusu, false);


            if (rect != Rectangle.Empty)//Image Foud
            {
                 Speak.speak.DebugSpeek("image finded");
               
                Point cntr = new Point(rect.X + System.Convert.ToInt32(rect.Width / (double)2), rect.Y + System.Convert.ToInt32(rect.Height / (double)2));
                Cursor.Position = cntr;
                Debug(rect.ToString());
                return true;

            }
            else
            {
                Debug("Image not found ");
                return false;

            }

        }

        public int ForDolu = 0;
        public bool DiziboxReklamAra()
        {
            if (ForDolu == 0)
            {
                ForDolu = 1;


                Speak.speak.DebugSpeek("Try to find ad");
                Bitmap reklam10 = Resources.DiziboxReklam10;
                Bitmap reklam9 = Resources.DiziboxReklam9;
                Bitmap reklam8 = Resources.DiziboxReklam8;
                Bitmap reklam7 = Resources.DiziboxReklam7;
                Bitmap reklam6 = Resources.DiziboxReklam6;
                Bitmap reklam5 = Resources.DiziboxReklam5;
                Bitmap reklam4 = Resources.DiziboxReklam4;
                Bitmap reklam3 = Resources.DiziboxReklam3;
                Bitmap reklam2 = Resources.DiziboxReklam2;
                Bitmap reklam1 = Resources.DiziboxReklam1;
                Bitmap reklam0 = Resources.DiziboxReklam0;
                Bitmap ekrangoruntusu = PcProcess.pcProcess.GetScreenCapture();


                for (int i = 10; i >= 0; i--)
                {
                    if (i == 10)
                    {
                        if (DiziboxReklamBul(ekrangoruntusu, reklam10)) { Debug("10. Resim Bulundu"); ForDolu = 0; return true; }
                    }
                    if (i == 9)
                    {
                        if (DiziboxReklamBul(ekrangoruntusu, reklam9)) { Debug("9. Resim Bulundu"); ForDolu = 0; return true; }
                    }
                    if (i == 8)
                    {
                        if (DiziboxReklamBul(ekrangoruntusu, reklam8)) { Debug("8. Resim Bulundu"); ForDolu = 0; return true; }
                    }
                    if (i == 7)
                    {
                        if (DiziboxReklamBul(ekrangoruntusu, reklam7)) { Debug("7. Resim Bulundu"); ForDolu = 0; return true; }
                    }
                    if (i == 6)
                    {
                        if (DiziboxReklamBul(ekrangoruntusu, reklam6)) { Debug("6. Resim Bulundu"); ForDolu = 0; return true; }
                    }
                    if (i == 5)
                    {
                        if (DiziboxReklamBul(ekrangoruntusu, reklam5)) { Debug("5. Resim Bulundu"); ForDolu = 0; return true; }
                    }
                    if (i == 4)
                    {
                        if (DiziboxReklamBul(ekrangoruntusu, reklam4)) { Debug("4. Resim Bulundu"); ForDolu = 0; return true; }
                    }
                    if (i == 3)
                    {
                        if (DiziboxReklamBul(ekrangoruntusu, reklam3)) { Debug("3. Resim Bulundu"); ForDolu = 0; return true; }
                    }
                    if (i == 2)
                    {
                        if (DiziboxReklamBul(ekrangoruntusu, reklam2)) { Debug("2. Resim Bulundu"); ForDolu = 0; return true; }
                    }
                    if (i == 1)
                    {
                        if (DiziboxReklamBul(ekrangoruntusu, reklam1)) { Debug("1. Resim Bulundu"); ForDolu = 0; return true; }
                    }
                    if (i == 0)
                    {
                        if (DiziboxReklamBul(ekrangoruntusu, reklam0)) { Debug("0. Resim Bulundu"); ForDolu = 0; return true; }
                    }


                }
                ForDolu = 0;
            }
            return false;
        }


        public bool DiziboxFilmiBaslatAra()
        {
           


                Speak.speak.DebugSpeek("Try to find Start Button");
             
                Bitmap dizibaslat = Resources.DiziboxDiziBaslat;
                Bitmap ekrangoruntusu = PcProcess.pcProcess.GetScreenCapture();


               
    if (DiziboxFilmiBaslatBul(ekrangoruntusu, dizibaslat)) { Debug("Film Başlatılıyor"); return true; }

            Debug("Bulunamadı");
                
               
            
            return false;
        }


        public bool DiziboxTamEkranAra()
        {



            Speak.speak.DebugSpeek("Try to find full screen");

            Bitmap dizitamekran = Resources.diziboxoncekisonraki_1_;
            Bitmap ekrangoruntusu = PcProcess.pcProcess.GetScreenCapture();



            if (DiziboxTamEkranBul(ekrangoruntusu, dizitamekran)) { Debug("Tam Ekran Yapılıyor"); return true; }

            Debug("Bulunamadı");



            return false;
        }

        public bool DiziboxFilmDevamKontrolAra()
        {



            Speak.speak.DebugSpeek("Try to find continious");

            Bitmap dizitamekran = Resources.devamet_1_;
            Bitmap ekrangoruntusu = PcProcess.pcProcess.GetScreenCapture();



            if (DiziboxDevamKontrolBul(ekrangoruntusu, dizitamekran)) { Debug("Devam Ettiriliyor"); return true; }

            Debug("Bulunamadı");



            return false;
        }

        public bool DiziboxOrtakResimAra(string tur)
        {
            Bitmap diziortakresim= Resources.DiziboxOncekiBolum;

            if (tur=="Önceki Bölüm")
            {
                Speak.speak.DebugSpeek("Try to find previous button");
                diziortakresim = Resources.DiziboxOncekiBolum;
            }
            if (tur == "Sonraki Bölüm")
            {
                Speak.speak.DebugSpeek("Try to find next button");
                diziortakresim = Resources.DiziboxSonrakiBolum;
            }



            Bitmap ekrangoruntusu = PcProcess.pcProcess.GetScreenCapture();



            if (DiziboxOrtakResimBul(ekrangoruntusu, diziortakresim, tur)) { Debug("Resim Bulunuyor"); return true; }

            Debug("Bulunamadı");



            return false;
        }



        public void Debug(string text)
        {
            Form1.form1.Debug(text);
        }




    }
}
