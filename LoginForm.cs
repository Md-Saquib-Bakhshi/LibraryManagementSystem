using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class LoginForm
    {
        //public static Registration currUser = null;
        public void Login()
        {
            if (DataStorage.currUser != null)
            {
                Console.WriteLine($"\n!!!{DataStorage.currUser.UserName} is already login, logout first!!!");
                return;
            }
            Console.WriteLine("******* Login Form *******");
            Console.WriteLine();

            //Taking Inputs
            Console.Write("Enter UserName: ");
            string userName = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("***************************");
            //Validation
            try
            {
                if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
                {
                    throw new ArgumentException("!!!All fields are required*!!!");
                }

                Registration user = Registration.ValidateUser(userName, password);
                if (user != null)
                {
                    DataStorage.currUser = user;
                    Console.WriteLine($"\nLogin successfull {DataStorage.currUser.UserName}.");

                    //Librarian Menu
                    if (DataStorage.currUser.IsLibrarian)
                    {
                        Console.WriteLine("\n*******Librarian Menu*******");
                        LibrarianMenu librarianMenu = new LibrarianMenu();
                        librarianMenu.Menu();
                        Console.WriteLine("********************************");
                    }
                    //User Menu
                    else
                    {
                        Console.WriteLine("\n*******User Menu*******");
                        UserMenu userMenu = new UserMenu();
                        userMenu.Menu();
                        Console.WriteLine("********************************");
                    }
                }
                else
                {
                    Console.WriteLine("\n!!!Incorrect username and password!!!");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"\nArgumentException: {e.Message}");
            }
        }

        public static void Logout()
        {
            if (DataStorage.currUser != null)
            {
                Console.WriteLine($"\nlogout successful {DataStorage.currUser.UserName}.");
                DataStorage.currUser = null;
            }
            else
            {
                Console.WriteLine("\n!!!Already no login!!!");
            }
        }
    }
}
