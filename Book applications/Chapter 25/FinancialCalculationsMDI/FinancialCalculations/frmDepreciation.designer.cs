namespace FinancialCalculations
{
	partial class frmDepreciation
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lstDepreciation = new System.Windows.Forms.ListBox();
            this.cboLife = new System.Windows.Forms.ComboBox();
            this.txtFinalValue = new System.Windows.Forms.TextBox();
            this.txtInitialCost = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClear = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCalculate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(149, 218);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "C&lose";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCalculate.Location = new System.Drawing.Point(62, 218);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 14;
            this.btnCalculate.Text = "&Calculate";
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(17, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "SYD Depreciation:";
            // 
            // lstDepreciation
            // 
            this.lstDepreciation.FormattingEnabled = true;
            this.lstDepreciation.Location = new System.Drawing.Point(17, 133);
            this.lstDepreciation.Name = "lstDepreciation";
            this.lstDepreciation.Size = new System.Drawing.Size(207, 69);
            this.lstDepreciation.TabIndex = 16;
            this.lstDepreciation.TabStop = false;
            // 
            // cboLife
            // 
            this.cboLife.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLife.FormattingEnabled = true;
            this.cboLife.Location = new System.Drawing.Point(137, 84);
            this.cboLife.Name = "cboLife";
            this.cboLife.Size = new System.Drawing.Size(87, 21);
            this.cboLife.TabIndex = 13;
            this.cboLife.Tag = "Life";
            // 
            // txtFinalValue
            // 
            this.txtFinalValue.Location = new System.Drawing.Point(137, 57);
            this.txtFinalValue.Name = "txtFinalValue";
            this.txtFinalValue.Size = new System.Drawing.Size(84, 20);
            this.txtFinalValue.TabIndex = 10;
            this.txtFinalValue.Tag = "Final Value";
            this.toolTip1.SetToolTip(this.txtFinalValue, "Enter the final value of the asset.");
            // 
            // txtInitialCost
            // 
            this.txtInitialCost.Location = new System.Drawing.Point(137, 29);
            this.txtInitialCost.Name = "txtInitialCost";
            this.txtInitialCost.Size = new System.Drawing.Size(84, 20);
            this.txtInitialCost.TabIndex = 8;
            this.txtInitialCost.Tag = "Initial Cost";
            this.toolTip1.SetToolTip(this.txtInitialCost, "Enter the amount it cost to acquire the asset.");
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(17, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Life of Asset in Years:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(17, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Final Value of Asset:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(17, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Initial Cost of Asset:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(236, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuClear,
            this.mnuCalculate});
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            this.actionToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.actionToolStripMenuItem.Text = "&Action";
            // 
            // mnuClear
            // 
            this.mnuClear.Name = "mnuClear";
            this.mnuClear.Size = new System.Drawing.Size(123, 22);
            this.mnuClear.Text = "C&lear";
            this.mnuClear.Click += new System.EventHandler(this.mnuClear_Click);
            // 
            // mnuCalculate
            // 
            this.mnuCalculate.Name = "mnuCalculate";
            this.mnuCalculate.Size = new System.Drawing.Size(123, 22);
            this.mnuCalculate.Text = "&Calculate";
            this.mnuCalculate.Click += new System.EventHandler(this.mnuCalculate_Click);
            // 
            // frmDepreciation
            // 
            this.AcceptButton = this.btnCalculate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(236, 248);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstDepreciation);
            this.Controls.Add(this.cboLife);
            this.Controls.Add(this.txtFinalValue);
            this.Controls.Add(this.txtInitialCost);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.helpProvider1.SetHelpString(this, "Use this form to calculate sum-of-years digits depreciation based on the initial " +
        "cost, final value, and useful life of an asset.");
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmDepreciation";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "SYD Depreciation";
            this.Load += new System.EventHandler(this.frmDepreciation_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnCalculate;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ListBox lstDepreciation;
		private System.Windows.Forms.ComboBox cboLife;
		private System.Windows.Forms.TextBox txtFinalValue;
		private System.Windows.Forms.TextBox txtInitialCost;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mnuClear;
		private System.Windows.Forms.ToolStripMenuItem mnuCalculate;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.HelpProvider helpProvider1;
	}
}