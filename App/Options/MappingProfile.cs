using App.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Options
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<User, Binding.BindingUserRegister>();
            CreateMap<Binding.BindingUserRegister, User>();
        }
    }
}
