using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Binding
{
    public class BindingUserRegister
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string NameFirst { get; set; }

        public string NameMiddle { get; set; }
        
        public string NameLast { get; set; }

        public bool Gender { get; set; }

        public DateTime? DateBirth { get; set; }

        public int? CountryId { get; set; }

        public int? CityId { get; set; }

        public int? DistrictId { get; set; }

        public string Address { get; set; }
    }
}
