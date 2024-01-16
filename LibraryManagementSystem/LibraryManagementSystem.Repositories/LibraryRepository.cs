using LibraryManagementSystem.Models;
using LibraryManagementSystem.Utilities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Repositories
{
    public class LibraryRepository
    {
        public static List<Library> GetAllLibraries()
        {
            List<Library> libraries = new List<Library>();

            string commandString = "SELECT * FROM Library";

            SqlCommand command = new SqlCommand(commandString, DBConnection.GetConnection());

            DBConnection.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                libraries.Add(MapToLibrary(reader));
            }

            DBConnection.CloseConnection();

            return libraries;
        }

        public static Library GetLibraryById(int libraryId)
        {
            Library library = new Library();

            string commandString = "SELECT * FROM Library" + libraryId;

            SqlCommand command = new SqlCommand(commandString, DBConnection.GetConnection());

            DBConnection.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();

            library = MapToLibrary(reader);

            DBConnection.CloseConnection();

            return library;
        }

        public static void AddLibrary(Library library)
        {
            string commandString = @"INSERT INTO Library(Name,Location) VALUES(@value1,@value2)";

            SqlCommand command = new SqlCommand(commandString, DBConnection.GetConnection());

            command.Parameters.AddWithValue("@value1", library.Name);
            command.Parameters.AddWithValue("@value2", library.Location);

            DBConnection.OpenConnection();

            command.ExecuteNonQuery();

            DBConnection.CloseConnection();
        }

        public static void UpdateLibrary(Library library)
        {
            string commandString = @"UPDATE Library SET Name = @value1, Location = @value2 WHERE Id = @value3";

            SqlCommand command = new SqlCommand(commandString, DBConnection.GetConnection());

            command.Parameters.AddWithValue("@value1", library.Name);
            command.Parameters.AddWithValue("@value2", library.Location);
            command.Parameters.AddWithValue("@value3", library.Id);

            DBConnection.OpenConnection();

            command.ExecuteNonQuery();

            DBConnection.CloseConnection();

        }

        public static void DeleteLibrary(Library library)
        {
            string commandString = @"DELETE FROM Library WHERE Id = @value";

            SqlCommand command = new SqlCommand(commandString, DBConnection.GetConnection());

            command.Parameters.AddWithValue("@value", library.Id);

            DBConnection.OpenConnection();

            command.ExecuteNonQuery();

            DBConnection.CloseConnection();
        }

        public static Library MapToLibrary(SqlDataReader reader)
        {
            Library library = new Library();

            library.Id = int.Parse(reader.GetValue(0).ToString());
            library.Name = reader.GetValue(1).ToString();
            library.Location = reader.GetValue(2).ToString();

            return library;
        }
    }
}
