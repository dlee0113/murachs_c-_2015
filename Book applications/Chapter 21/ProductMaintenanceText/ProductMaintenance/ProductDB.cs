using System;
using System.IO;
using System.Collections.Generic;

namespace ProductMaintenance
{
    public static class ProductDB
	{
		private const string dir = @"C:\C# 2015\Files\";
		private const string path = dir + "Products.txt";

		public static List<Product> GetProducts()
		{
			// if the directory doesn't exist, create it
			if (!Directory.Exists(dir))
				Directory.CreateDirectory(dir);

			// create the object for the input stream for a text file
			StreamReader textIn = 
				new StreamReader(
				new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read));

			// create the list
			List<Product> products = new List<Product>();

			// read the data from the file and store it in the list
			while (textIn.Peek() != -1)
			{
				string row = textIn.ReadLine();
				string[] columns = row.Split('|');
				Product product = new Product();
				product.Code = columns[0];
				product.Description = columns[1];
				product.Price = Convert.ToDecimal(columns[2]);
				products.Add(product);
			}

			// close the input stream for the text file
			textIn.Close();

			return products;
		}

		public static void SaveProducts(List<Product> products)
		{
			// create the output stream for a text file that exists
			StreamWriter textOut = 
				new StreamWriter(
				new FileStream(path, FileMode.Create, FileAccess.Write));

			// write each product
			foreach (Product product in products)
			{
				textOut.Write(product.Code + "|");
				textOut.Write(product.Description + "|");
				textOut.WriteLine(product.Price);
			}

			// close the output stream for the text file
			textOut.Close();
	   }
	}
}
