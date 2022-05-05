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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("Server=127.0.0.1;Database=kutuphane;Uid=root;Pwd=12345678;");
        public int kayit_id = -1;
        public string tc = "";

        void datagrid_seç(string tc)
        {
            
            for (int i = 0; i < dataGridView1.Rows.Count; i++) 
                if ((string)dataGridView1.Rows[i].Cells[1].Value == tc)
                {
                    dataGridView1.Rows[i].Selected = true;
                    break;
                }
        }

        void üyeleriGetir(string aranan="")
        {
            string şart_ifadesi = "";
            if (aranan!="") şart_ifadesi= string.Format(" WHERE tc LIKE '%{0}%' OR ad LIKE '%{0}%' OR soyad LIKE '%{0}%' OR telefon LIKE '%{0}%'",aranan);
            MySqlDataAdapter da = new MySqlDataAdapter("select * from uyeler"+şart_ifadesi, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
        }

        void seçiliOlanıYansıt(int satir)
        {
            if (satir == -1) return;
            maskedTextBox1.Text = dataGridView1.Rows[satir].Cells[1].Value.ToString(); //TC
            textBox1.Text = dataGridView1.Rows[satir].Cells[2].Value.ToString(); //Ad
            textBox2.Text = dataGridView1.Rows[satir].Cells[3].Value.ToString(); //Soyad
            textBox3.Text = dataGridView1.Rows[satir].Cells[6].Value.ToString(); //E-posta
            maskedTextBox2.Text = dataGridView1.Rows[satir].Cells[5].Value.ToString(); //telefon
            if (dataGridView1.Rows[satir].Cells[4].Value.ToString() == "Kız") radioButton1.Checked = true;
            else radioButton2.Checked = true; //Cinsiyet
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            try
            {
                con.Open();
                üyeleriGetir();
                dataGridView1.ClearSelection();
                if (tc!="") toolStripButton1_Click("yenikayıt",new EventArgs());
            }
            catch (Exception hata)
            {
                MessageBox.Show("Okul veritabanına bağlanılamadı.\nHata mesajı:\n" + hata.Message);
            }
        }

       
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("cellClick");
            //seçiliOlanıYansıt(e.RowIndex);
        }

        private void toolStripButton3_Click(object sender, EventArgs e) //Sil düğmesi
        {
            DialogResult cevap;
            cevap = MessageBox.Show(String.Format("{0} {1} isimli üye silinecek! Devam edilsin mi?", textBox1.Text, textBox2.Text), "Aman Dikkat!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (cevap == DialogResult.Yes)
            {
                MySqlCommand cmd = new MySqlCommand(String.Format("delete from uyeler where tc='{0}'", maskedTextBox1.Text), con);
                cmd.ExecuteNonQuery();
                üyeleriGetir();
            }
        }

        void düzenleme_aktif_pasif(bool aktif_mi)
        {
            d_kaydet.Enabled = d_iptal.Enabled = panel1.Enabled = aktif_mi;
            d_yeni.Enabled = d_düzenle.Enabled = d_sil.Enabled = dataGridView1.Enabled = t_arama.Enabled = !aktif_mi;
        }


        private void toolStripButton1_Click(object sender, EventArgs e) //Yeni
        {
            maskedTextBox2.Text = textBox1.Text = textBox2.Text = textBox3.Text = "";
            maskedTextBox1.Text = tc;
            if (tc!="") maskedTextBox2.Focus();else maskedTextBox1.Focus();
            düzenleme_aktif_pasif(true);
            kayit_id = -1;

        }
        
        bool veriler_tamam_mı()
        {
            if (!maskedTextBox1.MaskCompleted) return false;
            if (!maskedTextBox2.MaskCompleted) return false;
            if (textBox1.Text.Trim()=="") return false;
            if (textBox2.Text.Trim() == "") return false;
            return true;
        }

        bool yeni_Ekle()
        {
            if (!veriler_tamam_mı())
            {
                MessageBox.Show("Zorunlu veriler (TC, Ad, Soyad, Telefon) düzgün girilmemiş.", "Veriler eksik veya hatalı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                string cinsiyet = "";
                if (radioButton1.Checked) cinsiyet = "Kız";
                else cinsiyet = "Erkek";
                MySqlCommand cmd = new MySqlCommand(String.Format("insert into uyeler(tc,ad,soyad,cinsiyet,telefon,e_posta) values('{0}','{1}','{2}','{3}','{4}','{5}')",maskedTextBox1.Text,textBox1.Text,textBox2.Text,cinsiyet,maskedTextBox2.Text,textBox3.Text), con);
                cmd.ExecuteNonQuery();

                if (tc != "") //bu form tek kayıt için açılmış demektir.
                              // 1. tc ye göre sorgu yazılıp id numarası getirilecek.
                              // 2. form ok ile kapatılacak
                {
                    cmd = new MySqlCommand(String.Format("select id from uyeler where tc='{0}'", maskedTextBox1.Text.Trim()), con);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        kayit_id = dr.GetInt32(0);
                        dr.Close();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                üyeleriGetir();
                return true;
            }
            catch (Exception hata)
            {
                MessageBox.Show("Kaydetme işleminde hata oluştu.\nHataMesajı:\n"+hata.Message, "Kaydetme hatası!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        bool güncelle()
        {
            if (!veriler_tamam_mı())
            {
                MessageBox.Show("Zorunlu veriler (TC, Ad, Soyad, Telefon) düzgün girilmemiş.", "Veriler eksik veya hatalı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                string cinsiyet = "";
                if (radioButton1.Checked) cinsiyet = "Kız";
                else cinsiyet = "Erkek";
                MySqlCommand cmd = new MySqlCommand(String.Format("update uyeler set tc='{0}', ad='{1}', soyad='{2}',cinsiyet='{3}', telefon='{4}', e_posta='{5}' where id={6}", maskedTextBox1.Text, textBox1.Text, textBox2.Text, cinsiyet, maskedTextBox2.Text, textBox3.Text, kayit_id), con);
                cmd.ExecuteNonQuery();
                üyeleriGetir();
                return true;
            }
            catch (Exception hata)
            {
                MessageBox.Show("Kaydetme işleminde hata oluştu.\nHataMesajı:\n" + hata.Message, "Kaydetme hatası!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void d_iptal_Click(object sender, EventArgs e)
        {
            if (tc != "")
            {
                this.DialogResult = DialogResult.Cancel; //tek kayıt için açılan pencerede iptal düğmesine basınca formı CANCEL ile kapat.
            }
            else
            {
                seçiliOlanıYansıt(dataGridView1.SelectedRows[0].Index);
                düzenleme_aktif_pasif(false);
            }
        }

        private void d_kaydet_Click(object sender, EventArgs e)//kaydet düğmesi
        {
            bool sonuç;
            if (kayit_id == -1) sonuç=yeni_Ekle();
            else sonuç= güncelle();
            if (sonuç)
            {
               


                düzenleme_aktif_pasif(false);
                datagrid_seç(maskedTextBox1.Text);
            }

        }

        private void t_arama_TextChanged(object sender, EventArgs e)
        {
            if (t_arama.Text.Length >= 3) üyeleriGetir(t_arama.Text);
            else üyeleriGetir();
        }

        private void d_düzenle_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "") return;
            düzenleme_aktif_pasif(true);
            kayit_id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0) return;
            seçiliOlanıYansıt(dataGridView1.SelectedCells[0].RowIndex);
            
            //MessageBox.Show("selectedChanged");
        }
    }
}
