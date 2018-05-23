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
        // TODO: Add code that defines the path for the Customers.xml file

		public static void SaveCustomers(List<Customer> customers)
		{
            // TODO: Add code that writes the Customer objects
            // in the List<> to the Customers.xml file
        }

        public static List<Customer> GetCustomers()
        {
            // create the list
            List<Customer> customers = new List<Customer>();

            // TODO: Add code that reads data from the Customers.xml file
            // and stores that data in the List<Customer> object

            return customers;
        }
	}
}
