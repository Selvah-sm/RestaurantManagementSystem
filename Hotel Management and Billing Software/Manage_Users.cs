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
    public partial class Manage_Users : Form
    {
        public Manage_Users()
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ADMIN_MENU AM = new ADMIN_MENU();
            AM.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            VIEW_USER_DETAILS VUD = new VIEW_USER_DETAILS();
            VUD.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ADD_USER AU = new ADD_USER();
            AU.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DELETE_CONFIRMATION DC = new DELETE_CONFIRMATION();
            DC.Show();
        }

        private void Manage_Users_Load(object sender, EventArgs e)
        {

        }
    }
}
