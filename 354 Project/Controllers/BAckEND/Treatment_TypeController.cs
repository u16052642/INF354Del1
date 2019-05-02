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
    public class Treatment_TypeController : Controller
    {
        private Lung_LifeEntities2 db = new Lung_LifeEntities2();

        // GET: Treatment_Type
        public ActionResult Index()
        {
            return View(db.Treatment_Type.ToList());
        }

        // GET: Treatment_Type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treatment_Type treatment_Type = db.Treatment_Type.Find(id);
            if (treatment_Type == null)
            {
                return HttpNotFound();
            }
            return View(treatment_Type);
        }

        // GET: Treatment_Type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Treatment_Type/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Treat_Type_ID,Treat_Type_Name,Treat_Type_Description")] Treatment_Type treatment_Type)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Treatment_Type.Add(treatment_Type);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch { }

            return View(treatment_Type);
        }

        // GET: Treatment_Type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treatment_Type treatment_Type = db.Treatment_Type.Find(id);
            if (treatment_Type == null)
            {
                return HttpNotFound();
            }
            return View(treatment_Type);
        }

        // POST: Treatment_Type/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Treat_Type_ID,Treat_Type_Name,Treat_Type_Description")] Treatment_Type treatment_Type)
        {
            try {
                if (ModelState.IsValid)
                {

                    db.Entry(treatment_Type).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch { }
            return View(treatment_Type);
        }

        // GET: Treatment_Type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treatment_Type treatment_Type = db.Treatment_Type.Find(id);
            if (treatment_Type == null)
            {
                return HttpNotFound();
            }
            return View(treatment_Type);
        }

        // POST: Treatment_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try {
                Treatment_Type treatment_Type = db.Treatment_Type.Find(id);
                db.Treatment_Type.Remove(treatment_Type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch { return RedirectToAction("Index"); }
        }

        public ActionResult Search(string searchBy, string search)
        {
            if (searchBy == "Treat_Type_Name")
            {
                return View(db.Treatment_Type.Where(c => c.Treat_Type_Name.Contains(search) || search == null).ToList());
            }
            else
            {
                return View(db.Treatment_Type.Where(c => c.Treat_Type_Description.Contains(search) || search == null).ToList());
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
