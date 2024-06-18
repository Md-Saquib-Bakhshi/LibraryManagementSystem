using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class BookForm
    {
        public void AddBook()
        {
            Console.WriteLine("\n******* Book Form *******");
            Console.WriteLine();

            //Taking Inputs
            Console.Write("Enter ISBN: ");
            string isbn = Console.ReadLine();
            Console.Write("Enter Title: ");
            string title = Console.ReadLine();
            Console.Write("Enter Author: ");
            string author = Console.ReadLine();
            Console.Write("Enter Publication: ");
            string publication = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("***************************");

            //Validation
            if (string.IsNullOrWhiteSpace(isbn) || string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(publication))
            {
                throw new ArgumentException("\n!!!All fields are required*!!!");
            }
            Book book = new Book(isbn, title, author, publication);
            Book.AddBook(book);
            Console.WriteLine("\nSuccessfully Added...");
        }

        public void UpdateBook(Book book)
        {
            Console.WriteLine("\n******* Update Book Form *******");
            Console.WriteLine();

            // Show current book details
            Console.WriteLine($"\nCurrent Title: {book.Title}");
            Console.WriteLine($"\nCurrent Author: {book.Author}");
            Console.WriteLine($"\nCurrent Publication: {book.Publication}");

            //Taking Inputs
            Console.Write("Enter new Title (or press Enter to keep current): ");
            string title = Console.ReadLine();
            Console.Write("Enter new Author (or press Enter to keep current): ");
            string author = Console.ReadLine();
            Console.Write("Enter new Publication (or press Enter to keep current): ");
            string publication = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("***************************");

            // Update book details if new values are provided
            if (!string.IsNullOrWhiteSpace(title)) book.Title = title;
            if (!string.IsNullOrWhiteSpace(author)) book.Author = author;
            if (!string.IsNullOrWhiteSpace(publication)) book.Publication = publication;

            Console.WriteLine("\nSuccessfully Updated...");
        }
    }
}
