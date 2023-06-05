using lab_4_ASP_NET_ProductionSystem_NET_Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace lab_4_ASP_NET_ProductionSystem_NET_Framework.Controllers
{
    public class HomeController : Controller
    {
        MainDbContext db = new MainDbContext();
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Type_of_product);
            return View(products.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            SelectList types_of_products = new SelectList(db.Types_of_products, "Id", "Name");
            ViewBag.Types_of_products = types_of_products;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            Product currentProduct;
            try
            {
                currentProduct = db.Products.First(p => p.Type_Id == product.Type_Id);
                currentProduct.Volume += product.Volume;
                db.SaveChanges();
            }
            catch
            {
                product.Type_of_product = db.Types_of_products.Find(product.Type_Id);
                db.Products.Add(product);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            //var Products = db.Products.Include(p => p.Type_of_product);
            Product product = db.Products.Find(id);
            if (product != null)
            {
                //SelectList types_of_products = new SelectList(db.Types_of_products, "Id", "Name", product.Type_Id);
                //ViewBag.Types_of_products = types_of_products;
                return View(product);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            //var Types_of_products = db.Types_of_products.Include(t => t.Products);
            //product.Type_of_product = db.Types_of_products.Find(product.Type_Id);
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            var Products = db.Products.Include(p => p.Type_of_product);
            Product product = db.Products.Find(id);
            if (product != null)
            {
                return View(product);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            Product product = db.Products.Find(id);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}