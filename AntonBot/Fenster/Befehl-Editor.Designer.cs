namespace AntonBot
{
    partial class Befehl_Editor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Befehl_Editor));
            this.BefehlTab = new System.Windows.Forms.TabControl();
            this.Tab_Commands = new System.Windows.Forms.TabPage();
            this.BefehlList = new System.Windows.Forms.ListBox();
            this.Tab_Time_Commands = new System.Windows.Forms.TabPage();
            this.ZeitBefehlList = new System.Windows.Forms.ListBox();
            this.Tab_Twitch_Commands = new System.Windows.Forms.TabPage();
            this.TwitchList = new System.Windows.Forms.ListBox();
            this.Tab_Discord_Commands = new System.Windows.Forms.TabPage();
            this.Tab_List_Commands = new System.Windows.Forms.TabPage();
            this.ListBefehlList = new System.Windows.Forms.ListBox();
            this.btnNeu = new System.Windows.Forms.Button();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.btnSpeichern = new System.Windows.Forms.Button();
            this.GroupAnlegen = new System.Windows.Forms.GroupBox();
            this.btnStandard = new System.Windows.Forms.Button();
            this.grpZeit = new System.Windows.Forms.GroupBox();
            this.chkYouTube = new System.Windows.Forms.CheckBox();
            this.chkTwitch = new System.Windows.Forms.CheckBox();
            this.chkDiscord = new System.Windows.Forms.CheckBox();
            this.NUDIntervall = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVariableHilfe = new System.Windows.Forms.Button();
            this.btnListBefehle = new System.Windows.Forms.Button();
            this.btnZufallAntwort = new System.Windows.Forms.Button();
            this.btnLöschen = new System.Windows.Forms.Button();
            this.tabAntwort = new System.Windows.Forms.TabControl();
            this.tabPageText = new System.Windows.Forms.TabPage();
            this.tabPageAlternativ = new System.Windows.Forms.TabPage();
            this.txtAlternativAnswer = new System.Windows.Forms.TextBox();
            this.btnVariable = new System.Windows.Forms.Button();
            this.cmbVariable = new System.Windows.Forms.ComboBox();
            this.lblVerwendung = new System.Windows.Forms.Label();
            this.BefehlTab.SuspendLayout();
            this.Tab_Commands.SuspendLayout();
            this.Tab_Time_Commands.SuspendLayout();
            this.Tab_Twitch_Commands.SuspendLayout();
            this.Tab_List_Commands.SuspendLayout();
            this.GroupAnlegen.SuspendLayout();
            this.grpZeit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDIntervall)).BeginInit();
            this.tabAntwort.SuspendLayout();
            this.tabPageText.SuspendLayout();
            this.tabPageAlternativ.SuspendLayout();
            this.SuspendLayout();
            // 
            // BefehlTab
            // 
            this.BefehlTab.Controls.Add(this.Tab_Commands);
            this.BefehlTab.Controls.Add(this.Tab_Time_Commands);
            this.BefehlTab.Controls.Add(this.Tab_Twitch_Commands);
            this.BefehlTab.Controls.Add(this.Tab_Discord_Commands);
            this.BefehlTab.Controls.Add(this.Tab_List_Commands);
            this.BefehlTab.Location = new System.Drawing.Point(12, 12);
            this.BefehlTab.Name = "BefehlTab";
            this.BefehlTab.SelectedIndex = 0;
            this.BefehlTab.Size = new System.Drawing.Size(482, 650);
            this.BefehlTab.TabIndex = 0;
            this.BefehlTab.Selected += new System.Windows.Forms.TabControlEventHandler(this.BefehlTab_Selected);
            // 
            // Tab_Commands
            // 
            this.Tab_Commands.Controls.Add(this.BefehlList);
            this.Tab_Commands.Location = new System.Drawing.Point(4, 22);
            this.Tab_Commands.Name = "Tab_Commands";
            this.Tab_Commands.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Commands.Size = new System.Drawing.Size(474, 624);
            this.Tab_Commands.TabIndex = 0;
            this.Tab_Commands.Text = "Kommandos";
            this.Tab_Commands.UseVisualStyleBackColor = true;
            // 
            // BefehlList
            // 
            this.BefehlList.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BefehlList.FormattingEnabled = true;
            this.BefehlList.ItemHeight = 30;
            this.BefehlList.Location = new System.Drawing.Point(6, 6);
            this.BefehlList.Name = "BefehlList";
            this.BefehlList.Size = new System.Drawing.Size(462, 604);
            this.BefehlList.TabIndex = 0;
            this.BefehlList.SelectedIndexChanged += new System.EventHandler(this.BefehlList_SelectedIndexChanged);
            // 
            // Tab_Time_Commands
            // 
            this.Tab_Time_Commands.Controls.Add(this.ZeitBefehlList);
            this.Tab_Time_Commands.Location = new System.Drawing.Point(4, 22);
            this.Tab_Time_Commands.Name = "Tab_Time_Commands";
            this.Tab_Time_Commands.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Time_Commands.Size = new System.Drawing.Size(474, 624);
            this.Tab_Time_Commands.TabIndex = 1;
            this.Tab_Time_Commands.Text = "Zeit-Kommandos";
            this.Tab_Time_Commands.UseVisualStyleBackColor = true;
            // 
            // ZeitBefehlList
            // 
            this.ZeitBefehlList.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZeitBefehlList.FormattingEnabled = true;
            this.ZeitBefehlList.ItemHeight = 30;
            this.ZeitBefehlList.Location = new System.Drawing.Point(6, 6);
            this.ZeitBefehlList.Name = "ZeitBefehlList";
            this.ZeitBefehlList.Size = new System.Drawing.Size(465, 604);
            this.ZeitBefehlList.TabIndex = 1;
            this.ZeitBefehlList.SelectedIndexChanged += new System.EventHandler(this.ZeitBefehlList_SelectedIndexChanged);
            // 
            // Tab_Twitch_Commands
            // 
            this.Tab_Twitch_Commands.Controls.Add(this.TwitchList);
            this.Tab_Twitch_Commands.Location = new System.Drawing.Point(4, 22);
            this.Tab_Twitch_Commands.Name = "Tab_Twitch_Commands";
            this.Tab_Twitch_Commands.Size = new System.Drawing.Size(474, 624);
            this.Tab_Twitch_Commands.TabIndex = 2;
            this.Tab_Twitch_Commands.Text = "Twitch-Kommandos";
            this.Tab_Twitch_Commands.UseVisualStyleBackColor = true;
            // 
            // TwitchList
            // 
            this.TwitchList.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TwitchList.FormattingEnabled = true;
            this.TwitchList.ItemHeight = 30;
            this.TwitchList.Location = new System.Drawing.Point(6, 8);
            this.TwitchList.Name = "TwitchList";
            this.TwitchList.Size = new System.Drawing.Size(465, 604);
            this.TwitchList.TabIndex = 1;
            this.TwitchList.SelectedIndexChanged += new System.EventHandler(this.TwitchList_SelectedIndexChanged);
            // 
            // Tab_Discord_Commands
            // 
            this.Tab_Discord_Commands.Location = new System.Drawing.Point(4, 22);
            this.Tab_Discord_Commands.Name = "Tab_Discord_Commands";
            this.Tab_Discord_Commands.Size = new System.Drawing.Size(474, 624);
            this.Tab_Discord_Commands.TabIndex = 3;
            this.Tab_Discord_Commands.Text = "Discord-Kommandos";
            this.Tab_Discord_Commands.UseVisualStyleBackColor = true;
            // 
            // Tab_List_Commands
            // 
            this.Tab_List_Commands.Controls.Add(this.ListBefehlList);
            this.Tab_List_Commands.Location = new System.Drawing.Point(4, 22);
            this.Tab_List_Commands.Name = "Tab_List_Commands";
            this.Tab_List_Commands.Size = new System.Drawing.Size(474, 624);
            this.Tab_List_Commands.TabIndex = 4;
            this.Tab_List_Commands.Text = "Listen-Kommandos";
            this.Tab_List_Commands.UseVisualStyleBackColor = true;
            // 
            // ListBefehlList
            // 
            this.ListBefehlList.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.ListBefehlList.FormattingEnabled = true;
            this.ListBefehlList.ItemHeight = 30;
            this.ListBefehlList.Location = new System.Drawing.Point(3, 3);
            this.ListBefehlList.Name = "ListBefehlList";
            this.ListBefehlList.Size = new System.Drawing.Size(468, 604);
            this.ListBefehlList.TabIndex = 0;
            this.ListBefehlList.SelectedIndexChanged += new System.EventHandler(this.ListBefehlList_SelectedIndexChanged);
            // 
            // btnNeu
            // 
            this.btnNeu.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnNeu.Location = new System.Drawing.Point(500, 20);
            this.btnNeu.Name = "btnNeu";
            this.btnNeu.Size = new System.Drawing.Size(193, 37);
            this.btnNeu.TabIndex = 1;
            this.btnNeu.Text = "Neuer Befehl";
            this.btnNeu.UseVisualStyleBackColor = true;
            this.btnNeu.Click += new System.EventHandler(this.BtnNeu_Click);
            // 
            // txtCommand
            // 
            this.txtCommand.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtCommand.Location = new System.Drawing.Point(6, 20);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(482, 35);
            this.txtCommand.TabIndex = 2;
            this.txtCommand.Text = "Kommando";
            this.txtCommand.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TxtCommand_Click);
            // 
            // txtAnswer
            // 
            this.txtAnswer.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtAnswer.Location = new System.Drawing.Point(6, 6);
            this.txtAnswer.Multiline = true;
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAnswer.Size = new System.Drawing.Size(462, 241);
            this.txtAnswer.TabIndex = 3;
            this.txtAnswer.Text = "Antwort";
            this.txtAnswer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TxtAnswer_Click);
            this.txtAnswer.TextChanged += new System.EventHandler(this.txtAnswer_TextChanged);
            // 
            // btnSpeichern
            // 
            this.btnSpeichern.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnSpeichern.Location = new System.Drawing.Point(6, 552);
            this.btnSpeichern.Name = "btnSpeichern";
            this.btnSpeichern.Size = new System.Drawing.Size(181, 37);
            this.btnSpeichern.TabIndex = 4;
            this.btnSpeichern.Text = "Befehl Speichern";
            this.btnSpeichern.UseVisualStyleBackColor = true;
            this.btnSpeichern.Click += new System.EventHandler(this.BtnSpeichern_Click);
            // 
            // GroupAnlegen
            // 
            this.GroupAnlegen.Controls.Add(this.lblVerwendung);
            this.GroupAnlegen.Controls.Add(this.btnStandard);
            this.GroupAnlegen.Controls.Add(this.grpZeit);
            this.GroupAnlegen.Controls.Add(this.btnVariableHilfe);
            this.GroupAnlegen.Controls.Add(this.btnListBefehle);
            this.GroupAnlegen.Controls.Add(this.btnZufallAntwort);
            this.GroupAnlegen.Controls.Add(this.btnLöschen);
            this.GroupAnlegen.Controls.Add(this.tabAntwort);
            this.GroupAnlegen.Controls.Add(this.btnVariable);
            this.GroupAnlegen.Controls.Add(this.cmbVariable);
            this.GroupAnlegen.Controls.Add(this.txtCommand);
            this.GroupAnlegen.Controls.Add(this.btnSpeichern);
            this.GroupAnlegen.Enabled = false;
            this.GroupAnlegen.Location = new System.Drawing.Point(500, 63);
            this.GroupAnlegen.Name = "GroupAnlegen";
            this.GroupAnlegen.Size = new System.Drawing.Size(494, 595);
            this.GroupAnlegen.TabIndex = 10;
            this.GroupAnlegen.TabStop = false;
            // 
            // btnStandard
            // 
            this.btnStandard.Location = new System.Drawing.Point(300, 566);
            this.btnStandard.Name = "btnStandard";
            this.btnStandard.Size = new System.Drawing.Size(125, 23);
            this.btnStandard.TabIndex = 11;
            this.btnStandard.Text = "Anpassung-Befehle";
            this.btnStandard.UseVisualStyleBackColor = true;
            this.btnStandard.Click += new System.EventHandler(this.BtnStandard_Click);
            // 
            // grpZeit
            // 
            this.grpZeit.Controls.Add(this.chkYouTube);
            this.grpZeit.Controls.Add(this.chkTwitch);
            this.grpZeit.Controls.Add(this.chkDiscord);
            this.grpZeit.Controls.Add(this.NUDIntervall);
            this.grpZeit.Controls.Add(this.label1);
            this.grpZeit.Location = new System.Drawing.Point(6, 435);
            this.grpZeit.Name = "grpZeit";
            this.grpZeit.Size = new System.Drawing.Size(482, 79);
            this.grpZeit.TabIndex = 19;
            this.grpZeit.TabStop = false;
            this.grpZeit.Text = "Eigenschaften für Zeit-Kommandos";
            // 
            // chkYouTube
            // 
            this.chkYouTube.AutoSize = true;
            this.chkYouTube.Enabled = false;
            this.chkYouTube.Location = new System.Drawing.Point(138, 49);
            this.chkYouTube.Name = "chkYouTube";
            this.chkYouTube.Size = new System.Drawing.Size(70, 17);
            this.chkYouTube.TabIndex = 21;
            this.chkYouTube.Text = "YouTube";
            this.chkYouTube.UseVisualStyleBackColor = true;
            // 
            // chkTwitch
            // 
            this.chkTwitch.AutoSize = true;
            this.chkTwitch.Enabled = false;
            this.chkTwitch.Location = new System.Drawing.Point(78, 49);
            this.chkTwitch.Name = "chkTwitch";
            this.chkTwitch.Size = new System.Drawing.Size(58, 17);
            this.chkTwitch.TabIndex = 20;
            this.chkTwitch.Text = "Twitch";
            this.chkTwitch.UseVisualStyleBackColor = true;
            // 
            // chkDiscord
            // 
            this.chkDiscord.AutoSize = true;
            this.chkDiscord.Enabled = false;
            this.chkDiscord.Location = new System.Drawing.Point(10, 49);
            this.chkDiscord.Name = "chkDiscord";
            this.chkDiscord.Size = new System.Drawing.Size(62, 17);
            this.chkDiscord.TabIndex = 17;
            this.chkDiscord.Text = "Discord";
            this.chkDiscord.UseVisualStyleBackColor = true;
            // 
            // NUDIntervall
            // 
            this.NUDIntervall.Enabled = false;
            this.NUDIntervall.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.NUDIntervall.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.NUDIntervall.Increment = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.NUDIntervall.Location = new System.Drawing.Point(222, 16);
            this.NUDIntervall.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.NUDIntervall.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUDIntervall.Name = "NUDIntervall";
            this.NUDIntervall.Size = new System.Drawing.Size(120, 35);
            this.NUDIntervall.TabIndex = 19;
            this.NUDIntervall.ThousandsSeparator = true;
            this.NUDIntervall.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(5, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 30);
            this.label1.TabIndex = 18;
            this.label1.Text = "Zeit-Intervall (in Sek.):";
            // 
            // btnVariableHilfe
            // 
            this.btnVariableHilfe.Location = new System.Drawing.Point(409, 390);
            this.btnVariableHilfe.Name = "btnVariableHilfe";
            this.btnVariableHilfe.Size = new System.Drawing.Size(79, 23);
            this.btnVariableHilfe.TabIndex = 18;
            this.btnVariableHilfe.Text = "Hilfe Variable";
            this.btnVariableHilfe.UseVisualStyleBackColor = true;
            this.btnVariableHilfe.Click += new System.EventHandler(this.btnVariableHilfe_Click);
            // 
            // btnListBefehle
            // 
            this.btnListBefehle.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnListBefehle.Location = new System.Drawing.Point(6, 392);
            this.btnListBefehle.Name = "btnListBefehle";
            this.btnListBefehle.Size = new System.Drawing.Size(187, 37);
            this.btnListBefehle.TabIndex = 12;
            this.btnListBefehle.Text = "List-Befehl Editor";
            this.btnListBefehle.UseVisualStyleBackColor = true;
            this.btnListBefehle.Click += new System.EventHandler(this.btnListBefehle_Click);
            // 
            // btnZufallAntwort
            // 
            this.btnZufallAntwort.Enabled = false;
            this.btnZufallAntwort.Location = new System.Drawing.Point(314, 390);
            this.btnZufallAntwort.Name = "btnZufallAntwort";
            this.btnZufallAntwort.Size = new System.Drawing.Size(89, 23);
            this.btnZufallAntwort.TabIndex = 17;
            this.btnZufallAntwort.Text = "Zufall";
            this.btnZufallAntwort.UseVisualStyleBackColor = true;
            this.btnZufallAntwort.Click += new System.EventHandler(this.BtnZufallAntwort_Click);
            // 
            // btnLöschen
            // 
            this.btnLöschen.Location = new System.Drawing.Point(193, 566);
            this.btnLöschen.Name = "btnLöschen";
            this.btnLöschen.Size = new System.Drawing.Size(101, 23);
            this.btnLöschen.TabIndex = 4;
            this.btnLöschen.Text = "Befehl-Löschen";
            this.btnLöschen.UseVisualStyleBackColor = true;
            this.btnLöschen.Click += new System.EventHandler(this.BtnLöschen_Click);
            // 
            // tabAntwort
            // 
            this.tabAntwort.Controls.Add(this.tabPageText);
            this.tabAntwort.Controls.Add(this.tabPageAlternativ);
            this.tabAntwort.Location = new System.Drawing.Point(6, 61);
            this.tabAntwort.Name = "tabAntwort";
            this.tabAntwort.SelectedIndex = 0;
            this.tabAntwort.Size = new System.Drawing.Size(482, 279);
            this.tabAntwort.TabIndex = 11;
            // 
            // tabPageText
            // 
            this.tabPageText.Controls.Add(this.txtAnswer);
            this.tabPageText.Location = new System.Drawing.Point(4, 22);
            this.tabPageText.Name = "tabPageText";
            this.tabPageText.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageText.Size = new System.Drawing.Size(474, 253);
            this.tabPageText.TabIndex = 0;
            this.tabPageText.Text = "Antwort";
            this.tabPageText.UseVisualStyleBackColor = true;
            // 
            // tabPageAlternativ
            // 
            this.tabPageAlternativ.BackColor = System.Drawing.Color.Transparent;
            this.tabPageAlternativ.Controls.Add(this.txtAlternativAnswer);
            this.tabPageAlternativ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageAlternativ.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPageAlternativ.Location = new System.Drawing.Point(4, 22);
            this.tabPageAlternativ.Name = "tabPageAlternativ";
            this.tabPageAlternativ.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAlternativ.Size = new System.Drawing.Size(474, 253);
            this.tabPageAlternativ.TabIndex = 1;
            this.tabPageAlternativ.Text = "Alternative Antwort";
            // 
            // txtAlternativAnswer
            // 
            this.txtAlternativAnswer.Enabled = false;
            this.txtAlternativAnswer.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtAlternativAnswer.Location = new System.Drawing.Point(9, 6);
            this.txtAlternativAnswer.Multiline = true;
            this.txtAlternativAnswer.Name = "txtAlternativAnswer";
            this.txtAlternativAnswer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAlternativAnswer.Size = new System.Drawing.Size(459, 241);
            this.txtAlternativAnswer.TabIndex = 12;
            // 
            // btnVariable
            // 
            this.btnVariable.Location = new System.Drawing.Point(314, 346);
            this.btnVariable.Name = "btnVariable";
            this.btnVariable.Size = new System.Drawing.Size(174, 38);
            this.btnVariable.TabIndex = 10;
            this.btnVariable.Text = "Variable in Antwort hinzufügen";
            this.btnVariable.UseVisualStyleBackColor = true;
            this.btnVariable.Click += new System.EventHandler(this.BtnVariable_Click);
            // 
            // cmbVariable
            // 
            this.cmbVariable.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.cmbVariable.FormattingEnabled = true;
            this.cmbVariable.Items.AddRange(new object[] {
            "OptionalerTeil",
            "VariablerTeil",
            "Name",
            "Zähler",
            "KommandosBefehlsKette",
            "TwitchBefehlsKette"});
            this.cmbVariable.Location = new System.Drawing.Point(6, 346);
            this.cmbVariable.Name = "cmbVariable";
            this.cmbVariable.Size = new System.Drawing.Size(300, 38);
            this.cmbVariable.TabIndex = 9;
            // 
            // lblVerwendung
            // 
            this.lblVerwendung.AutoSize = true;
            this.lblVerwendung.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblVerwendung.Location = new System.Drawing.Point(5, 517);
            this.lblVerwendung.Name = "lblVerwendung";
            this.lblVerwendung.Size = new System.Drawing.Size(243, 30);
            this.lblVerwendung.TabIndex = 20;
            this.lblVerwendung.Text = "Anzahl an Verwendung: ";
            // 
            // Befehl_Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 670);
            this.Controls.Add(this.GroupAnlegen);
            this.Controls.Add(this.btnNeu);
            this.Controls.Add(this.BefehlTab);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Befehl_Editor";
            this.Text = "Befehl_Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Befehl_Editor_FormClosing);
            this.Load += new System.EventHandler(this.Befehl_Editor_Load);
            this.BefehlTab.ResumeLayout(false);
            this.Tab_Commands.ResumeLayout(false);
            this.Tab_Time_Commands.ResumeLayout(false);
            this.Tab_Twitch_Commands.ResumeLayout(false);
            this.Tab_List_Commands.ResumeLayout(false);
            this.GroupAnlegen.ResumeLayout(false);
            this.GroupAnlegen.PerformLayout();
            this.grpZeit.ResumeLayout(false);
            this.grpZeit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDIntervall)).EndInit();
            this.tabAntwort.ResumeLayout(false);
            this.tabPageText.ResumeLayout(false);
            this.tabPageText.PerformLayout();
            this.tabPageAlternativ.ResumeLayout(false);
            this.tabPageAlternativ.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl BefehlTab;
        private System.Windows.Forms.TabPage Tab_Commands;
        private System.Windows.Forms.TabPage Tab_Time_Commands;
        private System.Windows.Forms.ListBox BefehlList;
        private System.Windows.Forms.Button btnNeu;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Button btnSpeichern;
        private System.Windows.Forms.GroupBox GroupAnlegen;
        private System.Windows.Forms.ComboBox cmbVariable;
        private System.Windows.Forms.Button btnVariable;
        private System.Windows.Forms.Button btnStandard;
        private System.Windows.Forms.TabControl tabAntwort;
        private System.Windows.Forms.TabPage tabPageText;
        private System.Windows.Forms.TabPage tabPageAlternativ;
        private System.Windows.Forms.TextBox txtAlternativAnswer;
        private System.Windows.Forms.Button btnLöschen;
        private System.Windows.Forms.ListBox ZeitBefehlList;
        private System.Windows.Forms.Button btnZufallAntwort;
        private System.Windows.Forms.TabPage Tab_Twitch_Commands;
        private System.Windows.Forms.ListBox TwitchList;
        private System.Windows.Forms.TabPage Tab_Discord_Commands;
        private System.Windows.Forms.TabPage Tab_List_Commands;
        private System.Windows.Forms.ListBox ListBefehlList;
        private System.Windows.Forms.Button btnListBefehle;
        private System.Windows.Forms.GroupBox grpZeit;
        private System.Windows.Forms.CheckBox chkYouTube;
        private System.Windows.Forms.CheckBox chkTwitch;
        private System.Windows.Forms.CheckBox chkDiscord;
        private System.Windows.Forms.NumericUpDown NUDIntervall;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVariableHilfe;
        private System.Windows.Forms.Label lblVerwendung;
    }
}