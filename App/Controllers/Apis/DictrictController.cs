using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data;
using App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class DictrictController : ControllerBase
    {
        public IDataReponsitory<Country> _context;
        public DictrictController(IDataReponsitory<Country> context)
        {
            _context = context;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.GetAll());
        }
    }
}