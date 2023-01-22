using LibraryManagementSystem.DAL;
using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.PL
{
    public class UpdateView
    {
        public static void UpdateAccount(string username)
        {
            string name;
            string email;

            Console.Clear();

            Console.WriteLine("-------------------UPDATE-------------------");

            Console.WriteLine("Please enter all data you wish to update /blank for no change/");

            Console.Write("Name: ");
            name = Console.ReadLine();
            Console.Write("Email: ");
            email= Console.ReadLine();

            User user = ExtractFromDatabase.FindUser(username);

            if(!(name == null)) 
            {
                user.Name= name;
            }
            if(!(email == null))
            {
                user.Email= email;
            }

            SendToDatabase.UpdateAccount(user);
        }
    }
}
