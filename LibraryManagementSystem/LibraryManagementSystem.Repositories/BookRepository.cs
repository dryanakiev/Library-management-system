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
    public class BookRepository
    {
        public static List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();

            string commandString = "SELECT * FROM Book";

            SqlCommand command = new SqlCommand(commandString, DBConnection.GetConnection());

            DBConnection.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                books.Add(MapToBook(reader));
            }

            DBConnection.CloseConnection();

            return books;
        }

        public static Book GetBookById(int bookId)
        {
            Book book = new Book();

            string commandString = "SELECT * FROM Book" + bookId;

            SqlCommand command = new SqlCommand(commandString, DBConnection.GetConnection());

            DBConnection.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();

            book = MapToBook(reader);

            DBConnection.CloseConnection();

            return book;
        }

        public static void AddBook(Book book)
        {
            string commandString = @"INSERT INTO Book(Title,Author,Description) VALUES(@value1,@value2,@value3)";

            SqlCommand command = new SqlCommand(commandString, DBConnection.GetConnection());

            command.Parameters.AddWithValue("@value1", book.Title);
            command.Parameters.AddWithValue("@value2", book.Author);
            command.Parameters.AddWithValue("@value3", book.Description);

            DBConnection.OpenConnection();

            command.ExecuteNonQuery();

            DBConnection.CloseConnection();
        }

        public static void UpdateBook(Book book)
        {
            string commandString = @"UPDATE Book SET Title = @value1, Author = @value2, Description = @value3 WHERE Id = @value4";

            SqlCommand command = new SqlCommand(commandString, DBConnection.GetConnection());

            command.Parameters.AddWithValue("@value1", book.Title);
            command.Parameters.AddWithValue("@value2", book.Author);
            command.Parameters.AddWithValue("@value3", book.Description);
            command.Parameters.AddWithValue("@value3", book.Id);

            DBConnection.OpenConnection();

            command.ExecuteNonQuery();

            DBConnection.CloseConnection();

        }

        public static void DeleteBook(Book book)
        {
            string commandString = @"DELETE FROM Book WHERE Id = @value";

            SqlCommand command = new SqlCommand(commandString, DBConnection.GetConnection());

            command.Parameters.AddWithValue("@value", book.Id);

            DBConnection.OpenConnection();

            command.ExecuteNonQuery();

            DBConnection.CloseConnection();
        }

        public static Book MapToBook(SqlDataReader reader)
        {
            Book book = new Book();

            book.Id = int.Parse(reader.GetValue(0).ToString());
            book.Title = reader.GetValue(1).ToString();
            book.Author = reader.GetValue(2).ToString();
            book.Description = reader.GetValue(3).ToString();

            return book;
        }
    }
}
