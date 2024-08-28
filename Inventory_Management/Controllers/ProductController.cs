﻿using Inventory_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory_Management.Controllers
{
    public class ProductController : Controller
    {
        Inventory_managementEntities db = new Inventory_managementEntities();
        // GET: /Product/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(product pro)
        {
            db.products.Add(pro);
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }
        [HttpGet]
        public ActionResult DisplayProduct()
        {
            List<product> list = db.products.OrderByDescending(x => x.id).ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            product pr = db.products.Where(x => x.id == id).SingleOrDefault();
            return View(pr);
        }
        [HttpPost]
        public ActionResult UpdateProduct(int id, product pro)
        {
            product pr = db.products.Where(x => x.id == id).SingleOrDefault();
            pr.product_name = pro.product_name;
            pr.product_quantity = pro.product_quantity;
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }
        [HttpGet]
        public ActionResult ProductDetails( int id)
        {
            product pro = db.products.Where(x => x.id == id).SingleOrDefault();
            return View(pro);
        }
        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            product pro = db.products.Where(x => x.id == id).SingleOrDefault();
            return View(pro);
        }
        [HttpPost]
        public ActionResult DeleteProduct(int id, product pro)
        {
            db.products.Remove(db.products.Where(x=>x.id==id).SingleOrDefault());
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }
	}
}