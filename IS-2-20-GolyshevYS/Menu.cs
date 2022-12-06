using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task1;
using Task2;
using Task3;
using Task4;
using Task5;

namespace IS_2_20_GolyshevYS
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form z1 = new tk1();
                z1.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form z2 = new tk2();
            z2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form z3 = new tk3();
            z3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form z4 = new tk4();
            z4.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form z5 = new tk5();
            z5.ShowDialog();
        }
    }
}
