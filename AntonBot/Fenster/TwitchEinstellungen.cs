﻿using AntonBot.PlatformAPI;
using AntonBot.PlatformAPI.ListenTypen;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;



namespace AntonBot.Fenster
{
    public partial class TwitchEinstellungen : Form
    {
        string sClientID;


        bool bAccessTokenChange;
        string sAlterToken="";
        string sAlterTokenPubSub="";

        int iVariablenInhaltEvent;
        int iVariablenInhaltTextFeld;

        int iEventIndex;
        //0 = nichts
        //1 = ChatText
        //2 = KonsoleText
        //3 = DiscordText
        bool bÄnderung;
        bool bÄnderungAusIndex;
        int iAltIndex;


        List<BitElement> BitListe = new List<BitElement>();
        BitElement BitAuswahl = new BitElement();
        String ListPattern = "#(\\d*)\\s*(\\d*)-(\\d*)";
        String ListPatternEinzel = "#(\\d*)\\s*(\\d*)";
        int BitsID = 0;


        public TwitchEinstellungen()
        {
            InitializeComponent();
        }

        private void TwitchEinstellungen_Load(object sender, EventArgs e)
        {
            sClientID = SettingsGroup.Instance.TsclientID;
            txtStandardChannel.Text = SettingsGroup.Instance.TsStandardChannel;

            //sqal26jpskl64j5dc2pso1a44u0qmw
            //linkLabel1.Text = "https://dev.twitch.tv/console/apps/" + sClientID;


            chk_chat_edit.Checked = SettingsGroup.Instance.Tschat_edit;
            chk_chat_read.Checked = SettingsGroup.Instance.Tschat_read;
            chk_whispers_edit.Checked = SettingsGroup.Instance.Tswhispers_edit;
            chk_whispers_read.Checked = SettingsGroup.Instance.Tswhispers_read;
            chk_channel_moderate.Checked = SettingsGroup.Instance.Tschannel_moderate;
            chk_bits_read.Checked = SettingsGroup.Instance.Tsbits_read;
            chk_channel_manage_redemptions.Checked = SettingsGroup.Instance.Tschannel_manage_redemptions;
            chk_channel_read_redemptions.Checked = SettingsGroup.Instance.Tschannel_read_redemptions;
            chk_user_edit.Checked = SettingsGroup.Instance.Tsuser_edit;

            //chk_user_read.Checked = Properties.TwitchScopes.Default.user_read;
            chk_clips_edit.Checked = SettingsGroup.Instance.Tsclips_edit;

            chk_PubSubToken.Checked = SettingsGroup.Instance.TsPubSubZusatz;

            chk_user_edit_broadcast.Checked = SettingsGroup.Instance.Tsuser_edit_broadcast;
            chk_channel_editor.Checked = SettingsGroup.Instance.Tschannel_editor;


            txtClientID.Text = sClientID;

            lblTokenCurrent.Text = "Aktueller Token: " + SettingsGroup.Instance.TsAccessToken;
            lblTokenPubSub.Text = "Aktueller PubSub-Token: " + SettingsGroup.Instance.TsAccessTokenPubSub;

            chkBits.Checked = SettingsGroup.Instance.TeBitsReaction;
            chkSkillUse.Checked = SettingsGroup.Instance.SkillUse;
            LoadBits();
            LoadSkills();

            CheckEmpyList();

            //Änderung des Index, damit der erste Wert auch eingelesen wird (onStreamOnline) und nicht manuell geklickt werden muss
            LstEvents.SelectedIndex = 1;
            LstEvents.SelectedIndex = 0;
        }

        private void TwitchEinstellungen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bAccessTokenChange)
            {
                if (chk_PubSubToken.Checked && txtTokenPubSub.Text.Equals(""))
                {
                    //PupSub-Token wird deaktiviert, wenn das Feld leer ist.
                    chk_PubSubToken.Checked = false;
                    SettingsGroup.Instance.TsPubSubZusatz= false;
                    MessageBox.Show("Der Token für den PupSub ist leer. Ein zusätzlicher Token wird nicht verwendet", "leere Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (MessageBox.Show("Der Access Token oder Channel wurde geändert. Sollen die Daten übernommen werden?" + Environment.NewLine + "Der Bot muss sich bei Twitch neu anmelden", "Geänderte Daten", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Diese Werte werden erst beim Beenden übernommen
                    Scopeübernahme();
                    SettingsGroup.Instance.TsStandardChannel = txtStandardChannel.Text;
                    SettingsGroup.Instance.TsclientID = txtClientID.Text;
                    SettingsGroup.Instance.Save();
                }
                else {
                    SettingsGroup.Instance.TsAccessToken = sAlterToken;
                    SettingsGroup.Instance.TsAccessTokenPubSub = sAlterTokenPubSub;
                }
                
            }
        }

        #region TwitchEinstellungen
        private void button1_Click(object sender, EventArgs e)
        {
            GetPersimission(txtClientID.Text, AbfrageAufbauen());
        }

        public void GetPersimission(string ClientID, string Abfrage)
        {

            // Creates a redirect URI using an available port on the loopback address.


            // Creates an HttpListener to listen for requests on that redirect URI.
            if (ClientID.Equals(""))
            {
                MessageBox.Show("Es ist keine ClientID für den Bot eingetragen" + Environment.NewLine + "Ohne ClientID kann keine Abfrage erfolgen.", "ClientID eingeben", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                string redirectURI = "https://twitchapps.com/tokengen/";

                // Creates the OAuth 2.0 authorization request.
                string authorizationRequest = string.Format("https://id.twitch.tv/oauth2/authorize?response_type=token&client_id={0}&redirect_uri={1}&scope={2}&force_verify=true",
                    ClientID,
                    redirectURI,
                    Abfrage);

                // Opens request in the browser.
                System.Diagnostics.Process.Start(authorizationRequest);
        
            }

        }

        private void CheckEmpyList() {
            if (SettingsGroup.Instance.TeOnStreamOnlineChannel == null) {
                SettingsGroup.Instance.TeOnStreamOnlineChannel = new System.Collections.Specialized.StringCollection();
            }
            if (SettingsGroup.Instance.TeOnStreamOfflineChannel == null)
            {
                SettingsGroup.Instance.TeOnStreamOfflineChannel = new System.Collections.Specialized.StringCollection();
            }
            if (SettingsGroup.Instance.TeOnStreamUpdateChannel == null)
            {
                SettingsGroup.Instance.TeOnStreamUpdateChannel = new System.Collections.Specialized.StringCollection();
            }
            if (SettingsGroup.Instance.TeOnNewFollowersDetectedChannel == null)
            {
                SettingsGroup.Instance.TeOnNewFollowersDetectedChannel = new System.Collections.Specialized.StringCollection();
            }
            if (SettingsGroup.Instance.TeOnMessageReceivedChannel == null)
            {
                SettingsGroup.Instance.TeOnMessageReceivedChannel = new System.Collections.Specialized.StringCollection();
            }
            if (SettingsGroup.Instance.TeOnWhisperReceivedChannel == null)
            {
                SettingsGroup.Instance.TeOnWhisperReceivedChannel = new System.Collections.Specialized.StringCollection();
            }
            if (SettingsGroup.Instance.TeOnNewSubscriberChannel == null)
            {
                SettingsGroup.Instance.TeOnNewSubscriberChannel = new System.Collections.Specialized.StringCollection();
            }
            if (SettingsGroup.Instance.TeOnConnected.Channel == null)
            {
                SettingsGroup.Instance.TeOnConnected.Channel = new System.Collections.Specialized.StringCollection();
            }
            if (SettingsGroup.Instance.TeOnBeingHosted.Channel == null)
            {
                SettingsGroup.Instance.TeOnBeingHosted.Channel = new System.Collections.Specialized.StringCollection();
            }
            if (SettingsGroup.Instance.TeOnRaidNotificationChannel == null)
            {
                SettingsGroup.Instance.TeOnRaidNotificationChannel = new System.Collections.Specialized.StringCollection();
            }
            if (SettingsGroup.Instance.TeOnJoinedChannel.Channel == null)
            {
                SettingsGroup.Instance.TeOnJoinedChannel.Channel = new System.Collections.Specialized.StringCollection();
            }
            if (SettingsGroup.Instance.TeOnUserJoinedChannel == null)
            {
                SettingsGroup.Instance.TeOnUserJoinedChannel = new System.Collections.Specialized.StringCollection();
            }
            if (SettingsGroup.Instance.TeOnExistingUsersDetected.Channel == null)
            {
                SettingsGroup.Instance.TeOnExistingUsersDetected.Channel = new System.Collections.Specialized.StringCollection();
            }
            if (SettingsGroup.Instance.TeOnRewardRedeemedChannel == null)
            {
                SettingsGroup.Instance.TeOnRewardRedeemedChannel = new System.Collections.Specialized.StringCollection();
            }
            if (SettingsGroup.Instance.TeOnRaidGoChannel == null)
            {
                SettingsGroup.Instance.TeOnRaidGoChannel = new System.Collections.Specialized.StringCollection();
            }
            if (SettingsGroup.Instance.TeOnUserLeftChannel == null)
            {
                SettingsGroup.Instance.TeOnUserLeftChannel = new System.Collections.Specialized.StringCollection();
            }
            if (SettingsGroup.Instance.TeOnClipCreated.Channel == null)
            {
                SettingsGroup.Instance.TeOnClipCreated.Channel = new System.Collections.Specialized.StringCollection();
            }

            SettingsGroup.Instance.Save();

        }


        public string AbfrageAufbauen() {
            string erzeugteAnfrage="";
            bool ersteAnfrage = false;

            if (chk_chat_edit.Checked)
            {
                if (ersteAnfrage) { erzeugteAnfrage += "+"; } else { ersteAnfrage = true; };
                erzeugteAnfrage += "chat:edit";
            }
            if (chk_chat_read.Checked)
            {
                if (ersteAnfrage) { erzeugteAnfrage += "+"; } else { ersteAnfrage = true; };
                erzeugteAnfrage += "chat:read";;
            }
            if (chk_whispers_edit.Checked)
            {
                if (ersteAnfrage) { erzeugteAnfrage += "+"; } else { ersteAnfrage = true; };
                erzeugteAnfrage += "whispers:edit";
            }
            if (chk_whispers_read.Checked)
            {
                if (ersteAnfrage) { erzeugteAnfrage += "+"; } else { ersteAnfrage = true; };
                erzeugteAnfrage += "whispers:read";
            }
            if (chk_channel_moderate.Checked)
            {
                if (ersteAnfrage) { erzeugteAnfrage += "+"; } else { ersteAnfrage = true; };
                erzeugteAnfrage += "channel:moderate";
            }
            if (chk_bits_read.Checked)
            {
                if (ersteAnfrage) { erzeugteAnfrage += "+"; } else { ersteAnfrage = true; };
                erzeugteAnfrage += "bits:read";
            }
            if (chk_channel_read_redemptions.Checked)
            {
                if (ersteAnfrage) { erzeugteAnfrage += "+"; } else { ersteAnfrage = true; };
                erzeugteAnfrage += "channel:read:redemptions";
            }
            if (chk_channel_manage_redemptions.Checked)
            {
                if (ersteAnfrage) { erzeugteAnfrage += "+"; } else { ersteAnfrage = true; };
                erzeugteAnfrage += "channel:manage:redemptions";
            }

            if (chk_user_edit.Checked)
            {
                if (ersteAnfrage) { erzeugteAnfrage += "+"; } else { ersteAnfrage = true; };
                erzeugteAnfrage += "user:edit";
            }
            /*
            if (chk_user_read.Checked)
            {
                if (ersteAnfrage) { erzeugteAnfrage += "+"; } else { ersteAnfrage = true; };
                erzeugteAnfrage += "user_read";
            }
            */

            if (chk_user_edit_broadcast.Checked)
            {
                if (ersteAnfrage) { erzeugteAnfrage += "+"; } else { ersteAnfrage = true; };
                erzeugteAnfrage += "user:edit:broadcast";
            }
            if (chk_channel_editor.Checked)
            {
                if (ersteAnfrage) { erzeugteAnfrage += "+"; } else { ersteAnfrage = true; };
                erzeugteAnfrage += "channel_editor";
            }

            if (chk_clips_edit.Checked)
            {
                if (ersteAnfrage) { erzeugteAnfrage += "+"; } else { ersteAnfrage = true; };
                erzeugteAnfrage += "clips:edit";
            }
            erzeugteAnfrage += "&token_type=bearer";

            return erzeugteAnfrage;

        }

        private void btnHilfe_Click(object sender, EventArgs e)
        {

            Assembly _Assembly = Assembly.GetExecutingAssembly();
            Stream str = _Assembly.GetManifestResourceStream("AntonBot.Fenster.HilfeSeiten.TwitchAnleitung.html");
            StreamReader rd = new StreamReader(str);

            string Path = Application.StartupPath + System.IO.Path.DirectorySeparatorChar + "TwitchAnleitung.html";
            File.WriteAllText(Path, rd.ReadToEnd());

            

            var test = _Assembly.GetManifestResourceNames();
            System.Diagnostics.Process.Start(Path);

            //File.Delete(Path);
            //Datei nach beenden des Fensters löschen

        }

        private void Scopeübernahme() {
            SettingsGroup.Instance.Tschat_edit = chk_chat_edit.Checked;
            SettingsGroup.Instance.Tschat_read = chk_chat_read.Checked;
            SettingsGroup.Instance.Tswhispers_edit = chk_whispers_edit.Checked;
            SettingsGroup.Instance.Tswhispers_read = chk_whispers_read.Checked;
            SettingsGroup.Instance.Tschannel_moderate = chk_channel_moderate.Checked;

            SettingsGroup.Instance.Tsbits_read = chk_bits_read.Checked;
            SettingsGroup.Instance.Tschannel_read_redemptions = chk_channel_read_redemptions.Checked;
            SettingsGroup.Instance.Tschannel_manage_redemptions = chk_channel_manage_redemptions.Checked;
            SettingsGroup.Instance.Tsuser_edit = chk_user_edit.Checked;

            SettingsGroup.Instance.Tsclips_edit = chk_clips_edit.Checked;

            SettingsGroup.Instance.Tsuser_edit_broadcast = chk_user_edit_broadcast.Checked;
            SettingsGroup.Instance.Tschannel_editor = chk_channel_editor.Checked;

            bAccessTokenChange = true;
        }
        private void btnTokenManuell_Click(object sender, EventArgs e)
        {
            if (txtTokenManuell.Text != null)
            {
                sAlterToken = SettingsGroup.Instance.TsAccessToken;
                txtTokenManuell.Text = txtTokenManuell.Text.Trim();
                SettingsGroup.Instance.TsAccessToken = txtTokenManuell.Text;
                lblTokenNew.Text = "Neuer Token: " + txtTokenManuell.Text;
                bAccessTokenChange = true;
            }
        }

        private void lblTokenNew_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetText(lblTokenNew.Text, TextDataFormat.UnicodeText);
            if (Clipboard.ContainsText())
            {
                MessageBox.Show("In die Zwischenablage kopiert");
            }
            else
            {
                MessageBox.Show("Keine Kopierfunktion");
            }
        }

        private void lblTokenCurrent_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetText(lblTokenCurrent.Text, TextDataFormat.UnicodeText);
            if (Clipboard.ContainsText())
            {
                MessageBox.Show("In die Zwischenablage kopiert");
            }
            else
            {
                MessageBox.Show("Keine Kopierfunktion");
            }
        }

        private void chk_PubSubToken_CheckedChanged(object sender, EventArgs e)
        {
            txtTokenPubSub.Enabled = chk_PubSubToken.Checked;
            btnTokenPubSub.Enabled = chk_PubSubToken.Checked;
            SettingsGroup.Instance.TsPubSubZusatz = chk_PubSubToken.Checked;
        }

        private void btnTokenPubSub_Click(object sender, EventArgs e)
        {
            if (txtTokenPubSub.Text != null)
            {
                sAlterTokenPubSub = SettingsGroup.Instance.TsAccessTokenPubSub;
                txtTokenPubSub.Text = txtTokenPubSub.Text.Trim();
                SettingsGroup.Instance.TsAccessTokenPubSub = txtTokenPubSub.Text;
                lblTokenNewPubSub.Text = "Neuer PubSub-Token: " + txtTokenPubSub.Text;
                bAccessTokenChange = true;
            }
            else {
                MessageBox.Show("Das Feld ist leer. Der Token kann nicht übernommen werden.");
            }
        }

        private void lblTokenPubSub_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Clipboard.SetText(lblTokenPubSub.Text, TextDataFormat.UnicodeText);
            if (Clipboard.ContainsText())
            {
                MessageBox.Show("In die Zwischenablage kopiert");
            }
            else
            {
                MessageBox.Show("Keine Kopierfunktion");
            }
        }

        private void lblTokenNewPubSub_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetText(lblTokenNewPubSub.Text, TextDataFormat.UnicodeText);
            if (Clipboard.ContainsText())
            {
                MessageBox.Show("In die Zwischenablage kopiert");
            }
            else
            {
                MessageBox.Show("Keine Kopierfunktion");
            }
        }

        private void txtStandardChannel_TextChanged(object sender, EventArgs e)
        {
            if (txtStandardChannel.Text != SettingsGroup.Instance.TsStandardChannel)
            {
                bAccessTokenChange = true;
            }
        }

        private void btnTokenCheck_Click(object sender, EventArgs e)
        {
            //Token werden hier geprüft und Ergebnis als MessageBox angezeigt (Die Scopes die nicht passen, werden Rot eingefärbt)
            List<String> ErgebnisToken = TwitchFunction.TestTokensStatic(SettingsGroup.Instance.TsAccessToken);

            String Ausgabe = "Tokens wurden überprüft..." + Environment.NewLine + Environment.NewLine;
            //ist die Länge 0, dann ist der Token nicht gültig gewesen
            if (ErgebnisToken.Count > 0)
            {
                Ausgabe += "Der Twitch-Token ist noch " + ErgebnisToken[0] + " Sekunden gültig." + Environment.NewLine + Environment.NewLine;

                if (chk_chat_read.Checked ^ ErgebnisToken.Contains("chat:read"))
                {
                    if (chk_chat_read.Checked)
                    {
                        //Checkbox ist angehakt, aber das Recht ist nicht da. => Fehler, da muss neu angefordert werden
                        chk_chat_read.ForeColor = Color.DarkRed;
                        Ausgabe += "Die Berechtigung  'chat:read'  wird erwartet, aber ist nicht im Token." + Environment.NewLine;
                    }
                    else
                    {
                        //Recht ist da, aber Checkbox ist nicht angehakt => Kein Wirklicher Fehler, Haken muss nur übernommen werden
                        chk_chat_read.ForeColor = Color.Orange;
                        Ausgabe += "Die Berechtigung  'chat:read'  wird nicht erwartet, ist aber im Token." + Environment.NewLine;
                        chk_chat_read.Checked = true;
                    }
                }
                if (chk_chat_edit.Checked ^ ErgebnisToken.Contains("chat:edit"))
                {
                    if (chk_chat_edit.Checked)
                    {
                        //Checkbox ist angehakt, aber das Recht ist nicht da. => Fehler, da muss neu angefordert werden
                        chk_chat_edit.ForeColor = Color.DarkRed;
                        Ausgabe += "Die Berechtigung  'chat:edit'  wird erwartet, aber ist nicht im Token." + Environment.NewLine;
                    }
                    else
                    {
                        //Recht ist da, aber Checkbox ist nicht angehakt => Kein Wirklicher Fehler, Haken muss nur übernommen werden
                        chk_chat_edit.ForeColor = Color.Orange;
                        Ausgabe += "Die Berechtigung  'chat:edit'  wird nicht erwartet, ist aber im Token." + Environment.NewLine;
                        chk_chat_edit.Checked = true;
                    }
                }
                if (chk_whispers_read.Checked ^ ErgebnisToken.Contains("whispers:read"))
                {
                    if (chk_whispers_read.Checked)
                    {
                        //Checkbox ist angehakt, aber das Recht ist nicht da. => Fehler, da muss neu angefordert werden
                        chk_whispers_read.ForeColor = Color.DarkRed;
                        Ausgabe += "Die Berechtigung  'whispers:read'  wird erwartet, aber ist nicht im Token." + Environment.NewLine;
                    }
                    else
                    {
                        //Recht ist da, aber Checkbox ist nicht angehakt => Kein Wirklicher Fehler, Haken muss nur übernommen werden
                        chk_whispers_read.ForeColor = Color.Orange;
                        Ausgabe += "Die Berechtigung  'whispers:read'  wird nicht erwartet, ist aber im Token." + Environment.NewLine;
                        chk_whispers_read.Checked = true;
                    }
                }
                if (chk_whispers_edit.Checked ^ ErgebnisToken.Contains("whispers:edit"))
                {
                    if (chk_whispers_edit.Checked)
                    {
                        //Checkbox ist angehakt, aber das Recht ist nicht da. => Fehler, da muss neu angefordert werden
                        chk_whispers_edit.ForeColor = Color.DarkRed;
                        Ausgabe += "Die Berechtigung  'whispers:edit'  wird erwartet, aber ist nicht im Token." + Environment.NewLine;
                    }
                    else
                    {
                        //Recht ist da, aber Checkbox ist nicht angehakt => Kein Wirklicher Fehler, Haken muss nur übernommen werden
                        chk_whispers_edit.ForeColor = Color.Orange;
                        Ausgabe += "Die Berechtigung  'whispers:edit'  wird nicht erwartet, ist aber im Token." + Environment.NewLine;
                        chk_whispers_edit.Checked = true;
                    }
                }
                if (chk_channel_moderate.Checked ^ ErgebnisToken.Contains("channel:moderate"))
                {
                    if (chk_channel_moderate.Checked)
                    {
                        //Checkbox ist angehakt, aber das Recht ist nicht da. => Fehler, da muss neu angefordert werden
                        chk_channel_moderate.ForeColor = Color.DarkRed;
                        Ausgabe += "Die Berechtigung  'channel:moderate'  wird erwartet, aber ist nicht im Token." + Environment.NewLine;
                    }
                    else
                    {
                        //Recht ist da, aber Checkbox ist nicht angehakt => Kein Wirklicher Fehler, Haken muss nur übernommen werden
                        chk_channel_moderate.ForeColor = Color.Orange;
                        Ausgabe += "Die Berechtigung  'channel:moderate'  wird nicht erwartet, ist aber im Token." + Environment.NewLine;
                        chk_channel_moderate.Checked = true;
                    }
                }

                if (chk_user_edit_broadcast.Checked ^ ErgebnisToken.Contains("user:edit:broadcast"))
                {
                    if (chk_user_edit_broadcast.Checked)
                    {
                        //Checkbox ist angehakt, aber das Recht ist nicht da. => Fehler, da muss neu angefordert werden
                        chk_user_edit_broadcast.ForeColor = Color.DarkRed;
                        Ausgabe += "Die Berechtigung  'user:edit:broadcast'  wird erwartet, aber ist nicht im Token." + Environment.NewLine;
                    }
                    else
                    {
                        //Recht ist da, aber Checkbox ist nicht angehakt => Kein Wirklicher Fehler, Haken muss nur übernommen werden
                        chk_user_edit_broadcast.ForeColor = Color.Orange;
                        Ausgabe += "Die Berechtigung  'user:edit:broadcast'  wird nicht erwartet, ist aber im Token." + Environment.NewLine;
                        chk_user_edit_broadcast.Checked = true;
                    }
                }
                if (chk_channel_editor.Checked ^ ErgebnisToken.Contains("channel_editor"))
                {
                    if (chk_channel_editor.Checked)
                    {
                        //Checkbox ist angehakt, aber das Recht ist nicht da. => Fehler, da muss neu angefordert werden
                        chk_channel_editor.ForeColor = Color.DarkRed;
                        Ausgabe += "Die Berechtigung  'channel_editor'  wird erwartet, aber ist nicht im Token." + Environment.NewLine;
                    }
                    else
                    {
                        //Recht ist da, aber Checkbox ist nicht angehakt => Kein Wirklicher Fehler, Haken muss nur übernommen werden
                        chk_channel_editor.ForeColor = Color.Orange;
                        Ausgabe += "Die Berechtigung  'channel_editor'  wird nicht erwartet, ist aber im Token." + Environment.NewLine;
                        chk_channel_editor.Checked = true;
                    }
                }
                if (chk_clips_edit.Checked ^ ErgebnisToken.Contains("clips:edit"))
                {
                    if (chk_clips_edit.Checked)
                    {
                        //Checkbox ist angehakt, aber das Recht ist nicht da. => Fehler, da muss neu angefordert werden
                        chk_clips_edit.ForeColor = Color.DarkRed;
                        Ausgabe += "Die Berechtigung  'clips:edit'  wird erwartet, aber ist nicht im Token." + Environment.NewLine;
                    }
                    else
                    {
                        //Recht ist da, aber Checkbox ist nicht angehakt => Kein Wirklicher Fehler, Haken muss nur übernommen werden
                        chk_clips_edit.ForeColor = Color.Orange;
                        Ausgabe += "Die Berechtigung  'clips:edit'  wird nicht erwartet, ist aber im Token." + Environment.NewLine;
                        chk_clips_edit.Checked = true;
                    }
                }

                if (SettingsGroup.Instance.TsPubSubZusatz)
                {
                    Ausgabe += Environment.NewLine + "Der PupSub-Token wird zusätzlich verwendet und überprüft..." + Environment.NewLine + Environment.NewLine;
                    List<String> ErgebnisTokenPupSub = TwitchFunction.TestTokensStatic(SettingsGroup.Instance.TsAccessTokenPubSub);

                    if (ErgebnisTokenPupSub.Count > 0)
                    {
                        Ausgabe += "Der PupSub-Token ist noch " + ErgebnisTokenPupSub[0] + " Sekunden gültig." + Environment.NewLine + Environment.NewLine;

                        //Hier die Prüfungen, die nur für den PubSub-Token gelten (dieser kann zwar mehr haben, sind aber nicht wichtig für die eigentliche Verwendung)
                        if (chk_channel_read_redemptions.Checked ^ ErgebnisTokenPupSub.Contains("channel:read:redemptions"))
                        {
                            if (chk_channel_read_redemptions.Checked)
                            {
                                //Checkbox ist angehakt, aber das Recht ist nicht da. => Fehler, da muss neu angefordert werden
                                chk_channel_read_redemptions.ForeColor = Color.DarkRed;
                                Ausgabe += "Die Berechtigung  'channel:read:redemptions'  wird erwartet, aber ist nicht im Token." + Environment.NewLine;
                            }
                            else
                            {
                                //Recht ist da, aber Checkbox ist nicht angehakt => Kein Wirklicher Fehler, Haken muss nur übernommen werden
                                chk_channel_read_redemptions.ForeColor = Color.Orange;
                                Ausgabe += "Die Berechtigung  'channel:read:redemptions'  wird nicht erwartet, ist aber im Token." + Environment.NewLine;
                                chk_channel_read_redemptions.Checked = true;
                            }
                        }
                        if (chk_channel_manage_redemptions.Checked ^ ErgebnisTokenPupSub.Contains("channel:manage:redemptions"))
                        {
                            if (chk_channel_manage_redemptions.Checked)
                            {
                                //Checkbox ist angehakt, aber das Recht ist nicht da. => Fehler, da muss neu angefordert werden
                                chk_channel_manage_redemptions.ForeColor = Color.DarkRed;
                                Ausgabe += "Die Berechtigung  'channel:manage:redemptions'  wird erwartet, aber ist nicht im Token." + Environment.NewLine;
                            }
                            else
                            {
                                //Recht ist da, aber Checkbox ist nicht angehakt => Kein Wirklicher Fehler, Haken muss nur übernommen werden
                                chk_channel_manage_redemptions.ForeColor = Color.Orange;
                                Ausgabe += "Die Berechtigung  'channel:manage:redemptions'  wird nicht erwartet, ist aber im Token." + Environment.NewLine;
                                chk_channel_manage_redemptions.Checked = true;
                            }
                        }
                        if (chk_bits_read.Checked ^ ErgebnisTokenPupSub.Contains("bits:read"))
                        {
                            if (chk_bits_read.Checked)
                            {
                                //Checkbox ist angehakt, aber das Recht ist nicht da. => Fehler, da muss neu angefordert werden
                                chk_bits_read.ForeColor = Color.DarkRed;
                                Ausgabe += "Die Berechtigung  'bits:read'  wird erwartet, aber ist nicht im Token." + Environment.NewLine;
                            }
                            else
                            {
                                //Recht ist da, aber Checkbox ist nicht angehakt => Kein Wirklicher Fehler, Haken muss nur übernommen werden
                                chk_bits_read.ForeColor = Color.Orange;
                                Ausgabe += "Die Berechtigung  'bits:read'  wird nicht erwartet, ist aber im Token." + Environment.NewLine;
                                chk_bits_read.Checked = true;
                            }
                        }
                        if (chk_user_edit.Checked ^ ErgebnisTokenPupSub.Contains("user:edit"))
                        {
                            if (chk_user_edit.Checked)
                            {
                                //Checkbox ist angehakt, aber das Recht ist nicht da. => Fehler, da muss neu angefordert werden
                                chk_user_edit.ForeColor = Color.DarkRed;
                                Ausgabe += "Die Berechtigung  'user:edit'  wird erwartet, aber ist nicht im Token." + Environment.NewLine;
                            }
                            else
                            {
                                //Recht ist da, aber Checkbox ist nicht angehakt => Kein Wirklicher Fehler, Haken muss nur übernommen werden
                                chk_user_edit.ForeColor = Color.Orange;
                                Ausgabe += "Die Berechtigung  'user:edit'  wird nicht erwartet, ist aber im Token." + Environment.NewLine;
                                chk_user_edit.Checked = true;
                            }
                        }
                    }
                    else
                    {
                        Ausgabe += "Der geprüfte PupSub-Token ist nicht mehr gültig. Fordere einen neuen an.";
                    }
                }
                else
                {
                    //Wenn der PubSub Token nicht verwendet wird, werden hier noch die Berechtigungen des Twitch-Tokens geprüft
                    if (chk_channel_read_redemptions.Checked ^ ErgebnisToken.Contains("channel:read:redemptions"))
                    {
                        if (chk_channel_read_redemptions.Checked)
                        {
                            //Checkbox ist angehakt, aber das Recht ist nicht da. => Fehler, da muss neu angefordert werden
                            chk_channel_read_redemptions.ForeColor = Color.DarkRed;
                            Ausgabe += "Die Berechtigung  'channel:read:redemptions'  wird erwartet, aber ist nicht im Token." + Environment.NewLine;
                        }
                        else
                        {
                            //Recht ist da, aber Checkbox ist nicht angehakt => Kein Wirklicher Fehler, Haken muss nur übernommen werden
                            chk_channel_read_redemptions.ForeColor = Color.Orange;
                            Ausgabe += "Die Berechtigung  'channel:read:redemptions'  wird nicht erwartet, ist aber im Token." + Environment.NewLine;
                            chk_channel_read_redemptions.Checked = true;
                        }
                    }
                    if (chk_channel_manage_redemptions.Checked ^ ErgebnisToken.Contains("channel:manage:redemptions"))
                    {
                        if (chk_channel_manage_redemptions.Checked)
                        {
                            //Checkbox ist angehakt, aber das Recht ist nicht da. => Fehler, da muss neu angefordert werden
                            chk_channel_manage_redemptions.ForeColor = Color.DarkRed;
                            Ausgabe += "Die Berechtigung  'channel:manage:redemptions'  wird erwartet, aber ist nicht im Token." + Environment.NewLine;
                        }
                        else
                        {
                            //Recht ist da, aber Checkbox ist nicht angehakt => Kein Wirklicher Fehler, Haken muss nur übernommen werden
                            chk_channel_manage_redemptions.ForeColor = Color.Orange;
                            Ausgabe += "Die Berechtigung  'channel:manage:redemptions'  wird nicht erwartet, ist aber im Token." + Environment.NewLine;
                            chk_channel_manage_redemptions.Checked = true;
                        }
                    }
                    if (chk_bits_read.Checked ^ ErgebnisToken.Contains("bits:read"))
                    {
                        if (chk_bits_read.Checked)
                        {
                            //Checkbox ist angehakt, aber das Recht ist nicht da. => Fehler, da muss neu angefordert werden
                            chk_bits_read.ForeColor = Color.DarkRed;
                            Ausgabe += "Die Berechtigung  'bits:read'  wird erwartet, aber ist nicht im Token." + Environment.NewLine;
                        }
                        else
                        {
                            //Recht ist da, aber Checkbox ist nicht angehakt => Kein Wirklicher Fehler, Haken muss nur übernommen werden
                            chk_bits_read.ForeColor = Color.Orange;
                            Ausgabe += "Die Berechtigung  'bits:read'  wird nicht erwartet, ist aber im Token." + Environment.NewLine;
                            chk_bits_read.Checked = true;
                        }
                    }
                    if (chk_user_edit.Checked ^ ErgebnisToken.Contains("user:edit"))
                    {
                        if (chk_user_edit.Checked)
                        {
                            //Checkbox ist angehakt, aber das Recht ist nicht da. => Fehler, da muss neu angefordert werden
                            chk_user_edit.ForeColor = Color.DarkRed;
                            Ausgabe += "Die Berechtigung  'user:edit'  wird erwartet, aber ist nicht im Token." + Environment.NewLine;
                        }
                        else
                        {
                            //Recht ist da, aber Checkbox ist nicht angehakt => Kein Wirklicher Fehler, Haken muss nur übernommen werden
                            chk_user_edit.ForeColor = Color.Orange;
                            Ausgabe += "Die Berechtigung  'user:edit'  wird nicht erwartet, ist aber im Token." + Environment.NewLine;
                            chk_user_edit.Checked = true;
                        }
                    }
                }

                Ausgabe += Environment.NewLine + "Die Orange hinterlegten Werte wurden automatisch angepasst. Für die roten Werte muss ein neuer Token angefordert werden.";
            }
            else
            {
                Ausgabe += "Der geprüfte Twitch-Token ist nicht mehr gültig. Fordere einen neuen an.";
            }

            MessageBox.Show(Ausgabe, "Ergebniss der Auswertung", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region TwitchEvents

        private void IndexChange() {
            /* Index:
            0 = OnStreamOnline
            1 = OnStreamOffline
            2 = OnStreamUpdate
            3 = OnNewFollowersDetected
            4 = OnMessageReceived
            5 = OnWhisperReceived
            6 = OnNewSubscriber
            7 = OnConnected
            8 = OnBeingHosted
            9 = OnRaidNotification
            10 = OnJoinedChannel
            11 = OnUserJoined
            12 = OnExistingUsersDetected
            13 = OnRewardRedeemed
            14 = OnRaidGo
            15 = OnUserLeft
            16 = OnClipCreated
            */

            //Die Felder werden als erstes alle aktiviert, für den Fall, dass diese vorher deaktiviert wurden...
            chkTextReaction.Enabled = true;
            txtChatReaktion.Enabled = true;
            chkDiscordAusgabe.Enabled = true;
            txtDiscordChat.Enabled = true;
            chkKonsoleAusgabe.Enabled = true;
            txtKonsolenFenster.Enabled = true;
            grpEvent.Enabled = true;
            switch (LstEvents.SelectedIndex)
            {
                case 0:
                    chkUse.Checked = SettingsGroup.Instance.TeOnStreamOnlineUse;
                    chkTextReaction.Checked = SettingsGroup.Instance.TeOnStreamOnlineChat;
                    txtChatReaktion.Text = SettingsGroup.Instance.TeOnStreamOnlineChatText;
                    chkDiscordAusgabe.Checked = SettingsGroup.Instance.TeOnStreamOnlineDiscord;
                    txtDiscordChat.Text = SettingsGroup.Instance.TeOnStreamOnlineDiscordText;
                    chkKonsoleAusgabe.Checked = SettingsGroup.Instance.TeOnStreamOnlineKonsole;
                    txtKonsolenFenster.Text = SettingsGroup.Instance.TeOnStreamOnlineKonsoleText;
                    break;
                case 1:
                    chkUse.Checked = SettingsGroup.Instance.TeOnStreamOfflineUse;
                    chkTextReaction.Checked = SettingsGroup.Instance.TeOnStreamOfflineChat;
                    txtChatReaktion.Text = SettingsGroup.Instance.TeOnStreamOfflineChatText;
                    chkDiscordAusgabe.Checked = SettingsGroup.Instance.TeOnStreamOfflineDiscord;
                    txtDiscordChat.Text = SettingsGroup.Instance.TeOnStreamOfflineDiscordText;
                    chkKonsoleAusgabe.Checked = SettingsGroup.Instance.TeOnStreamOfflineKonsole;
                    txtKonsolenFenster.Text = SettingsGroup.Instance.TeOnStreamOfflineKonsoleText;
                    break;
                case 2:
                    chkUse.Checked = SettingsGroup.Instance.TeOnStreamUpdateUse;
                    chkTextReaction.Checked = SettingsGroup.Instance.TeOnStreamUpdateChat;
                    txtChatReaktion.Text = SettingsGroup.Instance.TeOnStreamUpdateChatText;
                    chkDiscordAusgabe.Checked = SettingsGroup.Instance.TeOnStreamUpdateDiscord;
                    txtDiscordChat.Text = SettingsGroup.Instance.TeOnStreamUpdateDiscordText;
                    chkKonsoleAusgabe.Checked = SettingsGroup.Instance.TeOnStreamUpdateKonsole;
                    txtKonsolenFenster.Text = SettingsGroup.Instance.TeOnStreamUpdateKonsoleText;
                    break;
                case 3:
                    chkUse.Checked = SettingsGroup.Instance.TeOnNewFollowersDetectedUse;
                    chkTextReaction.Checked = SettingsGroup.Instance.TeOnNewFollowersDetectedChat;
                    txtChatReaktion.Text = SettingsGroup.Instance.TeOnNewFollowersDetectedChatText;
                    chkDiscordAusgabe.Checked = SettingsGroup.Instance.TeOnNewFollowersDetectedDiscord;
                    txtDiscordChat.Text = SettingsGroup.Instance.TeOnNewFollowersDetectedDiscordText;
                    chkKonsoleAusgabe.Checked = SettingsGroup.Instance.TeOnNewFollowersDetectedKonsole;
                    txtKonsolenFenster.Text = SettingsGroup.Instance.TeOnNewFollowersDetectedKonsoleText;
                    break;
                case 4:
                    chkUse.Checked = SettingsGroup.Instance.TeOnMessageReceivedUse;
                    chkTextReaction.Checked = SettingsGroup.Instance.TeOnMessageReceivedChat;
                    txtChatReaktion.Text = SettingsGroup.Instance.TeOnMessageReceivedChatText;
                    chkDiscordAusgabe.Checked = SettingsGroup.Instance.TeOnMessageReceivedDiscord;
                    txtDiscordChat.Text = SettingsGroup.Instance.TeOnMessageReceivedDiscordText;
                    chkKonsoleAusgabe.Checked = SettingsGroup.Instance.TeOnMessageReceivedKonsole;
                    txtKonsolenFenster.Text = SettingsGroup.Instance.TeOnMessageReceivedKonsoleText;

                    //Fürs erste wird die Gesamte Gruppe deaktiviert, da die Reaktion auf dieses Event über die Kommandos erfolgt
                    grpEvent.Enabled = false;
                    break;
                case 5:
                    chkUse.Checked = SettingsGroup.Instance.TeOnWhisperReceivedUse;
                    chkTextReaction.Checked = SettingsGroup.Instance.TeOnWhisperReceivedChat;
                    txtChatReaktion.Text = SettingsGroup.Instance.TeOnWhisperReceivedChatText;
                    chkDiscordAusgabe.Checked = SettingsGroup.Instance.TeOnWhisperReceivedDiscord;
                    txtDiscordChat.Text = SettingsGroup.Instance.TeOnWhisperReceivedDiscordText;
                    chkKonsoleAusgabe.Checked = SettingsGroup.Instance.TeOnWhisperReceivedKonsole;
                    txtKonsolenFenster.Text = SettingsGroup.Instance.TeOnWhisperReceivedKonsoleText;

                    //Fürs erste wird die Gesamte Gruppe deaktiviert, da die Reaktion auf dieses Event über die Kommandos erfolgt
                    grpEvent.Enabled = false;
                    break;
                case 6:
                    chkUse.Checked = SettingsGroup.Instance.TeOnNewSubscriberUse;
                    chkTextReaction.Checked = SettingsGroup.Instance.TeOnNewSubscriberChat;
                    txtChatReaktion.Text = SettingsGroup.Instance.TeOnNewSubscriberChatText;
                    chkDiscordAusgabe.Checked = SettingsGroup.Instance.TeOnNewSubscriberDiscord;
                    txtDiscordChat.Text = SettingsGroup.Instance.TeOnNewSubscriberDiscordText;
                    chkKonsoleAusgabe.Checked = SettingsGroup.Instance.TeOnNewSubscriberKonsole;
                    txtKonsolenFenster.Text = SettingsGroup.Instance.TeOnNewSubscriberKonsoleText;
                    break;
                case 7:
                    chkUse.Checked = SettingsGroup.Instance.TeOnConnected.Use;
                    chkTextReaction.Checked = SettingsGroup.Instance.TeOnConnected.Chat;
                    txtChatReaktion.Text = SettingsGroup.Instance.TeOnConnected.ChatText;
                    chkDiscordAusgabe.Checked = SettingsGroup.Instance.TeOnConnected.Discord;
                    txtDiscordChat.Text = SettingsGroup.Instance.TeOnConnected.DiscordText;
                    chkKonsoleAusgabe.Checked = SettingsGroup.Instance.TeOnConnected.Konsole;
                    txtKonsolenFenster.Text = SettingsGroup.Instance.TeOnConnected.KonsoleText;
                    break;
                case 8:
                    chkUse.Checked = SettingsGroup.Instance.TeOnBeingHosted.Use;
                    chkTextReaction.Checked = SettingsGroup.Instance.TeOnBeingHosted.Chat;
                    txtChatReaktion.Text = SettingsGroup.Instance.TeOnBeingHosted.ChatText;
                    chkDiscordAusgabe.Checked = SettingsGroup.Instance.TeOnBeingHosted.Discord;
                    txtDiscordChat.Text = SettingsGroup.Instance.TeOnBeingHosted.DiscordText;
                    chkKonsoleAusgabe.Checked = SettingsGroup.Instance.TeOnBeingHosted.Konsole;
                    txtKonsolenFenster.Text = SettingsGroup.Instance.TeOnBeingHosted.KonsoleText;
                    break;
                case 9:
                    chkUse.Checked = SettingsGroup.Instance.TeOnRaidNotificationUse;
                    chkTextReaction.Checked = SettingsGroup.Instance.TeOnRaidNotificationChat;
                    txtChatReaktion.Text = SettingsGroup.Instance.TeOnRaidNotificationChatText;
                    chkDiscordAusgabe.Checked = SettingsGroup.Instance.TeOnRaidNotificationDiscord;
                    txtDiscordChat.Text = SettingsGroup.Instance.TeOnRaidNotificationDiscordText;
                    chkKonsoleAusgabe.Checked = SettingsGroup.Instance.TeOnRaidNotificationKonsole;
                    txtKonsolenFenster.Text = SettingsGroup.Instance.TeOnRaidNotificationKonsoleText; ;
                    break;
                case 10:
                    chkUse.Checked = SettingsGroup.Instance.TeOnJoinedChannel.Use;
                    chkTextReaction.Checked = SettingsGroup.Instance.TeOnJoinedChannel.Chat;
                    txtChatReaktion.Text = SettingsGroup.Instance.TeOnJoinedChannel.ChatText;
                    chkDiscordAusgabe.Checked = SettingsGroup.Instance.TeOnJoinedChannel.Discord;
                    txtDiscordChat.Text = SettingsGroup.Instance.TeOnJoinedChannel.DiscordText;
                    chkKonsoleAusgabe.Checked = SettingsGroup.Instance.TeOnJoinedChannel.Konsole;
                    txtKonsolenFenster.Text = SettingsGroup.Instance.TeOnJoinedChannel.KonsoleText;

                    //onUserJoined wird nur in der Konsole ausgegeben
                    
                    chkTextReaction.Enabled = false;
                    txtChatReaktion.Enabled = false;
                    chkDiscordAusgabe.Enabled = false;
                    txtDiscordChat.Enabled = false;
                    break;
                case 11:
                    chkUse.Checked = SettingsGroup.Instance.TeOnUserJoinedUse;
                    chkTextReaction.Checked = SettingsGroup.Instance.TeOnUserJoinedChat;
                    txtChatReaktion.Text = SettingsGroup.Instance.TeOnUserJoinedChatText;
                    chkDiscordAusgabe.Checked = SettingsGroup.Instance.TeOnUserJoinedDiscord;
                    txtDiscordChat.Text = SettingsGroup.Instance.TeOnUserJoinedDiscordText;
                    chkKonsoleAusgabe.Checked = SettingsGroup.Instance.TeOnUserJoinedKonsole;
                    txtKonsolenFenster.Text = SettingsGroup.Instance.TeOnUserJoinedKonsoleText;
                    break;
                case 12:
                    chkUse.Checked = SettingsGroup.Instance.TeOnExistingUsersDetected.Use;
                    chkTextReaction.Checked = SettingsGroup.Instance.TeOnExistingUsersDetected.Chat;
                    txtChatReaktion.Text = SettingsGroup.Instance.TeOnExistingUsersDetected.ChatText;
                    chkDiscordAusgabe.Checked = SettingsGroup.Instance.TeOnExistingUsersDetected.Discord;
                    txtDiscordChat.Text = SettingsGroup.Instance.TeOnExistingUsersDetected.DiscordText;
                    chkKonsoleAusgabe.Checked = SettingsGroup.Instance.TeOnExistingUsersDetected.Konsole;
                    txtKonsolenFenster.Text = SettingsGroup.Instance.TeOnExistingUsersDetected.KonsoleText;
                    break;
                case 13:
                    chkUse.Checked = SettingsGroup.Instance.TeOnRewardRedeemedUse;
                    chkTextReaction.Checked = SettingsGroup.Instance.TeOnRewardRedeemedChat;
                    txtChatReaktion.Text = SettingsGroup.Instance.TeOnRewardRedeemedChatText;
                    chkDiscordAusgabe.Checked = SettingsGroup.Instance.TeOnRewardRedeemedDiscord;
                    txtDiscordChat.Text = SettingsGroup.Instance.TeOnRewardRedeemedDiscordText;
                    chkKonsoleAusgabe.Checked = SettingsGroup.Instance.TeOnRewardRedeemedKonsole;
                    txtKonsolenFenster.Text = SettingsGroup.Instance.TeOnRewardRedeemedKonsoleText;
                    break;
                case 14:
                    chkUse.Checked = SettingsGroup.Instance.TeOnRaidGoUse;
                    chkTextReaction.Checked = SettingsGroup.Instance.TeOnRaidGoChat;
                    txtChatReaktion.Text = SettingsGroup.Instance.TeOnRaidGoChatText;
                    chkDiscordAusgabe.Checked = SettingsGroup.Instance.TeOnRaidGoDiscord;
                    txtDiscordChat.Text = SettingsGroup.Instance.TeOnRaidGoDiscordText;
                    chkKonsoleAusgabe.Checked = SettingsGroup.Instance.TeOnRaidGoKonsole;
                    txtKonsolenFenster.Text = SettingsGroup.Instance.TeOnRaidGoKonsoleText;
                    break;
                case 15:
                    chkUse.Checked = SettingsGroup.Instance.TeOnUserLeftUse;
                    chkTextReaction.Checked = SettingsGroup.Instance.TeOnUserLeftChat;
                    txtChatReaktion.Text = SettingsGroup.Instance.TeOnUserLeftChatText;
                    chkDiscordAusgabe.Checked = SettingsGroup.Instance.TeOnUserLeftDiscord;
                    txtDiscordChat.Text = SettingsGroup.Instance.TeOnUserLeftDiscordText;
                    chkKonsoleAusgabe.Checked = SettingsGroup.Instance.TeOnUserLeftKonsole;
                    txtKonsolenFenster.Text = SettingsGroup.Instance.TeOnUserLeftKonsoleText;
                    break;
                case 16:
                    chkUse.Checked = SettingsGroup.Instance.TeOnClipCreated.Use;
                    chkTextReaction.Checked = SettingsGroup.Instance.TeOnClipCreated.Chat;
                    txtChatReaktion.Text = SettingsGroup.Instance.TeOnClipCreated.ChatText;
                    chkDiscordAusgabe.Checked = SettingsGroup.Instance.TeOnClipCreated.Discord;
                    txtDiscordChat.Text = SettingsGroup.Instance.TeOnClipCreated.DiscordText;
                    chkKonsoleAusgabe.Checked = SettingsGroup.Instance.TeOnClipCreated.Konsole;
                    txtKonsolenFenster.Text = SettingsGroup.Instance.TeOnClipCreated.KonsoleText;
                    break;
            }
            btnDiscordChannel.Enabled = chkDiscordAusgabe.Checked;

            iAltIndex = LstEvents.SelectedIndex;
            
            VariableBefüllen(1, LstEvents.SelectedIndex);
        }

        private void VariableBefüllen(int Teil, int Inhalt) {
            //Die Variable Teil wird verwendet, um anzugeben, welchen Part der Variablen "Neu" beschrieben wird
            //Es gibt zwei Teile:
            // 1) Die Variablen aus den Events
            // 2) Die Variablen aus den Textfeldern
            // Je nach dem, soll nur eines der beiden Feldern befüllt werden

            cmbVariable.Text = "";

            if (Teil == 1) {
                iVariablenInhaltEvent = Inhalt;
            }
            else if(Teil == 2){
                iVariablenInhaltTextFeld = Inhalt;
            }

            cmbVariable.Items.Clear();

            switch (iVariablenInhaltEvent) {
                case 0:
                    //OnStreamOnline
                    cmbVariable.Items.Add("GameId");
                    //cmbVariable.Items.Add("Id");
                    cmbVariable.Items.Add("Language");
                    cmbVariable.Items.Add("StartedAt");
                    cmbVariable.Items.Add("Title");
                    cmbVariable.Items.Add("Type");
                    cmbVariable.Items.Add("UserId");
                    cmbVariable.Items.Add("UserName");
                    cmbVariable.Items.Add("ViewerCount");
                    cmbVariable.Items.Add("Channel");
                    cmbVariable.Items.Add("Hours");
                    cmbVariable.Items.Add("Minutes");
                    cmbVariable.Items.Add("Seconds");
                    break;
                case 1:
                    //OnStreamOffline
                    cmbVariable.Items.Add("GameId");
                    //cmbVariable.Items.Add("StreamId");
                    cmbVariable.Items.Add("Language");
                    cmbVariable.Items.Add("StartedAt");
                    cmbVariable.Items.Add("Title");
                    cmbVariable.Items.Add("Type");
                    cmbVariable.Items.Add("UserId");
                    cmbVariable.Items.Add("UserName");
                    cmbVariable.Items.Add("ViewerCount");
                    cmbVariable.Items.Add("Channel");
                    cmbVariable.Items.Add("Hours");
                    cmbVariable.Items.Add("Minutes");
                    cmbVariable.Items.Add("Seconds");
                    break;
                case 2:
                    //OnStreamUpdate
                    cmbVariable.Items.Add("Channel");
                    cmbVariable.Items.Add("GameId");
                    //cmbVariable.Items.Add("Id");
                    cmbVariable.Items.Add("Language");
                    cmbVariable.Items.Add("StartedAt");
                    cmbVariable.Items.Add("Title");
                    cmbVariable.Items.Add("Type");
                    cmbVariable.Items.Add("UserID");
                    cmbVariable.Items.Add("UserName");
                    cmbVariable.Items.Add("ViewerCount");
                    cmbVariable.Items.Add("Hours");
                    cmbVariable.Items.Add("Minutes");
                    cmbVariable.Items.Add("Seconds");
                    break;
                case 3:
                    //OnNewFollowersDetected
                    cmbVariable.Items.Add("Channel");
                    //Die Variablen, wenn ein neuer Follower erscheint
                    cmbVariable.Items.Add("NewFollowedAt");
                    cmbVariable.Items.Add("NewFromUserName");
                    cmbVariable.Items.Add("NewFromUserId");
                    cmbVariable.Items.Add("NewToUserId");
                    cmbVariable.Items.Add("NewToUserName");
                    break;
                case 4:
                    //OnMessageReceived
                    cmbVariable.Items.Add("Badges");
                    cmbVariable.Items.Add("BotUsername");
                    cmbVariable.Items.Add("ColorHex");
                    cmbVariable.Items.Add("DisplayName");
                    cmbVariable.Items.Add("IsTurbo");
                    cmbVariable.Items.Add("Message");
                    cmbVariable.Items.Add("MessageId");
                    cmbVariable.Items.Add("ThreadId");
                    cmbVariable.Items.Add("UserId");
                    cmbVariable.Items.Add("Username");
                    cmbVariable.Items.Add("UserType");
                    //die Variable "EmoteSet" ist eine Liste aller Emotes und deren Eigenschaften, die in User besitzt
                    cmbVariable.Items.Add("Emotes-List");
                    //Die Farbe wird im Datentyp Color abgespeicher, die dann auch andere Methoden für die einzelnen RGB-Werte besitzt
                    cmbVariable.Items.Add("Color-ColorTyp");
                    break;
                case 5:
                    //5 = OnWhisperReceived
                    cmbVariable.Items.Add("Badges");
                    cmbVariable.Items.Add("BotUsername");
                    cmbVariable.Items.Add("ColorHex");
                    cmbVariable.Items.Add("DisplayName");
                    cmbVariable.Items.Add("IsTurbo");
                    cmbVariable.Items.Add("Message");
                    cmbVariable.Items.Add("MessageId");
                    cmbVariable.Items.Add("ThreadId");
                    cmbVariable.Items.Add("UserId");
                    cmbVariable.Items.Add("Username");
                    cmbVariable.Items.Add("UserType");
                    //die Variable "EmoteSet" ist eine Liste aller Emotes und deren Eigenschaften, die in User besitzt
                    cmbVariable.Items.Add("Emotes-List");
                    //Die Farbe wird im Datentyp Color abgespeicher, die dann auch andere Methoden für die einzelnen RGB-Werte besitzt
                    cmbVariable.Items.Add("Color-ColorTyp");
                    break;
                case 6:
                    //6 = OnNewSubscriber
                    cmbVariable.Items.Add("Subscriber-Channel");
                    cmbVariable.Items.Add("DisplayName");
                    cmbVariable.Items.Add("ResubMessage");
                    cmbVariable.Items.Add("UserId");
                    cmbVariable.Items.Add("SystemMessage");
                    cmbVariable.Items.Add("SystemMessageParsed");
                    cmbVariable.Items.Add("RawIrc");
                    cmbVariable.Items.Add("MsgParamStreakMonths");
                    cmbVariable.Items.Add("MsgParamCumulativeMonths");
                    cmbVariable.Items.Add("MsgId");
                    cmbVariable.Items.Add("Channel");
                    break;
                case 7:
                    //7 = OnConnected
                    cmbVariable.Items.Add("BotUsername");
                    cmbVariable.Items.Add("AutoJoinChannel");
                    break;
                case 8:
                    //8 = OnBeingHosted
                    cmbVariable.Items.Add("Channel");
                    cmbVariable.Items.Add("HostedByChannel");
                    //cmbVariable.Items.Add("IsAutoHosted"); da dies nur eine Bool-Variable ist, die mit Replace nur ein Ja/Nein haben kann, wird die nicht mit ausgegeben
                    cmbVariable.Items.Add("Viewers");
                    cmbVariable.Items.Add("Viewers+1");
                    break;
                case 9:
                    //9 = OnRaidNotification
                    cmbVariable.Items.Add("DisplayName");;
                    cmbVariable.Items.Add("MsgParamDisplayName");
                    cmbVariable.Items.Add("MsgParamLogin");
                    cmbVariable.Items.Add("MsgParamViewerCount");
                    //cmbVariable.Items.Add("SystemMsg");
                    //cmbVariable.Items.Add("SystemMsgParsed");
                    cmbVariable.Items.Add("Game");
                    cmbVariable.Items.Add("Channel");
                    break;
                case 10:
                    //10 = OnJoinedChannel
                    cmbVariable.Items.Add("Channel");
                    cmbVariable.Items.Add("BotuserName");
                    break;
                case 11:
                    //11 = OnUserJoined
                    cmbVariable.Items.Add("Channel");
                    cmbVariable.Items.Add("Username");
                    break;
                case 12:
                    //12 = OnExistingUsersDetected
                    cmbVariable.Items.Add("Users"); //Dies ist ne Liste
                    cmbVariable.Items.Add("Channel");
                    break;
                case 13:
                    //13 = OnRewardRedeemed
                    cmbVariable.Items.Add("Name");
                    cmbVariable.Items.Add("Message");
                    cmbVariable.Items.Add("Reward-Title");
                    cmbVariable.Items.Add("Reward-Cost");
                    break;
                case 14:
                    //14 = OnRaidGo
                    cmbVariable.Items.Add("TargetName");
                    cmbVariable.Items.Add("ViewerCount");
                    break;
                case 15:
                    //15 = OnUserLeft
                    cmbVariable.Items.Add("Channel");
                    cmbVariable.Items.Add("Username");
                    break;
                case 16:
                    //16 = OnClipCreated
                    cmbVariable.Items.Add("BroadcasterId");
                    cmbVariable.Items.Add("CreatedAtTag");
                    cmbVariable.Items.Add("CreatedAtUhr");
                    cmbVariable.Items.Add("CreatorName");
                    cmbVariable.Items.Add("GameId");
                    cmbVariable.Items.Add("Title");
                    cmbVariable.Items.Add("Url");
                    break;
            }

            cmbVariable.Items.Add("---------------------------------");

            /*
             * Das hier ist die Switch-Prüfung für die Variablen, die es für die einzelnen Ziele (Twitch, Discord, Konsole) gibt
            switch (iVariablenInhaltTextFeld) { 
            
            }
            */
        }

        private void btnÜbernehmen_Click(object sender, EventArgs e)
        {
            bool Validierung = false;
            if (SettingsGroup.Instance.Tschat_read && SettingsGroup.Instance.Tschat_edit)
            {
                switch (LstEvents.SelectedIndex)
                {
                    case 0:
                        SettingsGroup.Instance.TeOnStreamOnlineUse = chkUse.Checked;
                        SettingsGroup.Instance.TeOnStreamOnlineChat = chkTextReaction.Checked;
                        SettingsGroup.Instance.TeOnStreamOnlineChatText = txtChatReaktion.Text;
                        SettingsGroup.Instance.TeOnStreamOnlineDiscord = chkDiscordAusgabe.Checked;
                        SettingsGroup.Instance.TeOnStreamOnlineDiscordText = txtDiscordChat.Text;
                        SettingsGroup.Instance.TeOnStreamOnlineKonsole = chkKonsoleAusgabe.Checked;
                        SettingsGroup.Instance.TeOnStreamOnlineKonsoleText = txtKonsolenFenster.Text;
                        if (SettingsGroup.Instance.TeOnStreamOnlineChannel.Count == 0 && chkDiscordAusgabe.Checked) {
                            Validierung = false;
                        }
                        else { Validierung = true; }
                        break;
                    case 1:
                        SettingsGroup.Instance.TeOnStreamOfflineUse = chkUse.Checked;
                        SettingsGroup.Instance.TeOnStreamOfflineChat = chkTextReaction.Checked;
                        SettingsGroup.Instance.TeOnStreamOfflineChatText = txtChatReaktion.Text;
                        SettingsGroup.Instance.TeOnStreamOfflineDiscord = chkDiscordAusgabe.Checked;
                        SettingsGroup.Instance.TeOnStreamOfflineDiscordText = txtDiscordChat.Text;
                        SettingsGroup.Instance.TeOnStreamOfflineKonsole = chkKonsoleAusgabe.Checked;
                        SettingsGroup.Instance.TeOnStreamOfflineKonsoleText = txtKonsolenFenster.Text;
                        if (SettingsGroup.Instance.TeOnStreamOfflineChannel.Count == 0 && chkDiscordAusgabe.Checked)
                        {
                            Validierung = false;
                        }
                        else { Validierung = true; }
                        break;
                    case 2:
                        SettingsGroup.Instance.TeOnStreamUpdateUse = chkUse.Checked;
                        SettingsGroup.Instance.TeOnStreamUpdateChat = chkTextReaction.Checked;
                        SettingsGroup.Instance.TeOnStreamUpdateChatText = txtChatReaktion.Text;
                        SettingsGroup.Instance.TeOnStreamUpdateDiscord = chkDiscordAusgabe.Checked;
                        SettingsGroup.Instance.TeOnStreamUpdateDiscordText = txtDiscordChat.Text;
                        SettingsGroup.Instance.TeOnStreamUpdateKonsole = chkKonsoleAusgabe.Checked;
                        SettingsGroup.Instance.TeOnStreamUpdateKonsoleText = txtKonsolenFenster.Text;
                        if (SettingsGroup.Instance.TeOnStreamUpdateChannel.Count == 0 && chkDiscordAusgabe.Checked)
                        {
                            Validierung = false;
                        }
                        else { Validierung = true; }
                        break;
                    case 3:
                        SettingsGroup.Instance.TeOnNewFollowersDetectedUse = chkUse.Checked;
                        SettingsGroup.Instance.TeOnNewFollowersDetectedChat = chkTextReaction.Checked;
                        SettingsGroup.Instance.TeOnNewFollowersDetectedChatText = txtChatReaktion.Text;
                        SettingsGroup.Instance.TeOnNewFollowersDetectedDiscord = chkDiscordAusgabe.Checked;
                        SettingsGroup.Instance.TeOnNewFollowersDetectedDiscordText = txtDiscordChat.Text;
                        SettingsGroup.Instance.TeOnNewFollowersDetectedKonsole = chkKonsoleAusgabe.Checked;
                        SettingsGroup.Instance.TeOnNewFollowersDetectedKonsoleText = txtKonsolenFenster.Text;
                        if (SettingsGroup.Instance.TeOnNewFollowersDetectedChannel.Count == 0 && chkDiscordAusgabe.Checked)
                        {
                            Validierung = false;
                        }
                        else { Validierung = true; }
                        break;
                    case 4:
                        SettingsGroup.Instance.TeOnMessageReceivedUse = chkUse.Checked;
                        SettingsGroup.Instance.TeOnMessageReceivedChat = chkTextReaction.Checked;
                        SettingsGroup.Instance.TeOnMessageReceivedChatText = txtChatReaktion.Text;
                        SettingsGroup.Instance.TeOnMessageReceivedDiscord = chkDiscordAusgabe.Checked;
                        SettingsGroup.Instance.TeOnMessageReceivedDiscordText = txtDiscordChat.Text;
                        SettingsGroup.Instance.TeOnMessageReceivedKonsole = chkKonsoleAusgabe.Checked;
                        SettingsGroup.Instance.TeOnMessageReceivedKonsoleText = txtKonsolenFenster.Text;
                        if (SettingsGroup.Instance.TeOnMessageReceivedChannel.Count == 0 && chkDiscordAusgabe.Checked)
                        {
                            Validierung = false;
                        }
                        else { Validierung = true; }
                        break;
                    case 5:
                        SettingsGroup.Instance.TeOnWhisperReceivedUse = chkUse.Checked;
                        SettingsGroup.Instance.TeOnWhisperReceivedChat = chkTextReaction.Checked;
                        SettingsGroup.Instance.TeOnWhisperReceivedChatText = txtChatReaktion.Text;
                        SettingsGroup.Instance.TeOnWhisperReceivedDiscord = chkDiscordAusgabe.Checked;
                        SettingsGroup.Instance.TeOnWhisperReceivedDiscordText = txtDiscordChat.Text;
                        SettingsGroup.Instance.TeOnWhisperReceivedKonsole = chkKonsoleAusgabe.Checked;
                        SettingsGroup.Instance.TeOnWhisperReceivedKonsoleText = txtKonsolenFenster.Text;
                        if (SettingsGroup.Instance.TeOnWhisperReceivedChannel.Count == 0 && chkDiscordAusgabe.Checked)
                        {
                            Validierung = false;
                        }
                        else { Validierung = true; }
                        break;
                    case 6:
                        SettingsGroup.Instance.TeOnNewSubscriberUse = chkUse.Checked;
                        SettingsGroup.Instance.TeOnNewSubscriberChat = chkTextReaction.Checked;
                        SettingsGroup.Instance.TeOnNewSubscriberChatText = txtChatReaktion.Text;
                        SettingsGroup.Instance.TeOnNewSubscriberDiscord = chkDiscordAusgabe.Checked;
                        SettingsGroup.Instance.TeOnNewSubscriberDiscordText = txtDiscordChat.Text;
                        SettingsGroup.Instance.TeOnNewSubscriberKonsole = chkKonsoleAusgabe.Checked;
                        SettingsGroup.Instance.TeOnNewSubscriberKonsoleText = txtKonsolenFenster.Text;
                        if (SettingsGroup.Instance.TeOnNewSubscriberChannel.Count == 0 && chkDiscordAusgabe.Checked)
                        {
                            Validierung = false;
                        }
                        else { Validierung = true; }
                        break;
                    case 7:
                        SettingsGroup.Instance.TeOnConnected.Use = chkUse.Checked;
                        SettingsGroup.Instance.TeOnConnected.Chat = chkTextReaction.Checked;
                        SettingsGroup.Instance.TeOnConnected.ChatText = txtChatReaktion.Text;
                        SettingsGroup.Instance.TeOnConnected.Discord = chkDiscordAusgabe.Checked;
                        SettingsGroup.Instance.TeOnConnected.DiscordText = txtDiscordChat.Text;
                        SettingsGroup.Instance.TeOnConnected.Konsole = chkKonsoleAusgabe.Checked;
                        SettingsGroup.Instance.TeOnConnected.KonsoleText = txtKonsolenFenster.Text;
                        if (SettingsGroup.Instance.TeOnConnected.Channel.Count == 0 && chkDiscordAusgabe.Checked)
                        {
                            Validierung = false;
                        }
                        else { Validierung = true; }
                        break;
                    case 8:
                        SettingsGroup.Instance.TeOnBeingHosted.Use = chkUse.Checked;
                        SettingsGroup.Instance.TeOnBeingHosted.Chat = chkTextReaction.Checked;
                        SettingsGroup.Instance.TeOnBeingHosted.ChatText = txtChatReaktion.Text;
                        SettingsGroup.Instance.TeOnBeingHosted.Discord = chkDiscordAusgabe.Checked;
                        SettingsGroup.Instance.TeOnBeingHosted.DiscordText = txtDiscordChat.Text;
                        SettingsGroup.Instance.TeOnBeingHosted.Konsole = chkKonsoleAusgabe.Checked;
                        SettingsGroup.Instance.TeOnBeingHosted.KonsoleText = txtKonsolenFenster.Text;
                        if (SettingsGroup.Instance.TeOnBeingHosted.Channel.Count == 0 && chkDiscordAusgabe.Checked)
                        {
                            Validierung = false;
                        }
                        else { Validierung = true; }
                        break;
                    case 9:
                        SettingsGroup.Instance.TeOnRaidNotificationUse = chkUse.Checked;
                        SettingsGroup.Instance.TeOnRaidNotificationChat = chkTextReaction.Checked;
                        SettingsGroup.Instance.TeOnRaidNotificationChatText = txtChatReaktion.Text;
                        SettingsGroup.Instance.TeOnRaidNotificationDiscord = chkDiscordAusgabe.Checked;
                        SettingsGroup.Instance.TeOnRaidNotificationDiscordText = txtDiscordChat.Text;
                        SettingsGroup.Instance.TeOnRaidNotificationKonsole = chkKonsoleAusgabe.Checked;
                        SettingsGroup.Instance.TeOnRaidNotificationKonsoleText = txtKonsolenFenster.Text;
                        if (SettingsGroup.Instance.TeOnRaidNotificationChannel.Count == 0 && chkDiscordAusgabe.Checked)
                        {
                            Validierung = false;
                        }
                        else { Validierung = true; }
                        break;
                    case 10:
                        SettingsGroup.Instance.TeOnJoinedChannel.Use = chkUse.Checked;
                        SettingsGroup.Instance.TeOnJoinedChannel.Chat = chkTextReaction.Checked;
                        SettingsGroup.Instance.TeOnJoinedChannel.ChatText = txtChatReaktion.Text;
                        SettingsGroup.Instance.TeOnJoinedChannel.Discord = chkDiscordAusgabe.Checked;
                        SettingsGroup.Instance.TeOnJoinedChannel.DiscordText = txtDiscordChat.Text;
                        SettingsGroup.Instance.TeOnJoinedChannel.Konsole = chkKonsoleAusgabe.Checked;
                        SettingsGroup.Instance.TeOnJoinedChannel.KonsoleText = txtKonsolenFenster.Text;
                        if (SettingsGroup.Instance.TeOnJoinedChannel.Channel.Count == 0 && chkDiscordAusgabe.Checked)
                        {
                            Validierung = false;
                        }
                        else { Validierung = true; }
                        break;
                    case 11:
                        SettingsGroup.Instance.TeOnUserJoinedUse = chkUse.Checked;
                        SettingsGroup.Instance.TeOnUserJoinedChat = chkTextReaction.Checked;
                        SettingsGroup.Instance.TeOnUserJoinedChatText = txtChatReaktion.Text;
                        SettingsGroup.Instance.TeOnUserJoinedDiscord = chkDiscordAusgabe.Checked;
                        SettingsGroup.Instance.TeOnUserJoinedDiscordText = txtDiscordChat.Text;
                        SettingsGroup.Instance.TeOnUserJoinedKonsole = chkKonsoleAusgabe.Checked;
                        SettingsGroup.Instance.TeOnUserJoinedKonsoleText = txtKonsolenFenster.Text;
                        if (SettingsGroup.Instance.TeOnUserJoinedChannel.Count == 0 && chkDiscordAusgabe.Checked)
                        {
                            Validierung = false;
                        }
                        else { Validierung = true; }
                        break;
                    case 12:
                        SettingsGroup.Instance.TeOnExistingUsersDetected.Use = chkUse.Checked;
                        SettingsGroup.Instance.TeOnExistingUsersDetected.Chat = chkTextReaction.Checked;
                        SettingsGroup.Instance.TeOnExistingUsersDetected.ChatText = txtChatReaktion.Text;
                        SettingsGroup.Instance.TeOnExistingUsersDetected.Discord = chkDiscordAusgabe.Checked;
                        SettingsGroup.Instance.TeOnExistingUsersDetected.DiscordText = txtDiscordChat.Text;
                        SettingsGroup.Instance.TeOnExistingUsersDetected.Konsole = chkKonsoleAusgabe.Checked;
                        SettingsGroup.Instance.TeOnExistingUsersDetected.KonsoleText = txtKonsolenFenster.Text;
                        if (SettingsGroup.Instance.TeOnExistingUsersDetected.Channel.Count == 0 && chkDiscordAusgabe.Checked)
                        {
                            Validierung = false;
                        }
                        else { Validierung = true; }
                        break;
                    case 13:
                        if (SettingsGroup.Instance.Tschannel_read_redemptions)
                        {
                            SettingsGroup.Instance.TeOnRewardRedeemedUse = chkUse.Checked;
                            SettingsGroup.Instance.TeOnRewardRedeemedChat = chkTextReaction.Checked;
                            SettingsGroup.Instance.TeOnRewardRedeemedChatText = txtChatReaktion.Text;
                            SettingsGroup.Instance.TeOnRewardRedeemedDiscord = chkDiscordAusgabe.Checked;
                            SettingsGroup.Instance.TeOnRewardRedeemedDiscordText = txtDiscordChat.Text;
                            SettingsGroup.Instance.TeOnRewardRedeemedKonsole = chkKonsoleAusgabe.Checked;
                            SettingsGroup.Instance.TeOnRewardRedeemedKonsoleText = txtKonsolenFenster.Text;
                            if (SettingsGroup.Instance.TeOnRewardRedeemedChannel.Count == 0 && chkDiscordAusgabe.Checked)
                            {
                                Validierung = false;
                            }
                            else { Validierung = true; }
                        }
                        else
                        {
                            MessageBox.Show("Der Bot besitzt nicht die Berechtigung für 'channel_read_redemptions'. Ein Einstellen ist nicht möglich", "Fehlende Berechtigung", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Validierung = false;
                        }
                        break;
                    case 14:
                        if (SettingsGroup.Instance.Tsuser_edit)
                        {
                            SettingsGroup.Instance.TeOnRaidGoUse = chkUse.Checked;
                            SettingsGroup.Instance.TeOnRaidGoChat = chkTextReaction.Checked;
                            SettingsGroup.Instance.TeOnRaidGoChatText = txtChatReaktion.Text;
                            SettingsGroup.Instance.TeOnRaidGoDiscord = chkDiscordAusgabe.Checked;
                            SettingsGroup.Instance.TeOnRaidGoDiscordText = txtDiscordChat.Text;
                            SettingsGroup.Instance.TeOnRaidGoKonsole = chkKonsoleAusgabe.Checked;
                            SettingsGroup.Instance.TeOnRaidGoKonsoleText = txtKonsolenFenster.Text;
                            if (SettingsGroup.Instance.TeOnRaidGoChannel.Count == 0 && chkDiscordAusgabe.Checked)
                            {
                                Validierung = false;
                            }
                            else { Validierung = true; }
                        }
                        else
                        {
                            MessageBox.Show("Der Bot besitzt nicht die Berechtigung für 'user_edit'. Ein Einstellen ist nicht möglich", "Fehlende Berechtigung", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Validierung = false;
                        }
                        break;
                    case 15:
                        SettingsGroup.Instance.TeOnUserLeftUse = chkUse.Checked;
                        SettingsGroup.Instance.TeOnUserLeftChat = chkTextReaction.Checked;
                        SettingsGroup.Instance.TeOnUserLeftChatText = txtChatReaktion.Text;
                        SettingsGroup.Instance.TeOnUserLeftDiscord = chkDiscordAusgabe.Checked;
                        SettingsGroup.Instance.TeOnUserLeftDiscordText = txtDiscordChat.Text;
                        SettingsGroup.Instance.TeOnUserLeftKonsole = chkKonsoleAusgabe.Checked;
                        SettingsGroup.Instance.TeOnUserLeftKonsoleText = txtKonsolenFenster.Text;
                        if (SettingsGroup.Instance.TeOnUserJoinedChannel.Count == 0 && chkDiscordAusgabe.Checked)
                        {
                            Validierung = false;
                        }
                        else { Validierung = true; }
                        break;
                    case 16:
                        SettingsGroup.Instance.TeOnClipCreated.Use = chkUse.Checked;
                        SettingsGroup.Instance.TeOnClipCreated.Chat = chkTextReaction.Checked;
                        SettingsGroup.Instance.TeOnClipCreated.ChatText = txtChatReaktion.Text;
                        SettingsGroup.Instance.TeOnClipCreated.Discord = chkDiscordAusgabe.Checked;
                        SettingsGroup.Instance.TeOnClipCreated.DiscordText = txtDiscordChat.Text;
                        SettingsGroup.Instance.TeOnClipCreated.Konsole = chkKonsoleAusgabe.Checked;
                        SettingsGroup.Instance.TeOnClipCreated.KonsoleText = txtKonsolenFenster.Text;
                        if (SettingsGroup.Instance.TeOnClipCreated.Channel.Count == 0 && chkDiscordAusgabe.Checked)
                        {
                            Validierung = false;
                        }
                        else { Validierung = true; }
                        break;
                }

                if (Validierung == true)
                {
                    SettingsGroup.Instance.Save();
                    Änderungchange(false);
                }
                else {
                    MessageBox.Show("Es wurde eine Discord-Nachricht eingestellt, aber keine Channels. Bitte wähle Channels aus", "Fehlende Kanäle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else {
                MessageBox.Show("Der Bot besitzt nicht die Standard-Berechtigungen für 'chat_read' und 'chat_edit'. Ein Einstellen ist nicht möglich", "Fehlende Berechtigung", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDiscordChannel_Click(object sender, EventArgs e)
        {
            using (DiscordChannelAuswahl Fenster = new DiscordChannelAuswahl())
            {

                switch (LstEvents.SelectedIndex)
                {
                    case 0:
                        Fenster.Channels = SettingsGroup.Instance.TeOnStreamOnlineChannel;
                        break;
                    case 1:
                        Fenster.Channels = SettingsGroup.Instance.TeOnStreamOfflineChannel;
                        break;
                    case 2:
                        Fenster.Channels = SettingsGroup.Instance.TeOnStreamUpdateChannel;
                        break;
                    case 3:
                        Fenster.Channels = SettingsGroup.Instance.TeOnNewFollowersDetectedChannel;
                        break;
                    case 4:
                        Fenster.Channels = SettingsGroup.Instance.TeOnMessageReceivedChannel;
                        break;
                    case 5:
                        Fenster.Channels = SettingsGroup.Instance.TeOnWhisperReceivedChannel;
                        break;
                    case 6:
                        Fenster.Channels = SettingsGroup.Instance.TeOnNewSubscriberChannel;
                        break;
                    case 7:
                        Fenster.Channels = SettingsGroup.Instance.TeOnConnected.Channel;
                        break;
                    case 8:
                        Fenster.Channels = SettingsGroup.Instance.TeOnBeingHosted.Channel;
                        break;
                    case 9:
                        Fenster.Channels = SettingsGroup.Instance.TeOnRaidNotificationChannel;
                        break;
                    case 10:
                        Fenster.Channels = SettingsGroup.Instance.TeOnJoinedChannel.Channel;
                        break;
                    case 11:
                        Fenster.Channels = SettingsGroup.Instance.TeOnUserJoinedChannel;
                        break;
                    case 12:
                        Fenster.Channels = SettingsGroup.Instance.TeOnExistingUsersDetected.Channel;
                        break;
                    case 13:
                        Fenster.Channels = SettingsGroup.Instance.TeOnRewardRedeemedChannel;
                        break;
                    case 14:
                        Fenster.Channels = SettingsGroup.Instance.TeOnRaidGoChannel;
                        break;
                    case 15:
                        Fenster.Channels = SettingsGroup.Instance.TeOnUserLeftChannel;
                        break;
                    case 16:
                        Fenster.Channels = SettingsGroup.Instance.TeOnClipCreated.Channel;
                        break;
                }

                DialogResult dr = Fenster.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    switch (LstEvents.SelectedIndex)
                    {
                        case 0:
                            SettingsGroup.Instance.TeOnStreamOnlineChannel = Fenster.Channels;
                            break;
                        case 1:
                            SettingsGroup.Instance.TeOnStreamOfflineChannel = Fenster.Channels;
                            break;
                        case 2:
                            SettingsGroup.Instance.TeOnStreamUpdateChannel = Fenster.Channels;
                            break;
                        case 3:
                            SettingsGroup.Instance.TeOnNewFollowersDetectedChannel = Fenster.Channels;
                            break;
                        case 4:
                            SettingsGroup.Instance.TeOnMessageReceivedChannel = Fenster.Channels;
                            break;
                        case 5:
                            SettingsGroup.Instance.TeOnWhisperReceivedChannel = Fenster.Channels;
                            break;
                        case 6:
                            SettingsGroup.Instance.TeOnNewSubscriberChannel = Fenster.Channels;
                            break;
                        case 7:
                            SettingsGroup.Instance.TeOnConnected.Channel = Fenster.Channels;
                            break;
                        case 8:
                            SettingsGroup.Instance.TeOnBeingHosted.Channel = Fenster.Channels;
                            break;
                        case 9:
                            SettingsGroup.Instance.TeOnRaidNotificationChannel = Fenster.Channels;
                            break;
                        case 10:
                            SettingsGroup.Instance.TeOnJoinedChannel.Channel = Fenster.Channels;
                            break;
                        case 11:
                            SettingsGroup.Instance.TeOnUserJoinedChannel = Fenster.Channels;
                            break;
                        case 12:
                            SettingsGroup.Instance.TeOnExistingUsersDetected.Channel = Fenster.Channels;
                            break;
                        case 13:
                            SettingsGroup.Instance.TeOnRewardRedeemedChannel = Fenster.Channels;
                            break;
                        case 14:
                            SettingsGroup.Instance.TeOnRaidGoChannel = Fenster.Channels;
                            break;
                        case 15:
                            SettingsGroup.Instance.TeOnUserLeftChannel = Fenster.Channels;
                            break;
                        case 16:
                            SettingsGroup.Instance.TeOnClipCreated.Channel = Fenster.Channels;
                            break;
                    }
                    SettingsGroup.Instance.Save();
                    Änderungchange(true);
                }

            }

        }

        private void LstEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bÄnderung == true && bÄnderungAusIndex == false)
            {
                if (MessageBox.Show("Es sind nicht gespeicherte Änderungen vorhanden. Fortfahren?", "Achtung", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    IndexChange();
                    bÄnderungAusIndex = true; //Damit wird festgestellt, dass die Änderung der Felder durch den Index erfolgt ist. Diese Änderungen in den Felern, die in diesem Fall keine sind, werden nicht als zu Speichern angezeigt.
                }
                else
                {
                    bÄnderungAusIndex = true; //Damit die MessageBox der Abfrage nicht zweimal erscheint
                    LstEvents.SelectedIndex = iAltIndex;

                    Änderungchange(true);
                }
            }
            else if (LstEvents.SelectedIndex != iAltIndex)
            { //Wenn sich der Index geändert hat, sollen sich die Daten aktualisieren. Umgekehrt, würden nicht gespeicherte Änderungen verloren gehen
                IndexChange();
                bÄnderungAusIndex = true; //Damit wird festgestellt, dass die Änderung der Felder durch den Index erfolgt ist. Diese Änderungen in den Felern, die in diesem Fall keine sind, werden nicht als zu Speichern angezeigt.

            }
        }

        private void chkUse_CheckedChanged(object sender, EventArgs e)
        {
            grpEvent.Enabled = chkUse.Checked;
            Änderungchange(true);
        }

        private void btnVariable_Click(object sender, EventArgs e)
        {
            if (cmbVariable.Text != "---------------------------------") //"---------------------------------" Dient als Platzhalter zwischen den Event-Variablen und den Feldeigenen Variablen, daher soll dieser nicht eingefügt werden können
            {
                switch (iEventIndex)
                {
                    case 1:
                        txtChatReaktion.Text = txtChatReaktion.Text + "°" + cmbVariable.Text;
                        break;
                    case 2:
                        txtKonsolenFenster.Text = txtKonsolenFenster.Text + "°" + cmbVariable.Text;
                        break;
                    case 3:
                        txtDiscordChat.Text = txtDiscordChat.Text + "°" + cmbVariable.Text;
                        break;
                }
            }
        }

        private void txtChatReaktion_MouseClick(object sender, MouseEventArgs e)
        {
            iEventIndex = 1;
        }

        private void txtKonsolenFenster_MouseClick(object sender, MouseEventArgs e)
        {
            iEventIndex = 2;
        }

        private void txtDiscordChat_MouseClick(object sender, MouseEventArgs e)
        {
            iEventIndex = 3;
        }

        private void Änderungchange(bool bArt) {

            if (bArt)
            {
                bÄnderung = true;
                bÄnderungAusIndex = false;
                btnÜbernehmen.BackColor = Color.Tomato;
            }
            else {
                bÄnderung = false;
                btnÜbernehmen.BackColor = Color.LightGreen;
            }
        }

        private void chkTextReaction_CheckedChanged(object sender, EventArgs e)
        {
            Änderungchange(true);
        }

        private void txtChatReaktion_TextChanged(object sender, EventArgs e)
        {
            Änderungchange(true);
        }

        private void chkKonsoleAusgabe_CheckedChanged(object sender, EventArgs e)
        {
            Änderungchange(true);
        }

        private void txtKonsolenFenster_TextChanged(object sender, EventArgs e)
        {
            Änderungchange(true);
        }

        private void chkDiscordAusgabe_CheckedChanged(object sender, EventArgs e)
        {
            Änderungchange(true);
            btnDiscordChannel.Enabled = chkDiscordAusgabe.Checked;
        }

        private void txtDiscordChat_TextChanged(object sender, EventArgs e)
        {
            Änderungchange(true);
        }

        #endregion

        #region Bits

        private void LoadBits() {
            String Path = Application.StartupPath + System.IO.Path.DirectorySeparatorChar + "BitListe.json";
            String InhaltJSON;

            if (File.Exists(Path))
            {
                //FileStream stream = File.OpenRead(Path);
                InhaltJSON = File.ReadAllText(Path);

                BitListe = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BitElement>>(InhaltJSON);

                foreach (var item in BitListe) {
                    if (BitsID < item.ID) {
                        BitsID = item.ID;
                    }
                }
                BitListeAktualisieren();
            }
        }
        private void SaveBits() {
            String Path = Application.StartupPath + System.IO.Path.DirectorySeparatorChar + "BitListe.json";
            String InhaltJSON = "";

            InhaltJSON += Newtonsoft.Json.JsonConvert.SerializeObject(BitListe);

            File.WriteAllText(Path, InhaltJSON);
        }

        private void chkBits_CheckedChanged(object sender, EventArgs e)
        {
            if (SettingsGroup.Instance.Tsbits_read)
            {
                grpBits.Enabled = chkBits.Checked;
                btnBitsSpeichern.BackColor = Color.Tomato;
            }
            else {
                MessageBox.Show("Der Bot besitzt nicht die Berechtigung für 'bits_read'. Ein Einstellen ist nicht möglich", "Fehlende Berechtigung", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstBitMengen_SelectedIndexChanged(object sender, EventArgs e)
        {
            Match ListEintrag = Regex.Match(lstBitMengen.SelectedItem.ToString(), ListPattern);

            if (ListEintrag.Success == false) {
                ListEintrag = Regex.Match(lstBitMengen.SelectedItem.ToString(), ListPatternEinzel);
            }

            int ausgewählteID = Convert.ToInt32(ListEintrag.Groups[1].Value);
            foreach (var item in BitListe)
            {
                if (item.ID == ausgewählteID)
                {
                    BitAuswahl = item;
                }
            }
            nudAbBetrag.Value = BitAuswahl.AbBetrag;

            chkKeinBereich.Checked = BitAuswahl.KeinBereich;

            if (BitAuswahl.KeinBereich)
            {
                chkBitsMaximum.Checked = false;
                chkBitsMaximum.Enabled = false;
                nudBisBetrag.Enabled = false;
            }
            else
            {
                nudBisBetrag.Value = BitAuswahl.BisBetrag;
            }
            
            chkBitsMaximum.Checked = BitAuswahl.bisMaximum;
            chkBitsKonsole.Checked = BitAuswahl.AusgabeKonsole;
            txtBitsChatText.Text = BitAuswahl.ChatText;
            txtBitsSoundPfad.Text = BitAuswahl.SoundPfad;
            chkBitsSound.Checked = BitAuswahl.Sound;
            
            BitsID = BitAuswahl.ID;

            btnBitsLöschen.Enabled = true;
            btnBitsUebernehmen.Enabled = true;


            if (chkBitsMaximum.Checked)
            {
                chkKeinBereich.Checked = false;
                chkKeinBereich.Enabled = false;
                nudBisBetrag.Enabled = false;
            }
            btnBitSoundAuswahl.Enabled = chkBitsSound.Checked;
            btnTestSound.Enabled = chkBitsSound.Checked;

            grpBitsEditor.Enabled = true;
            
        }

        private void btnBitsNeu_Click(object sender, EventArgs e)
        {
            grpBitsEditor.Enabled =true;
            BitAuswahl = new BitElement();
            BitsID += 1;
            nudBisBetrag.Value = 1;
            nudAbBetrag.Value = 1;
            txtBitsChatText.Text = "";
            chkBitsKonsole.Checked = false;
            chkBitsMaximum.Checked = false;
            chkKeinBereich.Checked = false;
            chkBitsSound.Checked = false;

            btnBitsLöschen.Enabled = true;
            btnBitsUebernehmen.Enabled = true;
        }

        private void btnBitsUebernehmen_Click(object sender, EventArgs e)
        {
            bool Validierung = false;

            BitAuswahl.AbBetrag = decimal.ToInt32(nudAbBetrag.Value);
            BitAuswahl.BisBetrag = decimal.ToInt32(nudBisBetrag.Value);
            BitAuswahl.bisMaximum = chkBitsMaximum.Checked;
            BitAuswahl.AusgabeKonsole = chkBitsKonsole.Checked;
            BitAuswahl.ChatText = txtBitsChatText.Text;
            BitAuswahl.SoundPfad = txtBitsSoundPfad.Text;
            BitAuswahl.Sound = chkBitsSound.Checked;
            BitAuswahl.KeinBereich = chkKeinBereich.Checked;
            BitAuswahl.ID = BitsID;

            if (BitAuswahl.bisMaximum) {
                BitAuswahl.BisBetrag = int.MaxValue;
            }

            if (BitAuswahl.KeinBereich) {
                BitAuswahl.BisBetrag = 0;
                Validierung = true;
            }
            else
            {
                if (BitAuswahl.AbBetrag < BitAuswahl.BisBetrag)
                {
                    Validierung = true;
                }
                else
                {
                    Validierung = false;
                    MessageBox.Show("Der \"Ab\"-Beitrag ist größer als der \"Bis\"-Betrag." + Environment.NewLine + "Bitte pass die Einträge an.", "Validierung", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (BitAuswahl.Sound) {
                if (txtBitsSoundPfad.Text != null) {
                    Validierung = true;
                }
                else
                {
                    Validierung = false;
                    MessageBox.Show("Es soll ein Sound verwendet werden, aber es ist kein Pfad eingetragen." + Environment.NewLine + "Bitte trage den Pfad der Datei ein", "Validierung", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            if (Validierung == true)
            {
                //String Eintrag = string.Format("#{0} {1}-{2}", BitAuswahl.ID, BitAuswahl.AbBetrag, BitAuswahl.BisBetrag);
                bool BitUpdate=false;
                for (int i=0; i < BitListe.Count && BitUpdate == false; i++)
                {
                    if (BitListe[i].ID == BitAuswahl.ID) {
                        BitUpdate = true;
                        BitListe[i] = BitAuswahl;
                    }

                }

                if (BitUpdate==false)
                {
                    BitListe.Add(BitAuswahl);
                }
                

                //List<BitElement> SortierteListe = BitListe.OrderBy(o => o.AbBetrag).ToList();

                BitListe.Sort((x, y) => x.AbBetrag.CompareTo(y.AbBetrag));

                //BitListe = SortierteListe;
                BitListeAktualisieren();
                grpBitsEditor.Enabled = false;
                FelderReset();

                btnBitsSpeichern.BackColor = Color.Tomato;
                
            }
            else {
                BitAuswahl = new BitElement();
            }
        }
        private void BitListeAktualisieren() {
            lstBitMengen.Items.Clear();
            foreach (var item in BitListe)
            {
                if (item.KeinBereich) {
                    lstBitMengen.Items.Add(string.Format("#{0} {1}", item.ID, item.AbBetrag));
                }
                else
                {
                    lstBitMengen.Items.Add(string.Format("#{0} {1}-{2}", item.ID, item.AbBetrag, item.BisBetrag));
                }
            }
        }
        private void btnBitsLöschen_Click(object sender, EventArgs e)
        {
            Match ListEintrag = Regex.Match(lstBitMengen.SelectedItem.ToString(), ListPattern);

            if (ListEintrag.Success == false)
            {
                ListEintrag = Regex.Match(lstBitMengen.SelectedItem.ToString(), ListPatternEinzel);
            }
            int ausgewählteID = Convert.ToInt32(ListEintrag.Groups[1].Value);
            bool gefunden = false;

            foreach (var item in BitListe)
            {
                if (item.ID == ausgewählteID) {
                    BitAuswahl = item;
                    gefunden = true;
                }
            }
            if (gefunden) {
                BitListe.Remove(BitAuswahl);
                BitAuswahl = new BitElement();

                FelderReset();
                btnBitsSpeichern.BackColor = Color.Tomato;
            }

            BitListeAktualisieren();
        }
        private void FelderReset()
        {
            nudAbBetrag.Value = 1;
            nudAbBetrag.Enabled = true;
            nudBisBetrag.Value = 1;
            nudBisBetrag.Enabled = true;
            chkBitsKonsole.Checked = false;
            chkBitsMaximum.Checked = false;
            chkBitsMaximum.Enabled = true;
            chkBitsSound.Checked = false;
            chkKeinBereich.Enabled = true;
            chkKeinBereich.Checked = false;
            txtBitsChatText.Text = "";

        }

        private void chkKeinBereich_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKeinBereich.Checked)
            {
                chkBitsMaximum.Checked = false;
                chkBitsMaximum.Enabled = false;
                nudBisBetrag.Enabled = false;
            }
            else
            {
                chkBitsMaximum.Enabled = true;
                nudBisBetrag.Enabled = true;
            }
        }

        private void chkBitsMaximum_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBitsMaximum.Checked)
            {
                chkKeinBereich.Checked = false;
                chkKeinBereich.Enabled = false;
                nudBisBetrag.Enabled = false;
            }
            else
            {
                chkKeinBereich.Enabled = true;
                nudBisBetrag.Enabled = true;
            }
        }

        private void chkBitsSound_CheckedChanged(object sender, EventArgs e)
        {
            txtBitsSoundPfad.Enabled = chkBitsSound.Checked;
            btnBitSoundAuswahl.Enabled = chkBitsSound.Checked;
            btnTestSound.Enabled = chkBitsSound.Checked;
        }

        private void btnBitSoundAuswahl_Click(object sender, EventArgs e)
        {
            if (ofdBitSoundAuswahl.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    txtBitsSoundPfad.Text= ofdBitSoundAuswahl.FileName.ToString().Replace('\\', Path.DirectorySeparatorChar);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void btnBitsVariable_Click(object sender, EventArgs e)
        {
            if (cmbBitsVariable.Text != "") {
                txtBitsChatText.Text = txtBitsChatText.Text + "°" + cmbBitsVariable.Text;
            }
        }

        private void btnBitsSpeichern_Click(object sender, EventArgs e)
        {
            if (chkBits.Checked)
            {
                if (SettingsGroup.Instance.Tschat_read && SettingsGroup.Instance.Tschat_edit)
                {
                    if (SettingsGroup.Instance.Tsbits_read)
                    {
                        //Überprüfung, ob Werte doppelt vergeben sind
                        bool Doppelt = false;
                        foreach (var item in BitListe)
                        {
                            foreach (var item2 in BitListe)
                            {
                                if (item.ID != item2.ID) //Prüfung, damit das gleiche Item nicht verglichen wird mit sich selber. Dann laufen die Prüfungen auf True
                                {
                                    if (item2.KeinBereich)
                                    {
                                        if (item.AbBetrag == item2.AbBetrag)
                                        {
                                            Doppelt = true;
                                        }
                                    }
                                    else
                                    {
                                        if (item.AbBetrag >= item2.AbBetrag && item.AbBetrag <= item2.BisBetrag)
                                        {
                                            Doppelt = true;
                                        }
                                    }
                                }
                            }

                            if (Doppelt)
                            {
                                MessageBox.Show("Es sind Werte doppelt vergeben." + Environment.NewLine + "Bei der Ausgabe werden die Werte ausgegeben, die gefunden werden." + Environment.NewLine + "Soll dies nicht so sein, bitte die Werte anpassen", "Warnung: Doppelte Werte", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            SaveBits();
                            btnBitsSpeichern.BackColor = Color.LightGreen;
                            SettingsGroup.Instance.TeBitsReaction = chkBits.Checked;
                            SettingsGroup.Instance.Save();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Der Bot besitzt nicht die Berechtigung für 'bits_read'. Ein Einstellen ist nicht möglich", "Fehlende Berechtigung", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Der Bot besitzt nicht die Standard-Berechtigungen für 'chat_read' und 'chat_edit'. Ein Einstellen ist nicht möglich", "Fehlende Berechtigung", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else {
                SettingsGroup.Instance.TeBitsReaction = chkBits.Checked;
                SettingsGroup.Instance.Save();
            }
        }

        private void btnTestSound_Click(object sender, EventArgs e)
        {
            if (File.Exists(txtBitsSoundPfad.Text))
            {
                BitAuswahl.SoundPfad = txtBitsSoundPfad.Text;
                if (BitAuswahl.playSound())
                {
                    MessageBox.Show("Bit-Sound wurde abgespielt","Test",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    //Rückgabewert true bedeutet, dass der Sound abgespielt wird
                }
                else
                {
                    MessageBox.Show("Bit-Sound wurde nicht abgespielt", "Test", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    //Rückgabewert false bedeutet, dass der Sound nicht gefunden wurde
                }
            }
            else {
                MessageBox.Show("Angegebener Pfad ist nicht verfügbar. Bitte eine vorhandene Datei auswählen.", "Datei nicht gefunden", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region TwitchAdminBefehle
        private void lstAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbAdminVariable.Items.Clear();
            switch (cmbAdmin.SelectedItem) {
                case "Update StreamTitle":
                    chkAdminUse.Checked = SettingsGroup.Instance.TeUpdateTitle.Use;
                    txtAdminKommando.Text = SettingsGroup.Instance.TeUpdateTitle.Command;
                    txtAdminChat.Text = SettingsGroup.Instance.TeUpdateTitle.ChatText;
                    txtAdminFalsch.Text = SettingsGroup.Instance.TeUpdateTitle.FailText;
                    chkForAdmin.Checked = SettingsGroup.Instance.TeUpdateTitle.Admin;
                    chkBroadcaster.Checked = SettingsGroup.Instance.TeUpdateTitle.Boardcast;
                    chkVIP.Checked = SettingsGroup.Instance.TeUpdateTitle.VIP;

                    cmbAdminVariable.Items.Add("AltTitel");
                    cmbAdminVariable.Items.Add("NeuTitel");
                    cmbAdminVariable.Items.Add("User");
                    cmbAdminVariable.Items.Add("Exception");
                    break;
                case "Update StreamGame":
                    chkAdminUse.Checked = SettingsGroup.Instance.TeUpdateGame.Use;
                    txtAdminKommando.Text = SettingsGroup.Instance.TeUpdateGame.Command;
                    txtAdminChat.Text = SettingsGroup.Instance.TeUpdateGame.ChatText;
                    txtAdminFalsch.Text = SettingsGroup.Instance.TeUpdateGame.FailText;
                    chkForAdmin.Checked = SettingsGroup.Instance.TeUpdateGame.Admin;
                    chkBroadcaster.Checked = SettingsGroup.Instance.TeUpdateGame.Boardcast;
                    chkVIP.Checked = SettingsGroup.Instance.TeUpdateGame.VIP;

                    cmbAdminVariable.Items.Add("AltGame");
                    cmbAdminVariable.Items.Add("NeuGame");
                    cmbAdminVariable.Items.Add("User");
                    break;
                case "Update GoRaid-Message":
                    chkAdminUse.Checked = SettingsGroup.Instance.TeGoRaid.Use;
                    txtAdminKommando.Text = SettingsGroup.Instance.TeGoRaid.Command;
                    txtAdminChat.Text = SettingsGroup.Instance.TeGoRaid.ChatText;
                    txtAdminFalsch.Text = SettingsGroup.Instance.TeGoRaid.FailText;
                    chkForAdmin.Checked = SettingsGroup.Instance.TeGoRaid.Admin;
                    chkBroadcaster.Checked = SettingsGroup.Instance.TeGoRaid.Boardcast;
                    chkVIP.Checked = SettingsGroup.Instance.TeGoRaid.VIP;

                    cmbAdminVariable.Items.Add("NeuText");
                    cmbAdminVariable.Items.Add("User");
                    break;
                case "ShoutOut":
                    chkAdminUse.Checked = SettingsGroup.Instance.TeSO.Use;
                    chkAdminUse.Checked = SettingsGroup.Instance.TeSO.Use;
                    txtAdminKommando.Text = SettingsGroup.Instance.TeSO.Command;
                    txtAdminChat.Text = SettingsGroup.Instance.TeSO.ChatText;
                    txtAdminFalsch.Text = SettingsGroup.Instance.TeSO.FailText;
                    chkForAdmin.Checked = SettingsGroup.Instance.TeSO.Admin;
                    chkBroadcaster.Checked = SettingsGroup.Instance.TeSO.Boardcast;
                    chkVIP.Checked = SettingsGroup.Instance.TeSO.VIP;

                    cmbAdminVariable.Items.Add("TargetName");
                    cmbAdminVariable.Items.Add("TargetFollowers");
                    cmbAdminVariable.Items.Add("TargetGame");
                    cmbAdminVariable.Items.Add("TargetUrl");
                    cmbAdminVariable.Items.Add("User");
                    break;
                case "CreateClip":
                    chkAdminUse.Checked = SettingsGroup.Instance.TeClipCreate.Use;
                    txtAdminKommando.Text = SettingsGroup.Instance.TeClipCreate.Command;
                    txtAdminChat.Text = SettingsGroup.Instance.TeClipCreate.ChatText;
                    txtAdminFalsch.Text = SettingsGroup.Instance.TeClipCreate.FailText;
                    chkForAdmin.Checked = SettingsGroup.Instance.TeClipCreate.Admin;
                    chkBroadcaster.Checked = SettingsGroup.Instance.TeClipCreate.Boardcast;
                    chkVIP.Checked = SettingsGroup.Instance.TeClipCreate.VIP;
                    break;
                case "Skill - Mainquest":
                    chkAdminUse.Checked = SettingsGroup.Instance.SkillMain.Use;
                    txtAdminKommando.Text = SettingsGroup.Instance.SkillMain.Command;
                    txtAdminChat.Text = SettingsGroup.Instance.SkillMain.ChatText;
                    txtAdminFalsch.Text = SettingsGroup.Instance.SkillMain.FailText;
                    chkForAdmin.Checked = SettingsGroup.Instance.SkillMain.Admin;
                    chkBroadcaster.Checked = SettingsGroup.Instance.SkillMain.Boardcast;
                    chkVIP.Checked = SettingsGroup.Instance.SkillMain.VIP;
                    break;
                case "Skill - Subquest":
                    break;
                case "Skill - Clear":
                    break;
                case "Skill - Status":
                    break;
                case "Skill - Update":
                    break;
                case "Skill - List":
                    break;

            }
            grpAdmin.Enabled = true;
        }

        private void btnAdminSpeichern_Click(object sender, EventArgs e)
        {
            if (SettingsGroup.Instance.Tschat_read && SettingsGroup.Instance.Tschat_edit)
            {
                switch (cmbAdmin.SelectedItem)
                {
                    case "Update StreamTitle":
                        if (SettingsGroup.Instance.Tschannel_editor && SettingsGroup.Instance.Tsuser_edit_broadcast)
                        {
                            SettingsGroup.Instance.TeUpdateTitle.Use = chkAdminUse.Checked;
                            SettingsGroup.Instance.TeUpdateTitle.Command = txtAdminKommando.Text;
                            SettingsGroup.Instance.TeUpdateTitle.ChatText = txtAdminChat.Text;
                            SettingsGroup.Instance.TeUpdateTitle.FailText = txtAdminFalsch.Text;
                            SettingsGroup.Instance.TeUpdateTitle.Admin = chkForAdmin.Checked;
                            SettingsGroup.Instance.TeUpdateTitle.Boardcast = chkBroadcaster.Checked;
                            SettingsGroup.Instance.TeUpdateTitle.VIP = chkVIP.Checked;
                        }
                        else
                        {
                            MessageBox.Show("Der Bot besitzt nicht die Berechtigungen für 'channel_editor' und 'User:edit:broadcast'. Ein Einstellen ist nicht möglich", "Fehlende Berechtigung", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case "Update StreamGame":
                        if (SettingsGroup.Instance.Tschannel_editor && SettingsGroup.Instance.Tsuser_edit_broadcast)
                        {
                            SettingsGroup.Instance.TeUpdateGame.Use = chkAdminUse.Checked;
                            SettingsGroup.Instance.TeUpdateGame.Command = txtAdminKommando.Text;
                            SettingsGroup.Instance.TeUpdateGame.ChatText = txtAdminChat.Text;
                            SettingsGroup.Instance.TeUpdateGame.FailText = txtAdminFalsch.Text;
                            SettingsGroup.Instance.TeUpdateGame.Admin = chkForAdmin.Checked;
                            SettingsGroup.Instance.TeUpdateGame.Boardcast = chkBroadcaster.Checked;
                            SettingsGroup.Instance.TeUpdateGame.VIP = chkVIP.Checked;
                        }
                        else
                        {
                            MessageBox.Show("Der Bot besitzt nicht die Berechtigungen für 'channel_editor' und 'User:edit:broadcast'. Ein Einstellen ist nicht möglich", "Fehlende Berechtigung", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case "Update GoRaid-Message":
                        if (SettingsGroup.Instance.Tsuser_edit)
                        {
                            SettingsGroup.Instance.TeGoRaid.Use = chkAdminUse.Checked;
                            SettingsGroup.Instance.TeGoRaid.Command = txtAdminKommando.Text;
                            SettingsGroup.Instance.TeGoRaid.ChatText = txtAdminChat.Text;
                            SettingsGroup.Instance.TeGoRaid.FailText = txtAdminFalsch.Text;
                            SettingsGroup.Instance.TeGoRaid.Admin = chkForAdmin.Checked;
                            SettingsGroup.Instance.TeGoRaid.Boardcast = chkBroadcaster.Checked;
                            SettingsGroup.Instance.TeGoRaid.VIP = chkVIP.Checked;
                        }
                        else
                        {
                            MessageBox.Show("Der Bot besitzt nicht die Berechtigung für 'user_edit'. Ein Einstellen ist nicht möglich", "Fehlende Berechtigung", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case "ShoutOut":
                        SettingsGroup.Instance.TeSO.Use = chkAdminUse.Checked;
                        SettingsGroup.Instance.TeSO.Command = txtAdminKommando.Text;
                        SettingsGroup.Instance.TeSO.ChatText = txtAdminChat.Text;
                        SettingsGroup.Instance.TeSO.FailText = txtAdminFalsch.Text;
                        SettingsGroup.Instance.TeSO.Admin = chkForAdmin.Checked;
                        SettingsGroup.Instance.TeSO.Boardcast = chkBroadcaster.Checked;
                        SettingsGroup.Instance.TeSO.VIP = chkVIP.Checked;
                        break;
                    case "CreateClip":
                        if (SettingsGroup.Instance.Tsclips_edit)
                        {
                            SettingsGroup.Instance.TeClipCreate.Use = chkAdminUse.Checked;
                            SettingsGroup.Instance.TeClipCreate.Command = txtAdminKommando.Text;
                            SettingsGroup.Instance.TeClipCreate.ChatText = txtAdminChat.Text;
                            SettingsGroup.Instance.TeClipCreate.FailText = txtAdminFalsch.Text;
                            SettingsGroup.Instance.TeClipCreate.Admin = chkForAdmin.Checked;
                            SettingsGroup.Instance.TeClipCreate.Boardcast = chkBroadcaster.Checked;
                            SettingsGroup.Instance.TeClipCreate.VIP = chkVIP.Checked;
                        }
                        else
                        {
                            MessageBox.Show("Der Bot besitzt nicht die Berechtigung für 'clips_edit'. Ein Einstellen ist nicht möglich", "Fehlende Berechtigung", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case "Skill - Mainquest":
                        SettingsGroup.Instance.SkillMain.Use = chkAdminUse.Checked;
                        SettingsGroup.Instance.SkillMain.Command= txtAdminKommando.Text;
                        SettingsGroup.Instance.SkillMain.ChatText= txtAdminChat.Text;
                        SettingsGroup.Instance.SkillMain.FailText= txtAdminFalsch.Text;
                        SettingsGroup.Instance.SkillMain.Admin= chkForAdmin.Checked;
                        SettingsGroup.Instance.SkillMain.Boardcast= chkBroadcaster.Checked;
                        SettingsGroup.Instance.SkillMain.VIP = chkVIP.Checked;
                        break;
                    case "Skill - Subquest":
                        break;
                    case "Skill - Clear":
                        break;
                    case "Skill - Status":
                        break;
                    case "Skill - Update":
                        break;
                    case "Skill - List":
                        break;
                }
                SettingsGroup.Instance.Save();
                grpAdmin.Enabled = false;
            }
            else
            {
                MessageBox.Show("Der Bot besitzt nicht die Standard-Berechtigungen für 'chat_read' und 'chat_edit'. Ein Einstellen ist nicht möglich", "Fehlende Berechtigung", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnAdminVariable_Click(object sender, EventArgs e)
        {
            if (cmbAdminVariable.Text != "")
            {
                txtAdminChat.Text = txtAdminChat.Text + "°" + cmbAdminVariable.Text;
            }
        }
        private void chkAdminUse_CheckedChanged(object sender, EventArgs e)
        {
            grpAdmin.Enabled = chkAdminUse.Checked;
        }
        #endregion



        #region Skill
        List<GameSkill> SkillList;
        GameSkill SelectedGame;
        Quest SelectedQuest;
        bool MainQuest = true; //true Mainquest. false Sidequest;
        string GamePattern = "^([\\w\\d\\s]+) - (\\d+)";
        int QuestIndex=0;
        int GameIndex = 0;
        bool SkillÄnderung;
        bool SkillGameChange = true;
        private void LoadSkills()
        {
            String Path = Application.StartupPath + System.IO.Path.DirectorySeparatorChar + "SkillListe.json";
            String InhaltJSON;

            if (File.Exists(Path))
            {
                //FileStream stream = File.OpenRead(Path);
                InhaltJSON = File.ReadAllText(Path);

                SkillList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<GameSkill>>(InhaltJSON);
                cbxGame.Items.Clear();
                foreach (var item in SkillList)
                {
                    cbxGame.Items.Add(item.Game + " - " + item.GameID);
                }
                
            }
            else
            {
                SkillList = new List<GameSkill>();
            }
        }

        private void btnAddGame_Click(object sender, EventArgs e)
        {
            if (cbxGame.Text != "")
            {
                bool Schalter = true;

                foreach (var item in cbxGame.Items)
                {
                    var Gamename = Regex.Match(item.ToString(), GamePattern).Groups[1];
                    var Neuname = Regex.Match(cbxGame.Text, GamePattern).Groups[1];
                    if (Gamename.Value.Equals(cbxGame.Text) || Gamename.Value.Equals(Neuname.Value))
                    {
                        Schalter = false;
                    }
                }
                if (Schalter)
                {
                    cbxGame.Items.Add(cbxGame.Text + " - " + "0");
                    cbxGame.Text = "";
                    SelectedGame = new GameSkill(cbxGame.Text);
                    cbxGame.SelectedIndex = cbxGame.Items.Count - 1; //Das letze Element ist normalweise das, was gerade angelegt worden ist.
                    GameRefresh();
                    SkillÄnderungChange(true);
                }
            }
        }
        private void SkillÄnderungChange(bool nWert) {
            SkillÄnderung = nWert;
            if (SkillÄnderung) {
                btnSkillSave.BackColor = Color.Tomato;
            }
            else
            {
                btnSkillSave.BackColor = Color.LightGreen;
            }
        }
        private void GameRefresh() {
            if (SelectedGame != null)
            {
                if (SelectedGame.Wachstumsart != 0)
                {
                    cbxLevelkurve.SelectedIndex = SelectedGame.Wachstumsart - 1;
                }

                NudLevel.Value = SelectedGame.Level;
                NudEXP.Value = SelectedGame.EXP;
                lblEXPNextLevel.Text = "/ " + SelectedGame.EXPNextLevel.ToString();
                lblTillEXP.Text = "Noch: " + SelectedGame.EXPTillNextLevel.ToString();
                lstHQ.Items.Clear();
                lstSQ.Items.Clear();
                foreach (var item in SelectedGame.MainQuest)
                {
                    lstHQ.Items.Add(item.ID + " - " + item.Name);
                }
                foreach (var item in SelectedGame.SideQeust)
                {
                    lstSQ.Items.Add(item.ID + " - " + item.Name);
                }
            }
            
        }

        private void cbxGame_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SkillGameChange)
            {
                foreach (var item in SkillList)
                {
                    var Match = Regex.Match(cbxGame.Text, GamePattern);
                    if (item.Game.Equals(Match.Groups[1].Value))
                    {
                        SelectedGame = item;
                        GameRefresh();
                        grpSkillGame.Enabled = true;
                        //Hier auf Nein setzen, da bei einem gerade gelandenen Game keine Änderungen gemacht wurden
                        SkillÄnderungChange(false);
                    }
                }
            }

            GameIndex = cbxGame.SelectedIndex;
        }


        private void cbxGame_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
            if (SkillÄnderung)
            {
                if (MessageBox.Show("Es sind nicht gespeicherte Änderungen vorhanden. Fortfahren?", "Achtung", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    SkillGameChange = true;
                }
                else
                {
                    SkillGameChange = false;
                }
            }
            if (!SkillGameChange)
            {
                //Da sich der Index erst zum Ende aktualisiert, kann ich hier auf den "Alten" Eintrag gehen, sollte die Meldung mit NEIN bestätigt werden
                cbxGame.SelectedIndex = GameIndex;
            }
        }

        private void btnDeleteGame_Click(object sender, EventArgs e)
        {
            cbxGame.Items.Remove(cbxGame.SelectedItem);
            SkillÄnderungChange(true);
        }

        private bool SkillValidierung() {
            bool Ergebnis = true;
            if (cbxLevelkurve.Text == "")
            {
                MessageBox.Show("Bitte Levelkurve eingeben");
                Ergebnis = false;
            }

            if (lstHQ.Items.Count < 1) {
                MessageBox.Show("Es ist keine Hauptquest angegeben. Es muss mind. eine bestehen");
                Ergebnis = false;
            }

            return Ergebnis;

        }

        private void btnSkillSave_Click(object sender, EventArgs e)
        {
            //Validierung: Wachstumsart, Hauptquest
            if (SkillValidierung())
            {

                SaveSelectedGame();
                int Gameindex = -1;
                foreach (var item in SkillList)
                {
                    var Match = Regex.Match(cbxGame.Text, GamePattern);
                    if (item.Game.Equals(Match.Groups[1].Value))
                    {
                        Gameindex = SkillList.IndexOf(item);
                    }
                }
                if (Gameindex != -1)
                {
                    SkillList.RemoveAt(Gameindex);
                    SkillList.Insert(Gameindex, SelectedGame);
                }
                else
                {
                    SkillList.Add(SelectedGame);

                }

                String Path = Application.StartupPath + System.IO.Path.DirectorySeparatorChar + "SkillListe.json";
                String InhaltJSON = Newtonsoft.Json.JsonConvert.SerializeObject(SkillList, Newtonsoft.Json.Formatting.Indented);

                File.WriteAllText(Path, InhaltJSON);

                SettingsGroup.Instance.SkillUse = chkSkillUse.Checked;
                SettingsGroup.Instance.Save();

                LoadSkills();
                cbxGame.SelectedIndex=Gameindex;
                SkillÄnderungChange(false);
            }
        }
        private void SaveSelectedGame() {
            SelectedGame.Wachstumsart = cbxLevelkurve.SelectedIndex+1;
            SelectedGame.EXP = Convert.ToInt32(NudEXP.Value);
            SelectedGame.Level = Convert.ToInt32(NudLevel.Value);
            SelectedGame.UpdateLevelEXP();
        }
        private void TabQuests_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQuestName.Text = "";
            NudQuestEXP.Value = 1;
            chkFinished.Checked = false;
            chkRepeat.Checked = false;
            lblD.Text = "ID: ";
            lblAbschluss.Text = "Abgeschlossen: x";

            if (TabQuests.SelectedTab.Text.Equals("Hauptquest"))
            {
                MainQuest = true;
            }
            else
            {
                MainQuest = false;
            }
            Leeren();
        }

        private void lstHQ_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstHQ.SelectedIndex != -1)
            {
                var ID = Regex.Match(lstHQ.SelectedItem.ToString(), "^([M]\\d+) - \\w+").Groups[1].Value;
                foreach (var item in SelectedGame.MainQuest)
                {
                    if (item.ID.Equals(ID))
                    {
                        SelectedQuest = item;
                        Auswahl(SelectedQuest);
                        QuestIndex = SelectedGame.MainQuest.IndexOf(SelectedQuest);
                    }
                }
            }
        }

        private void lstSQ_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSQ.SelectedIndex != -1)
            {
                var ID = Regex.Match(lstSQ.SelectedItem.ToString(), "^([S]\\d+) - \\w+").Groups[1].Value;
                foreach (var item in SelectedGame.SideQeust)
                {
                    if (item.ID.Equals(ID))
                    {
                        SelectedQuest = item;
                        Auswahl(SelectedQuest);
                        QuestIndex = SelectedGame.SideQeust.IndexOf(SelectedQuest);
                    }
                }
            }
        }


        private void btnAddQuest_Click(object sender, EventArgs e)
        {
            if (txtQuestName.Enabled)
            {
                if (txtQuestName.Text != "")
                {

                    if (SelectedQuest != null)
                    {
                        SelectedQuest.Update(txtQuestName.Text, NudQuestEXP.Value, chkFinished.Checked, chkRepeat.Checked);
                    }
                    else
                    {
                        int Count;
                        if (MainQuest)
                        {
                            Count = SelectedGame.MainQuest.Count;
                        }
                        else
                        {
                            Count = SelectedGame.SideQeust.Count;
                        }
                        SelectedQuest = new Quest(txtQuestName.Text, NudQuestEXP.Value, MainQuest, chkFinished.Checked, chkRepeat.Checked, Count.ToString());
                    }



                    bool SchalterUpdate = false;
                    if (MainQuest)
                    {
                        foreach (var item in SelectedGame.MainQuest)
                        {
                            if (item.ID.Equals(SelectedQuest.ID))
                            {
                                SchalterUpdate = true;
                            }
                        }
                        if (SchalterUpdate)
                        {
                            SelectedGame.MainQuest.RemoveAt(QuestIndex);
                            SelectedGame.MainQuest.Insert(QuestIndex, SelectedQuest);
                        }
                        else
                        {
                            SelectedGame.MainQuest.Add(SelectedQuest);
                        }
                    }
                    else
                    {
                        foreach (var item in SelectedGame.SideQeust)
                        {
                            if (item.ID.Equals(SelectedQuest.ID))
                            {
                                SchalterUpdate = true;
                            }
                        }
                        if (SchalterUpdate)
                        {
                            SelectedGame.SideQeust.RemoveAt(QuestIndex);
                            SelectedGame.SideQeust.Insert(QuestIndex, SelectedQuest);
                        }
                        else
                        {
                            SelectedGame.SideQeust.Add(SelectedQuest);
                        }
                    }
                    SkillÄnderungChange(true);
                    Leeren();
                    GameRefresh();
                }
            }
            else {
                txtQuestName.Enabled = true;
                grpSkill.Enabled = true;
            }
        }
        private void btnDeleteQuest_Click(object sender, EventArgs e)
        {
            if (MainQuest)
            {
                SelectedGame.MainQuest.Remove(SelectedQuest);
            }
            else {
                SelectedGame.SideQeust.Remove(SelectedQuest);
            }
            Leeren();
            GameRefresh();
            SkillÄnderungChange(true);
        }

        private void Auswahl(Quest Auswahl) {
            txtQuestName.Text = Auswahl.Name;
            txtQuestName.Enabled = true;
            grpSkill.Enabled = true;
            NudQuestEXP.Value = Auswahl.AbschlussEXP;
            chkFinished.Checked = Auswahl.Abschluss;
            chkRepeat.Checked = Auswahl.Repeat;
            lblD.Text = "ID: " + Auswahl.ID;
            lblAbschluss.Text = "Abgeschlossen: x" + Auswahl.AnzahlAbschluss.ToString();
        }

        private void Leeren() {
            txtQuestName.Text = "";
            txtQuestName.Enabled = false;
            grpSkill.Enabled = false;
            NudQuestEXP.Value = NudQuestEXP.Minimum;
            chkFinished.Checked = false;
            chkRepeat.Checked = false;
            lblD.Text = "ID: ";
            lblAbschluss.Text = "Abgeschlossen: x";
            SelectedQuest = null;
        }

        private void cbxLevelkurve_SelectedIndexChanged(object sender, EventArgs e)
        {
            SkillÄnderungChange(true);
        }

        private void NudLevel_ValueChanged(object sender, EventArgs e)
        {
            SkillÄnderungChange(true);
        }

        private void NudEXP_ValueChanged(object sender, EventArgs e)
        {
            SkillÄnderungChange(true);
        }
        private void chkSkillUse_CheckedChanged(object sender, EventArgs e)
        {
            btnDeleteGame.Enabled = chkSkillUse.Checked;
            btnAddGame.Enabled = chkSkillUse.Checked;
            cbxGame.Enabled = chkSkillUse.Checked;
        }

        #endregion

        private void btnSkillBefehle_Click(object sender, EventArgs e)
        {
            using (BefehleLevel Fenster = new BefehleLevel())
            {
                //Wenn ich Variablen übergeben möchte, dann muss ich es so machen
                //Fenster.randomBefehls = lRandomBefehls;
                DialogResult dr = Fenster.ShowDialog();

                if (dr == DialogResult.OK)
                {

                }

            }
        }
    }
}
