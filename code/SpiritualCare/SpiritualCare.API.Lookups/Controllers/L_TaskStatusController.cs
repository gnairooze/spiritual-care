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
    public class L_TaskStatusController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/L_TaskStatus
        public IQueryable<L_TaskStatus> GetL_TaskStatuses()
        {
            return db.L_TaskStatuses;
        }

        // GET: api/L_TaskStatus/5
        [ResponseType(typeof(L_TaskStatus))]
        public IHttpActionResult GetL_TaskStatus(long id)
        {
            L_TaskStatus l_TaskStatus = db.L_TaskStatuses.Find(id);
            if (l_TaskStatus == null)
            {
                return NotFound();
            }

            return Ok(l_TaskStatus);
        }

        // PUT: api/L_TaskStatus/5
        [ResponseType(typeof(L_TaskStatus))]
        [HttpPost]
        public IHttpActionResult PutL_TaskStatus(long id, L_TaskStatus l_TaskStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != l_TaskStatus.ID)
            {
                return BadRequest();
            }

            db.Entry(l_TaskStatus).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!L_TaskStatusExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(l_TaskStatus);
        }

        // POST: api/L_TaskStatus
        [ResponseType(typeof(L_TaskStatus))]
        public IHttpActionResult PostL_TaskStatus(L_TaskStatus l_TaskStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.L_TaskStatuses.Add(l_TaskStatus);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = l_TaskStatus.ID }, l_TaskStatus);
        }

        // DELETE: api/L_TaskStatus/5
        [ResponseType(typeof(L_TaskStatus))]
        [HttpPost]
        public IHttpActionResult DeleteL_TaskStatus(long id)
        {
            L_TaskStatus l_TaskStatus = db.L_TaskStatuses.Find(id);
            if (l_TaskStatus == null)
            {
                return NotFound();
            }

            db.L_TaskStatuses.Remove(l_TaskStatus);
            db.SaveChanges();

            return Ok(l_TaskStatus);
        }
        // OPTIONS: api/L_TaskStatus
        // for use with angular framework
        [HttpOptions]
        public IHttpActionResult OptionsL_TaskStatus()
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

        private bool L_TaskStatusExists(long id)
        {
            return db.L_TaskStatuses.Count(e => e.ID == id) > 0;
        }
    }
}