using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SpiritualCare.Data;
using SpiritualCare.Model.Lookup;

namespace SpiritualCare.TempWWW.SpiritualCare_Controllers
{
    public class L_ContactMeanController : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: L_ContactMean
        public ActionResult Index()
        {
            return View(db.L_ContactMeans.ToList());
        }

        // GET: L_ContactMean/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_ContactMean l_ContactMean = db.L_ContactMeans.Find(id);
            if (l_ContactMean == null)
            {
                return HttpNotFound();
            }
            return View(l_ContactMean);
        }

        // GET: L_ContactMean/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: L_ContactMean/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Value,Description,Created,Modified")] L_ContactMean l_ContactMean)
        {
            if (ModelState.IsValid)
            {
                db.L_ContactMeans.Add(l_ContactMean);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(l_ContactMean);
        }

        // GET: L_ContactMean/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_ContactMean l_ContactMean = db.L_ContactMeans.Find(id);
            if (l_ContactMean == null)
            {
                return HttpNotFound();
            }
            return View(l_ContactMean);
        }

        // POST: L_ContactMean/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Value,Description,Created,Modified")] L_ContactMean l_ContactMean)
        {
            if (ModelState.IsValid)
            {
                db.Entry(l_ContactMean).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(l_ContactMean);
        }

        // GET: L_ContactMean/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_ContactMean l_ContactMean = db.L_ContactMeans.Find(id);
            if (l_ContactMean == null)
            {
                return HttpNotFound();
            }
            return View(l_ContactMean);
        }

        // POST: L_ContactMean/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            L_ContactMean l_ContactMean = db.L_ContactMeans.Find(id);
            db.L_ContactMeans.Remove(l_ContactMean);
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
