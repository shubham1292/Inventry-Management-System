using Inventory_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory_Management.Controllers
{
    public class PurchaseController : Controller
    {
        Inventory_managementEntities db= new Inventory_managementEntities();
        //
        // GET: /Purchase/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DisplayPurchase()
        {
            List<purchase> list = db.purchases.OrderByDescending(x=> x.id).ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult PurchaseProduct()
        {
            List<string> list = db.products.Select(x => x.product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }
        [HttpPost]
        public ActionResult PurchaseProduct(purchase pur)
        {
            db.purchases.Add(pur);
            db.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            purchase p = db.purchases.Where(x => x.id == id).SingleOrDefault();
            List<string> list = db.products.Select(x => x.product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }
        [HttpPost]
        public ActionResult Edit(int id, purchase pur)
        {
            purchase p = db.purchases.Where(x => x.id == id).SingleOrDefault();
            p.purchase_date = pur.purchase_date;
            p.pruchase_product = pur.pruchase_product;
            p.purchase_quantity = pur.purchase_quantity;
            return RedirectToAction("DisplayPurchase");
        }
	}
}