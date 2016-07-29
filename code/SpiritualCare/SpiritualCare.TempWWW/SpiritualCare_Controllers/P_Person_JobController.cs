using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SpiritualCare.Data;
using SpiritualCare.Model.Person;

namespace SpiritualCare.TempWWW.SpiritualCare_Controllers
{
    public class P_Person_JobController : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: P_Person_Job
        public ActionResult Index()
        {
            return View(db.P_Person_Jobs.OrderByDescending(e => e.ID).ToList());
        }

        // GET: P_Person_Job/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Person_Job p_Person_Job = db.P_Person_Jobs.Find(id);
            if (p_Person_Job == null)
            {
                return HttpNotFound();
            }
            return View(p_Person_Job);
        }

        // GET: P_Person_Job/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: P_Person_Job/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Person_ID,Job_ID,Created,Modified")] P_Person_Job p_Person_Job)
        {
            if (ModelState.IsValid)
            {
                db.P_Person_Jobs.Add(p_Person_Job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(p_Person_Job);
        }

        // GET: P_Person_Job/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Person_Job p_Person_Job = db.P_Person_Jobs.Find(id);
            if (p_Person_Job == null)
            {
                return HttpNotFound();
            }
            return View(p_Person_Job);
        }

        // POST: P_Person_Job/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Person_ID,Job_ID,Created,Modified")] P_Person_Job p_Person_Job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_Person_Job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p_Person_Job);
        }

        // GET: P_Person_Job/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Person_Job p_Person_Job = db.P_Person_Jobs.Find(id);
            if (p_Person_Job == null)
            {
                return HttpNotFound();
            }
            return View(p_Person_Job);
        }

        // POST: P_Person_Job/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            P_Person_Job p_Person_Job = db.P_Person_Jobs.Find(id);
            db.P_Person_Jobs.Remove(p_Person_Job);
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
