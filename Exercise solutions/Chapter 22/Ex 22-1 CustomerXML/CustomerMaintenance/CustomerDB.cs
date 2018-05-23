using System;
using System.Collections.Generic;
using System.Xml;

namespace CustomerMaintenance
{
    /// <summary>
    /// CustomerDB class
    /// </summary>
    public static class CustomerDB
	{
        private const string path = @"C:\C# 2015\Files\Customers.xml";

		public static void SaveCustomers(List<Customer> customers)
		{
            // create the XmlWriterSettings object
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");

            // create the XmlWriter object
            XmlWriter xmlOut = XmlWriter.Create(path, settings);

            // write the start of the document
            xmlOut.WriteStartDocument();
            xmlOut.WriteStartElement("Customers");

            // write each Customer object to the xml file
            foreach (Customer c in customers)
            {
                xmlOut.WriteStartElement("Customer");
                xmlOut.WriteElementString("FirstName",
                    c.FirstName);
                xmlOut.WriteElementString("LastName",
                    c.LastName);
                xmlOut.WriteElementString("Email",
                    c.Email);
                xmlOut.WriteEndElement();
            }

            // write the end tag for the root element
            xmlOut.WriteEndElement();

            // close the XmlWriter object
            xmlOut.Close();
        }

        public static List<Customer> GetCustomers()
        {
            // create the list
            List<Customer> customers = new List<Customer>();

            // create the XmlReaderSettings object
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;

            // create the XmlReader object
            XmlReader xmlIn = XmlReader.Create(path, settings);

            // read past all nodes to the first Customer node
            xmlIn.ReadToDescendant("Customer");

            // create one Customer object for each Customer node
            do
            {
                Customer c = new Customer();
                xmlIn.ReadStartElement("Customer");
                c.FirstName =
                    xmlIn.ReadElementContentAsString();
                c.LastName =
                    xmlIn.ReadElementContentAsString();
                c.Email =
                    xmlIn.ReadElementContentAsString();
                customers.Add(c);
            }
            while (xmlIn.ReadToNextSibling("Customer"));

            // close the XmlReader object
            xmlIn.Close();

            return customers;
        }
	}
}
