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
    public partial class Account_Login : Form
    {
        public Account_Login()
        {
            InitializeComponent();
        }
       

        string type;
        

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            type = "Admin";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
                MessageBox.Show("User ID or Password must not be empty !", "Login Error", MessageBoxButtons.OK);
            else
            {
                if (type == "Staff")
                {
                    SqlConnection sqlcon = new SqlConnection(@"Data Source=SELVAH\SQLSERVER;Initial Catalog=master;Integrated Security=True;");
                    sqlcon.Open();
                    string try1 = "Select * from EmployeeDB where (LoginType='" + type + "') and (empid='" + this.textBox1.Text + "')and (passcode='" + this.textBox2.Text + "')";
                    SqlDataAdapter sda = new SqlDataAdapter(try1, sqlcon);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count.ToString() == "1")
                    {
                        this.Hide();
                        Staff_Menu ss = new Staff_Menu();
                        ss.Show();
                    }
                    else

                        MessageBox.Show("Enter Valid password and user id!", "Login Error", MessageBoxButtons.OK);

                }
                else
                {
                    SqlConnection sqlcon = new SqlConnection(@"Data Source=SELVAH\SQLSERVER;Initial Catalog=master;Integrated Security=True;");
                    sqlcon.Open();
                    string try1 = "Select * from EmployeeDB where (LoginType='" + type + "') and (empid='" + this.textBox1.Text + "')and (passcode='" + this.textBox2.Text + "')";
                    SqlDataAdapter sda = new SqlDataAdapter(try1, sqlcon);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count.ToString() == "1")
                    {
                        this.Hide();
                        ADMIN_MENU ss = new ADMIN_MENU();
                        ss.Show();
                    }
                    else
                    {
                        MessageBox.Show("Enter Valid password and user id!", "Login Error", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            type = "Staff";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
       
    }
}
