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
    public class L_JobController : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: L_Job
        public ActionResult Index()
        {
            return View(db.L_Jobs.OrderByDescending(e => e.ID).ToList());
        }

        // GET: L_Job/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_Job l_Job = db.L_Jobs.Find(id);
            if (l_Job == null)
            {
                return HttpNotFound();
            }
            return View(l_Job);
        }

        // GET: L_Job/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: L_Job/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Value,Description,Created,Modified")] L_Job l_Job)
        {
            if (ModelState.IsValid)
            {
                db.L_Jobs.Add(l_Job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(l_Job);
        }

        // GET: L_Job/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_Job l_Job = db.L_Jobs.Find(id);
            if (l_Job == null)
            {
                return HttpNotFound();
            }
            return View(l_Job);
        }

        // POST: L_Job/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Value,Description,Created,Modified")] L_Job l_Job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(l_Job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(l_Job);
        }

        // GET: L_Job/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_Job l_Job = db.L_Jobs.Find(id);
            if (l_Job == null)
            {
                return HttpNotFound();
            }
            return View(l_Job);
        }

        // POST: L_Job/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            L_Job l_Job = db.L_Jobs.Find(id);
            db.L_Jobs.Remove(l_Job);
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
