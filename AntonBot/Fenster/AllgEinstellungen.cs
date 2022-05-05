using System;
using System.IO;
using System.Windows.Forms;
using AntonBot.PlatformAPI;

namespace AntonBot
{
    public partial class AllgEinstellungen : Form
    {
        public AllgEinstellungen()
        {
            InitializeComponent();
        }
        private bool Pfadändern;
        private void AllgEinstellungen_Load(object sender, EventArgs e)
        {
            
            chkAutoDiscord.Checked = SettingsGroup.Instance.SDiscordAutoStart;
            chkAutoTwitch.Checked = SettingsGroup.Instance.STwitchAutoStart;
            chkTwitchAutoBan.Checked = SettingsGroup.Instance.SAutoBan;
            chkTwitchAutoMessage.Checked = SettingsGroup.Instance.STwitchAutoMessage;

            chkAutoBotBannUse.Checked = SettingsGroup.Instance.STwitchAutoBotBann;
            TabControllList.Enabled = SettingsGroup.Instance.STwitchAutoBotBann;
            NUDLogAmount.Value = SettingsGroup.Instance.STwitchAutoBotAmount;
            NUDLogDuration.Value = SettingsGroup.Instance.STwitchAutoBotDuration;

            chkOtherChannelDiscord.Checked = SettingsGroup.Instance.SDiscordOtherChannel;
            txtDiscordOtherChannel.Text = SettingsGroup.Instance.SDiscordOtherChannelChannel.ToString();

            if (SettingsGroup.Instance.STwitchAutoBotWhiteList!= null)
            {
                foreach (string Eintrag in SettingsGroup.Instance.STwitchAutoBotWhiteList)
                {
                    lstWhiteList.Items.Add(Eintrag);
                }
            }
            else
            {
                SettingsGroup.Instance.STwitchAutoBotWhiteList= new System.Collections.Specialized.StringCollection();
            }
            if (SettingsGroup.Instance.STwitchBlackList != null)
            {
                foreach (string Eintrag in SettingsGroup.Instance.STwitchBlackList)
                {
                    lstBlackList.Items.Add(Eintrag);
                }
            }
            else
            {
                SettingsGroup.Instance.STwitchBlackList = new System.Collections.Specialized.StringCollection();
            }

            txtStandardPfad.Text = SettingsGroup.Instance.StandardPfad.Replace(Path.DirectorySeparatorChar,'/');
            txtHTML.Text = SettingsGroup.Instance.HTMLPfad.Replace(Path.DirectorySeparatorChar, '/');
            txtLogPfad.Text = SettingsGroup.Instance.LogPfad.Replace(Path.DirectorySeparatorChar, '/');

            Pfadändern = false;
        }

        private void BtnSpeichern_Click(object sender, EventArgs e)
        {
            SettingsGroup.Instance.SDiscordAutoStart= chkAutoDiscord.Checked;
            SettingsGroup.Instance.STwitchAutoStart= chkAutoTwitch.Checked;
            SettingsGroup.Instance.SAutoBan= chkTwitchAutoBan.Checked;
            SettingsGroup.Instance.STwitchAutoMessage= chkTwitchAutoMessage.Checked;

            SettingsGroup.Instance.SDiscordOtherChannel= chkOtherChannelDiscord.Checked;
            SettingsGroup.Instance.SDiscordOtherChannelChannel= Convert.ToUInt64(txtDiscordOtherChannel.Text);

            SettingsGroup.Instance.STwitchAutoBotBann= chkAutoBotBannUse.Checked;
            SettingsGroup.Instance.STwitchAutoBotAmount= decimal.ToInt32(NUDLogAmount.Value);
            SettingsGroup.Instance.STwitchAutoBotDuration= decimal.ToInt32(NUDLogDuration.Value);
            SettingsGroup.Instance.STwitchAutoBotWhiteList.Clear();
            foreach (string i in lstWhiteList.Items) {
                SettingsGroup.Instance.STwitchAutoBotWhiteList.Add(i);
            }

            if (!SettingsGroup.Instance.STwitchAutoBotWhiteList.Contains(SettingsGroup.Instance.TsStandardChannel) && chkAutoBotBannUse.Checked)
            {
                if (MessageBox.Show("Der eigene Benutzer fehlt. Soll dieser mit aufgenommen werden?", "Fehlender Eintrag", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SettingsGroup.Instance.STwitchAutoBotWhiteList.Add(SettingsGroup.Instance.TsStandardChannel);
                }
            }

            SettingsGroup.Instance.STwitchBlackList.Clear();
            foreach (string i in lstBlackList.Items)
            {
                SettingsGroup.Instance.STwitchBlackList.Add(i);
            }

            if (Pfadändern) {
                //Hier die Überprüfung, ob der Pfad geändert wurde. Wenn ja alle Einstellungsdateien dorthin kopieren, bevor der Pfad geändert wird
                //Muss nicht unbedingt für den HTML-Pfad erfolgen
                if(MessageBox.Show("Die Pfade haben sich geändert. Sollen diese übernommen werden?","Geänderte Pfade", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SettingsGroup.Instance.ExportSettingsGroup(SettingsGroup.Instance.StandardPfad);

                    SettingsGroup.Instance.StandardPfad = txtStandardPfad.Text.Replace('/', Path.DirectorySeparatorChar);
                    SettingsGroup.Instance.HTMLPfad = txtHTML.Text.Replace('/', Path.DirectorySeparatorChar);
                    SettingsGroup.Instance.LogPfad = txtLogPfad.Text.Replace('/', Path.DirectorySeparatorChar);

                    SettingsGroup.Instance.WriteAllSettings();
                }
                else
                {
                    txtStandardPfad.Text = SettingsGroup.Instance.StandardPfad.Replace(Path.DirectorySeparatorChar, '/');
                    txtHTML.Text = SettingsGroup.Instance.HTMLPfad.Replace(Path.DirectorySeparatorChar, '/');
                    txtLogPfad.Text = SettingsGroup.Instance.LogPfad.Replace(Path.DirectorySeparatorChar, '/');
                }
                

            }
     

            SettingsGroup.Instance.Save();

            //Close();
        }

        private void BtnAbbrechen_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chkTwitchAuto_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkAutoTwitch_CheckedChanged(object sender, EventArgs e)
        {
            chkTwitchAutoMessage.Enabled = chkAutoTwitch.Checked;
        }

        private void chkAutoBotBannUse_CheckedChanged(object sender, EventArgs e)
        {
            TabControllList.Enabled = chkAutoBotBannUse.Checked;
        }

        private void btnWhiteListAdd_Click(object sender, EventArgs e)
        {
            lstWhiteList.Items.Add(txtWhiteList.Text);
            txtWhiteList.Text = "";
        }

        private void btnWhiteListDelete_Click(object sender, EventArgs e)
        {
            lstWhiteList.Items.Remove(lstWhiteList.SelectedItem);
        }

        private void chkOtherChannelDiscord_CheckedChanged(object sender, EventArgs e)
        {
            txtDiscordOtherChannel.Enabled = chkOtherChannelDiscord.Checked;
        }

        private void txtDiscordOtherChannel_Leave(object sender, EventArgs e)
        {
            try
            {
                ulong test = Convert.ToUInt64(txtDiscordOtherChannel.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Eintrag ist keine Discord-ID", "Falscher Eintrag", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiscordOtherChannel.Text = "0";
            }
        }

        private void btnBlackAdd_Click(object sender, EventArgs e)
        {
            lstBlackList.Items.Add(txtBlackList.Text);
            txtBlackList.Text = "";
        }

        private void btnBlackRemove_Click(object sender, EventArgs e)
        {
            lstBlackList.Items.Remove(lstBlackList.SelectedItem);
        }

        private void txtStandardPfad_TextChanged(object sender, EventArgs e)
        {
            Pfadändern = true;
        }

        private void txtHTML_TextChanged(object sender, EventArgs e)
        {
            Pfadändern = true;
        }

        private void txtLogPfad_TextChanged(object sender, EventArgs e)
        {
            Pfadändern = true;
        }

        private void btnExplorerStandard_Click(object sender, EventArgs e)
        {
            txtStandardPfad.Text = AuswahlOrdner(txtStandardPfad.Text.Replace('/', Path.DirectorySeparatorChar)).Replace(Path.DirectorySeparatorChar, '/');
        }

        private void btnExplorerLog_Click(object sender, EventArgs e)
        {
            txtLogPfad.Text = AuswahlOrdner(txtLogPfad.Text.Replace('/', Path.DirectorySeparatorChar)).Replace(Path.DirectorySeparatorChar, '/');
        }

        private void btnExplorerHTML_Click(object sender, EventArgs e)
        {
            txtHTML.Text = AuswahlOrdner(txtHTML.Text.Replace('/', Path.DirectorySeparatorChar)).Replace(Path.DirectorySeparatorChar, '/');
        }

        private String AuswahlOrdner(String Pfad) {
            String Ergebnis = "";

            fBDOrdnerAuswahl.SelectedPath=Pfad;
            DialogResult result = fBDOrdnerAuswahl.ShowDialog();
            if (result == DialogResult.OK)
            {
                Ergebnis = fBDOrdnerAuswahl.SelectedPath;
            }
            else
            {
                Ergebnis = Pfad;
            }

            return Ergebnis;
        }
    }
}
