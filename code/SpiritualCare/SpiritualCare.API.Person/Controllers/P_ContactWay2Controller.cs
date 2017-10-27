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
    public class P_ContactWay2Controller : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/P_ContactWay2
        public IQueryable<P_ContactWay2> GetP_ContactWay2()
        {
            return db.P_ContactWay2;
        }

        // GET: api/P_ContactWay2/5
        [ResponseType(typeof(P_ContactWay2))]
        public IHttpActionResult GetP_ContactWay2(long id)
        {
            P_ContactWay2 p_ContactWay2 = db.P_ContactWay2.Find(id);
            if (p_ContactWay2 == null)
            {
                return NotFound();
            }

            return Ok(p_ContactWay2);
        }

        // PUT: api/P_ContactWay2/5
        [ResponseType(typeof(P_ContactWay2))]
        [HttpPost]
        public IHttpActionResult PutP_ContactWay2(long id, P_ContactWay2 p_ContactWay2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != p_ContactWay2.ID)
            {
                return BadRequest();
            }

            db.Entry(p_ContactWay2).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!P_ContactWay2Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(p_ContactWay2);
        }

        // POST: api/P_ContactWay2
        [ResponseType(typeof(P_ContactWay2))]
        public IHttpActionResult PostP_ContactWay2(P_ContactWay2 p_ContactWay2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.P_ContactWay2.Add(p_ContactWay2);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = p_ContactWay2.ID }, p_ContactWay2);
        }

        // DELETE: api/P_ContactWay2/5
        [ResponseType(typeof(P_ContactWay2))]
        [HttpPost]
        public IHttpActionResult DeleteP_ContactWay2(long id)
        {
            P_ContactWay2 p_ContactWay2 = db.P_ContactWay2.Find(id);
            if (p_ContactWay2 == null)
            {
                return NotFound();
            }

            db.P_ContactWay2.Remove(p_ContactWay2);
            db.SaveChanges();

            return Ok(p_ContactWay2);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool P_ContactWay2Exists(long id)
        {
            return db.P_ContactWay2.Count(e => e.ID == id) > 0;
        }
    }
}