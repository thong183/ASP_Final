using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data;
using App.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Controllers.Apis
{
    [Route("api/[controller]")]
    public class CityController : Controller
    {
        public IDataReponsitory<Country> _context;
        public CityController(IDataReponsitory<Country> context)
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
