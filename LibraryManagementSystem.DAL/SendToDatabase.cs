using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DAL
{
    public class SendToDatabase
    {
        public static void UpdateAccount(User user)
        {
            UserRepository.UpdateUser(user);
        }

        public static void DeleteAccount(User user)
        {
            UserRepository.DeleteUser(user);
        }
    }
}
