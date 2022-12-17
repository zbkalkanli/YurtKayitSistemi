using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WinFormsApp1
{
    public class Yurt
    {
        public int yurtIsim { get; set; }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=YurtKayitSistemi; user Id=postgres; password=1234");

        public ArrayList view_data()
        {

            NpgsqlDataReader rdr;
            ArrayList yurtIsimleri = new ArrayList();

            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            NpgsqlCommand command = new NpgsqlCommand("SELECT \"isim\" from \"Yurt\" ;", baglanti);

            rdr = command.ExecuteReader();

            while (rdr.Read())
            {
                yurtIsimleri.Add(Convert.ToString(rdr["isim"]));
            }
            rdr.Close();

            return yurtIsimleri;
        }
    }
}
