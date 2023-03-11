using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AntonBot.PlatformAPI.ListenTypen
{
    public class OwnEmote
    {
        public String ServerName { get; set; }
        public ulong ServerID { get; set; }
        public ulong ID { get; set; }
        public String Name { get; set; }
        public String URL { get; set; }

        public Bitmap getEmoteBitmap() {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(URL);
            Bitmap bitmap;
            bitmap = new Bitmap(stream);

            stream.Flush();
            stream.Close();
            client.Dispose();

            if (bitmap != null)
            {
                return bitmap;
            }
            else {
                LogWriter.LogWrite("EMOTE -- geladenes Bild "+Name+" ist leer. URL: " + URL);
                return null;
            }
        }
    }
}
