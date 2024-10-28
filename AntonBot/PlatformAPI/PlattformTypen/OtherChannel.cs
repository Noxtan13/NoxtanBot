using System;
using System.Collections.Generic;

namespace AntonBot.PlatformAPI
{
    public class OtherChannel
    {
        private bool SendOtherChannel = false;
        private List<OtherChannelMessage> ChannelMessages = new List<OtherChannelMessage>();
        private List<Int16> ID = new List<Int16>(); //Liste um die IDs abzuspeichern, die bereits gesendet worden sind. Wird beim Bot neustart zurückgesetzt
        private int IDCount = 0; //Aktuelle ID

        public void SendMessageToOtherChannel(String Message, String Plattform)
        {
            ChannelMessages.Add(new OtherChannelMessage(Message, Plattform));

            SendOtherChannel = true;
            //753593040731504751 ist die ID des Twitch-Spam-Chat

        }

        public void SendMessageToOtherChannel(String Message, String Plattform, ulong DicsordChannelID)
        {
            ChannelMessages.Add(new OtherChannelMessage(Message, Plattform, DicsordChannelID));

            SendOtherChannel = true;
            //753593040731504751 ist die ID des Twitch-Spam-Chat


        }

        public bool isSendOtherChannel()
        {
            return SendOtherChannel;
        }

        public void Done()
        {
            if (ChannelMessages.Count > 0 && SendOtherChannel == true)
            {
                ChannelMessages.RemoveAt(0);
                if (ChannelMessages.Count == 0)
                {
                    SendOtherChannel = false;
                }
            }
            //evlt. muss hier dies nochmal gesetzt werden, wenn bei der IF-Prüfung weiterhin fehler geworfen werden... (wenn auf 0 gesetzt wird, sollte SendOtherChannel false sein
            else
            {
                ChannelMessages.Clear();
                SendOtherChannel = false;
            }


        }

        public void Reset()
        {
            ChannelMessages.Clear();
            SendOtherChannel = false;
        }

        public String getNextPlattform()
        {

            return ChannelMessages[0].Destination;
        }
        public String getMessage()
        {
            return ChannelMessages[0].MessageOtherChannel;
        }
        public ulong getDiscordChannelID()
        {
            return ChannelMessages[0].Discordchannel;
        }
    }

    internal class OtherChannelMessage
    {
        public String MessageOtherChannel = ""; //Die Nachricht, die gesendet wird
        public String Destination = ""; //Der Channel, zu dem was gesendet wird
        public ulong Discordchannel = 0; //Die ID des Discord-Channels

        public OtherChannelMessage(string message, string destination, ulong discordChannel)
        {
            MessageOtherChannel = message;
            Destination = destination;
            Discordchannel = discordChannel;
        }
        public OtherChannelMessage(string message, string destination)
        {
            MessageOtherChannel = message;
            Destination = destination;
            Discordchannel = 0;
        }
    }
}
