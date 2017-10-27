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
    public class P_ContactWay1Controller : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/P_ContactWay1
        public IQueryable<P_ContactWay1> GetP_ContactWay1()
        {
            return db.P_ContactWay1;
        }

        // GET: api/P_ContactWay1/5
        [ResponseType(typeof(P_ContactWay1))]
        public IHttpActionResult GetP_ContactWay1(long id)
        {
            P_ContactWay1 p_ContactWay1 = db.P_ContactWay1.Find(id);
            if (p_ContactWay1 == null)
            {
                return NotFound();
            }

            return Ok(p_ContactWay1);
        }

        // PUT: api/P_ContactWay1/5
        [ResponseType(typeof(P_ContactWay1))]
        [HttpPost]
        public IHttpActionResult PutP_ContactWay1(long id, P_ContactWay1 p_ContactWay1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != p_ContactWay1.ID)
            {
                return BadRequest();
            }

            db.Entry(p_ContactWay1).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!P_ContactWay1Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(p_ContactWay1);
        }

        // POST: api/P_ContactWay1
        [ResponseType(typeof(P_ContactWay1))]
        public IHttpActionResult PostP_ContactWay1(P_ContactWay1 p_ContactWay1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.P_ContactWay1.Add(p_ContactWay1);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = p_ContactWay1.ID }, p_ContactWay1);
        }

        // DELETE: api/P_ContactWay1/5
        [ResponseType(typeof(P_ContactWay1))]
        [HttpPost]
        public IHttpActionResult DeleteP_ContactWay1(long id)
        {
            P_ContactWay1 p_ContactWay1 = db.P_ContactWay1.Find(id);
            if (p_ContactWay1 == null)
            {
                return NotFound();
            }

            db.P_ContactWay1.Remove(p_ContactWay1);
            db.SaveChanges();

            return Ok(p_ContactWay1);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool P_ContactWay1Exists(long id)
        {
            return db.P_ContactWay1.Count(e => e.ID == id) > 0;
        }
    }
}