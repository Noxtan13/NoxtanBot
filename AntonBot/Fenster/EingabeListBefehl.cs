using AntonBot.PlatformAPI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AntonBot.Fenster
{
    public partial class EingabeListBefehl : Form
    {
        public List_Befehl List_Befehll;
        private int LetzeKommandobox = 0;
        public EingabeListBefehl()
        {
            InitializeComponent();
        }

        private void EingabeListBefehl_Load(object sender, EventArgs e)
        {
            txtKommando.Text = List_Befehll.Kommando;
            txtAusgabe.Text = List_Befehll.AusgabeListe;
            txtTrennungszeichen.Text = List_Befehll.BefehlTrennungszeichen.ToString();
            txtNextBefehl.Text = List_Befehll.NextBefehl;
            txtNextAntwort.Text = List_Befehll.NextAntwort;
            chkNextAdmin.Checked = List_Befehll.NextOnlyAdmin;
            chkGroupLoeschen.Checked = List_Befehll.HatLöschBefehl;
            txtLöschKommando.Enabled = List_Befehll.HatLöschBefehl;
            txtLoeschAntwort.Enabled = List_Befehll.HatLöschBefehl;
            txtLoeschFail.Enabled = List_Befehll.HatLöschBefehl;
            txtLöschKommando.Text = List_Befehll.LöschBefehl;
            txtLoeschAntwort.Text = List_Befehll.LöschAntwort;
            txtLoeschFail.Text = List_Befehll.LöschAntwortFail;
            chkOnlyKommands.Checked = List_Befehll.NurEigeneBefehle;
            chkUpdateEintrag.Checked = List_Befehll.UpdateOwn;
            txtUpdate.Text = List_Befehll.UpdateAntwort;

            chkOpenCloseUse.Checked = List_Befehll.OpenClose;
            txtOpenCommand.Text = List_Befehll.OpenCommand;
            txtOpenText.Text = List_Befehll.OpenText;
            txtCloseCommand.Text = List_Befehll.CloseCommand;
            txtCloseText.Text = List_Befehll.CloseText;
            chkOpenCloseAdmin.Checked = List_Befehll.OpenCloseAdmin;

            txtCurrentAntwort.Text = List_Befehll.CurrentAntwort;
            txtCurrentBefehl.Text = List_Befehll.CurrentBefehl;

            txtHinzufügen.Text = List_Befehll.HinzufügenAntwort;

            txtAufbau.Text = List_Befehll.AufbauEintrag;
            if (List_Befehll.AnzahlEinträge < 1)
            {
                NUDAnzahl.Value = 1;
            }
            else
            {
                NUDAnzahl.Value = List_Befehll.AnzahlEinträge;
            }
        }

        private void btnSpeichern_Click(object sender, EventArgs e)
        {

            if (txtAusgabe.Text.Equals(""))
            {
                MessageBox.Show("Die Ausgabe der Liste fehlt. Wie soll man sonst wissen, was in der Liste aktuell ist?", "Nicht Vollständig", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtHinzufügen.Text.Equals(""))
            {
                MessageBox.Show("Die Antwort, wenn ein Befehl hinzugefügt wurde fehlt.", "Nicht Vollständig", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtCurrentBefehl.Text.Equals(""))
            {
                MessageBox.Show("Der Befehl zur Anzeige der aktuellen Antwort fehlt. So kann der erste Eintrag nicht angezeigt werden", "Nicht Vollständig", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtCurrentAntwort.Text.Equals(""))
            {
                MessageBox.Show("Die Antwort für den aktuellen Befehl fehlt.", "Nicht Vollständig", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtNextBefehl.Text.Equals(""))
            {
                MessageBox.Show("Ein Befehl um in der Liste zum nächsten Eintrag zu springen fehlt. So kann kein Punkt abgehakt werden.", "Nicht Vollständig", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtNextAntwort.Text.Equals(""))
            {
                MessageBox.Show("Die Antwort zum nächsten Befehl fehlt.", "Nicht Vollständig", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtLöschKommando.Text.Equals("") && chkGroupLoeschen.Checked)
            {
                MessageBox.Show("Der Befehl zum Löschen fehlt. Warum soll das Löschen verfügbar sein, wenn es keinen Befehl gibt?", "Nicht Vollständig", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtLoeschAntwort.Text.Equals("") && chkGroupLoeschen.Checked)
            {
                MessageBox.Show("Die Antwort für ein erfolgreiches Löschen fehlt. Möchtest du nicht für stolze Gefühle sorgen?", "Nicht Vollständig", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtLoeschFail.Text.Equals("") && chkGroupLoeschen.Checked)
            {
                MessageBox.Show("Die Antwort für einen gescheiterten Lösch-Versuch fehlt. Soll den niemand wissen, wie verzweifelt der Bot gesucht hat?", "Nicht Vollständig", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtUpdate.Text.Equals("")&& chkUpdateEintrag.Checked)
            {
                MessageBox.Show("Die Antwort für einen Update fehlt. Eine Rückmeldung wäre nicht schlecht", "Nicht Vollständig", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtOpenCommand.Text.Equals("")||txtCloseCommand.Text.Equals("") && chkOpenCloseUse.Checked)
            {
                MessageBox.Show("Die Kommandos für die Open-Close-Funktion sind nicht gesetzt", "Nicht Vollständig", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                List_Befehll.Kommando = txtKommando.Text;
                List_Befehll.AusgabeListe = txtAusgabe.Text;
                List_Befehll.BefehlTrennungszeichen = Convert.ToChar(txtTrennungszeichen.Text);
                List_Befehll.NextBefehl = txtNextBefehl.Text;
                List_Befehll.NextAntwort = txtNextAntwort.Text;
                List_Befehll.NextOnlyAdmin = chkNextAdmin.Checked;
                List_Befehll.HatLöschBefehl = chkGroupLoeschen.Checked;
                List_Befehll.LöschBefehl = txtLöschKommando.Text;
                List_Befehll.LöschAntwort = txtLoeschAntwort.Text;
                List_Befehll.LöschAntwortFail = txtLoeschFail.Text;
                List_Befehll.NurEigeneBefehle = chkOnlyKommands.Checked;
                List_Befehll.AufbauEintrag = txtAufbau.Text;
                List_Befehll.AnzahlEinträge = Convert.ToInt32(NUDAnzahl.Value);
                List_Befehll.UpdateOwn = chkUpdateEintrag.Checked;
                List_Befehll.UpdateAntwort = txtUpdate.Text;

                List_Befehll.CurrentAntwort = txtCurrentAntwort.Text;
                List_Befehll.CurrentBefehl = txtCurrentBefehl.Text;
                List_Befehll.HinzufügenAntwort = txtHinzufügen.Text;

                List_Befehll.OpenClose = chkOpenCloseUse.Checked;
                List_Befehll.OpenCommand = txtOpenCommand.Text;
                List_Befehll.OpenText = txtOpenText.Text;
                List_Befehll.CloseCommand = txtCloseCommand.Text;
                List_Befehll.CloseText = txtCloseText.Text;
                List_Befehll.OpenCloseAdmin = chkOpenCloseAdmin.Checked;

                if (List_Befehll.Eintragsliste == null)
                {
                    List_Befehll.Eintragsliste = new List<Eintrag>();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkNextAdmin_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkGroupLoeschen_CheckedChanged(object sender, EventArgs e)
        {
            txtLöschKommando.Enabled = chkGroupLoeschen.Checked;
            txtLoeschAntwort.Enabled = chkGroupLoeschen.Checked;
            txtLoeschFail.Enabled = chkGroupLoeschen.Checked;
        }

        private void txtKommando_MouseClick(object sender, MouseEventArgs e)
        {
            LetzeKommandobox = 1;
        }

        private void txtAusgabe_MouseClick(object sender, MouseEventArgs e)
        {
            LetzeKommandobox = 2;
        }

        private void txtAufbau_MouseClick(object sender, MouseEventArgs e)
        {
            LetzeKommandobox = 3;
        }

        private void txtTrennungszeichen_MouseClick(object sender, MouseEventArgs e)
        {
            LetzeKommandobox = 4;
        }

        private void txtNextBefehl_MouseClick(object sender, MouseEventArgs e)
        {
            LetzeKommandobox = 5;
        }
        private void txtNextAntwort_MouseClick(object sender, MouseEventArgs e)
        {
            LetzeKommandobox = 6;
        }
        private void txtLöschKommando_MouseClick(object sender, MouseEventArgs e)
        {
            LetzeKommandobox = 7;
        }

        private void txtLoeschAntwort_MouseClick(object sender, MouseEventArgs e)
        {
            LetzeKommandobox = 8;
        }

        private void txtLoeschFail_MouseClick(object sender, MouseEventArgs e)
        {
            LetzeKommandobox = 9;
        }

        private void txtCurrentAntwort_MouseClick(object sender, MouseEventArgs e)
        {
            LetzeKommandobox = 10;
        }
        private void txtCurrentBefehl_MouseClick(object sender, MouseEventArgs e)
        {
            LetzeKommandobox = 11;
        }
        private void txtHinzufügen_TextChanged(object sender, EventArgs e)
        {
            LetzeKommandobox = 12;
        }

        private void btnVariable_Click(object sender, EventArgs e)
        {
            /*
             * Auflistung
               ListNummer
               ListEintrag
               ListBenutzer
               ListQuelle
               Name
               OptionalerTeil
             */
            switch (LetzeKommandobox)
            {
                case 1:
                    //txtKommando
                    MessageBox.Show("Kann nicht in Kommando eingefügt werden.", "Auswahl nicht möglich", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 2:
                    //txtAusgabe
                    if (cmbVariable.Text == "OptionalerTeil")
                    {
                        MessageBox.Show("Kann nicht in die Antwort der Liste eingefügt werden, da es sonst als \"Neuer Eintrag\" gewertet wird.", "Auswahl nicht möglich", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (cmbVariable.Text.Contains("List"))
                    {
                        MessageBox.Show("Kann nicht in die Antwort der Liste eingefügt werden, da die Listen-Einträge nur für den Aufbau sind", "Auswahl nicht möglich", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        txtAusgabe.Text = txtAusgabe.Text + "°" + cmbVariable.Text;
                    }
                    break;
                case 3:
                    //txtAufbau
                    if (cmbVariable.Text == "OptionalerTeil" || cmbVariable.Text == "Name")
                    {
                        MessageBox.Show("Kann nicht in die Auflistung eingefügt werden, da es sonst immer wieder ausgegeben werden würde.", "Auswahl nicht möglich", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (cmbVariable.Text == "Auflistung")
                    {
                        MessageBox.Show("Die Auflistung kann nicht in die Auflistung eingefügt werden. Das wäre Rekursiv." + Environment.NewLine + Environment.NewLine + "Wenn du es nicht verstanden hast, ließ die Meldung nochmal", "Auswahl nicht möglich", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        txtAufbau.Text = txtAufbau.Text + "°" + cmbVariable.Text;
                    }
                    break;
                case 4:
                    //txtTrennungszeichen
                    MessageBox.Show("Kann nicht für das Trennungszeichen verwendet werden.", "Auswahl nicht möglich", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 5:
                    //txtNextBefehl
                    MessageBox.Show("Kann nicht als nächster Befehl eingefügt werden.", "Auswahl nicht möglich", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 6:
                    //txtNextAntwort
                    if (cmbVariable.Text == "ListNummer")
                    {
                        MessageBox.Show("Die Nummer hier anzugeben macht keinen Sinn. Es wird im Feld \"NextAntwort\" der nächste Eintrag angezeigt", "Auswahl nicht möglich", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        txtNextAntwort.Text = txtNextAntwort.Text + "°" + cmbVariable.Text;
                    }
                    break;
                case 7:
                    //txtLöschKommando
                    MessageBox.Show("Kann nicht in Lösch-Kommando eingefügt werden.", "Auswahl nicht möglich", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 8:
                    //txtLöschAntwort
                    txtLoeschAntwort.Text = txtLoeschAntwort.Text + "°" + cmbVariable.Text;
                    break;
                case 9:
                    //txtLöschFail
                    if (cmbVariable.Text.Contains("List") || cmbVariable.Text == "Auflistung")
                    {
                        MessageBox.Show("Da kein Eintrag zum Löschen erkannt werden kann, kann zu dieser Variable nichts ermittelt werden.", "Auswahl nicht möglich", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        txtLoeschFail.Text = txtLoeschFail.Text + "°" + cmbVariable.Text;
                    }

                    break;
                case 10:
                    //txtCurrentAntwort
                    if (cmbVariable.Text == "ListNummer")
                    {
                        MessageBox.Show("Die Nummer hier anzugeben macht keinen Sinn. Es wird im Feld \"NextAntwort\" der aktuelle Eintrag angezeigt", "Auswahl nicht möglich", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        txtCurrentAntwort.Text = txtCurrentAntwort.Text + "°" + cmbVariable.Text;
                    }
                    break;
                case 11:
                    MessageBox.Show("Kann nicht als aktueller Befehl eingefügt werden.", "Auswahl nicht möglich", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 12:
                    //txtHinzufügen
                    if (cmbVariable.Text.Contains("List") || cmbVariable.Text == "Auflistung")
                    {
                        MessageBox.Show("Da der Eintrag noch nicht gespeichert ist, kann zu dieser Variable nichts ermittelt werden.", "Auswahl nicht möglich", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        txtHinzufügen.Text = txtHinzufügen.Text + "°" + cmbVariable.Text;
                    }
                    break;
                default:
                    MessageBox.Show("Kein Feld wurde ausgewählt", "Auswahl nicht möglich", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        private void btnDaten_Click(object sender, EventArgs e)
        {
            using (Fenster.ListEintragFenster Fenster = new Fenster.ListEintragFenster())
            {
                Fenster.EintragListe = List_Befehll.Eintragsliste;
                DialogResult dr = Fenster.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    List_Befehll.Eintragsliste = Fenster.EintragListe;
                }

            }
        }

        private void EingabeListBefehl_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void chkUpdateEintrag_CheckedChanged(object sender, EventArgs e)
        {
            txtUpdate.Enabled= chkUpdateEintrag.Checked;
        }
    }
}
