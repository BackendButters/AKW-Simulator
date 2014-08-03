using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AKW_Simulator
{
    public partial class Loginscreen : Form
    {
        public Loginscreen()
        {
            InitializeComponent();
        }

        private void Loginscreen_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void Loginscreen_Shown(object sender, EventArgs e)
        {
            LoginSounds.RunWorkerAsync();   //In Backgroundworker ausgelagert, damit der Sound, während der Thread blockiert ist, abgespielt werden kann
            LoginTextchange("Initialisiere...", 200);
            LoginTextchange("Prüfe Verfügbarkeit...", 1500);
            LoginTextchange("Suche freies Atomkraftwerk...", 200);
            LoginTextchange("Authentifizieren...", 750);
            LoginTextchange("Lade Umfeld...", 150);
            LoginTextchange("Lade Benutzerdaten...", 150);
            LoginTextchange("Überprüfe Systeme...", 150);
            LoginTextchange("Lade Kontrolldstation...", 200);
            LoginTextchange("Lade Steuerelemente...", 150);
            LoginTextchange("Schleime beim Chef ein...", 75);
            LoginTextchange("Begrüße Mitarbeiter...", 150);
            LoginTextchange("Backe Kuchen...", 75);
            LoginTextchange("Login...", 1000);
            this.Hide();
            this.Dispose();
        }

        private void LoginTextchange(string text, int sleeptime)
        {
            statuslabel.Text = text;
            statuslabel.TextAlign = ContentAlignment.MiddleCenter;
            progressBar1.PerformStep();
            statuslabel.Update();   //Update()-Methode wird aufgerufen, damit der Text geschrieben wird, bevor der Thread blockiert wird
            this.Update();
            progressBar1.Update();
            Thread.Sleep(sleeptime);
            
        }

        private void LoginSounds_DoWork(object sender, DoWorkEventArgs e)
        {
            WMPLib.WindowsMediaPlayerClass player = new WMPLib.WindowsMediaPlayerClass();
            player.URL = Application.StartupPath + @"\Sounds\Welcome.mp3";
        }
    }
}
