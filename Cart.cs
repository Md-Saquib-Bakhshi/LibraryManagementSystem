using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class Cart
    {
        public void ViewCart()
        {
            Console.WriteLine($"\n{DataStorage.currUser.UserName}'s Cart:");
            if (DataStorage.currUser.UserBookCart.Count == 0)
            {
                Console.WriteLine("Your cart is empty.");
            }
            else
            {
                foreach (var book in DataStorage.currUser.UserBookCart)
                {
                    Console.WriteLine($"- {book.Title} by {book.Author} (ISBN: {book.ISBN})");
                }
            }
        }

    }
}
