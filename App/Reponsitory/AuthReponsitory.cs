using App.Binding;
using App.Data;
using App.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Reponsitory
{
    public class AuthReponsitory : IAuthReponsitory
    {
        protected DataContext _context;
        protected DbSet<User> table;
        private readonly IMapper _mapper;

        public AuthReponsitory(IMapper mapper,DataContext context)
        {
            _context = context;
            table = context.Set<User>();
            _mapper = mapper;
        }
        public User ChangeInfo(BindingUserInfo user)
        {
            throw new NotImplementedException();
        }

        public User Login(BindingUserLogin user)
        {
            if (user.Username.Contains('@')) {
                var tmp = table.SingleOrDefault(_user => _user.Email.Equals(user.Username) && _user.Password.Equals(user.Password));
                if (tmp != null) return tmp;
            }
            return table.SingleOrDefault(_user => _user.Username.Equals(user.Username) && _user.Password.Equals(user.Password));
        }

        public User Register(BindingUserRegister user)
        {
            var _user = table.SingleOrDefault(x => x.Email.Equals(user.Email));
            if(_user == null)
            {
                _user = _mapper.Map<Models.User>(user);
                table.Add(_user);
                _context.SaveChanges();
            }

            return null;

        }
    }
}
