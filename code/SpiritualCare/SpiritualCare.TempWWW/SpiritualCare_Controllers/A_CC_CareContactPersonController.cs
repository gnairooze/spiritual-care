using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SpiritualCare.Data;
using SpiritualCare.Model.Activity.CareContact;

namespace SpiritualCare.TempWWW.SpiritualCare_Controllers
{
    public class A_CC_CareContactPersonController : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: A_CC_CareContactPerson
        public ActionResult Index()
        {
            return View(db.A_CC_CareContactPersons.OrderByDescending(e => e.ID).ToList());
        }

        // GET: A_CC_CareContactPerson/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            A_CC_CareContactPerson a_CC_CareContactPerson = db.A_CC_CareContactPersons.Find(id);
            if (a_CC_CareContactPerson == null)
            {
                return HttpNotFound();
            }
            return View(a_CC_CareContactPerson);
        }

        // GET: A_CC_CareContactPerson/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: A_CC_CareContactPerson/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CareContact_ID,Person_ID,Created,Modified")] A_CC_CareContactPerson a_CC_CareContactPerson)
        {
            if (ModelState.IsValid)
            {
                db.A_CC_CareContactPersons.Add(a_CC_CareContactPerson);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(a_CC_CareContactPerson);
        }

        // GET: A_CC_CareContactPerson/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            A_CC_CareContactPerson a_CC_CareContactPerson = db.A_CC_CareContactPersons.Find(id);
            if (a_CC_CareContactPerson == null)
            {
                return HttpNotFound();
            }
            return View(a_CC_CareContactPerson);
        }

        // POST: A_CC_CareContactPerson/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CareContact_ID,Person_ID,Created,Modified")] A_CC_CareContactPerson a_CC_CareContactPerson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(a_CC_CareContactPerson).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(a_CC_CareContactPerson);
        }

        // GET: A_CC_CareContactPerson/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            A_CC_CareContactPerson a_CC_CareContactPerson = db.A_CC_CareContactPersons.Find(id);
            if (a_CC_CareContactPerson == null)
            {
                return HttpNotFound();
            }
            return View(a_CC_CareContactPerson);
        }

        // POST: A_CC_CareContactPerson/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            A_CC_CareContactPerson a_CC_CareContactPerson = db.A_CC_CareContactPersons.Find(id);
            db.A_CC_CareContactPersons.Remove(a_CC_CareContactPerson);
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
