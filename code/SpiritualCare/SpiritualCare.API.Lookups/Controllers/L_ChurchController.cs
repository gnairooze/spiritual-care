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
    public class L_ChurchController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/L_Church
        public IQueryable<L_Church> GetL_Churches()
        {
            return db.L_Churches;
        }

        // GET: api/L_Church/5
        [ResponseType(typeof(L_Church))]
        public IHttpActionResult GetL_Church(long id)
        {
            L_Church l_Church = db.L_Churches.Find(id);
            if (l_Church == null)
            {
                return NotFound();
            }

            return Ok(l_Church);
        }

        // PUT: api/L_Church/5
        [ResponseType(typeof(L_Church))]
        [HttpPost]
        public IHttpActionResult PutL_Church(long id, L_Church l_Church)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != l_Church.ID)
            {
                return BadRequest();
            }

            db.Entry(l_Church).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!L_ChurchExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(l_Church);
        }

        // POST: api/L_Church
        [ResponseType(typeof(L_Church))]
        public IHttpActionResult PostL_Church(L_Church l_Church)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.L_Churches.Add(l_Church);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = l_Church.ID }, l_Church);
        }

        // DELETE: api/L_Church/5
        [ResponseType(typeof(L_Church))]
        [HttpPost]
        public IHttpActionResult DeleteL_Church(long id)
        {
            L_Church l_Church = db.L_Churches.Find(id);
            if (l_Church == null)
            {
                return NotFound();
            }

            db.L_Churches.Remove(l_Church);
            db.SaveChanges();

            return Ok(l_Church);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool L_ChurchExists(long id)
        {
            return db.L_Churches.Count(e => e.ID == id) > 0;
        }
    }
}