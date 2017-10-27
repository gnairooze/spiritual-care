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
    public class A_CC_CareContactController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/A_CC_CareContact
        public IQueryable<A_CC_CareContact> GetA_CC_CareContacts()
        {
            return db.A_CC_CareContacts;
        }

        // GET: api/A_CC_CareContact/5
        [ResponseType(typeof(A_CC_CareContact))]
        public IHttpActionResult GetA_CC_CareContact(long id)
        {
            A_CC_CareContact a_CC_CareContact = db.A_CC_CareContacts.Find(id);
            if (a_CC_CareContact == null)
            {
                return NotFound();
            }

            return Ok(a_CC_CareContact);
        }

        // PUT: api/A_CC_CareContact/5
        [ResponseType(typeof(A_CC_CareContact))]
        [HttpPost]
        public IHttpActionResult PutA_CC_CareContact(long id, A_CC_CareContact a_CC_CareContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != a_CC_CareContact.ID)
            {
                return BadRequest();
            }

            db.Entry(a_CC_CareContact).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!A_CC_CareContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(a_CC_CareContact);
        }

        // POST: api/A_CC_CareContact
        [ResponseType(typeof(A_CC_CareContact))]
        public IHttpActionResult PostA_CC_CareContact(A_CC_CareContact a_CC_CareContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.A_CC_CareContacts.Add(a_CC_CareContact);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = a_CC_CareContact.ID }, a_CC_CareContact);
        }

        // DELETE: api/A_CC_CareContact/5
        [ResponseType(typeof(A_CC_CareContact))]
        [HttpPost]
        public IHttpActionResult DeleteA_CC_CareContact(long id)
        {
            A_CC_CareContact a_CC_CareContact = db.A_CC_CareContacts.Find(id);
            if (a_CC_CareContact == null)
            {
                return NotFound();
            }

            db.A_CC_CareContacts.Remove(a_CC_CareContact);
            db.SaveChanges();

            return Ok(a_CC_CareContact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool A_CC_CareContactExists(long id)
        {
            return db.A_CC_CareContacts.Count(e => e.ID == id) > 0;
        }
    }
}