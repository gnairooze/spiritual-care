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
    public class L_ContactSortController : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: L_ContactSort
        public ActionResult Index()
        {
            return View(db.L_ContactSorts.ToList());
        }

        // GET: L_ContactSort/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_ContactSort l_ContactSort = db.L_ContactSorts.Find(id);
            if (l_ContactSort == null)
            {
                return HttpNotFound();
            }
            return View(l_ContactSort);
        }

        // GET: L_ContactSort/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: L_ContactSort/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Value,Description,Created,Modified")] L_ContactSort l_ContactSort)
        {
            if (ModelState.IsValid)
            {
                db.L_ContactSorts.Add(l_ContactSort);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(l_ContactSort);
        }

        // GET: L_ContactSort/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_ContactSort l_ContactSort = db.L_ContactSorts.Find(id);
            if (l_ContactSort == null)
            {
                return HttpNotFound();
            }
            return View(l_ContactSort);
        }

        // POST: L_ContactSort/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Value,Description,Created,Modified")] L_ContactSort l_ContactSort)
        {
            if (ModelState.IsValid)
            {
                db.Entry(l_ContactSort).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(l_ContactSort);
        }

        // GET: L_ContactSort/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_ContactSort l_ContactSort = db.L_ContactSorts.Find(id);
            if (l_ContactSort == null)
            {
                return HttpNotFound();
            }
            return View(l_ContactSort);
        }

        // POST: L_ContactSort/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            L_ContactSort l_ContactSort = db.L_ContactSorts.Find(id);
            db.L_ContactSorts.Remove(l_ContactSort);
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
