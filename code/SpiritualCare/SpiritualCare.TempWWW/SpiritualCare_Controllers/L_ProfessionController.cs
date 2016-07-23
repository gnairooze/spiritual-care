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
    public class L_ProfessionController : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: L_Profession
        public ActionResult Index()
        {
            return View(db.L_Professions.ToList());
        }

        // GET: L_Profession/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_Profession l_Profession = db.L_Professions.Find(id);
            if (l_Profession == null)
            {
                return HttpNotFound();
            }
            return View(l_Profession);
        }

        // GET: L_Profession/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: L_Profession/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Value,Description,Created,Modified")] L_Profession l_Profession)
        {
            if (ModelState.IsValid)
            {
                db.L_Professions.Add(l_Profession);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(l_Profession);
        }

        // GET: L_Profession/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_Profession l_Profession = db.L_Professions.Find(id);
            if (l_Profession == null)
            {
                return HttpNotFound();
            }
            return View(l_Profession);
        }

        // POST: L_Profession/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Value,Description,Created,Modified")] L_Profession l_Profession)
        {
            if (ModelState.IsValid)
            {
                db.Entry(l_Profession).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(l_Profession);
        }

        // GET: L_Profession/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_Profession l_Profession = db.L_Professions.Find(id);
            if (l_Profession == null)
            {
                return HttpNotFound();
            }
            return View(l_Profession);
        }

        // POST: L_Profession/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            L_Profession l_Profession = db.L_Professions.Find(id);
            db.L_Professions.Remove(l_Profession);
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
