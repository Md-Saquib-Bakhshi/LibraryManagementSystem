using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class ProfilePage
    {
        public void Profile()
        {
            {
                Console.WriteLine("\n-------MyProfile Details-------\n");
                if(DataStorage.currUser.IsLibrarian)
                {
                    Console.WriteLine($"Hello, Librarian({DataStorage.currUser.UserName})");
                }
                else
                {
                    Console.WriteLine($"Hello, User({DataStorage.currUser.UserName})");
                }
                Console.WriteLine($"\nFullName: {DataStorage.currUser.FirstName} {DataStorage.currUser.LastName}\nUsername: {DataStorage.currUser.UserName}\nEmail: {DataStorage.currUser.Email}\n");
                Console.WriteLine("--------------------------");
            }
        }
    }
}
