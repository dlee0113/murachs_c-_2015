using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace FutureValue
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (IsValidData())
                {
                    decimal monthlyInvestment =
                        Decimal.Parse(txtMonthlyInvestment.Text, NumberStyles.Currency);
                    decimal yearlyInterestRate =
                        Decimal.Parse(txtInterestRate.Text, NumberStyles.Number);
                    int years = Int32.Parse(txtYears.Text, NumberStyles.None);

                    int months = years * 12;
                    decimal monthlyInterestRate = yearlyInterestRate / 12 / 100;
                    decimal futureValue = CalculateFutureValue(
                        monthlyInvestment, monthlyInterestRate, months);

                    decimal interestRatePercent = yearlyInterestRate / 100;
                    txtMonthlyInvestment.Text = monthlyInvestment.ToString("c");
                    txtInterestRate.Text = interestRatePercent.ToString("p");
                    txtYears.Text = years.ToString();
                    txtFutureValue.Text = futureValue.ToString("c");

                    txtMonthlyInvestment.Focus();
                }
            }
            catch (OverflowException)
            {
                MessageBox.Show(
                    "An overflow exception has occurred. Please enter smaller values.",
                    "Entry Error");
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
                IsCurrency(txtMonthlyInvestment, "Monthly Investment") &&
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

        // the new IsDecimal method
        public bool IsDecimal(TextBox textBox, string name)
        {
            decimal number = 0m;
            if (Decimal.TryParse(textBox.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out number))
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

        // the new IsCurrency method
        public bool IsCurrency(TextBox textBox, string name)
        {
            decimal number = 0m;
            if (Decimal.TryParse(textBox.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must be in currency format.", "Entry Error");
                textBox.Focus();
                return false;
            }
        }


        // the new IsInt32 method
        public bool IsInt32(TextBox textBox, string name)
        {
            int number = 0;
            if (Int32.TryParse(textBox.Text, NumberStyles.None, CultureInfo.CurrentCulture, out number))
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
            decimal number = Decimal.Parse(textBox.Text, NumberStyles.Currency);
            if (number < min || number > max)
            {
                MessageBox.Show(name + " must be between " + min +
                    " and " + max + ".", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }

        private decimal CalculateFutureValue(decimal monthlyInvestment,
            decimal interestRateMonthly, int months)
        {
            decimal futureValue = 0m;
            for (int i = 0; i < months; i++)
            {
                futureValue = (futureValue + monthlyInvestment)
                    * (1 + interestRateMonthly);
            }
            return futureValue;
        }

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

    }
}