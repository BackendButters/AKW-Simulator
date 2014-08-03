    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AKW_Simulator
{
    public partial class Steuerstab_fehler_label : Form
    {
        WMPLib.WindowsMediaPlayerClass player = new WMPLib.WindowsMediaPlayerClass();   //Alarmplayer deklarieren

        public Steuerstab_fehler_label()
        {
            InitializeComponent();
            player.URL = Application.StartupPath + @"\Sounds\Componentalert.mp3";   //Sound laden
            player.stop();  //Sound beim initialisieren nicht abspielen
        }

        private void hide_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Schaltplan_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void componentError_timer_Tick(object sender, EventArgs e)  //Fehlergenerator der Elemente auf dem Schaltplan
        {
            #region Fehlerlabel
            if (Statics.TurbineError)   //Wenn Turbine kaputt, Label sichtbar
                Turbine_fehler_label.Visible = true;
            else
                Turbine_fehler_label.Visible = false;

            if (Statics.GeneratorError) //s.o.
                Generator_fehler_label.Visible = true;
            else
                Generator_fehler_label.Visible = false;

            if (Statics.KuhlwasserNachfullPumpeError)    //s.o.
                Kuhlwassernachschub_fehler_label.Visible = true;
            else
                Kuhlwassernachschub_fehler_label.Visible = false;

            #endregion 

            #region Kuhlwassernachfüllpumpe Bildchange
            if (Statics.KuhlwasserNachfullPumpeError)   //Wenn Kühlwassernachfüllpumpe defekt, entsprechendes Bild anzeigen..
                kuhlwassernachschubpumpe_picturebox.Image = Properties.Resources.pumpefailurefinal;
            else          //sonst die Pumpenbewegung simulieren
            {   
                if (kuhlwassernachschubpumpe_picturebox.Image == Properties.Resources.pumpeworkingfinal1)
                    kuhlwassernachschubpumpe_picturebox.Image = Properties.Resources.pumpeworkingfinal2;
                else
                    kuhlwassernachschubpumpe_picturebox.Image = Properties.Resources.pumpeworkingfinal1;
            }
            #endregion 

            #region Filterverschmutzung
            if ((int)Statics.FilterVerstopfung < 100)   //Wenn Filterverstopfung unter 100%
            {
                if ((int)(Statics.P1l + Statics.P2l + Statics.Epl) > 0 && (int)(Statics.P1l + Statics.P2l + Statics.Epl) <= 100)   //Filterverschmutzung anhand Pumpenleistung berechnen
                    Statics.FilterVerstopfung += 0.1;
                if ((int)(Statics.P1l + Statics.P2l + Statics.Epl) > 100 && (int)(Statics.P1l + Statics.P2l + Statics.Epl) <= 200)  //s.o.
                    Statics.FilterVerstopfung += 0.2;
                if ((int)(Statics.P1l + Statics.P2l + Statics.Epl) > 200)   //s.o.
                    Statics.FilterVerstopfung += 0.3;

                filterverschmutzung_label.Text = (int)Statics.FilterVerstopfung + "%";  //Auf dem Label den Verschmutungsgrat anzeigen
                if (Statics.FilterVerstopfung > 65)   //Farbe des Labels festlegen
                {
                    filterverschmutzung_label.ForeColor = Color.Orange;
                    if (Statics.FilterVerstopfung > 90)
                        filterverschmutzung_label.ForeColor = Color.Red;
                }
                else
                    filterverschmutzung_label.ForeColor = SystemColors.ControlText;
            }
            #endregion 

            #region Fehlergenerator Turbine, Generator, Kuhlwassernachfüllpumpe
            Random rnd = new Random();
            int ErrorGenerator = 0;
            if(Statics.Istleistung >0 && Statics.Istleistung <= 500)
                ErrorGenerator = rnd.Next(1, 1300); //Anhand der Reaktorleistung die Fehlerwahrscheinlichkeit festlegen
            if (Statics.Istleistung > 500 && Statics.Istleistung <= 1000)
                ErrorGenerator = rnd.Next(1, 900); //s.o.
            if (Statics.Istleistung > 1000)
                ErrorGenerator = rnd.Next(1, 800);  //s.o.

            switch (ErrorGenerator)
            {
                case 2:
                    Statics.TurbineError = true;    //Turbinendefekt generieren
                    player.play();
                    break;

                case 3:
                    Statics.GeneratorError = true;  //Turbinendefekt generieren
                    player.play();
                    break;
            }
            if (Statics.Fueling)    //Wenn das Kühlwasserbecken nachgefüllt wird...
            {
                ErrorGenerator = rnd.Next(1, 700);  //kann die Kühlwassernachfüllpumpe ausfallen
                if (ErrorGenerator == 2)
                {
                    Statics.KuhlwasserNachfullPumpeError = true;
                    player.play();
                }
            }
            #endregion

            #region RepStopp
            if (Statics.RepStopp)
            {
                turbinerep_btn.Enabled = true;
                generatorrep_btn.Enabled = true;
                kuhlwassernachfullpumpeRep_btn.Enabled = true;
                filterreinigen_btn.Enabled = true;

                technikerstatus_panel.Visible = false;
                componentRep_timer.Enabled = false;
            }
            #endregion
        }

        private void generator_ein_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (!generator_ein_btn.Checked) //Wenn der Generator abgeschaltet wird..
                componentShutdown_timer.Enabled = true; //beginnt das herunterfahren..
            else
                Statics.Leistung = 100;     //sonst wird die Leistung initialisiert
        }

        private void componentShutdown_timer_Tick(object sender, EventArgs e)
        {
            if (generator_progressbar.Value > 0)    //Die Progressbar langsam herauf, bzw herunterfahren
                try
                {
                    generator_progressbar.Value += -20;
                }
                catch
                {
                    generator_progressbar.Value = 0;
                }
            else
                componentShutdown_timer.Enabled = false;
        }

        private void turbinerep_btn_Click(object sender, EventArgs e)
        {
            if (Statics.externComponentToRep[0])    //Wenn die Turbine schon HypeRep repariert wird..
                hauptfenster.ExternMachtSchon();    //sagt Jim das an
            else
            {
                if (!Statics.RepStopp)  //Wenn der Techinker nicht zurückgerufen wird..
                {
                    if (Statics.TurbineError)   //und die Turbine kaputt ist..
                    {
                        if (!Statics.Technikoccupied)   //und Jim nicht beschäftigt ist, wird die Reparatur begonnen
                        {
                            turbinerep_btn.Enabled = false;
                            Statics.Technikoccupied = true;
                            Statics.TurbineRepRequest = true;
                            hauptfenster.JimGehtLos("der Turbine");

                            if (Statics.Mukkibude)  //Wenn er eine Prämie bekommen hat und im Fitnesstudio war. ist die Reparatrdauer kürzer
                                Statics.TurbineRepdauer = 23;
                            else
                                Statics.TurbineRepdauer = 28;

                            if (Statics.JimTurnschuhe)  //s.o.
                                Statics.TurbineWeg = 48;
                            else
                                Statics.TurbineWeg = 58;
                        }
                        else
                            hauptfenster.JimBusy();

                        if (Statics.Lastreperatur == "Turbine") //letzte Reparatur festlegen
                            hauptfenster.JimWarGeradeDa();
                    }
                    else
                        hauptfenster.NichtsZuTun();
                }
                else
                    hauptfenster.JimIstAufRuckweg();
            }
        }

        private void generatorrep_btn_Click(object sender, EventArgs e)
        {
            if (Statics.externComponentToRep[1])    //(ist das gleiche Schema wie bei der Turbine oben)
                hauptfenster.ExternMachtSchon();
            else
            {
                if (!Statics.RepStopp)
                {
                    if (Statics.GeneratorError)
                    {
                        if (!Statics.Technikoccupied)
                        {
                            generatorrep_btn.Enabled = false;
                            Statics.Technikoccupied = true;
                            Statics.GeneratorRepRequest = true;
                            hauptfenster.JimGehtLos("dem Generator");

                            if (Statics.Mukkibude)
                                Statics.GeneratorRepdauer = 59;
                            else
                                Statics.GeneratorRepdauer = 81;

                            if (Statics.JimTurnschuhe)
                                Statics.GeneratorWeg = 51;
                            else
                                Statics.GeneratorWeg = 63;
                        }
                        else
                            hauptfenster.JimBusy();

                        if (Statics.Lastreperatur == "Generator")
                            hauptfenster.JimWarGeradeDa();
                    }
                    else
                        hauptfenster.NichtsZuTun();
                }
                else
                    hauptfenster.JimIstAufRuckweg();
            }
        }

        private void filterreinigen_btn_Click(object sender, EventArgs e)
        {
            if (Statics.externComponentToRep[3])    //(ist das gleiche Schema wie oben)
                hauptfenster.ExternMachtSchon();
            else
            {
                if (!Statics.RepStopp)
                {
                    if (Statics.FilterVerstopfung > 0)
                    {
                        if (!Statics.Technikoccupied)
                        {
                            filterreinigen_btn.Enabled = false;
                            Statics.Technikoccupied = true;
                            Statics.FilterRepRequest = true;
                            hauptfenster.JimGehtLos("dem Filter");

                            if (Statics.Mukkibude)
                                Statics.FilterRepdauer = 12;
                            else
                                Statics.FilterRepdauer = 20;

                            if (Statics.JimTurnschuhe)
                                Statics.FilterWeg = 21;
                            else
                                Statics.FilterWeg = 35;
                        }
                        else
                            hauptfenster.JimBusy();

                        if (Statics.Lastreperatur == "Filter")
                            hauptfenster.JimWarGeradeDa();
                    }
                    else
                        hauptfenster.NichtsZuTun();
                }
                else
                    hauptfenster.JimIstAufRuckweg();
            }
        }

        private void kuhlwassernachfullpumpeRep_btn_Click(object sender, EventArgs e)
        {
            if (Statics.externComponentToRep[2])    //(ist das gleiche Schema wie oben)
                hauptfenster.ExternMachtSchon();
            else
            {
                if (!Statics.RepStopp)
                {
                    if (Statics.KuhlwasserNachfullPumpeError)
                    {
                        kuhlwassernachfullpumpeRep_btn.Enabled = false;
                        if (!Statics.Technikoccupied)
                        {
                            Statics.Technikoccupied = true;
                            Statics.KuhlwasserNachfullPumpeRepRequest = true;
                            hauptfenster.JimGehtLos("der Kühlwassernachfüllpumpe");

                            if (Statics.Mukkibude)
                                Statics.KuhlwassernachfullpumpeRepdauer = 22;
                            else
                                Statics.KuhlwassernachfullpumpeRepdauer = 32;

                            if (Statics.JimTurnschuhe)
                                Statics.KuhlwassernachfullpumpeWeg = 61;
                            else
                                Statics.KuhlwassernachfullpumpeWeg = 72;
                        }
                        else
                            hauptfenster.JimBusy();

                        if (Statics.Lastreperatur == "Kuhlwassernachfullpumpe")
                            hauptfenster.JimWarGeradeDa();
                    }
                    else
                        hauptfenster.NichtsZuTun();
                }
                else
                    hauptfenster.JimIstAufRuckweg();
            }
        }

        private void componentRep_timer_Tick(object sender, EventArgs e)
        {
            #region Turbine
            if (Statics.TurbineRepRequest)  //Wenn etwas repariert werden soll..
            {
                technikerstatus_panel.Visible = true;
                if (Statics.TurbineWeg > 1) //und Jim noch nicht da ist, wird seine Ankunftszeit angezeigt
                {
                    technikerstatus_label.Text = "Techniker kommt an in: ";
                    technikerdauer_label.Text = Statics.TurbineWeg.ToString() + " Sek.";
                    Statics.TurbineWeg--;
                }
                else
                {
                    if ((int)Statics.Leistung > 0)  //Wenn er da ist, aber der Reaktor noch nicht heruntergefahren ist..
                    {
                        if (Statics.Messagerepeat < 1)
                        {
                            hauptfenster.JimWartet("Der Reaktor");
                            technikerstatus_label.Text = "Techniker wartet..";
                            technikerdauer_label.Visible = false;
                            Statics.Messagerepeat++;
                        }
                    }
                    else
                    {
                        if (Statics.TurbineRepdauer > 0)    //Wenn er da ist, aber die Reparaturen noch nicht abgeschlossen sind..
                        {
                            if (Statics.Chatrepeat < 1)
                            {
                                hauptfenster.JimFangtAn("Turbine");
                                Statics.Chatrepeat++;
                            } 
                            technikerstatus_label.Text = "Reparaturen beendet: ";   //repariert er
                            technikerdauer_label.Visible = true;
                            technikerdauer_label.Text = Statics.TurbineRepdauer.ToString() + " Sek.";
                            Statics.TurbineRepdauer--;
                        }
                        else    //Wenn die Reparaturen fertig sind, werden alle Werte zurückgesetzt etc
                        {
                            hauptfenster.JimIstFertig("Turbine");
                            technikerstatus_panel.Visible = false;
                            Statics.TurbineRepRequest = false;
                            Statics.TurbineError = false;
                            turbinerep_btn.Enabled = true;
                            Statics.Technikoccupied = false;
                            Statics.Messagerepeat = 0;
                            Statics.Chatrepeat = 0;
                            Statics.Lastreperatur = "Turbine";
                        }
                    }
                }
            }
            else
            {
                if(!Statics.GeneratorRepRequest && !Statics.KuhlwasserNachfullPumpeRepRequest && !Statics.FilterRepRequest)
                    technikerstatus_panel.Visible = false;
            }
            #endregion

            #region Generator
            if (Statics.GeneratorRepRequest)    //(gleiches Schema wie bei der Turbine weiter oben)
            {
                technikerstatus_panel.Visible = true;
                if (Statics.GeneratorWeg > 1)
                {
                    technikerstatus_label.Text = "Techniker kommt an in: ";
                    technikerdauer_label.Text = Statics.GeneratorWeg.ToString() + " Sek.";
                    Statics.GeneratorWeg--;
                }
                else
                {
                    if (generator_ein_btn.Checked)
                    {
                        if (Statics.Messagerepeat < 1)
                        {
                            hauptfenster.JimWartet("Der Generator");
                            technikerstatus_label.Text = "Techniker wartet..";
                            technikerdauer_label.Visible = false;
                            Statics.Messagerepeat++;
                        }
                    }
                    else
                    {
                        generator_ein_btn.Enabled = false;
                        generator_aus_btn.Enabled = false;
                        if (Statics.GeneratorRepdauer > 0)
                        {
                            if (Statics.Chatrepeat < 1)
                            {
                                hauptfenster.JimFangtAn("dem Generator");
                                Statics.Chatrepeat++;
                            }
                            technikerstatus_label.Text = "Reparaturen beendet: ";
                            technikerdauer_label.Visible = true;
                            technikerdauer_label.Text = Statics.GeneratorRepdauer.ToString() + " Sek.";
                            Statics.GeneratorRepdauer--;
                        }
                        else
                        {
                            hauptfenster.JimIstFertig("dem Generator");
                            technikerstatus_panel.Visible = false;
                            Statics.GeneratorRepRequest = false;
                            Statics.GeneratorError = false;
                            generatorrep_btn.Enabled = true;
                            Statics.Technikoccupied = false;
                            Generator_fehler_label.Visible = false;
                            Statics.Messagerepeat = 0;
                            Statics.Chatrepeat = 0;
                            Statics.Lastreperatur = "Generator";
                            generator_ein_btn.Enabled = true;
                            generator_aus_btn.Enabled = true;
                        }
                    }
                }
            }
            else
            {
                if (!Statics.TurbineRepRequest && !Statics.KuhlwasserNachfullPumpeRepRequest && !Statics.FilterRepRequest)
                    technikerstatus_panel.Visible = false;
            }
            #endregion

            #region Kuhlwassernachfullpumpe
            if (Statics.KuhlwasserNachfullPumpeRepRequest)  //(gleiches Schema wie bei der Turbine weiter oben)
            {
                technikerstatus_panel.Visible = true;
                if (Statics.KuhlwassernachfullpumpeWeg > 1)
                {
                    technikerstatus_label.Text = "Techniker kommt an in: ";
                    technikerdauer_label.Text = Statics.KuhlwassernachfullpumpeWeg.ToString() + " Sek.";
                    Statics.KuhlwassernachfullpumpeWeg--;
                }
                else
                {
                    if (kuhlwassernachfullpumpe_ein_btn.Checked)
                    {
                        if (Statics.Messagerepeat < 1)
                        {
                            hauptfenster.JimWartet("Die Kühlwasserpumpe");
                            technikerstatus_label.Text = "Techniker wartet..";
                            technikerdauer_label.Visible = false;
                            Statics.Messagerepeat++;
                        }
                    }
                    else
                    {
                        kuhlwassernachfullpumpe_ein_btn.Enabled = false;
                        kuhlwassernachfullpumpe_aus_btn.Enabled = false;
                        if (Statics.KuhlwassernachfullpumpeRepdauer > 0)
                        {
                            if (Statics.Chatrepeat < 1)
                            {
                                hauptfenster.JimFangtAn("der Kühlwassernachfüllpumpe");
                                Statics.Chatrepeat++;
                            }
                            technikerstatus_label.Text = "Reparaturen beendet: ";
                            technikerdauer_label.Visible = true;
                            technikerdauer_label.Text = Statics.KuhlwassernachfullpumpeRepdauer.ToString() + " Sek.";
                            Statics.KuhlwassernachfullpumpeRepdauer--;
                        }
                        else
                        {
                            hauptfenster.JimIstFertig("der Kühlwassernachfüllpumpe");
                            technikerstatus_panel.Visible = false;
                            Statics.KuhlwasserNachfullPumpeRepRequest = false;
                            Statics.KuhlwasserNachfullPumpeError = false;
                            kuhlwassernachfullpumpeRep_btn.Enabled = true;
                            Statics.Technikoccupied = false;
                            Kuhlwassernachschub_fehler_label.Visible = false;
                            Statics.Messagerepeat = 0;
                            Statics.Chatrepeat = 0;
                            Statics.Lastreperatur = "Kuhlwasserpumpe";
                            kuhlwassernachfullpumpe_ein_btn.Enabled = true;
                            kuhlwassernachfullpumpe_aus_btn.Enabled = true;
                        }
                    }
                }
            }
            else
            {
                if (!Statics.GeneratorRepRequest && !Statics.TurbineRepRequest && !Statics.FilterRepRequest)
                    technikerstatus_panel.Visible = false;
            }
            #endregion

            #region Filter
            if (Statics.FilterRepRequest)   //(gleiches Schema wie bei der Turbine weiter oben)
            {
                technikerstatus_panel.Visible = true;
                if (Statics.FilterWeg > 1)
                {
                    technikerstatus_label.Text = "Techniker kommt an in: ";
                    technikerdauer_label.Text = Statics.FilterWeg.ToString() + " Sek.";
                    Statics.FilterWeg--;
                }
                else
                {
                    if ((Statics.P1l + Statics.P2l + Statics.Epl) > 10)
                    {
                        if (Statics.Messagerepeat < 1)
                        {
                            hauptfenster.JimWartet("Die Kühlwasserpumpen");
                            technikerstatus_label.Text = "Techniker wartet..";
                            technikerdauer_label.Visible = false;
                            Statics.Messagerepeat++;
                        }
                    }
                    else
                    {
                        if (Statics.FilterRepdauer > 0)
                        {
                            if (Statics.Chatrepeat < 1)
                            {
                                hauptfenster.JimFangtAn("dem Filter an");
                                Statics.Chatrepeat++;
                            }
                            technikerstatus_label.Text = "Reparaturen beendet: ";
                            technikerdauer_label.Visible = true;
                            technikerdauer_label.Text = Statics.FilterRepdauer.ToString() + " Sek.";
                            Statics.FilterRepdauer--;
                        }
                        else
                        {
                            hauptfenster.JimIstFertig("dem Filter");
                            technikerstatus_panel.Visible = false;
                            Statics.FilterRepRequest = false;
                            Statics.FilterVerstopfung = 0;
                            Statics.Technikoccupied = false;
                            Statics.Messagerepeat = 0;
                            Statics.Chatrepeat = 0;
                            Statics.Lastreperatur = "Filter";
                            filterreinigen_btn.Enabled = true;
                        }
                    }
                }
            }
            else
            {
                if (!Statics.GeneratorRepRequest && !Statics.TurbineRepRequest && !Statics.KuhlwasserNachfullPumpeRepRequest)
                    technikerstatus_panel.Visible = false;
            }
            #endregion
        }
    }
}
