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
    public class P_PersonController : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: P_Person
        public ActionResult Index()
        {
            return View(db.P_Persons.ToList());
        }

        // GET: P_Person/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Person p_Person = db.P_Persons.Find(id);
            if (p_Person == null)
            {
                return HttpNotFound();
            }
            return View(p_Person);
        }

        // GET: P_Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: P_Person/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,FirstName,MiddleName,LastName,FamilyName,FamilyRole,Photo,BirthDate,IsMale,NationalID,SocialStatus,Comment,Church,Diocese,ConfessionFather,ServantInChurchService,IsLordBrother,Created,Modified")] P_Person p_Person)
        {
            if (ModelState.IsValid)
            {
                db.P_Persons.Add(p_Person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(p_Person);
        }

        // GET: P_Person/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Person p_Person = db.P_Persons.Find(id);
            if (p_Person == null)
            {
                return HttpNotFound();
            }
            return View(p_Person);
        }

        // POST: P_Person/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,FirstName,MiddleName,LastName,FamilyName,FamilyRole,Photo,BirthDate,IsMale,NationalID,SocialStatus,Comment,Church,Diocese,ConfessionFather,ServantInChurchService,IsLordBrother,Created,Modified")] P_Person p_Person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_Person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p_Person);
        }

        // GET: P_Person/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Person p_Person = db.P_Persons.Find(id);
            if (p_Person == null)
            {
                return HttpNotFound();
            }
            return View(p_Person);
        }

        // POST: P_Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            P_Person p_Person = db.P_Persons.Find(id);
            db.P_Persons.Remove(p_Person);
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
