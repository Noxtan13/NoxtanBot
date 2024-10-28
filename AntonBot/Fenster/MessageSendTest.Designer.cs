
namespace AntonBot.Fenster
{
    partial class MessageSendTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageSendTest));
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSenden = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbTwitch = new System.Windows.Forms.RadioButton();
            this.rdbDiscord = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbKanal = new System.Windows.Forms.ComboBox();
            this.chkPlattformMessage = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(20, 99);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(446, 35);
            this.txtMessage.TabIndex = 0;
            // 
            // btnSenden
            // 
            this.btnSenden.Location = new System.Drawing.Point(472, 99);
            this.btnSenden.Name = "btnSenden";
            this.btnSenden.Size = new System.Drawing.Size(167, 42);
            this.btnSenden.TabIndex = 1;
            this.btnSenden.Text = "Senden";
            this.btnSenden.UseVisualStyleBackColor = true;
            this.btnSenden.Click += new System.EventHandler(this.btnSenden_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Plattform:";
            // 
            // rdbTwitch
            // 
            this.rdbTwitch.AutoSize = true;
            this.rdbTwitch.Location = new System.Drawing.Point(158, 12);
            this.rdbTwitch.Name = "rdbTwitch";
            this.rdbTwitch.Size = new System.Drawing.Size(92, 34);
            this.rdbTwitch.TabIndex = 3;
            this.rdbTwitch.TabStop = true;
            this.rdbTwitch.Text = "Twitch";
            this.rdbTwitch.UseVisualStyleBackColor = true;
            this.rdbTwitch.CheckedChanged += new System.EventHandler(this.rdbTwitch_CheckedChanged);
            // 
            // rdbDiscord
            // 
            this.rdbDiscord.AutoSize = true;
            this.rdbDiscord.Location = new System.Drawing.Point(273, 12);
            this.rdbDiscord.Name = "rdbDiscord";
            this.rdbDiscord.Size = new System.Drawing.Size(104, 34);
            this.rdbDiscord.TabIndex = 4;
            this.rdbDiscord.TabStop = true;
            this.rdbDiscord.Text = "Discord";
            this.rdbDiscord.UseVisualStyleBackColor = true;
            this.rdbDiscord.CheckedChanged += new System.EventHandler(this.rdbDiscord_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 30);
            this.label2.TabIndex = 5;
            this.label2.Text = "Kanal:";
            // 
            // cbbKanal
            // 
            this.cbbKanal.FormattingEnabled = true;
            this.cbbKanal.Location = new System.Drawing.Point(118, 49);
            this.cbbKanal.Name = "cbbKanal";
            this.cbbKanal.Size = new System.Drawing.Size(521, 38);
            this.cbbKanal.TabIndex = 6;
            // 
            // chkPlattformMessage
            // 
            this.chkPlattformMessage.AutoSize = true;
            this.chkPlattformMessage.Location = new System.Drawing.Point(383, 13);
            this.chkPlattformMessage.Name = "chkPlattformMessage";
            this.chkPlattformMessage.Size = new System.Drawing.Size(256, 34);
            this.chkPlattformMessage.TabIndex = 7;
            this.chkPlattformMessage.Text = "über PlattformMessage";
            this.chkPlattformMessage.UseVisualStyleBackColor = true;
            // 
            // MessageSendTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 157);
            this.Controls.Add(this.chkPlattformMessage);
            this.Controls.Add(this.cbbKanal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rdbDiscord);
            this.Controls.Add(this.rdbTwitch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSenden);
            this.Controls.Add(this.txtMessage);
            this.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MessageSendTest";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSenden;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbTwitch;
        private System.Windows.Forms.RadioButton rdbDiscord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbKanal;
        private System.Windows.Forms.CheckBox chkPlattformMessage;
    }
}