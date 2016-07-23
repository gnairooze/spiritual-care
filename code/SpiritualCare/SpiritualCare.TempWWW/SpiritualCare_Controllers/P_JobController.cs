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
    public class P_JobController : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: P_Job
        public ActionResult Index()
        {
            return View(db.P_Jobs.ToList());
        }

        // GET: P_Job/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Job p_Job = db.P_Jobs.Find(id);
            if (p_Job == null)
            {
                return HttpNotFound();
            }
            return View(p_Job);
        }

        // GET: P_Job/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: P_Job/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Profession,JobTitle,Employer,Comment,Created,Modified")] P_Job p_Job)
        {
            if (ModelState.IsValid)
            {
                db.P_Jobs.Add(p_Job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(p_Job);
        }

        // GET: P_Job/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Job p_Job = db.P_Jobs.Find(id);
            if (p_Job == null)
            {
                return HttpNotFound();
            }
            return View(p_Job);
        }

        // POST: P_Job/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Profession,JobTitle,Employer,Comment,Created,Modified")] P_Job p_Job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_Job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p_Job);
        }

        // GET: P_Job/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Job p_Job = db.P_Jobs.Find(id);
            if (p_Job == null)
            {
                return HttpNotFound();
            }
            return View(p_Job);
        }

        // POST: P_Job/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            P_Job p_Job = db.P_Jobs.Find(id);
            db.P_Jobs.Remove(p_Job);
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
