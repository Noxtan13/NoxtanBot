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
    public partial class PlattFormNachrichtenFenster : Form
    {
        public PlattFormNachrichtenFenster()
        {
            InitializeComponent();
        }

        private void PlattFormNachrichtenFenster_Load(object sender, EventArgs e)
        {
            chkPlattformUse.Checked = SettingsGroup.Instance.bPlattformMessageUse;
            txtPlattformKommand.Text = SettingsGroup.Instance.sPlattformMessageCommand;
            txtAnswer.Text = SettingsGroup.Instance.sPlattformMessageText;
        }

        private void btnVariable_Click(object sender, EventArgs e)
        {
            txtAnswer.Text += "°" + cmbVariable.Text;
        }

        private void PlattFormNachrichtenFenster_FormClosing(object sender, FormClosingEventArgs e)
        {
            SettingsGroup.Instance.bPlattformMessageUse = chkPlattformUse.Checked;
            SettingsGroup.Instance.sPlattformMessageText = txtAnswer.Text;
            SettingsGroup.Instance.sPlattformMessageCommand = txtPlattformKommand.Text;

            SettingsGroup.Instance.Save();
        }

        private void txtAnswer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SettingsGroup.Instance.bPlattformMessageUse = chkPlattformUse.Checked;
            SettingsGroup.Instance.sPlattformMessageText = txtAnswer.Text;
            SettingsGroup.Instance.sPlattformMessageCommand = txtPlattformKommand.Text;

            SettingsGroup.Instance.Save();
        }
    }
}
