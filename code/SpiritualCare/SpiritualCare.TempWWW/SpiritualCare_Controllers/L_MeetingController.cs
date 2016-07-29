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
    public class L_MeetingController : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: L_Meeting
        public ActionResult Index()
        {
            return View(db.L_Meetings.OrderByDescending(e => e.ID).ToList());
        }

        // GET: L_Meeting/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_Meeting l_Meeting = db.L_Meetings.Find(id);
            if (l_Meeting == null)
            {
                return HttpNotFound();
            }
            return View(l_Meeting);
        }

        // GET: L_Meeting/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: L_Meeting/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Value,Description,Created,Modified")] L_Meeting l_Meeting)
        {
            if (ModelState.IsValid)
            {
                db.L_Meetings.Add(l_Meeting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(l_Meeting);
        }

        // GET: L_Meeting/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_Meeting l_Meeting = db.L_Meetings.Find(id);
            if (l_Meeting == null)
            {
                return HttpNotFound();
            }
            return View(l_Meeting);
        }

        // POST: L_Meeting/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Value,Description,Created,Modified")] L_Meeting l_Meeting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(l_Meeting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(l_Meeting);
        }

        // GET: L_Meeting/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_Meeting l_Meeting = db.L_Meetings.Find(id);
            if (l_Meeting == null)
            {
                return HttpNotFound();
            }
            return View(l_Meeting);
        }

        // POST: L_Meeting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            L_Meeting l_Meeting = db.L_Meetings.Find(id);
            db.L_Meetings.Remove(l_Meeting);
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
