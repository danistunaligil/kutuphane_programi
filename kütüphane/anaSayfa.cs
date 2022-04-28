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
            this.Text = String.Format("Kütüphane Programı {0}.{1}",version.Major,version.Minor);
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

        enum görüntüleme_tipi { süresiGeçenler=1,iadesiYaklaşanlar=3,bugünGelecekler=2,tümü=0}

        void oduncVerilenleriGetir(görüntüleme_tipi hangiKayıtlar=görüntüleme_tipi.tümü)
        {

            string şartifadesi = "";
            if (hangiKayıtlar == görüntüleme_tipi.süresiGeçenler)
                şartifadesi = "WHERE odunc.getilecek_tarih < CURDATE()";
            else if (hangiKayıtlar == görüntüleme_tipi.iadesiYaklaşanlar)
                şartifadesi = "WHERE odunc.getilecek_tarih = CURDATE()+2 OR odunc.getilecek_tarih = CURDATE()+1";
            else if (hangiKayıtlar == görüntüleme_tipi.bugünGelecekler)
                şartifadesi = "WHERE odunc.getilecek_tarih = CURDATE()";

            MySqlDataAdapter da = new MySqlDataAdapter("SELECT odunc.id,kitaplar.barkod AS 'Barkod',kitaplar.adi AS 'Kitap Adı',kitaplar.yazari AS 'Kitabın Yazarı',uyeler.tc AS 'TC',uyeler.ad AS 'Öğrenci Adı',uyeler.soyad AS 'Öğrenci Soyadı',uyeler.telefon AS 'Öğrenci Telefon',uyeler.e_posta AS 'Öğrenci E-Posta',odunc.verilis_tarihi AS 'Veriliş Tarihi',odunc.getilecek_tarih AS 'Getirilecek Tarih', if(odunc.getilecek_tarih < CURDATE(),1,if(odunc.getilecek_tarih = CURDATE(),2,if(odunc.getilecek_tarih = CURDATE()+1 OR odunc.getilecek_tarih = CURDATE()+2,3,0))) AS durum FROM(odunc INNER JOIN kitaplar ON odunc.kitap_id = kitaplar.id) INNER JOIN uyeler ON odunc.uye_id = uyeler.id " + şartifadesi, con);
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

        private void dataGridView1_ColumnSortModeChanged(object sender, DataGridViewColumnEventArgs e)
        {
            
        }
    }
}
