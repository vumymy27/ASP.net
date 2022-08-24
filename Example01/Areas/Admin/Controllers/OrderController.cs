using Example01.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Example01.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        objqlbhEntities objqlbhEntities = new objqlbhEntities();


        public ActionResult Index()
        {
            var listOrder = objqlbhEntities.Orders.ToList();
            return View(listOrder);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var order = objqlbhEntities.Orders.Where(n => n.Id == id).FirstOrDefault();
            return View(order);
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {

            var objorder = objqlbhEntities.Orders.Where(n => n.Id == Id).FirstOrDefault();

            return View(objorder);
        }
        [HttpPost]
        public ActionResult Delete(Order objor)
        {

            var objorder = objqlbhEntities.Orders.Where(n => n.Id == objor.Id).FirstOrDefault();
            objqlbhEntities.Orders.Remove(objorder);
            objqlbhEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}