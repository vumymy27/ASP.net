﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example01.Models
{
    public class BrandMasterData
    {
        public int Id { get; set; }
        [Display(Name = "Tên thương hiệu")]
        [Required(ErrorMessage = "Tên thương hiệu không được để trống")]
        public string Name { get; set; }
        [Display(Name = "Hình ảnh")]

        public string Avatar { get; set; }
        public string Slug { get; set; }
        [Display(Name = "Hiện thị lên trang chủ")]
        public Nullable<bool> ShowOnHomePage { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        [Display(Name = "Ngày tạo")]

        public Nullable<System.DateTime> CreateOnUtc { get; set; }
        [Display(Name = "Ngày cập nhập")]

        public Nullable<System.DateTime> UpdateOnUtc { get; set; }
        public Nullable<bool> Deleted { get; set; }
    }
}