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
    public class P_ViberController : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: P_Viber
        public ActionResult Index()
        {
            return View(db.P_Vibers.ToList());
        }

        // GET: P_Viber/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Viber p_Viber = db.P_Vibers.Find(id);
            if (p_Viber == null)
            {
                return HttpNotFound();
            }
            return View(p_Viber);
        }

        // GET: P_Viber/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: P_Viber/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IsDefault,Person_ID,ContactType,Value,Comment,Created,Modified")] P_Viber p_Viber)
        {
            if (ModelState.IsValid)
            {
                db.P_Vibers.Add(p_Viber);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(p_Viber);
        }

        // GET: P_Viber/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Viber p_Viber = db.P_Vibers.Find(id);
            if (p_Viber == null)
            {
                return HttpNotFound();
            }
            return View(p_Viber);
        }

        // POST: P_Viber/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IsDefault,Person_ID,ContactType,Value,Comment,Created,Modified")] P_Viber p_Viber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_Viber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p_Viber);
        }

        // GET: P_Viber/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Viber p_Viber = db.P_Vibers.Find(id);
            if (p_Viber == null)
            {
                return HttpNotFound();
            }
            return View(p_Viber);
        }

        // POST: P_Viber/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            P_Viber p_Viber = db.P_Vibers.Find(id);
            db.P_Vibers.Remove(p_Viber);
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
