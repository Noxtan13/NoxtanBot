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
        public bool Broadcast;
        public bool VIP;
        public String Command;
        public String ChatText;
        public String FailText;
        

        public TwitchAdminBefehl(string name) {
            Name = name;
            Admin = false;
            Broadcast = false;
            VIP = false;
            ChatText = "";
            Command = "";
            FailText = "";
            Use = false;
        }

        public void UpdateCommand(TwitchAdminBefehl load) {
            if (load != null)
            {
                Admin = load.Admin;
                Broadcast = load.Broadcast;
                VIP = load.VIP;
                if (load.ChatText != null) { ChatText = load.ChatText; }
                if (load.Command != null) { Command = load.Command; }
                if (load.FailText != null) { FailText = load.FailText; }
                Use = load.Use;
            }
        }
    }
}
