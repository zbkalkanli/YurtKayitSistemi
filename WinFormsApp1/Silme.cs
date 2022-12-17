using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Silme : Form
    {
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=YurtKayitSistemi; user Id=postgres; password=1234");
        int silinecekOgrenci;
        public Silme()
        {
            InitializeComponent();
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            string ismi = textBox1.Text;
            string soyismi = textBox2.Text;
            NpgsqlCommand cmd = new NpgsqlCommand("select id from \"Ogrenci\" where ad='" + ismi + "' and soyad='" + soyismi + "';", baglanti);
            var arama = cmd.ExecuteScalar();
                int varMi = (int)Convert.ToInt64(arama);
                
                if (varMi < 0||arama==null) MessageBox.Show("Böyle bir öğrenci bulunmamaktadır.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    NpgsqlCommand cmd1 = new NpgsqlCommand("delete from \"Ogrenci\" where ad='" + ismi + "' and soyad='" + soyismi + "';", baglanti);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Öğrenci silindi", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Text = "";
                    textBox2.Text = "";
                }

        }

        private void Silme_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Yöneticiİslemleri yöneticiİslemleri = new Yöneticiİslemleri();
            yöneticiİslemleri.Show();
            this.Hide();
        }
    }
}
