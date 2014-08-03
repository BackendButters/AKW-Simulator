using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace AKW_Simulator
{
    public partial class hauptfenster : Form
    {
        #region Felder
        byte fehler1 = 0;   //Hilfsvariable, um das defekt-blinken der Pumpen zu simulieren
        byte fehler2 = 0;   //s.o.
        byte ersatzfehler = 0;  //s.o.
        byte wasserfehler = 0;  //s.o.
        byte temperaturwarning = 0; //s.o.
        Color pumpedisabled_color = Color.Orange;
        Color pumpefailure_color = Color.Maroon;
        Color pumpeworking_color = Color.Green;
        internal static Technikchat Chat = new Technikchat();   //Fenster erzeugen
        Finance finanzen = new Finance();
        Highscore highscore = new Highscore();
        Mails mails = new Mails();
        Steuerstab_fehler_label schaltplan = new Steuerstab_fehler_label();
        NewsWindow newswindow = new NewsWindow();
        AboutBox about = new AboutBox();
        HypeRep hyperep = new HypeRep();
        byte messagerepeat = 0; //Hilfsvariable, damit der Chat nicht gespammt wird
        ViperBytes.Windows.Forms.WaterBox waterbox = new ViperBytes.Windows.Forms.WaterBox();
        int solltemperatur = 150;   //Temperatur, die, abhängig von den Steuerstäben, erreicht werden soll
        int p1imagecounter = 0; //Hilfsvariable, um die Pumpenbewegung zu simulieren
        int p2imagecounter = 0; //s.o.
        int epimagecounter = 0; //s.o.
        int sollepl = 0;    //Sollleistung der Ersatzpumpe
        int sollp1l = 60;   //s.o.
        int sollp2l = 60;   //s.o.
        bool emergency = false; //SCRAM?
        byte emergencybuttoncolorcounter = 0;   //Hilfsvariable, um das Blinken des SCRAM-Buttons zu simulieren
        bool connectionAvailable = false;   //Verbindung zum Highscore- und Newsserver möglich?
        int backgroundworkerHelper = 0; //Hilfsvariable, damit die periodische Verbindungsüberprüfung nicht zu traffic-lastig wird
        WMPLib.WindowsMediaPlayerClass alarmplayer = new WMPLib.WindowsMediaPlayerClass();  //Soundplayer deklarieren
        WMPLib.WindowsMediaPlayerClass mailplayer = new WMPLib.WindowsMediaPlayerClass();   //s.o.
        WMPLib.WindowsMediaPlayerClass componentfailplayer = new WMPLib.WindowsMediaPlayerClass();  //s.o.
        double laufendeKosten = 0.2;    //laufende Kosten

        #endregion

        public hauptfenster()
        {
            InitializeComponent();
            Uhr.Text = DateTime.Now.ToShortTimeString() + "h";
            waterbox_panel.Controls.Add(waterbox);
            waterbox.Dock = DockStyle.Fill;
            waterbox.Value = 80;
            about.description_txtbx.AppendText("Falls Fragen / Kommentare / etc vorhanden sind, würde sich der Autor unter der eMail-Adresse 'AKW-Simulator@fssnet-n.de' über eine Mitteilung freuen.\n");
            about.description_txtbx.AppendText("Temperaturanzeige und Notaus-Button von Luca Bonotto (http://www.codeproject.com/KB/cs/industrial_controls.aspx)\n");
            about.description_txtbx.AppendText("Digitale Temperaturanzeige von sllow (http://www.codeproject.com/KB/miscctrl/digitalpanel.aspx)\n");
            about.description_txtbx.AppendText("Kühlwasseranzeige von v.wochnik (http://dotnet-snippets.de/dns/waterbox-SID737.aspx)\n");
            about.description_txtbx.AppendText("Gewinnanzeige von Adrian Tosca (http://www.codeproject.com/KB/miscctrl/CsCounterArticle1.aspx)\n");
            about.description_txtbx.AppendText("Helmbild im Jim-Bonusfenster von: http://commons.wikimedia.org/wiki/Image:Stub_edilizia.png\n");
            about.description_txtbx.AppendText("Alle Namen/Firmen/etc sind frei erfunden. Sollten Ähnlichkeiten zu realen Namen bestehen, sind diese unbeabsichtigt eingefügt worden.\n");
            about.description_txtbx.AppendText("Danke an Cubl!c und HCyborg fürs Alpha-Testen ;-)");
            about.description_txtbx.AppendText(@"Supportthread: http://www.mycsharp.de/wbb2/thread.php?threadid=58987");
            backgroundWorker.RunWorkerAsync();
            alarmplayer.URL = Application.StartupPath + @"\Sounds\Alarm.mp3";   //Sounddatei in Player laden
            alarmplayer.stop(); //damit die Datei nicht gleich abgespielt wird -> stoppen
            mailplayer.URL = Application.StartupPath + @"\Sounds\eMail.mp3";
            mailplayer.stop();
            componentfailplayer.URL = Application.StartupPath + @"\Sounds\Componentalert.mp3";
            componentfailplayer.stop();
            this.Enabled = false;   //bevor der Loginscreen nicht weg ist -> Formular disabled
        }

        #region Pumpen

        #region Ersatzpumpe
        private void ersatzpumpe_ein_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (Statics.Ersatzpumpe_working)    //Wenn die Ersatzpumpe nicht defekt ist..
            {
                if (ersatzpumpe_ein_btn.Checked)    //..einschalten
                {
                    ersatzpumpe_fehlertimer.Enabled = true;
                    ersatzpumpe_status.Text = "In Betrieb";
                    ersatzpumpe_status.ForeColor = pumpeworking_color;
                    ersatzpumpe_statustimer.Enabled = true;
                    ersatzpumpe_statuslabel.Text = "läuft an...";
                    ersatzpumpe_statuslabel.Visible = true;
                    ersatzpumpe_randomizer.Enabled = true;
                    ep_trackbar.Value = 2;
                    ersatzpumpe_leistung.Text = Statics.Epl + "%";
                }
                else       //..oder ausschalten
                {
                    ersatzpumpe_fehlertimer.Enabled = false;
                    ersatzpumpe_status.Text = "Außer Betrieb";
                    ersatzpumpe_status.ForeColor = pumpedisabled_color;
                    ersatzpumpe_statustimer.Enabled = true;
                    ersatzpumpe_statuslabel.Text = "hält an...";
                    ersatzpumpe_statuslabel.Visible = true;
                    ersatzpumpe_randomizer.Enabled = false;
                    ep_trackbar.Value = 1;
                }
            }
        }

        private void ersatzpumpe_statustimer_Tick(object sender, EventArgs e)
        {
            ersatzpumpe_progressbar.Value = (int)Statics.Epl;

            if (ersatzpumpe_ein_btn.Checked)     //Pumpenleistung hochfahren
            {
                if (Statics.Epl < ep_trackbar.Value)    //Wenn geforderte Leistung unter der momentanen Leistung
                {
                    Statics.Epl++;
                    ersatzpumpe_progressbar.Value = (int)Statics.Epl; //Progressbar und leistungslabel synchronisieren
                }
                else
                {
                    ersatzpumpe_statustimer.Enabled = false;     //wenn Solleistung erreicht -> Timer stoppen
                    ersatzpumpe_statuslabel.Visible = false;
                }
            }
            else
            {
                if (Statics.Epl > 0)                            //Pumpenleistung herunterfahren
                {
                    Statics.Epl--;
                    ersatzpumpe_progressbar.Value = (int)Statics.Epl;
                }
                else
                {
                    ersatzpumpe_statustimer.Enabled = false;
                    ersatzpumpe_statuslabel.Visible = false;
                }
            }
            ersatzpumpe_leistung.Text = Statics.Epl.ToString() + "%";   //Pumpenleistungslabel setzen
        }
        
        private void ersatzpumpe_randomizer_Tick(object sender, EventArgs e)
        {
            if (ep_trackbar.Value > 1)
            {
                int i = 0;
                int tmp = (int)Statics.Epl;
                Random rnd = new Random();
                i = rnd.Next(-3, 3);
                tmp += i;
                if (tmp > 1 && tmp < 101)
                    ersatzpumpe_leistung.Text = tmp.ToString() + "%";
            }
            else
                ersatzpumpe_leistung.Text = Statics.Epl + "%";
        }

        private void ep_trackbar_ValueChanged(object sender, EventArgs e)
        {
            if (Statics.Ersatzpumpe_working && ersatzpumpe_ein_btn.Checked) //Wenn die Pumpe eingeschaltet ist und nicht defekt ist..
            {
                switch (ep_trackbar.Value)  //Die Sollleistung zuweisen
                {
                    case 1:
                        sollepl = 0;
                        break;

                    case 2:
                        sollepl = 20;
                        break;

                    case 3:
                        sollepl = 40;
                        break;

                    case 4:
                        sollepl = 60;
                        break;

                    case 5:
                        sollepl = 80;
                        break;

                    case 6:
                        sollepl = 100;
                        break;
                }
            }
        }
        #endregion

        #region Pumpe 2
        private void pumpe2_ein_btn_CheckedChanged(object sender, EventArgs e)  //Nach gleichem Schema wie Ersatzpumpe weiter oben
        {
            if (Statics.Pumpe2_working)
            {
                if (pumpe2_ein_btn.Checked)
                {
                    pumpe2_fehlertimer.Enabled = true;
                    pumpe2_status.Text = "In Betrieb";
                    pumpe2_status.ForeColor = pumpeworking_color;
                    pumpe2_statustimer.Enabled = true;
                    pumpe2_statuslabel.Text = "läuft an...";
                    pumpe2_statuslabel.Visible = true;
                    pumpe2_randomizer.Enabled = true;
                    p2_trackbar.Value = 2;
                    pumpe2_leistung.Text = Statics.P2l + "%";
                }
                else
                {
                    pumpe2_fehlertimer.Enabled = false;
                    pumpe2_status.ForeColor = pumpedisabled_color;
                    pumpe2_status.Text = "Außer Betrieb";
                    pumpe2_statustimer.Enabled = true;
                    pumpe2_statuslabel.Text = "hält an...";
                    pumpe2_statuslabel.Visible = true;
                    pumpe2_progressbar.Visible = true;
                    pumpe2_randomizer.Enabled = false;
                    p2_trackbar.Value = 1;
                }
            }
        }

        private void pumpe2_statustimer_Tick_1(object sender, EventArgs e)
        {
            pumpe2_progressbar.Value = (int)Statics.P2l;

            if (pumpe2_ein_btn.Checked)     
            {
                if (Statics.P2l < p2_trackbar.Value)
                {
                    Statics.P2l++;
                    pumpe2_progressbar.Value = (int)Statics.P2l; 
                }
                else
                {
                    pumpe2_statustimer.Enabled = false;     
                    pumpe2_statuslabel.Visible = false;
                }
            }
            else
            {
                if (Statics.P2l > 0)                           
                {
                    Statics.P2l--;
                    pumpe2_progressbar.Value = (int)Statics.P2l;
                }
                else
                {
                    pumpe2_statustimer.Enabled = false;
                    pumpe2_statuslabel.Visible = false;
                }
            }
            pumpe2_leistung.Text = Statics.P2l.ToString() + "%";   
        }   

        private void pumpe2_randomizer_Tick(object sender, EventArgs e)
        {
            if (p1_trackbar.Value > 1)
            {
                int i = 0;
                int tmp = (int)Statics.P2l;
                Random rnd = new Random();
                i = rnd.Next(-3, 3);
                tmp += i;
                if (tmp > 1 && tmp < 101)
                    pumpe2_leistung.Text = tmp.ToString() + "%";
            }
            else
                pumpe2_leistung.Text = Statics.P2l + "%";
        }

        private void p2_trackbar_ValueChanged(object sender, EventArgs e)
        {
            if (Statics.Pumpe2_working && pumpe2_ein_btn.Checked)
            {
                switch (p2_trackbar.Value)
                {
                    case 1:
                        sollp2l = 0;
                        break;

                    case 2:
                        sollp2l = 20;
                        break;

                    case 3:
                        sollp2l = 40;
                        break;

                    case 4:
                        sollp2l = 60;
                        break;

                    case 5:
                        sollp2l = 80;
                        break;

                    case 6:
                        sollp2l = 100;
                        break;
                }
            }
        }
        #endregion

        #region Pumpe 1
        private void pumpe1_ein_btn_CheckedChanged(object sender, EventArgs e)  //Nach gleichem Schema wie Ersatzpumpe weiter oben
        {
            if (Statics.Pumpe1_working)
            {
                if (pumpe1_ein_btn.Checked)
                {
                    pumpe1_fehlertimer.Enabled = true;
                    pumpe1_status.Text = "In Betrieb";
                    pumpe1_status.ForeColor = pumpeworking_color;
                    pumpe1_statustimer.Enabled = true;
                    pumpe1_statuslabel.Text = "läuft an...";
                    pumpe1_statuslabel.Visible = true;
                    pumpe1_randomizer.Enabled = true;
                    p1_trackbar.Value = 2;
                    pumpe1_leistung.Text = Statics.P1l + "%";
                }
                else
                {
                    pumpe1_fehlertimer.Enabled = false;
                    pumpe1_status.Text = "Außer Betrieb";
                    pumpe1_status.ForeColor = pumpedisabled_color;
                    pumpe1_statustimer.Enabled = true;
                    pumpe1_statuslabel.Text = "hält an...";
                    pumpe1_statuslabel.Visible = true;
                    pumpe1_progressbar.Visible = true;
                    pumpe1_randomizer.Enabled = false;
                    p1_trackbar.Value = 1;
                }
            }
        }

        private void pumpe1_statustimer_Tick(object sender, EventArgs e)
        {
            pumpe1_progressbar.Value = (int)Statics.P1l;

            if (pumpe1_ein_btn.Checked)     
            {
                if (Statics.P1l < p1_trackbar.Value)
                {
                    Statics.P1l++;
                    pumpe1_progressbar.Value = (int)Statics.P1l; 
                }
                else
                {
                    pumpe1_statustimer.Enabled = false;     
                    pumpe1_statuslabel.Visible = false;
                }
            }
            else
            {
                if (Statics.P1l > 0)                           
                {
                    Statics.P1l--;
                    pumpe1_progressbar.Value = (int)Statics.P1l;
                }
                else
                {
                    pumpe1_statustimer.Enabled = false;
                    pumpe1_statuslabel.Visible = false;
                }
            }
            pumpe1_leistung.Text = Statics.P1l.ToString() + "%";   
        }

        private void pumpe1_randomizer_Tick(object sender, EventArgs e)
        {
            if (p1_trackbar.Value > 1)
            {
                int i = 0;
                int tmp = (int)Statics.P1l;
                Random rnd = new Random();
                i = rnd.Next(-3, 3);
                tmp += i;
                if (tmp > 1 && tmp < 101)
                    pumpe1_leistung.Text = tmp.ToString() + "%";
            }
            else
                pumpe1_leistung.Text = Statics.P1l + "%";
        }

        private void p1_trackbar_ValueChanged(object sender, EventArgs e)
        {
            if (Statics.Pumpe1_working && pumpe1_ein_btn.Checked)
            {
                switch (p1_trackbar.Value)
                {
                    case 1:
                        sollp1l = 0;
                        break;

                    case 2:
                        sollp1l = 20;
                        break;

                    case 3:
                        sollp1l = 40;
                        break;

                    case 4:
                        sollp1l = 60;
                        break;

                    case 5:
                        sollp1l = 80;
                        break;

                    case 6:
                        sollp1l = 100;
                        break;
                }
            }
        }
        #endregion

        #endregion

        #region Reaktor
        internal void steuerstab_trackbar_ValueChanged(object sender, EventArgs e)
        {
            if (Statics.Eventname == "Synchronisieren" && Statics.EventBegin <= 0)  //Wenn die Steuerstäbe während der Synchronisation bewegt werden -> GameOver
                EndGame("Synchronisation nicht abgewartet und damit Stromnetz gefährdet");
            switch (steuerstab_trackbar.Value)  //Sollleistung, laufende Kosten und Temperatur der Reaktorleistung anpassen
            {
                case 0:
                    Statics.Leistung = 1500;
                    solltemperatur = 1450;
                    laufendeKosten = 1.3;
                    break;

                case 1:
                    Statics.Leistung = 1400;
                    solltemperatur = 1360;
                    laufendeKosten = 1.1;
                    break;

                case 2:
                    Statics.Leistung = 1300;
                    solltemperatur = 1280;
                    laufendeKosten = 1;
                    break;

                case 3:
                    Statics.Leistung = 1200;
                    solltemperatur = 1090;
                    laufendeKosten = 0.9;
                    break;

                case 4:
                    Statics.Leistung = 1100;
                    solltemperatur = 980;
                    laufendeKosten = 0.8;
                    break;

                case 5:
                    Statics.Leistung = 1000;
                    solltemperatur = 896;
                    laufendeKosten = 0.7;
                    break;

                case 6:
                    Statics.Leistung = 900;
                    solltemperatur = 790;
                    laufendeKosten = 0.65;
                    break;

                case 7:
                    Statics.Leistung = 800;
                    solltemperatur = 610;
                    laufendeKosten = 0.6;
                    break;

                case 8:
                    Statics.Leistung = 700;
                    solltemperatur = 550;
                    laufendeKosten = 0.55;
                    break;

                case 9:
                    Statics.Leistung = 600;
                    solltemperatur = 490;
                    laufendeKosten = 0.5;
                    break;

                case 10:
                    Statics.Leistung = 500; 
                    solltemperatur = 410;
                    laufendeKosten = 0.45;
                    break;

                case 11:
                    Statics.Leistung = 400; 
                    solltemperatur = 340;
                    laufendeKosten = 0.4;
                    break;

                case 12:
                    Statics.Leistung = 300;
                    solltemperatur = 290;
                    laufendeKosten = 0.35;
                    break;

                case 13:
                    Statics.Leistung = 200;
                    solltemperatur = 265;
                    laufendeKosten = 0.3;
                    break;

                case 14:
                    Statics.Leistung = 100;
                    solltemperatur = 230;
                    laufendeKosten = 0.25;
                    break;

                case 15:
                    Statics.Leistung = 0;
                    solltemperatur = 65;
                    laufendeKosten = 0.2;
                    break;
            }
            Random rnd = new Random();
            temprandomizer.Enabled = false;
            leistungsrandomizer.Enabled = false;
        }

        private void leistungsrandomizer_Tick_1(object sender, EventArgs e)
        {
            if (steuerstab_trackbar.Value != 20)    //Leistung etwas schwanken lassen
            {
                int i = 0;
                Random rnd = new Random();
                i = rnd.Next(-25, 25);
                if ((Statics.Leistung + i) < 1510)
                    Statics.Leistung += i;
                if (Statics.Leistung > 0)
                    AKW_leistung_label.Text = Statics.Leistung.ToString() + " MW/h";
            }
        }

        private void temprandomizer_Tick(object sender, EventArgs e)
        {                     
            Temperaturanzeige.Value = (int)Statics.Temperatur;
            int tmp = (int)Statics.Temperatur;
            digital_temperatur.Number = (float)tmp;
        }
        #endregion

        #region sonstige Methoden und Buttons
        private void halbsekundengeber_Tick(object sender, EventArgs e)
        {
            #region Pleite-EndGame
            if (Statics.Guthaben <= 1)
                EndGame("Pleite");
            #endregion

            #region Pumpen

            #region Pumpe 1

            if (pumpe1_progressbar.Value < Statics.P1l) //Wenn der Wert der Progressbar unter dem der Leistung ist, wird er erhöht
                pumpe1_progressbar.Value++;
            else   //andernfalls abgesenkt
                try
                {
                    pumpe1_progressbar.Value--;
                }
                catch (Exception)
                {
                    pumpe1_progressbar.Value = 0;
                }
            if (Statics.Pumpe1_working) 
            {
                if (pumpe1_ein_btn.Checked) //Wenn die Pumpe an ist..
                {
                    if (sollp1l != Statics.P1l) //..und die Istleistung ungleich der Sollleistung ist..
                    {
                        if (sollp1l > Statics.P1l)  //..nimmt die Leistung zu, bzw ab.
                            Statics.P1l++;
                        else
                            Statics.P1l--;
                    }
                }
                else //Wenn die Pumpe defekt ist, wird die Leistung schrittweise auf 0 gesetzt.
                    if (Statics.P1l > 0)
                        Statics.P1l--;
            }

            #endregion

            #region Pumpe 2
            if (pumpe2_progressbar.Value < Statics.P2l)         //gleiches Schema wie Pumpe 1 weiter oben
                pumpe2_progressbar.Value++;
            else
                try
                {
                    pumpe2_progressbar.Value--;
                }
                catch (Exception)
                {
                    pumpe2_progressbar.Value = 0;
                }
            if (Statics.Pumpe2_working)
            {
                if (pumpe2_ein_btn.Checked)
                {
                    if (sollp2l != Statics.P2l)
                    {
                        if (sollp2l > Statics.P2l)
                            Statics.P2l++;
                        else
                            Statics.P2l--;
                    }
                }
                else
                    if (Statics.P2l > 0)
                        Statics.P2l--;
            }

            #endregion

            #region Ersatzpumpe
            if (ersatzpumpe_progressbar.Value < Statics.Epl)    //gleiches Schema wie Pumpe 1 weiter oben
                ersatzpumpe_progressbar.Value++;
            else
                try
                {
                    ersatzpumpe_progressbar.Value--;
                }
                catch (Exception)
                {
                    ersatzpumpe_progressbar.Value = 0;
                }

            if (Statics.Ersatzpumpe_working)
            {
                if (ersatzpumpe_ein_btn.Checked)
                {
                    if (sollepl != Statics.Epl)
                    {
                        if (sollepl > Statics.Epl)
                            Statics.Epl++;
                        else
                            Statics.Epl--;
                    }
                }
                else
                    if (Statics.Epl > 0)
                        Statics.Epl--;
            }
            #endregion 

            #region Pumpenleistungswarnung
            if ((Statics.P1l + Statics.P2l + Statics.Epl - (decimal)(Statics.FilterVerstopfung - 20) < 100))    //Wenn die Pumpenleistung zu niedrig ist, erhöht sich die Temperatur und eine Warnung wird angezeigt
            {
                pumpenleistungswarn_panel.Visible = true;
                Statics.Temperatur++;
            }
            else
                pumpenleistungswarn_panel.Visible = false;

            Statics.Gesamtpumpenleistung = Statics.P1l + Statics.P2l + Statics.Epl - (decimal)(Statics.FilterVerstopfung - 20); //Formel zur Berechnung der Pumpenleistung
            #endregion 

            #endregion

            #region Waterbox
            if (waterbox.Value < 0)
                waterbox.Value = 0;
            if (waterbox.Value == 0)    //Wenn der Kühlwasserbehälter leer ist, werden die Pumpen abgeschaltet
            {
                if (Statics.Pumpe1_working)
                {
                    pumpe1_aus_btn.Checked = true;
                    pumpe1_aus_btn.Enabled = false;
                    pumpe1_ein_btn.Enabled = false;
                    p1_trackbar.Enabled = false;
                }
                
                if (Statics.Pumpe2_working)
                {
                    pumpe2_aus_btn.Checked = true;
                    pumpe2_aus_btn.Enabled = false;
                    pumpe2_ein_btn.Enabled = false;
                    p2_trackbar.Enabled = false;
                }

                if (Statics.Ersatzpumpe_working)
                {
                    ersatzpumpe_aus_btn.Checked = true;
                    ersatzpumpe_aus_btn.Enabled = false;
                    ersatzpumpe_ein_btn.Enabled = false;
                    ep_trackbar.Enabled = false;
                }
            }
            else
            {
                if (!emergency) //Wenn SCRAM -> Pumpenbuttons etc kontrollieren
                {
                    if (Statics.Pumpe1_working)
                    {
                        pumpe1_aus_btn.Enabled = true;
                        pumpe1_ein_btn.Enabled = true;
                        p1_trackbar.Enabled = true;
                    }
                    else
                    {
                        if (!Statics.Reparing)
                        {
                            pumpe1_aus_btn.Enabled = true;
                            pumpe1_ein_btn.Enabled = true;
                            p1_trackbar.Enabled = true;
                        }
                    }
                    if (Statics.Pumpe2_working)
                    {
                        pumpe2_aus_btn.Enabled = true;
                        pumpe2_ein_btn.Enabled = true;
                        p2_trackbar.Enabled = true;
                    }
                    else
                    {
                        if (!Statics.Reparing)
                        {
                            pumpe2_aus_btn.Enabled = true;
                            pumpe2_ein_btn.Enabled = true;
                            p2_trackbar.Enabled = true;
                        }
                    }
                    if (Statics.Ersatzpumpe_working)
                    {
                        ersatzpumpe_aus_btn.Enabled = true;
                        ersatzpumpe_ein_btn.Enabled = true;
                        ep_trackbar.Enabled = true;
                    }
                    else
                    {
                        if (!Statics.Reparing)
                        {
                            ersatzpumpe_aus_btn.Enabled = true;
                            ersatzpumpe_ein_btn.Enabled = true;
                            ep_trackbar.Enabled = true;
                        }
                    }
                    if(!Statics.Steuerstaberror)
                        steuerstab_trackbar.Enabled = true;
                }
            }
            #endregion 

            #region reaktorleistung und Temperatur 
            
            #region Leistung
            if (Statics.GeneratorError || Statics.TurbineError || !schaltplan.generator_ein_btn.Checked || Statics.Eventname == "Synchronisieren")
            {
                Statics.Istleistung = 0;    //Wenn Turbine/Generator/Synchronisationsevent -> gelieferte Leistung = 0
                if (Statics.Istleistung >= 0 && Statics.Istleistung <= 1500)
                {
                    if((int)Statics.Leistung >=0)
                        steuerstab_progressbar.Value = (int)Statics.Leistung;
                }
            }
            else
            {
                if (!leistungsrandomizer.Enabled)   
                {
                    if (Statics.Istleistung < Statics.Leistung) //Wenn die Sollleistung nicht erreicht ist -> erhöhen bzw verringern
                    { 
                        leistungsrandomizer.Enabled = false;
                        Statics.Istleistung += 10;
                    }
                    else
                    {
                        if (Statics.Istleistung > Statics.Leistung)
                        {
                            leistungsrandomizer.Enabled = false;
                            Statics.Istleistung -= 10;
                        }
                    }
                    if (Statics.Istleistung >= 0 && Statics.Istleistung <= 1500)
                        steuerstab_progressbar.Value = (int)Statics.Istleistung;
                    if (Statics.Istleistung == Statics.Leistung)    //Wenn Sollleistung erreicht -> Leistung schwanken lassen
                        leistungsrandomizer.Enabled = true;
                }
            } 

            AKW_leistung_label.Text = Statics.Istleistung.ToString() + "MW";
            lieferleistung_display.Number = (float)Statics.Istleistung;

            if ((Statics.Istleistung + 10) < Statics.Demandleistung)      //Anzeigefarbe der geliferten Leistung
                demandleistung_display.FontColor = Color.Red;
            else
                demandleistung_display.FontColor = Color.YellowGreen;

            if (Statics.TurbineError)  
                schaltplan.turbine_progressbar.Value = 0;
            else
            {
                if (schaltplan.turbine_progressbar.Value < Statics.Leistung)    //Turbinen-Progressbar anpassen
                    schaltplan.turbine_progressbar.Value += 9;
                else
                    if (schaltplan.turbine_progressbar.Value > Statics.Istleistung)
                        schaltplan.turbine_progressbar.Value += -9;
            }

            if (Statics.GeneratorError)    
                schaltplan.generator_progressbar.Value = 0;
            else
            {
                if (schaltplan.generator_ein_btn.Checked)
                {
                    if (schaltplan.generator_progressbar.Value < Statics.Istleistung)   //Generator-Progressbar anpassen
                        schaltplan.generator_progressbar.Value += 9;
                    else
                        if (schaltplan.generator_progressbar.Value > Statics.Istleistung)
                        {
                            try
                            {
                                schaltplan.generator_progressbar.Value += -9;
                            }
                            catch
                            {
                                schaltplan.generator_progressbar.Value = 0;
                            }
                        }
                }
            }
            #endregion

            #region Temperatur
            if (waterbox.Value > 0)
            {
                if (Statics.FilterVerstopfung < 100)
                {
                    if (((Statics.P1l - ((decimal)Statics.FilterVerstopfung-20)) + (Statics.P2l - ((decimal)Statics.FilterVerstopfung-20)) + (Statics.Epl - ((decimal)Statics.FilterVerstopfung-20))) >= 100 && ((Statics.P1l - ((decimal)Statics.FilterVerstopfung-20)) + (Statics.P2l - ((decimal)Statics.FilterVerstopfung-20)) + (Statics.Epl - ((decimal)Statics.FilterVerstopfung-20))) <= 150) //Berechnung der Pumpenleistung mit Filterverschmutzung
                    {
                        if (Statics.Temperatur < solltemperatur)
                            Statics.Temperatur++;
                        else
                        {
                            if (Statics.Temperatur > solltemperatur)
                                Statics.Temperatur--;
                        }
                    }
                    if (((Statics.P1l - ((decimal)Statics.FilterVerstopfung-20)) + (Statics.P2l - ((decimal)Statics.FilterVerstopfung-20)) + (Statics.Epl - ((decimal)Statics.FilterVerstopfung-20))) >= 150 && ((Statics.P1l - ((decimal)Statics.FilterVerstopfung-20)) + (Statics.P2l - ((decimal)Statics.FilterVerstopfung-20)) + (Statics.Epl - ((decimal)Statics.FilterVerstopfung-20))) <= 225) 
                    {
                        if (Statics.Temperatur > 60)
                        {
                            if (Statics.Temperatur < solltemperatur - 50)
                                Statics.Temperatur += (decimal)0.8;
                            else
                            {
                                if (Statics.Temperatur > solltemperatur - 50)
                                    Statics.Temperatur -= (decimal)0.8;
                            }
                        }
                        else
                        {
                            Random rnd = new Random();
                            Statics.Temperatur = rnd.Next(58, 62);  //Temperatur schwanken lassen
                        }
                    }
                    if (((Statics.P1l - ((decimal)Statics.FilterVerstopfung-20)) + (Statics.P2l - ((decimal)Statics.FilterVerstopfung-20)) + (Statics.Epl - ((decimal)Statics.FilterVerstopfung-20))) > 225)        //Temperatur
                    {
                        if (Statics.Temperatur > 58)
                        {
                            if (Statics.Temperatur < solltemperatur - 70)
                                Statics.Temperatur += (decimal)0.8;
                            else
                            {
                                if (Statics.Temperatur > solltemperatur - 70)
                                    Statics.Temperatur -= (decimal)0.8;
                            }
                        }
                        else
                        {
                            Random rnd = new Random();
                            Statics.Temperatur = rnd.Next(56, 61);  //Temperatur schwanken lassen
                        }
                    }
                }
                else
                    Statics.Temperatur++;
            }
            else
                Statics.Temperatur++;

            Temperaturanzeige.Value = (int)Statics.Temperatur;   
            #endregion

            #endregion

            #region GameOver Generator
            if(Statics.Eventname == "Synchronisieren")
                if(!schaltplan.generator_ein_btn.Checked)
                    EndGame("Synchronisation nicht abgewartet und damit Stromnetz gefährdet");

            #region Meltdown
            if (Statics.Temperatur > 1850)
            {
                WMPLib.WindowsMediaPlayerClass explosionplayer = new WMPLib.WindowsMediaPlayerClass();
                explosionplayer.URL = Application.StartupPath + @"\Sounds\Explosion.mp3";
                EndGame("Meltdown!");
            }
            #endregion

            #region Guthaben zu gross
            if (Statics.Guthaben >= 9999998)
            {
                MessageBox.Show("WoW, du hast es geschafft, Gratulation! Das Guthaben ist ans Limit geraten.\n\nFalls dies die Regel ist, kontaktiere doch bitte den Autor, sodass eine Limiterhöhung vorgenommen werden kann. Danke!",
                                "Limit erreicht",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                EndGame("Guthaben zu hoch");               
            }
            #endregion

            #region zu viele SCRAMs
            if (EMails.SCRAMcounter >= 4)
            {
                EndGame("Zu viele SCRAMs ausgelöst");
            }
            #endregion

            #endregion

            #region HypeRep

            #region Checkboxen aktivieren/deaktivieren
            if (Statics.Pumpe1_working || !p1_technikrufen_btn.Enabled) //Wenn die Komponente nicht kaputt oder Jim bereits auf dem Weg zu ihr ist -> Checkboxen im HypeRep Fenster deaktiviern
            {
                hyperep.hyperep_kuhlwasserpumpe1_chkbx.Enabled = false;
                hyperep.hyperep_kuhlwasserpumpe1_chkbx.Checked = false;
            }
            else
                hyperep.hyperep_kuhlwasserpumpe1_chkbx.Enabled = true;

            if (Statics.Pumpe2_working || !p2_technikrufen_btn.Enabled)
            {
                hyperep.hyperep_kuhlwasserpumpe2_chkbx.Enabled = false;
                hyperep.hyperep_kuhlwasserpumpe2_chkbx.Checked = false;
            }
            else
                hyperep.hyperep_kuhlwasserpumpe2_chkbx.Enabled = true;

            if (Statics.Ersatzpumpe_working || !ep_technikrufen_btn.Enabled)
            {
                hyperep.hyperep_ersatzkuhlwasserpumpe_chkbx.Enabled = false;
                hyperep.hyperep_ersatzkuhlwasserpumpe_chkbx.Checked = false;
            }
            else
                hyperep.hyperep_ersatzkuhlwasserpumpe_chkbx.Enabled = true;

            if (!Statics.Steuerstaberror || !repairsteuerstab_btn.Enabled)
            {
                hyperep.hyperep_steuerstab_chkbx.Enabled = false;
                hyperep.hyperep_steuerstab_chkbx.Checked = false;
            }
            else
                hyperep.hyperep_steuerstab_chkbx.Enabled = true;

            if (!Statics.GeneratorError || !schaltplan.generatorrep_btn.Enabled)
            {
                hyperep.hyperep_generator_chkbx.Enabled = false;
                hyperep.hyperep_generator_chkbx.Checked = false;
            }
            else
                hyperep.hyperep_generator_chkbx.Enabled = true;

            if (!Statics.TurbineError || !schaltplan.turbinerep_btn.Enabled)
            {
                hyperep.hyperep_turbine_chkbx.Enabled = false;
                hyperep.hyperep_turbine_chkbx.Checked = false;
            }
            else
                hyperep.hyperep_turbine_chkbx.Enabled = true;

            if (!Statics.KuhlwasserNachfullPumpeError || !schaltplan.kuhlwassernachfullpumpeRep_btn.Enabled)
            {
                hyperep.hyperep_kuhlwassernachfullpumpe_chkbx.Enabled = false;
                hyperep.hyperep_kuhlwassernachfullpumpe_chkbx.Checked = false;
            }
            else
                hyperep.hyperep_kuhlwassernachfullpumpe_chkbx.Enabled = true;

            if (!schaltplan.filterreinigen_btn.Enabled || Statics.FilterVerstopfung <= 0)
            {
                hyperep.hyperep_filterreinigen_chkbx.Enabled = false;
                hyperep.hyperep_filterreinigen_chkbx.Checked = false;
            }
            else
                hyperep.hyperep_filterreinigen_chkbx.Enabled = true;
            #endregion 

            #region Pumpenreparatur HypeRep
            if (Statics.Pumpe1_working) //Sicherstellen, dass die Komponenten nach der Reparatur einsatzbereit sind
            {
                pumpe1_statustimer.Enabled = true;
                if (pumpe1_ein_btn.Checked)
                {
                    pumpe1_status.Text = "In Betrieb";
                    pumpe1_status.ForeColor = pumpeworking_color;
                }
                else
                {
                    pumpe1_status.Text = "Außer Betrieb";
                    pumpe1_status.ForeColor = pumpedisabled_color;

                }
            }

            if (Statics.Pumpe2_working)
            {
                pumpe2_statustimer.Enabled = true;
                if (pumpe2_ein_btn.Checked)
                {
                    pumpe2_status.Text = "In Betrieb";
                    pumpe2_status.ForeColor = pumpeworking_color;
                }
                else
                {
                    pumpe2_status.Text = "Außer Betrieb";
                    pumpe2_status.ForeColor = pumpedisabled_color;
                }
            }

            if (Statics.Ersatzpumpe_working)
            {
                ersatzpumpe_statustimer.Enabled = true;
                if (ersatzpumpe_ein_btn.Checked)
                {
                    ersatzpumpe_status.Text = "In Betrieb";
                    ersatzpumpe_status.ForeColor = pumpeworking_color;
                }
                else
                {
                    ersatzpumpe_status.Text = "Außer Betrieb";
                    ersatzpumpe_status.ForeColor = pumpedisabled_color;
                }
            }
            if (!Statics.Steuerstaberror)
            {
                Statics.Steuerstaberror = false;
                Steuerstab_statuslabel.Text = "Normal";
                Steuerstab_statuslabel.ForeColor = Color.Green;
                if(!emergency)
                    steuerstab_trackbar.Enabled = true;
                repairsteuerstab_btn.Visible = false;
                repairsteuerstab_btn.Enabled = true;
            }

            #endregion 

            #endregion
        }

        private void EndGame(string Grund)  //GameOver einleiten
        {
            Chat.chatbox.AppendText(DateTime.Now.ToShortTimeString() + ": Jim: Sorry Chef, ich konnt' nichts mehr machen...\n");
            ersatzpumpe_fehlertimer.Enabled = false;
            ersatzpumpe_randomizer.Enabled = false;
            ersatzpumpe_statustimer.Enabled = false;
            rep_ersatzpumpe.Enabled = false;

            pumpe1_fehlertimer.Enabled = false;
            pumpe1_randomizer.Enabled = false;
            pumpe1_statustimer.Enabled = false;
            rep_pumpe1.Enabled = false;

            pumpe2_fehlertimer.Enabled = false;
            pumpe2_randomizer.Enabled = false;
            pumpe2_statustimer.Enabled = false;
            rep_pumpe2.Enabled = false;

            temprandomizer.Enabled = false;
            leistungsrandomizer.Enabled = false;
            halbsekundengeber.Enabled = false;
            fehlerfarbe_timer.Enabled = false;
            ein_sekundengeber.Enabled = false;

            finanzen.refreshzeitgeber.Enabled = false;
            ein_sekundengeber.Enabled = false;

            Statics.Temperatur = 0;

            GameOver gameover = new GameOver();
            gameover.reason_label.Text = Grund;
            gameover.ShowDialog();

            if (gameover.DialogResult == DialogResult.Retry)
            {
                if (connectionAvailable)    //Wenn eine Verbindung zum Server besteht -> Highscore anzeigen und eintragen lassen
                {
                    highscore.guthaben_label.Text = ((int)(Statics.Guthaben)).ToString() + "$";
                    highscore.erwirtschaftetes_guthaben_panel.Visible = true;
                    highscore.HighscoreEintragen_panel.Visible = true;
                    highscore.ShowDialog();
                }
                Application.Restart();
                this.Close();
            }
            else
            {
                if (connectionAvailable)
                {
                    highscore.guthaben_label.Text = ((int)(Statics.Guthaben)).ToString() + "$";
                    highscore.erwirtschaftetes_guthaben_panel.Visible = true;
                    highscore.HighscoreEintragen_panel.Visible = true;
                    highscore.ShowDialog();
                }
                Application.Exit();
                this.Close();
            }
        }

        private void quit_btn_Click(object sender, EventArgs e)
        {
            Chat = null;
            finanzen = null;
            highscore = null;
            mails = null;
            schaltplan = null;
            about = null;
            Application.Exit();
            this.Close();
        }

        private void restart_btn_Click(object sender, EventArgs e)
        {
            Chat = null;
            finanzen = null;
            highscore = null;
            mails = null;
            schaltplan = null;
            about = null;
            Application.Restart();
            this.Close();
        }

        private void fehlerfarbe_timer_Tick(object sender, EventArgs e)
        {
            #region Kühlwasserfehlerfarbe
            if (waterbox.Value == 0)    //rotes Aufblinken simulieren
            {
                if (wasserfehler == 0)
                {
                    wasserfehler++;
                    wasser_panel.BackColor = Color.Red;
                }
                else
                {
                    wasserfehler--;
                    wasser_panel.BackColor = SystemColors.Control;
                }
            }
            else
                wasser_panel.BackColor = SystemColors.Control;
            #endregion 

            #region Reaktortemperatur Warnung
            if (Statics.Temperatur < 1500)
            {
                temperatur_statuslabel.Text = "Normal";
                temperatur_parent_panel.BackColor = SystemColors.Control;
                temperatur_statuslabel.ForeColor = SystemColors.ControlText;
            }
            if (Statics.Temperatur > 1500 && Statics.Temperatur < 1600)
            {
                temperatur_statuslabel.Text = "Achtung! Reaktor zu heiß!";
                temperatur_statuslabel.ForeColor = Color.Orange;
                temperatur_parent_panel.BackColor = SystemColors.Control;
            }
            if (Statics.Temperatur > 1600)                  //Auslager.Temperatur
            {
                temperatur_statuslabel.Text = "Achtung! Reaktortemperatur kritisch!";
                temperatur_statuslabel.ForeColor = Color.Maroon;
                if (temperaturwarning == 0) //rotes Aufblinken simulieren
                {
                    temperatur_parent_panel.BackColor = Color.Red;
                    temperaturwarning++;
                }
                else
                {
                    temperatur_parent_panel.BackColor = SystemColors.Control;
                    temperaturwarning--;
                }
            }
            #endregion

            #region Notausbutton Farbe
            if (emergency)  //Blinken simulieren
            {
                if (emergencybuttoncolorcounter == 0)
                {
                    notaus_btn.ButtonColor = Color.Orange;
                    notaus_label.ForeColor = Color.Red;
                    emergencybuttoncolorcounter++;
                }
                else
                {
                    notaus_btn.ButtonColor = Color.Red;
                    notaus_label.ForeColor = Color.Orange;
                    emergencybuttoncolorcounter--;
                }

                p1_trackbar.Enabled = false;
                pumpe1_ein_btn.Enabled = false;
                pumpe1_aus_btn.Enabled = false;

                p2_trackbar.Enabled = false;
                pumpe2_ein_btn.Enabled = false;
                pumpe2_aus_btn.Enabled = false;

                ep_trackbar.Enabled = false;
                ersatzpumpe_ein_btn.Enabled = false;
                ersatzpumpe_aus_btn.Enabled = false;

                steuerstab_trackbar.Enabled = false;

                notaus_btn.Enabled = false;
            }
            else
            {
                notaus_btn.ButtonColor = Color.Red;
                notaus_label.ForeColor = Color.Black;
                notaus_btn.Enabled = true;
            }
            #endregion

            #region Pumpenwarnung

            #region Pumpe1
            if (!Statics.Pumpe1_working)    //Blinken simulieren
            {
                if (fehler1 == 0)
                {
                    pumpe1_statuspanel.BackColor = Color.Red;
                    fehler1++;
                }
                else
                {
                    fehler1--;
                    pumpe1_statuspanel.BackColor = SystemColors.Control;
                }
            }
            else
                pumpe1_statuspanel.BackColor = SystemColors.Control;
            #endregion

            #region Pumpe 2
            if (!Statics.Pumpe2_working)    //Blinken simulieren
            {
                if (fehler2 == 0)
                {
                    fehler2++;
                    pumpe2_statuspanel.BackColor = Color.Red;
                }
                else
                {
                    fehler2--;
                    pumpe2_statuspanel.BackColor = SystemColors.Control;
                }
            }
            else
                pumpe2_statuspanel.BackColor = SystemColors.Control;
            #endregion

            #region Ersatzpumpe
            if (!Statics.Ersatzpumpe_working)       //Blinken simulieren
            {
                if (ersatzfehler == 0)
                {
                    ersatzfehler++;
                    ersatzpumpe_statuspanel.BackColor = Color.Red;
                }
                else
                {
                    ersatzfehler--;
                    ersatzpumpe_statuspanel.BackColor = SystemColors.Control;
                }
            }
            else
                ersatzpumpe_statuspanel.BackColor = SystemColors.Control;
            #endregion

            #endregion 

            #region Temperaturanzeige aktualisieren
            int tmp = (int)Statics.Temperatur;              //Temperaturanzeigen anpassen;
            digital_temperatur.Number = (float)tmp;
            #endregion 
        }

        #region Fenster öffnen
        private void about_btn_Click(object sender, EventArgs e)
        {
            about.Show();
            about.Focus();
        }

        private void technikchat_btn_Click(object sender, EventArgs e)
        {
            Chat.Show();
            Chat.Focus();
        }

        private void email_btn_Click(object sender, EventArgs e)
        {
            mails.Show();
            mails.Focus();
            email_btn.BackColor = SystemColors.Control;
        }

        private void Highscore_btn_Click(object sender, EventArgs e)
        {
            if (connectionAvailable)
            {
                highscore.HighscoreEintragen_panel.Visible = false;
                highscore.Show();
                highscore.Focus();
            }
            else
                MessageBox.Show("Es konnte keine Serververbindung hergestellt werden. Die Highscore ist deaktiviert. Bitte prüfen Sie Ihre Internetverbindung oder versuchen Sie es später erneut. Sollte dieses Problem andauern, besuchen Sie bitte die Supportwebsite unter http://www-FSSNET-N.de.",
                                "Verbindungsfehler",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
        }

        private void finance_btn_Click(object sender, EventArgs e)
        {
            finanzen.Show();
            finanzen.Focus();
        }

        private void schaltplan_btn_Click(object sender, EventArgs e)
        {
            schaltplan.Show();
            schaltplan.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hyperep.Show();
            hyperep.Focus();
        }
        #endregion 

        private void kuhlwassertimer_Tick(object sender, EventArgs e)
        {
            if (waterbox.Value >= 1 && !Statics.Fueling)    //Kühlwasserstand nimmt, Pumpenleistungsabhängig, ab
            {
                if (Statics.P1l + Statics.P2l + Statics.Epl > 0 && Statics.P1l + Statics.P2l + Statics.Epl <= 100)
                    waterbox.Value--;
                if (Statics.P1l + Statics.P2l + Statics.Epl > 100 && Statics.P1l + Statics.P2l + Statics.Epl <= 200)
                    waterbox.Value -= 2;
                if (Statics.P1l + Statics.P2l + Statics.Epl > 200 && Statics.P1l + Statics.P2l + Statics.Epl <= 300)
                    waterbox.Value -= 3;
            }
            if (Statics.Fueling)
            {
                if (!schaltplan.kuhlwassernachfullpumpe_ein_btn.Checked || Statics.KuhlwasserNachfullPumpeError)
                {
                    if (Statics.P1l + Statics.P2l + Statics.Epl > 0 && Statics.P1l + Statics.P2l + Statics.Epl <= 100)
                        waterbox.Value--;
                    if (Statics.P1l + Statics.P2l + Statics.Epl > 100 && Statics.P1l + Statics.P2l + Statics.Epl <= 200)
                        waterbox.Value -= 2;
                    if (Statics.P1l + Statics.P2l + Statics.Epl > 200 && Statics.P1l + Statics.P2l + Statics.Epl <= 300)
                        waterbox.Value -= 3;
                }
                if (!Statics.KuhlwasserNachfullPumpeError && schaltplan.kuhlwassernachfullpumpe_ein_btn.Checked)
                {
                    kuhlwassertimer.Interval = 500;
                    if (waterbox.Value < 100)
                        waterbox.Value++;
                    else
                    {
                        kuhlwassertimer.Interval = 2000;
                        Statics.Fueling = false;
                        button2.Enabled = true;
                        wassernachfullen_status.Visible = false;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)  //Waterbox füllen
        {
            Statics.Fueling = true;
            wassernachfullen_status.Visible = true;
            button2.Enabled = false;
        }

        private void ein_sekundengeber_Tick(object sender, EventArgs e)
        {
            #region laufende Kosten anzeigen
            laufendeKosten_display.Number = (float)(laufendeKosten * 100);
            #endregion

            #region Alarmsound
            if (emergency)  //Wenn SCRAM -> Alarm abspielen
            {
                if (alarmplayer.status == "Bereit" || alarmplayer.status == "Beendet")
                    alarmplayer.play(); 
            }
            else
                alarmplayer.stop();
            #endregion 

            #region RepStopp
            if (Statics.RepStopp)   //Wenn Jim zurückgerufen wurde, bis er da ist -> Reparaturstatus zurücksetzen
            {
                rep_steuerstab.Enabled = false;
                rep_pumpe1.Enabled = false;
                rep_pumpe2.Enabled = false;
                rep_ersatzpumpe.Enabled = false;

                p1_technik_timeleft.Visible = false;
                p1_technikerstatus.Visible = false;

                p2_technik_timeleft.Visible = false;
                p2_technikerstatus.Visible = false;

                ep_technik_timeleft.Visible = false;
                ep_technikerstatus.Visible = false;

                steuerstab_reperaturdauer_label.Visible = false;
                steuerstab_reperaturstatus_label.Visible = false;

                repairsteuerstab_btn.Enabled = true;
                p1_technikrufen_btn.Enabled = true;
                p2_technikrufen_btn.Enabled = true;
                ep_technikrufen_btn.Enabled = true;
            }
            #endregion 

            #region Splashscreen
            if (!this.Enabled)
            {
                Loginscreen splashscreen = new Loginscreen();
                splashscreen.ShowDialog();
                this.Enabled = true;
            }
            #endregion

            #region Zu wenig Leistung-EndGame
            if (Statics.Istleistung < Statics.Demandleistung)
                Statics.NichtErbrachteLeistung += (Statics.Demandleistung - (int)Statics.Istleistung);
            if (Statics.NichtErbrachteLeistung >= 1000000)
                EndGame("Gelieferte Leistung weit unter benötigter Leistung");
            #endregion

            #region TemperaturSCRAM
            int tmptemp = 0;
            if (Statics.Eventname == "Kontrollkomission")
                tmptemp = 1550;
            else
                tmptemp = 1700;
            if (Statics.Temperatur > tmptemp && !emergency)
            {
                EMails.SCRAMcounter++;
                SCRAMcommenced();
                mails.mailliste.Items.Add("SCRAM");
                mails.mailliste.Items.Add("PowerComES-SCRAM");
                mails.mailliste.Items.Add("SCRAM-Alert(IAEO)");
            }
            #endregion

            #region Benötigte Leistung und Preis / Gewinn

            #region Preis
            Random rnd = new Random();
            int i = rnd.Next(1, 50);
            if (i == 2)
            {
                i = rnd.Next(400, 700);
                Statics.Mwpreis = i;
            }
            mwpreis_anzeige.Number = (float)Statics.Mwpreis;
            #endregion

            #region Leistung
            if (Statics.Event)
            {
                if (Statics.Eventname == "Kontrollkomission")
                {
                    if (Statics.EventBegin <= 2)
                        Statics.Demandleistung = 1300;
                    else
                    {
                        i = rnd.Next(1, 5);
                        if (i == 2)
                        {
                            i = rnd.Next(-200, 200);
                            int tmp = Statics.Demandleistung + i;
                            if (tmp <= 1500 && tmp > 50)
                                Statics.Demandleistung += i;
                            demandleistung_display.Number = (float)Statics.Demandleistung;
                        }
                    }
                }
                else
                    if (Statics.Eventname == "Untersuchung")
                    {
                        i = rnd.Next(1, 5);
                        if (i == 2)
                        {
                            i = rnd.Next(-200, 200);
                            int tmp = Statics.Demandleistung + i;
                            if (tmp <= 1500 && tmp > 50)
                                Statics.Demandleistung += i;
                            demandleistung_display.Number = (float)Statics.Demandleistung;
                        }
                    }
                    else
                        Statics.Demandleistung = 0;
                demandleistung_display.Number = (float)Statics.Demandleistung;
            }
            else
            {
                i = rnd.Next(1, 5);
                if (i == 2)
                {
                    i = rnd.Next(-200, 200);
                    int tmp = Statics.Demandleistung + i;
                    if (tmp <= 1500 && tmp > 50)
                        Statics.Demandleistung += i;
                    demandleistung_display.Number = (float)Statics.Demandleistung;
                }
            }

            #endregion

            #region Gewinn

            if (Statics.Istleistung <= Statics.Demandleistung)
            {
                decimal tmpmoney = (((decimal)Statics.Istleistung / (decimal)System.Math.Pow(60, 2)) * (decimal)Statics.Mwpreis) / 100;
                Statics.Guthaben += (tmpmoney - (decimal)laufendeKosten);
            }
            else
            {
                decimal tmpmoney = (((decimal)Statics.Demandleistung / (decimal)System.Math.Pow(60, 2)) * (decimal)Statics.Mwpreis) / 100;
                if (tmpmoney > 0)
                    Statics.Guthaben += (tmpmoney - (decimal)laufendeKosten);
            }
            moneycounter.Value = (long)Statics.Guthaben;

            #endregion

            #endregion

            #region Pumpenbilder

            #region Pumpe 1
            if (Statics.Pumpe1_working && !pumpe1_aus_btn.Checked)
            {
                if (p1imagecounter == 0)
                {
                    p1imagecounter++;
                    p1_picturebox.Image = AKW_Simulator.Properties.Resources.pumpeworkingfinal1;
                }
                else
                {
                    p1imagecounter--;
                    p1_picturebox.Image = AKW_Simulator.Properties.Resources.pumpeworkingfinal2;
                }
            }
            else
            {
                if (Statics.Pumpe1_working && pumpe1_aus_btn.Checked)
                    p1_picturebox.Image = AKW_Simulator.Properties.Resources.pumpedisabled;

                if (!Statics.Pumpe1_working)
                {
                    if (p1imagecounter == 0)
                    {
                        p1_picturebox.Image = AKW_Simulator.Properties.Resources.pumpefailurefinal;
                        p1imagecounter++;
                    }
                    else
                    {
                        p1imagecounter--;
                        p1_picturebox.Image = AKW_Simulator.Properties.Resources.pumpeworkingfinal1;
                    }
                }
            }
            #endregion

            #region Pumpe 2
            if (Statics.Pumpe2_working && !pumpe2_aus_btn.Checked)
            {
                if (p2imagecounter == 0)
                {
                    p2imagecounter++;
                    p2_picturebox.Image = AKW_Simulator.Properties.Resources.pumpeworkingfinal1;
                }
                else
                {
                    p2imagecounter--;
                    p2_picturebox.Image = AKW_Simulator.Properties.Resources.pumpeworkingfinal2;
                }
            }
            else
            {
                if (Statics.Pumpe2_working && pumpe2_aus_btn.Checked)
                    p2_picturebox.Image = AKW_Simulator.Properties.Resources.pumpedisabled;

                if (!Statics.Pumpe2_working)
                {
                    if (p2imagecounter == 0)
                    {
                        p2_picturebox.Image = AKW_Simulator.Properties.Resources.pumpefailurefinal;
                        p2imagecounter++;
                    }
                    else
                    {
                        p2imagecounter--;
                        p2_picturebox.Image = AKW_Simulator.Properties.Resources.pumpeworkingfinal1;
                    }
                }
            }
            #endregion

            #region Ersatzpumpe
            if (Statics.Ersatzpumpe_working && !ersatzpumpe_aus_btn.Checked)
            {
                if (epimagecounter == 0)
                {
                    epimagecounter++;
                    ep_picturebox.Image = AKW_Simulator.Properties.Resources.pumpeworkingfinal1;
                }
                else
                {
                    epimagecounter--;
                    ep_picturebox.Image = AKW_Simulator.Properties.Resources.pumpeworkingfinal2;
                }
            }
            else
            {
                if (Statics.Ersatzpumpe_working && ersatzpumpe_aus_btn.Checked)
                    ep_picturebox.Image = AKW_Simulator.Properties.Resources.pumpedisabled;

                if (!Statics.Ersatzpumpe_working)
                {
                    if (epimagecounter == 0)
                    {
                        ep_picturebox.Image = AKW_Simulator.Properties.Resources.pumpefailurefinal;
                        epimagecounter++;
                    }
                    else
                    {
                        epimagecounter--;
                        ep_picturebox.Image = AKW_Simulator.Properties.Resources.pumpeworkingfinal1;
                    }
                }
            }
            #endregion

            #endregion

            #region Mails

            #region Jim-Bonus Mails
            if (EMails.JimBonusBekommen)    //Wenn Jim in letzter Zeit einen Bonus bekommen hat..
            {
                EMails.JimBonusBekommen = false;
                if (Statics.GeldMail < 3)
                {
                    Statics.GeldMail++;
                    Statics.Mailreceivetime[(Statics.GeldMail + 10)] = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    mailplayer.play();
                    switch (Statics.GeldMail)
                    {
                        case 1:
                            mails.mailliste.Items.Add("War da nicht mehr?");    //Mail erzeugen
                            break;

                        case 2:
                            mails.mailliste.Items.Add("Ich könnte schwören.."); //Mail erzeugen
                            break;

                        case 3:
                            mails.mailliste.Items.Add("Wo ist das hin?");   //Mail erzeugen
                            break;
                    }
                    email_btn.BackColor = Color.CadetBlue;
                }
            }
            #endregion 

            #region Privatmails
            int v = rnd.Next(1, 100);   //Zufallszahl generieren, die entscheidet, ob eine Spam-Mail eintreffen soll
            if (v == 25)
            {
                int l = rnd.Next(0, 10);
                string tmpstring = "";
                switch (l)
                {
                    case 1:
                        tmpstring = "Wann kommst du?";
                        break;

                    case 2:
                        tmpstring = "Essen";
                        break;

                    case 3:
                        tmpstring = "Einkaufen";
                        break;

                    case 4:
                        tmpstring = "Alle";
                        break;

                    case 5:
                        tmpstring = "Cheap Viagra";
                        break;

                    case 6:
                        tmpstring = "Best Viagra";
                        break;

                    case 7:
                        tmpstring = "Legal Viagra";
                        break;

                    case 8:
                        tmpstring = "FalconLines";
                        break;

                    case 9:
                        tmpstring = "Rente";
                        break;

                    case 10:
                        tmpstring = "TPG";
                        break;

                    case 0:
                        tmpstring = "Post";
                        break;
                }
                if (!mails.mailliste.Items.Contains(tmpstring)) //Nur neue Mail generieren, wenn die gleiche nicht schon vorhanden ist
                {
                    mails.mailliste.Items.Add(tmpstring);
                    mailplayer.play();
                    Statics.Mailreceivetime[l] = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    email_btn.BackColor = Color.CadetBlue;
                }
            }
            #endregion

            #endregion

            #region Steuerstabfehler generieren
            if (!Statics.Steuerstaberror)
            {
                int steuerstabfehlerrandom = rnd.Next(1, 1300);
                if (steuerstabfehlerrandom == 2)
                {
                    componentfailplayer.play();
                    steuerstab_trackbar.Enabled = false;
                    Statics.Steuerstaberror = true;
                    Steuerstab_statuslabel.ForeColor = Color.Red;
                    Steuerstab_statuslabel.Text = "Fehler!";
                    repairsteuerstab_btn.Visible = true;
                }
            }

            #endregion

            #region Schaltplan
            if (!Statics.Pumpe1_working || !Statics.Pumpe2_working || !Statics.Ersatzpumpe_working) //Bilder auf dem Schaltplan anzeigen
                schaltplan.Kuhlwasserpumpe_fehler_label.Visible = true;
            else
                schaltplan.Kuhlwasserpumpe_fehler_label.Visible = false;

            if (Statics.Steuerstaberror)
                schaltplan.steuerstaberror_label.Visible = true;
            else
                schaltplan.steuerstaberror_label.Visible = false;

            if (Statics.GeneratorError || Statics.KuhlwasserNachfullPumpeError || Statics.TurbineError)
                schaltplan_btn.BackColor = Color.Red;
            else
            {
                schaltplan_btn.BackColor = SystemColors.Control;
            }

            #endregion

            #region ConnectionRefresh
            backgroundworkerHelper++;
            if (backgroundworkerHelper == 20)   //überprüft intervallartig, ob eine Serververbindung besteht
            {
                backgroundWorker.RunWorkerAsync();
                backgroundworkerHelper = 0;
            }
            #endregion

            #region Events
            #region Event generieren
            if (!Statics.Event)
            {
                i = rnd.Next(1, 400); //Zufallszahl, die bestimmt, ob ein Event gestartet wird
                switch (i)
                {
                    case 2:
                        Statics.Event = true;
                        Statics.Eventname = "Kontrollkomission";
                        Statics.Mailreceivetime[17] = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                        Statics.EventBegin = rnd.Next(63, 80);  //Dauer bis zum Beginn des Events
                        Statics.EventDauer = rnd.Next(58, 72);  //dauer des Events
                        break;

                    case 3:
                        Statics.Event = true;
                        Statics.Eventname = "Demonstration";
                        Statics.Mailreceivetime[15] = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                        Statics.EventBegin = rnd.Next(20, 40);
                        Statics.EventDauer = rnd.Next(50, 80);
                        break;

                    case 4:
                        Statics.Event = true;
                        Statics.Eventname = "Anschlag";
                        Statics.Mailreceivetime[16] = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                        Statics.EventBegin = rnd.Next(12, 22);
                        Statics.EventDauer = rnd.Next(30, 45);
                        break;

                    case 5:
                        Statics.Event = true;
                        Statics.Eventname = "Untersuchung";
                        Statics.Mailreceivetime[18] = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                        Statics.EventBegin = rnd.Next(50, 81);
                        Statics.EventDauer = rnd.Next(41, 58);

                        break;

                    case 6:
                        if (!Statics.GeneratorError && schaltplan.generator_ein_btn.Checked)    //Wenn der Generator nicht defekt und eingeschaltet ist, kann die Synchronisation gestartet werdem
                        {
                            Statics.Event = true;
                            Statics.Eventname = "Synchronisieren";
                            Statics.Mailreceivetime[14] = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                            Statics.EventBegin = rnd.Next(3, 7);
                            Statics.EventDauer = rnd.Next(20, 30);
                        }
                        break;

                    case 8:
                        Statics.Event = true;
                        Statics.Eventname = "Erdbeben";
                        Statics.Mailreceivetime[20] = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                        Statics.EventBegin = rnd.Next(20, 30);
                        Statics.EventDauer = rnd.Next(40, 50);
                        break;
                }
                if (Statics.Event)  //Wenn ein Event stattfindet -> anzeigen etc
                {
                    currentEvent_label.Text = Statics.Eventname;
                    mails.mailliste.Items.Add(Statics.Eventname);
                    mailplayer.play();
                    Statics.EventdauerFix = Statics.EventDauer;
                    Statics.Eventleistung = 0;
                    Eventname_label.Text = Statics.Eventname;
                    Eventname_label.Visible = true;
                }
                else
                {
                    currentEvent_label.Text = "keine";
                    Eventname_label.Visible = false;
                }
            }
            #endregion

            #region Eventlogik
            else
            {
                switch (Statics.Eventname)
                {
                    #region Kontrollkomission
                    case "Kontrollkomission":
                        if (Statics.EventBegin > 0) //Wenn das Event noch nicht begonnen hat -> dauer bis zum Beginn verringern
                        {
                            currentEvent_label.Text = "Kontrollkomission kommt an in: " + Statics.EventBegin.ToString() + " Sek.";
                            Statics.EventBegin--;
                        }
                        else
                        {
                            if (Statics.EventDauer > 0) //Wenn das Event begonnen hat -> Eventdauer verringern
                            {
                                if (emergency)
                                    EndGame("SCRAM während dem Besuch der Kontrollkomission");
                                currentEvent_label.Text = "Untersuchungen beendet in: " + Statics.EventDauer.ToString() + " Sek.";
                                Statics.EventDauer--;
                                Statics.Eventleistung += (int)Statics.Istleistung;
                            }
                            else     //Wenn das Event vorbei ist -> zurücksetzen
                            {
                                currentEvent_label.Text = "keine";
                                Statics.Eventname = "";
                                Statics.Event = false;
                                if (Statics.Eventleistung < ((Statics.EventdauerFix * 1300) - 5000))
                                    EndGame("Zu wenig Leistung im Test gebracht.");
                            }
                        }
                        break;
                    #endregion

                    #region Demonstration
                    case "Demonstration":   //gleiches Schema wie bei Kontrollkomission
                        if (Statics.EventBegin > 0)
                        {
                            currentEvent_label.Text = "Demonstartion beginnt in: " + Statics.EventBegin.ToString() + " Sek.";
                            Statics.EventBegin--;
                        }
                        else
                        {
                            if (Statics.EventDauer > 0)
                            {
                                if (emergency)
                                    EndGame("SCRAM während der Demonstration");

                                currentEvent_label.Text = "Demonstration läuft..";
                                Statics.EventDauer--;
                                Statics.Eventleistung += (int)Statics.Istleistung;
                            }
                            else
                            {
                                currentEvent_label.Text = "keine";
                                Statics.Eventname = "";
                                Statics.Event = false;
                                if (Statics.Eventleistung > 20000)
                                {
                                    mails.mailliste.Items.Add("Leistung-Demo");
                                    Statics.Mailreceivetime[19] = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                                }
                            }
                        }
                        break;
                    #endregion

                    #region Anschlag
                    case "Anschlag":    //gleiches Schema wie bei Kontrollkomission
                        if (Statics.EventBegin > 0)
                        {
                            currentEvent_label.Text = "Polizei kommt an in: " + Statics.EventBegin.ToString() + " Sek.";
                            Statics.EventBegin--;
                            Statics.Eventleistung += (int)Statics.Leistung;
                        }
                        else
                        {
                            if (Statics.EventDauer > 0)
                            {
                                currentEvent_label.Text = "Polizeiuntersuchung beendet in " + Statics.EventDauer.ToString() + " Sek.";
                                Statics.EventDauer--;
                                Statics.Eventleistung += (int)Statics.Leistung;
                            }
                            else
                            {
                                currentEvent_label.Text = "keine";
                                Statics.Eventname = "";
                                Statics.Event = false;
                                if (Statics.Eventleistung > 5000)
                                    EndGame("Reaktor bei potentiellem Anschlag nicht schnell genug heruntergefahren");
                            }
                        }
                        break;
                    #endregion

                    #region Umwelt-Inspektion
                    case "Untersuchung":    //gleiches Schema wie bei Kontrollkomission
                        if (Statics.EventBegin > 0)
                        {
                            currentEvent_label.Text = "Komission kommt an in: " + Statics.EventBegin.ToString() + " Sek.";
                            Statics.EventBegin--;
                        }
                        else
                        {
                            if (Statics.EventDauer > 0)
                            {
                                if (emergency)
                                    EndGame("SCRAM während dem Besuch der Kontrollkomission");
                                currentEvent_label.Text = "Inspektion beendet in " + Statics.EventDauer.ToString() + " Sek.";
                                Statics.EventDauer--;
                            }
                            else
                            {
                                currentEvent_label.Text = "keine";
                                Statics.Eventname = "";
                                Statics.Event = false;
                            }
                        }
                        break;
                    #endregion

                    #region Syncrosisieren
                    case "Synchronisieren": //gleiches Schema wie bei Kontrollkomission
                        if (Statics.EventBegin > 0)
                        {
                            currentEvent_label.Text = "Synchronisation beginnt in " + Statics.EventBegin.ToString() + " Sek.";
                            Statics.EventBegin--;
                        }
                        else
                        {
                            if (Statics.EventDauer > 0)
                            {
                                currentEvent_label.Text = "Synchronisation abgeschlossen in " + Statics.EventDauer.ToString() + " Sek.";
                                Statics.EventDauer--;
                            }
                            else
                            {
                                currentEvent_label.Text = "keine";
                                Statics.Eventname = "";
                                Statics.Event = false;
                            }
                        }
                        break;
                    #endregion

                    #region Erdbeben
                    case "Erdbeben":    //gleiches Schema wie bei Kontrollkomission
                        if (Statics.EventBegin > 0)
                        {
                            currentEvent_label.Text = "Sicherheitsprüfer kommen an in " + Statics.EventBegin.ToString() + " " + " Sek.";
                            Statics.EventBegin--;
                            Statics.Eventleistung += (int)Statics.Leistung;
                        }
                        else
                        {
                            if (Statics.EventDauer > 0)
                            {
                                currentEvent_label.Text = "Sicherheitsinspektionen beendet in " + Statics.EventDauer.ToString() + " Sek.";
                                Statics.EventDauer--;
                                Statics.Eventleistung += (int)Statics.Leistung;
                            }
                            else
                            {
                                currentEvent_label.Text = "keine";
                                Statics.Eventname = "";
                                Statics.Event = false;
                                if (Statics.Eventleistung > 5000)
                                    EndGame("Reaktor bei potentiellen Erdbebenschäden nicht rechtzeitig heruntergefahren");
                            }
                        }
                        break;
                    #endregion
                }
            }
            #endregion
            #endregion 
        }

        private void news_btn_Click(object sender, EventArgs e)
        {
            if (connectionAvailable)    //Wenn eine Verbindung zum Server besteht -> News anzeigen
            {
                newswindow.Show();
                newswindow.Focus();
            }
            else
                MessageBox.Show("Es konnte keine Verbindung zum Server hergestellt werden. Bitte prüfen Sie Ihre Internetverbindung oder versuchen Sie es später erneut. Falls dieses Problem andauert, kontaktieren Sie bitte den Autor.\n\nVielen Dank",
                                "Verbindungsfehler",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(500);
            connectionAvailable = Statics.ConnectionAvailable();    //Prüfen, ob eine Verbindung zum Server besteht
            if (Statics.pause)  //Wenn das Spiel pausiert ist -> im Backgroundthread das Pausen-Fenster anzeigen
            {
                Pause_dialog pd = new Pause_dialog();
                if (pd.ShowDialog() == DialogResult.OK)
                    Statics.pause = false;
            }
        }

        #region Chatmeldungen Jim
        internal static void ExternMachtSchon() //Meldungen, die Jim im Chat ausgibt
        {
            Chat.chatbox.AppendText(DateTime.Now.ToShortTimeString() + ": Jim: Die Externe Firma ist schon auf dem Weg dahin!\n");
        }
        internal static void ExternAnnouncement()
        {
            Chat.chatbox.AppendText(DateTime.Now.ToShortTimeString() + ": Jim: Die Externe Firma kommt gleich an.\n");
        }
        internal static void ExternBegin()
        {
            Chat.chatbox.AppendText(DateTime.Now.ToShortTimeString() + ": Jim: Die Externe Firma fängt jetzt mit den Reparaturen an.\n");
        }
        internal static void ExternFertig()
        {
            Chat.chatbox.AppendText(DateTime.Now.ToShortTimeString() + ": Jim: Die Externe Firma hat die Reparaturen abgeschlossen.\n");
        }
        internal static void JimBusy()
        {
            Chat.chatbox.AppendText(DateTime.Now.ToShortTimeString() + ": Jim: Ich hab' schon was zu tun!\n");
        }

        internal static void JimWarGeradeDa()
        {
            Chat.chatbox.AppendText(DateTime.Now.ToShortTimeString() + ": Jim: Man, bei dem Ding war ich doch gerade erst!\n");
        }

        internal static void JimGehtLos(string ort)
        {
            Chat.chatbox.AppendText(DateTime.Now.ToShortTimeString() + ": Jim: Ich mach' mich auf den Weg zu " + ort + "\n");
        }

        internal static void JimIstFertig(string ort)
        {
            Chat.chatbox.AppendText(DateTime.Now.ToShortTimeString() + ": Jim: Reparaturen an " + ort + " abgeschlossen!\n");
        }

        internal static void JimFangtAn(string ort)
        {
            Chat.chatbox.AppendText(DateTime.Now.ToShortTimeString() + ": Jim: Ich fang' jetzt mit den Reparaturen an " + ort + " an.\n");
        }

        internal static void JimWartet(string ort)
        {
            Chat.chatbox.AppendText(DateTime.Now.ToShortTimeString() + ": Jim: " + ort + " muss erst heruntergefahren werden, bevor ich mit den Reparaturen anfangen kann!\n");
        }

        internal static void NichtsZuTun()
        {
            Chat.chatbox.AppendText(DateTime.Now.ToShortTimeString() + ": Jim: Da gibt nichts zu tun.\n");
        }
        internal static void JimKommtZuruck()
        {
            Chat.chatbox.AppendText(DateTime.Now.ToShortTimeString() + ": Jim: Ok, ich komme zurück.\n");
        }
        internal static void JimIstNichtWeg()
        {
            Chat.chatbox.AppendText(DateTime.Now.ToShortTimeString() + ": Jim: Ich kann nicht zurückkommen, weil ich nicht weg bin!\n");
        }
        internal static void JimRepariertFertig()
        {
            Chat.chatbox.AppendText(DateTime.Now.ToShortTimeString() + ": Jim: Ich Reparier das hier erst noch zu Ende und komme dann wieder.\n");
        }
        internal static void JimIstAufRuckweg()
        {
            Chat.chatbox.AppendText(DateTime.Now.ToShortTimeString() + ": Jim: Ich bin noch auf'm Rückweg!\n");
        }
        #endregion

        #region Pause
        private void Pause_btn_Click(object sender, EventArgs e)
        {
            Statics.pause = true;   //Spiel pausieren
            backgroundWorker.RunWorkerAsync();
            while (Statics.pause)
            {
                Thread.Sleep(500);
            }
        }
        #endregion
        #endregion

        #region SCRAM
        private void emergencyend_btn_Click(object sender, EventArgs e)
        {
            if (emergencyunlock_txtbx.Text != string.Empty)   //Wenn eine Eingabe gemacht wurde..
            {
                bool gultig = Regex.IsMatch(emergencyunlock_txtbx.Text, "[a-zA-Z]");    //auf ungültige Zeichen prüfen
                if (gultig)
                {
                    pwcheck_timer.Enabled = true;
                    pwcheck_label.Text = "Überprüfung läuft..";
                    pwcheck_label.Visible = true;
                    emergencyunlock_txtbx.ReadOnly = true;
                }
                else
                    pwcheck_label.Text = "ungültiges Zeichen!";
            }
            else
                pwcheck_label.Text = "Bitte Eingabe machen";
        }

        private void pwcheck_timer_Tick(object sender, EventArgs e)     //Überprüfung simulieren
        {
            pwcheck_timer.Enabled = false;
            if (emergencyunlock_txtbx.Text == Statics.Currentpw)    //Wenn das Passwort stimmt -> SCRAM beenden
            {
                emergency = false;
                pwcheck_label.Visible = false;
                emergencyreset_panel.Visible = false;
                pwcheck_label.Text = "";
                notaus_btn.Enabled = true;
            }
            else
                pwcheck_label.Text = "falsches Passwort!";

            emergencyunlock_txtbx.ReadOnly = false;
            emergencyunlock_txtbx.Clear();
        }

        private void notaus_btn_Click(object sender, EventArgs e)
        {
            EMails.SCRAMcounter++;  //Nummer des SCRAMs festlegen
            SCRAMcommenced();   //Methode zum beginnen des Alarms aufrufen
            mails.mailliste.Items.Add("SCRAM"); //eMails generieren
            mails.mailliste.Items.Add("PowerComES-SCRAM");
            mails.mailliste.Items.Add("SCRAM-Alert(IAEO)");
            this.email_btn.BackColor = Color.CadetBlue;
        }

        private void SCRAMcommenced()
        {
            if (EMails.SCRAMcounter <= 3)
            {
                if (!emergency) //Wenn kein Notfall besteht -> Notfall generieren
                {
                    if (!Statics.KuhlwasserNachfullPumpeError)  //Wenn die Kühlwassernachfüllpumpe nicht defekt ist -> Kühlwasser nachfüllen
                        Statics.Fueling = true;
                    wassernachfullen_status.Visible = true;
                    button2.Enabled = false;
                    waterbox.Value = 2;

                    emergency = true;
                    Statics.Guthaben -= 30;     //Starfe zahlen
                    Statics.Passwordchoose();   //Passwort generieren
                    emergencyreset_panel.Visible = true;

                    if (!Statics.Steuerstaberror)   //Wenn die Komponenten nicht defekt sind -> Steuerung übernehmen
                        steuerstab_trackbar.Value = 15;

                    if (Statics.Pumpe1_working)
                    {
                        pumpe1_ein_btn.Checked = true;
                        p1_trackbar.Value = 6;
                    }
                    if (Statics.Pumpe2_working)
                    {
                        pumpe2_ein_btn.Checked = true;
                        p2_trackbar.Value = 6;
                    }
                    if (Statics.Ersatzpumpe_working)
                    {
                        ersatzpumpe_ein_btn.Checked = true;
                        ep_trackbar.Value = 6;
                    }
                    AKW_status.Text = "Notaus!";
                    Statics.SCRAMTime[EMails.SCRAMcounter - 1] = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString(); //Empfangszeit der SCRAM-Mails festlegen
                }
            }
        }
        #endregion 

        #region Pumpenfehler generieren
        private void pumpe1_fehlertimer_Tick(object sender, EventArgs e)    //generiert Fehler für Pumpe 1
        {
            int i = 0;
            Random rnd = new Random();
            if(Statics.P1l > 0 && Statics.P1l <=33) //Pumpenausfallwahrscheinlichkeit je nach Leistung festlegen
                i = rnd.Next(1, 180);
            if (Statics.P1l > 33 && Statics.P1l <= 66)
                i = rnd.Next(1, 160);
            if (Statics.P1l > 66 && Statics.P1l <= 100)
                i = rnd.Next(1, 140);
            if (i == 9)     //Wenn Pumpendefekt generiert wurde -> Werte, label, etc setzen
            {
                componentfailplayer.play();
                pumpe1_statustimer.Enabled = false;
                pumpe1_fehlertimer.Enabled = false;
                pumpe1_randomizer.Enabled = false;
                Statics.Pumpe1_working = false;
                Statics.P1l = 0;
                pumpe1_leistung.Text = Statics.P1l.ToString() + "%";
                pumpe1_status.Text = "Fehler!";
                AKW_status.Text = "Kühlwasserpumpenfehler!";
                pumpe1_status.ForeColor = pumpefailure_color;
                Chat.chatbox.AppendText(DateTime.Now.ToShortTimeString() + ": Jim: Ich glaub' irgendwas ist mit den Kühlwasserpumpen..\n");
                pumpe1_progressbar.Value = 0;
            }
        }    

        private void pumpe2_fehlertimer_Tick(object sender, EventArgs e)    //gleiches Schema wie bei Pumpe 1
        {
            int i = 0;
            Random rnd = new Random();
            if (Statics.P2l > 0 && Statics.P2l <= 33)
                i = rnd.Next(1, 200);
            if (Statics.P2l > 33 && Statics.P2l <= 66)
                i = rnd.Next(1, 180);
            if (Statics.P2l > 66 && Statics.P2l <= 100)
                i = rnd.Next(1, 170);
            if (i == 9)
            {
                componentfailplayer.play();
                pumpe2_statustimer.Enabled = false;
                pumpe2_fehlertimer.Enabled = false;
                pumpe2_randomizer.Enabled = false;
                Statics.Pumpe2_working = false;
                Statics.P2l = 0;
                pumpe2_leistung.Text = Statics.P2l.ToString() + "%";
                pumpe2_status.Text = "Fehler!";
                AKW_status.Text = "Kühlwasserpumpenfehler!";
                pumpe2_status.ForeColor = pumpefailure_color;
                Chat.chatbox.AppendText(DateTime.Now.ToShortTimeString() + ": Jim: Ich glaub' irgendwas ist mit den Kühlwasserpumpen..\n");
                pumpe2_progressbar.Value = 0;
            }
        }

        private void ersatzpumpe_fehlertimer_Tick(object sender, EventArgs e)   //gleiches Schema wie bei Pumpe 1
        {
            int i = 0;
            Random rnd = new Random();
            if (Statics.Epl > 0 && Statics.Epl <= 33)
                i = rnd.Next(1,250);
            if (Statics.Epl > 33 && Statics.Epl <= 66)
                i = rnd.Next(1, 220);
            if (Statics.Epl > 66 && Statics.Epl <= 100)
                i = rnd.Next(1, 180);
            if (i == 9)
            {
                componentfailplayer.play();
                ersatzpumpe_statustimer.Enabled = false;
                ersatzpumpe_fehlertimer.Enabled = false;
                ersatzpumpe_randomizer.Enabled = false;
                Statics.Ersatzpumpe_working = false;
                Statics.Epl = 0;
                ersatzpumpe_leistung.Text = Statics.Epl.ToString() + "%";
                ersatzpumpe_status.Text = "Fehler!";
                AKW_status.Text = "Kühlwasserpumpenfehler!";
                ersatzpumpe_status.ForeColor = pumpefailure_color;
                Chat.chatbox.AppendText(DateTime.Now.ToShortTimeString() + ": Jim: Ich glaub' irgendwas ist mit den Kühlwasserpumpen..\n");
                ersatzpumpe_progressbar.Value = 0;
            }
        }
        #endregion 

        #region Reparatur

        #region Pumpe 1 reparieren
        private void button3_Click(object sender, EventArgs e)
        {
            if (Statics.externComponentToRep[4])    //Wenn HypeRep die Komponente schon repariert, sagt Jim das an
                hauptfenster.ExternMachtSchon();
            else
            {
                if (!Statics.RepStopp)  //Wenn Jim nicht gerade zurückgerufen wird, kann die Reparatur beginnen
                {
                    try
                    {
                        Chat.Show();
                    }
                    catch (Exception)
                    {
                        Chat.Focus();
                    }
                    if (!Statics.Technikoccupied && !Statics.Pumpe1_working)    //Wenn Jim nicht beschäftigt ist und die Pumpe defekt ist -> Reparatur beginnen
                    {
                        p1_technikrufen_btn.Enabled = false;
                        Statics.Technikoccupied = true;
                        rep_pumpe1.Enabled = true;
                        Random rnd = new Random();
                        if (!Statics.Mukkibude) //In Abhängigkeit, ob Jim eine Prämie bekommen hat, wird die Reparaturdauer und Ankunftszeit generiert
                            Statics.P1repdauer = rnd.Next(20, 40);
                        else
                            Statics.P1repdauer = rnd.Next(12, 30);
                        if (Statics.Lastreperatur == "pumpe1")
                            JimWarGeradeDa();
                        else
                            JimGehtLos("zur Kühlwasserpumpe 1");

                        if (!Statics.JimTurnschuhe)
                            Statics.P1repweg = 50;
                        else
                            Statics.P1repweg = 35;
                    }
                    else
                    {
                        if (Statics.Technikoccupied)    //Wenn Jim schon etwas zu tun hat oder es nichts zu tun gibt, wird die Situation im Chat ausgegeben.
                            JimBusy();
                        else
                            NichtsZuTun();
                    }
                }
                else
                    JimIstAufRuckweg();
            }
        }       

        private void rep_pumpe1_Tick(object sender, EventArgs e)
        {
            if (Statics.P1repweg == 0 && !Statics.Reparing) //Wenn Jim da ist, aber noch nicht mit der Reparatur angefangen hat, weil die Pumpe noch eingeschaltet ist, gibt er dies aus.
            {
                if (pumpe1_ein_btn.Checked)
                {
                    if (messagerepeat == 0)
                    {
                        JimWartet("Die Kühlwasserpumpe 1");
                        messagerepeat++;
                    }
                }
                else   //ansonsten fängt er mit der Reparatur an
                {
                    JimFangtAn("Kühlwasserpumpe 1");
                    Statics.Reparing = true;
                    pumpe1_ein_btn.Enabled = false;
                    pumpe1_aus_btn.Enabled = false;
                    p1_trackbar.Enabled = false;
                }
            }

            if (Statics.P1repweg > 0)   //Wenn er noch nicht da ist, nimmt seine Ankunftszeit ab.
            {
                p1_technik_timeleft.Text = Statics.P1repweg.ToString() + " Sekunden";
                p1_technikerstatus.Text = "Techniker kommt an in:";
                p1_technikerstatus.Visible = true;
                p1_technik_timeleft.Visible = true;
                Statics.P1repweg--;
            }
            else
            {
                if (Statics.Reparing)   //Wenn er bei der Reparatur ist, nimmt Reparaturzeit ab.
                {
                    p1_technik_timeleft.Text = Statics.P1repdauer.ToString() + " Sekunden";
                    p1_technikerstatus.Text = "Reparaturen beendet in:";
                    Statics.P1repdauer--;
                }
                else
                {
                    p1_technikerstatus.Text = "Techniker wartet auf Interaktion..";
                    p1_technik_timeleft.Text = "";
                }
            }
            if (Statics.P1repweg == 0 && Statics.P1repdauer == 0)   //Wenn die Reparatur beendet ist, werden die Werte wieder zurückgesetzt
            {
                rep_pumpe1.Enabled = false;
                p1_technik_timeleft.Visible = false;
                p1_technikerstatus.Visible = false;
                Statics.Reparing = false;
                JimIstFertig("Kühlwasserpumpe 1");

                pumpe1_statustimer.Enabled = true;
                Statics.Pumpe1_working = true;
                if (Statics.Pumpe1_working)
                    pumpe1_fehlertimer.Enabled = true;
                pumpe1_status.ForeColor = pumpedisabled_color;
                if (pumpe1_ein_btn.Checked)
                    pumpe1_status.Text = "In Betrieb";
                else
                    pumpe1_status.Text = "Außer Betrieb";
                p1_technikrufen_btn.Enabled = true;
                Statics.Technikoccupied = false;
                pumpe1_ein_btn.Enabled = true;
                pumpe1_aus_btn.Enabled = true;
                p1_trackbar.Enabled = true;
                messagerepeat = 0;
                Statics.Lastreperatur = "pumpe1";
            }
        }
        #endregion 

        #region Pumpe 2 reparieren
        private void p2_technikrufen_btn_Click(object sender, EventArgs e)  //gleiches Schema wie Pumpe 1
        {
            if (Statics.externComponentToRep[5])
                hauptfenster.ExternMachtSchon();
            else
            {
                if (!Statics.RepStopp)
                {
                    try
                    {
                        Chat.Show();
                    }
                    catch (Exception)
                    {
                        Chat.Focus();
                    }
                    if (!Statics.Technikoccupied && !Statics.Pumpe2_working)
                    {
                        p2_technikrufen_btn.Enabled = false;
                        Statics.Technikoccupied = true;
                        rep_pumpe2.Enabled = true;
                        Random rnd = new Random();
                        if (!Statics.Mukkibude)
                            Statics.P2repdauer = rnd.Next(15, 35);
                        else
                            Statics.P2repdauer = rnd.Next(11, 28);
                        if (Statics.Lastreperatur == "pumpe2")
                            JimWarGeradeDa();
                        else
                            JimGehtLos("zur Kühlwasserpumpe 2");

                        if (!Statics.JimTurnschuhe)
                            Statics.P2repweg = 80;
                        else
                            Statics.P2repweg = 60;
                    }
                    else
                    {
                        if (Statics.Technikoccupied)
                            JimBusy();
                        else
                            NichtsZuTun();
                    }
                }
                else
                    JimIstAufRuckweg();
            }
        }

        private void rep_pumpe2_Tick(object sender, EventArgs e)    //gleiches Schema wie Pumpe 1
        {
            if (Statics.P2repweg == 0 && !Statics.Reparing)
            {
                if (pumpe2_ein_btn.Checked)
                {
                    if (messagerepeat == 0)
                    {
                        JimWartet("Kühlwasserpumpe 2");
                        messagerepeat++;
                    }
                }
                else
                {
                    JimFangtAn("Kühlwasserpumpe 2");
                    Statics.Reparing = true;
                    pumpe2_ein_btn.Enabled = false;
                    pumpe2_aus_btn.Enabled = false;
                    p2_trackbar.Enabled = false;
                }
            }

            if (Statics.P2repweg > 0)
            {
                p2_technik_timeleft.Text = Statics.P2repweg.ToString() + " Sekunden";
                p2_technikerstatus.Text = "Techniker kommt an in:";
                p2_technikerstatus.Visible = true;
                p2_technik_timeleft.Visible = true;
                Statics.P2repweg--;
            }
            else
            {
                if (Statics.Reparing)
                {
                    p2_technik_timeleft.Text = Statics.P2repdauer.ToString() + " Sekunden";
                    p2_technikerstatus.Text = "Reparaturen beendet in:";
                    Statics.P2repdauer--;
                }
                else
                {
                    p2_technikerstatus.Text = "Techniker wartet auf Interaktion..";
                    p2_technik_timeleft.Text = "";
                }
            }
            if (Statics.P2repweg == 0 && Statics.P2repdauer == 0)
            {
                rep_pumpe2.Enabled = false;
                p2_technik_timeleft.Visible = false;
                p2_technikerstatus.Visible = false;
                Statics.Reparing = false;
                JimIstFertig("Kühlwasserpumpe 2");

                pumpe2_statustimer.Enabled = true;
                Statics.Pumpe2_working = true;
                pumpe2_fehlertimer.Enabled = true;
                if (pumpe2_ein_btn.Checked)
                    pumpe2_status.Text = "In Betrieb";
                else
                    pumpe2_status.Text = "Außer Betrieb";
                pumpe2_status.ForeColor = pumpedisabled_color;
                p2_technikrufen_btn.Enabled = true;
                Statics.Technikoccupied = false;
                pumpe2_aus_btn.Enabled = true;
                pumpe2_ein_btn.Enabled = true;
                p2_trackbar.Enabled = true;
                messagerepeat = 0;
                Statics.Lastreperatur = "pumpe2";
            }
        }
        #endregion 

        #region Ersatzpumpe reparieren
        private void ep_technikrufen_btn_Click(object sender, EventArgs e)  //gleiches Schema wie Pumpe 1
        {
            if (Statics.externComponentToRep[6])
                hauptfenster.ExternMachtSchon();
            else
            {
                if (!Statics.RepStopp)
                {
                    try
                    {
                        Chat.Show();
                    }
                    catch (Exception)
                    {
                        Chat.Focus();
                    }
                    if (!Statics.Technikoccupied && !Statics.Ersatzpumpe_working)   //gleiches Schema wie Pumpe 1
                    {
                        ep_technikrufen_btn.Enabled = false;
                        Statics.Technikoccupied = true;
                        rep_ersatzpumpe.Enabled = true;
                        Random rnd = new Random();
                        if (!Statics.Mukkibude)
                            Statics.Eprepdauer = rnd.Next(20, 40);
                        else
                            Statics.Eprepdauer = rnd.Next(12, 34);
                        if (Statics.Lastreperatur == "ersatzpumpe")
                            JimWarGeradeDa();
                        else
                            JimGehtLos("zur Ersatzkühlwasserpumpe");

                        if (!Statics.JimTurnschuhe)
                            Statics.Eprepweg = 110;
                        else
                            Statics.Eprepweg = 85;
                    }
                    else
                        if (Statics.Technikoccupied)
                            JimBusy();
                        else
                            NichtsZuTun();
                }
                else
                    JimIstAufRuckweg();
            }
        }

        private void rep_ersatzpumpe_Tick(object sender, EventArgs e)
        {
            if (Statics.Eprepweg == 0 && !Statics.Reparing)
            {
                if (ersatzpumpe_ein_btn.Checked)
                {
                    if (messagerepeat == 0)
                    {
                        JimWartet("Ersatzpumpe");
                        messagerepeat++;
                    }
                }
                else
                {
                    JimFangtAn("Ersatzkuhlwasserpumpe");
                    Statics.Reparing = true;
                    ersatzpumpe_aus_btn.Enabled = false;
                    ersatzpumpe_ein_btn.Enabled = false;
                    ep_trackbar.Enabled = false;
                }
            }

            if (Statics.Eprepweg > 0)
            {
                ep_technik_timeleft.Text = Statics.Eprepweg.ToString() + " Sekunden";
                ep_technikerstatus.Text = "Techniker kommt an in:";
                ep_technikerstatus.Visible = true;
                ep_technik_timeleft.Visible = true;
                Statics.Eprepweg--;
            }
            else
            {
                if (Statics.Reparing)
                {
                    ep_technik_timeleft.Text = Statics.Eprepdauer.ToString() + " Sekunden";
                    ep_technikerstatus.Text = "Reparaturen beendet in:";
                    Statics.Eprepdauer--;
                }
                else
                {
                    ep_technikerstatus.Text = "Techniker wartet..";
                    ep_technik_timeleft.Text = "";
                }
            }

            if (Statics.Eprepweg == 0 && Statics.Eprepdauer == 0)
            {
                rep_ersatzpumpe.Enabled = false;
                ep_technik_timeleft.Visible = false;
                ep_technikerstatus.Visible = false;
                Statics.Reparing = false;
                JimIstFertig("Ersatzkuhlwasserpumpe");
                ersatzpumpe_statustimer.Enabled = true;
                Statics.Ersatzpumpe_working = true;
                ersatzpumpe_fehlertimer.Enabled = true;
                ersatzpumpe_status.ForeColor = pumpedisabled_color;
                if (ersatzpumpe_ein_btn.Checked)
                    ersatzpumpe_status.Text = "In Betrieb";
                else
                    ersatzpumpe_status.Text = "Außer Betrieb";
                ep_technikrufen_btn.Enabled = true;
                ersatzpumpe_ein_btn.Enabled = true;
                ersatzpumpe_aus_btn.Enabled = true;
                ep_trackbar.Enabled = true;
                Statics.Technikoccupied = false;
                messagerepeat = 0;
                Statics.Lastreperatur = "ersatzpumpe";
            }
        }
        #endregion 

        #region Steuerstab reparieren
        private void repairsteuerstab_btn_Click(object sender, EventArgs e) //gleiches Schema wie Pumpe 1
        {
            if (Statics.externComponentToRep[7])
                hauptfenster.ExternMachtSchon();
            else
            {
                if (!Statics.RepStopp)
                {
                    try
                    {
                        Chat.Show();
                    }
                    catch (Exception)
                    {
                        Chat.Focus();
                    }
                    if (!Statics.Technikoccupied && Statics.Steuerstaberror)
                    {
                        repairsteuerstab_btn.Enabled = false;
                        Statics.Technikoccupied = true;
                        rep_steuerstab.Enabled = true;
                        Random rnd = new Random();
                        if (!Statics.Mukkibude)
                            Statics.Steuerstab_repdauer = rnd.Next(50, 70);
                        else
                            Statics.Steuerstab_repdauer = rnd.Next(35, 55);
                        if (Statics.Lastreperatur == "steuerstab")
                            JimWarGeradeDa();
                        else
                            Chat.chatbox.AppendText(DateTime.Now.ToShortTimeString() + ": Jim: Ich mach' mich auf den Weg zu den Steuerstäben.\n");

                        if (!Statics.JimTurnschuhe)
                            Statics.Steuerstabrepweg = 121;
                        else
                            Statics.Steuerstabrepweg = 103;
                    }
                    else
                        if (Statics.Technikoccupied)
                            JimBusy();
                        else
                            Chat.chatbox.AppendText(DateTime.Now.ToShortTimeString() + ": Jim: Was soll ich da?\n");
                }
                else
                    JimIstAufRuckweg();
            }
        }

        private void rep_steuerstab_Tick(object sender, EventArgs e)    //gleiches Schema wie Pumpe 1
        {
            if (Statics.Steuerstabrepweg == 0 && !Statics.Reparing)
            {
                Chat.chatbox.AppendText(DateTime.Now.ToShortTimeString() + ": Jim: Ich fang' jetzt mit den Reparaturen an den Steuerstäben an.\n");
                Statics.Reparing = true;

                if(Statics.Steuerstabrepweg == 20)
                    Chat.chatbox.AppendText(DateTime.Now.ToShortTimeString() + ": Jim: Ich bin gleich da.\n");
            }

                if (Statics.Steuerstabrepweg > 0)
                {
                    steuerstab_reperaturdauer_label.Text = Statics.Steuerstabrepweg.ToString() + " Sekunden";
                    steuerstab_reperaturstatus_label.Text = "Techniker kommt an in:";
                    steuerstab_reperaturstatus_label.Visible = true;
                    steuerstab_reperaturdauer_label.Visible = true;
                    Statics.Steuerstabrepweg--;

                    if (Statics.Steuerstabrepweg == 20)
                        Chat.chatbox.AppendText(DateTime.Now.ToShortTimeString() + ": Jim: Ich bin gleich da.\n");
                }
                else
                {
                    if (Statics.Reparing)
                    {
                        steuerstab_reperaturdauer_label.Text = Statics.Steuerstab_repdauer.ToString() + " Sekunden";
                        steuerstab_reperaturstatus_label.Text = "Reperaturen beendet in:";
                        Statics.Steuerstab_repdauer--;
                    }
                }

            if (Statics.Steuerstabrepweg == 0 && Statics.Steuerstab_repdauer == 0)
            {
                rep_steuerstab.Enabled = false;
                steuerstab_reperaturstatus_label.Visible = false;
                steuerstab_reperaturdauer_label.Visible = false;
                Statics.Reparing = false;
                Chat.chatbox.AppendText(DateTime.Now.ToShortTimeString() + ": Jim: Reparaturen an den Steuerstäben abgeschlossen. Man - die haben vielleicht geklemmt!\n");
                Statics.Steuerstaberror = false;
                Steuerstab_statuslabel.Text = "Normal";
                Steuerstab_statuslabel.ForeColor = Color.Green;
                steuerstab_trackbar.Enabled = true;
                repairsteuerstab_btn.Visible = false;
                repairsteuerstab_btn.Enabled = true;
                Statics.Technikoccupied = false;
                messagerepeat = 0;
                Statics.Lastreperatur = "steuerstab";
            }
        }
        #endregion      
        #endregion
    }
}