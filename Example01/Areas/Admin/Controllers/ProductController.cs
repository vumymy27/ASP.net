using Example01.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Example01.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        qlbhEntities objqlbhEntities = new qlbhEntities();

        // GET: Admin/Product
        public ActionResult Index()
        {
            var lstProduct = objqlbhEntities.Products.ToList();
            return View(lstProduct);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product objProduct)
        {
            try
            {
                if(objProduct.ImageUpload!=null)
                 {
                    String fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                    String extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                    fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                    objProduct.Avatar = fileName;
                    objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/Images"), fileName));
                }
                objqlbhEntities.Products.Add(objProduct);
                objqlbhEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                return RedirectToAction("Index");

            }
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var objProduct = objqlbhEntities.Products.Where(n => n.Id == id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objProduct = objqlbhEntities.Products.Where(n => n.Id == id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Delete(Product objPro)
        {
            var objProduct = objqlbhEntities.Products.Where(n => n.Id == objPro.Id).FirstOrDefault();
            objqlbhEntities.Products.Remove(objProduct);
            objqlbhEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objProduct = objqlbhEntities.Products.Where(n => n.Id == id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Edit(Product objProduct)
        {
           if(objProduct.ImageUpload!=null)
            {
                String fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                String extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                objProduct.Avatar = fileName;
                objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/Images"), fileName));
            }
            objqlbhEntities.Entry(objProduct).State = EntityState.Modified;
            objqlbhEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}