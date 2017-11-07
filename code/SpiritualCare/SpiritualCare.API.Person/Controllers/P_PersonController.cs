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
    public class P_PersonController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/P_Person
        public IQueryable<P_Person> GetP_Persons()
        {
            return db.P_Persons;
        }

        // GET: api/P_Person/5
        [ResponseType(typeof(P_Person))]
        public IHttpActionResult GetP_Person(long id)
        {
            P_Person p_Person = db.P_Persons.Find(id);
            if (p_Person == null)
            {
                return NotFound();
            }

            return Ok(p_Person);
        }

        // PUT: api/P_Person/5
        [ResponseType(typeof(P_Person))]
        [HttpPost]
        public IHttpActionResult PutP_Person(long id, P_Person p_Person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != p_Person.ID)
            {
                return BadRequest();
            }

            db.Entry(p_Person).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!P_PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(p_Person);
        }

        // POST: api/P_Person
        [ResponseType(typeof(P_Person))]
        public IHttpActionResult PostP_Person(P_Person p_Person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.P_Persons.Add(p_Person);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = p_Person.ID }, p_Person);
        }

        // DELETE: api/P_Person/5
        [ResponseType(typeof(P_Person))]
        [HttpPost]
        public IHttpActionResult DeleteP_Person(long id)
        {
            P_Person p_Person = db.P_Persons.Find(id);
            if (p_Person == null)
            {
                return NotFound();
            }

            db.P_Persons.Remove(p_Person);
            db.SaveChanges();

            return Ok(p_Person);
        }
        // OPTIONS: api/P_Person
        // for use with angular framework
        [HttpOptions]
        public IHttpActionResult OptionsP_Person()
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

        private bool P_PersonExists(long id)
        {
            return db.P_Persons.Count(e => e.ID == id) > 0;
        }
    }
}