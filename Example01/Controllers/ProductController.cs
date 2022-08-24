using Example01.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Example01.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        objqlbhEntities objqlbhEntities = new objqlbhEntities();
        public ActionResult Detail(int Id)
        {

            var objProduct = objqlbhEntities.Products.Where(n => n.Id == Id).FirstOrDefault();

            return View(objProduct);
        }
    }
}