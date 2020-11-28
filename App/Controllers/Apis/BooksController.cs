using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App.Reponsitory;
using App.Binding;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Controllers.Apis
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly BookDataResponsitory _context;
        public BooksController(BookDataResponsitory context)
        {
            _context = context;
        }
        [HttpGet("GetPage/{page}")]
        public async Task<IActionResult> GetPage(int page)
        {
            var res = await _context.GetAll(page);
            if (res.Count() == 0) return NotFound();
            return Ok(res);
        }
        [HttpGet("GetTopSeen")]
        public async Task<IActionResult> GetTopSeenBooks()
        {
            var res = await _context.GetTopSeenBooks();
            if (res.Count() == 0) return NotFound();
            return Ok(res);
        }
        [HttpGet("GetTopSale")]
        public async Task<IActionResult> GetTopSaleBooks()
        {
            var res = await _context.GetTopSaleBooks();
            if (res.Count() == 0) return NotFound();
            return Ok(res);
        }
        [HttpGet("GetTopLove")]
        public async Task<IActionResult> GetTopLove()
        {
            var res = await _context.GetTopLoveBooks();
            if (res.Count() == 0) return NotFound();
            return Ok(res);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.GetAll());
        }
        [HttpGet("GetById/{BookId}")]
        public async Task<IActionResult> GetById(int BookId)
        {
            var res = await _context.GetById(BookId);
            if (res == null) return NotFound();
            return Ok(res);
        }
        [HttpPost("GetByDate")]
        public async Task<IActionResult> GetByDate([FromBody]BindingDate DatePublish)
        {
            return Ok(await _context.GetByDate(DatePublish.DatePublish));
        }
        [HttpGet("GetByCategory/{id}/{page}")]
        public async Task<IActionResult> GetByCategory(int id,int page = 1)
        {
            return Ok(await _context.GetByCategory(id, page));
        }
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] Models.Book book)
        {
            var res = await _context.Create(book);
            if (res == null) return NotFound();
            return Ok(res);
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id,[FromBody]Models.Book book)
        {
            var res = await _context.GetById(id);
            if (res == null) return NotFound();
            book.Id = id;
            res = await _context.Update(book);

            return Ok(book);
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var res = _context.DeleteById(id);
            if (res) return Ok();
            return NotFound();
        }
    }
}
