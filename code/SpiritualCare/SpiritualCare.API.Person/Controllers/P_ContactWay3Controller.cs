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
    public class P_ContactWay3Controller : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/P_ContactWay3
        public IQueryable<P_ContactWay3> GetP_ContactWay3()
        {
            return db.P_ContactWay3;
        }

        // GET: api/P_ContactWay3/5
        [ResponseType(typeof(P_ContactWay3))]
        public IHttpActionResult GetP_ContactWay3(long id)
        {
            P_ContactWay3 p_ContactWay3 = db.P_ContactWay3.Find(id);
            if (p_ContactWay3 == null)
            {
                return NotFound();
            }

            return Ok(p_ContactWay3);
        }

        // PUT: api/P_ContactWay3/5
        [ResponseType(typeof(P_ContactWay3))]
        [HttpPost]
        public IHttpActionResult PutP_ContactWay3(long id, P_ContactWay3 p_ContactWay3)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != p_ContactWay3.ID)
            {
                return BadRequest();
            }

            db.Entry(p_ContactWay3).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!P_ContactWay3Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(p_ContactWay3);
        }

        // POST: api/P_ContactWay3
        [ResponseType(typeof(P_ContactWay3))]
        public IHttpActionResult PostP_ContactWay3(P_ContactWay3 p_ContactWay3)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.P_ContactWay3.Add(p_ContactWay3);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = p_ContactWay3.ID }, p_ContactWay3);
        }

        // DELETE: api/P_ContactWay3/5
        [ResponseType(typeof(P_ContactWay3))]
        [HttpPost]
        public IHttpActionResult DeleteP_ContactWay3(long id)
        {
            P_ContactWay3 p_ContactWay3 = db.P_ContactWay3.Find(id);
            if (p_ContactWay3 == null)
            {
                return NotFound();
            }

            db.P_ContactWay3.Remove(p_ContactWay3);
            db.SaveChanges();

            return Ok(p_ContactWay3);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool P_ContactWay3Exists(long id)
        {
            return db.P_ContactWay3.Count(e => e.ID == id) > 0;
        }
    }
}