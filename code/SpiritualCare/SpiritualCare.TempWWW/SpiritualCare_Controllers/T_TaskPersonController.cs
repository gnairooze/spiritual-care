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
    public class T_TaskPersonController : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: T_TaskPerson
        public ActionResult Index()
        {
            return View(db.T_TaskPersons.ToList());
        }

        // GET: T_TaskPerson/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_TaskPerson t_TaskPerson = db.T_TaskPersons.Find(id);
            if (t_TaskPerson == null)
            {
                return HttpNotFound();
            }
            return View(t_TaskPerson);
        }

        // GET: T_TaskPerson/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_TaskPerson/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Task_ID,Person_ID,Created,Modified")] T_TaskPerson t_TaskPerson)
        {
            if (ModelState.IsValid)
            {
                db.T_TaskPersons.Add(t_TaskPerson);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_TaskPerson);
        }

        // GET: T_TaskPerson/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_TaskPerson t_TaskPerson = db.T_TaskPersons.Find(id);
            if (t_TaskPerson == null)
            {
                return HttpNotFound();
            }
            return View(t_TaskPerson);
        }

        // POST: T_TaskPerson/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Task_ID,Person_ID,Created,Modified")] T_TaskPerson t_TaskPerson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_TaskPerson).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_TaskPerson);
        }

        // GET: T_TaskPerson/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_TaskPerson t_TaskPerson = db.T_TaskPersons.Find(id);
            if (t_TaskPerson == null)
            {
                return HttpNotFound();
            }
            return View(t_TaskPerson);
        }

        // POST: T_TaskPerson/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            T_TaskPerson t_TaskPerson = db.T_TaskPersons.Find(id);
            db.T_TaskPersons.Remove(t_TaskPerson);
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
