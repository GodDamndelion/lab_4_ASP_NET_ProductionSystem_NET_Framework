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
    public class Production_machineController : Controller
    {
        private MainDbContext db = new MainDbContext();

        static int old_production_machine_id;

        // GET: Production_machine
        public ActionResult Index()
        {
            //var Production_machines = db.Production_machines.Include(m => m.Recipe); // Да здравствует virtual!!! (aka ленивая подгрузка)
            return View(db.Production_machines.ToList());
        }

        // GET: Production_machine/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Production_machine production_machine = db.Production_machines.Find(id);
            if (production_machine == null)
            {
                return HttpNotFound();
            }
            return View(production_machine);
        }

        // GET: Production_machine/Create
        public ActionResult Create()
        {
            SelectList Recipes = new SelectList(db.Recipes, "Id", "Name");
            ViewBag.Recipes = Recipes;
            return View();
        }

        
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Name,Recipe_Id")] Production_machine production_machine)
        {
            if (ModelState.IsValid)
            {
                production_machine.Recipe = db.Recipes.Find(production_machine.Recipe_Id);
                db.Production_machines.Add(production_machine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(production_machine);
        }

        // GET: Production_machine/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Production_machine production_machine = db.Production_machines.Find(id);
            if (production_machine == null)
            {
                return HttpNotFound();
            }
            SelectList Recipes = new SelectList(db.Recipes, "Id", "Name", production_machine.Recipe_Id);
            ViewBag.Recipes = Recipes;
            //db.Production_machines.Remove(production_machine);
            //db.SaveChanges();
            //old_production_machine = production_machine;
            //old_production_machine = new Production_machine();
            old_production_machine_id = production_machine.Id;
            //old_production_machine.Name = production_machine.Name;
            //old_production_machine.Recipe_Id = production_machine.Recipe_Id;
            //old_production_machine.Recipe = production_machine.Recipe;
            return View(production_machine);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name,Recipe_Id")] Production_machine production_machine)
        {
            if (ModelState.IsValid)
            {
                db.Production_machines.Remove(db.Production_machines.Find(old_production_machine_id));
                production_machine.Recipe = db.Recipes.Find(production_machine.Recipe_Id);
                //db.Entry(production_machine).State = EntityState.Modified;
                //db.Production_machines.Remove(old_production_machine);
                db.Production_machines.Add(production_machine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(production_machine);
        }

        // GET: Production_machine/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Production_machine production_machine = db.Production_machines.Find(id);
            if (production_machine == null)
            {
                return HttpNotFound();
            }
            return View(production_machine);
        }

        // POST: Production_machine/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Production_machine production_machine = db.Production_machines.Find(id);
            db.Production_machines.Remove(production_machine);
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
