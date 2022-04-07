
namespace AntonBot.Fenster
{
    partial class EingabeListBefehl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EingabeListBefehl));
            this.btnSpeichern = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtKommando = new System.Windows.Forms.TextBox();
            this.txtAusgabe = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNextBefehl = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkNextAdmin = new System.Windows.Forms.CheckBox();
            this.chkGroupLoeschen = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTrennungszeichen = new System.Windows.Forms.TextBox();
            this.cmbVariable = new System.Windows.Forms.ComboBox();
            this.btnVariable = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAbbrechen = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNextAntwort = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAufbau = new System.Windows.Forms.TextBox();
            this.NUDAnzahl = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.btnDaten = new System.Windows.Forms.Button();
            this.CtabBefehle = new System.Windows.Forms.TabControl();
            this.tabHinzufügen = new System.Windows.Forms.TabPage();
            this.txtHinzufügen = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tabCurrent = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCurrentAntwort = new System.Windows.Forms.TextBox();
            this.txtCurrentBefehl = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tabNext = new System.Windows.Forms.TabPage();
            this.tabDelete = new System.Windows.Forms.TabPage();
            this.chkOnlyKommands = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLoeschFail = new System.Windows.Forms.TextBox();
            this.txtLoeschAntwort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLöschKommando = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NUDAnzahl)).BeginInit();
            this.CtabBefehle.SuspendLayout();
            this.tabHinzufügen.SuspendLayout();
            this.tabCurrent.SuspendLayout();
            this.tabNext.SuspendLayout();
            this.tabDelete.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSpeichern
            // 
            this.btnSpeichern.Location = new System.Drawing.Point(673, 624);
            this.btnSpeichern.Name = "btnSpeichern";
            this.btnSpeichern.Size = new System.Drawing.Size(155, 38);
            this.btnSpeichern.TabIndex = 0;
            this.btnSpeichern.Text = "Speichern";
            this.btnSpeichern.UseVisualStyleBackColor = true;
            this.btnSpeichern.Click += new System.EventHandler(this.btnSpeichern_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(137, 30);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Kommando: ";
            // 
            // txtKommando
            // 
            this.txtKommando.Location = new System.Drawing.Point(449, 6);
            this.txtKommando.Name = "txtKommando";
            this.txtKommando.Size = new System.Drawing.Size(379, 35);
            this.txtKommando.TabIndex = 2;
            this.txtKommando.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtKommando_MouseClick);
            // 
            // txtAusgabe
            // 
            this.txtAusgabe.Location = new System.Drawing.Point(449, 47);
            this.txtAusgabe.Multiline = true;
            this.txtAusgabe.Name = "txtAusgabe";
            this.txtAusgabe.Size = new System.Drawing.Size(379, 90);
            this.txtAusgabe.TabIndex = 3;
            this.txtAusgabe.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAusgabe_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(394, 30);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ausgabe bei Befehleingabe ohne Werte:";
            // 
            // txtNextBefehl
            // 
            this.txtNextBefehl.Location = new System.Drawing.Point(590, 11);
            this.txtNextBefehl.MaxLength = 10;
            this.txtNextBefehl.Name = "txtNextBefehl";
            this.txtNextBefehl.Size = new System.Drawing.Size(220, 35);
            this.txtNextBefehl.TabIndex = 5;
            this.txtNextBefehl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtNextBefehl_MouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(483, 30);
            this.label3.TabIndex = 6;
            this.label3.Text = "Befehl für den nächsten Eintrag (max. 10 Zeichen)";
            // 
            // chkNextAdmin
            // 
            this.chkNextAdmin.AutoSize = true;
            this.chkNextAdmin.Location = new System.Drawing.Point(12, 85);
            this.chkNextAdmin.Name = "chkNextAdmin";
            this.chkNextAdmin.Size = new System.Drawing.Size(188, 34);
            this.chkNextAdmin.TabIndex = 7;
            this.chkNextAdmin.Text = "Nur für Admins?";
            this.chkNextAdmin.UseVisualStyleBackColor = true;
            this.chkNextAdmin.CheckedChanged += new System.EventHandler(this.chkNextAdmin_CheckedChanged);
            // 
            // chkGroupLoeschen
            // 
            this.chkGroupLoeschen.AutoSize = true;
            this.chkGroupLoeschen.Location = new System.Drawing.Point(3, 3);
            this.chkGroupLoeschen.Name = "chkGroupLoeschen";
            this.chkGroupLoeschen.Size = new System.Drawing.Size(388, 34);
            this.chkGroupLoeschen.TabIndex = 0;
            this.chkGroupLoeschen.Text = "Lösch Befehl für die Liste verwenden?";
            this.chkGroupLoeschen.UseVisualStyleBackColor = true;
            this.chkGroupLoeschen.CheckedChanged += new System.EventHandler(this.chkGroupLoeschen_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(450, 30);
            this.label7.TabIndex = 10;
            this.label7.Text = "Trennungszeichen für Befehle (Standard = \" \")";
            // 
            // txtTrennungszeichen
            // 
            this.txtTrennungszeichen.Location = new System.Drawing.Point(767, 250);
            this.txtTrennungszeichen.MaxLength = 1;
            this.txtTrennungszeichen.Name = "txtTrennungszeichen";
            this.txtTrennungszeichen.Size = new System.Drawing.Size(61, 35);
            this.txtTrennungszeichen.TabIndex = 11;
            this.txtTrennungszeichen.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtTrennungszeichen_MouseClick);
            // 
            // cmbVariable
            // 
            this.cmbVariable.FormattingEnabled = true;
            this.cmbVariable.Items.AddRange(new object[] {
            "Auflistung",
            "ListNummer",
            "ListEintrag",
            "ListBenutzer",
            "ListQuelle",
            "Name",
            "OptionalerTeil"});
            this.cmbVariable.Location = new System.Drawing.Point(21, 625);
            this.cmbVariable.Name = "cmbVariable";
            this.cmbVariable.Size = new System.Drawing.Size(297, 38);
            this.cmbVariable.TabIndex = 12;
            // 
            // btnVariable
            // 
            this.btnVariable.Location = new System.Drawing.Point(324, 625);
            this.btnVariable.Name = "btnVariable";
            this.btnVariable.Size = new System.Drawing.Size(268, 38);
            this.btnVariable.TabIndex = 13;
            this.btnVariable.Text = "Variable in Text einfügen";
            this.btnVariable.UseVisualStyleBackColor = true;
            this.btnVariable.Click += new System.EventHandler(this.btnVariable_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 673);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(576, 30);
            this.label8.TabIndex = 14;
            this.label8.Text = "Variable wird in die zuletzt ausgewählte Textbox eingefügt.";
            // 
            // btnAbbrechen
            // 
            this.btnAbbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAbbrechen.Location = new System.Drawing.Point(673, 673);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(154, 38);
            this.btnAbbrechen.TabIndex = 15;
            this.btnAbbrechen.Text = "Abbrechen";
            this.btnAbbrechen.UseVisualStyleBackColor = true;
            this.btnAbbrechen.Click += new System.EventHandler(this.btnAbbrechen_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(412, 30);
            this.label9.TabIndex = 16;
            this.label9.Text = "Antwort im Chat für den nächsten Eintrag";
            // 
            // txtNextAntwort
            // 
            this.txtNextAntwort.Location = new System.Drawing.Point(439, 52);
            this.txtNextAntwort.Multiline = true;
            this.txtNextAntwort.Name = "txtNextAntwort";
            this.txtNextAntwort.Size = new System.Drawing.Size(372, 106);
            this.txtNextAntwort.TabIndex = 17;
            this.txtNextAntwort.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtNextAntwort_MouseClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(230, 30);
            this.label10.TabIndex = 18;
            this.label10.Text = "Aufbau der Auflistung:";
            // 
            // txtAufbau
            // 
            this.txtAufbau.Location = new System.Drawing.Point(449, 143);
            this.txtAufbau.Multiline = true;
            this.txtAufbau.Name = "txtAufbau";
            this.txtAufbau.Size = new System.Drawing.Size(378, 60);
            this.txtAufbau.TabIndex = 19;
            this.txtAufbau.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAufbau_MouseClick);
            // 
            // NUDAnzahl
            // 
            this.NUDAnzahl.Location = new System.Drawing.Point(708, 209);
            this.NUDAnzahl.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDAnzahl.Name = "NUDAnzahl";
            this.NUDAnzahl.Size = new System.Drawing.Size(120, 35);
            this.NUDAnzahl.TabIndex = 20;
            this.NUDAnzahl.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 214);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(328, 30);
            this.label11.TabIndex = 21;
            this.label11.Text = "Anzahl der angezeigten Einträge:";
            // 
            // btnDaten
            // 
            this.btnDaten.Location = new System.Drawing.Point(673, 717);
            this.btnDaten.Name = "btnDaten";
            this.btnDaten.Size = new System.Drawing.Size(154, 38);
            this.btnDaten.TabIndex = 22;
            this.btnDaten.Text = "Einträge";
            this.btnDaten.UseVisualStyleBackColor = true;
            this.btnDaten.Click += new System.EventHandler(this.btnDaten_Click);
            // 
            // CtabBefehle
            // 
            this.CtabBefehle.Controls.Add(this.tabHinzufügen);
            this.CtabBefehle.Controls.Add(this.tabCurrent);
            this.CtabBefehle.Controls.Add(this.tabNext);
            this.CtabBefehle.Controls.Add(this.tabDelete);
            this.CtabBefehle.Location = new System.Drawing.Point(12, 291);
            this.CtabBefehle.Name = "CtabBefehle";
            this.CtabBefehle.SelectedIndex = 0;
            this.CtabBefehle.Size = new System.Drawing.Size(825, 328);
            this.CtabBefehle.TabIndex = 23;
            // 
            // tabHinzufügen
            // 
            this.tabHinzufügen.Controls.Add(this.txtHinzufügen);
            this.tabHinzufügen.Controls.Add(this.label14);
            this.tabHinzufügen.Location = new System.Drawing.Point(4, 39);
            this.tabHinzufügen.Name = "tabHinzufügen";
            this.tabHinzufügen.Size = new System.Drawing.Size(817, 285);
            this.tabHinzufügen.TabIndex = 3;
            this.tabHinzufügen.Text = "Neuer Eintrag";
            this.tabHinzufügen.UseVisualStyleBackColor = true;
            // 
            // txtHinzufügen
            // 
            this.txtHinzufügen.Location = new System.Drawing.Point(8, 43);
            this.txtHinzufügen.Multiline = true;
            this.txtHinzufügen.Name = "txtHinzufügen";
            this.txtHinzufügen.Size = new System.Drawing.Size(550, 118);
            this.txtHinzufügen.TabIndex = 1;
            this.txtHinzufügen.TextChanged += new System.EventHandler(this.txtHinzufügen_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(555, 30);
            this.label14.TabIndex = 0;
            this.label14.Text = "Antwort, wenn ein neuer Eintrag hinzugefügt worden ist:";
            // 
            // tabCurrent
            // 
            this.tabCurrent.Controls.Add(this.label13);
            this.tabCurrent.Controls.Add(this.txtCurrentAntwort);
            this.tabCurrent.Controls.Add(this.txtCurrentBefehl);
            this.tabCurrent.Controls.Add(this.label12);
            this.tabCurrent.Location = new System.Drawing.Point(4, 39);
            this.tabCurrent.Name = "tabCurrent";
            this.tabCurrent.Padding = new System.Windows.Forms.Padding(3);
            this.tabCurrent.Size = new System.Drawing.Size(817, 285);
            this.tabCurrent.TabIndex = 0;
            this.tabCurrent.Text = "Current-Befehl";
            this.tabCurrent.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 53);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(333, 30);
            this.label13.TabIndex = 19;
            this.label13.Text = "Antwort für den aktuellen Eintrag";
            // 
            // txtCurrentAntwort
            // 
            this.txtCurrentAntwort.Location = new System.Drawing.Point(440, 50);
            this.txtCurrentAntwort.Multiline = true;
            this.txtCurrentAntwort.Name = "txtCurrentAntwort";
            this.txtCurrentAntwort.Size = new System.Drawing.Size(372, 106);
            this.txtCurrentAntwort.TabIndex = 18;
            this.txtCurrentAntwort.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtCurrentAntwort_MouseClick);
            // 
            // txtCurrentBefehl
            // 
            this.txtCurrentBefehl.Location = new System.Drawing.Point(591, 9);
            this.txtCurrentBefehl.MaxLength = 10;
            this.txtCurrentBefehl.Name = "txtCurrentBefehl";
            this.txtCurrentBefehl.Size = new System.Drawing.Size(220, 35);
            this.txtCurrentBefehl.TabIndex = 8;
            this.txtCurrentBefehl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtCurrentBefehl_MouseClick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(484, 30);
            this.label12.TabIndex = 7;
            this.label12.Text = "Befehl für den aktuellen Eintrag (max. 10 Zeichen)";
            // 
            // tabNext
            // 
            this.tabNext.Controls.Add(this.label9);
            this.tabNext.Controls.Add(this.txtNextBefehl);
            this.tabNext.Controls.Add(this.label3);
            this.tabNext.Controls.Add(this.chkNextAdmin);
            this.tabNext.Controls.Add(this.txtNextAntwort);
            this.tabNext.Location = new System.Drawing.Point(4, 39);
            this.tabNext.Name = "tabNext";
            this.tabNext.Padding = new System.Windows.Forms.Padding(3);
            this.tabNext.Size = new System.Drawing.Size(817, 285);
            this.tabNext.TabIndex = 1;
            this.tabNext.Text = "Next-Befehl";
            this.tabNext.UseVisualStyleBackColor = true;
            // 
            // tabDelete
            // 
            this.tabDelete.Controls.Add(this.chkOnlyKommands);
            this.tabDelete.Controls.Add(this.label6);
            this.tabDelete.Controls.Add(this.txtLoeschFail);
            this.tabDelete.Controls.Add(this.txtLoeschAntwort);
            this.tabDelete.Controls.Add(this.label5);
            this.tabDelete.Controls.Add(this.txtLöschKommando);
            this.tabDelete.Controls.Add(this.label4);
            this.tabDelete.Controls.Add(this.chkGroupLoeschen);
            this.tabDelete.Location = new System.Drawing.Point(4, 39);
            this.tabDelete.Name = "tabDelete";
            this.tabDelete.Size = new System.Drawing.Size(817, 285);
            this.tabDelete.TabIndex = 2;
            this.tabDelete.Text = "Delete-Befehl";
            this.tabDelete.UseVisualStyleBackColor = true;
            // 
            // chkOnlyKommands
            // 
            this.chkOnlyKommands.AutoSize = true;
            this.chkOnlyKommands.Location = new System.Drawing.Point(8, 218);
            this.chkOnlyKommands.Name = "chkOnlyKommands";
            this.chkOnlyKommands.Size = new System.Drawing.Size(309, 34);
            this.chkOnlyKommands.TabIndex = 21;
            this.chkOnlyKommands.Text = "Nur eigene Einträge löschen?";
            this.chkOnlyKommands.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(411, 30);
            this.label6.TabIndex = 20;
            this.label6.Text = "Antwort beim fehlgeschlagenen Löschen: ";
            // 
            // txtLoeschFail
            // 
            this.txtLoeschFail.Location = new System.Drawing.Point(429, 172);
            this.txtLoeschFail.Multiline = true;
            this.txtLoeschFail.Name = "txtLoeschFail";
            this.txtLoeschFail.Size = new System.Drawing.Size(383, 90);
            this.txtLoeschFail.TabIndex = 19;
            // 
            // txtLoeschAntwort
            // 
            this.txtLoeschAntwort.Location = new System.Drawing.Point(429, 76);
            this.txtLoeschAntwort.Multiline = true;
            this.txtLoeschAntwort.Name = "txtLoeschAntwort";
            this.txtLoeschAntwort.Size = new System.Drawing.Size(383, 90);
            this.txtLoeschAntwort.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(372, 30);
            this.label5.TabIndex = 17;
            this.label5.Text = "Antwort beim erfolgreichen Löschen: ";
            // 
            // txtLöschKommando
            // 
            this.txtLöschKommando.Location = new System.Drawing.Point(429, 35);
            this.txtLöschKommando.Name = "txtLöschKommando";
            this.txtLöschKommando.Size = new System.Drawing.Size(383, 35);
            this.txtLöschKommando.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(260, 30);
            this.label4.TabIndex = 15;
            this.label4.Text = "Lösch-Befehl-Kommando:";
            // 
            // EingabeListBefehl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 764);
            this.ControlBox = false;
            this.Controls.Add(this.CtabBefehle);
            this.Controls.Add(this.btnDaten);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.NUDAnzahl);
            this.Controls.Add(this.txtAufbau);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnAbbrechen);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnVariable);
            this.Controls.Add(this.cmbVariable);
            this.Controls.Add(this.txtTrennungszeichen);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAusgabe);
            this.Controls.Add(this.txtKommando);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnSpeichern);
            this.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "EingabeListBefehl";
            this.Text = "EingabeListBefehl";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EingabeListBefehl_FormClosing);
            this.Load += new System.EventHandler(this.EingabeListBefehl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NUDAnzahl)).EndInit();
            this.CtabBefehle.ResumeLayout(false);
            this.tabHinzufügen.ResumeLayout(false);
            this.tabHinzufügen.PerformLayout();
            this.tabCurrent.ResumeLayout(false);
            this.tabCurrent.PerformLayout();
            this.tabNext.ResumeLayout(false);
            this.tabNext.PerformLayout();
            this.tabDelete.ResumeLayout(false);
            this.tabDelete.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSpeichern;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox txtKommando;
        private System.Windows.Forms.TextBox txtAusgabe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNextBefehl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkNextAdmin;
        private System.Windows.Forms.CheckBox chkGroupLoeschen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTrennungszeichen;
        private System.Windows.Forms.ComboBox cmbVariable;
        private System.Windows.Forms.Button btnVariable;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAbbrechen;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNextAntwort;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAufbau;
        private System.Windows.Forms.NumericUpDown NUDAnzahl;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnDaten;
        private System.Windows.Forms.TabControl CtabBefehle;
        private System.Windows.Forms.TabPage tabCurrent;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCurrentAntwort;
        private System.Windows.Forms.TextBox txtCurrentBefehl;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabPage tabNext;
        private System.Windows.Forms.TabPage tabDelete;
        private System.Windows.Forms.CheckBox chkOnlyKommands;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLoeschFail;
        private System.Windows.Forms.TextBox txtLoeschAntwort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLöschKommando;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabHinzufügen;
        private System.Windows.Forms.TextBox txtHinzufügen;
        private System.Windows.Forms.Label label14;
    }
}