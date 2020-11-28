using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace App.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }      

        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        [StringLength(25, ErrorMessage = "Tên đăng nhập từ 6 đến 25 kí tự", MinimumLength = 6)]
        [Display(Name = "Tên đăng nhập")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(25, ErrorMessage = "Mật khẩu từ 6 đến 25 kí tự", MinimumLength = 6)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [StringLength(20, ErrorMessage = "Số điện thoại phải từ 10 đến 20 kí tự", MinimumLength = 10)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(100, ErrorMessage = "Tên không quá 100 kí tự")]
        [Display(Name = "Tên")]
        public string NameFirst { get; set; }

        [StringLength(100, ErrorMessage = "Họ đệm không quá 100 kí tự")]
        [Display(Name = "Họ đệm")]
        public string NameMiddle { get; set; }

        [Required(ErrorMessage = "Họ không được để trống")]
        [StringLength(100, ErrorMessage = "Họ không quá 100 kí tự")]
        [Display(Name = "Họ")]
        public string NameLast { get; set; }

        [Display(Name = "Giới tính")]
        [DefaultValue("1")]
        public bool Gender { get; set; }

        [Display(Name = "Ngày sinh")]
        public DateTime? DateBirth { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public Country Country { get; private set; }

        [ForeignKey("City")]
        public int CityId { get; set; }
        public City City { get; private set; }

        [ForeignKey("Dictrict")]
        public int DistrictId { get; set; }
        public Dictrict Dictrict { get; private set; }

        public string Address { get; set; }

        public string GetFullName()
        {
            return 
                NameLast + " " +
                (NameMiddle == "" ? NameMiddle + " ": "" )+
                NameFirst;
        }
    }
}
