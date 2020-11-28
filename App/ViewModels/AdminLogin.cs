using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.ViewModels;

namespace App.ViewModels
{
    public class AdminLogin
    {
        public string Username {get;set;}
        public string Password {get;set;}
    }
}
