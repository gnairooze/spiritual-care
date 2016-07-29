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
    public class P_Person_Actual_MeetingController : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: P_Person_Actual_Meeting
        public ActionResult Index()
        {
            return View(db.P_Person_Actual_Meetings.OrderByDescending(e => e.ID).ToList());
        }

        // GET: P_Person_Actual_Meeting/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Person_Actual_Meeting p_Person_Actual_Meeting = db.P_Person_Actual_Meetings.Find(id);
            if (p_Person_Actual_Meeting == null)
            {
                return HttpNotFound();
            }
            return View(p_Person_Actual_Meeting);
        }

        // GET: P_Person_Actual_Meeting/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: P_Person_Actual_Meeting/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Person_ID,Church,MeetingName,Comment,Created,Modified")] P_Person_Actual_Meeting p_Person_Actual_Meeting)
        {
            if (ModelState.IsValid)
            {
                db.P_Person_Actual_Meetings.Add(p_Person_Actual_Meeting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(p_Person_Actual_Meeting);
        }

        // GET: P_Person_Actual_Meeting/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Person_Actual_Meeting p_Person_Actual_Meeting = db.P_Person_Actual_Meetings.Find(id);
            if (p_Person_Actual_Meeting == null)
            {
                return HttpNotFound();
            }
            return View(p_Person_Actual_Meeting);
        }

        // POST: P_Person_Actual_Meeting/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Person_ID,Church,MeetingName,Comment,Created,Modified")] P_Person_Actual_Meeting p_Person_Actual_Meeting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_Person_Actual_Meeting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p_Person_Actual_Meeting);
        }

        // GET: P_Person_Actual_Meeting/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Person_Actual_Meeting p_Person_Actual_Meeting = db.P_Person_Actual_Meetings.Find(id);
            if (p_Person_Actual_Meeting == null)
            {
                return HttpNotFound();
            }
            return View(p_Person_Actual_Meeting);
        }

        // POST: P_Person_Actual_Meeting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            P_Person_Actual_Meeting p_Person_Actual_Meeting = db.P_Person_Actual_Meetings.Find(id);
            db.P_Person_Actual_Meetings.Remove(p_Person_Actual_Meeting);
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
