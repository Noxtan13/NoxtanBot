using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace AntonBot.PlatformAPI
{
    internal class Telegramm_Function : Bot_Verwalter
    {
        private TelegramBotClient botClient = new TelegramBotClient("1142465921:AAG_XTLLtRlr3NPYSTcDEF--Ydn8GXK8ZYw");

        public void startBot()
        {

            var me = botClient.GetMeAsync().Result;
            KonsolenAusgabe("Hallo, ich bin ein TelegrammBot mit dem Namen " + me.FirstName);

            //botClient.OnMessage += BotClient_OnMessage;


            //botClient.StartReceiving();
        }

        public void stopBot()
        {
            //botClient.StopReceiving();
        }

        /*
        private async void BotClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {

            if (DateTime.Now.Date == e.Message.Date.Date)
            {
                //+2 weil die Zeit in UTC (London) angegeben wird und nicht in Deutscher Zeit
                //+1 in Winterzeit und +2 in Sommerzeit
                if (DateTime.Now.Hour == e.Message.Date.Hour+1)
                {
                    if (DateTime.Now.Minute == e.Message.Date.Minute)
                    {
                        await SendMessage(e.Message.Chat, CheckBefehlAllg(e.Message.Text, e.Message.From.FirstName));
                    }
                }
            }
        }
        */

        public async Task SendMessage(ChatId chatId, String Text)
        {
            await botClient.SendTextMessageAsync(chatId, Text);
        }
    }
}
