using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace App.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tiêu đề sách không được để trống.")]
        [Display(Name = "Tiêu đề sách")]
        public string Title {get;set;}

        [Display(Name = "Mô tả sách")]
        public string Description {get;set;} 

        [Required(ErrorMessage = "Tên tác giả không được để trống.")]
        [Display(Name = "Tác giả")]
        public string Author {get;set;}

        [Required(ErrorMessage = "Ngày xuất bản không được để trống.")]
        [Display(Name = "Ngày xuất bản")]
        public DateTime DatePublish {get;set;} = DateTime.Now;

        [Required(ErrorMessage = "Nhà xuất bản không được để trống.")]
        [Display(Name = "Nhà xuất bản")]
        public string Publisher {get;set;}

        [Display(Name = "Dịch giả")]
        public string Translater {get;set;}

        [Required(ErrorMessage = "Kích cỡ sách không được để trống.")]
        [Display(Name = "Kích cỡ sách (dài x rộng)")]
        public string Size {get;set;}

        [Required(ErrorMessage = "Số trang không được để trống.")]
        [Display(Name = "Số trang")]
        [DefaultValue(0)]
        public int Pages {get;set;}

        [Required(ErrorMessage = "Ảnh bìa sách không được để trống.")]
        [Display(Name = "Ảnh bìa sách")]
        public string Cover {get;set;}

        [Required(ErrorMessage = "Đơn giá sách không được để trống.")]
        [Display(Name = "Đơn giá")]
        [DefaultValue(0)]
        public int Price {get;set;}

        [Display(Name = "Phần trăm giảm giá")]
        [DefaultValue(0)]
        public int Saleoff {get;set;}

        [Display(Name = "Thể loại sách")]
        [ForeignKey("BookCategory")]
        public int CategoryId {get;set;}
        public BookCategory Category { get; set; }

        [Display(Name = "Số lược xem")]
        [DefaultValue(0)]
        public int NSeen { get; set; }

        [Display(Name = "Số lược yêu thích")]
        [DefaultValue(0)]
        public int NLove { get; set; }
    }
}
