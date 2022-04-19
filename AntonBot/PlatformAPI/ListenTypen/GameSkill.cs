using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonBot.PlatformAPI.ListenTypen
{
    class GameSkill
    {
        public string Game;
        public string GameID; //wird nur vom Programm gesetzt. Evtl. auch einfach nicht verwenden
        public int Level;
        public decimal EXP;
        public decimal EXPNextLevel;
        public int Wachstumsart; //evlt auch einfach aus PKMN übernehmen https://www.pokewiki.de/Erfahrung
        public decimal EXPTillNextLevel;

        public List<Quest> MainQuest;
        public List<Quest> SideQeust;

        //Liste Sidequest (mit Zusatzfeld wie häufig es gemacht wurde, wenn wiederholung + ID)
        //Liste Hauptquest (mit zusatzfeld zum abspeichern, ob erl. oder nicht + ID)
        public GameSkill(string game) {
            Game = game;
            GameID = "0";
            Level = 1;
            EXP = 0;
            EXPNextLevel = 1;
            EXPTillNextLevel = 1;
            Wachstumsart = 0;
            MainQuest = new List<Quest>();
            MainQuest.Add(new Quest("Tutorial", 1, true, false, false, "0"));
            SideQeust = new List<Quest>();
        }
        private void Nextlevel() {
            Level += 1;
            SetEXP();
            Checklevel();
        }
        private void Checklevel() {
            if (EXP >= EXPNextLevel) {
                Nextlevel();
            }
        }

        private void SetEXP() {
            decimal altEXP = EXPNextLevel;
            switch (Wachstumsart)
            {
                case 1:
                    //leicht
                    EXPNextLevel = (4*Convert.ToInt32(Math.Pow(Level,3))) / 5;
                    break;
                case 2:
                    EXPNextLevel = Convert.ToInt32(Math.Pow(Level,3));
                    //mittel
                    break;
                case 3:
                    EXPNextLevel = 6/5*Convert.ToInt32(Math.Pow(Level,3))-15*Convert.ToInt32(Math.Pow(Level,2))+100*Level-140;
                    //schwer
                    break;
                case 4:
                    //sehr schwer
                    EXPNextLevel = (5 * Convert.ToInt32(Math.Pow(Level, 3))) / 4;
                    break;
            }
            EXPTillNextLevel = EXPNextLevel - altEXP - (EXP-altEXP);          
        }

        public void GetEXP(decimal amount) {
            EXP += amount;
            EXPTillNextLevel -= amount;
            Checklevel();
        }

        public void UpdateLevelEXP() {
            if (EXP == 0)
            {
                Level = Level - 1;
                SetEXP();
                EXP = EXPNextLevel;
                Checklevel();
            }
            else {
                Level = 1;
                EXPTillNextLevel = 1;
                SetEXP();
                Checklevel();
            }
        }

        public decimal getEXPlastLevel() {
            decimal Ergebnis = 0;
            int Altlevel = 1;
            if (Level > 1) {
                Altlevel = Level - 1;
            }

            switch (Wachstumsart)
            {
                case 1:
                    //leicht
                    Ergebnis = (4 * Convert.ToInt32(Math.Pow(Altlevel, 3))) / 5;
                    break;
                case 2:
                    Ergebnis = Convert.ToInt32(Math.Pow(Altlevel, 3));
                    //mittel
                    break;
                case 3:
                    Ergebnis = 6 / 5 * Convert.ToInt32(Math.Pow(Altlevel, 3)) - 15 * Convert.ToInt32(Math.Pow(Altlevel, 2)) + 100 * Altlevel - 140;
                    //schwer
                    break;
                case 4:
                    //sehr schwer
                    Ergebnis = (5 * Convert.ToInt32(Math.Pow(Altlevel, 3))) / 4;
                    break;
            }
            return Ergebnis;
        }
        //Aufbau von Befehlen (als Beispiel)
        /*
        !Mainquest <name> <Erfahrung>
        --> Antwort mit ID
        !Subquest <name> <Erfahrung>
        !clear <ID>
        !EXP, !LEVEL, SideQuest, MainQuest (Ausgabe mit IDs)
        !Update <ID> <...>
        . delete -> zum löschen
        . Buchstabe + Nummer -> Update der Punkte /Buchstabe S für Sidequest. M für Mainquest
        
         */
    }
}
