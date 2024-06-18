using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class UserAddBook
    {
        public void UserBook()
        {
            try
            {
                while (true)
                {
                    Console.Write("\nEnter\n 1 for ViewCart\n 2 for AddBookToCart\n 3 for RemoveBookToCart\n 4 for Menu: ");
                    if (!int.TryParse(Console.ReadLine(), out int choice))
                    {
                        throw new FormatException("!!!Choice must be an integer value!!!");
                    }
                    Console.WriteLine();
                    switch (choice)
                    {
                        case 1:
                            Cart cart = new Cart();
                            Console.WriteLine("\n-------- Library --------\n");
                            cart.ViewCart();
                            Console.WriteLine("\n--------------------------\n");
                            break;
                        case 2:
                            Book.ViewBook();
                            AddBook();
                            break;
                        case 3:
                            RemoveBook();
                            break;
                        case 4:
                            return;
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
        }

        public void AddBook()
        {
            if (DataStorage.currUser.UserBookCart.Count >= 3)
            {
                Console.WriteLine("\nYour cart is already full. Remove a book before adding a new one.");
                return;
            }

            Console.Write("To Add Book please provide the ISBN: ");
            string isbn = Console.ReadLine();
            bool bookFound = false;

            for (int i = 0; i < DataStorage.Books.Count; i++)
            {
                if (DataStorage.Books[i].ISBN == isbn)
                {
                    if (!DataStorage.Books[i].IsAvailable) { Console.WriteLine("\nBook is already taken..."); return; }
                    DataStorage.Books[i].IsAvailable = false;
                    DataStorage.currUser.UserBookCart.Add(DataStorage.Books[i]);
                    Console.WriteLine("\nBook added to your profile successfully.");
                    bookFound = true;
                    break;
                }
            }

            if (!bookFound)
            {
                Console.WriteLine($"\nBook not found with ISBN: {isbn}.");
            }
        }

        public void RemoveBook()
        {
            if (DataStorage.currUser.UserBookCart.Count == 0)
            {
                Console.WriteLine("\nYour cart is empty. There are no books to remove.");
                return;
            }

            Console.Write("To remove a book, please provide the ISBN: ");
            string isbn = Console.ReadLine();
            bool bookFound = false;

            for (int i = 0; i < DataStorage.currUser.UserBookCart.Count; i++)
            {
                if (DataStorage.currUser.UserBookCart[i].ISBN == isbn)
                {
                    var book = DataStorage.currUser.UserBookCart[i];
                    book.IsAvailable = true;
                    DataStorage.currUser.UserBookCart.RemoveAt(i);
                    Console.WriteLine("\nBook removed from your cart successfully.");
                    bookFound = true;
                    break;
                }
            }

            if (!bookFound)
            {
                Console.WriteLine($"\nBook not found in your cart with ISBN: {isbn}.");
            }
        }
    }
}
