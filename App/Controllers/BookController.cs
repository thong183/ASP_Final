using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using App.Models;
using App.Data;
using App.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.Controllers
{
    public class BookController : Controller
    {
        private readonly DataContext _context;

        public BookController(DataContext context)
        {
            _context = context;
        }

        #region Functions
        public bool IsLogedIn()
        {
            if (HttpContext.Session.GetInt32("Admin_Id") != null && HttpContext.Session.GetString("Admin_Username") != null){ return true;}
            return false;
        }
        #endregion

        public IActionResult Index()
        {
            return View(
                new BookIndex(){
                     Books = _context.Books.ToList()
                }
            );
        }

        public IActionResult New()
        {
            BookNew vm = new BookNew()
            {
                Book = new Book(),
                BookCategories = _context.BookCategory.ToList()
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult New(BookNew vm)
        {
            if (ModelState.IsValid)
            {
                Book new_book = vm.Book;
                new_book.Cover = "#";

                // Tải hình ảnh sản phẩm lên thư mục wwwroot/uploads
                if (vm.Cover != null)
                {
                    new_book.Cover = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                    string uniqueName = new_book.Cover ; // Tạo tên hình ảnh theo chuỗi ngày tháng lúc đăng ảnh
                    string newpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads"); // Trỏ đường dẫn đến thư mục wwwroot/uploads
                    newpath = Path.Combine(newpath, uniqueName); // Trỏ đường dẫn đến tên hình ảnh
                    newpath = newpath + Path.GetExtension(vm.Cover.FileName); // Gắn đuôi (loại file) cho hình
                    vm.Cover.CopyTo(new FileStream(newpath, FileMode.Create)); // Copy hình từ nguồn sang wwwroot/uploads
                    new_book.Cover += Path.GetExtension(vm.Cover.FileName);
                }

                _context.Books.Add(new_book);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(
                    new BookNew()
                    {
                        Book = vm.Book,
                        BookCategories = _context.BookCategory.ToList()
                    }
                );
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Book detail = _context.Books.Where(b => b.Id == id).FirstOrDefault();
            if (detail != null)
            {
                return View(
                    new BookNew()
                    {
                        Book = detail,
                        BookCategories = _context.BookCategory.ToList()
                    }
                );
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(BookNew vm)
        {
            if (ModelState.IsValid)
            {
                Book up = _context.Books.Where(b => b.Id == vm.Book.Id).FirstOrDefault();

                up.Title       = vm.Book.Title;
                up.Author      = vm.Book.Author;
                up.Description = vm.Book.Description;
                up.DatePublish = vm.Book.DatePublish;
                up.Publisher   = vm.Book.Publisher;
                up.Translater  = vm.Book.Translater;
                up.Price       = vm.Book.Price;
                up.Saleoff     = vm.Book.Saleoff;
                up.CategoryId  = vm.Book.CategoryId;
                up.NSeen       = vm.Book.NSeen;
                up.NLove       = vm.Book.NLove;

                if (vm.Cover != null)
                {
                    // Xóa ảnh cũ
                    string old_image = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","uploads",vm.Book.Cover);
                    if (System.IO.File.Exists(old_image))
                    {
                        System.IO.File.Delete(old_image);
                    }
            
                    // Lưu ảnh mới
                    string rename = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + Path.GetExtension(vm.Cover.FileName);
                    string new_image = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","uploads", rename);
                    vm.Cover.CopyTo(new FileStream(new_image,FileMode.Create));
                    up.Cover = rename;
                }

                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            { 
                return View(
                    new BookNew()
                    {
                        Book = vm.Book,
                        BookCategories = _context.BookCategory.ToList()
                    }
                );
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Book delete = _context.Books.Where(b => b.Id == id).FirstOrDefault();
            if (delete != null)
            {
                // Xóa ảnh khỏi thư mục uploads
                string url = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","uploads",delete.Cover);
                if (System.IO.File.Exists(url)){System.IO.File.Delete(url);}
                _context.Remove(delete);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }    
    }
}
