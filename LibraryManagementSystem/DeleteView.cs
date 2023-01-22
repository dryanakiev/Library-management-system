using LibraryManagementSystem.DAL;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.PL
{
    public class DeleteView
    {
        public static void DeleteAccount(string username)
        {
            string password;

            Console.Clear();

            Console.WriteLine("-------------------DELETE-------------------");

            do
            {
                Console.WriteLine("WARNING: YOU ARE ABOUT TO DELETE THIS ACCOUNT");

                Console.Write("To confirm please enter your password: ");

                password = Console.ReadLine();

                User user = ExtractFromDatabase.FindUser(username);

                if (user.Password == PasswordEncryption.XORCipher(password, user.Salt))
                {
                    SendToDatabase.DeleteAccount(user);

                    LoginView.LoginMenu();
                }
                else
                {
                    Console.WriteLine("Password is incorrect, please try again...");
                }

            }while(true);
        }
    }
}
