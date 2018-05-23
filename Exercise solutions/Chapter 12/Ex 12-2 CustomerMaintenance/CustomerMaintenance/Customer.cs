using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerMaintenance
{
    public struct Customer
	{
		private string firstName;
		private string lastName;
		private string email;

		public Customer(string firstName, string lastName, string email)
		{
			this.firstName = firstName;
			this.lastName = lastName;
			this.email = email;
		}

		public string FirstName
		{
			get
			{
				return firstName;
			}
			set
			{
				firstName = value;
			}
		}

		public string LastName
		{
			get
			{
				return lastName;
			}
			set
			{
				lastName = value;
			}
		}

		public string Email
		{
			get
			{
				return email;
			}
			set
			{
				email = value;
			}
		}

		public string GetDisplayText()
		{
			return firstName + " " + lastName + ", " + email;
		}
	}
}
