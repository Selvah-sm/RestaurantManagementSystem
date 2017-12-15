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
    public partial class Change_Passcode : Form
    {
        public Change_Passcode()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Staff_Menu SM = new Staff_Menu();
            SM.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
                MessageBox.Show("Staff ID or Password must not be empty !", "Login Error", MessageBoxButtons.OK);
            else
            {
                if (textBox3.Text == "" || textBox4.Text == "")
                    MessageBox.Show("Passcode cannot be empty !", "Error", MessageBoxButtons.OK);
                else
                {
                    if (textBox3.Text == textBox4.Text)
                    {
                        string type = "Staff";
                        SqlConnection sqlcon = new SqlConnection(@"Data Source=SELVAH\SQLSERVER;Initial Catalog=master;Integrated Security=True;");
                        sqlcon.Open();
                        string try1 = "Select * from EmployeeDB where (LoginType='" + type + "') and (empid='" + this.textBox1.Text + "')and (passcode='" + this.textBox2.Text + "')";
                        SqlDataAdapter sda = new SqlDataAdapter(try1, sqlcon);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        if (dt.Rows.Count.ToString() == "1")
                        {
                            SqlCommand cmd = new SqlCommand("update EmployeeDB set Passcode = @str1 where EmpID = @str2", sqlcon);
                            cmd.Parameters.AddWithValue("@str1", textBox3.Text);
                            cmd.Parameters.AddWithValue("@str2", textBox1.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Passcode Updated Successfully!", "Update Success", MessageBoxButtons.OK);
                            this.Hide();
                            Account_Login AL = new Account_Login();
                            AL.Show();
                            }
                        else

                            MessageBox.Show("Enter Valid password and Staff id!", "Login Error", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("New Passcode MisMatched !", "Error", MessageBoxButtons.OK);
                    }
                }
            }

        }
    }
}
