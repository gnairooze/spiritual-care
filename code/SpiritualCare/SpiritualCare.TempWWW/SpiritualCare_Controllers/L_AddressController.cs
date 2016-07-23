using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SpiritualCare.Data;
using SpiritualCare.Model.Lookup;

namespace SpiritualCare.TempWWW.SpiritualCare_Controllers
{
    public class L_AddressController : Controller
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: L_Address
        public ActionResult Index()
        {
            return View(db.L_AddressTypes.ToList());
        }

        // GET: L_Address/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_Address l_Address = db.L_AddressTypes.Find(id);
            if (l_Address == null)
            {
                return HttpNotFound();
            }
            return View(l_Address);
        }

        // GET: L_Address/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: L_Address/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Value,Description,Created,Modified")] L_Address l_Address)
        {
            if (ModelState.IsValid)
            {
                db.L_AddressTypes.Add(l_Address);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(l_Address);
        }

        // GET: L_Address/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_Address l_Address = db.L_AddressTypes.Find(id);
            if (l_Address == null)
            {
                return HttpNotFound();
            }
            return View(l_Address);
        }

        // POST: L_Address/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Value,Description,Created,Modified")] L_Address l_Address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(l_Address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(l_Address);
        }

        // GET: L_Address/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L_Address l_Address = db.L_AddressTypes.Find(id);
            if (l_Address == null)
            {
                return HttpNotFound();
            }
            return View(l_Address);
        }

        // POST: L_Address/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            L_Address l_Address = db.L_AddressTypes.Find(id);
            db.L_AddressTypes.Remove(l_Address);
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
