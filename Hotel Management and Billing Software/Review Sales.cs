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
    public partial class Review_Sales : Form
    {
        public Review_Sales()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ADMIN_MENU AM = new ADMIN_MENU();
            AM.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=SELVAH\SQLSERVER;Initial Catalog=master;Integrated Security=True;");
            SqlCommand command = new SqlCommand("SELECT BillAmount FROM OrderDetails Where TimeOfOrder BETWEEN @date AND @date2", con);
            command.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);
            command.Parameters.AddWithValue("@date2", dateTimePicker3.Value.Date);

            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int total=0;
            foreach (DataRow dr in dt.Rows)
            {
                total = total + Convert.ToInt32(dr["BillAmount"]); 
               
            }
            textBox1.Text = total.ToString();
             
        }

        private void Review_Sales_Load(object sender, EventArgs e)
        {

        }
    }
}
