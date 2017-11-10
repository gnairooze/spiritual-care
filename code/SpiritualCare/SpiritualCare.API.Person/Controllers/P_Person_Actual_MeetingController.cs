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
    public class P_Person_Actual_MeetingController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/P_Person_Actual_Meeting
        public IQueryable<P_Person_Actual_Meeting> GetP_Person_Actual_Meetings()
        {
            return db.P_Person_Actual_Meetings;
        }

        // GET: api/P_Person_Actual_Meeting/5
        [ResponseType(typeof(P_Person_Actual_Meeting))]
        public IHttpActionResult GetP_Person_Actual_Meeting(long id)
        {
            P_Person_Actual_Meeting p_Person_Actual_Meeting = db.P_Person_Actual_Meetings.Find(id);
            if (p_Person_Actual_Meeting == null)
            {
                return NotFound();
            }

            return Ok(p_Person_Actual_Meeting);
        }

        // PUT: api/P_Person_Actual_Meeting/5
        [ResponseType(typeof(P_Person_Actual_Meeting))]
        [HttpPost]
        public IHttpActionResult PutP_Person_Actual_Meeting(long id, P_Person_Actual_Meeting p_Person_Actual_Meeting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != p_Person_Actual_Meeting.ID)
            {
                return BadRequest();
            }

            db.Entry(p_Person_Actual_Meeting).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!P_Person_Actual_MeetingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(p_Person_Actual_Meeting);
        }

        // POST: api/P_Person_Actual_Meeting
        [ResponseType(typeof(P_Person_Actual_Meeting))]
        public IHttpActionResult PostP_Person_Actual_Meeting(P_Person_Actual_Meeting p_Person_Actual_Meeting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.P_Person_Actual_Meetings.Add(p_Person_Actual_Meeting);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = p_Person_Actual_Meeting.ID }, p_Person_Actual_Meeting);
        }

        // DELETE: api/P_Person_Actual_Meeting/5
        [ResponseType(typeof(P_Person_Actual_Meeting))]
        [HttpPost]
        public IHttpActionResult DeleteP_Person_Actual_Meeting(long id)
        {
            P_Person_Actual_Meeting p_Person_Actual_Meeting = db.P_Person_Actual_Meetings.Find(id);
            if (p_Person_Actual_Meeting == null)
            {
                return NotFound();
            }

            db.P_Person_Actual_Meetings.Remove(p_Person_Actual_Meeting);
            db.SaveChanges();

            return Ok(p_Person_Actual_Meeting);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool P_Person_Actual_MeetingExists(long id)
        {
            return db.P_Person_Actual_Meetings.Count(e => e.ID == id) > 0;
        }
    }
}