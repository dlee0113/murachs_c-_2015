using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProductMaintenance
{
    public static class ProductDB
    {
        private const string Path = @"..\..\Products.xml";

        public static List<Product> GetProducts()
        {
            // create the list
            List<Product> products = new List<Product>();

            // create the XmlReaderSettings object
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;

            // create the XmlReader object
            XmlReader xmlIn = XmlReader.Create(Path, settings);

            // read past all nodes to the first Product node
            if (xmlIn.ReadToDescendant("Product"))
            {
                // create one Product object for each Product node
                do
                {
                    Product product;
                    xmlIn.ReadStartElement("Product");
                    string type =
                        xmlIn.ReadElementContentAsString();
                    if (type == "Book")
                    {
                        product = ReadBook(xmlIn);
                    }
                    else    // type == "Software"
                    {
                        product = ReadSoftware(xmlIn);
                    }
                    products.Add(product);
                }
                while (xmlIn.ReadToNextSibling("Product"));
            }
            
            // close the XmlReader object
            xmlIn.Close();

            return products;
        }

        private static Book ReadBook(XmlReader xmlIn)
        {
            Book b = new Book();
            ReadBase(xmlIn, b);
            b.Author =
                xmlIn.ReadElementContentAsString();
            return b;
        }

        private static Software ReadSoftware(XmlReader xmlIn)
        {
            Software s = new Software();
            ReadBase(xmlIn, s);
            s.Version =
                xmlIn.ReadElementContentAsString();
            return s;
        }

        private static void ReadBase(XmlReader xmlIn, Product p)
        {
            p.Code =
                xmlIn.ReadElementContentAsString();
            p.Description =
                xmlIn.ReadElementContentAsString();
            p.Price =
                xmlIn.ReadElementContentAsDecimal();
        }

        public static void SaveProducts(List<Product> products)
        {
            // create the XmlWriterSettings object
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");

            // create the XmlWriter object
            XmlWriter xmlOut = XmlWriter.Create(Path, settings);

            // write the start of the document
            xmlOut.WriteStartDocument();
            xmlOut.WriteStartElement("Products");

            // write each product object to the xml file
            foreach (Product product in products)
            {
                if (product.GetType().Name == "Book")
                    WriteBook((Book)product, xmlOut);
                else if (product.GetType().Name == "Software")
                    WriteSoftware((Software)product, xmlOut);
            }

            // write the end tag for the root element
            xmlOut.WriteEndElement();

            // close the xmlWriter object
            xmlOut.Close();
        }
        private static void WriteBook(Book product,
            XmlWriter xmlOut)
        {
            xmlOut.WriteStartElement("Product");
            xmlOut.WriteElementString("Type", "Book");
            WriteBase(product, xmlOut);
            xmlOut.WriteElementString("Author",
                product.Author);
            xmlOut.WriteEndElement();
        }

        private static void WriteSoftware(Software product,
            XmlWriter xmlOut)
        {
            xmlOut.WriteStartElement("Product");
            xmlOut.WriteElementString("Type", "Software");
            WriteBase(product, xmlOut);
            xmlOut.WriteElementString("Version",
                product.Version);
            xmlOut.WriteEndElement();
        }

        private static void WriteBase(Product product,
            XmlWriter xmlOut)
        {
            xmlOut.WriteElementString("Code",
                product.Code);
            xmlOut.WriteElementString("Description",
                product.Description);
            xmlOut.WriteElementString("Price",
                Convert.ToString(product.Price));
        }
    }
}
