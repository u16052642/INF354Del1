using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using _354_Project.Models;

namespace _354_Project.Controllers.BAckEND
{
    public class TreatmentsController : Controller
    {
        private Lung_LifeEntities2 db = new Lung_LifeEntities2();

        // GET: Treatments
        public ActionResult Index()
        {
            var treatments = db.Treatments.Include(t => t.Treatment_Type);
            return View(treatments.ToList());
        }

        // GET: Treatments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treatment treatment = db.Treatments.Find(id);
            if (treatment == null)
            {
                return HttpNotFound();
            }
            return View(treatment);
        }

        // GET: Treatments/Create
        public ActionResult Create()
        {
            ViewBag.Treat_Type_ID = new SelectList(db.Treatment_Type, "Treat_Type_ID", "Treat_Type_Name");
            return View();
        }

        // POST: Treatments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Treat_ID,Treat_Type_ID,Treat_Name,Treat_Description,Treat_Image")] Treatment treatment)
        {
            try {
                if (ModelState.IsValid)
                {
                    db.Treatments.Add(treatment);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch { }

            ViewBag.Treat_Type_ID = new SelectList(db.Treatment_Type, "Treat_Type_ID", "Treat_Type_Name", treatment.Treat_Type_ID);

            return View(treatment);
        }

        // GET: Treatments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treatment treatment = db.Treatments.Find(id);
            if (treatment == null)
            {
                return HttpNotFound();
            }
            return View(treatment);
        }

        // POST: Treatments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Treat_ID,Treat_Type_ID,Treat_Name,Treat_Description,Treat_Image")] Treatment treatment)
        {
            try {
                if (ModelState.IsValid)
                {
                    db.Entry(treatment).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch { }
            return View(treatment);
        }

        // GET: Treatments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treatment treatment = db.Treatments.Find(id);
            if (treatment == null)
            {
                return HttpNotFound();
            }
            return View(treatment);
        }

        // POST: Treatments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try {
                Treatment treatment = db.Treatments.Find(id);
                db.Treatments.Remove(treatment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch { return RedirectToAction("Index"); }
        }

        public ActionResult Search(string searchBy, string search)
        {
            try
            {
                if (searchBy == "Treat_Name")
                {
                    return View(db.Treatments.Where(c => c.Treat_Name.Contains(search) || search == null).ToList());
                }
                else
                {
                    return View(db.Treatments.Where(c => c.Treat_Description.Contains(search) || search == null).ToList());
                }
            }
            catch
            { return View(db.Treatments.Where(c => c.Treat_Description.Contains(search) || search == null).ToList()); }

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
