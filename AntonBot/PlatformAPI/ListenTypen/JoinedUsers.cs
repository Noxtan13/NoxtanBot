using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonBot.PlatformAPI
{
    //Die Klasse ist für die User, die meinem Channel in einer auffälligen weise (wenn ich offline bin und dies häufiger passert) joinen
    //Dies sind Bot User und sollten dann gesperrt werden
    class JoinedUsers
    {
        public string ID;
        public string Name;
        public DateTime LastJoined;
        public int Anzahl;

        public JoinedUsers(string id, string name) {
            this.ID = id;
            this.Name = name;
            this.LastJoined = DateTime.Now;
            this.Anzahl = 1;
        }
        public void NewJoined() {
            //Wenn der letze Join mehr als 7 Tage zurück liegt, so wir der Zähler zurückgesetzt
            var letzeWoche = DateTime.Now.AddDays(SettingsGroup.Instance.STwitchAutoBotDuration * -1);
            if (letzeWoche > LastJoined) {
                Anzahl = 1;
                LastJoined = DateTime.Now;
            }
            else
            {
                Anzahl = Anzahl + 1;
                LastJoined = DateTime.Now;
            }
        }

        public string getID() {
            return ID;
        }
        public string getName() {
            return Name;
        }
        public int getAnzahl() {
            return Anzahl;
        }
        public DateTime getLastJoined() {
            return LastJoined;
        }
    }
}
