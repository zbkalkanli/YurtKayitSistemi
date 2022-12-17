using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Yöneticiİslemleri : Form
    {
        string girisKodu = "admin";
        string sifre = "1234";
        public Yöneticiİslemleri()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (girisKodu == textBox1.Text & sifre == textBox2.Text)
            {
                textBox1.Visible= false;
                textBox2.Visible= false;
                label1.Visible= false;
                label2.Visible= false;
                button1.Visible= false;
                button1.Enabled=false;
                textBox1.Enabled=false;
                textBox2.Enabled=false;

                button2.Enabled = true;
                button3.Enabled = true;
                button2.Visible = true;
                button3.Visible= true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Güncelleme güncelleme = new Güncelleme();
            güncelleme.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Silme silme = new Silme();
            silme.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form=new Form1();
            form.Show();
            this.Hide();
        }
    }
}
