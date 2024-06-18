using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class Input
    {
        public void Menu()
        {
            try
            {
                while (true)
                {
                    Console.Write("\nEnter\n 1 for Signup\n 2 for Login\n 3 for Logout\n 4 for exit: ");
                    if (!int.TryParse(Console.ReadLine(), out int choice))
                    {
                        throw new FormatException("!!!Choice must be an integer value!!!");
                    }
                    Console.WriteLine();
                    switch (choice)
                    {
                        case 1:
                            SignupForm signupForm = new SignupForm();
                            signupForm.Signup();
                            break;
                        case 2:
                            LoginForm loginForm = new LoginForm();
                            loginForm.Login();
                            break;
                        case 3:
                            LoginForm.Logout();
                            break;
                        case 4:
                            Console.WriteLine("Library Management System exits...");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("!!!Invalid Choice");
                            break;
                    }
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine($"FormatException: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"UnhandledException: {e.Message}");
            }
        }
    }
}
