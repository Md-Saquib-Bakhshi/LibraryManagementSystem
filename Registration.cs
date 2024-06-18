using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class Registration
    {
        private string firstName;
        private string lastName;
        private string userName;
        private string email;
        private string password;
        private bool isLibrarian;
        public List<Book> UserBookCart { get; set; } = new List<Book>();

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public bool IsLibrarian
        {
            get
            {
                return isLibrarian;
            }
            set
            {
                isLibrarian = value;
            }
        }

        public Registration(string firstName, string lastName, string userName, string email, string password, bool isLibrarian = false)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
            Password = password;
            IsLibrarian = isLibrarian;
        }

        //Add User in Storage
        public static void AddUser(Registration registration)
        {
            if (DataStorage.Users.ContainsKey(registration.UserName))
            {
                Console.WriteLine("Users already exists.");
            }
            else
            {
                DataStorage.Users.Add(registration.UserName, registration);
                Console.WriteLine();
                Console.WriteLine("User added successfully.");
            }
        }

        //ValidateUser or login
        public static Registration ValidateUser(string userName, string password)
        {
            if (DataStorage.Users.ContainsKey(userName) && DataStorage.Users[userName].Password == password)
            {
                return DataStorage.Users[userName];
            }
            return null;
        }

        //View User from Storage
        public static void ViewUser()
        {
            foreach(var user in DataStorage.Users)
            {
                Console.WriteLine("\n-------User Details-------\n");
                Console.WriteLine($"\nFullName: {user.Value.firstName} {user.Value.lastName}\nUserName: {user.Value.userName}\nEmail: {user.Value.email}\nIsLibrarian: {user.Value.isLibrarian}\n");
                Console.WriteLine("--------------------------");
            }
        }

        
    }
}
