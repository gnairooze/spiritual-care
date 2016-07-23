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
    public class P_FacebookController : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: P_Facebook
        public ActionResult Index()
        {
            return View(db.P_Facebooks.ToList());
        }

        // GET: P_Facebook/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Facebook p_Facebook = db.P_Facebooks.Find(id);
            if (p_Facebook == null)
            {
                return HttpNotFound();
            }
            return View(p_Facebook);
        }

        // GET: P_Facebook/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: P_Facebook/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IsDefault,Person_ID,ContactType,Value,Comment,Created,Modified")] P_Facebook p_Facebook)
        {
            if (ModelState.IsValid)
            {
                db.P_Facebooks.Add(p_Facebook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(p_Facebook);
        }

        // GET: P_Facebook/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Facebook p_Facebook = db.P_Facebooks.Find(id);
            if (p_Facebook == null)
            {
                return HttpNotFound();
            }
            return View(p_Facebook);
        }

        // POST: P_Facebook/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IsDefault,Person_ID,ContactType,Value,Comment,Created,Modified")] P_Facebook p_Facebook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_Facebook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p_Facebook);
        }

        // GET: P_Facebook/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Facebook p_Facebook = db.P_Facebooks.Find(id);
            if (p_Facebook == null)
            {
                return HttpNotFound();
            }
            return View(p_Facebook);
        }

        // POST: P_Facebook/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            P_Facebook p_Facebook = db.P_Facebooks.Find(id);
            db.P_Facebooks.Remove(p_Facebook);
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
