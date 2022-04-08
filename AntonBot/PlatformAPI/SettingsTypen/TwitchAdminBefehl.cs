using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonBot.PlatformAPI.ListenTypen
{
    class TwitchAdminBefehl
    {
        public String Name;
        public bool Use;
        public bool Admin;
        public bool Boardcast;
        public bool VIP;
        public String Command;
        public String ChatText;
        public String FailText;
        

        public TwitchAdminBefehl(string name) {
            Name = name;
            Admin = false;
            Boardcast = false;
            VIP = false;
            ChatText = "";
            Command = "";
            FailText = "";
            Use = false;
        }

        public void UpdateCommand(TwitchAdminBefehl load) {
            Admin = load.Admin;
            Boardcast = load.Boardcast;
            VIP = load.VIP;
            if (load.ChatText != null) { ChatText = load.ChatText; }
            if (load.Command != null) { Command = load.Command; }
            if (load.FailText != null) { FailText = load.FailText; }
            Use = load.Use;
        }

        public void UebernahmeWerte(bool use, bool admin, bool boardcast, bool vip, string chatText, string command, string failText) {
            Use = use;
            Admin = admin;
            Boardcast = boardcast;
            VIP = vip;
            if (command != null)
            {
                Command = command;
            }

            if (chatText != null)
            {
                ChatText = chatText;
            }

            if (failText != null)
            {
                FailText = failText;
            }         
        }
    }
}
