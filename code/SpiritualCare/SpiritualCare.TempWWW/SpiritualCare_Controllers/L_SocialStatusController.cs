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
    public class L_SocialStatusController : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: L_SocialStatus
        public ActionResult Index()
        {
            return View(db.L_SocialStatuses.ToList());
        }

        // GET: L_SocialStatus/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_SocialStatus l_SocialStatus = db.L_SocialStatuses.Find(id);
            if (l_SocialStatus == null)
            {
                return HttpNotFound();
            }
            return View(l_SocialStatus);
        }

        // GET: L_SocialStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: L_SocialStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Value,Description,Created,Modified")] L_SocialStatus l_SocialStatus)
        {
            if (ModelState.IsValid)
            {
                db.L_SocialStatuses.Add(l_SocialStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(l_SocialStatus);
        }

        // GET: L_SocialStatus/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_SocialStatus l_SocialStatus = db.L_SocialStatuses.Find(id);
            if (l_SocialStatus == null)
            {
                return HttpNotFound();
            }
            return View(l_SocialStatus);
        }

        // POST: L_SocialStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Value,Description,Created,Modified")] L_SocialStatus l_SocialStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(l_SocialStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(l_SocialStatus);
        }

        // GET: L_SocialStatus/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_SocialStatus l_SocialStatus = db.L_SocialStatuses.Find(id);
            if (l_SocialStatus == null)
            {
                return HttpNotFound();
            }
            return View(l_SocialStatus);
        }

        // POST: L_SocialStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            L_SocialStatus l_SocialStatus = db.L_SocialStatuses.Find(id);
            db.L_SocialStatuses.Remove(l_SocialStatus);
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
