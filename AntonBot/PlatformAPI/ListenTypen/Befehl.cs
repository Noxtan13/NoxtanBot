using System;
using System.Collections.Generic;

namespace AntonBot.PlatformAPI
{
    internal class Befehl
    {
        public String Kommando { get; set; }
        public String Antwort { get; set; }
        public bool HatErsatzText { get; set; }
        public String ErsatzAntwort { get; set; }
        public List<RandomBefehl> ZufallAntwort { get; set; }
        public bool HatZufallAntowort { get; set; }

        public int Anzahl { get; set; }
        //public int Art { get; set; }
        //0 = Allgemein
        //1 = Nur für Twitch
        //2 = Nur für Discord

        public void IncrementAnzahl()
        {
            Anzahl = Anzahl + 1;
        }

        public Befehl()
        {
            ZufallAntwort = new List<RandomBefehl>();
            Anzahl = 0;
        }
    }
}
