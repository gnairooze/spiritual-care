using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SpiritualCare.Data;
using SpiritualCare.Model.Person;

namespace SpiritualCare.TempWWW.SpiritualCare_Controllers
{
    public class P_PhoneController : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: P_Phone
        public ActionResult Index()
        {
            return View(db.P_Phones.ToList());
        }

        // GET: P_Phone/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Phone p_Phone = db.P_Phones.Find(id);
            if (p_Phone == null)
            {
                return HttpNotFound();
            }
            return View(p_Phone);
        }

        // GET: P_Phone/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: P_Phone/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IsDefault,Person_ID,ContactType,Value,Comment,Created,Modified")] P_Phone p_Phone)
        {
            if (ModelState.IsValid)
            {
                db.P_Phones.Add(p_Phone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(p_Phone);
        }

        // GET: P_Phone/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Phone p_Phone = db.P_Phones.Find(id);
            if (p_Phone == null)
            {
                return HttpNotFound();
            }
            return View(p_Phone);
        }

        // POST: P_Phone/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IsDefault,Person_ID,ContactType,Value,Comment,Created,Modified")] P_Phone p_Phone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_Phone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p_Phone);
        }

        // GET: P_Phone/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Phone p_Phone = db.P_Phones.Find(id);
            if (p_Phone == null)
            {
                return HttpNotFound();
            }
            return View(p_Phone);
        }

        // POST: P_Phone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            P_Phone p_Phone = db.P_Phones.Find(id);
            db.P_Phones.Remove(p_Phone);
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
