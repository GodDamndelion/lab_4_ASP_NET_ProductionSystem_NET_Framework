using lab_4_ASP_NET_ProductionSystem_NET_Framework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab_4_ASP_NET_ProductionSystem_NET_Framework.Controllers
{
    public class Types_of_productsController : Controller
    {
        MainDbContext db = new MainDbContext();
        public ActionResult Index()
        {
            var Types_of_products = db.Types_of_products;
            return View(Types_of_products.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Type_of_product type_of_product)
        {
            if (ModelState.IsValid)
            {
                db.Types_of_products.Add(type_of_product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(type_of_product);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            Type_of_product type_of_product = db.Types_of_products.Find(id);
            if (type_of_product != null)
            {
                return View(type_of_product);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Type_of_product type_of_product)
        {
            db.Entry(type_of_product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            Type_of_product type_of_product = db.Types_of_products.Find(id);
            if (type_of_product != null)
            {
                return View(type_of_product);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            Type_of_product type_of_product = db.Types_of_products.Find(id);
            if (type_of_product != null)
            {
                if (type_of_product.Products == null || !type_of_product.Products.Any())
                    if (type_of_product.Used_in == null || !type_of_product.Used_in.Any())
                    {
                        db.Types_of_products.Remove(type_of_product);
                        db.SaveChanges();
                    }
            }
            return RedirectToAction("Index");
        }
    }
}