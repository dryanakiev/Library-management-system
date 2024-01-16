using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DAL
{
    public class ExtractFromDatabase
    {
        public static List<User> ExtractUsers()
        {
            return UserRepository.GetAllUsers();
        }
        public static List<Book> ExtractBooks()
        {
            return BookRepository.GetAllBooks();
        }
        public static List<Library> ExtractLibraries()
        {
            return LibraryRepository.GetAllLibraries();
        }

        public static User FindUser(string username)
        {
            List<User> userList = ExtractUsers();

            User user = userList.Find(x => x.Username == username);

            return user;
        }
    }
}
