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
    public partial class ADMIN_MENU : Form
    {
        public ADMIN_MENU()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Account_Login AL = new Account_Login();
            AL.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_Users MU = new Manage_Users();
            MU.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            FOOD_DETAILS FD = new FOOD_DETAILS();
            FD.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Billing_Form BF = new Billing_Form(2);
            BF.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Review_Sales RS = new Review_Sales();
            RS.Show();
        }
    }
}
