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

namespace CustomerInvoiceDisplay
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void fillByCustomerIDToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                int customerID = Convert.ToInt32(
                    customerIDToolStripTextBox.Text);

                this.customersTableAdapter.FillByCustomerID(
                    this.mMABooksDataSet.Customers, customerID);

                if (customersBindingSource.Count > 0)
                    this.invoicesTableAdapter.FillByCustomerID(
                        this.mMABooksDataSet.Invoices, customerID);
                else
                    MessageBox.Show("No customer found with this ID. "
                        + "Please try again.", "Customer Not Found");
            }
            catch (FormatException)
            {
                MessageBox.Show("Customer ID must be an integer.", "Entry Error");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error # " + ex.Number +
                    ": " + ex.Message, ex.GetType().ToString());
            }
        }

    }
}
