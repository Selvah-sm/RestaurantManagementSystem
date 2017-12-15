using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management_and_Billing_Software
{
    public partial class Starter : Form
    {
        public Starter()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developers DV = new Developers();
            DV.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Account_Login AL = new Account_Login();
            AL.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AboutUs AU = new AboutUs();
            AU.Show();
        }
    }
}
