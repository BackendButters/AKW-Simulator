using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AKW_Simulator
{
    public partial class Mails : Form
    {
        public Mails()
        {
            InitializeComponent();
        }

        private void hide_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Mails_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void anhang_offnen_btn_Click(object sender, EventArgs e)
        {
            Rot13window raster = new Rot13window();
            raster.Show();
        }

        private void Mails_Load(object sender, EventArgs e)
        {
            mailliste.Items.Add("Wilkommen");   //Initialisierungsmail anzeigen
            mailliste.SelectedItem = "Wilkommen";

            EMails maildetails = new EMails(mailliste.SelectedItem.ToString()); //Mail wird erzeugt, indem dem Konstruktor der eMail-Klasse der Betreff übergeben wird

            empfangszeit_txtbx.Text = maildetails.Empfangszeit;
            betreff_txtbx.Text = mailliste.SelectedItem.ToString();
            absender_txtbx.Text = maildetails.Absender;
            anhang_offnen_btn.Enabled = maildetails.Hasattachment;
            Mailtext_rttbx.Text = maildetails.Text;

            maildetails = null;
        }

        private void mailliste_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mailliste.SelectedItem != null)
            {
                EMails maildetails = new EMails(mailliste.SelectedItem.ToString()); //s.o.

                if (maildetails.Absender != "") //Wenn nicht alle mails gelöscht wurden..
                {
                    betreff_txtbx.Text = mailliste.SelectedItem.ToString();
                    absender_txtbx.Text = maildetails.Absender;
                    anhang_offnen_btn.Enabled = maildetails.Hasattachment;
                    Mailtext_rttbx.Text = maildetails.Text;
                    empfangszeit_txtbx.Text = maildetails.Empfangszeit;
                    anhang_offnen_btn.Visible = maildetails.Hasattachment;
                }
                maildetails = null;
            }
            else
            {
                absender_txtbx.Text = string.Empty;
                empfangszeit_txtbx.Text = string.Empty;
                anhang_offnen_btn.Visible = false;
                betreff_txtbx.Text = string.Empty;
                Mailtext_rttbx.Text = string.Empty;
            }
        }

        private void mail_delete_btn_Click(object sender, EventArgs e)
        {
            mailliste.Items.Remove(mailliste.SelectedItem); //eMail aus der ListBox entfernen
            try
            {
                mailliste.SelectedItem = mailliste.Items[0];    //nächste eMail selektieren
            }
            catch   //Wenn es keine eMail mehr vorhanden sind (Exception), alle Textfelder leeren
            {
                absender_txtbx.Text = string.Empty;
                empfangszeit_txtbx.Text = string.Empty;
                anhang_offnen_btn.Visible = false;
                betreff_txtbx.Text = string.Empty;
                Mailtext_rttbx.Text = string.Empty;
            }
        }

        private void delete_all_mails_btn_Click(object sender, EventArgs e)
        {
            mailliste.Items.Clear();
            absender_txtbx.Text = string.Empty;
            empfangszeit_txtbx.Text = string.Empty;
            anhang_offnen_btn.Visible = false;
            betreff_txtbx.Text = string.Empty;
            Mailtext_rttbx.Text = string.Empty;
        }
    }
}
