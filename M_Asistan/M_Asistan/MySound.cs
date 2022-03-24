using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace M_Asistan
{
    class MySound
    {
        public static MySound mySound;



        public MySound()
        {
            mySound = this;
        }

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        public void volumeup(int sayi) {
            
            
            for (int i = 0; i < sayi; i++)
            {
                volumedoup();
            }
            Speak.speak.DebugSpeek(sayi.ToString() + " volume is increased");



        }
        public void volumedown(int sayi)
        {  

            for (int i = 0; i < sayi; i++)
            {
                volumedodown();
            }
            Speak.speak.DebugSpeek(sayi.ToString() + " volume is decrease");


        }

        public void volumedoup()
        {
            keybd_event((byte)Keys.VolumeUp, 0, 0, 0);
            keybd_event((byte)Keys.VolumeUp, 0, 0, 0);
            keybd_event((byte)Keys.VolumeUp, 0, 0, 0);
        }
        public void volumedodown()
        {
            keybd_event((byte)Keys.VolumeDown, 0, 0, 0);
            keybd_event((byte)Keys.VolumeDown, 0, 0, 0);
            keybd_event((byte)Keys.VolumeDown, 0, 0, 0);
        }


    }
}
