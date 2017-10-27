
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
    public class P_FacebookController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/P_Facebook
        public IQueryable<P_Facebook> GetP_Facebooks()
        {
            return db.P_Facebooks;
        }

        // GET: api/P_Facebook/5
        [ResponseType(typeof(P_Facebook))]
        public IHttpActionResult GetP_Facebook(long id)
        {
            P_Facebook p_Facebook = db.P_Facebooks.Find(id);
            if (p_Facebook == null)
            {
                return NotFound();
            }

            return Ok(p_Facebook);
        }

        // PUT: api/P_Facebook/5
        [ResponseType(typeof(P_Facebook))]
        [HttpPost]
        public IHttpActionResult PutP_Facebook(long id, P_Facebook p_Facebook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != p_Facebook.ID)
            {
                return BadRequest();
            }

            db.Entry(p_Facebook).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!P_FacebookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(p_Facebook);
        }

        // POST: api/P_Facebook
        [ResponseType(typeof(P_Facebook))]
        public IHttpActionResult PostP_Facebook(P_Facebook p_Facebook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.P_Facebooks.Add(p_Facebook);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = p_Facebook.ID }, p_Facebook);
        }

        // DELETE: api/P_Facebook/5
        [ResponseType(typeof(P_Facebook))]
        [HttpPost]
        public IHttpActionResult DeleteP_Facebook(long id)
        {
            P_Facebook p_Facebook = db.P_Facebooks.Find(id);
            if (p_Facebook == null)
            {
                return NotFound();
            }

            db.P_Facebooks.Remove(p_Facebook);
            db.SaveChanges();

            return Ok(p_Facebook);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool P_FacebookExists(long id)
        {
            return db.P_Facebooks.Count(e => e.ID == id) > 0;
        }
    }
}