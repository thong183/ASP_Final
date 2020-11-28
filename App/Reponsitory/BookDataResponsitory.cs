using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data;
using App.Models;
using App.Options;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace App.Reponsitory
{
    public class BookDataResponsitory: PaginatinReponsitory<Book>, ISearchingReponsitory<Book>
    {
        public BookDataResponsitory(IOptionsMonitor<PaginOption> option, DataContext context): base(option,context)
        { }

        public async Task<IEnumerable<Book>> GetTopSeenBooks(int top = 5)
        {
            return await table.OrderByDescending(x => x.NSeen).Take(top).ToListAsync();
        }
        public async Task<IEnumerable<Book>> GetTopSaleBooks(int top = 5)
        {
            return await (from b in table
                         join sub in (from cd in _context.CartDetails group cd by cd.Book_Id into g orderby g.Count() descending select new { BookId = g.Key })
                         on b.Id equals sub.BookId into total
                         from subBooks in total.DefaultIfEmpty()
                         select b).Take(top).ToListAsync();
        }
        public async Task<IEnumerable<Book>> GetTopLoveBooks(int top = 5)
        {
            return await table.OrderByDescending(x => x.NLove).Take(top).ToListAsync();
        }
        public async Task<IEnumerable<Book>> GetByDate(DateTime PublishDate)
        {
            return await table.Where(x => x.DatePublish.Date.CompareTo( PublishDate.Date) == 0).ToListAsync();
        }
        public async Task<IEnumerable<Book>> GetByDate(DateTime from, DateTime to)
        {
            return await table.Where(x => x.DatePublish.Date >= from.Date && x.DatePublish.Date <= to.Date).ToListAsync();

        }
        public async Task<IEnumerable<Book>> GetTopNewest(int top = 5)
        {
            return await table.OrderByDescending(x => x.Id).Take(top).ToListAsync();
        }
        public async Task<IEnumerable<Book>> GetWithSameCategory(Book entity,int? top = null)
        {
            return await GetWithSameCategory(entity.CategoryId,top);
        }
        public async Task<IEnumerable<Book>> GetWithSameCategory(int CategoryId,int? top = null)
        {
            if (top != null)
                return await table.Where(x => x.CategoryId == CategoryId).Take((int)top).ToListAsync();
            return await table.Where(x => x.CategoryId == CategoryId).ToListAsync();
        }
        public async Task<IEnumerable<Book>> GetByCategory(int CategoryId,int page)
        {
            if (table.Where(x => x.CategoryId == CategoryId).Count() > 1)
                return await table.Where(x => x.CategoryId == CategoryId).Skip(pageCount * (page - 1)).Take(pageCount).ToListAsync();
            return null;
        }
        public async Task<IEnumerable<Book>> GetWithRecentBoughtCategory(int Id, int top = 5)
        {
            //User => Card => CardId => BookId => BookCategoryId
            var _CategoriesId = await (from bc in _context.Books
                     join sub in (from cr in (from _cr in _context.Carts where _cr.User_Id == Id select _cr)
                                  join crd in _context.CartDetails on cr.Id equals crd.Cart_Id
                                  select new { BookId = crd.Book_Id }) on bc.Id equals sub.BookId
                                  group bc by bc.CategoryId into g
                     select g.Key).Take(top).ToListAsync();
            var _Book = new List<Book>();
            _CategoriesId.ForEach(async x => 
                _Book.AddRange(await GetWithSameCategory(x, top: 3)));

            return _Book;


        }
        public async Task Seen(int Id)
        {
            var _res = await table.SingleOrDefaultAsync(x => x.Id == Id);
            if(_res == null)
            {
                _res.NSeen += 1;
                table.Update(_res);
                await _context.SaveChangesAsync();

            }
        }
        public async Task<IEnumerable<Book>> Search(string key)
        {
            return await table.Where(x => x.Title.Contains(key)).ToListAsync();
        }
    }
}
