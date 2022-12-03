namespace AntonBot
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.DiscordStart = new System.Windows.Forms.Button();
            this.DiscordStop = new System.Windows.Forms.Button();
            this.DiscordGroupBox = new System.Windows.Forms.GroupBox();
            this.chkDiscordZeit = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.DiscordStatusStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.TwitchStatusStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolLoadBefehle = new System.Windows.Forms.ToolStripStatusLabel();
            this.MenuLeiste = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allgemeineEinstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.befehleCommandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webSeitenExportierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logZurücksetzenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.telegrammBotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einstellungenExportierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einstellungenImportierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.discordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twitchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.TwitchGroupBox = new System.Windows.Forms.GroupBox();
            this.chkTwitchZeit = new System.Windows.Forms.CheckBox();
            this.TwitchStart = new System.Windows.Forms.Button();
            this.TwitchStop = new System.Windows.Forms.Button();
            this.txtAusgabe = new System.Windows.Forms.TextBox();
            this.UpdateAusgabe = new System.Windows.Forms.Timer(this.components);
            this.btnLoadBefehle = new System.Windows.Forms.Button();
            this.timerResetBox = new System.Windows.Forms.Timer(this.components);
            this.timerOtherChannel = new System.Windows.Forms.Timer(this.components);
            this.sfdEinstellungExport = new System.Windows.Forms.SaveFileDialog();
            this.ofdEinstellungImport = new System.Windows.Forms.OpenFileDialog();
            this.DiscordGroupBox.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.MenuLeiste.SuspendLayout();
            this.TwitchGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // DiscordStart
            // 
            this.DiscordStart.Location = new System.Drawing.Point(12, 44);
            this.DiscordStart.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.DiscordStart.Name = "DiscordStart";
            this.DiscordStart.Size = new System.Drawing.Size(174, 53);
            this.DiscordStart.TabIndex = 0;
            this.DiscordStart.Text = "Bot-Login";
            this.DiscordStart.UseVisualStyleBackColor = true;
            this.DiscordStart.Click += new System.EventHandler(this.DiscordStart_Click);
            // 
            // DiscordStop
            // 
            this.DiscordStop.Enabled = false;
            this.DiscordStop.Location = new System.Drawing.Point(12, 111);
            this.DiscordStop.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.DiscordStop.Name = "DiscordStop";
            this.DiscordStop.Size = new System.Drawing.Size(174, 53);
            this.DiscordStop.TabIndex = 1;
            this.DiscordStop.Text = "Bot-Logout";
            this.DiscordStop.UseVisualStyleBackColor = true;
            this.DiscordStop.Click += new System.EventHandler(this.DiscordStop_Click);
            // 
            // DiscordGroupBox
            // 
            this.DiscordGroupBox.Controls.Add(this.chkDiscordZeit);
            this.DiscordGroupBox.Controls.Add(this.DiscordStart);
            this.DiscordGroupBox.Controls.Add(this.DiscordStop);
            this.DiscordGroupBox.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.DiscordGroupBox.Location = new System.Drawing.Point(24, 94);
            this.DiscordGroupBox.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.DiscordGroupBox.Name = "DiscordGroupBox";
            this.DiscordGroupBox.Padding = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.DiscordGroupBox.Size = new System.Drawing.Size(350, 176);
            this.DiscordGroupBox.TabIndex = 4;
            this.DiscordGroupBox.TabStop = false;
            this.DiscordGroupBox.Text = "Discord";
            // 
            // chkDiscordZeit
            // 
            this.chkDiscordZeit.AutoSize = true;
            this.chkDiscordZeit.Location = new System.Drawing.Point(204, 44);
            this.chkDiscordZeit.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.chkDiscordZeit.Name = "chkDiscordZeit";
            this.chkDiscordZeit.Size = new System.Drawing.Size(134, 34);
            this.chkDiscordZeit.TabIndex = 15;
            this.chkDiscordZeit.Text = "Auto-Send";
            this.chkDiscordZeit.UseVisualStyleBackColor = true;
            this.chkDiscordZeit.CheckedChanged += new System.EventHandler(this.chkDiscordZeit_CheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DiscordStatusStrip,
            this.TwitchStatusStrip,
            this.toolLoadBefehle});
            this.statusStrip1.Location = new System.Drawing.Point(0, 631);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 28, 0);
            this.statusStrip1.Size = new System.Drawing.Size(757, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // DiscordStatusStrip
            // 
            this.DiscordStatusStrip.Name = "DiscordStatusStrip";
            this.DiscordStatusStrip.Size = new System.Drawing.Size(53, 17);
            this.DiscordStatusStrip.Text = "Discord: ";
            this.DiscordStatusStrip.Click += new System.EventHandler(this.DiscordStatusStrip_Click);
            // 
            // TwitchStatusStrip
            // 
            this.TwitchStatusStrip.Name = "TwitchStatusStrip";
            this.TwitchStatusStrip.Size = new System.Drawing.Size(47, 17);
            this.TwitchStatusStrip.Text = "Twitch: ";
            this.TwitchStatusStrip.Click += new System.EventHandler(this.TwitchStatusStrip_Click);
            // 
            // toolLoadBefehle
            // 
            this.toolLoadBefehle.Name = "toolLoadBefehle";
            this.toolLoadBefehle.Size = new System.Drawing.Size(126, 17);
            this.toolLoadBefehle.Text = "Befehle: Nicht geladen";
            // 
            // MenuLeiste
            // 
            this.MenuLeiste.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuLeiste.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuLeiste.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.einstellungenToolStripMenuItem});
            this.MenuLeiste.Location = new System.Drawing.Point(0, 0);
            this.MenuLeiste.Name = "MenuLeiste";
            this.MenuLeiste.Padding = new System.Windows.Forms.Padding(12, 5, 0, 5);
            this.MenuLeiste.Size = new System.Drawing.Size(757, 31);
            this.MenuLeiste.TabIndex = 6;
            this.MenuLeiste.Text = " ";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allgemeineEinstellungenToolStripMenuItem,
            this.befehleCommandsToolStripMenuItem,
            this.webSeitenExportierenToolStripMenuItem,
            this.logZurücksetzenToolStripMenuItem,
            this.telegrammBotToolStripMenuItem,
            this.importExportToolStripMenuItem,
            this.beendenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(51, 21);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // allgemeineEinstellungenToolStripMenuItem
            // 
            this.allgemeineEinstellungenToolStripMenuItem.Name = "allgemeineEinstellungenToolStripMenuItem";
            this.allgemeineEinstellungenToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.allgemeineEinstellungenToolStripMenuItem.Text = "Allgemeine Einstellungen";
            this.allgemeineEinstellungenToolStripMenuItem.Click += new System.EventHandler(this.allgemeineEinstellungenToolStripMenuItem_Click);
            // 
            // befehleCommandsToolStripMenuItem
            // 
            this.befehleCommandsToolStripMenuItem.Name = "befehleCommandsToolStripMenuItem";
            this.befehleCommandsToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.befehleCommandsToolStripMenuItem.Text = "Befehle / Commands";
            this.befehleCommandsToolStripMenuItem.Click += new System.EventHandler(this.befehleCommandsToolStripMenuItem_Click);
            // 
            // webSeitenExportierenToolStripMenuItem
            // 
            this.webSeitenExportierenToolStripMenuItem.Name = "webSeitenExportierenToolStripMenuItem";
            this.webSeitenExportierenToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.webSeitenExportierenToolStripMenuItem.Text = "Web-Seiten exportieren";
            this.webSeitenExportierenToolStripMenuItem.Click += new System.EventHandler(this.webSeitenExportierenToolStripMenuItem_Click);
            // 
            // logZurücksetzenToolStripMenuItem
            // 
            this.logZurücksetzenToolStripMenuItem.Name = "logZurücksetzenToolStripMenuItem";
            this.logZurücksetzenToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.logZurücksetzenToolStripMenuItem.Text = "Log zurücksetzen";
            this.logZurücksetzenToolStripMenuItem.Click += new System.EventHandler(this.logZurücksetzenToolStripMenuItem_Click);
            // 
            // telegrammBotToolStripMenuItem
            // 
            this.telegrammBotToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.telegrammBotToolStripMenuItem.Name = "telegrammBotToolStripMenuItem";
            this.telegrammBotToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.telegrammBotToolStripMenuItem.Text = "Telegramm-Bot";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // importExportToolStripMenuItem
            // 
            this.importExportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.einstellungenExportierenToolStripMenuItem,
            this.einstellungenImportierenToolStripMenuItem});
            this.importExportToolStripMenuItem.Name = "importExportToolStripMenuItem";
            this.importExportToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.importExportToolStripMenuItem.Text = "Import/Export";
            // 
            // einstellungenExportierenToolStripMenuItem
            // 
            this.einstellungenExportierenToolStripMenuItem.Name = "einstellungenExportierenToolStripMenuItem";
            this.einstellungenExportierenToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.einstellungenExportierenToolStripMenuItem.Text = "Einstellungen exportieren";
            this.einstellungenExportierenToolStripMenuItem.Click += new System.EventHandler(this.einstellungenExportierenToolStripMenuItem_Click);
            // 
            // einstellungenImportierenToolStripMenuItem
            // 
            this.einstellungenImportierenToolStripMenuItem.Name = "einstellungenImportierenToolStripMenuItem";
            this.einstellungenImportierenToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.einstellungenImportierenToolStripMenuItem.Text = "Einstellungen importieren";
            this.einstellungenImportierenToolStripMenuItem.Click += new System.EventHandler(this.einstellungenImportierenToolStripMenuItem_Click);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.beendenToolStripMenuItem.Text = "Beenden";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // einstellungenToolStripMenuItem
            // 
            this.einstellungenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.discordToolStripMenuItem,
            this.twitchToolStripMenuItem});
            this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            this.einstellungenToolStripMenuItem.Size = new System.Drawing.Size(163, 21);
            this.einstellungenToolStripMenuItem.Text = "Plattform-Einstellungen";
            // 
            // discordToolStripMenuItem
            // 
            this.discordToolStripMenuItem.Name = "discordToolStripMenuItem";
            this.discordToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.discordToolStripMenuItem.Text = "Discord";
            this.discordToolStripMenuItem.Click += new System.EventHandler(this.discordToolStripMenuItem_Click);
            // 
            // twitchToolStripMenuItem
            // 
            this.twitchToolStripMenuItem.Name = "twitchToolStripMenuItem";
            this.twitchToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.twitchToolStripMenuItem.Text = "Twitch";
            this.twitchToolStripMenuItem.Click += new System.EventHandler(this.twitchToolStripMenuItem_Click);
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Enabled = true;
            this.UpdateTimer.Interval = 1000;
            this.UpdateTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TwitchGroupBox
            // 
            this.TwitchGroupBox.Controls.Add(this.chkTwitchZeit);
            this.TwitchGroupBox.Controls.Add(this.TwitchStart);
            this.TwitchGroupBox.Controls.Add(this.TwitchStop);
            this.TwitchGroupBox.Location = new System.Drawing.Point(392, 94);
            this.TwitchGroupBox.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.TwitchGroupBox.Name = "TwitchGroupBox";
            this.TwitchGroupBox.Padding = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.TwitchGroupBox.Size = new System.Drawing.Size(350, 176);
            this.TwitchGroupBox.TabIndex = 7;
            this.TwitchGroupBox.TabStop = false;
            this.TwitchGroupBox.Text = "Twitch";
            // 
            // chkTwitchZeit
            // 
            this.chkTwitchZeit.AutoSize = true;
            this.chkTwitchZeit.Location = new System.Drawing.Point(204, 44);
            this.chkTwitchZeit.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.chkTwitchZeit.Name = "chkTwitchZeit";
            this.chkTwitchZeit.Size = new System.Drawing.Size(134, 34);
            this.chkTwitchZeit.TabIndex = 16;
            this.chkTwitchZeit.Text = "Auto-Send";
            this.chkTwitchZeit.UseVisualStyleBackColor = true;
            this.chkTwitchZeit.CheckedChanged += new System.EventHandler(this.chkTwitchZeit_CheckedChanged);
            // 
            // TwitchStart
            // 
            this.TwitchStart.Location = new System.Drawing.Point(12, 44);
            this.TwitchStart.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.TwitchStart.Name = "TwitchStart";
            this.TwitchStart.Size = new System.Drawing.Size(174, 53);
            this.TwitchStart.TabIndex = 8;
            this.TwitchStart.Text = "Twitch-Login";
            this.TwitchStart.UseVisualStyleBackColor = true;
            this.TwitchStart.Click += new System.EventHandler(this.TwitchStart_Click);
            // 
            // TwitchStop
            // 
            this.TwitchStop.Enabled = false;
            this.TwitchStop.Location = new System.Drawing.Point(12, 111);
            this.TwitchStop.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.TwitchStop.Name = "TwitchStop";
            this.TwitchStop.Size = new System.Drawing.Size(174, 53);
            this.TwitchStop.TabIndex = 9;
            this.TwitchStop.Text = "Twitch-Logout";
            this.TwitchStop.UseVisualStyleBackColor = true;
            this.TwitchStop.Click += new System.EventHandler(this.TwitchStop_Click);
            // 
            // txtAusgabe
            // 
            this.txtAusgabe.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtAusgabe.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAusgabe.Location = new System.Drawing.Point(24, 284);
            this.txtAusgabe.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.txtAusgabe.Multiline = true;
            this.txtAusgabe.Name = "txtAusgabe";
            this.txtAusgabe.ReadOnly = true;
            this.txtAusgabe.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAusgabe.Size = new System.Drawing.Size(718, 336);
            this.txtAusgabe.TabIndex = 10;
            this.txtAusgabe.Text = "Ausgabe vom NOXTANBOT:";
            this.txtAusgabe.DoubleClick += new System.EventHandler(this.txtAusgabe_DoubleClick);
            // 
            // UpdateAusgabe
            // 
            this.UpdateAusgabe.Enabled = true;
            this.UpdateAusgabe.Interval = 50;
            this.UpdateAusgabe.Tick += new System.EventHandler(this.UpdateAusgabe_Tick);
            // 
            // btnLoadBefehle
            // 
            this.btnLoadBefehle.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnLoadBefehle.Location = new System.Drawing.Point(24, 38);
            this.btnLoadBefehle.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnLoadBefehle.Name = "btnLoadBefehle";
            this.btnLoadBefehle.Size = new System.Drawing.Size(718, 42);
            this.btnLoadBefehle.TabIndex = 14;
            this.btnLoadBefehle.Text = "Load All";
            this.btnLoadBefehle.UseVisualStyleBackColor = true;
            this.btnLoadBefehle.Click += new System.EventHandler(this.btnLoadBefehle_Click);
            // 
            // timerResetBox
            // 
            this.timerResetBox.Interval = 600000;
            this.timerResetBox.Tick += new System.EventHandler(this.timerResetBox_Tick);
            // 
            // timerOtherChannel
            // 
            this.timerOtherChannel.Enabled = true;
            this.timerOtherChannel.Interval = 5000;
            this.timerOtherChannel.Tick += new System.EventHandler(this.timerOtherChannel_Tick);
            // 
            // sfdEinstellungExport
            // 
            this.sfdEinstellungExport.FileName = "Einstellung";
            this.sfdEinstellungExport.RestoreDirectory = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 653);
            this.Controls.Add(this.btnLoadBefehle);
            this.Controls.Add(this.txtAusgabe);
            this.Controls.Add(this.TwitchGroupBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.MenuLeiste);
            this.Controls.Add(this.DiscordGroupBox);
            this.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuLeiste;
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "NoxtanBot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.DiscordGroupBox.ResumeLayout(false);
            this.DiscordGroupBox.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.MenuLeiste.ResumeLayout(false);
            this.MenuLeiste.PerformLayout();
            this.TwitchGroupBox.ResumeLayout(false);
            this.TwitchGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DiscordStart;
        private System.Windows.Forms.Button DiscordStop;
        private System.Windows.Forms.GroupBox DiscordGroupBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel DiscordStatusStrip;
        private System.Windows.Forms.MenuStrip MenuLeiste;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem discordToolStripMenuItem;
        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.ToolStripStatusLabel TwitchStatusStrip;
        private System.Windows.Forms.ToolStripMenuItem twitchToolStripMenuItem;
        private System.Windows.Forms.GroupBox TwitchGroupBox;
        private System.Windows.Forms.Button TwitchStart;
        private System.Windows.Forms.Button TwitchStop;
        public System.Windows.Forms.TextBox txtAusgabe;
        private System.Windows.Forms.Timer UpdateAusgabe;
        private System.Windows.Forms.ToolStripMenuItem allgemeineEinstellungenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem befehleCommandsToolStripMenuItem;
        private System.Windows.Forms.Button btnLoadBefehle;
        private System.Windows.Forms.CheckBox chkDiscordZeit;
        private System.Windows.Forms.CheckBox chkTwitchZeit;
        private System.Windows.Forms.Timer timerResetBox;
        private System.Windows.Forms.ToolStripMenuItem telegrammBotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolLoadBefehle;
        private System.Windows.Forms.Timer timerOtherChannel;
        private System.Windows.Forms.ToolStripMenuItem importExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem einstellungenExportierenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem einstellungenImportierenToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog sfdEinstellungExport;
        private System.Windows.Forms.OpenFileDialog ofdEinstellungImport;
        private System.Windows.Forms.ToolStripMenuItem webSeitenExportierenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logZurücksetzenToolStripMenuItem;
    }
}

