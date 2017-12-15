using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management_and_Billing_Software
{
    public partial class ItemDetailsView : Form
    {
        public ItemDetailsView()
        {
            InitializeComponent();
        }

        private void itemDetailsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try{
            this.Validate();
            this.itemDetailsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.masterDataSet);
            }
            catch
            {
                MessageBox.Show("Error Occured !", "Error", MessageBoxButtons.OK);
            }
        }

        private void ItemDetailsView_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Staff_Menu SM = new Staff_Menu();
            SM.Show();
        }

        private void itemDetailsBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }
    }
}
