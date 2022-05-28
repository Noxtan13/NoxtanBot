using AntonBot.PlatformAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace AntonBot
{
    public partial class Befehl_Editor : Form
    {
        private List<Befehl> lBefehlListe = new List<Befehl>();
        private List<Zeit_Befehl> lZeitBefehlListe = new List<Zeit_Befehl>();
        private List<Befehl> lTwitchBefehlListe = new List<Befehl>();
        private List<List_Befehl> lList_BefehlListe = new List<List_Befehl>();
        private List_Befehl lList_Befehl;
        private bool bupdate = false;
        private int iAusgewählterEintrag = 0;
        private List<RandomBefehl> lRandomBefehls = new List<RandomBefehl>();
        private byte byteIndex = 1;
        //1 ist der Index für die Bot-Kommandos
        //2 für die Zeit-Kommandos
        public Befehl_Editor()
        {
            InitializeComponent();
        }
        private void Befehl_Editor_Load(object sender, EventArgs e)
        {
            String Path = SettingsGroup.Instance.StandardPfad + "Befehl.json";
            String InhaltJSON;

            if (File.Exists(Path))
            {
                //FileStream stream = File.OpenRead(Path);
                InhaltJSON = File.ReadAllText(Path);
                try
                {
                    lBefehlListe = JsonConvert.DeserializeObject<List<Befehl>>(InhaltJSON);
                }
                catch (Exception Fehler)
                {
                    MessageBox.Show("Die Befehlsliste beinhaltet nicht die erwarteten Einstellungen oder ist beschädigt. Eine leere Liste wird verwendet und die Beschädigte in Befehl.json1 umbenannt. \n Weitere Informationen: \n\n" + Fehler.InnerException.ToString(), "Beschädigte Datei", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    File.WriteAllText(Path + "1", InhaltJSON);
                    lBefehlListe = new List<Befehl>();
                }
            }

            Path = SettingsGroup.Instance.StandardPfad + "Zeit-Befehl.json";

            if (File.Exists(Path))
            {
                //FileStream stream = File.OpenRead(Path);
                InhaltJSON = File.ReadAllText(Path);
                try
                {
                    lZeitBefehlListe = JsonConvert.DeserializeObject<List<Zeit_Befehl>>(InhaltJSON);
                }
                catch (Exception Fehler)
                {
                    MessageBox.Show("Die Zeit-Liste beinhaltet nicht die erwarteten Einstellungen oder ist beschädigt. Eine leere Liste wird verwendet und die Beschädigte in Zeit-Befehl.json1 umbenannt. \n Weitere Informationen: \n\n" + Fehler.InnerException.ToString(), "Beschädigte Datei", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    File.WriteAllText(Path + "1", InhaltJSON);
                    lBefehlListe = new List<Befehl>();
                }
            }

            Path = SettingsGroup.Instance.StandardPfad + "Befehl-Twitch.json";

            if (File.Exists(Path))
            {
                //FileStream stream = File.OpenRead(Path);
                InhaltJSON = File.ReadAllText(Path);
                try
                {
                    lTwitchBefehlListe = JsonConvert.DeserializeObject<List<Befehl>>(InhaltJSON);
                }
                catch (Exception Fehler)
                {
                    MessageBox.Show("Die Twitch-Befehlsliste beinhaltet nicht die erwarteten Einstellungen oder ist beschädigt. Eine leere Liste wird verwendet und die Beschädigte in Befehl-Twitch.json1 umbenannt. \n Weitere Informationen: \n\n" + Fehler.InnerException.ToString(), "Beschädigte Datei", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    File.WriteAllText(Path + "1", InhaltJSON);
                    lBefehlListe = new List<Befehl>();
                }
            }

            Path = SettingsGroup.Instance.StandardPfad + "List-Befehl.json";

            if (File.Exists(Path))
            {
                InhaltJSON = File.ReadAllText(Path);
                try
                {
                    lList_BefehlListe = JsonConvert.DeserializeObject<List<List_Befehl>>(InhaltJSON);
                }
                catch (Exception Fehler)
                {
                    MessageBox.Show("Die Liste der Listenbefehle beinhaltet nicht die erwarteten Einstellungen oder ist beschädigt. Eine leere Liste wird verwendet und die Beschädigte in List-Befehl.json1 umbenannt. \n Weitere Informationen: \n\n" + Fehler.InnerException.ToString(), "Beschädigte Datei", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    File.WriteAllText(Path + "1", InhaltJSON);
                    lBefehlListe = new List<Befehl>();
                }
            }
            BefehlListeUpdate();
        }

        private void BefehlListeUpdate()
        {
            BefehlList.Items.Clear();
            foreach (Befehl item in lBefehlListe)
            {
                BefehlList.Items.Add(item.Kommando);
            }

            ZeitBefehlList.Items.Clear();
            foreach (Zeit_Befehl item in lZeitBefehlListe)
            {
                ZeitBefehlList.Items.Add(item.Kommando);
            }

            TwitchList.Items.Clear();
            foreach (Befehl item in lTwitchBefehlListe)
            {
                TwitchList.Items.Add(item.Kommando);
            }

            ListBefehlList.Items.Clear();
            foreach (List_Befehl item in lList_BefehlListe)
            {
                ListBefehlList.Items.Add(item.Kommando);
            }
        }

        private void BtnNeu_Click(object sender, EventArgs e)
        {
            bupdate = false;
            Wertezurücksetzen();
            GroupAnlegen.Enabled = true;
        }

        private void Wertezurücksetzen()
        {

            GroupAnlegen.Enabled = true;
            txtCommand.Text = "";
            txtAnswer.Text = "";
            txtAlternativAnswer.Text = "";
            txtAlternativAnswer.Enabled = false;
            NUDIntervall.Value = 10;
            cmbVariable.Text = "";

            lRandomBefehls.Clear();
            btnZufallAntwort.Enabled = false;

            chkDiscord.Checked = false;
            chkTwitch.Checked = false;
            chkYouTube.Checked = false;

            lList_Befehl = new List_Befehl();

            tabAntwort.SelectedIndex = 0;
            //0 entspricht der ersten Seite
            GroupAnlegen.Enabled = false;
        }

        private void BtnSpeichern_Click(object sender, EventArgs e)
        {
            Befehl bBefehl = new Befehl();


            if (Validierung())
            {
                bBefehl = Befehlwerte(bBefehl);
                if (bupdate)
                {
                    switch (byteIndex)
                    {
                        case 1:
                            lBefehlListe.RemoveAt(iAusgewählterEintrag);
                            lBefehlListe.Insert(iAusgewählterEintrag, bBefehl);
                            break;
                        case 2:
                            Zeit_Befehl NeuerBefehl = new Zeit_Befehl();

                            NeuerBefehl = Befehlwerte(NeuerBefehl);
                            lZeitBefehlListe.RemoveAt(iAusgewählterEintrag);
                            lZeitBefehlListe.Insert(iAusgewählterEintrag, NeuerBefehl);
                            break;
                        case 3:
                            lTwitchBefehlListe.RemoveAt(iAusgewählterEintrag);
                            lTwitchBefehlListe.Insert(iAusgewählterEintrag, bBefehl);
                            break;
                        case 4:
                            break;
                        case 5:
                            lList_Befehl.Kommando = txtCommand.Text;
                            lList_Befehl.AusgabeListe = txtAnswer.Text;

                            lList_BefehlListe.RemoveAt(iAusgewählterEintrag);
                            lList_BefehlListe.Insert(iAusgewählterEintrag, lList_Befehl);
                            break;
                    }
                    iAusgewählterEintrag = 0;
                    bupdate = false;
                }
                else
                {
                    switch (byteIndex)
                    {
                        case 1:
                            lBefehlListe.Add(bBefehl);
                            break;
                        case 2:
                            Zeit_Befehl NeuerBefehl = new Zeit_Befehl();

                            NeuerBefehl = Befehlwerte(NeuerBefehl);

                            lZeitBefehlListe.Add(NeuerBefehl);
                            break;
                        case 3:
                            lTwitchBefehlListe.Add(bBefehl);
                            break;
                        case 4:
                            break;
                        case 5:
                            lList_Befehl.Kommando = txtCommand.Text;
                            lList_Befehl.AusgabeListe = txtAnswer.Text;

                            lList_BefehlListe.Add(lList_Befehl);
                            break;
                    }
                }
                Wertezurücksetzen();
            }

            BefehlListeUpdate();
        }

        private bool Validierung()
        {
            bool Ergebnis = false;

            if (txtCommand.Text != "")
            {
                switch (byteIndex)
                {
                    case 1:
                        if (PrüfungOptionalerTeil() && PrüfungVariablerTeil())
                        {
                            Ergebnis = true;
                        }
                        else
                        {
                            Ergebnis = false;
                        }
                        break;
                    case 2:
                        if (PrüfungVariablerTeil() && PrüfungTimer())
                        {
                            Ergebnis = true;
                        }
                        else
                        {
                            Ergebnis = false;
                        }
                        break;
                    case 3:
                        if (PrüfungOptionalerTeil() && PrüfungVariablerTeil() && PrüfungFollow())
                        {
                            Ergebnis = true;
                        }
                        else
                        {
                            Ergebnis = false;
                        }
                        break;
                    case 4:
                        //Hier erfolgt aktuell keine Prüfung
                        Ergebnis = true;
                        break;
                    case 5:
                        //Hier erfolgt aktuell keine Prüfung
                        Ergebnis = true;
                        break;
                }
            }
            else
            {
                MessageBox.Show("Bitte einen Kommandonamen eingeben", "Fehlender Command", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Ergebnis;
        }

        private bool PrüfungOptionalerTeil()
        {
            if (txtAnswer.Text.Contains("°OptionalerTeil") && txtAlternativAnswer.Text.Equals(""))
            {
                MessageBox.Show("Es wird bei der Variable 'OptionalerTeil' eine Alternative Antwort erwartet. Diese ist aber leer.", "Es fehlen Werte", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAlternativAnswer.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool PrüfungVariablerTeil()
        {
            if (txtAnswer.Text.Contains("°VariablerTeil") ^ txtAlternativAnswer.Text.Contains("°VariablerTeil") && lRandomBefehls.Count.Equals(0))
            {
                MessageBox.Show("Es wird bei der Variable 'VariablerTeil' mind. eine Antwort erwartet. Davon gibt es keine.", "Es fehlen Werte", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool PrüfungTimer()
        {
            if (NUDIntervall.Value < 300)
            {
                if (MessageBox.Show("Der Timer liegt unter 5 Minuten (300 sek)." + Environment.NewLine + "Es werden möglicherweise zu viele Nachrichten geschrieben (Spam)" + Environment.NewLine + Environment.NewLine + "Möchtest du diesen Wert behalten?", "Achtung", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
        private bool PrüfungFollow()
        {
            //Die Prüfung prüft hier alle 3 "Follow"-Variablen gleichermaßen
            if (txtAlternativAnswer.Text.Equals("") && txtAnswer.Text.Contains("°Follow"))
            {
                MessageBox.Show("Es wird bei der Variable 'FollowAt', 'FollowSince' und/oder 'Follownatame' eine Alternative Antwort erwartet. Diese ist aber leer.", "Es fehlen Werte", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAlternativAnswer.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private Befehl Befehlwerte(Befehl befehl)
        {
            befehl.Kommando = txtCommand.Text;
            befehl.Antwort = txtAnswer.Text;
            befehl.ErsatzAntwort = txtAlternativAnswer.Text;
            if (befehl.ErsatzAntwort.Equals(""))
            {
                befehl.HatErsatzText = false;
            }
            else
            {
                befehl.HatErsatzText = true;
            }


            befehl.HatZufallAntowort = btnZufallAntwort.Enabled;
            befehl.ZufallAntwort.Clear();
            befehl.ZufallAntwort.AddRange(lRandomBefehls);
            return befehl;
        }

        private Zeit_Befehl Befehlwerte(Zeit_Befehl befehl)
        {
            befehl.Kommando = txtCommand.Text;
            befehl.Antwort = txtAnswer.Text;
            befehl.HatErsatzText = txtAlternativAnswer.Enabled;
            befehl.ErsatzAntwort = txtAlternativAnswer.Text;

            befehl.HatZufallAntowort = btnZufallAntwort.Enabled;
            befehl.ZufallAntwort = lRandomBefehls;

            befehl.Zeitspanne = Decimal.ToInt32(NUDIntervall.Value);
            befehl.ZeitAnDiscord = chkDiscord.Checked;
            befehl.ZeitAnTwitch = chkTwitch.Checked;
            befehl.ZeitAnYouTube = chkYouTube.Checked;
            return befehl;
        }

        private void TxtCommand_Click(object sender, EventArgs e)
        {
            if (txtCommand.Text.Equals("Kommando"))
            {
                txtCommand.Text = "";
            }
        }
        private void TxtAnswer_Click(object sender, EventArgs e)
        {
            if (txtAnswer.Text.Equals("Antwort"))
            {
                txtAnswer.Text = "";
            }
        }

        private void JSONSpeichern_Click(object sender, EventArgs e)
        {
            String Path = SettingsGroup.Instance.StandardPfad + "Befehl.json";
            String InhaltJSON = "";

            InhaltJSON += JsonConvert.SerializeObject(lBefehlListe, Formatting.Indented);

            File.WriteAllText(Path, InhaltJSON);

            Path = SettingsGroup.Instance.StandardPfad + "Zeit-Befehl.json";
            InhaltJSON = "";
            InhaltJSON += JsonConvert.SerializeObject(lZeitBefehlListe, Formatting.Indented);

            File.WriteAllText(Path, InhaltJSON);

            Path = SettingsGroup.Instance.StandardPfad + "Befehl-Twitch.json";
            InhaltJSON = "";
            InhaltJSON += JsonConvert.SerializeObject(lTwitchBefehlListe, Formatting.Indented);

            File.WriteAllText(Path, InhaltJSON);

            Path = SettingsGroup.Instance.StandardPfad + "List-Befehl.json";
            InhaltJSON = "";
            InhaltJSON += JsonConvert.SerializeObject(lList_BefehlListe, Formatting.Indented);

            File.WriteAllText(Path, InhaltJSON);
        }

        private void BefehlList_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in lBefehlListe)
            {
                if (item.Kommando.Equals(BefehlList.SelectedItem))
                {
                    bupdate = true;
                    GroupAnlegen.Enabled = true;
                    txtCommand.Text = item.Kommando;
                    txtAnswer.Text = item.Antwort;
                    txtAlternativAnswer.Enabled = item.HatErsatzText;
                    txtAlternativAnswer.Text = item.ErsatzAntwort;

                    btnZufallAntwort.Enabled = item.HatZufallAntowort;
                    lRandomBefehls = item.ZufallAntwort;

                    iAusgewählterEintrag = BefehlList.SelectedIndex;

                    lblVerwendung.Text = "Anzahl an Verwendung: " + item.Anzahl;

                    GroupAnlegen.Enabled = true;
                }
            }


        }

        private void BtnVariable_Click(object sender, EventArgs e)
        {
            if (cmbVariable.Text.Equals("VariablerTeil"))
            {
                using (EingabeZufallVariable Fenster = new EingabeZufallVariable())
                {
                    Fenster.randomBefehls = lRandomBefehls;
                    DialogResult dr = Fenster.ShowDialog();

                    if (dr == DialogResult.OK)
                    {
                        lRandomBefehls = Fenster.randomBefehls;
                        btnZufallAntwort.Enabled = true;
                    }

                }
            }
            switch (tabAntwort.SelectedIndex)
            {
                //Prüfung, ob die Variable in txtAlternativAnswer eingefügt werden soll. (Ist an der Stelle nicht zulässig)
                case 0:
                    if (cmbVariable.Text.Equals("OptionalerTeil") || cmbVariable.Text.Equals("FollowAt") || cmbVariable.Text.Equals("Followsince"))
                    {
                        txtAlternativAnswer.Enabled = true;
                    }
                    txtAnswer.Text += "°" + cmbVariable.Text;
                    break;
                case 1:
                    if (cmbVariable.Text.Equals("OptionalerTeil") || cmbVariable.Text.Equals("FollowAt") || cmbVariable.Text.Equals("Followsince"))
                    {
                        MessageBox.Show("Die Variable kann in einer alternativen Antwort nicht verwendet werden.", "Ungültige Auwahl", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        txtAlternativAnswer.Text += "°" + cmbVariable.Text;
                    }
                    break;
            }


        }

        private void Befehl_Editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            String Path = SettingsGroup.Instance.StandardPfad + "Befehl.json";
            String InhaltJSON = "";

            InhaltJSON += JsonConvert.SerializeObject(lBefehlListe);

            File.WriteAllText(Path, InhaltJSON);

            Path = SettingsGroup.Instance.StandardPfad + "Zeit-Befehl.json";
            InhaltJSON = "";
            InhaltJSON += JsonConvert.SerializeObject(lZeitBefehlListe);

            File.WriteAllText(Path, InhaltJSON);

            Path = SettingsGroup.Instance.StandardPfad + "Befehl-Twitch.json";
            InhaltJSON = "";
            InhaltJSON += JsonConvert.SerializeObject(lTwitchBefehlListe);

            File.WriteAllText(Path, InhaltJSON);

            Path = SettingsGroup.Instance.StandardPfad + "List-Befehl.json";
            InhaltJSON = "";
            InhaltJSON += JsonConvert.SerializeObject(lList_BefehlListe);

            File.WriteAllText(Path, InhaltJSON);

            this.DialogResult = DialogResult.OK;
        }

        private void BtnStandard_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Es werden alle für alle Befehle die Objekte erzeugt, falls einige Befehle keinen Objektverweis haben.", "ACHTUNG", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                foreach (Befehl item in lBefehlListe)
                {
                    if (item.Antwort == null)
                    {
                        item.Antwort = "";
                    }
                    if (item.ErsatzAntwort == null)
                    {
                        item.ErsatzAntwort = "";
                    }
                    if (item.Kommando == null)
                    {
                        item.Kommando = "";
                    }
                    if (item.ZufallAntwort == null)
                    {
                        item.ZufallAntwort = new List<RandomBefehl>();
                    }
                }
                foreach (Zeit_Befehl item in lZeitBefehlListe)
                {
                    if (item.Antwort == null)
                    {
                        item.Antwort = "";
                    }
                    if (item.ErsatzAntwort == null)
                    {
                        item.ErsatzAntwort = "";
                    }
                    if (item.Kommando == null)
                    {
                        item.Kommando = "";
                    }
                    if (item.ZufallAntwort == null)
                    {
                        item.ZufallAntwort = new List<RandomBefehl>();
                    }
                }
                foreach (Befehl item in lTwitchBefehlListe)
                {
                    if (item.Antwort == null)
                    {
                        item.Antwort = "";
                    }
                    if (item.ErsatzAntwort == null)
                    {
                        item.ErsatzAntwort = "";
                    }
                    if (item.Kommando == null)
                    {
                        item.Kommando = "";
                    }
                    if (item.ZufallAntwort == null)
                    {
                        item.ZufallAntwort = new List<RandomBefehl>();
                    }
                }

                foreach (List_Befehl item in lList_BefehlListe)
                {
                    //Platzhalter noch füllen
                }
            }


        }

        private void BtnLöschen_Click(object sender, EventArgs e)
        {
            //Unterscheidung, ob der zu löschende Befehl neu ist oder schon in der Liste

            int x = 0;
            int Position = 0;
            bool Treffer = false;
            //Bei einem schon vorhanden Befehl, muss dieser erstmal in der Liste gesucht und dann gelöscht werden

            switch (byteIndex)
            {
                case 1:
                    foreach (Befehl item in lBefehlListe)
                    {
                        if (item.Kommando.Equals(txtCommand.Text))
                        {
                            Position = x;
                            Treffer = true;
                        }
                        x += 1;
                    }

                    if (Treffer)
                    {
                        lBefehlListe.RemoveAt(Position);
                    }
                    break;
                case 2:
                    foreach (Zeit_Befehl item in lZeitBefehlListe)
                    {
                        if (item.Kommando.Equals(txtCommand.Text))
                        {
                            Position = x;
                            Treffer = true;
                        }
                        x += 1;
                    }

                    if (Treffer)
                    {
                        lZeitBefehlListe.RemoveAt(Position);
                    }
                    break;
                case 3:
                    foreach (Befehl item in lTwitchBefehlListe)
                    {
                        if (item.Kommando.Equals(txtCommand.Text))
                        {
                            Position = x;
                            Treffer = true;
                        }
                        x += 1;
                    }

                    if (Treffer)
                    {
                        lTwitchBefehlListe.RemoveAt(Position);
                    }
                    break;
                case 4:
                    //Platzhalter für Discord
                    break;
                case 5:
                    foreach (List_Befehl item in lList_BefehlListe)
                    {
                        if (item.Kommando.Equals(txtCommand.Text))
                        {
                            Position = x;
                            Treffer = true;
                        }
                        x += 1;
                    }

                    if (Treffer)
                    {
                        lList_BefehlListe.RemoveAt(Position);
                    }
                    break;
            }


            //Bei einem neuen Befehl, einfach die Werte rauslöschen
            Wertezurücksetzen();

            lList_Befehl = new List_Befehl();

            BefehlListeUpdate();
        }

        private void BefehlTab_Selected(object sender, TabControlEventArgs e)
        {
            //Erst die Werte auf Standard zurücksetzen

            txtCommand.Enabled = true;
            txtAnswer.Enabled = true;

            btnLöschen.Enabled = true;
            btnNeu.Enabled = true;
            btnSpeichern.Enabled = true;
            btnVariable.Enabled = true;
            btnListBefehle.Enabled = false;

            txtCommand.Text = "Kommando";
            txtAnswer.Text = "";
            txtAlternativAnswer.Text = "";
            txtAlternativAnswer.Enabled = false;
            NUDIntervall.Value = 10;
            cmbVariable.Text = "";
            btnZufallAntwort.Enabled = false;
            GroupAnlegen.Enabled = false;

            chkDiscord.Checked = false;
            chkTwitch.Checked = false;
            chkYouTube.Checked = false;

            //Dann die Steuerelemente entsprechend aktivieren oder deaktivieren, wenn diese nicht schon deaktiviert wurden (z.B. txtAlternativAnswer)
            switch (e.TabPage.Text)
            {
                case "Kommandos":
                    byteIndex = 1;
                    NUDIntervall.Enabled = false;
                    btnVariable.Enabled = true;
                    cmbVariable.Enabled = true;
                    chkDiscord.Enabled = false;
                    chkTwitch.Enabled = false;
                    chkYouTube.Enabled = false;
                    break;
                case "Zeit-Kommandos":
                    byteIndex = 2;
                    NUDIntervall.Enabled = true;
                    btnVariable.Enabled = false;
                    cmbVariable.Enabled = false;
                    chkDiscord.Enabled = true;
                    chkTwitch.Enabled = true;
                    chkYouTube.Enabled = true;
                    break;
                case "Twitch-Kommandos":
                    byteIndex = 3;
                    NUDIntervall.Enabled = false;
                    btnVariable.Enabled = true;
                    cmbVariable.Enabled = true;
                    chkDiscord.Enabled = false;
                    chkTwitch.Enabled = false;
                    chkYouTube.Enabled = false;
                    break;
                case "Discord-Kommandos":
                    //Platzhalter, daher alles auf False setzen
                    byteIndex = 4;
                    GroupAnlegen.Enabled = false;
                    break;
                case "Listen-Kommandos":
                    byteIndex = 5;
                    txtAnswer.Enabled = false;
                    btnZufallAntwort.Enabled = false;

                    btnListBefehle.Enabled = true;
                    break;
            }


            UpdatecmbVariablen(byteIndex);
        }

        private void UpdatecmbVariablen(int Index)
        {
            cmbVariable.Items.Clear();
            switch (Index)
            {
                case 1:
                    cmbVariable.Items.Add("OptionalerTeil");
                    cmbVariable.Items.Add("VariablerTeil");
                    cmbVariable.Items.Add("Name");
                    cmbVariable.Items.Add("Zähler");
                    cmbVariable.Items.Add("KommandosBefehlsKette");
                    break;
                case 2:
                    cmbVariable.Items.Add("VariablerTeil");
                    cmbVariable.Items.Add("Name");
                    cmbVariable.Items.Add("KommandosBefehlsKette");
                    break;
                case 3:
                    cmbVariable.Items.Add("OptionalerTeil");
                    cmbVariable.Items.Add("VariablerTeil");
                    cmbVariable.Items.Add("Name");
                    cmbVariable.Items.Add("Zähler");
                    cmbVariable.Items.Add("FollowAt");
                    cmbVariable.Items.Add("Followatname");
                    cmbVariable.Items.Add("FollowSince");
                    cmbVariable.Items.Add("KommandosBefehlsKette");
                    cmbVariable.Items.Add("TwitchBefehlsKette");
                    cmbVariable.Items.Add("TwitchAdminKette");
                    cmbVariable.Items.Add("RNDUser");
                    break;
                case 4:
                    //Platzhalter für Discord
                    break;
                case 5:
                    cmbVariable.Items.Add("List-Items");
                    break;
            }

        }

        private void ZeitBefehlList_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (Zeit_Befehl item in lZeitBefehlListe)
            {
                if (item.Kommando.Equals(ZeitBefehlList.SelectedItem))
                {
                    bupdate = true;
                    GroupAnlegen.Enabled = true;
                    txtCommand.Text = item.Kommando;
                    txtAnswer.Text = item.Antwort;
                    txtAlternativAnswer.Enabled = item.HatErsatzText;
                    txtAlternativAnswer.Text = item.ErsatzAntwort;
                    NUDIntervall.Value = item.Zeitspanne;

                    chkDiscord.Checked = item.ZeitAnDiscord;
                    chkTwitch.Checked = item.ZeitAnTwitch;
                    chkYouTube.Checked = item.ZeitAnYouTube;

                    btnZufallAntwort.Enabled = item.HatZufallAntowort;
                    lRandomBefehls = item.ZufallAntwort;

                    iAusgewählterEintrag = ZeitBefehlList.SelectedIndex;

                    lblVerwendung.Text = "Anzahl an Verwendung: " + item.Anzahl;

                    GroupAnlegen.Enabled = true;
                }
            }
        }

        private void BtnZufallAntwort_Click(object sender, EventArgs e)
        {
            using (EingabeZufallVariable Fenster = new EingabeZufallVariable())
            {
                Fenster.randomBefehls = lRandomBefehls;
                DialogResult dr = Fenster.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    lRandomBefehls = Fenster.randomBefehls;
                    btnZufallAntwort.Enabled = true;
                }

            }
        }

        private void TwitchList_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (var item in lTwitchBefehlListe)
            {
                if (item.Kommando.Equals(TwitchList.SelectedItem))
                {
                    bupdate = true;
                    GroupAnlegen.Enabled = true;
                    txtCommand.Text = item.Kommando;
                    txtAnswer.Text = item.Antwort;
                    txtAlternativAnswer.Enabled = item.HatErsatzText;
                    txtAlternativAnswer.Text = item.ErsatzAntwort;

                    btnZufallAntwort.Enabled = item.HatZufallAntowort;
                    lRandomBefehls = item.ZufallAntwort;

                    iAusgewählterEintrag = TwitchList.SelectedIndex;

                    lblVerwendung.Text = "Anzahl an Verwendung: " + item.Anzahl;

                    GroupAnlegen.Enabled = true;
                }
            }
        }

        private void ListBefehlList_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (List_Befehl item in lList_BefehlListe)
            {
                if (item.Kommando.Equals(ListBefehlList.SelectedItem))
                {
                    bupdate = true;
                    GroupAnlegen.Enabled = true;
                    txtCommand.Text = item.Kommando;
                    txtAnswer.Text = item.AusgabeListe;
                    lList_Befehl = item;

                    lblVerwendung.Text = "Anzahl an Verwendung: 0";

                    GroupAnlegen.Enabled = true;
                }
            }
        }

        private void btnListBefehle_Click(object sender, EventArgs e)
        {
            lList_Befehl.Kommando = txtCommand.Text;
            lList_Befehl.AusgabeListe = txtAnswer.Text;
            using (Fenster.EingabeListBefehl Fenster = new Fenster.EingabeListBefehl())
            {
                Fenster.List_Befehll = lList_Befehl;
                DialogResult dr = Fenster.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    lList_Befehl = Fenster.List_Befehll;
                    txtCommand.Text = lList_Befehl.Kommando;
                    txtAnswer.Text = lList_Befehl.AusgabeListe;
                }

            }
        }

        private void btnVariableHilfe_Click(object sender, EventArgs e)
        {
            Assembly _Assembly = Assembly.GetExecutingAssembly();
            Stream str = _Assembly.GetManifestResourceStream("AntonBot.Fenster.HilfeSeiten.VariableHilfe.html");
            StreamReader rd = new StreamReader(str);

            string Path = Application.StartupPath + System.IO.Path.DirectorySeparatorChar + "VariableHilfe.html";
            File.WriteAllText(Path, rd.ReadToEnd());



            var test = _Assembly.GetManifestResourceNames();
            System.Diagnostics.Process.Start(Path);
        }

        private void txtAnswer_TextChanged(object sender, EventArgs e)
        {
            if (txtAnswer.Text.Contains("°OptionalerTeil"))
            {
                txtAlternativAnswer.Enabled = true;
            }
            else
            {
                txtAlternativAnswer.Enabled = true;
            }
        }
    }
}
