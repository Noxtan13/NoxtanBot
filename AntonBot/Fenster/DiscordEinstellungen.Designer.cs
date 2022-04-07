
namespace AntonBot.Fenster
{
    partial class DiscordEinstellungen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiscordEinstellungen));
            this.tabFenster = new System.Windows.Forms.TabControl();
            this.TabEinrichtung = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAdmin = new System.Windows.Forms.CheckBox();
            this.ChkListSprache = new System.Windows.Forms.CheckedListBox();
            this.lblSumme = new System.Windows.Forms.Label();
            this.ChkListText = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ChkListAllgemein = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnToken = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnHilfe = new System.Windows.Forms.Button();
            this.txtClientID = new System.Windows.Forms.TextBox();
            this.btnScopesAnfordern = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.TabEvents = new System.Windows.Forms.TabPage();
            this.chkUse = new System.Windows.Forms.CheckBox();
            this.btnÜbernehmen = new System.Windows.Forms.Button();
            this.grpEvent = new System.Windows.Forms.GroupBox();
            this.btnDiscordChannel = new System.Windows.Forms.Button();
            this.txtDiscordChat = new System.Windows.Forms.TextBox();
            this.chkDiscordAusgabe = new System.Windows.Forms.CheckBox();
            this.txtKonsolenFenster = new System.Windows.Forms.TextBox();
            this.chkTextReaction = new System.Windows.Forms.CheckBox();
            this.txtChatReaktion = new System.Windows.Forms.TextBox();
            this.chkKonsoleAusgabe = new System.Windows.Forms.CheckBox();
            this.btnVariable = new System.Windows.Forms.Button();
            this.cmbVariable = new System.Windows.Forms.ComboBox();
            this.LstEvents = new System.Windows.Forms.ListBox();
            this.tabInfos = new System.Windows.Forms.TabPage();
            this.tabFenster.SuspendLayout();
            this.TabEinrichtung.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.TabEvents.SuspendLayout();
            this.grpEvent.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabFenster
            // 
            this.tabFenster.Controls.Add(this.TabEinrichtung);
            this.tabFenster.Controls.Add(this.TabEvents);
            this.tabFenster.Controls.Add(this.tabInfos);
            this.tabFenster.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.tabFenster.Location = new System.Drawing.Point(12, 12);
            this.tabFenster.Name = "tabFenster";
            this.tabFenster.SelectedIndex = 0;
            this.tabFenster.Size = new System.Drawing.Size(807, 691);
            this.tabFenster.TabIndex = 0;
            // 
            // TabEinrichtung
            // 
            this.TabEinrichtung.Controls.Add(this.label5);
            this.TabEinrichtung.Controls.Add(this.txtToken);
            this.TabEinrichtung.Controls.Add(this.groupBox1);
            this.TabEinrichtung.Controls.Add(this.btnToken);
            this.TabEinrichtung.Controls.Add(this.label4);
            this.TabEinrichtung.Controls.Add(this.btnHilfe);
            this.TabEinrichtung.Controls.Add(this.txtClientID);
            this.TabEinrichtung.Controls.Add(this.btnScopesAnfordern);
            this.TabEinrichtung.Controls.Add(this.linkLabel1);
            this.TabEinrichtung.Location = new System.Drawing.Point(4, 39);
            this.TabEinrichtung.Name = "TabEinrichtung";
            this.TabEinrichtung.Padding = new System.Windows.Forms.Padding(3);
            this.TabEinrichtung.Size = new System.Drawing.Size(799, 648);
            this.TabEinrichtung.TabIndex = 0;
            this.TabEinrichtung.Text = "Einrichtung";
            this.TabEinrichtung.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 30);
            this.label5.TabIndex = 26;
            this.label5.Text = "Token:";
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(11, 117);
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(447, 35);
            this.txtToken.TabIndex = 25;
            this.txtToken.TextChanged += new System.EventHandler(this.txtToken_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAdmin);
            this.groupBox1.Controls.Add(this.ChkListSprache);
            this.groupBox1.Controls.Add(this.lblSumme);
            this.groupBox1.Controls.Add(this.ChkListText);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ChkListAllgemein);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 195);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(754, 473);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // chkAdmin
            // 
            this.chkAdmin.AutoSize = true;
            this.chkAdmin.Location = new System.Drawing.Point(9, 437);
            this.chkAdmin.Name = "chkAdmin";
            this.chkAdmin.Size = new System.Drawing.Size(165, 34);
            this.chkAdmin.TabIndex = 6;
            this.chkAdmin.Text = "Administrator";
            this.chkAdmin.UseVisualStyleBackColor = true;
            this.chkAdmin.CheckedChanged += new System.EventHandler(this.chkAdmin_CheckedChanged);
            // 
            // ChkListSprache
            // 
            this.ChkListSprache.FormattingEnabled = true;
            this.ChkListSprache.Items.AddRange(new object[] {
            "Connect",
            "Speak",
            "Video",
            "Mute Members",
            "Deafen Members",
            "Move Members",
            "Use Voice Activity",
            "Priority Speaker"});
            this.ChkListSprache.Location = new System.Drawing.Point(501, 37);
            this.ChkListSprache.Name = "ChkListSprache";
            this.ChkListSprache.Size = new System.Drawing.Size(240, 394);
            this.ChkListSprache.TabIndex = 5;
            this.ChkListSprache.SelectedIndexChanged += new System.EventHandler(this.ChkListSprache_SelectedIndexChanged);
            // 
            // lblSumme
            // 
            this.lblSumme.AutoSize = true;
            this.lblSumme.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblSumme.Location = new System.Drawing.Point(610, 437);
            this.lblSumme.Name = "lblSumme";
            this.lblSumme.Size = new System.Drawing.Size(131, 13);
            this.lblSumme.TabIndex = 24;
            this.lblSumme.Text = "Aufsummierte Berechnung";
            // 
            // ChkListText
            // 
            this.ChkListText.FormattingEnabled = true;
            this.ChkListText.Items.AddRange(new object[] {
            "Send Messages",
            "Send TTS Messages",
            "Manage Messages",
            "Embed Links",
            "Attach Files",
            "Read Message History",
            "Mention Everyone",
            "Use External Emojis",
            "Add Reactions",
            "Use Slash Commands"});
            this.ChkListText.Location = new System.Drawing.Point(255, 37);
            this.ChkListText.Name = "ChkListText";
            this.ChkListText.Size = new System.Drawing.Size(240, 394);
            this.ChkListText.TabIndex = 4;
            this.ChkListText.SelectedIndexChanged += new System.EventHandler(this.ChkListText_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.Location = new System.Drawing.Point(501, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Sprach Berechtigungen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(255, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Text Berechtigungen";
            // 
            // ChkListAllgemein
            // 
            this.ChkListAllgemein.FormattingEnabled = true;
            this.ChkListAllgemein.Items.AddRange(new object[] {
            "View Audit Log",
            "View Server Insights",
            "Manage Server",
            "Manage Roles",
            "Manage Channels",
            "Kick Members",
            "Ban Members",
            "Create Instant Invite",
            "Change Nickname",
            "Manage Nicknames",
            "Manage Emojis",
            "Manage Webhooks",
            "View Channels"});
            this.ChkListAllgemein.Location = new System.Drawing.Point(9, 37);
            this.ChkListAllgemein.Name = "ChkListAllgemein";
            this.ChkListAllgemein.Size = new System.Drawing.Size(240, 394);
            this.ChkListAllgemein.TabIndex = 1;
            this.ChkListAllgemein.SelectedIndexChanged += new System.EventHandler(this.ChkListAllgemein_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Allgemeine Berechtigungen";
            // 
            // btnToken
            // 
            this.btnToken.Location = new System.Drawing.Point(482, 117);
            this.btnToken.Name = "btnToken";
            this.btnToken.Size = new System.Drawing.Size(283, 38);
            this.btnToken.TabIndex = 20;
            this.btnToken.Text = "Token holen";
            this.btnToken.UseVisualStyleBackColor = true;
            this.btnToken.Click += new System.EventHandler(this.btnToken_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 30);
            this.label4.TabIndex = 19;
            this.label4.Text = "Client-ID:";
            // 
            // btnHilfe
            // 
            this.btnHilfe.Location = new System.Drawing.Point(482, 72);
            this.btnHilfe.Name = "btnHilfe";
            this.btnHilfe.Size = new System.Drawing.Size(283, 39);
            this.btnHilfe.TabIndex = 18;
            this.btnHilfe.Text = "Hilfe in HTML";
            this.btnHilfe.UseVisualStyleBackColor = true;
            // 
            // txtClientID
            // 
            this.txtClientID.Location = new System.Drawing.Point(11, 46);
            this.txtClientID.Name = "txtClientID";
            this.txtClientID.Size = new System.Drawing.Size(447, 35);
            this.txtClientID.TabIndex = 17;
            this.txtClientID.TextChanged += new System.EventHandler(this.txtClientID_TextChanged);
            // 
            // btnScopesAnfordern
            // 
            this.btnScopesAnfordern.Location = new System.Drawing.Point(482, 27);
            this.btnScopesAnfordern.Name = "btnScopesAnfordern";
            this.btnScopesAnfordern.Size = new System.Drawing.Size(283, 39);
            this.btnScopesAnfordern.TabIndex = 15;
            this.btnScopesAnfordern.Text = "Server Joinen";
            this.btnScopesAnfordern.UseVisualStyleBackColor = true;
            this.btnScopesAnfordern.Click += new System.EventHandler(this.btnScopesAnfordern_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(6, 155);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(104, 30);
            this.linkLabel1.TabIndex = 16;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "linkLabel1";
            // 
            // TabEvents
            // 
            this.TabEvents.Controls.Add(this.chkUse);
            this.TabEvents.Controls.Add(this.btnÜbernehmen);
            this.TabEvents.Controls.Add(this.grpEvent);
            this.TabEvents.Controls.Add(this.LstEvents);
            this.TabEvents.Location = new System.Drawing.Point(4, 39);
            this.TabEvents.Name = "TabEvents";
            this.TabEvents.Size = new System.Drawing.Size(799, 648);
            this.TabEvents.TabIndex = 1;
            this.TabEvents.Text = "Event-Reaktionen";
            this.TabEvents.UseVisualStyleBackColor = true;
            // 
            // chkUse
            // 
            this.chkUse.AutoSize = true;
            this.chkUse.Location = new System.Drawing.Point(301, 3);
            this.chkUse.Name = "chkUse";
            this.chkUse.Size = new System.Drawing.Size(225, 34);
            this.chkUse.TabIndex = 32;
            this.chkUse.Text = "Auf Event Reagieren";
            this.chkUse.UseVisualStyleBackColor = true;
            this.chkUse.CheckedChanged += new System.EventHandler(this.chkUse_CheckedChanged);
            // 
            // btnÜbernehmen
            // 
            this.btnÜbernehmen.BackColor = System.Drawing.Color.LightGreen;
            this.btnÜbernehmen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnÜbernehmen.Location = new System.Drawing.Point(298, 614);
            this.btnÜbernehmen.Name = "btnÜbernehmen";
            this.btnÜbernehmen.Size = new System.Drawing.Size(167, 23);
            this.btnÜbernehmen.TabIndex = 31;
            this.btnÜbernehmen.Text = "Übernehmen und Speichern";
            this.btnÜbernehmen.UseVisualStyleBackColor = false;
            this.btnÜbernehmen.Click += new System.EventHandler(this.btnÜbernehmen_Click);
            // 
            // grpEvent
            // 
            this.grpEvent.Controls.Add(this.btnDiscordChannel);
            this.grpEvent.Controls.Add(this.txtDiscordChat);
            this.grpEvent.Controls.Add(this.chkDiscordAusgabe);
            this.grpEvent.Controls.Add(this.txtKonsolenFenster);
            this.grpEvent.Controls.Add(this.chkTextReaction);
            this.grpEvent.Controls.Add(this.txtChatReaktion);
            this.grpEvent.Controls.Add(this.chkKonsoleAusgabe);
            this.grpEvent.Controls.Add(this.btnVariable);
            this.grpEvent.Controls.Add(this.cmbVariable);
            this.grpEvent.Enabled = false;
            this.grpEvent.Location = new System.Drawing.Point(301, 39);
            this.grpEvent.Name = "grpEvent";
            this.grpEvent.Size = new System.Drawing.Size(487, 569);
            this.grpEvent.TabIndex = 30;
            this.grpEvent.TabStop = false;
            // 
            // btnDiscordChannel
            // 
            this.btnDiscordChannel.Location = new System.Drawing.Point(387, 18);
            this.btnDiscordChannel.Name = "btnDiscordChannel";
            this.btnDiscordChannel.Size = new System.Drawing.Size(100, 35);
            this.btnDiscordChannel.TabIndex = 27;
            this.btnDiscordChannel.Text = "Auswahl";
            this.btnDiscordChannel.UseVisualStyleBackColor = true;
            this.btnDiscordChannel.Click += new System.EventHandler(this.btnDiscordChannel_Click);
            // 
            // txtDiscordChat
            // 
            this.txtDiscordChat.Location = new System.Drawing.Point(6, 59);
            this.txtDiscordChat.Multiline = true;
            this.txtDiscordChat.Name = "txtDiscordChat";
            this.txtDiscordChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDiscordChat.Size = new System.Drawing.Size(475, 148);
            this.txtDiscordChat.TabIndex = 26;
            this.txtDiscordChat.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtDiscordChat_MouseClick);
            this.txtDiscordChat.TextChanged += new System.EventHandler(this.txtDiscordChat_TextChanged);
            // 
            // chkDiscordAusgabe
            // 
            this.chkDiscordAusgabe.AutoSize = true;
            this.chkDiscordAusgabe.Location = new System.Drawing.Point(6, 19);
            this.chkDiscordAusgabe.Name = "chkDiscordAusgabe";
            this.chkDiscordAusgabe.Size = new System.Drawing.Size(380, 34);
            this.chkDiscordAusgabe.TabIndex = 25;
            this.chkDiscordAusgabe.Text = "In einem Discord-Channel ausgeben:";
            this.chkDiscordAusgabe.UseVisualStyleBackColor = true;
            this.chkDiscordAusgabe.CheckedChanged += new System.EventHandler(this.chkDiscordAusgabe_CheckedChanged);
            // 
            // txtKonsolenFenster
            // 
            this.txtKonsolenFenster.Location = new System.Drawing.Point(6, 253);
            this.txtKonsolenFenster.Multiline = true;
            this.txtKonsolenFenster.Name = "txtKonsolenFenster";
            this.txtKonsolenFenster.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtKonsolenFenster.Size = new System.Drawing.Size(475, 110);
            this.txtKonsolenFenster.TabIndex = 24;
            this.txtKonsolenFenster.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtKonsolenFenster_MouseClick);
            this.txtKonsolenFenster.TextChanged += new System.EventHandler(this.txtKonsolenFenster_TextChanged);
            // 
            // chkTextReaction
            // 
            this.chkTextReaction.AutoSize = true;
            this.chkTextReaction.Location = new System.Drawing.Point(6, 369);
            this.chkTextReaction.Name = "chkTextReaction";
            this.chkTextReaction.Size = new System.Drawing.Size(361, 34);
            this.chkTextReaction.TabIndex = 0;
            this.chkTextReaction.Text = "Im Twitch-Chat mit Text reagieren:";
            this.chkTextReaction.UseVisualStyleBackColor = true;
            this.chkTextReaction.CheckedChanged += new System.EventHandler(this.chkTextReaction_CheckedChanged);
            // 
            // txtChatReaktion
            // 
            this.txtChatReaktion.Location = new System.Drawing.Point(6, 409);
            this.txtChatReaktion.Multiline = true;
            this.txtChatReaktion.Name = "txtChatReaktion";
            this.txtChatReaktion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChatReaktion.Size = new System.Drawing.Size(475, 110);
            this.txtChatReaktion.TabIndex = 1;
            this.txtChatReaktion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtChatReaktion_MouseClick);
            this.txtChatReaktion.TextChanged += new System.EventHandler(this.txtChatReaktion_TextChanged);
            // 
            // chkKonsoleAusgabe
            // 
            this.chkKonsoleAusgabe.AutoSize = true;
            this.chkKonsoleAusgabe.Location = new System.Drawing.Point(6, 213);
            this.chkKonsoleAusgabe.Name = "chkKonsoleAusgabe";
            this.chkKonsoleAusgabe.Size = new System.Drawing.Size(323, 34);
            this.chkKonsoleAusgabe.TabIndex = 23;
            this.chkKonsoleAusgabe.Text = "Im KonsolenFenster ausgeben:";
            this.chkKonsoleAusgabe.UseVisualStyleBackColor = true;
            this.chkKonsoleAusgabe.CheckedChanged += new System.EventHandler(this.chkKonsoleAusgabe_CheckedChanged);
            // 
            // btnVariable
            // 
            this.btnVariable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnVariable.Location = new System.Drawing.Point(332, 525);
            this.btnVariable.Name = "btnVariable";
            this.btnVariable.Size = new System.Drawing.Size(149, 38);
            this.btnVariable.TabIndex = 20;
            this.btnVariable.Text = "Variable im letzten Textfeld hinzufügen";
            this.btnVariable.UseVisualStyleBackColor = true;
            this.btnVariable.Click += new System.EventHandler(this.btnVariable_Click);
            // 
            // cmbVariable
            // 
            this.cmbVariable.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.cmbVariable.FormattingEnabled = true;
            this.cmbVariable.Items.AddRange(new object[] {
            "OptionalerTeil",
            "VariablerTeil",
            "Name",
            "KommandosBefehlsKette",
            "TwitchBefehlsKette"});
            this.cmbVariable.Location = new System.Drawing.Point(6, 525);
            this.cmbVariable.Name = "cmbVariable";
            this.cmbVariable.Size = new System.Drawing.Size(318, 38);
            this.cmbVariable.TabIndex = 19;
            // 
            // LstEvents
            // 
            this.LstEvents.FormattingEnabled = true;
            this.LstEvents.ItemHeight = 30;
            this.LstEvents.Items.AddRange(new object[] {
            "OnUserJoined",
            "OnUserLeft"});
            this.LstEvents.Location = new System.Drawing.Point(3, 3);
            this.LstEvents.Name = "LstEvents";
            this.LstEvents.Size = new System.Drawing.Size(289, 634);
            this.LstEvents.TabIndex = 29;
            this.LstEvents.SelectedIndexChanged += new System.EventHandler(this.LstEvents_SelectedIndexChanged);
            // 
            // tabInfos
            // 
            this.tabInfos.Location = new System.Drawing.Point(4, 39);
            this.tabInfos.Name = "tabInfos";
            this.tabInfos.Size = new System.Drawing.Size(799, 648);
            this.tabInfos.TabIndex = 2;
            this.tabInfos.Text = "Emotes & Rollen";
            this.tabInfos.UseVisualStyleBackColor = true;
            // 
            // DiscordEinstellungen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 707);
            this.Controls.Add(this.tabFenster);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DiscordEinstellungen";
            this.Text = "DiscordEinstellungen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DiscordEinstellungen_FormClosing);
            this.Load += new System.EventHandler(this.DiscordEinstellungen_Load);
            this.tabFenster.ResumeLayout(false);
            this.TabEinrichtung.ResumeLayout(false);
            this.TabEinrichtung.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.TabEvents.ResumeLayout(false);
            this.TabEvents.PerformLayout();
            this.grpEvent.ResumeLayout(false);
            this.grpEvent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabFenster;
        private System.Windows.Forms.TabPage TabEinrichtung;
        private System.Windows.Forms.Button btnToken;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnHilfe;
        private System.Windows.Forms.TextBox txtClientID;
        private System.Windows.Forms.Button btnScopesAnfordern;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox ChkListSprache;
        private System.Windows.Forms.CheckedListBox ChkListText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox ChkListAllgemein;
        private System.Windows.Forms.Label lblSumme;
        private System.Windows.Forms.CheckBox chkAdmin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.TabPage TabEvents;
        private System.Windows.Forms.Button btnÜbernehmen;
        private System.Windows.Forms.GroupBox grpEvent;
        private System.Windows.Forms.Button btnDiscordChannel;
        private System.Windows.Forms.TextBox txtDiscordChat;
        private System.Windows.Forms.CheckBox chkDiscordAusgabe;
        private System.Windows.Forms.TextBox txtKonsolenFenster;
        private System.Windows.Forms.CheckBox chkKonsoleAusgabe;
        private System.Windows.Forms.Button btnVariable;
        private System.Windows.Forms.ComboBox cmbVariable;
        private System.Windows.Forms.TextBox txtChatReaktion;
        private System.Windows.Forms.CheckBox chkTextReaction;
        private System.Windows.Forms.ListBox LstEvents;
        private System.Windows.Forms.CheckBox chkUse;
        private System.Windows.Forms.TabPage tabInfos;
    }
}