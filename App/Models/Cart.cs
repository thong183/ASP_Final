using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int User_Id { get; set; }

        [Display(Name = "Tổng số tiền")]
        public int TotalPrice { get; set; } = 0;

        [Display(Name = "Số lượng hàng trong giỏ")]
        public int TotalQuantity { get; set; } = 0;
    }
}
