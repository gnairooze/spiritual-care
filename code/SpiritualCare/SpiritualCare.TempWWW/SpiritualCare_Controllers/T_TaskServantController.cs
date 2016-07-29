using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SpiritualCare.Data;
using SpiritualCare.Model.Task;

namespace SpiritualCare.TempWWW.SpiritualCare_Controllers
{
    public class T_TaskServantController : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: T_TaskServant
        public ActionResult Index()
        {
            return View(db.T_TaskServants.OrderByDescending(e => e.ID).ToList());
        }

        // GET: T_TaskServant/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_TaskServant t_TaskServant = db.T_TaskServants.Find(id);
            if (t_TaskServant == null)
            {
                return HttpNotFound();
            }
            return View(t_TaskServant);
        }

        // GET: T_TaskServant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_TaskServant/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Task_ID,Person_ID,Created,Modified")] T_TaskServant t_TaskServant)
        {
            if (ModelState.IsValid)
            {
                db.T_TaskServants.Add(t_TaskServant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_TaskServant);
        }

        // GET: T_TaskServant/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_TaskServant t_TaskServant = db.T_TaskServants.Find(id);
            if (t_TaskServant == null)
            {
                return HttpNotFound();
            }
            return View(t_TaskServant);
        }

        // POST: T_TaskServant/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Task_ID,Person_ID,Created,Modified")] T_TaskServant t_TaskServant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_TaskServant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_TaskServant);
        }

        // GET: T_TaskServant/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_TaskServant t_TaskServant = db.T_TaskServants.Find(id);
            if (t_TaskServant == null)
            {
                return HttpNotFound();
            }
            return View(t_TaskServant);
        }

        // POST: T_TaskServant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            T_TaskServant t_TaskServant = db.T_TaskServants.Find(id);
            db.T_TaskServants.Remove(t_TaskServant);
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
