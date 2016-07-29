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
    public class L_CountryController : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: L_Country
        public ActionResult Index()
        {
            return View(db.L_Countries.OrderByDescending(e => e.ID).ToList());
        }

        // GET: L_Country/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_Country l_Country = db.L_Countries.Find(id);
            if (l_Country == null)
            {
                return HttpNotFound();
            }
            return View(l_Country);
        }

        // GET: L_Country/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: L_Country/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Value,Description,Created,Modified")] L_Country l_Country)
        {
            if (ModelState.IsValid)
            {
                db.L_Countries.Add(l_Country);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(l_Country);
        }

        // GET: L_Country/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_Country l_Country = db.L_Countries.Find(id);
            if (l_Country == null)
            {
                return HttpNotFound();
            }
            return View(l_Country);
        }

        // POST: L_Country/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Value,Description,Created,Modified")] L_Country l_Country)
        {
            if (ModelState.IsValid)
            {
                db.Entry(l_Country).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(l_Country);
        }

        // GET: L_Country/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_Country l_Country = db.L_Countries.Find(id);
            if (l_Country == null)
            {
                return HttpNotFound();
            }
            return View(l_Country);
        }

        // POST: L_Country/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            L_Country l_Country = db.L_Countries.Find(id);
            db.L_Countries.Remove(l_Country);
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
