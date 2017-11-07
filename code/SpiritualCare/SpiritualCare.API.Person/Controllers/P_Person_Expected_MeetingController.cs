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
    public class P_Person_Expected_MeetingController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/P_Person_Expected_Meeting
        public IQueryable<P_Person_Expected_Meeting> GetP_Person_Expected_Meetings()
        {
            return db.P_Person_Expected_Meetings;
        }

        // GET: api/P_Person_Expected_Meeting/5
        [ResponseType(typeof(P_Person_Expected_Meeting))]
        public IHttpActionResult GetP_Person_Expected_Meeting(long id)
        {
            P_Person_Expected_Meeting p_Person_Expected_Meeting = db.P_Person_Expected_Meetings.Find(id);
            if (p_Person_Expected_Meeting == null)
            {
                return NotFound();
            }

            return Ok(p_Person_Expected_Meeting);
        }

        // PUT: api/P_Person_Expected_Meeting/5
        [ResponseType(typeof(P_Person_Expected_Meeting))]
        [HttpPost]
        public IHttpActionResult PutP_Person_Expected_Meeting(long id, P_Person_Expected_Meeting p_Person_Expected_Meeting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != p_Person_Expected_Meeting.ID)
            {
                return BadRequest();
            }

            db.Entry(p_Person_Expected_Meeting).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!P_Person_Expected_MeetingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(p_Person_Expected_Meeting);
        }

        // POST: api/P_Person_Expected_Meeting
        [ResponseType(typeof(P_Person_Expected_Meeting))]
        public IHttpActionResult PostP_Person_Expected_Meeting(P_Person_Expected_Meeting p_Person_Expected_Meeting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.P_Person_Expected_Meetings.Add(p_Person_Expected_Meeting);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = p_Person_Expected_Meeting.ID }, p_Person_Expected_Meeting);
        }

        // DELETE: api/P_Person_Expected_Meeting/5
        [ResponseType(typeof(P_Person_Expected_Meeting))]
        [HttpPost]
        public IHttpActionResult DeleteP_Person_Expected_Meeting(long id)
        {
            P_Person_Expected_Meeting p_Person_Expected_Meeting = db.P_Person_Expected_Meetings.Find(id);
            if (p_Person_Expected_Meeting == null)
            {
                return NotFound();
            }

            db.P_Person_Expected_Meetings.Remove(p_Person_Expected_Meeting);
            db.SaveChanges();

            return Ok(p_Person_Expected_Meeting);
        }
        // OPTIONS: api/P_Person_Expected_Meeting
        // for use with angular framework
        [HttpOptions]
        public IHttpActionResult OptionsP_Person_Expected_Meeting()
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

        private bool P_Person_Expected_MeetingExists(long id)
        {
            return db.P_Person_Expected_Meetings.Count(e => e.ID == id) > 0;
        }
    }
}