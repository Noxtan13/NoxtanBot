using AntonBot.Fenster;
using AntonBot.PlatformAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AntonBot
{

    public partial class MainWindow : Form
    {

        //Bot_Verwalter Verwalter = new Bot_Verwalter();

        private DiscordFunction Discord = new DiscordFunction();
        private TwitchFunction Twitch = new TwitchFunction();

        //YouTube_Functions YouTube = new YouTube_Functions();
        //PlatformAPI.Google_Function Google = new PlatformAPI.Google_Function();

        private Telegramm_Function Telegramm = new Telegramm_Function();
        private String PathBefehl = Application.StartupPath + Path.DirectorySeparatorChar + "Befehl.json";
        private String PathZeit = Application.StartupPath + Path.DirectorySeparatorChar + "Zeit-Befehl.json";
        private String PathTwitch = Application.StartupPath + Path.DirectorySeparatorChar + "Befehl-Twitch.json";
        private String PathListBefehl = Application.StartupPath + Path.DirectorySeparatorChar + "List-Befehl.json";
        private bool FirstStart = true;
        private int EventTimer;
        private int WaitForOnline = 20;
        private int RestartTimer = 30;
        private string KonsolenLogPath = Application.StartupPath + Path.DirectorySeparatorChar + "KonsolenLogAusgabe.json";
        private List<KonsolenAusgabe> KonsolenAusgabeJSON = new List<KonsolenAusgabe>();
        public MainWindow()
        {
            SettingsGroup.Instance.LoadSettings();
            InitializeComponent();

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            //SettingsGroup.Instance.LoadSettings();

            EventTimer = SettingsGroup.Instance.SEventTimer;
            DiscordStatusStrip.Text = "Discord: " + Discord.getClientStatus();
            TwitchStatusStrip.Text = "Twitch: Disconnected - Online:" + SettingsGroup.Instance.TsOnline.ToString();

            PathBefehl = SettingsGroup.Instance.StandardPfad + "Befehl.json";
            PathZeit = SettingsGroup.Instance.StandardPfad + "Zeit-Befehl.json";
            PathTwitch = SettingsGroup.Instance.StandardPfad + "Befehl-Twitch.json";
            PathListBefehl = SettingsGroup.Instance.StandardPfad + "List-Befehl.json";

            LogWriter.LogPath = SettingsGroup.Instance.LogPfad + "Log.txt";
            KonsolenLogPath = SettingsGroup.Instance.LogPfad + "KonsolenLogAusgabe.json";
        }

        private async void autostart()
        {
            if (SettingsGroup.Instance.SDiscordAutoStart)
            {
                if (!Discord.getActive())
                {
                    await Discord.RunBotAsync();
                    DiscordStop.Enabled = true;
                    DiscordStart.Enabled = false;
                }
            }
            if (SettingsGroup.Instance.STwitchAutoStart)
            {
                if (!Twitch.getActive())
                {
                    Twitch.StartBot();
                    TwitchStop.Enabled = true;
                    TwitchStart.Enabled = false;
                    chkTwitchZeit.Checked = SettingsGroup.Instance.STwitchAutoMessage;
                }
            }
            LoadBefehle();
        }

        private async void DiscordStop_Click(object sender, EventArgs e)
        {
            await Discord.StopBotAsync();
            DiscordStart.Enabled = true;
            DiscordStop.Enabled = false;
        }

        private async void DiscordStart_Click(object sender, EventArgs e)
        {
            await Discord.RunBotAsync();
            DiscordStop.Enabled = true;
            DiscordStart.Enabled = false;
            LoadBefehle();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string DiscordStatus = Discord.getClientStatus();
            if (DiscordStatus == "LoggedOut" || DiscordStatus == "NULL")
            {
                //Wenn Discord sich nicht einloggen konnte
                DiscordStop.Enabled = false;
                DiscordStart.Enabled = true;
            }
            else
            {
                DiscordStop.Enabled = true;
                DiscordStart.Enabled = false;
            }
            DiscordStatusStrip.Text = "Discord: " + DiscordStatus;

            if (Twitch.GetClientStatus())
            {
                TwitchStatusStrip.Text = "Twitch: Connected - Online:" + SettingsGroup.Instance.TsOnline.ToString() + " - Spiel: " + Twitch.getCurrentGame();
                TwitchStop.Enabled = true;
                TwitchStart.Enabled = false;

                //Die erweiterten Time-Funktionen werden nur verwendet, wenn der Bot bei Twitch auch aktiv ist.

                //Die Verzögerte Nachricht in Twitch runterzählen. Bei 0 wird die Nachricht gesendet
                if (Twitch.getSleepBool())
                {
                    Twitch.decrementDelay();
                }

                //Timer für das Prüfen von neuen Clips
                EventTimer = EventTimer - 1;
                if (EventTimer == 0)
                {
                    Twitch.getNewClips();
                    EventTimer = SettingsGroup.Instance.SEventTimer;
                }
            }
            else
            {
                TwitchStatusStrip.Text = "Twitch: Disconnected - Online:" + SettingsGroup.Instance.TsOnline.ToString();
                TwitchStop.Enabled = false;
                TwitchStart.Enabled = true;
            }

            //Warten auf das Twitch-Online-Event. Erscheint es nach einer Zeit nicht, so wird der Online-Status zurückgesetzt
            WaitForOnline = WaitForOnline - 1;
            if (WaitForOnline == 0)
            {
                SettingsGroup.Instance.TsOnline = Twitch.IsChannelOnline();
            }

            if (Discord.getRestart() || Twitch.getRestart())
            {
                RestartTimer = RestartTimer - 1;
                if (RestartTimer == 0)
                {
                    RestartTimer = 30;
                    autostart();
                    AusgabeKonsole(new KonsolenAusgabe("Konsole", DateTime.Now.TimeOfDay, "Verbindungsaufbau wird erneut versucht...", 30));

                }
            }
            //Timer für die AutoNachrichten, der einzelnen Channels
            Discord.Zeitschritt(Discord);
            Twitch.Zeitschritt(Twitch);
        }

        private async void CheckSendToOtherChannel()
        {

            if (Twitch.IsOtherChannel())
            {
                PlatformAPI.OtherChannel otherChannel = Twitch.getSendOtherChannel();
                if (otherChannel.getNextPlattform().Equals("Discord") && Discord.getActive())
                {
                    //753593040731504751 ist die ID des Twitch-Spam-Chat
                    if (otherChannel.getMessage().Equals(""))
                    {
                        try
                        {
                            await Discord.SendMessage(otherChannel.getDiscordChannelID(), "leere Nachricht");
                        }
                        catch (Exception e)
                        {
                            AusgabeKonsole(new KonsolenAusgabe("Discord.SendMessage() vom Startfenster konnte nicht durchgeführt werden." + Environment.NewLine + "Nachricht: " + Environment.NewLine + "leere Nachricht" + Environment.NewLine + "Excpetion-Message: " + Environment.NewLine + e.Message + Environment.NewLine + "InnerException: " + Environment.NewLine + e.InnerException, DateTime.Now.TimeOfDay, "StartFenster"));
                        }

                    }
                    else if (otherChannel.getMessage().Length >= 1999)
                    {
                        try
                        {
                            await Discord.SendMessage(otherChannel.getDiscordChannelID(), otherChannel.getMessage().Substring(0, 1999));
                        }
                        catch (Exception e)
                        {
                            AusgabeKonsole(new KonsolenAusgabe("StartFenster", DateTime.Now.TimeOfDay, "Discord.SendMessage() vom Startfenster konnte nicht durchgeführt werden." + Environment.NewLine + "Nachricht: " + Environment.NewLine + otherChannel.getMessage().Substring(0, 1999) + Environment.NewLine + "Excpetion-Message: " + Environment.NewLine + e.Message + Environment.NewLine + "InnerException: " + Environment.NewLine + e.InnerException));
                        }

                    }
                    else
                    {
                        try
                        {
                            await Discord.SendMessage(otherChannel.getDiscordChannelID(), otherChannel.getMessage());
                        }
                        catch (Exception e)
                        {
                            AusgabeKonsole(new KonsolenAusgabe("StartFenster", DateTime.Now.TimeOfDay, "Discord.SendMessage() vom Startfenster konnte nicht durchgeführt werden." + Environment.NewLine + "Nachricht: " + Environment.NewLine + otherChannel.getMessage() + Environment.NewLine + "Excpetion-Message: " + Environment.NewLine + e.Message + Environment.NewLine + "InnerException: " + Environment.NewLine + e.InnerException));
                        }

                    }
                    Twitch.OtherChannelDone();
                }
                else
                {
                    if (otherChannel.getNextPlattform() == "")
                    {
                        AusgabeKonsole(new KonsolenAusgabe("TWITCH", DateTime.Now.TimeOfDay, "SendMessageToOtherChannel - ungültiger Channel"));
                    }
                    else
                    {
                        AusgabeKonsole(new KonsolenAusgabe("TWITCH", DateTime.Now.TimeOfDay, "SendMessageToOtherChannel - Plattform: " + otherChannel.getNextPlattform() + " ist nicht aktiv"));
                    }

                }

            }


            if (Discord.IsOtherChannel())
            {
                OtherChannel otherChannel = Discord.getSendOtherChannel();
                if (otherChannel.getNextPlattform().Equals("Twitch") && Twitch.getActive())
                {
                    Twitch.SendMessage(otherChannel.getMessage(), SettingsGroup.Instance.TsStandardChannel);
                }
                else
                {
                    if (otherChannel.getNextPlattform() == "")
                    {
                        AusgabeKonsole(new KonsolenAusgabe("DISCORD", DateTime.Now.TimeOfDay, "SendMessageToOtherChannel - ungültiger Channel"));
                    }
                    else
                    {
                        AusgabeKonsole(new KonsolenAusgabe("DISCORD", DateTime.Now.TimeOfDay, "SendMessageToOtherChannel - Plattform: " + otherChannel.getNextPlattform() + " ist nicht aktiv"));
                    }
                }
                Discord.OtherChannelDone();
            }


        }

        private async void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Discord.getActive())
            {
                await Discord.StopBotAsync();
            }
            if (Twitch.getActive())
            {
                Twitch.StopBot();
            }
            this.Close();
        }

        private void discordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DiscordEinstellungen discordEinstellungen = new DiscordEinstellungen(Discord);
            discordEinstellungen.Show();
        }

        private void TwitchStart_Click(object sender, EventArgs e)
        {
            Twitch.StartBot();
            TwitchStop.Enabled = true;
            TwitchStart.Enabled = false;
            LoadBefehle();
        }

        private void TwitchStop_Click(object sender, EventArgs e)
        {
            Twitch.StopBot();
            Twitch.BotUserSave();
            TwitchStop.Enabled = false;
            TwitchStart.Enabled = true;
        }

        public void AusgabeKonsole(KonsolenAusgabe Eingabe)
        {
            KonsolenAusgabeJSON.Add(Eingabe);
            txtAusgabe.Text = Eingabe.AusgabeTyp + " - " + Eingabe.AusgabeDatum + " - " + Eingabe.AusgabeZeitpunkt.ToString() + ":" + Environment.NewLine + Eingabe.AusgabeText + Environment.NewLine + Environment.NewLine + txtAusgabe.Text;
            Eingabe.ausgegeben();

            LogWriter.LogWrite(Eingabe.AusgabeTyp + "---" + Eingabe.AusgabeText);

        }
        private void UpdateAusgabe_Tick(object sender, EventArgs e)
        {
            KonsolenAusgabe ausgabe = null;
            if (Discord.isAusgeben() == true)
            {
                ausgabe = Discord.getKonsoleAusgabe();
                ausgabe.AusgabeTyp = "DISCORD";
                AusgabeKonsole(ausgabe);

                /*
                //Prüfung, wenn Discord die Verbindung gefunden hat, ob Twitch nicht auch neugestartet wird
                if (ausgabe.AusgabeText.Contains("Connected") && !Twitch.getActive()) {
                    autostart();
                }
                */
            }
            if (Twitch.isAusgeben() == true)
            {
                ausgabe = Twitch.getKonsoleAusgabe();
                ausgabe.AusgabeTyp = "TWITCH";
                AusgabeKonsole(ausgabe);
            }
        }

        private void allgemeineEinstellungenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllgEinstellungen FensterAllgEinstellungen = new AllgEinstellungen();
            FensterAllgEinstellungen.Show();
        }

        private void twitchToolStripMenuItem_Click(object sender, EventArgs e)
        {

            TwitchEinstellungen twitchEinstellungen = new TwitchEinstellungen();
            twitchEinstellungen.SetTwitch(Twitch);
            twitchEinstellungen.Show();
        }

        private void befehleCommandsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Befehl_Editor Fenster = new Befehl_Editor())
            {
                DialogResult dr = Fenster.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    LoadBefehle();
                }

            }
        }

        private void LoadBefehle()
        {
            if (Discord.getActive())
            {
                AusgabeKonsole(new KonsolenAusgabe("KONSOLE", DateTime.Now.TimeOfDay, "Discord Befehle werden geladen..."));
                toolLoadBefehle.Text = "Befehle: Laden Discord Start";
                Discord.LoadBefehle(PathBefehl, 1);
                toolLoadBefehle.Text = "Befehle: Laden Discord Befehle Fertig";
                Discord.LoadBefehle(PathZeit, 2);
                toolLoadBefehle.Text = "Befehle: Laden Discord Zeit-Befehle Fertig";
                Discord.LoadBefehle(PathListBefehl, 3);
                toolLoadBefehle.Text = "Befehle: Laden Discord List-Befehle Fertig";
                AusgabeKonsole(new KonsolenAusgabe("KONSOLE", DateTime.Now.TimeOfDay, "Discord Befehle sind alle geladen..."));

                Discord.LoadAllCommands();
            }
            if (Twitch.getActive())
            {
                AusgabeKonsole(new KonsolenAusgabe("KONSOLE", DateTime.Now.TimeOfDay, "Twitch Befehle werden geladen..."));
                Twitch.LoadBefehle(PathBefehl, 1);
                toolLoadBefehle.Text = "Befehle: Laden Twitch Befehle Fertig";
                Twitch.LoadBefehle(PathZeit, 2);
                toolLoadBefehle.Text = "Befehle: Laden Twitch Zeit-Befehle Fertig";
                Twitch.LoadBefehle(PathListBefehl, 3);
                toolLoadBefehle.Text = "Befehle: Laden List-Befehle Fertig";
                Twitch.LoadTwitchBefehle(PathTwitch);
                toolLoadBefehle.Text = "Befehle: Laden Twitch Twitch-Befehle Fertig";
                AusgabeKonsole(new KonsolenAusgabe("KONSOLE", DateTime.Now.TimeOfDay, "Twitch Befehle sind alle geladen..."));

                Twitch.LoadAllCommands();
            }

            toolLoadBefehle.Text = "Befehle: geladen";
        }


        private void btnLoadBefehle_Click(object sender, EventArgs e)
        {
            LoadBefehle();

            //Telegramm nur für Testzwecke aktuell
            Telegramm.LoadBefehle(PathBefehl, 1);
        }

        private void chkDiscordZeit_CheckedChanged(object sender, EventArgs e)
        {
            Discord.ZeitBefehlSenden = chkDiscordZeit.Checked;
        }

        private void chkTwitchZeit_CheckedChanged(object sender, EventArgs e)
        {
            Twitch.ZeitBefehlSenden = chkTwitchZeit.Checked;
        }

        private void TwitchStatusStrip_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ID - Name - Anzahl - LastJoined" + Environment.NewLine + Twitch.getStringBotUser(), "Logbuch der gejointen User");
        }

        private void timerResetBox_Tick(object sender, EventArgs e)
        {
            txtAusgabe.Clear();
            if (Twitch.getActive())
            {
                Twitch.TestAllCurrentTokens();
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Telegramm.LoadBefehle(PathBefehl, 1);
            Telegramm.startBot();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Telegramm.stopBot();
        }



        private void timerOtherChannel_Tick(object sender, EventArgs e)
        {
            if (FirstStart)
            {
                autostart();
                FirstStart = false;
                timerOtherChannel.Interval = 10000; //entspricht 10 Sekunden
            }
            else
            {

                CheckSendToOtherChannel();

                //Prüfung, ob die Anmeldung in beiden Plattformen erfolgt ist. Bei Unterschiede evtl. nochmal neu anmelden (evtl. über Einstellung verfügbar machen. In die ToDo-Liste aufgenommen
                //Zähler wie häufig eine Anmeldung wieder versucht wird, wird so lange verdoppelt, bis 5 min (300 000) erreicht wird. Wird zurückgesetzt auf (10 000) wenn beide einmal zeitgleich angemeldet waren
                if (Discord.getActive() != Twitch.getActive())
                {
                    timerOtherChannel.Interval = timerOtherChannel.Interval * 2;
                    if (timerOtherChannel.Interval >= 300000)
                    {
                        timerOtherChannel.Interval = 300000;
                    }
                    autostart();
                }
                else
                {
                    timerOtherChannel.Interval = 10000;
                }
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Twitch.BotUserSave();

        }

        private void einstellungenExportierenToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //string Path = System.Windows.Forms.Application.StartupPath + "TEST-Einstellung"; //"\\Befehl.json";
            SettingsGroup.Instance.ExportSettingsGroup(Application.StartupPath + Path.DirectorySeparatorChar);

            string InhaltJSON = "";
            InhaltJSON += JsonConvert.SerializeObject(SettingsGroup.Instance, Formatting.Indented);
            Stream myStream;

            sfdEinstellungExport.Filter = "JSON-Files (*.json)|*.json";
            sfdEinstellungExport.FilterIndex = 2;
            sfdEinstellungExport.RestoreDirectory = true;

            if (sfdEinstellungExport.ShowDialog() == DialogResult.OK && sfdEinstellungExport.FileName != "")
            {
                if ((myStream = sfdEinstellungExport.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    byte[] bytes = Encoding.Default.GetBytes(InhaltJSON);
                    myStream.Write(bytes, 0, bytes.Length);
                    myStream.Close();
                }
            }

        }

        private void einstellungenImportierenToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ofdEinstellungImport.InitialDirectory = Application.StartupPath;
            ofdEinstellungImport.Filter = "JSON-Files (*.json)|*.json";
            ofdEinstellungImport.FilterIndex = 2;
            ofdEinstellungImport.RestoreDirectory = true;

            if (ofdEinstellungImport.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file

                //Read the contents of the file into a stream
                var fileStream = ofdEinstellungImport.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream, Encoding.Default))
                {

                    string Inhalt = reader.ReadToEnd();
                    try
                    {
                        SettingsGroup Import = JsonConvert.DeserializeObject<SettingsGroup>(Inhalt);

                        if (DialogResult.Yes == MessageBox.Show("Die aktuellen Einstellungen werden alle überschrieben \nFortfahren?", "Überschreiben der Einstellungen", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            Import.ImportSettingsGroup(Inhalt);
                            LoadBefehle();

                            if (DialogResult.Yes == MessageBox.Show("Einstellungen wurden importiert. Damit die Einstellungen verwendet werden können, wird ein neustart empfohlen. \nNeustart Durchführen?", "Import erfolgreich", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                            {
                                Application.Restart();
                            }
                        }
                    }
                    catch (Exception Fehler)
                    {
                        MessageBox.Show("Die ausgewählte Datei beinhaltet nicht die Einstellungen oder ist beschädigt \n Weitere Informationen: \n\n" + Fehler.InnerException.ToString(), "Fehler beim Einlesen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }

        }

        private void SavePHPFile()
        {
            System.Reflection.Assembly _Assembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream str;
            StreamReader rd;
            string PHPInhalt;
            string Pfad = Application.StartupPath + Path.DirectorySeparatorChar + "WebSite" + Path.DirectorySeparatorChar;
            //Export der Startseite und Meta-Daten
            AusgabeKonsole(new KonsolenAusgabe("KONSOLE", DateTime.Now.TimeOfDay, "Start der Ausgabe nach " +Pfad+" ..."));
            try
            {
                str = _Assembly.GetManifestResourceStream("AntonBot.Fenster.HilfeSeiten.Index.html");
                rd = new StreamReader(str, encoding: Encoding.GetEncoding("ISO-8859-1"));

                PHPInhalt = rd.ReadToEnd();
                Pfad = Application.StartupPath + Path.DirectorySeparatorChar + "WebSite" + Path.DirectorySeparatorChar + "Index.html";
                (new FileInfo(Pfad)).Directory.Create();
                File.WriteAllText(Pfad, PHPInhalt, Encoding.GetEncoding("ISO-8859-1"));
            }
            catch (Exception WriteFehler)
            {
                AusgabeKonsole(new KonsolenAusgabe("KONSOLE", DateTime.Now.TimeOfDay, "Home-Index.html konnte nicht beschrieben werden: " + WriteFehler.Message));
            }
            try
            {
                str = _Assembly.GetManifestResourceStream("AntonBot.Fenster.HilfeSeiten.PinguinServer.jpg");
                Bitmap bmp = new Bitmap(str);

                Pfad = Application.StartupPath + Path.DirectorySeparatorChar + "WebSite" + Path.DirectorySeparatorChar + "PinguinServer.jpg";
                (new FileInfo(Pfad)).Directory.Create();
                Image.FromStream(str).Save(Pfad);
            }
            catch (Exception WriteFehler)
            {
                AusgabeKonsole(new KonsolenAusgabe("KONSOLE", DateTime.Now.TimeOfDay, "PinguinServer.jpg konnte nicht beschrieben werden: " + WriteFehler.Message));
            }
            try
            {
                str = _Assembly.GetManifestResourceStream("AntonBot.Fenster.HilfeSeiten.Style.css");
                rd = new StreamReader(str, encoding: Encoding.GetEncoding("ISO-8859-1"));
                PHPInhalt = rd.ReadToEnd().Normalize();
                Pfad = Application.StartupPath + Path.DirectorySeparatorChar + "WebSite" + Path.DirectorySeparatorChar + "Style.css";
                (new FileInfo(Pfad)).Directory.Create();
                File.WriteAllText(Pfad, PHPInhalt, Encoding.GetEncoding("ISO-8859-1"));
            }
            catch (Exception WriteFehler)
            {
                AusgabeKonsole(new KonsolenAusgabe("KONSOLE", DateTime.Now.TimeOfDay, "Style.css konnte nicht beschrieben werden: " + WriteFehler.Message));
            }
            //Export der Einrichtung
            try
            {
                str = _Assembly.GetManifestResourceStream("AntonBot.Fenster.HilfeSeiten.Einrichtung.Index.html");
                rd = new StreamReader(str, encoding: Encoding.GetEncoding("ISO-8859-1"));
                PHPInhalt = rd.ReadToEnd().Normalize();
                Pfad = Application.StartupPath + Path.DirectorySeparatorChar + "WebSite" + Path.DirectorySeparatorChar + "Einrichtung" + Path.DirectorySeparatorChar + "Index.html";
                (new FileInfo(Pfad)).Directory.Create();
                File.WriteAllText(Pfad, PHPInhalt, Encoding.GetEncoding("ISO-8859-1"));
            }
            catch (Exception WriteFehler)
            {
                AusgabeKonsole(new KonsolenAusgabe("KONSOLE", DateTime.Now.TimeOfDay, "Einrichtung-Index.html konnte nicht beschrieben werden: " + WriteFehler.Message));
            }
            try
            {
                str = _Assembly.GetManifestResourceStream("AntonBot.Fenster.HilfeSeiten.Einrichtung.TwitchAnleitung.html");
                rd = new StreamReader(str, encoding: Encoding.GetEncoding("ISO-8859-1"));
                PHPInhalt = rd.ReadToEnd().Normalize();
                Pfad = Application.StartupPath + Path.DirectorySeparatorChar + "WebSite" + Path.DirectorySeparatorChar + "Einrichtung" + Path.DirectorySeparatorChar + "TwitchAnleitung.html";
                (new FileInfo(Pfad)).Directory.Create();
                File.WriteAllText(Pfad, PHPInhalt, Encoding.GetEncoding("ISO-8859-1"));
            }
            catch (Exception WriteFehler)
            {
                AusgabeKonsole(new KonsolenAusgabe("KONSOLE", DateTime.Now.TimeOfDay, "TwitchAnleitung.html konnte nicht beschrieben werden: " + WriteFehler.Message));
            }
            try
            {
                str = _Assembly.GetManifestResourceStream("AntonBot.Fenster.HilfeSeiten.Einrichtung.DiscordAnleitung.html");
                rd = new StreamReader(str, encoding: Encoding.GetEncoding("ISO-8859-1"));
                PHPInhalt = rd.ReadToEnd().Normalize();
                Pfad = Application.StartupPath + Path.DirectorySeparatorChar + "WebSite" + Path.DirectorySeparatorChar + "Einrichtung" + Path.DirectorySeparatorChar + "DiscordAnleitung.html";
                (new FileInfo(Pfad)).Directory.Create();
                File.WriteAllText(Pfad, PHPInhalt, Encoding.GetEncoding("ISO-8859-1"));
            }
            catch (Exception WriteFehler)
            {
                AusgabeKonsole(new KonsolenAusgabe("KONSOLE", DateTime.Now.TimeOfDay, "DiscordAnleitung.html konnte nicht beschrieben werden: " + WriteFehler.Message));
            }
            //Export der Fenster
            try
            {
                str = _Assembly.GetManifestResourceStream("AntonBot.Fenster.HilfeSeiten.Fenster.AllgEinstellungen.html");
                rd = new StreamReader(str, encoding: Encoding.GetEncoding("ISO-8859-1"));
                PHPInhalt = rd.ReadToEnd().Normalize();
                Pfad = Application.StartupPath + Path.DirectorySeparatorChar + "WebSite" + Path.DirectorySeparatorChar + "Fenster" + Path.DirectorySeparatorChar + "AllgEinstellungen.html";
                (new FileInfo(Pfad)).Directory.Create();
                File.WriteAllText(Pfad, PHPInhalt, Encoding.GetEncoding("ISO-8859-1"));
            }
            catch (Exception WriteFehler)
            {
                AusgabeKonsole(new KonsolenAusgabe("KONSOLE", DateTime.Now.TimeOfDay, "AllgEinstellungen.html konnte nicht beschrieben werden: " + WriteFehler.Message));
            }
            try
            {
                str = _Assembly.GetManifestResourceStream("AntonBot.Fenster.HilfeSeiten.Fenster.BefehlEditor.html");
                rd = new StreamReader(str, encoding: Encoding.GetEncoding("ISO-8859-1"));
                PHPInhalt = rd.ReadToEnd().Normalize();
                Pfad = Application.StartupPath + Path.DirectorySeparatorChar + "WebSite" + Path.DirectorySeparatorChar + "Fenster" + Path.DirectorySeparatorChar + "BefehlEditor.html";
                (new FileInfo(Pfad)).Directory.Create();
                File.WriteAllText(Pfad, PHPInhalt, Encoding.GetEncoding("ISO-8859-1"));
            }
            catch (Exception WriteFehler)
            {
                AusgabeKonsole(new KonsolenAusgabe("KONSOLE", DateTime.Now.TimeOfDay, "BefehlEditor.html konnte nicht beschrieben werden: " + WriteFehler.Message));
            }
            try
            {
                str = _Assembly.GetManifestResourceStream("AntonBot.Fenster.HilfeSeiten.Fenster.DiscordEinstellungen.html");
                rd = new StreamReader(str, encoding: Encoding.GetEncoding("ISO-8859-1"));
                PHPInhalt = rd.ReadToEnd().Normalize();
                Pfad = Application.StartupPath + Path.DirectorySeparatorChar + "WebSite" + Path.DirectorySeparatorChar + "Fenster" + Path.DirectorySeparatorChar + "DiscordEinstellungen.html";
                (new FileInfo(Pfad)).Directory.Create();
                File.WriteAllText(Pfad, PHPInhalt, Encoding.GetEncoding("ISO-8859-1"));
            }
            catch (Exception WriteFehler)
            {
                AusgabeKonsole(new KonsolenAusgabe("KONSOLE", DateTime.Now.TimeOfDay, "DiscordEinstellungen.html konnte nicht beschrieben werden: " + WriteFehler.Message));
            }
            try
            {
                str = _Assembly.GetManifestResourceStream("AntonBot.Fenster.HilfeSeiten.Fenster.Index.html");
                rd = new StreamReader(str, encoding: Encoding.GetEncoding("ISO-8859-1"));
                PHPInhalt = rd.ReadToEnd().Normalize();
                Pfad = Application.StartupPath + Path.DirectorySeparatorChar + "WebSite" + Path.DirectorySeparatorChar + "Fenster" + Path.DirectorySeparatorChar + "Index.html";
                (new FileInfo(Pfad)).Directory.Create();
                File.WriteAllText(Pfad, PHPInhalt, Encoding.GetEncoding("ISO-8859-1"));
            }
            catch (Exception WriteFehler)
            {
                AusgabeKonsole(new KonsolenAusgabe("KONSOLE", DateTime.Now.TimeOfDay, "Fenster-Index.html konnte nicht beschrieben werden: " + WriteFehler.Message));
            }
            try
            {
                str = _Assembly.GetManifestResourceStream("AntonBot.Fenster.HilfeSeiten.Fenster.Bilder.Startseite.png");
                Bitmap bmp = new Bitmap(str);

                Pfad = Application.StartupPath + Path.DirectorySeparatorChar + "WebSite" + Path.DirectorySeparatorChar + "Fenster" + Path.DirectorySeparatorChar + "Bilder" + Path.DirectorySeparatorChar + "Startseite.png";
                (new FileInfo(Pfad)).Directory.Create();
                Image.FromStream(str).Save(Pfad);
            }
            catch (Exception WriteFehler)
            {
                AusgabeKonsole(new KonsolenAusgabe("KONSOLE", DateTime.Now.TimeOfDay, "Startseite.jpg konnte nicht beschrieben werden: " + WriteFehler.Message));
            }
            try
            {
                str = _Assembly.GetManifestResourceStream("AntonBot.Fenster.HilfeSeiten.Fenster.StartFenster.html");
                rd = new StreamReader(str, encoding: Encoding.GetEncoding("ISO-8859-1"));
                PHPInhalt = rd.ReadToEnd().Normalize();
                Pfad = Application.StartupPath + Path.DirectorySeparatorChar + "WebSite" + Path.DirectorySeparatorChar + "Fenster" + Path.DirectorySeparatorChar + "StartFenster.html";
                (new FileInfo(Pfad)).Directory.Create();
                File.WriteAllText(Pfad, PHPInhalt, Encoding.GetEncoding("ISO-8859-1"));
            }
            catch (Exception WriteFehler)
            {
                AusgabeKonsole(new KonsolenAusgabe("KONSOLE", DateTime.Now.TimeOfDay, "StartFenster.html konnte nicht beschrieben werden: " + WriteFehler.Message));
            }
            try
            {
                str = _Assembly.GetManifestResourceStream("AntonBot.Fenster.HilfeSeiten.Fenster.TwitchEinstellungen.html");
                rd = new StreamReader(str, encoding: Encoding.GetEncoding("ISO-8859-1"));
                PHPInhalt = rd.ReadToEnd().Normalize();
                Pfad = Application.StartupPath + Path.DirectorySeparatorChar + "WebSite" + Path.DirectorySeparatorChar + "Fenster" + Path.DirectorySeparatorChar + "TwitchEinstellungen.html";
                (new FileInfo(Pfad)).Directory.Create();
                File.WriteAllText(Pfad, PHPInhalt, Encoding.GetEncoding("ISO-8859-1"));
            }
            catch (Exception WriteFehler)
            {
                AusgabeKonsole(new KonsolenAusgabe("KONSOLE", DateTime.Now.TimeOfDay, "TwitchEinstellungen.html konnte nicht beschrieben werden: " + WriteFehler.Message));
            }
            try
            {
                str = _Assembly.GetManifestResourceStream("AntonBot.Fenster.HilfeSeiten.Fenster.VariableHilfe.html");
                rd = new StreamReader(str, encoding: Encoding.GetEncoding("ISO-8859-1"));
                PHPInhalt = rd.ReadToEnd().Normalize();
                Pfad = Application.StartupPath + Path.DirectorySeparatorChar + "WebSite" + Path.DirectorySeparatorChar + "Fenster" + Path.DirectorySeparatorChar + "VariableHilfe.html";
                (new FileInfo(Pfad)).Directory.Create();
                File.WriteAllText(Pfad, PHPInhalt, Encoding.GetEncoding("ISO-8859-1"));
            }
            catch (Exception WriteFehler)
            {
                AusgabeKonsole(new KonsolenAusgabe("KONSOLE", DateTime.Now.TimeOfDay, "VariableHilfe.html konnte nicht beschrieben werden: " + WriteFehler.Message));
            }
            //Export der LogFiles
            try
            {
                str = _Assembly.GetManifestResourceStream("AntonBot.Fenster.HilfeSeiten.LogFile.Index.html");
                rd = new StreamReader(str, encoding: Encoding.GetEncoding("ISO-8859-1"));
                PHPInhalt = rd.ReadToEnd();
                Pfad = Application.StartupPath + Path.DirectorySeparatorChar + "WebSite" + Path.DirectorySeparatorChar + "LogFile" + Path.DirectorySeparatorChar + "Index.html";
                (new FileInfo(Pfad)).Directory.Create();
                File.WriteAllText(Pfad, PHPInhalt, Encoding.GetEncoding("ISO-8859-1"));
            }
            catch (Exception WriteFehler)
            {
                AusgabeKonsole(new KonsolenAusgabe("KONSOLE", DateTime.Now.TimeOfDay, "LogFile-Index.html konnte nicht beschrieben werden: " + WriteFehler.Message));
            }
            try
            {
                str = _Assembly.GetManifestResourceStream("AntonBot.Fenster.HilfeSeiten.LogFile.BotStatus.php");
                rd = new StreamReader(str, encoding: Encoding.GetEncoding("ISO-8859-1"));
                PHPInhalt = rd.ReadToEnd().Normalize();
                PHPInhalt = PHPInhalt.Replace("°LogPfad", SettingsGroup.Instance.StandardPfad + "KonsolenAusgabe.json");
                Pfad = Application.StartupPath + Path.DirectorySeparatorChar + "WebSite" + Path.DirectorySeparatorChar + "LogFile" + Path.DirectorySeparatorChar + "BotStatus.php";
                (new FileInfo(Pfad)).Directory.Create();
                File.WriteAllText(Pfad, PHPInhalt, Encoding.GetEncoding("ISO-8859-1"));
            }
            catch (Exception WriteFehler)
            {
                AusgabeKonsole(new KonsolenAusgabe("KONSOLE", DateTime.Now.TimeOfDay, "BotStatus.php konnte nicht beschrieben werden: " + WriteFehler.Message));
            }
            try
            {
                str = _Assembly.GetManifestResourceStream("AntonBot.Fenster.HilfeSeiten.LogFile.Logbuch.php");
                rd = new StreamReader(str, encoding: Encoding.GetEncoding("ISO-8859-1"));
                PHPInhalt = rd.ReadToEnd().Normalize();
                PHPInhalt = PHPInhalt.Replace("°LogPfad", SettingsGroup.Instance.StandardPfad + "KonsolenAusgabe.json");
                Pfad = Application.StartupPath + Path.DirectorySeparatorChar + "WebSite" + Path.DirectorySeparatorChar + "LogFile" + Path.DirectorySeparatorChar + "Logbuch.php";
                (new FileInfo(Pfad)).Directory.Create();
                File.WriteAllText(Pfad, PHPInhalt, Encoding.GetEncoding("ISO-8859-1"));
            }
            catch (Exception WriteFehler)
            {
                AusgabeKonsole(new KonsolenAusgabe("KONSOLE", DateTime.Now.TimeOfDay, "Logbuch.php konnte nicht beschrieben werden: " + WriteFehler.Message));
            }
            //Export des OnlineEditors
            try
            {
                str = _Assembly.GetManifestResourceStream("AntonBot.Fenster.HilfeSeiten.OnlineEditor.Index.html");
                rd = new StreamReader(str, encoding: Encoding.GetEncoding("ISO-8859-1"));
                PHPInhalt = rd.ReadToEnd().Normalize();
                Pfad = Application.StartupPath + Path.DirectorySeparatorChar + "WebSite" + Path.DirectorySeparatorChar + "OnlineEditor" + Path.DirectorySeparatorChar + "Index.html";
                (new FileInfo(Pfad)).Directory.Create();
                File.WriteAllText(Pfad, PHPInhalt, Encoding.GetEncoding("ISO-8859-1"));
            }
            catch (Exception WriteFehler)
            {
                AusgabeKonsole(new KonsolenAusgabe("KONSOLE", DateTime.Now.TimeOfDay, "OnlineEditor-Index.html konnte nicht beschrieben werden: " + WriteFehler.Message));
            }
            //Export der Sonstigen Seiten
            try
            {
                str = _Assembly.GetManifestResourceStream("AntonBot.Fenster.HilfeSeiten.Sonstiges.Index.html");
                rd = new StreamReader(str, encoding: Encoding.GetEncoding("ISO-8859-1"));
                PHPInhalt = rd.ReadToEnd().Normalize();
                Pfad = Application.StartupPath + Path.DirectorySeparatorChar + "WebSite" + Path.DirectorySeparatorChar + "Sonstiges" + Path.DirectorySeparatorChar + "Index.html";
                (new FileInfo(Pfad)).Directory.Create();
                File.WriteAllText(Pfad, PHPInhalt, Encoding.GetEncoding("ISO-8859-1"));
            }
            catch (Exception WriteFehler)
            {
                AusgabeKonsole(new KonsolenAusgabe("KONSOLE", DateTime.Now.TimeOfDay, "Sonstiges-Index.html konnte nicht beschrieben werden: " + WriteFehler.Message));
            }
            try
            {
                str = _Assembly.GetManifestResourceStream("AntonBot.Fenster.HilfeSeiten.Sonstiges.GameSkill.php");
                rd = new StreamReader(str, encoding: Encoding.GetEncoding("ISO-8859-1"));
                PHPInhalt = rd.ReadToEnd().Normalize();
                Pfad = Application.StartupPath + Path.DirectorySeparatorChar + "WebSite" + Path.DirectorySeparatorChar + "Sonstiges" + Path.DirectorySeparatorChar + "GameSkill.php";
                (new FileInfo(Pfad)).Directory.Create();
                File.WriteAllText(Pfad, PHPInhalt, Encoding.GetEncoding("ISO-8859-1"));
            }
            catch (Exception WriteFehler)
            {
                AusgabeKonsole(new KonsolenAusgabe("KONSOLE", DateTime.Now.TimeOfDay, "GameSkill.php konnte nicht beschrieben werden: " + WriteFehler.Message));
            }
            //Ausgabe der Bilder
            try
            {
                str = _Assembly.GetManifestResourceStream("AntonBot.Fenster.HilfeSeiten.Fenster.Bilder.AllgEinstellung1.png");
                Bitmap bmp = new Bitmap(str);

                Pfad = Application.StartupPath + Path.DirectorySeparatorChar + "WebSite" + Path.DirectorySeparatorChar + "Fenster" + Path.DirectorySeparatorChar + "Bilder" + Path.DirectorySeparatorChar + "AllgEinstellung1.png";
                (new FileInfo(Pfad)).Directory.Create();
                Image.FromStream(str).Save(Pfad);
            }
            catch (Exception WriteFehler)
            {
                AusgabeKonsole(new KonsolenAusgabe("KONSOLE", DateTime.Now.TimeOfDay, "AllgEinstellung1.png konnte nicht beschrieben werden: " + WriteFehler.Message));
            }
            try
            {
                str = _Assembly.GetManifestResourceStream("AntonBot.Fenster.HilfeSeiten.Fenster.Bilder.AllgEinstellung2.png");
                Bitmap bmp = new Bitmap(str);

                Pfad = Application.StartupPath + Path.DirectorySeparatorChar + "WebSite" + Path.DirectorySeparatorChar + "Fenster" + Path.DirectorySeparatorChar + "Bilder" + Path.DirectorySeparatorChar + "AllgEinstellung2.png";
                (new FileInfo(Pfad)).Directory.Create();
                Image.FromStream(str).Save(Pfad);
            }
            catch (Exception WriteFehler)
            {
                AusgabeKonsole(new KonsolenAusgabe("KONSOLE", DateTime.Now.TimeOfDay, "AllgEinstellung2.png konnte nicht beschrieben werden: " + WriteFehler.Message));
            }
            try
            {
                str = _Assembly.GetManifestResourceStream("AntonBot.Fenster.HilfeSeiten.Fenster.Bilder.AllgEinstellung2_2.png");
                Bitmap bmp = new Bitmap(str);

                Pfad = Application.StartupPath + Path.DirectorySeparatorChar + "WebSite" + Path.DirectorySeparatorChar + "Fenster" + Path.DirectorySeparatorChar + "Bilder" + Path.DirectorySeparatorChar + "AllgEinstellung2_2.png";
                (new FileInfo(Pfad)).Directory.Create();
                Image.FromStream(str).Save(Pfad);
            }
            catch (Exception WriteFehler)
            {
                AusgabeKonsole(new KonsolenAusgabe("KONSOLE", DateTime.Now.TimeOfDay, "AllgEinstellung2_2.png konnte nicht beschrieben werden: " + WriteFehler.Message));
            }
            try
            {
                str = _Assembly.GetManifestResourceStream("AntonBot.Fenster.HilfeSeiten.Fenster.Bilder.AllgEinstellung3.png");
                Bitmap bmp = new Bitmap(str);

                Pfad = Application.StartupPath + Path.DirectorySeparatorChar + "WebSite" + Path.DirectorySeparatorChar + "Fenster" + Path.DirectorySeparatorChar + "Bilder" + Path.DirectorySeparatorChar + "AllgEinstellung3.png";
                (new FileInfo(Pfad)).Directory.Create();
                Image.FromStream(str).Save(Pfad);
            }
            catch (Exception WriteFehler)
            {
                AusgabeKonsole(new KonsolenAusgabe("KONSOLE", DateTime.Now.TimeOfDay, "AllgEinstellung3.png konnte nicht beschrieben werden: " + WriteFehler.Message));
            }
            try
            {
                str = _Assembly.GetManifestResourceStream("AntonBot.Fenster.HilfeSeiten.Fenster.Bilder.Befehle.png");
                Bitmap bmp = new Bitmap(str);

                Pfad = Application.StartupPath + Path.DirectorySeparatorChar + "WebSite" + Path.DirectorySeparatorChar + "Fenster" + Path.DirectorySeparatorChar + "Bilder" + Path.DirectorySeparatorChar + "Befehle.png";
                (new FileInfo(Pfad)).Directory.Create();
                Image.FromStream(str).Save(Pfad);
            }
            catch (Exception WriteFehler)
            {
                AusgabeKonsole(new KonsolenAusgabe("KONSOLE", DateTime.Now.TimeOfDay, "Befehle.png konnte nicht beschrieben werden: " + WriteFehler.Message));
            }


            AusgabeKonsole(new KonsolenAusgabe("KONSOLE", DateTime.Now.TimeOfDay, "...Ausgabe abgeschlossen"));
        }

        private void testc()
        {
            Discord.SendMessage(735764666424492062, "Hello My Friend");
        }

        private void txtAusgabe_DoubleClick(object sender, EventArgs e)
        {
            SettingsGroup.Instance.Update();
            SavePHPFile();

            JoinedUsers test = new JoinedUsers("23", "Herbert");
            test.NewJoined();
        }

        private void webSeitenExportierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SavePHPFile();
        }

        private void logZurücksetzenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KonsolenAusgabeJSON = new List<KonsolenAusgabe>();
            AusgabeKonsole(new KonsolenAusgabe("KONSOLE", DateTime.Now.TimeOfDay, "Log-Dateien werden gelöscht"));
            

            File.WriteAllText(KonsolenLogPath, JsonConvert.SerializeObject(KonsolenAusgabeJSON, Formatting.Indented));
            KonsolenAusgabeJSON = new List<KonsolenAusgabe>();
            AusgabeKonsole(new KonsolenAusgabe("KONSOLE", DateTime.Now.TimeOfDay, "Log-Dateien gelöscht"));
        }

        private void DiscordStatusStrip_Click(object sender, EventArgs e)
        {
            testc();
        }
    }
}
