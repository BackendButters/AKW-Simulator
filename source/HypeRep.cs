using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AKW_Simulator
{
    public partial class HypeRep : Form
    {
        int repkosten = 0;
        int hypeRepArrival = 0;
        int hypeRepDuration = 0;
        int messagerepeat = 0;
        
        
        public HypeRep()
        {
            InitializeComponent();
            for (int i = 0; i < 7; i++)
            {
                Statics.externComponentToRep[i] = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void HypeRep_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void externrep_confirm_btn_Click(object sender, EventArgs e)
        {
            if ((repkosten + 15) >= Statics.Guthaben)   //Wenn man nicht genug geld hat..
                MessageBox.Show("Sie haben nicht genug Geld um die Reparatur durch eine externe Firma bezahlen zu können.",
                                "Achtung",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            else
            {
                Statics.Guthaben -= (repkosten + 15);
                externrep_confirm_btn.Enabled = false;
                Random rnd = new Random();
                hypeRepArrival = rnd.Next(7, 12);   //Ankunfs- Reparaturdauer dynamich generieren
                hypeRepDuration = rnd.Next(5, 9);
                hypeRep_statuspanel.Visible = true;
                HypeRep_timer.Enabled = true;

                if (hyperep_turbine_chkbx.Checked)      //jeder Komponente wird mit einer ID belegt, damit später ausgewertet werden kann, welche Komponenten repariert werden sollten
                    Statics.externComponentToRep[0] = true;

                if (hyperep_generator_chkbx.Checked)
                    Statics.externComponentToRep[1] = true;

                if (hyperep_kuhlwassernachfullpumpe_chkbx.Checked)
                    Statics.externComponentToRep[2] = true;

                if (hyperep_filterreinigen_chkbx.Checked)
                    Statics.externComponentToRep[3] = true;

                if (hyperep_kuhlwasserpumpe1_chkbx.Checked)
                    Statics.externComponentToRep[4] = true;

                if (hyperep_kuhlwasserpumpe2_chkbx.Checked)
                    Statics.externComponentToRep[5] = true;

                if (hyperep_ersatzkuhlwasserpumpe_chkbx.Checked)
                    Statics.externComponentToRep[6] = true;

                if (hyperep_steuerstab_chkbx.Checked)
                    Statics.externComponentToRep[7] = true;
            }
        }

        #region Checked Change
        private void hyperep_turbine_chkbx_CheckedChanged(object sender, EventArgs e)
        {
            if (hyperep_turbine_chkbx.Checked)
                repkosten += 40;
            else
                repkosten -= 40;
            summe_lbl.Text = "Summe: " + (repkosten + 15).ToString() + "$";
        }

        private void hyperep_generator_chkbx_CheckedChanged(object sender, EventArgs e)
        {
            if (hyperep_generator_chkbx.Checked)
                repkosten += 40;
            else
                repkosten -= 40;
            summe_lbl.Text = "Summe: " + (repkosten + 15).ToString() + "$";
        }

        private void hyperep_kuhlwassernachfullpumpe_chkbx_CheckedChanged(object sender, EventArgs e)
        {
            if (hyperep_kuhlwassernachfullpumpe_chkbx.Checked)
                repkosten += 45;
            else
                repkosten -= 45;
            summe_lbl.Text = "Summe: " + (repkosten + 15).ToString() + "$";
        }

        private void hyperep_filterreinigen_chkbx_CheckedChanged(object sender, EventArgs e)
        {
            if (hyperep_filterreinigen_chkbx.Checked)
                repkosten += 20;
            else
                repkosten -= 20;
            summe_lbl.Text = "Summe: " + (repkosten + 15).ToString() + "$";
        }

        private void hyperep_kuhlwasserpumpe1_chkbx_CheckedChanged(object sender, EventArgs e)
        {
            if (hyperep_kuhlwasserpumpe1_chkbx.Checked)
                repkosten += 50;
            else
                repkosten -= 50;
            summe_lbl.Text = "Summe: " + (repkosten + 15).ToString() + "$";
        }

        private void hyperep_kuhlwasserpumpe2_chkbx_CheckedChanged(object sender, EventArgs e)
        {
            if (hyperep_kuhlwasserpumpe2_chkbx.Checked)
                repkosten += 50;
            else
                repkosten -= 50;
            summe_lbl.Text = "Summe: " + (repkosten + 15).ToString() + "$";
        }

        private void hyperep_ersatzkuhlwasserpumpe_chkbx_CheckedChanged(object sender, EventArgs e)
        {
            if (hyperep_ersatzkuhlwasserpumpe_chkbx.Checked)
                repkosten += 50;
            else
                repkosten -= 50;
            summe_lbl.Text = "Summe: " + (repkosten + 15).ToString() + "$";
        }

        private void hyperep_steuerstab_chkbx_CheckedChanged(object sender, EventArgs e)
        {
            if (hyperep_steuerstab_chkbx.Checked)
                repkosten += 80;
            else
                repkosten -= 80;
            summe_lbl.Text = "Summe: " + (repkosten + 15).ToString() + "$";
        }
        #endregion 

        private void HypeRep_timer_Tick(object sender, EventArgs e)
        {
            if (hypeRepArrival > 0) //Wenn die Reparaturfirma noch nicht da ist..
            {
                if (messagerepeat == 0) //Um Chatspam zu vermeiden, wird die Hilfsvariable messagerepeat verwendet
                {
                    hauptfenster.ExternAnnouncement();  
                    messagerepeat++;
                }
                hypeRepArrival--;   //wird die Ankunftszeit dekrementiert
                hypeRep_status_lbl.Text = "HypeRep kommt an in:";
                hypeRep_dauer_lbl.Text = hypeRepArrival.ToString() + " Sek.";
            }
            else
            {
                if (hypeRepDuration > 0)    //Das gleiche wie mit der Ankunftszeit mit der Reparaturdauer
                {
                    if (messagerepeat == 1)
                    {
                        messagerepeat++;
                        hauptfenster.ExternBegin();
                    }
                    hypeRepDuration--;
                    hypeRep_dauer_lbl.Text = hypeRepDuration.ToString() + " Sek.";
                    hypeRep_status_lbl.Text = "Reparaturen beendet in:";
                }
                else    //Wenn die Reparatur beendet ist, sind die Komponenten, die repariert werden sollten, wieder bereit.
                {
                    HypeRep_timer.Enabled = false;
                    hauptfenster.ExternFertig();
                    hypeRep_statuspanel.Visible = false;

                    if (Statics.externComponentToRep[0])
                        Statics.TurbineError = false;

                    if (Statics.externComponentToRep[1])
                        Statics.GeneratorError = false;

                    if (Statics.externComponentToRep[2])
                        Statics.KuhlwasserNachfullPumpeError = false;

                    if (Statics.externComponentToRep[3])
                        Statics.FilterVerstopfung = 0;

                    if (Statics.externComponentToRep[4])
                        Statics.Pumpe1_working = true;

                    if (Statics.externComponentToRep[5])
                        Statics.Pumpe2_working = true;

                    if (Statics.externComponentToRep[6])
                        Statics.Ersatzpumpe_working = true;

                    if (Statics.externComponentToRep[7])
                        Statics.Steuerstaberror = false;

                    for (int i = 0; i < 7; i++)
                    {
                        Statics.externComponentToRep[i] = false;
                    }
                    externrep_confirm_btn.Enabled = true;
                }
            }
        }
    }
}
