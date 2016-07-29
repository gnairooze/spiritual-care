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
    public class L_StreetController : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: L_Street
        public ActionResult Index()
        {
            return View(db.L_Streets.OrderByDescending(e => e.ID).ToList());
        }

        // GET: L_Street/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_Street l_Street = db.L_Streets.Find(id);
            if (l_Street == null)
            {
                return HttpNotFound();
            }
            return View(l_Street);
        }

        // GET: L_Street/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: L_Street/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Value,Description,Created,Modified")] L_Street l_Street)
        {
            if (ModelState.IsValid)
            {
                db.L_Streets.Add(l_Street);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(l_Street);
        }

        // GET: L_Street/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_Street l_Street = db.L_Streets.Find(id);
            if (l_Street == null)
            {
                return HttpNotFound();
            }
            return View(l_Street);
        }

        // POST: L_Street/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Value,Description,Created,Modified")] L_Street l_Street)
        {
            if (ModelState.IsValid)
            {
                db.Entry(l_Street).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(l_Street);
        }

        // GET: L_Street/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_Street l_Street = db.L_Streets.Find(id);
            if (l_Street == null)
            {
                return HttpNotFound();
            }
            return View(l_Street);
        }

        // POST: L_Street/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            L_Street l_Street = db.L_Streets.Find(id);
            db.L_Streets.Remove(l_Street);
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
