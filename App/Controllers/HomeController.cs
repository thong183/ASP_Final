using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.Data;
using App.ViewModels;
using App.Reponsitory;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;
        private readonly BookDataResponsitory _bookContext;

        public HomeController(BookDataResponsitory bookContext, DataContext context)
        {
            _context = context;
            _bookContext = bookContext;
        }

        public async Task<IActionResult> Index()
        {
            var _ = new BookHome()
            {
                Books = await _bookContext.GetAll(1),
                BooksNew = await _bookContext.GetTopNewest(),
                BooksTopLove = await _bookContext.GetTopLoveBooks(),
                BooksTopSale = await _bookContext.GetTopSaleBooks(),
                BooksTopSeen = await _bookContext.GetTopSeenBooks()

            };
            return View(_);
        }

        public async Task<IActionResult> CategoryList()
        {
            var _res = await _context.BookCategory.ToListAsync();
            return View(_res);
        }
        
        [HttpGet]
        public IActionResult BookListCategory(int id)
        {
            BookCategory category = _context.BookCategory.Where(c => c.Id == id).FirstOrDefault();
            if (category != null)
            {
                HomeBookList vm = new HomeBookList()
                {
                    Books = _context.Books.Where(b => b.CategoryId == id).ToList()
                };
                ViewBag.BookCategory = category.Name;
                return View(vm);
            }
            else
            {
                return RedirectToAction("Index","User");
            }
        }

        public async Task<IActionResult> BookList()
        {
            var _res = await _bookContext.GetAll(1);
            ViewBag.pageCount = await _bookContext.CountAllPage();
            return View(_res);
        }
        [HttpGet]
        public async Task<IActionResult> BookDetail(int id)
        {
            Book detail = _context.Books.Where(b => b.Id == id).FirstOrDefault();

            // Update NSeen
            var _res = await _context.Books.SingleOrDefaultAsync(x => x.Id == id);
            if (_res == null)
            {
                _res.NSeen += 1;
                _context.Books.Update(_res);
                await _context.SaveChangesAsync();
            }

            if (detail != null)
            {
                return View(
                    new HomeBookDetail()
                    {
                        Book = detail,
                        Books = _context.Books.ToList()
                    }
                );
            }
            else
            {
                return RedirectToAction("Index","User");
            }
        }
    }
}
