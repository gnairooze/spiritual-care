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
    public class P_Person_PersonController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/P_Person_Person
        public IQueryable<P_Person_Person> GetP_Person_Persons()
        {
            return db.P_Person_Persons;
        }

        // GET: api/P_Person_Person/5
        [ResponseType(typeof(P_Person_Person))]
        public IHttpActionResult GetP_Person_Person(long id)
        {
            P_Person_Person p_Person_Person = db.P_Person_Persons.Find(id);
            if (p_Person_Person == null)
            {
                return NotFound();
            }

            return Ok(p_Person_Person);
        }

        // PUT: api/P_Person_Person/5
        [ResponseType(typeof(P_Person_Person))]
        [HttpPost]
        public IHttpActionResult PutP_Person_Person(long id, P_Person_Person p_Person_Person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != p_Person_Person.ID)
            {
                return BadRequest();
            }

            db.Entry(p_Person_Person).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!P_Person_PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(p_Person_Person);
        }

        // POST: api/P_Person_Person
        [ResponseType(typeof(P_Person_Person))]
        public IHttpActionResult PostP_Person_Person(P_Person_Person p_Person_Person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.P_Person_Persons.Add(p_Person_Person);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = p_Person_Person.ID }, p_Person_Person);
        }

        // DELETE: api/P_Person_Person/5
        [ResponseType(typeof(P_Person_Person))]
        [HttpPost]
        public IHttpActionResult DeleteP_Person_Person(long id)
        {
            P_Person_Person p_Person_Person = db.P_Person_Persons.Find(id);
            if (p_Person_Person == null)
            {
                return NotFound();
            }

            db.P_Person_Persons.Remove(p_Person_Person);
            db.SaveChanges();

            return Ok(p_Person_Person);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool P_Person_PersonExists(long id)
        {
            return db.P_Person_Persons.Count(e => e.ID == id) > 0;
        }
    }
}