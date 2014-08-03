using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AKW_Simulator
{
    public partial class Highscore : Form
    {
        public Highscore()
        {
            InitializeComponent();
        }

        private void Highscore_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void hide_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void HighscoreEintragen_btn_Click(object sender, EventArgs e)
        {
            //DB Verbindung hier 
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
                RefreshHighscore();
        }

        private void Highscore_Load(object sender, EventArgs e)
        {
            RefreshHighscore();
        }

        private void RefreshHighscore()
        {
            //DB-Verbindung hier
        }

        private void suchen_btn_Click(object sender, EventArgs e)
        {
            //DB-verbindung hier
        }
    }
}
