using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal static class DataStorage
    {
        public static Registration currUser = null;

        public static Dictionary<string, Registration> Users = new Dictionary<string, Registration>();

        public static List<Book> Books = new List<Book>();

    }
}
