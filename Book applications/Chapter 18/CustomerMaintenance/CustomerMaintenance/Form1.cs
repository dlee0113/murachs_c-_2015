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

namespace CustomerMaintenance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                this.customersTableAdapter.Fill(this.mmaBooksDataSet.Customers);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error # " + ex.Number +
                    ": " + ex.Message, ex.GetType().ToString());
            }
        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            try
            {
                this.customersBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.mmaBooksDataSet);
            }
            // this block catches exceptions such as a value that's beyond 
            // the maximum length for a column in a dataset
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Argument Exception");
                customersBindingSource.CancelEdit();
            }
            catch (DBConcurrencyException)
            {
                MessageBox.Show("A concurrency error occurred. " +
                    "Some rows were not updated.", "Concurrency Exception");
                this.customersTableAdapter.Fill(this.mmaBooksDataSet.Customers);
            }
            // this block catches any ADO.NET errors other than DBConcurrencyException
            catch (DataException ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
                customersBindingSource.CancelEdit();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error # " + ex.Number +
                    ": " + ex.Message, ex.GetType().ToString());
            }
        }
    }
}
