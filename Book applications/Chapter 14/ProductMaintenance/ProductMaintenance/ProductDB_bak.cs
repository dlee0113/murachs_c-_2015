using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ProductMaint
{
    // This application is described in chapter 14 of
    // "Murach's C# 2005" by Joel Murach
    // (c) 2006 by Mike Murach & Associates, Inc. 
    // www.murach.com

    public static class ProductDB
	{
		private const string Path = @"..\..\Products.xml";

		public static List<Product> GetProducts()
		{
            List<Product> products = new List<Product>();

            XmlTextReader xmlIn = new XmlTextReader(Path);
            xmlIn.WhitespaceHandling = WhitespaceHandling.None;

            while (xmlIn.Name != "Product")
                xmlIn.Read();
            while (xmlIn.Name == "Product")
            {
                Product product = new Product();

                xmlIn.ReadStartElement("Product");
                product.Code =
                    xmlIn.ReadElementString("Code");
                product.Description =
                    xmlIn.ReadElementString("Description");
                product.Price = Convert.ToDecimal(
                    xmlIn.ReadElementString("Price"));

                xmlIn.Read();
                xmlIn.Read();
                string nodeName = xmlIn.Name;
                if (nodeName == "Author")
                {
                    Book b = new Book();
                    b.Code = product.Code;
                    b.Description = product.Description;
                    b.Price = product.Price;
                    //xmlIn.Read();
                    //xmlIn.Read();
                    string author = xmlIn.ReadContentAsString();
                    b.Author = author;
                    xmlIn.Read();
                    product = b;
                }

                xmlIn.ReadEndElement();

                products.Add(product);
            }
            xmlIn.Close();
            return products;
        }

        public static void SaveProducts(List<Product> products)
		{
            // create the xmlOut object
            XmlTextWriter xmlOut = new XmlTextWriter(
                Path, System.Text.Encoding.UTF8);
            xmlOut.Formatting = Formatting.Indented;

            // write the start of the document
            xmlOut.WriteStartDocument();
            xmlOut.WriteStartElement("Products");

            // write each product
            Product product = null;
            for (int i = 0; i < products.Count; i++)
            {
                product = (Product)products[i];
                xmlOut.WriteStartElement("Product");
                xmlOut.WriteElementString("Code",
                    product.Code);
                xmlOut.WriteElementString("Description",
                    product.Description);
                xmlOut.WriteElementString("Price",
                    Convert.ToString(product.Price));
                xmlOut.WriteEndElement();
            }

            // write the end of the document
            xmlOut.WriteEndElement();
            xmlOut.WriteEndDocument();

            // close the xmlOut object
            xmlOut.Close();
        }

		public static Product GetProduct(string code)
		{
			List<Product> products = ProductDB.GetProducts();
			for (int i = 0; i < products.Count; i++)
			{
				Product p = (Product)products[i];
				if (p.Code == code)
					return p;
			}
			return null;
		}
	}
}
