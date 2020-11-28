using App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace App.ViewModels
{
    public class BookNew
    {
        public Book Book {get;set;}
        public IFormFile Cover { get; set; }
        public IEnumerable<BookCategory> BookCategories {get;set;}
    }
}
