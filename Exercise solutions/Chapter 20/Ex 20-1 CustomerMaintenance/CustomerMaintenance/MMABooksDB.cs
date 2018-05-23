using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CustomerMaintenance
{
    class MMABooksDB
    {
        public static SqlConnection GetConnection()
        {
            string connectionString =
                "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\MMABooks.mdf;" +
                "Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
