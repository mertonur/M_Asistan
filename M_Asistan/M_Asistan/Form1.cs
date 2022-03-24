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
using System.Data.SqlClient;
using System.Configuration;

namespace M_Asistan
{
    public partial class Form1 : Form
    {
        Point diziboxreklam1 = new Point(1100, 1100);
        public static Form1 form1;
        public static DizilerForm dizilerForm;
        Speak speak = new Speak();
        MyTimers timers = new MyTimers();
        MyProcess myProcess = new MyProcess();
        PcProcess pcProcess = new PcProcess();
        MySound mySound = new MySound();
        Conn connection = new Conn();
        string DebugYazdir="";
        public Form1()
        {
            InitializeComponent();
            form1 = this;
            Speak.speak.LoadGrammer();
        }
        private void button1_Click(object sender, EventArgs e)
        {

         

            MyProcess.myprocess.DiziBox();

        }




        private void button2_Click(object sender, EventArgs e)
        {
            
                dizilerForm = new DizilerForm();
                dizilerForm.Show();
            



            //rEngine.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {



        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void Debug(string s)
        {
            DebugYazdir += s + "\n";
            
        }


       


        private void timerDebug_Tick(object sender, EventArgs e)
        {
          
            if (DebugYazdir != "")
            {
                richTextBox1.AppendText(DebugYazdir);
                DebugYazdir = "";
            }

            textBox1.Text = MyTimers.myTimers.Timer1Name;
            textBox2.Text = MyTimers.myTimers.Timer2Name;
            textBox3.Text = MyTimers.myTimers.Timer3Name;
            textBox4.Text = MyTimers.myTimers.Timer1int.ToString()+" - "+ MyTimers.myTimers.Timer1Finishint.ToString();
            textBox5.Text = MyTimers.myTimers.Timer1.Interval.ToString();
            textBox6.Text = MyTimers.myTimers.WaitName;
        }

        private void consoleOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        public void DebugNotification(string header,string text,ToolTipIcon tip)
        {
            notifyIcon1.ShowBalloonTip(1000, header, text, tip);

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }
    }
}
