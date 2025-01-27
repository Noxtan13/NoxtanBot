namespace AntonBot.Fenster
{
    partial class ListZitatEintragFenster
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
            this.TableEinträge = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // TableEinträge
            // 
            this.TableEinträge.AutoSize = true;
            this.TableEinträge.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.TableEinträge.ColumnCount = 5;
            this.TableEinträge.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.TableEinträge.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.91421F));
            this.TableEinträge.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.08579F));
            this.TableEinträge.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.TableEinträge.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 127F));
            this.TableEinträge.Location = new System.Drawing.Point(12, 12);
            this.TableEinträge.Name = "TableEinträge";
            this.TableEinträge.RowCount = 1;
            this.TableEinträge.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.TableEinträge.Size = new System.Drawing.Size(1001, 38);
            this.TableEinträge.TabIndex = 1;
            // 
            // ListZitatEintragFenster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 450);
            this.Controls.Add(this.TableEinträge);
            this.Name = "ListZitatEintragFenster";
            this.Text = "ListZitatEintragFenster";
            this.Load += new System.EventHandler(this.ListZitatEintragFenster_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TableEinträge;
    }
}