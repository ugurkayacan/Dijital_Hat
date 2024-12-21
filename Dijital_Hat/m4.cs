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
    public partial class m4 : Form
    {
        public m4()
        {
            InitializeComponent();
        }
        public void m_kisitla()
        {

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;

        }
        public double mc4;
        double[] D1x = new double[15000];
        double[] D1y = new double[15000];
        double[] D1z = new double[15000];
        takip_et t = new takip_et();
        mo m = new mo();
        int index = 0;
        private void m4_Load(object sender, EventArgs e)
        {
            m_kisitla();
            timer1.Enabled = true;
            OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Application.StartupPath + "\\Dijital_hat_veri_tababanı.accdb");
            baglanti.Open();
            OleDbCommand komut1 = new OleDbCommand();
            komut1.Connection = baglanti;
            komut1.CommandText = ("Select * From deprem_5");
            IDataReader oku1 = komut1.ExecuteReader();
            while (oku1.Read())
            {

                chart1.Series["X"].Points.AddXY(oku1["Kimlik"], oku1["X"]);
                chart2.Series["Y"].Points.AddXY(oku1["Kimlik"], oku1["Y"]);
                chart3.Series["Z"].Points.AddXY(oku1["Kimlik"], oku1["Z"]);
                listBox_x_s.Items.Add(oku1["X"]);
                listBox_y_s.Items.Add(oku1["Y"]);
                listBox_z_s.Items.Add(oku1["Z"]);
                D1x[index] = Convert.ToDouble(oku1["X"]) * 0.0010197162129779;
                D1y[index] = Convert.ToDouble(oku1["Y"]) * 0.0010197162129779;
                D1z[index] = Convert.ToDouble(oku1["Z"]) * 0.0010197162129779;



                listBox_x_g.Items.Add(Math.Round(D1x[index], 7));

                listBox_y_g.Items.Add(Math.Round(D1y[index], 7));

                listBox_z_g.Items.Add(Math.Round(D1z[index], 7));
                index++;




            }
            textBox5.Text = Math.Round(D1x.Max(), 7).ToString();
            textBox6.Text = Math.Round(D1y.Max(), 7).ToString();
            textBox7.Text = Math.Round(D1z.Max(), 7).ToString();
            textBox1.Text = Math.Round(t.en_buyuk(D1x.Max(), D1y.Max(), D1z.Max()), 7).ToString();


            textBox2.Text =m. ambrayses(D1x.Max(), mc4).ToString();
            textBox3.Text =m. ambrayses(D1y.Max(), mc4).ToString();
            textBox4.Text =m. ambrayses(D1z.Max(), mc4).ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            label8.Text = DateTime.Now.ToString();
        }
    }
}
