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
    public class P_EmailController : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: P_Email
        public ActionResult Index()
        {
            return View(db.P_Emails.ToList());
        }

        // GET: P_Email/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Email p_Email = db.P_Emails.Find(id);
            if (p_Email == null)
            {
                return HttpNotFound();
            }
            return View(p_Email);
        }

        // GET: P_Email/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: P_Email/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IsDefault,Person_ID,ContactType,Value,Comment,Created,Modified")] P_Email p_Email)
        {
            if (ModelState.IsValid)
            {
                db.P_Emails.Add(p_Email);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(p_Email);
        }

        // GET: P_Email/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Email p_Email = db.P_Emails.Find(id);
            if (p_Email == null)
            {
                return HttpNotFound();
            }
            return View(p_Email);
        }

        // POST: P_Email/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IsDefault,Person_ID,ContactType,Value,Comment,Created,Modified")] P_Email p_Email)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_Email).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p_Email);
        }

        // GET: P_Email/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Email p_Email = db.P_Emails.Find(id);
            if (p_Email == null)
            {
                return HttpNotFound();
            }
            return View(p_Email);
        }

        // POST: P_Email/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            P_Email p_Email = db.P_Emails.Find(id);
            db.P_Emails.Remove(p_Email);
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
