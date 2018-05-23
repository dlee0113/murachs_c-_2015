using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CustomerMaintenance
{
    class StateDB
    {
        public static List<State> GetStates()
        {
            List<State> states = new List<State>();
            SqlConnection connection = MMABooksDB.GetConnection();
            string selectStatement = "SELECT StateCode, StateName "
                                   + "FROM States "
                                   + "ORDER BY StateName";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    State s = new State();
                    s.StateCode = reader["StateCode"].ToString();
                    s.StateName = reader["StateName"].ToString();
                    states.Add(s);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return states;
        }
    }
}
