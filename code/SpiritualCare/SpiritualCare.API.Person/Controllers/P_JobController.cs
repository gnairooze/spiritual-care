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
    public class P_JobController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/P_Job
        public IQueryable<P_Job> GetP_Jobs()
        {
            return db.P_Jobs;
        }

        // GET: api/P_Job/5
        [ResponseType(typeof(P_Job))]
        public IHttpActionResult GetP_Job(long id)
        {
            P_Job p_Job = db.P_Jobs.Find(id);
            if (p_Job == null)
            {
                return NotFound();
            }

            return Ok(p_Job);
        }

        // PUT: api/P_Job/5
        [ResponseType(typeof(P_Job))]
        [HttpPost]
        public IHttpActionResult PutP_Job(long id, P_Job p_Job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != p_Job.ID)
            {
                return BadRequest();
            }

            db.Entry(p_Job).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!P_JobExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(p_Job);
        }

        // POST: api/P_Job
        [ResponseType(typeof(P_Job))]
        public IHttpActionResult PostP_Job(P_Job p_Job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.P_Jobs.Add(p_Job);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = p_Job.ID }, p_Job);
        }

        // DELETE: api/P_Job/5
        [ResponseType(typeof(P_Job))]
        [HttpPost]
        public IHttpActionResult DeleteP_Job(long id)
        {
            P_Job p_Job = db.P_Jobs.Find(id);
            if (p_Job == null)
            {
                return NotFound();
            }

            db.P_Jobs.Remove(p_Job);
            db.SaveChanges();

            return Ok(p_Job);
        }
        // OPTIONS: api/P_Job
        // for use with angular framework
        [HttpOptions]
        public IHttpActionResult OptionsP_Job()
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

        private bool P_JobExists(long id)
        {
            return db.P_Jobs.Count(e => e.ID == id) > 0;
        }
    }
}