using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace kütüphane
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("Server=127.0.0.1;Database=kutuphane;Uid=root;Pwd=12345678;");
        int kayit_id = -1;

        void datagrid_seç(string barkod)
        {

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                if ((string)dataGridView1.Rows[i].Cells[1].Value == barkod)
                {
                    dataGridView1.Rows[i].Selected = true;
                    break;
                }
        }

        void kitaplarıGetir(string aranan = "")
        {
            string şart_ifadesi = "";
            if (aranan != "") şart_ifadesi = string.Format(" WHERE barkod LIKE '%{0}%' OR adi LIKE '%{0}%' OR yazari LIKE '%{0}%' OR yayinevi LIKE '%{0}%'", aranan);
            MySqlDataAdapter da = new MySqlDataAdapter("select * from kitaplar" + şart_ifadesi, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
        }

        void seçiliOlanıYansıt(int satir)
        {
            if (satir == -1) return;
            maskedTextBox1.Text = dataGridView1.Rows[satir].Cells[1].Value.ToString(); //Barkod
            textBox1.Text = dataGridView1.Rows[satir].Cells[2].Value.ToString(); //Ad
            textBox2.Text = dataGridView1.Rows[satir].Cells[3].Value.ToString(); //Soyad
            textBox3.Text = dataGridView1.Rows[satir].Cells[4].Value.ToString(); //E-posta
            numericUpDown1.Value = (int)dataGridView1.Rows[satir].Cells[5].Value; //adet
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                kitaplarıGetir();
                dataGridView1.ClearSelection();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Okul veritabanına bağlanılamadı.\nHata mesajı:\n" + hata.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //seçiliOlanıYansıt(e.RowIndex);
        }

        private void d_sil_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kitabı silmek için adet bilgisini 0 (sıfır) yapıp kaydetmelisiniz.");
        }

        void düzenleme_aktif_pasif(bool aktif_mi)
        {
            d_kaydet.Enabled = d_iptal.Enabled = panel1.Enabled = aktif_mi;
            d_yeni.Enabled = d_düzenle.Enabled = d_sil.Enabled = dataGridView1.Enabled = t_arama.Enabled = !aktif_mi;
        }

        private void d_yeni_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Text =  textBox1.Text = textBox2.Text = textBox3.Text = "";
            numericUpDown1.Value = 1;
            düzenleme_aktif_pasif(true);
            kayit_id = -1;
        }

        bool veriler_tamam_mı()
        {
            //barkod ve yazar adı zorunlu
            if (!maskedTextBox1.MaskCompleted) return false;
            if (textBox1.Text.Trim() == "") return false;
            return true;
        }

        bool yeni_Ekle()
        {
            if (!veriler_tamam_mı())
            {
                MessageBox.Show("Zorunlu veriler (Barkod, Kitap adı) düzgün girilmemiş.", "Veriler eksik veya hatalı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
               MySqlCommand cmd = new MySqlCommand(String.Format("insert into kitaplar(barkod,adi,yazari,yayinevi,adet) values('{0}','{1}','{2}','{3}',{4})", maskedTextBox1.Text, textBox1.Text, textBox2.Text, textBox3.Text,numericUpDown1.Value), con);
                cmd.ExecuteNonQuery();
                kitaplarıGetir();
                return true;
            }
            catch (Exception hata)
            {
                MessageBox.Show("Kaydetme işleminde hata oluştu.\nHataMesajı:\n" + hata.Message, "Kaydetme hatası!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        bool güncelle()
        {
            if (!veriler_tamam_mı())
            {
                MessageBox.Show("Zorunlu veriler (Barkod, Kitap adı) düzgün girilmemiş.", "Veriler eksik veya hatalı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (numericUpDown1.Value == 0)
            {
                //Burada silme işlemi yapılacak
                DialogResult cevap;
                cevap = MessageBox.Show(String.Format("{0} isimli kitap adeti 0 (sıfır) olarak belirttiniz. Bu nedenle kitap silinecek! Devam edilsin mi?", textBox1.Text), "Aman Dikkat!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (cevap == DialogResult.Yes)
                {
                    MySqlCommand cmd = new MySqlCommand(String.Format("delete from kitaplar where id={0}", kayit_id), con);
                    cmd.ExecuteNonQuery();
                    kitaplarıGetir();
                    return true;
                }
                else return false;
            }
            else
            {
                //Güncelleme
                try
                {
                    MySqlCommand cmd = new MySqlCommand(String.Format("update kitaplar set barkod='{0}', adi='{1}', yazari='{2}',yayinevi='{3}', adet={4} where id={5}", maskedTextBox1.Text, textBox1.Text, textBox2.Text, textBox3.Text, numericUpDown1.Value, kayit_id), con);
                    cmd.ExecuteNonQuery();
                    kitaplarıGetir();
                    return true;
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Kaydetme işleminde hata oluştu.\nHataMesajı:\n" + hata.Message, "Kaydetme hatası!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private void d_iptal_Click(object sender, EventArgs e)
        {
            seçiliOlanıYansıt(dataGridView1.SelectedRows[0].Index);
            düzenleme_aktif_pasif(false);
        }

        private void d_kaydet_Click(object sender, EventArgs e)
        {
            bool sonuç;
            if (kayit_id == -1) sonuç = yeni_Ekle();
            else sonuç = güncelle();
            if (sonuç)
            {
                düzenleme_aktif_pasif(false);
                datagrid_seç(maskedTextBox1.Text);
            }
        }

        private void t_arama_TextChanged(object sender, EventArgs e)
        {
            if (t_arama.Text.Length >= 3) kitaplarıGetir(t_arama.Text);
            else kitaplarıGetir();
        }

        private void d_düzenle_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "") return;
            düzenleme_aktif_pasif(true);
            kayit_id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0) return;
            seçiliOlanıYansıt(dataGridView1.SelectedCells[0].RowIndex);
        }
    }
}
