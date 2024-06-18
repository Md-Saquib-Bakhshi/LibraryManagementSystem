using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class SignupForm
    {
        public void Signup()
        {
            if (DataStorage.currUser != null)
            {
                Console.WriteLine($"\n{DataStorage.currUser.UserName} is already log in, logout first!!!");
                return;
            }
            Console.WriteLine("******* Signup Form *******");
            Console.WriteLine();

            //Taking Inputs
            Console.Write("Enter FirstName: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter LastName: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter userName: ");
            string userName = Console.ReadLine();
            Console.Write("Enter email: ");
            string email = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            Console.Write("Are you librarian? (yes/no): ");
            bool isLibrarian = Console.ReadLine().ToLower() == "yes";

            Console.WriteLine();
            Console.WriteLine("***************************");
            //Validation
            try
            {
                if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                {
                    throw new ArgumentException("\n!!!All fields are required*!!!");
                }
                if (!EmailValidator.Validate(email))
                {
                    throw new InvalidEmailException("\n!!!Email format is invalid!!!");
                }
                Registration registration = new Registration(firstName, lastName, userName, email, password, isLibrarian);
                Registration.AddUser(registration);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"ArgumentException: {e.Message}");
            }
            catch (InvalidEmailException e)
            {
                Console.WriteLine($"InvalidEmailException: {e.Message}");
            }
        }
    }
}
