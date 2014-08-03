namespace AKW_Simulator
{
    partial class Technikchat
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
            this.button1 = new System.Windows.Forms.Button();
            this.chatbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.jimbonus_btn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.reparatur_abbrechen_btn = new System.Windows.Forms.Button();
            this.technikbereit_panel = new System.Windows.Forms.GroupBox();
            this.Technikbereit_label = new System.Windows.Forms.Label();
            this.technikfrei_timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.technikbereit_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(248, 277);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 36);
            this.button1.TabIndex = 1;
            this.button1.Text = "Chat schließen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chatbox
            // 
            this.chatbox.Location = new System.Drawing.Point(12, 36);
            this.chatbox.Multiline = true;
            this.chatbox.Name = "chatbox";
            this.chatbox.ReadOnly = true;
            this.chatbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chatbox.Size = new System.Drawing.Size(360, 187);
            this.chatbox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "T e c h n i k e r c h a t";
            // 
            // jimbonus_btn
            // 
            this.jimbonus_btn.Location = new System.Drawing.Point(12, 229);
            this.jimbonus_btn.Name = "jimbonus_btn";
            this.jimbonus_btn.Size = new System.Drawing.Size(130, 37);
            this.jimbonus_btn.TabIndex = 0;
            this.jimbonus_btn.Text = "Jim eine Prämie geben";
            this.jimbonus_btn.UseVisualStyleBackColor = true;
            this.jimbonus_btn.Click += new System.EventHandler(this.jimbonus_btn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AKW_Simulator.Properties.Resources.Stub_edilizia;
            this.pictureBox1.Location = new System.Drawing.Point(148, 230);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(92, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // reparatur_abbrechen_btn
            // 
            this.reparatur_abbrechen_btn.Location = new System.Drawing.Point(12, 272);
            this.reparatur_abbrechen_btn.Name = "reparatur_abbrechen_btn";
            this.reparatur_abbrechen_btn.Size = new System.Drawing.Size(129, 36);
            this.reparatur_abbrechen_btn.TabIndex = 5;
            this.reparatur_abbrechen_btn.Text = "Aufgabe des Technikers abbrechen";
            this.reparatur_abbrechen_btn.UseVisualStyleBackColor = true;
            this.reparatur_abbrechen_btn.Click += new System.EventHandler(this.reparatur_abbrechen_btn_Click);
            // 
            // technikbereit_panel
            // 
            this.technikbereit_panel.Controls.Add(this.Technikbereit_label);
            this.technikbereit_panel.Location = new System.Drawing.Point(248, 229);
            this.technikbereit_panel.Name = "technikbereit_panel";
            this.technikbereit_panel.Size = new System.Drawing.Size(125, 41);
            this.technikbereit_panel.TabIndex = 6;
            this.technikbereit_panel.TabStop = false;
            this.technikbereit_panel.Text = "Techniker bereit in:";
            this.technikbereit_panel.Visible = false;
            // 
            // Technikbereit_label
            // 
            this.Technikbereit_label.AutoSize = true;
            this.Technikbereit_label.Location = new System.Drawing.Point(16, 18);
            this.Technikbereit_label.Name = "Technikbereit_label";
            this.Technikbereit_label.Size = new System.Drawing.Size(44, 13);
            this.Technikbereit_label.TabIndex = 0;
            this.Technikbereit_label.Text = "10 Sek.";
            // 
            // technikfrei_timer
            // 
            this.technikfrei_timer.Interval = 1000;
            this.technikfrei_timer.Tick += new System.EventHandler(this.technikfrei_timer_Tick);
            // 
            // Technikchat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(383, 326);
            this.Controls.Add(this.technikbereit_panel);
            this.Controls.Add(this.reparatur_abbrechen_btn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.jimbonus_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chatbox);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Technikchat";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Technikerchat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.technikchat_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.technikbereit_panel.ResumeLayout(false);
            this.technikbereit_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox chatbox;
        private System.Windows.Forms.Button jimbonus_btn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button reparatur_abbrechen_btn;
        private System.Windows.Forms.GroupBox technikbereit_panel;
        private System.Windows.Forms.Label Technikbereit_label;
        private System.Windows.Forms.Timer technikfrei_timer;
    }
}