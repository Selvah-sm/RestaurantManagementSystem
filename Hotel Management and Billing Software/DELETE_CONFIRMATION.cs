using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hotel_Management_and_Billing_Software
{
    public partial class DELETE_CONFIRMATION : Form
    {
        public DELETE_CONFIRMATION()
        {
            InitializeComponent();
        }
 
        String eid;
        private void button1_Click(object sender, EventArgs e)
        {
            eid = textBox1.Text.ToString();
            this.Hide();
            CHECK_POINT CP = new CHECK_POINT(eid);
            CP.Show();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_Users MU = new Manage_Users();
            MU.Show();
        }
        private void DELETE_CONFIRMATION_Load(object sender, EventArgs e)
        {

        }
    }
}
