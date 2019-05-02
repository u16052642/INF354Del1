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
    public class ResourcesController : Controller
    {
        private Lung_LifeEntities2 db = new Lung_LifeEntities2();

        // GET: Resources
        public ActionResult Index()
        {
            var resources = db.Resources.Include(r => r.CancerType);
            return View(resources.ToList());
        }

        // GET: Resources/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = db.Resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // GET: Resources/Create
        public ActionResult Create()
        {
            ViewBag.CancerType_ID = new SelectList(db.CancerTypes, "CancerType_ID", "CancerType_Name");
            return View();
        }

        // POST: Resources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Res_ID,CancerType_ID,Res_Name,Res_Description,Res_Link,Res_Image")] Resource resource)
        {
            if (ModelState.IsValid)
            {
                db.Resources.Add(resource);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CancerType_ID = new SelectList(db.CancerTypes, "CancerType_ID", "CancerType_Name", resource.CancerType_ID);
            return View(resource);
        }

        // GET: Resources/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = db.Resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            ViewBag.CancerType_ID = new SelectList(db.CancerTypes, "CancerType_ID", "CancerType_Name", resource.CancerType_ID);
            return View(resource);
        }

        // POST: Resources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Res_ID,CancerType_ID,Res_Name,Res_Description,Res_Link,Res_Image")] Resource resource)
        {
            try {
                if (ModelState.IsValid)
                {
                    db.Entry(resource).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch { }
            ViewBag.CancerType_ID = new SelectList(db.CancerTypes, "CancerType_ID", "CancerType_Name", resource.CancerType_ID);
            return View(resource);
        }

        // GET: Resources/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = db.Resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // POST: Resources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try {
                Resource resource = db.Resources.Find(id);
                db.Resources.Remove(resource);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch { return RedirectToAction("Index"); }
        }

        public ActionResult Search(string searchBy, string search)
        {
            if (searchBy == "Resources")
            {
                return View(db.Resources.Where(c => c.Res_Name.Contains(search) || search == null).ToList());
            }
            else
            {
                return View(db.Resources.Where(c => c.Res_Description.Contains(search) || search == null).ToList());
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
