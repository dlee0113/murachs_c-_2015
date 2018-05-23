using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomerInvoices.MMABooksDataSetTableAdapters;

namespace CustomerInvoices
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MMABooksDataSet mmaBooksDataSet = new MMABooksDataSet();
        InvoicesTableAdapter invoicesTableAdapter = new InvoicesTableAdapter();
        CustomersTableAdapter customersTableAdapter = new CustomersTableAdapter();

        private void Form1_Load(object sender, EventArgs e)
        {
            invoicesTableAdapter.Fill(mmaBooksDataSet.Invoices);
            customersTableAdapter.Fill(mmaBooksDataSet.Customers);

            var invoices = from invoice in mmaBooksDataSet.Invoices
                           join customer in mmaBooksDataSet.Customers
                           on invoice.CustomerID equals customer.CustomerID
                           orderby customer.Name, invoice.InvoiceTotal descending
                           select new
                           {
                               customer.Name,
                               invoice.InvoiceID,
                               invoice.InvoiceDate,
                               invoice.InvoiceTotal
                           };

            string customerName = "";
            int i = 0;
            foreach (var invoice in invoices)
            {
                if (invoice.Name != customerName)
                {
                    lvInvoices.Items.Add(invoice.Name);
                    customerName = invoice.Name;
                }
                else
                {
                    lvInvoices.Items.Add("");
                }
                lvInvoices.Items[i].SubItems.Add(invoice.InvoiceID.ToString());
                lvInvoices.Items[i].SubItems.Add(
                    Convert.ToDateTime(invoice.InvoiceDate).ToShortDateString());
                lvInvoices.Items[i].SubItems.Add(invoice.InvoiceTotal.ToString("c"));
                i += 1;
            }
        }
    }
}
