using AntonBot.PlatformAPI;
using AntonBot.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace AntonBot
{

    class Bot_Verwalter
    {        
        protected bool Active = false;
        //private String Ausgabe = "";
        private KonsolenAusgabe Ausgabe1=new KonsolenAusgabe();
        private bool Ausgeben = false;

        protected OtherChannel OtherChannel = new OtherChannel();

        protected List<Befehl> BefehlListe = new List<Befehl>();
        protected List<Zeit_Befehl> ZeitBefehlListe = new List<Zeit_Befehl>();

        protected List<List_Befehl> ListBefehlListe = new List<List_Befehl>();
        public bool ZeitBefehlSenden { get; set; } = false;

        protected List<String> AllCommands = new List<string>();

        protected Random Zufallszahl = new Random();

        protected DateTime LastLoadTime = new DateTime();

        //Variable zum erneuten Versuchsaufbau, wenn z.B. keine Verbindung ins Internet möglich war
        protected bool Restart = false;

        /*
public void Speichern() {
   String welt = JsonConvert.SerializeObject(new Gespeicherte_Commands() { Anton = "ANTON 3", Antwort = "Hallo ich heiße Anton 3", Befehl = "!ANTON3" });
   Gespeicherte_Commands deserialisiert = JsonConvert.DeserializeObject<Gespeicherte_Commands>(welt);
}
*/
        public bool getRestart() {
            return Restart;
        }

        public void LoadBefehle(String Path, int BefehlArt) {
            //Path = Application.StartupPath + "\\Befehl.json";
            String InhaltJSON = "";

            if (File.Exists(Path))
            {
                
                InhaltJSON = File.ReadAllText(Path);

                LastLoadTime = File.GetLastWriteTime(Path);
                switch (BefehlArt)
                {
                    case 1:
                        try
                        {
                            BefehlListe = JsonConvert.DeserializeObject<List<Befehl>>(InhaltJSON);
                            
                            //ZufallGewichtung(BefehlListe);
                        }
                        catch (Exception Fehler)
                        {
                            KonsolenAusgabe("Die Befehlsliste beinhaltet nicht die erwarteten Einträge oder ist beschädigt \n Weitere Informationen: \n\n" + Fehler.InnerException.ToString());
                        }

                        break;
                    case 2:
                        try
                        {
                            ZeitBefehlListe = JsonConvert.DeserializeObject<List<Zeit_Befehl>>(InhaltJSON);
                        }
                        catch (Exception Fehler)
                        {
                            KonsolenAusgabe("Die Zeit-Befehlsliste beinhaltet nicht die erwarteten Einträge oder ist beschädigt \n Weitere Informationen: \n\n" + Fehler.InnerException.ToString());
                        }
                        break;
                    case 3:
                        try
                        {
                            ListBefehlListe = JsonConvert.DeserializeObject<List<List_Befehl>>(InhaltJSON);
                        }
                        catch (Exception Fehler)
                        {
                            KonsolenAusgabe("Die Liste der ListenBefehle beinhaltet nicht die erwarteten Einträge oder ist beschädigt \n Weitere Informationen: \n\n" + Fehler.InnerException.ToString());
                        }
                        break;
                    default:
                        break;
                }
                //FileStream stream = File.OpenRead(Path);

            }
        }
        protected List<Befehl> LoadList(String Path) {
            String InhaltJSON = "";

            if (File.Exists(Path))
            {
                try
                {
                    InhaltJSON = File.ReadAllText(Path);
                    return JsonConvert.DeserializeObject<List<Befehl>>(InhaltJSON);
                }
                catch (Exception Fehler)
                {
                    KonsolenAusgabe("Die Liste der Befehle beinhaltet nicht die erwarteten Einstellungen oder ist beschädigt \n Weitere Informationen: \n\n" + Fehler.InnerException.ToString());
                    return null;
                }
            }
            else {
                return null;
            }
        }

        protected List<JoinedUsers> LoadJoinedUserList()
        {
            String Path = System.Windows.Forms.Application.StartupPath + System.IO.Path.DirectorySeparatorChar + "JoinedUsers.json";
            String InhaltJSON = "";
            if (File.Exists(Path))
            {
                try
                {
                    InhaltJSON = File.ReadAllText(Path);

                    return JsonConvert.DeserializeObject<List<JoinedUsers>>(InhaltJSON);
                }
                catch (Exception Fehler)
                {
                    KonsolenAusgabe("Die Liste der gejointen User beinhaltet nicht die erwarteten Einstellungen oder ist beschädigt \n Weitere Informationen: \n\n" + Fehler.InnerException.ToString());
                    return new List<JoinedUsers>();
                }
            }
            else
            {
                return new List<JoinedUsers>();
            }
        }
        protected void SaveJoinedUserList(List<JoinedUsers> UserList) {

            string Path = System.Windows.Forms.Application.StartupPath + System.IO.Path.DirectorySeparatorChar + "JoinedUsers.json";
            string InhaltJSON = "";
            InhaltJSON += JsonConvert.SerializeObject(UserList,Formatting.Indented);
            

            File.WriteAllText(Path, InhaltJSON);
        }

        protected List<Befehl> ZufallGewichtung(List<Befehl> Liste) {
            //Hier werden die Zufallsantworten anhand ihrer Gewichtung zusätzlich erzeugt, damit die Zufallsgenerierung für diese auch mit Gewichtung funktioniert.


            foreach (Befehl item in Liste)
            {
                if (item.HatZufallAntowort)
                {
                    List<RandomBefehl> gewichteteRandomBefehle = new List<RandomBefehl>();

                    foreach (RandomBefehl randomItem in item.ZufallAntwort)
                    {
                        if (randomItem.Wahrscheinlichkeit > 1)
                        {
                            for (int i = 1; i < randomItem.Wahrscheinlichkeit; i++)
                            {
                                gewichteteRandomBefehle.Add(new RandomBefehl { Text = randomItem.Text });
                            }
                        }
                    }

                    item.ZufallAntwort.AddRange(gewichteteRandomBefehle);
                }
            }
            return Liste;
        }

        protected string CheckBefehlAllg(String Message, String User)
        {
            string BefehlTeil = getBefehlTeil(Message);
            string OptionalerTeil = getOptionalerTeil(Message);

            

            Message = null;

            if (BefehlTeil.StartsWith(SettingsGroup.Instance.SBefehlSymbol))
            {
                foreach (Befehl item in BefehlListe)
                {
                    if (BefehlTeil.Equals(SettingsGroup.Instance.SBefehlSymbol+item.Kommando.ToLower())) {
                        CheckLastLoad("Befehl.json", 1);
                        Message = item.Antwort;
                        string Ersatzantwort = item.ErsatzAntwort;
                        //String für die Ersatzantwort, da diese auch bei der Zufallsantwort angepasst werden müsste (auch wenn diese gerade nicht verwenden werden würde)

                        if (item.HatZufallAntowort)
                        {
                            

                            int Wert = Zufallszahl.Next(item.ZufallAntwort.Count);

                            Message = Message.Replace("°VariablerTeil", item.ZufallAntwort[Wert].Text);
                            Ersatzantwort = Ersatzantwort.Replace("°VariablerTeil", item.ZufallAntwort[Wert].Text);

                        }

                        if (item.HatErsatzText)
                        {
                            if (OptionalerTeil.Contains("§§$%&"))
                            {
                                Message = Ersatzantwort;

                                Message = Message.Replace("°OptionalerTeil", OptionalerTeil);
                            }
                            else {
                                Message = Message.Replace("°OptionalerTeil", OptionalerTeil);
                            }
                        }

                        Message = Message.Replace("°Name", User);
                        Message = Message.Replace("°KommandosBefehlsKette", Befehlskette(AllCommands));

                        item.IncrementAnzahl();
                        Message = Message.Replace("°Zähler", item.Anzahl.ToString());

                        BefehlSpeichern(BefehlListe, "Befehl.json");
                        //ZufallGewichtung(BefehlListe);
                    }
                }
            }

            return Message;
        }

        protected string CheckListBefehl(string Message, string User, bool Adminkennzeichen, string Plattform) {
            string Nachricht=null;
            string BefehlTeil1 = getBefehlTeil(Message);
            string BefehlTeil2 = "UPS";
            string OptionalerTeilGesamt = getOptionalerTeil(Message);

            BefehlTeil2 = getBefehlTeil(getOptionalerTeil(Message));
            string OptionalerTeil = getOptionalerTeil(OptionalerTeilGesamt);

            foreach (List_Befehl item in ListBefehlListe) {
                if (BefehlTeil1.Equals(SettingsGroup.Instance.SBefehlSymbol+ item.Kommando.ToLower()))
                {


                    if (item.BefehlTrennungszeichen.Equals(' ')) {
                        BefehlTeil2 = " " + BefehlTeil2;
                        //Damit das Leerzeichen auch als Befehlteil ausgewertet werden kann, muss das abgeschnittene Leerzeichen wieder hinzugefügt werden
                    }

                    if (BefehlTeil2.Equals(item.BefehlTrennungszeichen + item.CurrentBefehl))
                    {
                        //Hier steht die Ausgabe für den Aktuellen Eintrag
                        string Ausgabe = item.CurrentAntwort;

                        Ausgabe = Ausgabe.Replace("°Auflistung", item.AufbauEintrag);
                        Ausgabe = Ausgabe.Replace("°ListNummer", " ");
                        Ausgabe = Ausgabe.Replace("°ListEintrag", item.Eintragsliste[0].UserEintrag);
                        Ausgabe = Ausgabe.Replace("°ListBenutzer", item.Eintragsliste[0].User);
                        Ausgabe = Ausgabe.Replace("°ListQuelle", item.Eintragsliste[0].PlattformQuelle);

                        Ausgabe = Ausgabe.Replace("°Name", User);
                        Ausgabe = Ausgabe.Replace("°OptionalerTeil", OptionalerTeil);

                        Nachricht = Ausgabe;

                    }
                    else if (BefehlTeil2.Equals(item.BefehlTrennungszeichen + item.NextBefehl.ToLower()))
                    {
                        //Hier wird zum nächsten Eintrag gesprungen und der aktuelle gelöscht

                        if (item.NextOnlyAdmin && Adminkennzeichen)
                        {
                            //Wenn ein Admin erwartet wird und einer da ist
                            string Ausgabe = item.NextAntwort;

                            item.Eintragsliste.RemoveAt(0);

                            Ausgabe = Ausgabe.Replace("°Auflistung", item.AufbauEintrag);
                            Ausgabe = Ausgabe.Replace("°ListNummer", " ");
                            Ausgabe = Ausgabe.Replace("°ListEintrag", item.Eintragsliste[0].UserEintrag);
                            Ausgabe = Ausgabe.Replace("°ListBenutzer", item.Eintragsliste[0].User);
                            Ausgabe = Ausgabe.Replace("°ListQuelle", item.Eintragsliste[0].PlattformQuelle);

                            Ausgabe = Ausgabe.Replace("°Name", User);
                            Ausgabe = Ausgabe.Replace("°OptionalerTeil", OptionalerTeil);

                            Nachricht = Ausgabe;
                            BefehlListSpeichern();
                        }
                        else if (item.NextOnlyAdmin == false)
                        {
                            //wenn kein Admin erwartet wird
                            string Ausgabe = item.NextAntwort;

                            item.Eintragsliste.RemoveAt(0);

                            Ausgabe = Ausgabe.Replace("°Auflistung", item.AufbauEintrag);
                            Ausgabe = Ausgabe.Replace("°ListNummer", " ");
                            Ausgabe = Ausgabe.Replace("°ListEintrag", item.Eintragsliste[0].UserEintrag);
                            Ausgabe = Ausgabe.Replace("°ListBenutzer", item.Eintragsliste[0].User);
                            Ausgabe = Ausgabe.Replace("°ListQuelle", item.Eintragsliste[0].PlattformQuelle);

                            Ausgabe = Ausgabe.Replace("°Name", User);
                            Ausgabe = Ausgabe.Replace("°OptionalerTeil", OptionalerTeil);

                            Nachricht = Ausgabe;
                            BefehlListSpeichern();
                        }
                    }
                    else if (item.HatLöschBefehl && BefehlTeil2.Equals(item.BefehlTrennungszeichen + item.LöschBefehl.ToLower()))
                    {
                        Eintrag Eintragitem = null;
                        string Ausgabe;
                        //Hier wird ein Eintrag gelöscht

                        for (int i = 1; i < item.Eintragsliste.Count; i++)
                        {
                            if (item.NurEigeneBefehle)
                            {
                                if (OptionalerTeil.Equals(i.ToString()) && item.Eintragsliste[i].User.Equals(User))
                                {
                                    Eintragitem = item.Eintragsliste[i];
                                    item.Eintragsliste.RemoveAt(i);
                                }
                            }
                            else
                            {
                                if (OptionalerTeil.Equals(i.ToString()))
                                {
                                    Eintragitem = item.Eintragsliste[i];
                                    item.Eintragsliste.RemoveAt(i);
                                }
                            }
                        }

                        
                        if (Eintragitem == null)
                        {
                            //Nicht gefunden
                            Ausgabe = item.LöschAntwortFail;

                            Ausgabe = Ausgabe.Replace("°Name", User);
                            Ausgabe = Ausgabe.Replace("°OptionalerTeil", OptionalerTeil);
                        }
                        else
                        {
                            //gefunden
                            Ausgabe = item.LöschAntwort;
                            Ausgabe = Ausgabe.Replace("°Auflistung", item.AufbauEintrag);
                            Ausgabe = Ausgabe.Replace("°ListNummer", " ");
                            Ausgabe = Ausgabe.Replace("°ListEintrag", Eintragitem.UserEintrag);
                            Ausgabe = Ausgabe.Replace("°ListBenutzer", Eintragitem.User);
                            Ausgabe = Ausgabe.Replace("°ListQuelle", Eintragitem.PlattformQuelle);

                            Ausgabe = Ausgabe.Replace("°Name", User);
                            Ausgabe = Ausgabe.Replace("°OptionalerTeil", OptionalerTeil);
                        }
                        BefehlListSpeichern();
                        Nachricht = Ausgabe;

                    }
                    else if (OptionalerTeilGesamt.Equals("§§$%&"))
                    {
                        //Es wird nur der "List"-Befehl aufgerufen und dann die entsprechende Liste ausgegeben
                        string Ausgabe = item.AusgabeListe;
                        string Eintrag = "";

                        for (int i = 1; i < item.AnzahlEinträge && i < item.Eintragsliste.Count; i++)
                        {

                            Eintrag Eintragitem = item.Eintragsliste[i];
                            string Text = item.AufbauEintrag;
                            Text = Text.Replace("°ListNummer", i.ToString());
                            Text = Text.Replace("°ListEintrag", Eintragitem.UserEintrag);
                            Text = Text.Replace("°ListBenutzer", Eintragitem.User);
                            Text = Text.Replace("°ListQuelle", Eintragitem.PlattformQuelle);
                            Eintrag = Eintrag + Text;
                        }

                        Ausgabe = Ausgabe.Replace("°Auflistung", Eintrag);
                        Ausgabe = Ausgabe.Replace("°Name", User);
                        Nachricht = Ausgabe;
                    }
                    else
                    {
                        //Alle anderen Nachrichten werden als Eintrag in die Liste aufgenommen und die Antwort wird ausgegeben
                        Eintrag NeuerEintrag = new Eintrag();
                        NeuerEintrag.User = User;
                        NeuerEintrag.UserEintrag = OptionalerTeilGesamt;
                        NeuerEintrag.PlattformQuelle = Plattform;

                        item.Eintragsliste.Add(NeuerEintrag);

                        string Text = item.HinzufügenAntwort;
                        Text = Text.Replace("°Name", User);
                        Text = Text.Replace("°OptionalerTeil", OptionalerTeilGesamt);

                        Nachricht = Text;

                        BefehlListSpeichern();

                        
                    }
                }
            }

            if (Nachricht == null) {
                
            }
            //Nachricht = "BefehlTeil1: " + BefehlTeil1 + " BefehlTeil2: " + BefehlTeil2 + " OptionalerTeil " + OptionalerTeil;

            return Nachricht;
        }

        protected void BefehlListSpeichern() {
            string Path = System.Windows.Forms.Application.StartupPath + System.IO.Path.DirectorySeparatorChar + "List-Befehl.json";
            string InhaltJSON = "";
            InhaltJSON += JsonConvert.SerializeObject(ListBefehlListe, Formatting.Indented);

            

            File.WriteAllText(Path, InhaltJSON);

            LoadBefehle(Path, 3);
        }

        protected void CheckLastLoad(String Name, int BefehlArt) {
            string Path = System.Windows.Forms.Application.StartupPath + System.IO.Path.DirectorySeparatorChar + Name; // "\\Befehl.json";
            
            if (LastLoadTime < File.GetLastWriteTime(Path)) {
                LoadBefehle(Path, BefehlArt);
                KonsolenAusgabe(Name + " wurde neu geladen, da nicht aktuell");
            }
        }

        protected void BefehlSpeichern(List<Befehl> Liste, String Name)
        {
            string Path = System.Windows.Forms.Application.StartupPath + System.IO.Path.DirectorySeparatorChar + Name; //"\\Befehl.json";
            string InhaltJSON = "";
            InhaltJSON += JsonConvert.SerializeObject(Liste, Formatting.Indented);

            File.WriteAllText(Path, InhaltJSON);
            LastLoadTime = File.GetLastWriteTime(Path);
        }

        protected string getBefehlTeil(string message) {

            String BefehlTeil;
            //Unterscheidung ob Befehl (bzw. in dem Fall Nachricht" weitere "Parameter" getrennt nach "Leerzeichen" beinhaltet
            if (message.Contains(" "))
            {
                BefehlTeil = message.Substring(0, message.IndexOf(" "));
                //tolower einfach nur damit die Befehle erkannt werden, egal wie die geschrieben werden
                BefehlTeil = BefehlTeil.ToLower();
            }
            else
            {
                BefehlTeil = message.ToLower();
            }

            return BefehlTeil;
        }
        protected string getOptionalerTeil(string message)
        {
            //Das §§$%& verwende ich als Trennungzeichen, um herauszufinden, ob der Optionaler Teil Werte beinhaltet oder nicht, zur Unterscheidung später
            String OptionalerTeil = "§§$%&";

            //Unterscheidung ob Befehl (bzw. in dem Fall Nachricht" weitere "Parameter" getrennt nach "Leerzeichen" beinhaltet
            if (message.Contains(" "))
            {
                //+1, damit das Leerzeichen nicht zusätzlich verwendet wird
                OptionalerTeil = message.Substring(message.IndexOf(" ") + 1);
            }

            return OptionalerTeil;
        }

        protected void CommandListFill(List<Befehl> Liste) {
            foreach (var item in Liste)
            {
                AllCommands.Add(item.Kommando.ToString());
            }
        }


        protected string Befehlskette(List<Befehl> Liste) {
            String HilfeBefehl="";

            foreach (Befehl item in Liste)
            {
                HilfeBefehl += ", " + SettingsGroup.Instance.SBefehlSymbol+ item.Kommando;
            }
            HilfeBefehl = HilfeBefehl.Remove(0,1);
            return HilfeBefehl;
        }
        protected string Befehlskette(List<string> Liste)
        {
            String HilfeBefehl = "";

            foreach (var item in Liste)
            {
                HilfeBefehl += ", " + SettingsGroup.Instance.SBefehlSymbol+ item;
            }
            HilfeBefehl = HilfeBefehl.Remove(0,1);
            return HilfeBefehl;
        }


        public async void Zeitschritt(DiscordFunction Dclient = null) {
            if (ZeitBefehlSenden)
            {
                foreach (Zeit_Befehl item in ZeitBefehlListe)
                {
                    item.DeltaZeit += 1;
                    if (item.DeltaZeit > item.Zeitspanne)
                    {
                        if (item.ZeitAnDiscord)
                        {
                            item.DeltaZeit = 0;
                            await Dclient.SendMessage(735764666424492062, item.Antwort);
                        }
                    }
                }
            }
        }
        public void Zeitschritt(TwitchFunction Tclient = null)
        {
            if (ZeitBefehlSenden && SettingsGroup.Instance.TsOnline)
            {
                foreach (Zeit_Befehl item in ZeitBefehlListe)
                {
                    if (item.ZeitAnTwitch)
                    {
                        item.DeltaZeit += 1;
                        if (item.DeltaZeit > item.Zeitspanne)
                        {
                            item.DeltaZeit = 0;
                            Tclient.SendMessage(item.Antwort, SettingsGroup.Instance.TsStandardChannel);
                        }
                    }
                }
            }
        }
        public void Zeitschritt(YouTube_Functions Yclient = null)
        {
            if (ZeitBefehlSenden)
            {
                foreach (Zeit_Befehl item in ZeitBefehlListe)
                {
                    item.DeltaZeit += 1;
                    if (item.DeltaZeit > item.Zeitspanne)
                    {
                        if (item.ZeitAnYouTube)
                        {
                            item.DeltaZeit = 0;
                            Yclient.SendMessage(item.Antwort);
                        }
                    }
                }
            }
        }
        public Boolean getActive() {
            return Active;
        }
        
        public void KonsolenAusgabe(String text) {
            //Ausgabe = Ausgabe + Environment.NewLine + text;
            KonsolenAusgabe(text, 0);
        }
        public void KonsolenAusgabe(String text, double Zusatz) {
            //Ausgabe = Ausgabe + Environment.NewLine + text + " " + Zusatz;
            if (Ausgeben)
            {
                //Eintrag schon vorhanden, wird erweitert
                if (Zusatz == 0)
                    //Wenn der Wert 0 entspricht, muss er auch im Text nicht ausgegeben werden
                {
                    Ausgabe1.AusgabeText = Ausgabe1.AusgabeText + Environment.NewLine + text;
                }
                else {
                    Ausgabe1.AusgabeText = Ausgabe1.AusgabeText + Environment.NewLine + text + " - " + Zusatz.ToString();
                }             
                Ausgabe1.AusgabeZeitmessung = Ausgabe1.AusgabeZeitmessung + Zusatz;
            }
            else {
                //Eintrag nicht vorhanden, wird neu gesetzt
                Ausgabe1 = new KonsolenAusgabe(DateTime.Now.TimeOfDay, text, Zusatz);
            }
            Ausgeben = true;
        }
        public bool isAusgeben() {
            return Ausgeben;
        }
        public KonsolenAusgabe getKonsoleAusgabe() {
            Ausgeben = false;
            return Ausgabe1; 
        }

        public void SendOtherChannel (String Message, String Plattform)
        {
            OtherChannel.SendMessageToOtherChannel(Message, Plattform);
        }
        public void SendOtherChannel(String Message, String Plattform,ulong DiscordChannel)
        {
            OtherChannel.SendMessageToOtherChannel(Message, Plattform,DiscordChannel);
        }
        public bool IsOtherChannel() {
            return OtherChannel.isSendOtherChannel();
        }
        public OtherChannel getSendOtherChannel() {
            return OtherChannel;
        }
        public void OtherChannelDone()
        {
            OtherChannel.Done();
        }

     }
}
