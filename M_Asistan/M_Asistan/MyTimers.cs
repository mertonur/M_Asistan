using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace M_Asistan
{
    class MyTimers
    {

        
       public Timer Timer1=new Timer();
        public string Timer1Name="";
        int Timer1Full = 0;
        public int Timer1int =0;
        public int Timer1Finishint = 0;

        static Timer Timer2;
        public string Timer2Name = "";
        int Timer2Full = 0;
        public int Timer2int = 0;
        public int Timer2Finishint = 0;

        static Timer Timer3;
        public string Timer3Name = "";
        int Timer3Full = 0;
        public int Timer3int = 0;
        public int Timer3Finishint = 0;

        static Timer Timer4;
        public string Timer4Name = "";
        int Timer4Full = 0;
        public int Timer4int = 0;
        public int Timer4Finishint = 0;

        static Timer Timer5;
        public string Timer5Name = "";
        int Timer5Full = 0;
        public int Timer5int = 0;
        public int Timer5Finishint = 0;

        static Timer TimerKK;
        public string TimerKKName = "";
        int TimerKKFull = 0;
        public int TimerKKint = 0;
        public int TimerKKFinishint = 0;

        static Timer Wait;
        public string WaitName = "";
        int WaitFull = 0;
        int Waitint = 0;
        public int WaitFinishint = 0;

        int Waitms2 = 0;
        int WaitFinishint2 = 0;

        public static MyTimers myTimers;

        

        public MyTimers()
        {
            myTimers = this;
        }

        public bool GetTimerName(string funname) {

            if (Timer1Name == funname || Timer2Name == funname || Timer3Name == funname || Timer4Name == funname || Timer5Name == funname)
            {
                return true;
            }
            return false;
        }

        int timerint = 0;
        public bool SetTimer(int ms, string funname, int finishint)
        {
            if (Timer1Name==funname|| Timer2Name == funname|| Timer3Name == funname|| Timer4Name == funname|| Timer5Name == funname) {

                Form1.form1.Debug("Bu İşlem Zaten Yapılıyor");
                return false;
            }

            if (Timer1Full == 0)
            {
                SetTimer1(ms, funname, finishint);
            }
            else if (Timer2Full == 0)
            {
                SetTimer2(ms, funname, finishint);
            }
            else if (Timer3Full == 0)
            {
                SetTimer3(ms, funname, finishint);
            }
            else if (Timer4Full == 0)
            {
                SetTimer4(ms, funname, finishint);
            }
            else if (Timer5Full == 0)
            {
                SetTimer5(ms, funname, finishint);
            }
            else
            {
                Form1.form1.Debug("Timer Yeri Yok");
                return false;
            }


            return true;
        }

        public bool SetTimerDisable(string funname)
        {
            Form1.form1.Debug("Disable "+funname);

            if (Timer1Name == funname)
            {
                SetTimer1Disable(); 
            }
            else if (Timer2Name == funname)
            {
                SetTimer2Disable();
            }
            else if (Timer3Name == funname)
            {
                SetTimer3Disable();
            }
            else if (Timer4Name == funname)
            {
                SetTimer4Disable();
            }
            else if (Timer5Name == funname)
            {
                SetTimer5Disable();
            }
            else
            {
                Form1.form1.Debug("Bu İşlem Timerda Yok");
                return false;
            }
            return true;
        }

       
        public bool WaitFun(int ms, string funname, int finishint,int ms2,int finishint2)
        {
            if (WaitFull == 0)
            {
                Wait1(ms, funname, finishint,  ms2,  finishint2);
            }
            else
            {
                Form1.form1.Debug("Wait Yeri Yok");
                return false;
            }
            return true;

        }
       
        private void Wait1(int ms, string funname, int finishint, int ms2, int finishint2)
        {
            Waitint = 0;
            WaitFull = 1;
            WaitFinishint = finishint;
            WaitName = funname;
            Waitms2 = ms2;
            WaitFinishint2 = finishint2;

            Wait = new Timer();
            Wait.Interval = ms;
            Wait.Elapsed += OnTimedEventWait1;
            Wait.AutoReset = true;
            Wait.Enabled = true;
        }

        private void SetTimerWait1Disable()
        {
           
            Form1.form1.Debug("Wait Bitti");
            Wait.Enabled = false;
            SetTimer(Waitms2, WaitName, WaitFinishint2);
            WaitName = "";
            WaitFull = 0;
            Waitint = 0;
            WaitFinishint = 0;
            Waitms2 = 0;
            WaitFinishint2 = 0;

        }

        private void OnTimedEventWait1(Object source, System.Timers.ElapsedEventArgs e)
        {

            Form1.form1.Debug("Wait");


            Waitint++;
            if (WaitFinishint == Waitint)
            {
                SetTimerWait1Disable();
            }
        }



        private void SetTimer1(int ms,string funname,int finishint) {
            Timer1int = 0;
            Timer1Full = 1;
            Timer1Finishint = finishint;
            Timer1Name = funname;
            Timer1 = new Timer();
            Timer1.Interval = ms;
            Timer1.Elapsed += OnTimedEvent1;
            Timer1.AutoReset = true;
            Timer1.Enabled = true;
        }

        private void SetTimer1Disable()
        {
            Form1.form1.Debug(Timer1Name+"-Timer1 Bitti");
            Timer1Name = "";
             Timer1Full = 0;
             Timer1int = 0;
             Timer1Finishint = 0;
            
            Timer1.Enabled = false;
        }

    private void OnTimedEvent1(Object source, System.Timers.ElapsedEventArgs e)
    {
            Form1.form1.Debug("OnTimedEvent1");
            AllFunctions(Timer1Name);


                Timer1int++;
                if (Timer1Finishint == Timer1int)
                {
                    SetTimer1Disable();
                }
            
    }

        private void SetTimer2(int ms, string funname, int finishint)
        {
            Timer2int = 0;
            Timer2Full = 1;
            Timer2Finishint = finishint;
            Timer2Name = funname;
            Timer2 = new Timer();
            Timer2.Interval = ms;
            Timer2.Elapsed += OnTimedEvent2;
            Timer2.AutoReset = true;
            Timer2.Enabled = true;



        }
        private void SetTimer2Disable()
        {
            Form1.form1.Debug(Timer2Name + "-Timer2 Bitti");
            Timer2Name = "";
            Timer2Full = 0;
            Timer2int = 0;
            Timer2Finishint = 0;
            
            Timer2.Enabled = false;
        }
        private void OnTimedEvent2(Object source, System.Timers.ElapsedEventArgs e)
        {

            AllFunctions(Timer2Name);


            Timer2int++;
            if (Timer2Finishint == Timer2int)
            {
                SetTimer2Disable();
            }
        }

        private void SetTimer3(int ms, string funname, int finishint)
        {
            Timer3int = 0;
            Timer3Full = 1;
            Timer3Finishint = finishint;
            Timer3Name = funname;
            Timer3 = new Timer();
            Timer3.Interval = ms;
            Timer3.Elapsed += OnTimedEvent3;
            Timer3.AutoReset = true;
            Timer3.Enabled = true;



        }

        private void SetTimer3Disable()
        {
            Form1.form1.Debug(Timer3Name + "-Timer3 Bitti");
            Timer3Name = "";
            Timer3Full = 0;
            Timer3int = 0;
            Timer3Finishint = 0;
            
            Timer3.Enabled = false;
        }
        private void OnTimedEvent3(Object source, System.Timers.ElapsedEventArgs e)
        {

            AllFunctions(Timer3Name);


            Timer3int++;
            if (Timer3Finishint == Timer3int)
            {
                SetTimer3Disable();
            }
        }

        private void SetTimer4(int ms, string funname, int finishint)
        {
            Timer4int = 0;
            Timer4Full = 1;
            Timer4Finishint = finishint;
            Timer4Name = funname;
            Timer4 = new Timer();
            Timer4.Interval = ms;
            Timer4.Elapsed += OnTimedEvent4;
            Timer4.AutoReset = true;
            Timer4.Enabled = true;



        }

        private void SetTimer4Disable()
        {
            Form1.form1.Debug(Timer4Name + "-Timer4 Bitti");
            Timer4Name = "";
            Timer4Full = 0;
            Timer4int = 0;
            Timer4Finishint = 0;
            
            Timer4.Enabled = false;
        }
        private void OnTimedEvent4(Object source, System.Timers.ElapsedEventArgs e)
        {

            AllFunctions(Timer4Name);


            Timer4int++;
            if (Timer4Finishint == Timer4int)
            {
                SetTimer4Disable();
            }
        }

        private void SetTimer5(int ms, string funname, int finishint)
        {
            Timer5int = 0;
            Timer5Full = 1;
            Timer5Finishint = finishint;
            Timer5Name = funname;
            Timer5 = new Timer();
            Timer5.Interval = ms;
            Timer5.Elapsed += OnTimedEvent5;
            Timer5.AutoReset = true;
            Timer5.Enabled = true;

        }

        private void SetTimer5Disable()
        {
            Form1.form1.Debug(Timer5Name + "-Timer5 Bitti");
            Timer5Name = "";
            Timer5Full = 0;
            Timer5int = 0;
            Timer5Finishint = 0;
            
            Timer5.Enabled = false;
        }
        private void OnTimedEvent5(Object source, System.Timers.ElapsedEventArgs e)
        {

            AllFunctions(Timer5Name);


            Timer5int++;
            if (Timer5Finishint == Timer5int)
            {
                SetTimer5Disable();
            }
        }

        public void SetTimerKK(int ms, string funname, int finishint)
        {
            TimerKKint = 0;
            TimerKKFull = 1;
            TimerKKFinishint = finishint;
            TimerKKName = funname;
            TimerKK = new Timer();
            TimerKK.Interval = ms;
            TimerKK.Elapsed += OnTimedEventKK;
            TimerKK.AutoReset = true;
            TimerKK.Enabled = true;

        }

        public void SetTimerKKDisable()
        {
            Speak.speak.komutacik = 0;

            Speak.speak.dinlesoundbitti.Play();

          
            TimerKKName = "";
            TimerKKFull = 0;
            TimerKKint = 0;
            TimerKKFinishint = 0;

            TimerKK.Enabled = false;
        }

        public void SetTimerKKadd()
        {
           
            TimerKKFinishint = TimerKKint+10;
        }
        private void OnTimedEventKK(Object source, System.Timers.ElapsedEventArgs e)
        {
            
            TimerKKint++;
            if (TimerKKFinishint == TimerKKint)
            {
                SetTimerKKDisable();
            }
        }



        private void AllFunctions(string name)
        {
            Form1.form1.Debug(name);

            if (name == "yazdir")
            {
                Form1.form1.Debug("yazdim");
            }
            else if (name == "DiziboxReklamGec")
            {
                MyProcess.myprocess.DiziboxReklamGec();
            }
            else if(name== "DiziboxReklamGec1")
            {
                MyProcess.myprocess.DiziboxReklamGec1();
            }
            else if (name == "DiziboxReklamGec2")
            {
                MyProcess.myprocess.DiziboxReklamGec2();
            }
            else if (name == "DiziboxReklamGec3")
            {
                MyProcess.myprocess.DiziboxReklamGec3();
            }
            else if (name == "DiziboxTamEkranAc")
            {
                MyProcess.myprocess.DiziboxTamEkranAc();
            }
            else if (name == "DiziboxFilmDevamKontrol")
            {
                MyProcess.myprocess.DiziboxFilmDevamKontrol();
            }
            else if (name == "DiziboxOncekiBolum")
            {
                MyProcess.myprocess.DiziboxOncekiBolum();
            }
            else if (name == "DiziboxSonrakiBolum")
            {
                MyProcess.myprocess.DiziboxSonrakiBolum();
            }
            else if (name == "SpeakSetDefault")
            {
                Speak.speak.SpeakSetDefault();
            }

        }

    }
}
