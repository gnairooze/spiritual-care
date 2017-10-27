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
using SpiritualCare.Model.Activity.CareContact;

namespace SpiritualCare.API.Activity.CareContact.Controllers
{
    public class A_CC_CareContactPersonController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/A_CC_CareContactPerson
        public IQueryable<A_CC_CareContactPerson> GetA_CC_CareContactPersons()
        {
            return db.A_CC_CareContactPersons;
        }

        // GET: api/A_CC_CareContactPerson/5
        [ResponseType(typeof(A_CC_CareContactPerson))]
        public IHttpActionResult GetA_CC_CareContactPerson(long id)
        {
            A_CC_CareContactPerson a_CC_CareContactPerson = db.A_CC_CareContactPersons.Find(id);
            if (a_CC_CareContactPerson == null)
            {
                return NotFound();
            }

            return Ok(a_CC_CareContactPerson);
        }

        // PUT: api/A_CC_CareContactPerson/5
        [ResponseType(typeof(A_CC_CareContactPerson))]
        [HttpPost]
        public IHttpActionResult PutA_CC_CareContactPerson(long id, A_CC_CareContactPerson a_CC_CareContactPerson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != a_CC_CareContactPerson.ID)
            {
                return BadRequest();
            }

            db.Entry(a_CC_CareContactPerson).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!A_CC_CareContactPersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(a_CC_CareContactPerson);
        }

        // POST: api/A_CC_CareContactPerson
        [ResponseType(typeof(A_CC_CareContactPerson))]
        public IHttpActionResult PostA_CC_CareContactPerson(A_CC_CareContactPerson a_CC_CareContactPerson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.A_CC_CareContactPersons.Add(a_CC_CareContactPerson);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = a_CC_CareContactPerson.ID }, a_CC_CareContactPerson);
        }

        // DELETE: api/A_CC_CareContactPerson/5
        [ResponseType(typeof(A_CC_CareContactPerson))]
        [HttpPost]
        public IHttpActionResult DeleteA_CC_CareContactPerson(long id)
        {
            A_CC_CareContactPerson a_CC_CareContactPerson = db.A_CC_CareContactPersons.Find(id);
            if (a_CC_CareContactPerson == null)
            {
                return NotFound();
            }

            db.A_CC_CareContactPersons.Remove(a_CC_CareContactPerson);
            db.SaveChanges();

            return Ok(a_CC_CareContactPerson);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool A_CC_CareContactPersonExists(long id)
        {
            return db.A_CC_CareContactPersons.Count(e => e.ID == id) > 0;
        }
    }
}