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
using System.IO;
using System.Diagnostics;
namespace Hotel_Management_and_Billing_Software
{
    public partial class Billing_Form : Form
    {
        int token,cost,order;
        float billAmount;
        String OrderID;
        public static SqlConnection sqlcon = new SqlConnection(@"Data Source=SELVAH\SQLSERVER;Initial Catalog=master;Integrated Security=True;");
        public Billing_Form(int tok)
        {
            InitializeComponent();
            FillOrderID();
            token = tok;

        }
        public void FillOrderID()
        {
            try
            {
                sqlcon.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from OrderDetails", sqlcon);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                sqlcon.Close();
                order = dt.Rows.Count + 1;
                OrderID = "ORDER " + order.ToString();
                textBox6.Text = OrderID;
            }
            catch
            {
                MessageBox.Show("Error Occured !", "Error", MessageBoxButtons.OK);
            }

        }

        private void itemDetailsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.itemDetailsBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.masterDataSet);
            }
            catch
            {
                MessageBox.Show("Error Occured !", "Error", MessageBoxButtons.OK);
            }

        }

        private void Billing_Form_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'masterDataSet.OrderInstance' table. You can move, or remove it, as needed.
           // this.orderInstanceTableAdapter.Fill(this.masterDataSet.OrderInstance);
            // TODO: This line of code loads data into the 'masterDataSet.itemDetails' table. You can move, or remove it, as needed.
            try
            {
            this.itemDetailsTableAdapter.Fill(this.masterDataSet.itemDetails);
            sqlcon.Open();
            string try1 = "Select * from itemDetails";
            SqlDataAdapter sda = new SqlDataAdapter(try1, sqlcon);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["ItemCode"].ToString());
            }
            sqlcon.Close();
            }
            catch
            {
                MessageBox.Show("Error Occured !", "Error", MessageBoxButtons.OK);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text == "")
                {
                    textBox3.Text = "0";
                }
                cost = Convert.ToInt32(textBox2.Text) * Convert.ToInt32(textBox3.Text);
                textBox4.Text =  cost.ToString();
            }
            catch
            {
                MessageBox.Show("Error Occured !","Error",MessageBoxButtons.OK);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = 0.ToString();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void itemDetailsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        SqlCommand command;
        private void button1_Click(object sender, EventArgs e) 
        {
            if (token == 1)
            {

                this.Hide();
                Staff_Menu SM = new Staff_Menu();
                SM.Show();
            }
            else
            {
                this.Hide();
                ADMIN_MENU AM = new ADMIN_MENU();
                AM.Show();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try{

            sqlcon.Open();
        
            command = new SqlCommand( "Insert into OrderInstance(ItemCode,ItemName,Rate,Quantity,Cost) Values (@str1,@str2,@str3,@str4,@str5)",sqlcon);
            command.Parameters.AddWithValue("@str1", comboBox1.SelectedItem.ToString());
            command.Parameters.AddWithValue("@str2", textBox1.Text);
            command.Parameters.AddWithValue("@str3", Convert.ToInt32(textBox2.Text));
            command.Parameters.AddWithValue("@str4", Convert.ToInt32(textBox3.Text));
            command.Parameters.AddWithValue("@str5", cost.ToString());
            command.ExecuteNonQuery();
            sqlcon.Close();
            FillKart();
            //this.orderInstanceTableAdapter.Fill(this.masterDataSet.OrderInstance);
            
            billAmount += cost;
            textBox5.Text = billAmount.ToString();
            }
            catch
            {
                MessageBox.Show("Error Occured !", "Error", MessageBoxButtons.OK);
            }
            
        }
        public void FillKart()
        {
            try{
            sqlcon.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from OrderInstance", sqlcon);
            DataSet ds = new DataSet();
            sda.Fill(ds, "OrderInstance");
            orderInstanceDataGridView.DataSource = ds;
            orderInstanceDataGridView.DataMember = "OrderInstance";
            sqlcon.Close();
            }
            catch
            {
                MessageBox.Show("Error Occured !", "Error", MessageBoxButtons.OK);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try{
            sqlcon.Open();
            string try1 = "Select * from itemDetails where itemCode = '"+this.comboBox1.SelectedItem.ToString()+"'";
            SqlDataAdapter sda = new SqlDataAdapter(try1, sqlcon);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox1.Text = dr["ItemName"].ToString();
                textBox2.Text = dr["Rate"].ToString();
                textBox3.Text = "1";
                cost= Convert.ToInt32(textBox2.Text) * Convert.ToInt32(textBox3.Text);
                textBox4.Text = cost.ToString();

            }
            sqlcon.Close();
            }
            catch
            {
                MessageBox.Show("Error Occured !", "Error", MessageBoxButtons.OK);
            }
        }

        private void orderInstanceDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    sqlcon.Open();
                    string query = "insert into OrderDetails(OrderID,BillAmount,TimeOfOrder) values ('" + this.textBox6.Text + "', '" + Convert.ToInt32(this.textBox5.Text) + "',CURRENT_TIMESTAMP)";
                    SqlCommand cmd = new SqlCommand(query, sqlcon);
                    cmd.ExecuteNonQuery();
                    sqlcon.Close();
                    MessageBox.Show("Order Placed Successfully !", "Success", MessageBoxButtons.OK);
                    TextWriter writer = new StreamWriter("C:\\Users\\harish\\Desktop\\ " + textBox6.Text + " .txt");
                    writer.WriteLine("");
                    writer.WriteLine("			   KOVAI KARADI KUTTY RESTAURANT");
                    writer.WriteLine("");
                    writer.WriteLine("				'VANGA SAPDALAAM'");
                    writer.WriteLine("				 _______________");
                    writer.WriteLine("");
                    writer.WriteLine("   Item Code        Item Name                 Rate    Quantity     Cost");
                    writer.WriteLine("___________________________________________________________________________");
                    for (int i = 0; i < orderInstanceDataGridView.Rows.Count; i++)
                    {
                        writer.WriteLine("");
                        for (int j = 0; j < orderInstanceDataGridView.Columns.Count; j++)
                        {
                            writer.Write("   " + orderInstanceDataGridView.Rows[i].Cells[j].Value.ToString() + "   " + "|");
                        }
                        writer.WriteLine("");
                        writer.WriteLine("___________________________________________________________________________");

                    }
                    writer.WriteLine("");
                    writer.WriteLine("						     Total Cost :" + billAmount);
                    writer.WriteLine("___________________________________________________________________________");
                    writer.WriteLine(""); writer.WriteLine("");
                    writer.WriteLine("				THANK YOU !"); writer.WriteLine("");
                    writer.WriteLine("			LET'S EAT TOGETHER AGAIN !");
                    writer.Close();
                    print();
                    printOrder();
                }
                catch
                {
                    MessageBox.Show("Error Occured !", "Error", MessageBoxButtons.OK);
                }
            }
            else
                MessageBox.Show("Add item to the list !", "Error", MessageBoxButtons.OK);
        }
        public void print()
        {
            try {
            string location = @"C:\Users\harish\Desktop\ " + textBox6.Text + " .txt";
            ProcessStartInfo info = new ProcessStartInfo(location.Trim());
            info.Verb = "Print";
            info.CreateNoWindow = true;
            info.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(info);
            }
            catch
            {
                MessageBox.Show("Error Occured !", "Error", MessageBoxButtons.OK);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void OrderInstanceBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }
        public void printOrder()
        {
            try{
            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = 0.ToString();
            textBox4.Text = "";
            textBox5.Text = "";
            sqlcon.Open();
            string query = "truncate table OrderInstance";
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            cmd.ExecuteNonQuery();
            sqlcon.Close();
            billAmount = 0;
            cost = 0;
            FillKart();
            FillOrderID();
            }
            catch
            {
                MessageBox.Show("Error Occured !", "Error", MessageBoxButtons.OK);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            printOrder(); 
        }
    }
}
