using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonBot.PlatformAPI
{
    public class KonsolenAusgabe
    {
        public string AusgabeTyp;
        public TimeSpan AusgabeZeitpunkt;
        public string AusgabeText;
        public double AusgabeZeitmessung;
        private bool Ausgegeben = false;
        public KonsolenAusgabe(string Typ, TimeSpan Zeitpunkt, string Ausgabe) {
            AusgabeTyp = Typ;
            AusgabeZeitpunkt = Zeitpunkt;
            AusgabeText = Ausgabe;
            //AusgabeZusatzInfo = "";
        }
        public KonsolenAusgabe(string Typ, TimeSpan Zeitpunkt, string Ausgabe,double ZusatzMessung)
        {
            AusgabeTyp = Typ;
            AusgabeZeitpunkt = Zeitpunkt;
            AusgabeText = Ausgabe;
            AusgabeZeitmessung = ZusatzMessung;
        }
        public KonsolenAusgabe(TimeSpan Zeitpunkt, string Ausgabe)
        {
            //AusgabeTyp = "leerer Typ";
            AusgabeZeitpunkt = Zeitpunkt;
            AusgabeText = Ausgabe;
            //AusgabeZusatzInfo = "";
        }
        public KonsolenAusgabe(TimeSpan Zeitpunkt, string Ausgabe, double ZusatzMessung)
        {
            //AusgabeTyp = "leerer Typ";
            AusgabeZeitpunkt = Zeitpunkt;
            AusgabeText = Ausgabe;
            AusgabeZeitmessung = ZusatzMessung;
         }

        public KonsolenAusgabe() {
            AusgabeTyp = "leere Anlage";
            AusgabeZeitpunkt = DateTime.Now.TimeOfDay;
            AusgabeText = "";
            AusgabeZeitmessung = 0;
            Ausgegeben = true;
        }

        public void ausgegeben() {
            Ausgegeben = true;
        }
        public bool getAusgabe() {
            return Ausgegeben;
        }
    }
}
