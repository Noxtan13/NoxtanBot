using System;
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

        private void AllgEinstellungen_Load(object sender, EventArgs e)
        {
            
            chkAutoDiscord.Checked = SettingsGroup.Instance.SDiscordAutoStart;
            chkAutoTwitch.Checked = SettingsGroup.Instance.STwitchAutoStart;
            chkTwitchAutoBan.Checked = SettingsGroup.Instance.SAutoBan;
            chkTwitchAutoMessage.Checked = SettingsGroup.Instance.STwitchAutoMessage;

            chkAutoBotBannUse.Checked = SettingsGroup.Instance.STwitchAutoBotBann;
            grpAutoBotBann.Enabled = SettingsGroup.Instance.STwitchAutoBotBann;
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

            SettingsGroup.Instance.Save();

            Close();
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
            grpAutoBotBann.Enabled = chkAutoBotBannUse.Checked;
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
    }
}
