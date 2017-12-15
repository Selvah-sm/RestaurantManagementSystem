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
    public partial class DELETE_FOOD_ITEM : Form
    {
        public DELETE_FOOD_ITEM()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FOOD_DETAILS fd = new FOOD_DETAILS();
            fd.Show();
        }
        String fid;
        private void button1_Click(object sender, EventArgs e)
        {
            fid = textBox1.Text.ToString();
            this.Hide();
            CHECK_POINT_FOR_DELETE_FOOD CP = new CHECK_POINT_FOR_DELETE_FOOD(fid);
            CP.Show();

        }
    }
}
