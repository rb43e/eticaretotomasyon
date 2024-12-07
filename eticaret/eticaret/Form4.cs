using eticaret;
using System.Windows.Forms;


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

namespace eticaret
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        public SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-1KMHI4I\MSSQLSERVER01;Initial Catalog=eticaret;Integrated Security=True");
        SqlDataReader reader;
        SqlCommand komut;
        int siparis_adet_2;
        private object numericUpDown1;

        public string Siparis_kod { get; set; }
        private void Form4_Load_1(object sender, EventArgs e)
        {
            baglanti.Open();
            komut = new SqlCommand("select * from siparisler where siparis_kod='" + Siparis_kod + "'", baglanti);
            reader = komut.ExecuteReader();
            reader.Read();
            siparis_adet_2 = Convert.ToInt16(reader["adet"]);
            numericUpDown1.Maximum = Convert.ToInt16(siparis_adet_2);
            reader.Close(); baglanti.Close();
            if (siparis_adet_2 <= 1) { radioButton2.Enabled = false; radioButton1.Checked = true; }
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            int silinecek_adet_sayisi = Convert.ToInt16(numericUpDown1.Value);
            if (radioButton1.Checked == true)
            {
                string sil = "delete from siparisler where siparis_kod='" + Siparis_kod + "'";
                komut = new SqlCommand(sil, baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Siparişiniz Silinmiştir!\n" + "Siparişlerinize Tekar Bakınız", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }
            else
            {
                int yeni_adet = siparis_adet_2 - Convert.ToInt16(numericUpDown1.Value);
                string update = "update siparisler set adet = @yeni_adet where siparis_kod=@siparis_kod";
                komut = new SqlCommand(update, baglanti);
                komut.Parameters.AddWithValue("@yeni_adet", yeni_adet);
                komut.Parameters.AddWithValue("@siparis_kod", Siparis_kod);
                komut.ExecuteNonQuery();
                MessageBox.Show("Siparişinizden " + silinecek_adet_sayisi.ToString() + " Adet Silinmiştir!\n" + "Siparişlerinize Tekar Bakınız", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            baglanti.Close();
            this.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) => numericUpDown1.Enabled = true;
    }
}
