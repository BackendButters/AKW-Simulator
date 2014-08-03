using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AKW_Simulator
{
    public partial class JimBonusWindow : Form
    {
        public JimBonusWindow()
        {
            InitializeComponent();
        }

        private void JimBonusWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void hide_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void geldgeben_btn_Click(object sender, EventArgs e)
        {
            int pramie = 0;
            try
            {
                pramie = int.Parse(jimbonus_txtbx.Text);
                if (pramie <= Statics.Guthaben && pramie > 0)
                {
                    Statics.Guthaben -= pramie;
                    Statics.Jimbonus += pramie;
                    EMails.JimBonusBekommen = true;
                    this.Close();
                }
                else
                    throw (new IndexOutOfRangeException());
                
            }
            catch (Exception)
            {
                MessageBox.Show("Sie können nur ganzzahlige Beträge ausgeben, die Ihr aktuelles Guthaben nichtübersteigen.",
                                "Warnung",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }

            if (Statics.Jimbonus < 10 || Statics.JimTurnschuhe || Statics.Mukkibude) //Wenn Jim noch nicht genug Geld für ein Upgrade hat, oder bereits alle Upgrades hat, bedankt er sich nur
                hauptfenster.Chat.chatbox.AppendText("\n" + DateTime.Now.ToShortTimeString() + ": Jim: Danke Chef! Du bist mein Lieblingschef!\n");
            else
            {
                if (Statics.Jimbonus >= 10 && !Statics.JimTurnschuhe)   //Wenn das Guthaben größer 9 ist und Jim noch keine Turnschuhe hat, bekommt er jetzt welche
                {
                    hauptfenster.Chat.chatbox.AppendText("\n" + DateTime.Now.ToShortTimeString() + ": Jim: Danke Chef! Yuhuu! Ich werde mir von dem Geld neue Turnschuhe kaufen! \n(Die Wegzeiten der Reperaturen dauern jetzt nicht mehr so lange.) \n");
                    Statics.P1repweg = 35;
                    Statics.P2repweg = 60;
                    Statics.Eprepweg = 85;
                    Statics.Steuerstabrepweg = 102;
                    Statics.JimTurnschuhe = true;
                }
                if (Statics.Jimbonus >= 50 && !Statics.Mukkibude)   //s.o.
                {
                    hauptfenster.Chat.chatbox.AppendText("\n" + DateTime.Now.ToShortTimeString() + ": Jim: Super! Danke Chef! Ich werd' mir von dem Geld einen Kurs im Fitnessstudo nehmen! \n(Die Reperaturdauer der Pumpen ist jetzt nicht mehr so lange.) \n");
                    Statics.Mukkibude = true;
                }
            }
        }
    }
}
