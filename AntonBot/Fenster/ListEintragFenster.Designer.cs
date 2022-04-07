
namespace AntonBot.Fenster
{
    partial class ListEintragFenster
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
            this.TableEinträge.ColumnCount = 4;
            this.TableEinträge.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.TableEinträge.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.5022F));
            this.TableEinträge.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.4978F));
            this.TableEinträge.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.TableEinträge.Location = new System.Drawing.Point(12, 12);
            this.TableEinträge.Name = "TableEinträge";
            this.TableEinträge.RowCount = 1;
            this.TableEinträge.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableEinträge.Size = new System.Drawing.Size(820, 34);
            this.TableEinträge.TabIndex = 0;
            // 
            // ListEintragFenster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 651);
            this.Controls.Add(this.TableEinträge);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Name = "ListEintragFenster";
            this.Text = "ListEintragFenster";
            this.Load += new System.EventHandler(this.ListEintragFenster_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TableEinträge;
    }
}