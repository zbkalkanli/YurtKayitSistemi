using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Güncelleme : Form
    {
        string ad, soyad;
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=YurtKayitSistemi; user Id=postgres; password=1234");

        public Güncelleme()
        {
            InitializeComponent();
        }

        private void Güncelleme_Load(object sender, EventArgs e)
        {

        }

        private void güncellemeIslemi()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            NpgsqlCommand cmd = new NpgsqlCommand("select \"ad\" from \"Ogrenci\" where \"Ogrenci\".\"ad\"='" + ad + "' and \"Ogrenci\".\"soyad\"='" + soyad + "'; ", baglanti);
            NpgsqlCommand cmd1 = new NpgsqlCommand("select \"soyad\" from \"Ogrenci\" where \"Ogrenci\".\"ad\"='" + ad + "' and \"Ogrenci\".\"soyad\"='" + soyad + "'; ", baglanti);
            NpgsqlCommand cmd2 = new NpgsqlCommand("select \"tcNo\" from \"Ogrenci\" where \"Ogrenci\".\"ad\"='" + ad + "' and \"Ogrenci\".\"soyad\"='" + soyad + "'; ", baglanti);
            NpgsqlCommand cmd3 = new NpgsqlCommand("select \"telefonNumarasi\" from \"Ogrenci\" where \"Ogrenci\".\"ad\"='" + ad + "' and \"Ogrenci\".\"soyad\"='" + soyad + "'; ", baglanti);
            NpgsqlCommand cmd4 = new NpgsqlCommand("select \"uyruk\" from \"Ogrenci\" where \"Ogrenci\".\"ad\"='" + ad + "' and \"Ogrenci\".\"soyad\"='" + soyad + "'; ", baglanti);
            var arama1 = cmd.ExecuteScalar();
            var arama2 = cmd1.ExecuteScalar();
            if (arama1 == null || arama2 == null) MessageBox.Show("Böyle bir öğrenci bulunmamaktadır.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                panel1.Visible = false;
                panel2.Visible = true;
                panel1.Enabled = false;
                panel2.Enabled = true;
                textBox3.Text = arama1.ToString();
                textBox4.Text = arama2.ToString();
                textBox5.Text = cmd2.ExecuteScalar().ToString();
                textBox6.Text = cmd3.ExecuteScalar().ToString();
                textBox7.Text = cmd4.ExecuteScalar().ToString();

            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            NpgsqlCommand cmd = new NpgsqlCommand("UPDATE \"Ogrenci\" SET \"ad\"='" + textBox3.Text +
                "', \"soyad\"='" + textBox4.Text + "', \"tcNo\"='" + textBox5.Text + "', \"telefonNumarasi\"='" +
                textBox6.Text + "' , \"uyruk\"='" + textBox7.Text + "' where \"Ogrenci\".\"ad\"='" + ad + "' " +
                "and \"Ogrenci\".\"soyad\"='" + soyad + "'; ", baglanti);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Öğrenci güncellendi", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Yöneticiİslemleri ynt=new Yöneticiİslemleri();
            ynt.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Yöneticiİslemleri ynt = new Yöneticiİslemleri();
            ynt.Show();
            this.Hide();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Yöneticiİslemleri ynt = new Yöneticiİslemleri();
            ynt.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ad = textBox1.Text; soyad = textBox2.Text;
            güncellemeIslemi();
        }
    }
}
