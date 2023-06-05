using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using lab_4_ASP_NET_ProductionSystem_NET_Framework.Models;

namespace lab_4_ASP_NET_ProductionSystem_NET_Framework.Controllers
{
    public class RecipesController : Controller
    {
        private MainDbContext db = new MainDbContext();

        // GET: Recipes
        public ActionResult Index()
        {
            return View(db.Recipes.ToList());
        }

        // GET: Recipes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // GET: Recipes/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Name")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Recipes.Add(recipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipe recipe = db.Recipes.Find(id);
            foreach (var u in db.Used_in.Where(u => u.Recipe_Id == recipe.Id))
            {
                db.Used_in.Remove(u);
            }
            foreach (var m in db.Production_machines.Where(m => m.Recipe_Id == recipe.Id))
            {
                m.Recipe_Id = 0;
            }
            db.Recipes.Remove(recipe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CreateUse(int Recipe_Id)
        {
            if (Recipe_Id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Use_in use_in = new Use_in();
            use_in.Recipe_Id = Recipe_Id;
            if (use_in == null)
            {
                return HttpNotFound();
            }
            use_in.Recipe = db.Recipes.Find(use_in.Recipe_Id);
            SelectList Recipes = new SelectList(db.Recipes, "Id", "Name");
            ViewBag.Recipes = Recipes;
            SelectList Types_of_products = new SelectList(db.Types_of_products, "Id", "Name");
            ViewBag.Types_of_products = Types_of_products;
            return View(use_in);
        }

        [HttpPost]
        public ActionResult CreateUse(Use_in use_in)
        {
            if (use_in.Recipe_Id != 0)
            {
                use_in.Recipe = db.Recipes.Find(use_in.Recipe_Id);
                use_in.Type_of_product = db.Types_of_products.Find(use_in.Type_of_product_Id);
                db.Used_in.Add(use_in);
                db.SaveChanges();
                return RedirectToAction($"Details/{use_in.Recipe_Id}");
            }
            SelectList Recipes = new SelectList(db.Recipes, "Id", "Name");
            ViewBag.Recipes = Recipes;
            SelectList Types_of_products = new SelectList(db.Types_of_products, "Id", "Name");
            ViewBag.Types_of_products = Types_of_products;
            return View(use_in);
        }

        public ActionResult DeleteUse(int id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            Use_in use_in = db.Used_in.Find(id);
            if (use_in != null)
            {
                db.Used_in.Remove(use_in);
                db.SaveChanges();
            }
            return RedirectToAction($"Details/{use_in.Recipe_Id}");
        }

        public ActionResult EditUse(int id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            Use_in use_in = db.Used_in.Find(id);
            if (use_in != null)
            {
                SelectList Types_of_products = new SelectList(db.Types_of_products, "Id", "Name", use_in.Type_of_product_Id);
                ViewBag.Types_of_products = Types_of_products;
                return View(use_in);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditUse(Use_in use_in)
        {
            db.Used_in.Remove(db.Used_in.Find(use_in.Id));
            use_in.Type_of_product = db.Types_of_products.Find(use_in.Type_of_product_Id);
            use_in.Recipe = db.Recipes.Find(use_in.Recipe_Id);
            //db.Entry(use_in).State = EntityState.Modified;
            db.Used_in.Add(use_in);
            db.SaveChanges();
            return RedirectToAction($"Details/{use_in.Recipe_Id}");
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
