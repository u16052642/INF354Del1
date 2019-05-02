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
    public class CancerType_SymptomController : Controller
    {
        private Lung_LifeEntities2 db = new Lung_LifeEntities2();

        // GET: CancerType_Symptom
        public ActionResult Index()
        {
            var cancerType_Symptom = db.CancerType_Symptom.Include(c => c.Symptom).Include(c => c.CancerType);
            return View(cancerType_Symptom.ToList());
        }

        // GET: CancerType_Symptom/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CancerType_Symptom cancerType_Symptom = db.CancerType_Symptom.Find(id);
            if (cancerType_Symptom == null)
            {
                return HttpNotFound();
            }
            return View(cancerType_Symptom);
        }

        // GET: CancerType_Symptom/Create
        public ActionResult Create()
        {
            ViewBag.Sym_ID = new SelectList(db.Symptoms, "Sym_ID", "Sym_Name");
            ViewBag.CancerType_ID = new SelectList(db.CancerTypes, "CancerType_ID", "CancerType_Name");
            return View();
        }

        // POST: CancerType_Symptom/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cancer_Sym_ID,CancerType_ID,Sym_ID,Cancer_Sym_Name,Cancer_Sym_Description")] CancerType_Symptom cancerType_Symptom)
        {
            try {
                if (ModelState.IsValid)
                {
                    db.CancerType_Symptom.Add(cancerType_Symptom);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch { }

            ViewBag.Sym_ID = new SelectList(db.Symptoms, "Sym_ID", "Sym_Name", cancerType_Symptom.Sym_ID);
            ViewBag.CancerType_ID = new SelectList(db.CancerTypes, "CancerType_ID", "CancerType_Name", cancerType_Symptom.CancerType_ID);
            return View(cancerType_Symptom);
        }

        // GET: CancerType_Symptom/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CancerType_Symptom cancerType_Symptom = db.CancerType_Symptom.Find(id);
            if (cancerType_Symptom == null)
            {
                return HttpNotFound();
            }
            ViewBag.Sym_ID = new SelectList(db.Symptoms, "Sym_ID", "Sym_Name", cancerType_Symptom.Sym_ID);
            ViewBag.CancerType_ID = new SelectList(db.CancerTypes, "CancerType_ID", "CancerType_Name", cancerType_Symptom.CancerType_ID);
            return View(cancerType_Symptom);
        }

        // POST: CancerType_Symptom/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cancer_Sym_ID,CancerType_ID,Sym_ID,Cancer_Sym_Name,Cancer_Sym_Description")] CancerType_Symptom cancerType_Symptom)
        {
            if (ModelState.IsValid)
            {
                try {
                    db.Entry(cancerType_Symptom).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch { }
            }
            ViewBag.Sym_ID = new SelectList(db.Symptoms, "Sym_ID", "Sym_Name", cancerType_Symptom.Sym_ID);
            ViewBag.CancerType_ID = new SelectList(db.CancerTypes, "CancerType_ID", "CancerType_Name", cancerType_Symptom.CancerType_ID);
            return View(cancerType_Symptom);
        }

        // GET: CancerType_Symptom/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CancerType_Symptom cancerType_Symptom = db.CancerType_Symptom.Find(id);
            if (cancerType_Symptom == null)
            {
                return HttpNotFound();
            }
            return View(cancerType_Symptom);
        }

        // POST: CancerType_Symptom/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try {
                CancerType_Symptom cancerType_Symptom = db.CancerType_Symptom.Find(id);
                db.CancerType_Symptom.Remove(cancerType_Symptom);
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
