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
    public partial class OdaOzellikleri : Form
    {
        Label labelFontIcin;
        Label labelIsimIcin;
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=YurtKayitSistemi; user Id=postgres; password=1234");
        public OdaOzellikleri(Label labelIsim, Label labelFont, int kacKisi)
        {
            InitializeComponent();
            label1.Text = labelIsim.Text;
            label1.Font = labelFont.Font;
            this.Width = label1.Width * 2;
            labelIsimIcin = labelIsim;
            labelFontIcin = labelFont;

            baglanti.Open();
            int sayac = 0;
            int labelSayaci = 0;
            string[] rows = { "kisiselDolap", "kitaplik", "odadaBanyoWc", "ortakBanyo", "buzdolabi", "hali", "calismaMasasi", "tv", "nevresim", "komodin", "miniMutfak", "bazaliYatak", "ranza", "normalYatak", "odaKapasitesi", "yillikUcret" };
            Label[] labellar = { label20, label21, label22, label23, label24, label25, label26, label27, label28, label29, label30, label31, label32, label33, label34, label35 };
            string odaSecenekleriIdSorgu = "SELECT \"OdaSecenekleri\".\"id\" from \"Yurt\" join \"OdaSecenekleri\" on \"Yurt\".\"odalari\"=\"OdaSecenekleri\".\"id\" where \"Yurt\".\"isim\"='" + labelIsim.Text + "';\r\n";
            using var odaSecenekleriIdKomut = new NpgsqlCommand(odaSecenekleriIdSorgu, baglanti);
            var odaSecenekleriId = odaSecenekleriIdKomut.ExecuteScalar().ToString();

            if (kacKisi == 1)
            {
                while (labelSayaci != 16)
                {
                    string sorgu = "SELECT \"OdaOzellikleri\".\"" + rows[sayac] + "\" FROM \"OdaOzellikleri\" join \"OdaSecenekleri\" on \"OdaOzellikleri\".\"id\"=\"OdaSecenekleri\".\"tekKisilikOzellikleri\" where \"OdaSecenekleri\".\"id\"=" + odaSecenekleriId + ";";
                    using var cmd = new NpgsqlCommand(sorgu, baglanti);
                    var veri = cmd.ExecuteScalar().ToString();
                    if (veri == "False")
                        labellar[labelSayaci].Text = " × ";
                    else if (veri == "True")
                        labellar[labelSayaci].Text = " ✓ ";
                    else
                        labellar[labelSayaci].Text = veri;
                    sayac++;
                    labelSayaci++;
                }
            }
            else if (kacKisi == 2)
            {
                while (labelSayaci != 16)
                {
                    string sorgu = "SELECT \"OdaOzellikleri\".\"" + rows[sayac] + "\" FROM \"OdaOzellikleri\" join \"OdaSecenekleri\" on \"OdaOzellikleri\".\"id\"=\"OdaSecenekleri\".\"ikiKisilikOzellikleri\" where \"OdaSecenekleri\".\"id\"=" + odaSecenekleriId + ";";
                    using var cmd = new NpgsqlCommand(sorgu, baglanti);
                    var veri = cmd.ExecuteScalar().ToString();
                    if (veri == "False")
                        labellar[labelSayaci].Text = " × ";
                    else if (veri == "True")
                        labellar[labelSayaci].Text = " ✓ ";
                    else
                        labellar[labelSayaci].Text = veri;
                    sayac++;
                    labelSayaci++;
                }
            }
            else if (kacKisi == 3)
            {
                while (labelSayaci != 16)
                {
                    string sorgu = "SELECT \"OdaOzellikleri\".\"" + rows[sayac] + "\" FROM \"OdaOzellikleri\" join \"OdaSecenekleri\" on \"OdaOzellikleri\".\"id\"=\"OdaSecenekleri\".\"ucKisilikOzellikleri\" where \"OdaSecenekleri\".\"id\"=" + odaSecenekleriId + ";";
                    using var cmd = new NpgsqlCommand(sorgu, baglanti);
                    var veri = cmd.ExecuteScalar().ToString();
                    if (veri == "False")
                        labellar[labelSayaci].Text = " × ";
                    else if (veri == "True")
                        labellar[labelSayaci].Text = " ✓ ";
                    else
                        labellar[labelSayaci].Text = veri;
                    sayac++;
                    labelSayaci++;
                }
            }
        }

        private void OdaOzellikleri_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            YurtHakkinda yurtHakkinda = new YurtHakkinda(labelIsimIcin, labelFontIcin);
            yurtHakkinda.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KayitSayfasi kayit = new KayitSayfasi(Convert.ToInt16(label34.Text), labelIsimIcin.Text);
            kayit.Show();
            this.Hide();
        }

    }
}
