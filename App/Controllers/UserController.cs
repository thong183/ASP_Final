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
using App.ViewModels;

namespace App.Controllers
{
    public class UserController : Controller
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        #region Functions
        public bool IsLogedIn()
        {
            if (HttpContext.Session.GetInt32("User_Id") != null && HttpContext.Session.GetString("User_Fullname") != null){ return true;}
            return false;
        }
        #endregion

        public IActionResult Index()
        {
            UserIndex vm = new UserIndex()
            {
                Books = _context.Books.ToList()
            };
            return View(vm);
        }

       
    }
}
