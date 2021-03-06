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
    public class P_ContactWay1Controller : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: P_ContactWay1
        public ActionResult Index()
        {
            return View(db.P_ContactWay1.OrderByDescending(e => e.ID).ToList());
        }

        // GET: P_ContactWay1/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_ContactWay1 p_ContactWay1 = db.P_ContactWay1.Find(id);
            if (p_ContactWay1 == null)
            {
                return HttpNotFound();
            }
            return View(p_ContactWay1);
        }

        // GET: P_ContactWay1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: P_ContactWay1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Person_ID,ContactType,Value,Comment,Created,Modified")] P_ContactWay1 p_ContactWay1)
        {
            if (ModelState.IsValid)
            {
                db.P_ContactWay1.Add(p_ContactWay1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(p_ContactWay1);
        }

        // GET: P_ContactWay1/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_ContactWay1 p_ContactWay1 = db.P_ContactWay1.Find(id);
            if (p_ContactWay1 == null)
            {
                return HttpNotFound();
            }
            return View(p_ContactWay1);
        }

        // POST: P_ContactWay1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Person_ID,ContactType,Value,Comment,Created,Modified")] P_ContactWay1 p_ContactWay1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_ContactWay1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p_ContactWay1);
        }

        // GET: P_ContactWay1/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_ContactWay1 p_ContactWay1 = db.P_ContactWay1.Find(id);
            if (p_ContactWay1 == null)
            {
                return HttpNotFound();
            }
            return View(p_ContactWay1);
        }

        // POST: P_ContactWay1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            P_ContactWay1 p_ContactWay1 = db.P_ContactWay1.Find(id);
            db.P_ContactWay1.Remove(p_ContactWay1);
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
