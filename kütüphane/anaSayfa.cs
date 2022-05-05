using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kütüphane
{
    public partial class anaSayfa : Form
    {
        public anaSayfa()
        {
            InitializeComponent();
        }


        MySqlConnection con = new MySqlConnection("Server=127.0.0.1;Database=kutuphane;Uid=root;Pwd=12345678;");

        private void anaSayfa_Load(object sender, EventArgs e)
        {
            DialogResult şifre = new Form1().ShowDialog();
            if (şifre == DialogResult.Cancel) Application.Exit();
            //this.Text = "Ana Sayfa "+ (kullanıcılar_Sınıfı.secilen.yetki == yetki_tipi.Yönetici ? "Yetkili kullanıcı" : "Standart Kullanıcı");
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            Version version = assembly.GetName().Version;
            this.Text = String.Format("Kütüphane Programı {0}.{1}", version.Major, version.Minor);
            con.Open();
            tsbHangiKayıtlar.SelectedIndex = 0;
            oduncVerilenleriGetir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form3().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new ayarlar().ShowDialog();
        }

        enum görüntüleme_tipi { süresiGeçenler = 1, iadesiYaklaşanlar = 3, bugünGelecekler = 2, tümü = 0 }

        void oduncVerilenleriGetir(görüntüleme_tipi hangiKayıtlar = görüntüleme_tipi.tümü)
        {

            string şartifadesi = "";
            if (hangiKayıtlar == görüntüleme_tipi.süresiGeçenler)
                şartifadesi = "WHERE odunc.getilecek_tarih < CURDATE()";
            else if (hangiKayıtlar == görüntüleme_tipi.iadesiYaklaşanlar)
                şartifadesi = "WHERE odunc.getilecek_tarih = CURDATE()+2 OR odunc.getilecek_tarih = CURDATE()+1";
            else if (hangiKayıtlar == görüntüleme_tipi.bugünGelecekler)
                şartifadesi = "WHERE odunc.getilecek_tarih = CURDATE()";

            MySqlDataAdapter da = new MySqlDataAdapter("SELECT odunc.id,kitaplar.barkod AS 'Barkod',kitaplar.adi AS 'Kitap Adı',kitaplar.yazari AS 'Kitabın Yazarı',uyeler.tc AS 'TC',uyeler.ad AS 'Öğrenci Adı',uyeler.soyad AS 'Öğrenci Soyadı',uyeler.telefon AS 'Öğrenci Telefon',uyeler.e_posta AS 'Öğrenci E-Posta',odunc.verilis_tarihi AS 'Veriliş Tarihi',odunc.getirilecek_tarih AS 'Getirilecek Tarih', if(odunc.getirilecek_tarih < CURDATE(),1,if(odunc.getirilecek_tarih = CURDATE(),2,if(odunc.getirilecek_tarih = CURDATE()+1 OR odunc.getirilecek_tarih = CURDATE()+2,3,0))) AS durum FROM(odunc INNER JOIN kitaplar ON odunc.kitap_id = kitaplar.id) INNER JOIN uyeler ON odunc.uye_id = uyeler.id " + şartifadesi, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            //dataGridView1.Columns[11].Visible = 
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[10].DefaultCellStyle.Format = "dd.MM.yyyy";
        }

        private void anaSayfa_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        private void tsbHangiKayıtlar_Click(object sender, EventArgs e)
        {

        }

        private void tsbHangiKayıtlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            oduncVerilenleriGetir((görüntüleme_tipi)tsbHangiKayıtlar.SelectedIndex);
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int durum = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[11].Value);
            dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = durum == 3 ? Color.LightYellow : (durum == 2 ? Color.Tomato : (durum == 1 ? Color.LightGray : Color.White));
        }

        void kontrol()
        {
            MySqlCommand cmd = new MySqlCommand(String.Format("select odunc.id from (odunc inner join kitaplar on odunc.kitap_id=kitaplar.id) inner join uyeler on odunc.uye_id=uyeler.id where kitaplar.barkod='{0}' and uyeler.tc='{1}'", textBox2.Text.Trim(), textBox1.Text.Trim()), con);
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) //ÖDÜNÇ TABLOSUNDA BU TC Lİ VE BU BARKODLU BİR KAYIT VAR. YANİ BU KİŞİ O KİTABI ÖNCEDEN ÖDÜNÇ ALMIŞ. İADE ETMEK İSTİYOR.
            {
                int id = dr.GetInt32(0);
                dr.Close();
                //Kitabı iade edecek
                cmd.CommandText = "delete from odunc where id=" + id.ToString();
                cmd.ExecuteNonQuery();
                oduncVerilenleriGetir();
                MessageBox.Show("İade işlemi yapıldı.");
            }
            else
            {
                dr.Close();
                int üye_id = -1;
                int kitap_id = -1;
                cmd.CommandText = String.Format("select id from uyeler where tc='{0}'", textBox1.Text.Trim());
                dr = cmd.ExecuteReader();
                if (dr.Read()) üye_id = dr.GetInt32(0);
                dr.Close();
                if (üye_id == -1)
                {
                    if (DialogResult.Cancel == MessageBox.Show("Bu üye kayıtlı değil. Üye kayıt sayfasına yönlendiriliyorsunuz.", "Üye eklenmesi gerekli", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)) return;
                    Form2 üye = new Form2();
                    üye.tc = textBox1.Text.Trim();
                    DialogResult cevap = üye.ShowDialog();
                    if (cevap == DialogResult.Cancel)
                    {
                        MessageBox.Show("İşlem iptal edildi.", "Üye eklenemedi.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        üye_id = üye.kayit_id;
                    }
                }

                cmd.CommandText = String.Format("select id from kitaplar where barkod='{0}'", textBox2.Text.Trim());
                dr = cmd.ExecuteReader();
                if (dr.Read()) kitap_id = dr.GetInt32(0);
                dr.Close();
                if (kitap_id == -1)
                {
                    if (DialogResult.Cancel == MessageBox.Show("Bu kitap kayıtlı değil. Kitap kayıt sayfasına yönlendiriliyorsunuz.", "Kitap eklenmesi gerekli", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)) return;
                    button2_Click("ödünç", new EventArgs());
                    return;
                }

                cmd.CommandText = String.Format("select count(*) from odunc inner join kitaplar on odunc.kitap_id=kitaplar.id where kitaplar.barkod='{0}'", textBox2.Text.Trim());
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    int ödünçVerilenAdet = dr.GetInt32(0);
                    dr.Close();
                    cmd.CommandText = String.Format("select kitaplar.adet from kitaplar where kitaplar.barkod='{0}'", textBox2.Text.Trim());
                    int kitapAdeti = 0;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        kitapAdeti = dr.GetInt32(0);
                    }
                    dr.Close();
                    if (ödünçVerilenAdet >= kitapAdeti)
                    {
                        //hataver ve çık
                        MessageBox.Show("Bu kitap adetinden fazla ödünç verilemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else dr.Close();

                

                cmd.CommandText = String.Format("insert into odunc(uye_id,kitap_id,verilis_tarihi,getirilecek_tarih) values({0},{1},'{2}','{3}')", üye_id, kitap_id, DateTime.Today.ToString("yyyy.MM.dd"), DateTime.Today.AddDays(7).ToString("yyyy.MM.dd"));
                cmd.ExecuteNonQuery();
                oduncVerilenleriGetir();
                MessageBox.Show("Ödünç verme işlemi yapıldı.");
                //Kitabı ödünç almak istiyor demektir.
                //Kitabın odunc tablosundaki adeti getirilecek

            }

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e) //tc kimlik no ENTER a basılınca
        {
            if (e.KeyData == Keys.Enter)
                if (textBox2.Text.Trim() == "")
                {
                    textBox2.Focus();
                    textBox2.Text = "";
                }
                else kontrol();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)  //barkod ENTER a basılınca
        {
            if (e.KeyData == Keys.Enter)
                if (textBox1.Text.Trim() == "")
                {
                    textBox1.Text = "";
                    textBox1.Focus();
                }
                else kontrol();

        }
        // DahaNasipOlmadı: iade ve ödünç
        // YAPILACAK: Barkod işlemi yapılacak
        // DahaNasipOlmadı: şldfkhgşlksdfşlh

        //YAPILACAK: KLJLEFKJSKLŞ
    }
}
