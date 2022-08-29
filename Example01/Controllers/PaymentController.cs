using Example01.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Example01.Models;

namespace WebsiteBanHang.Controllers
{
    public class PaymentController : Controller
    {
        objqlbhEntities objqlbhEntities = new objqlbhEntities();
        // GET: Payment
        public ActionResult Index()
        {
            if (Session["idUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var lstCart = (List<CartModel>)Session["cart"];
                //gan du lieu cho Order
                Order objOrder = new Order();
                objOrder.Name = "DonHang" + DateTime.Now.ToString("ddMMyyyyHHmmss");
                objOrder.UserId = int.Parse(Session["idUser"].ToString());
                objOrder.CreatedOnUtc = DateTime.Now;
                objOrder.Status = 1;
                objqlbhEntities.Orders.Add(objOrder);
                //luu vao bang Order
                objqlbhEntities.SaveChanges();
                //Lay OrderId vua tao luu vao bang OrderDetail
                int intOrderId = objOrder.Id;

                List<OrderDetail> lstOrderDetail = new List<OrderDetail>();
                foreach (var item in lstCart)
                {
                    OrderDetail obj = new OrderDetail();
                    obj.Quantity = item.Quantity;
                    obj.OrderId = intOrderId;
                    obj.ProductId = item.Product.Id;
                    lstOrderDetail.Add(obj);
                }
                objqlbhEntities.OrderDetails.AddRange(lstOrderDetail);
                objqlbhEntities.SaveChanges();
            }
            return View();
        }
    }
}
