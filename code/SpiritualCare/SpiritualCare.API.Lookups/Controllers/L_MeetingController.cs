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
    public class L_MeetingController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/L_Meeting
        public IQueryable<L_Meeting> GetL_Meetings()
        {
            return db.L_Meetings;
        }

        // GET: api/L_Meeting/5
        [ResponseType(typeof(L_Meeting))]
        public IHttpActionResult GetL_Meeting(long id)
        {
            L_Meeting l_Meeting = db.L_Meetings.Find(id);
            if (l_Meeting == null)
            {
                return NotFound();
            }

            return Ok(l_Meeting);
        }

        // PUT: api/L_Meeting/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult PutL_Meeting(long id, L_Meeting l_Meeting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != l_Meeting.ID)
            {
                return BadRequest();
            }

            db.Entry(l_Meeting).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!L_MeetingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(l_Meeting);
        }

        // POST: api/L_Meeting
        [ResponseType(typeof(L_Meeting))]
        public IHttpActionResult PostL_Meeting(L_Meeting l_Meeting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.L_Meetings.Add(l_Meeting);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = l_Meeting.ID }, l_Meeting);
        }

        // DELETE: api/L_Meeting/5
        [ResponseType(typeof(L_Meeting))]
        [HttpPost]
        public IHttpActionResult DeleteL_Meeting(long id)
        {
            L_Meeting l_Meeting = db.L_Meetings.Find(id);
            if (l_Meeting == null)
            {
                return NotFound();
            }

            db.L_Meetings.Remove(l_Meeting);
            db.SaveChanges();

            return Ok(l_Meeting);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool L_MeetingExists(long id)
        {
            return db.L_Meetings.Count(e => e.ID == id) > 0;
        }
    }
}