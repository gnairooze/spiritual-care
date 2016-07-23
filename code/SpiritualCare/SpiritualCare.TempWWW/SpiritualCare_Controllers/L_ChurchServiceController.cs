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
    public class L_ChurchServiceController : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: L_ChurchService
        public ActionResult Index()
        {
            return View(db.L_ChurchServices.ToList());
        }

        // GET: L_ChurchService/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_ChurchService l_ChurchService = db.L_ChurchServices.Find(id);
            if (l_ChurchService == null)
            {
                return HttpNotFound();
            }
            return View(l_ChurchService);
        }

        // GET: L_ChurchService/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: L_ChurchService/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Value,Description,Created,Modified")] L_ChurchService l_ChurchService)
        {
            if (ModelState.IsValid)
            {
                db.L_ChurchServices.Add(l_ChurchService);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(l_ChurchService);
        }

        // GET: L_ChurchService/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_ChurchService l_ChurchService = db.L_ChurchServices.Find(id);
            if (l_ChurchService == null)
            {
                return HttpNotFound();
            }
            return View(l_ChurchService);
        }

        // POST: L_ChurchService/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Value,Description,Created,Modified")] L_ChurchService l_ChurchService)
        {
            if (ModelState.IsValid)
            {
                db.Entry(l_ChurchService).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(l_ChurchService);
        }

        // GET: L_ChurchService/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_ChurchService l_ChurchService = db.L_ChurchServices.Find(id);
            if (l_ChurchService == null)
            {
                return HttpNotFound();
            }
            return View(l_ChurchService);
        }

        // POST: L_ChurchService/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            L_ChurchService l_ChurchService = db.L_ChurchServices.Find(id);
            db.L_ChurchServices.Remove(l_ChurchService);
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
