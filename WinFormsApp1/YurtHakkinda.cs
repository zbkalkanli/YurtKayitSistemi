using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace WinFormsApp1
{
    public partial class YurtHakkinda : Form
    {
        int tekKisi = 1, ikiKisi = 2, ucKisi = 3;
        Label labelYurtIsmi;
        Label labelFontIcin;
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=YurtKayitSistemi; user Id=postgres; password=1234");
        public YurtHakkinda(Label label, Label labelFont)
        {
            InitializeComponent();
            Yurtlar yurtListesi = new Yurtlar();
            label1.Text = label.Text;
            label1.Font=labelFont.Font;
            this.Width = label1.Width * 2;
            labelYurtIsmi = label;
            labelFontIcin = labelFont;
        }


        private void button17_Click(object sender, EventArgs e)
        {
            Yurtlar oncekiSayfa = new Yurtlar();
            oncekiSayfa.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = { radioButton1, radioButton2, radioButton3 };
            int i = 0;
            int odaSayisi=0;
            for(;i<radioButtons.Length;i++)
            {
                if (radioButtons[i].Checked == true)
                    odaSayisi = i + 1;
                else
                {
                    label16.Visible = true;
                    label16.Text = "Lütfen Oda Seçiniz.";
                }
            }
            if (odaSayisi != 0)
            {
                KayitSayfasi kayitSayfasi = new KayitSayfasi(odaSayisi, labelYurtIsmi.Text);
                kayitSayfasi.Show();
                this.Hide();
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            YurtOzellikleri yurtOzellikleri = new YurtOzellikleri(labelYurtIsmi, labelFontIcin);
            yurtOzellikleri.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Hizmet hizmet = new Hizmet(labelYurtIsmi, labelFontIcin);
            hizmet.Show();
            this.Hide();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            OdaOzellikleri odaOzellikleri = new OdaOzellikleri(labelYurtIsmi, labelFontIcin, tekKisi);
            odaOzellikleri.Show();
            this.Hide();

        }

        private void label15_Click(object sender, EventArgs e)
        {
            OdaOzellikleri odaOzellikleri = new OdaOzellikleri(labelYurtIsmi, labelFontIcin, ikiKisi);
            odaOzellikleri.Show();
            this.Hide();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            OdaOzellikleri odaOzellikleri = new OdaOzellikleri(labelYurtIsmi, labelFontIcin, ucKisi);
            odaOzellikleri.Show();
            this.Hide();
        }

        private void YurtHakkinda_Load(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            //----------ADRES------------""

            NpgsqlCommand adresIdSorgu = new NpgsqlCommand("SELECT \"adres\" from \"Yurt\" where \"isim\"='"+label1.Text+"';\r\n", baglanti);
            var adresId = adresIdSorgu.ExecuteScalar().ToString();
            
            NpgsqlCommand mahalleSorgu = new NpgsqlCommand("SELECT \"mahalle\" from \"Adres\" where \"id\"=" + adresId+";", baglanti);
            var mahalle = mahalleSorgu.ExecuteScalar().ToString();
            NpgsqlCommand caddeSorgu = new NpgsqlCommand("SELECT \"cadde\" from \"Adres\" where \"id\"=" + adresId + ";", baglanti);
            var cadde = caddeSorgu.ExecuteScalar().ToString();
            NpgsqlCommand sokakSorgu = new NpgsqlCommand("SELECT \"sokak\" from \"Adres\" where \"id\"=" + adresId + ";", baglanti);
            var sokak = sokakSorgu.ExecuteScalar().ToString();

            NpgsqlCommand sehirIdSorgu = new NpgsqlCommand("SELECT \"sehir\" from \"Adres\" where \"id\"=" + adresId + ";", baglanti);
            var sehirId= sehirIdSorgu.ExecuteScalar().ToString();

            NpgsqlCommand ilceSorgu = new NpgsqlCommand("SELECT \"ilce\" FROM \"Sehir\" where \"id\"=" + sehirId+";", baglanti);
            var ilce = ilceSorgu.ExecuteScalar().ToString();
            NpgsqlCommand ilSorgu= new NpgsqlCommand("SELECT \"il\" FROM \"Sehir\" where \"id\"=" + sehirId + ";", baglanti);
            var il = ilSorgu.ExecuteScalar().ToString();

            label9.Text = mahalle + " " + cadde + " " + sokak + " " + ilce + "/" + il;

            //----------ADRES------------""

            NpgsqlCommand telSorgu = new NpgsqlCommand("SELECT \"telefon\" from \"Yurt\" where \"isim\"='" + label1.Text + "';\r\n", baglanti);
            label10.Text = telSorgu.ExecuteScalar().ToString();

            NpgsqlCommand kontenjanSorgu = new NpgsqlCommand("SELECT \"kontenjan\" from \"Yurt\" where \"isim\"='" + label1.Text + "';\r\n", baglanti);
            label11.Text = kontenjanSorgu.ExecuteScalar().ToString();

            NpgsqlCommand mevcutOgrenciSorgu = new NpgsqlCommand("SELECT \"mevcutOgrenciSayisi\" from \"Yurt\" where \"isim\"='" + label1.Text + "';\r\n", baglanti);
            label12.Text = mevcutOgrenciSorgu.ExecuteScalar().ToString();

            label16.Visible= false;
        }
    }
}
