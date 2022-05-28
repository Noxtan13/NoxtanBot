using System;
using System.Collections.Specialized;

namespace AntonBot.PlatformAPI.SettingsTypen
{
    internal class DiscordEvent
    {
        public String Name;
        public bool Use;
        public bool Twitch;
        public String TwitchText;
        public bool Discord;
        public String DiscordText;
        public StringCollection Channel;
        public bool Konsole;
        public String KonsoleText;

        public DiscordEvent(string name)
        {
            Name = name;
            Use = false;
            Twitch = false;
            TwitchText = "";
            Discord = false;
            DiscordText = "";
            Channel = new StringCollection();
            Konsole = false;
            KonsoleText = "";
        }

        public void UpdateCommand(DiscordEvent load)
        {
            if (load != null)
            {
                Use = load.Use;
                Twitch = load.Twitch;
                Discord = load.Discord;
                Konsole = load.Konsole;
                if (load.TwitchText != null) { TwitchText = load.TwitchText; }
                if (load.DiscordText != null) { DiscordText = load.DiscordText; }
                if (load.KonsoleText != null) { KonsoleText = load.KonsoleText; }
                if (load.Channel != null) { Channel = load.Channel; }
            }
        }
    }
}
