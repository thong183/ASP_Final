using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.Models;

namespace App.ViewModels
{
    public class BookIndex
    {
        public IEnumerable<Book> Books {get;set;}
    }
}
