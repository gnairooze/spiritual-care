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
    public class P_ContactWay3Controller : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: P_ContactWay3
        public ActionResult Index()
        {
            return View(db.P_ContactWay3.OrderByDescending(e => e.ID).ToList());
        }

        // GET: P_ContactWay3/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_ContactWay3 p_ContactWay3 = db.P_ContactWay3.Find(id);
            if (p_ContactWay3 == null)
            {
                return HttpNotFound();
            }
            return View(p_ContactWay3);
        }

        // GET: P_ContactWay3/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: P_ContactWay3/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Person_ID,ContactType,Value,Comment,Created,Modified")] P_ContactWay3 p_ContactWay3)
        {
            if (ModelState.IsValid)
            {
                db.P_ContactWay3.Add(p_ContactWay3);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(p_ContactWay3);
        }

        // GET: P_ContactWay3/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_ContactWay3 p_ContactWay3 = db.P_ContactWay3.Find(id);
            if (p_ContactWay3 == null)
            {
                return HttpNotFound();
            }
            return View(p_ContactWay3);
        }

        // POST: P_ContactWay3/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Person_ID,ContactType,Value,Comment,Created,Modified")] P_ContactWay3 p_ContactWay3)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_ContactWay3).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p_ContactWay3);
        }

        // GET: P_ContactWay3/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_ContactWay3 p_ContactWay3 = db.P_ContactWay3.Find(id);
            if (p_ContactWay3 == null)
            {
                return HttpNotFound();
            }
            return View(p_ContactWay3);
        }

        // POST: P_ContactWay3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            P_ContactWay3 p_ContactWay3 = db.P_ContactWay3.Find(id);
            db.P_ContactWay3.Remove(p_ContactWay3);
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
