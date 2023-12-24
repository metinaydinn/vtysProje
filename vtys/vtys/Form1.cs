using Npgsql;
using System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace vtys
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=vtysProje; user ID=postgres; password=gardolap41");


        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "SELECT *FROM kisiler JOIN personel ON kisiler.tckimlikno = personel.tckimlikno;\r\n";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void yolculariGetir_Click(object sender, EventArgs e)
        {
            string sorgu = "SELECT *FROM kisiler JOIN yolcu ON kisiler.tckimlikno = yolcu.tckimlikno;\r\n";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void soforListele_Click(object sender, EventArgs e)
        {
            string sorgu = "SELECT k.*, p.*, s.* FROM kisiler k JOIN personel p ON k.tckimlikno = p.tckimlikno JOIN sofor s ON p.tckimlikno = s.tckimlikno;\r\n";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void muavinListele_Click(object sender, EventArgs e)
        {
            string sorgu = "SELECT k.*, p.*, s.* FROM kisiler k JOIN personel p ON k.tckimlikno = p.tckimlikno JOIN muavin s ON p.tckimlikno = s.tckimlikno;\r\n";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void mclistele_Click(object sender, EventArgs e)
        {
            string sorgu = "SELECT k.*, p.*, s.* FROM kisiler k JOIN personel p ON k.tckimlikno = p.tckimlikno JOIN merkezcalisan s ON p.tckimlikno = s.tckimlikno;\r\n";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void otogarcalisanListele_Click(object sender, EventArgs e)
        {
            string sorgu = "SELECT k.*, p.*, s.* FROM kisiler k JOIN personel p ON k.tckimlikno = p.tckimlikno JOIN otogarcalisan s ON p.tckimlikno = s.tckimlikno;\r\n";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into kisiler(ad,soyad,tckimlikno,telefonno) values (@p1,@p2,@p3,@p4)", baglanti);
            komut1.Parameters.AddWithValue("@p1", textBox1.Text.ToString());
            komut1.Parameters.AddWithValue("@p2", textBox2.Text.ToString());
            komut1.Parameters.AddWithValue("@p3", textBox3.Text.ToString());
            komut1.Parameters.AddWithValue("@p4", textBox4.Text.ToString());
            komut1.ExecuteNonQuery();

            NpgsqlCommand komut2 = new NpgsqlCommand("insert into yolcu(tckimlikno,biletno) values(@p1,@p2)", baglanti);
            komut2.Parameters.AddWithValue("@p1", textBox3.Text.ToString());
            komut2.Parameters.AddWithValue("@p2", 1);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("YOLCU EKLEME ISLEMI BASARILI");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string sorgu = "SELECT* FROM kisiler;\r\n";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button8_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("Delete from yolcu where tckimlikno=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", textBox5.Text.ToString());
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("YOLCU SILME ISLEMI BASARILI");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut4 = new NpgsqlCommand("CALL updatephonenumber(@p1,@p2)", baglanti);
            komut4.Parameters.AddWithValue("@p1", textBox6.Text.ToString());
            komut4.Parameters.AddWithValue("@p2", textBox7.Text.ToString());
            komut4.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("TELEFON NUMARASI DEGISTIRME ISLEMI BASARILI");
        }
    }
}