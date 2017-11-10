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
    public class P_PhoneController : ApiController
    {
        private SpiritualCareContext db = new SpiritualCareContext();

        // GET: api/P_Phone
        public IQueryable<P_Phone> GetP_Phones()
        {
            return db.P_Phones;
        }

        // GET: api/P_Phone/5
        [ResponseType(typeof(P_Phone))]
        public IHttpActionResult GetP_Phone(long id)
        {
            P_Phone p_Phone = db.P_Phones.Find(id);
            if (p_Phone == null)
            {
                return NotFound();
            }

            return Ok(p_Phone);
        }

        // PUT: api/P_Phone/5
        [ResponseType(typeof(P_Phone))]
        [HttpPost]
        public IHttpActionResult PutP_Phone(long id, P_Phone p_Phone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != p_Phone.ID)
            {
                return BadRequest();
            }

            db.Entry(p_Phone).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!P_PhoneExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(p_Phone);
        }

        // POST: api/P_Phone
        [ResponseType(typeof(P_Phone))]
        public IHttpActionResult PostP_Phone(P_Phone p_Phone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.P_Phones.Add(p_Phone);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = p_Phone.ID }, p_Phone);
        }

        // DELETE: api/P_Phone/5
        [ResponseType(typeof(P_Phone))]
        [HttpPost]
        public IHttpActionResult DeleteP_Phone(long id)
        {
            P_Phone p_Phone = db.P_Phones.Find(id);
            if (p_Phone == null)
            {
                return NotFound();
            }

            db.P_Phones.Remove(p_Phone);
            db.SaveChanges();

            return Ok(p_Phone);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool P_PhoneExists(long id)
        {
            return db.P_Phones.Count(e => e.ID == id) > 0;
        }
    }
}