using AntonBot.PlatformAPI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AntonBot
{

    public partial class EingabeZufallVariable : Form
    {
        public List<RandomBefehl> randomBefehls;
        private int ausgewählterIndex = 0;
        private bool update = false;
        public EingabeZufallVariable()
        {
            InitializeComponent();
        }

        private void EingabeZufallVariable_Load(object sender, EventArgs e)
        {
            ListeAktualisieren();
        }

        private void ListeAktualisieren()
        {
            LstBoxVariablen.Items.Clear();
            foreach (RandomBefehl item in randomBefehls)
            {
                LstBoxVariablen.Items.Add(item.Text);
            }
            lblAnzeigeElemente.Text = "In der Liste enthaltene Elemente: " + randomBefehls.Count;
        }
        private void btnÜbernehmen_Click(object sender, EventArgs e)
        {
            if (update)
            {
                RandomBefehl updateBefehl = new RandomBefehl();

                updateBefehl.Text = txtEingabe.Text;
                updateBefehl.Wahrscheinlichkeit = decimal.ToInt32(nupGewicht.Value);

                randomBefehls.RemoveAt(ausgewählterIndex);
                randomBefehls.Insert(ausgewählterIndex, updateBefehl);

                update = false;
                ausgewählterIndex = 0;
            }
            else
            {
                RandomBefehl neuerBefehl = new RandomBefehl();
                neuerBefehl.Text = txtEingabe.Text;
                neuerBefehl.Wahrscheinlichkeit = decimal.ToInt32(nupGewicht.Value);

                randomBefehls.Add(neuerBefehl);
            }

            txtEingabe.Text = "";
            nupGewicht.Value = 1;

            ListeAktualisieren();
        }

        private void btnLöschen_Click(object sender, EventArgs e)
        {
            randomBefehls.RemoveAt(ausgewählterIndex);
            ausgewählterIndex = 0;
            update = false;
            txtEingabe.Text = "";
            nupGewicht.Value = 1;
            ListeAktualisieren();
        }

        private void LstBoxVariablen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LstBoxVariablen.SelectedItem != null)
            {
                ausgewählterIndex = LstBoxVariablen.SelectedIndex;
                txtEingabe.Text = randomBefehls[ausgewählterIndex].Text;
                nupGewicht.Value = randomBefehls[ausgewählterIndex].Wahrscheinlichkeit;
                update = true;
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblAnzeigeElemente_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MessageBox.Show("Gewichtung ALLER Elemente auf 1 zurücksetzen?", "Zurücksetzen der Werte", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (RandomBefehl item in randomBefehls)
                {
                    item.Wahrscheinlichkeit = 1;
                }
            }
        }
    }
}
