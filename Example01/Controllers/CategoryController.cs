using Example01.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Example01.Controllers
{
    public class CategoryController : Controller
    {
        objqlbhEntities objqlbhEntities = new objqlbhEntities();

        // GET: Category
        public ActionResult Index()
        {
            var lstCategory = objqlbhEntities.Categories.ToList();

            return View(lstCategory);
        }
        public ActionResult ProductCategory(int Id)
        {
            var LstProduct = objqlbhEntities.Products.Where(n => n.CategoryId == Id).ToList();
            return View(LstProduct);
        }
    }
}