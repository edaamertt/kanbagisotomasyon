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
    public partial class DonorListesi : Form
    {
        public DonorListesi()
        {
            InitializeComponent();
            uyeler();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenova\Desktop\KanBankasi\WindowsFormsApp1\WindowsFormsApp1\KanBankasi.mdf;Integrated Security=True");

        private void uyeler()
        {
            baglanti.Open();
            // ROW_NUMBER() ile silinen kayıtlardan bağımsız, 1'den başlayan sanal No sütunu oluşturur
            string query = "SELECT ROW_NUMBER() OVER(ORDER BY DNum) AS [No], * FROM DonorTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DonorDGV.DataSource = dt;
            baglanti.Close();
        }

        private void Arama()
        {
            try
            {
                baglanti.Open();
                // Arama sonuçlarında da numaranın her zaman 1'den başlamasını sağlar
                string query = "SELECT ROW_NUMBER() OVER(ORDER BY DNum) AS [No], * FROM DonorTbl WHERE DAdSoyad LIKE '%" + textBox1.Text + "%'";
                SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DonorDGV.DataSource = dt;
                baglanti.Close();
            }
            catch (Exception ex)
            {
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Arama();
        }

        // --- Hataları Önlemek İçin Boş Metodlar ---
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void DonorListesi_Load(object sender, EventArgs e)
        {
        }

        // --- Yönlendirme Olayları ---
        private void label2_Click(object sender, EventArgs e) { Donor dn = new Donor(); dn.Show(); this.Hide(); }
        private void label3_Click(object sender, EventArgs e) { DonorListesi dn = new DonorListesi(); dn.Show(); this.Hide(); }
        private void label12_Click(object sender, EventArgs e) { KanBagisi dn = new KanBagisi(); dn.Show(); this.Hide(); }
        private void label4_Click(object sender, EventArgs e) { Hasta dn = new Hasta(); dn.Show(); this.Hide(); }
        private void label5_Click(object sender, EventArgs e) { HastaListesi dn = new HastaListesi(); dn.Show(); this.Hide(); }
        private void label6_Click(object sender, EventArgs e) { KanStogu dn = new KanStogu(); dn.Show(); this.Hide(); }
        private void label7_Click(object sender, EventArgs e) { KanTransferi dn = new KanTransferi(); dn.Show(); this.Hide(); }
        private void label8_Click(object sender, EventArgs e) { KontrolPaneli dn = new KontrolPaneli(); dn.Show(); this.Hide(); }
        private void label9_Click(object sender, EventArgs e) { Login log = new Login(); log.Show(); this.Hide(); }
    }
}