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
    public class L_ChurchController : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: L_Church
        public ActionResult Index()
        {
            return View(db.L_Churches.OrderByDescending(e => e.ID).ToList());
        }

        // GET: L_Church/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_Church l_Church = db.L_Churches.Find(id);
            if (l_Church == null)
            {
                return HttpNotFound();
            }
            return View(l_Church);
        }

        // GET: L_Church/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: L_Church/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Value,Description,Created,Modified")] L_Church l_Church)
        {
            if (ModelState.IsValid)
            {
                db.L_Churches.Add(l_Church);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(l_Church);
        }

        // GET: L_Church/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_Church l_Church = db.L_Churches.Find(id);
            if (l_Church == null)
            {
                return HttpNotFound();
            }
            return View(l_Church);
        }

        // POST: L_Church/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Value,Description,Created,Modified")] L_Church l_Church)
        {
            if (ModelState.IsValid)
            {
                db.Entry(l_Church).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(l_Church);
        }

        // GET: L_Church/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_Church l_Church = db.L_Churches.Find(id);
            if (l_Church == null)
            {
                return HttpNotFound();
            }
            return View(l_Church);
        }

        // POST: L_Church/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            L_Church l_Church = db.L_Churches.Find(id);
            db.L_Churches.Remove(l_Church);
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
