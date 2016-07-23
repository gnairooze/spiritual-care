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
    public class P_Person_AddressController : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: P_Person_Address
        public ActionResult Index()
        {
            return View(db.P_Person_Addresses.ToList());
        }

        // GET: P_Person_Address/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Person_Address p_Person_Address = db.P_Person_Addresses.Find(id);
            if (p_Person_Address == null)
            {
                return HttpNotFound();
            }
            return View(p_Person_Address);
        }

        // GET: P_Person_Address/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: P_Person_Address/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Person_ID,Address_ID,Created,Modified")] P_Person_Address p_Person_Address)
        {
            if (ModelState.IsValid)
            {
                db.P_Person_Addresses.Add(p_Person_Address);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(p_Person_Address);
        }

        // GET: P_Person_Address/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Person_Address p_Person_Address = db.P_Person_Addresses.Find(id);
            if (p_Person_Address == null)
            {
                return HttpNotFound();
            }
            return View(p_Person_Address);
        }

        // POST: P_Person_Address/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Person_ID,Address_ID,Created,Modified")] P_Person_Address p_Person_Address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_Person_Address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p_Person_Address);
        }

        // GET: P_Person_Address/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Person_Address p_Person_Address = db.P_Person_Addresses.Find(id);
            if (p_Person_Address == null)
            {
                return HttpNotFound();
            }
            return View(p_Person_Address);
        }

        // POST: P_Person_Address/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            P_Person_Address p_Person_Address = db.P_Person_Addresses.Find(id);
            db.P_Person_Addresses.Remove(p_Person_Address);
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
