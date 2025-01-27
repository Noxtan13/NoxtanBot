namespace AntonBot.Fenster
{
    partial class ZitateEinstellungen
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
            this.components = new System.ComponentModel.Container();
            this.chkZitateUse = new System.Windows.Forms.CheckBox();
            this.txtZitatCommand = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtZitatAntwort = new System.Windows.Forms.TextBox();
            this.btnZitateEinträge = new System.Windows.Forms.Button();
            this.btnVariable = new System.Windows.Forms.Button();
            this.cmbVariable = new System.Windows.Forms.ComboBox();
            this.chkZitateAdd = new System.Windows.Forms.CheckBox();
            this.chkZitateDelete = new System.Windows.Forms.CheckBox();
            this.txtZitateAdd = new System.Windows.Forms.TextBox();
            this.txtZitateDelete = new System.Windows.Forms.TextBox();
            this.chkAddAll = new System.Windows.Forms.CheckBox();
            this.chkAddVIP = new System.Windows.Forms.CheckBox();
            this.chkAddMod = new System.Windows.Forms.CheckBox();
            this.chkDeleteMod = new System.Windows.Forms.CheckBox();
            this.chkDeleteVIP = new System.Windows.Forms.CheckBox();
            this.chkDeleteAll = new System.Windows.Forms.CheckBox();
            this.chkZitatSuche = new System.Windows.Forms.CheckBox();
            this.txtZitateFailSearch = new System.Windows.Forms.TextBox();
            this.toolTipZitate = new System.Windows.Forms.ToolTip(this.components);
            this.grpZitateBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddAnswer = new System.Windows.Forms.TextBox();
            this.txtDeleteAnswer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grpZitateBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkZitateUse
            // 
            this.chkZitateUse.AutoSize = true;
            this.chkZitateUse.Location = new System.Drawing.Point(12, 12);
            this.chkZitateUse.Name = "chkZitateUse";
            this.chkZitateUse.Size = new System.Drawing.Size(198, 34);
            this.chkZitateUse.TabIndex = 0;
            this.chkZitateUse.Text = "Zitate verwenden";
            this.chkZitateUse.UseVisualStyleBackColor = true;
            this.chkZitateUse.CheckedChanged += new System.EventHandler(this.chkZitateUse_CheckedChanged);
            // 
            // txtZitatCommand
            // 
            this.txtZitatCommand.Location = new System.Drawing.Point(84, 23);
            this.txtZitatCommand.Name = "txtZitatCommand";
            this.txtZitatCommand.Size = new System.Drawing.Size(307, 35);
            this.txtZitatCommand.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Befehl:";
            // 
            // txtZitatAntwort
            // 
            this.txtZitatAntwort.Location = new System.Drawing.Point(6, 64);
            this.txtZitatAntwort.Multiline = true;
            this.txtZitatAntwort.Name = "txtZitatAntwort";
            this.txtZitatAntwort.Size = new System.Drawing.Size(593, 101);
            this.txtZitatAntwort.TabIndex = 3;
            // 
            // btnZitateEinträge
            // 
            this.btnZitateEinträge.Location = new System.Drawing.Point(397, 23);
            this.btnZitateEinträge.Name = "btnZitateEinträge";
            this.btnZitateEinträge.Size = new System.Drawing.Size(202, 37);
            this.btnZitateEinträge.TabIndex = 4;
            this.btnZitateEinträge.Text = "Einträge";
            this.btnZitateEinträge.UseVisualStyleBackColor = true;
            this.btnZitateEinträge.Click += new System.EventHandler(this.btnZitateEinträge_Click);
            // 
            // btnVariable
            // 
            this.btnVariable.Location = new System.Drawing.Point(324, 171);
            this.btnVariable.Name = "btnVariable";
            this.btnVariable.Size = new System.Drawing.Size(275, 38);
            this.btnVariable.TabIndex = 15;
            this.btnVariable.Text = "Variable in Text einfügen";
            this.btnVariable.UseVisualStyleBackColor = true;
            this.btnVariable.Click += new System.EventHandler(this.btnVariable_Click);
            // 
            // cmbVariable
            // 
            this.cmbVariable.FormattingEnabled = true;
            this.cmbVariable.Items.AddRange(new object[] {
            "Zitat",
            "Ersteller",
            "Benutzer",
            "ZitatNr",
            "Datum",
            "Uhrzeit"});
            this.cmbVariable.Location = new System.Drawing.Point(6, 171);
            this.cmbVariable.Name = "cmbVariable";
            this.cmbVariable.Size = new System.Drawing.Size(312, 38);
            this.cmbVariable.TabIndex = 14;
            // 
            // chkZitateAdd
            // 
            this.chkZitateAdd.AutoSize = true;
            this.chkZitateAdd.Location = new System.Drawing.Point(6, 215);
            this.chkZitateAdd.Name = "chkZitateAdd";
            this.chkZitateAdd.Size = new System.Drawing.Size(141, 34);
            this.chkZitateAdd.TabIndex = 16;
            this.chkZitateAdd.Text = "Hinzufügen";
            this.chkZitateAdd.UseVisualStyleBackColor = true;
            this.chkZitateAdd.CheckedChanged += new System.EventHandler(this.chkZitateAdd_CheckedChanged);
            // 
            // chkZitateDelete
            // 
            this.chkZitateDelete.AutoSize = true;
            this.chkZitateDelete.Location = new System.Drawing.Point(6, 295);
            this.chkZitateDelete.Name = "chkZitateDelete";
            this.chkZitateDelete.Size = new System.Drawing.Size(109, 34);
            this.chkZitateDelete.TabIndex = 17;
            this.chkZitateDelete.Text = "Löschen";
            this.chkZitateDelete.UseVisualStyleBackColor = true;
            this.chkZitateDelete.CheckedChanged += new System.EventHandler(this.chkZitateDelete_CheckedChanged);
            // 
            // txtZitateAdd
            // 
            this.txtZitateAdd.Location = new System.Drawing.Point(153, 213);
            this.txtZitateAdd.Name = "txtZitateAdd";
            this.txtZitateAdd.Size = new System.Drawing.Size(204, 35);
            this.txtZitateAdd.TabIndex = 18;
            // 
            // txtZitateDelete
            // 
            this.txtZitateDelete.Location = new System.Drawing.Point(153, 295);
            this.txtZitateDelete.Name = "txtZitateDelete";
            this.txtZitateDelete.Size = new System.Drawing.Size(204, 35);
            this.txtZitateDelete.TabIndex = 19;
            // 
            // chkAddAll
            // 
            this.chkAddAll.AutoSize = true;
            this.chkAddAll.Location = new System.Drawing.Point(363, 215);
            this.chkAddAll.Name = "chkAddAll";
            this.chkAddAll.Size = new System.Drawing.Size(67, 34);
            this.chkAddAll.TabIndex = 20;
            this.chkAddAll.Text = "Alle";
            this.chkAddAll.UseVisualStyleBackColor = true;
            // 
            // chkAddVIP
            // 
            this.chkAddVIP.AutoSize = true;
            this.chkAddVIP.Location = new System.Drawing.Point(436, 215);
            this.chkAddVIP.Name = "chkAddVIP";
            this.chkAddVIP.Size = new System.Drawing.Size(72, 34);
            this.chkAddVIP.TabIndex = 21;
            this.chkAddVIP.Text = "VIPs";
            this.chkAddVIP.UseVisualStyleBackColor = true;
            // 
            // chkAddMod
            // 
            this.chkAddMod.AutoSize = true;
            this.chkAddMod.Location = new System.Drawing.Point(514, 215);
            this.chkAddMod.Name = "chkAddMod";
            this.chkAddMod.Size = new System.Drawing.Size(86, 34);
            this.chkAddMod.TabIndex = 22;
            this.chkAddMod.Text = "Mods";
            this.chkAddMod.UseVisualStyleBackColor = true;
            // 
            // chkDeleteMod
            // 
            this.chkDeleteMod.AutoSize = true;
            this.chkDeleteMod.Location = new System.Drawing.Point(514, 297);
            this.chkDeleteMod.Name = "chkDeleteMod";
            this.chkDeleteMod.Size = new System.Drawing.Size(86, 34);
            this.chkDeleteMod.TabIndex = 25;
            this.chkDeleteMod.Text = "Mods";
            this.chkDeleteMod.UseVisualStyleBackColor = true;
            // 
            // chkDeleteVIP
            // 
            this.chkDeleteVIP.AutoSize = true;
            this.chkDeleteVIP.Location = new System.Drawing.Point(436, 297);
            this.chkDeleteVIP.Name = "chkDeleteVIP";
            this.chkDeleteVIP.Size = new System.Drawing.Size(72, 34);
            this.chkDeleteVIP.TabIndex = 24;
            this.chkDeleteVIP.Text = "VIPs";
            this.chkDeleteVIP.UseVisualStyleBackColor = true;
            // 
            // chkDeleteAll
            // 
            this.chkDeleteAll.AutoSize = true;
            this.chkDeleteAll.Location = new System.Drawing.Point(363, 297);
            this.chkDeleteAll.Name = "chkDeleteAll";
            this.chkDeleteAll.Size = new System.Drawing.Size(67, 34);
            this.chkDeleteAll.TabIndex = 23;
            this.chkDeleteAll.Text = "Alle";
            this.chkDeleteAll.UseVisualStyleBackColor = true;
            // 
            // chkZitatSuche
            // 
            this.chkZitatSuche.AutoSize = true;
            this.chkZitatSuche.Location = new System.Drawing.Point(6, 375);
            this.chkZitatSuche.Name = "chkZitatSuche";
            this.chkZitatSuche.Size = new System.Drawing.Size(299, 34);
            this.chkZitatSuche.TabIndex = 26;
            this.chkZitatSuche.Text = "Suche nach Zitate aktivieren";
            this.toolTipZitate.SetToolTip(this.chkZitatSuche, "Aktiviert die Möglichkeit nach Einträge zu suchen. Suchbegriff wird nach dem Befe" +
        "hl verwendet");
            this.chkZitatSuche.UseVisualStyleBackColor = true;
            this.chkZitatSuche.CheckedChanged += new System.EventHandler(this.chkZitatSuche_CheckedChanged);
            // 
            // txtZitateFailSearch
            // 
            this.txtZitateFailSearch.Location = new System.Drawing.Point(6, 415);
            this.txtZitateFailSearch.Multiline = true;
            this.txtZitateFailSearch.Name = "txtZitateFailSearch";
            this.txtZitateFailSearch.Size = new System.Drawing.Size(593, 98);
            this.txtZitateFailSearch.TabIndex = 27;
            this.toolTipZitate.SetToolTip(this.txtZitateFailSearch, "Antworttext, wenn kein Zitat gefunden wird. Wird vor dem Text gestellt");
            // 
            // grpZitateBox
            // 
            this.grpZitateBox.Controls.Add(this.txtDeleteAnswer);
            this.grpZitateBox.Controls.Add(this.label3);
            this.grpZitateBox.Controls.Add(this.txtAddAnswer);
            this.grpZitateBox.Controls.Add(this.label2);
            this.grpZitateBox.Controls.Add(this.txtZitateFailSearch);
            this.grpZitateBox.Controls.Add(this.txtZitatCommand);
            this.grpZitateBox.Controls.Add(this.chkZitatSuche);
            this.grpZitateBox.Controls.Add(this.label1);
            this.grpZitateBox.Controls.Add(this.chkDeleteMod);
            this.grpZitateBox.Controls.Add(this.txtZitatAntwort);
            this.grpZitateBox.Controls.Add(this.chkDeleteVIP);
            this.grpZitateBox.Controls.Add(this.btnZitateEinträge);
            this.grpZitateBox.Controls.Add(this.chkDeleteAll);
            this.grpZitateBox.Controls.Add(this.cmbVariable);
            this.grpZitateBox.Controls.Add(this.chkAddMod);
            this.grpZitateBox.Controls.Add(this.btnVariable);
            this.grpZitateBox.Controls.Add(this.chkAddVIP);
            this.grpZitateBox.Controls.Add(this.chkZitateAdd);
            this.grpZitateBox.Controls.Add(this.chkAddAll);
            this.grpZitateBox.Controls.Add(this.chkZitateDelete);
            this.grpZitateBox.Controls.Add(this.txtZitateDelete);
            this.grpZitateBox.Controls.Add(this.txtZitateAdd);
            this.grpZitateBox.Location = new System.Drawing.Point(12, 39);
            this.grpZitateBox.Name = "grpZitateBox";
            this.grpZitateBox.Size = new System.Drawing.Size(605, 522);
            this.grpZitateBox.TabIndex = 28;
            this.grpZitateBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 30);
            this.label2.TabIndex = 28;
            this.label2.Text = "Antwort:";
            // 
            // txtAddAnswer
            // 
            this.txtAddAnswer.Location = new System.Drawing.Point(109, 254);
            this.txtAddAnswer.Name = "txtAddAnswer";
            this.txtAddAnswer.Size = new System.Drawing.Size(490, 35);
            this.txtAddAnswer.TabIndex = 29;
            // 
            // txtDeleteAnswer
            // 
            this.txtDeleteAnswer.Location = new System.Drawing.Point(109, 336);
            this.txtDeleteAnswer.Name = "txtDeleteAnswer";
            this.txtDeleteAnswer.Size = new System.Drawing.Size(490, 35);
            this.txtDeleteAnswer.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 339);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 30);
            this.label3.TabIndex = 30;
            this.label3.Text = "Antwort:";
            // 
            // ZitateEinstellungen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 568);
            this.Controls.Add(this.grpZitateBox);
            this.Controls.Add(this.chkZitateUse);
            this.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "ZitateEinstellungen";
            this.Text = "Zitate Einstellungen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ZitateEinstellungen_FormClosing);
            this.Load += new System.EventHandler(this.ZitateEinstellungen_Load);
            this.grpZitateBox.ResumeLayout(false);
            this.grpZitateBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkZitateUse;
        private System.Windows.Forms.TextBox txtZitatCommand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtZitatAntwort;
        private System.Windows.Forms.Button btnZitateEinträge;
        private System.Windows.Forms.Button btnVariable;
        private System.Windows.Forms.ComboBox cmbVariable;
        private System.Windows.Forms.CheckBox chkZitateAdd;
        private System.Windows.Forms.CheckBox chkZitateDelete;
        private System.Windows.Forms.TextBox txtZitateAdd;
        private System.Windows.Forms.TextBox txtZitateDelete;
        private System.Windows.Forms.CheckBox chkAddAll;
        private System.Windows.Forms.CheckBox chkAddVIP;
        private System.Windows.Forms.CheckBox chkAddMod;
        private System.Windows.Forms.CheckBox chkDeleteMod;
        private System.Windows.Forms.CheckBox chkDeleteVIP;
        private System.Windows.Forms.CheckBox chkDeleteAll;
        private System.Windows.Forms.CheckBox chkZitatSuche;
        private System.Windows.Forms.TextBox txtZitateFailSearch;
        private System.Windows.Forms.ToolTip toolTipZitate;
        private System.Windows.Forms.GroupBox grpZitateBox;
        private System.Windows.Forms.TextBox txtDeleteAnswer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddAnswer;
        private System.Windows.Forms.Label label2;
    }
}