using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagementSystem
{
    internal class Book
    {
        private string isbn;
        private string title;
        private string author;
        private string publication;
        private bool isAvailable;

        public string ISBN
        {
            get
            {
                return isbn;
            }
            set
            {
                isbn = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                author = value;
            }
        }

        public string Publication
        {
            get
            {
                return publication;
            }
            set
            {
                publication = value;
            }
        }

        public bool IsAvailable
        {
            get
            {
                return isAvailable;
            }
            set
            {
                isAvailable = value;
            }
        }

        public Book(string isbn, string title, string author, string publication, bool isAvailable = true)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
            Publication = publication;
            IsAvailable = isAvailable;
        }

        public static void AddBook(Book book)
        {
            DataStorage.Books.Add(book);
        }

        public static void RemoveBook(string isbn)
        {
            bool bookFound = false;

            for (int i = 0; i < DataStorage.Books.Count; i++)
            {
                if (DataStorage.Books[i].ISBN == isbn)
                {
                    Console.WriteLine($"\n{DataStorage.Books[i].Title} is deleted...");
                    DataStorage.Books.RemoveAt(i);
                    bookFound = true;
                    break;
                }
            }

            if (!bookFound)
            {
                Console.WriteLine($"\nBook not found with ISBN: {isbn}.");
            }
        }

        public static void UpdateBook(string isbn)
        {
            bool bookFound = false;

            for (int i = 0; i < DataStorage.Books.Count; i++)
            {
                if (DataStorage.Books[i].ISBN == isbn)
                {
                    Console.WriteLine($"\n{DataStorage.Books[i].ISBN} is found...");
                    BookForm bookForm = new BookForm();
                    bookForm.UpdateBook(DataStorage.Books[i]);
                    bookFound = true;
                    break;
                }
            }

            if (!bookFound)
            {
                Console.WriteLine($"\nBook not found with ISBN: {isbn}.");
            }
        }

        public static void ViewBook()
        {
            string avail = null;
            foreach (var book in DataStorage.Books)
            {
                Console.WriteLine("\n-------Book Details-------\n");
                if (book.IsAvailable)
                {
                    avail = "Available";
                }
                else
                {
                    avail = "Not Available";
                }
                Console.WriteLine($"\nISBN: {book.ISBN}\nTitle: {book.Title}\nAuthor: {book.Author}\nPublication: {book.publication}\nIsAvailable: {avail}\n");
                Console.WriteLine("--------------------------");
            }
        }
    }
}
