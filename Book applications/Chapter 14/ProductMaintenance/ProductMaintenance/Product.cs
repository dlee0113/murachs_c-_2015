using System;

namespace ProductMaintenance
{
    public class Product
	{
		private string code;
		private string description;
		private decimal price;

        public Product()
        {
        }

        public Product(string Code, string Description, decimal Price)
        {
            this.Code = Code;
            this.Description = Description;
            this.Price = Price;
        }

		public string Code
		{
			get
			{
				return code;
			}
			set
			{
				code = value;
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
				description = value;
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
				price = value;
			}
		}

		public virtual string  GetDisplayText(string sep) =>
			 Code + sep + Price.ToString("c") + sep + Description;

	}


}
