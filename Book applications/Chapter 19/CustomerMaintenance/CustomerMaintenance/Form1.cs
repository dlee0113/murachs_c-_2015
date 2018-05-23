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
                this.statesTableAdapter.Fill(this.mMABooksDataSet.States);
                stateComboBox.SelectedIndex = -1;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error # " + ex.Number +
                    ": " + ex.Message, ex.GetType().ToString());
            }
        }

        private void fillByCustomerIDToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                int customerID = Convert.ToInt32(
                    customerIDToolStripTextBox.Text);

                this.customersTableAdapter.FillByCustomerID(
                    this.mMABooksDataSet.Customers, customerID);

                if (customersBindingSource.Count == 0)
                    MessageBox.Show("No customer found with this ID. "
                        + "Please try again.", "Customer Not Found");
            }
            catch (FormatException)
            {
                MessageBox.Show("Customer ID must be an integer.",
                    "Entry Error");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error # " + ex.Number +
                    ": " + ex.Message, ex.GetType().ToString());
            }
        }

        private void bindingNavigatorCancelItem_Click(object sender, EventArgs e)
        {
            this.customersBindingSource.CancelEdit();
        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (customersBindingSource.Count > 0)
            {
                if (IsValidData())
                {
                    try
                    {
                        this.customersBindingSource.EndEdit();
                        this.tableAdapterManager.UpdateAll(this.mMABooksDataSet);
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, "Argument Exception");
                        customersBindingSource.CancelEdit();
                    }
                    catch (DBConcurrencyException)
                    {
                        MessageBox.Show("A concurrency error occurred. " +
                            "Some rows were not updated.", "Concurrency Exception");
                        this.customersTableAdapter.Fill(this.mMABooksDataSet.Customers);
                    }
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
            else
            {
                try
                {
                    this.tableAdapterManager.UpdateAll(this.mMABooksDataSet);
                }
                catch (DBConcurrencyException)
                {
                    MessageBox.Show("A concurrency error occurred. " +
                        "Some rows were not updated.", "Concurrency Exception");
                    this.customersTableAdapter.Fill(this.mMABooksDataSet.Customers);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Database error # " + ex.Number +
                        ": " + ex.Message, ex.GetType().ToString());
                }
            }
        }

        public bool IsValidData()
        {
            return
                IsPresent(nameTextBox, "Name") &&
                IsPresent(addressTextBox, "Address") &&
                IsPresent(cityTextBox, "City") &&
                IsPresent(stateComboBox, "State") &&
                IsPresent(zipCodeTextBox, "Zip code");
        }

        public bool IsPresent(Control control, string name)
        {
            if (control.GetType().ToString() == "System.Windows.Forms.TextBox")
            {
                TextBox textBox = (TextBox)control;
                if (textBox.Text == "")
                {
                    MessageBox.Show(name + " is a required field.", "Entry Error");
                    textBox.Focus();
                    return false;
                }
            }
            else if (control.GetType().ToString() == "System.Windows.Forms.ComboBox")
            {
                ComboBox comboBox = (ComboBox)control;
                if (comboBox.SelectedIndex == -1)
                {
                    MessageBox.Show(name + " is a required field.", "Entry Error");
                    comboBox.Focus();
                    return false;
                }
            }
            return true;
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.customersTableAdapter.Fill(this.mMABooksDataSet.Customers);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error # " + ex.Number +
                    ": " + ex.Message, ex.GetType().ToString());
            }
        }
    }
}
