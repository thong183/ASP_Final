using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Binding
{
    public class BindingUserInfo
    {
        public string Password { get; set; }

        public string Email { get; set; }
        
        public string PhoneNumber { get; set; }

        public string NameFirst { get; set; }

        public string NameMiddle { get; set; }

        public string NameLast { get; set; }

        public bool Gender { get; set; }

        public DateTime? DateBirth { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; private set; }

        public int CityId { get; set; }
        public City City { get; private set; }

        public int DistrictId { get; set; }
        public Dictrict Dictrict { get; private set; }

        public string Address { get; set; }
    }
}
