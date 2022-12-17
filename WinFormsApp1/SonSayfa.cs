using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class SonSayfa : Form
    {
        string yurtIsmi, hesapNo, odemeTuru;
        int yillikUcret, odaKapasitesi;

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        public SonSayfa(string yurtIsmi, string hesapNo, int yillikUcret, int odaKapasitesi, string odemeTuru)
        {
            this.yurtIsmi = yurtIsmi;
            this.hesapNo = hesapNo;
            this.odemeTuru = odemeTuru;
            this.yillikUcret = yillikUcret;
            this.odemeTuru = odemeTuru;
            this.odaKapasitesi = odaKapasitesi;
            InitializeComponent();
        }

        private void SonSayfa_Load(object sender, EventArgs e)
        {
            if (odemeTuru == "Nakit")
            {
                label4.Visible = false;
                label6.Visible = false;
            }
            else label6.Text = hesapNo;
            label5.Text = yurtIsmi;
            label8.Text = odaKapasitesi.ToString();
            label3.Text = yillikUcret.ToString();
        }
    }
}
