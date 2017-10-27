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
    public class P_ViberController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/P_Viber
        public IQueryable<P_Viber> GetP_Vibers()
        {
            return db.P_Vibers;
        }

        // GET: api/P_Viber/5
        [ResponseType(typeof(P_Viber))]
        public IHttpActionResult GetP_Viber(long id)
        {
            P_Viber p_Viber = db.P_Vibers.Find(id);
            if (p_Viber == null)
            {
                return NotFound();
            }

            return Ok(p_Viber);
        }

        // PUT: api/P_Viber/5
        [ResponseType(typeof(P_Viber))]
        [HttpPost]
        public IHttpActionResult PutP_Viber(long id, P_Viber p_Viber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != p_Viber.ID)
            {
                return BadRequest();
            }

            db.Entry(p_Viber).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!P_ViberExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(p_Viber);
        }

        // POST: api/P_Viber
        [ResponseType(typeof(P_Viber))]
        public IHttpActionResult PostP_Viber(P_Viber p_Viber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.P_Vibers.Add(p_Viber);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = p_Viber.ID }, p_Viber);
        }

        // DELETE: api/P_Viber/5
        [ResponseType(typeof(P_Viber))]
        [HttpPost]
        public IHttpActionResult DeleteP_Viber(long id)
        {
            P_Viber p_Viber = db.P_Vibers.Find(id);
            if (p_Viber == null)
            {
                return NotFound();
            }

            db.P_Vibers.Remove(p_Viber);
            db.SaveChanges();

            return Ok(p_Viber);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool P_ViberExists(long id)
        {
            return db.P_Vibers.Count(e => e.ID == id) > 0;
        }
    }
}