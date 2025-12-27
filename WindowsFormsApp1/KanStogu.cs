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
    public partial class KanStogu : Form
    {
        public KanStogu()
        {
            InitializeComponent();
            KanStok(); // Sayfa ilk açıldığında tüm listeyi yükler
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenova\Desktop\KanBankasi\WindowsFormsApp1\WindowsFormsApp1\KanBankasi.mdf;Integrated Security=True");

        // Tüm stok verilerini getiren metod
        private void KanStok()
        {
            baglanti.Open();
            string query = "select * from KanTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            KStoguDGV.DataSource = dt;
            baglanti.Close();
        }

        // Filtrele() metodunda FiltreCb yerine DKGrupCb kullanıldı
        private void Filtrele()
        {
            try
            {
                // Eğer seçim yapılmadıysa işlem yapma
                if (DKGrupCb.SelectedItem == null) return;

                baglanti.Open();
                // Seçilen kan grubuna göre filtreleme yapar
                string query = "select * from KanTbl where KGrup='" + DKGrupCb.SelectedItem.ToString() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                KStoguDGV.DataSource = dt;
                baglanti.Close();
            }
            catch (Exception ex)
            {
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
                MessageBox.Show(ex.Message);
            }
        }

        // Event ismi DKGrupCb_SelectedIndexChanged olarak güncellendi
        private void DKGrupCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtrele();
        }

        // --- Yönlendirme ve Diğer Olaylar ---

        private void label7_Click(object sender, EventArgs e)
        {
            KanTransferi kant = new KanTransferi();
            kant.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor dn = new Donor();
            dn.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
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

        private void label4_Click(object sender, EventArgs e)
        {
            Hasta dn = new Hasta();
            dn.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            HastaListesi dn = new HastaListesi();
            dn.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            // Listeyi yenilemek için KanStok() metodunu çağırır
            KanStok();
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
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void KStoguDGV_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void KanStogu_Load(object sender, EventArgs e) { }
    }

} 
