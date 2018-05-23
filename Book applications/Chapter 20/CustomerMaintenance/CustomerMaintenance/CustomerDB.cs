using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CustomerMaintenance
{
    public static class CustomerDB
    {
        public static Customer GetCustomer(int customerID)
        {
            SqlConnection connection = MMABooksDB.GetConnection();
            string selectStatement
                = "SELECT CustomerID, Name, Address, City, State, ZipCode "
                + "FROM Customers "
                + "WHERE CustomerID = @CustomerID";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@CustomerID", customerID);

            try
            {
                connection.Open();
                SqlDataReader custReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (custReader.Read())
                {
                    Customer customer = new Customer();
                    customer.CustomerID = (int)custReader["CustomerID"];
                    customer.Name = custReader["Name"].ToString();
                    customer.Address = custReader["Address"].ToString();
                    customer.City = custReader["City"].ToString();
                    customer.State = custReader["State"].ToString();
                    customer.ZipCode = custReader["ZipCode"].ToString();
                    return customer;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static int AddCustomer(Customer customer)
        {
            SqlConnection connection = MMABooksDB.GetConnection();
            string insertStatement =
                "INSERT Customers " +
                "(Name, Address, City, State, ZipCode) " +
                "VALUES (@Name, @Address, @City, @State, @ZipCode)";
            SqlCommand insertCommand =
                new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue(
                "@Name", customer.Name);
            insertCommand.Parameters.AddWithValue(
                "@Address", customer.Address);
            insertCommand.Parameters.AddWithValue(
                "@City", customer.City);
            insertCommand.Parameters.AddWithValue(
                "@State", customer.State);
            insertCommand.Parameters.AddWithValue(
                "@ZipCode", customer.ZipCode);
            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                string selectStatement =
                    "SELECT IDENT_CURRENT('Customers') FROM Customers";
                SqlCommand selectCommand =
                    new SqlCommand(selectStatement, connection);
                int customerID = Convert.ToInt32(selectCommand.ExecuteScalar());
                return customerID;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool UpdateCustomer(Customer oldCustomer, 
            Customer newCustomer)
        {
            SqlConnection connection = MMABooksDB.GetConnection();
            string updateStatement =
                "UPDATE Customers SET " +
                "Name = @NewName, " +
                "Address = @NewAddress, " +
                "City = @NewCity, " +
                "State = @NewState, " +
                "ZipCode = @NewZipCode " +
                "WHERE CustomerID = @oldCustomerID " +
                "AND Name = @OldName " +
                "AND Address = @OldAddress " +
                "AND City = @OldCity " +
                "AND State = @OldState " +
                "AND ZipCode = @OldZipCode";
            SqlCommand updateCommand =
                new SqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue(
                "@NewName", newCustomer.Name);
            updateCommand.Parameters.AddWithValue(
                "@NewAddress", newCustomer.Address);
            updateCommand.Parameters.AddWithValue(
                "@NewCity", newCustomer.City);
            updateCommand.Parameters.AddWithValue(
                "@NewState", newCustomer.State);
            updateCommand.Parameters.AddWithValue(
                "@NewZipCode", newCustomer.ZipCode);
            updateCommand.Parameters.AddWithValue(
                "@OldCustomerID", oldCustomer.CustomerID);
            updateCommand.Parameters.AddWithValue(
                "@OldName", oldCustomer.Name);
            updateCommand.Parameters.AddWithValue(
                "@OldAddress", oldCustomer.Address);
            updateCommand.Parameters.AddWithValue(
                "@OldCity", oldCustomer.City);
            updateCommand.Parameters.AddWithValue(
                "@OldState", oldCustomer.State);
            updateCommand.Parameters.AddWithValue(
                "@OldZipCode", oldCustomer.ZipCode);
            try
            {
                connection.Open();
                int count = updateCommand.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool DeleteCustomer(Customer customer)
        {
            SqlConnection connection = MMABooksDB.GetConnection();
            string deleteStatement =
                "DELETE FROM Customers " +
                "WHERE CustomerID = @CustomerID " +
                "AND Name = @Name " +
                "AND Address = @Address " +
                "AND City = @City " +
                "AND State = @State " +
                "AND ZipCode = @ZipCode";
            SqlCommand deleteCommand =
                new SqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue(
                "@CustomerID", customer.CustomerID);
            deleteCommand.Parameters.AddWithValue(
                "@Name", customer.Name);
            deleteCommand.Parameters.AddWithValue(
                "@Address", customer.Address);
            deleteCommand.Parameters.AddWithValue(
                "@City", customer.City);
            deleteCommand.Parameters.AddWithValue(
                "@State", customer.State);
            deleteCommand.Parameters.AddWithValue(
                "@ZipCode", customer.ZipCode);
            try
            {
                connection.Open();
                int count = deleteCommand.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
