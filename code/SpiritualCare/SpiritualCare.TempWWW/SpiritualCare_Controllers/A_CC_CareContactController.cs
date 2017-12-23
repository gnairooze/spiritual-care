using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SpiritualCare.Data;
using SpiritualCare.Model.Activity.CareContact;

namespace SpiritualCare.TempWWW.SpiritualCare_Controllers
{
    
    public class A_CC_CareContactController : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: A_CC_CareContact
        [Authorize(Roles = "Admin,CareContactAdmin,CareContactEditor,CareContactReader")]
        public ActionResult Index()
        {
            return View(db.A_CC_CareContacts.OrderByDescending(e=>e.ID).ToList());
        }

        // GET: A_CC_CareContact/Details/5
        [Authorize(Roles = "Admin,CareContactAdmin,CareContactEditor,CareContactReader")]
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            A_CC_CareContact a_CC_CareContact = db.A_CC_CareContacts.Find(id);
            if (a_CC_CareContact == null)
            {
                return HttpNotFound();
            }
            return View(a_CC_CareContact);
        }

        // GET: A_CC_CareContact/Create
        [Authorize(Roles = "Admin,CareContactAdmin,CareContactEditor")]
        public ActionResult Create()
        {
            //ViewBag.ContactMeans = 
            return View();
        }

        // POST: A_CC_CareContact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,CareContactAdmin,CareContactEditor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ContactDate,ContactMean,FamilyName,Comment,Created,Modified")] A_CC_CareContact a_CC_CareContact)
        {
            if (ModelState.IsValid)
            {
                db.A_CC_CareContacts.Add(a_CC_CareContact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(a_CC_CareContact);
        }

        // GET: A_CC_CareContact/Edit/5
        [Authorize(Roles = "Admin,CareContactAdmin,CareContactEditor")]
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            A_CC_CareContact a_CC_CareContact = db.A_CC_CareContacts.Find(id);
            if (a_CC_CareContact == null)
            {
                return HttpNotFound();
            }
            return View(a_CC_CareContact);
        }

        // POST: A_CC_CareContact/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,CareContactAdmin,CareContactEditor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ContactDate,ContactMean,FamilyName,Comment,Created,Modified")] A_CC_CareContact a_CC_CareContact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(a_CC_CareContact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(a_CC_CareContact);
        }

        // GET: A_CC_CareContact/Delete/5
        [Authorize(Roles = "Admin,CareContactAdmin")]
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            A_CC_CareContact a_CC_CareContact = db.A_CC_CareContacts.Find(id);
            if (a_CC_CareContact == null)
            {
                return HttpNotFound();
            }
            return View(a_CC_CareContact);
        }

        // POST: A_CC_CareContact/Delete/5
        [Authorize(Roles = "Admin,CareContactAdmin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            A_CC_CareContact a_CC_CareContact = db.A_CC_CareContacts.Find(id);
            db.A_CC_CareContacts.Remove(a_CC_CareContact);
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
