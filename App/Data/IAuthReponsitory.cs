using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using App.Binding;

namespace App.Data
{
    public interface IAuthReponsitory
    {
        User Login(BindingUserLogin user);
        User Register(BindingUserRegister user);
        User ChangeInfo(BindingUserInfo user);
    }
}
