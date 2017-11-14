using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VentasFinal.Models;
using VentasFinal.ViewModels;

namespace VentasFinal.Controllers
{
    public class OrdersController : Controller
    {
        VentasFinalContext db = new VentasFinalContext();
        //
        // GET: /Orders/
        [HttpGet]
        public ActionResult NewOrder()
        {
            var orderView =  new OrderView();
            orderView.Customer = new Customer();
            orderView.Employee = new Employee();
            orderView.Products = new List<ProductOrder>();

            Session["orderView"] = orderView;

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FullName");
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullName");

            return View(orderView);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Description");
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(ProductOrder productOrder)
        {
            var orderView = Session["orderView"] as OrderView;
            var productID = int.Parse(Request["ProductID"]);

            if (productID==0)
            {
                 ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Description");
                 ViewBag.Error = "Debe seleccionar un producto";
                 return View(productOrder);
            }

            var product = db.Products.Find(productID);
            if (product==null)
            {
                ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Description");
                 ViewBag.Error = "Producto no existe";
                 return View(productOrder);
            }

            //Evalua si existe un producto seleccionado y hace una suma acumulativa
            productOrder = orderView.Products.Find(p => p.ProductID == productID);
            if (productOrder == null)
            {
                productOrder = new ProductOrder
                {
                    Description = product.Description,
                    Price = product.Price,
                    ProductID = product.ProductID,
                    Quantity = float.Parse(Request["Quantity"])

                };
                orderView.Products.Add(productOrder);
            }
            else
            {
                productOrder.Quantity += float.Parse(Request["Quantity"]);
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FullName");
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullName");

            return View("NewOrder", orderView);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
	}
}