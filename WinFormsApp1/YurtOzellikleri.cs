using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class YurtOzellikleri : Form
    {
        Label labelFontIcin;
        Label labelIsımIcin;

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=YurtKayitSistemi; user Id=postgres; password=1234");
       
        public YurtOzellikleri(Label labelIsim, Label labelFont)
        {
            InitializeComponent();
            label1.Text = labelIsim.Text;
            label1.Font = labelFont.Font;
            this.Width = label1.Width * 3 / 2;
            labelIsımIcin = labelIsim;
            labelFontIcin = labelFont;
            baglanti.Open();
            int sayac = 0;
            int labelSayaci = 0;
            string[] rows = { "kutuphane", "bilgisayarOdasi", "yemekhane", "sporOdasi", "yuzmeHavuzu", "revir", "lobi", "camasirhane", "utuOdasi", "mescid", "kafeterya", "asansor", "bahce", "kamera", "konferansSalonu", "atolyeOdasi", "abdesthane", "teras", "etutOdasi" };
            Label[] labellar = { label20, label21, label22, label23, label24, label25, label26, label27, label28, label29, label30, label31, label32, label33, label34, label35, label36, label37, label38 };

            string sorgu1 = "SELECT \"isim\" from \"Yurt\" ;";
            using var cmd1 = new NpgsqlCommand(sorgu1, baglanti);
            while (labelSayaci != 19)
            {
                string sorgu = "select \"YurtOzellikleri\".\"" + rows[sayac] + "\" from \"YurtOzellikleri\" join \"Yurt\" on \"YurtOzellikleri\".\"id\" = \"Yurt\".\"yurtOzellikleri\" where \"Yurt\".\"isim\"='" + labelIsim.Text + "';";
                using var cmd = new NpgsqlCommand(sorgu, baglanti);
                var veri = cmd.ExecuteScalar().ToString();
                if (veri == "False")
                    labellar[labelSayaci].Text = " × ";
                else if (veri == "True")
                    labellar[labelSayaci].Text = " ✓ ";
                sayac++;
                labelSayaci++;
            }


        }
        private void button1_Click(object sender, EventArgs e)
        {
            YurtHakkinda yurtHakkinda = new YurtHakkinda(labelIsımIcin, labelFontIcin);
            yurtHakkinda.Show();
            this.Hide();
        }

        private void YurtOzellikleri_Load(object sender, EventArgs e)
        {

        }
    }
}
