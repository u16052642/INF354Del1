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
    public class CancerTypesController : Controller
    {
        private Lung_LifeEntities2 db = new Lung_LifeEntities2();

        // GET: CancerTypes
        public ActionResult Index()
        {
            return View(db.CancerTypes.ToList());
        }

        // GET: CancerTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CancerType cancerType = db.CancerTypes.Find(id);
            if (cancerType == null)
            {
                return HttpNotFound();
            }
            return View(cancerType);
        }

        // GET: CancerTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CancerTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CancerType_ID,CancerType_Name,CancerType_Description,CancerType_Image")] CancerType cancerType)
        {
            try {
                if (ModelState.IsValid)
                {
                    db.CancerTypes.Add(cancerType);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch { }

            return View(cancerType);
        }

        // GET: CancerTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CancerType cancerType = db.CancerTypes.Find(id);
            if (cancerType == null)
            {
                return HttpNotFound();
            }
            return View(cancerType);
        }

        // POST: CancerTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CancerType_ID,CancerType_Name,CancerType_Description,CancerType_Image")] CancerType cancerType)
        {
            try {
                if (ModelState.IsValid)
                {
                    db.Entry(cancerType).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch { }
            return View(cancerType);
        }

        // GET: CancerTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CancerType cancerType = db.CancerTypes.Find(id);
            if (cancerType == null)
            {
                return HttpNotFound();
            }
            return View(cancerType);
        }

        // POST: CancerTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try { 
            CancerType cancerType = db.CancerTypes.Find(id);
            db.CancerTypes.Remove(cancerType);
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
