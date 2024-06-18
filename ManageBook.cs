using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class ManageBook
    {
        public void ManageBookMenu()
        {
            try
            {
                while (true)
                {
                    Console.Write("\nEnter\n 1 for AddBook\n 2 for DeleteBook\n 3 for UpdateBook\n 4 for ViewBook\n 5 for Menu: ");
                    if (!int.TryParse(Console.ReadLine(), out int choice))
                    {
                        throw new FormatException("!!!Choice must be an integer value!!!");
                    }
                    switch (choice)
                    {
                        case 1:
                            BookForm bookForm = new BookForm();
                            bookForm.AddBook();
                            break;
                        case 2:
                            Console.Write("\nEnter ISBN to delete book: ");
                            string isbn = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(isbn))
                            {
                                throw new ArgumentException("\n!!!Field are required*!!!");
                            }
                            Book.RemoveBook(isbn);
                            break;
                        case 3:
                            Console.Write("\nEnter ISBN to update book: ");
                            isbn = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(isbn))
                            {
                                throw new ArgumentException("\n!!!Field are required*!!!");
                            }
                            Book.UpdateBook(isbn);
                            break;
                        case 4:
                            Book.ViewBook();
                            break;
                        case 5:
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
            catch (ArgumentException e)
            {
                Console.WriteLine($"ArgumentException: {e.Message}");
            }
        }
    }
}
