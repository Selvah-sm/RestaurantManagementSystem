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
    public partial class ADD_NEW_FOOD_ITEM : Form
    {
        public ADD_NEW_FOOD_ITEM()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FOOD_DETAILS FD = new FOOD_DETAILS();
            FD.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlcon = new SqlConnection(@"Data Source=SELVAH\SQLSERVER;Initial Catalog=master;Integrated Security=True;");
                sqlcon.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO ITEMDETAILS (itemCode,itemName,RATE) VALUES (@str1,@str2,@str3)", sqlcon);
                cmd.Parameters.AddWithValue("@str1", textBox1.Text);
                cmd.Parameters.AddWithValue("@str2", textBox2.Text);
                cmd.Parameters.AddWithValue("@str3", Convert.ToInt32(textBox3.Text));
                cmd.ExecuteNonQuery();
                sqlcon.Close();
                MessageBox.Show("Food Item Added Successfully!", "Successful", MessageBoxButtons.OK);
                this.Hide();
                FOOD_DETAILS FD = new FOOD_DETAILS();
                FD.Show();
            }
            catch
            {
                MessageBox.Show("Error Occured !", "Error", MessageBoxButtons.OK);


            }
        }
    }
}
