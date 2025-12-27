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
    public partial class Calisan : Form
    {
        public Calisan()
        {
            InitializeComponent();
            uyeler();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenova\Desktop\KanBankasi\WindowsFormsApp1\WindowsFormsApp1\KanBankasi.mdf;Integrated Security=True");
        private void Calisan_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void Reset()
        {
            CalAdSoyadTb.Text = "";
            CalSifTb.Text = "";
            key = 0;

        }
        private void uyeler()
        {
            baglanti.Open();
      
            string query = "SELECT ROW_NUMBER() OVER(ORDER BY CalNum) AS [No], CalId, CalSif, CalNum FROM CalisanTbl";

            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            var ds = new DataSet();
            sda.Fill(ds);
            CalisanDGV.DataSource = ds.Tables[0];

           
            baglanti.Close();
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (CalAdSoyadTb.Text == "" || CalSifTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");

            }
            else
            {
                try
                {
                    string query = "insert into CalisanTbl values ('" + CalAdSoyadTb.Text + "','" + CalSifTb.Text + "')";
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Çalışan Başarıyla Kaydedildi");
                    baglanti.Close();
                    Reset();
                    uyeler();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Ex.Message");
                }
            }
        }
        int key = 0;
        private void CalisanDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           
            CalAdSoyadTb.Text = CalisanDGV.SelectedRows[0].Cells[1].Value.ToString();
            CalSifTb.Text = CalisanDGV.SelectedRows[0].Cells[2].Value.ToString();

            if (CalAdSoyadTb.Text == "")
            {
                key = 0;
            }
            else
            {
               
                key = Convert.ToInt32(CalisanDGV.SelectedRows[0].Cells[3].Value.ToString());
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            {
                if (key == 0)
                {
                    MessageBox.Show("Silinecek Çalışanı Seçiniz");
                }
                else
                {
                    try
                    {
                        string query = "delete from CalisanTbl where CalNum=" + key + ";";
                        baglanti.Open();
                        SqlCommand komut = new SqlCommand(query, baglanti);
                        komut.ExecuteNonQuery();
                        MessageBox.Show("Çalışan Başarıyla Silindi");
                        baglanti.Close();
                        Reset();
                        uyeler();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show("Ex.Message");
                    }
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (CalAdSoyadTb.Text == "" || CalSifTb.Text == "")

            {
                MessageBox.Show("Eksik Bilgi: Lütfen tüm alanların dolu olduğundan emin olun.");
            }
            else
            {
                try
                {
                    string query = "update CalisanTbl set CalId='" + CalAdSoyadTb.Text + "',CalSif='" + CalSifTb.Text + "' where CalNum=" + key + ";";

                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }

                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Çalışan Başarıyla Güncellendi");

                    baglanti.Close();
                    Reset();
                    uyeler();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Hata Oluştu: " + Ex.Message);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
        }

