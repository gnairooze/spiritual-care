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
    public class L_ContactMeanController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/L_ContactMean
        public IQueryable<L_ContactMean> GetL_ContactMeans()
        {
            return db.L_ContactMeans;
        }

        // GET: api/L_ContactMean/5
        [ResponseType(typeof(L_ContactMean))]
        public IHttpActionResult GetL_ContactMean(long id)
        {
            L_ContactMean l_ContactMean = db.L_ContactMeans.Find(id);
            if (l_ContactMean == null)
            {
                return NotFound();
            }

            return Ok(l_ContactMean);
        }

        // PUT: api/L_ContactMean/5
        [ResponseType(typeof(L_ContactMean))]
        [HttpPost]
        public IHttpActionResult PutL_ContactMean(long id, L_ContactMean l_ContactMean)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != l_ContactMean.ID)
            {
                return BadRequest();
            }

            db.Entry(l_ContactMean).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!L_ContactMeanExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(l_ContactMean);
        }

        // POST: api/L_ContactMean
        [ResponseType(typeof(L_ContactMean))]
        public IHttpActionResult PostL_ContactMean(L_ContactMean l_ContactMean)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.L_ContactMeans.Add(l_ContactMean);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = l_ContactMean.ID }, l_ContactMean);
        }

        // DELETE: api/L_ContactMean/5
        [ResponseType(typeof(L_ContactMean))]
        [HttpPost]
        public IHttpActionResult DeleteL_ContactMean(long id)
        {
            L_ContactMean l_ContactMean = db.L_ContactMeans.Find(id);
            if (l_ContactMean == null)
            {
                return NotFound();
            }

            db.L_ContactMeans.Remove(l_ContactMean);
            db.SaveChanges();

            return Ok(l_ContactMean);
        }
        // OPTIONS: api/L_ContactMean
        // for use with angular framework
        [HttpOptions]
        public IHttpActionResult OptionsL_ContactMean()
        {
            return Ok();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool L_ContactMeanExists(long id)
        {
            return db.L_ContactMeans.Count(e => e.ID == id) > 0;
        }
    }
}