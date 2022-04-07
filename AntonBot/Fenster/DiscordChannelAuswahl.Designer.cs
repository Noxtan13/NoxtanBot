
namespace AntonBot.Fenster
{
    partial class DiscordChannelAuswahl
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
            this.chkl_Channels = new System.Windows.Forms.CheckedListBox();
            this.Lst_Server = new System.Windows.Forms.ListBox();
            this.btnAuswahl = new System.Windows.Forms.Button();
            this.btn_Abbruch = new System.Windows.Forms.Button();
            this.btnLöschen = new System.Windows.Forms.Button();
            this.btnIDAnzeige = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkl_Channels
            // 
            this.chkl_Channels.FormattingEnabled = true;
            this.chkl_Channels.Location = new System.Drawing.Point(328, 12);
            this.chkl_Channels.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.chkl_Channels.Name = "chkl_Channels";
            this.chkl_Channels.Size = new System.Drawing.Size(483, 544);
            this.chkl_Channels.TabIndex = 0;
            // 
            // Lst_Server
            // 
            this.Lst_Server.FormattingEnabled = true;
            this.Lst_Server.ItemHeight = 30;
            this.Lst_Server.Location = new System.Drawing.Point(12, 12);
            this.Lst_Server.Name = "Lst_Server";
            this.Lst_Server.Size = new System.Drawing.Size(307, 544);
            this.Lst_Server.TabIndex = 1;
            this.Lst_Server.SelectedIndexChanged += new System.EventHandler(this.Lst_Server_SelectedIndexChanged);
            // 
            // btnAuswahl
            // 
            this.btnAuswahl.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAuswahl.Location = new System.Drawing.Point(475, 562);
            this.btnAuswahl.Name = "btnAuswahl";
            this.btnAuswahl.Size = new System.Drawing.Size(165, 40);
            this.btnAuswahl.TabIndex = 2;
            this.btnAuswahl.Text = "Auswählen";
            this.btnAuswahl.UseVisualStyleBackColor = true;
            this.btnAuswahl.Click += new System.EventHandler(this.btnAuswahl_Click);
            // 
            // btn_Abbruch
            // 
            this.btn_Abbruch.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Abbruch.Location = new System.Drawing.Point(646, 562);
            this.btn_Abbruch.Name = "btn_Abbruch";
            this.btn_Abbruch.Size = new System.Drawing.Size(165, 40);
            this.btn_Abbruch.TabIndex = 3;
            this.btn_Abbruch.Text = "Abbrechen";
            this.btn_Abbruch.UseVisualStyleBackColor = true;
            this.btn_Abbruch.Click += new System.EventHandler(this.btn_Abbruch_Click);
            // 
            // btnLöschen
            // 
            this.btnLöschen.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnLöschen.Location = new System.Drawing.Point(243, 562);
            this.btnLöschen.Name = "btnLöschen";
            this.btnLöschen.Size = new System.Drawing.Size(226, 40);
            this.btnLöschen.TabIndex = 4;
            this.btnLöschen.Text = "Alle Einträge löschen";
            this.btnLöschen.UseVisualStyleBackColor = true;
            this.btnLöschen.Click += new System.EventHandler(this.btnLöschen_Click);
            // 
            // btnIDAnzeige
            // 
            this.btnIDAnzeige.Location = new System.Drawing.Point(12, 562);
            this.btnIDAnzeige.Name = "btnIDAnzeige";
            this.btnIDAnzeige.Size = new System.Drawing.Size(163, 40);
            this.btnIDAnzeige.TabIndex = 5;
            this.btnIDAnzeige.Text = "IDs Anzeigen";
            this.btnIDAnzeige.UseVisualStyleBackColor = true;
            this.btnIDAnzeige.Click += new System.EventHandler(this.btnIDAnzeige_Click);
            // 
            // DiscordChannelAuswahl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 613);
            this.Controls.Add(this.btnIDAnzeige);
            this.Controls.Add(this.btnLöschen);
            this.Controls.Add(this.btn_Abbruch);
            this.Controls.Add(this.btnAuswahl);
            this.Controls.Add(this.Lst_Server);
            this.Controls.Add(this.chkl_Channels);
            this.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "DiscordChannelAuswahl";
            this.Text = "DiscordChannelAuswahl";
            this.Load += new System.EventHandler(this.DiscordChannelAuswahl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chkl_Channels;
        private System.Windows.Forms.ListBox Lst_Server;
        private System.Windows.Forms.Button btnAuswahl;
        private System.Windows.Forms.Button btn_Abbruch;
        private System.Windows.Forms.Button btnLöschen;
        private System.Windows.Forms.Button btnIDAnzeige;
    }
}