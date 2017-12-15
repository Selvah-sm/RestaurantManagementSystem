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
    public partial class CHECK_POINT : Form
    {
        String empid;
        public CHECK_POINT(String id)
        {
            InitializeComponent();
            empid = id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_Users MU = new Manage_Users();
            MU.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                    MessageBox.Show("ADMIN ID or Password must not be empty !", "Authorization Failed", MessageBoxButtons.OK);
                else
                {
                    SqlConnection sqlcon = new SqlConnection(@"Data Source=SELVAH\SQLSERVER;Initial Catalog=master;Integrated Security=True;");
                    sqlcon.Open();
                    string type = "Admin";
                    string try1 = "Select * from EmployeeDB where ((LoginType='" + type + "') and (empid='" + this.textBox1.Text + "')and (passcode='" +this.textBox2.Text + "'))";
                    SqlDataAdapter sda = new SqlDataAdapter(try1, sqlcon);
                    DataTable dtc = new DataTable();
                    sda.Fill(dtc);

                    if (dtc.Rows.Count.ToString() == "1")
                    {
                        this.Hide();
                        SqlCommand command = new SqlCommand("DELETE FROM EmployeeDB WHERE empid = @id", sqlcon);
                        command.Parameters.AddWithValue("@id", empid);
                        command.ExecuteNonQuery();
                        sqlcon.Close();

                        MessageBox.Show("Profile Deleted Successfully!", "Successful", MessageBoxButtons.OK);
                        Manage_Users M = new Manage_Users();
                        M.Show();
                    }
                    else
                    {
                        MessageBox.Show("Enter Valid password and user id!", "Authorization Failed", MessageBoxButtons.OK);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error Occured !", "Error", MessageBoxButtons.OK);
            }
        }

        private void CHECK_POINT_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
