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

        private void anaSayfa_Load(object sender, EventArgs e)
        {
            DialogResult şifre = new Form1().ShowDialog();
            if (şifre == DialogResult.Cancel) Application.Exit();
            //this.Text = "Ana Sayfa "+ (kullanıcılar_Sınıfı.secilen.yetki == yetki_tipi.Yönetici ? "Yetkili kullanıcı" : "Standart Kullanıcı");
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            Version version = assembly.GetName().Version;
            this.Text = String.Format("Kütüphane Programı {0}.{1}",version.Major,version.Minor);
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
    }
}
