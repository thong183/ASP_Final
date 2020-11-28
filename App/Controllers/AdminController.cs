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
    public class AdminController : Controller
    {
        private readonly DataContext _context;

        public AdminController(DataContext context)
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
            return View();
        }

        public IActionResult Login()
        {
            return View(new AdminLogin());
        }

        [HttpPost]
        public IActionResult Login(AdminLogin vm)
        {
            if (ModelState.IsValid)
            {
                Admin check = _context.Admins.Where(ad => ad.Username == vm.Username).FirstOrDefault();
                if (check != null)
                {
                    if (check.Password == vm.Password)
                    {
                        HttpContext.Session.SetString("Admin_Username",check.Username);
                        HttpContext.Session.SetInt32("Admin_Id",check.Id);
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(vm);
        }

        public IActionResult Logout()
        {
            if (IsLogedIn())
            {
                HttpContext.Session.Remove("Admin_Id");
                HttpContext.Session.Remove("Admin_Username");
            }
            return RedirectToAction("Login");
        }
    }
}
