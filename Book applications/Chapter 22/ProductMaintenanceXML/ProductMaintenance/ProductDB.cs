using System;
using System.Xml;
using System.Collections.Generic;

namespace ProductMaintenance
{
    public class ProductDB
    {
        //private const string path = @"C:\C# 2015\Files\Products.xml";
        private const string path = @"..\..\Products.xml";  // this uses the project file

        public static List<Product> GetProducts()
        {
            // create the list
            List<Product> products = new List<Product>();

            // create the XmlReaderSettings object
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;

            // create the XmlReader object
            XmlReader xmlIn = XmlReader.Create(path, settings);

            // read past all nodes to the first Product node
            if (xmlIn.ReadToDescendant("Product"))
            {
                // create one Product object for each Product node
                do
                {
                    Product product = new Product();
                    product.Code = xmlIn["Code"];
                    xmlIn.ReadStartElement("Product");
                    product.Description = 
                        xmlIn.ReadElementContentAsString();
                    product.Price = 
                        xmlIn.ReadElementContentAsDecimal();
                    products.Add(product);
                }
                while(xmlIn.ReadToNextSibling("Product"));
            }

            // close the XmlReader object
            xmlIn.Close();

            return products;
        }

        public static void SaveProducts(List<Product> products)
        {
            // create the XmlWriterSettings object
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");

            // create the XmlWriter object
            XmlWriter xmlOut = XmlWriter.Create(path, settings);
            
            // write the start of the document
            xmlOut.WriteStartDocument();
            xmlOut.WriteStartElement("Products");

            // write each Product object to the xml file
            foreach (Product product in products)
            {
                xmlOut.WriteStartElement("Product");
                xmlOut.WriteAttributeString("Code", 
                    product.Code);
                xmlOut.WriteElementString("Description", 
                    product.Description);
                xmlOut.WriteElementString("Price", 
                    Convert.ToString(product.Price));
                xmlOut.WriteEndElement();
            }

            // write the end tag for the root element
            xmlOut.WriteEndElement();

            // close the XmlWriter object
            xmlOut.Close();
        }
    }
}
