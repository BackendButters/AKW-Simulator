namespace AKW_Simulator
{
    partial class NewsWindow
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
            this.NewsLaden_btn = new System.Windows.Forms.Button();
            this.closeWindow_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.message_txtbx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.newVersion_txtbx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.installedversion_txtbx = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.changelog_txtbx = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // NewsLaden_btn
            // 
            this.NewsLaden_btn.Location = new System.Drawing.Point(521, 241);
            this.NewsLaden_btn.Name = "NewsLaden_btn";
            this.NewsLaden_btn.Size = new System.Drawing.Size(94, 35);
            this.NewsLaden_btn.TabIndex = 0;
            this.NewsLaden_btn.Text = "News abrufen";
            this.NewsLaden_btn.UseVisualStyleBackColor = true;
            this.NewsLaden_btn.Click += new System.EventHandler(this.NewsLaden_btn_Click);
            // 
            // closeWindow_btn
            // 
            this.closeWindow_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeWindow_btn.Location = new System.Drawing.Point(621, 241);
            this.closeWindow_btn.Name = "closeWindow_btn";
            this.closeWindow_btn.Size = new System.Drawing.Size(94, 35);
            this.closeWindow_btn.TabIndex = 1;
            this.closeWindow_btn.Text = "Fenster schließen";
            this.closeWindow_btn.UseVisualStyleBackColor = true;
            this.closeWindow_btn.Click += new System.EventHandler(this.closeWindow_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(325, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Spiel-News";
            // 
            // message_txtbx
            // 
            this.message_txtbx.Location = new System.Drawing.Point(79, 36);
            this.message_txtbx.Multiline = true;
            this.message_txtbx.Name = "message_txtbx";
            this.message_txtbx.ReadOnly = true;
            this.message_txtbx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.message_txtbx.Size = new System.Drawing.Size(397, 77);
            this.message_txtbx.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nachricht:";
            // 
            // newVersion_txtbx
            // 
            this.newVersion_txtbx.Location = new System.Drawing.Point(614, 33);
            this.newVersion_txtbx.Name = "newVersion_txtbx";
            this.newVersion_txtbx.ReadOnly = true;
            this.newVersion_txtbx.Size = new System.Drawing.Size(101, 20);
            this.newVersion_txtbx.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(513, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Neuste Version:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(513, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Installierte Version:";
            // 
            // installedversion_txtbx
            // 
            this.installedversion_txtbx.Location = new System.Drawing.Point(614, 59);
            this.installedversion_txtbx.Name = "installedversion_txtbx";
            this.installedversion_txtbx.ReadOnly = true;
            this.installedversion_txtbx.Size = new System.Drawing.Size(101, 20);
            this.installedversion_txtbx.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Changelog:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(512, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Supportwebsite:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(601, 120);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(102, 13);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "www.FSSNET-N.de";
            this.linkLabel1.Click += new System.EventHandler(this.linkLabel1_Click);
            // 
            // changelog_txtbx
            // 
            this.changelog_txtbx.Location = new System.Drawing.Point(80, 120);
            this.changelog_txtbx.Name = "changelog_txtbx";
            this.changelog_txtbx.ReadOnly = true;
            this.changelog_txtbx.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.changelog_txtbx.Size = new System.Drawing.Size(396, 156);
            this.changelog_txtbx.TabIndex = 13;
            this.changelog_txtbx.Text = "";
            // 
            // NewsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeWindow_btn;
            this.ClientSize = new System.Drawing.Size(727, 288);
            this.Controls.Add(this.changelog_txtbx);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.installedversion_txtbx);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.newVersion_txtbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.message_txtbx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.closeWindow_btn);
            this.Controls.Add(this.NewsLaden_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewsWindow";
            this.ShowInTaskbar = false;
            this.Text = "Spiel-News";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewsWindow_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NewsLaden_btn;
        private System.Windows.Forms.Button closeWindow_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox message_txtbx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox newVersion_txtbx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox installedversion_txtbx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.RichTextBox changelog_txtbx;
    }
}