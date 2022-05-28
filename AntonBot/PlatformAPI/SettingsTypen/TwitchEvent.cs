using System;
using System.Collections.Specialized;

namespace AntonBot.PlatformAPI.SettingsTypen
{
    internal class TwitchEvent
    {
        public String Name;
        public bool Use;
        public bool Chat;
        public String ChatText;
        public bool Discord;
        public String DiscordText;
        public StringCollection Channel;
        public bool Konsole;
        public String KonsoleText;

        public TwitchEvent(string name)
        {
            Name = name;
            Use = false;
            Chat = false;
            ChatText = "";
            Discord = false;
            DiscordText = "";
            Channel = new StringCollection();
            Konsole = false;
            KonsoleText = "";
        }

        public void UpdateCommand(TwitchEvent load)
        {
            if (load != null)
            {
                Use = load.Use;
                Chat = load.Chat;
                Discord = load.Discord;
                Konsole = load.Konsole;
                if (load.ChatText != null) { ChatText = load.ChatText; }
                if (load.DiscordText != null) { DiscordText = load.DiscordText; }
                if (load.KonsoleText != null) { KonsoleText = load.KonsoleText; }
                if (load.Channel != null) { Channel = load.Channel; }
            }
        }
    }
}
