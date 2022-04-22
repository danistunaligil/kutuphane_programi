namespace kütüphane
{
    partial class ayarlar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ayarlar));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bYeni = new System.Windows.Forms.ToolStripButton();
            this.bDüzenle = new System.Windows.Forms.ToolStripButton();
            this.bSil = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bKaydet = new System.Windows.Forms.ToolStripButton();
            this.bİptal = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cYetki = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kullanıcı Adı";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(94, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(136, 20);
            this.textBox1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Şifre";
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 16);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(212, 179);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 156);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 198);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tüm kullanıcılar";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bYeni,
            this.bDüzenle,
            this.bSil,
            this.toolStripSeparator1,
            this.bKaydet,
            this.bİptal});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(323, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // bYeni
            // 
            this.bYeni.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bYeni.Image = ((System.Drawing.Image)(resources.GetObject("bYeni.Image")));
            this.bYeni.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bYeni.Name = "bYeni";
            this.bYeni.Size = new System.Drawing.Size(33, 22);
            this.bYeni.Text = "Yeni";
            this.bYeni.Click += new System.EventHandler(this.bYeni_Click);
            // 
            // bDüzenle
            // 
            this.bDüzenle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bDüzenle.Image = ((System.Drawing.Image)(resources.GetObject("bDüzenle.Image")));
            this.bDüzenle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bDüzenle.Name = "bDüzenle";
            this.bDüzenle.Size = new System.Drawing.Size(53, 22);
            this.bDüzenle.Text = "Düzenle";
            this.bDüzenle.Click += new System.EventHandler(this.bDüzenle_Click);
            // 
            // bSil
            // 
            this.bSil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bSil.Image = ((System.Drawing.Image)(resources.GetObject("bSil.Image")));
            this.bSil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bSil.Name = "bSil";
            this.bSil.Size = new System.Drawing.Size(23, 22);
            this.bSil.Text = "Sil";
            this.bSil.Click += new System.EventHandler(this.bSil_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bKaydet
            // 
            this.bKaydet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bKaydet.Image = ((System.Drawing.Image)(resources.GetObject("bKaydet.Image")));
            this.bKaydet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bKaydet.Name = "bKaydet";
            this.bKaydet.Size = new System.Drawing.Size(47, 22);
            this.bKaydet.Text = "Kaydet";
            this.bKaydet.Click += new System.EventHandler(this.bKaydet_Click);
            // 
            // bİptal
            // 
            this.bİptal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bİptal.Image = ((System.Drawing.Image)(resources.GetObject("bİptal.Image")));
            this.bİptal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bİptal.Name = "bİptal";
            this.bİptal.Size = new System.Drawing.Size(34, 22);
            this.bİptal.Text = "İptal";
            this.bİptal.Click += new System.EventHandler(this.bİptal_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cYetki);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.maskedTextBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(5, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(241, 108);
            this.panel1.TabIndex = 1;
            // 
            // cYetki
            // 
            this.cYetki.FormattingEnabled = true;
            this.cYetki.Items.AddRange(new object[] {
            "Standart",
            "Yönetici"});
            this.cYetki.Location = new System.Drawing.Point(94, 74);
            this.cYetki.Name = "cYetki";
            this.cYetki.Size = new System.Drawing.Size(136, 21);
            this.cYetki.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::kütüphane.Properties.Resources.büyüteç;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(201, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 22);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(94, 41);
            this.maskedTextBox1.Mask = "AAAAAA";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(92, 20);
            this.maskedTextBox1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Yetki";
            // 
            // ayarlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 357);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ayarlar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ayarlar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ayarlar_FormClosing);
            this.Load += new System.EventHandler(this.ayarlar_Load);
            this.groupBox1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bYeni;
        private System.Windows.Forms.ToolStripButton bDüzenle;
        private System.Windows.Forms.ToolStripButton bSil;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton bKaydet;
        private System.Windows.Forms.ToolStripButton bİptal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.ComboBox cYetki;
        private System.Windows.Forms.Label label3;
    }
}