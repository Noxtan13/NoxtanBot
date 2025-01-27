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
    public partial class ZitateEinstellungen : Form
    {
        public ZitateEinstellungen()
        {
            InitializeComponent();
        }

        private void ZitateEinstellungen_Load(object sender, EventArgs e)
        {
            chkZitateUse.Checked = SettingsGroup.Instance.bZitateUse;
            txtZitatCommand.Text = SettingsGroup.Instance.sZitateBefehl;
            txtZitatAntwort.Text = SettingsGroup.Instance.sZitateBefehlText;
            chkZitateAdd.Checked = SettingsGroup.Instance.bZitateAdd;
            txtZitateAdd.Text = SettingsGroup.Instance.sZitateAddText;
            txtAddAnswer.Text = SettingsGroup.Instance.sZitateAddAnswer;
            chkAddAll.Checked = SettingsGroup.Instance.bZitateAddAll;   
            chkAddVIP.Checked= SettingsGroup.Instance.bZitateAddVIP;
            chkAddMod.Checked= SettingsGroup.Instance.bZitateAddMod;
            chkZitateDelete.Checked = SettingsGroup.Instance.bZitateRemove;
            txtZitateDelete.Text= SettingsGroup.Instance.sZitateRemoveText;
            txtDeleteAnswer.Text= SettingsGroup.Instance.sZitateRemoveAnswer;
            chkDeleteAll.Checked = SettingsGroup.Instance.bZitateRemoveAll;
            chkDeleteVIP.Checked = SettingsGroup.Instance.bZitateRemoveVIP;
            chkDeleteMod.Checked = SettingsGroup.Instance.bZitateRemoveMod;
            chkZitatSuche.Checked = SettingsGroup.Instance.bZitatSuche;
            txtZitateFailSearch.Text = SettingsGroup.Instance.sZitatSucheText;

            grpZitateBox.Enabled = SettingsGroup.Instance.bZitateUse;


        }

        private void ZitateEinstellungen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Validierung())
            {
                SettingsGroup.Instance.bZitateUse = chkZitateUse.Checked;
                SettingsGroup.Instance.sZitateBefehl = txtZitatCommand.Text;
                SettingsGroup.Instance.sZitateBefehlText = txtZitatAntwort.Text;
                SettingsGroup.Instance.bZitateAdd = chkZitateAdd.Checked;
                SettingsGroup.Instance.sZitateAddText = txtZitateAdd.Text;
                SettingsGroup.Instance.sZitateAddAnswer = txtAddAnswer.Text;
                SettingsGroup.Instance.bZitateAddAll = chkAddAll.Checked;
                SettingsGroup.Instance.bZitateAddVIP = chkAddVIP.Checked;
                SettingsGroup.Instance.bZitateAddMod = chkAddMod.Checked;
                SettingsGroup.Instance.bZitateRemove = chkZitateDelete.Checked;
                SettingsGroup.Instance.sZitateRemoveText = txtZitateDelete.Text;
                SettingsGroup.Instance.sZitateRemoveAnswer = txtDeleteAnswer.Text;
                SettingsGroup.Instance.bZitateRemoveAll = chkDeleteAll.Checked;
                SettingsGroup.Instance.bZitateRemoveVIP = chkDeleteVIP.Checked;
                SettingsGroup.Instance.bZitateRemoveMod = chkDeleteMod.Checked;
                SettingsGroup.Instance.bZitatSuche = chkZitatSuche.Checked;

                SettingsGroup.Instance.sZitatSucheText = txtZitateFailSearch.Text;

                if (SettingsGroup.Instance.ZitateEintraege == null)
                {
                    SettingsGroup.Instance.ZitateEintraege = new List<PlatformAPI.ListenTypen.ZitatEintrag> ();
                }

                SettingsGroup.Instance.Save();
            }
            else {
                e.Cancel = true;
                MessageBox.Show("Nicht alle Felder sind ausgefüllt, die aktiviert wurden");
            }
        }

        bool Validierung() {
            if (chkZitateUse.Checked && txtZitatCommand.Text == string.Empty){return false;}
            if(txtZitatCommand.Text != string.Empty && txtZitatAntwort.Text==string.Empty) { return false; }
            if(chkZitateAdd.Checked && txtZitateAdd.Text == string.Empty || txtAddAnswer.Text==string.Empty){return false;}
            if(chkZitateDelete.Checked && txtZitateDelete.Text == string.Empty|| txtDeleteAnswer.Text==string.Empty){return false;}
            if(chkZitatSuche.Checked && txtZitateFailSearch.Text == string.Empty){return false;}
            return true;
        }

        private void chkZitateUse_CheckedChanged(object sender, EventArgs e)
        {
            grpZitateBox.Enabled = chkZitateUse.Checked;
        }

        private void chkZitateAdd_CheckedChanged(object sender, EventArgs e)
        {
            txtZitateAdd.Enabled = chkZitateAdd.Checked;
            chkAddAll.Enabled = chkZitateAdd.Checked;
            chkAddMod.Enabled = chkZitateAdd.Checked;
            chkAddVIP.Enabled = chkZitateAdd.Checked;
        }

        private void chkZitateDelete_CheckedChanged(object sender, EventArgs e)
        {
            txtZitateDelete.Enabled = chkZitateDelete.Checked;
            chkDeleteAll.Enabled = chkZitateDelete.Checked;
            chkDeleteMod.Enabled = chkZitateDelete.Checked;
            chkDeleteVIP.Enabled = chkZitateDelete.Checked;

        }

        private void chkZitatSuche_CheckedChanged(object sender, EventArgs e)
        {
            txtZitateFailSearch.Enabled=chkZitatSuche.Checked;
        }

        private void btnVariable_Click(object sender, EventArgs e)
        {
            if (cmbVariable.Text != "")
            {
                txtZitatAntwort.Text = txtZitatAntwort.Text + "°" + cmbVariable.Text;
            }
        }

        private void btnZitateEinträge_Click(object sender, EventArgs e)
        {
            ListZitatEintragFenster listZitatEintragFenster = new ListZitatEintragFenster();
            listZitatEintragFenster.Show();
        }
    }
}
