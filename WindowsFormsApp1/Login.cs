using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenova\Desktop\KanBankasi\WindowsFormsApp1\WindowsFormsApp1\KanBankasi.mdf;Integrated Security=True");

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from CalisanTbl where CalId='" + KullaniciTb.Text + "' and CalSif='" + SifreTb.Text + "'", baglanti);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1")
                {
                    AnaSayfa ana = new AnaSayfa();
                    ana.Show();
                    this.Hide(); // Ana sayfa açılınca Login'i gizler
                }
                else
                {
                    MessageBox.Show("Yanlış Kullanıcı ya da Şifre");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            AdminLogin admin = new AdminLogin();
            admin.Show();
            this.Hide(); // Eskiden burada .Show() vardı, o yüzden üst üste biniyordu.
        }

        
        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Uygulamayı tamamen kapatır
        }

        
        private void Login_Load(object sender, EventArgs e) { }
        // Tasarım dosyasındaki hataları gidermek için gereken boş metodlar:
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void KullaniciTb_TextChanged(object sender, EventArgs e) { }
        private void SifreTb_TextChanged(object sender, EventArgs e) { }
    }
}