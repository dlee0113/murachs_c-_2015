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
    public partial class frmMain : Form
	{
		public frmMain()
		{
			InitializeComponent();
		}

		private void mnuNewFutureValue_Click(object sender, EventArgs e)
		{
			Form newForm = new frmFutureValue();
			newForm.MdiParent = this;
			newForm.Show();
		}

		private void mnuNewDepreciation_Click(object sender, EventArgs e)
		{
			Form newForm = new frmDepreciation();
			newForm.MdiParent = this;
			newForm.Show();
		}

		private void mnuClose_Click(object sender, EventArgs e)
		{
			Form activeForm = this.ActiveMdiChild;
			if (activeForm != null)
				activeForm.Close();
		}

		private void mnuExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void mnuToolbar_Click(object sender, EventArgs e)
		{
			if (mnuToolbar.Checked == true)
			{
				mnuToolbar.Checked = false;
				tlbMain.Visible = false;
			}
			else if (mnuToolbar.Checked == false)
			{
				mnuToolbar.Checked = true;
				tlbMain.Visible = true;
			}

			// another way to code the if-else statement
			/*
			mnuToolbar.Checked = !mnuToolbar.Checked;
			tlbMain.Visible = !tlbMain.Visible;
			*/
		}

		private void mnuCascade_Click(object sender, EventArgs e)
		{
			this.LayoutMdi(MdiLayout.Cascade);
		}

		private void mnuTileVertical_Click(object sender, EventArgs e)
		{
			this.LayoutMdi(MdiLayout.TileVertical);
		}

		private void mnuTileHorizontal_Click(object sender, EventArgs e)
		{
			this.LayoutMdi(MdiLayout.TileHorizontal);
		}

		private void btnFutureValue_Click(object sender, EventArgs e)
		{
			mnuNewFutureValue.PerformClick();
		}

		// NOTE: The Click event for the Depreciation button 
		// in the ToolStrip has been wired to the 
		// mnuNewDepreciation_Click event handler.
		// That's why it isn't shown here.

	}
}