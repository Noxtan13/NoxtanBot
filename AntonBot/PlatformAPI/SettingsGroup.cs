using System;
using System.Collections.Specialized;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using AntonBot.PlatformAPI.ListenTypen;

namespace AntonBot.PlatformAPI
{
    sealed class SettingsGroup
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

        #region DiscordScopes
        public string DSclientID;
        public string DSAccessToken;
        #endregion
        #region DiscordEvents
        public bool DsJoinUser;
        public bool DsJoinUserDiscord;
        public String DsJoinUserDiscordText;
        public StringCollection DsJoinUserChannel;
        public bool DsJoinUserKonsole;
        public String DsJoinUserKonsoleText;
        public bool DsJoinUserTwitch;
        public String DsJoinUserTwitchText;

        public bool DsLeftUser;
        public bool DsLeftUserDiscord;
        public String DsLeftUserDiscordText;
        public StringCollection DsLeftUserChannel;
        public bool DsLeftUserKonsole;
        public String DsLeftUserKonsoleText;
        public bool DsLeftUserTwitch;
        public String DsLeftUserTwitchText;
        #endregion
        #region Settings
        public bool SDiscordAutoStart;
        public bool STwitchAutoStart;
        public String SBefehlSymbol;
        public bool SAutoBan;
        public int SEventTimer;
        public bool STwitchAutoMessage;
        public bool STwitchAutoBotBann;
        public int STwitchAutoBotDuration;
        public StringCollection STwitchAutoBotWhiteList;
        public int STwitchAutoBotAmount;
        public bool SDiscordOtherChannel;
        public ulong SDiscordOtherChannelChannel;
        #endregion
        #region TwitchEvents

        public bool TeBitsReaction;
        public bool TeClipCreateAdmin;
        public bool TeClipCreateBoardcast;
        public bool TeClipCreateVIP;
        public String TeClipCreateChatText;
        public String TeClipCreateCommand;
        public String TeClipCreateFailText;
        public bool TeClipCreateUse;
        public bool TeGoRaidTextAdmin;
        public bool TeGoRaidTextBroadcaster;
        public bool TeGoRaidTextVIP;
        public String TeGoRaidTextChat;
        public String TeGoRaidTextCommand;
        public String TeGoRaidTextFail;
        public bool TeGoRaidTextUse;
        public bool TeOnBeingHosted;
        public StringCollection TeOnBeingHostedChannel;
        public bool TeOnBeingHostedChat;
        public String TeOnBeingHostedChatText;
        public bool TeOnBeingHostedDiscord;
        public String TeOnBeingHostedDiscordText;
        public bool TeOnBeingHostedKonsole;
        public String TeOnBeingHostedKonsoleText;
        public bool TeOnClipCreated;
        public StringCollection TeOnClipCreatedChannel;
        public bool TeOnClipCreatedChat;
        public String TeOnClipCreatedChatText;
        public bool TeOnClipCreatedDiscord;
        public String TeOnClipCreatedDiscordText;
        public bool TeOnClipCreatedKonsole;
        public String TeOnClipCreatedKonsoleText;
        public bool TeOnConnected;
        public StringCollection TeOnConnectedChannel;
        public bool TeOnConnectedChat;
        public String TeOnConnectedChatText;
        public bool TeOnConnectedDiscord;
        public String TeOnConnectedDiscordText;
        public bool TeOnConnectedKonsole;
        public String TeOnConnectedKonsoleText;
        public bool TeOnExistingUsersDetected;
        public StringCollection TeOnExistingUsersDetectedChannel;
        public bool TeOnExistingUsersDetectedChat;
        public String TeOnExistingUsersDetectedChatText;
        public bool TeOnExistingUsersDetectedDiscord;
        public String TeOnExistingUsersDetectedDiscordText;
        public bool TeOnExistingUsersDetectedKonsole;
        public String TeOnExistingUsersDetectedKonsoleText;
        public bool TeOnJoinedChannel;
        public StringCollection TeOnJoinedChannelChannel;
        public bool TeOnJoinedChannelChat;
        public String TeOnJoinedChannelChatText;
        public bool TeOnJoinedChannelDiscord;
        public String TeOnJoinedChannelDiscordText;
        public bool TeOnJoinedChannelKonsole;
        public String TeOnJoinedChannelKonsoleText;
        public bool TeOnMessageReceived;
        public StringCollection TeOnMessageReceivedChannel;
        public bool TeOnMessageReceivedChat;
        public String TeOnMessageReceivedChatText;
        public bool TeOnMessageReceivedDiscord;
        public String TeOnMessageReceivedDiscordText;
        public bool TeOnMessageReceivedKonsole;
        public String TeOnMessageReceivedKonsoleText;
        public bool TeOnNewFollowersDetected;
        public StringCollection TeOnNewFollowersDetectedChannel;
        public bool TeOnNewFollowersDetectedChat;
        public String TeOnNewFollowersDetectedChatText;
        public bool TeOnNewFollowersDetectedDiscord;
        public String TeOnNewFollowersDetectedDiscordText;
        public bool TeOnNewFollowersDetectedKonsole;
        public String TeOnNewFollowersDetectedKonsoleText;
        public bool TeOnNewSubscriber;
        public StringCollection TeOnNewSubscriberChannel;
        public bool TeOnNewSubscriberChat;
        public String TeOnNewSubscriberChatText;
        public bool TeOnNewSubscriberDiscord;
        public String TeOnNewSubscriberDiscordText;
        public bool TeOnNewSubscriberKonsole;
        public String TeOnNewSubscriberKonsoleText;
        public bool TeOnRaidGo;
        public StringCollection TeOnRaidGoChannel;
        public bool TeOnRaidGoChat;
        public String TeOnRaidGoChatText;
        public bool TeOnRaidGoDiscord;
        public String TeOnRaidGoDiscordText;
        public bool TeOnRaidGoKonsole;
        public String TeOnRaidGoKonsoleText;
        public bool TeOnRaidNotification;
        public StringCollection TeOnRaidNotificationChannel;
        public bool TeOnRaidNotificationChat;
        public String TeOnRaidNotificationChatText;
        public bool TeOnRaidNotificationDiscord;
        public String TeOnRaidNotificationDiscordText;
        public bool TeOnRaidNotificationKonsole;
        public String TeOnRaidNotificationKonsoleText;
        public bool TeOnRewardRedeemed;
        public StringCollection TeOnRewardRedeemedChannel;
        public bool TeOnRewardRedeemedChat;
        public String TeOnRewardRedeemedChatText;
        public bool TeOnRewardRedeemedDiscord;
        public String TeOnRewardRedeemedDiscordText;
        public bool TeOnRewardRedeemedKonsole;
        public String TeOnRewardRedeemedKonsoleText;
        public bool TeOnStreamOffline;
        public StringCollection TeOnStreamOfflineChannel;
        public bool TeOnStreamOfflineChat;
        public String TeOnStreamOfflineChatText;
        public bool TeOnStreamOfflineDiscord;
        public String TeOnStreamOfflineDiscordText;
        public bool TeOnStreamOfflineKonsole;
        public String TeOnStreamOfflineKonsoleText;
        public bool TeOnStreamOnline;
        public StringCollection TeOnStreamOnlineChannel;
        public bool TeOnStreamOnlineChat;
        public String TeOnStreamOnlineChatText;
        public bool TeOnStreamOnlineDiscord;
        public String TeOnStreamOnlineDiscordText;
        public bool TeOnStreamOnlineKonsole;
        public String TeOnStreamOnlineKonsoleText;
        public bool TeOnStreamUpdate;
        public StringCollection TeOnStreamUpdateChannel;
        public bool TeOnStreamUpdateChat;
        public String TeOnStreamUpdateChatText;
        public bool TeOnStreamUpdateDiscord;
        public String TeOnStreamUpdateDiscordText;
        public bool TeOnStreamUpdateKonsole;
        public String TeOnStreamUpdateKonsoleText;
        public bool TeOnUserJoined;
        public StringCollection TeOnUserJoinedChannel;
        public bool TeOnUserJoinedChat;
        public String TeOnUserJoinedChatText;
        public bool TeOnUserJoinedDiscord;
        public String TeOnUserJoinedDiscordText;
        public bool TeOnUserJoinedKonsole;
        public String TeOnUserJoinedKonsoleText;
        public bool TeOnUserLeft;
        public StringCollection TeOnUserLeftChannel;
        public bool TeOnUserLeftChat;
        public String TeOnUserLeftChatText;
        public bool TeOnUserLeftDiscord;
        public String TeOnUserLeftDiscordText;
        public bool TeOnUserLeftKonsole;
        public String TeOnUserLeftKonsoleText;
        public bool TeOnWhisperReceived;
        public StringCollection TeOnWhisperReceivedChannel;
        public bool TeOnWhisperReceivedChat;
        public String TeOnWhisperReceivedChatText;
        public bool TeOnWhisperReceivedDiscord;
        public String TeOnWhisperReceivedDiscordText;
        public bool TeOnWhisperReceivedKonsole;
        public String TeOnWhisperReceivedKonsoleText;
        public bool TeSOAdmin;
        public bool TeSOBoardcast;
        public bool TeSOVIP;
        public String TeSOChatText;
        public String TeSOCommand;
        public String TeSOFailText;
        public bool TeSOUse;
        public bool TeUpdateGameAdmin;
        public bool TeUpdateGameBoardcaster;
        public bool TeUpdateGameVIP;
        public String TeUpdateGameChatText;
        public String TeUpdateGameCommand;
        public String TeUpdateGameFailText;
        public bool TeUpdateGameUse;
        public bool TeUpdateTitleAdmin;
        public bool TeUpdateTitleBroadcaster;
        public bool TeUpdateTitleVIP;
        public String TeUpdateTitleChatText;
        public String TeUpdateTitleCommand;
        public String TeUpdateTitleFailText;
        public bool TeUpdateTitleUse;

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
        public List<DiscordGilde> InhaltDiscordServer;
        public List<JoinedUsers> InhaltJoinedUsers;
        public List<List_Befehl> InhaltListBefehl;
        public List<Zeit_Befehl> InhaltZeitBefehl;
        public List<GameSkill> InhaltSkillList;
        #endregion

        #region Skill
        public bool SkillUse;

        #endregion

        public void LoadSettings()
        {
            if (File.Exists(DefaultSavePath))
            {
                SettingsGroup load = JsonConvert.DeserializeObject<SettingsGroup>(File.ReadAllText(DefaultSavePath));
                DSclientID = load.DSclientID;
                DSAccessToken = load.DSAccessToken;

                DsJoinUser = load.DsJoinUser;
                DsJoinUserChannel = load.DsJoinUserChannel;
                DsJoinUserDiscord = load.DsJoinUserDiscord;
                DsJoinUserDiscordText = load.DsJoinUserDiscordText;
                DsJoinUserKonsole = load.DsJoinUserKonsole;
                DsJoinUserKonsoleText = load.DsJoinUserKonsoleText;
                DsJoinUserTwitch = load.DsJoinUserTwitch;
                DsJoinUserTwitchText = load.DsJoinUserTwitchText;
                DsLeftUser = load.DsLeftUser;
                DsLeftUserChannel = load.DsLeftUserChannel;
                DsLeftUserDiscord = load.DsLeftUserDiscord;
                DsLeftUserDiscordText = load.DsLeftUserDiscordText;
                DsLeftUserKonsole = load.DsLeftUserKonsole;
                DsLeftUserKonsoleText = load.DsLeftUserKonsoleText;
                DsLeftUserTwitch = load.DsLeftUserTwitch;
                DsLeftUserTwitchText = load.DsLeftUserTwitchText;

                SDiscordAutoStart = load.SDiscordAutoStart;
                STwitchAutoStart = load.STwitchAutoStart;
                SBefehlSymbol = load.SBefehlSymbol;
                SAutoBan = load.SAutoBan;
                SEventTimer = load.SEventTimer;
                STwitchAutoMessage = load.STwitchAutoMessage;
                STwitchAutoBotBann = load.STwitchAutoBotBann;
                STwitchAutoBotDuration = load.STwitchAutoBotDuration;
                STwitchAutoBotWhiteList = load.STwitchAutoBotWhiteList;
                STwitchAutoBotAmount = load.STwitchAutoBotAmount;
                SDiscordOtherChannel = load.SDiscordOtherChannel;
                SDiscordOtherChannelChannel = load.SDiscordOtherChannelChannel;

                TeBitsReaction = load.TeBitsReaction;
                TeClipCreateAdmin = load.TeClipCreateAdmin;
                TeClipCreateBoardcast = load.TeClipCreateBoardcast;
                TeClipCreateChatText = load.TeClipCreateChatText;
                TeClipCreateCommand = load.TeClipCreateCommand;
                TeClipCreateFailText = load.TeClipCreateFailText;
                TeClipCreateUse = load.TeClipCreateUse;
                TeClipCreateVIP = load.TeClipCreateVIP;
                TeGoRaidTextAdmin = load.TeGoRaidTextAdmin;
                TeGoRaidTextBroadcaster = load.TeGoRaidTextBroadcaster;
                TeGoRaidTextVIP = load.TeGoRaidTextVIP;
                TeGoRaidTextChat = load.TeGoRaidTextChat;
                TeGoRaidTextCommand = load.TeGoRaidTextCommand;
                TeGoRaidTextFail = load.TeGoRaidTextFail;
                TeGoRaidTextUse = load.TeGoRaidTextUse;
                TeOnBeingHosted = load.TeOnBeingHosted;
                TeOnBeingHostedChannel = load.TeOnBeingHostedChannel;
                TeOnBeingHostedChat = load.TeOnBeingHostedChat;
                TeOnBeingHostedChatText = load.TeOnBeingHostedChatText;
                TeOnBeingHostedDiscord = load.TeOnBeingHostedDiscord;
                TeOnBeingHostedDiscordText = load.TeOnBeingHostedDiscordText;
                TeOnBeingHostedKonsole = load.TeOnBeingHostedKonsole;
                TeOnBeingHostedKonsoleText = load.TeOnBeingHostedKonsoleText;
                TeOnClipCreated = load.TeOnClipCreated;
                TeOnClipCreatedChannel = load.TeOnClipCreatedChannel;
                TeOnClipCreatedChat = load.TeOnClipCreatedChat;
                TeOnClipCreatedChatText = load.TeOnClipCreatedChatText;
                TeOnClipCreatedDiscord = load.TeOnClipCreatedDiscord;
                TeOnClipCreatedDiscordText = load.TeOnClipCreatedDiscordText;
                TeOnClipCreatedKonsole = load.TeOnClipCreatedKonsole;
                TeOnClipCreatedKonsoleText = load.TeOnClipCreatedKonsoleText;
                TeOnConnected = load.TeOnConnected;
                TeOnConnectedChannel = load.TeOnConnectedChannel;
                TeOnConnectedChat = load.TeOnConnectedChat;
                TeOnConnectedChatText = load.TeOnConnectedChatText;
                TeOnConnectedDiscord = load.TeOnConnectedDiscord;
                TeOnConnectedDiscordText = load.TeOnConnectedDiscordText;
                TeOnConnectedKonsole = load.TeOnConnectedKonsole;
                TeOnConnectedKonsoleText = load.TeOnConnectedKonsoleText;
                TeOnExistingUsersDetected = load.TeOnExistingUsersDetected;
                TeOnExistingUsersDetectedChannel = load.TeOnExistingUsersDetectedChannel;
                TeOnExistingUsersDetectedChat = load.TeOnExistingUsersDetectedChat;
                TeOnExistingUsersDetectedChatText = load.TeOnExistingUsersDetectedChatText;
                TeOnExistingUsersDetectedDiscord = load.TeOnExistingUsersDetectedDiscord;
                TeOnExistingUsersDetectedDiscordText = load.TeOnExistingUsersDetectedDiscordText;
                TeOnExistingUsersDetectedKonsole = load.TeOnExistingUsersDetectedKonsole;
                TeOnExistingUsersDetectedKonsoleText = load.TeOnExistingUsersDetectedKonsoleText;
                TeOnJoinedChannel = load.TeOnJoinedChannel;
                TeOnJoinedChannelChannel = load.TeOnJoinedChannelChannel;
                TeOnJoinedChannelChat = load.TeOnJoinedChannelChat;
                TeOnJoinedChannelChatText = load.TeOnJoinedChannelChatText;
                TeOnJoinedChannelDiscord = load.TeOnJoinedChannelDiscord;
                TeOnJoinedChannelDiscordText = load.TeOnJoinedChannelDiscordText;
                TeOnJoinedChannelKonsole = load.TeOnJoinedChannelKonsole;
                TeOnJoinedChannelKonsoleText = load.TeOnJoinedChannelKonsoleText;
                TeOnMessageReceived = load.TeOnMessageReceived;
                TeOnMessageReceivedChannel = load.TeOnMessageReceivedChannel;
                TeOnMessageReceivedChat = load.TeOnMessageReceivedChat;
                TeOnMessageReceivedChatText = load.TeOnMessageReceivedChatText;
                TeOnMessageReceivedDiscord = load.TeOnMessageReceivedDiscord;
                TeOnMessageReceivedDiscordText = load.TeOnMessageReceivedDiscordText;
                TeOnMessageReceivedKonsole = load.TeOnMessageReceivedKonsole;
                TeOnMessageReceivedKonsoleText = load.TeOnMessageReceivedKonsoleText;
                TeOnNewFollowersDetected = load.TeOnNewFollowersDetected;
                TeOnNewFollowersDetectedChannel = load.TeOnNewFollowersDetectedChannel;
                TeOnNewFollowersDetectedChat = load.TeOnNewFollowersDetectedChat;
                TeOnNewFollowersDetectedChatText = load.TeOnNewFollowersDetectedChatText;
                TeOnNewFollowersDetectedDiscord = load.TeOnNewFollowersDetectedDiscord;
                TeOnNewFollowersDetectedDiscordText = load.TeOnNewFollowersDetectedDiscordText;
                TeOnNewFollowersDetectedKonsole = load.TeOnNewFollowersDetectedKonsole;
                TeOnNewFollowersDetectedKonsoleText = load.TeOnNewFollowersDetectedKonsoleText;
                TeOnNewSubscriber = load.TeOnNewSubscriber;
                TeOnNewSubscriberChannel = load.TeOnNewSubscriberChannel;
                TeOnNewSubscriberChat = load.TeOnNewSubscriberChat;
                TeOnNewSubscriberChatText = load.TeOnNewSubscriberChatText;
                TeOnNewSubscriberDiscord = load.TeOnNewSubscriberDiscord;
                TeOnNewSubscriberDiscordText = load.TeOnNewSubscriberDiscordText;
                TeOnNewSubscriberKonsole = load.TeOnNewSubscriberKonsole;
                TeOnNewSubscriberKonsoleText = load.TeOnNewSubscriberKonsoleText;
                TeOnRaidGo = load.TeOnRaidGo;
                TeOnRaidGoChannel = load.TeOnRaidGoChannel;
                TeOnRaidGoChat = load.TeOnRaidGoChat;
                TeOnRaidGoChatText = load.TeOnRaidGoChatText;
                TeOnRaidGoDiscord = load.TeOnRaidGoDiscord;
                TeOnRaidGoDiscordText = load.TeOnRaidGoDiscordText;
                TeOnRaidGoKonsole = load.TeOnRaidGoKonsole;
                TeOnRaidGoKonsoleText = load.TeOnRaidGoKonsoleText;
                TeOnRaidNotification = load.TeOnRaidNotification;
                TeOnRaidNotificationChannel = load.TeOnRaidNotificationChannel;
                TeOnRaidNotificationChat = load.TeOnRaidNotificationChat;
                TeOnRaidNotificationChatText = load.TeOnRaidNotificationChatText;
                TeOnRaidNotificationDiscord = load.TeOnRaidNotificationDiscord;
                TeOnRaidNotificationDiscordText = load.TeOnRaidNotificationDiscordText;
                TeOnRaidNotificationKonsole = load.TeOnRaidNotificationKonsole;
                TeOnRaidNotificationKonsoleText = load.TeOnRaidNotificationKonsoleText;
                TeOnRewardRedeemed = load.TeOnRewardRedeemed;
                TeOnRewardRedeemedChannel = load.TeOnRewardRedeemedChannel;
                TeOnRewardRedeemedChat = load.TeOnRewardRedeemedChat;
                TeOnRewardRedeemedChatText = load.TeOnRewardRedeemedChatText;
                TeOnRewardRedeemedDiscord = load.TeOnRewardRedeemedDiscord;
                TeOnRewardRedeemedDiscordText = load.TeOnRewardRedeemedDiscordText;
                TeOnRewardRedeemedKonsole = load.TeOnRewardRedeemedKonsole;
                TeOnRewardRedeemedKonsoleText = load.TeOnRewardRedeemedKonsoleText;
                TeOnStreamOffline = load.TeOnStreamOffline;
                TeOnStreamOfflineChannel = load.TeOnStreamOfflineChannel;
                TeOnStreamOfflineChat = load.TeOnStreamOfflineChat;
                TeOnStreamOfflineChatText = load.TeOnStreamOfflineChatText;
                TeOnStreamOfflineDiscord = load.TeOnStreamOfflineDiscord;
                TeOnStreamOfflineDiscordText = load.TeOnStreamOfflineDiscordText;
                TeOnStreamOfflineKonsole = load.TeOnStreamOfflineKonsole;
                TeOnStreamOfflineKonsoleText = load.TeOnStreamOfflineKonsoleText;
                TeOnStreamOnline = load.TeOnStreamOnline;
                TeOnStreamOnlineChannel = load.TeOnStreamOnlineChannel;
                TeOnStreamOnlineChat = load.TeOnStreamOnlineChat;
                TeOnStreamOnlineChatText = load.TeOnStreamOnlineChatText;
                TeOnStreamOnlineDiscord = load.TeOnStreamOnlineDiscord;
                TeOnStreamOnlineDiscordText = load.TeOnStreamOnlineDiscordText;
                TeOnStreamOnlineKonsole = load.TeOnStreamOnlineKonsole;
                TeOnStreamOnlineKonsoleText = load.TeOnStreamOnlineKonsoleText;
                TeOnStreamUpdate = load.TeOnStreamUpdate;
                TeOnStreamUpdateChannel = load.TeOnStreamUpdateChannel;
                TeOnStreamUpdateChat = load.TeOnStreamUpdateChat;
                TeOnStreamUpdateChatText = load.TeOnStreamUpdateChatText;
                TeOnStreamUpdateDiscord = load.TeOnStreamUpdateDiscord;
                TeOnStreamUpdateDiscordText = load.TeOnStreamUpdateDiscordText;
                TeOnStreamUpdateKonsole = load.TeOnStreamUpdateKonsole;
                TeOnStreamUpdateKonsoleText = load.TeOnStreamUpdateKonsoleText;
                TeOnUserJoined = load.TeOnUserJoined;
                TeOnUserJoinedChannel = load.TeOnUserJoinedChannel;
                TeOnUserJoinedChat = load.TeOnUserJoinedChat;
                TeOnUserJoinedChatText = load.TeOnUserJoinedChatText;
                TeOnUserJoinedDiscord = load.TeOnUserJoinedDiscord;
                TeOnUserJoinedDiscordText = load.TeOnUserJoinedDiscordText;
                TeOnUserJoinedKonsole = load.TeOnUserJoinedKonsole;
                TeOnUserJoinedKonsoleText = load.TeOnUserJoinedKonsoleText;
                TeOnUserLeft = load.TeOnUserLeft;
                TeOnUserLeftChannel = load.TeOnUserLeftChannel;
                TeOnUserLeftChat = load.TeOnUserLeftChat;
                TeOnUserLeftChatText = load.TeOnUserLeftChatText;
                TeOnUserLeftDiscord = load.TeOnUserLeftDiscord;
                TeOnUserLeftDiscordText = load.TeOnUserLeftDiscordText;
                TeOnUserLeftKonsole = load.TeOnUserLeftKonsole;
                TeOnUserLeftKonsoleText = load.TeOnUserLeftKonsoleText;
                TeOnWhisperReceived = load.TeOnWhisperReceived;
                TeOnWhisperReceivedChannel = load.TeOnWhisperReceivedChannel;
                TeOnWhisperReceivedChat = load.TeOnWhisperReceivedChat;
                TeOnWhisperReceivedChatText = load.TeOnWhisperReceivedChatText;
                TeOnWhisperReceivedDiscord = load.TeOnWhisperReceivedDiscord;
                TeOnWhisperReceivedDiscordText = load.TeOnBeingHostedDiscordText;
                TeOnWhisperReceivedKonsole = load.TeOnWhisperReceivedKonsole;
                TeOnWhisperReceivedKonsoleText = load.TeOnWhisperReceivedKonsoleText;
                TeSOAdmin = load.TeSOAdmin;
                TeSOBoardcast = load.TeSOBoardcast;
                TeSOVIP = load.TeSOVIP;
                TeSOChatText = load.TeSOChatText;
                TeSOCommand = load.TeSOCommand;
                TeSOFailText = load.TeSOFailText;
                TeSOUse = load.TeSOUse;
                TeUpdateGameAdmin = load.TeUpdateGameAdmin;
                TeUpdateGameBoardcaster = load.TeUpdateGameBoardcaster;
                TeUpdateGameVIP = load.TeUpdateGameVIP;
                TeUpdateGameChatText = load.TeUpdateGameChatText;
                TeUpdateGameCommand = load.TeUpdateGameCommand;
                TeUpdateGameFailText = load.TeUpdateGameFailText;
                TeUpdateGameUse = load.TeUpdateGameUse;
                TeUpdateTitleAdmin = load.TeUpdateTitleAdmin;
                TeUpdateTitleBroadcaster = load.TeUpdateTitleBroadcaster;
                TeUpdateTitleVIP = load.TeUpdateTitleVIP;
                TeUpdateTitleChatText = load.TeUpdateTitleChatText;
                TeUpdateTitleCommand = load.TeUpdateTitleCommand;
                TeUpdateTitleFailText = load.TeUpdateTitleFailText;
                TeUpdateTitleUse = load.TeUpdateTitleUse;

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
            }
            else {
                setStandardSettings();
                Save(DefaultSavePath);
            }

        }
        public void setStandardSettings() {

            DSclientID = "";
            DSAccessToken = "";


            DsJoinUser = false;
            DsJoinUserChannel = new StringCollection();
            DsJoinUserDiscord = false;
            DsJoinUserDiscordText = "";
            DsJoinUserKonsole = false;
            DsJoinUserKonsoleText = "";
            DsJoinUserTwitch = false;
            DsJoinUserTwitchText = "";
            DsLeftUser = false;
            DsLeftUserChannel = new StringCollection();
            DsLeftUserDiscord = false;
            DsLeftUserDiscordText = "";
            DsLeftUserKonsole = false;
            DsLeftUserKonsoleText = "";
            DsLeftUserTwitch = false;
            DsLeftUserTwitchText = "";

            SDiscordAutoStart = false;
            STwitchAutoStart = false;
            SBefehlSymbol = "!";
            SAutoBan = false;
            SEventTimer = 30;
            STwitchAutoMessage = false;
            STwitchAutoBotBann = false;
            STwitchAutoBotDuration = 7;
            STwitchAutoBotWhiteList = new StringCollection();
            STwitchAutoBotAmount = 5;
            SDiscordOtherChannel = false;
            SDiscordOtherChannelChannel = 0;

            TeBitsReaction = false;
            TeClipCreateAdmin = true;
            TeClipCreateBoardcast = true;
            TeClipCreateChatText = "";
            TeClipCreateCommand = "";
            TeClipCreateFailText = "";
            TeClipCreateUse = false;
            TeClipCreateVIP = false;
            TeGoRaidTextAdmin = true;
            TeGoRaidTextBroadcaster = true;
            TeGoRaidTextVIP = false;
            TeGoRaidTextChat = "";
            TeGoRaidTextCommand = "";
            TeGoRaidTextFail = "";
            TeGoRaidTextUse = false;
            TeOnBeingHosted = false;
            TeOnBeingHostedChannel = new StringCollection();
            TeOnBeingHostedChat = false;
            TeOnBeingHostedChatText = "";
            TeOnBeingHostedDiscord = false;
            TeOnBeingHostedDiscordText = "";
            TeOnBeingHostedKonsole = false;
            TeOnBeingHostedKonsoleText = "";
            TeOnClipCreated = false;
            TeOnClipCreatedChannel = new StringCollection();
            TeOnClipCreatedChat = false;
            TeOnClipCreatedChatText = "";
            TeOnClipCreatedDiscord = false;
            TeOnClipCreatedDiscordText = "";
            TeOnClipCreatedKonsole = false;
            TeOnClipCreatedKonsoleText = "";
            TeOnConnected = false;
            TeOnConnectedChannel = new StringCollection();
            TeOnConnectedChat = false;
            TeOnConnectedChatText = "";
            TeOnConnectedDiscord = false;
            TeOnConnectedDiscordText = "";
            TeOnConnectedKonsole = false;
            TeOnConnectedKonsoleText = "";
            TeOnExistingUsersDetected = false;
            TeOnExistingUsersDetectedChannel = new StringCollection();
            TeOnExistingUsersDetectedChat = false;
            TeOnExistingUsersDetectedChatText = "";
            TeOnExistingUsersDetectedDiscord = false;
            TeOnExistingUsersDetectedDiscordText = "";
            TeOnExistingUsersDetectedKonsole = false;
            TeOnExistingUsersDetectedKonsoleText = "";
            TeOnJoinedChannel = false;
            TeOnJoinedChannelChannel = new StringCollection();
            TeOnJoinedChannelChat = false;
            TeOnJoinedChannelChatText = "";
            TeOnJoinedChannelDiscord = false;
            TeOnJoinedChannelDiscordText = "";
            TeOnJoinedChannelKonsole = false;
            TeOnJoinedChannelKonsoleText = "";
            TeOnMessageReceived = false;
            TeOnMessageReceivedChannel = new StringCollection();
            TeOnMessageReceivedChat = false;
            TeOnMessageReceivedChatText = "Die Reaktion auf einer Chat-Nachricht erfolgt über die Bot-Kommandos. Eine Einstellung hier ist, außer die Aktivierung, nicht notwendig";
            TeOnMessageReceivedDiscord = false;
            TeOnMessageReceivedDiscordText = "Auf eine Twitch Nachricht, sollte am Besten auch auf Twitch reagiert werden und nicht auf Discord";
            TeOnMessageReceivedKonsole = false;
            TeOnMessageReceivedKonsoleText = "Die Ausgabe würde bei vielen Nachrichten sehr schnell voll laufen, daher ist hier keine Einstellung möglich";
            TeOnNewFollowersDetected = false;
            TeOnNewFollowersDetectedChannel = new StringCollection();
            TeOnNewFollowersDetectedChat = false;
            TeOnNewFollowersDetectedChatText = "";
            TeOnNewFollowersDetectedDiscord = false;
            TeOnNewFollowersDetectedDiscordText = "";
            TeOnNewFollowersDetectedKonsole = false;
            TeOnNewFollowersDetectedKonsoleText = "";
            TeOnNewSubscriber = false;
            TeOnNewSubscriberChannel = new StringCollection();
            TeOnNewSubscriberChat = false;
            TeOnNewSubscriberChatText = "";
            TeOnNewSubscriberDiscord = false;
            TeOnNewSubscriberDiscordText = "";
            TeOnNewSubscriberKonsole = false;
            TeOnNewSubscriberKonsoleText = "";
            TeOnRaidGo = false;
            TeOnRaidGoChannel = new StringCollection();
            TeOnRaidGoChat = false;
            TeOnRaidGoChatText = "";
            TeOnRaidGoDiscord = false;
            TeOnRaidGoDiscordText = "";
            TeOnRaidGoKonsole = false;
            TeOnRaidGoKonsoleText = "";
            TeOnRaidNotification = false;
            TeOnRaidNotificationChannel = new StringCollection();
            TeOnRaidNotificationChat = false;
            TeOnRaidNotificationChatText = "";
            TeOnRaidNotificationDiscord = false;
            TeOnRaidNotificationDiscordText = "";
            TeOnRaidNotificationKonsole = false;
            TeOnRaidNotificationKonsoleText = "";
            TeOnRewardRedeemed = false;
            TeOnRewardRedeemedChannel = new StringCollection();
            TeOnRewardRedeemedChat = false;
            TeOnRewardRedeemedChatText = "";
            TeOnRewardRedeemedDiscord = false;
            TeOnRewardRedeemedDiscordText = "";
            TeOnRewardRedeemedKonsole = false;
            TeOnRewardRedeemedKonsoleText = "";
            TeOnStreamOffline = false;
            TeOnStreamOfflineChannel = new StringCollection();
            TeOnStreamOfflineChat = false;
            TeOnStreamOfflineChatText = "";
            TeOnStreamOfflineDiscord = false;
            TeOnStreamOfflineDiscordText = "";
            TeOnStreamOfflineKonsole = false;
            TeOnStreamOfflineKonsoleText = "";
            TeOnStreamOnline = false;
            TeOnStreamOnlineChannel = new StringCollection();
            TeOnStreamOnlineChat = false;
            TeOnStreamOnlineChatText = "";
            TeOnStreamOnlineDiscord = false;
            TeOnStreamOnlineDiscordText = "";
            TeOnStreamOnlineKonsole = false;
            TeOnStreamOnlineKonsoleText = "";
            TeOnStreamUpdate = false;
            TeOnStreamUpdateChannel = new StringCollection();
            TeOnStreamUpdateChat = false;
            TeOnStreamUpdateChatText = "";
            TeOnStreamUpdateDiscord = false;
            TeOnStreamUpdateDiscordText = "";
            TeOnStreamUpdateKonsole = false;
            TeOnStreamUpdateKonsoleText = "";
            TeOnUserJoined = false;
            TeOnUserJoinedChannel = new StringCollection();
            TeOnUserJoinedChat = false;
            TeOnUserJoinedChatText = "Das Event wird erzeugt, wenn sich der Bot an einem Channel verbindet. Diese Info hat nichts im Chat zu suchen";
            TeOnUserJoinedDiscord = false;
            TeOnUserJoinedDiscordText = "Das Event wird erzeugt, wenn sich der Bot an einem Channel verbindet. Diese Info hat nichts im Discord zu suchen";
            TeOnUserJoinedKonsole = false;
            TeOnUserJoinedKonsoleText = "";
            TeOnUserLeft = false;
            TeOnUserLeftChannel = new StringCollection();
            TeOnUserLeftChat = false;
            TeOnUserLeftChatText = "";
            TeOnUserLeftDiscord = false;
            TeOnUserLeftDiscordText = "";
            TeOnUserLeftKonsole = false;
            TeOnUserLeftKonsoleText = "";
            TeOnWhisperReceived = false;
            TeOnWhisperReceivedChannel = new StringCollection();
            TeOnWhisperReceivedChat = false;
            TeOnWhisperReceivedChatText = "Die Reaktion auf einer Chat-Nachricht erfolgt über die Bot-Kommandos. Eine Einstellung hier ist, außer die Aktivierung, nicht notwendig";
            TeOnWhisperReceivedDiscord = false;
            TeOnWhisperReceivedDiscordText = "Auf eine Twitch Nachricht, sollte am Besten auch auf Twitch reagiert werden und nicht auf Discord";
            TeOnWhisperReceivedKonsole = false;
            TeOnWhisperReceivedKonsoleText = "Die Ausgabe würde bei vielen Nachrichten sehr schnell voll laufen, daher ist hier keine Einstellung möglich";
            TeSOAdmin = true;
            TeSOBoardcast = true;
            TeSOVIP = true;
            TeSOChatText = "";
            TeSOCommand = "";
            TeSOFailText = "";
            TeSOUse = false;
            TeUpdateGameAdmin = true;
            TeUpdateGameBoardcaster = true;
            TeUpdateGameVIP = true;
            TeUpdateGameChatText = "";
            TeUpdateGameCommand = "";
            TeUpdateGameFailText = "";
            TeUpdateGameUse = false;
            TeUpdateTitleAdmin = true;
            TeUpdateTitleBroadcaster = true;
            TeUpdateTitleVIP = false;
            TeUpdateTitleChatText = "";
            TeUpdateTitleCommand = "";
            TeUpdateTitleFailText = "";
            TeUpdateTitleUse = false;

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
        }

        public void Update()
        {
            SettingsGroup load = JsonConvert.DeserializeObject<SettingsGroup>(File.ReadAllText(DefaultSavePath));
            setStandardSettings();
            if (load.DSclientID != null) { DSAccessToken = load.DSclientID; }
            if (load.DSAccessToken != null) { DSAccessToken = load.DSAccessToken; }

            DsJoinUser = load.DsJoinUser;
            DsJoinUserDiscord = load.DsJoinUserDiscord;
            DsJoinUserKonsole = load.DsJoinUserKonsole;
            DsJoinUserTwitch = load.DsJoinUserTwitch;
            if (load.DsJoinUserChannel != null) { DsJoinUserChannel = load.DsJoinUserChannel; }
            if (load.DsJoinUserDiscordText != null) { DsJoinUserDiscordText = load.DsJoinUserDiscordText; }
            if (load.DsJoinUserKonsoleText != null) { DsJoinUserKonsoleText = load.DsJoinUserKonsoleText; }
            if (load.DsJoinUserTwitchText!= null) { DsJoinUserTwitchText = load.DsJoinUserTwitchText; }
            DsLeftUser = load.DsLeftUser;
            DsLeftUserDiscord = load.DsLeftUserDiscord;
            DsLeftUserKonsole = load.DsLeftUserKonsole;
            DsLeftUserTwitch = load.DsLeftUserTwitch;
            if (load.DsLeftUserChannel != null) { DsLeftUserChannel = load.DsLeftUserChannel; }
            if (load.DsLeftUserDiscordText != null) { DsLeftUserDiscordText = load.DsLeftUserDiscordText; }
            if (load.DsLeftUserKonsoleText != null) { DsLeftUserKonsoleText = load.DsLeftUserKonsoleText; }
            if (load.DsLeftUserTwitchText != null) { DsLeftUserTwitchText = load.DsLeftUserTwitchText; }

            SDiscordAutoStart = load.SDiscordAutoStart;
            STwitchAutoStart = load.STwitchAutoStart;
            if (load.SBefehlSymbol != null) { SBefehlSymbol = load.SBefehlSymbol; }
            SAutoBan = load.SAutoBan;
            SEventTimer = load.SEventTimer;
            STwitchAutoMessage = load.STwitchAutoMessage;
            STwitchAutoBotBann = load.STwitchAutoBotBann;
            STwitchAutoBotDuration = load.STwitchAutoBotDuration;
            if (load.STwitchAutoBotWhiteList != null) { STwitchAutoBotWhiteList = load.STwitchAutoBotWhiteList; }
            STwitchAutoBotAmount = load.STwitchAutoBotAmount;
            SDiscordOtherChannel = load.SDiscordOtherChannel;
            SDiscordOtherChannelChannel = load.SDiscordOtherChannelChannel;

            TeBitsReaction = load.TeBitsReaction;
            TeClipCreateAdmin = load.TeClipCreateAdmin;
            TeClipCreateBoardcast = load.TeClipCreateBoardcast;
            TeClipCreateVIP = load.TeClipCreateVIP;
            if (load.TeClipCreateChatText != null) { TeClipCreateChatText = load.TeClipCreateChatText; }
            if (load.TeClipCreateCommand != null) { TeClipCreateCommand = load.TeClipCreateCommand; }
            if (load.TeClipCreateFailText != null) { TeClipCreateFailText = load.TeClipCreateFailText; }
            TeClipCreateUse = load.TeClipCreateUse;
            TeGoRaidTextAdmin = load.TeGoRaidTextAdmin;
            TeGoRaidTextBroadcaster = load.TeGoRaidTextBroadcaster;
            TeGoRaidTextVIP = load.TeGoRaidTextVIP;
            if (load.TeGoRaidTextChat != null) { TeGoRaidTextChat = load.TeGoRaidTextChat; }
            if (load.TeGoRaidTextCommand != null) { TeGoRaidTextCommand = load.TeGoRaidTextCommand; }
            if (load.TeGoRaidTextFail != null) { TeGoRaidTextFail = load.TeGoRaidTextFail; }
            TeGoRaidTextUse = load.TeGoRaidTextUse;
            TeOnBeingHosted = load.TeOnBeingHosted;
            if (load.TeOnBeingHostedChannel != null) { TeOnBeingHostedChannel = load.TeOnBeingHostedChannel; }
            TeOnBeingHostedChat = load.TeOnBeingHostedChat;
            if (load.TeOnBeingHostedChatText != null) { TeOnBeingHostedChatText = load.TeOnBeingHostedChatText; }
            TeOnBeingHostedDiscord = load.TeOnBeingHostedDiscord;
            if (load.TeOnBeingHostedDiscordText != null) { TeOnBeingHostedDiscordText = load.TeOnBeingHostedDiscordText; }
            TeOnBeingHostedKonsole = load.TeOnBeingHostedKonsole;
            if (load.TeOnBeingHostedKonsoleText != null) { TeOnBeingHostedKonsoleText = load.TeOnBeingHostedKonsoleText; }
            TeOnClipCreated = load.TeOnClipCreated;
            if (load.TeOnClipCreatedChannel != null) { TeOnClipCreatedChannel = load.TeOnClipCreatedChannel; }
            TeOnClipCreatedChat = load.TeOnClipCreatedChat;
            if (load.TeOnClipCreatedChatText != null) { TeOnClipCreatedChatText = load.TeOnClipCreatedChatText; }
            TeOnClipCreatedDiscord = load.TeOnClipCreatedDiscord;
            if (load.TeOnClipCreatedDiscordText != null) { TeOnClipCreatedDiscordText = load.TeOnClipCreatedDiscordText; }
            TeOnClipCreatedKonsole = load.TeOnClipCreatedKonsole;
            if (load.TeOnClipCreatedKonsoleText != null) { TeOnClipCreatedKonsoleText = load.TeOnClipCreatedKonsoleText; }
            TeOnConnected = load.TeOnConnected;
            if (load.TeOnConnectedChannel != null) { TeOnConnectedChannel = load.TeOnConnectedChannel; }
            TeOnConnectedChat = load.TeOnConnectedChat;
            if (load.TeOnConnectedChatText != null) { TeOnConnectedChatText = load.TeOnConnectedChatText; }
            TeOnConnectedDiscord = load.TeOnConnectedDiscord;
            if (load.TeOnConnectedDiscordText != null) { TeOnConnectedDiscordText = load.TeOnConnectedDiscordText; }
            TeOnConnectedKonsole = load.TeOnConnectedKonsole;
            if (load.TeOnConnectedKonsoleText != null) { TeOnConnectedKonsoleText = load.TeOnConnectedKonsoleText; }
            TeOnExistingUsersDetected = load.TeOnExistingUsersDetected;
            if (load.TeOnExistingUsersDetectedChannel != null) { TeOnExistingUsersDetectedChannel = load.TeOnExistingUsersDetectedChannel; }
            TeOnExistingUsersDetectedChat = load.TeOnExistingUsersDetectedChat;
            if (load.TeOnExistingUsersDetectedChatText != null) { TeOnExistingUsersDetectedChatText = load.TeOnExistingUsersDetectedChatText; }
            TeOnExistingUsersDetectedDiscord = load.TeOnExistingUsersDetectedDiscord;
            if (load.TeOnExistingUsersDetectedDiscordText != null) { TeOnExistingUsersDetectedDiscordText = load.TeOnExistingUsersDetectedDiscordText; }
            TeOnExistingUsersDetectedKonsole = load.TeOnExistingUsersDetectedKonsole;
            if (load.TeOnExistingUsersDetectedKonsoleText != null) { TeOnExistingUsersDetectedKonsoleText = load.TeOnExistingUsersDetectedKonsoleText; }
            TeOnJoinedChannel = load.TeOnJoinedChannel;
            if (load.TeOnJoinedChannelChannel != null) { TeOnJoinedChannelChannel = load.TeOnJoinedChannelChannel; }
            TeOnJoinedChannelChat = load.TeOnJoinedChannelChat;
            if (load.TeOnJoinedChannelChatText != null) { TeOnJoinedChannelChatText = load.TeOnJoinedChannelChatText; }
            TeOnJoinedChannelDiscord = load.TeOnJoinedChannelDiscord;
            if (load.TeOnJoinedChannelDiscordText != null) { TeOnJoinedChannelDiscordText = load.TeOnJoinedChannelDiscordText; }
            TeOnJoinedChannelKonsole = load.TeOnJoinedChannelKonsole;
            if (load.TeOnJoinedChannelKonsoleText != null) { TeOnJoinedChannelKonsoleText = load.TeOnJoinedChannelKonsoleText; }
            TeOnMessageReceived = load.TeOnMessageReceived;
            if (load.TeOnMessageReceivedChannel != null) { TeOnMessageReceivedChannel = load.TeOnMessageReceivedChannel; }
            TeOnMessageReceivedChat = load.TeOnMessageReceivedChat;
            if (load.TeOnMessageReceivedChatText != null) { TeOnMessageReceivedChatText = load.TeOnMessageReceivedChatText; }
            TeOnMessageReceivedDiscord = load.TeOnMessageReceivedDiscord;
            if (load.TeOnMessageReceivedDiscordText != null) { TeOnMessageReceivedDiscordText = load.TeOnMessageReceivedDiscordText; }
            TeOnMessageReceivedKonsole = load.TeOnMessageReceivedKonsole;
            if (load.TeOnMessageReceivedKonsoleText != null) { TeOnMessageReceivedKonsoleText = load.TeOnMessageReceivedKonsoleText; }
            TeOnNewFollowersDetected = load.TeOnNewFollowersDetected;
            if (load.TeOnNewFollowersDetectedChannel != null) { TeOnNewFollowersDetectedChannel = load.TeOnNewFollowersDetectedChannel; }
            TeOnNewFollowersDetectedChat = load.TeOnNewFollowersDetectedChat;
            if (load.TeOnNewFollowersDetectedChatText != null) { TeOnNewFollowersDetectedChatText = load.TeOnNewFollowersDetectedChatText; }
            TeOnNewFollowersDetectedDiscord = load.TeOnNewFollowersDetectedDiscord;
            if (load.TeOnNewFollowersDetectedDiscordText != null) { TeOnNewFollowersDetectedDiscordText = load.TeOnNewFollowersDetectedDiscordText; }
            TeOnNewFollowersDetectedKonsole = load.TeOnNewFollowersDetectedKonsole;
            if (load.TeOnNewFollowersDetectedKonsoleText != null) { TeOnNewFollowersDetectedKonsoleText = load.TeOnNewFollowersDetectedKonsoleText; }
            TeOnNewSubscriber = load.TeOnNewSubscriber;
            if (load.TeOnNewSubscriberChannel != null) { TeOnNewSubscriberChannel = load.TeOnNewSubscriberChannel; }
            TeOnNewSubscriberChat = load.TeOnNewSubscriberChat;
            if (load.TeOnNewSubscriberChatText != null) { TeOnNewSubscriberChatText = load.TeOnNewSubscriberChatText; }
            TeOnNewSubscriberDiscord = load.TeOnNewSubscriberDiscord;
            if (load.TeOnNewSubscriberDiscordText != null) { TeOnNewSubscriberDiscordText = load.TeOnNewSubscriberDiscordText; }
            TeOnNewSubscriberKonsole = load.TeOnNewSubscriberKonsole;
            if (load.TeOnNewSubscriberKonsoleText != null) { TeOnNewSubscriberKonsoleText = load.TeOnNewSubscriberKonsoleText; }
            TeOnRaidGo = load.TeOnRaidGo;
            if (load.TeOnRaidGoChannel != null) { TeOnRaidGoChannel = load.TeOnRaidGoChannel; }
            TeOnRaidGoChat = load.TeOnRaidGoChat;
            if (load.TeOnRaidGoChatText != null) { TeOnRaidGoChatText = load.TeOnRaidGoChatText; }
            TeOnRaidGoDiscord = load.TeOnRaidGoDiscord;
            if (load.TeOnRaidGoDiscordText != null) { TeOnRaidGoDiscordText = load.TeOnRaidGoDiscordText; }
            TeOnRaidGoKonsole = load.TeOnRaidGoKonsole;
            if (load.TeOnRaidGoKonsoleText != null) { TeOnRaidGoKonsoleText = load.TeOnRaidGoKonsoleText; }
            TeOnRaidNotification = load.TeOnRaidNotification;
            if (load.TeOnRaidNotificationChannel != null) { TeOnRaidNotificationChannel = load.TeOnRaidNotificationChannel; }
            TeOnRaidNotificationChat = load.TeOnRaidNotificationChat;
            if (load.TeOnRaidNotificationChatText != null) { TeOnRaidNotificationChatText = load.TeOnRaidNotificationChatText; }
            TeOnRaidNotificationDiscord = load.TeOnRaidNotificationDiscord;
            if (load.TeOnRaidNotificationDiscordText != null) { TeOnRaidNotificationDiscordText = load.TeOnRaidNotificationDiscordText; }
            TeOnRaidNotificationKonsole = load.TeOnRaidNotificationKonsole;
            if (load.TeOnRaidNotificationKonsoleText != null) { TeOnRaidNotificationKonsoleText = load.TeOnRaidNotificationKonsoleText; }
            TeOnRewardRedeemed = load.TeOnRewardRedeemed;
            if (load.TeOnRewardRedeemedChannel != null) { TeOnRewardRedeemedChannel = load.TeOnRewardRedeemedChannel; }
            TeOnRewardRedeemedChat = load.TeOnRewardRedeemedChat;
            if (load.TeOnRewardRedeemedChatText != null) { TeOnRewardRedeemedChatText = load.TeOnRewardRedeemedChatText; }
            TeOnRewardRedeemedDiscord = load.TeOnRewardRedeemedDiscord;
            if (load.TeOnRewardRedeemedDiscordText != null) { TeOnRewardRedeemedDiscordText = load.TeOnRewardRedeemedDiscordText; }
            TeOnRewardRedeemedKonsole = load.TeOnRewardRedeemedKonsole;
            if (load.TeOnRewardRedeemedKonsoleText != null) { TeOnRewardRedeemedKonsoleText = load.TeOnRewardRedeemedKonsoleText; }
            TeOnStreamOffline = load.TeOnStreamOffline;
            if (load.TeOnStreamOfflineChannel != null) { TeOnStreamOfflineChannel = load.TeOnStreamOfflineChannel; }
            TeOnStreamOfflineChat = load.TeOnStreamOfflineChat;
            if (load.TeOnStreamOfflineChatText != null) { TeOnStreamOfflineChatText = load.TeOnStreamOfflineChatText; }
            TeOnStreamOfflineDiscord = load.TeOnStreamOfflineDiscord;
            if (load.TeOnStreamOfflineDiscordText != null) { TeOnStreamOfflineDiscordText = load.TeOnStreamOfflineDiscordText; }
            TeOnStreamOfflineKonsole = load.TeOnStreamOfflineKonsole;
            if (load.TeOnStreamOfflineKonsoleText != null) { TeOnStreamOfflineKonsoleText = load.TeOnStreamOfflineKonsoleText; }
            TeOnStreamOnline = load.TeOnStreamOnline;
            if (load.TeOnStreamOnlineChannel != null) { TeOnStreamOnlineChannel = load.TeOnStreamOnlineChannel; }
            TeOnStreamOnlineChat = load.TeOnStreamOnlineChat;
            if (load.TeOnStreamOnlineChatText != null) { TeOnStreamOnlineChatText = load.TeOnStreamOnlineChatText; }
            TeOnStreamOnlineDiscord = load.TeOnStreamOnlineDiscord;
            if (load.TeOnStreamOnlineDiscordText != null) { TeOnStreamOnlineDiscordText = load.TeOnStreamOnlineDiscordText; }
            TeOnStreamOnlineKonsole = load.TeOnStreamOnlineKonsole;
            if (load.TeOnStreamOnlineKonsoleText != null) { TeOnStreamOnlineKonsoleText = load.TeOnStreamOnlineKonsoleText; }
            TeOnStreamUpdate = load.TeOnStreamUpdate;
            if (load.TeOnStreamUpdateChannel != null) { TeOnStreamUpdateChannel = load.TeOnStreamUpdateChannel; }
            TeOnStreamUpdateChat = load.TeOnStreamUpdateChat;
            if (load.TeOnStreamUpdateChatText != null) { TeOnStreamUpdateChatText = load.TeOnStreamUpdateChatText; }
            TeOnStreamUpdateDiscord = load.TeOnStreamUpdateDiscord;
            if (load.TeOnStreamUpdateDiscordText != null) { TeOnStreamUpdateDiscordText = load.TeOnStreamUpdateDiscordText; }
            TeOnStreamUpdateKonsole = load.TeOnStreamUpdateKonsole;
            if (load.TeOnStreamUpdateKonsoleText != null) { TeOnStreamUpdateKonsoleText = load.TeOnStreamUpdateKonsoleText; }
            TeOnUserJoined = load.TeOnUserJoined;
            if (load.TeOnUserJoinedChannel != null) { TeOnUserJoinedChannel = load.TeOnUserJoinedChannel; }
            TeOnUserJoinedChat = load.TeOnUserJoinedChat;
            if (load.TeOnUserJoinedChatText != null) { TeOnUserJoinedChatText = load.TeOnUserJoinedChatText; }
            TeOnUserJoinedDiscord = load.TeOnUserJoinedDiscord;
            if (load.TeOnUserJoinedDiscordText != null) { TeOnUserJoinedDiscordText = load.TeOnUserJoinedDiscordText; }
            TeOnUserJoinedKonsole = load.TeOnUserJoinedKonsole;
            if (load.TeOnUserJoinedKonsoleText != null) { TeOnUserJoinedKonsoleText = load.TeOnUserJoinedKonsoleText; }
            TeOnUserLeft = load.TeOnUserLeft;
            if (load.TeOnUserLeftChannel != null) { TeOnUserLeftChannel = load.TeOnUserLeftChannel; }
            TeOnUserLeftChat = load.TeOnUserLeftChat;
            if (load.TeOnUserLeftChatText != null) { TeOnUserLeftChatText = load.TeOnUserLeftChatText; }
            TeOnUserLeftDiscord = load.TeOnUserLeftDiscord;
            if (load.TeOnUserLeftDiscordText != null) { TeOnUserLeftDiscordText = load.TeOnUserLeftDiscordText; }
            TeOnUserLeftKonsole = load.TeOnUserLeftKonsole;
            if (load.TeOnUserLeftKonsoleText != null) { TeOnUserLeftKonsoleText = load.TeOnUserLeftKonsoleText; }
            TeOnWhisperReceived = load.TeOnWhisperReceived;
            if (load.TeOnWhisperReceivedChannel != null) { TeOnWhisperReceivedChannel = load.TeOnWhisperReceivedChannel; }
            TeOnWhisperReceivedChat = load.TeOnWhisperReceivedChat;
            if (load.TeOnWhisperReceivedChatText != null) { TeOnWhisperReceivedChatText = load.TeOnWhisperReceivedChatText; }
            TeOnWhisperReceivedDiscord = load.TeOnWhisperReceivedDiscord;
            if (load.TeOnWhisperReceivedDiscordText != null) { TeOnWhisperReceivedDiscordText = load.TeOnBeingHostedDiscordText; }
            TeOnWhisperReceivedKonsole = load.TeOnWhisperReceivedKonsole;
            if (load.TeOnWhisperReceivedKonsoleText != null) { TeOnWhisperReceivedKonsoleText = load.TeOnWhisperReceivedKonsoleText; }
            TeSOAdmin = load.TeSOAdmin;
            TeSOBoardcast = load.TeSOBoardcast;
            TeSOVIP = load.TeSOVIP;
            if (load.TeSOChatText != null) { TeSOChatText = load.TeSOChatText; }
            if (load.TeSOCommand != null) { TeSOCommand = load.TeSOCommand; }
            if (load.TeSOFailText != null) { TeSOFailText = load.TeSOFailText; }
            TeSOUse = load.TeSOUse;
            TeUpdateGameAdmin = load.TeUpdateGameAdmin;
            TeUpdateGameBoardcaster = load.TeUpdateGameBoardcaster;
            TeUpdateGameVIP = load.TeUpdateGameVIP;
            if (load.TeUpdateGameChatText != null) { TeUpdateGameChatText = load.TeUpdateGameChatText; }
            if (load.TeUpdateGameCommand != null) { TeUpdateGameCommand = load.TeUpdateGameCommand; }
            if (load.TeUpdateGameFailText != null) { TeUpdateGameFailText = load.TeUpdateGameFailText; }
            TeUpdateGameUse = load.TeUpdateGameUse;
            TeUpdateTitleAdmin = load.TeUpdateTitleAdmin;
            TeUpdateTitleBroadcaster = load.TeUpdateTitleBroadcaster;
            TeUpdateTitleVIP = load.TeUpdateTitleVIP;
            if (load.TeUpdateTitleChatText != null) { TeUpdateTitleChatText = load.TeUpdateTitleChatText; }
            if (load.TeUpdateTitleCommand != null) { TeUpdateTitleCommand = load.TeUpdateTitleCommand; }
            if (load.TeUpdateTitleFailText != null) { TeUpdateTitleFailText = load.TeUpdateTitleFailText; }
            TeUpdateTitleUse = load.TeUpdateTitleUse;

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

            Save(DefaultSavePath);
        }

        public void Save(String SpeicherPfad)
        {
            string InhaltJSON = JsonConvert.SerializeObject(this,Formatting.Indented);
            File.WriteAllText(SpeicherPfad, InhaltJSON);         
        }
        public void Save() {
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

        public void ImportSettingsGroup(String ApplicationPath, String Inhalt)
        {
            SettingsGroup Import = JsonConvert.DeserializeObject<SettingsGroup>(Inhalt);

            //discordScopes
            SettingsGroup.Instance.DSclientID = Import.DSclientID;
            SettingsGroup.Instance.DSAccessToken = Import.DSAccessToken;

            //discordEvents

            SettingsGroup.Instance.DsJoinUser = Import.DsJoinUser;
            SettingsGroup.Instance.DsJoinUserDiscord = Import.DsJoinUserDiscord;
            SettingsGroup.Instance.DsJoinUserChannel = Import.DsJoinUserChannel;
            SettingsGroup.Instance.DsJoinUserDiscordText = Import.DsJoinUserDiscordText;
            SettingsGroup.Instance.DsJoinUserKonsole = Import.DsJoinUserKonsole;
            SettingsGroup.Instance.DsJoinUserKonsoleText = Import.DsJoinUserKonsoleText;
            SettingsGroup.Instance.DsJoinUserTwitch = Import.DsJoinUserTwitch;
            SettingsGroup.Instance.DsJoinUserTwitchText = Import.DsJoinUserTwitchText;
            SettingsGroup.Instance.DsLeftUser = Import.DsLeftUser;
            SettingsGroup.Instance.DsLeftUserChannel = Import.DsLeftUserChannel;
            SettingsGroup.Instance.DsLeftUserDiscord = Import.DsLeftUserDiscord;
            SettingsGroup.Instance.DsLeftUserDiscordText = Import.DsLeftUserDiscordText;
            SettingsGroup.Instance.DsLeftUserKonsole = Import.DsLeftUserKonsole;
            SettingsGroup.Instance.DsLeftUserKonsoleText = Import.DsLeftUserKonsoleText;
            SettingsGroup.Instance.DsLeftUserTwitch = Import.DsLeftUserTwitch;
            SettingsGroup.Instance.DsLeftUserTwitchText = Import.DsLeftUserTwitchText;

            //settings

            SettingsGroup.Instance.SDiscordAutoStart = Import.SDiscordAutoStart;
            SettingsGroup.Instance.STwitchAutoStart = Import.STwitchAutoStart;
            SettingsGroup.Instance.SBefehlSymbol = Import.SBefehlSymbol;
            SettingsGroup.Instance.SAutoBan = Import.SAutoBan;
            SettingsGroup.Instance.SEventTimer = Import.SEventTimer;
            SettingsGroup.Instance.STwitchAutoMessage = Import.STwitchAutoMessage;
            SettingsGroup.Instance.STwitchAutoBotBann = Import.STwitchAutoBotBann;
            SettingsGroup.Instance.STwitchAutoBotDuration = Import.STwitchAutoBotDuration;
            SettingsGroup.Instance.STwitchAutoBotWhiteList = Import.STwitchAutoBotWhiteList;
            SettingsGroup.Instance.STwitchAutoBotAmount = Import.STwitchAutoBotAmount;
            SettingsGroup.Instance.SDiscordOtherChannel = Import.SDiscordOtherChannel;
            SettingsGroup.Instance.SDiscordOtherChannelChannel = Import.SDiscordOtherChannelChannel;

            //twitchEvent

            SettingsGroup.Instance.TeBitsReaction = Import.TeBitsReaction;
            SettingsGroup.Instance.TeClipCreateAdmin = Import.TeClipCreateAdmin;
            SettingsGroup.Instance.TeClipCreateBoardcast = Import.TeClipCreateBoardcast;
            SettingsGroup.Instance.TeClipCreateChatText = Import.TeClipCreateChatText;
            SettingsGroup.Instance.TeClipCreateCommand = Import.TeClipCreateCommand;
            SettingsGroup.Instance.TeClipCreateFailText = Import.TeClipCreateFailText;
            SettingsGroup.Instance.TeClipCreateUse = Import.TeClipCreateUse;
            SettingsGroup.Instance.TeClipCreateVIP = Import.TeClipCreateVIP;
            SettingsGroup.Instance.TeGoRaidTextAdmin = Import.TeGoRaidTextAdmin;
            SettingsGroup.Instance.TeGoRaidTextBroadcaster = Import.TeGoRaidTextBroadcaster;
            SettingsGroup.Instance.TeGoRaidTextVIP = Import.TeGoRaidTextVIP;
            SettingsGroup.Instance.TeGoRaidTextChat = Import.TeGoRaidTextChat;
            SettingsGroup.Instance.TeGoRaidTextCommand = Import.TeGoRaidTextCommand;
            SettingsGroup.Instance.TeGoRaidTextFail = Import.TeGoRaidTextFail;
            SettingsGroup.Instance.TeGoRaidTextUse = Import.TeGoRaidTextUse;
            SettingsGroup.Instance.TeOnBeingHosted = Import.TeOnBeingHosted;
            SettingsGroup.Instance.TeOnBeingHostedChannel = Import.TeOnBeingHostedChannel;
            SettingsGroup.Instance.TeOnBeingHostedChat = Import.TeOnBeingHostedChat;
            SettingsGroup.Instance.TeOnBeingHostedChatText = Import.TeOnBeingHostedChatText;
            SettingsGroup.Instance.TeOnBeingHostedDiscord = Import.TeOnBeingHostedDiscord;
            SettingsGroup.Instance.TeOnBeingHostedDiscordText = Import.TeOnBeingHostedDiscordText;
            SettingsGroup.Instance.TeOnBeingHostedKonsole = Import.TeOnBeingHostedKonsole;
            SettingsGroup.Instance.TeOnBeingHostedKonsoleText = Import.TeOnBeingHostedKonsoleText;
            SettingsGroup.Instance.TeOnClipCreated = Import.TeOnClipCreated;
            SettingsGroup.Instance.TeOnClipCreatedChannel = Import.TeOnClipCreatedChannel;
            SettingsGroup.Instance.TeOnClipCreatedChat = Import.TeOnClipCreatedChat;
            SettingsGroup.Instance.TeOnClipCreatedChatText = Import.TeOnClipCreatedChatText;
            SettingsGroup.Instance.TeOnClipCreatedDiscord = Import.TeOnClipCreatedDiscord;
            SettingsGroup.Instance.TeOnClipCreatedDiscordText = Import.TeOnClipCreatedDiscordText;
            SettingsGroup.Instance.TeOnClipCreatedKonsole = Import.TeOnClipCreatedKonsole;
            SettingsGroup.Instance.TeOnClipCreatedKonsoleText = Import.TeOnClipCreatedKonsoleText;
            SettingsGroup.Instance.TeOnConnected = Import.TeOnConnected;
            SettingsGroup.Instance.TeOnConnectedChannel = Import.TeOnConnectedChannel;
            SettingsGroup.Instance.TeOnConnectedChat = Import.TeOnConnectedChat;
            SettingsGroup.Instance.TeOnConnectedChatText = Import.TeOnConnectedChatText;
            SettingsGroup.Instance.TeOnConnectedDiscord = Import.TeOnConnectedDiscord;
            SettingsGroup.Instance.TeOnConnectedDiscordText = Import.TeOnConnectedDiscordText;
            SettingsGroup.Instance.TeOnConnectedKonsole = Import.TeOnConnectedKonsole;
            SettingsGroup.Instance.TeOnConnectedKonsoleText = Import.TeOnConnectedKonsoleText;
            SettingsGroup.Instance.TeOnExistingUsersDetected = Import.TeOnExistingUsersDetected;
            SettingsGroup.Instance.TeOnExistingUsersDetectedChannel = Import.TeOnExistingUsersDetectedChannel;
            SettingsGroup.Instance.TeOnExistingUsersDetectedChat = Import.TeOnExistingUsersDetectedChat;
            SettingsGroup.Instance.TeOnExistingUsersDetectedChatText = Import.TeOnExistingUsersDetectedChatText;
            SettingsGroup.Instance.TeOnExistingUsersDetectedDiscord = Import.TeOnExistingUsersDetectedDiscord;
            SettingsGroup.Instance.TeOnExistingUsersDetectedDiscordText = Import.TeOnExistingUsersDetectedDiscordText;
            SettingsGroup.Instance.TeOnExistingUsersDetectedKonsole = Import.TeOnExistingUsersDetectedKonsole;
            SettingsGroup.Instance.TeOnExistingUsersDetectedKonsoleText = Import.TeOnExistingUsersDetectedKonsoleText;
            SettingsGroup.Instance.TeOnJoinedChannel = Import.TeOnJoinedChannel;
            SettingsGroup.Instance.TeOnJoinedChannelChannel = Import.TeOnJoinedChannelChannel;
            SettingsGroup.Instance.TeOnJoinedChannelChat = Import.TeOnJoinedChannelChat;
            SettingsGroup.Instance.TeOnJoinedChannelChatText = Import.TeOnJoinedChannelChatText;
            SettingsGroup.Instance.TeOnJoinedChannelDiscord = Import.TeOnJoinedChannelDiscord;
            SettingsGroup.Instance.TeOnJoinedChannelDiscordText = Import.TeOnJoinedChannelDiscordText;
            SettingsGroup.Instance.TeOnJoinedChannelKonsole = Import.TeOnJoinedChannelKonsole;
            SettingsGroup.Instance.TeOnJoinedChannelKonsoleText = Import.TeOnJoinedChannelKonsoleText;
            SettingsGroup.Instance.TeOnMessageReceived = Import.TeOnMessageReceived;
            SettingsGroup.Instance.TeOnMessageReceivedChannel = Import.TeOnMessageReceivedChannel;
            SettingsGroup.Instance.TeOnMessageReceivedChat = Import.TeOnMessageReceivedChat;
            SettingsGroup.Instance.TeOnMessageReceivedChatText = Import.TeOnMessageReceivedChatText;
            SettingsGroup.Instance.TeOnMessageReceivedDiscord = Import.TeOnMessageReceivedDiscord;
            SettingsGroup.Instance.TeOnMessageReceivedDiscordText = Import.TeOnMessageReceivedDiscordText;
            SettingsGroup.Instance.TeOnMessageReceivedKonsole = Import.TeOnMessageReceivedKonsole;
            SettingsGroup.Instance.TeOnMessageReceivedKonsoleText = Import.TeOnMessageReceivedKonsoleText;
            SettingsGroup.Instance.TeOnNewFollowersDetected = Import.TeOnNewFollowersDetected;
            SettingsGroup.Instance.TeOnNewFollowersDetectedChannel = Import.TeOnNewFollowersDetectedChannel;
            SettingsGroup.Instance.TeOnNewFollowersDetectedChat = Import.TeOnNewFollowersDetectedChat;
            SettingsGroup.Instance.TeOnNewFollowersDetectedChatText = Import.TeOnNewFollowersDetectedChatText;
            SettingsGroup.Instance.TeOnNewFollowersDetectedDiscord = Import.TeOnNewFollowersDetectedDiscord;
            SettingsGroup.Instance.TeOnNewFollowersDetectedDiscordText = Import.TeOnNewFollowersDetectedDiscordText;
            SettingsGroup.Instance.TeOnNewFollowersDetectedKonsole = Import.TeOnNewFollowersDetectedKonsole;
            SettingsGroup.Instance.TeOnNewFollowersDetectedKonsoleText = Import.TeOnNewFollowersDetectedKonsoleText;
            SettingsGroup.Instance.TeOnNewSubscriber = Import.TeOnNewSubscriber;
            SettingsGroup.Instance.TeOnNewSubscriberChannel = Import.TeOnNewSubscriberChannel;
            SettingsGroup.Instance.TeOnNewSubscriberChat = Import.TeOnNewSubscriberChat;
            SettingsGroup.Instance.TeOnNewSubscriberChatText = Import.TeOnNewSubscriberChatText;
            SettingsGroup.Instance.TeOnNewSubscriberDiscord = Import.TeOnNewSubscriberDiscord;
            SettingsGroup.Instance.TeOnNewSubscriberDiscordText = Import.TeOnNewSubscriberDiscordText;
            SettingsGroup.Instance.TeOnNewSubscriberKonsole = Import.TeOnNewSubscriberKonsole;
            SettingsGroup.Instance.TeOnNewSubscriberKonsoleText = Import.TeOnNewSubscriberKonsoleText;
            SettingsGroup.Instance.TeOnRaidGo = Import.TeOnRaidGo;
            SettingsGroup.Instance.TeOnRaidGoChannel = Import.TeOnRaidGoChannel;
            SettingsGroup.Instance.TeOnRaidGoChat = Import.TeOnRaidGoChat;
            SettingsGroup.Instance.TeOnRaidGoChatText = Import.TeOnRaidGoChatText;
            SettingsGroup.Instance.TeOnRaidGoDiscord = Import.TeOnRaidGoDiscord;
            SettingsGroup.Instance.TeOnRaidGoDiscordText = Import.TeOnRaidGoDiscordText;
            SettingsGroup.Instance.TeOnRaidGoKonsole = Import.TeOnRaidGoKonsole;
            SettingsGroup.Instance.TeOnRaidGoKonsoleText = Import.TeOnRaidGoKonsoleText;
            SettingsGroup.Instance.TeOnRaidNotification = Import.TeOnRaidNotification;
            SettingsGroup.Instance.TeOnRaidNotificationChannel = Import.TeOnRaidNotificationChannel;
            SettingsGroup.Instance.TeOnRaidNotificationChat = Import.TeOnRaidNotificationChat;
            SettingsGroup.Instance.TeOnRaidNotificationChatText = Import.TeOnRaidNotificationChatText;
            SettingsGroup.Instance.TeOnRaidNotificationDiscord = Import.TeOnRaidNotificationDiscord;
            SettingsGroup.Instance.TeOnRaidNotificationDiscordText = Import.TeOnRaidNotificationDiscordText;
            SettingsGroup.Instance.TeOnRaidNotificationKonsole = Import.TeOnRaidNotificationKonsole;
            SettingsGroup.Instance.TeOnRaidNotificationKonsoleText = Import.TeOnRaidNotificationKonsoleText;
            SettingsGroup.Instance.TeOnRewardRedeemed = Import.TeOnRewardRedeemed;
            SettingsGroup.Instance.TeOnRewardRedeemedChannel = Import.TeOnRewardRedeemedChannel;
            SettingsGroup.Instance.TeOnRewardRedeemedChat = Import.TeOnRewardRedeemedChat;
            SettingsGroup.Instance.TeOnRewardRedeemedChatText = Import.TeOnRewardRedeemedChatText;
            SettingsGroup.Instance.TeOnRewardRedeemedDiscord = Import.TeOnRewardRedeemedDiscord;
            SettingsGroup.Instance.TeOnRewardRedeemedDiscordText = Import.TeOnRewardRedeemedDiscordText;
            SettingsGroup.Instance.TeOnRewardRedeemedKonsole = Import.TeOnRewardRedeemedKonsole;
            SettingsGroup.Instance.TeOnRewardRedeemedKonsoleText = Import.TeOnRewardRedeemedKonsoleText;
            SettingsGroup.Instance.TeOnStreamOffline = Import.TeOnStreamOffline;
            SettingsGroup.Instance.TeOnStreamOfflineChannel = Import.TeOnStreamOfflineChannel;
            SettingsGroup.Instance.TeOnStreamOfflineChat = Import.TeOnStreamOfflineChat;
            SettingsGroup.Instance.TeOnStreamOfflineChatText = Import.TeOnStreamOfflineChatText;
            SettingsGroup.Instance.TeOnStreamOfflineDiscord = Import.TeOnStreamOfflineDiscord;
            SettingsGroup.Instance.TeOnStreamOfflineDiscordText = Import.TeOnStreamOfflineDiscordText;
            SettingsGroup.Instance.TeOnStreamOfflineKonsole = Import.TeOnStreamOfflineKonsole;
            SettingsGroup.Instance.TeOnStreamOfflineKonsoleText = Import.TeOnStreamOfflineKonsoleText;
            SettingsGroup.Instance.TeOnStreamOnline = Import.TeOnStreamOnline;
            SettingsGroup.Instance.TeOnStreamOnlineChannel = Import.TeOnStreamOnlineChannel;
            SettingsGroup.Instance.TeOnStreamOnlineChat = Import.TeOnStreamOnlineChat;
            SettingsGroup.Instance.TeOnStreamOnlineChatText = Import.TeOnStreamOnlineChatText;
            SettingsGroup.Instance.TeOnStreamOnlineDiscord = Import.TeOnStreamOnlineDiscord;
            SettingsGroup.Instance.TeOnStreamOnlineDiscordText = Import.TeOnStreamOnlineDiscordText;
            SettingsGroup.Instance.TeOnStreamOnlineKonsole = Import.TeOnStreamOnlineKonsole;
            SettingsGroup.Instance.TeOnStreamOnlineKonsoleText = Import.TeOnStreamOnlineKonsoleText;
            SettingsGroup.Instance.TeOnStreamUpdate = Import.TeOnStreamUpdate;
            SettingsGroup.Instance.TeOnStreamUpdateChannel = Import.TeOnStreamUpdateChannel;
            SettingsGroup.Instance.TeOnStreamUpdateChat = Import.TeOnStreamUpdateChat;
            SettingsGroup.Instance.TeOnStreamUpdateChatText = Import.TeOnStreamUpdateChatText;
            SettingsGroup.Instance.TeOnStreamUpdateDiscord = Import.TeOnStreamUpdateDiscord;
            SettingsGroup.Instance.TeOnStreamUpdateDiscordText = Import.TeOnStreamUpdateDiscordText;
            SettingsGroup.Instance.TeOnStreamUpdateKonsole = Import.TeOnStreamUpdateKonsole;
            SettingsGroup.Instance.TeOnStreamUpdateKonsoleText = Import.TeOnStreamUpdateKonsoleText;
            SettingsGroup.Instance.TeOnUserJoined = Import.TeOnUserJoined;
            SettingsGroup.Instance.TeOnUserJoinedChannel = Import.TeOnUserJoinedChannel;
            SettingsGroup.Instance.TeOnUserJoinedChat = Import.TeOnUserJoinedChat;
            SettingsGroup.Instance.TeOnUserJoinedChatText = Import.TeOnUserJoinedChatText;
            SettingsGroup.Instance.TeOnUserJoinedDiscord = Import.TeOnUserJoinedDiscord;
            SettingsGroup.Instance.TeOnUserJoinedDiscordText = Import.TeOnUserJoinedDiscordText;
            SettingsGroup.Instance.TeOnUserJoinedKonsole = Import.TeOnUserJoinedKonsole;
            SettingsGroup.Instance.TeOnUserJoinedKonsoleText = Import.TeOnUserJoinedKonsoleText;
            SettingsGroup.Instance.TeOnUserLeft = Import.TeOnUserLeft;
            SettingsGroup.Instance.TeOnUserLeftChannel = Import.TeOnUserLeftChannel;
            SettingsGroup.Instance.TeOnUserLeftChat = Import.TeOnUserLeftChat;
            SettingsGroup.Instance.TeOnUserLeftChatText = Import.TeOnUserLeftChatText;
            SettingsGroup.Instance.TeOnUserLeftDiscord = Import.TeOnUserLeftDiscord;
            SettingsGroup.Instance.TeOnUserLeftDiscordText = Import.TeOnUserLeftDiscordText;
            SettingsGroup.Instance.TeOnUserLeftKonsole = Import.TeOnUserLeftKonsole;
            SettingsGroup.Instance.TeOnUserLeftKonsoleText = Import.TeOnUserLeftKonsoleText;
            SettingsGroup.Instance.TeOnWhisperReceived = Import.TeOnWhisperReceived;
            SettingsGroup.Instance.TeOnWhisperReceivedChannel = Import.TeOnWhisperReceivedChannel;
            SettingsGroup.Instance.TeOnWhisperReceivedChat = Import.TeOnWhisperReceivedChat;
            SettingsGroup.Instance.TeOnWhisperReceivedChatText = Import.TeOnWhisperReceivedChatText;
            SettingsGroup.Instance.TeOnWhisperReceivedDiscord = Import.TeOnWhisperReceivedDiscord;
            SettingsGroup.Instance.TeOnBeingHostedDiscordText = Import.TeOnWhisperReceivedDiscordText;
            SettingsGroup.Instance.TeOnWhisperReceivedKonsole = Import.TeOnWhisperReceivedKonsole;
            SettingsGroup.Instance.TeOnWhisperReceivedKonsoleText = Import.TeOnWhisperReceivedKonsoleText;
            SettingsGroup.Instance.TeSOAdmin = Import.TeSOAdmin;
            SettingsGroup.Instance.TeSOBoardcast = Import.TeSOBoardcast;
            SettingsGroup.Instance.TeSOVIP = Import.TeSOVIP;
            SettingsGroup.Instance.TeSOChatText = Import.TeSOChatText;
            SettingsGroup.Instance.TeSOCommand = Import.TeSOCommand;
            SettingsGroup.Instance.TeSOFailText = Import.TeSOFailText;
            SettingsGroup.Instance.TeSOUse = Import.TeSOUse;
            SettingsGroup.Instance.TeUpdateGameAdmin = Import.TeUpdateGameAdmin;
            SettingsGroup.Instance.TeUpdateGameBoardcaster = Import.TeUpdateGameBoardcaster;
            SettingsGroup.Instance.TeUpdateGameVIP = Import.TeUpdateGameVIP;
            SettingsGroup.Instance.TeUpdateGameChatText = Import.TeUpdateGameChatText;
            SettingsGroup.Instance.TeUpdateGameCommand = Import.TeUpdateGameCommand;
            SettingsGroup.Instance.TeUpdateGameFailText = Import.TeUpdateGameFailText;
            SettingsGroup.Instance.TeUpdateGameUse = Import.TeUpdateGameUse;
            SettingsGroup.Instance.TeUpdateTitleAdmin = Import.TeUpdateTitleAdmin;
            SettingsGroup.Instance.TeUpdateTitleBroadcaster = Import.TeUpdateTitleBroadcaster;
            SettingsGroup.Instance.TeUpdateTitleVIP = Import.TeUpdateTitleVIP;
            SettingsGroup.Instance.TeUpdateTitleChatText = Import.TeUpdateTitleChatText;
            SettingsGroup.Instance.TeUpdateTitleCommand = Import.TeUpdateTitleCommand;
            SettingsGroup.Instance.TeUpdateTitleFailText = Import.TeUpdateTitleFailText;
            SettingsGroup.Instance.TeUpdateTitleUse = Import.TeUpdateTitleUse;

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

            Save(DefaultSavePath);

            File.WriteAllText(ApplicationPath + "Befehl.json", JsonConvert.SerializeObject(InhaltBefehl, Formatting.Indented));
            File.WriteAllText(ApplicationPath + "Befehl-Twitch.json", JsonConvert.SerializeObject(InhaltBefehlTwitch, Formatting.Indented));
            File.WriteAllText(ApplicationPath + "BitListe.json", JsonConvert.SerializeObject(InhaltBitListe, Formatting.Indented));
            File.WriteAllText(ApplicationPath + "DiscordServer.json", JsonConvert.SerializeObject(InhaltDiscordServer, Formatting.Indented));
            File.WriteAllText(ApplicationPath + "JoinedUsers.json", JsonConvert.SerializeObject(InhaltJoinedUsers, Formatting.Indented));
            File.WriteAllText(ApplicationPath + "List-Befehl.json", JsonConvert.SerializeObject(InhaltListBefehl, Formatting.Indented));
            File.WriteAllText(ApplicationPath + "Zeit-Befehl.json", JsonConvert.SerializeObject(InhaltZeitBefehl, Formatting.Indented));
            File.WriteAllText(ApplicationPath + "SkillListe.json", JsonConvert.SerializeObject(InhaltSkillList, Formatting.Indented));
        }
    }
}
