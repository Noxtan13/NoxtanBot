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
            this.chkTwitchAutoBan = new System.Windows.Forms.CheckBox();
            this.chkAutoTwitch = new System.Windows.Forms.CheckBox();
            this.chkAutoDiscord = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabAutoBot = new System.Windows.Forms.TabPage();
            this.btnWhiteListDelete = new System.Windows.Forms.Button();
            this.btnWhiteListAdd = new System.Windows.Forms.Button();
            this.txtWhiteList = new System.Windows.Forms.TextBox();
            this.lstWhiteList = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NUDLogAmount = new System.Windows.Forms.NumericUpDown();
            this.NUDLogDuration = new System.Windows.Forms.NumericUpDown();
            this.chkAutoBotBannUse = new System.Windows.Forms.CheckBox();
            this.tabPfade = new System.Windows.Forms.TabPage();
            this.txtStandardPfad = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TabControllList = new System.Windows.Forms.TabControl();
            this.tabWhite = new System.Windows.Forms.TabPage();
            this.tabBlack = new System.Windows.Forms.TabPage();
            this.btnBlackRemove = new System.Windows.Forms.Button();
            this.lstBlackList = new System.Windows.Forms.ListBox();
            this.btnBlackAdd = new System.Windows.Forms.Button();
            this.txtBlackList = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.TabStart.SuspendLayout();
            this.tabAutoBot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDLogAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDLogDuration)).BeginInit();
            this.tabPfade.SuspendLayout();
            this.TabControllList.SuspendLayout();
            this.tabWhite.SuspendLayout();
            this.tabBlack.SuspendLayout();
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
            this.TabStart.Controls.Add(this.chkTwitchAutoBan);
            this.TabStart.Controls.Add(this.chkAutoTwitch);
            this.TabStart.Controls.Add(this.chkAutoDiscord);
            this.TabStart.Controls.Add(this.label1);
            this.TabStart.Location = new System.Drawing.Point(4, 39);
            this.TabStart.Name = "TabStart";
            this.TabStart.Padding = new System.Windows.Forms.Padding(3);
            this.TabStart.Size = new System.Drawing.Size(720, 350);
            this.TabStart.TabIndex = 0;
            this.TabStart.Text = "Start-Einstellung";
            this.TabStart.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(183, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 30);
            this.label4.TabIndex = 12;
            this.label4.Text = "Channel:";
            // 
            // txtDiscordOtherChannel
            // 
            this.txtDiscordOtherChannel.Enabled = false;
            this.txtDiscordOtherChannel.Location = new System.Drawing.Point(283, 189);
            this.txtDiscordOtherChannel.Name = "txtDiscordOtherChannel";
            this.txtDiscordOtherChannel.Size = new System.Drawing.Size(339, 35);
            this.txtDiscordOtherChannel.TabIndex = 11;
            this.txtDiscordOtherChannel.Leave += new System.EventHandler(this.txtDiscordOtherChannel_Leave);
            // 
            // chkOtherChannelDiscord
            // 
            this.chkOtherChannelDiscord.AutoSize = true;
            this.chkOtherChannelDiscord.Location = new System.Drawing.Point(188, 155);
            this.chkOtherChannelDiscord.Name = "chkOtherChannelDiscord";
            this.chkOtherChannelDiscord.Size = new System.Drawing.Size(434, 34);
            this.chkOtherChannelDiscord.TabIndex = 10;
            this.chkOtherChannelDiscord.Text = "Einträge in Discord-Channel protokolieren";
            this.chkOtherChannelDiscord.UseVisualStyleBackColor = true;
            this.chkOtherChannelDiscord.CheckedChanged += new System.EventHandler(this.chkOtherChannelDiscord_CheckedChanged);
            // 
            // chkTwitchAutoMessage
            // 
            this.chkTwitchAutoMessage.AutoSize = true;
            this.chkTwitchAutoMessage.Enabled = false;
            this.chkTwitchAutoMessage.Location = new System.Drawing.Point(188, 89);
            this.chkTwitchAutoMessage.Name = "chkTwitchAutoMessage";
            this.chkTwitchAutoMessage.Size = new System.Drawing.Size(202, 34);
            this.chkTwitchAutoMessage.TabIndex = 9;
            this.chkTwitchAutoMessage.Text = "Auto-Nachrichten";
            this.chkTwitchAutoMessage.UseVisualStyleBackColor = true;
            // 
            // chkTwitchAutoBan
            // 
            this.chkTwitchAutoBan.AutoSize = true;
            this.chkTwitchAutoBan.Location = new System.Drawing.Point(188, 129);
            this.chkTwitchAutoBan.Name = "chkTwitchAutoBan";
            this.chkTwitchAutoBan.Size = new System.Drawing.Size(237, 34);
            this.chkTwitchAutoBan.TabIndex = 8;
            this.chkTwitchAutoBan.Text = "Twitch Bots Auto Ban";
            this.chkTwitchAutoBan.UseVisualStyleBackColor = true;
            // 
            // chkAutoTwitch
            // 
            this.chkAutoTwitch.AutoSize = true;
            this.chkAutoTwitch.Location = new System.Drawing.Point(14, 89);
            this.chkAutoTwitch.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.chkAutoTwitch.Name = "chkAutoTwitch";
            this.chkAutoTwitch.Size = new System.Drawing.Size(93, 34);
            this.chkAutoTwitch.TabIndex = 7;
            this.chkAutoTwitch.Text = "Twitch";
            this.chkAutoTwitch.UseVisualStyleBackColor = true;
            // 
            // chkAutoDiscord
            // 
            this.chkAutoDiscord.AutoSize = true;
            this.chkAutoDiscord.Location = new System.Drawing.Point(14, 40);
            this.chkAutoDiscord.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.chkAutoDiscord.Name = "chkAutoDiscord";
            this.chkAutoDiscord.Size = new System.Drawing.Size(105, 34);
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
            this.label1.Size = new System.Drawing.Size(669, 30);
            this.label1.TabIndex = 6;
            this.label1.Text = "Auswahl der Plattformen, die beim Start sich automatisch verbinden:";
            // 
            // tabAutoBot
            // 
            this.tabAutoBot.Controls.Add(this.TabControllList);
            this.tabAutoBot.Controls.Add(this.chkAutoBotBannUse);
            this.tabAutoBot.Location = new System.Drawing.Point(4, 39);
            this.tabAutoBot.Name = "tabAutoBot";
            this.tabAutoBot.Padding = new System.Windows.Forms.Padding(3);
            this.tabAutoBot.Size = new System.Drawing.Size(720, 350);
            this.tabAutoBot.TabIndex = 1;
            this.tabAutoBot.Text = "AutoBot-Bann";
            this.tabAutoBot.UseVisualStyleBackColor = true;
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
            // txtWhiteList
            // 
            this.txtWhiteList.Location = new System.Drawing.Point(11, 97);
            this.txtWhiteList.Name = "txtWhiteList";
            this.txtWhiteList.Size = new System.Drawing.Size(350, 35);
            this.txtWhiteList.TabIndex = 5;
            // 
            // lstWhiteList
            // 
            this.lstWhiteList.FormattingEnabled = true;
            this.lstWhiteList.ItemHeight = 30;
            this.lstWhiteList.Location = new System.Drawing.Point(367, 15);
            this.lstWhiteList.Name = "lstWhiteList";
            this.lstWhiteList.Size = new System.Drawing.Size(325, 214);
            this.lstWhiteList.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 30);
            this.label3.TabIndex = 3;
            this.label3.Text = "Erlaubte Häufigkeit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Gültigkeit der Einträge";
            // 
            // NUDLogAmount
            // 
            this.NUDLogAmount.Location = new System.Drawing.Point(241, 56);
            this.NUDLogAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDLogAmount.Name = "NUDLogAmount";
            this.NUDLogAmount.Size = new System.Drawing.Size(120, 35);
            this.NUDLogAmount.TabIndex = 1;
            this.NUDLogAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NUDLogDuration
            // 
            this.NUDLogDuration.Location = new System.Drawing.Point(241, 15);
            this.NUDLogDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDLogDuration.Name = "NUDLogDuration";
            this.NUDLogDuration.Size = new System.Drawing.Size(120, 35);
            this.NUDLogDuration.TabIndex = 0;
            this.NUDLogDuration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkAutoBotBannUse
            // 
            this.chkAutoBotBannUse.AutoSize = true;
            this.chkAutoBotBannUse.Location = new System.Drawing.Point(6, 6);
            this.chkAutoBotBannUse.Name = "chkAutoBotBannUse";
            this.chkAutoBotBannUse.Size = new System.Drawing.Size(226, 34);
            this.chkAutoBotBannUse.TabIndex = 0;
            this.chkAutoBotBannUse.Text = "Funktion verwenden";
            this.chkAutoBotBannUse.UseVisualStyleBackColor = true;
            this.chkAutoBotBannUse.CheckedChanged += new System.EventHandler(this.chkAutoBotBannUse_CheckedChanged);
            // 
            // tabPfade
            // 
            this.tabPfade.Controls.Add(this.txtStandardPfad);
            this.tabPfade.Controls.Add(this.label5);
            this.tabPfade.Location = new System.Drawing.Point(4, 39);
            this.tabPfade.Name = "tabPfade";
            this.tabPfade.Size = new System.Drawing.Size(720, 350);
            this.tabPfade.TabIndex = 2;
            this.tabPfade.Text = "Pfade";
            this.tabPfade.UseVisualStyleBackColor = true;
            // 
            // txtStandardPfad
            // 
            this.txtStandardPfad.Location = new System.Drawing.Point(177, 13);
            this.txtStandardPfad.Name = "txtStandardPfad";
            this.txtStandardPfad.Size = new System.Drawing.Size(527, 35);
            this.txtStandardPfad.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 30);
            this.label5.TabIndex = 0;
            this.label5.Text = "Standard-Pfad:";
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
            this.tabWhite.Location = new System.Drawing.Point(4, 39);
            this.tabWhite.Name = "tabWhite";
            this.tabWhite.Padding = new System.Windows.Forms.Padding(3);
            this.tabWhite.Size = new System.Drawing.Size(700, 249);
            this.tabWhite.TabIndex = 0;
            this.tabWhite.Text = "Whitelist";
            this.tabWhite.UseVisualStyleBackColor = true;
            // 
            // tabBlack
            // 
            this.tabBlack.Controls.Add(this.btnBlackRemove);
            this.tabBlack.Controls.Add(this.lstBlackList);
            this.tabBlack.Controls.Add(this.btnBlackAdd);
            this.tabBlack.Controls.Add(this.txtBlackList);
            this.tabBlack.Location = new System.Drawing.Point(4, 39);
            this.tabBlack.Name = "tabBlack";
            this.tabBlack.Padding = new System.Windows.Forms.Padding(3);
            this.tabBlack.Size = new System.Drawing.Size(700, 249);
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
            this.lstBlackList.ItemHeight = 30;
            this.lstBlackList.Location = new System.Drawing.Point(368, 17);
            this.lstBlackList.Name = "lstBlackList";
            this.lstBlackList.Size = new System.Drawing.Size(325, 214);
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
            this.txtBlackList.Size = new System.Drawing.Size(350, 35);
            this.txtBlackList.TabIndex = 13;
            // 
            // AllgEinstellungen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
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
            ((System.ComponentModel.ISupportInitialize)(this.NUDLogAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDLogDuration)).EndInit();
            this.tabPfade.ResumeLayout(false);
            this.tabPfade.PerformLayout();
            this.TabControllList.ResumeLayout(false);
            this.tabWhite.ResumeLayout(false);
            this.tabWhite.PerformLayout();
            this.tabBlack.ResumeLayout(false);
            this.tabBlack.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSpeichern;
        private System.Windows.Forms.Button btnAbbrechen;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabStart;
        private System.Windows.Forms.CheckBox chkTwitchAutoMessage;
        private System.Windows.Forms.CheckBox chkTwitchAutoBan;
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
    }
}