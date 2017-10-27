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
    public class P_Person_JobController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/P_Person_Job
        public IQueryable<P_Person_Job> GetP_Person_Jobs()
        {
            return db.P_Person_Jobs;
        }

        // GET: api/P_Person_Job/5
        [ResponseType(typeof(P_Person_Job))]
        public IHttpActionResult GetP_Person_Job(long id)
        {
            P_Person_Job p_Person_Job = db.P_Person_Jobs.Find(id);
            if (p_Person_Job == null)
            {
                return NotFound();
            }

            return Ok(p_Person_Job);
        }

        // PUT: api/P_Person_Job/5
        [ResponseType(typeof(P_Person_Job))]
        [HttpPost]
        public IHttpActionResult PutP_Person_Job(long id, P_Person_Job p_Person_Job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != p_Person_Job.ID)
            {
                return BadRequest();
            }

            db.Entry(p_Person_Job).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!P_Person_JobExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(p_Person_Job);
        }

        // POST: api/P_Person_Job
        [ResponseType(typeof(P_Person_Job))]
        public IHttpActionResult PostP_Person_Job(P_Person_Job p_Person_Job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.P_Person_Jobs.Add(p_Person_Job);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = p_Person_Job.ID }, p_Person_Job);
        }

        // DELETE: api/P_Person_Job/5
        [ResponseType(typeof(P_Person_Job))]
        [HttpPost]
        public IHttpActionResult DeleteP_Person_Job(long id)
        {
            P_Person_Job p_Person_Job = db.P_Person_Jobs.Find(id);
            if (p_Person_Job == null)
            {
                return NotFound();
            }

            db.P_Person_Jobs.Remove(p_Person_Job);
            db.SaveChanges();

            return Ok(p_Person_Job);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool P_Person_JobExists(long id)
        {
            return db.P_Person_Jobs.Count(e => e.ID == id) > 0;
        }
    }
}