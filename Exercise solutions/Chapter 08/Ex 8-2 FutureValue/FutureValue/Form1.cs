using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FutureValue
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // declare the rectangular array and the row index
        string[,] calculationsTable = new string[10, 4];
        int row = 0;

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidData())
                {
                    decimal monthlyInvestment =
                        Convert.ToDecimal(txtMonthlyInvestment.Text);
                    decimal yearlyInterestRate =
                        Convert.ToDecimal(txtInterestRate.Text);
                    int years = Convert.ToInt32(txtYears.Text);

                    int months = years * 12;
                    decimal monthlyInterestRate = yearlyInterestRate / 12 / 100;

                    decimal futureValue = CalculateFutureValue(
                        monthlyInvestment, monthlyInterestRate, months);

                    txtFutureValue.Text = futureValue.ToString("c");
                    txtMonthlyInvestment.Focus();

                    // add the calculation to the rectangular array
                    decimal interestRatePercent = yearlyInterestRate / 100;
                    calculationsTable[row, 0] = monthlyInvestment.ToString("c");
                    calculationsTable[row, 1] = interestRatePercent.ToString("p1");
                    calculationsTable[row, 2] = years.ToString();
                    calculationsTable[row, 3] = futureValue.ToString("c");
                    row++;
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
                // Validate the Monthly Investment text box
                IsPresent(txtMonthlyInvestment, "Monthly Investment") &&
                IsDecimal(txtMonthlyInvestment, "Monthly Investment") &&
                IsWithinRange(txtMonthlyInvestment, "Monthly Investment", 1, 1000) &&

                // Validate the Yearly Interest Rate text box
                IsPresent(txtInterestRate, "Yearly Interest Rate") &&
                IsDecimal(txtInterestRate, "Yearly Interest Rate") &&
                IsWithinRange(txtInterestRate, "Yearly Interest Rate", 1, 20) &&

                // Validate the Number of Years text box
                IsPresent(txtYears, "Number of Years") &&
                IsInt32(txtYears, "Number of Years") &&
                IsWithinRange(txtYears, "Number of Years", 1, 40);
        }

        public bool IsPresent(TextBox textBox, string name)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(name + " is a required field.", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }

        public bool IsDecimal(TextBox textBox, string name)
        {
            decimal number = 0m;
            if (Decimal.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must be a decimal value.", "Entry Error");
                textBox.Focus();
                return false;
            }
        }

        public bool IsInt32(TextBox textBox, string name)
        {
            int number = 0;
            if (Int32.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must be an integer.", "Entry Error");
                textBox.Focus();
                return false;
            }
        }

        public bool IsWithinRange(TextBox textBox, string name,
            decimal min, decimal max)
        {
            decimal number = Convert.ToDecimal(textBox.Text);
            if (number < min || number > max)
            {
                MessageBox.Show(name + " must be between " + min
                    + " and " + max + ".", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }

        private decimal CalculateFutureValue(decimal monthlyInvestment,
           decimal monthlyInterestRate, int months)
        {
            decimal futureValue = 0m;
            for (int i = 0; i < months; i++)
            {
                futureValue = (futureValue + monthlyInvestment)
                    * (1 + monthlyInterestRate);
            }

            return futureValue;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // display the rectangular array in a dialog box
            string message = "Inv/Mo.\tRate\tYears\tFuture Value\n";
            for (int i = 0; i < calculationsTable.GetLength(0); i++)
            {
                if (calculationsTable[i, 0] != null)
                {
                    for (int j = 0; j < calculationsTable.GetLength(1); j++)
                    {
                        message += calculationsTable[i, j] + "\t";
                    }
                    message += "\n";
                }
            }
            MessageBox.Show(message, "Future Value Calculations");
            
            this.Close();
        }

    }
}