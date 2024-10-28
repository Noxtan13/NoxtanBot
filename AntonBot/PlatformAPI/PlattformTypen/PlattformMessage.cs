using System;
using System.Collections.Generic;

namespace AntonBot.PlatformAPI.PlattformTypen
{
    public class PlattformMessage
    {
        private static PlattformMessage _instance;
        private static readonly object _lock = new object();

        public static PlattformMessage Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new PlattformMessage();
                    }
                    return _instance;
                }
            }
        }

        private PlattformMessage()
        {
            ListOfMessages = new List<Message>();
            ListOfIDs = new List<ulong>();
            ID = 0;
        }

        private List<Message> ListOfMessages;
        private List<ulong> ListOfIDs;
        private ulong ID;
        private bool ReadStatus; 

        public void SaveMessage(String Message, String Plattform, ulong DiscordChannelID=0) {
            ID += 1;
            ListOfMessages.Add(new Message(Message, Plattform, DiscordChannelID, ID));
        }

        public void StartReadMessage()
        {
            if( !ReadStatus )
            {
                if (ListOfMessages.Count > 0)
                {
                    Message message = ListOfMessages[0];
                    if(ListOfIDs.Contains(message.ID)==false) //ID nicht vorhanden, also noch nicht gelesen
                    {
                        ReadStatus = true;
                    }                  
                }
            }
        }
        public void ReadMessageDone()
        {
            Message LastMessage = ListOfMessages[0];
            ListOfIDs.Add(LastMessage.ID);
            ListOfMessages.RemoveAt(0);
            ReadStatus = false;

        }

        public string ReadMessage() {
            if (ReadStatus)
            {
                return ListOfMessages[0].MessageOtherChannel;
            }
            else { return ""; }

        }
        public string ReadDestination() {
            if (ReadStatus)
            {
                return ListOfMessages[0].Destination;
            }
            else { return ""; }

        }
        public ulong ReadDiscordChannel()
        {
            if (ReadStatus)
            {
                return ListOfMessages[0].Discordchannel;
            }
            else { return 0; }
        }

        public bool NeedToSend() {
            if (!ReadStatus && ListOfMessages.Count > 0) {
                return true;
            }
            else
            {
                return false;
            }
        }    

    }

    internal class Message
    {
        public String MessageOtherChannel = ""; //Die Nachricht, die gesendet wird
        public String Destination = ""; //Der Channel, zu dem was gesendet wird
        public ulong Discordchannel = 0; //Die ID des Discord-Channels
        public ulong ID; //Die ID der Nachricht

        public Message(string message, string destination, ulong discordChannel, ulong Id)
        {
            MessageOtherChannel = message;
            Destination = destination;
            Discordchannel = discordChannel;
            ID = Id;
        }


    }
}
