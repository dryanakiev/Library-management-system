using LibraryManagementSystem.Models;
using LibraryManagementSystem.Utilities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Repositories
{
    public class UserRepository
    {
        public static List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            string commandString = "SELECT * FROM [User]";

            SqlCommand command= new SqlCommand(commandString,DBConnection.GetConnection());

            DBConnection.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                users.Add(MapToUser(reader));
            }

            DBConnection.CloseConnection();

            return users;
        }

        public static User GetUserById(int userId)
        {
            User user = new User();

            string commandString = "SELECT * FROM [User]" + userId;

            SqlCommand command = new SqlCommand(commandString, DBConnection.GetConnection());

            DBConnection.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();

            user = MapToUser(reader);

            DBConnection.CloseConnection();

            return user;
        }

        public static void AddUser(User user)
        {
            string commandString = @"INSERT INTO [User](Username,Password,Name,Email) VALUES(@value1,@value2,@value3,@value4)";

            SqlCommand command = new SqlCommand(commandString, DBConnection.GetConnection());

            command.Parameters.AddWithValue("@value1",user.Username);
            command.Parameters.AddWithValue("@value2",user.Password);
            command.Parameters.AddWithValue("@value3",user.Name);
            command.Parameters.AddWithValue("@value4",user.Email);

            DBConnection.OpenConnection();

            command.ExecuteNonQuery();

            DBConnection.CloseConnection();
        }

        public static void UpdateUser(User user)
        {
            string commandString = @"UPDATE [User] SET Username = @value1, Password = @value2, Name = @value3, Email = @value4 WHERE Id = @value5";

            SqlCommand command = new SqlCommand(commandString,DBConnection.GetConnection());

            command.Parameters.AddWithValue("@value1", user.Username);
            command.Parameters.AddWithValue("@value2", user.Password);
            command.Parameters.AddWithValue("@value3", user.Name);
            command.Parameters.AddWithValue("@value4", user.Email);
            command.Parameters.AddWithValue("@value5", user.Id);

            DBConnection.OpenConnection();

            command.ExecuteNonQuery();

            DBConnection.CloseConnection();

        }

        public static void DeleteUser(User user) 
        {
            string commandString = @"DELETE FROM [User] WHERE Id = @value";

            SqlCommand command = new SqlCommand(commandString, DBConnection.GetConnection());

            command.Parameters.AddWithValue("@value", user.Id);

            DBConnection.OpenConnection();

            command.ExecuteNonQuery();

            DBConnection.CloseConnection();
        }

        public static User MapToUser(SqlDataReader reader)
        {
            User user = new User();

            user.Id = int.Parse(reader.GetValue(0).ToString());
            user.Username = reader.GetValue(1).ToString();
            user.Password = reader.GetValue(2).ToString();
            user.Name = reader.GetValue(3).ToString();
            user.Email = reader.GetValue(4).ToString();

            return user;
        }
    }
}
