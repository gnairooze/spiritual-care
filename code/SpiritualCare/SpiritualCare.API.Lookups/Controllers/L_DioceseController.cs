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
    public class L_DioceseController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/L_Diocese
        public IQueryable<L_Diocese> GetL_Dioceses()
        {
            return db.L_Dioceses;
        }

        // GET: api/L_Diocese/5
        [ResponseType(typeof(L_Diocese))]
        public IHttpActionResult GetL_Diocese(long id)
        {
            L_Diocese l_Diocese = db.L_Dioceses.Find(id);
            if (l_Diocese == null)
            {
                return NotFound();
            }

            return Ok(l_Diocese);
        }

        // PUT: api/L_Diocese/5
        [ResponseType(typeof(L_Diocese))]
        [HttpPost]
        public IHttpActionResult PutL_Diocese(long id, L_Diocese l_Diocese)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != l_Diocese.ID)
            {
                return BadRequest();
            }

            db.Entry(l_Diocese).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!L_DioceseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(l_Diocese);
        }

        // POST: api/L_Diocese
        [ResponseType(typeof(L_Diocese))]
        public IHttpActionResult PostL_Diocese(L_Diocese l_Diocese)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.L_Dioceses.Add(l_Diocese);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = l_Diocese.ID }, l_Diocese);
        }

        // DELETE: api/L_Diocese/5
        [ResponseType(typeof(L_Diocese))]
        [HttpPost]
        public IHttpActionResult DeleteL_Diocese(long id)
        {
            L_Diocese l_Diocese = db.L_Dioceses.Find(id);
            if (l_Diocese == null)
            {
                return NotFound();
            }

            db.L_Dioceses.Remove(l_Diocese);
            db.SaveChanges();

            return Ok(l_Diocese);
        }
        // OPTIONS: api/L_Diocese
        // for use with angular framework
        [HttpOptions]
        public IHttpActionResult OptionsL_Diocese()
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

        private bool L_DioceseExists(long id)
        {
            return db.L_Dioceses.Count(e => e.ID == id) > 0;
        }
    }
}