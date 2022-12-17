using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Yurtlar : Form
    {
        public Yurtlar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = { radioButton1, radioButton2, radioButton3 };
            int i = 0;
            int odaSayisi = 0;
            for (; i < radioButtons.Length; i++)
            {
                if (radioButtons[i].Checked == true)
                    odaSayisi = i + 1;
                else
                {
                    label9.Visible = true;
                    radioButton1.Visible = true;
                    radioButton2.Visible = true;
                    radioButton3.Visible = true;
                }
            }
            if (odaSayisi != 0)
            {
                KayitSayfasi kayitSayfasi = new KayitSayfasi(odaSayisi, label1.Text);
                kayitSayfasi.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = { radioButton1, radioButton2, radioButton3 };
            int i = 0;
            int odaSayisi = 0;
            for (; i < radioButtons.Length; i++)
            {
                if (radioButtons[i].Checked == true)
                    odaSayisi = i + 1;
                else
                {
                    label9.Visible = true;
                    radioButton1.Visible = true;
                    radioButton2.Visible = true;
                    radioButton3.Visible = true;
                }
            }
            if (odaSayisi != 0)
            {
                KayitSayfasi kayitSayfasi = new KayitSayfasi(odaSayisi, label2.Text);
                kayitSayfasi.Show();
                this.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = { radioButton1, radioButton2, radioButton3 };
            int i = 0;
            int odaSayisi = 0;
            for (; i < radioButtons.Length; i++)
            {
                if (radioButtons[i].Checked == true)
                    odaSayisi = i + 1;
                else
                {
                    label9.Visible = true;
                    radioButton1.Visible = true;
                    radioButton2.Visible = true;
                    radioButton3.Visible = true;
                }
            }
            if (odaSayisi != 0)
            {
                KayitSayfasi kayitSayfasi = new KayitSayfasi(odaSayisi, label3.Text);
                kayitSayfasi.Show();
                this.Hide();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = { radioButton1, radioButton2, radioButton3 };
            int i = 0;
            int odaSayisi = 0;
            for (; i < radioButtons.Length; i++)
            {
                if (radioButtons[i].Checked == true)
                    odaSayisi = i + 1;
                else
                {
                    label9.Visible = true;
                    radioButton1.Visible = true;
                    radioButton2.Visible = true;
                    radioButton3.Visible = true;
                }
            }
            if (odaSayisi != 0)
            {
                KayitSayfasi kayitSayfasi = new KayitSayfasi(odaSayisi, label4.Text);
                kayitSayfasi.Show();
                this.Hide();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = { radioButton1, radioButton2, radioButton3 };
            int i = 0;
            int odaSayisi = 0;
            for (; i < radioButtons.Length; i++)
            {
                if (radioButtons[i].Checked == true)
                    odaSayisi = i + 1;
                else
                {
                    label9.Visible = true;
                    radioButton1.Visible = true;
                    radioButton2.Visible = true;
                    radioButton3.Visible = true;
                }
            }
            if (odaSayisi != 0)
            {
                KayitSayfasi kayitSayfasi = new KayitSayfasi(odaSayisi, label5.Text);
                kayitSayfasi.Show();
                this.Hide();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = { radioButton1, radioButton2, radioButton3 };
            int i = 0;
            int odaSayisi = 0;
            for (; i < radioButtons.Length; i++)
            {
                if (radioButtons[i].Checked == true)
                    odaSayisi = i + 1;
                else
                {
                    label9.Visible = true;
                    radioButton1.Visible = true;
                    radioButton2.Visible = true;
                    radioButton3.Visible = true;
                }
            }
            if (odaSayisi != 0)
            {
                KayitSayfasi kayitSayfasi = new KayitSayfasi(odaSayisi, label6.Text);
                kayitSayfasi.Show();
                this.Hide();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = { radioButton1, radioButton2, radioButton3 };
            int i = 0;
            int odaSayisi = 0;
            for (; i < radioButtons.Length; i++)
            {
                if (radioButtons[i].Checked == true)
                    odaSayisi = i + 1;
                else
                {
                    label9.Visible = true;
                    radioButton1.Visible = true;
                    radioButton2.Visible = true;
                    radioButton3.Visible = true;
                }
            }
            if (odaSayisi != 0)
            {
                KayitSayfasi kayitSayfasi = new KayitSayfasi(odaSayisi, label7.Text);
                kayitSayfasi.Show();
                this.Hide();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = { radioButton1, radioButton2, radioButton3 };
            int i = 0;
            int odaSayisi = 0;
            for (; i < radioButtons.Length; i++)
            {
                if (radioButtons[i].Checked == true)
                    odaSayisi = i + 1;
                else
                {
                    label9.Visible = true;
                    radioButton1.Visible = true;
                    radioButton2.Visible = true;
                    radioButton3.Visible = true;
                }
            }
            if (odaSayisi != 0)
            {
                KayitSayfasi kayitSayfasi = new KayitSayfasi(odaSayisi, label8.Text);
                kayitSayfasi.Show();
                this.Hide();
            }
        }

        private void Yurtlar_Load(object sender, EventArgs e)
        {
            label9.Visible= false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            YurtHakkinda yurt = new YurtHakkinda(label1, label13);
            yurt.Show();
            this.Hide();
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            YurtHakkinda yurt = new YurtHakkinda(label2, label13);
            yurt.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            YurtHakkinda yurt = new YurtHakkinda(label3, label13);
            yurt.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            YurtHakkinda yurt = new YurtHakkinda(label4, label13);
            yurt.Show();
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            YurtHakkinda yurt = new YurtHakkinda(label5, label13);
            yurt.Show();
            this.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            YurtHakkinda yurt = new YurtHakkinda(label6, label13);
            yurt.Show();
            this.Hide();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            YurtHakkinda yurt = new YurtHakkinda(label7, label13);
            yurt.Show();
            this.Hide();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            YurtHakkinda yurt = new YurtHakkinda(label8, label13);
            yurt.Show();
            this.Hide();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Form1 ilkSayfa = new Form1();
            ilkSayfa.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
