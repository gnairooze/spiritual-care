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
    public class P_EmailController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/P_Email
        public IQueryable<P_Email> GetP_Emails()
        {
            return db.P_Emails;
        }

        // GET: api/P_Email/5
        [ResponseType(typeof(P_Email))]
        public IHttpActionResult GetP_Email(long id)
        {
            P_Email p_Email = db.P_Emails.Find(id);
            if (p_Email == null)
            {
                return NotFound();
            }

            return Ok(p_Email);
        }

        // PUT: api/P_Email/5
        [ResponseType(typeof(P_Email))]
        [HttpPost]
        public IHttpActionResult PutP_Email(long id, P_Email p_Email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != p_Email.ID)
            {
                return BadRequest();
            }

            db.Entry(p_Email).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!P_EmailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(p_Email);
        }

        // POST: api/P_Email
        [ResponseType(typeof(P_Email))]
        public IHttpActionResult PostP_Email(P_Email p_Email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.P_Emails.Add(p_Email);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = p_Email.ID }, p_Email);
        }

        // DELETE: api/P_Email/5
        [ResponseType(typeof(P_Email))]
        [HttpPost]
        public IHttpActionResult DeleteP_Email(long id)
        {
            P_Email p_Email = db.P_Emails.Find(id);
            if (p_Email == null)
            {
                return NotFound();
            }

            db.P_Emails.Remove(p_Email);
            db.SaveChanges();

            return Ok(p_Email);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool P_EmailExists(long id)
        {
            return db.P_Emails.Count(e => e.ID == id) > 0;
        }
    }
}