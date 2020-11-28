using App.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Components
{
    [ViewComponent(Name = "NavBar")]
    public class NavBarViewComponent: ViewComponent
    {
        private readonly IPaginationReponsitory<Models.BookCategory> _context;
        public NavBarViewComponent(IPaginationReponsitory<Models.BookCategory> context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            _context.UpdatePageCount(6);
            var items = await _context.GetAll(1);
            return View(items);
        }
    }
}
