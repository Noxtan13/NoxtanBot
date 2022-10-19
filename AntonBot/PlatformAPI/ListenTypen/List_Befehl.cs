using System.Collections.Generic;

namespace AntonBot.PlatformAPI
{
    public class List_Befehl
    {
        public string Kommando { get; set; }
        public string AusgabeListe { get; set; }
        //Die "Antwort", wenn man nur den Kommando eingibt
        public List<Eintrag> Eintragsliste { get; set; }
        public string AufbauEintrag { get; set; }
        public int AnzahlEinträge { get; set; }
        public char BefehlTrennungszeichen { get; set; } = ' ';
        public string CurrentBefehl { get; set; }
        public string CurrentAntwort { get; set; }
        public string NextBefehl { get; set; }
        //Befehl um den nächsten Eintrag zu wählen.
        public string NextAntwort { get; set; }
        public bool NextOnlyAdmin { get; set; }
        //Schalter um zu prüfen, dass nur ein Admin den Next Befehl verwenden kann
        public bool HatLöschBefehl { get; set; }
        //Schalter um anzugeben, ob ein LöschBefehl für den List-Befehl verfügbar ist
        public string LöschBefehl { get; set; }
        //Befehl um einen Eintrag zu löschen
        public string LöschAntwort { get; set; }
        //Befehl um eine Reaktion zum ERFOLGREICHEN Löschen anzugeben
        public string LöschAntwortFail { get; set; }
        //Befehl um eine Reaktion zum GESCHEITERTEN Löschen anzugeben
        public bool NurEigeneBefehle { get; set; }
        //Schalter um anzugeben, ob ein User nur seine eigenen Einträge löschen darf
        public string HinzufügenAntwort { get; set; }
        //Antwort, wenn ein neuer Eintrag hinzugefügt wird
        public bool UpdateOwn { get; set; }
        //Schalter, ob der Benutzer mehrere Einträge machen kann oder nur seinen Eintrag updaten kann
        public string UpdateAntwort { get; set; }
    }

    public class Eintrag
    {
        public string User { get; set; }
        public string UserEintrag { get; set; }
        public string PlattformQuelle { get; set; }
    }
}
