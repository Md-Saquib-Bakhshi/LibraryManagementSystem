using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class LibrarianMenu
    {
        public void Menu()
        {
            try
            {
                while (true)
                {
                    Console.Write("\nEnter\n 1 for ManageBook\n 2 for ManageUser\n 3 for ManageProfile\n 4 for MainMenu: ");
                    if (!int.TryParse(Console.ReadLine(), out int choice))
                    {
                        throw new FormatException("!!!Choice must be an integer value!!!");
                    }
                    Console.WriteLine();
                    switch (choice)
                    {
                        case 1:
                            ManageBook manageBook = new ManageBook();
                            manageBook.ManageBookMenu();
                            break;
                        case 2:
                            //Console.WriteLine("ManageUser");
                            Registration.ViewUser();
                            break;
                        case 3:
                            ProfilePage page = new ProfilePage();
                            page.Profile();
                            break;
                        case 4:
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
