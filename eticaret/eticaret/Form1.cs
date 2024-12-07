using eticaret;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-1KMHI4I\MSSQLSERVER01;Initial Catalog=eticaret;Integrated Security=True");
        SqlDataReader reader;
        private SqlCommand komut;

        public TextBox GetTextBox3()
        {
            return textBox3;
        }

        public TextBox GetTextBox5()
        {
            return textBox5;
        }

        public void kayit_temizle(TextBox textBox3, TextBox textBox5)
        {
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            richTextBox1.Clear();
            textBox7.Clear();

        }
        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            groupBox1.Enabled = true;
            kayit_temizle(GetTextBox3(), GetTextBox5());
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }
        public void kontrol(string control_malzeme)
        {
            if (control_malzeme == "" || control_malzeme == null) { kayit_temizle(GetTextBox3(), GetTextBox5()); }
        }


        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
        }

        private void radioButton2_CheckedChanged_2(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
            groupBox1.Enabled = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            string sifre = textBox2.Text;
            string eposta = textBox1.Text;
            komut = new SqlCommand("select * from uyeler where eposta = '" + eposta + "' and sifre='" + sifre + "'", baglanti);
            reader = komut.ExecuteReader();
            if (reader.Read())
            {
                Form2 frm2 = new Form2();
                Form3 frm3 = new Form3();
                frm3.uye_id = reader["uye_id"].ToString();
                frm2.uye_id = reader["uye_id"].ToString();
                MessageBox.Show("Hoþgeldin " + reader["uye_adi"] + " \n" + "Yönlendiriliyorsunuz!");
                frm2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Kullanýcý Adý veya Þifre Hatalý", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox3.Text == null) { MessageBox.Show("Boþ Alanlarý Doldur!"); }
            if (textBox4.Text == "" || textBox4.Text == null) { MessageBox.Show("Boþ Alanlarý Doldur!"); }
            if (textBox5.Text == "" || textBox5.Text == null) { MessageBox.Show("Boþ Alanlarý Doldur!"); }
            if (textBox6.Text == "" || textBox6.Text == null) { MessageBox.Show("Boþ Alanlarý Doldur!"); }
            if (textBox7.Text == "" || textBox7.Text == null) { MessageBox.Show("Boþ Alanlarý Doldur!"); }
            if (richTextBox1.Text == "" || richTextBox1.Text == null) { MessageBox.Show("Boþ Alanlarý Doldur!"); }
            else
            {
                string adi = textBox3.Text;
                string soyadi = textBox4.Text;
                string tel = textBox5.Text;
                string sifre = textBox6.Text;
                string adres = richTextBox1.Text;
                string eposta = textBox7.Text;
                baglanti.Open();
                komut = new SqlCommand("select * from uyeler where eposta = '@eposta'", baglanti);
                komut.Parameters.AddWithValue("@eposta", eposta);
                reader = komut.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("Lütfen Farklý Bir Eposta Adresi Girin!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    kayit_temizle(GetTextBox3(), GetTextBox5());
                }
                else
                {
                    reader.Close();
                    string sorgu = "insert into uyeler (uye_adi,uye_soyadi,uye_tel,uye_adres,sifre,eposta) values (@uye_adi,@uye_soyadi,@uye_tel,@uye_adres,@sifre,@eposta)";
                    komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@uye_adi", adi);
                    komut.Parameters.AddWithValue("@uye_soyadi", soyadi);
                    komut.Parameters.AddWithValue("@uye_tel", tel);
                    komut.Parameters.AddWithValue("@uye_adres", adres);
                    komut.Parameters.AddWithValue("@sifre", sifre);
                    komut.Parameters.AddWithValue("@eposta", eposta);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Üyeliðiniz Baþarýlý Bir Þekilde Kaydedildi! \n" + "Giriþ Yapýnýz", "Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    radioButton1.Checked = true;
                    textBox1.Text = eposta;
                    textBox2.Text = sifre;
                    button1.Focus();
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            kayit_temizle(GetTextBox3(), GetTextBox5());
        }
    }
}