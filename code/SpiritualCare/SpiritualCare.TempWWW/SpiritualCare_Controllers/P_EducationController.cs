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
    public class P_EducationController : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: P_Education
        public ActionResult Index()
        {
            return View(db.P_Educations.ToList());
        }

        // GET: P_Education/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Education p_Education = db.P_Educations.Find(id);
            if (p_Education == null)
            {
                return HttpNotFound();
            }
            return View(p_Education);
        }

        // GET: P_Education/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: P_Education/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EducationType,Value,Comment,Created,Modified")] P_Education p_Education)
        {
            if (ModelState.IsValid)
            {
                db.P_Educations.Add(p_Education);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(p_Education);
        }

        // GET: P_Education/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Education p_Education = db.P_Educations.Find(id);
            if (p_Education == null)
            {
                return HttpNotFound();
            }
            return View(p_Education);
        }

        // POST: P_Education/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EducationType,Value,Comment,Created,Modified")] P_Education p_Education)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_Education).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p_Education);
        }

        // GET: P_Education/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Education p_Education = db.P_Educations.Find(id);
            if (p_Education == null)
            {
                return HttpNotFound();
            }
            return View(p_Education);
        }

        // POST: P_Education/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            P_Education p_Education = db.P_Educations.Find(id);
            db.P_Educations.Remove(p_Education);
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
