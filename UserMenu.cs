using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class UserMenu
    {
        public void Menu()
        {
            try
            {
                while (true)
                {
                    Console.Write("\nEnter\n 1 for ManageBook\n 2 for ManageProfile\n 3 for MainMenu: ");
                    if (!int.TryParse(Console.ReadLine(), out int choice))
                    {
                        throw new FormatException("!!!Choice must be an integer value!!!");
                    }
                    Console.WriteLine();
                    switch (choice)
                    {
                        case 1:
                            UserAddBook userAddBook = new UserAddBook();
                            userAddBook.UserBook();
                            break;
                        case 2:
                            ProfilePage profilePage = new ProfilePage();
                            profilePage.Profile();
                            break;
                        case 3:
                            return;
                        default:
                            Console.WriteLine("!!!Invalid Choice!!!");
                            break;
                    }
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine($"FormatException: {e.Message}");
            }
        }
    }
}
