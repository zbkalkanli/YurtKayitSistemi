using Microsoft.VisualBasic;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace WinFormsApp1
{
    public partial class KayitSayfasi : Form
    {
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=YurtKayitSistemi; user Id=postgres; password=1234");
        string[] veriler = new string[18];
        int veliId=0;
        int odemeId;
        int adresId;
        int ogrenciId;
        int egitimId;
        string yurtIsmi;
        int odaKisiSayisi;
        int adresinSehirIdsi;
        int secilenUniId;
        int secilenBolumId;
        int secilenFakulteId;
        string secilenOdemeBicimi;
        
        public KayitSayfasi(int OdaKisiSayisi, string yurtIsmi)
        {
            InitializeComponent();
            this.yurtIsmi = yurtIsmi;
            this.odaKisiSayisi= OdaKisiSayisi;
            
            
        }
        public void bilgilerGirildi()
        {;
            TextBox[] textBoxes = { textBox1, textBox6, textBox5, textBox3, textBox2, textBox4, textBox11, textBox10, textBox9, textBox8, textBox7, textBox17, textBox12, textBox13, textBox15, textBox16, textBox14, textBox22 };

            for (int i = 0; i < veriler.Length; i++)
            {
                veriler[i] = textBoxes[i].Text;
            }
        }
        public void odemeIdBulma()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            using var cmd = new NpgsqlCommand("select \"odalari\" from \"Yurt\" where \"isim\"='"+ yurtIsmi +"';\r\n", baglanti);
            var odalarId = cmd.ExecuteScalar().ToString();
            string odaId=null;
            if (odaKisiSayisi == 1)
            {
                using var tekKisilikCommand = new NpgsqlCommand("select \"tekKisilikOzellikleri\" from \"OdaSecenekleri\" where \"id\"="+ odalarId +" ;\r\n", baglanti);
                odaId = tekKisilikCommand.ExecuteScalar().ToString();
            }
            else if(odaKisiSayisi == 2)
            {
                using var ciftKisilikCommand = new NpgsqlCommand("select \"ikiKisilikOzellikleri\" from \"OdaSecenekleri\" where \"id\"=" + odalarId + " ;\r\n", baglanti);
                odaId = ciftKisilikCommand.ExecuteScalar().ToString();
            }
            else if (odaKisiSayisi == 3)
            {
                using var ucKisilikCommand = new NpgsqlCommand("select \"ucKisilikOzellikleri\" from \"OdaSecenekleri\" where \"id\"=" + odalarId + " ;\r\n", baglanti);
                odaId= ucKisilikCommand.ExecuteScalar().ToString();
            }
            using var odemeIdKomutu = new NpgsqlCommand("select \"id\" from \"Odeme\" where \"odaId\"="+ odaId +" and \"odemeTuru\"='"+ comboBox6.SelectedItem +"';", baglanti);
            var odemeId = odemeIdKomutu.ExecuteScalar().ToString();
            this.odemeId = (int)Convert.ToInt32(odemeId);
        }
        public void sehirBilgisi()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            NpgsqlCommand komut = new NpgsqlCommand("Select MAX(id) FROM \"Sehir\";", baglanti);
            var sonId = komut.ExecuteScalar().ToString();
            int sehirId = (int)Convert.ToInt32(sonId);
            string arama = "select \"id\" from \"Sehir\" where il='" + veriler[14] +"' AND ilce='" + veriler[15] +"'";
            var varMiKomutu = new NpgsqlCommand(arama, baglanti);
            var varMi = (int)Convert.ToInt64(varMiKomutu.ExecuteScalar());
            
            if(varMi>=0)
            {
                adresinSehirIdsi = ++sehirId;
            }
            else
            {
                adresinSehirIdsi=(int)Convert.ToInt64(varMi);
            }

            NpgsqlCommand ekleme = new NpgsqlCommand("insert into \"Sehir\" \r\nvalues (" + adresinSehirIdsi + ", '" + veriler[14] + "', '" + veriler[15] + "');", baglanti);
            ekleme.ExecuteNonQuery();
        }
        public void adresiVeritabanınaEkle()
        {
            adresId = 0;
            bilgilerGirildi();
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            NpgsqlCommand sonIdKomutu = new NpgsqlCommand("Select MAX(id) FROM \"Adres\";", baglanti);
            var sonId = sonIdKomutu.ExecuteScalar().ToString();
            adresId = (int)Convert.ToInt64(sonId);
            adresId++;
            NpgsqlCommand komut = new NpgsqlCommand("INSERT INTO \"Adres\" (\"id\", \"mahalle\", \"cadde\", \"sokak\", \"sehir\", \"postaKodu\") \r\nVALUES (" + adresId + ",'" + veriler[11] + "','" + veriler[12] + "','" + veriler[13] + "',"+adresinSehirIdsi+",'" + veriler[16] +"')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        public void veliyiVeritabanınaEkle()
        {
            veliId = 0;
            bilgilerGirildi();
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            NpgsqlCommand sonIdKomutu = new NpgsqlCommand("Select MAX(id) FROM \"Veli\";", baglanti);
            var sonId = sonIdKomutu.ExecuteScalar().ToString();
            if (sonId == "") veliId = -1;
            else veliId = (int)Convert.ToInt64(sonId);
            veliId++;
            NpgsqlCommand komut = new NpgsqlCommand("INSERT into \"Veli\"\r\n(\"id\", \"isim\", \"soyisim\", \"telefonNumarasi\", \"meslek\", \"ogrenimDurumu\")\r\nVALUES\r\n(" + veliId + "," + "'" + veriler[6] + "'," + "'" + veriler[7] + "'," + "'" + veriler[8] + "'," + "'" + veriler[9] + "'," + "'" + veriler[10] + "'" + ");", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        public string yurtIdsi()
        {
            bilgilerGirildi();
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            using var cmd = new NpgsqlCommand("select \"id\" from \"Yurt\" where \"isim\"='"+ yurtIsmi +"';", baglanti);
            var yurtId = cmd.ExecuteScalar().ToString();
            baglanti.Close();
            return yurtId;
        }
        public void egitimiVeritabaninaEkle()
        {
            bolumIdBulma();
            egitimId = 0;
            bilgilerGirildi();
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            NpgsqlCommand sonIdKomutu = new NpgsqlCommand("Select MAX(id) FROM \"Egitim\";", baglanti);
            var sonId = sonIdKomutu.ExecuteScalar().ToString();
            if (sonId == "") egitimId = -1;
            else egitimId = (int)Convert.ToInt64(sonId);
            egitimId++;
            NpgsqlCommand komut = new NpgsqlCommand("INSERT into \"Egitim\"\r\n(\"id\", \"universite\", \"bolum\", \"egitimTuru\", \"sinif\" )\r\nVALUES\r\n(" + egitimId + "," + "'" + secilenUniId + "'," + "'" + secilenBolumId + "'," + "'" + comboBox4.SelectedItem + "'," + "'" + veriler[17] +"');", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        private void buttonKayitOl_Click(object sender, EventArgs e)
        {
            if(comboBox6.SelectedIndex == null || comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || comboBox3.SelectedItem == null || comboBox4.SelectedItem == null || comboBox6.SelectedItem==null || textBox1==null || textBox2 == null || textBox3 == null || textBox4 == null || textBox5 == null || textBox6 == null || textBox7 == null || textBox8 == null || textBox9 == null || textBox10 == null || textBox11 == null || textBox12 == null || textBox13 == null || textBox14 == null || textBox15 == null || textBox16 == null || textBox17 == null || textBox22== null) 
                MessageBox.Show("Lütfen boş olan kutucukları doldurunuz.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {

                sehirBilgisi();
                adresiVeritabanınaEkle();
                veliyiVeritabanınaEkle();
                egitimiVeritabaninaEkle();

                string yurtId = yurtIdsi();

                string dateTime = "16-12-2020";

                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                NpgsqlCommand sonIdKomutu = new NpgsqlCommand("Select MAX(id) FROM \"Ogrenci\";", baglanti);
                var sonId = sonIdKomutu.ExecuteScalar().ToString();
                if (sonId == "") ogrenciId = -1;
                else ogrenciId = (int)Convert.ToInt64(sonId);
                ogrenciId++;
                NpgsqlCommand komut = new NpgsqlCommand("INSERT into \"Ogrenci\"\r\n(\"id\", \"tcNo\", \"ad\", \"soyad\", \"telefonNumarasi\", \"adres\", \"yurt\", \"kayitTarihi\", \"uyruk\", \"dogumTarihi\", \"veli\", \"odeme\", \"egitim\")\r\nVALUES\r\n(" + ogrenciId + ", '" + veriler[2] + "', '" + veriler[0] + "', '" + veriler[1] + "', '" + veriler[3] + "', " + adresId + ", " + yurtId + ", " + dateTime + ", '" + veriler[4] + "', '" + veriler[5] + "', " + veliId + ", " + odemeId + ", " + egitimId + ");", baglanti);
                komut.ExecuteNonQuery();
                NpgsqlCommand cmd = new NpgsqlCommand("select \"Odeme\".\"odemeYapilacakHesapNo\" from \"Odeme\" where \"id\"=" + odemeId + ";", baglanti);
                var hesapNo = cmd.ExecuteScalar().ToString();

                NpgsqlCommand command = new NpgsqlCommand("select \"OdaOzellikleri\".\"yillikUcret\" from \"OdaOzellikleri\" join \"Odeme\" on \"OdaOzellikleri\".\"id\"= \"Odeme\".\"odaId\" where \"odaId\"=" + odemeId + ";", baglanti);
                var yillikUcretStr = command.ExecuteScalar().ToString();
                int yillikUcret = (int)Convert.ToInt64(yillikUcretStr);
                baglanti.Close();
                SonSayfa sonSayfa = new SonSayfa(yurtIsmi, hesapNo, yillikUcret, odaKisiSayisi, secilenOdemeBicimi);
                sonSayfa.Show();
                this.Hide();
            }
        }

        private void KayitSayfasi_Load(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            NpgsqlCommand sonIdKomutu = new NpgsqlCommand("Select MAX(id) FROM \"Universite\";", baglanti);
            var sonId = sonIdKomutu.ExecuteScalar().ToString();
            int sonID = (int)Convert.ToInt32(sonId);

            for (int i = 0; i < sonID; i++)
            {
                string arama = "select \"universiteAdi\" from \"Universite\" where \"id\"=" + i + ";";
                NpgsqlCommand uniIsimleriKomut = new NpgsqlCommand(arama, baglanti);
                var universite = uniIsimleriKomut.ExecuteScalar().ToString();

                comboBox1.Items.Add(universite);
            }
            comboBox4.Items.Add("Birinci Öğretim");
            comboBox4.Items.Add("İkinci Öğretim");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string secilenUniIdSorgusu = "select \"id\" from \"Universite\" where \"universiteAdi\"='"+comboBox1.SelectedItem+"';\r\n";
            NpgsqlCommand secilenUniIdKomutu = new NpgsqlCommand(secilenUniIdSorgusu, baglanti);
            secilenUniId = (int)Convert.ToInt64(secilenUniIdKomutu.ExecuteScalar());
            comboBox2.Items.Clear();
            string fakulteAdlariSorgu = "select \"fakulteAdi\" from \"Fakulte\" join \"Universite\" on \"Fakulte\".\"universite\"=\"Universite\".\"id\" where \"Universite\".\"universiteAdi\"='"+comboBox1.SelectedItem + "';\r\n\r\n";

            NpgsqlDataReader rdr;
            ArrayList fakulteIsimleri = new ArrayList();

            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            NpgsqlCommand fakulteAdlariKomut = new NpgsqlCommand(fakulteAdlariSorgu, baglanti);

            rdr = fakulteAdlariKomut.ExecuteReader();
            int i = 0;
            while (rdr.Read())
            {
                fakulteIsimleri.Add(Convert.ToString(rdr["fakulteAdi"]));
                comboBox2.Items.Add(fakulteIsimleri[i]);
                i++;
            }
            rdr.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            string secilenFakulteIdSorgusu = "select \"fakulteNo\" from \"Fakulte\" where \"universite\"="+secilenUniId+" and \"fakulteAdi\"='"+comboBox2.SelectedItem+"';";
            NpgsqlCommand secilenFakulteIdKomutu = new NpgsqlCommand(secilenFakulteIdSorgusu, baglanti);
            secilenFakulteId = (int)Convert.ToInt64(secilenFakulteIdKomutu.ExecuteScalar());
            string bolumAdlariSorgu = "select \"bolumAdi\" from \"Fakulte\" join \"Bolum\" on \"Fakulte\".\"fakulteNo\"=\"Bolum\".\"fakulte\" where \"fakulteAdi\"='"+comboBox2.SelectedItem + "' and \"universite\"="+secilenUniId+";\r\n";

            NpgsqlDataReader rdr;
            ArrayList bolumIsimleri = new ArrayList();

            NpgsqlCommand bolumAdlariKomut = new NpgsqlCommand(bolumAdlariSorgu, baglanti);

            rdr = bolumAdlariKomut.ExecuteReader();
            int i = 0;
            while (rdr.Read())
            {
                bolumIsimleri.Add(Convert.ToString(rdr["bolumAdi"]));
                comboBox3.Items.Add(bolumIsimleri[i]);
                i++;
            }
            rdr.Close();
        }
        public void bolumIdBulma() {

            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            string secilenBolumIdSorgusu = "select \"bolumNo\" from \"Bolum\" where \"bolumAdi\"='" + comboBox3.SelectedItem + "' and \"fakulte\"="+ secilenFakulteId +";";
            NpgsqlCommand secilenBolumIdKomutu = new NpgsqlCommand(secilenBolumIdSorgusu, baglanti);
            var bolumId = secilenBolumIdKomutu.ExecuteScalar().ToString();
            secilenBolumId = (int)Convert.ToInt64(bolumId);
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            secilenOdemeBicimi = comboBox6.SelectedItem.ToString();
        }
    }
}
