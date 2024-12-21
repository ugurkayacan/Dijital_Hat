using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dijital_Hat
{
    public partial class takip_et : Form
    {

        int say = 0;

        public double en_buyuk(double x,double y,double z)
        {
            double ara=0;

            double buyuk =0;
            buyuk = Math.Max(x, y);
            buyuk = Math.Max(buyuk, z);

            return buyuk;
        }

        public int kontrol = 0;
        public int index = 0;
        public int sayac = 1;
        public double max1x;
        public double max1y;
        public double max1z;
        public double max2x;
        public double max2y;
        public double max2z;
        public double max3x;
        public double max3y;
        public double max3z;
        public double max4x;
        public double max4y;
        public double max4z;
        public double max5x;
        public double max5y;
        public double max5z;
        public double max6x;
        public double max6y;
        public double max6z;
        public double max7x;
        public double max7y;
        public double max7z;
        public double max8x;
        public double max8y;
        public double max8z;
        public double max9x;
        public double max9y;
        public double max9z;
        public double max10x;
        public double max10y;
        public double max10z;

        public double k1=0;
        public double k2=0;
        public double k3=0;
        public double k4=0;
        public double k5=0;
        public double k6=0;
        public double k7=0;
        public double k8=0;
        public double k9=0;
        public double k10=0;

        public double[] D1x = new double[15000];
        public double[] D1y = new double[15000];
        public double[] D1z = new double[15000];
        public double[] D2x = new double[15000];
        public double[] D2y = new double[15000];
        public double[] D2z = new double[15000];
        public double[] D3x = new double[15000];
        public double[] D3y = new double[15000];
        public double[] D3z = new double[15000];
        public double[] D4x = new double[15000];
        public double[] D4y = new double[15000];
        public double[] D4z = new double[15000];
        public double[] D5x = new double[15000];
        public double[] D5y = new double[15000];
        public double[] D5z = new double[15000];
        public double[] D6x = new double[15000];
        public double[] D6y = new double[15000];
        
        public double[] D6z = new double[15000];
        public double[] D7x = new double[15000];
        public double[] D7y = new double[15000];
        public double[] D7z = new double[15000];
        public double[] D8x = new double[15000];
        public double[] D8y = new double[15000];
        public double[] D8z = new double[15000];
        public double[] D9x = new double[15000];
        public double[] D9y = new double[15000];
        public double[] D9z = new double[15000];
        public double[] D10x = new double[15000];
        public double[] D10y = new double[15000];
        public double[] D10z = new double[15000]; 
        double pga_xyz=0;
        public takip_et()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Application.StartupPath + "\\Dijital_hat_veri_tababanı.accdb");

        public void veri_akıt(int b)
        {
            k1 = Convert.ToDouble(textBox1.Text);
            k2 = Convert.ToDouble(textBox2.Text);
            k3 = Convert.ToDouble(textBox3.Text);
            k4 = Convert.ToDouble(textBox4.Text);
            k5 = Convert.ToDouble(textBox5.Text);
            k6 = Convert.ToDouble(textBox6.Text);
            k7 = Convert.ToDouble(textBox7.Text);
            k8 = Convert.ToDouble(textBox8.Text);
            k9 = Convert.ToDouble(textBox9.Text);
            k10 = Convert.ToDouble(textBox10.Text);


           
            //OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/hp/Desktop/Dijital_Hat/Dijital_hat_veri_tababanı.accdb");
            //OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/Dijital_hat_veri_tababanı.accdb");

            if (b==1)
            { 
                baglanti.Open();
                OleDbCommand komut1 = new OleDbCommand();
                komut1.Connection = baglanti;
                komut1.CommandText = ("Select * From deprem_1");
                IDataReader oku1 = komut1.ExecuteReader();
                
                while (oku1.Read())
                {

                    D1x[index] =Convert.ToDouble( oku1["X"]);
                    D1y[index] = Convert.ToDouble(oku1["Y"]);
                    D1z[index] = Convert.ToDouble(oku1["Z"]);
                   
                    index++;



                }
                baglanti.Close();
                max1x = D1x.Max();
                max1y = D1y.Max();
                max1z = D1z.Max();

                max1x = max1x * 0.0010197162129779;
                max1y = max1y * 0.0010197162129779;
                max1z = max1z * 0.0010197162129779;
                pga_xyz = en_buyuk(max1x, max1y, max1z);
                if(pga_xyz>k1)
                {   
                   
                    button1.Enabled = true;
                    button1.BackColor = Color.Red;
                    kontrol = 0;
                    listBox1.Items.Add("PGA-[M0]->"+pga_xyz.ToString());     
                
                
                }

               
               
                index = 0;
               
            }

            if (b == 2)
            {
                baglanti.Open();
                OleDbCommand komut2 = new OleDbCommand();
                komut2.Connection = baglanti;
                komut2.CommandText = ("Select * From deprem_2");
                IDataReader oku2 = komut2.ExecuteReader();

                while (oku2.Read())
                {
                    D2x[index] = Convert.ToDouble(oku2["X"]);
                    D2y[index] = Convert.ToDouble(oku2["Y"]);
                    D2z[index] = Convert.ToDouble(oku2["Z"]);
                    index++;


                }
                baglanti.Close();
                max2x = D2x.Max();
                max2y = D2y.Max();
                max2z = D2z.Max();

                max2x = max2x * 0.0010197162129779;
                max2y = max2y * 0.0010197162129779;
                max2z = max2z * 0.0010197162129779;
                pga_xyz = en_buyuk(max2x, max2y, max2z);
                if ( pga_xyz > k2)
                {   
                    
                    button9.Enabled = true;
                    button9.BackColor = Color.Red;
                    kontrol = 1;
                    listBox1.Items.Add("PGA-[M1]->" + pga_xyz.ToString());

                }
                
                index = 0;
              
            }

            if (b == 3)
            {
                baglanti.Open();
                OleDbCommand komut3 = new OleDbCommand();
                komut3.Connection = baglanti;
                komut3.CommandText = ("Select * From deprem_3");
                IDataReader oku3 = komut3.ExecuteReader();


                while (oku3.Read())
                {

                    D3x[index] = Convert.ToDouble(oku3["X"]);
                    D3y[index] = Convert.ToDouble(oku3["Y"]);
                    D3z[index] = Convert.ToDouble(oku3["Z"]);
                    index++;

                }
                baglanti.Close();
                max3x = D3x.Max();
                max3y = D3y.Max();
                max3z = D3z.Max();

                max3x = max3x * 0.0010197162129779;
                max3y = max3y * 0.0010197162129779;
                max3z = max3z * 0.0010197162129779;
                pga_xyz = en_buyuk(max3x, max3y, max3z);
                if ( pga_xyz > k3)
                {
                    button8.Enabled = true;
                    button8.BackColor = Color.Red;
                    kontrol = 2;
                    listBox1.Items.Add("PGA-[M2]->" + pga_xyz.ToString());


                }

                
                index = 0;
                
            }


            if (b == 4)
            {
                baglanti.Open();
                OleDbCommand komut4 = new OleDbCommand();
                komut4.Connection = baglanti;
                komut4.CommandText = ("Select * From deprem_4");
                IDataReader oku4 = komut4.ExecuteReader();


                while (oku4.Read())
                {
                    D4x[index] = Convert.ToDouble(oku4["X"]);
                    D4y[index] = Convert.ToDouble(oku4["Y"]);
                    D4z[index] = Convert.ToDouble(oku4["Z"]);
                    index++;


                }
                baglanti.Close();
                max4x = D4x.Max();
                max4y = D4y.Max();
                max4z = D4z.Max();

                max4x = max4x * 0.0010197162129779;
                max4y = max4y * 0.0010197162129779;
                max4z = max4z * 0.0010197162129779;
                pga_xyz = en_buyuk(max4x, max4y, max4z);
                if (pga_xyz > k4)
                {
                   
                    button7.Enabled = true;
                    button7.BackColor = Color.Red;
                    kontrol = 3;
                    listBox1.Items.Add("PGA-[M3]->" + pga_xyz.ToString());


                }
                
                index = 0;
                

            }


            if (b == 5)
            {
                baglanti.Open();
                OleDbCommand komut5 = new OleDbCommand();
                komut5.Connection = baglanti;
                komut5.CommandText = ("Select * From deprem_5");
                IDataReader oku5 = komut5.ExecuteReader();


                while (oku5.Read())
                {

                    D5x[index] = Convert.ToDouble(oku5["X"]);
                    D5y[index] = Convert.ToDouble(oku5["Y"]);
                    D5z[index] = Convert.ToDouble(oku5["Z"]);
                    index++;

                }
                baglanti.Close();
                max5x = D5x.Max();
                max5y = D5y.Max();
                max5z = D5z.Max();

                max5x = max5x * 0.0010197162129779;
                max5y = max5y * 0.0010197162129779;
                max5z = max5z * 0.0010197162129779;
                pga_xyz = en_buyuk(max5x, max5y, max5z);
                if ( pga_xyz > k5 )
                {
                    
                    button13.Enabled = true;
                    button13.BackColor = Color.Red;
                    kontrol = 4;
                    listBox1.Items.Add("PGA-[M4]->" + pga_xyz.ToString());

                }
                
                index = 0;
                
            }


            if (b == 6)
            {
                baglanti.Open();
                OleDbCommand komut6 = new OleDbCommand();
                komut6.Connection = baglanti;
                komut6.CommandText = ("Select * From deprem_6");
                IDataReader oku6 = komut6.ExecuteReader();

                while (oku6.Read())
                {
                    D6x[index] = Convert.ToDouble(oku6["X"]);
                    D6y[index] = Convert.ToDouble(oku6["Y"]);
                    D6z[index] = Convert.ToDouble(oku6["Z"]);
                    index++;


                }
                baglanti.Close();
                max6x = D6x.Max();
                max6y = D6y.Max();
                max6z = D6z.Max();

                max6x = max6x * 0.0010197162129779;
                max6y = max6y * 0.0010197162129779;
                max6z = max6z * 0.0010197162129779;
                pga_xyz = en_buyuk(max6x, max6y, max6z);
                if ( pga_xyz > k6 )
                {
                   
                    button6.Enabled = true;
                    button6.BackColor = Color.Red;
                    kontrol = 5;
                    listBox1.Items.Add("PGA-[M5]->" + pga_xyz.ToString());


                }
                
                index = 0;
                
            }


            if (b == 7)
            {
                baglanti.Open();
                OleDbCommand komut7 = new OleDbCommand();
                komut7.Connection = baglanti;
                komut7.CommandText = ("Select * From deprem_7");
                IDataReader oku7 = komut7.ExecuteReader();

                while (oku7.Read())
                {
                    D7x[index] = Convert.ToDouble(oku7["X"]);
                    D7y[index] = Convert.ToDouble(oku7["Y"]);
                    D7z[index] = Convert.ToDouble(oku7["Z"]);
                    index++;

                }
                baglanti.Close();
                max7x = D7x.Max();
                max7y = D7y.Max();
                max7z = D7z.Max();



                max7x = max7x * 0.0010197162129779;
                max7y = max7y * 0.0010197162129779;
                max7z = max7z * 0.0010197162129779;
                pga_xyz = en_buyuk(max7x, max7y, max7z);
                if ( pga_xyz > k7 )
                {
                    
                    button5.Enabled = true;
                    button5.BackColor = Color.Red;
                    kontrol = 6;
                    listBox1.Items.Add("PGA-[M6]->" + pga_xyz.ToString());


                }
                
                index = 0;
                

            }


            if (b == 8)
            {
                baglanti.Open ();
                OleDbCommand komut8 = new OleDbCommand();
                komut8.Connection = baglanti;
                komut8.CommandText = ("Select * From deprem_8");
                IDataReader oku8 = komut8.ExecuteReader();

                while (oku8.Read())
                {

                    D8x[index] = Convert.ToDouble(oku8["X"]);
                    D8y[index] = Convert.ToDouble(oku8["Y"]);
                    D8z[index] = Convert.ToDouble(oku8["Z"]);
                    index++;

                }
                baglanti.Close();
                max8x = D8x.Max();
                max8y = D8y.Max();
                max8z = D8z.Max();

                max8x = max8x * 0.0010197162129779;
                max8y = max8y * 0.0010197162129779;
                max8z = max8z * 0.0010197162129779;
                pga_xyz = en_buyuk(max8x, max8y, max8z);
                if ( pga_xyz > k8 )
                {
                    
                    button4.Enabled = true;
                    button4.BackColor = Color.Red;
                    kontrol = 7;
                    listBox1.Items.Add("PGA-[M7]->" + pga_xyz.ToString());


                }
                
                index = 0;
                
            }

            if (b == 9)
            {
                baglanti.Open();
                OleDbCommand komut9 = new OleDbCommand();
                komut9.Connection = baglanti;
                komut9.CommandText = ("Select * From deprem_9");
                IDataReader oku9 = komut9.ExecuteReader();

                while (oku9.Read())
                {

                    D9x[index] = Convert.ToDouble(oku9["X"]);
                    D9y[index] = Convert.ToDouble(oku9["Y"]);
                    D9z[index] = Convert.ToDouble(oku9["Z"]);
                    index++;

                }
                baglanti.Close();
                max9x = D9x.Max();
                max9y = D9y.Max();
                max9z = D9z.Max();

                max9x = max9x * 0.0010197162129779;
                max9y = max9y * 0.0010197162129779;
                max9z = max9z * 0.0010197162129779;
                pga_xyz = en_buyuk(max9x, max9y, max9z);
                if ( pga_xyz > k9)
                {
                    
                    button3.Enabled = true;
                    button3.BackColor = Color.Red;
                    kontrol = 8;
                    listBox1.Items.Add("PGA-[M8]->" + pga_xyz.ToString());

                }
                
                index = 0;
                
            }



            if (b == 10)
            {
                baglanti.Open();
                OleDbCommand komut10 = new OleDbCommand();
                komut10.Connection = baglanti;
                komut10.CommandText = ("Select * From deprem_10");
                IDataReader oku10 = komut10.ExecuteReader();

                while (oku10.Read())
                {

                    D10x[index] = Convert.ToDouble(oku10["X"]);
                    D10y[index] = Convert.ToDouble(oku10["Y"]);
                    D10z[index] = Convert.ToDouble(oku10["Z"]);
                    index++;

                }
                baglanti.Close();
                max10x = D10x.Max();
                max10y = D10y.Max();
                max10z = D10z.Max();

                max10x = max10x * 0.0010197162129779;
                max10y = max10y * 0.0010197162129779;
                max10z = max10z * 0.0010197162129779;
                pga_xyz = en_buyuk(max10x, max10y, max10z);
                if ( pga_xyz > k10)
                {
                   
                    button2.Enabled = true;
                    button2.BackColor = Color.Red;
                    kontrol = 9;
                    listBox1.Items.Add("PGA-[M9]->" + pga_xyz.ToString());



                }
                
                index = 0;
                b++;
                

            }
}

      
        public double ac_m0;
        public double ac_m1;
        public double ac_m2;
        public double ac_m3;
        public double ac_m4;
        public double ac_m5;
        public double ac_m6;
        public double ac_m7;
        public double ac_m8;
        public double ac_m9;


        private void button1_Click(object sender, EventArgs e)
        {
            mo a = new mo();
            a.mc0 = Convert.ToDouble(textBox1.Text);

            a.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            m1 b = new m1();
            b.mc1 = Convert.ToDouble(textBox2.Text);
            b.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            m2 c = new m2();
            c.mc2 = Convert.ToDouble(textBox3.Text);
            c.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            m3 d = new m3();
            d.mc3 = Convert.ToDouble(textBox4.Text);
            d.Show();
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            m5 f = new m5();
            f.mc5 = Convert.ToDouble(textBox6.Text);
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            m6 g = new m6();
            g.mc6 = Convert.ToDouble(textBox7.Text);
            g.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            m7 n = new m7();
            n.mc7 = Convert.ToDouble(textBox8.Text);
            n.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            m8 m = new m8();
            m.mc8 = Convert.ToDouble(textBox9.Text);
            m.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m9 z = new m9();
            z.mc9 = Convert.ToDouble(textBox10.Text);
            z.Show();
        }

        private void takip_et_Load(object sender, EventArgs e)
        {
        
            button16.BackColor = Color.Red;
            timer2.Enabled = true;
            
           
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button13.Enabled = false;

         
            textBox1.Text = ac_m0.ToString();
            textBox2.Text = ac_m1.ToString();
            textBox3.Text = ac_m2.ToString();
            textBox4.Text = ac_m3.ToString();
            textBox5.Text = ac_m4.ToString();
            textBox6.Text = ac_m5.ToString();
            textBox7.Text = ac_m6.ToString();
            textBox8.Text = ac_m7.ToString();
            textBox9.Text = ac_m8.ToString();
            textBox10.Text = ac_m9.ToString();

            mo m0 = new mo();
            m0.mc0 = Convert.ToDouble(textBox1.Text);


        }

        private void button10_Click(object sender, EventArgs e)
        {
            Ayarlar a = new Ayarlar();
            this.Close();
            a.Show();
         }

        private void button11_Click(object sender, EventArgs e)
        {
            Ana_ekran a = new Ana_ekran();
            a.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            sayac = 0;
            button15.BackColor = Color.Green;
            button16.BackColor = Color.Gray;
            timer3.Enabled = true;

            timer1.Enabled = true;
         }

        private void timer1_Tick(object sender, EventArgs e)
        {
            veri_akıt(sayac);

            sayac++;
            
            if(button1.BackColor==Color.Red &&kontrol==0)
            { listBox2.Items.Add("M0 NOKTASINDA HASAR TESPİT EDİLDİ"+" "+DateTime.Now.ToString());kontrol = 0; }

            if(button9.BackColor == Color.Red&&kontrol==1)
            { listBox2.Items.Add("M1 NOKTASINDA HASAR TESPİT EDİLDİ" + " " + DateTime.Now.ToString()); kontrol = 0; }

            if (button8.BackColor == Color.Red&& kontrol == 2)
            { listBox2.Items.Add("M2 NOKTASINDA HASAR TESPİT EDİLDİ" + " " + DateTime.Now.ToString()); kontrol = 0; }

            if (button7.BackColor == Color.Red&& kontrol == 3)
            { listBox2.Items.Add("M3 NOKTASINDA HASAR TESPİT EDİLDİ" + " " + DateTime.Now.ToString()); kontrol = 0; }

            if (button13.BackColor == Color.Red&& kontrol == 4)
            { listBox2.Items.Add("M4 NOKTASINDA HASAR TESPİT EDİLDİ" + " " + DateTime.Now.ToString()); kontrol = 0; }

            if (button6.BackColor == Color.Red&& kontrol == 5)
            { listBox2.Items.Add("M5 NOKTASINDA HASAR TESPİT EDİLDİ" + " " + DateTime.Now.ToString()); kontrol = 0; }

            if (button5.BackColor == Color.Red&& kontrol == 6)
            { listBox2.Items.Add("M6 NOKTASINDA HASAR TESPİT EDİLDİ" + " " + DateTime.Now.ToString()); kontrol = 0; }

            if (button4.BackColor == Color.Red&& kontrol == 7)
            { listBox2.Items.Add("M7 NOKTASINDA HASAR TESPİT EDİLDİ" + " " + DateTime.Now.ToString()); kontrol = 0; }

            if (button3.BackColor == Color.Red&& kontrol == 8)
            { listBox2.Items.Add("M8 NOKTASINDA HASAR TESPİT EDİLDİ" + " " + DateTime.Now.ToString()); kontrol = 0; }

            if (button2.BackColor == Color.Red&& kontrol == 9)
            { listBox2.Items.Add("M9 NOKTASINDA HASAR TESPİT EDİLDİ" + " " + DateTime.Now.ToString()); kontrol = 0; }
            
            if (sayac==11)
            { 
               
                timer1.Enabled = false;
              
                button16.BackColor = Color.Red;
                button15.BackColor = Color.Gray;
               

            }
           
        }

        private void button13_Click(object sender, EventArgs e)
        {
            m4 z = new m4();
            z.mc4 = Convert.ToDouble(textBox5.Text);
            z.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label13.Text = DateTime.Now.ToString();
            
           

        }
        int kilitle=0;
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.Red || button2.BackColor == Color.Red || button3.BackColor == Color.Red || button4.BackColor == Color.Red || button5.BackColor == Color.Red || button6.BackColor == Color.Red || button7.BackColor == Color.Red || button8.BackColor == Color.Red || button9.BackColor == Color.Red || button13.BackColor == Color.Red)
            {
                button17.Text = "Tehtid bulundu!!!";
            
                
                if (say % 2 == 0)
                { button17.BackColor = Color.Red; say++; }
                else
                { button17.BackColor = Color.Black; say--; }


                if(timer1.Enabled==false)
                {
                    timer3.Enabled = false;
                    button17.BackColor = Color.Red;
                    button17.Text = "Tehtid bulundu!!!";
                    say = 0;


                }

            }
        }

        private void button17_Click(object sender, EventArgs e)
        {

        }
       

        private void timer4_Tick(object sender, EventArgs e)
        {
       
           
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
          
         
          
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            {

                button1.BackColor = Color.Green;

            }
            if (checkBox2.Checked == true)
            {

                button9.BackColor = Color.Green;

            }
            if (checkBox3.Checked == true)
            {

                button8.BackColor = Color.Green;

            }
            if (checkBox4.Checked == true)
            {

                button7.BackColor = Color.Green;

            }
            if (checkBox5.Checked == true)
            {

                button13.BackColor = Color.Green;

            }
            if (checkBox6.Checked == true)
            {

                button6.BackColor = Color.Green;

            }
            if (checkBox7.Checked == true)
            {

                button5.BackColor = Color.Green;

            }
            if (checkBox8.Checked == true)
            {

                button4.BackColor = Color.Green;

            }
            if (checkBox9.Checked == true)
            {

                button3.BackColor = Color.Green;

            }
            if (checkBox10.Checked == true)
            {

                button2.BackColor = Color.Green;

            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            button17.BackColor = Color.Orange;
            button17.Text = "Tehtit Bulunamadı";

        }
    }
}
