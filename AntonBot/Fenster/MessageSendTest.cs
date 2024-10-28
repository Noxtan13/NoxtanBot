using AntonBot.PlatformAPI;
using AntonBot.PlatformAPI.PlattformTypen;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AntonBot.Fenster
{
    public partial class MessageSendTest : Form
    {
        private TwitchFunction Twitch;
        private DiscordFunction Discord;
        private List<DiscordGilde> DiscordListe;
        public MessageSendTest(TwitchFunction twitch, DiscordFunction discord)
        {
            InitializeComponent();

            Twitch = twitch;
            Discord = discord;

            //Wenn die Plattformen nicht aktiv sind, werden diese zur Auswahl nicht angeboten
            if (!Twitch.getActive())
            {
                rdbTwitch.Enabled = false;
                rdbDiscord.Checked = true;
            }
            if (!Discord.getActive())
            {
                rdbDiscord.Enabled = false;
                rdbTwitch.Checked = true;
            }
            if (!rdbDiscord.Enabled && !rdbTwitch.Enabled)
            {
                cbbKanal.Enabled = false;
                txtMessage.Enabled = false;
                btnSenden.Enabled = false;
            }
        }

        private void rdbTwitch_CheckedChanged(object sender, EventArgs e)
        {
            Change();
        }

        private void rdbDiscord_CheckedChanged(object sender, EventArgs e)
        {
            Change();
        }

        private void Change()
        {
            cbbKanal.Items.Clear();
            cbbKanal.Text = "";
            if (rdbTwitch.Checked && Twitch.getActive())
            {
                cbbKanal.Items.Add(Twitch.getStandardChannel());
            }
            else if (rdbDiscord.Checked && Discord.getActive())
            {
                String Path = Application.StartupPath + System.IO.Path.DirectorySeparatorChar + "DiscordServer.json";

                if (File.Exists(Path))
                {
                    String InhaltJSON = File.ReadAllText(Path);
                    try
                    {
                        DiscordListe = JsonConvert.DeserializeObject<List<DiscordGilde>>(InhaltJSON);
                    }
                    catch (Exception Fehler)
                    {
                        MessageBox.Show("Die Discord-Liste beinhaltet nicht die Einstellungen oder ist beschädigt \n Weitere Informationen: \n\n" + Fehler.InnerException.ToString(), "Fehler beim Einlesen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DiscordListe = new List<DiscordGilde>();
                    }
                }
                else
                {
                    MessageBox.Show("Es existiert keine DiscordServer.json. Diese Datei wird erzeugt, wenn sich der Bot an Discord anmeldet oder die Discord-Einstellungen aufgerufen werden.", "Keine Discord-Server", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DiscordListe = new List<DiscordGilde>();
                }

                foreach (var server in DiscordListe)
                {
                    foreach (var channel in server.Channels)
                    {
                        cbbKanal.Items.Add(server.Name + " --- " + channel.Name);
                    }
                }

            }
        }

        private void btnSenden_Click(object sender, EventArgs e)
        {
            bool Validierung = true;
            if (txtMessage.Text.Equals(""))
            {
                Validierung = false;
                MessageBox.Show("Es ist keine Nachricht hinterlegt." + Environment.NewLine + "Eine leere Nachricht kann nicht gesendet werden.", "Leere Nachricht", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cbbKanal.Text.Equals(""))
            {
                Validierung = false;
                MessageBox.Show("Es ist kein Kanal hinterlegt." + Environment.NewLine + "Ein Kanal muss als Ziel angegeben werden.", "Leerer Kanal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            if (Validierung)
            {
                if (chkPlattformMessage.Checked)
                {
                    if (rdbTwitch.Checked)
                    {
                        PlattformMessage.Instance.SaveMessage(txtMessage.Text, cbbKanal.Text);
                    }
                    else if (rdbDiscord.Checked)
                    {
                        String Channel = cbbKanal.Text;
                        String Pattern = @"([\S]*) --- ([\S]*)";
                        ulong ChannelID = 0;

                        Regex r = new Regex(Pattern, RegexOptions.IgnoreCase);
                        Match m = r.Match(Channel);

                        foreach (var server in DiscordListe)
                        {
                            if (m.Groups[1].Value.Equals(server.Name))
                            {
                                foreach (var channel in server.Channels)
                                {
                                    if (m.Groups[2].Value.Equals(channel.Name))
                                    {
                                        ChannelID = channel.ID;
                                    }
                                }
                            }
                        }

                        if (ChannelID != 0)
                        {
                            PlattformMessage.Instance.SaveMessage(txtMessage.Text, "Discord", ChannelID);
                        }
                        else
                        {
                            MessageBox.Show("Es konnte der Kanal nicht gefunden werden." + Environment.NewLine + "Ein Kanal muss als Ziel angegeben werden.", "Nicht gefundener Kanal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
                else
                {
                    if (rdbTwitch.Checked)
                    {
                        Twitch.SendMessage(txtMessage.Text, cbbKanal.Text);
                    }
                    else if (rdbDiscord.Checked)
                    {
                        String Channel = cbbKanal.Text;
                        String Pattern = @"([\S]*) --- ([\S]*)";
                        ulong ChannelID = 0;

                        Regex r = new Regex(Pattern, RegexOptions.IgnoreCase);
                        Match m = r.Match(Channel);

                        foreach (var server in DiscordListe)
                        {
                            if (m.Groups[1].Value.Equals(server.Name))
                            {
                                foreach (var channel in server.Channels)
                                {
                                    if (m.Groups[2].Value.Equals(channel.Name))
                                    {
                                        ChannelID = channel.ID;
                                    }
                                }
                            }
                        }

                        if (ChannelID != 0)
                        {
                            Discord.SendMessage(ChannelID, txtMessage.Text);
                        }
                        else
                        {
                            MessageBox.Show("Es konnte der Kanal nicht gefunden werden." + Environment.NewLine + "Ein Kanal muss als Ziel angegeben werden.", "Nicht gefundener Kanal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
