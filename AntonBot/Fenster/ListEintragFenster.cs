using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AntonBot.Fenster
{
    public partial class ListEintragFenster : Form
    {
        public List<PlatformAPI.Eintrag> EintragListe = new List<PlatformAPI.Eintrag>();
        public ListEintragFenster()
        {
            InitializeComponent();
        }

        private void ListEintragFenster_Load(object sender, EventArgs e)
        {


            TableEinträge.ColumnCount = 4;
            TableEinträge.RowCount = 1;
            TableEinträge.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 25));
            TableEinträge.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
            TableEinträge.Controls.Add(new Label() { Text = "Eintrag Nr." }, 0, 0);
            TableEinträge.Controls.Add(new Label() { Text = "Eintrag" }, 1, 0);
            TableEinträge.Controls.Add(new Label() { Text = "Von User" }, 2, 0);
            TableEinträge.Controls.Add(new Label() { Text = "Aus Quelle" }, 3, 0);


            // For Add New Row (Loop this code for add multiple rows)

            for (int i = 0; i < EintragListe.Count; i++)
            {
                //RowStyle temp = TableEinträge.RowStyles[TableEinträge.RowCount - 1];

                TableEinträge.RowCount++;
                TableEinträge.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
                TableEinträge.Controls.Add(new Label() { Text = i.ToString() }, 0, TableEinträge.RowCount - 1);
                TableEinträge.Controls.Add(new Label() { Text = EintragListe[i].UserEintrag }, 1, TableEinträge.RowCount - 1);
                TableEinträge.Controls.Add(new Label() { Text = EintragListe[i].User }, 2, TableEinträge.RowCount - 1);
                TableEinträge.Controls.Add(new Label() { Text = EintragListe[i].PlattformQuelle }, 3, TableEinträge.RowCount - 1);
            }

            TableEinträge.Refresh();
        }
    }
}
