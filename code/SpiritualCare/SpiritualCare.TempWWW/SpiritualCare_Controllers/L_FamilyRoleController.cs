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
    public class L_FamilyRoleController : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: L_FamilyRole
        public ActionResult Index()
        {
            return View(db.L_FamilyRoles.OrderByDescending(e => e.ID).ToList());
        }

        // GET: L_FamilyRole/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_FamilyRole l_FamilyRole = db.L_FamilyRoles.Find(id);
            if (l_FamilyRole == null)
            {
                return HttpNotFound();
            }
            return View(l_FamilyRole);
        }

        // GET: L_FamilyRole/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: L_FamilyRole/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Value,Description,Created,Modified")] L_FamilyRole l_FamilyRole)
        {
            if (ModelState.IsValid)
            {
                db.L_FamilyRoles.Add(l_FamilyRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(l_FamilyRole);
        }

        // GET: L_FamilyRole/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_FamilyRole l_FamilyRole = db.L_FamilyRoles.Find(id);
            if (l_FamilyRole == null)
            {
                return HttpNotFound();
            }
            return View(l_FamilyRole);
        }

        // POST: L_FamilyRole/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Value,Description,Created,Modified")] L_FamilyRole l_FamilyRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(l_FamilyRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(l_FamilyRole);
        }

        // GET: L_FamilyRole/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_FamilyRole l_FamilyRole = db.L_FamilyRoles.Find(id);
            if (l_FamilyRole == null)
            {
                return HttpNotFound();
            }
            return View(l_FamilyRole);
        }

        // POST: L_FamilyRole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            L_FamilyRole l_FamilyRole = db.L_FamilyRoles.Find(id);
            db.L_FamilyRoles.Remove(l_FamilyRole);
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
