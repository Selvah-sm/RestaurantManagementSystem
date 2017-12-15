using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
namespace Hotel_Management_and_Billing_Software
{
    public partial class VIEW_USER_DETAILS : Form
    {
        public VIEW_USER_DETAILS()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void VIEW_USER_DETAILS_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'masterDataSet.EmployeeDB' table. You can move, or remove it, as needed.
            try{
            this.employeeDBTableAdapter.Fill(this.masterDataSet.EmployeeDB);
            }
            catch
            {
                MessageBox.Show("Error Occured !", "Error", MessageBoxButtons.OK);
            }
            
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_Users MU = new Manage_Users();
            MU.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try{
            this.employeeDBTableAdapter.Update(this.masterDataSet.EmployeeDB);
            MessageBox.Show("Details Updated Successfully!", "Update Report", MessageBoxButtons.OK);
            }
            catch
            {
                MessageBox.Show("Error Occured !", "Error", MessageBoxButtons.OK);
            }

             
        }
    }
}
