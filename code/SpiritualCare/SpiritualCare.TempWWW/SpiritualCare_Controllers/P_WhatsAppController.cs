﻿using System;
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
    public class P_WhatsAppController : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: P_WhatsApp
        public ActionResult Index()
        {
            return View(db.P_WhatsApps.ToList());
        }

        // GET: P_WhatsApp/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_WhatsApp p_WhatsApp = db.P_WhatsApps.Find(id);
            if (p_WhatsApp == null)
            {
                return HttpNotFound();
            }
            return View(p_WhatsApp);
        }

        // GET: P_WhatsApp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: P_WhatsApp/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IsDefault,Person_ID,ContactType,Value,Comment,Created,Modified")] P_WhatsApp p_WhatsApp)
        {
            if (ModelState.IsValid)
            {
                db.P_WhatsApps.Add(p_WhatsApp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(p_WhatsApp);
        }

        // GET: P_WhatsApp/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_WhatsApp p_WhatsApp = db.P_WhatsApps.Find(id);
            if (p_WhatsApp == null)
            {
                return HttpNotFound();
            }
            return View(p_WhatsApp);
        }

        // POST: P_WhatsApp/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IsDefault,Person_ID,ContactType,Value,Comment,Created,Modified")] P_WhatsApp p_WhatsApp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_WhatsApp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p_WhatsApp);
        }

        // GET: P_WhatsApp/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_WhatsApp p_WhatsApp = db.P_WhatsApps.Find(id);
            if (p_WhatsApp == null)
            {
                return HttpNotFound();
            }
            return View(p_WhatsApp);
        }

        // POST: P_WhatsApp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            P_WhatsApp p_WhatsApp = db.P_WhatsApps.Find(id);
            db.P_WhatsApps.Remove(p_WhatsApp);
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
