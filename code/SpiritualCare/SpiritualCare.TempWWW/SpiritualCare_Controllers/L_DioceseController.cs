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
    public class L_DioceseController : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: L_Diocese
        public ActionResult Index()
        {
            return View(db.L_Dioceses.ToList());
        }

        // GET: L_Diocese/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_Diocese l_Diocese = db.L_Dioceses.Find(id);
            if (l_Diocese == null)
            {
                return HttpNotFound();
            }
            return View(l_Diocese);
        }

        // GET: L_Diocese/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: L_Diocese/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Value,Description,Created,Modified")] L_Diocese l_Diocese)
        {
            if (ModelState.IsValid)
            {
                db.L_Dioceses.Add(l_Diocese);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(l_Diocese);
        }

        // GET: L_Diocese/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_Diocese l_Diocese = db.L_Dioceses.Find(id);
            if (l_Diocese == null)
            {
                return HttpNotFound();
            }
            return View(l_Diocese);
        }

        // POST: L_Diocese/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Value,Description,Created,Modified")] L_Diocese l_Diocese)
        {
            if (ModelState.IsValid)
            {
                db.Entry(l_Diocese).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(l_Diocese);
        }

        // GET: L_Diocese/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_Diocese l_Diocese = db.L_Dioceses.Find(id);
            if (l_Diocese == null)
            {
                return HttpNotFound();
            }
            return View(l_Diocese);
        }

        // POST: L_Diocese/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            L_Diocese l_Diocese = db.L_Dioceses.Find(id);
            db.L_Dioceses.Remove(l_Diocese);
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
