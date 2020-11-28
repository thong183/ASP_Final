using App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace App.ViewModels
{
    public class HomeBookList
    {
        public IEnumerable<Book> Books {get;set;}
    }
}
