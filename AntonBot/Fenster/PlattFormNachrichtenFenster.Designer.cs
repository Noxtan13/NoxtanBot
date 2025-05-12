namespace AntonBot.Fenster
{
    partial class PlattFormNachrichtenFenster
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
            this.chkPlattformUse = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnVariable = new System.Windows.Forms.Button();
            this.cmbVariable = new System.Windows.Forms.ComboBox();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.chkSendDiscord = new System.Windows.Forms.CheckBox();
            this.chkSendTwitch = new System.Windows.Forms.CheckBox();
            this.txtPlattformKommand = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkPlattformUse
            // 
            this.chkPlattformUse.AutoSize = true;
            this.chkPlattformUse.Location = new System.Drawing.Point(12, 12);
            this.chkPlattformUse.Name = "chkPlattformUse";
            this.chkPlattformUse.Size = new System.Drawing.Size(442, 34);
            this.chkPlattformUse.TabIndex = 0;
            this.chkPlattformUse.Text = "Nachrichten an andere Plattformen senden";
            this.chkPlattformUse.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnVariable);
            this.groupBox1.Controls.Add(this.cmbVariable);
            this.groupBox1.Controls.Add(this.txtAnswer);
            this.groupBox1.Controls.Add(this.chkSendDiscord);
            this.groupBox1.Controls.Add(this.chkSendTwitch);
            this.groupBox1.Controls.Add(this.txtPlattformKommand);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(506, 434);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnVariable
            // 
            this.btnVariable.Location = new System.Drawing.Point(326, 388);
            this.btnVariable.Name = "btnVariable";
            this.btnVariable.Size = new System.Drawing.Size(174, 38);
            this.btnVariable.TabIndex = 13;
            this.btnVariable.Text = "Variable";
            this.btnVariable.UseVisualStyleBackColor = true;
            this.btnVariable.Click += new System.EventHandler(this.btnVariable_Click);
            // 
            // cmbVariable
            // 
            this.cmbVariable.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.cmbVariable.FormattingEnabled = true;
            this.cmbVariable.Items.AddRange(new object[] {
            "Username",
            "Plattform",
            "Text"});
            this.cmbVariable.Location = new System.Drawing.Point(6, 388);
            this.cmbVariable.Name = "cmbVariable";
            this.cmbVariable.Size = new System.Drawing.Size(314, 38);
            this.cmbVariable.TabIndex = 12;
            // 
            // txtAnswer
            // 
            this.txtAnswer.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtAnswer.Location = new System.Drawing.Point(6, 109);
            this.txtAnswer.Multiline = true;
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAnswer.Size = new System.Drawing.Size(494, 273);
            this.txtAnswer.TabIndex = 11;
            this.txtAnswer.Text = "Antwort";
            this.txtAnswer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtAnswer_MouseDoubleClick);
            // 
            // chkSendDiscord
            // 
            this.chkSendDiscord.AutoSize = true;
            this.chkSendDiscord.Location = new System.Drawing.Point(105, 69);
            this.chkSendDiscord.Name = "chkSendDiscord";
            this.chkSendDiscord.Size = new System.Drawing.Size(105, 34);
            this.chkSendDiscord.TabIndex = 3;
            this.chkSendDiscord.Text = "Discord";
            this.chkSendDiscord.UseVisualStyleBackColor = true;
            // 
            // chkSendTwitch
            // 
            this.chkSendTwitch.AutoSize = true;
            this.chkSendTwitch.Location = new System.Drawing.Point(6, 69);
            this.chkSendTwitch.Name = "chkSendTwitch";
            this.chkSendTwitch.Size = new System.Drawing.Size(93, 34);
            this.chkSendTwitch.TabIndex = 2;
            this.chkSendTwitch.Text = "Twitch";
            this.chkSendTwitch.UseVisualStyleBackColor = true;
            // 
            // txtPlattformKommand
            // 
            this.txtPlattformKommand.Location = new System.Drawing.Point(138, 28);
            this.txtPlattformKommand.Name = "txtPlattformKommand";
            this.txtPlattformKommand.Size = new System.Drawing.Size(362, 35);
            this.txtPlattformKommand.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kommando";
            // 
            // PlattFormNachrichtenFenster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 493);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkPlattformUse);
            this.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "PlattFormNachrichtenFenster";
            this.Text = "PlattFormNachrichten";
            this.Load += new System.EventHandler(this.PlattFormNachrichtenFenster_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkPlattformUse;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkSendDiscord;
        private System.Windows.Forms.CheckBox chkSendTwitch;
        private System.Windows.Forms.TextBox txtPlattformKommand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVariable;
        private System.Windows.Forms.ComboBox cmbVariable;
        private System.Windows.Forms.TextBox txtAnswer;
    }
}