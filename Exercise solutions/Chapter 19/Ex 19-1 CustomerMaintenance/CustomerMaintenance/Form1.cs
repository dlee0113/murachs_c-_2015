using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerMaintenance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.mMABooksDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mMABooksDataSet.States' table. You can move, or remove it, as needed.
            this.statesTableAdapter.Fill(this.mMABooksDataSet.States);
            stateComboBox.SelectedIndex = -1;
            // TODO: This line of code loads data into the 'mMABooksDataSet.Customers' table. You can move, or remove it, as needed.
            // this.customersTableAdapter.Fill(this.mMABooksDataSet.Customers);

        }

        private void fillByCustomerIDToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.customersTableAdapter.FillByCustomerID(this.mMABooksDataSet.Customers, ((int)(System.Convert.ChangeType(customerIDToolStripTextBox.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void cancelToolStripButton_Click(object sender, EventArgs e)
        {
            this.customersBindingSource.CancelEdit();
        }

        private void getAllCustomersToolStripButton_Click(object sender, EventArgs e)
        {
            this.customersTableAdapter.Fill(this.mMABooksDataSet.Customers);
        }

        private void fillByStateToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.customersTableAdapter.FillByState(this.mMABooksDataSet.Customers, stateToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
