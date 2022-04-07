namespace AntonBot
{
    partial class EingabeZufallVariable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EingabeZufallVariable));
            this.LstBoxVariablen = new System.Windows.Forms.ListBox();
            this.txtEingabe = new System.Windows.Forms.TextBox();
            this.btnÜbernehmen = new System.Windows.Forms.Button();
            this.btnLöschen = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnAbrechen = new System.Windows.Forms.Button();
            this.lblAnzeigeElemente = new System.Windows.Forms.Label();
            this.lblGewicht = new System.Windows.Forms.Label();
            this.nupGewicht = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nupGewicht)).BeginInit();
            this.SuspendLayout();
            // 
            // LstBoxVariablen
            // 
            this.LstBoxVariablen.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.LstBoxVariablen.FormattingEnabled = true;
            this.LstBoxVariablen.ItemHeight = 30;
            this.LstBoxVariablen.Location = new System.Drawing.Point(12, 12);
            this.LstBoxVariablen.Name = "LstBoxVariablen";
            this.LstBoxVariablen.Size = new System.Drawing.Size(408, 364);
            this.LstBoxVariablen.TabIndex = 0;
            this.LstBoxVariablen.SelectedIndexChanged += new System.EventHandler(this.LstBoxVariablen_SelectedIndexChanged);
            // 
            // txtEingabe
            // 
            this.txtEingabe.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtEingabe.Location = new System.Drawing.Point(426, 12);
            this.txtEingabe.Multiline = true;
            this.txtEingabe.Name = "txtEingabe";
            this.txtEingabe.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEingabe.Size = new System.Drawing.Size(241, 292);
            this.txtEingabe.TabIndex = 1;
            // 
            // btnÜbernehmen
            // 
            this.btnÜbernehmen.Location = new System.Drawing.Point(426, 310);
            this.btnÜbernehmen.Name = "btnÜbernehmen";
            this.btnÜbernehmen.Size = new System.Drawing.Size(117, 23);
            this.btnÜbernehmen.TabIndex = 2;
            this.btnÜbernehmen.Text = "Übernehmen";
            this.btnÜbernehmen.UseVisualStyleBackColor = true;
            this.btnÜbernehmen.Click += new System.EventHandler(this.btnÜbernehmen_Click);
            // 
            // btnLöschen
            // 
            this.btnLöschen.Location = new System.Drawing.Point(549, 310);
            this.btnLöschen.Name = "btnLöschen";
            this.btnLöschen.Size = new System.Drawing.Size(117, 23);
            this.btnLöschen.TabIndex = 3;
            this.btnLöschen.Text = "Löschen";
            this.btnLöschen.UseVisualStyleBackColor = true;
            this.btnLöschen.Click += new System.EventHandler(this.btnLöschen_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(426, 380);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(117, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "Speichern";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnAbrechen
            // 
            this.btnAbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAbrechen.Location = new System.Drawing.Point(550, 380);
            this.btnAbrechen.Name = "btnAbrechen";
            this.btnAbrechen.Size = new System.Drawing.Size(117, 23);
            this.btnAbrechen.TabIndex = 5;
            this.btnAbrechen.Text = "Abbrechen";
            this.btnAbrechen.UseVisualStyleBackColor = true;
            this.btnAbrechen.Click += new System.EventHandler(this.btnAbrechen_Click);
            // 
            // lblAnzeigeElemente
            // 
            this.lblAnzeigeElemente.AutoSize = true;
            this.lblAnzeigeElemente.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblAnzeigeElemente.Location = new System.Drawing.Point(12, 379);
            this.lblAnzeigeElemente.Name = "lblAnzeigeElemente";
            this.lblAnzeigeElemente.Size = new System.Drawing.Size(330, 30);
            this.lblAnzeigeElemente.TabIndex = 6;
            this.lblAnzeigeElemente.Text = "In der Liste enthaltene Elemente: ";
            this.lblAnzeigeElemente.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lblAnzeigeElemente_MouseDoubleClick);
            // 
            // lblGewicht
            // 
            this.lblGewicht.AutoSize = true;
            this.lblGewicht.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblGewicht.Location = new System.Drawing.Point(549, 342);
            this.lblGewicht.Name = "lblGewicht";
            this.lblGewicht.Size = new System.Drawing.Size(127, 30);
            this.lblGewicht.TabIndex = 8;
            this.lblGewicht.Text = "Gewichtung";
            // 
            // nupGewicht
            // 
            this.nupGewicht.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.nupGewicht.Location = new System.Drawing.Point(426, 339);
            this.nupGewicht.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nupGewicht.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupGewicht.Name = "nupGewicht";
            this.nupGewicht.Size = new System.Drawing.Size(117, 35);
            this.nupGewicht.TabIndex = 9;
            this.nupGewicht.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // EingabeZufallVariable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 413);
            this.ControlBox = false;
            this.Controls.Add(this.nupGewicht);
            this.Controls.Add(this.lblGewicht);
            this.Controls.Add(this.lblAnzeigeElemente);
            this.Controls.Add(this.btnAbrechen);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnLöschen);
            this.Controls.Add(this.btnÜbernehmen);
            this.Controls.Add(this.txtEingabe);
            this.Controls.Add(this.LstBoxVariablen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EingabeZufallVariable";
            this.Text = "EingabeZufallVariable";
            this.Load += new System.EventHandler(this.EingabeZufallVariable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nupGewicht)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LstBoxVariablen;
        private System.Windows.Forms.TextBox txtEingabe;
        private System.Windows.Forms.Button btnÜbernehmen;
        private System.Windows.Forms.Button btnLöschen;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnAbrechen;
        private System.Windows.Forms.Label lblAnzeigeElemente;
        private System.Windows.Forms.Label lblGewicht;
        private System.Windows.Forms.NumericUpDown nupGewicht;
    }
}