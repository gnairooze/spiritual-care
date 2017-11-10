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
    public class L_StreetController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/L_Street
        public IQueryable<L_Street> GetL_Streets()
        {
            return db.L_Streets;
        }

        // GET: api/L_Street/5
        [ResponseType(typeof(L_Street))]
        public IHttpActionResult GetL_Street(long id)
        {
            L_Street l_Street = db.L_Streets.Find(id);
            if (l_Street == null)
            {
                return NotFound();
            }

            return Ok(l_Street);
        }

        // PUT: api/L_Street/5
        [ResponseType(typeof(L_Street))]
        [HttpPost]
        public IHttpActionResult PutL_Street(long id, L_Street l_Street)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != l_Street.ID)
            {
                return BadRequest();
            }

            db.Entry(l_Street).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!L_StreetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(l_Street);
        }

        // POST: api/L_Street
        [ResponseType(typeof(L_Street))]
        public IHttpActionResult PostL_Street(L_Street l_Street)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.L_Streets.Add(l_Street);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = l_Street.ID }, l_Street);
        }

        // DELETE: api/L_Street/5
        [ResponseType(typeof(L_Street))]
        [HttpPost]
        public IHttpActionResult DeleteL_Street(long id)
        {
            L_Street l_Street = db.L_Streets.Find(id);
            if (l_Street == null)
            {
                return NotFound();
            }

            db.L_Streets.Remove(l_Street);
            db.SaveChanges();

            return Ok(l_Street);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool L_StreetExists(long id)
        {
            return db.L_Streets.Count(e => e.ID == id) > 0;
        }
    }
}