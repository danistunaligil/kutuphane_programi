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
using System.Security.Cryptography;

namespace kütüphane
{
    public partial class ayarlar : Form
    {
        public ayarlar()
        {
            InitializeComponent();
        }


        SHA256Managed sha256 = new SHA256Managed();
        MySqlConnection con = new MySqlConnection("Server=127.0.0.1;Database=kutuphane;Uid=root;Pwd=12345678;");
        int kayit_id = -1;




        void listele()
        {
            listBox1.Items.Clear();
            foreach (kullanıcılar_Sınıfı kullanici in Form1.kullanicilar)
            {
                listBox1.Items.Add(kullanici.ad);
            }
            listBox1.SelectedIndex = Form1.kullanicilar.IndexOf(kullanıcılar_Sınıfı.secilen);
        }

        private void ayarlar_Load(object sender, EventArgs e)
        {
            con.Open();
            if (kullanıcılar_Sınıfı.secilen.yetki == yetki_tipi.Yönetici)
            {
                this.Height = 399;
                listele();
                cYetki.SelectedIndex = 1;
                düzenleme_aktif_pasif(false);
                this.Text = "Ayarlar penceresi (Yetkili kullanıcı)";

            }
            else
            {
                this.Text = "Ayarlar penceresi";
                this.Height = 130;
                cYetki.SelectedIndex = 0;
                bYeni.Visible = bDüzenle.Visible = bSil.Visible = toolStripSeparator1.Visible = cYetki.Visible = false;

            }

            textBox1.Text = kullanıcılar_Sınıfı.secilen.ad;
            maskedTextBox1.Text = kullanıcılar_Sınıfı.secilen.şifre;
            maskedTextBox1.PasswordChar = '*';
        }

        void düzenleme_aktif_pasif(bool aktif_mi)
        {
            bKaydet.Enabled = bİptal.Enabled = panel1.Enabled = aktif_mi;
            bYeni.Enabled = bDüzenle.Enabled = bSil.Enabled = listBox1.Enabled = !aktif_mi;
            cYetki.Enabled = aktif_mi && (Form1.kullanicilar[listBox1.SelectedIndex] != kullanıcılar_Sınıfı.secilen || kayit_id == -1);
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            if (kullanıcılar_Sınıfı.secilen.yetki == yetki_tipi.Standart || (kullanıcılar_Sınıfı.secilen.yetki == yetki_tipi.Yönetici && Form1.kullanicilar[listBox1.SelectedIndex] == kullanıcılar_Sınıfı.secilen))
                maskedTextBox1.PasswordChar = '\0';
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            maskedTextBox1.PasswordChar = '*';
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1) return;
            textBox1.Text = Form1.kullanicilar[listBox1.SelectedIndex].ad;
            maskedTextBox1.Text = Form1.kullanicilar[listBox1.SelectedIndex].şifre;
            cYetki.SelectedIndex = (int)Form1.kullanicilar[listBox1.SelectedIndex].yetki;

        }

        private void bDüzenle_Click(object sender, EventArgs e)
        {
            düzenleme_aktif_pasif(true);
            kayit_id = Form1.kullanicilar[listBox1.SelectedIndex].id;
        }

        private void bİptal_Click(object sender, EventArgs e)
        {
            düzenleme_aktif_pasif(false);
            listBox1_SelectedIndexChanged(this, new EventArgs());
        }

        private void bYeni_Click(object sender, EventArgs e)
        {
            textBox1.Text = maskedTextBox1.Text = "";
            cYetki.SelectedIndex = 0;
            düzenleme_aktif_pasif(true);
            kayit_id = -1;
        }

        private void bSil_Click(object sender, EventArgs e)
        {
            if (Form1.kullanicilar[listBox1.SelectedIndex] == kullanıcılar_Sınıfı.secilen)
            {
                MessageBox.Show("Kendinizi silemezsiniz..", "Silme yapılamaz.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show(Form1.kullanicilar[listBox1.SelectedIndex].ad + " kullanıcısı silinmek üzere!! Devam edilsin mi?", "Dikkat !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    MySqlCommand cmd = new MySqlCommand(String.Format("delete from users where id={0}", Form1.kullanicilar[listBox1.SelectedIndex].id), con);
                    cmd.ExecuteNonQuery();
                    Form1.kullanicilar.RemoveAt(listBox1.SelectedIndex);
                    listele();
                }
            }
        }

        private void ayarlar_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        private void bKaydet_Click(object sender, EventArgs e)
        {
            bool sonuç;
            if (kayit_id == -1) sonuç = yeni_Ekle();
            else sonuç = güncelle();
            if (sonuç)
            {
                düzenleme_aktif_pasif(false);
                listele();
            }
        }

        bool veriler_tamam_mı()
        {
            textBox1.Text = textBox1.Text.Trim();
            if (textBox1.Text == "") return false;
            if (!maskedTextBox1.MaskCompleted) return false;
            return true;
        }

        bool yeni_Ekle()
        {
            if (!veriler_tamam_mı())
            {
                MessageBox.Show("Ad boş veya şifre hatalı.", "Veriler eksik veya hatalı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                MySqlCommand cmd = new MySqlCommand(String.Format("insert into users(adi,password,su) values('{0}','{1}',{2})", textBox1.Text, kullanıcılar_Sınıfı.şifreliVeri(maskedTextBox1.Text), cYetki.SelectedIndex), con);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand("select * from users", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                Form1.kullanicilar = new List<kullanıcılar_Sınıfı>();

                while (dr.Read())
                {
                    kullanıcılar_Sınıfı x = new kullanıcılar_Sınıfı();
                    x.id = dr.GetInt32(0);
                    x.ad = dr.GetString(1);
                    x.şifre = dr.GetString(2);

                    if (dr.GetInt32(3) == 1)
                        x.yetki = yetki_tipi.Yönetici;
                    else
                        x.yetki = yetki_tipi.Standart;

                    //kullanicilar[kullanicilar.Length - 1].yetki = dr.GetInt32(3) == 1 ? yetki_tipi.Yönetici : yetki_tipi.Standart;
                    Form1.kullanicilar.Add(x);
                }

                dr.Close();
                con.Close();
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
                MessageBox.Show("Ad boş veya şifre hatalı.", "Veriler eksik veya hatalı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                MySqlCommand cmd = new MySqlCommand(String.Format("update users set adi='{0}', password='{1}', su={2} where id={3}", textBox1.Text, kullanıcılar_Sınıfı.şifreliVeri(maskedTextBox1.Text), cYetki.SelectedIndex, kayit_id), con);
                cmd.ExecuteNonQuery();
                cmd = new MySqlCommand("select * from users", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                Form1.kullanicilar = new List<kullanıcılar_Sınıfı>();

                while (dr.Read())
                {
                    kullanıcılar_Sınıfı x = new kullanıcılar_Sınıfı();
                    x.id = dr.GetInt32(0);
                    x.ad = dr.GetString(1);
                    x.şifre = dr.GetString(2);

                    if (dr.GetInt32(3) == 1)
                        x.yetki = yetki_tipi.Yönetici;
                    else
                        x.yetki = yetki_tipi.Standart;

                    //kullanicilar[kullanicilar.Length - 1].yetki = dr.GetInt32(3) == 1 ? yetki_tipi.Yönetici : yetki_tipi.Standart;
                    Form1.kullanicilar.Add(x);
                }

                dr.Close();
                con.Close();
                return true;
            }
            catch (Exception hata)
            {
                MessageBox.Show("Kaydetme işleminde hata oluştu.\nHataMesajı:\n" + hata.Message, "Kaydetme hatası!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
