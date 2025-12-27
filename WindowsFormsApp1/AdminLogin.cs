using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        
        private void KullaniciTb_TextChanged(object sender, EventArgs e)
        {
            Login log = new Login(); 
            log.Show();             
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (AdminSifreTb.Text == "")
            {
                MessageBox.Show("Admin Şifrenizi Giriniz");
            }
            else if (AdminSifreTb.Text == "5151")
            {
                Calisan cal = new Calisan();
                cal.Show();
                this.Hide(); // Admin giriş başarılı olunca bu ekranı gizler
            }
            else
            {
                MessageBox.Show("Yanlış Şifre");
                AdminSifreTb.Text = "";
            }
        }

        // HATA DÜZELTİLDİ: "Kapat" butonuna tıklandığında Login sayfasına geri döner.
        private void label2_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Close(); // AdminLogin formunu tamamen kapatır
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {
        }
    }
}

