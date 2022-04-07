
namespace AntonBot.Fenster
{
    partial class BefehleLevel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BefehleLevel));
            this.cmbBefehle = new System.Windows.Forms.ComboBox();
            this.txtKommando = new System.Windows.Forms.TextBox();
            this.txtAntwort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbVariable = new System.Windows.Forms.ComboBox();
            this.btnVariable = new System.Windows.Forms.Button();
            this.chkAlle = new System.Windows.Forms.CheckBox();
            this.chkAdmin = new System.Windows.Forms.CheckBox();
            this.chkVIPs = new System.Windows.Forms.CheckBox();
            this.btnSpeichern = new System.Windows.Forms.Button();
            this.btnAbbruch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbBefehle
            // 
            this.cmbBefehle.FormattingEnabled = true;
            this.cmbBefehle.Location = new System.Drawing.Point(12, 12);
            this.cmbBefehle.Name = "cmbBefehle";
            this.cmbBefehle.Size = new System.Drawing.Size(247, 38);
            this.cmbBefehle.TabIndex = 0;
            // 
            // txtKommando
            // 
            this.txtKommando.Location = new System.Drawing.Point(172, 56);
            this.txtKommando.Name = "txtKommando";
            this.txtKommando.Size = new System.Drawing.Size(362, 35);
            this.txtKommando.TabIndex = 1;
            // 
            // txtAntwort
            // 
            this.txtAntwort.Location = new System.Drawing.Point(172, 97);
            this.txtAntwort.Multiline = true;
            this.txtAntwort.Name = "txtAntwort";
            this.txtAntwort.Size = new System.Drawing.Size(362, 166);
            this.txtAntwort.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 30);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kommando:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 30);
            this.label2.TabIndex = 4;
            this.label2.Text = "Antwort:";
            // 
            // cmbVariable
            // 
            this.cmbVariable.FormattingEnabled = true;
            this.cmbVariable.Location = new System.Drawing.Point(12, 269);
            this.cmbVariable.Name = "cmbVariable";
            this.cmbVariable.Size = new System.Drawing.Size(300, 38);
            this.cmbVariable.TabIndex = 5;
            // 
            // btnVariable
            // 
            this.btnVariable.Location = new System.Drawing.Point(318, 269);
            this.btnVariable.Name = "btnVariable";
            this.btnVariable.Size = new System.Drawing.Size(216, 38);
            this.btnVariable.TabIndex = 6;
            this.btnVariable.Text = "Variable einfügen";
            this.btnVariable.UseVisualStyleBackColor = true;
            // 
            // chkAlle
            // 
            this.chkAlle.AutoSize = true;
            this.chkAlle.Location = new System.Drawing.Point(12, 313);
            this.chkAlle.Name = "chkAlle";
            this.chkAlle.Size = new System.Drawing.Size(67, 34);
            this.chkAlle.TabIndex = 7;
            this.chkAlle.Text = "Alle";
            this.chkAlle.UseVisualStyleBackColor = true;
            // 
            // chkAdmin
            // 
            this.chkAdmin.AutoSize = true;
            this.chkAdmin.Location = new System.Drawing.Point(12, 353);
            this.chkAdmin.Name = "chkAdmin";
            this.chkAdmin.Size = new System.Drawing.Size(95, 34);
            this.chkAdmin.TabIndex = 8;
            this.chkAdmin.Text = "Admin";
            this.chkAdmin.UseVisualStyleBackColor = true;
            // 
            // chkVIPs
            // 
            this.chkVIPs.AutoSize = true;
            this.chkVIPs.Location = new System.Drawing.Point(12, 393);
            this.chkVIPs.Name = "chkVIPs";
            this.chkVIPs.Size = new System.Drawing.Size(72, 34);
            this.chkVIPs.TabIndex = 9;
            this.chkVIPs.Text = "VIPs";
            this.chkVIPs.UseVisualStyleBackColor = true;
            // 
            // btnSpeichern
            // 
            this.btnSpeichern.Location = new System.Drawing.Point(265, 11);
            this.btnSpeichern.Name = "btnSpeichern";
            this.btnSpeichern.Size = new System.Drawing.Size(129, 38);
            this.btnSpeichern.TabIndex = 10;
            this.btnSpeichern.Text = "Speichern";
            this.btnSpeichern.UseVisualStyleBackColor = true;
            // 
            // btnAbbruch
            // 
            this.btnAbbruch.Location = new System.Drawing.Point(400, 12);
            this.btnAbbruch.Name = "btnAbbruch";
            this.btnAbbruch.Size = new System.Drawing.Size(134, 38);
            this.btnAbbruch.TabIndex = 11;
            this.btnAbbruch.Text = "Abbrechen";
            this.btnAbbruch.UseVisualStyleBackColor = true;
            // 
            // BefehleLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 436);
            this.Controls.Add(this.btnAbbruch);
            this.Controls.Add(this.btnSpeichern);
            this.Controls.Add(this.chkVIPs);
            this.Controls.Add(this.chkAdmin);
            this.Controls.Add(this.chkAlle);
            this.Controls.Add(this.btnVariable);
            this.Controls.Add(this.cmbVariable);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAntwort);
            this.Controls.Add(this.txtKommando);
            this.Controls.Add(this.cmbBefehle);
            this.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BefehleLevel";
            this.Text = "BefehleLevel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbBefehle;
        private System.Windows.Forms.TextBox txtKommando;
        private System.Windows.Forms.TextBox txtAntwort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbVariable;
        private System.Windows.Forms.Button btnVariable;
        private System.Windows.Forms.CheckBox chkAlle;
        private System.Windows.Forms.CheckBox chkAdmin;
        private System.Windows.Forms.CheckBox chkVIPs;
        private System.Windows.Forms.Button btnSpeichern;
        private System.Windows.Forms.Button btnAbbruch;
    }
}