﻿using System;

namespace AntonBot.PlatformAPI.ListenTypen
{
    internal class TwitchAdminBefehl
    {
        public String Name;
        public bool Use;
        public bool Admin;
        public bool Broadcast;
        public bool VIP;
        public String Command;
        public String ChatText;
        public String FailText;
        public String Reward;


        public TwitchAdminBefehl(string name)
        {
            Name = name;
            Admin = false;
            Broadcast = false;
            VIP = false;
            ChatText = "";
            Command = "";
            FailText = "";
            Reward = "";
            Use = false;
        }

        public void UpdateCommand(TwitchAdminBefehl load)
        {
            if (load != null)
            {
                Admin = load.Admin;
                Broadcast = load.Broadcast;
                VIP = load.VIP;
                if (load.ChatText != null) { ChatText = load.ChatText; }
                if (load.Command != null) { Command = load.Command; }
                if (load.FailText != null) { FailText = load.FailText; }
                if (load.Reward != null) { Reward = load.Reward; }
                Use = load.Use;
            }
        }
    }
}
