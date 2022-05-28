using AntonBot.PlatformAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace AntonBot.Fenster
{
    public partial class DiscordChannelAuswahl : Form
    {
        private List<DiscordGilde> DiscordListe;
        public System.Collections.Specialized.StringCollection Channels = new System.Collections.Specialized.StringCollection();
        public DiscordChannelAuswahl()
        {
            InitializeComponent();
        }

        private void DiscordChannelAuswahl_Load(object sender, EventArgs e)
        {
            String Path = Application.StartupPath + System.IO.Path.DirectorySeparatorChar + "DiscordServer.json";

            if (File.Exists(Path))
            {
                String InhaltJSON = File.ReadAllText(Path);
                try
                {
                    DiscordListe = JsonConvert.DeserializeObject<List<DiscordGilde>>(InhaltJSON);
                }
                catch (Exception Fehler)
                {
                    MessageBox.Show("Die Discord-Liste beinhaltet nicht die Einstellungen oder ist beschädigt \n Weitere Informationen: \n\n" + Fehler.InnerException.ToString(), "Fehler beim Einlesen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DiscordListe = new List<DiscordGilde>();
                }
            }
            else
            {
                MessageBox.Show("Es existiert keine DiscordServer.json. Diese Datei wird erzeugt, wenn sich der Bot an Discord anmeldet oder die Discord-Einstellungen aufgerufen werden.", "Keine Discord-Server", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DiscordListe = new List<DiscordGilde>();
            }

            foreach (var server in DiscordListe)
            {
                Lst_Server.Items.Add(server.Name);
            }

            if (Channels == null)
            {
                Channels = new System.Collections.Specialized.StringCollection();
            }

        }

        private void btnAuswahl_Click(object sender, EventArgs e)
        {
            Channels.Clear();
            foreach (var server in DiscordListe)
            {
                foreach (var channel in server.Channels)
                {
                    if (chkl_Channels.CheckedItems.Contains(channel.Name))
                    {
                        Channels.Add(channel.ID.ToString());
                    }
                }
            }

            this.Close();
        }

        private void btn_Abbruch_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Lst_Server_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkl_Channels.Items.Clear();
            foreach (var server in DiscordListe)
            {
                if (Lst_Server.SelectedItem != null && Lst_Server.SelectedItem.Equals(server.Name))
                {
                    foreach (var channel in server.Channels)
                    {
                        chkl_Channels.Items.Add(channel.Name);

                        //Prüfung, ob die ID, die gleiche ist, wie schon abgespeichert

                        foreach (var ID in Channels)
                        {
                            if (Convert.ToUInt64(ID) == channel.ID)
                            {
                                chkl_Channels.SetItemChecked(chkl_Channels.Items.Count - 1, true);
                            }
                        }
                    }
                }
            }
        }

        private void btnLöschen_Click(object sender, EventArgs e)
        {
            Channels = new System.Collections.Specialized.StringCollection();
            for (int i = 0; i < chkl_Channels.Items.Count; i++)
            {
                chkl_Channels.SetItemChecked(i, false);
            }
        }

        private void btnIDAnzeige_Click(object sender, EventArgs e)
        {
            string Text = "";

            foreach (var item in Channels)
            {
                Text = Text + item + Environment.NewLine;
            }

            MessageBox.Show(Text);
        }
    }
}
