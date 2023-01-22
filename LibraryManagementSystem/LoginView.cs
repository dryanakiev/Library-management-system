using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.BLL;

namespace LibraryManagementSystem.PL
{
    public class LoginView
    {
        public static void LoginMenu()
        {
            string username;
            string password;

            Console.Clear();

            Console.WriteLine("-------------------LOGIN-------------------");

            Console.WriteLine("Welcome, please enter your credentials");

            do
            {
                Console.Write("Username: ");
                username = Console.ReadLine();
                Console.Write("Password: ");
                password = Console.ReadLine();

                if (UserVerification.VerifyAccount(username, password))
                {
                    AccountView.Account(username);
                }
                else
                {
                    Console.WriteLine("Incorrect username or password, please try again...");
                }
            } while(true);
        }
    }
}
