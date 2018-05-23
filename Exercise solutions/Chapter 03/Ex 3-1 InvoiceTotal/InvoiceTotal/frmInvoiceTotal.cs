using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceTotal
{
    public partial class frmInvoiceTotal : Form
	{
		public frmInvoiceTotal()
		{
			InitializeComponent();
		}

		private void btnCalculate_Click(object sender, EventArgs e)
		{
			decimal invoiceSubtotal = Convert.ToDecimal(txtSubtotal.Text);

			decimal discountPercent = 0m;
			if (invoiceSubtotal >= 500)
			{
				discountPercent = .2m;
			}
			else if (invoiceSubtotal >= 250 && invoiceSubtotal < 500)
			{
				discountPercent = .15m;
			}
			else if (invoiceSubtotal >= 100 && invoiceSubtotal < 250)
			{
				discountPercent = .1m;
			}

			decimal discountAmount = invoiceSubtotal * discountPercent;
			decimal invoiceTotal = invoiceSubtotal - discountAmount;

			txtDiscountPercent.Text = discountPercent.ToString("p1");
			txtDiscountAmount.Text = discountAmount.ToString("c");
			txtTotal.Text = invoiceTotal.ToString("c");

			txtSubtotal.Focus();
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

	}
}