using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models
{
    public class CartDetail
    {
        [Key]
        public int Id { get; set; }

        public int Cart_Id { get; set; }

        [Display(Name = "Mã số sách")]
        public int Book_Id {get;set;}

        [Display(Name = "Tên sách")]
        public string Book_Title {get;set;}

        [Display(Name = "Đơn giá")]
        public int Book_Price {get;set;}

        [Display(Name = "Phần trăm khuyến mãi")]
        public int Book_Saleoff {get;set;}

        [Display(Name = "Số lượng")]
        public int Quantity {get;set;}        

        [Display(Name = "Tổng tiền")]
        public int Total { get; set; }
      
    }
}
