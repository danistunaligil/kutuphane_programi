namespace kütüphane
{
    partial class Form3
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.t_arama = new System.Windows.Forms.ToolStripTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.d_yeni = new System.Windows.Forms.ToolStripButton();
            this.d_düzenle = new System.Windows.Forms.ToolStripButton();
            this.d_sil = new System.Windows.Forms.ToolStripButton();
            this.d_kaydet = new System.Windows.Forms.ToolStripButton();
            this.d_iptal = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.d_yeni,
            this.d_düzenle,
            this.d_sil,
            this.toolStripSeparator1,
            this.d_kaydet,
            this.d_iptal,
            this.t_arama});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 80);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 80);
            // 
            // t_arama
            // 
            this.t_arama.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.t_arama.BackColor = System.Drawing.Color.PaleGreen;
            this.t_arama.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.t_arama.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.t_arama.Name = "t_arama";
            this.t_arama.Size = new System.Drawing.Size(100, 80);
            this.t_arama.Text = "Aranan değeri yaz..";
            this.t_arama.TextChanged += new System.EventHandler(this.t_arama_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.maskedTextBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(0, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 78);
            this.panel1.TabIndex = 2;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(720, 38);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(69, 20);
            this.numericUpDown1.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(505, 38);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(209, 20);
            this.textBox3.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(502, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Yayınevi";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(288, 37);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(211, 20);
            this.textBox2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(285, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Yazar";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(121, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(161, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ad";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(717, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Adet";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(12, 38);
            this.maskedTextBox1.Mask = "0000000000000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(103, 20);
            this.maskedTextBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Barkod";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(0, 158);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(800, 292);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // d_yeni
            // 
            this.d_yeni.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.d_yeni.Image = global::kütüphane.Properties.Resources._new;
            this.d_yeni.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.d_yeni.Name = "d_yeni";
            this.d_yeni.Size = new System.Drawing.Size(36, 77);
            this.d_yeni.Text = "Yeni";
            this.d_yeni.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.d_yeni.Click += new System.EventHandler(this.d_yeni_Click);
            // 
            // d_düzenle
            // 
            this.d_düzenle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.d_düzenle.Image = global::kütüphane.Properties.Resources.edit;
            this.d_düzenle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.d_düzenle.Name = "d_düzenle";
            this.d_düzenle.Size = new System.Drawing.Size(36, 77);
            this.d_düzenle.Text = "Düzenle";
            this.d_düzenle.Click += new System.EventHandler(this.d_düzenle_Click);
            // 
            // d_sil
            // 
            this.d_sil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.d_sil.Image = global::kütüphane.Properties.Resources.delete;
            this.d_sil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.d_sil.Name = "d_sil";
            this.d_sil.Size = new System.Drawing.Size(36, 77);
            this.d_sil.Text = "Sil";
            this.d_sil.Click += new System.EventHandler(this.d_sil_Click);
            // 
            // d_kaydet
            // 
            this.d_kaydet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.d_kaydet.Enabled = false;
            this.d_kaydet.Image = global::kütüphane.Properties.Resources.dialog_ok_apply;
            this.d_kaydet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.d_kaydet.Name = "d_kaydet";
            this.d_kaydet.Size = new System.Drawing.Size(36, 77);
            this.d_kaydet.Text = "Kaydet";
            this.d_kaydet.Click += new System.EventHandler(this.d_kaydet_Click);
            // 
            // d_iptal
            // 
            this.d_iptal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.d_iptal.Enabled = false;
            this.d_iptal.Image = global::kütüphane.Properties.Resources.application_exit;
            this.d_iptal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.d_iptal.Name = "d_iptal";
            this.d_iptal.Size = new System.Drawing.Size(36, 77);
            this.d_iptal.Text = "İptal";
            this.d_iptal.Click += new System.EventHandler(this.d_iptal_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kitaplar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            this.Load += new System.EventHandler(this.Form3_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton d_yeni;
        private System.Windows.Forms.ToolStripButton d_düzenle;
        private System.Windows.Forms.ToolStripButton d_sil;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton d_kaydet;
        private System.Windows.Forms.ToolStripButton d_iptal;
        private System.Windows.Forms.ToolStripTextBox t_arama;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}