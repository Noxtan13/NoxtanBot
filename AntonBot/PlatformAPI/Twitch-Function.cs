using AntonBot.PlatformAPI;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TwitchLib.Api;
using TwitchLib.Api.Core.Enums;
using TwitchLib.Api.Services;
using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;
using TwitchLib.PubSub;

namespace AntonBot
{
    class TwitchFunction : Bot_Verwalter
    {
        public TwitchClient tcClient = new TwitchClient();

        LiveStreamMonitorService lsmMonitor;
        FollowerService fsFollower;
        TwitchAPI TwitchAPI;
        TwitchPubSub twitchPupSub;



        //List<TwitchLib.Api.Helix.Models.Users.Follow> FollowerList;

        String sStandardChannel = "";
        String sChannelID = "";

        private List<Befehl> lTwitchBefehlListe = new List<Befehl>();

        TwitchLib.Api.Helix.Models.Streams.GetStreams.Stream StreamData;

        List<TwitchLib.Api.Helix.Models.Users.GetUserFollows.Follow> FollowerList;



        bool bSleepMessage = false;
        string sSleepMessage = "";
        string sSleepTarget = "";
        int iSleepDelay = 0;

        List<String> lUserInChat = new List<string>();
        List<JoinedUsers> lJoinedUsers = new List<JoinedUsers>();

        TwitchLib.Api.Helix.Models.Clips.GetClips.Clip[] Lastclips;
        String sRaidMessage = "Noch kein Stream gestartet";

        public void StartBot()
        {

            if (StartBotCheck())
            {
                StartBotDienste();
            }

        }

        private bool StartBotCheck()
        {
            if (SettingsGroup.Instance.TsAccessToken.Equals(""))
            {
                KonsolenAusgabe("Es ist kein AccessToken verfügbar!" + Environment.NewLine + "Bitte Einrichtung durchführen");
                return false;
            }
            else if (SettingsGroup.Instance.TsStandardChannel.Equals(""))
            {
                KonsolenAusgabe("Es ist kein StandardChannel eingetragen!" + Environment.NewLine + "Bitte Einrichtung durchführen");
                return false;
            }
            else
            {
                if (SettingsGroup.Instance.Tschat_read && SettingsGroup.Instance.Tschat_edit)
                {

                    TwitchAPI = new TwitchAPI();

                    TwitchAPI.Settings.ClientId = SettingsGroup.Instance.TsclientID;
                    TwitchAPI.Settings.AccessToken = SettingsGroup.Instance.TsAccessToken;


                    if (CheckTokenValidation(SettingsGroup.Instance.TsAccessToken))
                    {

                        if (SettingsGroup.Instance.TsPubSubZusatz)
                        {
                            //Wenn für den PubSub ein anderer Token verwendet wird, so wird dieser hier noch geprüft. Bei gleichen Token wird dann einfach True zurückgegeben

                            if (CheckTokenValidation(SettingsGroup.Instance.TsAccessTokenPubSub))
                            {
                                return true;
                            }
                            else
                            {
                                KonsolenAusgabe("Der Twitch-PubSub-Token passt nicht. Bitte prüfe diesen und fodere ihn neu an");
                                return false;
                            }
                        }
                        else
                        {
                            return true;
                        }

                    }
                    else
                    {
                        KonsolenAusgabe("Der Twitch-Token für den Standardbenutzer passt nicht. Bitte prüfe diesen und fodere ihn neu an");
                        return false;
                    }
                }
                else
                {
                    KonsolenAusgabe("Der Bot besitzt nicht die Standard-Berechtigungen für 'chat_read' und 'chat_edit'. Eine Verwendung ist gerade nicht mögich. Bitte fordere die Berechtigungen unter 'Plattform-Einstellungen' - 'Twitch' an");
                    return false;
                }
            }
        }
        private void StartBotDienste()
        {

            bool erfolgreich = true;
            ConnectionCredentials credentials = new ConnectionCredentials("antonbot", "oauth:" + SettingsGroup.Instance.TsAccessToken, "irc://irc.chat.twitch.tv:6697");


            var Standardchannel = searchOneChannel(SettingsGroup.Instance.TsStandardChannel);

            if (Standardchannel != null)
            {


                lsmMonitor = new LiveStreamMonitorService(TwitchAPI, 60);
                fsFollower = new FollowerService(TwitchAPI, 30);


                sStandardChannel = Standardchannel.BroadcasterLogin;
                sChannelID = Standardchannel.Id;

                var clientOptions = new ClientOptions
                {
                    MessagesAllowedInPeriod = 750,
                    ThrottlingPeriod = TimeSpan.FromSeconds(30)
                };
                WebSocketClient customClient = new WebSocketClient(clientOptions);
                tcClient = new TwitchClient(customClient);

                tcClient.Initialize(credentials, "noxtan13");

                //client.OnLog += Client_OnLog;
                tcClient.OnJoinedChannel += Client_OnJoinedChannel;
                tcClient.OnMessageReceived += Client_OnMessageReceived;
                tcClient.OnWhisperReceived += Client_OnWhisperReceived;
                tcClient.OnNewSubscriber += Client_OnNewSubscriber;
                tcClient.OnConnected += Client_OnConnected;
                tcClient.OnBeingHosted += Client_OnBeingHosted;
                tcClient.OnRaidNotification += Client_OnRaidNotification;

                tcClient.OnUserJoined += Client_OnUserJoined;
                tcClient.OnExistingUsersDetected += Client_OnExistingUsersDetected;

                tcClient.OnError += TcClient_OnError;
                tcClient.OnNoPermissionError += TcClient_OnNoPermissionError;
                tcClient.OnConnectionError += TcClient_OnConnectionError;

                tcClient.OnIncorrectLogin += TcClient_OnIncorrectLogin;
                tcClient.OnUserLeft += TcClient_OnUserLeft;
                try
                {
                    tcClient.Connect();

                }
                catch (Exception e)
                {
                    KonsolenAusgabe("client.Connect() konnte nicht durchgeführt werden." + Environment.NewLine + "Excpetion-Message: " + Environment.NewLine + e.Message + Environment.NewLine + "InnerException: " + Environment.NewLine + e.InnerException);
                    erfolgreich = false;
                    throw;
                }




                List<string> lst = new List<string> { sChannelID };
                lsmMonitor.SetChannelsById(lst);
                fsFollower.SetChannelsById(lst);


                lsmMonitor.OnStreamOnline += Monitor_OnStreamOnline;
                lsmMonitor.OnStreamOffline += Monitor_OnStreamOffline;
                lsmMonitor.OnStreamUpdate += Monitor_OnStreamUpdate;

                fsFollower.OnNewFollowersDetected += Follower_OnNewFollowersDetected;

                twitchPupSub = new TwitchPubSub();

                twitchPupSub.OnBitsReceived += TwitchPupSub_OnBitsReceived;
                twitchPupSub.OnRaidGo += TwitchPupSub_OnRaidGo;

                //twitchPupSub.OnRewardRedeemed

                twitchPupSub.OnChannelPointsRewardRedeemed += TwitchPupSub_OnChannelPointsRewardRedeemed;

                twitchPupSub.OnPubSubServiceError += TwitchPupSub_OnPubSubServiceError;
                twitchPupSub.OnPubSubServiceConnected += TwitchPupSub_OnPubSubServiceConnected;
                twitchPupSub.OnPubSubServiceClosed += TwitchPupSub_OnPubSubServiceClosed;
                twitchPupSub.OnListenResponse += TwitchPupSub_OnListenResponse;




                //twitchPupSub.OnFollow wird geworfen, wenn ich jemanden Folge
                if (SettingsGroup.Instance.Tsbits_read)
                {
                    twitchPupSub.ListenToBitsEventsV2(sChannelID);

                }
                if (SettingsGroup.Instance.Tsuser_edit)
                {
                    twitchPupSub.ListenToRaid(sChannelID);
                }
                if (SettingsGroup.Instance.Tschannel_read_redemptions)
                {
                    twitchPupSub.ListenToChannelPoints(sChannelID);
                }


                try
                {
                    twitchPupSub.Connect();
                    //twitchPupSub.SendTopics();
                }
                catch (Exception e)
                {
                    KonsolenAusgabe("twitchPupSub.Connect() konnte nicht durchgeführt werden." + Environment.NewLine + "Excpetion-Message: " + Environment.NewLine + e.Message + Environment.NewLine + "InnerException: " + Environment.NewLine + e.InnerException);
                    erfolgreich = false;
                    throw;
                }

                try
                {

                    lsmMonitor.Start();
                }
                catch (Exception e)
                {
                    KonsolenAusgabe("Monitor.Start() konnte nicht durchgeführt werden." + Environment.NewLine + "Excpetion-Message: " + Environment.NewLine + e.Message + Environment.NewLine + "InnerException: " + Environment.NewLine + e.InnerException);
                    erfolgreich = false;
                    throw;
                }

                try
                {
                    fsFollower.Start();
                }
                catch (Exception e)
                {
                    KonsolenAusgabe("Follower.Start() konnte nicht durchgeführt werden." + Environment.NewLine + "Excpetion-Message: " + Environment.NewLine + e.Message + Environment.NewLine + "InnerException: " + Environment.NewLine + e.InnerException);
                    erfolgreich = false;
                    throw;
                }



                fsFollower.UpdateLatestFollowersAsync(false);



                lsmMonitor.UpdateLiveStreamersAsync();

                //Sollte irgeindein Teil des Twitch-Bots nicht funktionieren, so werden die weiteren Funktionen nicht durchgeführt
                if (erfolgreich)
                {
                    //Das erste mal, wenn der Bot gestartet wird und die Liste noch leer ist, werden alle Follower in die Liste geladen

                    FollowerlistAufbau();
                    getCurrentClips();
                    LoadUserJoinedList();
                    Active = true;
                    Restart = false;

                    //Am Ende werden dann noch alle Tokens überprüft
                    TestAllCurrentTokens();
                }
            }
            else
            {
                KonsolenAusgabe("Der verwendete ChannelName " + SettingsGroup.Instance.TsStandardChannel + " exsistiert nicht. Bitte überprüfe den Namen in den Einstellungen oder versuche es erneut.");
            }
        }

        private void FollowerlistAufbau()
        {
            FollowerList = new List<TwitchLib.Api.Helix.Models.Users.GetUserFollows.Follow>();
            try
            {
                var Antwort = TwitchAPI.Helix.Users.GetUsersFollowsAsync(first: 100, toId: sChannelID, accessToken: SettingsGroup.Instance.TsAccessToken);
                //long Total = Antwort.Result.TotalFollows; //wird aktuell nicht benötigt. Falls ich eine Anzahl aller Follows benötige, kann der Kommentar hier entfernt werden
                String Pagkey = Antwort.Result.Pagination.Cursor;
                FollowerList.AddRange(Antwort.Result.Follows);

                while (Pagkey != null)
                {
                    var Abfrage = TwitchAPI.Helix.Users.GetUsersFollowsAsync(after: Pagkey, first: 100, toId: sChannelID, accessToken: SettingsGroup.Instance.TsAccessToken);
                    Pagkey = Abfrage.Result.Pagination.Cursor;
                    FollowerList.AddRange(Abfrage.Result.Follows);
                }
            }
            catch (Exception e) {
                KonsolenAusgabe("Aufbau der FollowerListe ist auf ein Fehler gelaufen: " + e.Message);
            }
        }

        #region Events

        private void TwitchPupSub_OnBitsReceived(object sender, TwitchLib.PubSub.Events.OnBitsReceivedArgs e)
        {
            string Variablen = "ChannelID + Name: " + e.ChannelId + " - " + e.ChannelName + Environment.NewLine + "UserID + Name: " + e.UserId + " - " + e.Username
                + Environment.NewLine + "Chat-Message: " + e.ChatMessage + Environment.NewLine + "Context: " + e.Context + "Bits / Gesamt:" + e.BitsUsed + " -/- " + e.TotalBitsUsed;
            KonsolenAusgabe("OnBitsReceived wurde ausgelöst:" + Environment.NewLine + Variablen);


            if (SettingsGroup.Instance.TeBitsReaction)
            {
                String Path = System.Windows.Forms.Application.StartupPath + System.IO.Path.DirectorySeparatorChar + "BitListe.json";
                String InhaltJSON;

                if (System.IO.File.Exists(Path))
                {
                    //FileStream stream = File.OpenRead(Path);
                    InhaltJSON = System.IO.File.ReadAllText(Path);

                    List<BitElement> BitListe;

                    try
                    {
                        BitListe = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BitElement>>(InhaltJSON);
                    }
                    catch (Exception Fehler)
                    {
                        KonsolenAusgabe("Die Befehlsliste beinhaltet nicht die erwarteten Einstellungen oder ist beschädigt. Es wird eine leere Liste verwendet. \n Weitere Informationen: \n\n" + Fehler.InnerException.ToString());
                        BitListe = new List<BitElement>();
                    }

                    BitElement element = new BitElement();

                    foreach (var item in BitListe)
                    {
                        if (item.KeinBereich)
                        {
                            if (item.AbBetrag == e.BitsUsed)
                            {
                                element = item;
                            }
                        }
                        else
                        {
                            if (e.BitsUsed >= item.AbBetrag && e.BitsUsed <= item.BisBetrag)
                            {
                                element = item;
                            }
                        }
                    }

                    //Die ID fängt immer mit 1 an zu zählen. Also bedeutet die ID 0 nicht gefunden
                    if (element.ID == 0)
                    {
                        //Wenn Bits gespendet wurde, aber kein Betrag dafür gefunden worden ist.
                    }
                    else
                    {
                        //Bits wurden gespendet und ein Betrag wurde gefunden.

                        SendMessage(OnBitsReplace(element.ChatText, e), sStandardChannel);

                        if (element.Sound)
                        {
                            if (element.playSound())
                            {
                                KonsolenAusgabe("Bit-Sound wurde abgespielt");
                                //Rückgabewert true bedeutet, dass der Sound abgespielt wird
                            }
                            else
                            {
                                KonsolenAusgabe("Bit-Sound wurde nicht gefunden");
                                //Rückgabewert false bedeutet, dass der Sound nicht gefunden wurde
                            }
                        }

                        if (element.AusgabeKonsole)
                        {
                            KonsolenAusgabe(OnBitsReplace(element.ChatText, e));
                        }
                    }
                }
                else
                {
                    KonsolenAusgabe("Bit-Event wurde zwar ausgelöst, aber die Datei in der sich die Reaktionen finden, ist aktuell nicht vorhanden");
                }

            }
        }
        private String OnBitsReplace(string Text, TwitchLib.PubSub.Events.OnBitsReceivedArgs e)
        {

            Text = Text.Replace("°ChannelId", e.ChannelId);
            Text = Text.Replace("°ChannelName", e.ChannelName);
            Text = Text.Replace("°UserId", e.UserId);
            Text = Text.Replace("°UserName", e.Username);
            Text = Text.Replace("°ChatMessage", e.ChatMessage);
            Text = Text.Replace("°Context", e.Context);
            Text = Text.Replace("°BitsUsed", e.BitsUsed.ToString());
            Text = Text.Replace("°TotalBitsUsed", e.TotalBitsUsed.ToString());

            return Text;
        }

        private void Monitor_OnStreamUpdate(object sender, TwitchLib.Api.Services.Events.LiveStreamMonitor.OnStreamUpdateArgs e)
        {

            if (SettingsGroup.Instance.TeOnStreamUpdate)
            {
                if (e.Channel == sChannelID || e.Channel == sStandardChannel)
                {
                    if (SettingsGroup.Instance.TeOnStreamUpdateChat)
                    {
                        string Text = SettingsGroup.Instance.TeOnStreamUpdateChatText;

                        Text.Replace("°Channel", e.Channel);

                        //Es soll das Event nur dann geworfen werden, wenn sich die Daten auch geändert haben

                        if (OnStreamUpdateCheck(Text, StreamData, e) == true)
                        {
                            Text = OnStreamUpdateReplace(Text, e);
                            SendMessage(Text, sStandardChannel);
                        }
                    }
                    if (SettingsGroup.Instance.TeOnStreamUpdate)
                    {
                        string Text = SettingsGroup.Instance.TeOnStreamUpdateDiscordText;
                        Text.Replace("°Channel", e.Channel);
                        if (OnStreamUpdateCheck(Text, StreamData, e) == true)
                        {
                            Text = OnStreamUpdateReplace(Text, e);
                            foreach (var item in SettingsGroup.Instance.TeOnStreamUpdateChannel)
                            {
                                SendOtherChannel(Text, "Discord", Convert.ToUInt64(item));
                            }
                        }
                    }
                    if (SettingsGroup.Instance.TeOnStreamUpdateKonsole)
                    {
                        string Text = SettingsGroup.Instance.TeOnStreamUpdateKonsoleText;
                        Text.Replace("°Channel", e.Channel);
                        if (OnStreamUpdateCheck(Text, StreamData, e) == true)
                        {
                            Text = OnStreamUpdateReplace(Text, e);
                            KonsolenAusgabe(Text);
                        }
                    }
                }
            }
            StreamData = e.Stream;
        }
        private Boolean OnStreamUpdateCheck(string Text, TwitchLib.Api.Helix.Models.Streams.GetStreams.Stream AltStreamData, TwitchLib.Api.Services.Events.LiveStreamMonitor.OnStreamUpdateArgs NeuStreamData)
        {
            bool schalter = false;
            if (Text.Contains("°GameId") && AltStreamData.GameId != NeuStreamData.Stream.GameId)
            {
                schalter = true;
            }
            if (Text.Contains("°Id") && AltStreamData.Id != NeuStreamData.Stream.Id)
            {
                schalter = true;
            }
            if (Text.Contains("°Language") && AltStreamData.Language != NeuStreamData.Stream.Language)
            {
                schalter = true;
            }
            if (Text.Contains("°StartedAt") && AltStreamData.StartedAt != NeuStreamData.Stream.StartedAt)
            {
                schalter = true;
            }
            if (Text.Contains("°Title") && AltStreamData.Title != NeuStreamData.Stream.Title)
            {
                schalter = true;
            }
            if (Text.Contains("°Type") && AltStreamData.Type != NeuStreamData.Stream.Type)
            {
                schalter = true;
            }
            if (Text.Contains("°UserId") && AltStreamData.UserId != NeuStreamData.Stream.UserId)
            {
                schalter = true;
            }
            if (Text.Contains("°UserName") && AltStreamData.UserName != NeuStreamData.Stream.UserName)
            {
                schalter = true;
            }
            if (Text.Contains("°ViewerCount") && AltStreamData.ViewerCount != NeuStreamData.Stream.ViewerCount)
            {
                schalter = true;
            }

            return schalter;
        }
        private String OnStreamUpdateReplace(string Text, TwitchLib.Api.Services.Events.LiveStreamMonitor.OnStreamUpdateArgs e)
        {

            Text = Text.Replace("°GameId", GameByID(e.Stream.GameId));
            //Text = Text.Replace("°Id", e.Stream.Id);
            Text = Text.Replace("°Language", e.Stream.Language);
            Text = Text.Replace("°StartedAt", e.Stream.StartedAt.ToString());
            Text = Text.Replace("°Title", e.Stream.Title);
            Text = Text.Replace("°Type", e.Stream.Type);
            Text = Text.Replace("°UserID", e.Stream.UserId);
            Text = Text.Replace("°UserName", e.Stream.UserName);
            Text = Text.Replace("°ViewerCount", e.Stream.ViewerCount.ToString());

            TimeSpan tDuration = DateTime.Now - e.Stream.StartedAt.ToLocalTime();

            Text = Text.Replace("°Hours", tDuration.Hours.ToString());
            Text = Text.Replace("°Minutes", tDuration.Minutes.ToString());
            Text = Text.Replace("°Seconds", tDuration.Seconds.ToString());


            return Text;
        }
        private String OnStreamOfflineReplace(string Text, TwitchLib.Api.Services.Events.LiveStreamMonitor.OnStreamOfflineArgs e)
        {

            Text = Text.Replace("°GameId", GameByID(e.Stream.GameId));
            //Text = Text.Replace("°Id", e.Stream.Id);
            Text = Text.Replace("°Language", e.Stream.Language);
            Text = Text.Replace("°StartedAt", e.Stream.StartedAt.ToString());
            Text = Text.Replace("°Title", e.Stream.Title);
            Text = Text.Replace("°Type", e.Stream.Type);
            Text = Text.Replace("°UserID", e.Stream.UserId);
            Text = Text.Replace("°UserName", e.Stream.UserName);
            Text = Text.Replace("°ViewerCount", e.Stream.ViewerCount.ToString());

            TimeSpan tDuration = DateTime.Now - e.Stream.StartedAt.ToLocalTime();

            Text = Text.Replace("°Hours", tDuration.Hours.ToString());
            Text = Text.Replace("°Minutes", tDuration.Minutes.ToString());
            Text = Text.Replace("°Seconds", tDuration.Seconds.ToString());


            return Text;
        }
        private String OnStreamOnlineReplace(string Text, TwitchLib.Api.Services.Events.LiveStreamMonitor.OnStreamOnlineArgs e)
        {

            Text = Text.Replace("°GameId", GameByID(e.Stream.GameId));
            //Text = Text.Replace("°Id", e.Stream.Id);
            Text = Text.Replace("°Language", e.Stream.Language);
            Text = Text.Replace("°StartedAt", e.Stream.StartedAt.ToString());
            Text = Text.Replace("°Title", e.Stream.Title);
            Text = Text.Replace("°Type", e.Stream.Type);
            Text = Text.Replace("°UserID", e.Stream.UserId);
            Text = Text.Replace("°UserName", e.Stream.UserName);
            Text = Text.Replace("°ViewerCount", e.Stream.ViewerCount.ToString());

            TimeSpan tDuration = DateTime.Now - e.Stream.StartedAt.ToLocalTime();

            Text = Text.Replace("°Hours", tDuration.Hours.ToString());
            Text = Text.Replace("°Minutes", tDuration.Minutes.ToString());
            Text = Text.Replace("°Seconds", tDuration.Seconds.ToString());


            return Text;
        }
        private void Monitor_OnStreamOffline(object sender, TwitchLib.Api.Services.Events.LiveStreamMonitor.OnStreamOfflineArgs e)
        {

            if (SettingsGroup.Instance.TeOnStreamOffline)
            {
                if (e.Channel == sChannelID || e.Channel == sStandardChannel)
                {
                    if (SettingsGroup.Instance.TeOnStreamOfflineChat)
                    {
                        string Text = SettingsGroup.Instance.TeOnStreamOfflineChatText;

                        Text.Replace("°Channel", e.Channel);
                        Text = OnStreamOfflineReplace(Text, e);

                        SendMessage(Text, sStandardChannel);
                    }
                    if (SettingsGroup.Instance.TeOnStreamOfflineDiscord)
                    {
                        string Text = SettingsGroup.Instance.TeOnStreamOfflineDiscordText;

                        Text.Replace("°Channel", e.Channel);
                        Text = OnStreamOfflineReplace(Text, e);

                        foreach (var item in SettingsGroup.Instance.TeOnStreamOfflineChannel)
                        {
                            SendOtherChannel(Text, "Discord", Convert.ToUInt64(item));
                        }


                    }
                    if (SettingsGroup.Instance.TeOnStreamOfflineKonsole)
                    {
                        string Text = SettingsGroup.Instance.TeOnStreamOfflineKonsoleText;

                        Text.Replace("°Channel", e.Channel);
                        Text = OnStreamOfflineReplace(Text, e);

                        KonsolenAusgabe(Text);
                    }
                }
            }
            StreamData = e.Stream;
            SettingsGroup.Instance.TsOnline = false;
            SettingsGroup.Instance.Save();
        }
        private void Monitor_OnStreamOnline(object sender, TwitchLib.Api.Services.Events.LiveStreamMonitor.OnStreamOnlineArgs e)
        {
            if (!SettingsGroup.Instance.TsOnline)
            //Die Abfrage soll verhindern, dass das Event mehrfach hintereinander geworfen wird (damit nur eine Nachricht im Discord erscheint)
            {
                if (SettingsGroup.Instance.TeOnStreamOnline)
                {
                    if (e.Channel == sChannelID || e.Channel == sStandardChannel)
                    {
                        if (SettingsGroup.Instance.TeOnStreamOnlineChat)
                        {
                            string Text = SettingsGroup.Instance.TeOnStreamOnlineChatText;

                            Text.Replace("°Channel", e.Channel);
                            Text = OnStreamOnlineReplace(Text, e);

                            SendMessage(Text, sStandardChannel);
                        }
                        if (SettingsGroup.Instance.TeOnStreamOnlineDiscord)
                        {
                            string Text = SettingsGroup.Instance.TeOnStreamOnlineDiscordText;

                            Text.Replace("°Channel", e.Channel);
                            Text = OnStreamOnlineReplace(Text, e);

                            foreach (var item in SettingsGroup.Instance.TeOnStreamOnlineChannel)
                            {
                                SendOtherChannel(Text, "Discord", Convert.ToUInt64(item));
                            }
                            //SendOtherChannel(Text, "Discord", 653542632986902547);
                        }
                        if (SettingsGroup.Instance.TeOnStreamOnlineKonsole)
                        {
                            string Text = SettingsGroup.Instance.TeOnStreamOnlineKonsoleText;

                            Text.Replace("°Channel", e.Channel);
                            Text = OnStreamOnlineReplace(Text, e);

                            KonsolenAusgabe(Text);
                        }
                    }
                }

            }
            StreamData = e.Stream;
            //Online Status des Streams festlegen
            SettingsGroup.Instance.TsOnline = true;
            SettingsGroup.Instance.Save();
            //Raid-Message auslesen und setzen
            sRaidMessage = SettingsGroup.Instance.TeOnRaidGoChatText;
            //UserListe wird einmal gespeichert, wenn der Stream online kommt
            SaveJoinedUserList(lJoinedUsers);
        }

        private void Follower_OnNewFollowersDetected(object sender, TwitchLib.Api.Services.Events.FollowerService.OnNewFollowersDetectedArgs e)
        {
            if (e.Channel == sChannelID || e.Channel == sStandardChannel)
            {

                if (FollowerList == null)
                {

                    //Eine weitere Ausgabe erfolgt erstmal nicht
                }
                else
                {

                    if (SettingsGroup.Instance.TeOnNewFollowersDetected)
                    {
                        if (SettingsGroup.Instance.TeOnNewFollowersDetectedChat)
                        {
                            foreach (var item in e.NewFollowers)
                            {

                                string Text = SettingsGroup.Instance.TeOnNewFollowersDetectedChatText;

                                Text.Replace("°Channel", e.Channel);

                                Text = OnNewFollowerReplace(Text, item);

                                SendMessage(Text, sStandardChannel);

                            }

                        }
                        if (SettingsGroup.Instance.TeOnNewFollowersDetectedDiscord)
                        {
                            foreach (var item in e.NewFollowers)
                            {
                                string Text = SettingsGroup.Instance.TeOnNewFollowersDetectedDiscordText;
                                Text.Replace("°Channel", e.Channel);
                                Text = OnNewFollowerReplace(Text, item);

                                foreach (var channelID in SettingsGroup.Instance.TeOnNewFollowersDetectedChannel)
                                {
                                    SendOtherChannel(Text, "Discord", Convert.ToUInt64(channelID));
                                }
                            }


                        }
                        if (SettingsGroup.Instance.TeOnNewFollowersDetectedKonsole)
                        {
                            foreach (var item in e.NewFollowers)
                            {
                                string Text = SettingsGroup.Instance.TeOnNewFollowersDetectedKonsoleText;

                                Text.Replace("°Channel", e.Channel);
                                Text = OnNewFollowerReplace(Text, item);

                                KonsolenAusgabe(Text);
                            }
                        }
                    }
                    //Am Ende wird die vollständige Liste einfach nochmal abgerufen
                    FollowerlistAufbau();
                }

            }
        }
        private String OnNewFollowerReplace(string Text, TwitchLib.Api.Helix.Models.Users.GetUserFollows.Follow e)
        {
            Text = Text.Replace("°NewFollowedAt", e.FollowedAt.ToString());
            Text = Text.Replace("°NewFromUserName", e.FromUserName);
            Text = Text.Replace("°NewFromUserId", e.FromUserId);
            Text = Text.Replace("°NewToUserId", e.ToUserId);
            Text = Text.Replace("°NewToUserName", e.ToUserName);

            return Text;
        }

        private void Client_OnRaidNotification(object sender, OnRaidNotificationArgs e)
        {

            if (SettingsGroup.Instance.TeOnRaidNotification)
            {
                if (e.Channel == sStandardChannel || e.Channel == sStandardChannel)
                {
                    if (SettingsGroup.Instance.TeOnRaidNotificationChat)
                    {
                        string Text = SettingsGroup.Instance.TeOnRaidNotificationChatText;
                        Text = Text.Replace("°Channel", e.Channel);
                        Text = OnRaidReplace(Text, e.RaidNotification);
                        SendMessage(Text, sStandardChannel);

                    }
                    if (SettingsGroup.Instance.TeOnRaidNotificationDiscord)
                    {
                        string Text = SettingsGroup.Instance.TeOnRaidNotificationDiscordText;
                        Text = Text.Replace("°Channel", e.Channel);
                        Text = OnRaidReplace(Text, e.RaidNotification);
                        foreach (var item in SettingsGroup.Instance.TeOnRaidNotificationChannel)
                        {
                            SendOtherChannel(Text, "Discord", Convert.ToUInt64(item));
                        }
                    }
                    if (SettingsGroup.Instance.TeOnRaidNotificationKonsole)
                    {
                        string Text = SettingsGroup.Instance.TeOnRaidNotificationKonsoleText;
                        Text = Text.Replace("°Channel", e.Channel);
                        Text = OnRaidReplace(Text, e.RaidNotification);
                        KonsolenAusgabe(Text);
                    }
                }
            }
        }
        private String OnRaidReplace(string text, RaidNotification e)
        {

            text = text.Replace("°DisplayName", e.DisplayName);
            text = text.Replace("°MsgParamDisplayName", e.MsgParamDisplayName);
            text = text.Replace("°MsgParamLogin", e.MsgParamLogin);
            text = text.Replace("°MsgParamViewerCount", e.MsgParamViewerCount);
            //text.Replace("°SystemMsg", e.SystemMsg);
            //text.Replace("°SystemMsgParsed", e.SystemMsgParsed);

            var ChannelDaten = searchOneChannel(e.DisplayName);

            text = text.Replace("°Game", ChannelDaten.GameName);


            return text;
        }

        private void Client_OnBeingHosted(object sender, OnBeingHostedArgs e)
        {

            if (SettingsGroup.Instance.TeOnBeingHosted)
            {
                if (e.BeingHostedNotification.Channel == sStandardChannel || e.BeingHostedNotification.Channel == sStandardChannel)
                {
                    if (SettingsGroup.Instance.TeOnBeingHostedChat)
                    {
                        string Text = SettingsGroup.Instance.TeOnBeingHostedChatText;

                        Text = OnBeingHostedReplace(Text, e.BeingHostedNotification);
                        SendMessage(Text, sStandardChannel);

                    }
                    if (SettingsGroup.Instance.TeOnBeingHostedDiscord)
                    {
                        string Text = SettingsGroup.Instance.TeOnBeingHostedDiscordText;
                        Text = OnBeingHostedReplace(Text, e.BeingHostedNotification);

                        foreach (var item in SettingsGroup.Instance.TeOnBeingHostedChannel)
                        {
                            SendOtherChannel(Text, "Discord", Convert.ToUInt64(item));
                        }
                    }
                    if (SettingsGroup.Instance.TeOnBeingHostedKonsole)
                    {
                        string Text = SettingsGroup.Instance.TeOnBeingHostedKonsoleText;
                        Text = OnBeingHostedReplace(Text, e.BeingHostedNotification);

                        KonsolenAusgabe(Text);

                    }
                }
            }
        }
        private String OnBeingHostedReplace(string Text, BeingHostedNotification e)
        {

            Text = Text.Replace("°Channel", e.Channel);
            Text = Text.Replace("°HostedByChannel", e.HostedByChannel);
            //Text.Replace("°IsAutoHosted", e.IsAutoHosted.);
            int Anzahl = e.Viewers + 1;
            Text = Text.Replace("°Viewers+1", Anzahl.ToString());

            Text = Text.Replace("°Viewers", e.Viewers.ToString());
            return Text;
        }

        private void Client_OnNewSubscriber(object sender, OnNewSubscriberArgs e)
        {

            if (SettingsGroup.Instance.TeOnNewSubscriber)
            {
                if (e.Channel == sStandardChannel || e.Channel == sStandardChannel)
                {
                    if (SettingsGroup.Instance.TeOnNewSubscriberChat)
                    {
                        string Text = SettingsGroup.Instance.TeOnNewSubscriberChatText;

                        Text.Replace("°Channel", e.Channel);

                        Text = OnNewSubscriberReplace(Text, e.Subscriber);
                        SendMessage(Text, sStandardChannel);

                    }
                    if (SettingsGroup.Instance.TeOnNewSubscriberDiscord)
                    {
                        string Text = SettingsGroup.Instance.TeOnNewSubscriberDiscordText;
                        Text.Replace("°Channel", e.Channel);
                        Text = OnNewSubscriberReplace(Text, e.Subscriber);
                        foreach (var item in SettingsGroup.Instance.TeOnNewSubscriberChannel)
                        {
                            SendOtherChannel(Text, "Discord", Convert.ToUInt64(item));
                        }
                    }
                    if (SettingsGroup.Instance.TeOnNewSubscriberKonsole)
                    {
                        string Text = SettingsGroup.Instance.TeOnNewSubscriberKonsoleText;
                        Text.Replace("°Channel", e.Channel);
                        Text = OnNewSubscriberReplace(Text, e.Subscriber);
                        KonsolenAusgabe(Text);

                    }
                }
            }
        }
        private String OnNewSubscriberReplace(string Text, Subscriber e)
        {

            Text = Text.Replace("°Subscriber-Channel", e.Channel);
            Text = Text.Replace("°DisplayName", e.DisplayName);
            Text = Text.Replace("°ResubMessage", e.ResubMessage);
            Text = Text.Replace("°UserId", e.UserId);
            Text = Text.Replace("°SystemMessage", e.SystemMessage);
            Text = Text.Replace("°SystemMessageParsed", e.SystemMessageParsed);
            Text = Text.Replace("°RawIrc", e.RawIrc);
            Text = Text.Replace("°MsgParamStreakMonths", e.MsgParamStreakMonths);
            Text = Text.Replace("°MsgParamCumulativeMonths", e.MsgParamCumulativeMonths);
            Text = Text.Replace("°MsgId", e.MsgId);

            return Text;
        }

        private void Client_OnExistingUsersDetected(object sender, OnExistingUsersDetectedArgs e)
        {
            lUserInChat = e.Users;
            if (SettingsGroup.Instance.TeOnExistingUsersDetected)
            {
                if (e.Channel == sStandardChannel || e.Channel == sStandardChannel)
                {
                    if (SettingsGroup.Instance.TeOnExistingUsersDetectedChat)
                    {
                        foreach (var item in e.Users)
                        {
                            string Text = SettingsGroup.Instance.TeOnExistingUsersDetectedChatText;
                            Text = Text.Replace("°Channel", e.Channel);
                            Text = Text.Replace("°Username", item);
                            SendMessage(Text, sStandardChannel);
                        }

                    }
                    if (SettingsGroup.Instance.TeOnExistingUsersDetectedDiscord)
                    {
                        foreach (var item in e.Users)
                        {
                            string Text = SettingsGroup.Instance.TeOnExistingUsersDetectedDiscordText;
                            Text = Text.Replace("°Channel", e.Channel);
                            Text = Text.Replace("°Username", item);
                            foreach (var channelID in SettingsGroup.Instance.TeOnExistingUsersDetectedChannel)
                            {
                                SendOtherChannel(Text, "Discord", Convert.ToUInt64(channelID));
                            }
                        }
                    }
                    if (SettingsGroup.Instance.TeOnExistingUsersDetectedKonsole)
                    {
                        foreach (var item in e.Users)
                        {
                            string Text = SettingsGroup.Instance.TeOnExistingUsersDetectedKonsoleText;
                            Text = Text.Replace("°Channel", e.Channel);
                            Text = Text.Replace("°Username", item);
                            KonsolenAusgabe(Text);
                        }

                    }
                }
            }


        }
        private void Client_OnUserJoined(object sender, OnUserJoinedArgs e)
        {
            //Wird erzeugt, wenn ein Benutzer auf dem Channel erkannt wird. Wird aber nicht zeitgleich erzeugt, sondern teilweise zeit versetzt

            lUserInChat.Add(e.Username);

            if (SettingsGroup.Instance.TeOnUserJoined)
            {
                if (e.Channel == sStandardChannel || e.Channel == sStandardChannel)
                {
                    if (SettingsGroup.Instance.TeOnUserJoinedChat)
                    {
                        string Text = SettingsGroup.Instance.TeOnUserJoinedChatText;

                        Text = Text.Replace("°Channel", e.Channel);
                        Text = Text.Replace("°Username", e.Username);
                        SendMessage(Text, sStandardChannel);
                    }
                    if (SettingsGroup.Instance.TeOnUserJoinedDiscord)
                    {
                        string Text = SettingsGroup.Instance.TeOnUserJoinedDiscordText;
                        Text = Text.Replace("°Channel", e.Channel);
                        Text = Text.Replace("°Username", e.Username);

                        foreach (var item in SettingsGroup.Instance.TeOnUserJoinedChannel)
                        {
                            SendOtherChannel(Text, "Discord", Convert.ToUInt64(item));
                        }
                    }
                    if (SettingsGroup.Instance.TeOnUserJoinedKonsole)
                    {
                        string Text = SettingsGroup.Instance.TeOnUserJoinedKonsoleText;
                        Text = Text.Replace("°Channel", e.Channel);
                        Text = Text.Replace("°Username", e.Username);

                        KonsolenAusgabe(Text);

                    }
                }
            }

            //Die Prüfung nach gejointen Bot-Usern erfolgt erstmal nur, wenn der Stream offline ist
            if (!SettingsGroup.Instance.TsOnline)
            {
                CheckAutoBannBot(e.Username);
            }
        }
        private void TcClient_OnUserLeft(object sender, OnUserLeftArgs e)
        {
            lUserInChat.Remove(e.Username);
            if (SettingsGroup.Instance.TeOnUserLeft)
            {
                if (e.Channel == sStandardChannel || e.Channel == sStandardChannel)
                {
                    if (SettingsGroup.Instance.TeOnUserLeftChat)
                    {
                        string Text = SettingsGroup.Instance.TeOnUserLeftChatText;

                        Text = Text.Replace("°Channel", e.Channel);
                        Text = Text.Replace("°Username", e.Username);
                        SendMessage(Text, sStandardChannel);
                    }
                    if (SettingsGroup.Instance.TeOnUserLeftDiscord)
                    {
                        string Text = SettingsGroup.Instance.TeOnUserLeftDiscordText;
                        Text = Text.Replace("°Channel", e.Channel);
                        Text = Text.Replace("°Username", e.Username);

                        foreach (var item in SettingsGroup.Instance.TeOnUserLeftChannel)
                        {
                            SendOtherChannel(Text, "Discord", Convert.ToUInt64(item));
                        }
                    }
                    if (SettingsGroup.Instance.TeOnUserLeftKonsole)
                    {
                        string Text = SettingsGroup.Instance.TeOnUserLeftKonsoleText;
                        Text = Text.Replace("°Channel", e.Channel);
                        Text = Text.Replace("°Username", e.Username);

                        KonsolenAusgabe(Text);

                    }
                }
            }
        }
        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            if (SettingsGroup.Instance.TeOnConnected)
            {
                if (SettingsGroup.Instance.TeOnConnectedChat)
                {
                    string Text = SettingsGroup.Instance.TeOnConnectedChatText;

                    Text.Replace("°BotUsername", e.BotUsername);
                    Text.Replace("°AutoJoinChannel", e.AutoJoinChannel);

                    SendMessage(Text, sStandardChannel);

                }
                if (SettingsGroup.Instance.TeOnConnectedDiscord)
                {
                    string Text = SettingsGroup.Instance.TeOnConnectedDiscordText;
                    Text.Replace("°BotUsername", e.BotUsername);
                    Text.Replace("°AutoJoinChannel", e.AutoJoinChannel);

                    foreach (var item in SettingsGroup.Instance.TeOnConnectedChannel)
                    {
                        SendOtherChannel(Text, "Discord", Convert.ToUInt64(item));
                    }
                }
                if (SettingsGroup.Instance.TeOnConnectedKonsole)
                {
                    string Text = SettingsGroup.Instance.TeOnConnectedKonsoleText;
                    Text.Replace("°BotUsername", e.BotUsername);
                    Text.Replace("°AutoJoinChannel", e.AutoJoinChannel);

                    KonsolenAusgabe(Text);

                }
            }
        }
        private void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {

            if (SettingsGroup.Instance.TeOnJoinedChannel)
            {
                if (e.Channel == sStandardChannel || e.Channel == sStandardChannel)
                {
                    if (SettingsGroup.Instance.TeOnJoinedChannelChat)
                    {
                        string Text = SettingsGroup.Instance.TeOnJoinedChannelChatText;

                        Text = Text.Replace("°Channel", e.Channel);
                        Text = Text.Replace("°BotuserName", e.BotUsername);
                        SendMessage(Text, sStandardChannel);

                    }
                    if (SettingsGroup.Instance.TeOnJoinedChannelDiscord)
                    {
                        string Text = SettingsGroup.Instance.TeOnJoinedChannelDiscordText;
                        Text = Text.Replace("°Channel", e.Channel);
                        Text = Text.Replace("°BotuserName", e.BotUsername);

                        foreach (var item in SettingsGroup.Instance.TeOnJoinedChannelChannel)
                        {
                            SendOtherChannel(Text, "Discord", Convert.ToUInt64(item));
                        }
                    }
                    if (SettingsGroup.Instance.TeOnJoinedChannelKonsole)
                    {
                        string Text = SettingsGroup.Instance.TeOnJoinedChannelKonsoleText;
                        Text = Text.Replace("°Channel", e.Channel);
                        Text = Text.Replace("°BotuserName", e.BotUsername);

                        KonsolenAusgabe(Text);

                    }
                }
            }
        }
        private void Client_OnLog(object sender, OnLogArgs e)
        {
            KonsolenAusgabe("OnLog-Event: " + Environment.NewLine + e.BotUsername + " - " + e.Data);
        }

        private void Client_OnWhisperReceived(object sender, OnWhisperReceivedArgs e)
        {
        }
        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {

            if (SettingsGroup.Instance.TeOnMessageReceived)
            {
                if (e.ChatMessage.Channel == sStandardChannel || e.ChatMessage.Channel == sStandardChannel)
                {
                    //Erst wird geprüft, ob die Nachricht eine Suspekte Link-Endung enthält (zum Abblocken von Bots)
                    if (e.ChatMessage.Message.Contains(".ly") && SettingsGroup.Instance.SAutoBan)
                    {
                        //Aktuell blocke ich nur die .ly-Adressen. Sollte ich mehr mitbekommen, müsste ich evtl eine Liste machen
                        BlockBotUser(e.ChatMessage);
                    }
                    else
                    {
                        if (e.ChatMessage.Message.StartsWith(SettingsGroup.Instance.SBefehlSymbol))
                        {

                            String MessageText = TwitchCheckBefehl(getBefehlTeil(e.ChatMessage.Message), getOptionalerTeil(e.ChatMessage.Message), e.ChatMessage.Username);

                            if (MessageText == null)
                            {
                                if (e.ChatMessage.IsBroadcaster)
                                {
                                    
                                    MessageText = CheckListBefehl(e.ChatMessage.Message, e.ChatMessage.Username, e.ChatMessage.IsBroadcaster, "Twitch");
                                }
                                else
                                {
                                    MessageText = CheckListBefehl(e.ChatMessage.Message, e.ChatMessage.Username, e.ChatMessage.IsModerator, "Twitch");
                                }

                            }
                            if (MessageText == null)
                            {
                                CheckTwitchAdmin(e.ChatMessage);
                            }
                            if (MessageText == null)
                            {
                                MessageText = CheckBefehlAllg(e.ChatMessage.Message, e.ChatMessage.Username);
                            }

                            SendMessage(MessageText, e.ChatMessage.Channel);
                        }
                    }
                }
            }
        }

        private void CheckTwitchAdmin(ChatMessage chatMessage)
        {
            string Befehlteil = getBefehlTeil(chatMessage.Message);

            if (SettingsGroup.Instance.TeSO.Use)
            {
                if (Befehlteil == SettingsGroup.Instance.SBefehlSymbol + SettingsGroup.Instance.TeSO.Command)
                {
                    if (SettingsGroup.Instance.TeSO.Admin == true && SettingsGroup.Instance.TeSO.Admin == chatMessage.IsModerator)
                    {
                        Shoutout(getOptionalerTeil(chatMessage.Message), chatMessage.Username);
                    }
                    else if (SettingsGroup.Instance.TeSO.Boardcast == true && SettingsGroup.Instance.TeSO.Boardcast == chatMessage.IsBroadcaster)
                    {
                        Shoutout(getOptionalerTeil(chatMessage.Message), chatMessage.Username);
                    }
                    else if (SettingsGroup.Instance.TeSO.Admin == false && SettingsGroup.Instance.TeSO.Boardcast == false)
                    {
                        Shoutout(getOptionalerTeil(chatMessage.Message), chatMessage.Username);
                    }
                }
            }
            if (SettingsGroup.Instance.TeUpdateTitle.Use)
            {
                if (Befehlteil == SettingsGroup.Instance.SBefehlSymbol + SettingsGroup.Instance.TeUpdateTitle.Command.ToLower())
                {
                    if (SettingsGroup.Instance.TeUpdateTitle.Admin == true && SettingsGroup.Instance.TeUpdateTitle.Admin == chatMessage.IsModerator)
                    {
                        setStreamTitle(getOptionalerTeil(chatMessage.Message), chatMessage.Username);
                    }
                    else if (SettingsGroup.Instance.TeUpdateTitle.Boardcast == true && SettingsGroup.Instance.TeUpdateTitle.Boardcast == chatMessage.IsBroadcaster)
                    {
                        setStreamTitle(getOptionalerTeil(chatMessage.Message), chatMessage.Username);
                    }
                    else if (SettingsGroup.Instance.TeUpdateTitle.Admin == false && SettingsGroup.Instance.TeUpdateTitle.Boardcast == false)
                    {
                        setStreamTitle(getOptionalerTeil(chatMessage.Message), chatMessage.Username);
                    }
                }
            }
            if (SettingsGroup.Instance.TeGoRaid.Use)
            {
                if (Befehlteil == SettingsGroup.Instance.SBefehlSymbol + SettingsGroup.Instance.TeGoRaid.Command.ToLower())
                {
                    if (SettingsGroup.Instance.TeGoRaid.Admin == true && SettingsGroup.Instance.TeGoRaid.Admin == chatMessage.IsModerator)
                    {
                        setRaidMessage(getOptionalerTeil(chatMessage.Message), chatMessage.Username);
                    }
                    else if (SettingsGroup.Instance.TeGoRaid.Boardcast == true && SettingsGroup.Instance.TeGoRaid.Boardcast == chatMessage.IsBroadcaster)
                    {
                        setRaidMessage(getOptionalerTeil(chatMessage.Message), chatMessage.Username);
                    }
                    else if (SettingsGroup.Instance.TeGoRaid.Admin == false && SettingsGroup.Instance.TeGoRaid.Boardcast == false)
                    {
                        setRaidMessage(getOptionalerTeil(chatMessage.Message), chatMessage.Username);
                    }
                }
            }
            if (SettingsGroup.Instance.TeUpdateGame.Use)
            {
                if (Befehlteil == SettingsGroup.Instance.SBefehlSymbol + SettingsGroup.Instance.TeUpdateGame.Command.ToLower())
                {
                    if (SettingsGroup.Instance.TeUpdateGame.Admin == true && SettingsGroup.Instance.TeUpdateGame.Admin == chatMessage.IsModerator)
                    {
                        setStreamGame(getOptionalerTeil(chatMessage.Message), chatMessage.Username);
                    }
                    else if (SettingsGroup.Instance.TeUpdateGame.Boardcast == true && SettingsGroup.Instance.TeUpdateGame.Boardcast == chatMessage.IsBroadcaster)
                    {
                        setStreamGame(getOptionalerTeil(chatMessage.Message), chatMessage.Username);
                    }
                    else if (SettingsGroup.Instance.TeUpdateGame.Admin == false && SettingsGroup.Instance.TeUpdateGame.Boardcast == false)
                    {
                        setStreamGame(getOptionalerTeil(chatMessage.Message), chatMessage.Username);
                    }
                }
            }
            if (SettingsGroup.Instance.TeClipCreate.Use)
            {
                if (Befehlteil == SettingsGroup.Instance.SBefehlSymbol + SettingsGroup.Instance.TeClipCreate.Command.ToLower())
                {
                    KonsolenAusgabe("ClipCreate wird nun ausgeführt.");
                    if (SettingsGroup.Instance.TeClipCreate.Admin == true && SettingsGroup.Instance.TeClipCreate.Admin == chatMessage.IsModerator)
                    {
                        ClipCreate();
                    }
                    else if (SettingsGroup.Instance.TeClipCreate.Boardcast == true && SettingsGroup.Instance.TeClipCreate.Boardcast == chatMessage.IsBroadcaster)
                    {
                        ClipCreate();
                    }
                    else if (SettingsGroup.Instance.TeClipCreate.Admin == false && SettingsGroup.Instance.TeClipCreate.Boardcast == false)
                    {
                        ClipCreate();
                    }
                }
            }
        }

        private String TwitchCheckBefehl(string BefehlTeil, string OptionalerTeil, string User)
        {
            string Message = null;
            //Hier kommen die Twitch eigenen Variablen, wie z.B. beim Namen Message = Message.Replace("°Name", User);
            foreach (Befehl item in lTwitchBefehlListe)
            {
                if (BefehlTeil.Equals(SettingsGroup.Instance.SBefehlSymbol + item.Kommando.ToLower()))
                {
                    Message = item.Antwort;
                    string Ersatzantwort = item.ErsatzAntwort;

                    string gesuchterUser = "";
                    //String für die Ersatzantwort, da diese auch bei der Zufallsantwort angepasst werden müsste (auch wenn diese gerade nicht verwenden werden würde)


                    //Abfrage für die Variable "FollowAt", da diese anhand des Optionalen Teil anders abgefragt werden müsste
                    if (OptionalerTeil.Contains("§§$%&"))
                    {
                        Message = Message.Replace("°FollowAt", getFollowDate(User));
                        Message = Message.Replace("°FollowSince", getFollowSince(User));
                        gesuchterUser = User;
                    }
                    else
                    {
                        Message = Message.Replace("°FollowAt", getFollowDate(OptionalerTeil));
                        Message = Message.Replace("°FollowSince", getFollowSince(OptionalerTeil));
                        gesuchterUser = OptionalerTeil;
                    }

                    if (item.HatZufallAntowort)
                    {
                        Random Zufallszahl = new Random();

                        int Wert = Zufallszahl.Next(item.ZufallAntwort.Count);

                        Message = Message.Replace("°VariablerTeil", item.ZufallAntwort[Wert].Text);
                        Ersatzantwort = Ersatzantwort.Replace("°VariablerTeil", item.ZufallAntwort[Wert].Text);

                    }

                    if (item.HatErsatzText)
                    {
                        if (Message.Contains("<Not_Found>"))
                        {
                            Message = Ersatzantwort;

                            Message = Message.Replace("°OptionalerTeil", OptionalerTeil);
                        }
                        else if (OptionalerTeil.Contains("§§$%&") && Message.Contains("°OptionalerTeil"))
                        {
                            Message = Ersatzantwort;

                            Message = Message.Replace("°OptionalerTeil", OptionalerTeil);
                        }
                        else
                        {
                            Message = Message.Replace("°OptionalerTeil", OptionalerTeil);
                        }

                        //Diese Abfrage muss seperat erfolgen, da ein nicht gefundener Benutzer auch auftauchen kann, wenn kein Optionaler Teil mit angegeben worden ist.

                    }

                    Message = Message.Replace("°Followatname", gesuchterUser);
                    Message = Message.Replace("°RNDUser", RandomUser());

                    Message = Message.Replace("°Name", User);
                    Message = Message.Replace("°KommandosBefehlsKette", Befehlskette(BefehlListe));
                    Message = Message.Replace("°TwitchBefehlsKette", Befehlskette(lTwitchBefehlListe));
                    Message = Message.Replace("°TwitchAdminKette", AdminBefehlKette());

                    item.IncrementAnzahl();
                    Message = Message.Replace("°Zähler", item.Anzahl.ToString());

                    BefehlSpeichern(lTwitchBefehlListe, "Befehl-Twitch.json");
                }
            }
            return Message;
        }

        private void TwitchPupSub_OnChannelPointsRewardRedeemed(object sender, TwitchLib.PubSub.Events.OnChannelPointsRewardRedeemedArgs e)
        {
            if (SettingsGroup.Instance.TeOnRewardRedeemed)
            {
                if (e.ChannelId == sChannelID)
                {
                    if (SettingsGroup.Instance.TeOnRewardRedeemedChat)
                    {
                        string Text = SettingsGroup.Instance.TeOnRewardRedeemedChatText;

                        Text = OnRewardReplace(Text, e);
                        SendMessage(Text, sStandardChannel);

                    }
                    if (SettingsGroup.Instance.TeOnRewardRedeemedDiscord)
                    {
                        string Text = SettingsGroup.Instance.TeOnRewardRedeemedDiscordText;
                        Text = OnRewardReplace(Text, e);

                        foreach (var item in SettingsGroup.Instance.TeOnRewardRedeemedChannel)
                        {
                            SendOtherChannel(Text, "Discord", Convert.ToUInt64(item));
                        }
                    }
                    if (SettingsGroup.Instance.TeOnRewardRedeemedKonsole)
                    {
                        string Text = SettingsGroup.Instance.TeOnRewardRedeemedKonsoleText;
                        Text = OnRewardReplace(Text, e);

                        KonsolenAusgabe(Text);

                    }
                }
            }
        }
        private string OnRewardReplace(string Text, TwitchLib.PubSub.Events.OnRewardRedeemedArgs e)
        {
            Text = Text.Replace("°Name", e.DisplayName);
            Text = Text.Replace("°Message", e.Message);
            Text = Text.Replace("°Reward-Title", e.RewardTitle);
            Text = Text.Replace("°Reward-Cost", e.RewardCost.ToString());
            return Text;
        }
        private string OnRewardReplace(string Text, TwitchLib.PubSub.Events.OnChannelPointsRewardRedeemedArgs e)
        {
            Text = Text.Replace("°Name", e.RewardRedeemed.Redemption.User.DisplayName);
            Text = Text.Replace("°Message", e.RewardRedeemed.Redemption.UserInput);
            Text = Text.Replace("°Reward-Title", e.RewardRedeemed.Redemption.Reward.Title);
            Text = Text.Replace("°Reward-Cost", e.RewardRedeemed.Redemption.Reward.Cost.ToString());
            return Text;
        }

        private void TwitchPupSub_OnRaidGo(object sender, TwitchLib.PubSub.Events.OnRaidGoArgs e)
        {

            if (SettingsGroup.Instance.TeOnRaidGo)
            {
                if (e.ChannelId == sChannelID)
                {
                    if (SettingsGroup.Instance.TeOnRaidGoChat)
                    {
                        //Hier wird die vorher gesetzte Raid-Message verwendet, anstatt dies aus den Properties direkt zu lesen

                        sRaidMessage = onRaidReplace(sRaidMessage, e);
                        SendMessage(sRaidMessage, sStandardChannel);

                        //Die Nachricht wird zeitgleich beim Streamer geschrieben, der geraidet wird
                        SleepMessage(sRaidMessage, 5, e.TargetDisplayName);
                    }
                    if (SettingsGroup.Instance.TeOnRaidGoDiscord)
                    {
                        string Text = SettingsGroup.Instance.TeOnRaidGoDiscordText;
                        Text = onRaidReplace(Text, e);

                        foreach (var item in SettingsGroup.Instance.TeOnRaidGoChannel)
                        {
                            SendOtherChannel(Text, "Discord", Convert.ToUInt64(item));
                        }
                    }
                    if (SettingsGroup.Instance.TeOnRaidGoKonsole)
                    {
                        string Text = SettingsGroup.Instance.TeOnRaidGoKonsoleText;
                        Text = onRaidReplace(Text, e);

                        KonsolenAusgabe(Text);

                    }
                }
            }
        }
        private string onRaidReplace(string Text, TwitchLib.PubSub.Events.OnRaidGoArgs e)
        {
            Text = Text.Replace("°TargetName", e.TargetDisplayName);
            Text = Text.Replace("°ViewerCount", e.ViewerCount.ToString());
            return Text;
        }

        private void OnClipCreated(TwitchLib.Api.Helix.Models.Clips.GetClips.Clip NeuerClip)
        {

            if (SettingsGroup.Instance.TeOnClipCreated)
            {
                if (NeuerClip.BroadcasterId == sChannelID)
                {
                    if (SettingsGroup.Instance.TeOnClipCreatedChat)
                    {
                        string Text = SettingsGroup.Instance.TeOnClipCreatedChatText;

                        Text = OnClipCreatedReplace(Text, NeuerClip);
                        SendMessage(Text, sStandardChannel);

                    }
                    if (SettingsGroup.Instance.TeOnClipCreatedDiscord)
                    {
                        string Text = SettingsGroup.Instance.TeOnClipCreatedDiscordText;
                        Text = OnClipCreatedReplace(Text, NeuerClip);

                        foreach (var item in SettingsGroup.Instance.TeOnClipCreatedChannel)
                        {
                            SendOtherChannel(Text, "Discord", Convert.ToUInt64(item));
                        }
                    }
                    if (SettingsGroup.Instance.TeOnClipCreatedKonsole)
                    {
                        string Text = SettingsGroup.Instance.TeOnClipCreatedKonsoleText;
                        Text = OnClipCreatedReplace(Text, NeuerClip);

                        KonsolenAusgabe(Text);

                    }
                }
            }
            /*
            NeuerClip.BroadcasterId;
            NeuerClip.CreatedAt;
            NeuerClip.CreatorId;
            NeuerClip.GameId;
            NeuerClip.Title;
            NeuerClip.Url;
            */

        }
        private string OnClipCreatedReplace(string text, TwitchLib.Api.Helix.Models.Clips.GetClips.Clip Clip)
        {
            //text = text.Replace("°BroadcasterId", UserNameByID(Clip.BroadcasterId));
            //string Datum = string.Format("{0}.{1}.{2}",Regex.Matches(Clip.CreatedAt,"");
            
            text = text.Replace("°CreatedAtTag", "");
            text = text.Replace("°CreatedAtUhr", "");
            text = text.Replace("°CreatorName", Clip.CreatorName);
            text = text.Replace("°GameId", GameByID(Clip.GameId));
            text = text.Replace("°Title", Clip.Title);
            text = text.Replace("°Url", Clip.Url);
            return text;
        }


        #endregion

        #region ErrorEvents

        private void TcClient_OnConnectionError(object sender, OnConnectionErrorArgs e)
        {
            KonsolenAusgabe("OnConnectionError wurde geworfen: " + Environment.NewLine + e.BotUsername + " - " + e.Error.Message + Environment.NewLine + "Aus Twitch wird sich wieder abgemeldet.");
            StopBot();
        }
        private void TcClient_OnIncorrectLogin(object sender, OnIncorrectLoginArgs e)
        {
            KonsolenAusgabe("IncorrectLogin wurde geworfen: " + e.Exception.Message);
            KonsolenAusgabe("Die Twitchverbindung wird nun wieder getrennt.");
            StopBot();
        }
        private void TwitchPupSub_OnListenResponse(object sender, TwitchLib.PubSub.Events.OnListenResponseArgs e)
        {
            KonsolenAusgabe("OnListenResponse wurde geworfen" + Environment.NewLine + e.Topic + " - " + e.Successful + " - " + e.Response.Error.ToString());

        }
        private void TwitchPupSub_OnPubSubServiceClosed(object sender, EventArgs e)
        {
            KonsolenAusgabe("TwitchPupSub wurde getrennt");
        }
        private void TwitchPupSub_OnPubSubServiceConnected(object sender, EventArgs e)
        {
            KonsolenAusgabe("TwitchPupSub ist verbunden");
            //twitchPupSub.SendTopics("bq6ho9iryyrkpw650pgv2uktr6amrg");

            if (SettingsGroup.Instance.TsPubSubZusatz)
            {
                twitchPupSub.SendTopics(SettingsGroup.Instance.TsAccessTokenPubSub);
                KonsolenAusgabe("TwitchPupSub wird mit Token " + SettingsGroup.Instance.TsAccessTokenPubSub + " verwendet.");
            }
            else
            {
                twitchPupSub.SendTopics(SettingsGroup.Instance.TsAccessToken); //Give OAuth Key and connect
                KonsolenAusgabe("TwitchPupSub wird mit Token " + SettingsGroup.Instance.TsAccessToken + " verwendet.");
            }


        }
        private void TwitchPupSub_OnPubSubServiceError(object sender, TwitchLib.PubSub.Events.OnPubSubServiceErrorArgs e)
        {
            KonsolenAusgabe("TwítchPupSub ist auf Fehler gelaufen: " + e.Exception.Message + Environment.NewLine + "Aus Twitch wird sich wieder abgemeldet.");
            StopBot();
        }
        private void TcClient_OnNoPermissionError(object sender, EventArgs e)
        {
            KonsolenAusgabe("NoPermissionError wurde erzeugt:" + Environment.NewLine + e.ToString() + Environment.NewLine + "Aus Twitch wird sich wieder abgemeldet.");
            StopBot();
        }
        private void TcClient_OnError(object sender, TwitchLib.Communication.Events.OnErrorEventArgs e)
        {
            KonsolenAusgabe("Exception wurde erzeugt:" + Environment.NewLine + e.Exception.Message + Environment.NewLine + "Aus Twitch wird sich wieder abgemeldet.");
            StopBot();
        }

        #endregion

        #region TokenHandling
        private bool CheckTokenValidation(string Token)
        {
            var Tokentest = System.Threading.Tasks.Task.Run(() => TwitchAPI.Auth.ValidateAccessTokenAsync(Token));
            if (Tokentest.Result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public TwitchLib.Api.Auth.ValidateAccessTokenResponse TokenInhalt(string Token)
        {
            var Tokentest = System.Threading.Tasks.Task.Run(() => TwitchAPI.Auth.ValidateAccessTokenAsync(Token));
            //Der Wert ExpiresIn gibt die Gültigkeit in Sekunden wieder
            return Tokentest.Result;
        }

        public static List<String> TestTokensStatic(String Token)
        {
            TwitchAPI twitchAPIStatic = new TwitchAPI();
            var Tokentest = System.Threading.Tasks.Task.Run(() => twitchAPIStatic.Auth.ValidateAccessTokenAsync(Token));
            List<String> Ergebnis = new List<string>();

            if (Tokentest.Result != null)
            {
                Ergebnis.Add(Tokentest.Result.ExpiresIn.ToString());
                Ergebnis.AddRange(Tokentest.Result.Scopes);
            }

            return Ergebnis;

        }

        public void TestAllCurrentTokens()
        {
            //Prüfung aller Tokens auf Gültigkeit
            //Wenn die Tokens bald ablaufen, werden Warnungen geworfen und sich evtl. auch vorher abgemeldet (Automatisch neue Token abspeichern ist aktuell nicht möglich)
            //Alle 10 Stunden soll erstmal geprüpft werden (mit dem Timer, der die Textbox leer)
            //Auch die Berechtigungen sollen abgeglichen werden

            var standardtoken = TokenInhalt(SettingsGroup.Instance.TsAccessToken);

            if (standardtoken == null)
            {
                KonsolenAusgabe("Der Twitch-Token ist nicht gültig. Fordere diesen neu an.");
            }
            else
            {
                //Token ist gültig
                //Token wird auf Zeit geprüft
                switch (standardtoken.ExpiresIn)
                {
                    case int n when (n <= 1800000 && n > 90001):
                        KonsolenAusgabe("Der Twitch-Token läuft in 50 Stunden ab. Fordere ihn am Besten neu an.");
                        break;
                    case int n when (n <= 90000 && n > 36001):
                        KonsolenAusgabe("Der Twitch-Token läuft in 25 Stunden ab. Fordere ihn am Besten neu an, ansonsten wird sich von Twitch abgemeldet.");
                        break;
                    case int n when (n <= 36000):
                        KonsolenAusgabe("Der Twitch-Token läuft in weniger als 10 Stunden ab. Es wird sich von Twitch abgemeldet. Fordere den Token neu an.");
                        StopBot();
                        break;
                }

                //Prüfung der Scopes, die nur für den Twitch-Token benöigt werden
                if (!(SettingsGroup.Instance.Tschat_read && standardtoken.Scopes.Contains("chat:read")))
                {
                    KonsolenAusgabe("Berechtigungen für chat:read sind zwar gesetzt, aber im Token nicht vorhanden. Fordere den Token neu an.");
                }
                if (!(SettingsGroup.Instance.Tschat_edit && standardtoken.Scopes.Contains("chat:edit")))
                {
                    KonsolenAusgabe("Berechtigungen für chat:edit sind zwar gesetzt, aber im Token nicht vorhanden. Fordere den Token neu an.");
                }
                if (!(SettingsGroup.Instance.Tswhispers_read && standardtoken.Scopes.Contains("whispers:read")))
                {
                    KonsolenAusgabe("Berechtigungen für whispers:read sind zwar gesetzt, aber im Token nicht vorhanden. Fordere den Token neu an.");
                }
                if (!(SettingsGroup.Instance.Tswhispers_edit && standardtoken.Scopes.Contains("whispers:edit")))
                {
                    KonsolenAusgabe("Berechtigungen für whispers:edit sind zwar gesetzt, aber im Token nicht vorhanden. Fordere den Token neu an.");
                }
                if (!(SettingsGroup.Instance.Tschannel_moderate && standardtoken.Scopes.Contains("channel:moderate")))
                {
                    KonsolenAusgabe("Berechtigungen für channel:moderate sind zwar gesetzt, aber im Token nicht vorhanden. Fordere den Token neu an.");
                }

                if (!(SettingsGroup.Instance.Tsuser_edit_broadcast && standardtoken.Scopes.Contains("user:edit:broadcast")))
                {
                    KonsolenAusgabe("Berechtigungen für user:edit:broadcast sind zwar gesetzt, aber im Token nicht vorhanden. Fordere den Token neu an.");
                }
                if (!(SettingsGroup.Instance.Tschannel_editor && standardtoken.Scopes.Contains("channel_editor")))
                {
                    KonsolenAusgabe("Berechtigungen für channel_editor sind zwar gesetzt, aber im Token nicht vorhanden. Fordere den Token neu an.");
                }
                if (!(SettingsGroup.Instance.Tsclips_edit && standardtoken.Scopes.Contains("clips:edit")))
                {
                    KonsolenAusgabe("Berechtigungen für clips:edit sind zwar gesetzt, aber im Token nicht vorhanden. Fordere den Token neu an.");
                }
            }

            //Prüfung für den PubSubToken, wenn dieser verwendet wird
            if (SettingsGroup.Instance.TsPubSubZusatz)
            {
                var PubSubToken = TokenInhalt(SettingsGroup.Instance.TsAccessTokenPubSub);

                if (PubSubToken == null)
                {
                    KonsolenAusgabe("Der Twitch-PubSub-Token ist nicht gültig. Fordere diesen neu an.");
                }
                else
                {
                    //Token ist gültig
                    //Token wird auf Zeit geprüft
                    switch (PubSubToken.ExpiresIn)
                    {
                        case int n when (n <= 1800000 && n > 90001):
                            KonsolenAusgabe("Der Twitch-PubSub-Token läuft in 50 Stunden ab. Fordere ihn am Besten neu an.");
                            break;
                        case int n when (n <= 90000 && n > 36001):
                            KonsolenAusgabe("Der Twitch-PubSub-Token läuft in 25 Stunden ab. Fordere ihn am Besten neu an, ansonsten wird sich von Twitch abgemeldet.");
                            break;
                        case int n when (n <= 36000):
                            KonsolenAusgabe("Der Twitch-PubSub-Token läuft in weniger als 10 Stunden ab. Es wird sich von Twitch abgemeldet. Fordere den Token neu an.");
                            StopBot();
                            break;
                    }

                    //Hier die Prüfungen, die nur für den PubSub-Token gelten (dieser kann zwar mehr haben, sind aber nicht wichtig für die eigentliche Verwendung)

                    if (!(SettingsGroup.Instance.Tschannel_read_redemptions && PubSubToken.Scopes.Contains("channel:read:redemptions")))
                    {
                        KonsolenAusgabe("Berechtigungen für channel:read:redemptions sind zwar gesetzt, aber im Token nicht vorhanden. Fordere den Token neu an.");
                    }
                    if (!(SettingsGroup.Instance.Tschannel_manage_redemptions && PubSubToken.Scopes.Contains("channel:manage:redemptions")))
                    {
                        KonsolenAusgabe("Berechtigungen für channel:manage:redemptions sind zwar gesetzt, aber im Token nicht vorhanden. Fordere den Token neu an.");
                    }
                    if (!(SettingsGroup.Instance.Tsbits_read && PubSubToken.Scopes.Contains("bits:read")))
                    {
                        KonsolenAusgabe("Berechtigungen für bits:read sind zwar gesetzt, aber im Token nicht vorhanden. Fordere den Token neu an.");
                    }
                    if (!(SettingsGroup.Instance.Tsuser_edit && PubSubToken.Scopes.Contains("user:edit")))
                    {
                        KonsolenAusgabe("Berechtigungen für user:edit sind zwar gesetzt, aber im Token nicht vorhanden. Fordere den Token neu an.");
                    }
                }
            }
            else
            {
                //Wenn der PubSub Token nicht verwendet wird, werden hier noch die Berechtigungen des Twitch-Tokens geprüft
                if (!(SettingsGroup.Instance.Tschannel_read_redemptions && standardtoken.Scopes.Contains("channel:read:redemptions")))
                {
                    KonsolenAusgabe("Berechtigungen für channel:read:redemptions sind zwar gesetzt, aber im Token nicht vorhanden. Fordere den Token neu an.");
                }
                if (!(SettingsGroup.Instance.Tschannel_manage_redemptions && standardtoken.Scopes.Contains("channel:manage:redemptions")))
                {
                    KonsolenAusgabe("Berechtigungen für channel:manage:redemptions sind zwar gesetzt, aber im Token nicht vorhanden. Fordere den Token neu an.");
                }
                if (!(SettingsGroup.Instance.Tsbits_read && standardtoken.Scopes.Contains("bits:read")))
                {
                    KonsolenAusgabe("Berechtigungen für bits:read sind zwar gesetzt, aber im Token nicht vorhanden. Fordere den Token neu an.");
                }
                if (!(SettingsGroup.Instance.Tsuser_edit && standardtoken.Scopes.Contains("user:edit")))
                {
                    KonsolenAusgabe("Berechtigungen für user:edit sind zwar gesetzt, aber im Token nicht vorhanden. Fordere den Token neu an.");
                }
            }
        }

        #endregion

        private void SleepMessage(string Text, int Delay, string Target)
        {
            //Die Funktion wird verwendet, um EINE Nachricht verzögert zu senden.
            //Wird die Funktion noochmal aufgerufen, während gewartet wird, wird keine zweite Nachricht gesendet
            //Der Delay wird in Sekunden angegeben

            if (bSleepMessage == false)
            {
                bSleepMessage = true;
                sSleepMessage = Text;
                sSleepTarget = Target;
                iSleepDelay = Delay;
            }
        }
        public bool getSleepBool()
        {
            return bSleepMessage;
        }
        public void decrementDelay()
        {
            iSleepDelay = iSleepDelay - 1;
            if (iSleepDelay == 0)
            {
                sendSleepMessage();
            }
        }
        public void sendSleepMessage()
        {
            if (bSleepMessage == true)
            {
                bSleepMessage = false;
                if (sSleepTarget == sStandardChannel)
                {
                    SendMessage(sSleepMessage, sStandardChannel);
                }
                else
                {
                    tcClient.JoinChannel(sSleepTarget);
                    SendMessage(sSleepMessage, sSleepTarget);
                    tcClient.LeaveChannel(sSleepTarget);
                }
                sSleepMessage = "";
                iSleepDelay = 0;
                sSleepTarget = "";
            }
        }

        public void StopBot()
        {
            if (Active == true)
            {
                Active = false;
                tcClient.Disconnect();
                lsmMonitor.Stop();
                fsFollower.Stop();
                twitchPupSub.Disconnect();
                //FollowerList = null;
                KonsolenAusgabe("Aus Twitch wurde sich abgemeldet.");
            }
            else
            {
                KonsolenAusgabe("Ein Ausloggen aus Twitch ist nicht möglich. Der Bot war nicht aktiv gewesen.");
            }
        }
        public bool GetClientStatus()
        {
            try
            {
                return Active;
            }
            catch (Exception e)
            {
                KonsolenAusgabe("GetClientStatus konnte nicht durchgeführt werden." + Environment.NewLine + "Excpetion-Message: " + Environment.NewLine + e.Message + Environment.NewLine + "InnerException: " + Environment.NewLine + e.InnerException);
                return false;
                throw;
            }

        }
        public string getUserName()
        {
            return tcClient.TwitchUsername;
        }
        public void SendMessage(String Message, String Channel)
        {

            if (Message != null)
            {
                try
                {
                    //Prüfung, ob die Nachricht länger als 500 Zeichen ist, ansonsten wird (erstmal) abgeschnitten
                    if (tcClient.JoinedChannels.Count == 0)
                    {
                        KonsolenAusgabe("In keinem Channel gejoint. Channel werden wieder verbunden...");
                        JoinChannel();
                    }
                    if (Message.Length < 500)
                    {
                        tcClient.SendMessage(Channel, Message);
                    }
                    else
                    {
                        tcClient.SendMessage(Channel, Message.Substring(0, 499));
                    }

                }
                catch (Exception e)
                {
                    KonsolenAusgabe("SendMessage konnte nicht durchgeführt werden." + Environment.NewLine + "Nachricht: " + Message + Environment.NewLine + "Channel: " + Channel + Environment.NewLine + "Excpetion-Message: " + Environment.NewLine + e.Message + Environment.NewLine + "InnerException: " + Environment.NewLine + e.InnerException);
                }
            }

        }

        private String getFollowDate(string Name)
        {
            string FollowDate = "";
            
            foreach (var item in FollowerList)
            {
                
                if (item.FromUserName.ToLower().Equals(Name.ToLower())) {
                    FollowDate = item.FollowedAt.ToString();
                }
            }
            
            if (FollowDate.Equals(""))
            {
                FollowDate = "<Not_Found>";
            }

            return FollowDate;

        }
        private String getFollowSince(string Name)
        {
            string FollowSince = "";
            
            foreach (var item in FollowerList)
            {
                if (item.FromUserName.ToLower().Equals(Name.ToLower()))
                {
                    var timeSpan = DateTime.Now - item.FollowedAt;

                    FollowSince = timeSpan.Days.ToString() + " Tage, " + timeSpan.Hours.ToString() + " Stunden, " + timeSpan.Minutes.ToString() + " Minunten und " + timeSpan.Seconds.ToString() + " Sekunden";
                }
            }
            
            if (FollowSince.Equals(""))
            {
                FollowSince = "<Not_Found>";
            }

            return FollowSince;
        }
        public void LoadTwitchBefehle(string Path)
        {
            lTwitchBefehlListe = LoadList(Path);
            //ZufallGewichtung(lTwitchBefehlListe);
        }

        private void Shoutout(String Channel, String User)
        {
            //Es wird der gesamte Optionale Teil übergeben. Da Twitch keine Namen mit Leerzeichen erlaubt, wird der Text abgeschnitten, bis zum ersten Leerzeichen, wenn Leerzeichen vorhanden sind

            if (Channel.Contains(" "))
            {
                Channel = Channel.Substring(0, Channel.IndexOf(" "));
            }

            var ChannelDaten = searchOneChannel(Channel);
            if (ChannelDaten == null)
            {
                //Nicht gefunden
                String Text = SettingsGroup.Instance.TeSO.FailText;
                Text = Text.Replace("°User", User);
                Text = Text.Replace("°TargetName", Channel);

                SendMessage(Text, sStandardChannel);
            }
            else
            {
                //Gefunden
                String Text = SettingsGroup.Instance.TeSO.ChatText;
                
                Text = Text.Replace("°TargetName", ChannelDaten.DisplayName);
                // Text = Text.Replace("°TargetFollowers", ChannelDaten.Followers.ToString());
                Text = Text.Replace("°TargetGame", ChannelDaten.GameName);
                Text = Text.Replace("°TargetUrl", "www.twitch.tv/" + ChannelDaten.BroadcasterLogin);
                Text = Text.Replace("°User", User);

                SendMessage(Text, sStandardChannel);
            }

        }

        private TwitchLib.Api.Helix.Models.Search.Channel searchOneChannel(string Channel)
        {
            try
            {
                var ChannelDaten = TwitchAPI.Helix.Search.SearchChannelsAsync(Channel);

                foreach (var item in ChannelDaten.Result.Channels)
                {
                    if (item.DisplayName == Channel || item.BroadcasterLogin == Channel)
                    {
                        return item;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                if (e.InnerException.InnerException.Message.Equals("Der Remotename konnte nicht aufgelöst werden: 'api.twitch.tv'"))
                {
                    KonsolenAusgabe("SearchOneChannel ist fehlgeschlagen, da keine Verbindung ins Internet besteht" + Environment.NewLine + e.Message + Environment.NewLine + e.InnerException);
                    Restart = true;
                }
                else if (e.Message.Contains("No such host ist known"))
                {
                    KonsolenAusgabe("SearchOneChannel ist fehlgeschlagen, da keine Verbindung ins Internet besteht" + Environment.NewLine + e.Message + Environment.NewLine + e.InnerException);
                    Restart = true;
                }
                else
                {
                    KonsolenAusgabe("SearchOneChannel ist auf Fehler gelaufen: " + e.InnerException);
                }

                return null;
            }
        }


        private async void setStreamTitle(String Title, String User)
        {
            //braucht die Berechtigung User:Edit:Broadcast und channel_editor
            //TwitchAPI.Settings.SkipDynamicScopeValidation = true;

            if (SettingsGroup.Instance.Tschannel_editor && SettingsGroup.Instance.Tsuser_edit_broadcast)
            {
                if (StreamData != null)
                {

                    string Message="";
                    string AltTitle = StreamData.Title;
                    try
                    {
                        Message = SettingsGroup.Instance.TeUpdateTitle.ChatText;
                        //StreamData.GameName
                        TwitchLib.Api.Helix.Models.Channels.ModifyChannelInformation.ModifyChannelInformationRequest request = new TwitchLib.Api.Helix.Models.Channels.ModifyChannelInformation.ModifyChannelInformationRequest();

                        request.Title = Title;
                        if (SettingsGroup.Instance.TsPubSubZusatz)
                        {
                            await TwitchAPI.Helix.Channels.ModifyChannelInformationAsync(sChannelID, request, SettingsGroup.Instance.TsAccessTokenPubSub);
                        }
                        else
                        {
                            await TwitchAPI.Helix.Channels.ModifyChannelInformationAsync(sChannelID, request, SettingsGroup.Instance.TsAccessToken);
                        }
                        Message = Message.Replace("°AltTitel", AltTitle);
                        Message = Message.Replace("°NeuTitel", Title);
                        Message = Message.Replace("°User", User);
                    }
                    catch (Exception e) {
                        Message = SettingsGroup.Instance.TeUpdateTitle.FailText;
                        Message = Message.Replace("°AltTitel", AltTitle);
                        Message = Message.Replace("°NeuTitel", Title);
                        Message = Message.Replace("°User", User);
                        Message = Message.Replace("°Exception", e.Message);
                    }
                    
                    SendMessage(Message, sStandardChannel);

                }
                else
                {
                    string Message = SettingsGroup.Instance.TeUpdateTitle.FailText;

                    Message = Message.Replace("°Exception", "No StreamData");
                    Message = Message.Replace("°NeuTitel", Title);
                    Message = Message.Replace("°User", User);

                    SendMessage(Message, sStandardChannel);
                }
            }
            else
            {
                KonsolenAusgabe("Für UpdateTitle sind die Berechtungen User:Edit:Broadcast und channel_editor notwendig");
            }
        }
        private async void setStreamGame(String Game, String User)
        {
            //braucht die Berechtigung User:Edit:Broadcast und channel:manage:broadcast und channel_editor
            //TwitchAPI.Settings.SkipDynamicScopeValidation = true;
            if (SettingsGroup.Instance.Tschannel_editor && SettingsGroup.Instance.Tsuser_edit_broadcast)
            {
                if (StreamData != null)
                {

                    string Message = "";
                    string AltGame = StreamData.GameName;

                    try
                    {
                        Message = SettingsGroup.Instance.TeUpdateGame.ChatText;
                        var GameData = TwitchAPI.Helix.Games.GetGamesAsync(gameNames: new List<string> { Game });


                        TwitchLib.Api.Helix.Models.Channels.ModifyChannelInformation.ModifyChannelInformationRequest request = new TwitchLib.Api.Helix.Models.Channels.ModifyChannelInformation.ModifyChannelInformationRequest();

                        var gamedata = TwitchAPI.Helix.Games.GetGamesAsync(gameNames: new List<String> { Game });

                        request.GameId = gamedata.Result.Games[0].Id;

                        if (SettingsGroup.Instance.TsPubSubZusatz)
                        {
                            await TwitchAPI.Helix.Channels.ModifyChannelInformationAsync(sChannelID, request, SettingsGroup.Instance.TsAccessTokenPubSub);
                        }
                        else
                        {
                            await TwitchAPI.Helix.Channels.ModifyChannelInformationAsync(sChannelID, request, SettingsGroup.Instance.TsAccessToken);
                        }


                        Message = Message.Replace("°AltGame", AltGame);
                        Message = Message.Replace("°NeuGame", Game);
                        Message = Message.Replace("°User", User);
                    }
                    catch (Exception e)
                    {
                        Message = SettingsGroup.Instance.TeUpdateTitle.FailText;
                        Message = Message.Replace("°AltGame", AltGame);
                        Message = Message.Replace("°NeuGame", Game);
                        Message = Message.Replace("°User", User);
                        Message = Message.Replace("°Exception", e.Message);
                    }

                    SendMessage(Message, sStandardChannel);

                }
                else
                {
                    string Message = SettingsGroup.Instance.TeUpdateGame.FailText;

                    Message = Message.Replace("°NeuGame", Game);
                    Message = Message.Replace("°User", User);

                    SendMessage(Message, sStandardChannel);
                }
            }
            else
            {
                KonsolenAusgabe("Für UpdateTitle sind die Berechtungen User:Edit:Broadcast und channel_editor notwendig");
            }

        }
        private void setRaidMessage(String Message, String User)
        {

            //Wenn keine Raid-Message gesetzt ist, soll nur die aktuelle Raid-Message angezeigt werden
            //§§$%& steht drinnen, wenn sonst kein Text dabei ist
            if (Message.Contains("§§$%&"))
            {
                SendMessage(sRaidMessage, sStandardChannel);
            }
            else
            {
                sRaidMessage = Message;

                String Antwort = SettingsGroup.Instance.TeGoRaid.ChatText;
                Antwort = Antwort.Replace("°NeuText", Message);
                Antwort = Antwort.Replace("°User", User);

                SendMessage(Antwort, sStandardChannel);
            }
        }

        public void JoinChannel()
        {
            tcClient.JoinChannel(sStandardChannel);
            string text = "Joined Channels: ";
            foreach (var item in tcClient.JoinedChannels)
            {
                text += Environment.NewLine + item.Channel;
            }
            KonsolenAusgabe(text);
        }
        public void LevaeChannel()
        {
            tcClient.LeaveChannel(sStandardChannel);
        }

        public void LoadAllCommands()
        {
            //Funktion zum Laden der Befehle in die Liste
            AllCommands.Clear();
            CommandListFill(BefehlListe);
            CommandListFill(lTwitchBefehlListe);
        }

        private void LoadUserJoinedList()
        {
            lJoinedUsers = LoadJoinedUserList();
        }

        public string getStringBotUser()
        {
            string Text = "";

            foreach (var i in lJoinedUsers)
            {
                Text += i.getID() + " - " + i.getName() + " - " + i.getAnzahl().ToString() + " - " + i.getLastJoined().ToString() + Environment.NewLine;
            }

            return Text;
        }

        private bool CheckWhiteList(String Name) {
            bool Treffer = false;
            foreach (var item in SettingsGroup.Instance.STwitchAutoBotWhiteList) { 
                if (item.ToLower().Equals(Name.ToLower()))
                {
                    Treffer = true;
                }
            }

            return Treffer;
        }

        private void CheckAutoBannBot(string Name)
        {
            
            if (SettingsGroup.Instance.STwitchAutoBotBann)
            {
                bool gefunden = false;
                //Daten des Benutzers suchen
                var User = searchOneChannel(Name);
                if (User != null)
                {
                    //Erst wird geschaut, ob der User in der Whitelist...
                    if (!CheckWhiteList(Name))
                    {
                        bool isFollower = false;
                        //... oder in der Followerlist steht...
                        foreach (var Follower in FollowerList)
                        {
                            if (Follower.FromUserId == User.Id)
                            {
                                isFollower = true;
                            }
                        }
                        //... steht er in keiner Liste...
                        if (!isFollower)
                        {
                            //... wird der Benutzer in der Liste gesucht...
                            foreach (var i in lJoinedUsers)
                            {

                                //... Wird geprüft, ob er bereits in der Liste steht
                                if (i.getID() == User.Id && !gefunden)
                                {
                                    //... dann wird hochgezählt
                                    i.NewJoined();
                                    gefunden = true;
                                    KonsolenAusgabe("AutoBotUser:" + Environment.NewLine + "Benutzer " + User.DisplayName + " wiedererkannt und hochgezählt");
                                    //Sollte der Name jetzt schon X Einträge haben, dann wird er gebannt
                                    if (i.getAnzahl() >= SettingsGroup.Instance.STwitchAutoBotAmount)
                                    {
                                        tcClient.BanUser(sStandardChannel, i.getName());
                                        KonsolenAusgabe("AutoBotUser:" + Environment.NewLine + i.getName() + " wurde auf Verdacht von Bot-Aktivität gebannt.");
                                        SendOtherChannel("AutoBotUser:" + Environment.NewLine + i.getName() + " wurde auf Verdacht von Bot-Aktivität gebannt.", "Discord", SettingsGroup.Instance.SDiscordOtherChannelChannel);
                                    }
                                }

                            }
                            //Wurde er nicht gefunden, so wird ein neuer Eintrag gesetzt
                            if (!gefunden)
                            {
                                lJoinedUsers.Add(new JoinedUsers(User.Id, User.DisplayName));
                                KonsolenAusgabe("AutoBotUser:" + Environment.NewLine + "Neuer Benutzer in Liste aufgenommen: " + User.DisplayName);
                            }
                        }

                    }

                }
            }

            
        }

        public void BotUserSave()
        {
            SaveJoinedUserList(lJoinedUsers);
        }
        private void BlockBotUser(ChatMessage e)
        {
            if (SettingsGroup.Instance.Tschannel_moderate)
            {

                tcClient.DeleteMessage(e.Channel, e);
                tcClient.BanUser(e.Channel, e.Username, "Bitte keine Bot Nachrichten.");
                KonsolenAusgabe("AutoBotUser:" + Environment.NewLine + e.Username + " wurde aufgrund der Nachricht: " + e.Message + " gebannt.");
            }
            else
            {
                KonsolenAusgabe("AutoBotUser:" + Environment.NewLine + "Bot Nachricht mit Inahlt .ly wurde erkannt, aber die Berechtigung ist nicht da.");
            }
        }

        private string RandomUser()
        {
            if (lUserInChat.Count > 0)
            {
                return lUserInChat[Zufallszahl.Next(0, lUserInChat.Count)];
            }
            else
            {
                return "NULL";
            }
        }

        private string AdminBefehlKette()
        {
            string Ergebnis = "";

            if (SettingsGroup.Instance.TeUpdateTitle.Use)
            {
                Ergebnis += SettingsGroup.Instance.SBefehlSymbol + SettingsGroup.Instance.TeUpdateTitle.Command;
            }
            if (SettingsGroup.Instance.TeUpdateGame.Use)
            {
                Ergebnis += ", " + SettingsGroup.Instance.SBefehlSymbol + SettingsGroup.Instance.TeUpdateGame.Command;
            }
            if (SettingsGroup.Instance.TeGoRaid.Use)
            {
                Ergebnis += ", " + SettingsGroup.Instance.SBefehlSymbol + SettingsGroup.Instance.TeGoRaid.Command;
            }
            if (SettingsGroup.Instance.TeSO.Use)
            {
                Ergebnis += ", " + SettingsGroup.Instance.SBefehlSymbol + SettingsGroup.Instance.TeSO.Command;
            }

            return Ergebnis;
        }

        private void getCurrentClips()
        {
            try
            {
                var Aktuell = TwitchAPI.Helix.Clips.GetClipsAsync(broadcasterId: sChannelID, startedAt: DateTime.Now.AddMonths(-1), endedAt: DateTime.Now);
                Lastclips = Aktuell.Result.Clips;
            }
            catch (Exception e)
            {
                KonsolenAusgabe("GetCurrentClips ist auf Fehler gelaufen: " + e.InnerException);
            }
        }

        public void getNewClips()
        {
            var Neu = TwitchAPI.Helix.Clips.GetClipsAsync(broadcasterId: sChannelID, startedAt: DateTime.Now.AddMonths(-1), endedAt: DateTime.Now);

            TwitchLib.Api.Helix.Models.Clips.GetClips.Clip[] Currentclips = null;
            try
            {
                Currentclips = Neu.Result.Clips;
            }
            catch (Exception e)
            {
                KonsolenAusgabe("Get-Clips ist auf ein Fehler gelaufen:" + Environment.NewLine + e.InnerException);
            }


            List<TwitchLib.Api.Helix.Models.Clips.GetClips.Clip> NewClips = new List<TwitchLib.Api.Helix.Models.Clips.GetClips.Clip>();
            bool inListe = false;

            //Unterscheidung nach Länge

            //if (Lastclips.Length <= Currentclips.Length)
            //{
            //CurrentClips ist größer
            for (int i = 0; i < Currentclips.Length; i++)
            {
                for (int y = 0; y < Lastclips.Length; y++)
                {
                    if (Currentclips[i].Id.Equals(Lastclips[y].Id))
                    {
                        inListe = true;
                    }
                }
                if (inListe)
                {
                    inListe = false;
                }
                else
                {
                    NewClips.Add(Currentclips[i]);
                }

            }

            if (NewClips.Count > 0)
            {
                foreach (var item in NewClips)
                {
                    OnClipCreated(item);
                }
                getCurrentClips();
            }
        }

        private String GameByID(string ID)
        {

            List<string> Liste = new List<string>();
            Liste.Add(ID);

            var Suche = TwitchAPI.Helix.Games.GetGamesAsync(Liste);

            //Suche.Start();

            if (Suche.Result.Games != null)
            {
                return Suche.Result.Games[0].Name;
            }
            else
            {
                return "GAME_NOT_FOUND";
            }


        }
        public DateTime getStreamstart()
        {
            if (StreamData != null)
            {
                return StreamData.StartedAt;
            }
            else
            {
                return DateTime.MinValue;
            }
        }

        public bool IsChannelOnline()
        {
            if (Active)
            {
                try
                {
                    var Daten = searchOneChannel(sStandardChannel);
                    return Daten.IsLive;
                }
                catch (Exception e)
                {
                    KonsolenAusgabe("IsChannelOnline ist auf ein Fehler gelaufen: " + Environment.NewLine + e.InnerException);
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
        private void ClipCreate()
        {
            try
            {
                var test = TwitchAPI.Helix.Clips.CreateClipAsync(sChannelID, SettingsGroup.Instance.TsAccessToken);
                KonsolenAusgabe("Clip-Create-Result:" + test.Result.CreatedClips.ToString());
                SendMessage(SettingsGroup.Instance.TeClipCreate.ChatText, sStandardChannel);
            }
            catch (Exception e)
            {
                KonsolenAusgabe("Clip konnte nicht erstellt werden:" + Environment.NewLine + e.InnerException);
                SendMessage(SettingsGroup.Instance.TeClipCreate.FailText, sStandardChannel);
            }

        }
        public string TestClipCreate()
        {
            var test = TwitchAPI.Helix.Clips.CreateClipAsync(sChannelID, SettingsGroup.Instance.TsAccessToken);

            KonsolenAusgabe(test.Result.CreatedClips.Length.ToString());

            return test.Id.ToString();
        }

        public async void test()
        {
            TwitchLib.Api.Helix.Models.Channels.ModifyChannelInformation.ModifyChannelInformationRequest request = new TwitchLib.Api.Helix.Models.Channels.ModifyChannelInformation.ModifyChannelInformationRequest();

            var gamedata = TwitchAPI.Helix.Games.GetGamesAsync(gameNames: new List<String> { "Portal" });

            request.GameId = gamedata.Result.Games[0].Id;

            await TwitchAPI.Helix.Channels.ModifyChannelInformationAsync(sChannelID, request, SettingsGroup.Instance.TsAccessTokenPubSub);
        }
    }
}
