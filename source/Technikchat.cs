using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AKW_Simulator
{
    public partial class Technikchat : Form
    {
        public Technikchat()
        {
            InitializeComponent();
        }

        JimBonusWindow bonuswindow = new JimBonusWindow();  //Prämienfenster deklarieren
        int Technikready = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void technikchat_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }  //Form nur verstecken

        private void jimbonus_btn_Click(object sender, EventArgs e)
        {
            if (!Statics.Technikoccupied)   //Prüfen, ob Jim beschäftigt ist
            {
                bonuswindow.Show();         //wenn nicht, Prämienfenster anzeigen, bzw darauf den focus setzen
                bonuswindow.Focus();
            }
            else
                MessageBox.Show("Das geht nicht, während Jim beschäftigt ist.",
                                "Achtung",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
        }

        private void reparatur_abbrechen_btn_Click(object sender, EventArgs e)
        {
            if (Statics.Technikoccupied && !Statics.Reparing)   //Reparatur kann nur abgebrochen werden, wenn Jim unterwegs ist und noch nicht mit der Reparatur begonnen hat
            {
                Random rnd = new Random();
                reparatur_abbrechen_btn.Enabled = false;    //Status anzeigen, Buttons disablen etc
                technikfrei_timer.Enabled = true;
                technikbereit_panel.Visible = true;
                Technikready = rnd.Next(8, 13);     //Zufallszahl generieren, die Jims Rückkehr angibt
                Technikbereit_label.Text = Technikready.ToString() + " Sek.";
                Statics.RepStopp = true;            //gibt an, dass Jim zurückgerufen wurde
            }
            else
            {
                if(!Statics.Technikoccupied)    //Falls Jim gar nicht weg ist..
                    hauptfenster.JimIstNichtWeg();
                if (Statics.Reparing)           //Wenn Jim schon am Reparieren ist..
                    hauptfenster.JimRepariertFertig();
            }
        }

        private void technikfrei_timer_Tick(object sender, EventArgs e)
        {
            if (Technikready > 0)   //Wenn Jim noch nicht zurückgekehrt ist..
            {
                Technikready--;     //Rückkehrzeit dekrementieren
                Technikbereit_label.Text = Technikready.ToString() + " Sek.";
            }
            else
            {
                Statics.Technikoccupied = false;    //Wenn er zurück ist, Status zurücksetzen etc
                reparatur_abbrechen_btn.Enabled = true;
                technikbereit_panel.Visible = false;
                technikfrei_timer.Enabled = false;
                Statics.RepStopp = false;
            }
        }
    }
}
