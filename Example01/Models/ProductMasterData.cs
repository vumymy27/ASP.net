using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace Example01.Models
{
    public partial class ProductMasterData
    {
        public int Id { get; set; }
        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        public string Name { get; set; }
        [Display(Name = "Hình ảnh")]

        public string Avatar { get; set; }
        [Display(Name = "Danh mục")]
        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        public Nullable<int> CategoryId { get; set; }
        [Display(Name = "Loại danh mục")]
        [Required(ErrorMessage = "Tên  loại danh mục không được để trống")]
        public Nullable<int> TypeId { get; set; }
        [Display(Name = "Thương hiệu")]
        [Required(ErrorMessage = "Tên thương hiệu không được để trống")]
        public Nullable<int> BrandId { get; set; }
        [Display(Name = "Mô tả ngắn")]
        [Required(ErrorMessage = "Tên mô tả ngắn không được để trống")]
        public string ShortDes { get; set; }
        [Display(Name = "Mô tả đầy đủ")]
        [Required(ErrorMessage = "Mô tả đầy đủ không được để trống")]

        public string FullDescription { get; set; }
        [Display(Name = "Giá")]
        [Required(ErrorMessage = "Giá không được để trống")]
        public Nullable<double> Price { get; set; }
        [Display(Name = "Giá khuyến mãi")]
        [Required(ErrorMessage = "Giá khuyến mãi không được để trống")]

        public Nullable<double> PriceDiscount { get; set; }
        public string Slug { get; set; }
        public Nullable<bool> Deleted { get; set; }
        [Display(Name = "Hiển thị trang chủ")]

        public Nullable<bool> ShowOnHomePage { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        [Display(Name = "Ngày tạo")]

        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
        [Display(Name = "Ngày cập nhật")]

        public Nullable<System.DateTime> UpdatedOnUtc { get; set; }
        [NotMapped]
        public System.Web.HttpPostedFileBase ImageUpload { get; set; }

    }
}