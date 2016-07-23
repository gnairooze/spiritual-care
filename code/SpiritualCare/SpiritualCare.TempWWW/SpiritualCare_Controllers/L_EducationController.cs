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
    public class L_EducationController : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: L_Education
        public ActionResult Index()
        {
            return View(db.L_EducationKinds.ToList());
        }

        // GET: L_Education/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_Education l_Education = db.L_EducationKinds.Find(id);
            if (l_Education == null)
            {
                return HttpNotFound();
            }
            return View(l_Education);
        }

        // GET: L_Education/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: L_Education/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Value,Description,Created,Modified")] L_Education l_Education)
        {
            if (ModelState.IsValid)
            {
                db.L_EducationKinds.Add(l_Education);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(l_Education);
        }

        // GET: L_Education/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_Education l_Education = db.L_EducationKinds.Find(id);
            if (l_Education == null)
            {
                return HttpNotFound();
            }
            return View(l_Education);
        }

        // POST: L_Education/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Value,Description,Created,Modified")] L_Education l_Education)
        {
            if (ModelState.IsValid)
            {
                db.Entry(l_Education).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(l_Education);
        }

        // GET: L_Education/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_Education l_Education = db.L_EducationKinds.Find(id);
            if (l_Education == null)
            {
                return HttpNotFound();
            }
            return View(l_Education);
        }

        // POST: L_Education/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            L_Education l_Education = db.L_EducationKinds.Find(id);
            db.L_EducationKinds.Remove(l_Education);
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
