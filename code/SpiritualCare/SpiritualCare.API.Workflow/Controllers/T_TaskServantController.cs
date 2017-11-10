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
    public class T_TaskServantController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/T_TaskServant
        public IQueryable<T_TaskServant> GetT_TaskServants()
        {
            return db.T_TaskServants;
        }

        // GET: api/T_TaskServant/5
        [ResponseType(typeof(T_TaskServant))]
        public IHttpActionResult GetT_TaskServant(long id)
        {
            T_TaskServant t_TaskServant = db.T_TaskServants.Find(id);
            if (t_TaskServant == null)
            {
                return NotFound();
            }

            return Ok(t_TaskServant);
        }

        // PUT: api/T_TaskServant/5
        [ResponseType(typeof(T_TaskServant))]
        [HttpPost]
        public IHttpActionResult PutT_TaskServant(long id, T_TaskServant t_TaskServant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != t_TaskServant.ID)
            {
                return BadRequest();
            }

            db.Entry(t_TaskServant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!T_TaskServantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(t_TaskServant);
        }

        // POST: api/T_TaskServant
        [ResponseType(typeof(T_TaskServant))]
        public IHttpActionResult PostT_TaskServant(T_TaskServant t_TaskServant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.T_TaskServants.Add(t_TaskServant);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = t_TaskServant.ID }, t_TaskServant);
        }

        // DELETE: api/T_TaskServant/5
        [ResponseType(typeof(T_TaskServant))]
        [HttpPost]
        public IHttpActionResult DeleteT_TaskServant(long id)
        {
            T_TaskServant t_TaskServant = db.T_TaskServants.Find(id);
            if (t_TaskServant == null)
            {
                return NotFound();
            }

            db.T_TaskServants.Remove(t_TaskServant);
            db.SaveChanges();

            return Ok(t_TaskServant);
        }
       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool T_TaskServantExists(long id)
        {
            return db.T_TaskServants.Count(e => e.ID == id) > 0;
        }
    }
}