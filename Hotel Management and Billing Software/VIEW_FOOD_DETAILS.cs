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
using System.Configuration;

namespace Hotel_Management_and_Billing_Software
{
    public partial class VIEW_FOOD_DETAILS : Form
    {
        public VIEW_FOOD_DETAILS()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            FOOD_DETAILS FD = new FOOD_DETAILS();
            FD.Show();
        }

        private void VIEW_FOOD_DETAILS_Load(object sender, EventArgs e)
        {
            try{
            // TODO: This line of code loads data into the 'masterDataSet.itemDetails' table. You can move, or remove it, as needed.
            this.itemDetailsTableAdapter.Fill(this.masterDataSet.itemDetails);
            }
            catch
            {
                MessageBox.Show("Error Occured !", "Error", MessageBoxButtons.OK);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try{
            this.itemDetailsTableAdapter.Update(this.masterDataSet.itemDetails);
            MessageBox.Show("Details Updated Successfully!", "Update Report", MessageBoxButtons.OK);
            }
            catch
            {
                MessageBox.Show("Error Occured !", "Error", MessageBoxButtons.OK);
            }
        }


    }
}
