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
    public class L_ProfessionController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/L_Profession
        public IQueryable<L_Profession> GetL_Professions()
        {
            return db.L_Professions;
        }

        // GET: api/L_Profession/5
        [ResponseType(typeof(L_Profession))]
        public IHttpActionResult GetL_Profession(long id)
        {
            L_Profession l_Profession = db.L_Professions.Find(id);
            if (l_Profession == null)
            {
                return NotFound();
            }

            return Ok(l_Profession);
        }

        // PUT: api/L_Profession/5
        [ResponseType(typeof(L_Profession))]
        [HttpPost]
        public IHttpActionResult PutL_Profession(long id, L_Profession l_Profession)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != l_Profession.ID)
            {
                return BadRequest();
            }

            db.Entry(l_Profession).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!L_ProfessionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(l_Profession);
        }

        // POST: api/L_Profession
        [ResponseType(typeof(L_Profession))]
        public IHttpActionResult PostL_Profession(L_Profession l_Profession)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.L_Professions.Add(l_Profession);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = l_Profession.ID }, l_Profession);
        }

        // DELETE: api/L_Profession/5
        [ResponseType(typeof(L_Profession))]
        [HttpPost]
        public IHttpActionResult DeleteL_Profession(long id)
        {
            L_Profession l_Profession = db.L_Professions.Find(id);
            if (l_Profession == null)
            {
                return NotFound();
            }

            db.L_Professions.Remove(l_Profession);
            db.SaveChanges();

            return Ok(l_Profession);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool L_ProfessionExists(long id)
        {
            return db.L_Professions.Count(e => e.ID == id) > 0;
        }
    }
}