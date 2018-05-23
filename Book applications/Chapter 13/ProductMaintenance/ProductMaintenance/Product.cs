using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMaint
{
    public class Product
	{
		private string code;
		private string description;
		private decimal price;

		public Product()
		{
		}

		public Product(string code, string description, decimal price)
		{
			this.code = code;
			this.description = description;
			this.price = price;
		}


		public string Code
		{
			get
			{
				return code;
			}
			set
			{
				if (value.Length > 4)
					throw new ArgumentException("Maximum length of Code is 4 characters.");
				this.code = value;
			}
		}

		public string Description
		{
			get
			{
				return description;
			}
			set
			{
				this.description = value;
			}
		}

		public decimal Price
		{
			get
			{
				return price;
			}
			set
			{
				this.price = value;
			}
		}

		public string GetDisplayText(string sep)
		{
			return code + sep + price.ToString("c") + sep + description;
		}
	}
}