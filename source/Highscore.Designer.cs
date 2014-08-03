namespace AKW_Simulator
{
    partial class Highscore
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
            this.hide_btn = new System.Windows.Forms.Button();
            this.HighscoreGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.HighscoreEintragen_panel = new System.Windows.Forms.GroupBox();
            this.HighscoreName_txtbx = new System.Windows.Forms.TextBox();
            this.HighscoreEintragen_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.guthaben_label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.erwirtschaftetes_guthaben_panel = new System.Windows.Forms.Panel();
            this.refresh_btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.suchen_btn = new System.Windows.Forms.Button();
            this.spielersuche_txtbx = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.HighscoreGrid)).BeginInit();
            this.HighscoreEintragen_panel.SuspendLayout();
            this.erwirtschaftetes_guthaben_panel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hide_btn
            // 
            this.hide_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.hide_btn.Location = new System.Drawing.Point(588, 398);
            this.hide_btn.Name = "hide_btn";
            this.hide_btn.Size = new System.Drawing.Size(75, 23);
            this.hide_btn.TabIndex = 0;
            this.hide_btn.Text = "Schließen";
            this.hide_btn.UseVisualStyleBackColor = true;
            this.hide_btn.Click += new System.EventHandler(this.hide_btn_Click);
            // 
            // HighscoreGrid
            // 
            this.HighscoreGrid.AllowUserToAddRows = false;
            this.HighscoreGrid.AllowUserToDeleteRows = false;
            this.HighscoreGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HighscoreGrid.Location = new System.Drawing.Point(12, 32);
            this.HighscoreGrid.Name = "HighscoreGrid";
            this.HighscoreGrid.ReadOnly = true;
            this.HighscoreGrid.Size = new System.Drawing.Size(651, 279);
            this.HighscoreGrid.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(229, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "AKW-Simulator Highscore";
            // 
            // HighscoreEintragen_panel
            // 
            this.HighscoreEintragen_panel.Controls.Add(this.HighscoreName_txtbx);
            this.HighscoreEintragen_panel.Controls.Add(this.HighscoreEintragen_btn);
            this.HighscoreEintragen_panel.Controls.Add(this.label2);
            this.HighscoreEintragen_panel.Location = new System.Drawing.Point(204, 371);
            this.HighscoreEintragen_panel.Name = "HighscoreEintragen_panel";
            this.HighscoreEintragen_panel.Size = new System.Drawing.Size(378, 56);
            this.HighscoreEintragen_panel.TabIndex = 3;
            this.HighscoreEintragen_panel.TabStop = false;
            this.HighscoreEintragen_panel.Text = "Ihren Gewinn eintragen";
            // 
            // HighscoreName_txtbx
            // 
            this.HighscoreName_txtbx.Location = new System.Drawing.Point(90, 19);
            this.HighscoreName_txtbx.Name = "HighscoreName_txtbx";
            this.HighscoreName_txtbx.Size = new System.Drawing.Size(164, 20);
            this.HighscoreName_txtbx.TabIndex = 2;
            // 
            // HighscoreEintragen_btn
            // 
            this.HighscoreEintragen_btn.Location = new System.Drawing.Point(260, 16);
            this.HighscoreEintragen_btn.Name = "HighscoreEintragen_btn";
            this.HighscoreEintragen_btn.Size = new System.Drawing.Size(100, 23);
            this.HighscoreEintragen_btn.TabIndex = 1;
            this.HighscoreEintragen_btn.Text = "Eintragen";
            this.HighscoreEintragen_btn.UseVisualStyleBackColor = true;
            this.HighscoreEintragen_btn.Click += new System.EventHandler(this.HighscoreEintragen_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name:";
            // 
            // guthaben_label
            // 
            this.guthaben_label.AutoSize = true;
            this.guthaben_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guthaben_label.ForeColor = System.Drawing.Color.DarkOrange;
            this.guthaben_label.Location = new System.Drawing.Point(45, 27);
            this.guthaben_label.Name = "guthaben_label";
            this.guthaben_label.Size = new System.Drawing.Size(121, 23);
            this.guthaben_label.TabIndex = 3;
            this.guthaben_label.Text = "guthaben_label";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Erwirtschaftetes Guthaben:";
            // 
            // erwirtschaftetes_guthaben_panel
            // 
            this.erwirtschaftetes_guthaben_panel.Controls.Add(this.guthaben_label);
            this.erwirtschaftetes_guthaben_panel.Controls.Add(this.label4);
            this.erwirtschaftetes_guthaben_panel.Location = new System.Drawing.Point(12, 364);
            this.erwirtschaftetes_guthaben_panel.Name = "erwirtschaftetes_guthaben_panel";
            this.erwirtschaftetes_guthaben_panel.Size = new System.Drawing.Size(186, 63);
            this.erwirtschaftetes_guthaben_panel.TabIndex = 5;
            this.erwirtschaftetes_guthaben_panel.Visible = false;
            // 
            // refresh_btn
            // 
            this.refresh_btn.Location = new System.Drawing.Point(588, 371);
            this.refresh_btn.Name = "refresh_btn";
            this.refresh_btn.Size = new System.Drawing.Size(75, 23);
            this.refresh_btn.TabIndex = 6;
            this.refresh_btn.Text = "Refresh";
            this.refresh_btn.UseVisualStyleBackColor = true;
            this.refresh_btn.Click += new System.EventHandler(this.refresh_btn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.suchen_btn);
            this.groupBox1.Controls.Add(this.spielersuche_txtbx);
            this.groupBox1.Location = new System.Drawing.Point(12, 317);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(651, 48);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Suchen";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(357, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Spielername eingeben (nur exakt eingegebene Namen werden angezeigt):";
            // 
            // suchen_btn
            // 
            this.suchen_btn.Location = new System.Drawing.Point(531, 16);
            this.suchen_btn.Name = "suchen_btn";
            this.suchen_btn.Size = new System.Drawing.Size(114, 23);
            this.suchen_btn.TabIndex = 8;
            this.suchen_btn.Text = "Spieler suchen";
            this.suchen_btn.UseVisualStyleBackColor = true;
            this.suchen_btn.Click += new System.EventHandler(this.suchen_btn_Click);
            // 
            // spielersuche_txtbx
            // 
            this.spielersuche_txtbx.Location = new System.Drawing.Point(386, 18);
            this.spielersuche_txtbx.Name = "spielersuche_txtbx";
            this.spielersuche_txtbx.Size = new System.Drawing.Size(139, 20);
            this.spielersuche_txtbx.TabIndex = 0;
            // 
            // Highscore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.hide_btn;
            this.ClientSize = new System.Drawing.Size(675, 433);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.refresh_btn);
            this.Controls.Add(this.erwirtschaftetes_guthaben_panel);
            this.Controls.Add(this.HighscoreEintragen_panel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HighscoreGrid);
            this.Controls.Add(this.hide_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Highscore";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Highscore";
            this.Load += new System.EventHandler(this.Highscore_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Highscore_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.HighscoreGrid)).EndInit();
            this.HighscoreEintragen_panel.ResumeLayout(false);
            this.HighscoreEintragen_panel.PerformLayout();
            this.erwirtschaftetes_guthaben_panel.ResumeLayout(false);
            this.erwirtschaftetes_guthaben_panel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button hide_btn;
        private System.Windows.Forms.DataGridView HighscoreGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox HighscoreName_txtbx;
        private System.Windows.Forms.Button HighscoreEintragen_btn;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.GroupBox HighscoreEintragen_panel;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Panel erwirtschaftetes_guthaben_panel;
        internal System.Windows.Forms.Label guthaben_label;
        private System.Windows.Forms.Button refresh_btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button suchen_btn;
        private System.Windows.Forms.TextBox spielersuche_txtbx;
    }
}