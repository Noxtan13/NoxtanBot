using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace AntonBot.PlatformAPI.ListenTypen
{
    public class OwnEmote
    {
        public String ServerName { get; set; } //Servername, von dem der Emote stammt. Ist der Code des Emotes, wenn das ein Unicode Emote ist. Entweder der Langecode wie "\U0001f958" oder als Emote direkt 😊
        public ulong ServerID { get; set; } //ID des Servers, von dem der Emote stammt. Ist 1 wenn ein Unicode Emote verwendet wird
        public ulong ID { get; set; } //ID des Emotes. Ist vorerst 1, wenn Unicode Emote (evtl. kann ich es für Unicode Emote noch verwenden)
        public String Name { get; set; } //Vollständigen Namen des Emotes
        public String URL { get; set; } //URL des Bildes
        public bool isUniEmote { get; set; }
        public OwnEmote()
        {
            ServerName = "";
            ServerID = 0;
            ID = 0;
            Name = "";
            URL = "";
            isUniEmote = false;
        }
        public OwnEmote(string name)
        {
            ServerName = EmojiOne.EmojiOne.ShortnameToUnicode(name);
            ServerID = 1;
            ID = 1;
            Name = EmojiOne.EmojiOne.ToShort(name);

            string URLPattern = "src=\\\"(\\S*)\\\"";
            string test = EmojiOne.EmojiOne.ToImage(Name);
            Match m = Regex.Match(test, URLPattern, RegexOptions.IgnoreCase);
            if (m.Success)
            {
                URL = m.Groups[1].Value;
            }
            else
            {
                URL = "";
            }
            isUniEmote = true;
        }

        public Bitmap getEmoteBitmap()
        {
            if (URL != "")
            {
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
                else
                {
                    LogWriter.LogWrite("EMOTE -- geladenes Bild " + Name + " ist leer. URL: " + URL);
                    return null;
                }
            }
            else
            {
                LogWriter.LogWrite("EMOTE -- geladenes Bild " + Name + " ist leer, weil die URL nicht vorhanden ist");
                return null;
            }
        }
    }
}
