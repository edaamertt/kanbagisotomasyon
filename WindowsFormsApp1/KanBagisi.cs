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
    public partial class KanBagisi: Form
    {
        public KanBagisi()
        {
            InitializeComponent();
            uyeler();
            KanStok();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenova\Desktop\KanBankasi\WindowsFormsApp1\WindowsFormsApp1\KanBankasi.mdf;Integrated Security=True");
        private void uyeler()
        {
            baglanti.Open();
            string query = "select *from DonorTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            KBagisiDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void KanStok()
        {
            baglanti.Open();
            string query = "select *from KanTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            KStoguDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void label2_Click(object sender, EventArgs e)
        {
            Donor dn = new Donor();
            dn.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            DonorListesi dn = new DonorListesi();
            dn.Show();
            this.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void KanBagisi_Load(object sender, EventArgs e)
        {

        }
        int eskistok;
        private void Stok(string Kgrup)
        {
            baglanti.Open();
            string query = "select * from KanTbl where KGrup='" + Kgrup + "'";
            SqlCommand komut = new SqlCommand(query, baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(komut);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                eskistok = Convert.ToInt32(dr["KStok"].ToString());

            }
            baglanti.Close();
        }

        private void KBagisiDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DAdSoyadTb.Text = KBagisiDGV.SelectedRows[0].Cells[1].Value.ToString();
            DKGrubuTb.Text = KBagisiDGV.SelectedRows[0].Cells[6].Value.ToString();
            Stok(DKGrubuTb.Text);
        }
        private void Reset()
        {
            DAdSoyadTb.Text = "";
            DKGrubuTb.Text = "";
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(DAdSoyadTb.Text=="")
            {
                MessageBox.Show("Bir Donör Seçiniz");

            }
            else
            {
                try
                {
                    int stok = eskistok + 1;
                    string query = "update KanTbl set KStok= '" + stok + "'where KGrup ='" + DKGrubuTb.Text + "'; ";
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }

                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Bağış  Başarılı");

                    baglanti.Close();
                    Reset();
                    KanStok();
                    
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

        private void DKGrubuTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void KStoguDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            KanBagisi dn = new KanBagisi();
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
    }
}
