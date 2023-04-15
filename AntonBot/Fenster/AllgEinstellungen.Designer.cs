namespace AntonBot
{
    partial class AllgEinstellungen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AllgEinstellungen));
            this.btnSpeichern = new System.Windows.Forms.Button();
            this.btnAbbrechen = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabStart = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDiscordOtherChannel = new System.Windows.Forms.TextBox();
            this.chkOtherChannelDiscord = new System.Windows.Forms.CheckBox();
            this.chkTwitchAutoMessage = new System.Windows.Forms.CheckBox();
            this.chkAutoTwitch = new System.Windows.Forms.CheckBox();
            this.chkAutoDiscord = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabAutoBot = new System.Windows.Forms.TabPage();
            this.TabControllList = new System.Windows.Forms.TabControl();
            this.tabWhite = new System.Windows.Forms.TabPage();
            this.btnWhiteListDelete = new System.Windows.Forms.Button();
            this.lstWhiteList = new System.Windows.Forms.ListBox();
            this.btnWhiteListAdd = new System.Windows.Forms.Button();
            this.NUDLogDuration = new System.Windows.Forms.NumericUpDown();
            this.txtWhiteList = new System.Windows.Forms.TextBox();
            this.NUDLogAmount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabBlack = new System.Windows.Forms.TabPage();
            this.btnBlackRemove = new System.Windows.Forms.Button();
            this.lstBlackList = new System.Windows.Forms.ListBox();
            this.btnBlackAdd = new System.Windows.Forms.Button();
            this.txtBlackList = new System.Windows.Forms.TextBox();
            this.chkAutoBotBannUse = new System.Windows.Forms.CheckBox();
            this.tabPfade = new System.Windows.Forms.TabPage();
            this.btnPfadRecover = new System.Windows.Forms.Button();
            this.btnExplorerHTML = new System.Windows.Forms.Button();
            this.btnExplorerLog = new System.Windows.Forms.Button();
            this.btnExplorerStandard = new System.Windows.Forms.Button();
            this.txtLogPfad = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHTML = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStandardPfad = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.fBDOrdnerAuswahl = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1.SuspendLayout();
            this.TabStart.SuspendLayout();
            this.tabAutoBot.SuspendLayout();
            this.TabControllList.SuspendLayout();
            this.tabWhite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDLogDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDLogAmount)).BeginInit();
            this.tabBlack.SuspendLayout();
            this.tabPfade.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSpeichern
            // 
            this.btnSpeichern.Location = new System.Drawing.Point(15, 415);
            this.btnSpeichern.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnSpeichern.Name = "btnSpeichern";
            this.btnSpeichern.Size = new System.Drawing.Size(363, 53);
            this.btnSpeichern.TabIndex = 1;
            this.btnSpeichern.Text = "Speichern";
            this.btnSpeichern.UseVisualStyleBackColor = true;
            this.btnSpeichern.Click += new System.EventHandler(this.BtnSpeichern_Click);
            // 
            // btnAbbrechen
            // 
            this.btnAbbrechen.Location = new System.Drawing.Point(382, 415);
            this.btnAbbrechen.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(349, 53);
            this.btnAbbrechen.TabIndex = 2;
            this.btnAbbrechen.Text = "Abbrechen";
            this.btnAbbrechen.UseVisualStyleBackColor = true;
            this.btnAbbrechen.Click += new System.EventHandler(this.BtnAbbrechen_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabStart);
            this.tabControl1.Controls.Add(this.tabAutoBot);
            this.tabControl1.Controls.Add(this.tabPfade);
            this.tabControl1.Location = new System.Drawing.Point(15, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(728, 393);
            this.tabControl1.TabIndex = 3;
            // 
            // TabStart
            // 
            this.TabStart.Controls.Add(this.label4);
            this.TabStart.Controls.Add(this.txtDiscordOtherChannel);
            this.TabStart.Controls.Add(this.chkOtherChannelDiscord);
            this.TabStart.Controls.Add(this.chkTwitchAutoMessage);
            this.TabStart.Controls.Add(this.chkAutoTwitch);
            this.TabStart.Controls.Add(this.chkAutoDiscord);
            this.TabStart.Controls.Add(this.label1);
            this.TabStart.Location = new System.Drawing.Point(4, 45);
            this.TabStart.Name = "TabStart";
            this.TabStart.Padding = new System.Windows.Forms.Padding(3);
            this.TabStart.Size = new System.Drawing.Size(720, 344);
            this.TabStart.TabIndex = 0;
            this.TabStart.Text = "Start-Einstellung";
            this.TabStart.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 37);
            this.label4.TabIndex = 12;
            this.label4.Text = "Channel:";
            // 
            // txtDiscordOtherChannel
            // 
            this.txtDiscordOtherChannel.Location = new System.Drawing.Point(133, 218);
            this.txtDiscordOtherChannel.Name = "txtDiscordOtherChannel";
            this.txtDiscordOtherChannel.Size = new System.Drawing.Size(339, 42);
            this.txtDiscordOtherChannel.TabIndex = 11;
            this.txtDiscordOtherChannel.Leave += new System.EventHandler(this.txtDiscordOtherChannel_Leave);
            // 
            // chkOtherChannelDiscord
            // 
            this.chkOtherChannelDiscord.AutoSize = true;
            this.chkOtherChannelDiscord.Location = new System.Drawing.Point(40, 177);
            this.chkOtherChannelDiscord.Name = "chkOtherChannelDiscord";
            this.chkOtherChannelDiscord.Size = new System.Drawing.Size(554, 41);
            this.chkOtherChannelDiscord.TabIndex = 10;
            this.chkOtherChannelDiscord.Text = "Einträge in Discord-Channel protokolieren";
            this.chkOtherChannelDiscord.UseVisualStyleBackColor = true;
            this.chkOtherChannelDiscord.CheckedChanged += new System.EventHandler(this.chkOtherChannelDiscord_CheckedChanged);
            // 
            // chkTwitchAutoMessage
            // 
            this.chkTwitchAutoMessage.AutoSize = true;
            this.chkTwitchAutoMessage.Enabled = false;
            this.chkTwitchAutoMessage.Location = new System.Drawing.Point(40, 130);
            this.chkTwitchAutoMessage.Name = "chkTwitchAutoMessage";
            this.chkTwitchAutoMessage.Size = new System.Drawing.Size(260, 41);
            this.chkTwitchAutoMessage.TabIndex = 9;
            this.chkTwitchAutoMessage.Text = "Auto-Nachrichten";
            this.chkTwitchAutoMessage.UseVisualStyleBackColor = true;
            // 
            // chkAutoTwitch
            // 
            this.chkAutoTwitch.AutoSize = true;
            this.chkAutoTwitch.Location = new System.Drawing.Point(14, 89);
            this.chkAutoTwitch.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.chkAutoTwitch.Name = "chkAutoTwitch";
            this.chkAutoTwitch.Size = new System.Drawing.Size(117, 41);
            this.chkAutoTwitch.TabIndex = 7;
            this.chkAutoTwitch.Text = "Twitch";
            this.chkAutoTwitch.UseVisualStyleBackColor = true;
            this.chkAutoTwitch.CheckedChanged += new System.EventHandler(this.chkAutoTwitch_CheckedChanged_1);
            // 
            // chkAutoDiscord
            // 
            this.chkAutoDiscord.AutoSize = true;
            this.chkAutoDiscord.Location = new System.Drawing.Point(14, 40);
            this.chkAutoDiscord.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.chkAutoDiscord.Name = "chkAutoDiscord";
            this.chkAutoDiscord.Size = new System.Drawing.Size(132, 41);
            this.chkAutoDiscord.TabIndex = 5;
            this.chkAutoDiscord.Text = "Discord";
            this.chkAutoDiscord.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(856, 37);
            this.label1.TabIndex = 6;
            this.label1.Text = "Auswahl der Plattformen, die beim Start sich automatisch verbinden:";
            // 
            // tabAutoBot
            // 
            this.tabAutoBot.Controls.Add(this.TabControllList);
            this.tabAutoBot.Controls.Add(this.chkAutoBotBannUse);
            this.tabAutoBot.Location = new System.Drawing.Point(4, 45);
            this.tabAutoBot.Name = "tabAutoBot";
            this.tabAutoBot.Padding = new System.Windows.Forms.Padding(3);
            this.tabAutoBot.Size = new System.Drawing.Size(720, 344);
            this.tabAutoBot.TabIndex = 1;
            this.tabAutoBot.Text = "AutoBot-Bann";
            this.tabAutoBot.UseVisualStyleBackColor = true;
            // 
            // TabControllList
            // 
            this.TabControllList.Controls.Add(this.tabWhite);
            this.TabControllList.Controls.Add(this.tabBlack);
            this.TabControllList.Location = new System.Drawing.Point(6, 46);
            this.TabControllList.Name = "TabControllList";
            this.TabControllList.SelectedIndex = 0;
            this.TabControllList.Size = new System.Drawing.Size(708, 292);
            this.TabControllList.TabIndex = 2;
            // 
            // tabWhite
            // 
            this.tabWhite.Controls.Add(this.btnWhiteListDelete);
            this.tabWhite.Controls.Add(this.lstWhiteList);
            this.tabWhite.Controls.Add(this.btnWhiteListAdd);
            this.tabWhite.Controls.Add(this.NUDLogDuration);
            this.tabWhite.Controls.Add(this.txtWhiteList);
            this.tabWhite.Controls.Add(this.NUDLogAmount);
            this.tabWhite.Controls.Add(this.label2);
            this.tabWhite.Controls.Add(this.label3);
            this.tabWhite.Location = new System.Drawing.Point(4, 45);
            this.tabWhite.Name = "tabWhite";
            this.tabWhite.Padding = new System.Windows.Forms.Padding(3);
            this.tabWhite.Size = new System.Drawing.Size(700, 243);
            this.tabWhite.TabIndex = 0;
            this.tabWhite.Text = "Whitelist";
            this.tabWhite.UseVisualStyleBackColor = true;
            // 
            // btnWhiteListDelete
            // 
            this.btnWhiteListDelete.Location = new System.Drawing.Point(11, 182);
            this.btnWhiteListDelete.Name = "btnWhiteListDelete";
            this.btnWhiteListDelete.Size = new System.Drawing.Size(202, 38);
            this.btnWhiteListDelete.TabIndex = 7;
            this.btnWhiteListDelete.Text = "Eintrag löschen";
            this.btnWhiteListDelete.UseVisualStyleBackColor = true;
            this.btnWhiteListDelete.Click += new System.EventHandler(this.btnWhiteListDelete_Click);
            // 
            // lstWhiteList
            // 
            this.lstWhiteList.FormattingEnabled = true;
            this.lstWhiteList.ItemHeight = 36;
            this.lstWhiteList.Location = new System.Drawing.Point(367, 15);
            this.lstWhiteList.Name = "lstWhiteList";
            this.lstWhiteList.Size = new System.Drawing.Size(325, 184);
            this.lstWhiteList.TabIndex = 4;
            // 
            // btnWhiteListAdd
            // 
            this.btnWhiteListAdd.Location = new System.Drawing.Point(11, 138);
            this.btnWhiteListAdd.Name = "btnWhiteListAdd";
            this.btnWhiteListAdd.Size = new System.Drawing.Size(202, 38);
            this.btnWhiteListAdd.TabIndex = 6;
            this.btnWhiteListAdd.Text = "Eintrag hinzufügen";
            this.btnWhiteListAdd.UseVisualStyleBackColor = true;
            this.btnWhiteListAdd.Click += new System.EventHandler(this.btnWhiteListAdd_Click);
            // 
            // NUDLogDuration
            // 
            this.NUDLogDuration.Location = new System.Drawing.Point(241, 15);
            this.NUDLogDuration.Name = "NUDLogDuration";
            this.NUDLogDuration.Size = new System.Drawing.Size(120, 42);
            this.NUDLogDuration.TabIndex = 0;
            // 
            // txtWhiteList
            // 
            this.txtWhiteList.Location = new System.Drawing.Point(11, 97);
            this.txtWhiteList.Name = "txtWhiteList";
            this.txtWhiteList.Size = new System.Drawing.Size(350, 42);
            this.txtWhiteList.TabIndex = 5;
            // 
            // NUDLogAmount
            // 
            this.NUDLogAmount.Location = new System.Drawing.Point(241, 56);
            this.NUDLogAmount.Name = "NUDLogAmount";
            this.NUDLogAmount.Size = new System.Drawing.Size(120, 42);
            this.NUDLogAmount.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(292, 37);
            this.label2.TabIndex = 2;
            this.label2.Text = "Gültigkeit der Einträge";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(252, 37);
            this.label3.TabIndex = 3;
            this.label3.Text = "Erlaubte Häufigkeit";
            // 
            // tabBlack
            // 
            this.tabBlack.Controls.Add(this.btnBlackRemove);
            this.tabBlack.Controls.Add(this.lstBlackList);
            this.tabBlack.Controls.Add(this.btnBlackAdd);
            this.tabBlack.Controls.Add(this.txtBlackList);
            this.tabBlack.Location = new System.Drawing.Point(4, 45);
            this.tabBlack.Name = "tabBlack";
            this.tabBlack.Padding = new System.Windows.Forms.Padding(3);
            this.tabBlack.Size = new System.Drawing.Size(700, 243);
            this.tabBlack.TabIndex = 1;
            this.tabBlack.Text = "Blacklist";
            this.tabBlack.UseVisualStyleBackColor = true;
            // 
            // btnBlackRemove
            // 
            this.btnBlackRemove.Location = new System.Drawing.Point(6, 102);
            this.btnBlackRemove.Name = "btnBlackRemove";
            this.btnBlackRemove.Size = new System.Drawing.Size(202, 38);
            this.btnBlackRemove.TabIndex = 15;
            this.btnBlackRemove.Text = "Eintrag löschen";
            this.btnBlackRemove.UseVisualStyleBackColor = true;
            this.btnBlackRemove.Click += new System.EventHandler(this.btnBlackRemove_Click);
            // 
            // lstBlackList
            // 
            this.lstBlackList.FormattingEnabled = true;
            this.lstBlackList.ItemHeight = 36;
            this.lstBlackList.Location = new System.Drawing.Point(368, 17);
            this.lstBlackList.Name = "lstBlackList";
            this.lstBlackList.Size = new System.Drawing.Size(325, 184);
            this.lstBlackList.TabIndex = 12;
            // 
            // btnBlackAdd
            // 
            this.btnBlackAdd.Location = new System.Drawing.Point(6, 58);
            this.btnBlackAdd.Name = "btnBlackAdd";
            this.btnBlackAdd.Size = new System.Drawing.Size(202, 38);
            this.btnBlackAdd.TabIndex = 14;
            this.btnBlackAdd.Text = "Eintrag hinzufügen";
            this.btnBlackAdd.UseVisualStyleBackColor = true;
            this.btnBlackAdd.Click += new System.EventHandler(this.btnBlackAdd_Click);
            // 
            // txtBlackList
            // 
            this.txtBlackList.Location = new System.Drawing.Point(6, 17);
            this.txtBlackList.Name = "txtBlackList";
            this.txtBlackList.Size = new System.Drawing.Size(350, 42);
            this.txtBlackList.TabIndex = 13;
            // 
            // chkAutoBotBannUse
            // 
            this.chkAutoBotBannUse.AutoSize = true;
            this.chkAutoBotBannUse.Location = new System.Drawing.Point(6, 6);
            this.chkAutoBotBannUse.Name = "chkAutoBotBannUse";
            this.chkAutoBotBannUse.Size = new System.Drawing.Size(288, 41);
            this.chkAutoBotBannUse.TabIndex = 0;
            this.chkAutoBotBannUse.Text = "Funktion verwenden";
            this.chkAutoBotBannUse.UseVisualStyleBackColor = true;
            this.chkAutoBotBannUse.CheckedChanged += new System.EventHandler(this.chkAutoBotBannUse_CheckedChanged);
            // 
            // tabPfade
            // 
            this.tabPfade.Controls.Add(this.btnPfadRecover);
            this.tabPfade.Controls.Add(this.btnExplorerHTML);
            this.tabPfade.Controls.Add(this.btnExplorerLog);
            this.tabPfade.Controls.Add(this.btnExplorerStandard);
            this.tabPfade.Controls.Add(this.txtLogPfad);
            this.tabPfade.Controls.Add(this.label7);
            this.tabPfade.Controls.Add(this.txtHTML);
            this.tabPfade.Controls.Add(this.label6);
            this.tabPfade.Controls.Add(this.txtStandardPfad);
            this.tabPfade.Controls.Add(this.label5);
            this.tabPfade.Location = new System.Drawing.Point(4, 45);
            this.tabPfade.Name = "tabPfade";
            this.tabPfade.Size = new System.Drawing.Size(720, 344);
            this.tabPfade.TabIndex = 2;
            this.tabPfade.Text = "Pfade";
            this.tabPfade.UseVisualStyleBackColor = true;
            // 
            // btnPfadRecover
            // 
            this.btnPfadRecover.Location = new System.Drawing.Point(20, 156);
            this.btnPfadRecover.Name = "btnPfadRecover";
            this.btnPfadRecover.Size = new System.Drawing.Size(151, 38);
            this.btnPfadRecover.TabIndex = 9;
            this.btnPfadRecover.Text = "Standard wiederherrstellen";
            this.btnPfadRecover.UseVisualStyleBackColor = true;
            this.btnPfadRecover.Click += new System.EventHandler(this.btnPfadRecover_Click);
            // 
            // btnExplorerHTML
            // 
            this.btnExplorerHTML.Image = ((System.Drawing.Image)(resources.GetObject("btnExplorerHTML.Image")));
            this.btnExplorerHTML.Location = new System.Drawing.Point(679, 102);
            this.btnExplorerHTML.Name = "btnExplorerHTML";
            this.btnExplorerHTML.Size = new System.Drawing.Size(33, 33);
            this.btnExplorerHTML.TabIndex = 8;
            this.btnExplorerHTML.UseVisualStyleBackColor = true;
            this.btnExplorerHTML.Click += new System.EventHandler(this.btnExplorerHTML_Click);
            // 
            // btnExplorerLog
            // 
            this.btnExplorerLog.Image = ((System.Drawing.Image)(resources.GetObject("btnExplorerLog.Image")));
            this.btnExplorerLog.Location = new System.Drawing.Point(679, 57);
            this.btnExplorerLog.Name = "btnExplorerLog";
            this.btnExplorerLog.Size = new System.Drawing.Size(33, 33);
            this.btnExplorerLog.TabIndex = 7;
            this.btnExplorerLog.UseVisualStyleBackColor = true;
            this.btnExplorerLog.Click += new System.EventHandler(this.btnExplorerLog_Click);
            // 
            // btnExplorerStandard
            // 
            this.btnExplorerStandard.Image = global::AntonBot.Properties.Resources.WinExplorer;
            this.btnExplorerStandard.Location = new System.Drawing.Point(679, 13);
            this.btnExplorerStandard.Name = "btnExplorerStandard";
            this.btnExplorerStandard.Size = new System.Drawing.Size(33, 33);
            this.btnExplorerStandard.TabIndex = 6;
            this.btnExplorerStandard.UseVisualStyleBackColor = true;
            this.btnExplorerStandard.Click += new System.EventHandler(this.btnExplorerStandard_Click);
            // 
            // txtLogPfad
            // 
            this.txtLogPfad.Location = new System.Drawing.Point(177, 55);
            this.txtLogPfad.Name = "txtLogPfad";
            this.txtLogPfad.Size = new System.Drawing.Size(496, 42);
            this.txtLogPfad.TabIndex = 5;
            this.txtLogPfad.TextChanged += new System.EventHandler(this.txtLogPfad_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 37);
            this.label7.TabIndex = 4;
            this.label7.Text = "Log-Pfad";
            // 
            // txtHTML
            // 
            this.txtHTML.Location = new System.Drawing.Point(177, 100);
            this.txtHTML.Name = "txtHTML";
            this.txtHTML.Size = new System.Drawing.Size(496, 42);
            this.txtHTML.TabIndex = 3;
            this.txtHTML.TextChanged += new System.EventHandler(this.txtHTML_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 37);
            this.label6.TabIndex = 2;
            this.label6.Text = "HTML-Pfad:";
            // 
            // txtStandardPfad
            // 
            this.txtStandardPfad.Location = new System.Drawing.Point(177, 13);
            this.txtStandardPfad.Name = "txtStandardPfad";
            this.txtStandardPfad.Size = new System.Drawing.Size(496, 42);
            this.txtStandardPfad.TabIndex = 1;
            this.txtStandardPfad.TextChanged += new System.EventHandler(this.txtStandardPfad_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(201, 37);
            this.label5.TabIndex = 0;
            this.label5.Text = "Standard-Pfad:";
            // 
            // AllgEinstellungen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 36F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(752, 484);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnAbbrechen);
            this.Controls.Add(this.btnSpeichern);
            this.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AllgEinstellungen";
            this.ShowInTaskbar = false;
            this.Text = "AllgEinstellungen";
            this.Load += new System.EventHandler(this.AllgEinstellungen_Load);
            this.tabControl1.ResumeLayout(false);
            this.TabStart.ResumeLayout(false);
            this.TabStart.PerformLayout();
            this.tabAutoBot.ResumeLayout(false);
            this.tabAutoBot.PerformLayout();
            this.TabControllList.ResumeLayout(false);
            this.tabWhite.ResumeLayout(false);
            this.tabWhite.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDLogDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDLogAmount)).EndInit();
            this.tabBlack.ResumeLayout(false);
            this.tabBlack.PerformLayout();
            this.tabPfade.ResumeLayout(false);
            this.tabPfade.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSpeichern;
        private System.Windows.Forms.Button btnAbbrechen;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabStart;
        private System.Windows.Forms.CheckBox chkTwitchAutoMessage;
        private System.Windows.Forms.CheckBox chkAutoTwitch;
        private System.Windows.Forms.CheckBox chkAutoDiscord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabAutoBot;
        private System.Windows.Forms.Button btnWhiteListDelete;
        private System.Windows.Forms.Button btnWhiteListAdd;
        private System.Windows.Forms.TextBox txtWhiteList;
        private System.Windows.Forms.ListBox lstWhiteList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown NUDLogAmount;
        private System.Windows.Forms.NumericUpDown NUDLogDuration;
        private System.Windows.Forms.CheckBox chkAutoBotBannUse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDiscordOtherChannel;
        private System.Windows.Forms.CheckBox chkOtherChannelDiscord;
        private System.Windows.Forms.TabPage tabPfade;
        private System.Windows.Forms.TextBox txtStandardPfad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl TabControllList;
        private System.Windows.Forms.TabPage tabWhite;
        private System.Windows.Forms.TabPage tabBlack;
        private System.Windows.Forms.Button btnBlackRemove;
        private System.Windows.Forms.ListBox lstBlackList;
        private System.Windows.Forms.Button btnBlackAdd;
        private System.Windows.Forms.TextBox txtBlackList;
        private System.Windows.Forms.TextBox txtHTML;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLogPfad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnExplorerStandard;
        private System.Windows.Forms.Button btnExplorerHTML;
        private System.Windows.Forms.Button btnExplorerLog;
        private System.Windows.Forms.FolderBrowserDialog fBDOrdnerAuswahl;
        private System.Windows.Forms.Button btnPfadRecover;
    }
}