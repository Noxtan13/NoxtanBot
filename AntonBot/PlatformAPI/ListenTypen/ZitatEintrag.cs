using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonBot.PlatformAPI.ListenTypen
{
    public class ZitatEintrag
    {
        public String Zitat { get; set; }
        public String Ersteller { get; set; }
        public DateTime ZitatZeitpunkt { get; }
        public String Plattform { get; set; }
        public int Number { get; set; }

        public ZitatEintrag(String zitat, String ersteller, String plattform) { 
            this.Zitat = zitat;
            this.Ersteller = ersteller;
            this.Plattform = plattform;
            this.ZitatZeitpunkt = DateTime.Now;
        }
    }
}
