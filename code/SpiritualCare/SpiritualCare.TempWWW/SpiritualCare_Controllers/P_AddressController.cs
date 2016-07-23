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
    public class P_AddressController : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: P_Address
        public ActionResult Index()
        {
            return View(db.P_Addresses.ToList());
        }

        // GET: P_Address/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Address p_Address = db.P_Addresses.Find(id);
            if (p_Address == null)
            {
                return HttpNotFound();
            }
            return View(p_Address);
        }

        // GET: P_Address/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: P_Address/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AddressType,StreetNo,StreetName,City,Governerate,Country,Comment,IsDefault,GPS_Long,GPS_Lat,Created,Modified")] P_Address p_Address)
        {
            if (ModelState.IsValid)
            {
                db.P_Addresses.Add(p_Address);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(p_Address);
        }

        // GET: P_Address/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Address p_Address = db.P_Addresses.Find(id);
            if (p_Address == null)
            {
                return HttpNotFound();
            }
            return View(p_Address);
        }

        // POST: P_Address/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AddressType,StreetNo,StreetName,City,Governerate,Country,Comment,IsDefault,GPS_Long,GPS_Lat,Created,Modified")] P_Address p_Address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_Address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p_Address);
        }

        // GET: P_Address/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Address p_Address = db.P_Addresses.Find(id);
            if (p_Address == null)
            {
                return HttpNotFound();
            }
            return View(p_Address);
        }

        // POST: P_Address/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            P_Address p_Address = db.P_Addresses.Find(id);
            db.P_Addresses.Remove(p_Address);
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
