using Example01.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Example01.Common;

namespace Example01.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        

        
        objqlbhEntities objqlbhEntities = new objqlbhEntities();

        // GET: Admin/Product
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var lstCategory = new List<Category>();
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentFilter;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                lstCategory = objqlbhEntities.Categories.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            {
                lstCategory = objqlbhEntities.Categories.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            lstCategory = lstCategory.OrderByDescending(n => n.Id).ToList();
            return View(lstCategory.ToPagedList(pageNumber, pageSize));
        }
        void LoadData()
        {

            Common objCommon = new Common();

            var lstCat = objqlbhEntities.Categories.ToList();

            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dtCategory = converter.ToDataTable(lstCat);
            ViewBag.ListCategory = objCommon.ToSelectList(dtCategory, "Id", "Name");

            List<CategoryType> lstCategoryType = new List<CategoryType>();
            CategoryType objCategoryType = new CategoryType();
            objCategoryType.Id = 1;
            objCategoryType.Name = "Danh mục phổ biến";
            lstCategoryType.Add(objCategoryType);



            DataTable dtCategoryType = converter.ToDataTable(lstCategoryType);
            ViewBag.CategoryType = objCommon.ToSelectList(dtCategoryType, "Id", "Name");


        }
        [HttpGet]
        public ActionResult Create()
        {
            this.LoadData();
            return View();

        }
      
        [ValidateInput(false)]
        //end
        [HttpPost]
        public ActionResult Create(Category objCategory)
        {

            this.LoadData();
            if (ModelState.IsValid)
            {
                try
                {
                    if (objCategory.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objCategory.ImageUpload.FileName);
                        string extension = Path.GetExtension(objCategory.ImageUpload.FileName);
                        fileName = fileName + extension;
                        objCategory.Avatar = fileName;
                        objCategory.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items"), fileName));
                    }
                    objCategory.CreatedOnUtc = DateTime.Now;
                    objqlbhEntities.Categories.Add(objCategory);
                    objqlbhEntities.SaveChanges();


                    return RedirectToAction("Index");

                }
                catch
                {
                    return RedirectToAction("Index");
                }
            }
            return View(objCategory);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var lstCategory = objqlbhEntities.Categories.Where(n => n.Id == id).FirstOrDefault();

            return View(lstCategory);

        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objCategory = objqlbhEntities.Categories.Where(n => n.Id == id).FirstOrDefault();

            return View(objCategory);

        }
        [HttpPost]
        public ActionResult Delete(Category objCa)
        {
            var objCategory = objqlbhEntities.Categories.Where(n => n.Id == objCa.Id).FirstOrDefault();


            objqlbhEntities.Categories.Remove(objCategory);
            objqlbhEntities.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objCategory = objqlbhEntities.Categories.Where(n => n.Id == id).FirstOrDefault();

            return View(objCategory);

        }
        [HttpPost]
        public ActionResult Edit(Category objCategory, FormCollection form)
        {
            if (objCategory.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objCategory.ImageUpload.FileName);
                string extension = Path.GetExtension(objCategory.ImageUpload.FileName);
                fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                objCategory.Avatar = fileName;
                objCategory.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items"), fileName));
            }
            else
            {
                objCategory.Avatar = form["oldimage"];
                objqlbhEntities.Entry(objCategory).State = EntityState.Modified;
                objCategory.UpdatedOnUtc = DateTime.Now;
                objqlbhEntities.SaveChanges();


            }
            objqlbhEntities.Entry(objCategory).State = EntityState.Modified;
            objCategory.UpdatedOnUtc = DateTime.Now;
            objqlbhEntities.SaveChanges();


            return RedirectToAction("Index");
        
    }
    }

}