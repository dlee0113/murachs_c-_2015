using System;
using System.Xml;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CustomerMaintenance
{
    public class CustomerDB
	{

        private const string Path = @"C:\C# 2015\Files\CustomersX14.xml";

        public static List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;

            XmlReader xmlIn = XmlReader.Create(Path, settings);

            if (xmlIn.ReadToDescendant("Customer"))
            {
                do
                {
                    xmlIn.ReadStartElement("Customer");
                    string type =
                        xmlIn.ReadElementContentAsString(); 
                    if (type == "Wholesale")
                        customers.Add(ReadWholesale(xmlIn));
                    else if (type == "Retail")
                        customers.Add(ReadRetail(xmlIn));
                }
                while (xmlIn.ReadToNextSibling("Customer"));
            }

            xmlIn.Close();
            return customers;
        }

        private static WholesaleCustomer ReadWholesale(XmlReader xmlIn)
        {
            WholesaleCustomer customer = new WholesaleCustomer();
            customer.FirstName = 
                xmlIn.ReadElementContentAsString();
            customer.LastName = 
                xmlIn.ReadElementContentAsString();
            customer.Email = 
                xmlIn.ReadElementContentAsString();
            customer.Company = 
                xmlIn.ReadElementContentAsString();
            return customer;
        }

        private static RetailCustomer ReadRetail(XmlReader xmlIn)
        {
            RetailCustomer customer = new RetailCustomer();        
            customer.FirstName = 
                xmlIn.ReadElementContentAsString();
            customer.LastName = 
                xmlIn.ReadElementContentAsString();
            customer.Email = 
                xmlIn.ReadElementContentAsString();
            customer.HomePhone = 
                xmlIn.ReadElementContentAsString();
            return customer;
        }
        
        public static void SaveCustomers(List<Customer> customers)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");

            XmlWriter xmlOut = XmlWriter.Create(Path, settings);

            xmlOut.WriteStartDocument();
            xmlOut.WriteStartElement("Customers");

            foreach (Customer customer in customers)
            {
                if (customer.GetType().Name == "WholesaleCustomer")
                    WriteWholesale((WholesaleCustomer)customer, xmlOut);
                else if (customer.GetType().Name == "RetailCustomer")
                    WriteRetail((RetailCustomer)customer, xmlOut);
            }
            xmlOut.WriteEndElement();
            xmlOut.Close();
        }

        private static void WriteWholesale(WholesaleCustomer customer, 
            XmlWriter xmlOut)
        {
            xmlOut.WriteStartElement("Customer");
            xmlOut.WriteElementString("Type", "Wholesale");
            xmlOut.WriteElementString("FirstName",
                customer.FirstName);
            xmlOut.WriteElementString("LastName", 
                customer.LastName);
            xmlOut.WriteElementString("Email", 
                customer.Email);
            xmlOut.WriteElementString("Company",
                customer.Company);
            xmlOut.WriteEndElement();
        }

        private static void WriteRetail(RetailCustomer customer,
            XmlWriter xmlOut)
        {
            xmlOut.WriteStartElement("Customer");
            xmlOut.WriteElementString("Type", "Retail"); 
            xmlOut.WriteElementString("FirstName", 
                customer.FirstName);
            xmlOut.WriteElementString("LastName", 
                customer.LastName);
            xmlOut.WriteElementString("Email", 
                customer.Email);
            xmlOut.WriteElementString("HomePhone",
                customer.HomePhone);
            xmlOut.WriteEndElement();
        }
	}
}
