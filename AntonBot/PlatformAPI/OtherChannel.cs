using System;
using System.Collections.Generic;

namespace AntonBot.PlatformAPI
{
    internal class OtherChannel
    {
        private bool SendOtherChannel = false;
        private List<OtherChannelMessage> ChannelMessages = new List<OtherChannelMessage>();

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
        public String MessageOtherChannel = "";
        public String Destination = "";
        public ulong Discordchannel = 0;

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
