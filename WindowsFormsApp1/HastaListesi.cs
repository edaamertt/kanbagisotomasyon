using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class HastaListesi: Form
    {
        public HastaListesi()
        {
            InitializeComponent();
            uyeler();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenova\Desktop\KanBankasi\WindowsFormsApp1\WindowsFormsApp1\KanBankasi.mdf;Integrated Security=True");
        private void uyeler()
        {
            baglanti.Open();
            string query = "select *from HastaTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            HastaDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void HastaListesi_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        int key = 0;
        private void HastaDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            HAdSoyadTb.Text = HastaDGV.SelectedRows[0].Cells[1].Value.ToString();
            HYasTb.Text = HastaDGV.SelectedRows[0].Cells[2].Value.ToString();
            HTelefonTb.Text = HastaDGV.SelectedRows[0].Cells[3].Value.ToString();
            HCinsCb.Text = HastaDGV.SelectedRows[0].Cells[4].Value.ToString();
            HKGrupCb.Text = HastaDGV.SelectedRows[0].Cells[5].Value.ToString();
            HAdresTb.Text = HastaDGV.SelectedRows[0].Cells[6].Value.ToString();
            if(HAdSoyadTb.Text=="")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(HastaDGV.SelectedRows[0].Cells[0].Value.ToString());

            }
        }
        private void Reset()
        {
            HAdSoyadTb.Text = "";
            HYasTb.Text = "";
            HCinsCb.SelectedIndex = -1;
            HTelefonTb.Text = "";
            HAdresTb.Text = "";
            HKGrupCb.SelectedIndex = -1;
            key = 0;
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if(key==0)
            {
                MessageBox.Show("Silinecek Hastayı Seçiniz");
            }
            else
            {
                try
                {
                    string query = "delete from HastaTbl where Hnum=" + key + ";";
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Hasta Başarıyla Silindi");
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

        private void label5_Click(object sender, EventArgs e)
        {
            HastaListesi HL = new HastaListesi();
            HL.Show();
            this.Hide();

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Hasta ha = new Hasta();
            ha.Show();
            this.Hide();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
            if (HAdSoyadTb.Text == "" ||
                HYasTb.Text == "" ||
                HCinsCb.Text == "" ||
                HTelefonTb.Text == "" ||
                HKGrupCb.Text == "" ||
                HAdresTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi: Lütfen tüm alanların dolu olduğundan emin olun.");
            }
            else
            {
                try
                {
                    string query = "update HastaTbl set HAdSoyad='" + HAdSoyadTb.Text + "',HYas=" + HYasTb.Text + ",HTelefon='" + HTelefonTb.Text + "',HCinsiyet='" + HCinsCb.Text + "',HKGrup='" + HKGrupCb.Text + "',HAdres='" + HAdresTb.Text + "' where HNum=" + key + ";";

                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }

                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Hasta Başarıyla Güncellendi");

                    baglanti.Close();
                    Reset();  
                    uyeler(); 
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Hata Oluştu: " + Ex.Message);
                    if (baglanti.State == ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor dn = new Donor();
            dn.Show();
            this.Hide();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            KanBagisi dn = new KanBagisi();
            dn.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            DonorListesi dn = new DonorListesi();
            dn.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            KanStogu dn = new KanStogu();
            dn.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            KanTransferi dn = new KanTransferi();
            dn.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            KontrolPaneli dn = new KontrolPaneli();
            dn.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}
