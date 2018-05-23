using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialCalculations
{
    public partial class frmDepreciation : Form
	{
		public frmDepreciation()
		{
			InitializeComponent();
		}

		private void frmDepreciation_Load(object sender, EventArgs e)
		{
			// populate the Life combo box with ints from 1 to 40
			for (int i = 1; i <= 40; i++)
				cboLife.Items.Add(i);
			cboLife.SelectedIndex = -1;
		}

		private void btnCalculate_Click(object sender, EventArgs e)
		{
			try
			{
				if (IsValidData())
				{
					double cost = Convert.ToDouble(txtInitialCost.Text);
					double salvage = Convert.ToDouble(txtFinalValue.Text);
					lstDepreciation.Items.Clear();
					int life = Convert.ToInt32(cboLife.Text);
					double dLife = (double)life;

					for (int i = 1; i <= life; i++)
					{
						double period = (double)i;
						double yearlyAllowance =
							CalculateSYDDepreciation(
							cost, salvage, dLife, period);
						lstDepreciation.Items.Add(
							"Year " + i + ": " + yearlyAllowance.ToString("c"));
					}
                    txtInitialCost.Focus();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\n\n" +
					ex.GetType().ToString() + "\n" +
					ex.StackTrace, "Exception");
			}
		}

		public bool IsValidData()
		{
			return
				// Validate the Initial Cost text box
				Validator.IsPresent(txtInitialCost) &&
				Validator.IsDecimal(txtInitialCost) &&
				Validator.IsWithinRange(txtInitialCost, 500, 1000000) &&

				// Validate the Final Value text box
				Validator.IsPresent(txtFinalValue) &&
				Validator.IsDecimal(txtFinalValue) &&
				Validator.IsWithinRange(txtFinalValue, 0, 10000000);
		}

		private double CalculateSYDDepreciation(double cost,
			double salvage, double life, double period)
		{
			double SYDValue =
				(cost - salvage) * (life - period + 1) * 2 /
				((life) * (life + 1));
			return SYDValue;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void mnuClear_Click(object sender, EventArgs e)
		{
			txtFinalValue.Text = "";
			txtInitialCost.Text = "";
			cboLife.SelectedIndex = -1;
			lstDepreciation.Items.Clear();
		}

		private void mnuCalculate_Click(object sender, EventArgs e)
		{
			btnCalculate.PerformClick();
		}

	}
}