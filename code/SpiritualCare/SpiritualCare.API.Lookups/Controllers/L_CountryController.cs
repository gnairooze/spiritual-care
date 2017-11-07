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
    public class L_CountryController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/L_Country
        public IQueryable<L_Country> GetL_Countries()
        {
            return db.L_Countries;
        }

        // GET: api/L_Country/5
        [ResponseType(typeof(L_Country))]
        public IHttpActionResult GetL_Country(long id)
        {
            L_Country l_Country = db.L_Countries.Find(id);
            if (l_Country == null)
            {
                return NotFound();
            }

            return Ok(l_Country);
        }

        // PUT: api/L_Country/5
        [ResponseType(typeof(L_Country))]
        [HttpPost]
        public IHttpActionResult PutL_Country(long id, L_Country l_Country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != l_Country.ID)
            {
                return BadRequest();
            }

            db.Entry(l_Country).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!L_CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(l_Country);
        }

        // POST: api/L_Country
        [ResponseType(typeof(L_Country))]
        public IHttpActionResult PostL_Country(L_Country l_Country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.L_Countries.Add(l_Country);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = l_Country.ID }, l_Country);
        }

        // DELETE: api/L_Country/5
        [ResponseType(typeof(L_Country))]
        [HttpPost]
        public IHttpActionResult DeleteL_Country(long id)
        {
            L_Country l_Country = db.L_Countries.Find(id);
            if (l_Country == null)
            {
                return NotFound();
            }

            db.L_Countries.Remove(l_Country);
            db.SaveChanges();

            return Ok(l_Country);
        }
        // OPTIONS: api/L_Country
        // for use with angular framework
        [HttpOptions]
        public IHttpActionResult OptionsL_Country()
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

        private bool L_CountryExists(long id)
        {
            return db.L_Countries.Count(e => e.ID == id) > 0;
        }
    }
}