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
    public partial class CHECK_POINT_FOR_DELETE_FOOD : Form
    {
        String empid;
        public CHECK_POINT_FOR_DELETE_FOOD(String id)
        {
            InitializeComponent();
            empid=id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
             if (textBox1.Text == "" || textBox2.Text == "")
                MessageBox.Show("ADMIN ID or Password must not be empty !", "Authorization Failed", MessageBoxButtons.OK);
            else
            {
                SqlConnection sqlcon = new SqlConnection(@"Data Source=SELVAH\SQLSERVER;Initial Catalog=master;Integrated Security=True;");
                sqlcon.Open();
                string type = "Admin";
                string try1 = "Select * from EmployeeDB where ((LoginType='" + type + "') and (empid='" + this.textBox1.Text + "')and (passcode='" + this.textBox2.Text + "'))";
                SqlDataAdapter sda = new SqlDataAdapter(try1, sqlcon);
                DataTable dtc = new DataTable();
                sda.Fill(dtc);

                if (dtc.Rows.Count.ToString() == "1")
                {
                    this.Hide();
                    SqlCommand command = new SqlCommand("DELETE FROM ItemDetails WHERE ItemCode = @id", sqlcon);
                    command.Parameters.AddWithValue("@id", empid);
                    command.ExecuteNonQuery();
                    sqlcon.Close();
           
                    MessageBox.Show("Food Item Deleted Successfully!", "Successful", MessageBoxButtons.OK);
                    FOOD_DETAILS M = new FOOD_DETAILS();
                    M.Show();      
                }
                else
                {
                    MessageBox.Show("Enter Valid password and user id!", "Authorization Failed", MessageBoxButtons.OK);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FOOD_DETAILS FD = new FOOD_DETAILS();
            FD.Show();
        }
    }
}
