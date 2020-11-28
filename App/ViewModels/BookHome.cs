using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.ViewModels
{
    public class BookHome
    {
        public IEnumerable<Models.Book> Books { get; set; }
        public IEnumerable<Models.Book> BooksNew { get; set; }
        public IEnumerable<Models.Book> BooksTopSeen { get; set; }
        public IEnumerable<Models.Book> BooksTopLove { get; set; }
        public IEnumerable<Models.Book> BooksTopSale { get; set; }
    }
}
