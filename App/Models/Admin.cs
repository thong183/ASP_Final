using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        [StringLength(25, ErrorMessage = "Tên đăng nhập từ 6 đến 25 kí tự",MinimumLength = 6)]
        [Display(Name = "Tên đăng nhập")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu đăng nhập không được để trống")]
        [StringLength(25, ErrorMessage = "Mật khẩu đăng nhập từ 6 đến 25 kí tự", MinimumLength = 6)]
        [Display(Name = "Mật khẩu đăng nhập")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
