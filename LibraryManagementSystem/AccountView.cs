using LibraryManagementSystem.DAL;
using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.PL
{
    public class AccountView
    {
        public static void Account(string username)
        {
            int userInput;

            Console.Clear();

            Console.WriteLine("-------------------ACCOUNT-------------------");

            
            do
            {
                Console.WriteLine();

                Console.WriteLine("Welcome, what would you like to do?");

                Console.WriteLine("1.View account\n2.View books\n3.View libraries\n4.Update account\n5.Delete account");

                userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        {
                            Console.Clear();

                            User user = ExtractFromDatabase.FindUser(username);

                            Console.WriteLine($"##################{user.Username}##################");

                            Console.WriteLine("Name: " + user.Name);
                            Console.WriteLine("Account email: " + user.Email);

                            break;
                        }
                    case 2:
                        {
                            Console.Clear();

                            List<Book>books = ExtractFromDatabase.ExtractBooks();

                            foreach(Book book in books)
                            {
                                Console.WriteLine($"-------------------{book.Title}-------------------");
                                Console.WriteLine("Author: " + book.Author);
                                Console.WriteLine("Sinopsis: " + book.Description);
                                Console.WriteLine($"-------------------{book.Title}-------------------");
                                Console.WriteLine();
                            }

                            break;
                        }
                    case 3:
                        {
                            Console.Clear();

                            List<Library> libraries = ExtractFromDatabase.ExtractLibraries();

                            foreach (Library library in libraries)
                            {
                                Console.WriteLine($"+++++++++++++++++{library.Name}+++++++++++++++++");
                                Console.WriteLine("Location: " + library.Location);
                                Console.WriteLine();
                            }

                            break;
                        }
                    case 4:
                        {
                            UpdateView.UpdateAccount(username);

                            break;
                        }
                    case 5:
                        {
                            DeleteView.DeleteAccount(username);

                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            } while (true);
        }
    }
}
