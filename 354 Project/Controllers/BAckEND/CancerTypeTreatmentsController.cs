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
    public class CancerTypeTreatmentsController : Controller
    {
        private Lung_LifeEntities2 db = new Lung_LifeEntities2();

        // GET: CancerTypeTreatments
        public ActionResult Index()
        {
            var cancerTypeTreatments = db.CancerTypeTreatments.Include(c => c.CancerType).Include(c => c.Treatment);
            return View(cancerTypeTreatments.ToList());
        }

        // GET: CancerTypeTreatments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CancerTypeTreatment cancerTypeTreatment = db.CancerTypeTreatments.Find(id);
            if (cancerTypeTreatment == null)
            {
                return HttpNotFound();
            }
            return View(cancerTypeTreatment);
        }

        // GET: CancerTypeTreatments/Create
        public ActionResult Create()
        {
            ViewBag.CancerType_ID = new SelectList(db.CancerTypes, "CancerType_ID", "CancerType_Name");
            ViewBag.Treat_ID = new SelectList(db.Treatments, "Treat_ID", "Treat_Name");
            return View();
        }

        // POST: CancerTypeTreatments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cancer_Treat_ID,Treat_Type_ID,CancerType_ID,Cancer_Treat_Image,Treat_ID")] CancerTypeTreatment cancerTypeTreatment)
        {
            try {
                if (ModelState.IsValid)
                {
                    db.CancerTypeTreatments.Add(cancerTypeTreatment);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch { }

            ViewBag.CancerType_ID = new SelectList(db.CancerTypes, "CancerType_ID", "CancerType_Name", cancerTypeTreatment.CancerType_ID);
            ViewBag.Treat_ID = new SelectList(db.Treatments, "Treat_ID", "Treat_Name", cancerTypeTreatment.Treat_ID);
            return View(cancerTypeTreatment);
        }

        // GET: CancerTypeTreatments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CancerTypeTreatment cancerTypeTreatment = db.CancerTypeTreatments.Find(id);
            if (cancerTypeTreatment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CancerType_ID = new SelectList(db.CancerTypes, "CancerType_ID", "CancerType_Name", cancerTypeTreatment.CancerType_ID);
            ViewBag.Treat_ID = new SelectList(db.Treatments, "Treat_ID", "Treat_Name", cancerTypeTreatment.Treat_ID);
            return View(cancerTypeTreatment);
        }

        // POST: CancerTypeTreatments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cancer_Treat_ID,Treat_Type_ID,CancerType_ID,Cancer_Treat_Image,Treat_ID")] CancerTypeTreatment cancerTypeTreatment)
        {
            try {
                if (ModelState.IsValid)
                {
                    db.Entry(cancerTypeTreatment).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch { }

            ViewBag.CancerType_ID = new SelectList(db.CancerTypes, "CancerType_ID", "CancerType_Name", cancerTypeTreatment.CancerType_ID);
            ViewBag.Treat_ID = new SelectList(db.Treatments, "Treat_ID", "Treat_Name", cancerTypeTreatment.Treat_ID);
            return View(cancerTypeTreatment);
        }

        // GET: CancerTypeTreatments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CancerTypeTreatment cancerTypeTreatment = db.CancerTypeTreatments.Find(id);
            if (cancerTypeTreatment == null)
            {
                return HttpNotFound();
            }
            return View(cancerTypeTreatment);
        }

        // POST: CancerTypeTreatments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try {
                CancerTypeTreatment cancerTypeTreatment = db.CancerTypeTreatments.Find(id);
                db.CancerTypeTreatments.Remove(cancerTypeTreatment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch { return RedirectToAction("Index"); }
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
