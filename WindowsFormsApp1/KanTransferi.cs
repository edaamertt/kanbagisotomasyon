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
    public partial class KanTransferi : Form
    {
        public KanTransferi()
        {
            InitializeComponent();
            fillHastaCb();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenova\Desktop\KanBankasi\WindowsFormsApp1\WindowsFormsApp1\KanBankasi.mdf;Integrated Security=True");

        private void fillHastaCb()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select Hnum from HastaTbl ", baglanti);
            SqlDataReader rdr = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Hnum", typeof(int));
            dt.Load(rdr);
            HastaIdCb.ValueMember = "HNum";
            HastaIdCb.DataSource = dt;
            baglanti.Close();
        }

        private void VeriAl()
        {
            baglanti.Open();
            string query = "select * from HastaTbl where HNum=" + HastaIdCb.SelectedValue.ToString() + "";
            SqlCommand komut = new SqlCommand(query, baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(komut);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                HasAdTb.Text = dr["HAdSoyad"].ToString();
                KanGrupTb.Text = dr["HKGrup"].ToString();
            }
            baglanti.Close();
        }

        int stokk = 0;
        private void Stok(string Kgrup)
        {
            // Bağlantı kapalıysa aç
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();

            string query = "select * from KanTbl where KGrup='" + Kgrup + "'";
            SqlCommand komut = new SqlCommand(query, baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(komut);
            sda.Fill(dt);

            stokk = 0; // Her kontrolde sıfırla
            foreach (DataRow dr in dt.Rows)
            {
                stokk = Convert.ToInt32(dr["KStok"].ToString());
            }
            baglanti.Close();
        }

        private void HastaIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            VeriAl();
            Stok(KanGrupTb.Text);

            if (stokk > 0)
            {
                TransferBtn.Visible = true;
                UygunLbl.Text = "Stok Uygun";
                UygunLbl.ForeColor = Color.Green; // Görsel netlik için
                UygunLbl.Visible = true;
            }
            else
            {
                TransferBtn.Visible = false; // Stok yoksa butonu gizle!
                UygunLbl.Text = "Stok Uygun Değil";
                UygunLbl.ForeColor = Color.Red;
                UygunLbl.Visible = true;
            }
        }

        private void kanGuncelle()
        {
            try
            {
                int yenistok = stokk - 1;
                string query = "update KanTbl set KStok=" + yenistok + " where KGrup='" + KanGrupTb.Text + "';";
                baglanti.Open();
                SqlCommand komut = new SqlCommand(query, baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
            }
        }

        private void TransferBtn_Click(object sender, EventArgs e)
        {
            if (HasAdTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            // DÜZELTME: Stok miktarını son bir kez kontrol et
            else if (stokk <= 0)
            {
                MessageBox.Show("Stok Uygun Değil, Transfer Yapılamaz!");
            }
            else
            {
                try
                {
                    string query = "insert into TransferTbl values ('" + HasAdTb.Text + "','" + KanGrupTb.Text + "')";
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Transfer Başarılı");
                    baglanti.Close();

                    kanGuncelle(); // Stoktan bir düş
                    Reset();       // Formu temizle
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                    if (baglanti.State == ConnectionState.Open) baglanti.Close();
                }
            }
        }

        private void Reset()
        {
            HasAdTb.Text = "";
            KanGrupTb.Text = "";
            UygunLbl.Visible = false;
            TransferBtn.Visible = false;
        }

        // Diğer Label Click olayları değişmedi...
        private void label4_Click(object sender, EventArgs e) { Hasta HL = new Hasta(); HL.Show(); this.Hide(); }
        private void label7_Click(object sender, EventArgs e) { KanTransferi kt = new KanTransferi(); kt.Show(); this.Hide(); }
        private void label6_Click(object sender, EventArgs e) { KanStogu ks = new KanStogu(); ks.Show(); this.Hide(); }
        private void label8_Click(object sender, EventArgs e) { KontrolPaneli dn = new KontrolPaneli(); dn.Show(); this.Hide(); }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Burayı boş bırakabilirsin
        }

        private void KanTransferi_Load(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}