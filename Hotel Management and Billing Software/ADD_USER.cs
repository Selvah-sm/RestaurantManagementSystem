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
    public partial class ADD_USER : Form
    {
        //ADD_USER AU = new ADD_USER();
        public ADD_USER()
        {
            InitializeComponent();
        }
         
        string gender;
        private void ADD_USER_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_Users MU = new Manage_Users();
            MU.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlcon = new SqlConnection(@"Data Source=SELVAH\SQLSERVER;Initial Catalog=master;Integrated Security=True;");
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand("insert into EmployeeDB ( LoginType, EmpID, Name, Date_Of_Joining, Gender,Contact_No, AddressInfo, Passcode) values (@str0,@str1,@str2,@str3,@str4,@str5,@str6,@str7)", sqlcon);
                cmd.Parameters.AddWithValue("@str0", comboBox1.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@str1", textBox1.Text);
                cmd.Parameters.AddWithValue("@str2", textBox2.Text);
                cmd.Parameters.AddWithValue("@str3", textBox3.Text);
                cmd.Parameters.AddWithValue("@str4", gender);
                cmd.Parameters.AddWithValue("@str5", textBox4.Text);
                cmd.Parameters.AddWithValue("@str6", textBox6.Text);
                cmd.Parameters.AddWithValue("@str7", textBox5.Text);
                cmd.ExecuteNonQuery();
                this.Hide();
                MessageBox.Show("Profile Created Successfully!", "Successful", MessageBoxButtons.OK);
                Manage_Users MU = new Manage_Users();
                MU.Show();
            }
            catch
            {
                MessageBox.Show("Error Occured !", "Error", MessageBoxButtons.OK);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
        }
    }
}
