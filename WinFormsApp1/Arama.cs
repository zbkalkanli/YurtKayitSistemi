using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Arama : Form
    {
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=YurtKayitSistemi; user Id=postgres; password=1234");
        string arananSehir;
        public Arama()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            arananSehir = textBox1.Text;
            NpgsqlDataReader rdr;
            ArrayList adresIdleri = new ArrayList();

            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            NpgsqlCommand command = new NpgsqlCommand("select \"Adres\".\"id\" from \"Adres\" join" +
                " \"Sehir\" on \"Sehir\".\"id\"= \"Adres\".\"sehir\" where \"Sehir\".\"il\"='" + arananSehir + "';", baglanti);

            rdr = command.ExecuteReader();

            while (rdr.Read())
            {
                adresIdleri.Add(Convert.ToString(rdr["id"]));
            }
            rdr.Close();


            ArrayList yurtIsimleri = new ArrayList();
            int j = adresIdleri.Count;
            for (int i = 0; i < j; i++)
            {

                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                NpgsqlCommand cmd = new NpgsqlCommand("select \"Yurt\".\"isim\" from \"Yurt\" " +
                    "join \"Adres\" on \"Yurt\".\"adres\"= \"Adres\".\"id\" where \"Adres\".\"id\" =" + 
                    adresIdleri[i] + ";", baglanti);

                rdr = cmd.ExecuteReader();
                yurtIsimleri.Clear();
                while (rdr.Read())
                {
                    yurtIsimleri.Add(Convert.ToString(rdr["isim"]));
                }
                rdr.Close();
                int l = yurtIsimleri.Count;
                for (int k = 0; k < l; k++)
                {
                    label1.Text += yurtIsimleri[k];
                    label1.Text += "\n";
                }
            }
            if (label1.Text == "")
                label1.Text = "Bu şehirde yurdumuz bulunmamaktadır.";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 formSayfasi = new Form1();
            formSayfasi.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            label1.Text = "";
        }

        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            label1.Text = "";
        }

        private void Arama_Load(object sender, EventArgs e)
        {

        }
    }
}
