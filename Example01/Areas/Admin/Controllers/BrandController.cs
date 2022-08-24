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

    public class BrandController : Controller
    {
        objqlbhEntities objqlbhEntities = new objqlbhEntities();

        // GET: Admin/Brand
        public ActionResult Index()
        {
            var lstBrand = objqlbhEntities.Brands.ToList();
            return View(lstBrand);
        }
        [HttpGet]
        public ActionResult Create()
        {
           
            return View();

        }

        [HttpPost]
        public ActionResult Create(Brand objBrand)
        {

           
            if (ModelState.IsValid)
            {
                try
                {
                    if (objBrand.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objBrand.ImageUpload.FileName);
                        string extension = Path.GetExtension(objBrand.ImageUpload.FileName);
                        fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                        objBrand.Avatar = fileName;
                        objBrand.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items"), fileName));
                    }
                    objBrand.CreateOnUtc = DateTime.Now;
                    objqlbhEntities.Brands.Add(objBrand);
                    objqlbhEntities.SaveChanges();


                    return RedirectToAction("Index");

                }
                catch
                {
                    return RedirectToAction("Index");
                }
            }
            return View(objBrand);
        }
        public ActionResult Details(int id)
        {
            var lstBrand = objqlbhEntities.Brands.Where(n => n.Id == id).FirstOrDefault();

            return View(lstBrand);

        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objBrand = objqlbhEntities.Brands.Where(n => n.Id == id).FirstOrDefault();

            return View(objBrand);

        }
        [HttpPost]
        public ActionResult Delete(Brand objBr)
        {
            var objBrand = objqlbhEntities.Brands.Where(n => n.Id == objBr.Id).FirstOrDefault();


            objqlbhEntities.Brands.Remove(objBrand);
            objqlbhEntities.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objBrand = objqlbhEntities.Brands.Where(n => n.Id == id).FirstOrDefault();

            return View(objBrand);

        }
        [HttpPost]
        public ActionResult Edit(Category objBrand, FormCollection form)
        {
            if (objBrand.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objBrand.ImageUpload.FileName);
                string extension = Path.GetExtension(objBrand.ImageUpload.FileName);
                fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                objBrand.Avatar = fileName;
                objBrand.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items"), fileName));
            }
            else
            {
                objBrand.Avatar = form["oldimage"];
                objqlbhEntities.Entry(objBrand).State = EntityState.Modified;
                objBrand.UpdatedOnUtc = DateTime.Now;
                objqlbhEntities.SaveChanges();


            }
            objqlbhEntities.Entry(objBrand).State = EntityState.Modified;
            objBrand.UpdatedOnUtc = DateTime.Now;
            objqlbhEntities.SaveChanges();


            return RedirectToAction("Index");

        }
    }
}