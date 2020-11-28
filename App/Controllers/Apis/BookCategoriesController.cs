using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using App.Models;

namespace App.Controllers.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCategoriesController : ControllerBase
    {
        public IDataReponsitory<BookCategory> _context;
        public BookCategoriesController(IDataReponsitory<BookCategory> context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.GetAll());
        }
    }
}