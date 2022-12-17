using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace WinFormsApp1
{
    public partial class Hizmet : Form
    {
        Label labelFontIcin;
        Label labelIsımIcin;
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=YurtKayitSistemi; user Id=postgres; password=1234");

        public Hizmet(Label labelIsim, Label labelFont)
        {
            InitializeComponent();
            label19.Text = labelIsim.Text;
            label19.Font = labelFont.Font;
            this.Width = label19.Width * 3 / 2;
            labelIsımIcin = labelIsim;
            labelFontIcin = labelFont;

            baglanti.Open();
            int sayac = 0;
            int labelSayaci = 0;
            string[] rows = { "kahvalti", "tv", "odaTemizligi", "aksamYemegi", "sicakSu", "guvenlik", "icmeSuyu", "internet", "isinma"};
            Label[] labellar = { label10, label11, label12, label13, label14, label15, label16, label17, label18 };

            string sorgu1 = "SELECT \"isim\" from \"Yurt\" ;";
            using var cmd1 = new NpgsqlCommand(sorgu1, baglanti);
            while (labelSayaci != 9)
            {
                string sorgu = "select \"Hizmet\".\"" + rows[sayac] +"\" from \"Hizmet\" join \"Yurt\" on \"Hizmet\".\"id\" = \"Yurt\".\"hizmet\" where \"Yurt\".\"isim\"='"+labelIsim.Text+"';";
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

        private void Hizmet_Load(object sender, EventArgs e)
        {
           
        }
    }
}
