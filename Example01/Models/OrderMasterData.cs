using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example01.Models
{
    public class OrderMasterData
    {
        public int Id { get; set; }
        [Display(Name = "Tên đơn hàng")]
        public string Name { get; set; }
        public int UserId { get; set; }
        [Display(Name = "Trạng thái")]
        public int Status { get; set; }

        public System.DateTime CreatedOnUtc { get; set; }
    }
}