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
    public class L_EducationController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/L_Education
        public IQueryable<L_Education> GetL_EducationKinds()
        {
            return db.L_EducationKinds;
        }

        // GET: api/L_Education/5
        [ResponseType(typeof(L_Education))]
        public IHttpActionResult GetL_Education(long id)
        {
            L_Education l_Education = db.L_EducationKinds.Find(id);
            if (l_Education == null)
            {
                return NotFound();
            }

            return Ok(l_Education);
        }

        // PUT: api/L_Education/5
        [ResponseType(typeof(L_Education))]
        [HttpPost]
        public IHttpActionResult PutL_Education(long id, L_Education l_Education)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != l_Education.ID)
            {
                return BadRequest();
            }

            db.Entry(l_Education).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!L_EducationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(l_Education);
        }

        // POST: api/L_Education
        [ResponseType(typeof(L_Education))]
        public IHttpActionResult PostL_Education(L_Education l_Education)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.L_EducationKinds.Add(l_Education);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = l_Education.ID }, l_Education);
        }

        // DELETE: api/L_Education/5
        [ResponseType(typeof(L_Education))]
        [HttpPost]
        public IHttpActionResult DeleteL_Education(long id)
        {
            L_Education l_Education = db.L_EducationKinds.Find(id);
            if (l_Education == null)
            {
                return NotFound();
            }

            db.L_EducationKinds.Remove(l_Education);
            db.SaveChanges();

            return Ok(l_Education);
        }
        // OPTIONS: api/L_Education
        // for use with angular framework
        [HttpOptions]
        public IHttpActionResult OptionsL_Education()
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

        private bool L_EducationExists(long id)
        {
            return db.L_EducationKinds.Count(e => e.ID == id) > 0;
        }
    }
}