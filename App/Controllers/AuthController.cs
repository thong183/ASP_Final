using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data;
using Microsoft.AspNetCore.Mvc;
using App.Extensions;
using AutoMapper;

namespace App.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthReponsitory _context;

        public AuthController(IMapper mapper,IAuthReponsitory context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Binding.BindingUserLogin user)
        {
            var _res = _context.Login(user);

            if (_res == null)
                return View("Login");

            HttpContext.Session.Set<string>("Fullname", _res.GetFullName());
            HttpContext.Session.Set<string>("Username", _res.Username);
            HttpContext.Session.Set<int>("Id", _res.Id);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Binding.BindingUserRegister user)
        {
            var _res = _context.Register(user);
            if (_res == null)
                return View("Index");
            return RedirectToAction("Index","Home");
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}