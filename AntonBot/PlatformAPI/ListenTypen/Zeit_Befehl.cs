using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonBot.PlatformAPI
{
    class Zeit_Befehl : Befehl
    {
        public int Zeitspanne { get; set; }
        public int DeltaZeit { get; set; }
        public bool ZeitAnDiscord { get; set; }
        public bool ZeitAnTwitch { get; set; }
        public bool ZeitAnYouTube { get; set; }
    }
}
