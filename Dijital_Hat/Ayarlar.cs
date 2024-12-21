using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Dijital_Hat
{
    public partial class Ayarlar : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/hp/Desktop/Dijital_Hat/Dijital_hat_veri_tababanı.accdb");
        
        public double deger=0.2;

        public double a0;
        public double a1;
        public double a2;
        public double a3;
        public double a4;
        public double a5;
        public double a6;
        public double a7;
        public double a8;

        public double a9;



        public Ayarlar()
        {
            InitializeComponent();
        }
     
        void atama(int sec )
        {



            if (sec == 1)
            {
                if (comboBox2.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen geçerli bir m seçiniz...");
                }
                else
                {
                    string selectedcmb = comboBox2.SelectedItem.ToString();

                    if (selectedcmb == "m0")
                    { textBox9.Text = textBox2.Text; }
                    else if (selectedcmb == "m1")
                    { textBox10.Text = textBox2.Text; }
                    else if (selectedcmb == "m2")
                    { textBox11.Text = textBox2.Text; }
                    else if (selectedcmb == "m3")
                    { textBox12.Text = textBox2.Text; }
                    else if (selectedcmb == "m4")
                    { textBox13.Text = textBox2.Text; }
                    else if (selectedcmb == "m5")
                    { textBox14.Text = textBox2.Text; }
                    else if (selectedcmb == "m6")
                    { textBox15.Text = textBox2.Text; }
                    else if (selectedcmb == "m7")
                    { textBox16.Text = textBox2.Text; }
                    else if (selectedcmb == "m8")
                    { textBox17.Text = textBox2.Text; }
                    else if (selectedcmb == "m9")
                    { textBox18.Text = textBox2.Text; }
                }
            }
            else if(sec==2)
            {

                
                textBox9.Text = textBox2.Text; 
                
                textBox10.Text = textBox2.Text;
                
                textBox11.Text = textBox2.Text; 
                
                textBox12.Text = textBox2.Text; 
               
                textBox13.Text = textBox2.Text; 
                
                textBox14.Text = textBox2.Text; 
                
                textBox15.Text = textBox2.Text; 
               
                textBox16.Text = textBox2.Text; 
               
                textBox17.Text = textBox2.Text; 
               
                textBox18.Text = textBox2.Text; 

            }

        }

        void kisitla()
        {
            comboBox1.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;
            button5.Enabled=false;


            button1.Enabled = false;
            textBox1.Enabled = false;
            textBox8.Enabled = false;
            textBox7.Enabled = false;
            textBox6.Enabled = false;
            textBox5.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox2.Enabled = false;


        }
        void renklendir(int renk)
        {
            if(renk==0)
            {

            textBox1.BackColor = Color.Red;
            textBox8.BackColor = Color.Red;
            textBox7.BackColor = Color.Red;
            textBox6.BackColor = Color.Red;
            textBox5.BackColor = Color.Red;
            textBox4.BackColor = Color.Red;
            textBox3.BackColor = Color.Red;
            }
            else
            {
                textBox1.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox3.BackColor = Color.White;

            }

         }

        void temizle()
        {

            textBox1.Clear();
            textBox8.Clear();
            textBox7.Clear();
            textBox6.Clear();
            textBox5.Clear();
            textBox4.Clear();
            textBox3.Clear();


        }

        double Su = 0;    //Efektif kohezyon
        double Ye = 0;    //Özgül ağırlık       
        double h = 0;     //Zayıf zemin kalınlığı
        double Qs = 0;    //içsel sürtünme açısı
        double a = 0;     //Yamaç eğim açısı
        double Yw = 0;    //suyun özgül ağırlığı
        double hW = 0;    //Zemin suyu yüksekliği
        double Fs = 0;    //Fs=GS Statik durumda, deprem kuvvetlerini dikkate almadan ki şevin güvenlik katsayısı
         public  double  ac;    //Kritik ivme

        private void Ayarlar_Load(object sender, EventArgs e)
        {
            this.TopMost = true;

            takip_et t = new takip_et();
            t.Close();
            kisitla();
            comboBox1.Text = "Geçerli Kritik ivme seç";
            comboBox2.Text = "Geçerli m nesnesi";


            object[] n = new object[] { 0.1,0.2,0.3,0.4,0.5 };
            object[] k = new object[] {"m0","m1","m2","m3","m4","m5","m6","m7","m8","m9" };
            comboBox1.Items.AddRange(n);
            comboBox2.Items.AddRange(k);
      



        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "" || textBox8.Text == "" || textBox7.Text == "" || textBox6.Text == "" || textBox5.Text == "" || textBox4.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show(" MANUEL HASAPLAMA YAPABİLMEK İÇİN LÜTFEN İLGİLİ ALANLARI DOLDURUNUZ!!!");
                renklendir(0);
             }
            else
            {

                Su = Convert.ToDouble(textBox1.Text);
                Ye = Convert.ToDouble(textBox8.Text);
                h = Convert.ToDouble(textBox7.Text);
                Qs = Convert.ToDouble(textBox6.Text);
                a = Convert.ToDouble(textBox5.Text);
                Yw = Convert.ToDouble(textBox4.Text);
                hW = Convert.ToDouble(textBox3.Text);


                Fs = (Su / (Ye * h * System.Math.Sin(a))) + (System.Math.Tan(Qs) / System.Math.Tan(a)) * ((1 - Yw * hW) / Ye * h);
                ac = (Fs - 1) * System.Math.Sin(a);
                textBox2.Text = ac.ToString();


                atama(1);
                



            }
        }

        private void manuel_CheckedChanged(object sender, EventArgs e)
        {
            temizle();

            renklendir(1);


            button1.Enabled = true;

            textBox1.Enabled = true;
            textBox8.Enabled = true;
            textBox7.Enabled = true;
            textBox6.Enabled = true;
            textBox5.Enabled = true;
            textBox4.Enabled = true;
            textBox3.Enabled = true;


            comboBox1.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;
        }

        private void test_CheckedChanged(object sender, EventArgs e)
        {
            kisitla();
            button4.Enabled = true;
            Su = 60;    //Efektif kohezyon
            Ye = 15.5;    //Özgül ağırlık       
            h = 3;     //Zayıf zemin kalınlığı
            Qs = 15 * System.Math.PI / 180;    //içsel sürtünme açısı
            a = 47 * System.Math.PI / 180;     //Yamaç eğim açısı
            Yw = 20;    //suyun özgül ağırlığı
            hW = 0.5;    //Zemin suyu yüksekliği
            Fs = 0;    //Fs=GS Statik durumda, deprem kuvvetlerini dikkate almadan ki şevin güvenlik katsayısı
            ac = 0;    //Kritik ivme
            Fs = (Su / (Ye * h * System.Math.Sin(a))) + (System.Math.Tan(Qs) / System.Math.Tan(a)) * ((1 - Yw * hW) / Ye * h);
            ac = (Fs - 1) * System.Math.Sin(a);


            textBox1.Text = Su.ToString();
            textBox8.Text = Ye.ToString();
            textBox7.Text = h.ToString();
            textBox6.Text = Qs.ToString();
            textBox5.Text = a.ToString();
            textBox4.Text = Yw.ToString();
            textBox3.Text = hW.ToString();
                

            textBox2.Text = ac.ToString();
        }

        private void otomatik_CheckedChanged(object sender, EventArgs e)
        {
            temizle();
            kisitla();
            renklendir(1);

            button2.Enabled = true;
            comboBox1.Enabled = true;


       

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            { textBox2.Text = "Lütfen geçerli bir değer seçin!!!"; }
            else
            {
                textBox2.Text = comboBox1.SelectedItem.ToString();

                atama(2);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\hp\Desktop\Dijital_Hat\Dijital_hat_veri_tababanı.accdb
            takip_et t = new takip_et();
            OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Application.StartupPath + "\\Dijital_hat_veri_tababanı.accdb");


            if (textBox9.Text == "")
            { t.ac_m0 = 0.2; }
            else
            { t.ac_m0 = Convert.ToDouble(Math.Round(decimal.Parse(textBox9.Text), 7)); }

            if (textBox10.Text == "")
            { t.ac_m1 = 0.2; }
            else
            { t.ac_m1 = Convert.ToDouble(Math.Round(decimal.Parse(textBox10.Text), 7)); }


            if (textBox11.Text == "")
            { t.ac_m2 = 0.2; }
            else
            { t.ac_m2 = Convert.ToDouble(Math.Round(decimal.Parse(textBox11.Text), 7)); }



            if (textBox12.Text == "")
            { t.ac_m3 = 0.2; }
            else
            { t.ac_m3 = Convert.ToDouble(Math.Round(decimal.Parse(textBox12.Text), 7)); }


            if (textBox13.Text == "")
            { t.ac_m4 = 0.2; }
            else
            { t.ac_m4 = Convert.ToDouble(Math.Round(decimal.Parse(textBox13.Text), 7)); }


            if (textBox14.Text == "")
            { t.ac_m5 = 0.2; }
            else
            { t.ac_m5 = Convert.ToDouble(Math.Round(decimal.Parse(textBox14.Text), 7)); }




            if (textBox15.Text == "")
            { t.ac_m6 = 0.2; }
            else
            { t.ac_m6 = Convert.ToDouble(Math.Round(decimal.Parse(textBox15.Text), 7)); }



            if (textBox16.Text == "")
            { t.ac_m7 = 0.2; }
            else
            { t.ac_m7 = Convert.ToDouble(Math.Round(decimal.Parse(textBox16.Text), 7)); }


            if (textBox17.Text == "")
            { t.ac_m8 = 0.2; }
            else
            { t.ac_m8 = Convert.ToDouble(Math.Round(decimal.Parse(textBox17.Text), 7)); }


            if (textBox18.Text == "")
            { t.ac_m9 = 0.2; }
            else
            { t.ac_m9 = Convert.ToDouble(Math.Round(decimal.Parse(textBox18.Text), 7)); }

            this.Close();

            t.Show();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            atama(2);
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox9.Text = textBox2.Text;

            textBox10.Text = textBox2.Text;

            textBox11.Text = textBox2.Text;

            textBox12.Text = textBox2.Text;

            textBox13.Text = textBox2.Text;

            textBox14.Text = textBox2.Text;

            textBox15.Text = textBox2.Text;

            textBox16.Text = textBox2.Text;

            textBox17.Text = textBox2.Text;

            textBox18.Text = textBox2.Text;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            kisitla();
            button5.Enabled = true;
            textBox2.Enabled = true;
        }
    }
}
