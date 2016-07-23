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
    public class T_TaskDefinitionController : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: T_TaskDefinition
        public ActionResult Index()
        {
            return View(db.T_TaskDefinitions.ToList());
        }

        // GET: T_TaskDefinition/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_TaskDefinition t_TaskDefinition = db.T_TaskDefinitions.Find(id);
            if (t_TaskDefinition == null)
            {
                return HttpNotFound();
            }
            return View(t_TaskDefinition);
        }

        // GET: T_TaskDefinition/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_TaskDefinition/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,DueDays,Created,Modified")] T_TaskDefinition t_TaskDefinition)
        {
            if (ModelState.IsValid)
            {
                db.T_TaskDefinitions.Add(t_TaskDefinition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_TaskDefinition);
        }

        // GET: T_TaskDefinition/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_TaskDefinition t_TaskDefinition = db.T_TaskDefinitions.Find(id);
            if (t_TaskDefinition == null)
            {
                return HttpNotFound();
            }
            return View(t_TaskDefinition);
        }

        // POST: T_TaskDefinition/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,DueDays,Created,Modified")] T_TaskDefinition t_TaskDefinition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_TaskDefinition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_TaskDefinition);
        }

        // GET: T_TaskDefinition/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_TaskDefinition t_TaskDefinition = db.T_TaskDefinitions.Find(id);
            if (t_TaskDefinition == null)
            {
                return HttpNotFound();
            }
            return View(t_TaskDefinition);
        }

        // POST: T_TaskDefinition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            T_TaskDefinition t_TaskDefinition = db.T_TaskDefinitions.Find(id);
            db.T_TaskDefinitions.Remove(t_TaskDefinition);
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
