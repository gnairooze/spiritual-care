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
using SpiritualCare.Model.Task;

namespace SpiritualCare.API.Workflow.Controllers
{
    public class T_TaskPersonController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/T_TaskPerson
        public IQueryable<T_TaskPerson> GetT_TaskPersons()
        {
            return db.T_TaskPersons;
        }

        // GET: api/T_TaskPerson/5
        [ResponseType(typeof(T_TaskPerson))]
        public IHttpActionResult GetT_TaskPerson(long id)
        {
            T_TaskPerson t_TaskPerson = db.T_TaskPersons.Find(id);
            if (t_TaskPerson == null)
            {
                return NotFound();
            }

            return Ok(t_TaskPerson);
        }

        // PUT: api/T_TaskPerson/5
        [ResponseType(typeof(T_TaskPerson))]
        [HttpPost]
        public IHttpActionResult PutT_TaskPerson(long id, T_TaskPerson t_TaskPerson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != t_TaskPerson.ID)
            {
                return BadRequest();
            }

            db.Entry(t_TaskPerson).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!T_TaskPersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(t_TaskPerson);
        }

        // POST: api/T_TaskPerson
        [ResponseType(typeof(T_TaskPerson))]
        public IHttpActionResult PostT_TaskPerson(T_TaskPerson t_TaskPerson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.T_TaskPersons.Add(t_TaskPerson);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = t_TaskPerson.ID }, t_TaskPerson);
        }

        // DELETE: api/T_TaskPerson/5
        [ResponseType(typeof(T_TaskPerson))]
        [HttpPost]
        public IHttpActionResult DeleteT_TaskPerson(long id)
        {
            T_TaskPerson t_TaskPerson = db.T_TaskPersons.Find(id);
            if (t_TaskPerson == null)
            {
                return NotFound();
            }

            db.T_TaskPersons.Remove(t_TaskPerson);
            db.SaveChanges();

            return Ok(t_TaskPerson);
        }
       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool T_TaskPersonExists(long id)
        {
            return db.T_TaskPersons.Count(e => e.ID == id) > 0;
        }
    }
}