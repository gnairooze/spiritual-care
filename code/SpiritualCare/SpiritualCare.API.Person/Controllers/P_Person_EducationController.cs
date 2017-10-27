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
    public class P_Person_EducationController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/P_Person_Education
        public IQueryable<P_Person_Education> GetP_Person_Educations()
        {
            return db.P_Person_Educations;
        }

        // GET: api/P_Person_Education/5
        [ResponseType(typeof(P_Person_Education))]
        public IHttpActionResult GetP_Person_Education(long id)
        {
            P_Person_Education p_Person_Education = db.P_Person_Educations.Find(id);
            if (p_Person_Education == null)
            {
                return NotFound();
            }

            return Ok(p_Person_Education);
        }

        // PUT: api/P_Person_Education/5
        [ResponseType(typeof(P_Person_Education))]
        [HttpPost]
        public IHttpActionResult PutP_Person_Education(long id, P_Person_Education p_Person_Education)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != p_Person_Education.ID)
            {
                return BadRequest();
            }

            db.Entry(p_Person_Education).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!P_Person_EducationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(p_Person_Education);
        }

        // POST: api/P_Person_Education
        [ResponseType(typeof(P_Person_Education))]
        public IHttpActionResult PostP_Person_Education(P_Person_Education p_Person_Education)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.P_Person_Educations.Add(p_Person_Education);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = p_Person_Education.ID }, p_Person_Education);
        }

        // DELETE: api/P_Person_Education/5
        [ResponseType(typeof(P_Person_Education))]
        [HttpPost]
        public IHttpActionResult DeleteP_Person_Education(long id)
        {
            P_Person_Education p_Person_Education = db.P_Person_Educations.Find(id);
            if (p_Person_Education == null)
            {
                return NotFound();
            }

            db.P_Person_Educations.Remove(p_Person_Education);
            db.SaveChanges();

            return Ok(p_Person_Education);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool P_Person_EducationExists(long id)
        {
            return db.P_Person_Educations.Count(e => e.ID == id) > 0;
        }
    }
}