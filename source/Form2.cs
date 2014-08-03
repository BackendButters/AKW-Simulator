using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AKW_Simulator
{
    public partial class Pause_dialog : Form
    {
        public Pause_dialog()
        {
            InitializeComponent();
        }

        private void weiterspielen_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Pause_dialog_Load(object sender, EventArgs e)
        {
            //Icon setzen
        }

        private void Pause_dialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.pause = false;
            this.Close();
        }
    }
}
