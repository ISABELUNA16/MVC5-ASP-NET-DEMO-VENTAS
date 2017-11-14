using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VentasFinal.Models;

namespace VentasFinal.Controllers
{
    public class SupplierProductController : Controller
    {
        private VentasFinalContext db = new VentasFinalContext();

        // GET: /SupplierProduct/
        public ActionResult Index()
        {
            var supplierproducts = db.SupplierProducts.Include(s => s.Product).Include(s => s.Supplier);
            return View(supplierproducts.ToList());
        }

        // GET: /SupplierProduct/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierProduct supplierproduct = db.SupplierProducts.Find(id);
            if (supplierproduct == null)
            {
                return HttpNotFound();
            }
            return View(supplierproduct);
        }

        // GET: /SupplierProduct/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Description");
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "Name");
            return View();
        }

        // POST: /SupplierProduct/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="SupplierProductID,Price,LastBuy,SupplierID,ProductID")] SupplierProduct supplierproduct)
        {
            if (ModelState.IsValid)
            {
                db.SupplierProducts.Add(supplierproduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Description", supplierproduct.ProductID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "Name", supplierproduct.SupplierID);
            return View(supplierproduct);
        }

        // GET: /SupplierProduct/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierProduct supplierproduct = db.SupplierProducts.Find(id);
            if (supplierproduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Description", supplierproduct.ProductID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "Name", supplierproduct.SupplierID);
            return View(supplierproduct);
        }

        // POST: /SupplierProduct/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="SupplierProductID,Price,LastBuy,SupplierID,ProductID")] SupplierProduct supplierproduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplierproduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Description", supplierproduct.ProductID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "Name", supplierproduct.SupplierID);
            return View(supplierproduct);
        }

        // GET: /SupplierProduct/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierProduct supplierproduct = db.SupplierProducts.Find(id);
            if (supplierproduct == null)
            {
                return HttpNotFound();
            }
            return View(supplierproduct);
        }

        // POST: /SupplierProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SupplierProduct supplierproduct = db.SupplierProducts.Find(id);
            db.SupplierProducts.Remove(supplierproduct);
            db.SaveChanges();
            return RedirectToAction("Index");
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
