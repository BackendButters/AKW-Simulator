namespace AKW_Simulator
{
    partial class JimBonusWindow
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
            this.jimbonus_txtbx = new System.Windows.Forms.TextBox();
            this.geldgeben_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.hide_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // jimbonus_txtbx
            // 
            this.jimbonus_txtbx.Location = new System.Drawing.Point(15, 46);
            this.jimbonus_txtbx.Name = "jimbonus_txtbx";
            this.jimbonus_txtbx.Size = new System.Drawing.Size(98, 20);
            this.jimbonus_txtbx.TabIndex = 0;
            // 
            // geldgeben_btn
            // 
            this.geldgeben_btn.Location = new System.Drawing.Point(143, 43);
            this.geldgeben_btn.Name = "geldgeben_btn";
            this.geldgeben_btn.Size = new System.Drawing.Size(75, 23);
            this.geldgeben_btn.TabIndex = 1;
            this.geldgeben_btn.Text = "Geben";
            this.geldgeben_btn.UseVisualStyleBackColor = true;
            this.geldgeben_btn.Click += new System.EventHandler(this.geldgeben_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hier können Sie Jim eine Prämie geben.";
            // 
            // hide_btn
            // 
            this.hide_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.hide_btn.Location = new System.Drawing.Point(272, 104);
            this.hide_btn.Name = "hide_btn";
            this.hide_btn.Size = new System.Drawing.Size(75, 23);
            this.hide_btn.TabIndex = 2;
            this.hide_btn.Text = "Abbrechen";
            this.hide_btn.UseVisualStyleBackColor = true;
            this.hide_btn.Click += new System.EventHandler(this.hide_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(119, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "$";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::AKW_Simulator.Properties.Resources.Stub_edilizia;
            this.pictureBox2.Location = new System.Drawing.Point(265, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(82, 86);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AKW_Simulator.Properties.Resources.PowerCom_Logo_247x56;
            this.pictureBox1.Location = new System.Drawing.Point(12, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(247, 56);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // JimBonusWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.hide_btn;
            this.ClientSize = new System.Drawing.Size(359, 139);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hide_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.geldgeben_btn);
            this.Controls.Add(this.jimbonus_txtbx);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JimBonusWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "JimBonusWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.JimBonusWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox jimbonus_txtbx;
        private System.Windows.Forms.Button geldgeben_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button hide_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}