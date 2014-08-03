using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AKW_Simulator
{
    public partial class Finance : Form     //Name des Fensters kommt daher, da es ursprüngliche eine Finanzübersicht bieten sollte
    {
        #region Felder
        int leistungy = (int)(Statics.Istleistung / 10);    //y-Wert der Leistung
        int tempy = (int)(Statics.Temperatur / 10); //y-Wert der Temperatur
        int guthabeny = (int)Statics.Guthaben;  //y-Wert des Guthabens  
        int preisy = (Statics.Mwpreis / 10);    //y-Wert des Preises
        int demandleistungy = (Statics.Demandleistung / 10);    //y-Wert der benötigten Leistung
        int pumpenleistungy = (int)Statics.Istleistung; //y-Wert der Pumpenleistung
        Point[] leistungpoints = new Point[812];    //Koordinaten der Werte in einem Punkte-Array speichern
        Point[] mwspoints = new Point[812];
        Point[] guthabenpoints = new Point[812];
        Point[] temperaturpoints = new Point[812];
        Point[] demandleistungpoints = new Point[812];
        Point[] pumpenleistungpoints = new Point[812];
        #endregion

        public Finance()
        {
            InitializeComponent();

            Rot_label.ForeColor = Color.Red;
            green_label.ForeColor = Color.Green;
            blau_label.ForeColor = Color.Blue;
            gelb_label.ForeColor = Color.Gold;
            orange_label.ForeColor = Color.Orange;

            //Array initialisieren
            for (int i = 0; i < leistungpoints.Length; ++i)
            {
                leistungpoints[i].X = 0;
                leistungpoints[i].Y = 0;
            }
            for (int i = 0; i < mwspoints.Length; ++i)
            {
                mwspoints[i].X = 0;
                mwspoints[i].Y = 0;
            }
            for (int i = 0; i < guthabenpoints.Length; ++i)
            {
                guthabenpoints[i].X = 0;
                guthabenpoints[i].Y = 0;
            }
            for (int i = 0; i < temperaturpoints.Length; ++i)
            {
                temperaturpoints[i].X = 0;
                temperaturpoints[i].Y = 0;
            }
            for (int i = 0; i < demandleistungpoints.Length; ++i)
            {
                demandleistungpoints[i].X = 0;
                demandleistungpoints[i].Y = 0;
            }
            for (int i = 0; i < pumpenleistungpoints.Length; ++i)
            {
                pumpenleistungpoints[i].X = 0;
                pumpenleistungpoints[i].Y = 0;
            }
        }

        private void refreshzeitgeber_Tick(object sender, EventArgs e)
        {
            #region init

            Graphics grafik = graphen_picturebox.CreateGraphics();
            BufferedGraphicsContext bgc = BufferedGraphicsManager.Current;  //um Flimmern zu vermeiden -> buffered Graphics verwenden
            BufferedGraphics bg = bgc.Allocate(grafik, graphen_picturebox.ClientRectangle);

            bg.Graphics.Clear(Color.White);
            bg.Graphics.TranslateTransform(0.0F, graphen_picturebox.ClientSize.Height);
            bg.Graphics.ScaleTransform(1.0F, -1.0F);    //Koordinatenbezugssystem festlegen

            bg.Graphics.DrawLine(Pens.Gray, 1, 149, ClientSize.Width, 149); //Orientierungslinien
            bg.Graphics.DrawLine(Pens.Gray, 1, 299, ClientSize.Width, 299);

            #endregion 

            #region Reaktorleistung
            if (schwarz_checkbox.Checked)   //Wenn die Anzeige der Leistung gewollt ist -> Zeichnen                       
            {
                for (int i = 1; i < (leistungpoints.Length - 1); ++i)   //Werte der Punkte des Leistungs-Arrays festlegen
                {
                    leistungpoints[i].X = i + 1;    
                    leistungpoints[i].Y = leistungpoints[i + 1].Y;
                }

                leistungpoints[811].Y = leistungy;
                leistungpoints[811].X = 812;

                for (int i = 0; i < 811; ++i)   //Punkte des Leistungs-Arrays verbinden
                {
                    bg.Graphics.DrawLine(Pens.Black, leistungpoints[i].X, leistungpoints[i].Y, leistungpoints[i + 1].X, leistungpoints[i + 1].Y);
                }
            }
            #endregion 

            #region MW/s Preis
            if (oranje_checkbox.Checked)    //gleiches Schema wie bei Reaktorleistung
            {
                for (int i = 1; i < (mwspoints.Length - 1); ++i)
                {
                    mwspoints[i].X = i + 1;
                    mwspoints[i].Y = mwspoints[i + 1].Y;
                }

                mwspoints[811].Y = preisy;
                mwspoints[811].X = 812;

                for (int i = 0; i < 811; ++i)
                {
                    bg.Graphics.DrawLine(Pens.Orange, mwspoints[i].X, mwspoints[i].Y, mwspoints[i + 1].X, mwspoints[i + 1].Y);
                }
            }
            #endregion

            #region benötigte Leistung
            if (gold_checkbox.Checked)  //gleiches Schema wie bei Reaktorleistung
            {
                for (int i = 1; i < (demandleistungpoints.Length - 1); ++i)
                {
                    demandleistungpoints[i].X = i + 1;
                    demandleistungpoints[i].Y = demandleistungpoints[i + 1].Y;
                }

                demandleistungpoints[811].Y = demandleistungy;
                demandleistungpoints[811].X = 812;

                for (int i = 0; i < 811; ++i)
                {
                    bg.Graphics.DrawLine(Pens.Gold, demandleistungpoints[i].X, demandleistungpoints[i].Y, demandleistungpoints[i + 1].X, demandleistungpoints[i + 1].Y);
                }
            }
            #endregion 

            #region Pumpenleistung
            if (blue_checkbox.Checked)  //gleiches Schema wie bei Reaktorleistung
            {
                for (int i = 1; i < (pumpenleistungpoints.Length - 1); ++i)
                {
                    pumpenleistungpoints[i].X = i + 1;
                    pumpenleistungpoints[i].Y = pumpenleistungpoints[i + 1].Y;
                }

                pumpenleistungpoints[811].Y = pumpenleistungy;
                pumpenleistungpoints[811].X = 812;

                for (int i = 0; i < 811; ++i)
                {
                    bg.Graphics.DrawLine(Pens.Blue, pumpenleistungpoints[i].X, pumpenleistungpoints[i].Y, pumpenleistungpoints[i + 1].X, pumpenleistungpoints[i + 1].Y);
                }
            }
            #endregion

            #region Temperatur
            if (rot_checkbox.Checked)   //gleiches Schema wie bei Reaktorleistung
            {
                for (int i = 1; i < (temperaturpoints.Length - 1); ++i)
                {
                    temperaturpoints[i].X = i + 1;
                    temperaturpoints[i].Y = temperaturpoints[i + 1].Y;
                }

                temperaturpoints[811].Y = tempy;
                temperaturpoints[811].X = 812;

                for (int i = 0; i < 811; ++i)
                {
                    bg.Graphics.DrawLine(Pens.Red, temperaturpoints[i].X, temperaturpoints[i].Y, temperaturpoints[i + 1].X, temperaturpoints[i + 1].Y);
                }
            }
            #endregion 

            #region Guthaben
            if (green_checkbox.Checked) //gleiches Schema wie bei Reaktorleistung
            {
                for (int i = 1; i < (guthabenpoints.Length - 1); ++i)
                {
                    guthabenpoints[i].X = i + 1;
                    guthabenpoints[i].Y = guthabenpoints[i + 1].Y;
                }

                guthabenpoints[811].Y = guthabeny;
                guthabenpoints[811].X = 812;

                for (int i = 0; i < 811; ++i)
                {
                    bg.Graphics.DrawLine(Pens.Green, guthabenpoints[i].X, guthabenpoints[i].Y, guthabenpoints[i + 1].X, guthabenpoints[i + 1].Y);
                }
            }
            #endregion

            #region Wertaktualisierung
            leistungy = (int)(Statics.Istleistung / 10);    //Werte aktualisieren
            tempy = (int)(Statics.Temperatur / 10);
            guthabeny = (int)Statics.Guthaben;
            preisy = (Statics.Mwpreis / 10);
            demandleistungy = (Statics.Demandleistung / 10);
            pumpenleistungy = (int)Statics.Gesamtpumpenleistung;
            bg.Render();
            bg.Dispose();
            grafik.Dispose();
            #endregion
        }

        #region sonstiges
        private void Finance_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void hide_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        #endregion
    }
}

