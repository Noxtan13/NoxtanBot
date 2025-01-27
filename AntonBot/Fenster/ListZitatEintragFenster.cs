using AntonBot.PlatformAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntonBot.Fenster
{
    public partial class ListZitatEintragFenster : Form
    {
        public ListZitatEintragFenster()
        {
            InitializeComponent();
        }

        private void ListZitatEintragFenster_Load(object sender, EventArgs e)
        {
            TableEinträge.ColumnCount = 5;
            TableEinträge.RowCount = 1;
            TableEinträge.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 25));
            TableEinträge.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
            TableEinträge.Controls.Add(new Label() { Text = "Zitat Nr." }, 0, 0);
            TableEinträge.Controls.Add(new Label() { Text = "Zitat" }, 1, 0);
            TableEinträge.Controls.Add(new Label() { Text = "Von User" }, 2, 0);
            TableEinträge.Controls.Add(new Label() { Text = "Aus Quelle" }, 3, 0);
            TableEinträge.Controls.Add(new Label() { Text = "Zeitpunkt" }, 4, 0);

            // For Add New Row (Loop this code for add multiple rows)
            if (SettingsGroup.Instance.ZitateEintraege != null)
            {
                foreach(var item in SettingsGroup.Instance.ZitateEintraege)
                {
                    //RowStyle temp = TableEinträge.RowStyles[TableEinträge.RowCount - 1];

                    TableEinträge.RowCount++;
                    TableEinträge.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
                    TableEinträge.Controls.Add(new Label() { Text = item.Number.ToString() }, 0, TableEinträge.RowCount - 1);
                    TableEinträge.Controls.Add(new Label() { Text = item.Zitat }, 1, TableEinträge.RowCount - 1);
                    TableEinträge.Controls.Add(new Label() { Text = item.Ersteller }, 2, TableEinträge.RowCount - 1);
                    TableEinträge.Controls.Add(new Label() { Text = item.Plattform }, 3, TableEinträge.RowCount - 1);
                    TableEinträge.Controls.Add(new Label() { Text = item.ZitatZeitpunkt.ToLongDateString() }, 4, TableEinträge.RowCount - 1);
                }
            }
            TableEinträge.Refresh();
        }
    }
}
