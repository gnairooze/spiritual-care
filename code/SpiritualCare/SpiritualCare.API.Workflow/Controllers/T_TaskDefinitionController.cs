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
    public class T_TaskDefinitionController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/T_TaskDefinition
        public IQueryable<T_TaskDefinition> GetT_TaskDefinitions()
        {
            return db.T_TaskDefinitions;
        }

        // GET: api/T_TaskDefinition/5
        [ResponseType(typeof(T_TaskDefinition))]
        public IHttpActionResult GetT_TaskDefinition(long id)
        {
            T_TaskDefinition t_TaskDefinition = db.T_TaskDefinitions.Find(id);
            if (t_TaskDefinition == null)
            {
                return NotFound();
            }

            return Ok(t_TaskDefinition);
        }

        // PUT: api/T_TaskDefinition/5
        [ResponseType(typeof(T_TaskDefinition))]
        [HttpPost]
        public IHttpActionResult PutT_TaskDefinition(long id, T_TaskDefinition t_TaskDefinition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != t_TaskDefinition.ID)
            {
                return BadRequest();
            }

            db.Entry(t_TaskDefinition).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!T_TaskDefinitionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(t_TaskDefinition);
        }

        // POST: api/T_TaskDefinition
        [ResponseType(typeof(T_TaskDefinition))]
        public IHttpActionResult PostT_TaskDefinition(T_TaskDefinition t_TaskDefinition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.T_TaskDefinitions.Add(t_TaskDefinition);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = t_TaskDefinition.ID }, t_TaskDefinition);
        }

        // DELETE: api/T_TaskDefinition/5
        [ResponseType(typeof(T_TaskDefinition))]
        [HttpPost]
        public IHttpActionResult DeleteT_TaskDefinition(long id)
        {
            T_TaskDefinition t_TaskDefinition = db.T_TaskDefinitions.Find(id);
            if (t_TaskDefinition == null)
            {
                return NotFound();
            }

            db.T_TaskDefinitions.Remove(t_TaskDefinition);
            db.SaveChanges();

            return Ok(t_TaskDefinition);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool T_TaskDefinitionExists(long id)
        {
            return db.T_TaskDefinitions.Count(e => e.ID == id) > 0;
        }
    }
}