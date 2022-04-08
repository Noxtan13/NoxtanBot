using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonBot.PlatformAPI.SettingsTypen
{
    class TwitchEvent
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

        public TwitchEvent(string name) {
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
            Use = load.Use;
            Chat = load.Chat;
            Discord = load.Discord;
            Konsole = load.Konsole;
            if (load.ChatText != null) { ChatText = load.ChatText; }
            if (load.DiscordText != null) { DiscordText = load.DiscordText; }
            if (load.KonsoleText != null) { KonsoleText = load.KonsoleText; }
            if (load.Channel != null) { Channel = load.Channel; }
        }

        public void UebernahmeWerte(bool use,bool chat, bool discord, bool konsole, String chatText, string discordText, string konsoleText, StringCollection channels)
        {
            Use = use;
            Chat = chat;
            Discord = discord;
            Konsole = konsole;
            
            if (chatText != null)
            {
                ChatText = chatText;
            }

            if (discordText != null)
            {
                DiscordText = discordText;
            }

            if (konsoleText != null)
            {
                KonsoleText = konsoleText;
            }

            if (channels != null)
            {
                Channel = channels;
            }
        }
    }
}
