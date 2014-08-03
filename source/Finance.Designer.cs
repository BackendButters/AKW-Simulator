namespace AKW_Simulator
{
    partial class Finance
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.hide_btn = new System.Windows.Forms.Button();
            this.refreshzeitgeber = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.graphen_picturebox = new System.Windows.Forms.PictureBox();
            this.blau_label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Rot_label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.green_label = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.gelb_label = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.orange_label = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rot_checkbox = new System.Windows.Forms.CheckBox();
            this.blue_checkbox = new System.Windows.Forms.CheckBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.schwarz_checkbox = new System.Windows.Forms.CheckBox();
            this.gold_checkbox = new System.Windows.Forms.CheckBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.oranje_checkbox = new System.Windows.Forms.CheckBox();
            this.green_checkbox = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphen_picturebox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // hide_btn
            // 
            this.hide_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.hide_btn.Location = new System.Drawing.Point(784, 424);
            this.hide_btn.Name = "hide_btn";
            this.hide_btn.Size = new System.Drawing.Size(75, 23);
            this.hide_btn.TabIndex = 0;
            this.hide_btn.Text = "Schließen";
            this.hide_btn.UseVisualStyleBackColor = true;
            this.hide_btn.Click += new System.EventHandler(this.hide_btn_Click);
            // 
            // refreshzeitgeber
            // 
            this.refreshzeitgeber.Enabled = true;
            this.refreshzeitgeber.Interval = 200;
            this.refreshzeitgeber.Tick += new System.EventHandler(this.refreshzeitgeber_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.graphen_picturebox);
            this.panel1.Location = new System.Drawing.Point(44, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(815, 310);
            this.panel1.TabIndex = 1;
            // 
            // graphen_picturebox
            // 
            this.graphen_picturebox.BackColor = System.Drawing.SystemColors.Window;
            this.graphen_picturebox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphen_picturebox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphen_picturebox.Location = new System.Drawing.Point(0, 0);
            this.graphen_picturebox.Name = "graphen_picturebox";
            this.graphen_picturebox.Size = new System.Drawing.Size(815, 310);
            this.graphen_picturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.graphen_picturebox.TabIndex = 0;
            this.graphen_picturebox.TabStop = false;
            // 
            // blau_label
            // 
            this.blau_label.AutoSize = true;
            this.blau_label.Location = new System.Drawing.Point(3, 32);
            this.blau_label.Name = "blau_label";
            this.blau_label.Size = new System.Drawing.Size(31, 13);
            this.blau_label.TabIndex = 2;
            this.blau_label.Text = "Blau:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "MW/s Preis";
            // 
            // Rot_label
            // 
            this.Rot_label.AutoSize = true;
            this.Rot_label.Location = new System.Drawing.Point(3, 10);
            this.Rot_label.Name = "Rot_label";
            this.Rot_label.Size = new System.Drawing.Size(27, 13);
            this.Rot_label.TabIndex = 4;
            this.Rot_label.Text = "Rot:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Temperatur";
            // 
            // green_label
            // 
            this.green_label.AutoSize = true;
            this.green_label.Location = new System.Drawing.Point(3, 31);
            this.green_label.Name = "green_label";
            this.green_label.Size = new System.Drawing.Size(33, 13);
            this.green_label.TabIndex = 6;
            this.green_label.Text = "Grün:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(54, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Guthaben";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Schwarz:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(63, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Reaktorleistung";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 333);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "(150)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "1500";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "3000";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "(300)";
            // 
            // gelb_label
            // 
            this.gelb_label.AutoSize = true;
            this.gelb_label.Location = new System.Drawing.Point(3, 8);
            this.gelb_label.Name = "gelb_label";
            this.gelb_label.Size = new System.Drawing.Size(32, 13);
            this.gelb_label.TabIndex = 10;
            this.gelb_label.Text = "Gold:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(63, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "benötigte Leistung";
            // 
            // orange_label
            // 
            this.orange_label.AutoSize = true;
            this.orange_label.Location = new System.Drawing.Point(3, 8);
            this.orange_label.Name = "orange_label";
            this.orange_label.Size = new System.Drawing.Size(45, 13);
            this.orange_label.TabIndex = 13;
            this.orange_label.Text = "Orange:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(40, 33);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 13);
            this.label15.TabIndex = 15;
            this.label15.Text = "Pumpenleistung";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(393, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(111, 24);
            this.label13.TabIndex = 16;
            this.label13.Text = "Auswertung";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel8);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Location = new System.Drawing.Point(44, 352);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(705, 85);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Legende";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.Rot_label);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.rot_checkbox);
            this.panel2.Controls.Add(this.blau_label);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.blue_checkbox);
            this.panel2.Location = new System.Drawing.Point(470, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(226, 54);
            this.panel2.TabIndex = 23;
            // 
            // rot_checkbox
            // 
            this.rot_checkbox.AutoSize = true;
            this.rot_checkbox.Checked = true;
            this.rot_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rot_checkbox.Location = new System.Drawing.Point(128, 9);
            this.rot_checkbox.Name = "rot_checkbox";
            this.rot_checkbox.Size = new System.Drawing.Size(59, 17);
            this.rot_checkbox.TabIndex = 0;
            this.rot_checkbox.Text = "Zeigen";
            this.rot_checkbox.UseVisualStyleBackColor = true;
            // 
            // blue_checkbox
            // 
            this.blue_checkbox.AutoSize = true;
            this.blue_checkbox.Checked = true;
            this.blue_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.blue_checkbox.Location = new System.Drawing.Point(128, 32);
            this.blue_checkbox.Name = "blue_checkbox";
            this.blue_checkbox.Size = new System.Drawing.Size(59, 17);
            this.blue_checkbox.TabIndex = 1;
            this.blue_checkbox.Text = "Zeigen";
            this.blue_checkbox.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.schwarz_checkbox);
            this.panel8.Controls.Add(this.label7);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Controls.Add(this.gold_checkbox);
            this.panel8.Controls.Add(this.gelb_label);
            this.panel8.Controls.Add(this.label12);
            this.panel8.Location = new System.Drawing.Point(6, 19);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(226, 54);
            this.panel8.TabIndex = 22;
            // 
            // schwarz_checkbox
            // 
            this.schwarz_checkbox.AutoSize = true;
            this.schwarz_checkbox.Checked = true;
            this.schwarz_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.schwarz_checkbox.Location = new System.Drawing.Point(163, 30);
            this.schwarz_checkbox.Name = "schwarz_checkbox";
            this.schwarz_checkbox.Size = new System.Drawing.Size(59, 17);
            this.schwarz_checkbox.TabIndex = 1;
            this.schwarz_checkbox.Text = "Zeigen";
            this.schwarz_checkbox.UseVisualStyleBackColor = true;
            // 
            // gold_checkbox
            // 
            this.gold_checkbox.AutoSize = true;
            this.gold_checkbox.Checked = true;
            this.gold_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gold_checkbox.Location = new System.Drawing.Point(163, 7);
            this.gold_checkbox.Name = "gold_checkbox";
            this.gold_checkbox.Size = new System.Drawing.Size(59, 17);
            this.gold_checkbox.TabIndex = 0;
            this.gold_checkbox.Text = "Zeigen";
            this.gold_checkbox.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.oranje_checkbox);
            this.panel5.Controls.Add(this.orange_label);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.green_checkbox);
            this.panel5.Controls.Add(this.green_label);
            this.panel5.Location = new System.Drawing.Point(238, 19);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(226, 54);
            this.panel5.TabIndex = 19;
            // 
            // oranje_checkbox
            // 
            this.oranje_checkbox.AutoSize = true;
            this.oranje_checkbox.Checked = true;
            this.oranje_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.oranje_checkbox.Location = new System.Drawing.Point(137, 7);
            this.oranje_checkbox.Name = "oranje_checkbox";
            this.oranje_checkbox.Size = new System.Drawing.Size(59, 17);
            this.oranje_checkbox.TabIndex = 0;
            this.oranje_checkbox.Text = "Zeigen";
            this.oranje_checkbox.UseVisualStyleBackColor = true;
            // 
            // green_checkbox
            // 
            this.green_checkbox.AutoSize = true;
            this.green_checkbox.Checked = true;
            this.green_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.green_checkbox.Location = new System.Drawing.Point(137, 30);
            this.green_checkbox.Name = "green_checkbox";
            this.green_checkbox.Size = new System.Drawing.Size(59, 17);
            this.green_checkbox.TabIndex = 1;
            this.green_checkbox.Text = "Zeigen";
            this.green_checkbox.UseVisualStyleBackColor = true;
            // 
            // Finance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.hide_btn;
            this.ClientSize = new System.Drawing.Size(871, 459);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.hide_btn);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Finance";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Finanzübersicht";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Finance_FormClosing);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.graphen_picturebox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button hide_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox graphen_picturebox;
        internal System.Windows.Forms.Timer refreshzeitgeber;
        private System.Windows.Forms.Label blau_label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Rot_label;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label green_label;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label gelb_label;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label orange_label;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox rot_checkbox;
        private System.Windows.Forms.CheckBox oranje_checkbox;
        private System.Windows.Forms.CheckBox schwarz_checkbox;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.CheckBox gold_checkbox;
        private System.Windows.Forms.CheckBox green_checkbox;
        private System.Windows.Forms.CheckBox blue_checkbox;
        private System.Windows.Forms.Panel panel2;
    }
}