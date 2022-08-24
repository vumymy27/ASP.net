using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example01.Models
{
    public class UserMasterData
    {
        public int Id { get; set; }
        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Tên để trống")]
        public string LastName { get; set; }
        [Display(Name = "Họ")]
        [Required(ErrorMessage = "Họ để trống")]
        public string FirstName { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email để trống")]
        public string Email { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password để trống")]
        public string Password { get; set; }
       
        public Nullable<bool> IsAdmin { get; set; }
    }
}