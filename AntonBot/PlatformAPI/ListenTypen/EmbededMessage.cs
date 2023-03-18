using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonBot.PlatformAPI.ListenTypen
{
    class EmbededMessage
    {
        public string ServerName { get; set; }
        public ulong ServerID { get; set; }

        public string ChannelName { get; set; }
        public ulong ChannelID { get; set; }

        public string MessageName { get; set; }
        public ulong MessageID { get; set; }

        public string MessageTitle { get; set; }
        public string MessageFooter { get; set; }
        public string MessageText { get; set; }
    }

    class EmbededMessageReactionRole : EmbededMessage {
        public List<ReactionRoleEntry> RollenEinträge = new List<ReactionRoleEntry>();

        public EmbededMessageReactionRole() {
            ServerName = "";
            ServerID = 0;
            ChannelName = "";
            ChannelID = 0;
            MessageName = "";
            MessageID = 0;
            MessageTitle = "";
            MessageFooter = "";
            MessageText = "";
        }

        public void AddRollenEnträge(OwnEmote ownEmote, ulong roleID, string roleName) { 
            ReactionRoleEntry newEntry = new ReactionRoleEntry(ownEmote, roleID, roleName,getNextID());
            RollenEinträge.Add(newEntry);
        }
        public void RemoveEinträge(int iD) {
            ReactionRoleEntry Entry = new ReactionRoleEntry();
            foreach (var item in RollenEinträge) {
                if (item.ID == iD) {
                    Entry = item;
                }
            }

            if (Entry.ID != 0)
            {
                RollenEinträge.Remove(Entry);
            }
        }

        private int getNextID() {
            int ID = 0;
            foreach (var item in RollenEinträge) {
                if (item.ID > ID) {
                    ID = item.ID;
                }
            }
            ID++;
            return ID;
        }

        public void Save(EmbededMessage embededMessage) {
            ServerName = embededMessage.ServerName;
            ServerID = embededMessage.ServerID;
            ChannelName = embededMessage.ChannelName;
            ChannelID = embededMessage.ChannelID;
            MessageName = embededMessage.MessageName;
            MessageID = embededMessage.MessageID;
            MessageTitle = embededMessage.MessageTitle;
            MessageFooter = embededMessage.MessageFooter;
            MessageText = embededMessage.MessageText;
        }
    }

    public class ReactionRoleEntry {
        
        public int ID { get; set; }
        public OwnEmote Emote { get; set; }
        public ulong RoleID { get; set; }
        public string RoleName { get; set; }
        public ReactionRoleEntry(OwnEmote emote, ulong roleID, string roleName,int iD) {
            this.Emote = emote;
            this.RoleID = roleID;
            this.RoleName = roleName;
            this.ID = iD;
        }
        public ReactionRoleEntry() {
            this.Emote = null;
            this.RoleID = 0;
            this.RoleName = "";
            this.ID = 0;
        }
    }
}
