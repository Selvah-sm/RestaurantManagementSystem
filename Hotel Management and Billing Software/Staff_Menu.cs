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
    public partial class Staff_Menu : Form
    {
        public Staff_Menu()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Account_Login AL = new Account_Login();
            AL.Show();
        }

        

        private void button5_Click_1(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
             ItemDetailsView IDV = new ItemDetailsView();
            IDV.Show();
     
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Change_Passcode CP = new Change_Passcode();
            CP.Show();
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Billing_Form BF = new Billing_Form(1);
            BF.Show();
        }

    }
}
