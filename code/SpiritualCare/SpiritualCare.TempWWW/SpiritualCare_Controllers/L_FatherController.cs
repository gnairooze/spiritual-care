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
    public class L_FatherController : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: L_Father
        public ActionResult Index()
        {
            return View(db.L_Fathers.OrderByDescending(e => e.ID).ToList());
        }

        // GET: L_Father/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_Father l_Father = db.L_Fathers.Find(id);
            if (l_Father == null)
            {
                return HttpNotFound();
            }
            return View(l_Father);
        }

        // GET: L_Father/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: L_Father/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Value,Description,Created,Modified")] L_Father l_Father)
        {
            if (ModelState.IsValid)
            {
                db.L_Fathers.Add(l_Father);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(l_Father);
        }

        // GET: L_Father/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_Father l_Father = db.L_Fathers.Find(id);
            if (l_Father == null)
            {
                return HttpNotFound();
            }
            return View(l_Father);
        }

        // POST: L_Father/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Value,Description,Created,Modified")] L_Father l_Father)
        {
            if (ModelState.IsValid)
            {
                db.Entry(l_Father).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(l_Father);
        }

        // GET: L_Father/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_Father l_Father = db.L_Fathers.Find(id);
            if (l_Father == null)
            {
                return HttpNotFound();
            }
            return View(l_Father);
        }

        // POST: L_Father/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            L_Father l_Father = db.L_Fathers.Find(id);
            db.L_Fathers.Remove(l_Father);
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
