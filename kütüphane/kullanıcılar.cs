using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace kütüphane
{
    public enum yetki_tipi { Standart, Yönetici };
    public class kullanıcılar_Sınıfı
    {
        public static FlowLayoutPanel panel;
        public static MaskedTextBox sifreAlanı;
        public static kullanıcılar_Sınıfı secilen;
        public int id;
        public string ad;
        public string şifre;
        public yetki_tipi yetki;
        Panel p;

        static string hash = "11DSınıfıKütüphaneProgramı";


        public static string şifreliVeri(string şifre)
        {

            byte[] data = UTF8Encoding.UTF8.GetBytes(şifre);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }

        }

        public static string şifreÇöz(string SifrelenmisDeger)
        {
            byte[] data = Convert.FromBase64String(SifrelenmisDeger);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return UTF8Encoding.UTF8.GetString(results);
                }
            }
        }
        public void görseli_ver()
        {
            Panel p = new Panel();
            //p.BorderStyle = BorderStyle.FixedSingle;
            p.Width = 142;
            p.Height = 130;
            p.BackColor = SystemColors.Menu;

            Label l = new Label();
            //l.BorderStyle = BorderStyle.FixedSingle;
            l.Text = ad;
            l.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Bold);
            l.AutoSize = false;
            l.TextAlign = ContentAlignment.MiddleCenter;
            l.Dock = DockStyle.Bottom;
            l.Height = (int)l.CreateGraphics().MeasureString("A", l.Font).Height + 5;
            p.Controls.Add(l);

            PictureBox r = new PictureBox();
            //r.BorderStyle = BorderStyle.FixedSingle;
            r.BackgroundImage = yetki == yetki_tipi.Yönetici ? kütüphane.Properties.Resources.Admin : kütüphane.Properties.Resources.user;
            r.BackgroundImageLayout = ImageLayout.Zoom;
            r.Dock = DockStyle.Fill;

            p.Controls.Add(r);
            r.BringToFront();

            r.Click += R_Click;
            l.Click += R_Click;
            panel.Controls.Add(p);
            this.p = p;
        }

        private void R_Click(object sender, EventArgs e)
        {
            if (secilen != null)
                if (secilen.Equals(this)) return;

            if (secilen != null) secilen.p.BackColor = Color.White;
            p.BackColor = SystemColors.MenuHighlight;
            sifreAlanı.Clear();
            secilen = this;
            sifreAlanı.Enabled = true;
            sifreAlanı.Focus();
        }
    }


}
