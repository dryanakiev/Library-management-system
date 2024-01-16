using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Utilities
{
    public class DBConnection
    {
        public static SqlConnection connection = new SqlConnection(ProjectProperties.DB_URL);

        public static SqlConnection GetConnection()
        {
            return connection;
        }

        public static void OpenConnection()
        {
            connection.Open();
        }

        public static void CloseConnection()
        {
            connection.Close();
        }
    }
}
