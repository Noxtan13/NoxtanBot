﻿using AntonBot.PlatformAPI;
using AntonBot.PlatformAPI.ListenTypen;
using Discord;
using Discord.Commands;
using Discord.Rest;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntonBot
{
    public class DiscordFunction : Bot_Verwalter
    {

        private DiscordSocketClient client;
        private CommandService commands = new CommandService();
        private IServiceProvider services;

        public bool SongsRequest = false;

        private bool FirstStart;

        private DateTime dtLetzerAusfall;
        private TimeSpan dtAusfallDauer;
        private bool bAusfall = false;

        public List<OwnEmote> Emotelist;

        private List<EmbededMessageReactionRole> ReactionRoleList;
        private String PathReactionRoleList = Application.StartupPath + Path.DirectorySeparatorChar + "ReactionRole.json";
        public async Task RunBotAsync()
        {
            //Fehlermeldung bei leeren Token 
            /*
             A supplied token was invalid.
Exception: 
A token cannot be null, empty, or contain only whitespace.
             */

            Plattform = "Discord";

            if (SettingsGroup.Instance.DSAccessToken == null || SettingsGroup.Instance.DSAccessToken == "")
            {
                KonsolenAusgabe("Es ist kein Token verfügbar!" + Environment.NewLine + "Bitte Einrichtung durchführen");
            }
            else
            {
                var cfg = new DiscordSocketConfig();
                //Das sind die Infos, die ich von Discord abrufen darf. MessageContent ist notwendig, damit der Inhalt der Nachricht gelesen werden kann
                cfg.GatewayIntents = GatewayIntents.AllUnprivileged | GatewayIntents.GuildMembers | GatewayIntents.GuildBans | GatewayIntents.MessageContent;


                client = new DiscordSocketClient(cfg);

                bool Loginerfolgreich = false;
                bool Starterfolgreich = false;

                services = new ServiceCollection()
                    .AddSingleton(client)
                    .AddSingleton(commands)
                    .BuildServiceProvider();


                Loginerfolgreich = await Login();
                Starterfolgreich = await Start();


                if (Loginerfolgreich == true && Starterfolgreich == true)
                {
                    Active = true;
                    Restart = false;
                    DiscordWriteGuilds();
                    LoadReactionRole();
                }
                else
                {
                    Active = false;
                    KonsolenAusgabe("Login nicht erfolgreich. Stoppe Discord");
                    await StopBotAsync();
                }


            }
        }
        private async Task<bool> Start() {

            try
            {
                KonsolenAusgabe("StartAsync wird ausgeführt");
                await client.StartAsync();
                return true;
            }
            catch (Exception e)
            {
                KonsolenAusgabe("Die Funktion StartAsync() konnte nicht durchgeführt werden." + Environment.NewLine + "Exception-Message: " + e.Message + Environment.NewLine + "InnerException: " + e.InnerException);
                return false;
            }
        }

        private async Task<bool> Login() {
            if (!FirstStart)
            {
                client.Log += Client_Log;
                await RegisterCommandsAsync();

                FirstStart = true;
            }

            try
            {
                KonsolenAusgabe("LoginSync wird ausgeführt");
                await client.LoginAsync(TokenType.Bot, SettingsGroup.Instance.DSAccessToken);
                return true;
            }
            catch (Exception e)
            {
                if (e.Message.Contains("No such host is known"))
                {
                    KonsolenAusgabe("Login konnte nicht durchgeführt werden, da keine Verbindung ins Internet besteht:" + Environment.NewLine + "Exception-Message: " + e.Message + Environment.NewLine + "InnerException: " + e.InnerException);
                    Restart = true;
                }
                else if (e.InnerException.Message.Contains("Der Remotename konnte nicht aufgelöst werden: \'discord.com\'"))
                {
                    KonsolenAusgabe("Login konnte nicht durchgeführt werden, da keine Verbindung ins Internet besteht:" + Environment.NewLine + "Exception-Message: " + e.Message + Environment.NewLine + "InnerException: " + e.InnerException);
                    Restart = true;
                }
                else
                {
                    KonsolenAusgabe("Die Funktion LoginAsync() konnte nicht durchgeführt werden." + Environment.NewLine + "Exception-Message: " + e.Message + Environment.NewLine + "InnerException: " + e.InnerException);
                }
                return false;
            }

        }

        public void DiscordWriteGuilds()
        {
            System.Collections.Generic.List<PlatformAPI.DiscordGilde> discordGilde = new System.Collections.Generic.List<PlatformAPI.DiscordGilde>();
            if (client != null)
            {
                foreach (var server in client.Guilds)
                {

                    discordGilde.Add(new PlatformAPI.DiscordGilde());
                    discordGilde[discordGilde.Count - 1].ID = server.Id;
                    discordGilde[discordGilde.Count - 1].OwnerID = server.OwnerId;
                    discordGilde[discordGilde.Count - 1].Name = server.Name;

                    discordGilde[discordGilde.Count - 1].Channels = new System.Collections.Generic.List<PlatformAPI.DiscordServerChannel>();
                    discordGilde[discordGilde.Count - 1].Users = new System.Collections.Generic.List<PlatformAPI.DiscordServerUser>();
                    discordGilde[discordGilde.Count - 1].Emotes = new System.Collections.Generic.List<PlatformAPI.DiscordServerEmotes>();
                    discordGilde[discordGilde.Count - 1].Roles = new System.Collections.Generic.List<PlatformAPI.DiscordServerRoles>();


                    foreach (var Kanal in server.TextChannels)
                    {
                        discordGilde[discordGilde.Count - 1].Channels.Add(new PlatformAPI.DiscordServerChannel(Kanal.Id, Kanal.Name));
                    }

                    foreach (var User in server.Users)
                    {
                        discordGilde[discordGilde.Count - 1].Users.Add(new PlatformAPI.DiscordServerUser(User.Id, User.Username, User.IsBot));
                    }

                    foreach (var Emote in server.Emotes)
                    {
                        discordGilde[discordGilde.Count - 1].Emotes.Add(new PlatformAPI.DiscordServerEmotes(Emote.Id, Emote.Name));
                    }

                    foreach (var Role in server.Roles)
                    {
                        discordGilde[discordGilde.Count - 1].Roles.Add(new PlatformAPI.DiscordServerRoles(Role.Id, Role.Name));
                    }

                    string InhaltJSON = Newtonsoft.Json.JsonConvert.SerializeObject(discordGilde, Newtonsoft.Json.Formatting.Indented);
                    String Path = SettingsGroup.Instance.StandardPfad + "DiscordServer.json";

                    System.IO.File.WriteAllText(Path, InhaltJSON);
                }
            }
            else
            {
                KonsolenAusgabe("Client war noch nicht gestartet. DiscordWriteGuilds() wird nicht ausgeführt");
            }
        }
        public async Task StopBotAsync()
        {

            if (client != null)
            {
                Active = false;
                await client.LogoutAsync();
                await client.StopAsync();
            }
            else
            {
                KonsolenAusgabe("Der Bot wurde nicht vollständig geladen. Warte, bis die Anmeldung richtig erfolgt, bevor der Logout gestartet wird.");
            }
        }

        public String getClientStatus()
        {
            if (client != null)
            {
                return client.LoginState.ToString();
            }
            else
            {
                return "NULL";
            }

        }

        private Task Client_Log(LogMessage arg)
        {
            //Console.WriteLine(arg);
            /*
            Exception:
            WebSocket connection was closed
            Source: Gateway

            Disconnecting 
            DISCORD - 21:15:51.3996018
            Connected
            Resumed previous session
            */


            string Text = arg.Message;
            if (arg.Exception != null)
            {
                Text += Environment.NewLine + "Exception: " + Environment.NewLine + arg.Exception.Message + Environment.NewLine + "Source: " + arg.Source;
            }
            KonsolenAusgabe(Text);

            if (arg.Message != null)
            {
                if (arg.Message.Equals("Disconnected"))
                {
                    dtLetzerAusfall = DateTime.Now;
                    bAusfall = true;
                }
                if (arg.Message.Equals("Connected") && bAusfall)
                {
                    bAusfall = false;
                    dtAusfallDauer = DateTime.Now - dtLetzerAusfall;
                    KonsolenAusgabe("Dauer Ausfall in Sekunden: ", dtAusfallDauer.TotalSeconds);
                }
                else
                {
                    //Einträge werden sonst doppelt ausgegeben, wenn dies nicht kommentiert ist
                    //KonsolenAusgabe(arg.Message);
                }
            }

            return Task.CompletedTask;
        }



        public async Task RegisterCommandsAsync()
        {
            client.MessageReceived += HandleCommandAsync;
            client.UserJoined += Client_UserJoined;
            client.UserLeft += Client_UserLeft1;
            //client.UserVoiceStateUpdated += Client_UserVoiceStateUpdated;
            client.ReactionAdded += Client_ReactionAdded;
            client.ReactionRemoved += Client_ReactionRemoved;
            await commands.AddModulesAsync(Assembly.GetEntryAssembly(), services);
        }

        private async Task Client_ReactionRemoved(Cacheable<IUserMessage, ulong> arg1, Cacheable<IMessageChannel, ulong> arg2, SocketReaction arg3)
        {
            LoadReactionRole();//Aktuelle Rollen zur Sicherheit laden

            var Message = (RestUserMessage)await arg2.Value.GetMessageAsync(arg3.MessageId);
            OwnEmote ownEmote = new OwnEmote(arg3.Emote.Name);

            foreach (var ReaktionRole in ReactionRoleList)
            {
                if (Message.Channel.Id == ReaktionRole.ChannelID)
                {
                    if (Message.Id == ReaktionRole.MessageID)
                    {
                        foreach (var Entry in ReaktionRole.RollenEinträge)
                        {
                            if (Entry.Emote.Name == ownEmote.Name)
                            {
                                var role = client.GetGuild(ReaktionRole.ServerID).GetRole(Entry.RoleID);
                                var GuildUser = client.GetGuild(ReaktionRole.ServerID).GetUser(arg3.UserId);

                                await GuildUser.RemoveRoleAsync(role);
                                KonsolenAusgabe("Rolle " + role.Name + " dem Benutzer " + GuildUser.DisplayName + " entfernt.");
                            }
                        }
                    }
                }
            }

        }

        private async Task Client_ReactionAdded(Cacheable<IUserMessage, ulong> arg1, Cacheable<IMessageChannel, ulong> arg2, SocketReaction arg3)
        {
            LoadReactionRole();//Aktuelle Rollen zur Sicherheit laden

            var Message = (RestUserMessage)await arg2.Value.GetMessageAsync(arg3.MessageId);
            OwnEmote ownEmote = new OwnEmote(arg3.Emote.Name);


            foreach (var ReaktionRole in ReactionRoleList)
            {
                if (Message.Channel.Id == ReaktionRole.ChannelID)
                {
                    if (Message.Id == ReaktionRole.MessageID)
                    {
                        foreach (var Entry in ReaktionRole.RollenEinträge)
                        {
                            if (Entry.Emote.Name == ownEmote.Name)
                            {
                                var role = client.GetGuild(ReaktionRole.ServerID).GetRole(Entry.RoleID);
                                var GuildUser = client.GetGuild(ReaktionRole.ServerID).GetUser(arg3.UserId);

                                await GuildUser.AddRoleAsync(role);
                                KonsolenAusgabe("Rolle " + role.Name + " dem Benutzer " + GuildUser.DisplayName + " hinzugefügt.");
                            }
                        }
                    }
                }
            }

        }

        private async Task Client_UserLeft1(SocketGuild arg1, SocketUser arg2)
        {
            if (SettingsGroup.Instance.DsLeftUser.Use)
            {
                if (SettingsGroup.Instance.DsLeftUser.Discord)
                {
                    string Text = SettingsGroup.Instance.DsLeftUser.DiscordText;
                    Text = OnUserLeftReplace(Text, arg1, arg2);

                    foreach (var channels in arg1.Channels)
                    {
                        foreach (var item in SettingsGroup.Instance.DsJoinUser.Channel)
                        {
                            if (Convert.ToUInt64(item) == channels.Id)
                            {
                                await SendMessage(Convert.ToUInt64(item), Text);
                            }
                        }
                    }
                }
                if (SettingsGroup.Instance.DsLeftUser.Konsole)
                {
                    string Text = SettingsGroup.Instance.DsLeftUser.KonsoleText;

                    Text = OnUserLeftReplace(Text, arg1, arg2);

                    KonsolenAusgabe(Text);
                }
                if (SettingsGroup.Instance.DsLeftUser.Twitch)
                {
                    string Text = SettingsGroup.Instance.DsLeftUser.TwitchText;
                    Text = OnUserLeftReplace(Text, arg1, arg2);

                    SendOtherChannel(Text, "Twitch");

                }

            }

            //arg1 ist der betroffene Server
            //arg2 ist der User
        }

        private String OnUserLeftReplace(String Text, SocketGuild arg1, SocketUser arg2)
        {

            Text = Text.Replace("°GuildName", arg1.Name);
            Text = Text.Replace("UserName°", arg2.Username);
            return Text;
        }

        private async Task Client_UserJoined(SocketGuildUser arg)
        {
            if (SettingsGroup.Instance.DsJoinUser.Use)
            {
                if (SettingsGroup.Instance.DsJoinUser.Discord)
                {
                    string Text = SettingsGroup.Instance.DsJoinUser.DiscordText;
                    Text = OnUserJoinReplace(Text, arg);

                    foreach (var channels in arg.Guild.Channels)
                    {
                        foreach (var item in SettingsGroup.Instance.DsJoinUser.Channel)
                        {
                            if (Convert.ToUInt64(item) == channels.Id)
                            {
                                await SendMessage(Convert.ToUInt64(item), Text);
                            }
                        }
                    }
                }
                if (SettingsGroup.Instance.DsJoinUser.Konsole)
                {
                    string Text = SettingsGroup.Instance.DsJoinUser.KonsoleText;

                    Text = OnUserJoinReplace(Text, arg);

                    KonsolenAusgabe(Text);
                }
                if (SettingsGroup.Instance.DsJoinUser.Twitch)
                {
                    string Text = SettingsGroup.Instance.DsJoinUser.TwitchText;
                    Text = OnUserJoinReplace(Text, arg);

                    SendOtherChannel(Text, "Twitch");

                }

            }
        }

        private String OnUserJoinReplace(String Text, SocketGuildUser arg)
        {
            Text = Text.Replace("°Username", arg.Username);
            Text = Text.Replace("°DisplayName", arg.DisplayName);
            Text = Text.Replace("°Guild", arg.Guild.Name);
            Text = Text.Replace("°JoinedAt", arg.JoinedAt.Value.DateTime.ToString());
            Text = Text.Replace("°Nickname", arg.Nickname); ;
            return Text;
        }

        private async Task HandleCommandAsync(SocketMessage RecievedMessage)
        {

            await ReactToCommand(RecievedMessage);

        }

        public async Task ReactToCommand(SocketMessage RecievedMessage)
        {
            string Nachricht = CheckBefehlAllg(RecievedMessage.Content, RecievedMessage.Author.Username);
            
            //Dieser Block sollte eig. vor den CheckBefehlAllg kommen
            if (Nachricht == null && SettingsGroup.Instance.bZitateUse)
            {
                //Aktuell nur 0, da ich Stand jetzt keine weiter Möglichkeiten zur überprüfung habe der Rollen in Discord
                Nachricht = CheckZitate(RecievedMessage.Content, RecievedMessage.Author.Username, 0, "Discord");          
            }

            if (Nachricht == null)
            {
                //Hier muss noch die Überprüfung der Adminrechte erfolgen
                Nachricht = CheckListBefehl(RecievedMessage.Content, RecievedMessage.Author.Username, false, "Discord");
            }
            //Nur wenn die Nachricht einen Inhalt hat, wird diese gesendet, 
            if (Nachricht != null)
            {
                if (RecievedMessage.Channel.Name.Contains("@"))
                {
                    //Nachricht als DM
                    await SendMessageDM(RecievedMessage.Channel.Id, Nachricht, RecievedMessage.Channel.Name);
                }
                else
                {
                    //Nachricht in einem Channel
                    await SendMessage(RecievedMessage.Channel.Id, Nachricht);
                }
            }
        }
        public async Task SendMessage(ulong ChannelID, String Nachricht)
        {
            if (Active)
            {
                try
                {
                    if (Nachricht != null || Nachricht != "")
                    {
                        KonsolenAusgabe(Nachricht + " wird an Dicsord gesendet");
                        await ((ISocketMessageChannel)client.GetChannel(ChannelID)).SendMessageAsync(Nachricht);
                    }
                }
                catch (Exception e)
                {
                    KonsolenAusgabe("SendMessage() konnte nicht durchgeführt werden." + Environment.NewLine + "Nachricht: " + Environment.NewLine + Nachricht + Environment.NewLine + "Channel-ID: " + Environment.NewLine + ChannelID + Environment.NewLine + "Excpetion-Message: " + Environment.NewLine + e.Message + Environment.NewLine + "InnerException: " + Environment.NewLine + e.InnerException);
                    throw;
                }
            }
            else
            {
                KonsolenAusgabe("Der Bot ist nicht aktiv oder angemeldet. Eine Nachricht zu senden ist nicht möglich.");
            }
        }
        public async Task SendMessageDM(ulong ChannelID, String Nachricht, string Name)
        {
            if (Active)
            {
                try
                {
                    if (Nachricht != null || Nachricht != "")
                    {
                        KonsolenAusgabe(Nachricht + " wird an Dicsord per DM an " + Name + " gesendet");
                        await (client.GetDMChannelAsync(ChannelID).Result).SendMessageAsync(Nachricht);
                    }
                }
                catch (Exception e)
                {
                    KonsolenAusgabe("SendMessageDM() konnte nicht durchgeführt an " + Name + " werden." + Environment.NewLine + "Nachricht: " + Environment.NewLine + Nachricht + Environment.NewLine + "Channel-ID: " + Environment.NewLine + ChannelID + Environment.NewLine + "Excpetion-Message: " + Environment.NewLine + e.Message + Environment.NewLine + "InnerException: " + Environment.NewLine + e.InnerException);
                    throw;
                }
            }
            else
            {
                KonsolenAusgabe("Der Bot ist nicht aktiv oder angemeldet. Eine Nachricht zu senden ist nicht möglich.");
            }
        }

        public async Task<ulong> SendEmbededMessage(ulong ChannelID, Embed Message)
        {


            var Result = await ((ISocketMessageChannel)client.GetChannel(ChannelID)).SendMessageAsync("", embed: Message);

            return Result.Id;
        }

        public async Task<ulong> SendReactionRoleMessage(EmbededMessageReactionRole embededMessageReactionRole)
        {
            var Message = new EmbedBuilder();
            embededMessageReactionRole = ValidateReactionMessage(embededMessageReactionRole);
            Message.WithAuthor(client.CurrentUser)
                .WithFooter(embededMessageReactionRole.MessageFooter)
                .WithColor(Color.Gold)
                .WithTitle(embededMessageReactionRole.MessageTitle)
                .WithDescription(embededMessageReactionRole.MessageText)
                .WithCurrentTimestamp();

            return await SendEmbededMessage(embededMessageReactionRole.ChannelID, Message.Build());

        }

        public async Task EditEmbededMessage(EmbededMessageReactionRole Message)
        {

            var MessageBuild = new EmbedBuilder();
            Message = ValidateReactionMessage(Message);

            MessageBuild.WithAuthor(client.CurrentUser)
                .WithFooter(Message.MessageFooter)
                .WithColor(Color.Gold)
                .WithTitle(Message.MessageTitle)
                .WithDescription(Message.MessageText)
                .WithCurrentTimestamp();

            await ((ISocketMessageChannel)client.GetChannel(Message.ChannelID)).ModifyMessageAsync(Message.MessageID, msg => msg.Embed = MessageBuild.Build());
        }

        private EmbededMessageReactionRole ValidateReactionMessage(EmbededMessageReactionRole Message)
        {
            //Leere Felder werden mit Dummywerten gefüllt

            if (Message.MessageFooter == null)
            {
                Message.MessageFooter = "<No Footer>";
            }
            if (Message.MessageTitle == null)
            {
                Message.MessageTitle = "<No Titel>";
            }
            if (Message.MessageText == null)
            {
                Message.MessageText = "<No Text>";
            }
            return Message;
        }

        public async Task DeleteEmbedeMessage(EmbededMessageReactionRole Message)
        {
            await ((ISocketMessageChannel)client.GetChannel(Message.ChannelID)).DeleteMessageAsync(Message.MessageID);
        }

        public void LoadAllCommands()
        {
            //Funktion zum Laden der Befehle in die Liste
            AllCommands.Clear();
            CommandListFill(BefehlListe);
            //CommandListFill(lTwitchBefehlListe); Hier werden die Discordeigenen Befehle dann geladen
        }

        public void LoadAllEmotes()
        {
            if (Active)
            {
                Emotelist = new List<OwnEmote>();
                if (client.Guilds.Count > 0)
                {
                    foreach (var Server in client.Guilds)
                    {
                        if (Server.Emotes.Count > 0)
                        {
                            foreach (var Emote in Server.Emotes)
                            {
                                OwnEmote Eintrag = new OwnEmote();
                                Eintrag.ServerID = Server.Id;
                                Eintrag.ServerName = Server.Name;
                                Eintrag.ID = Emote.Id;
                                Eintrag.Name = Emote.Name;
                                Eintrag.URL = Emote.Url;

                                Emotelist.Add(Eintrag);
                            }
                        }
                    }
                }
            }
        }

        private void LoadReactionRole()
        {
            if (File.Exists(PathReactionRoleList))
            {
                String InhaltJSON = File.ReadAllText(PathReactionRoleList);
                try
                {
                    ReactionRoleList = JsonConvert.DeserializeObject<List<EmbededMessageReactionRole>>(InhaltJSON);
                }
                catch (Exception Fehler)
                {
                    MessageBox.Show("Die ReactionRole-Liste beinhaltet nicht die Einstellungen oder ist beschädigt \n Weitere Informationen: \n\n" + Fehler.InnerException.ToString(), "Fehler beim Einlesen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ReactionRoleList = new List<EmbededMessageReactionRole>();
                }
            }
        }

        public List<OwnEmote> getEmotelist()
        {

            if (Emotelist == null)
            {
                Emotelist = new List<OwnEmote>();
                LoadAllEmotes();
            }

            return Emotelist;
        }
    }
}
