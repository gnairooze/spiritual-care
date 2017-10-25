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
    public class L_JobController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/L_Job
        public IQueryable<L_Job> GetL_Jobs()
        {
            return db.L_Jobs;
        }

        // GET: api/L_Job/5
        [ResponseType(typeof(L_Job))]
        public IHttpActionResult GetL_Job(long id)
        {
            L_Job l_Job = db.L_Jobs.Find(id);
            if (l_Job == null)
            {
                return NotFound();
            }

            return Ok(l_Job);
        }

        // PUT: api/L_Job/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult PutL_Job(long id, L_Job l_Job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != l_Job.ID)
            {
                return BadRequest();
            }

            db.Entry(l_Job).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!L_JobExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(l_Job);
        }

        // POST: api/L_Job
        [ResponseType(typeof(L_Job))]
        public IHttpActionResult PostL_Job(L_Job l_Job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.L_Jobs.Add(l_Job);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = l_Job.ID }, l_Job);
        }

        // DELETE: api/L_Job/5
        [ResponseType(typeof(L_Job))]
        [HttpPost]
        public IHttpActionResult DeleteL_Job(long id)
        {
            L_Job l_Job = db.L_Jobs.Find(id);
            if (l_Job == null)
            {
                return NotFound();
            }

            db.L_Jobs.Remove(l_Job);
            db.SaveChanges();

            return Ok(l_Job);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool L_JobExists(long id)
        {
            return db.L_Jobs.Count(e => e.ID == id) > 0;
        }
    }
}