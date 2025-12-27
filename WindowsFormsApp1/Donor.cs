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
    public partial class Donor: Form
    {
        public Donor()
        {
            InitializeComponent();
        }
        
 SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenova\Desktop\KanBankasi\WindowsFormsApp1\WindowsFormsApp1\KanBankasi.mdf;Integrated Security=True");
       private void Reset()
        {
            DAdSoyadTb.Text = "";
            DYasTb.Text = "";
            DCinsCb.SelectedIndex = -1;
            DTelefonTb.Text = "";
            DAdresTb.Text = "";
            DKGrupCb.SelectedIndex = -1;

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {  
          if (DAdSoyadTb.Text==""||DYasTb.Text==""||DCinsCb.SelectedIndex==-1||DTelefonTb.Text==""||DKGrupCb.SelectedIndex==-1||DAdresTb.Text=="")
            {
                MessageBox.Show("Eksik Bilgi");

            }
          else
            {
                try
                {
                    string query = "insert into DonorTbl values ('" + DAdSoyadTb.Text + "'," + DYasTb.Text + ",'" + DCinsCb.SelectedItem.ToString() + "','" + DTelefonTb.Text + "','" + DAdresTb.Text + "','" + DKGrupCb.SelectedItem.ToString() + "')";
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Donör Başarıyla Kaydedildi");
                    baglanti.Close();
                    Reset();
                }catch(Exception Ex)
                {
                    MessageBox.Show("Ex.Message");
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor dn = new Donor();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            KanBagisi dn = new KanBagisi();
            dn.Show();
            this.Hide();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
