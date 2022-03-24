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

namespace M_Asistan
{
    class Speak
    {

        SpeechSynthesizer synt = new SpeechSynthesizer();
        PromptBuilder pbuilder = new PromptBuilder();
        SpeechRecognitionEngine rEngine = new SpeechRecognitionEngine();

        public string paste = "^v";

        public List<string> numbers=new List<string>();

        public int sayistatic = 0;
        public string sonfunstatic = "";

        public static Speak speak;
        //Müzik Dosyaları
        public System.Media.SoundPlayer consoleopensound = new System.Media.SoundPlayer(@"");
        public System.Media.SoundPlayer consoleclosesound = new System.Media.SoundPlayer(@"");
        public System.Media.SoundPlayer dinlesound = new System.Media.SoundPlayer(@"");
        public System.Media.SoundPlayer dinlesoundbitti = new System.Media.SoundPlayer(@"");

        public Speak()
        {
            speak = this;
        }




        public void LoadGrammer()
        {

            Choices list = new Choices();
            list.Add(new String[] { "open yourself", "open", "chrome aç", "exit", "open valorant","open forever", "do", "you", "deneme", "valorantı aç", "open console", "close console", "aç", "güzel", "discord", "enter password", 
                "open next chapter", "go next chapter", "volume up", "volume down","1","two" ,"three","four","five","six","seven","eight","nine","ten","hey kk","not you kk","thanks kk"});

            for (int i = 0; i < 100; i++)
            {
                list.Add(i.ToString());
                list.Add("Load "+i.ToString());
                list.Add("Open " + i.ToString());
                list.Add("Open " + i.ToString()+".");
               
                numbers.Add(i.ToString());
            }
            


            Grammar gramer = new Grammar(new GrammarBuilder(list));
            try
            {
                rEngine.RequestRecognizerUpdate();
                rEngine.LoadGrammar(gramer);
                rEngine.SpeechRecognized += rEngine_SpeechRecognized;
                rEngine.SetInputToDefaultAudioDevice();
                rEngine.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception z)
            {
                Form1.form1.Debug(z.ToString());
                Console.WriteLine(z);
                return;
            }
        }




        public int komutacik = 0;
        public int consoleacik = 1;
        void rEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (komutacik == 1)
            {
                MyTimers.myTimers.SetTimerKKadd();
            }


            switch (e.Result.Text)
            {
                case "open console":
                    {
                        if (consoleacik != 1)
                        {
                            consoleacik = 1;
                            Form1.form1.DebugNotification("KK", "Konsol Açıldı", ToolTipIcon.None);
                            consoleopensound.Play();
                            Form1.form1.Debug(e.Result.Text);
                        }
                        else
                        {
                            Form1.form1.DebugNotification("KK", "Konsol Halihazırda Açık", ToolTipIcon.None);
                        }
                        break;
                    }
                case "close console":
                    {
                        if (consoleacik != 0)
                        {
                            consoleacik = 0;
                            Form1.form1.DebugNotification("KK", "Konsol Kapandı", ToolTipIcon.None);
                            consoleclosesound.Play();

                            Form1.form1.Debug(e.Result.Text);

                            if (komutacik != 0)
                            {

                                komutacik = 0;
                                dinlesoundbitti.Play();
                                MyTimers.myTimers.SetTimerKKDisable();
                            }

                        }
                        else
                        {
                            Form1.form1.DebugNotification("KK", "Konsol Halihazırda Kapalı", ToolTipIcon.None);
                        }
                        break;
                    }
            }

            if (consoleacik==1) {
                switch (e.Result.Text)
                {
                    case "hey kk":
                        {
                            Form1.form1.Debug(e.Result.Text);
                            if (komutacik != 1)
                            {
                                komutacik = 1;
                                MyTimers.myTimers.SetTimerKK(1000, "", 10);
                            }
                            dinlesound.Play();
                            break;
                        }
                    case "not you kk":
                        {
                            Form1.form1.Debug(e.Result.Text);
                            if (komutacik != 0)
                            {
                                komutacik = 0;
                                dinlesoundbitti.Play();
                                MyTimers.myTimers.SetTimerKKDisable();
                            }
                            break;
                        }
                    case "thanks kk":
                        {
                            Form1.form1.Debug(e.Result.Text);
                            if (komutacik != 0)
                            {
                                komutacik = 0;
                                dinlesoundbitti.Play();
                                MyTimers.myTimers.SetTimerKKDisable();
                            }

                            break;
                        }
                }

                if (komutacik == 1)
                {
                    Form1.form1.Debug(e.Result.Text);
                    Do(e.Result.Text);
                }
            }
        }



        public void Do(string command) {

            if (numbers.Contains(command))
            {

            }
            
            switch (command)
            {

                case "chrome aç":
                    {
                        System.Diagnostics.Process.Start("C:/Program Files/Google/Chrome/Application/chrome.exe");
                        pbuilder.ClearContent();
                        pbuilder.AppendText("very well");
                        synt.Speak(pbuilder);
                        break;
                    }
                case "open valorant":
                    {
                        
                        ProcessStartInfo info = new ProcessStartInfo("C:/Riot Games/Riot Client/RiotClientServices.exe ");
                        
                        info.Arguments = "--launch-product=valorant --launch-patchline=live";
                        Process.Start(info);

                        int valorantacik = 0;



                        Process[] localByName = Process.GetProcessesByName("VALORANT", "pcname");
                        foreach (var item in localByName)
                        {
                            valorantacik = 1;

                        }
                        if (valorantacik == 0)
                        {
                            pbuilder.ClearContent();
                            pbuilder.AppendText("Valorant is Opened");
                            synt.Speak(pbuilder);
                            System.Threading.Thread.Sleep(6000);



                            SendKeys.Send("^a");
                            SendKeys.Send("NİCNAME");//NİCKNAME
                            SendKeys.Send("{TAB}");
                            SendKeys.Send("PASSWORD");//PASSWORD

                            pbuilder.ClearContent();
                            pbuilder.AppendText("Valorant's password is ready for you");
                            synt.Speak(pbuilder);

                        }
                        else if (valorantacik == 1)
                        {
                            pbuilder.ClearContent();
                            pbuilder.AppendText("Valorant is currently open");
                            synt.Speak(pbuilder);
                        }
                       

                        

                        break;
                    }
                case "open yourself":
                    {
                        SendKeys.Send("{ENTER}");
                        SendKeys.Send("ABC");
                        SendKeys.Send("{ENTER}");
                        SendKeys.Send("{ENTER}");
                        break;
                    }
                case "open forever":
                    {
                        DebugSpeek("Okey is opening");
                        MyProcess.myprocess.DiziBox();
                        break;
                    }
                case "exit":
                    {
                        //Application.Exit();
                        break;
                    }
                case "enter password":
                    {
                        SendKeys.Send("{ENTER}");
                        pbuilder.ClearContent();
                        pbuilder.AppendText("password confirmed");
                        synt.Speak(pbuilder);
                        break;
                    }
                case "go next chapter":
                    {
                        DebugSpeek("Okey i am trying");
                        MyProcess.myprocess.DiziboxSonrakiBolum();
                        break;
                    }
                case "open next chapter":
                    {
                        DebugSpeek("Okey i am trying");
                        MyProcess.myprocess.DiziboxSonrakiBolum();
                        break;
                    }
                case "volume up":
                    {
                        if (sayistatic == 0)
                        {
                            sonfunstatic = "volume up";
                            DebugSpeek("How much volume do you want to increase?");
                            MyTimers.myTimers.SetTimer(10000, "SpeakSetDefault", 1);
                        }
                        else
                        {
                            MySound.mySound.volumeup(sayistatic);
                        }
                        
                        break;
                    }
                case "volume down":
                    {
                        if (sayistatic == 0)
                        {
                            sonfunstatic = "volume down";
                            DebugSpeek("How much volume do you want to  decrease ?");
                            MyTimers.myTimers.SetTimer(10000, "SpeakSetDefault", 1);
                        }
                        else
                        {

                            MySound.mySound.volumedown(sayistatic);
                        }

                        break;
                    }
                case "1":
                    {
                        SetSayi(1);

                        break;
                    }
                case "two":
                    {
                        SetSayi(2);

                        break;
                    }
                case "three":
                    {
                        SetSayi(3);

                        break;
                    }
                case "four":
                    {
                        SetSayi(4);

                        break;
                    }
                case "five":
                    {
                        SetSayi(5);

                        break;
                    }
                case "six":
                    {
                        SetSayi(6);

                        break;
                    }
                case "seven":
                    {
                        SetSayi(7);

                        break;
                    }
                case "eight":
                    {
                        SetSayi(8);

                        break;
                    }
                case "nine":
                    {
                        SetSayi(9);

                        break;
                    }
                case "ten":
                    {
                        SetSayi(10);

                        break;
                    }
            }

        }

        public void SetSayi(int sayi)
        {
            sayistatic = sayi;
            Do(sonfunstatic);
            SpeakSetDefault();
        }

        public void SpeakSetDefault()
        {
            sonfunstatic = "";
            sayistatic = 0;
            MyTimers.myTimers.SetTimerDisable("SpeakSetDefault");
        }


        public void DebugSpeek(string text)
        {
            pbuilder.ClearContent();
            pbuilder.AppendText(text);
            synt.Speak(pbuilder);
        }


    }
}
