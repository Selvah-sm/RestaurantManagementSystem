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
    public partial class FOOD_DETAILS : Form
    {
        public FOOD_DETAILS()
        {
            InitializeComponent();
        }

        private void FOOD_DETAILS_Load(object sender, EventArgs e)
        {

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

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DELETE_FOOD_ITEM DFI = new DELETE_FOOD_ITEM();
            DFI.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            VIEW_FOOD_DETAILS VFD = new VIEW_FOOD_DETAILS();
            VFD.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ADD_NEW_FOOD_ITEM ANFI = new ADD_NEW_FOOD_ITEM();
            ANFI.Show();
        }
    }
}
