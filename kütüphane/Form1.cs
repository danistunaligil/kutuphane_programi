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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("Server=127.0.0.1;Database=kutuphane;Uid=root;Pwd=12345678;");


        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            maskedTextBox1.PasswordChar = '\0';
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            maskedTextBox1.PasswordChar = '*';
        }

        public static List<kullanıcılar_Sınıfı> kullanicilar = new List<kullanıcılar_Sınıfı>();

        


        private void Form1_Load(object sender, EventArgs e)
        {
            kullanıcılar_Sınıfı.panel = flowLayoutPanel1;
            kullanıcılar_Sınıfı.sifreAlanı = maskedTextBox1;

            con.Open();

            MySqlCommand cmd = new MySqlCommand("select * from users",con);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                kullanıcılar_Sınıfı x=new kullanıcılar_Sınıfı();
                x.id = dr.GetInt32(0);
                x.ad = dr.GetString(1);
                x.şifre = kullanıcılar_Sınıfı.şifreÇöz(dr.GetString(2));
                
                if (dr.GetInt32(3) == 1)
                    x.yetki = yetki_tipi.Yönetici;
                else
                    x.yetki = yetki_tipi.Standart;

                //kullanicilar[kullanicilar.Length - 1].yetki = dr.GetInt32(3) == 1 ? yetki_tipi.Yönetici : yetki_tipi.Standart;
                kullanicilar.Add(x);


            }

            dr.Close();
            con.Close();


            //kullanicilar[0] = new kullanıcılar_Sınıfı();
            //kullanicilar[0].ad = "Admin";
            //kullanicilar[0].yetki = yetki_tipi.Yönetici;
            //kullanicilar[0].şifre = "12345";

            //kullanicilar[1] = new kullanıcılar_Sınıfı();
            //kullanicilar[1].ad = "Emir";
            //kullanicilar[1].yetki = yetki_tipi.Standart;
            //kullanicilar[1].şifre = "1";

            //kullanicilar[2] = new kullanıcılar_Sınıfı();
            //kullanicilar[2].ad = "Berk";
            //kullanicilar[2].yetki = yetki_tipi.Standart;
            //kullanicilar[2].şifre = "2";

            //kullanicilar[3] = new kullanıcılar_Sınıfı();
            //kullanicilar[3].ad = "Hakan";
            //kullanicilar[3].yetki = yetki_tipi.Yönetici;
            //kullanicilar[3].şifre = "3";

            //kullanicilar[4] = new kullanıcılar_Sınıfı();
            //kullanicilar[4].ad = "M. Emin";
            //kullanicilar[4].yetki = yetki_tipi.Standart;
            //kullanicilar[4].şifre = "4";


            foreach (kullanıcılar_Sınıfı x in kullanicilar) x.görseli_ver();

        }

        int hak = 3;
        private void button1_Click(object sender, EventArgs e)
        {
            if (kullanıcılar_Sınıfı.secilen.şifre == maskedTextBox1.Text)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Parola hatalı");
                hak--;
                if (hak==0) this.DialogResult = DialogResult.Cancel;
            }
            maskedTextBox1.SelectAll();
        }

        private void maskedTextBox1_EnabledChanged(object sender, EventArgs e)
        {
            button1.Enabled = maskedTextBox1.Enabled;
        }

        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) button1_Click(maskedTextBox1, new EventArgs());
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
