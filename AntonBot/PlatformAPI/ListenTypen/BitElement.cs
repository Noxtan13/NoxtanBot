using System;
using WMPLib;

namespace AntonBot.PlatformAPI
{
    internal class BitElement
    {
        public int ID { get; set; }
        public int AbBetrag { get; set; }
        public int BisBetrag { get; set; }
        public bool bisMaximum { get; set; }
        public bool KeinBereich { get; set; }
        public String ChatText { get; set; }
        public bool AusgabeKonsole { get; set; }
        public bool Sound { get; set; }
        public String SoundPfad { get; set; }

        public bool playSound()
        {
            if (System.IO.File.Exists(SoundPfad))
            {
                WindowsMediaPlayer wplayer = new WindowsMediaPlayer();

                wplayer.URL = SoundPfad;
                wplayer.controls.play();

                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
