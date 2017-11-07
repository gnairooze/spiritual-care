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
    public class L_SocialStatusController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/L_SocialStatus
        public IQueryable<L_SocialStatus> GetL_SocialStatuses()
        {
            return db.L_SocialStatuses;
        }

        // GET: api/L_SocialStatus/5
        [ResponseType(typeof(L_SocialStatus))]
        public IHttpActionResult GetL_SocialStatus(long id)
        {
            L_SocialStatus l_SocialStatus = db.L_SocialStatuses.Find(id);
            if (l_SocialStatus == null)
            {
                return NotFound();
            }

            return Ok(l_SocialStatus);
        }

        // PUT: api/L_SocialStatus/5
        [ResponseType(typeof(L_SocialStatus))]
        [HttpPost]
        public IHttpActionResult PutL_SocialStatus(long id, L_SocialStatus l_SocialStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != l_SocialStatus.ID)
            {
                return BadRequest();
            }

            db.Entry(l_SocialStatus).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!L_SocialStatusExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(l_SocialStatus);
        }

        // POST: api/L_SocialStatus
        [ResponseType(typeof(L_SocialStatus))]
        public IHttpActionResult PostL_SocialStatus(L_SocialStatus l_SocialStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.L_SocialStatuses.Add(l_SocialStatus);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = l_SocialStatus.ID }, l_SocialStatus);
        }

        // DELETE: api/L_SocialStatus/5
        [ResponseType(typeof(L_SocialStatus))]
        [HttpPost]
        public IHttpActionResult DeleteL_SocialStatus(long id)
        {
            L_SocialStatus l_SocialStatus = db.L_SocialStatuses.Find(id);
            if (l_SocialStatus == null)
            {
                return NotFound();
            }

            db.L_SocialStatuses.Remove(l_SocialStatus);
            db.SaveChanges();

            return Ok(l_SocialStatus);
        }
        // OPTIONS: api/L_SocialStatus
        // for use with angular framework
        [HttpOptions]
        public IHttpActionResult OptionsL_SocialStatus()
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

        private bool L_SocialStatusExists(long id)
        {
            return db.L_SocialStatuses.Count(e => e.ID == id) > 0;
        }
    }
}