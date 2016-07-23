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
    public class T_TaskController : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: T_Task
        public ActionResult Index()
        {
            return View(db.T_Tasks.ToList());
        }

        // GET: T_Task/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Task t_Task = db.T_Tasks.Find(id);
            if (t_Task == null)
            {
                return HttpNotFound();
            }
            return View(t_Task);
        }

        // GET: T_Task/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_Task/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TaskDefinition_ID,CareContact_ID,FamilyName,Comment,Status,DueDate,Created,Modified")] T_Task t_Task)
        {
            if (ModelState.IsValid)
            {
                db.T_Tasks.Add(t_Task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_Task);
        }

        // GET: T_Task/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Task t_Task = db.T_Tasks.Find(id);
            if (t_Task == null)
            {
                return HttpNotFound();
            }
            return View(t_Task);
        }

        // POST: T_Task/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TaskDefinition_ID,CareContact_ID,FamilyName,Comment,Status,DueDate,Created,Modified")] T_Task t_Task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_Task);
        }

        // GET: T_Task/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Task t_Task = db.T_Tasks.Find(id);
            if (t_Task == null)
            {
                return HttpNotFound();
            }
            return View(t_Task);
        }

        // POST: T_Task/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            T_Task t_Task = db.T_Tasks.Find(id);
            db.T_Tasks.Remove(t_Task);
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
