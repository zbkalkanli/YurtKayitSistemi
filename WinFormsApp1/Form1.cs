using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void buttonListele_Click(object sender, EventArgs e)
        {
           
            Yurtlar yurtlistesi = new Yurtlar();
            yurtlistesi.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Arama aramaSayfasi = new Arama();
            aramaSayfasi.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Yöneticiİslemleri admin=new Yöneticiİslemleri();
            admin.Show();
            this.Hide();
        }
    }
}
