using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AKW_Simulator
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new hauptfenster());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Es ist ein Fehler aufgetreten und das Programm muss beendet werden.\n\n Weitere Fehlerinformationen: " + ex.Message,
                                "Fehler!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }
    }
}
