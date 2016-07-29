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
    public class L_TaskStatusController : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: L_TaskStatus
        public ActionResult Index()
        {
            return View(db.L_TaskStatuses.OrderByDescending(e => e.ID).ToList());
        }

        // GET: L_TaskStatus/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_TaskStatus l_TaskStatus = db.L_TaskStatuses.Find(id);
            if (l_TaskStatus == null)
            {
                return HttpNotFound();
            }
            return View(l_TaskStatus);
        }

        // GET: L_TaskStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: L_TaskStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Value,Description,Created,Modified")] L_TaskStatus l_TaskStatus)
        {
            if (ModelState.IsValid)
            {
                db.L_TaskStatuses.Add(l_TaskStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(l_TaskStatus);
        }

        // GET: L_TaskStatus/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_TaskStatus l_TaskStatus = db.L_TaskStatuses.Find(id);
            if (l_TaskStatus == null)
            {
                return HttpNotFound();
            }
            return View(l_TaskStatus);
        }

        // POST: L_TaskStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Value,Description,Created,Modified")] L_TaskStatus l_TaskStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(l_TaskStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(l_TaskStatus);
        }

        // GET: L_TaskStatus/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_TaskStatus l_TaskStatus = db.L_TaskStatuses.Find(id);
            if (l_TaskStatus == null)
            {
                return HttpNotFound();
            }
            return View(l_TaskStatus);
        }

        // POST: L_TaskStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            L_TaskStatus l_TaskStatus = db.L_TaskStatuses.Find(id);
            db.L_TaskStatuses.Remove(l_TaskStatus);
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
