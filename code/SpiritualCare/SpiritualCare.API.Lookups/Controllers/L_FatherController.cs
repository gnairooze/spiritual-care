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
    public class L_FatherController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/L_Father
        public IQueryable<L_Father> GetL_Fathers()
        {
            return db.L_Fathers;
        }

        // GET: api/L_Father/5
        [ResponseType(typeof(L_Father))]
        public IHttpActionResult GetL_Father(long id)
        {
            L_Father l_Father = db.L_Fathers.Find(id);
            if (l_Father == null)
            {
                return NotFound();
            }

            return Ok(l_Father);
        }

        // PUT: api/L_Father/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutL_Father(long id, L_Father l_Father)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != l_Father.ID)
            {
                return BadRequest();
            }

            db.Entry(l_Father).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!L_FatherExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/L_Father
        [ResponseType(typeof(L_Father))]
        public IHttpActionResult PostL_Father(L_Father l_Father)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.L_Fathers.Add(l_Father);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = l_Father.ID }, l_Father);
        }

        // DELETE: api/L_Father/5
        [ResponseType(typeof(L_Father))]
        public IHttpActionResult DeleteL_Father(long id)
        {
            L_Father l_Father = db.L_Fathers.Find(id);
            if (l_Father == null)
            {
                return NotFound();
            }

            db.L_Fathers.Remove(l_Father);
            db.SaveChanges();

            return Ok(l_Father);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool L_FatherExists(long id)
        {
            return db.L_Fathers.Count(e => e.ID == id) > 0;
        }
    }
}