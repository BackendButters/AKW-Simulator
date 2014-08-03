namespace AKW_Simulator
{
    partial class HypeRep
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.externrep_confirm_btn = new System.Windows.Forms.Button();
            this.hyperep_kuhlwasserpumpe1_chkbx = new System.Windows.Forms.CheckBox();
            this.hyperep_kuhlwasserpumpe2_chkbx = new System.Windows.Forms.CheckBox();
            this.hyperep_ersatzkuhlwasserpumpe_chkbx = new System.Windows.Forms.CheckBox();
            this.hyperep_steuerstab_chkbx = new System.Windows.Forms.CheckBox();
            this.hyperep_filterreinigen_chkbx = new System.Windows.Forms.CheckBox();
            this.hyperep_kuhlwassernachfullpumpe_chkbx = new System.Windows.Forms.CheckBox();
            this.hyperep_generator_chkbx = new System.Windows.Forms.CheckBox();
            this.hyperep_turbine_chkbx = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.hypeRep_statuspanel = new System.Windows.Forms.GroupBox();
            this.hypeRep_dauer_lbl = new System.Windows.Forms.Label();
            this.hypeRep_status_lbl = new System.Windows.Forms.Label();
            this.summe_lbl = new System.Windows.Forms.Label();
            this.HypeRep_timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.hypeRep_statuspanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(510, 292);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Schließen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::AKW_Simulator.Properties.Resources.hyperep;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(573, 134);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // externrep_confirm_btn
            // 
            this.externrep_confirm_btn.Location = new System.Drawing.Point(426, 185);
            this.externrep_confirm_btn.Name = "externrep_confirm_btn";
            this.externrep_confirm_btn.Size = new System.Drawing.Size(159, 29);
            this.externrep_confirm_btn.TabIndex = 2;
            this.externrep_confirm_btn.Text = "Reparatur beauftragen";
            this.externrep_confirm_btn.UseVisualStyleBackColor = true;
            this.externrep_confirm_btn.Click += new System.EventHandler(this.externrep_confirm_btn_Click);
            // 
            // hyperep_kuhlwasserpumpe1_chkbx
            // 
            this.hyperep_kuhlwasserpumpe1_chkbx.AutoSize = true;
            this.hyperep_kuhlwasserpumpe1_chkbx.Location = new System.Drawing.Point(14, 44);
            this.hyperep_kuhlwasserpumpe1_chkbx.Name = "hyperep_kuhlwasserpumpe1_chkbx";
            this.hyperep_kuhlwasserpumpe1_chkbx.Size = new System.Drawing.Size(121, 17);
            this.hyperep_kuhlwasserpumpe1_chkbx.TabIndex = 3;
            this.hyperep_kuhlwasserpumpe1_chkbx.Text = "Kühlwasserpumpe 1";
            this.hyperep_kuhlwasserpumpe1_chkbx.UseVisualStyleBackColor = true;
            this.hyperep_kuhlwasserpumpe1_chkbx.CheckedChanged += new System.EventHandler(this.hyperep_kuhlwasserpumpe1_chkbx_CheckedChanged);
            // 
            // hyperep_kuhlwasserpumpe2_chkbx
            // 
            this.hyperep_kuhlwasserpumpe2_chkbx.AutoSize = true;
            this.hyperep_kuhlwasserpumpe2_chkbx.Location = new System.Drawing.Point(14, 67);
            this.hyperep_kuhlwasserpumpe2_chkbx.Name = "hyperep_kuhlwasserpumpe2_chkbx";
            this.hyperep_kuhlwasserpumpe2_chkbx.Size = new System.Drawing.Size(121, 17);
            this.hyperep_kuhlwasserpumpe2_chkbx.TabIndex = 4;
            this.hyperep_kuhlwasserpumpe2_chkbx.Text = "Kühlwasserpumpe 2";
            this.hyperep_kuhlwasserpumpe2_chkbx.UseVisualStyleBackColor = true;
            this.hyperep_kuhlwasserpumpe2_chkbx.CheckedChanged += new System.EventHandler(this.hyperep_kuhlwasserpumpe2_chkbx_CheckedChanged);
            // 
            // hyperep_ersatzkuhlwasserpumpe_chkbx
            // 
            this.hyperep_ersatzkuhlwasserpumpe_chkbx.AutoSize = true;
            this.hyperep_ersatzkuhlwasserpumpe_chkbx.Location = new System.Drawing.Point(14, 90);
            this.hyperep_ersatzkuhlwasserpumpe_chkbx.Name = "hyperep_ersatzkuhlwasserpumpe_chkbx";
            this.hyperep_ersatzkuhlwasserpumpe_chkbx.Size = new System.Drawing.Size(140, 17);
            this.hyperep_ersatzkuhlwasserpumpe_chkbx.TabIndex = 5;
            this.hyperep_ersatzkuhlwasserpumpe_chkbx.Text = "Ersatzkühlwasserpumpe";
            this.hyperep_ersatzkuhlwasserpumpe_chkbx.UseVisualStyleBackColor = true;
            this.hyperep_ersatzkuhlwasserpumpe_chkbx.CheckedChanged += new System.EventHandler(this.hyperep_ersatzkuhlwasserpumpe_chkbx_CheckedChanged);
            // 
            // hyperep_steuerstab_chkbx
            // 
            this.hyperep_steuerstab_chkbx.AutoSize = true;
            this.hyperep_steuerstab_chkbx.Location = new System.Drawing.Point(14, 113);
            this.hyperep_steuerstab_chkbx.Name = "hyperep_steuerstab_chkbx";
            this.hyperep_steuerstab_chkbx.Size = new System.Drawing.Size(83, 17);
            this.hyperep_steuerstab_chkbx.TabIndex = 6;
            this.hyperep_steuerstab_chkbx.Text = "Steuerstäbe";
            this.hyperep_steuerstab_chkbx.UseVisualStyleBackColor = true;
            this.hyperep_steuerstab_chkbx.CheckedChanged += new System.EventHandler(this.hyperep_steuerstab_chkbx_CheckedChanged);
            // 
            // hyperep_filterreinigen_chkbx
            // 
            this.hyperep_filterreinigen_chkbx.AutoSize = true;
            this.hyperep_filterreinigen_chkbx.Location = new System.Drawing.Point(215, 113);
            this.hyperep_filterreinigen_chkbx.Name = "hyperep_filterreinigen_chkbx";
            this.hyperep_filterreinigen_chkbx.Size = new System.Drawing.Size(48, 17);
            this.hyperep_filterreinigen_chkbx.TabIndex = 7;
            this.hyperep_filterreinigen_chkbx.Text = "Filter";
            this.hyperep_filterreinigen_chkbx.UseVisualStyleBackColor = true;
            this.hyperep_filterreinigen_chkbx.CheckedChanged += new System.EventHandler(this.hyperep_filterreinigen_chkbx_CheckedChanged);
            // 
            // hyperep_kuhlwassernachfullpumpe_chkbx
            // 
            this.hyperep_kuhlwassernachfullpumpe_chkbx.AutoSize = true;
            this.hyperep_kuhlwassernachfullpumpe_chkbx.Location = new System.Drawing.Point(215, 90);
            this.hyperep_kuhlwassernachfullpumpe_chkbx.Name = "hyperep_kuhlwassernachfullpumpe_chkbx";
            this.hyperep_kuhlwassernachfullpumpe_chkbx.Size = new System.Drawing.Size(149, 17);
            this.hyperep_kuhlwassernachfullpumpe_chkbx.TabIndex = 8;
            this.hyperep_kuhlwassernachfullpumpe_chkbx.Text = "Kühlwassernachfüllpumpe";
            this.hyperep_kuhlwassernachfullpumpe_chkbx.UseVisualStyleBackColor = true;
            this.hyperep_kuhlwassernachfullpumpe_chkbx.CheckedChanged += new System.EventHandler(this.hyperep_kuhlwassernachfullpumpe_chkbx_CheckedChanged);
            // 
            // hyperep_generator_chkbx
            // 
            this.hyperep_generator_chkbx.AutoSize = true;
            this.hyperep_generator_chkbx.Location = new System.Drawing.Point(215, 67);
            this.hyperep_generator_chkbx.Name = "hyperep_generator_chkbx";
            this.hyperep_generator_chkbx.Size = new System.Drawing.Size(73, 17);
            this.hyperep_generator_chkbx.TabIndex = 9;
            this.hyperep_generator_chkbx.Text = "Generator";
            this.hyperep_generator_chkbx.UseVisualStyleBackColor = true;
            this.hyperep_generator_chkbx.CheckedChanged += new System.EventHandler(this.hyperep_generator_chkbx_CheckedChanged);
            // 
            // hyperep_turbine_chkbx
            // 
            this.hyperep_turbine_chkbx.AutoSize = true;
            this.hyperep_turbine_chkbx.Location = new System.Drawing.Point(215, 45);
            this.hyperep_turbine_chkbx.Name = "hyperep_turbine_chkbx";
            this.hyperep_turbine_chkbx.Size = new System.Drawing.Size(62, 17);
            this.hyperep_turbine_chkbx.TabIndex = 10;
            this.hyperep_turbine_chkbx.Text = "Turbine";
            this.hyperep_turbine_chkbx.UseVisualStyleBackColor = true;
            this.hyperep_turbine_chkbx.CheckedChanged += new System.EventHandler(this.hyperep_turbine_chkbx_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(377, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Wählen Sie die zu reparierenden Komponenten aus:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.hyperep_filterreinigen_chkbx);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.hyperep_turbine_chkbx);
            this.panel1.Controls.Add(this.hyperep_kuhlwasserpumpe1_chkbx);
            this.panel1.Controls.Add(this.hyperep_kuhlwasserpumpe2_chkbx);
            this.panel1.Controls.Add(this.hyperep_ersatzkuhlwasserpumpe_chkbx);
            this.panel1.Controls.Add(this.hyperep_generator_chkbx);
            this.panel1.Controls.Add(this.hyperep_steuerstab_chkbx);
            this.panel1.Controls.Add(this.hyperep_kuhlwassernachfullpumpe_chkbx);
            this.panel1.Location = new System.Drawing.Point(12, 152);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(407, 163);
            this.panel1.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(170, 139);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 15);
            this.label11.TabIndex = 23;
            this.label11.Text = "+ 15 $ Anfahrt";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(371, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "(40$)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(160, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "(50$)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(160, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "(50$)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(371, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "(45$)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(160, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "(50$)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(160, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "(80$)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(371, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "(20$)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(371, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "(40$)";
            // 
            // hypeRep_statuspanel
            // 
            this.hypeRep_statuspanel.Controls.Add(this.hypeRep_dauer_lbl);
            this.hypeRep_statuspanel.Controls.Add(this.hypeRep_status_lbl);
            this.hypeRep_statuspanel.Location = new System.Drawing.Point(426, 220);
            this.hypeRep_statuspanel.Name = "hypeRep_statuspanel";
            this.hypeRep_statuspanel.Size = new System.Drawing.Size(159, 66);
            this.hypeRep_statuspanel.TabIndex = 13;
            this.hypeRep_statuspanel.TabStop = false;
            this.hypeRep_statuspanel.Text = "Status";
            this.hypeRep_statuspanel.Visible = false;
            // 
            // hypeRep_dauer_lbl
            // 
            this.hypeRep_dauer_lbl.AutoSize = true;
            this.hypeRep_dauer_lbl.Location = new System.Drawing.Point(22, 46);
            this.hypeRep_dauer_lbl.Name = "hypeRep_dauer_lbl";
            this.hypeRep_dauer_lbl.Size = new System.Drawing.Size(44, 13);
            this.hypeRep_dauer_lbl.TabIndex = 1;
            this.hypeRep_dauer_lbl.Text = "10 Sek.";
            // 
            // hypeRep_status_lbl
            // 
            this.hypeRep_status_lbl.AutoSize = true;
            this.hypeRep_status_lbl.Location = new System.Drawing.Point(6, 18);
            this.hypeRep_status_lbl.Name = "hypeRep_status_lbl";
            this.hypeRep_status_lbl.Size = new System.Drawing.Size(115, 13);
            this.hypeRep_status_lbl.TabIndex = 0;
            this.hypeRep_status_lbl.Text = "HypeRep kommt an in:";
            // 
            // summe_lbl
            // 
            this.summe_lbl.AutoSize = true;
            this.summe_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.summe_lbl.Location = new System.Drawing.Point(425, 160);
            this.summe_lbl.Name = "summe_lbl";
            this.summe_lbl.Size = new System.Drawing.Size(81, 16);
            this.summe_lbl.TabIndex = 14;
            this.summe_lbl.Text = "Summe: 15$";
            // 
            // HypeRep_timer
            // 
            this.HypeRep_timer.Interval = 1000;
            this.HypeRep_timer.Tick += new System.EventHandler(this.HypeRep_timer_Tick);
            // 
            // HypeRep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 327);
            this.Controls.Add(this.summe_lbl);
            this.Controls.Add(this.hypeRep_statuspanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.externrep_confirm_btn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HypeRep";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "HypeRep";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HypeRep_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.hypeRep_statuspanel.ResumeLayout(false);
            this.hypeRep_statuspanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button externrep_confirm_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox hypeRep_statuspanel;
        private System.Windows.Forms.Label hypeRep_dauer_lbl;
        private System.Windows.Forms.Label hypeRep_status_lbl;
        internal System.Windows.Forms.CheckBox hyperep_kuhlwasserpumpe1_chkbx;
        internal System.Windows.Forms.CheckBox hyperep_kuhlwasserpumpe2_chkbx;
        internal System.Windows.Forms.CheckBox hyperep_ersatzkuhlwasserpumpe_chkbx;
        internal System.Windows.Forms.CheckBox hyperep_steuerstab_chkbx;
        internal System.Windows.Forms.CheckBox hyperep_filterreinigen_chkbx;
        internal System.Windows.Forms.CheckBox hyperep_kuhlwassernachfullpumpe_chkbx;
        internal System.Windows.Forms.CheckBox hyperep_generator_chkbx;
        internal System.Windows.Forms.CheckBox hyperep_turbine_chkbx;
        private System.Windows.Forms.Label summe_lbl;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Timer HypeRep_timer;
    }
}