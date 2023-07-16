using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonBot.PlatformAPI.ListenTypen
{
    public class EmbededMessage
    {
        public string ServerName { get; set; } //Name des Servers wo die Embeded Message gesendet werden soll
        public ulong ServerID { get; set; } //ID des Servers

        public string ChannelName { get; set; } //Name des Kanals des jeweiligen Servers, wo die Nachricht gesendet werden soll
        public ulong ChannelID { get; set; } //ID des Channels

        public string MessageName { get; set; } //Name der Nachricht, falls mehrere Nachrichten in einem Channel vorhanden sein sollen
        public ulong MessageID { get; set; } //ID der Nachricht

        public string MessageTitle { get; set; } //Der Titel der Nachricht, die angezeigt wird
        public string MessageFooter { get; set; } //Die Fußnote der Nachricht, die angezeigt wird
        public string MessageText { get; set; } //Der Nachrichtentext
    }

    public class EmbededMessageReactionRole : EmbededMessage {
        public List<ReactionRoleEntry> RollenEinträge = new List<ReactionRoleEntry>(); //Liste der Einträge von Emote - Rolle

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
        
        public int ID { get; set; } //Individuelle ID des Eintrages. Wird mit der Funktion GetNextID festgelegt
        public OwnEmote Emote { get; set; } //Der Emote, auf dem sich der Eintrag auswirkt
        public ulong RoleID { get; set; } //ID der Discord-Rolle
        public string RoleName { get; set; } //Name der Discord-Rolle
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
