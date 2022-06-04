using AntonBot.PlatformAPI.ListenTypen;
using AntonBot.PlatformAPI.SettingsTypen;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;

namespace AntonBot.PlatformAPI
{
    internal sealed class SettingsGroup
    {
        private SettingsGroup() { }
        public static SettingsGroup Instance { get { return Nested.instance; } }

        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {

            }

            internal static readonly SettingsGroup instance = new SettingsGroup();
        }
        private String DefaultSavePath = System.Windows.Forms.Application.StartupPath + Path.DirectorySeparatorChar + "NoxtanBotSettings.json";

        public byte Version;

        #region DiscordScopes
        public string DSclientID;
        public string DSAccessToken;
        #endregion
        #region DiscordEvents
        public DiscordEvent DsJoinUser;

        public DiscordEvent DsLeftUser;
        #endregion
        #region Settings
        public bool SDiscordAutoStart;
        public bool STwitchAutoStart;
        public String SBefehlSymbol;
        public int SEventTimer;
        public bool STwitchAutoMessage;
        public bool STwitchAutoBotBann;
        public int STwitchAutoBotDuration;
        public StringCollection STwitchAutoBotWhiteList;
        public StringCollection STwitchBlackList;
        public int STwitchAutoBotAmount;
        public bool SDiscordOtherChannel;
        public ulong SDiscordOtherChannelChannel;
        public String StandardPfad;
        public String HTMLPfad;
        public String LogPfad;
        #endregion
        #region TwitchEvents

        public bool TeBitsReaction;
        public TwitchAdminBefehl TeClipCreate;
        public TwitchAdminBefehl TeGoRaid;
        public TwitchEvent TeOnBeingHosted;
        public TwitchEvent TeOnClipCreated;
        public TwitchEvent TeOnConnected;
        public TwitchEvent TeOnExistingUsersDetected;
        public TwitchEvent TeOnJoinedChannel;
        public TwitchEvent TeOnMessageReceived;
        public TwitchEvent TeOnNewFollowersDetected;
        public TwitchEvent TeOnNewSubscriber;
        public TwitchEvent TeOnRaidGo;
        public TwitchEvent TeOnRaidNotification;
        public TwitchEvent TeOnRewardRedeemed;
        public TwitchEvent TeOnStreamOffline;
        public TwitchEvent TeOnStreamOnline;
        public TwitchEvent TeOnStreamUpdate;
        public TwitchEvent TeOnUserJoined;
        public TwitchEvent TeOnUserLeft;
        public TwitchEvent TeOnWhisperReceived;
        public TwitchAdminBefehl TeSO;
        public TwitchAdminBefehl TeUpdateGame;
        public TwitchAdminBefehl TeUpdateTitle;
        #endregion
        #region TwitchScopes
        public bool Tschat_edit;
        public bool Tschat_read;
        public bool Tswhispers_read;
        public bool Tswhispers_edit;
        public String TsclientID;
        public String TsAccessToken;
        public bool Tschannel_manage_redemptions;
        public bool Tsbits_read;
        public bool Tschannel_read_redemptions;
        public bool Tsuser_edit;
        public bool Tsuser_edit_broadcast;
        public bool Tschannel_editor;
        public bool Tschannel_moderate;
        public bool Tsuser_read;
        public bool Tsclips_edit;
        public String TsStandardChannel;
        public String TsAccessTokenPubSub;
        public bool TsPubSubZusatz;
        public bool TsOnline;
        #endregion

        #region JsonListen
        public List<Befehl> InhaltBefehl;
        public List<Befehl> InhaltBefehlTwitch;
        public List<BitElement> InhaltBitListe;
        public List<JoinedUsers> InhaltJoinedUsers;
        public List<DiscordGilde> InhaltDiscordServer;
        public List<List_Befehl> InhaltListBefehl;
        public List<Zeit_Befehl> InhaltZeitBefehl;
        public List<GameSkill> InhaltSkillList;
        #endregion

        #region Skill
        public bool SkillUse;

        public TwitchAdminBefehl SkillMain;
        public TwitchAdminBefehl SkillSub;
        public TwitchAdminBefehl SkillClear;
        public TwitchAdminBefehl SkillStatus;
        public TwitchAdminBefehl SkillUpdate;
        public TwitchAdminBefehl SkillList;
        #endregion

        private void SetVersion()
        {
            //Funktion zum setzen der Version (manuell)
            //Diese wird beim Laden geprüft um festzustellen, ob ein Update der Settings gemacht werden muss oder nicht
            //Keine Ausgabe an die Oberfläche
            Version = 8;
        }

        public void LoadSettings()
        {
            if (File.Exists(DefaultSavePath))
            {
                SettingsGroup load = JsonConvert.DeserializeObject<SettingsGroup>(File.ReadAllText(DefaultSavePath));
                SetVersion();
                DSclientID = load.DSclientID;
                DSAccessToken = load.DSAccessToken;

                DsJoinUser = load.DsJoinUser;
                DsLeftUser = load.DsLeftUser;

                SDiscordAutoStart = load.SDiscordAutoStart;
                STwitchAutoStart = load.STwitchAutoStart;
                SBefehlSymbol = load.SBefehlSymbol;
                SEventTimer = load.SEventTimer;
                STwitchAutoMessage = load.STwitchAutoMessage;
                STwitchAutoBotBann = load.STwitchAutoBotBann;
                STwitchAutoBotDuration = load.STwitchAutoBotDuration;
                STwitchAutoBotWhiteList = load.STwitchAutoBotWhiteList;
                STwitchBlackList = load.STwitchBlackList;
                STwitchAutoBotAmount = load.STwitchAutoBotAmount;
                SDiscordOtherChannel = load.SDiscordOtherChannel;
                SDiscordOtherChannelChannel = load.SDiscordOtherChannelChannel;

                if (Directory.Exists(load.StandardPfad))
                {
                    StandardPfad = load.StandardPfad;
                }
                else
                {
                    StandardPfad = System.Windows.Forms.Application.StartupPath + Path.DirectorySeparatorChar;
                }
                if (Directory.Exists(load.HTMLPfad))
                {
                    HTMLPfad = load.HTMLPfad;
                }
                else
                {
                    HTMLPfad = System.Windows.Forms.Application.StartupPath + Path.DirectorySeparatorChar + "WebSite" + Path.DirectorySeparatorChar; ;
                }
                if (Directory.Exists(load.LogPfad))
                {
                    LogPfad = load.LogPfad;
                }
                else
                {
                    LogPfad = System.Windows.Forms.Application.StartupPath + Path.DirectorySeparatorChar;
                }



                TeBitsReaction = load.TeBitsReaction;

                TeClipCreate = load.TeClipCreate;
                TeGoRaid = load.TeGoRaid;
                TeOnBeingHosted = load.TeOnBeingHosted;
                TeOnClipCreated = load.TeOnClipCreated;
                TeOnConnected = load.TeOnConnected;
                TeOnExistingUsersDetected = load.TeOnExistingUsersDetected;
                TeOnJoinedChannel = load.TeOnJoinedChannel;
                TeOnMessageReceived = load.TeOnMessageReceived;
                TeOnNewFollowersDetected = load.TeOnNewFollowersDetected;
                TeOnNewSubscriber = load.TeOnNewSubscriber;
                TeOnRaidGo = load.TeOnRaidGo;
                TeOnRaidNotification = load.TeOnRaidNotification;
                TeOnRewardRedeemed = load.TeOnRewardRedeemed;
                TeOnStreamOffline = load.TeOnStreamOffline;
                TeOnStreamOnline = load.TeOnStreamOnline;
                TeOnStreamUpdate = load.TeOnStreamUpdate;
                TeOnUserJoined = load.TeOnUserJoined;
                TeOnUserLeft = load.TeOnUserLeft;
                TeOnWhisperReceived = load.TeOnWhisperReceived;
                TeSO = load.TeSO;
                TeUpdateGame = load.TeUpdateGame;
                TeUpdateTitle = load.TeUpdateTitle;

                Tschat_edit = load.Tschat_edit;
                Tschat_read = load.Tschat_read;
                Tswhispers_read = load.Tswhispers_read;
                Tswhispers_edit = load.Tswhispers_edit;
                TsclientID = load.TsclientID;
                TsAccessToken = load.TsAccessToken;
                Tschannel_manage_redemptions = load.Tschannel_manage_redemptions;
                Tsbits_read = load.Tsbits_read;
                Tschannel_read_redemptions = load.Tschannel_read_redemptions;
                Tsuser_edit = load.Tsuser_edit;
                Tsuser_edit_broadcast = load.Tsuser_edit_broadcast;
                Tschannel_editor = load.Tschannel_editor;
                Tschannel_moderate = load.Tschannel_moderate;
                Tsuser_read = load.Tsuser_read;
                Tsclips_edit = load.Tsclips_edit;
                TsStandardChannel = load.TsStandardChannel;
                TsAccessTokenPubSub = load.TsAccessTokenPubSub;
                TsPubSubZusatz = load.TsPubSubZusatz;
                TsOnline = load.TsOnline;

                SkillUse = load.SkillUse;

                SkillMain = load.SkillMain;
                SkillSub = load.SkillSub;
                SkillClear = load.SkillClear;
                SkillList = load.SkillList;
                SkillUpdate = load.SkillUpdate;
                SkillStatus = load.SkillStatus;

                if (Version != load.Version)
                {
                    Update();
                }
            }
            else
            {
                setStandardSettings();
                Save(DefaultSavePath);
            }

        }
        public void setStandardSettings()
        {

            DSclientID = "";
            DSAccessToken = "";

            DsJoinUser = new DiscordEvent("JoinUser");
            DsLeftUser = new DiscordEvent("LeftUser");

            SDiscordAutoStart = false;
            STwitchAutoStart = false;
            SBefehlSymbol = "!";
            SEventTimer = 30;
            STwitchAutoMessage = false;
            STwitchAutoBotBann = false;
            STwitchAutoBotDuration = 7;
            STwitchAutoBotWhiteList = new StringCollection();
            STwitchBlackList = new StringCollection();
            STwitchAutoBotAmount = 5;
            SDiscordOtherChannel = false;
            SDiscordOtherChannelChannel = 0;
            StandardPfad = System.Windows.Forms.Application.StartupPath + Path.DirectorySeparatorChar;
            LogPfad = System.Windows.Forms.Application.StartupPath + Path.DirectorySeparatorChar;
            HTMLPfad = System.Windows.Forms.Application.StartupPath + Path.DirectorySeparatorChar + "WebSite" + Path.DirectorySeparatorChar;

            TeBitsReaction = false;
            TeClipCreate = new TwitchAdminBefehl("CreateClip");
            TeGoRaid = new TwitchAdminBefehl("Update GoRaid-Message");
            TeOnBeingHosted = new TwitchEvent("OnBeingHosted");
            TeOnClipCreated = new TwitchEvent("OnClipCreated");
            TeOnConnected = new TwitchEvent("OnConnected");
            TeOnExistingUsersDetected = new TwitchEvent("OnExistingUsersDetected");
            TeOnJoinedChannel = new TwitchEvent("OnJoinedChannel");
            TeOnMessageReceived = new TwitchEvent("OnMessageReceived");
            //Standardwerte für das Event
            TeOnMessageReceived.Use = false;
            TeOnMessageReceived.Channel = new StringCollection();
            TeOnMessageReceived.Chat = false;
            TeOnMessageReceived.ChatText = "Die Reaktion auf einer Chat-Nachricht erfolgt über die Bot-Kommandos. Eine Einstellung hier ist, außer die Aktivierung, nicht notwendig";
            TeOnMessageReceived.Discord = false;
            TeOnMessageReceived.DiscordText = "Auf eine Twitch Nachricht, sollte am Besten auch auf Twitch reagiert werden und nicht auf Discord";
            TeOnMessageReceived.Konsole = false;
            TeOnMessageReceived.KonsoleText = "Die Ausgabe würde bei vielen Nachrichten sehr schnell voll laufen, daher ist hier keine Einstellung möglich";

            TeOnNewFollowersDetected = new TwitchEvent("OnNewFollowersDetected");
            TeOnNewSubscriber = new TwitchEvent("OnNewSubscriber");
            TeOnRaidGo = new TwitchEvent("OnRaidGo");
            TeOnRaidNotification = new TwitchEvent("OnRaidNotification");
            TeOnRewardRedeemed = new TwitchEvent("OnRewardRedeemed");
            TeOnStreamOffline = new TwitchEvent("OnStreamOffline");
            TeOnStreamOnline = new TwitchEvent("OnStreamOnline");
            TeOnStreamUpdate = new TwitchEvent("OnStreamUpdate");
            TeOnUserJoined = new TwitchEvent("OnUserJoined");
            //Standardwerte für das Event
            TeOnUserJoined.Use = false;
            TeOnUserJoined.Channel = new StringCollection();
            TeOnUserJoined.Chat = false;
            TeOnUserJoined.ChatText = "Das Event wird erzeugt, wenn sich der Bot an einem Channel verbindet. Diese Info hat nichts im Chat zu suchen";
            TeOnUserJoined.Discord = false;
            TeOnUserJoined.DiscordText = "Das Event wird erzeugt, wenn sich der Bot an einem Channel verbindet. Diese Info hat nichts im Discord zu suchen";
            TeOnUserJoined.Konsole = false;
            TeOnUserJoined.KonsoleText = "";

            TeOnUserLeft = new TwitchEvent("OnUserLeft");
            TeOnWhisperReceived = new TwitchEvent("TeOnWhisperReceived");
            TeSO = new TwitchAdminBefehl("ShoutOut");
            TeUpdateGame = new TwitchAdminBefehl("Update StreamGame");
            TeUpdateTitle = new TwitchAdminBefehl("Update StreamTitle");

            Tschat_edit = false;
            Tschat_read = false;
            Tswhispers_read = false;
            Tswhispers_edit = false;
            TsclientID = "";
            TsAccessToken = "";
            Tschannel_manage_redemptions = false;
            Tsbits_read = false;
            Tschannel_read_redemptions = false;
            Tsuser_edit = false;
            Tsuser_edit_broadcast = false;
            Tschannel_editor = false;
            Tschannel_moderate = false;
            Tsuser_read = false;
            Tsclips_edit = false;
            TsStandardChannel = "";
            TsAccessTokenPubSub = "";
            TsPubSubZusatz = false;
            TsOnline = false;

            SkillUse = false;

            SkillMain = new TwitchAdminBefehl("Skill - Mainquest");
            SkillSub = new TwitchAdminBefehl("Skill - Subquest");
            SkillClear = new TwitchAdminBefehl("Skill - Clear");
            SkillList = new TwitchAdminBefehl("Skill - Status");
            SkillUpdate = new TwitchAdminBefehl("Skill - Update");
            SkillStatus = new TwitchAdminBefehl("Skill - List");
        }

        public void Update()
        {
            SettingsGroup load = JsonConvert.DeserializeObject<SettingsGroup>(File.ReadAllText(DefaultSavePath));
            setStandardSettings();
            if (load.DSclientID != null) { DSAccessToken = load.DSclientID; }
            if (load.DSAccessToken != null) { DSAccessToken = load.DSAccessToken; }

            DsJoinUser.UpdateCommand(load.DsJoinUser);
            DsLeftUser.UpdateCommand(load.DsLeftUser);

            SDiscordAutoStart = load.SDiscordAutoStart;
            STwitchAutoStart = load.STwitchAutoStart;
            if (load.SBefehlSymbol != null) { SBefehlSymbol = load.SBefehlSymbol; }
            SEventTimer = load.SEventTimer;
            STwitchAutoMessage = load.STwitchAutoMessage;
            STwitchAutoBotBann = load.STwitchAutoBotBann;
            STwitchAutoBotDuration = load.STwitchAutoBotDuration;
            if (load.STwitchAutoBotWhiteList != null) { STwitchAutoBotWhiteList = load.STwitchAutoBotWhiteList; }
            if (load.STwitchBlackList != null) { STwitchBlackList = load.STwitchBlackList; }
            STwitchAutoBotAmount = load.STwitchAutoBotAmount;
            SDiscordOtherChannel = load.SDiscordOtherChannel;
            SDiscordOtherChannelChannel = load.SDiscordOtherChannelChannel;

            if (load.StandardPfad != null)
            {
                if (Directory.Exists(load.StandardPfad))
                {
                    StandardPfad = load.StandardPfad;
                }
                else
                {
                    StandardPfad = System.Windows.Forms.Application.StartupPath + Path.DirectorySeparatorChar;
                }
            }
            if (load.HTMLPfad != null) {
                if (Directory.Exists(load.HTMLPfad))
                {
                    HTMLPfad = load.HTMLPfad;
                }
                else
                {
                    HTMLPfad = System.Windows.Forms.Application.StartupPath + Path.DirectorySeparatorChar + "WebSite" + Path.DirectorySeparatorChar; ;
                }
            }
            if (load.LogPfad != null) {
                if (Directory.Exists(load.LogPfad))
                {
                    LogPfad = load.LogPfad;
                }
                else
                {
                    LogPfad = System.Windows.Forms.Application.StartupPath + Path.DirectorySeparatorChar;
                }
            }

            TeBitsReaction = load.TeBitsReaction;

            load.TeClipCreate = null;
            TeClipCreate.UpdateCommand(load.TeClipCreate);
            TeGoRaid.UpdateCommand(load.TeGoRaid);
            TeOnBeingHosted.UpdateCommand(load.TeOnBeingHosted);
            TeOnClipCreated.UpdateCommand(load.TeOnClipCreated);
            TeOnConnected.UpdateCommand(load.TeOnConnected);
            TeOnExistingUsersDetected.UpdateCommand(load.TeOnExistingUsersDetected);
            TeOnJoinedChannel.UpdateCommand(load.TeOnJoinedChannel);
            TeOnMessageReceived.UpdateCommand(load.TeOnMessageReceived);
            TeOnNewFollowersDetected.UpdateCommand(load.TeOnNewFollowersDetected);
            TeOnNewSubscriber.UpdateCommand(load.TeOnNewSubscriber);
            TeOnRaidGo.UpdateCommand(load.TeOnRaidGo);
            TeOnRaidNotification.UpdateCommand(load.TeOnRaidNotification);
            TeOnRewardRedeemed.UpdateCommand(load.TeOnRewardRedeemed);
            TeOnStreamOffline.UpdateCommand(load.TeOnStreamOffline);
            TeOnStreamOnline.UpdateCommand(load.TeOnStreamOnline);
            TeOnStreamUpdate.UpdateCommand(load.TeOnStreamUpdate);
            TeOnUserJoined.UpdateCommand(load.TeOnUserJoined);
            TeOnUserLeft.UpdateCommand(load.TeOnUserLeft);
            TeOnWhisperReceived.UpdateCommand(load.TeOnWhisperReceived);
            TeSO.UpdateCommand(load.TeSO);
            TeUpdateGame.UpdateCommand(load.TeUpdateGame);
            TeUpdateTitle.UpdateCommand(load.TeUpdateTitle);

            Tschat_edit = load.Tschat_edit;
            Tschat_read = load.Tschat_read;
            Tswhispers_read = load.Tswhispers_read;
            Tswhispers_edit = load.Tswhispers_edit;
            if (load.TsclientID != null) { TsclientID = load.TsclientID; }
            if (load.TsAccessToken != null) { TsAccessToken = load.TsAccessToken; }
            Tschannel_manage_redemptions = load.Tschannel_manage_redemptions;
            Tsbits_read = load.Tsbits_read;
            Tschannel_read_redemptions = load.Tschannel_read_redemptions;
            Tsuser_edit = load.Tsuser_edit;
            Tsuser_edit_broadcast = load.Tsuser_edit_broadcast;
            Tschannel_editor = load.Tschannel_editor;
            Tschannel_moderate = load.Tschannel_moderate;
            Tsuser_read = load.Tsuser_read;
            Tsclips_edit = load.Tsclips_edit;
            if (load.TsStandardChannel != null) { TsStandardChannel = load.TsStandardChannel; }
            if (load.TsAccessTokenPubSub != null) { TsAccessTokenPubSub = load.TsAccessTokenPubSub; }
            TsPubSubZusatz = load.TsPubSubZusatz;
            TsOnline = load.TsOnline;

            SkillUse = load.SkillUse;

            SkillMain.UpdateCommand(load.SkillMain);
            SkillSub.UpdateCommand(load.SkillSub);
            SkillClear.UpdateCommand(load.SkillClear);
            SkillList.UpdateCommand(load.SkillList);
            SkillUpdate.UpdateCommand(load.SkillUpdate);
            SkillStatus.UpdateCommand(load.SkillStatus);

            Save(DefaultSavePath);
        }

        public void Save(String SpeicherPfad)
        {
            string InhaltJSON = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(SpeicherPfad, InhaltJSON);
        }
        public void Save()
        {
            Save(DefaultSavePath);
        }

        public void ExportSettingsGroup(String ApplicationPath)
        {

            if (File.Exists(ApplicationPath + "Befehl.json"))
            {
                InhaltBefehl = JsonConvert.DeserializeObject<List<Befehl>>(File.ReadAllText(ApplicationPath + "Befehl.json"));
            }
            if (File.Exists(ApplicationPath + "Befehl-Twitch.json"))
            {
                InhaltBefehlTwitch = JsonConvert.DeserializeObject<List<Befehl>>(File.ReadAllText(ApplicationPath + "Befehl-Twitch.json"));
            }
            if (File.Exists(ApplicationPath + "BitListe.json"))
            {
                InhaltBitListe = JsonConvert.DeserializeObject<List<BitElement>>(File.ReadAllText(ApplicationPath + "BitListe.json"));
            }
            if (File.Exists(ApplicationPath + "DiscordServer.json"))
            {
                InhaltDiscordServer = JsonConvert.DeserializeObject<List<DiscordGilde>>(File.ReadAllText(ApplicationPath + "DiscordServer.json"));
            }
            if (File.Exists(ApplicationPath + "JoinedUsers.json"))
            {
                InhaltJoinedUsers = JsonConvert.DeserializeObject<List<JoinedUsers>>(File.ReadAllText(ApplicationPath + "JoinedUsers.json"));
            }
            if (File.Exists(ApplicationPath + "List-Befehl.json"))
            {
                InhaltListBefehl = JsonConvert.DeserializeObject<List<List_Befehl>>(File.ReadAllText(ApplicationPath + "List-Befehl.json"));
            }
            if (File.Exists(ApplicationPath + "Zeit-Befehl.json"))
            {
                InhaltZeitBefehl = JsonConvert.DeserializeObject<List<Zeit_Befehl>>(File.ReadAllText(ApplicationPath + "Zeit-Befehl.json"));
            }
            if (File.Exists(ApplicationPath + "SkillListe.json"))
            {
                InhaltSkillList = JsonConvert.DeserializeObject<List<GameSkill>>(File.ReadAllText(ApplicationPath + "SkillListe.json"));
            }
        }

        public String WriteAllSettings()
        {
            try
            {
                File.WriteAllText(StandardPfad + "Befehl.json", JsonConvert.SerializeObject(InhaltBefehl, Formatting.Indented));
                File.WriteAllText(StandardPfad + "Befehl-Twitch.json", JsonConvert.SerializeObject(InhaltBefehlTwitch, Formatting.Indented));
                File.WriteAllText(StandardPfad + "BitListe.json", JsonConvert.SerializeObject(InhaltBitListe, Formatting.Indented));
                File.WriteAllText(StandardPfad + "DiscordServer.json", JsonConvert.SerializeObject(InhaltDiscordServer, Formatting.Indented));
                File.WriteAllText(StandardPfad + "List-Befehl.json", JsonConvert.SerializeObject(InhaltListBefehl, Formatting.Indented));
                File.WriteAllText(StandardPfad + "Zeit-Befehl.json", JsonConvert.SerializeObject(InhaltZeitBefehl, Formatting.Indented));
                File.WriteAllText(StandardPfad + "SkillListe.json", JsonConvert.SerializeObject(InhaltSkillList, Formatting.Indented));
                File.WriteAllText(StandardPfad + "JoinedUsers.json", JsonConvert.SerializeObject(InhaltJoinedUsers, Formatting.Indented));
                return "Erfolg";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public void ImportSettingsGroup(String Inhalt)
        {
            SettingsGroup Import = JsonConvert.DeserializeObject<SettingsGroup>(Inhalt);

            //discordScopes
            SettingsGroup.Instance.DSclientID = Import.DSclientID;
            SettingsGroup.Instance.DSAccessToken = Import.DSAccessToken;

            //discordEvents
            SettingsGroup.Instance.DsJoinUser = Import.DsJoinUser;
            SettingsGroup.Instance.DsLeftUser = Import.DsLeftUser;

            //settings

            SettingsGroup.Instance.SDiscordAutoStart = Import.SDiscordAutoStart;
            SettingsGroup.Instance.STwitchAutoStart = Import.STwitchAutoStart;
            SettingsGroup.Instance.SBefehlSymbol = Import.SBefehlSymbol;
            SettingsGroup.Instance.SEventTimer = Import.SEventTimer;
            SettingsGroup.Instance.STwitchAutoMessage = Import.STwitchAutoMessage;
            SettingsGroup.Instance.STwitchAutoBotBann = Import.STwitchAutoBotBann;
            SettingsGroup.Instance.STwitchAutoBotDuration = Import.STwitchAutoBotDuration;
            SettingsGroup.Instance.STwitchAutoBotWhiteList = Import.STwitchAutoBotWhiteList;
            SettingsGroup.Instance.STwitchBlackList = Import.STwitchBlackList;
            SettingsGroup.Instance.STwitchAutoBotAmount = Import.STwitchAutoBotAmount;
            SettingsGroup.Instance.SDiscordOtherChannel = Import.SDiscordOtherChannel;
            SettingsGroup.Instance.SDiscordOtherChannelChannel = Import.SDiscordOtherChannelChannel;
            SettingsGroup.Instance.StandardPfad = Import.StandardPfad;
            SettingsGroup.Instance.HTMLPfad = Import.HTMLPfad;
            SettingsGroup.Instance.LogPfad = Import.LogPfad;

            //twitchEvent

            SettingsGroup.Instance.TeBitsReaction = Import.TeBitsReaction;

            SettingsGroup.Instance.TeGoRaid = Import.TeGoRaid;
            SettingsGroup.Instance.TeClipCreate = Import.TeClipCreate;
            SettingsGroup.Instance.TeGoRaid = Import.TeGoRaid;
            SettingsGroup.Instance.TeOnBeingHosted = Import.TeOnBeingHosted;
            SettingsGroup.Instance.TeOnClipCreated = Import.TeOnClipCreated;
            SettingsGroup.Instance.TeOnConnected = Import.TeOnConnected;
            SettingsGroup.Instance.TeOnExistingUsersDetected = Import.TeOnExistingUsersDetected;
            SettingsGroup.Instance.TeOnJoinedChannel = Import.TeOnJoinedChannel;
            SettingsGroup.Instance.TeOnMessageReceived = Import.TeOnMessageReceived;
            SettingsGroup.Instance.TeOnNewFollowersDetected = Import.TeOnNewFollowersDetected;
            SettingsGroup.Instance.TeOnNewSubscriber = Import.TeOnNewSubscriber;
            SettingsGroup.Instance.TeOnRaidGo = Import.TeOnRaidGo;
            SettingsGroup.Instance.TeOnRaidNotification = Import.TeOnRaidNotification;
            SettingsGroup.Instance.TeOnRewardRedeemed = Import.TeOnRewardRedeemed;
            SettingsGroup.Instance.TeOnStreamOffline = Import.TeOnStreamOffline;
            SettingsGroup.Instance.TeOnStreamOnline = Import.TeOnStreamOnline;
            SettingsGroup.Instance.TeOnStreamUpdate = Import.TeOnStreamUpdate;
            SettingsGroup.Instance.TeOnUserJoined = Import.TeOnUserJoined;
            SettingsGroup.Instance.TeOnUserLeft = Import.TeOnUserLeft;
            SettingsGroup.Instance.TeOnWhisperReceived = Import.TeOnWhisperReceived;
            SettingsGroup.Instance.TeSO = Import.TeSO;
            SettingsGroup.Instance.TeUpdateGame = Import.TeUpdateGame;
            SettingsGroup.Instance.TeUpdateTitle = Import.TeUpdateTitle;

            //twitchScopes

            SettingsGroup.Instance.Tschat_edit = Import.Tschat_edit;
            SettingsGroup.Instance.Tschat_read = Import.Tschat_read;
            SettingsGroup.Instance.Tswhispers_read = Import.Tswhispers_read;
            SettingsGroup.Instance.Tswhispers_edit = Import.Tswhispers_edit;
            SettingsGroup.Instance.TsclientID = Import.TsclientID;
            SettingsGroup.Instance.TsAccessToken = Import.TsAccessToken;
            SettingsGroup.Instance.Tschannel_manage_redemptions = Import.Tschannel_manage_redemptions;
            SettingsGroup.Instance.Tsbits_read = Import.Tsbits_read;
            SettingsGroup.Instance.Tschannel_read_redemptions = Import.Tschannel_read_redemptions;
            SettingsGroup.Instance.Tsuser_edit = Import.Tsuser_edit;
            SettingsGroup.Instance.Tsuser_edit_broadcast = Import.Tsuser_edit_broadcast;
            SettingsGroup.Instance.Tschannel_editor = Import.Tschannel_editor;
            SettingsGroup.Instance.Tschannel_moderate = Import.Tschannel_moderate;
            SettingsGroup.Instance.Tsuser_read = Import.Tsuser_read;
            SettingsGroup.Instance.Tsclips_edit = Import.Tsclips_edit;
            SettingsGroup.Instance.TsStandardChannel = Import.TsStandardChannel;
            SettingsGroup.Instance.TsAccessTokenPubSub = Import.TsAccessTokenPubSub;
            SettingsGroup.Instance.TsPubSubZusatz = Import.TsPubSubZusatz;
            SettingsGroup.Instance.TsOnline = Import.TsOnline;

            //Skills
            SettingsGroup.Instance.SkillUse = Import.SkillUse;

            SettingsGroup.Instance.SkillMain = Import.SkillMain;
            SettingsGroup.Instance.SkillSub = Import.SkillSub;
            SettingsGroup.Instance.SkillClear = Import.SkillClear;
            SettingsGroup.Instance.SkillList = Import.SkillList;
            SettingsGroup.Instance.SkillUpdate = Import.SkillUpdate;
            SettingsGroup.Instance.SkillStatus = Import.SkillStatus;

            Save(DefaultSavePath);

            WriteAllSettings();
        }
    }
}
