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
    public class T_TaskController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/T_Task
        public IQueryable<T_Task> GetT_Tasks()
        {
            return db.T_Tasks;
        }

        // GET: api/T_Task/5
        [ResponseType(typeof(T_Task))]
        public IHttpActionResult GetT_Task(long id)
        {
            T_Task t_Task = db.T_Tasks.Find(id);
            if (t_Task == null)
            {
                return NotFound();
            }

            return Ok(t_Task);
        }

        // PUT: api/T_Task/5
        [ResponseType(typeof(T_Task))]
        [HttpPost]
        public IHttpActionResult PutT_Task(long id, T_Task t_Task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != t_Task.ID)
            {
                return BadRequest();
            }

            db.Entry(t_Task).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!T_TaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(t_Task);
        }

        // POST: api/T_Task
        [ResponseType(typeof(T_Task))]
        public IHttpActionResult PostT_Task(T_Task t_Task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.T_Tasks.Add(t_Task);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = t_Task.ID }, t_Task);
        }

        // DELETE: api/T_Task/5
        [ResponseType(typeof(T_Task))]
        [HttpPost]
        public IHttpActionResult DeleteT_Task(long id)
        {
            T_Task t_Task = db.T_Tasks.Find(id);
            if (t_Task == null)
            {
                return NotFound();
            }

            db.T_Tasks.Remove(t_Task);
            db.SaveChanges();

            return Ok(t_Task);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool T_TaskExists(long id)
        {
            return db.T_Tasks.Count(e => e.ID == id) > 0;
        }
    }
}