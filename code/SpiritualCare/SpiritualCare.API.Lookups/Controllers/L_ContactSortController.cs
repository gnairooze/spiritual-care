using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SpiritualCare.Data;
using SpiritualCare.Model.Lookup;

namespace SpiritualCare.API.Lookups.Controllers
{
    public class L_ContactSortController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/L_ContactSort
        public IQueryable<L_ContactSort> GetL_ContactSorts()
        {
            return db.L_ContactSorts;
        }

        // GET: api/L_ContactSort/5
        [ResponseType(typeof(L_ContactSort))]
        public IHttpActionResult GetL_ContactSort(long id)
        {
            L_ContactSort l_ContactSort = db.L_ContactSorts.Find(id);
            if (l_ContactSort == null)
            {
                return NotFound();
            }

            return Ok(l_ContactSort);
        }

        // PUT: api/L_ContactSort/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult PutL_ContactSort(long id, L_ContactSort l_ContactSort)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != l_ContactSort.ID)
            {
                return BadRequest();
            }

            db.Entry(l_ContactSort).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!L_ContactSortExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(l_ContactSort);
        }

        // POST: api/L_ContactSort
        [ResponseType(typeof(L_ContactSort))]
        public IHttpActionResult PostL_ContactSort(L_ContactSort l_ContactSort)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.L_ContactSorts.Add(l_ContactSort);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = l_ContactSort.ID }, l_ContactSort);
        }

        // DELETE: api/L_ContactSort/5
        [ResponseType(typeof(L_ContactSort))]
        [HttpPost]
        public IHttpActionResult DeleteL_ContactSort(long id)
        {
            L_ContactSort l_ContactSort = db.L_ContactSorts.Find(id);
            if (l_ContactSort == null)
            {
                return NotFound();
            }

            db.L_ContactSorts.Remove(l_ContactSort);
            db.SaveChanges();

            return Ok(l_ContactSort);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool L_ContactSortExists(long id)
        {
            return db.L_ContactSorts.Count(e => e.ID == id) > 0;
        }
    }
}