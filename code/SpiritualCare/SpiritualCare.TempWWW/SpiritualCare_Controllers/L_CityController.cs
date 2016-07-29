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
    public class L_CityController : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: L_City
        public ActionResult Index()
        {
            return View(db.L_Cities.OrderByDescending(e => e.ID).ToList());
        }

        // GET: L_City/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_City l_City = db.L_Cities.Find(id);
            if (l_City == null)
            {
                return HttpNotFound();
            }
            return View(l_City);
        }

        // GET: L_City/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: L_City/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Value,Description,Created,Modified")] L_City l_City)
        {
            if (ModelState.IsValid)
            {
                db.L_Cities.Add(l_City);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(l_City);
        }

        // GET: L_City/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_City l_City = db.L_Cities.Find(id);
            if (l_City == null)
            {
                return HttpNotFound();
            }
            return View(l_City);
        }

        // POST: L_City/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Value,Description,Created,Modified")] L_City l_City)
        {
            if (ModelState.IsValid)
            {
                db.Entry(l_City).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(l_City);
        }

        // GET: L_City/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_City l_City = db.L_Cities.Find(id);
            if (l_City == null)
            {
                return HttpNotFound();
            }
            return View(l_City);
        }

        // POST: L_City/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            L_City l_City = db.L_Cities.Find(id);
            db.L_Cities.Remove(l_City);
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
