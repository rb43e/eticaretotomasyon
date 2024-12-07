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
using Microsoft.VisualBasic;
using System.Windows.Forms;

namespace eticaret
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public string uye_id { get; set; }

        private SqlDataReader reader;

        public Form2(SqlCommand komut) => this.komut = komut ?? throw new ArgumentNullException(nameof(komut));

        private SqlCommand komut;
        string urun_isim;
        string urun_fiyat;
        string urun_id;
        string uye_adi;
        public SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-1KMHI4I\MSSQLSERVER01;Initial Catalog=eticaret;Integrated Security=True");

        public TextBox GetTextBox2()
        {
            return textBox2;
        }

        public TextBox GetTextBox5()
        {
            return textBox5;
        }

        public TextBox GetTextBox4()
        {
            return textBox4;
        }

        public TextBox GetTextBox3()
        {
            return textBox3;
        }

        public TextBox GetTextBox6()
        {
            return textBox6;
        }

        public RichTextBox GetRichTextBox1()
        {
            return richTextBox1;
        }

        public string GetUye_adi()
        {
            return uye_adi;
        }

        public Label GetLabel1()
        {
            return label1;
        }

        public void getir(TextBox textBox2, TextBox textBox5, TextBox textBox4, TextBox textBox3, TextBox textBox6, RichTextBox richTextBox1, string uye_adi, Label label1)
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select urun_isim,urun_fiyat from urunler", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;

            komut = new SqlCommand("select * from uyeler where uye_id = '" + uye_id + "'", baglanti);
            reader = komut.ExecuteReader();
            if (reader.Read())
            {
                label1.Text = "Hoşgeldin " +reader["uye_adi"] + " " +reader["uye_soyadi"];
                textBox2.Text = reader["uye_adi"].ToString();
                textBox3.Text = reader["uye_soyadi"].ToString();
                textBox4.Text = reader["uye_tel"].ToString();
                textBox5.Text = reader["sifre"].ToString();
                textBox6.Text = reader["eposta"].ToString();
                richTextBox1.Text = reader["uye_adres"].ToString();
                uye_adi = reader["uye_adi"].ToString();

            }
            baglanti.Close();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            getir(GetTextBox2(), GetTextBox5(), GetTextBox4(), GetTextBox3(), GetTextBox6(), GetRichTextBox1(), GetUye_adi(), GetLabel1());
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.uye_id = uye_id;
            frm3.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        kod_uret:
            Random rastgele_sayi = new Random();
            int sayi = rastgele_sayi.Next(0, 999999999);
            Random rastgele = new Random();
            string harfler = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZabcçdefgğhıijklmnoöprsştuüvyz";
            string uret = "";
            for (int i = 0; i < 10; i++)
            {
                uret += harfler[rastgele.Next(harfler.Length)];
            }
            string siparis_kod = uret + sayi;
            baglanti.Open();
            komut = new SqlCommand("select * from siparisler where siparis_kod='" + siparis_kod + "'", baglanti);
            reader = komut.ExecuteReader();
            if (reader.Read()) { goto kod_uret; }
            reader.Close();
            string adet = Interaction.InputBox("Adet Sayısı Giriniz", "Adet Sayısı");
            komut = new SqlCommand("select urun_id from urunler where urun_isim='" + urun_isim + "' and urun_fiyat ='" + urun_fiyat + "'", baglanti);
            reader = komut.ExecuteReader();
            reader.Read();
            urun_id = reader["urun_id"].ToString();
            reader.Close();
            string ekle = "insert into siparisler (urun_id,uye_id,adet,siparis_kod) values (@urun_id,@uye_id,@adet,@siparis_kod)";
            SqlCommand komut2 = new SqlCommand(ekle, baglanti);
            komut2.Parameters.AddWithValue("@urun_id", urun_id);
            komut2.Parameters.AddWithValue("@uye_id", uye_id);
            komut2.Parameters.AddWithValue("@adet", adet);
            komut2.Parameters.AddWithValue("@siparis_kod", siparis_kod);
            komut2.ExecuteNonQuery();
            komut = new SqlCommand("select * from siparsiler where urun_id='" + urun_id + "' and uye_id ='' and adet=''", baglanti);
            MessageBox.Show(adet + " Adet " + urun_isim + " Siparişiniz Alınmıştır\n" + "Sipariş Kodunuz : " + siparis_kod);
            baglanti.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Görüşmek Üzere " + uye_adi, " Güle Güle ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            baglanti.Close();
            this.Close();
            uye_id = "";
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            string adi = textBox3.Text;
            string soyadi = textBox4.Text;
            string tel = textBox5.Text;
            string sifre = textBox6.Text;
            string eposta = textBox7.Text;
            string adres = richTextBox1.Text;
            baglanti.Open();
            string sorgu = "update uyeler set uye_adi = @uye_adi , uye_soyadi = @uye_soyadi , uye_tel = @uye_tel , uye_adres = @uye_adres , sifre = @sifre where uye_id = @uye_id";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@uye_id", uye_id);
            komut.Parameters.AddWithValue("@uye_adi", adi);
            komut.Parameters.AddWithValue("@uye_soyadi", soyadi);
            komut.Parameters.AddWithValue("@uye_tel", tel);
            komut.Parameters.AddWithValue("@uye_adres", adres);
            komut.Parameters.AddWithValue("@sifre", sifre);
            komut.Parameters.AddWithValue("@eposta", eposta);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Üyelik Bilgileriniz Güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == null) { getir(GetTextBox2(), GetTextBox5(), GetTextBox4(), GetTextBox3(), GetTextBox6(), GetRichTextBox1(), GetUye_adi(), GetLabel1()); }
            else
            {
                baglanti.Open();
                SqlDataAdapter ds = new SqlDataAdapter("select urun_isim,urun_fiyat from urunler where urun_isim like'%" + textBox1.Text + "%'", baglanti);
                DataTable tablo2 = new DataTable();
                ds.Fill(tablo2);
                dataGridView1.DataSource = tablo2;
                baglanti.Close();
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            urun_isim = dataGridView1.CurrentRow.Cells["urun_isim"].Value.ToString();
            urun_fiyat = dataGridView1.CurrentRow.Cells["urun_fiyat"].Value.ToString();
        }
    }
}
