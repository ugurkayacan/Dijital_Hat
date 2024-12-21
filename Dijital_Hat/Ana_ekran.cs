using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Dijital_Hat
{
    public partial class Ana_ekran : Form
    {
        public double ac0;
        public double ac1;
        public double ac2;
        public double ac3;
        public double ac4;
        public double ac5;
        public double ac6;
        public double ac7;
        public double ac8;
        public double ac9;







        public Ana_ekran()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            takip_et t = new takip_et(); 
            this.Hide();
            t.ShowDialog();
           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Ana_ekran_Load(object sender, EventArgs e)
        {
           
        }
    }
}
