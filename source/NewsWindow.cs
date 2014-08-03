using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Xml;
using RemoteObjects;

namespace AKW_Simulator
{
    public partial class NewsWindow : Form
    {
        public NewsWindow()
        {
            InitializeComponent();
            installedversion_txtbx.Text = Application.ProductVersion.ToString() + " S";
            RemotingConfiguration.Configure("AKWS_msgcfg.exe.config", false);
        }

        private void closeWindow_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void NewsLaden_btn_Click(object sender, EventArgs e)
        {
            changelog_txtbx.Text = "wird geladen...";
            newVersion_txtbx.Text = "wird geladen...";
            message_txtbx.Text = "wird geladen...";

            changelog_txtbx.Update();   //Update()-Methode aufrufen, damit der Text vor dem Datenabruf (dh der Wartezeit) übernommen wird
            newVersion_txtbx.Update();
            message_txtbx.Update();

            try
            {
                Customers c = new Customers();  //Übertragene Klasse (unglücklicher Name, da ich die Klasse aus einem anderem Testprojekt übernommen habe)
                message_txtbx.Text = c.GetCustomers();

                string XMLPath = c.GetXML();
                XmlDocument XMLdoc = new XmlDocument();
                XMLdoc.Load(XMLPath);

                XmlNodeList VersionNodelist = XMLdoc.GetElementsByTagName("currentVersion");
                foreach (XmlNode node in VersionNodelist)
                {
                    newVersion_txtbx.Text = node.InnerText;
                }

                changelog_txtbx.Clear();
                XmlNodeList ChangeNodelist = XMLdoc.GetElementsByTagName("Change");
                foreach (XmlNode node in ChangeNodelist)
                {
                    changelog_txtbx.AppendText("\n\t" + node.ChildNodes.Item(0).InnerText + "  " + node.ChildNodes.Item(1).InnerText + "\n");
                    changelog_txtbx.AppendText(node.ChildNodes.Item(2).InnerText + "\n");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Die Verbindung konnte nicht hergestellt werden.\n\nWeitere Fehlerinformationen: " + ex.Message, "Verbindungsfehler", MessageBoxButtons.OK, MessageBoxIcon.Error);

                changelog_txtbx.Text = "(Verbindung konnte nicht hergestellt werden)";
                newVersion_txtbx.Text = "(unknown)";
                message_txtbx.Text = "(Verbindung konnte nicht hergestellt werden)";
            }
        }

        private void NewsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);  //Browser öffnen
        }
    }
}
