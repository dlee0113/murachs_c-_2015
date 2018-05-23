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
    public partial class frmCustomerMaintenance : Form
    {
        public frmCustomerMaintenance()
        {
            InitializeComponent();
        }

        private Customer customer;

        private void btnGetCustomer_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(txtCustomerID) &&
                Validator.IsInt32(txtCustomerID))
            {
                int customerID = Convert.ToInt32(txtCustomerID.Text);
                this.GetCustomer(customerID);
                if (customer == null)
                {
                    MessageBox.Show("No customer found with this ID. " +
                         "Please try again.", "Customer Not Found");
                    this.ClearControls();
                }
                else
                    this.DisplayCustomer();
            }
        }

        private void GetCustomer(int customerID)
        {
            try
            {
                customer = CustomerDB.GetCustomer(customerID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void ClearControls()
        {
            txtCustomerID.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZipCode.Text = "";
            btnModify.Enabled = false;
            btnDelete.Enabled = false;
            txtCustomerID.Select();
        }

        private void DisplayCustomer()
        {
            txtName.Text = customer.Name;
            txtAddress.Text = customer.Address;
            txtCity.Text = customer.City;
            txtState.Text = customer.State;
            txtZipCode.Text = customer.ZipCode;
            btnModify.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddModifyCustomer addCustomerForm = new frmAddModifyCustomer();
            addCustomerForm.addCustomer = true;
            DialogResult result = addCustomerForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                customer = addCustomerForm.customer;
                txtCustomerID.Text = customer.CustomerID.ToString();
                this.DisplayCustomer();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            frmAddModifyCustomer modifyCustomerForm = new frmAddModifyCustomer();
            modifyCustomerForm.addCustomer = false;
            modifyCustomerForm.customer = customer;
            DialogResult result = modifyCustomerForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                customer = modifyCustomerForm.customer;
                this.DisplayCustomer();
            }
            else if (result == DialogResult.Retry)
            {
                this.GetCustomer(customer.CustomerID);
                if (customer != null)
                    this.DisplayCustomer();
                else
                    this.ClearControls();           
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Delete " + customer.Name + "?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (!CustomerDB.DeleteCustomer(customer))
                    {
                        MessageBox.Show("Another user has updated or deleted " +
                            "that customer.", "Database Error");
                        this.GetCustomer(customer.CustomerID);
                        if (customer != null)
                            this.DisplayCustomer();
                        else
                            this.ClearControls();
                    }
                    else
                        this.ClearControls();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
