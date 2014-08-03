namespace AKW_Simulator
{
    partial class Mails
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.mailliste = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Mailtext_rttbx = new System.Windows.Forms.RichTextBox();
            this.betreff_txtbx = new System.Windows.Forms.TextBox();
            this.empfangszeit_txtbx = new System.Windows.Forms.TextBox();
            this.absender_txtbx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.hide_btn = new System.Windows.Forms.Button();
            this.anhang_offnen_btn = new System.Windows.Forms.Button();
            this.mail_delete_btn = new System.Windows.Forms.Button();
            this.delete_all_mails_btn = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.mailliste);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.betreff_txtbx);
            this.splitContainer1.Panel2.Controls.Add(this.empfangszeit_txtbx);
            this.splitContainer1.Panel2.Controls.Add(this.absender_txtbx);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(677, 367);
            this.splitContainer1.SplitterDistance = 225;
            this.splitContainer1.TabIndex = 2;
            // 
            // mailliste
            // 
            this.mailliste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mailliste.FormattingEnabled = true;
            this.mailliste.Location = new System.Drawing.Point(0, 0);
            this.mailliste.Name = "mailliste";
            this.mailliste.Size = new System.Drawing.Size(223, 355);
            this.mailliste.TabIndex = 0;
            this.mailliste.SelectedIndexChanged += new System.EventHandler(this.mailliste_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Mailtext_rttbx);
            this.panel1.Location = new System.Drawing.Point(0, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(447, 276);
            this.panel1.TabIndex = 6;
            // 
            // Mailtext_rttbx
            // 
            this.Mailtext_rttbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Mailtext_rttbx.Location = new System.Drawing.Point(0, 0);
            this.Mailtext_rttbx.Name = "Mailtext_rttbx";
            this.Mailtext_rttbx.ReadOnly = true;
            this.Mailtext_rttbx.Size = new System.Drawing.Size(447, 276);
            this.Mailtext_rttbx.TabIndex = 0;
            this.Mailtext_rttbx.Text = "";
            // 
            // betreff_txtbx
            // 
            this.betreff_txtbx.Location = new System.Drawing.Point(99, 63);
            this.betreff_txtbx.Name = "betreff_txtbx";
            this.betreff_txtbx.ReadOnly = true;
            this.betreff_txtbx.Size = new System.Drawing.Size(336, 20);
            this.betreff_txtbx.TabIndex = 5;
            // 
            // empfangszeit_txtbx
            // 
            this.empfangszeit_txtbx.Location = new System.Drawing.Point(99, 37);
            this.empfangszeit_txtbx.Name = "empfangszeit_txtbx";
            this.empfangszeit_txtbx.ReadOnly = true;
            this.empfangszeit_txtbx.Size = new System.Drawing.Size(336, 20);
            this.empfangszeit_txtbx.TabIndex = 4;
            // 
            // absender_txtbx
            // 
            this.absender_txtbx.Location = new System.Drawing.Point(99, 11);
            this.absender_txtbx.Name = "absender_txtbx";
            this.absender_txtbx.ReadOnly = true;
            this.absender_txtbx.Size = new System.Drawing.Size(336, 20);
            this.absender_txtbx.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Betreff:.......................";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Empfangszeit:.......................";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Absender:.............................................";
            // 
            // hide_btn
            // 
            this.hide_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.hide_btn.Location = new System.Drawing.Point(590, 373);
            this.hide_btn.Name = "hide_btn";
            this.hide_btn.Size = new System.Drawing.Size(75, 26);
            this.hide_btn.TabIndex = 0;
            this.hide_btn.Text = "Schließen";
            this.hide_btn.UseVisualStyleBackColor = true;
            this.hide_btn.Click += new System.EventHandler(this.hide_btn_Click);
            // 
            // anhang_offnen_btn
            // 
            this.anhang_offnen_btn.Location = new System.Drawing.Point(491, 373);
            this.anhang_offnen_btn.Name = "anhang_offnen_btn";
            this.anhang_offnen_btn.Size = new System.Drawing.Size(93, 26);
            this.anhang_offnen_btn.TabIndex = 3;
            this.anhang_offnen_btn.Text = "Anhang öffnen";
            this.anhang_offnen_btn.UseVisualStyleBackColor = true;
            this.anhang_offnen_btn.Visible = false;
            this.anhang_offnen_btn.Click += new System.EventHandler(this.anhang_offnen_btn_Click);
            // 
            // mail_delete_btn
            // 
            this.mail_delete_btn.Location = new System.Drawing.Point(230, 373);
            this.mail_delete_btn.Name = "mail_delete_btn";
            this.mail_delete_btn.Size = new System.Drawing.Size(142, 26);
            this.mail_delete_btn.TabIndex = 4;
            this.mail_delete_btn.Text = "Ausgewählte Mail löschen";
            this.mail_delete_btn.UseVisualStyleBackColor = true;
            this.mail_delete_btn.Click += new System.EventHandler(this.mail_delete_btn_Click);
            // 
            // delete_all_mails_btn
            // 
            this.delete_all_mails_btn.Location = new System.Drawing.Point(78, 373);
            this.delete_all_mails_btn.Name = "delete_all_mails_btn";
            this.delete_all_mails_btn.Size = new System.Drawing.Size(146, 26);
            this.delete_all_mails_btn.TabIndex = 5;
            this.delete_all_mails_btn.Text = "Alle Mails löschen";
            this.delete_all_mails_btn.UseVisualStyleBackColor = true;
            this.delete_all_mails_btn.Click += new System.EventHandler(this.delete_all_mails_btn_Click);
            // 
            // Mails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.hide_btn;
            this.ClientSize = new System.Drawing.Size(677, 411);
            this.Controls.Add(this.delete_all_mails_btn);
            this.Controls.Add(this.mail_delete_btn);
            this.Controls.Add(this.anhang_offnen_btn);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.hide_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Mails";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "eMails";
            this.Load += new System.EventHandler(this.Mails_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Mails_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button hide_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button anhang_offnen_btn;
        internal System.Windows.Forms.TextBox betreff_txtbx;
        internal System.Windows.Forms.TextBox empfangszeit_txtbx;
        internal System.Windows.Forms.TextBox absender_txtbx;
        internal System.Windows.Forms.RichTextBox Mailtext_rttbx;
        internal System.Windows.Forms.ListBox mailliste;
        private System.Windows.Forms.Button mail_delete_btn;
        private System.Windows.Forms.Button delete_all_mails_btn;
    }
}