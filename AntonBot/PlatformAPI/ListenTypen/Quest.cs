using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonBot.PlatformAPI.ListenTypen
{
    class Quest
    {
        public string ID;
        public string Name;
        public decimal AbschlussEXP;
        public bool isMain;
        public bool Abschluss;
        public bool Repeat;
        public int AnzahlAbschluss;
        public Quest(string name, decimal abschlussEXP, bool Main, bool abschluss, bool repeat, string id) {
            Name = name;
            AbschlussEXP = abschlussEXP;
            isMain = Main;
            if (id.Contains("S") || id.Contains("M")) {
                ID = id;
            }
            else
            {
                if (Main)
                {
                    ID = "M" + id.ToString();
                }
                else
                {
                    ID = "S" + id.ToString();
                }
            }
            Abschluss = abschluss;
            Repeat = repeat;
            AnzahlAbschluss = 0;
        }

        public void Update(string name, decimal abschlussEXP, bool abschluss, bool repeat)
        {
            Name = name;
            AbschlussEXP = abschlussEXP;
            Abschluss = abschluss;
            Repeat = repeat;
        }
    }
}
