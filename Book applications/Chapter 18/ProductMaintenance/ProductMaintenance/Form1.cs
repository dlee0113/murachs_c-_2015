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

namespace ProductMaintenance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mmaBooksDataSet.Products'
            // table. You can move, or remove it, as needed.
            try
            {
                this.productsTableAdapter.Fill(this.mmaBooksDataSet.Products);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error # " + ex.Number +
                    ": " + ex.Message, ex.GetType().ToString());
            }
        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            try
            {
                this.productsBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.mmaBooksDataSet);
            }
            catch (DBConcurrencyException)
            {
                MessageBox.Show("A concurrency error occurred. " +
                    "Some rows were not updated. ", "Save Error");
                this.productsTableAdapter.Fill(this.mmaBooksDataSet.Products);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Database error # " + ex.Number +
                    ": " + ex.Message, ex.GetType().ToString());
            }
        }

        private void productsDataGridView_DataError(
            object sender, DataGridViewDataErrorEventArgs e)
        {
            int row = e.RowIndex + 1;
            string errorMessage = "A data error occurred.\n" +
                "Row: " + row + "\n" +
                "Error: " + e.Exception.Message;
            MessageBox.Show(errorMessage, "Data Error");
        }
    }
}
