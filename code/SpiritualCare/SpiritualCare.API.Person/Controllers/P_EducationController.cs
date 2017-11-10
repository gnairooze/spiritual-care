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
using SpiritualCare.Model.Person;

namespace SpiritualCare.API.Person.Controllers
{
    public class P_EducationController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/P_Education
        public IQueryable<P_Education> GetP_Educations()
        {
            return db.P_Educations;
        }

        // GET: api/P_Education/5
        [ResponseType(typeof(P_Education))]
        public IHttpActionResult GetP_Education(long id)
        {
            P_Education p_Education = db.P_Educations.Find(id);
            if (p_Education == null)
            {
                return NotFound();
            }

            return Ok(p_Education);
        }

        // PUT: api/P_Education/5
        [ResponseType(typeof(P_Education))]
        [HttpPost]
        public IHttpActionResult PutP_Education(long id, P_Education p_Education)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != p_Education.ID)
            {
                return BadRequest();
            }

            db.Entry(p_Education).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!P_EducationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(p_Education);
        }

        // POST: api/P_Education
        [ResponseType(typeof(P_Education))]
        public IHttpActionResult PostP_Education(P_Education p_Education)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.P_Educations.Add(p_Education);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = p_Education.ID }, p_Education);
        }

        // DELETE: api/P_Education/5
        [ResponseType(typeof(P_Education))]
        [HttpPost]
        public IHttpActionResult DeleteP_Education(long id)
        {
            P_Education p_Education = db.P_Educations.Find(id);
            if (p_Education == null)
            {
                return NotFound();
            }

            db.P_Educations.Remove(p_Education);
            db.SaveChanges();

            return Ok(p_Education);
        }
       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool P_EducationExists(long id)
        {
            return db.P_Educations.Count(e => e.ID == id) > 0;
        }
    }
}