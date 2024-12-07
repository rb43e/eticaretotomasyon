using eticaret;
using System.Data;
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
using Microsoft.VisualBasic;

namespace eticaret
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlDataReader reader;
        SqlCommand komut;
        string[] urunler;

        public string uye_id { get; set; }
        List<string> liste = new List<string>();
        List<string> liste2 = new List<string>();
        List<string> liste3 = new List<string>();
        string urun_isim, urun_fiyat, urun_id, siparis_id, siparis_kod, siparis_adet;

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            siparis_kod = dataGridView1.CurrentRow.Cells["Sipariş Kodu"].Value.ToString();
        }

        public SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-1KMHI4I\MSSQLSERVER01;Initial Catalog=eticaret;Integrated Security=True");
        

        private void Form3_Load_1(object sender, EventArgs e)
        {
            getir();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Siparis_kod = siparis_kod;
            frm4.ShowDialog();
            this.Close();
        }

        public void getir()
        {
            baglanti.Open();
            komut = new SqlCommand("select * from siparisler where uye_id='" + uye_id + "'", baglanti);
            reader = komut.ExecuteReader();
            int ddd = 0;
            while (reader.Read())
            {
                ddd++;
                liste.Add(reader["urun_id"].ToString());
                liste2.Add(reader["siparis_kod"].ToString());
                liste3.Add(reader["adet"].ToString());
            }
            if (ddd == 0) { MessageBox.Show("Hiç Siparişiniz Bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop); this.Close(); }
            reader.Close();
            string urun_isim;
            int urun_fiyat;
            DataTable tablo = new DataTable();
            tablo.Columns.Add("Ürün İsim");
            tablo.Columns.Add("Ürün Fiyat");
            tablo.Columns.Add("Sipariş Adedi");
            tablo.Columns.Add("Sipariş Kodu");
            for (int i = 0; i < liste.Count(); i++)
            {
                reader.Close();
                komut = new SqlCommand("select * from urunler where urun_id='" + liste[i] + "'", baglanti);
                reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    urun_isim = reader["urun_isim"].ToString();
                    siparis_adet = liste3[i];
                    siparis_kod = liste2[i];
                    urun_fiyat = Convert.ToInt16(reader["urun_fiyat"]);
                    tablo.Rows.Add(urun_isim, urun_fiyat.ToString(), siparis_adet, siparis_kod);
                }
            }
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
    }
}
