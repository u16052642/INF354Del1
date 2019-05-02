using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _354_Project.Models;

namespace _354_Project.Controllers.BAckEND
{
    public class PreventionsController : Controller
    {
        private Lung_LifeEntities2 db = new Lung_LifeEntities2();

        // GET: Preventions
        public ActionResult Index()
        {
            var preventions = db.Preventions.Include(p => p.CancerType);
            return View(preventions.ToList());
        }

        // GET: Preventions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prevention prevention = db.Preventions.Find(id);
            if (prevention == null)
            {
                return HttpNotFound();
            }
            return View(prevention);
        }

        // GET: Preventions/Create
        public ActionResult Create()
        {
            ViewBag.CancerType_ID = new SelectList(db.CancerTypes, "CancerType_ID", "CancerType_Name");
            return View();
        }

        // POST: Preventions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Prev_ID,CancerType_ID,Prev_Name,Prev_Description")] Prevention prevention)
        {
            try {
                if (ModelState.IsValid)
                {
                    db.Preventions.Add(prevention);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch { }

            ViewBag.CancerType_ID = new SelectList(db.CancerTypes, "CancerType_ID", "CancerType_Name", prevention.CancerType_ID);
            return View(prevention);
        }

        // GET: Preventions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prevention prevention = db.Preventions.Find(id);
            if (prevention == null)
            {
                return HttpNotFound();
            }
            ViewBag.CancerType_ID = new SelectList(db.CancerTypes, "CancerType_ID", "CancerType_Name", prevention.CancerType_ID);
            return View(prevention);
        }

        // POST: Preventions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Prev_ID,CancerType_ID,Prev_Name,Prev_Description")] Prevention prevention)
        {
            try {
                if (ModelState.IsValid)
                {
                    db.Entry(prevention).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch { }

            ViewBag.CancerType_ID = new SelectList(db.CancerTypes, "CancerType_ID", "CancerType_Name", prevention.CancerType_ID);
            return View(prevention);
        }

        // GET: Preventions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prevention prevention = db.Preventions.Find(id);
            if (prevention == null)
            {
                return HttpNotFound();
            }
            return View(prevention);
        }

        // POST: Preventions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try {
                Prevention prevention = db.Preventions.Find(id);
                db.Preventions.Remove(prevention);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch { return RedirectToAction("Index"); }
        }

        public ActionResult Search(string searchBy, string search)
        {
            if (searchBy == "Preventions")
            {
                return View(db.Preventions.Where(c => c.Prev_Name.Contains(search) || search == null).ToList());
            }
            else
            {
                return View(db.Preventions.Where(c => c.Prev_Description.Contains(search) || search == null).ToList());
            }

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
