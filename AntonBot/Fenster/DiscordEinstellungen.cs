﻿using AntonBot.PlatformAPI;
using AntonBot.PlatformAPI.ListenTypen;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AntonBot.Fenster
{
    public partial class DiscordEinstellungen : Form
    {
        private string sClientID;
        private bool Erststart = true;
        private bool bAccessTokenChange;
        private long Summe = 0x0000000000;
        private bool bÄnderung;
        private bool bÄnderungAusIndex;
        private int iEventIndex;
        private int iAltIndex;
        private int iVariablenInhaltEvent;
        private int iVariablenInhaltTextFeld;
        private DiscordFunction DiscordClient;
        private List<DiscordGilde> DiscordListe;
        private List<EmbededMessageReactionRole> ReactionRoleList;
        private String PathReactionRoleList = Application.StartupPath + Path.DirectorySeparatorChar + "ReactionRole.json";

        public DiscordEinstellungen(DiscordFunction client)
        {
            InitializeComponent();
            DiscordClient = client;
        }

        private void DiscordEinstellungen_Load(object sender, EventArgs e)
        {
            sClientID = SettingsGroup.Instance.DSclientID;
            txtClientID.Text = sClientID;
            //txtStandardChannel.Text = Properties.DiscordScopes.Default.StandardChannel;
            txtToken.Text = SettingsGroup.Instance.DSAccessToken;

            lblSumme.Text = Summe.ToString();
            Erststart = false;

            DiscordClient.DiscordWriteGuilds();


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

            //Änderung des Index, damit der erste Wert auch eingelesen wird (onStreamOnline) und nicht manuell geklickt werden muss
            LstEvents.SelectedIndex = 1;
            LstEvents.SelectedIndex = 0;

            //Emote Auswahl
            cmbServerAuswahl.Items.Clear();
            foreach (var Server in DiscordListe)
            {
                cmbServerAuswahl.Items.Add(Server.Name);
            }

            //EmoteReactionRole
            DiscordClient.LoadAllEmotes();
            LoadReactionRoles();
            foreach (var Server in DiscordListe)
            {
                cmdReactRollServer.Items.Add(Server.Name);
            }
        }

        private void DiscordEinstellungen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bAccessTokenChange)
            {
                if (MessageBox.Show("Der Token wurde geändert." + Environment.NewLine + "Soll dieser übernommen werden? (Bot muss sich neu anmelden)", "Geänderte Daten", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    SettingsGroup.Instance.DSclientID = txtClientID.Text.Trim();
                    SettingsGroup.Instance.DSAccessToken = txtToken.Text.Trim();

                    SettingsGroup.Instance.Save();
                }
            }
        }


        #region Einrichtung
        private void btnScopesAnfordern_Click(object sender, EventArgs e)
        {
            SummeBerechnen();
            JoinDiscordServer(txtClientID.Text.Trim(), Summe.ToString());
        }

        public void JoinDiscordServer(string ClientID, string Abfrage)
        {

            // Creates a redirect URI using an available port on the loopback address.


            // Creates an HttpListener to listen for requests on that redirect URI.
            if (ClientID.Equals(""))
            {
                MessageBox.Show("Es ist keine ClientID für den Bot eingetragen" + Environment.NewLine + "Ohne ClientID kann keine Abfrage erfolgen.", "ClientID eingeben", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                /*
                string redirectURI = string.Format("http://{0}:{1}/", IPAddress.Loopback, "8443"); //Port 8443 ist der https Port am Rechner selber

                http.Prefixes.Clear();
                http.Prefixes.Add(redirectURI);
                http.Start();
                */
                // Creates the OAuth 2.0 authorization request.
                string authorizationRequest = string.Format("http://discord.com/api/oauth2/authorize?client_id={0}&permissions={1}&scope=bot",
                    ClientID,
                    Abfrage);

                // Opens request in the browser.
                System.Diagnostics.Process.Start(authorizationRequest);

                //Hier muss was für das Zertifikat gemacht werden
                //Im nächsten Schritt scheitert die Abfrage der Anfrage


            }

        }
        private void SummeBerechnen()
        {
            long NeueSumme = 0x0000000000;
            if (chkAdmin.Checked)
            {
                NeueSumme = 0x0000000008;
            }
            else
            {
                NeueSumme = 0x0000000000;
                foreach (var item in ChkListAllgemein.CheckedItems)
                {
                    switch (item.ToString())
                    {
                        case "Administrator":
                            NeueSumme += 0x0000000008;
                            break;
                        case "View Audit Log":
                            NeueSumme += 0x0000000080;
                            break;
                        case "View Server Insights":
                            NeueSumme += 0x0000080000;
                            break;
                        case "Manage Server":
                            NeueSumme += 0x0000000020;
                            break;
                        case "Manage Roles":
                            NeueSumme += 0x0010000000;
                            break;
                        case "Manage Channels":
                            NeueSumme += 0x0000000010;
                            break;
                        case "Kick Members":
                            NeueSumme += 0x0000000002;
                            break;
                        case "Ban Members":
                            NeueSumme += 0x0000000004;
                            break;
                        case "Create Instant Invite":
                            NeueSumme += 0x0000000001;
                            break;
                        case "Change Nickname":
                            NeueSumme += 0x0004000000;
                            break;
                        case "Manage Nicknames":
                            NeueSumme += 0x0008000000;
                            break;
                        case "Manage Emojis":
                            NeueSumme += 0x0040000000;
                            break;
                        case "Manage Webhooks":
                            NeueSumme += 0x0020000000;
                            break;
                        case "View Channels":
                            NeueSumme += 0x0000000400;
                            break;
                    }
                }
                foreach (var item in ChkListText.CheckedItems)
                {
                    switch (item.ToString())
                    {
                        case "Send Messages":
                            NeueSumme += 0x0000000800;
                            break;
                        case "Send TTS Messages":
                            NeueSumme += 0x0000001000;
                            break;
                        case "Manage Messages":
                            NeueSumme += 0x0000002000;
                            break;
                        case "Embed Links":
                            NeueSumme += 0x0000004000;
                            break;
                        case "Attach Files":
                            NeueSumme += 0x0000008000;
                            break;
                        case "Read Message History":
                            NeueSumme += 0x0000010000;
                            break;
                        case "Mention Everyone":
                            NeueSumme += 0x0000020000;
                            break;
                        case "Use External Emojis":
                            NeueSumme += 0x0000040000;
                            break;
                        case "Add Reactions":
                            NeueSumme += 0x0000000040;
                            break;
                        case "Use Slash Commands":
                            NeueSumme += 0x0080000000;
                            break;
                    }
                }
                foreach (var item in ChkListSprache.CheckedItems)
                {
                    switch (item.ToString())
                    {
                        case "Connect":
                            NeueSumme += 0x0000100000;
                            break;
                        case "Speak":
                            NeueSumme += 0x0000200000;
                            break;
                        case "Video":
                            NeueSumme += 0x0000000200;
                            break;
                        case "Mute Members":
                            NeueSumme += 0x0000400000;
                            break;
                        case "Deafen Members":
                            NeueSumme += 0x0010000000;
                            break;
                        case "Move Members":
                            NeueSumme += 0x0000800000;
                            break;
                        case "Use Voice Activity":
                            NeueSumme += 0x0002000000;
                            break;
                        case "Priority Speaker":
                            NeueSumme += 0x0000000100;
                            break;
                    }
                }
            }

            Summe = NeueSumme;
            lblSumme.Text = Summe.ToString();
        }

        private void ChkListAllgemein_SelectedIndexChanged(object sender, EventArgs e)
        {
            SummeBerechnen();
        }

        private void ChkListText_SelectedIndexChanged(object sender, EventArgs e)
        {
            SummeBerechnen();
        }

        private void ChkListSprache_SelectedIndexChanged(object sender, EventArgs e)
        {
            SummeBerechnen();
        }

        private void chkAdmin_CheckedChanged(object sender, EventArgs e)
        {
            ChkListAllgemein.Enabled = !chkAdmin.Checked;
            ChkListSprache.Enabled = !chkAdmin.Checked;
            ChkListText.Enabled = !chkAdmin.Checked;
            if (chkAdmin.Checked)
            {
                //long Summe = 0x0000000008;
                lblSumme.Text = "8";
            }
            else
            {
                SummeBerechnen();
            }
        }

        private void txtToken_TextChanged(object sender, EventArgs e)
        {
            if (!Erststart)
            {
                bAccessTokenChange = true;
            }

        }
        private void txtClientID_TextChanged(object sender, EventArgs e)
        {
            if (!Erststart)
            {
                bAccessTokenChange = true;
            }
            sClientID = txtClientID.Text;
        }
        private void btnToken_Click(object sender, EventArgs e)
        {
            sClientID = txtClientID.Text;
            if (sClientID.Equals(""))
            {
                MessageBox.Show("Es ist keine ClientID für den Bot eingetragen" + Environment.NewLine + "Ohne ClientID kann die richtige Seite nicht aufgerufen werden.", "ClientID eingeben", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string authorizationRequest = string.Format("https://discord.com/developers/applications/{0}/bot",
                sClientID);
                // Opens request in the browser.
                System.Diagnostics.Process.Start(authorizationRequest);
            }
        }


        #endregion

        #region Events

        private void txtDiscordChat_MouseClick(object sender, MouseEventArgs e)
        {
            iEventIndex = 1;
        }

        private void txtDiscordChat_TextChanged(object sender, EventArgs e)
        {
            Änderungchange(true);
        }

        private void chkDiscordAusgabe_CheckedChanged(object sender, EventArgs e)
        {
            Änderungchange(true);
            btnDiscordChannel.Enabled = chkDiscordAusgabe.Checked;
        }

        private void txtKonsolenFenster_MouseClick(object sender, MouseEventArgs e)
        {
            iEventIndex = 2;
        }

        private void txtKonsolenFenster_TextChanged(object sender, EventArgs e)
        {
            Änderungchange(true);
        }

        private void chkKonsoleAusgabe_CheckedChanged(object sender, EventArgs e)
        {
            Änderungchange(true);
        }

        private void btnVariable_Click(object sender, EventArgs e)
        {
            if (cmbVariable.Text != "---------------------------------") //"---------------------------------" Dient als Platzhalter zwischen den Event-Variablen und den Feldeigenen Variablen, daher soll dieser nicht eingefügt werden können
            {
                switch (iEventIndex)
                {
                    case 1:

                        txtDiscordChat.Text = txtDiscordChat.Text + "°" + cmbVariable.Text;
                        break;
                    case 2:
                        txtKonsolenFenster.Text = txtKonsolenFenster.Text + "°" + cmbVariable.Text;
                        break;
                    case 3:
                        txtChatReaktion.Text = txtChatReaktion.Text + "°" + cmbVariable.Text;
                        break;
                }
            }
        }

        private void txtChatReaktion_MouseClick(object sender, MouseEventArgs e)
        {
            iEventIndex = 3;
        }

        private void txtChatReaktion_TextChanged(object sender, EventArgs e)
        {
            Änderungchange(true);
        }

        private void chkTextReaction_CheckedChanged(object sender, EventArgs e)
        {
            Änderungchange(true);
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

        private void btnDiscordChannel_Click(object sender, EventArgs e)
        {
            using (DiscordChannelAuswahl Fenster = new DiscordChannelAuswahl())
            {

                switch (LstEvents.SelectedIndex)
                {
                    case 0:
                        Fenster.Channels = SettingsGroup.Instance.DsJoinUser.Channel;
                        break;
                    case 1:
                        Fenster.Channels = SettingsGroup.Instance.DsLeftUser.Channel;
                        break;
                }

                DialogResult dr = Fenster.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    switch (LstEvents.SelectedIndex)
                    {
                        case 0:
                            SettingsGroup.Instance.DsJoinUser.Channel = Fenster.Channels;
                            break;
                        case 1:
                            SettingsGroup.Instance.DsLeftUser.Channel = Fenster.Channels;
                            break;
                    }
                    SettingsGroup.Instance.Save();
                    Änderungchange(true);
                }

            }
        }
        private void Änderungchange(bool bArt)
        {

            if (bArt)
            {
                bÄnderung = true;
                bÄnderungAusIndex = false;
                btnÜbernehmen.BackColor = Color.Tomato;
            }
            else
            {
                bÄnderung = false;
                btnÜbernehmen.BackColor = Color.LightGreen;
            }
        }
        private void IndexChange()
        {
            /* Index:
            0 = OnUserJoined
            1 = OnUserLeft
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
                    chkUse.Checked = SettingsGroup.Instance.DsJoinUser.Use;
                    chkTextReaction.Checked = SettingsGroup.Instance.DsJoinUser.Twitch;
                    txtChatReaktion.Text = SettingsGroup.Instance.DsJoinUser.TwitchText;
                    chkDiscordAusgabe.Checked = SettingsGroup.Instance.DsJoinUser.Discord;
                    txtDiscordChat.Text = SettingsGroup.Instance.DsJoinUser.DiscordText;
                    chkKonsoleAusgabe.Checked = SettingsGroup.Instance.DsJoinUser.Konsole;
                    txtKonsolenFenster.Text = SettingsGroup.Instance.DsJoinUser.KonsoleText;
                    break;
                case 1:
                    chkUse.Checked = SettingsGroup.Instance.DsLeftUser.Use;
                    chkTextReaction.Checked = SettingsGroup.Instance.DsLeftUser.Twitch;
                    txtChatReaktion.Text = SettingsGroup.Instance.DsLeftUser.TwitchText;
                    chkDiscordAusgabe.Checked = SettingsGroup.Instance.DsLeftUser.Discord;
                    txtDiscordChat.Text = SettingsGroup.Instance.DsLeftUser.DiscordText;
                    chkKonsoleAusgabe.Checked = SettingsGroup.Instance.DsLeftUser.Konsole;
                    txtKonsolenFenster.Text = SettingsGroup.Instance.DsLeftUser.KonsoleText;
                    break;

            }
            btnDiscordChannel.Enabled = chkDiscordAusgabe.Checked;

            iAltIndex = LstEvents.SelectedIndex;

            VariableBefüllen(1, LstEvents.SelectedIndex);
        }

        private void VariableBefüllen(int Teil, int Inhalt)
        {
            //Die Variable Teil wird verwendet, um anzugeben, welchen Part der Variablen "Neu" beschrieben wird
            //Es gibt zwei Teile:
            // 1) Die Variablen aus den Events
            // 2) Die Variablen aus den Textfeldern
            // Je nach dem, soll nur eines der beiden Feldern befüllt werden

            cmbVariable.Text = "";

            if (Teil == 1)
            {
                iVariablenInhaltEvent = Inhalt;
            }
            else if (Teil == 2)
            {
                iVariablenInhaltTextFeld = Inhalt;
            }

            cmbVariable.Items.Clear();

            switch (iVariablenInhaltEvent)
            {
                case 0:
                    //OnUserJoin
                    cmbVariable.Items.Add("Username");
                    cmbVariable.Items.Add("DisplayName");
                    cmbVariable.Items.Add("Guild");
                    cmbVariable.Items.Add("JoinedAt");
                    cmbVariable.Items.Add("Nickname");
                    break;
                case 1:
                    //OnStreamOffline
                    cmbVariable.Items.Add("GuildName");
                    cmbVariable.Items.Add("UserName");

                    break;

            }

            cmbVariable.Items.Add("---------------------------------");

            /*
             * Das hier ist die Switch-Prüfung für die Variablen, die es für die einzelnen Ziele (Twitch, Discord, Konsole) gibt
            switch (iVariablenInhaltTextFeld) { 
            
            }
            */
        }

        private void chkUse_CheckedChanged(object sender, EventArgs e)
        {
            grpEvent.Enabled = chkUse.Checked;
            Änderungchange(true);
        }



        private void btnÜbernehmen_Click(object sender, EventArgs e)
        {
            bool Validierung = false;
            if (SettingsGroup.Instance.Tschat_read && SettingsGroup.Instance.Tschat_edit)
            {
                switch (LstEvents.SelectedIndex)
                {
                    case 0:
                        SettingsGroup.Instance.DsJoinUser.Use = chkUse.Checked;
                        SettingsGroup.Instance.DsJoinUser.Twitch = chkTextReaction.Checked;
                        SettingsGroup.Instance.DsJoinUser.TwitchText = txtChatReaktion.Text;
                        SettingsGroup.Instance.DsJoinUser.Discord = chkDiscordAusgabe.Checked;
                        SettingsGroup.Instance.DsJoinUser.DiscordText = txtDiscordChat.Text;
                        SettingsGroup.Instance.DsJoinUser.Konsole = chkKonsoleAusgabe.Checked;
                        SettingsGroup.Instance.DsJoinUser.KonsoleText = txtKonsolenFenster.Text;
                        if (SettingsGroup.Instance.DsJoinUser.Channel.Count == 0 && chkDiscordAusgabe.Checked)
                        {
                            Validierung = false;
                        }
                        else { Validierung = true; }
                        break;
                    case 1:
                        SettingsGroup.Instance.DsLeftUser.Use = chkUse.Checked;
                        SettingsGroup.Instance.DsLeftUser.Twitch = chkTextReaction.Checked;
                        SettingsGroup.Instance.DsLeftUser.TwitchText = txtChatReaktion.Text;
                        SettingsGroup.Instance.DsLeftUser.Discord = chkDiscordAusgabe.Checked;
                        SettingsGroup.Instance.DsLeftUser.DiscordText = txtDiscordChat.Text;
                        SettingsGroup.Instance.DsLeftUser.Konsole = chkKonsoleAusgabe.Checked;
                        SettingsGroup.Instance.DsLeftUser.KonsoleText = txtKonsolenFenster.Text;
                        if (SettingsGroup.Instance.DsLeftUser.Channel.Count == 0 && chkDiscordAusgabe.Checked)
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
                else
                {
                    MessageBox.Show("Es wurde eine Discord-Nachricht eingestellt, aber keine Channels. Bitte wähle Channels aus", "Fehlende Kanäle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Der Bot besitzt nicht die Standard-Berechtigungen für 'chat_read' und 'chat_edit'. Ein Einstellen ist nicht möglich", "Fehlende Berechtigung", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Emotes
        private void cmbServerAuswahl_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstEmotes.Items.Clear();
            foreach (var Server in DiscordListe)
            {
                if (cmbServerAuswahl.SelectedItem.Equals(Server.Name))
                {
                    foreach (var Emotes in Server.Emotes)
                    {
                        string item = "<" + Emotes.Name + ":" + Emotes.ID + ">";
                        lstEmotes.Items.Add(item);
                    }
                }
            }
        }

        private void btnEmotesCopy_Click(object sender, EventArgs e)
        {
            if (lstEmotes.SelectedItem != null)
            {
                Clipboard.SetText(lstEmotes.SelectedItem.ToString());
            }
        }

        #endregion

        #region ReactionRoles
        private void LoadReactionRoles() {
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
            else
            {
                MessageBox.Show("Es existiert keine ReactionRole.json. Diese Datei wird nun erzeugt.", "Keine ReactionRole", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReactionRoleList = new List<EmbededMessageReactionRole>();
                SaveReactionRole();
            }
        }

        private void SaveReactionRole() {
            string InhaltJSON = Newtonsoft.Json.JsonConvert.SerializeObject(ReactionRoleList,Formatting.Indented);
            File.WriteAllText(PathReactionRoleList, InhaltJSON);
        }

        private void btnEmoteRoleAdd_Click(object sender, EventArgs e)
        {
            bool gefunden = false;
            OwnEmote ownEmote = new OwnEmote();
            foreach (var Emote in DiscordClient.Emotelist)
            {
                if (Emote.Name.Equals(cmbEmoteSelect.SelectedItem)) {
                    ownEmote = Emote;
                    gefunden = true;
                }
            }

            if (gefunden) {
                //AddRow(ownEmote.getEmoteBitmap(), ownEmote.Name, cmbRoleSelect.Text);
                AddRow(ownEmote.getEmoteBitmap(), ownEmote.Name, cmbRoleSelect.Text);
            }

        }

        private void AddRow(Image image, String name, String role) {
            //increase panel rows count by one
            EmoteRoleTable.RowCount++;
            //add a new RowStyle as a copy of the previous one
            EmoteRoleTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            //add your three controls
            EmoteRoleTable.Controls.Add(new PictureBox() { Image = image, AutoSize = true, Anchor = AnchorStyles.Left, SizeMode = PictureBoxSizeMode.StretchImage }, 0, EmoteRoleTable.RowCount - 1) ;
            EmoteRoleTable.Controls.Add(new Label() { Text = name, AutoSize = true, Anchor = AnchorStyles.Left }, 1, EmoteRoleTable.RowCount - 1);
            EmoteRoleTable.Controls.Add(new Label() { Text = role, AutoSize = true, Anchor = AnchorStyles.Left }, 2, EmoteRoleTable.RowCount - 1);
            EmoteRoleTable.Controls.Add(new Label() { Text = "X", AutoSize = true, Anchor = AnchorStyles.Left }, 3, EmoteRoleTable.RowCount - 1);
        }

        private void ResetTable() {
            EmoteRoleTable.Controls.Clear();
            EmoteRoleTable.RowStyles.Clear();
            EmoteRoleTable.RowCount = 1;

            EmoteRoleTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            //add your three controls
            EmoteRoleTable.Controls.Add(new Label() { Text = "Emote", AutoSize = true, Anchor = AnchorStyles.None, Font = label15.Font }, 0, EmoteRoleTable.RowCount - 1);
            EmoteRoleTable.Controls.Add(new Label() { Text = "Emotename", AutoSize = true, Anchor = AnchorStyles.None }, 1, EmoteRoleTable.RowCount - 1);
            EmoteRoleTable.Controls.Add(new Label() { Text = "Rolle", AutoSize = true, Anchor = AnchorStyles.None }, 2, EmoteRoleTable.RowCount - 1);
            EmoteRoleTable.Controls.Add(new Label() { Text = "", AutoSize = true, Anchor = AnchorStyles.None }, 3, EmoteRoleTable.RowCount - 1);

        }

        private void ResetAll(int Ebene)
        {
            //Ebene gibt an wie viele Felder zurück gesetzt werden, damit die Funktion nicht 10-fach geschrieben werden muss
            //Je niedriger der Wert, desto mehr Felder werden zurück gesetzt

            if (Ebene < 1) { 
                cmdReactRollServer.Items.Clear(); cmdReactRollServer.Text = "";
            }
            if (Ebene < 2) { 
                cmbReactChannel.Items.Clear(); cmbReactChannel.Text = "";
                cmbEmoteSelect.Items.Clear();
                cmbEmoteSelect.Text = "";
                cmbRoleSelect.Items.Clear();
                cmbRoleSelect.Text = "";
            }
            if (Ebene < 3) { cmdRollMessage.Items.Clear();cmdRollMessage.Text = "";}
            if (Ebene < 4) { 
                txtReactionName.Text = "";
                txtReactFooter.Text = "";
                txtReactMessage.Text = "";
                txtReactTitle.Text = "";
                ResetTable();
            }
        }

        private void cmdReactRollServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetAll(1);
            foreach (var Server in DiscordListe) {
                if (cmdReactRollServer.SelectedItem.Equals(Server.Name))
                {
                    foreach (var Channel in Server.Channels) {
                        cmbReactChannel.Items.Add(Channel.Name);
                    }
                    foreach (var Emote in Server.Emotes)
                    {
                        cmbEmoteSelect.Items.Add(Emote.Name);
                    }
                    foreach (var Role in Server.Roles)
                    {
                        cmbRoleSelect.Items.Add(Role.Name);
                    }
                }
            }
        }

        private void cmbReactChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetAll(2);
            foreach (var Server in DiscordListe)
            {
                if (cmdReactRollServer.SelectedItem.Equals(Server.Name))
                {
                    foreach (var Channel in Server.Channels)
                    {
                        if (cmbReactChannel.SelectedItem.Equals(Channel.Name))
                        {
                            foreach (var ReactionRole in ReactionRoleList) {
                                cmdRollMessage.Items.Add(ReactionRole.MessageName);
                            }
                        }
                    }
                }
            }
        }
 
        private void cmdRollMessage_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetAll(3);
            foreach (var ReactionRole in ReactionRoleList)
            {
                if (cmdRollMessage.SelectedItem.Equals(ReactionRole.MessageName)) {
                    txtReactionName.Text = ReactionRole.MessageName;
                    txtReactTitle.Text = ReactionRole.MessageTitle;
                    txtReactFooter.Text = ReactionRole.MessageFooter;
                    txtReactMessage.Text = ReactionRole.MessageText;
                    ResetTable();
                    foreach (var Emote in ReactionRole.RollenEinträge) {
                        //vorher die Tabelle auf leer setzen
                         AddRow(Emote.Emote.getEmoteBitmap(), Emote.Emote.Name,Emote.RoleName);
                    }
                }
            }
        }

        

        private void btnReactionDelete_Click(object sender, EventArgs e)
        {
            
        }

        #endregion
    }
}
